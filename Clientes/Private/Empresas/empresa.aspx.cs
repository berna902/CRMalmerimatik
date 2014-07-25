﻿using Clientes.ServicioDatos2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clientes.Private.Empresas
{
    public partial class empresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //SrvDatosClient proxy = new SrvDatosClient();
            if (!this.IsPostBack)
            {
                String s = Request.QueryString["estado"];
                String id = Request.QueryString["id"];
                try
                {
                    int estado;
                    int idEmpresa;

                    estado = -1;
                    idEmpresa = -1;
                    if (s != null)
                        estado = Int32.Parse(s);
                    //si estado es igual a 0 es para dar de alta una empresa nueva. Si es 1, es para modificar una empresa.
                    if (id != null)
                        idEmpresa = Int32.Parse(id);

                    SrvDatosClient proxy = new SrvDatosClient();
                    
                    TipoEmpresaData[] tiposEmpresas = proxy.GetAllTiposEmpresa();

                    switch (estado)
                    {
                        case 0:
                            this.lbIDEmpresa.Visible = false;
                            this.tbIDEmpresa.Visible = false;
                            this.H1Titulo.InnerHtml = "Alta de empresa";
                            this.btAlta.Text = "Alta";
                            this.btAlta.Visible = true;

                            //TipoEmpresaData[] tiposEmpresas = proxy.GetAllTiposEmpresa();

                            tbTipoEMpresa.DataSource = tiposEmpresas;
                            tbTipoEMpresa.DataValueField = "ID";
                            tbTipoEMpresa.DataTextField = "Tipo";
                            formularioTelefonos.Visible = false;
                            tbTipoEMpresa.DataBind();

                            break;

                        case 1:
                            this.lbIDEmpresa.Visible = true;
                            this.tbIDEmpresa.Visible = true;
                            this.tbIDEmpresa.ReadOnly = true;
                            this.H1Titulo.InnerHtml = "Modificar empresa";
                            this.btAlta.Text = "Guardar";
                            this.btAlta.Visible = true;

                            EmpresaData empresa = proxy.GetEmpresa(idEmpresa);

                            tbTipoEMpresa.DataSource = tiposEmpresas;
                            tbTipoEMpresa.DataValueField = "ID";
                            tbTipoEMpresa.DataTextField = "Tipo";
                            tbTipoEMpresa.SelectedValue = empresa.IDTipoEmpresa.ToString();
                            tbTipoEMpresa.DataBind();

                            TelefonosData[] telefonos = proxy.GetAllTelefonosEmpresa(idEmpresa);
                            tbTelefonos.DataSource = telefonos;
                            tbTelefonos.DataValueField = "Telefono";
                            tbTelefonos.DataTextField = "Telefono";
                            tbTelefonos.DataBind();

                            this.tbCIF.Text = empresa.CIF;
                            this.tbEmail.Text = empresa.Email;
                            this.tbIDEmpresa.Text = idEmpresa.ToString();
                            this.tbNombre.Text = empresa.Nombre;
                            this.tbRazonSocial.Text = empresa.RazonSocial;
                            this.tbWeb.Text = empresa.Web;


                            ContactoData[] contactos = proxy.GetAllContactosEmpresa(idEmpresa);

                            this.GridView1.DataSource = contactos;
                            this.GridView1.DataBind();
                            //this.tbTipoEMpresa.Text = empresa.TipoEmpresa;
                            break;
                       
                        default:
                            Response.Redirect("Default.aspx");
                            break;
                    }

                }
                catch (Exception ex) { }
            }
            else
            {
            }
        }

        protected void btAlta_Click(object sender, EventArgs e)
        {
            try
            {
                SrvDatosClient proxy = new SrvDatosClient();
                String s = Request.QueryString["estado"];
                int estado = -1;
                if (s != null)
                    estado = Int32.Parse(s);
                switch (estado)
                {
                    case 0:
                        EmpresaData empresa = new EmpresaData();
                        empresa.Nombre = tbNombre.Text;
                        empresa.IDTipoEmpresa = Int32.Parse(tbTipoEMpresa.SelectedValue);
                        empresa.RazonSocial = tbRazonSocial.Text;
                        empresa.CIF = tbCIF.Text;
                        empresa.Email = tbEmail.Text;
                        empresa.Web = tbWeb.Text;
                        if(proxy.AddEmpresa(empresa)!=-1){
                            Response.Redirect("Default.aspx");
                            //string script = "alert('No se pudo modificar la empresa');";
                            //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                        }else{
                            string script = "alert('No se pudo insertar la empresa');";
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                        }

                        break;

                    case 1:
                        EmpresaData empresa2 = new EmpresaData();
                        empresa2.ID = Int32.Parse(tbIDEmpresa.Text);
                        empresa2.Nombre = tbNombre.Text;
                        empresa2.IDTipoEmpresa = Int32.Parse(tbTipoEMpresa.SelectedValue);
                        empresa2.RazonSocial = tbRazonSocial.Text;
                        empresa2.CIF = tbCIF.Text;
                        empresa2.Email = tbEmail.Text;
                        empresa2.Web = tbWeb.Text;
                        if (proxy.EditEmpresa(empresa2))
                        {
                            string script = "alert('Empresa modificada con exito');";
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                        }
                        else {
                            string script = "alert('No se pudo modificar la empresa');";
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex) { }
        }

        protected void btAddTelf_Click(object sender, EventArgs e)
        {
            SrvDatosClient proxy = new SrvDatosClient();
            TelefonosData telefono = new TelefonosData();
            telefono.ID = Int32.Parse(tbIDEmpresa.Text);
            telefono.Telefono = tbTelefono.Text;
            proxy.AddTelefonoEmpresa(telefono);
            //llamar al servicio para que inserte el telefono nuevo. aun no está hecho T_T
            tbTelefonos.Items.Add(new ListItem(tbTelefono.Text, tbTelefono.Text));
            tbTelefono.DataBind();
            tbTelefono.Text = "";

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = e.Values["id"].ToString();
            SrvDatosClient proxy = new SrvDatosClient();
           
            proxy.BorrarEmpresa(Int32.Parse(id));

            this.GridView1.DataSource = proxy.GetAllEmpresas();
            this.GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            string idu = this.GridView1.Rows[e.NewEditIndex].Cells[0].Text;
            string id = this.GridView1.Rows[e.NewEditIndex].Cells[1].Text;
            this.Response.Redirect("GContactos.aspx?estado=1&idU=" + idu+"&id="+id);
        }

        protected void btnDeleteTelf_Click(object sender, EventArgs e)
        {
            SrvDatosClient proxy = new SrvDatosClient();
            proxy.BorrarTelefonoEmpresa(tbTelefonos.SelectedValue);

            TelefonosData[] telefonos = proxy.GetAllTelefonosEmpresa(Int32.Parse(tbIDEmpresa.Text));
            tbTelefonos.DataSource = telefonos;
            tbTelefonos.DataValueField = "Telefono";
            tbTelefonos.DataTextField = "Telefono";
            tbTelefonos.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int idEmpresa;
            String id = Request.QueryString["id"];
            idEmpresa = -1;
            
            if (id != null)
                idEmpresa = Int32.Parse(id);

            SrvDatosClient proxy = new SrvDatosClient();
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataSource = proxy.GetAllContactosEmpresa(idEmpresa);
            this.GridView1.DataBind();
        }

        protected void validar_CIF(object source, ServerValidateEventArgs args)
        {

        }
    }
}
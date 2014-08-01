using Clientes.ServicioDatos2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clientes.Private.Empresas
{
    public partial class GContactos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                String s = Request.QueryString["estado"];
                String id = Request.QueryString["id"];
                String idU = Request.QueryString["idU"];
                try
                {
                    int estado;
                    int idEmpresa;
                    int idUsuario;

                    estado = -1;
                    idEmpresa = -1;
                    idUsuario = -1;
                    if (s != null)
                        estado = Int32.Parse(s);
                    //si estado es igual a 0 es para dar de alta una empresa nueva. Si es 1, es para modificar una empresa.
                    if (id != null)
                        idEmpresa = Int32.Parse(id);

                    if (idU != null)
                        idUsuario = Int32.Parse(idU);


                    SrvDatosClient proxy = new SrvDatosClient();

                    switch (estado)
                    {
                        case 0:
                            this.lbIDUsuario.Visible = false;
                            this.tbIDUsuario.Visible = false;           
                            this.H1Titulo.InnerHtml = "Nuevo contacto";
                            this.btnAltaContacto.Text = "Alta";
                            this.btnAltaContacto.Visible = true;

                            EmpresaData[] empresas = proxy.GetAllEmpresas();

                            tbEmpresa.DataSource = empresas;
                            tbEmpresa.DataValueField = "ID";
                            tbEmpresa.DataTextField = "Nombre";
                            tbEmpresa.SelectedValue = empresas[0].ID.ToString();
                            tbEmpresa.DataBind();

                            //this.formularioTelefonos.Visible = false;

                            CargoData[] cargos = proxy.GetAllCargos();
                            tbCargos.DataSource = cargos;
                            tbCargos.DataValueField = "ID";
                            tbCargos.DataTextField = "Cargo";
                            tbCargos.SelectedValue = cargos[0].ID.ToString();
                            tbCargos.DataBind();

                            break;

                        case 1:
                            this.lbIDUsuario.Visible = true;
                            this.tbIDUsuario.Visible = true;
                            this.tbIDUsuario.ReadOnly = true;
                            this.H1Titulo.InnerHtml = "Modificar contacto";
                            this.btnAltaContacto.Text = "Guardar";
                            this.btnAltaContacto.Visible = true;

                            ContactoData usuario = proxy.GetContacto(idUsuario);

                            tbIDUsuario.Text = usuario.ID.ToString();
                            tbNombre.Text = usuario.Nombre;
                            tbEmail.Text = usuario.Email;

                            TelefonosData[] telefonos = proxy.GetAllTelefonosContacto(idUsuario);
                            if (telefonos.Length > 0)
                            {
                                tbTelefonos.DataSource = telefonos;
                                tbTelefonos.DataValueField = "Telefono";
                                tbTelefonos.DataTextField = "Telefono";
                                tbTelefonos.DataBind();
                            }

                            EmpresaData[] empresas2 = proxy.GetAllEmpresas();

                            tbEmpresa.DataSource = empresas2;
                            tbEmpresa.DataValueField = "ID";
                            tbEmpresa.DataTextField = "Nombre";
                            tbEmpresa.SelectedValue = usuario.IDEmpresa.ToString();
                            tbEmpresa.DataBind();

                            CargoData[] cargos2 = proxy.GetAllCargos();
                            tbCargos.DataSource = cargos2;
                            tbCargos.DataValueField = "ID";
                            tbCargos.DataTextField = "Cargo";
                            //usuario.Cargo = "Gerente";
                            tbCargos.DataBind();

                            ListItem selectedListItem = tbCargos.Items.FindByText(usuario.Cargo);

                            if (selectedListItem != null)
                            {
                                selectedListItem.Selected = true;
                            };

                            //tbCargos.SelectedValue = tbCargos.Items.FindByText(usuario.Cargo).Value;
                            

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

        protected void btAddTelf_Click(object sender, EventArgs e)
        {
            SrvDatosClient proxy = new SrvDatosClient();
            TelefonosData telefono = new TelefonosData();
            telefono.ID = Int32.Parse(tbIDUsuario.Text);
            telefono.Telefono = tbTelefono.Text;
            String s = Request.QueryString["estado"];
            int estado = -1;
            if (s != null)
               estado = Int32.Parse(s);
            if(estado==1)
                proxy.AddTelefonoContacto(telefono);
            //llamar al servicio para que inserte el telefono nuevo. aun no está hecho T_T
            tbTelefonos.Items.Add(new ListItem(tbTelefono.Text, tbTelefono.Text));
            tbTelefono.DataBind();
            tbTelefono.Text = "";
        }

        protected void btnAltaContacto_Click(object sender, EventArgs e)
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
                        ContactoData contacto = new ContactoData();

                        contacto.Email = tbEmail.Text;
                        contacto.IDEmpresa = Int32.Parse(tbEmpresa.SelectedValue);
                        contacto.Nombre = tbNombre.Text;
                        int id = proxy.AddContacto(contacto);
                        if (id != -1)
                        {
                        TelefonosData tel = new TelefonosData();
                        tel.ID = id;
                        for (int i = 0; i < tbTelefonos.Items.Count; i++ )
                        {
                            tel.Telefono = tbTelefonos.SelectedValue;
                            proxy.AddTelefonoContacto(tel);
                        }
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "<script type='text/javascript'> alert('CONTACTO INSERTADO'); </script>", false);
                            Response.Redirect("Default.aspx");
                            //string script = "alert('No se pudo modificar la empresa');";
                            //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                        }else{
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "<script type='text/javascript'> alert('ERROR AL INSERTAR'); </script>", false);
                            //string script = "alert('No se pudo insertar el contacto');";
                            //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                        }
                        break;

                    case 1:
                        ContactoData contacto2 = new ContactoData();
                        contacto2.ID = Int32.Parse(tbIDUsuario.Text);
                        contacto2.Email = tbEmail.Text;
                        contacto2.IDEmpresa = Int32.Parse(tbEmpresa.SelectedValue);
                        contacto2.Nombre = tbNombre.Text;
                        contacto2.Cargo = tbEmpresa.SelectedValue;
                        if (proxy.EditContacto(contacto2))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "<script type='text/javascript'> alert('CONTACTO MODIFICADO'); </script>", false);
                        }else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "<script type='text/javascript'> alert('ERROR AL MODIFICAR'); </script>", false);

                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex) { }
        }

        protected void btnEliminarTelf_Click(object sender, EventArgs e)
        {
            SrvDatosClient proxy = new SrvDatosClient();
            proxy.BorrarTelefonoContacto(tbTelefonos.SelectedValue);

            TelefonosData[] telefonos = proxy.GetAllTelefonosContacto(Int32.Parse(tbIDUsuario.Text));
            tbTelefonos.DataSource = telefonos;
            tbTelefonos.DataValueField = "Telefono";
            tbTelefonos.DataTextField = "Telefono";
            tbTelefonos.DataBind();
        }
    }
}
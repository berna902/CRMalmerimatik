using Clientes.ServicioDatos2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clientes.Private.Usuarios
{
    public partial class usuarios : System.Web.UI.Page
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
                    int idUsuario;

                    estado = -1;
                    idUsuario = -1;
                    if (s != null)
                        estado = Int32.Parse(s);
                    //si estado es igual a 0 es para dar de alta una empresa nueva. Si es 1, es para modificar una empresa.
                    if (id != null)
                        idUsuario = Int32.Parse(id);

                    SrvDatosClient proxy = new SrvDatosClient();

                    TipoEmpresaData[] tiposEmpresas = proxy.GetAllTiposEmpresa();

                    switch (estado)
                    {
                        case 0:
                            this.lbID.Visible = false;
                            this.tbID.Visible = false;
                            this.H1Titulo.InnerHtml = "Alta de usuario";
                            this.btnAlta.Text = "Alta";
                            this.btnAlta.Visible = true;

                            break;

                        case 1:
                            this.lbID.Visible = true;
                            this.tbID.Visible = true;
                            this.tbID.ReadOnly = true;
                            this.H1Titulo.InnerHtml = "Modificar usuario";
                            this.btnAlta.Text = "Guardar";
                            this.btnAlta.Visible = true;

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

        protected void btnAlta_Click(object sender, EventArgs e)
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
                        UserData usuario = new UserData();
                        usuario.Nombre = tbNombre.Text;
                        usuario.Username = tbUsername.Text;
                        usuario.Password = tbPassword.Text;
                        
                        if (proxy.ad(usuario) != -1)
                        {
                            Response.Redirect("Default.aspx");
                            
                        }
                        else
                        {
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
                        else
                        {
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
    }
}
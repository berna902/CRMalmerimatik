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
                            this.lbIDEmpresa.Visible = false;
                            this.tbIDEmpresa.Visible = false;           
                            this.H1Titulo.InnerHtml = "Alta de Usuario";
                            this.btnAltaContacto.Text = "Alta";
                            this.btnAltaContacto.Visible = true;
                            break;

                        case 1:
                            this.lbIDEmpresa.Visible = true;
                            this.tbIDEmpresa.Visible = true;
                            this.tbIDEmpresa.ReadOnly = true;
                            this.H1Titulo.InnerHtml = "Modificar usuario";
                            this.btnAltaContacto.Text = "Guardar";
                            this.btnAltaContacto.Visible = true;

                           
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
            telefono.ID = Int32.Parse(tbIDEmpresa.Text);
            telefono.Telefono = tbTelefono.Text;
            proxy.AddTelefonoEmpresa(telefono);
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
                        

                        break;

                    case 1:
                       
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex) { }
        }
    }
}
using Clientes.ServicioDatos2;
using System;
using System.Collections;
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
                            
                            UserData usuario = proxy.GetUser(idUsuario);
                            this.tbID.Text = id;
                            this.tbNombre.Text = usuario.Nombre;
                            this.tbUsername.Text = usuario.Username;
                            break;
                        default:
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
                UserData usuario = new UserData();
                switch (estado)
                {
                    case 0:

                        
                        usuario.Nombre = tbNombre.Text;
                        usuario.Username = tbUsername.Text;
                        usuario.Password = tbPassword.Text;
                        
                        if (proxy.AddUser(usuario) != -1)
                        {
                            //ArrayList historial = new ArrayList();
                            //historial = (ArrayList)Session["historial"];
                            //historial.Add("Usuario insertado");
                            Response.Redirect("Default.aspx");
                            
                        }
                        else
                        {
                            string script = "alert('No se pudo insertar el usuario');";
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                        }

                        break;

                    case 1:
                        //UserData usuario = new UserData();
                        usuario.IDUsuario = Int32.Parse(tbID.Text);
                        usuario.Nombre = tbNombre.Text;
                        usuario.Username = tbUsername.Text;
                        usuario.Password = tbPassword.Text;
                        
                        if (proxy.EditUser(usuario))
                        {
                            //ArrayList historial = new ArrayList();
                            //historial = (ArrayList)Session["historial"];
                            //historial.Add("Usuario modificado");
                            string script = "alert('Usuario modificado');";
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                            
                        }
                        else
                        {
                            string script = "alert('No se pudo modificar el usuario');";
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
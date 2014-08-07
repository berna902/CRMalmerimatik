using Clientes.Models;
using Clientes.ServicioDatos2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clientes
{
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Private/Default.aspx");
            }
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                SrvDatosClient proxy = new SrvDatosClient();
                
                UserData usuario = new UserData();
                usuario.Nombre = tbNombre.Text;
                usuario.Username = tbUsername.Text;
                usuario.Password = tbPassword.Text;

                if(!proxy.ExisteUser(usuario)){
                    if (proxy.AddUser(usuario) != -1)
                    {

                        List<Clientes.Models.ERROR> historial = new List<Clientes.Models.ERROR>();
                        historial = (List<Clientes.Models.ERROR>)Session["historial"];

                        ERROR err = new ERROR(0, "Usuario insertado con exito.");
                        historial.Add(err);
                        Session["historial"] = historial;

                        Response.Redirect("Default.aspx");

                    }
                    else
                    {
                        List<Clientes.Models.ERROR> historial = new List<Clientes.Models.ERROR>();
                        historial = (List<Clientes.Models.ERROR>)Session["historial"];

                        ERROR err = new ERROR(0, "ERROR al insertar usuario.");
                        historial.Add(err);
                        Session["historial"] = historial;

                        string script = "alert('No se pudo insertar el usuario');";
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "<script type='text/javascript'> alert('ERROR. EL USUARIO YA EXISTE');</script>", false);
                }
  
            }
            catch (Exception ex) { }
        }
    }
}
using Clientes.ServicioDatos2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clientes
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Private/Default.aspx");
            }
        }

        protected void Entrar(object sender, AuthenticateEventArgs e)
        {
            SrvDatosClient proxy = new SrvDatosClient();
            bool entrar = proxy.ValidaUser(this.Login1.UserName, this.Login1.Password);

            if (entrar)
            {
                //te envia a la pagina que quieres entrar
                FormsAuthentication.RedirectFromLoginPage(this.Login1.UserName, false);
                e.Authenticated = true;
                
            }
            else
            {
                e.Authenticated = false;
                this.Login1.FailureText = "Usuario o Contraseña Incorrecta";
            }


        }
    }
}
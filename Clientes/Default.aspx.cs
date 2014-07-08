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

        }

        protected void Entrar(object sender, AuthenticateEventArgs e)
        {
            
            //te envia a la pagina que quieres entrar
            FormsAuthentication.RedirectFromLoginPage(this.Login1.UserName, false);
            e.Authenticated = true;
            Response.Redirect("~/Private/Default.aspx");


        }
    }
}
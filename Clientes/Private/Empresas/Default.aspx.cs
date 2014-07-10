using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Clientes.Private.Empresas
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //ServicioDatos proxy = new ServicioDatos();

                /*string username = (string)Session["user"];
                string pass = (string)Session["pass"];

                proxy.ClientCredentials.UserName.UserName = username;
                proxy.ClientCredentials.UserName.Password = pass;
                proxy.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;

                LibroData[] libros = proxy.GetAllLibros();
                this.GridView1.DataSource = libros;
                this.GridView1.DataBind();*/

            }
        }
    }
}
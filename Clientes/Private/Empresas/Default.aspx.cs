using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServicioCRM;
using Clientes.ServicioDatos2;

namespace Clientes.Private.Empresas
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                SrvDatosClient proxy = new SrvDatosClient();

                EmpresaData[] empresas =  proxy.GetAllEmpresas();

                this.GridView1.DataSource = empresas;
                this.GridView1.DataBind();

            }
        }
    }
}
using Clientes.ServicioDatos2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clientes.Private.Acciones
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                SrvDatosClient proxy = new SrvDatosClient();

                AccionComercialData[] acciones = proxy.GetAllAccionesComerciales();

                this.GridView1.DataSource = acciones;
                this.GridView1.DataBind();

            }
        }
    }
}
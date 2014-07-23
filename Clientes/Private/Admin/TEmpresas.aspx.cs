using Clientes.ServicioDatos2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clientes.Private.Admin
{
    public partial class TEmpresas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btAlta_Click(object sender, EventArgs e)
        {
            SrvDatosClient proxy = new SrvDatosClient();
            proxy.AddTipoEmpresa(tbTipo.Text);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "<script type='text/javascript'> alert('SE HA INSERTADO CORRECTAMENTE'); parent.$.fancybox.close();</script>", false);

        }
    }
}
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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = e.Values["id"].ToString();

            SrvDatosClient proxy = new SrvDatosClient();

            //proxy.BorrarEmpresa(Int32.Parse(id));

            this.GridView1.DataSource = proxy.GetAllAccionesComerciales();
            this.GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string id = this.GridView1.Rows[e.NewEditIndex].Cells[0].Text;
            this.Response.Redirect("acciones.aspx?estado=1&id=" + id);
        }
    }
}
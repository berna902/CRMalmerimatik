using Clientes.ServicioDatos2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clientes.Private.Usuarios
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                SrvDatosClient proxy = new SrvDatosClient();

                UserData[] usuarios = proxy.GetAllUsers();

                this.GridView1.DataSource = usuarios;
                this.GridView1.DataBind();

            }
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string id = this.GridView1.Rows[e.NewEditIndex].Cells[0].Text;
            this.Response.Redirect("usuarios.aspx?estado=1&id=" + id);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = e.Values["idUsuario"].ToString();

            SrvDatosClient proxy = new SrvDatosClient();

            proxy.BorrarUser(Int32.Parse(id));

            this.GridView1.DataSource = proxy.GetAllUsers();
            this.GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SrvDatosClient proxy = new SrvDatosClient();
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataSource = proxy.GetAllUsers();
            this.GridView1.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            SrvDatosClient proxy = new SrvDatosClient();
            UserData[] usuarios = proxy.BusquedaAvanzadaUser(tbNombre.Text, tbUsername.Text);

            this.GridView1.DataSource = usuarios;
            this.GridView1.DataBind();
        }

    }
}
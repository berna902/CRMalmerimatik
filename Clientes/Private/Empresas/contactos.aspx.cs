using Clientes.Models;
using Clientes.ServicioDatos2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clientes.Private.Empresas
{
    public partial class contactos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                SrvDatosClient proxy = new SrvDatosClient();

                ContactoData[] contactos = proxy.GetAllContactos();

                this.GridView1.DataSource = contactos;
                this.GridView1.DataBind();
                
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = e.Values["ID"].ToString();
            SrvDatosClient proxy = new SrvDatosClient();
            
            proxy.BorrarContacto(Int32.Parse(id));

            this.GridView1.DataSource = proxy.GetAllContactos();
            this.GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string idu = this.GridView1.Rows[e.NewEditIndex].Cells[0].Text;
            string id = this.GridView1.Rows[e.NewEditIndex].Cells[1].Text;
            this.Response.Redirect("GContactos.aspx?estado=1&idU=" + idu + "&id=" + id);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SrvDatosClient proxy = new SrvDatosClient();
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataSource = proxy.GetAllContactos();
            this.GridView1.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            SrvDatosClient proxy = new SrvDatosClient();
            ContactoData[] contactos = proxy.BusquedaAvanzadaContacto(tbNombre.Text, tbEmail.Text);

            this.GridView1.DataSource = contactos;
            this.GridView1.DataBind();
        }
    }
}
﻿using System;
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

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string id = this.GridView1.Rows[e.NewEditIndex].Cells[0].Text;
            this.Response.Redirect("empresa.aspx?estado=1&id=" + id);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = e.Values["id"].ToString();

            SrvDatosClient proxy = new SrvDatosClient();

            proxy.BorrarEmpresa(Int32.Parse(id));

            this.GridView1.DataSource = proxy.GetAllEmpresas();
            this.GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SrvDatosClient proxy = new SrvDatosClient();
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataSource = proxy.GetAllEmpresas();
            this.GridView1.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            SrvDatosClient proxy = new SrvDatosClient();
            EmpresaData[] empresas = proxy.BusquedaAvanzadaEmpresa(tbNombre.Text,tbRazonSocial.Text,tbCIF.Text,tbEmail.Text, tbWeb.Text);

            this.GridView1.DataSource = empresas;
            this.GridView1.DataBind();
        }


    }
}
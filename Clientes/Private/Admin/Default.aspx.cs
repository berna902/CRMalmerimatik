﻿using Clientes.ServicioDatos2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clientes.Private.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                SrvDatosClient proxy = new SrvDatosClient();

                TipoEmpresaData[] tiposEmpresas = proxy.GetAllTiposEmpresa();
                this.GridView1.DataSource = tiposEmpresas;
                this.GridView1.DataBind();

                TipoAccionData[] tiposAcciones = proxy.GetAllTiposAccion();
                this.GridView2.DataSource = tiposAcciones;
                this.GridView2.DataBind();

                CargoData[] cargos = proxy.GetAllCargos();
                this.GridView3.DataSource = cargos;
                this.GridView3.DataBind();

                EstadoData[] estados = proxy.GetAllEstados();
                this.GridView4.DataSource = estados;
                this.GridView4.DataBind();
                

            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string id = this.GridView1.Rows[e.NewEditIndex].Cells[0].Text;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "<script type='text/javascript'> alert('SE HA INSERTADO CORRECTAMENTE'); parent.$.fancybox.close();</script>", false);
            //this.Response.Redirect("GContactos.aspx?estado=1&idU=" + idu + "&id=" + id);

            string script = @"<script type=""text/javascript"">$(document).ready(function() {$(""#termsandConditions"").fancybox({'transitionIn':'elastic','transitionOut':'elastic','speedIn':600,'speedOut':200,'overlayShow':false,'overlayOpacity': 0.5,'width':800,'href':""/Contents/Common/EN/TermandConditions.aspx""}).trigger('click');});</script>";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;

            if (!cs.IsStartupScriptRegistered(cstype, script))
            {
                cs.RegisterStartupScript(cstype, "fancybox", script);
            }

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = e.Values["ID"].ToString();
            SrvDatosClient proxy = new SrvDatosClient();

            proxy.BorrarTipoEmpresa(Int32.Parse(id));
            
            this.GridView1.DataSource = proxy.GetAllTiposEmpresa();
            this.GridView1.DataBind();
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = e.Values["ID"].ToString();
            SrvDatosClient proxy = new SrvDatosClient();

            proxy.BorrarTipoAccion(Int32.Parse(id));

            this.GridView1.DataSource = proxy.GetAllTiposAccion();
            this.GridView1.DataBind();
        }

        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = e.Values["ID"].ToString();
            SrvDatosClient proxy = new SrvDatosClient();

            proxy.BorrarCargo(Int32.Parse(id));

            this.GridView1.DataSource = proxy.GetAllCargos();
            this.GridView1.DataBind();
        }


        protected void GridView4_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = e.Values["ID"].ToString();
            SrvDatosClient proxy = new SrvDatosClient();

            proxy.BorrarEstado(Int32.Parse(id));

            this.GridView1.DataSource = proxy.GetAllEstados();
            this.GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SrvDatosClient proxy = new SrvDatosClient();
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataSource = proxy.GetAllTiposEmpresa();
            this.GridView1.DataBind();
        }

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SrvDatosClient proxy = new SrvDatosClient();
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataSource = proxy.GetAllCargos();
            this.GridView1.DataBind();
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SrvDatosClient proxy = new SrvDatosClient();
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataSource = proxy.GetAllTiposAccion();
            this.GridView1.DataBind();
        }

        protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SrvDatosClient proxy = new SrvDatosClient();
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataSource = proxy.GetAllEstados();
            this.GridView1.DataBind();
        }



       
    }
}
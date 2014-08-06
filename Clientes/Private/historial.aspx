<%@ Page Title="" Language="C#" MasterPageFile="~/Private/Maestra.Master" AutoEventWireup="true" CodeBehind="historial.aspx.cs" Inherits="Clientes.Private.historial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu_lateral" runat="server">
    <ul class="nav nav-sidebar">
            <li class="active"><a href="Default.aspx">Resumen</a></li>
            <li><a href="Empresas/Default.aspx">Gestión Empresas</a></li>
            <li><a href="Usuarios/Default.aspx">Gestión Usuarios</a></li>
            <li><a href="Acciones/Default.aspx">Gestión Acciones</a></li>
            <li><a href="Admin/Default.aspx">Administración</a></li>
          </ul>
          <ul class="nav nav-sidebar">
            <li class="active historial"><a href="historial.aspx">Historial</a></li>

          </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="central" runat="server">
    <h1 class="page-header">Historial</h1>
    <div id="historial">
        <% 
            List<Clientes.Models.ERROR> historial = new List<Clientes.Models.ERROR>();
            
            if (Session["historial"] != null) {
                historial = (List<Clientes.Models.ERROR>)Session["historial"];

                foreach (Clientes.Models.ERROR error in historial) { 
                    //0 no hay errores, 1 hay error
                    if (error.cod == 0) { 
                     %>
                    <div class="alert alert-success" role="alert">
                        <%
                        Response.Write(error.msg);
                        %>
                        
                    </div>
                    <%
                    }else if (error.cod == 1){
                                             %>
                    <div class="alert alert-danger" role="alert">
                        <%
                        Response.Write(error.msg);
                        %>
                        
                    </div>
                    <%
                    }
                }
           } %>
    </div>
</asp:Content>

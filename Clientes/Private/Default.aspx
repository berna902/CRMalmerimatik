<%@ Page Title="" Language="C#" MasterPageFile="~/Private/Maestra.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Clientes.Private.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu_lateral" runat="server">
          <ul class="nav nav-sidebar">
            <li class="active"><a href="Default.aspx">Resumen</a></li>
            <li><a href="Empresas/Default.aspx">Gestión Empresas</a></li>
            <li><a href="#">Gestión Usuarios</a></li>
            <li><a href="#">Gestión Acciones</a></li>
            <li><a href="#">Administración</a></li>
          </ul>
          <ul class="nav nav-sidebar">
            <li class="active historial"><a href="#">Historial</a></li>

          </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="central" runat="server">
    <h1 class="page-header">Notificaciones</h1>

    <div class="row placeholders notificaciones">
        No hay notificaciones.
    </div>

    <h2 class="sub-header">Resumen empresas</h2>
    No hay datos disponibles
    <h2 class="sub-header">Resumen usuarios</h2>
    No hay datos disponibles
    <h2 class="sub-header">Resumen acciones</h2>
    No hay datos disponibles
</asp:Content>

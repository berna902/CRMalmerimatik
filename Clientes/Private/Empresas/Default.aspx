﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Private/Maestra.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Clientes.Private.Empresas.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu_lateral" runat="server">
    <ul class="nav nav-sidebar">
        <li><a href="../Default.aspx">Resumen</a></li>
        <li class="active"><a href="Default.aspx">Gestión Empresas</a></li>
        <li><a href="#">Gestión Usuarios</a></li>
        <li><a href="#">Gestión Acciones</a></li>
        <li><a href="#">Administración</a></li>
    </ul>
    <ul class="nav nav-sidebar">
        <li class="active historial"><a href="#">Historial</a></li>

    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="central" runat="server">
     <h1 class="page-header">Gestión de empresas</h1>

    <div class="row placeholders">
        <div class="table-responsive">
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped"></asp:GridView>
        </div>
    </div>
</asp:Content>
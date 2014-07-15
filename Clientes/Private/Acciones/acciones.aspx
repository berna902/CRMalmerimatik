﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Private/Maestra.Master" AutoEventWireup="true" CodeBehind="acciones.aspx.cs" Inherits="Clientes.Private.Acciones.acciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu_lateral" runat="server">
    <ul class="nav nav-sidebar">
        <li><a href="../Default.aspx">Resumen</a></li>
        <li><a href="../Empresas/Default.aspx">Gestión Empresas</a></li>
        <li><a href="../Usuarios/Default.aspx">Gestión Usuarios</a></li>
        <li class="active"><a href="Default.aspx">Gestión Acciones</a></li>
        <li><a href="../Admin/Default.aspx">Administración</a></li>
    </ul>
    <ul class="nav nav-sidebar">
        <li class="active historial"><a href="#">Historial</a></li>

    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="central" runat="server">

    <h1>Nueva acción</h1>

    <div class="col-md-12">
        <div class="form-group">
            <asp:Label CssClass="control-label" Text="Usuario" ID="lbUsuario" runat="server" AssociatedControlID="tbUsuario"></asp:Label>

             <asp:DropDownList ID="tbUsuario" runat="server" CssClass="form-control">
                <asp:ListItem Value="1">S.L.</asp:ListItem>
            </asp:DropDownList>

        </div>

        <div class="form-group">
            <asp:Label CssClass="control-label" Text="Fecha" ID="lbFecha" runat="server" AssociatedControlID="tbFecha"></asp:Label>

            <asp:TextBox ID="tbFecha" runat="server" CssClass="form-control"></asp:TextBox>

        </div>

        <div class="form-group">
            <asp:Label CssClass="control-label" Text="Descripción" ID="lbDescripcion" runat="server" AssociatedControlID="tbDescripcion"></asp:Label>

            <asp:TextBox ID="tbDescripcion" runat="server" CssClass="form-control" placeholder="Descripción de la acción"></asp:TextBox>

        </div>


        <div class="form-group">
            <asp:Label CssClass="control-label" Text="Email" ID="lbComentarios" runat="server" AssociatedControlID="tbComentarios"></asp:Label>

            <asp:TextBox ID="tbComentarios" runat="server" CssClass="form-control" placeholder="Introduce un comentario.."></asp:TextBox>

        </div>

        <div class="form-group">
            <asp:Label CssClass="control-label" Text="Tipo de acción" ID="lbTipoAccion" runat="server" AssociatedControlID="tbTipoAccion"></asp:Label>

            <asp:DropDownList ID="tbTipoAccion" runat="server" CssClass="form-control">
                <asp:ListItem Value="1">S.L.</asp:ListItem>
            </asp:DropDownList>

        </div>
        <div class="form-group">
            <asp:Label CssClass="control-label" Text="Estado" ID="lbEstado" runat="server" AssociatedControlID="tbEstado"></asp:Label>

            <asp:DropDownList ID="tbEstado" runat="server" CssClass="form-control">
                <asp:ListItem Value="1">S.L.</asp:ListItem>
            </asp:DropDownList>

        </div>
        <div class="form-group">

                <asp:Button ID="Button1" runat="server" Text="Alta" CssClass="btn btn-primary" />

        </div>
    </div>
</asp:Content>
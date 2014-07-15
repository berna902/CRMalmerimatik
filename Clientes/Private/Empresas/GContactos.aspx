<%@ Page Title="" Language="C#" MasterPageFile="~/Private/Maestra.Master" AutoEventWireup="true" CodeBehind="GContactos.aspx.cs" Inherits="Clientes.Private.Empresas.GContactos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu_lateral" runat="server">
    <ul class="nav nav-sidebar">
        <li><a href="../Default.aspx">Resumen</a></li>
        <li class="active"><a href="Default.aspx">Gestión Empresas</a></li>
        <li><a href="../Usuarios/Default.aspx">Gestión Usuarios</a></li>
        <li><a href="../Acciones/Default.aspx">Gestión Acciones</a></li>
        <li><a href="../Admin/Default.aspx">Administración</a></li>
    </ul>
    <ul class="nav nav-sidebar">
        <li class="active historial"><a href="#">Historial</a></li>

    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="central" runat="server">

    <h1>Alta empresa</h1>

    <div class="col-md-12">
        <div class="form-group">
            <asp:Label CssClass="control-label" Text="ID de la Empresa" ID="lbIDEmpresa" runat="server" AssociatedControlID="tbIDEmpresa"></asp:Label>

            <asp:TextBox ID="tbIDEmpresa" runat="server" CssClass="form-control"></asp:TextBox>

        </div>

        <div class="form-group">
            <asp:Label CssClass="control-label" Text="Nombre" ID="lbNombre" runat="server" AssociatedControlID="tbNombre"></asp:Label>

            <asp:TextBox ID="tbNombre" runat="server" CssClass="form-control" placeholder="Nombre del contacto"></asp:TextBox>

        </div>

        <div class="form-group">
            <asp:Label CssClass="control-label" Text="Email" ID="lbEmail" runat="server" AssociatedControlID="tbEmail"></asp:Label>

            <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control" placeholder="Email del usuario.."></asp:TextBox>

        </div>


        <div class="form-group">

                <asp:Button ID="Button1" runat="server" Text="Alta" CssClass="btn btn-primary" />

        </div>
    </div>
</asp:Content>

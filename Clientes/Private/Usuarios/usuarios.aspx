<%@ Page Title="" Language="C#" MasterPageFile="~/Private/Maestra.Master" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="Clientes.Private.Usuarios.usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu_lateral" runat="server">
    <ul class="nav nav-sidebar">
        <li><a href="../Default.aspx">Resumen</a></li>
        <li><a href="../Empresas/Default.aspx">Gestión Empresas</a></li>
        <li class="active"><a href="Default.aspx">Gestión Usuarios</a></li>
        <li><a href="../Acciones/Default.aspx">Gestión Acciones</a></li>
        <li><a href="../Admin/Default.aspx">Administración</a></li>
    </ul>
    <ul class="nav nav-sidebar">
        <li class="active historial"><a href="#">Historial</a></li>

    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="central" runat="server">

    <h1 id="H1Titulo" runat="server">Alta usuario</h1>

    <div class="col-md-12">
        <div class="form-group">
            <asp:Label CssClass="control-label" Text="ID" ID="lbID" runat="server" AssociatedControlID="tbID"></asp:Label>

            <asp:TextBox ID="tbID" runat="server" CssClass="form-control" placeholder="ID del usuario"></asp:TextBox>

        </div>
        <div class="form-group">
            <asp:Label CssClass="control-label" Text="Nombre" ID="lbNombre" runat="server" AssociatedControlID="tbNombre"></asp:Label>

            <asp:TextBox ID="tbNombre" runat="server" CssClass="form-control" placeholder="Nombre del usuario"></asp:TextBox>

        </div>

        <div class="form-group">
            <asp:Label CssClass="control-label" Text="Username" ID="lbUsername" runat="server" AssociatedControlID="tbUsername"></asp:Label>

            <asp:TextBox ID="tbUsername" runat="server" CssClass="form-control" placeholder="Username del usuario"></asp:TextBox>

        </div>

        <div class="form-group">
            <asp:Label CssClass="control-label" Text="Password" ID="lbPassword" runat="server" AssociatedControlID="tbPassword"></asp:Label>

            <asp:TextBox ID="tbPassword" runat="server" CssClass="form-control" placeholder="Password del usuario"></asp:TextBox>

        </div>


        <div class="form-group">
            <asp:Label CssClass="control-label" Text="Repite el password" ID="lbPassword2" runat="server" AssociatedControlID="tbPassword2"></asp:Label>

            <asp:TextBox ID="tbpassword2" runat="server" CssClass="form-control" placeholder="Repite el password.."></asp:TextBox>

        </div>

        

        <div class="form-group">

             <asp:Button ID="btnAlta" runat="server" Text="Alta" CssClass="btn btn-primary" OnClick="btnAlta_Click" />

        </div>
    </div>
</asp:Content>

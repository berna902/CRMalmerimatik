<%@ Page Title="" Language="C#" MasterPageFile="~/Private/Maestra.Master" AutoEventWireup="true" CodeBehind="direccion.aspx.cs" Inherits="Clientes.Private.Empresas.direccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
        input:focus::-webkit-input-placeholder {
            color: transparent;
        }
    </style>
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
        <li class="active historial"><a href="../historial.aspx">Historial</a></li>
        
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="central" runat="server">
    <asp:ScriptManager runat="server" ID="scripmanager1"></asp:ScriptManager>
    <h1 id="H1Titulo" runat="server">Nueva dirección</h1>

    <div class="col-md-12">
        <div class="form-group">
            <asp:Label CssClass="control-label" Text="ID dirección" ID="lbIDireccion" runat="server" AssociatedControlID="tbIDireccion"></asp:Label>
            <asp:TextBox ID="tbIDireccion" runat="server" CssClass="form-control"></asp:TextBox>

        </div>
        <div class="form-group">
            <asp:Label CssClass="control-label" Text="Domicilio" ID="lbDomicilio" runat="server" AssociatedControlID="tbDomicilio"></asp:Label>
            <asp:TextBox ID="tbDomicilio" runat="server" CssClass="form-control" placeholder="c/nombre de la calle edificio piso"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Introduzca el domicilio." ControlToValidate="tbDomicilio" CssClass="label label-danger" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label CssClass="control-label" Text="Población" ID="lbPoblacion" runat="server" AssociatedControlID="tbPoblacion"></asp:Label>
            <asp:TextBox ID="tbPoblacion" runat="server" CssClass="form-control" placeholder="Población"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Introduzca la población." ControlToValidate="tbPoblacion" CssClass="label label-danger" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>

         <div class="form-group">
            <asp:Label CssClass="control-label" Text="Provincia" ID="lbProvincia" runat="server" AssociatedControlID="tbProvincia"></asp:Label>
            <asp:TextBox ID="tbProvincia" runat="server" CssClass="form-control" placeholder="Provincia"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Introduzca la provincia." ControlToValidate="tbProvincia" CssClass="label label-danger" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label CssClass="control-label" Text="CP" ID="lbCP" runat="server" AssociatedControlID="tbCP"></asp:Label>
            <asp:TextBox ID="tbCP" runat="server" CssClass="form-control" placeholder="Código postal"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Introduzca el código postal." ControlToValidate="tbCP" CssClass="label label-danger" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>


        <div class="form-group">

                <asp:Button ID="btnAltaDireccion" runat="server" Text="Alta" CssClass="btn btn-primary" OnClick="btnAltaDireccion_Click" />
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-info" PostBackUrl="~/Private/Empresas/Default.aspx">Volver</asp:LinkButton>
        </div>
    </div>
</asp:Content>

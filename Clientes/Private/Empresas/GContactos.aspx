<%@ Page Title="" Language="C#" MasterPageFile="~/Private/Maestra.Master" AutoEventWireup="true" CodeBehind="GContactos.aspx.cs" Inherits="Clientes.Private.Empresas.GContactos" %>
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
    <h1 id="H1Titulo" runat="server">Alta de contacto</h1>

    <div class="col-md-12">
        <div class="form-group">
            <asp:Label CssClass="control-label" Text="ID Usuario" ID="lbIDUsuario" runat="server" AssociatedControlID="tbIDUsuario"></asp:Label>
            <asp:TextBox ID="tbIDUsuario" runat="server" CssClass="form-control"></asp:TextBox>

        </div>
        <div class="form-group">
            <asp:Label CssClass="control-label" Text="Empresa" ID="lbEmpresa" runat="server" AssociatedControlID="tbEmpresa"></asp:Label>
            <asp:DropDownList ID="tbEmpresa" runat="server" CssClass="form-control" AutoPostBack="True">
                <asp:ListItem Value="1">-</asp:ListItem>
            </asp:DropDownList>

        </div>

        <div class="form-group">
            <asp:Label CssClass="control-label" Text="Nombre" ID="lbNombre" runat="server" AssociatedControlID="tbNombre"></asp:Label>
            <asp:TextBox ID="tbNombre" runat="server" CssClass="form-control" placeholder="Nombre del contacto"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Introduzca un nombre para el contacto." ControlToValidate="tbNombre" CssClass="label label-danger" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </div>

         <div class="form-group">
            <asp:Label CssClass="control-label" Text="Cargo" ID="lbCargo" runat="server" AssociatedControlID="tbCargos"></asp:Label>

            <asp:DropDownList ID="tbCargos" runat="server" CssClass="form-control" AutoPostBack="True">
                <asp:ListItem Value="1">-</asp:ListItem>
            </asp:DropDownList>

        </div>

        <div class="form-group">
            <asp:Label CssClass="control-label" Text="Email" ID="lbEmail" runat="server" AssociatedControlID="tbEmail"></asp:Label>
            <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control" placeholder="Email del usuario.."></asp:TextBox>

        </div>

        <div class="form-group" id="formularioTelefonos" runat="server">

                <asp:Label CssClass="control-label" Text="Telefonos" ID="Label1" runat="server" AssociatedControlID="tbTelefonos"></asp:Label>
                <div class="telefonos navbar-form">
                    <div class="form-group">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="tbTelefonos" runat="server" CssClass="form-control" AutoPostBack="True">
                                    <asp:ListItem Value="1">-</asp:ListItem>
                                </asp:DropDownList>
                        <asp:Button ID="btnEliminarTel" runat="server" Text="X" CssClass="btn btn-danger" OnClick="btnEliminarTelf_Click" />
                        <asp:TextBox ID="tbTelefono" runat="server" CssClass="form-control" placeholder="nuevo telefono"></asp:TextBox>
                        <asp:Button ID="btAddTelf" runat="server" Text="Añadir" CssClass="btn btn-success" OnClick="btAddTelf_Click" />
                                <div id="mcorrecto" class="alert alert-success hidden " role="alert" runat="server">Insertado!</div>
                                <div id="mfallo" class="alert alert-danger hidden" role="alert">ERROR!</div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btAddTelf" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>

        </div>

        <div class="form-group">

                <asp:Button ID="btnAltaContacto" runat="server" Text="Alta" CssClass="btn btn-primary" OnClick="btnAltaContacto_Click" />
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-info" PostBackUrl="~/Private/Empresas/Default.aspx" CausesValidation="False">Volver</asp:LinkButton>
        </div>
    </div>
</asp:Content>

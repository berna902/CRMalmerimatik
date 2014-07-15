<%@ Page Title="" Language="C#" MasterPageFile="~/Private/Maestra.Master" AutoEventWireup="true" CodeBehind="empresa.aspx.cs" Inherits="Clientes.Private.Empresas.empresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script>

        $(function(){
            $('#central_btAddTelf').click(function () {
                
                $('#central_mcorrecto').slideDown(1000);
            });

        });
        </script>

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
    <asp:ScriptManager runat="server" ID="scripmanager1"></asp:ScriptManager>
    <h1 id="H1Titulo" runat="server">Alta empresa</h1>

    <div class="col-md-12">
        <div class="form-group">
            <asp:Label CssClass="control-label" Text="ID de la Empresa" ID="lbIDEmpresa" runat="server" AssociatedControlID="tbIDEmpresa"></asp:Label>

            <asp:TextBox ID="tbIDEmpresa" runat="server" CssClass="form-control"></asp:TextBox>

        </div>
        <div class="form-group">
            <asp:Label CssClass="control-label" Text="CIF" ID="lbCIF" runat="server" AssociatedControlID="tbCIF"></asp:Label>

            <asp:TextBox ID="tbCIF" runat="server" CssClass="form-control" placeholder="CIF de la empresa"></asp:TextBox>

        </div>

        <div class="form-group">
            <asp:Label CssClass="control-label" Text="Razón Social" ID="lbRazonSocial" runat="server" AssociatedControlID="tbRazonSocial"></asp:Label>

            <asp:TextBox ID="tbRazonSocial" runat="server" CssClass="form-control" placeholder="Razón social de la empresa"></asp:TextBox>

        </div>

        <div class="form-group">
            <asp:Label CssClass="control-label" Text="Nombre" ID="lbNombre" runat="server" AssociatedControlID="tbNombre"></asp:Label>

            <asp:TextBox ID="tbNombre" runat="server" CssClass="form-control" placeholder="Introduce el nombre de la empresa"></asp:TextBox>

        </div>

        <div class="form-group">
            <asp:Label CssClass="control-label" Text="Web" ID="lbWeb" runat="server" AssociatedControlID="tbWeb"></asp:Label>

            <asp:TextBox ID="tbWeb" runat="server" CssClass="form-control" placeholder="web de la empresa"></asp:TextBox>

        </div>

        <div class="form-group">
            <asp:Label CssClass="control-label" Text="Email" ID="lbEmail" runat="server" AssociatedControlID="tbEmail"></asp:Label>

            <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control" placeholder="Introduce el email"></asp:TextBox>

        </div>

        <div class="form-group ">


                <asp:Label CssClass="control-label" Text="Telefonos" ID="Label1" runat="server" AssociatedControlID="tbTelefonos"></asp:Label>
                <div class="telefonos navbar-form">
                    <div class="form-group">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="tbTelefonos" runat="server" CssClass="form-control" AutoPostBack="True">
                                    <asp:ListItem Value="1">-</asp:ListItem>
                                </asp:DropDownList>

                        <asp:TextBox ID="tbTelefono" runat="server" CssClass="form-control" placeholder="nuevo telefono"></asp:TextBox>
                        <asp:Button ID="btAddTelf" runat="server" Text="Añadir" CssClass="btn btn-success" />
                                <div id="mcorrecto" class="alert alert-success hidden" role="alert" runat="server">Insertado!</div>
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
            <asp:Label CssClass="control-label" Text="Tipo de empresa" ID="lbTipoEmpresa" runat="server" AssociatedControlID="tbTipoEMpresa"></asp:Label>

            <asp:DropDownList ID="tbTipoEMpresa" runat="server" CssClass="form-control">
                <asp:ListItem Value="1">S.L.</asp:ListItem>
            </asp:DropDownList>

        </div>

        <div class="form-group">

            <asp:Button ID="btAlta" runat="server" Text="Alta" CssClass="btn btn-primary" OnClick="btAlta_Click" />

        </div>
    </div>
</asp:Content>

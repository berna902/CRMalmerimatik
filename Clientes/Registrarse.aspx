<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="Clientes.Registrarse" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <h1 id="H1Titulo" runat="server">Registrarse</h1>

            <div class="col-md-12">
                
                <div class="form-group">
                    <asp:Label CssClass="control-label" Text="Nombre" ID="lbNombre" runat="server" AssociatedControlID="tbNombre"></asp:Label>
                    <asp:TextBox ID="tbNombre" runat="server" CssClass="form-control" placeholder="Nombre del usuario"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Introduzca el nombre del usuario." ControlToValidate="tbNombre" CssClass="label label-danger" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <asp:Label CssClass="control-label" Text="Username" ID="lbUsername" runat="server" AssociatedControlID="tbUsername"></asp:Label>
                    <asp:TextBox ID="tbUsername" runat="server" CssClass="form-control" placeholder="Username del usuario"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Introduzca un username." ControlToValidate="tbUsername" CssClass="label label-danger" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <asp:Label CssClass="control-label" Text="Password" ID="lbPassword" runat="server" AssociatedControlID="tbPassword"></asp:Label>
                    <asp:TextBox ID="tbPassword" runat="server" CssClass="form-control" placeholder="Password del usuario"></asp:TextBox>
            
                </div>


                <div class="form-group">
                    <asp:Label CssClass="control-label" Text="Repite el password" ID="lbPassword2" runat="server" AssociatedControlID="tbPassword2"></asp:Label>
                    <asp:TextBox ID="tbpassword2" runat="server" CssClass="form-control" placeholder="Repite el password.."></asp:TextBox>
            
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Las contraseñas son distintas." ControlToCompare="tbPassword" ControlToValidate="tbpassword2" CssClass="label label-danger" SetFocusOnError="True"></asp:CompareValidator>
                </div>
                
                <div class="form-group">

                     <asp:Button ID="btnRegistro" runat="server" Text="Registrarse" CssClass="btn btn-primary" OnClick="btnRegistro_Click" />
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-info" PostBackUrl="~/Default.aspx" CausesValidation="False">Volver</asp:LinkButton>
                </div>
             </div>
        </div>
    </div>

</asp:Content>

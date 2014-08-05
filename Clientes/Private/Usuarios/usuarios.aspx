<%@ Page Title="" Language="C#" MasterPageFile="~/Private/Maestra.Master" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="Clientes.Private.Usuarios.usuarios" %>
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

                <div class="table-responsive">
            <!--<asp:GridView ID="GridView2" runat="server" CssClass="table table-striped"></asp:GridView>-->
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" AllowPaging="True"  EmptyDataText="No hay datos." OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="5" ShowHeaderWhenEmpty="True">

                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID">
                        <HeaderStyle BackColor="#000066" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Username" HeaderText="Username">
                        <HeaderStyle BackColor="#000066" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CIF" HeaderText="CIF">
                        <HeaderStyle BackColor="#000066" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha">
                        <HeaderStyle BackColor="#000066" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion">
                        <HeaderStyle BackColor="#000066" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Comentarios" HeaderText="Comentarios">
                        <HeaderStyle BackColor="#000066" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Accion" HeaderText="Accion">
                        <HeaderStyle BackColor="#000066" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Estado" HeaderText="Estado">
                        <HeaderStyle BackColor="#000066" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>

        <div class="form-group">

             <asp:Button ID="btnAlta" runat="server" Text="Alta" CssClass="btn btn-primary" OnClick="btnAlta_Click" />
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-info" PostBackUrl="~/Private/Usuarios/Default.aspx">Volver</asp:LinkButton>
        </div>
    </div>
</asp:Content>

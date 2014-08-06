<%@ Page Title="" Language="C#" MasterPageFile="~/Private/Maestra.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Clientes.Private.Empresas.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
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
    <h1 class="page-header">Gestión de Empresas</h1>

    <div class="row placeholders">
        <fieldset class="opciones">
            <div class="row">
                <div class="col-md-1" id="divAlta">
                    <asp:LinkButton ID="btnAlta" runat="server" Text="Añadir" CssClass="btn btn-success" PostBackUrl="empresa.aspx?estado=0"><span class="glyphicon glyphicon-plus"></span>Alta</asp:LinkButton>
                    <br /><br />
                    <asp:LinkButton ID="btnGestionContactos" runat="server" Text="Gestión de Contactos" CssClass="btn btn-info" PostBackUrl="contactos.aspx"><span class="glyphicon glyphicon-plus"></span>Gestión de Contactos</asp:LinkButton>
                </div>
                <div class="col-md-11">
                    <div class="form-group">
                        <div class="col-md-2">
                            <div class="form-group" runat="server">
                                <asp:Label ID="lbNombre" runat="server" Text="Nombre" AssociatedControlID="tbNombre"></asp:Label>
                                <asp:TextBox ID="tbNombre" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group" runat="server">
                                <asp:Label ID="lbCIF" runat="server" Text="CIF" AssociatedControlID="tbCIF"></asp:Label>
                                <asp:TextBox ID="tbCIF" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group" runat="server">
                                <asp:Label CssClass="control-label" Text="Razón Social" ID="lbRazonSocial" runat="server" AssociatedControlID="tbRazonSocial"></asp:Label>

                                <asp:TextBox ID="tbRazonSocial" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group" runat="server">
                                <asp:Label CssClass="control-label" Text="Email" ID="lbEmail" runat="server" AssociatedControlID="tbEmail"></asp:Label>

                                <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                                                <div class="col-md-2">
                            <div class="form-group" runat="server">
                                <asp:Label ID="lbWeb" runat="server" Text="Web" AssociatedControlID="tbWeb"></asp:Label>
                                <asp:TextBox ID="tbWeb" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-1" id="divBuscar">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-info" OnClick="btnBuscar_Click" />

                    </div>
                </div>
                </div>
        </fieldset>
        <div class="table-responsive">
            <!--<asp:GridView ID="GridView2" runat="server" CssClass="table table-striped"></asp:GridView>-->
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" AllowPaging="True" OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting" EmptyDataText="No hay datos." ShowHeaderWhenEmpty="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="5">

                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="ID">
                                <HeaderStyle BackColor="#000066" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CIF" HeaderText="CIF">
                                <HeaderStyle BackColor="#000066" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RazonSocial" HeaderText="RazonSocial">
                                <HeaderStyle BackColor="#000066" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre">
                                <HeaderStyle BackColor="#000066" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Email" HeaderText="Email">
                                <HeaderStyle BackColor="#000066" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Web" HeaderText="Web">
                                <HeaderStyle BackColor="#000066" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TipoEmpresa" HeaderText="TipoEmpresa">
                                <HeaderStyle BackColor="#000066" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                            </asp:BoundField>

                            <asp:TemplateField>
                                <ItemTemplate>


                                    <asp:LinkButton ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-warning" CommandName="Edit"><span class="glyphicon glyphicon-pencil"></span>Modificar</asp:LinkButton>
                                    <asp:LinkButton ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="Delete"><span class="glyphicon glyphicon-minus"></span>Eliminar</asp:LinkButton>

                                </ItemTemplate>
                                <HeaderStyle BackColor="#000066" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>

            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

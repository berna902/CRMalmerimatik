<%@ Page Title="" Language="C#" MasterPageFile="~/Private/Maestra.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Clientes.Private.Admin.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu_lateral" runat="server">
    <ul class="nav nav-sidebar">
        <li><a href="../Default.aspx">Resumen</a></li>
        <li><a href="../Empresas/Default.aspx">Gestión Empresas</a></li>
        <li><a href="../Usuarios/Default.aspx">Gestión Usuarios</a></li>
        <li><a href="../Acciones/Default.aspx">Gestión Acciones</a></li>
        <li  class="active"><a href="Default.aspx">Administración</a></li>
    </ul>
    <ul class="nav nav-sidebar">
        <li class="active historial"><a href="#">Historial</a></li>

    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="central" runat="server">
    <h1 class="page-header">Gestión de Administración</h1>
    <div class="col-md-6">
        <div class="panel panel-primary">
            <div class="panel-heading">Tipo de Empresas</div>
            <div class="panel-body">
                <asp:Button ID="btAltaTempresa" runat="server" Text="Nuevo tipo de empresa" CssClass="btn btn-success" OnClick="btAltaTempresa_Click" />
                <br />
                <br />
                <div class="table-responsive">
                    <asp:GridView ID="GridView1" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" AllowPaging="True" OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting" runat="server">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID">
                                <HeaderStyle BackColor="#DCDCDC" ForeColor="#696969" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Tipo" HeaderText="Tipo">
                                <HeaderStyle BackColor="#DCDCDC" ForeColor="#696969" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnModificarAccion" runat="server" Text="Modificar" CssClass="btn btn-warning" CommandName="Edit"><span class="glyphicon glyphicon-pencil"></span>Modificar</asp:LinkButton>
                                    <asp:LinkButton ID="btnEliminarAccion" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="Delete"><span class="glyphicon glyphicon-minus"></span>Eliminar</asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle BackColor="#DCDCDC" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="panel panel-primary">
            <div class="panel-heading">Cargos</div>
            <div class="panel-body">
                <asp:Button ID="btAltaCargos" runat="server" Text="Nuevo cargo" CssClass="btn btn-success" OnClick="btAltaCargos_Click" />
                <br />
                <br />
                <div class="table-responsive">
                    <asp:GridView ID="GridView3" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" AllowPaging="True" OnRowEditing="GridView3_RowEditing" OnRowDeleting="GridView3_RowDeleting" runat="server">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID">
                                <HeaderStyle BackColor="#DCDCDC" ForeColor="#696969" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Cargo" HeaderText="Cargo">
                                <HeaderStyle BackColor="#DCDCDC" ForeColor="#696969" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnModificarCargos" runat="server" Text="Modificar" CssClass="btn btn-warning" CommandName="Edit"><span class="glyphicon glyphicon-pencil"></span>Modificar</asp:LinkButton>
                                    <asp:LinkButton ID="btnEliminarCargos" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="Delete"><span class="glyphicon glyphicon-minus"></span>Eliminar</asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle BackColor="#DCDCDC" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-6">
        <div class="panel panel-primary">
            <div class="panel-heading">Tipo de Acciones</div>
            <div class="panel-body">
                <asp:Button ID="btAltaTAccion" runat="server" Text="Nuevo tipo de acción" CssClass="btn btn-success" OnClick="btAltaTAciones_Click" />
                <br />
                <br />
                <div class="table-responsive">
                    <asp:GridView ID="GridView2" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" AllowPaging="True" OnRowEditing="GridView2_RowEditing" OnRowDeleting="GridView2_RowDeleting" runat="server">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID">
                                <HeaderStyle BackColor="#DCDCDC" ForeColor="#696969" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Tipo" HeaderText="Tipo">
                                <HeaderStyle BackColor="#DCDCDC" ForeColor="#696969" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnModificarEmpresa" runat="server" Text="Modificar" CssClass="btn btn-warning" CommandName="Edit"><span class="glyphicon glyphicon-pencil"></span>Modificar</asp:LinkButton>
                                    <asp:LinkButton ID="btnEliminarEmpresa" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="Delete"><span class="glyphicon glyphicon-minus"></span>Eliminar</asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle BackColor="#DCDCDC" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="panel panel-primary">
            <div class="panel-heading">Estados</div>
            <div class="panel-body">
                <asp:Button ID="btAltaEstado" runat="server" Text="Nuevo estado" CssClass="btn btn-success" OnClick="btAltaEstado_Click" />
                <br />
                <br />
                <div class="table-responsive">
                    <asp:GridView ID="GridView4" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" AllowPaging="True" OnRowEditing="GridView4_RowEditing" OnRowDeleting="GridView4_RowDeleting" runat="server">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID">
                                <HeaderStyle BackColor="#DCDCDC" ForeColor="#696969" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Estado" HeaderText="Estado">
                                <HeaderStyle BackColor="#DCDCDC" ForeColor="#696969" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnModificarEstado" runat="server" Text="Modificar" CssClass="btn btn-warning" CommandName="Edit"><span class="glyphicon glyphicon-pencil"></span>Modificar</asp:LinkButton>
                                    <asp:LinkButton ID="btnEliminarEstado" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="Delete"><span class="glyphicon glyphicon-minus"></span>Eliminar</asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle BackColor="#DCDCDC" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
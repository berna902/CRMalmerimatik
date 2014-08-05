<%@ Page Title="" Language="C#" MasterPageFile="~/Private/Maestra.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Clientes.Private.Acciones.Default" %>
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
    <h1 class="page-header">Gestión de Acciones</h1>

    <div class="row placeholders">
        <fieldset class="opciones">
            <div class="row">
                <div class="col-md-1" id="divAlta">
                    <asp:LinkButton ID="btnAlta" runat="server" Text="Añadir" CssClass="btn btn-success" PostBackUrl="acciones.aspx?estado=0"><span class="glyphicon glyphicon-plus"></span>Alta</asp:LinkButton>
                </div>

                <div class="col-md-11">
                    <div class="form-group">
                        <div class="col-md-3">
                            <div class="form-group" runat="server">
                                <asp:Label ID="lbBuscarDes" runat="server" Text="Descripción" AssociatedControlID="tbBuscarDes"></asp:Label>
                                <asp:TextBox ID="tbBuscarDes" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group" runat="server">
                                <asp:Label ID="lbBuscarCom" runat="server" Text="Comentario" AssociatedControlID="tbBuscarCom"></asp:Label>
                                <asp:TextBox ID="tbBuscarCom" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group" runat="server">
                                <asp:Label CssClass="control-label" Text="Tipo" ID="lbTipo" runat="server" AssociatedControlID="tbTipo"></asp:Label>

                                <asp:DropDownList ID="tbTipo" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="1">S.L.</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group" runat="server">
                                <asp:Label CssClass="control-label" Text="Estado" ID="lbEstado" runat="server" AssociatedControlID="tbEstado"></asp:Label>

                                <asp:DropDownList ID="tbEstado" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="1">S.L</asp:ListItem>
                                </asp:DropDownList>
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
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" AllowPaging="True" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" EmptyDataText="No hay datos." OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="5" ShowHeaderWhenEmpty="True">

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

                    <asp:TemplateField>
                        <ItemTemplate>


                            <asp:LinkButton ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-warning" CommandName="Edit"><span class="glyphicon glyphicon-pencil"></span>Modificar</asp:LinkButton>
                            <asp:LinkButton ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="Delete"><span class="glyphicon glyphicon-minus"></span>Eliminar</asp:LinkButton>

                        </ItemTemplate>
                        <HeaderStyle BackColor="#000066" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

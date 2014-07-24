<%@ Page Title="" Language="C#" MasterPageFile="~/Private/Maestra.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Clientes.Private.Admin.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
    <link href="../../Scripts/fancybox/jquery.fancybox.css" rel="stylesheet" />
    <script src="../../Scripts/fancybox/jquery.fancybox.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
             jQuery("a.fancy").fancybox({
                'type': 'iframe',
                'autoSize': false,
                'autoScale': false,
                'height': "220px",
                'width': "500px",
                'transitionIn': 'none',
                'transitionOut': 'none',
                'hideOnOverlayClick': false,
                'hideOnContentClick': false,
                'type': 'iframe',
                'afterClose': function () {
                    window.location.reload();
                }

             });   

        });
    </script>
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
                <a class="fancy" rel="fancy" href="TEmpresas.aspx?estado=0" >
                <asp:Button ID="btAltaTempresa" runat="server" Text="Nuevo tipo de empresa" CssClass="btn btn-success" />
                </a>
                    <br />
                <br />
                <div class="table-responsive">
                    <asp:GridView ID="GridView1" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" AllowPaging="True" OnRowDeleting="GridView1_RowDeleting" runat="server" EmptyDataText="No hay datos." ShowHeaderWhenEmpty="True">
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
                                    
                                    <asp:LinkButton id="btnModificarAccion" CssClass="btn btn-warning fancy" runat="server" href='<%# string.Format("TEmpresas.aspx?estado=1&id={0}", Eval("ID")) %>' Text="Modificar" ><span class="glyphicon glyphicon-pencil"></span>Modificar</asp:LinkButton>  
                                    <asp:LinkButton ID="btnEliminarAccion" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="Delete"><span class="glyphicon glyphicon-remove"></span>Eliminar</asp:LinkButton>
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
                <a class="fancy" rel="fancy" href="Cargos.aspx?estado=0" >
                <asp:Button ID="btAltaCargos" runat="server" Text="Nuevo cargo" CssClass="btn btn-success" />
                    </a>
                <br />
                <br />
                <div class="table-responsive">
                    <asp:GridView ID="GridView3" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" AllowPaging="True" OnRowDeleting="GridView3_RowDeleting" runat="server" EmptyDataText="No hay datos." ShowHeaderWhenEmpty="True">
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
                                    <asp:LinkButton ID="btnModificarCargos" CssClass="btn btn-warning fancy" runat="server" href='<%# string.Format("Cargos.aspx?estado=1&id={0}", Eval("ID")) %>' Text="Modificar" ><span class="glyphicon glyphicon-pencil"></span>Modificar</asp:LinkButton>  
                                    <asp:LinkButton ID="btnEliminarCargos" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="Delete"><span class="glyphicon glyphicon-remove"></span>Eliminar</asp:LinkButton>
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
                <a class="fancy" rel="fancy" href="TAccionesaspx.aspx?estado=0" >
                <asp:Button ID="btAltaTAccion" runat="server" Text="Nuevo tipo de acción" CssClass="btn btn-success"  />
                    </a>
                <br />
                <br />
                <div class="table-responsive">
                    <asp:GridView ID="GridView2" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" AllowPaging="True" OnRowDeleting="GridView2_RowDeleting" runat="server" EmptyDataText="No hay datos." ShowHeaderWhenEmpty="True">
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
                                    <asp:LinkButton ID="btnModificarEmpresa" CssClass="btn btn-warning fancy" runat="server" href='<%# string.Format("TAccionesaspx.aspx?estado=1&id={0}", Eval("ID")) %>' Text="Modificar" ><span class="glyphicon glyphicon-pencil"></span>Modificar</asp:LinkButton>  
                                    <asp:LinkButton ID="btnEliminarEmpresa" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="Delete"><span class="glyphicon glyphicon-remove"></span>Eliminar</asp:LinkButton>
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
                <a class="fancy" rel="fancy" href="Estados.aspx?estado=0" >
                <asp:Button ID="btAltaEstado" runat="server" Text="Nuevo estado" CssClass="btn btn-success" />
                    </a>
                <br />
                <br />
                <div class="table-responsive">
                    <asp:GridView ID="GridView4" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" AllowPaging="True" OnRowDeleting="GridView4_RowDeleting" runat="server" EmptyDataText="No hay datos." ShowHeaderWhenEmpty="True">
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
                                    <asp:LinkButton ID="btnModificarEstado" CssClass="btn btn-warning fancy" runat="server" href='<%# string.Format("Estados.aspx?estado=1&id={0}", Eval("ID")) %>' Text="Modificar" ><span class="glyphicon glyphicon-pencil"></span>Modificar</asp:LinkButton>  
                                    <asp:LinkButton ID="btnEliminarEstado" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="Delete"><span class="glyphicon glyphicon-remove"></span>Eliminar</asp:LinkButton>
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
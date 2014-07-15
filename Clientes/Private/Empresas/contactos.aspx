﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Private/Maestra.Master" AutoEventWireup="true" CodeBehind="contactos.aspx.cs" Inherits="Clientes.Private.Empresas.contactos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
     <h1 class="page-header">Gestión de Empresas</h1>

    <div class="row placeholders">
        <fieldset class="opciones">
            <asp:LinkButton  ID="btnAlta" runat="server" Text="Añadir" CssClass="btn btn-success"><span class="glyphicon glyphicon-plus"></span>Alta</asp:LinkButton>

        </fieldset>
        <div class="table-responsive">
            <!--<asp:GridView ID="GridView2" runat="server" CssClass="table table-striped"></asp:GridView>-->
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" AllowPaging="True">

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

                            <asp:LinkButton ID="btnAlta" runat="server" Text="Añadir" CssClass="btn btn-info"><span class="glyphicon glyphicon-plus"></span>Info</asp:LinkButton>
                            <asp:LinkButton ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-warning"><span class="glyphicon glyphicon-pencil"></span>Modificar</asp:LinkButton>
                            <asp:LinkButton ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger"><span class="glyphicon glyphicon-minus"></span>Eliminar</asp:LinkButton>

                        </ItemTemplate>
                        <HeaderStyle BackColor="#000066" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
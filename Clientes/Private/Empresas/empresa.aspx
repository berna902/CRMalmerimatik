<%@ Page Title="" Language="C#" MasterPageFile="~/Private/Maestra.Master" AutoEventWireup="true" CodeBehind="empresa.aspx.cs" Inherits="Clientes.Private.Empresas.empresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        input:focus::-webkit-input-placeholder {
            color: transparent;
        }

        #tabs .row .tab {
            background-color: #E0E0E0 ;
            margin-bottom: 15px;
            border-radius: 0px 5px 5px 5px;
        }

        #tabs .row .til {
            padding-left:0px;

        }
        .row h2{
            background-color: white;
        }
        .row h2 span{
            background-color:#E0E0E0 ;
            padding: 10px;
            border-radius: 5px 5px 0px 0px;
        }
        
    </style>
    <script src="../../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
    <script type="text/javascript">

        /*$(document).ready(function () {
            $('#central_btAddTelf').on("click", function (event) {
                 
                $('#mcorrecto').fadeIn(600);
                var t = setTimeout(function () { $('#mcorrecto').fadeOut(1000); }, 3500);

            });
        });*/


        function validateCIF(val,cif) {
            //Quitamos el primer caracter y el ultimo digito
            var valueCif = cif.Value;
            valueCif = valueCif.substr(1, valueCif.length - 2);
            
            var suma = 0;

            //Sumamos las cifras pares de la cadena
            for (i = 1; i < valueCif.length; i = i + 2) {
                suma = suma + parseInt(valueCif.substr(i, 1));
            }

            var suma2 = 0;

            //Sumamos las cifras impares de la cadena
            for (i = 0; i < valueCif.length; i = i + 2) {
                result = parseInt(valueCif.substr(i, 1)) * 2;
                if (String(result).length == 1) {
                    // Un solo caracter
                    suma2 = suma2 + parseInt(result);
                } else {
                    // Dos caracteres. Los sumamos...
                    suma2 = suma2 + parseInt(String(result).substr(0, 1)) + parseInt(String(result).substr(1, 1));
                }
            }

            // Sumamos las dos sumas que hemos realizado
            suma = suma + suma2;

            var unidad = String(suma).substr(1, 1)
            unidad = 10 - parseInt(unidad);

            var primerCaracter = valueCif.substr(0, 1).toUpperCase();

            if (primerCaracter.match(/^[FJKNPQRSUVW]$/)) {
                //Empieza por .... Comparamos la ultima letra
                if (String.fromCharCode(64 + unidad).toUpperCase() == valueCif.substr(valueCif.length - 1, 1).toUpperCase())
                    return true;
            } else if (primerCaracter.match(/^[XYZ]$/)) {
                //Se valida como un dni
                var newcif;
                if (primerCaracter == "X")
                    newcif = valueCif.substr(1);
                else if (primerCaracter == "Y")
                    newcif = "1" + valueCif.substr(1);
                else if (primerCaracter == "Z")
                    newcif = "2" + valueCif.substr(1);
                return  true;
            } else if (primerCaracter.match(/^[ABCDEFGHLM]$/)) {
                //Se revisa que el ultimo valor coincida con el calculo
                if (unidad == 10)
                    unidad = 0;
                if (valueCif.substr(valueCif.length - 1, 1) == String(unidad))
                    return true;
            } else {
                //Se valida como un dni
                return true;
            }
            return false;
        }
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

    <div id="tabs">
    <div class="row">
        <div class="til col-md-10">
        <h2><span>Datos de empresa</span></h2>
            </div>
        <div class="tab col-md-10">

            <div class="form-group">
                <asp:Label CssClass="control-label" Text="ID de la Empresa" ID="lbIDEmpresa" runat="server" AssociatedControlID="tbIDEmpresa"></asp:Label>
                <asp:TextBox ID="tbIDEmpresa" runat="server" CssClass="form-control"></asp:TextBox>

            </div>
            <div class="form-group">
                <asp:Label CssClass="control-label" Text="CIF" ID="lbCIF" runat="server" AssociatedControlID="tbCIF"></asp:Label>
                <asp:TextBox ID="tbCIF" runat="server" CssClass="form-control" placeholder="CIF de la empresa" MaxLength="9"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe introducir el CIF de la empresa." ControlToValidate="tbCIF" CssClass="label label-danger" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="EL CIF no es correcto." ClientValidationFunction="validateCIF" ControlToValidate="tbCIF" CssClass="label label-danger" OnServerValidate="validar_CIF" SetFocusOnError="True"></asp:CustomValidator>
            </div>

            <div class="form-group">
                <asp:Label CssClass="control-label" Text="Razón Social" ID="lbRazonSocial" runat="server" AssociatedControlID="tbRazonSocial"></asp:Label>
                <asp:TextBox ID="tbRazonSocial" runat="server" CssClass="form-control" placeholder="Razón social de la empresa"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Debe introducir la razón social de la empresa." ControlToValidate="tbRazonSocial" CssClass="label label-danger" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <asp:Label CssClass="control-label" Text="Nombre" ID="lbNombre" runat="server" AssociatedControlID="tbNombre"></asp:Label>
                <asp:TextBox ID="tbNombre" runat="server" CssClass="form-control" placeholder="Introduce el nombre de la empresa"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Introduzca un nombre de empresa." ControlToValidate="tbNombre" CssClass="label label-danger"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <asp:Label CssClass="control-label" Text="Web" ID="lbWeb" runat="server" AssociatedControlID="tbWeb"></asp:Label>
                <asp:TextBox ID="tbWeb" runat="server" CssClass="form-control" placeholder="web de la empresa"></asp:TextBox>

            </div>

            <div class="form-group">
                <asp:Label CssClass="control-label" Text="Email" ID="lbEmail" runat="server" AssociatedControlID="tbEmail"></asp:Label>
                <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control" placeholder="Introduce el email"></asp:TextBox>

            </div>

            <div class="form-group" id="formularioTelefonos" runat="server">
                <asp:Label CssClass="control-label" Text="Telefonos" ID="Label1" runat="server" AssociatedControlID="tbTelefonos"></asp:Label>
                <div class="telefonos navbar-form">
                    <div class="form-group">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:ListBox ID="tbTelefonos" runat="server" CssClass="form-control" AutoPostBack="True">
                                    <asp:ListItem Value="1">-</asp:ListItem>
                                </asp:ListBox>
                                <asp:Button ID="btnDeleteTelf" runat="server" Text="X" CssClass="btn btn-danger" OnClick="btnDeleteTelf_Click" />
                                <asp:TextBox ID="tbTelefono" runat="server" CssClass="form-control" placeholder="nuevo telefono"></asp:TextBox>
                                <asp:Button ID="btAddTelf" runat="server" Text="Añadir" CssClass="btn btn-success" OnClick="btAddTelf_Click" />

                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btAddTelf" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <div id="mcorrecto" style="display: none;" class="alert alert-success" role="alert">Insertado!</div>
                        <div id="mfallo" style="display: none;" class="alert alert-danger" role="alert">ERROR!</div>
                    </div>
                </div>

            </div>

            <div class="form-group">
                <asp:Label CssClass="control-label" Text="Tipo de empresa" ID="lbTipoEmpresa" runat="server" AssociatedControlID="tbTipoEMpresa"></asp:Label>

                <asp:DropDownList ID="tbTipoEMpresa" runat="server" CssClass="form-control">
                    <asp:ListItem Value="1">S.L.</asp:ListItem>
                </asp:DropDownList>

            </div>

        </div>
    </div>
    <div class="row">
        <div class="til col-md-10">
        <h2><span>Direcciones</span></h2>
            </div>
        <div class="tab col-md-10">

            <asp:Button ID="btAltaDireccion" runat="server" Text="Nueva dirección" CssClass="btn btn-success" OnClick="btAltaDireccion_Click" />

            <asp:GridView ID="GridView3" runat="server" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" AllowPaging="True" OnRowEditing="GridView3_RowEditing" OnRowDeleting="GridView3_RowDeleting" EmptyDataText="No hay datos." ShowHeaderWhenEmpty="True" OnPageIndexChanging="GridView3_PageIndexChanging">

                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID">
                        <HeaderStyle BackColor="#000066" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Domicilio" HeaderText="Domicilio">
                        <HeaderStyle BackColor="#000066" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Poblacion" HeaderText="Poblacion">
                        <HeaderStyle BackColor="#000066" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Provincia" HeaderText="Provincia">
                        <HeaderStyle BackColor="#000066" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CP" HeaderText="CP">
                        <HeaderStyle BackColor="#000066" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>

                            <asp:LinkButton ID="btnModificarDireccion" runat="server" Text="Modificar" CssClass="btn btn-warning" CommandName="Edit"><span class="glyphicon glyphicon-pencil"></span>Modificar</asp:LinkButton>
                            <asp:LinkButton ID="btnEliminarDireccion" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="Delete"><span class="glyphicon glyphicon-remove"></span>Eliminar</asp:LinkButton>

                        </ItemTemplate>
                        <HeaderStyle BackColor="#000066" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    </div>
    <div class="row">
        <div class="til col-md-10">
        <h2><span>Contactos</span></h2>
            </div>
        <div class="tab col-md-10">
            <asp:Button ID="btNuevoContacto" runat="server" Text="Nueva contacto" CssClass="btn btn-success" OnClick="btNuevoContacto_Click" />
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" AllowPaging="True" OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting" EmptyDataText="No hay datos." ShowHeaderWhenEmpty="True" OnPageIndexChanging="GridView1_PageIndexChanging">

                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID">
                        <HeaderStyle BackColor="#000066" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Justify" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IDEmpresa" HeaderText="IDEmpresa">
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

                    <asp:TemplateField>
                        <ItemTemplate>

                            <asp:LinkButton ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-warning" CommandName="Edit"><span class="glyphicon glyphicon-pencil"></span>Modificar</asp:LinkButton>
                            <asp:LinkButton ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="Delete"><span class="glyphicon glyphicon-remove"></span>Eliminar</asp:LinkButton>

                        </ItemTemplate>
                        <HeaderStyle BackColor="#000066" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    </div>
    <div class="form-group">

        <asp:Button ID="btAlta" runat="server" Text="Alta" CssClass="btn btn-primary" OnClick="btAlta_Click" />

    </div>

</asp:Content>

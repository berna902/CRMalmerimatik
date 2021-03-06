﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TEmpresas.aspx.cs" Inherits="Clientes.Private.Admin.TEmpresas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tipo de Empresa</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
    <link href="../../Scripts/fancybox/jquery.fancybox.css" rel="stylesheet" />
    <script src="../../Scripts/fancybox/jquery.fancybox.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="panel panel-primary">
            <div class="panel-heading">Tipo de Empresas</div>
            <div class="panel-body">

                <div class="form-group">
                    <asp:Label CssClass="control-label" Text="Tipo" ID="lbTipo" runat="server" AssociatedControlID="tbTipo"></asp:Label>
                    <asp:TextBox ID="tbTipo" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Introduce un nuevo tipo de empresa." ControlToValidate="tbTipo" CssClass="label label-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Button ID="btAlta" runat="server" Text="Alta" CssClass="btn btn-primary" OnClick="btAlta_Click" />
                    
                    
                </div>
            </div>
        </div>
    </form>
</body>
</html>

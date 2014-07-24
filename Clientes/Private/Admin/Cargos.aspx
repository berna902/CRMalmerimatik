<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cargos.aspx.cs" Inherits="Clientes.Private.Admin.Cargos" %>

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
            <div class="panel-heading">Estados</div>
            <div class="panel-body">

                <div class="form-group">
                    <asp:Label CssClass="control-label" Text="Cargo" ID="lbCargo" runat="server" AssociatedControlID="tbCargo"></asp:Label>
                    <asp:TextBox ID="tbCargo" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button ID="btAlta" runat="server" Text="Alta" CssClass="btn btn-primary" OnClick="btAlta_Click" />
                    
                    
                </div>
            </div>
        </div>
    </form>
</body>
</html>

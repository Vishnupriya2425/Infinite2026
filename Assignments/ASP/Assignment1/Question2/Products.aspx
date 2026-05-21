<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Assignment1_product_.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Product App</title>
    <style>
        .container {
            text-align: center;
            margin-top: 50px;
        }
        img {
            margin-top: 20px;
            width: 200px;
            height: 200px;
        }
    </style>
</head>

<body>
<form id="form2" runat="server">
    <div class="container">

        <h2>Select a Product</h2>

        <asp:DropDownList ID="ddlProducts" runat="server"
            AutoPostBack="true"
            OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">
        </asp:DropDownList>

        <br /><br />

        <asp:Image ID="imgProduct" runat="server" Width="200px" Height="200px" />

        <br /><br />

        <asp:Button ID="btnPrice" runat="server"
            Text="Get Price"
            OnClick="btnPrice_Click" />

        <br /><br />

        <asp:Label ID="lblPrice" runat="server" 
            Font-Bold="true" ForeColor="Green" />

    </div>
</form>
</body>
</html>



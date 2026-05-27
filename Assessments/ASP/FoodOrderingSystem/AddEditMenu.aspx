<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="AddEditMenu.aspx.cs"
    Inherits="FoodOrderingSystem.AddEditMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style5 {
            width: 192px;
            text-align: right;
        }
        .auto-style6 {
            width: 192px;
            font-weight: bold;
            text-align: right;
        }
    </style>
</head>
<body>
<form id="form1" runat="server">
<div>

<h2 style="text-align:center">Add / Edit Menu</h2>

<table cellpadding="10" style="margin:auto">

<tr>
    <td class="auto-style6">Item Name&nbsp;&nbsp;&nbsp; : </td>
    <td><asp:TextBox ID="txtName" runat="server" CssClass="input" /></td>
</tr>

<tr>
    <td class="auto-style6">Category&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
    <td><asp:TextBox ID="txtCategory" runat="server" /></td>
</tr>

<tr>
    <td class="auto-style6">Food Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
    <td>
        <asp:DropDownList ID="ddlType" runat="server">
            <asp:ListItem Text="Select" Value="" />
            <asp:ListItem Text="Veg" />
            <asp:ListItem Text="Non-Veg" />
        </asp:DropDownList>
    </td>
</tr>

<tr>
    <td class="auto-style6">Price&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
    <td><asp:TextBox ID="txtPrice" runat="server" /></td>
</tr>

<tr>
    <td class="auto-style6">Quantity&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
    <td><asp:TextBox ID="txtQty" runat="server" /></td>
</tr>

<tr>
    <td class="auto-style6">Available&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</td>
    <td><asp:CheckBox ID="chkAvailable" runat="server" /></td>
</tr>

<tr>
    <td class="auto-style5"></td>
    <td>
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Save"
            BackColor="#27ae60"
            ForeColor="White"
            BorderStyle="None"
            Padding="8px"
            OnClick="btnSave_Click" />
    </td>
</tr>

</table>


</div>
</form>
</body>
</html>

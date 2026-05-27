<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="MenuDetails.aspx.cs"
    Inherits="MenuDetails"
    MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h2 style="text-align: center">Menu Details</h2>

    <table cellpadding="6" align="center">

        <tr>
            <td>ID:</td>
            <td><asp:Label ID="lblId" runat="server" /></td>
        </tr>

        <tr>
            <td>Name:</td>
            <td><asp:Label ID="lblName" runat="server" /></td>
        </tr>

        <tr>
            <td>Category:</td>
            <td><asp:Label ID="lblCategory" runat="server" /></td>
        </tr>

        <tr>
            <td>Food Type:</td>
            <td><asp:Label ID="lblType" runat="server" /></td>
        </tr>

        <tr>
            <td>Price:</td>
            <td><asp:Label ID="lblPrice" runat="server" /></td>
        </tr>

        <tr>
            <td>Quantity:</td>
            <td><asp:Label ID="lblQty" runat="server" /></td>
        </tr>

        <tr>
            <td>Available:</td>
            <td><asp:Label ID="lblAvailable" runat="server" /></td>
        </tr>

    </table>

</asp:Content>


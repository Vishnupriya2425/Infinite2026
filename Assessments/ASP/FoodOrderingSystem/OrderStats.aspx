<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="OrderStats.aspx.cs"
    Inherits="OrderStats"
    MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h2 style="text-align:center">Order Statistics</h2>

    <div style="display:flex; gap:20px; justify-content:center; margin-bottom:20px;">

        <div style="background:#3498db; color:white; padding:20px; border-radius:8px; width:1538px; text-align:center;">
            <h3>Total Visitors</h3>
            <asp:Label ID="lblTotal" runat="server" Font-Size="Large"></asp:Label>
        </div>

        <div style="background:#27ae60; color:white; padding:20px; border-radius:8px; width:1541px; text-align:center;">
            <h3>Active Users</h3>
            <asp:Label ID="lblActive" runat="server" Font-Size="Large"></asp:Label>
        </div>

    </div>

    <h3> Category-wise Food Summary</h3>

    <asp:GridView ID="gvStats" runat="server" Width="100%"
        AutoGenerateColumns="true"

        BackColor="White"
        BorderColor="#ccc"
        BorderWidth="1px"
        GridLines="None"

        HeaderStyle-BackColor="#34495e"
        HeaderStyle-ForeColor="White"
        RowStyle-HorizontalAlign="Center"
        AlternatingRowStyle-BackColor="#f2f2f2">
    </asp:GridView>

</asp:Content>

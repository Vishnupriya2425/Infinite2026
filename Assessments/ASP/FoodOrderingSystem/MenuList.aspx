<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="MenuList.aspx.cs"
    Inherits="MenuList"
    MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h2 style="text-align: center">Menu Items</h2>

    <asp:GridView ID="gvMenu" runat="server"
    AutoGenerateColumns="False"
    DataKeyNames="MenuId"
    OnRowCommand="gvMenu_RowCommand"
    Width="100%"

    BackColor="White"
    BorderColor="#ccc"
    BorderWidth="1px"
    GridLines="None"

    HeaderStyle-BackColor="#34495e"
    HeaderStyle-ForeColor="White"
    RowStyle-HorizontalAlign="Center"
    AlternatingRowStyle-BackColor="#f2f2f2">

    <Columns>
        <asp:BoundField DataField="MenuId" HeaderText="ID" />
        <asp:BoundField DataField="ItemName" HeaderText="Name" />
        <asp:BoundField DataField="Category" HeaderText="Category" />
        <asp:BoundField DataField="Price" HeaderText="Price" />

        <asp:ButtonField CommandName="View" Text="View" ButtonType="Button" />
        <asp:ButtonField CommandName="Edit" Text="Edit" ButtonType="Button" />
        <asp:ButtonField CommandName="Delete" Text="Delete" ButtonType="Button" />
    </Columns>

</asp:GridView>


</asp:Content>
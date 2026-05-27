<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FoodOrderingSystem.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:300px;margin:auto;margin-top:100px;"
     class="card">

<h2 style="text-align:center">Login</h2>

Username:
<asp:TextBox ID="txtUsername" runat="server" /><br /><br />

Password:
<asp:TextBox ID="txtPassword" runat="server"
    TextMode="Password" /><br /><br />

<asp:Button ID="btnLogin" runat="server" Text="Login"
    Width="100%"
    BackColor="#3498db"
    ForeColor="White"
    OnClick="btnLogin_Click" />

<br /><br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lblMsg" runat="server" ForeColor="Red" />

</div>
    </form>
</body>
</html>

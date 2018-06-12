<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AzureNTierWebRoleWithSession_WebRole.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center">
    
        Login 
        Page<br />
        <br />
        Username:<asp:TextBox ID="tbUsername" runat="server" ></asp:TextBox>
        &nbsp;(name is default)<br />
        Password:<asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
        &nbsp;(password is 123)<br />
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="Login" 
            onclick="btnLogin_Click" />
        <br />
        <asp:Label ID="lbContent" ForeColor="Red" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>

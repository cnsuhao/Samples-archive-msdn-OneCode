<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebRole1.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <div>
    Login Page
        <asp:Login ID="Login1" runat="server">
        </asp:Login>
    </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        ValidationGroup="Login1"/>
    </form>
</body>
</html>

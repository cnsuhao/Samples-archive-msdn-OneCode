﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UserPage2.aspx.vb" Inherits="VBASPNETAutoRedirectLoginPage.UserPage2" %>

<%@ Register src="UserControl/AutoRedirect.ascx" tagname="AutoRedirect" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        User Page 2.
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server">Refresh this page</asp:LinkButton>
        <br />
        <a href="UserPage1.aspx">User Page 1</a>
    </div>
    <uc1:AutoRedirect ID="AutoRedirect1" runat="server" />
    </form>
</body>
</html>
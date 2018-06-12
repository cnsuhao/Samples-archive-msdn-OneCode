<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="VBASPNETMembershipProvider._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Built-in Membership Provider</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        This sample will show how to use Built-in Membership Provider.
        <br />
    </div>
    <h3>
        The following are the most commonly used in e-commerce website, a simple prompt.</h3>
    <p>
        <b>[<asp:LoginName ID="LoginName1" runat="server" />
            ]</b> Your current login status is login in, you can:
        <asp:LoginStatus ID="LoginStatus1" runat="server" />
        .Log in, you can continue <a href="#">shopping</a> or enter the <a href="MemberCenter.aspx">
            Member Center</a>. &nbsp;,</p>
    If you have forgotten your password, you can choose:<br />
   <%-- <a href="RecoveryPassword.aspx">Recovery Password</a>--%>
    </form>
</body>
</html>

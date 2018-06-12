<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="WebApplication1._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HyperLink ID="hlkLogin" runat="server" NavigateUrl="~/Login.aspx">login</asp:HyperLink>
        <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>

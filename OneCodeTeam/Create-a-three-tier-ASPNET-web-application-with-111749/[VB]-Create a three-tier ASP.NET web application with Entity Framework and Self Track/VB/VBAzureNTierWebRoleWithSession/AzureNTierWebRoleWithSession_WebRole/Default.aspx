<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="AzureNTierWebRoleWithSession_WebRole._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Hello<asp:Label ID="lbUser" runat="server" Text=""></asp:Label>:
        <br />
    
        <asp:GridView ID="gvwDataSource" runat="server">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>

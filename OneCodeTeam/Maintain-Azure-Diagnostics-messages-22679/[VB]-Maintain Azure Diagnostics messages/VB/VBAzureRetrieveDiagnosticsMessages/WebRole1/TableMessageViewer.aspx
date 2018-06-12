<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TableMessageViewer.aspx.vb" Inherits="WebRole1.TableMessageViewer_aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     &nbsp;<asp:GridView ID="gdvMessageList" runat="server">
    </asp:GridView>

    <asp:Label ID="lbStatus" runat="server"></asp:Label>
    </form>
</body>
</html>

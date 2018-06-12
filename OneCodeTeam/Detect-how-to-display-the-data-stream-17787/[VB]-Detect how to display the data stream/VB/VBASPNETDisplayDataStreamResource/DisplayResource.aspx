<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DisplayResource.aspx.vb" Inherits="VBASPNETDisplayDataStreamResource.DisplayResource" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        web page:
        <asp:TextBox ID="tbKeyWord" runat="server" Text="http://www.msdn.com"></asp:TextBox>
        <br />
        <asp:Button ID="btnSearchPage" runat="server" Text="Search target page links" 
            onclick="btnSearchPage_Click" />
        <br />

        <%=publicTable%>
    </div>
    </form>
</body>
</html>

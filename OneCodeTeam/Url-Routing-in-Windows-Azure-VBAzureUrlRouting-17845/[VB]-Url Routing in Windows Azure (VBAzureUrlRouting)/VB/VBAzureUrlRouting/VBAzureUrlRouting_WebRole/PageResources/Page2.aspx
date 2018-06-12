<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Page2.aspx.vb" Inherits="VBAzureUrlRouting_WebRole.Page2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     Hi, I am page 2.
                  <br />
        <br />
    <asp:Button ID="btnReturn" runat="server"  Text="Return to default page." 
            onclick="btnReturn_Click" />
    </div>
    </form>
</body>
</html>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="WebRole1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        This programe will show you how to retrieve diagnostics message and transfer 
        them to Azure storage. And also it will show you how to view both logs in Table 
        and logs in blob.<br />
        <br />
        <asp:HyperLink ID="hlBlobDirectoryExplorer" runat="server" 
            NavigateUrl="~/BlobDirectoryExplorer.aspx">BlobDirectoryExplorer</asp:HyperLink>
        <br />
        <asp:HyperLink ID="hlTableEntityExplorer" runat="server" 
            NavigateUrl="~/TableEntityExplorer.aspx">TableEntityExplorer</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>

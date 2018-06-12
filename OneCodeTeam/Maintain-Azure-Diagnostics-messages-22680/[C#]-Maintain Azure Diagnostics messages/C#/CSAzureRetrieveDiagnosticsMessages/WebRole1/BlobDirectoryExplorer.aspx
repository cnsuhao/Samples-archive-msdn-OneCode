<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BlobDirectoryExplorer.aspx.cs" Inherits="CSAzureRetrieveDiagnosticsMessages_WebRole.BlobDirectoryExplorer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Label ID="status" runat="server" ForeColor="Red" />
    <asp:TreeView ID="tvBlobDirectory" runat="server">       
    </asp:TreeView>
    </form>
</body>
</html>

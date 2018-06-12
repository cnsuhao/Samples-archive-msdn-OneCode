<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GetTableSchemaWithDynamicEntity.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Button ID="btnQuery" runat="server" OnClick="btnQuery_Click" Text="Query All Data from Azure table storage" />
        <asp:GridView ID="gvwAzureTable" runat="server">
        </asp:GridView>
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CSASPNETMultiHeadGridView.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gdvData" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="True" OnRowCreated="gdvData_RowCreated" DataKeyNames="Id"
            DataSourceID="SqlDataSource1">          
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT [Id], [Name], [Age], [Sex] FROM [PersonData]"></asp:SqlDataSource>
        <br />
        <br />
    </div>
    </form>
</body>
</html>

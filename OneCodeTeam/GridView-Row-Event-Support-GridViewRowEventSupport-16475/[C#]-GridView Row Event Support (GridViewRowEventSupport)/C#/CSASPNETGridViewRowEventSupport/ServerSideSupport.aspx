<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="true" CodeBehind="ServerSideSupport.aspx.cs"
    Inherits="CSASPNETGridViewRowEventSupport.ServerSideSupport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gvCustomer" runat="server" OnRowCreated="gvCustomer_RowCreated"
            AutoGenerateColumns="False" OnRowEditing="gvCustomer_RowEditing" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True"
                    SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT [Id], [Name], [Age], [Email] FROM [CustomerInfo]"></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>

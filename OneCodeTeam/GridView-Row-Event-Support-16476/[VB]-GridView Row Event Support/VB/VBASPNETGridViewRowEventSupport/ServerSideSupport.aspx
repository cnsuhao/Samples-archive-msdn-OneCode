<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ServerSideSupport.aspx.vb" Inherits="VBASPNETGridViewRowEventSupport.ServerSideSupport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvCustomer" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowCreated="gvCustomer_RowCreated" OnRowEditing="gvCustomer_RowEditing">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Id], [Name], [Age], [Email] FROM [CustomerInfo]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>

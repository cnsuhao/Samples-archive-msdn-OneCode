<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ClientSideSupport.aspx.vb" Inherits="VBASPNETGridViewRowEventSupport.ClientSideSupport" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <script src="Script/jquery-1.4.1.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=gvCustomer.ClientID%> tr").bind("click", function () {
                alert($(this).html())
            });
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gvCustomer" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
            DataSourceID="SqlDataSource2">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True"
                    SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT [Id], [Name], [Age], [Email] FROM [CustomerInfo]"></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>


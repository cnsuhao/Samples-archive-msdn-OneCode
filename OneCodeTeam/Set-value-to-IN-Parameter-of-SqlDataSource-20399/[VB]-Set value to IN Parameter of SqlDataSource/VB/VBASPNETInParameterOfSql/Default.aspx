<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="VBASPNETInParameterOfSql._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div>
        List of ID:
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="SqlDataSource2"
            RepeatColumns="6" RepeatDirection="Horizontal" DataTextField="ID" DataValueField="ID">
        </asp:CheckBoxList>
        <asp:Button ID="btnDynamicShow" runat="server" Text="ShowDynamicData" OnClick="btnDynamicShow_Click" />&nbsp;
        <asp:Button ID="btnStaticShow" runat="server" Text="ShowStaticData" OnClick="btnStaticShow_Click" />
        <br />
        Data of selected:
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1">
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT [Id], [Name] FROM [Test]">
            <%--   SelectCommand="SELECT [Id], [Name] FROM [Test] WHERE ([Id] IN (@Id))">
            <SelectParameters>
                <asp:Parameter DefaultValue="1" Name="Id" Type="Int32" />
            </SelectParameters>--%>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT [Id], [Name] FROM [Test]"></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>

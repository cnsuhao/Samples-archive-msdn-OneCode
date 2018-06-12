<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="VBASPNETMultiFiltering._Default" %>

<%@ Register src="MultiFiltering.ascx" tagname="MultiFiltering" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:MultiFiltering ID="MultiFiltering1" runat="server" />
    <asp:GridView ID="GridView1" runat="server" 
        AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" 
        DataSourceID="SqlDataSource1" EnableModelValidation="True" 
        AllowPaging="True" onpageindexchanged="GridView1_PageIndexChanged">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="number" HeaderText="number" 
                SortExpression="number" />
            <asp:BoundField DataField="value" HeaderText="value" SortExpression="value" />
            <asp:CheckBoxField DataField="isleader" HeaderText="IsLeader" />
            <asp:BoundField DataField="datetime" DataFormatString="{0:yyyy-MM-dd}" 
                HeaderText="DateTime" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:MyTestConnectionString %>" 
        SelectCommand="SELECT * FROM [tb_dbo]" 
            ProviderName="<%$ ConnectionStrings:MyTestConnectionString.ProviderName %>"></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>

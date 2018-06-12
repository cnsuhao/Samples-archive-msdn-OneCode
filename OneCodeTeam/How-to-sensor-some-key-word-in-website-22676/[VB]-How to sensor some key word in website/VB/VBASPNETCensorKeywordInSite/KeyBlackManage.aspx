<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="KeyBlackManage.aspx.vb" Inherits="VBASPNETCensorKeywordInSite.KeyBlackManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <hr />
    <div>
        Filter character:
        <asp:TextBox ID="tbKey" runat="server" ValidationGroup="Add"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Value can not be empty"
            ControlToValidate="tbKey"></asp:RequiredFieldValidator>
        <asp:Button ID="btnAdd" runat="server" Text="Add a new key" ValidationGroup="Add"
            OnClick="btnAdd_Click" />
    </div>
    <hr />
    <div>
        <asp:GridView ID="gdvKeyword" runat="server" AutoGenerateColumns="False" DataKeyNames="Id">     
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True"
                    SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            </Columns>
        </asp:GridView>
    </div>
    <hr />
    </form>
</body>
</html>

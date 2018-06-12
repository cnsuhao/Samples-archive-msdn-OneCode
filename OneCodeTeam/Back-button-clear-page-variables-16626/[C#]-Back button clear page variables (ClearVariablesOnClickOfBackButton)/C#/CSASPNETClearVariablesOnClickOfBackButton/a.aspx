<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="a.aspx.cs" Inherits="CSASPNETClearVariablesOnClickOfBackButton.a" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        UserName:<asp:TextBox ID="tbName" runat="server"></asp:TextBox><br />
        <br />
        Password:<asp:TextBox ID="tbPwd" runat="server"></asp:TextBox><br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Register" OnClick="btnSubmit_Click" />
    </div>
    </form>
</body>
</html>

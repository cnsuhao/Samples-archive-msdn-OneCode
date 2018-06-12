<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPNETRunScriptsAfterServerSideValidation._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Please enter a valid e-mail:<asp:TextBox ID="tbEmail" runat="server" ValidationGroup="vailEmail"></asp:TextBox>
        <asp:Button ID="btnEnter" runat="server" Text="Validate" ValidationGroup="vailEmail" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required field cannot be blank."
            ControlToValidate="tbEmail" ValidationGroup="vailEmail" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="CustomValidator1" ControlToValidate="tbEmail" runat="server"
            ErrorMessage="Invalid email address." Display="Dynamic"></asp:CustomValidator>
    </div>
    <div id="divTask" style="display: none">
        This is valid email address.</div>
    </form>
</body>
</html>

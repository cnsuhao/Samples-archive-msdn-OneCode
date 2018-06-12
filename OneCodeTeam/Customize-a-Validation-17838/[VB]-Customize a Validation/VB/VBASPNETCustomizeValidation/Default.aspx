<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="VBASPNETCustomizeValidation._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div>
        <table>
            <tr>
                <td>
                    Email
                </td>
                <td>
                    <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox><asp:CustomValidator ID="CustomValidator1"
                        runat="server" ControlToValidate="tbEmail" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnRegister" runat="server" Text="Button" OnClick="btnRegister_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

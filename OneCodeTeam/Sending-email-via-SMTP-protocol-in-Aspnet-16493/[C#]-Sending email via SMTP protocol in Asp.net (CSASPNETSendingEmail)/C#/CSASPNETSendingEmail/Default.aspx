<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="Default.aspx.cs" Inherits="CSASPNETSendingEmail.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
    <td colspan="2" style="text-align:center;font-size:24px;font-weight:bold">Sending Email Sample</td>
    </tr>
    <tr>
    <td>Your email address:</td>
    <td><asp:TextBox ID="tbEmailAddress" runat="server" Text="username@hotmail.com"></asp:TextBox></td>
    </tr>
    <tr>
    <td>Your email password:</td>
    <td><asp:TextBox ID="tbEmailPassword" runat="server" TextMode="Password"></asp:TextBox></td>
    </tr>
    <tr>
    <td>Source email host:</td>
    <td><asp:TextBox ID="tbSourceHost" runat="server" Text="smtp.live.com"></asp:TextBox></td>
    </tr>
    <tr>
    <td>Target email address:</td>
    <td><asp:TextBox ID="tbTargetEmailAddress" runat="server" Text="target@hotmail.com"></asp:TextBox></td>
    </tr>
    <tr>
    <td>Message Title:</td>
    <td><asp:TextBox ID="tbTitle" runat="server" Text="Sample Test"></asp:TextBox></td>
    </tr>
    <tr>
    <td>Add attachments:</td>
    <td>
        <asp:FileUpload ID="fupAttachment" runat="server" />
    </td>
    </tr>
    <tr>
    <td>Add image:</td>
    <td>
        <asp:FileUpload ID="fupImage" runat="server" />
    </td>
    </tr>
    <tr>
    <td>Message Text:</td>
    <td><asp:TextBox ID="tbText" runat="server" Height="407px" TextMode="MultiLine" 
            Width="691px" Text="This is a test email from Microsoft."></asp:TextBox></td>
    </tr>      
    <tr>
    <td></td>
    <td><asp:Button ID="btnSend" runat="server" Text="Send Now!" 
            onclick="btnSend_Click" />
            <asp:Button ID="btnReset" runat="server" 
            Text="Reset Email" onclick="tbReset_Click" />&nbsp;&nbsp;
        <asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>
        </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>

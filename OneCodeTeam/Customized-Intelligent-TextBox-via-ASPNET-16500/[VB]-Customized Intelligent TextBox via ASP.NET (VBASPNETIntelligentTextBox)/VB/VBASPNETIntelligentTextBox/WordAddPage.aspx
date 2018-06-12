<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WordAddPage.aspx.vb" Inherits="VBASPNETIntelligentTextBox.WordAddPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        New words:<asp:TextBox ID="tbNewWords" runat="server"></asp:TextBox>
        (If you want to add multiple words at once, please use a comma between them, for 
        example &quot;word1,word2&quot;)<br />
        <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
            Text="Submit" />
        <asp:Button ID="btnBack" runat="server" onclick="btnBack_Click" Text="Back" />
        <br />
        <asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>
    
    </div>
    </form>
</body>
</html>

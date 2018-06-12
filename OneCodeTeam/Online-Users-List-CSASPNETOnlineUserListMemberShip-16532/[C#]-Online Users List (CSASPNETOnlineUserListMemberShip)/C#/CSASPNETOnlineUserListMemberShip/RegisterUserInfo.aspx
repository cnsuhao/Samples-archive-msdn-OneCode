<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterUserInfo.aspx.cs" Inherits="CSASPNETOnlineUserList.RegisterUserInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lbUserName" runat="server" Text="User Name:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbUserName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lbPassWord" runat="server" Text="Pass Word:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="tbPassWord" runat="server" 
            TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="lbRepeatePass" runat="server" Text="Repeate Pass:"></asp:Label>
        &nbsp;<asp:TextBox ID="tbRepeatePass" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="lbEmail" runat="server" Text="User Email:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbUserEmail" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lbQuestion" runat="server" Text="Question:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbQuestion" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lbAnswer" runat="server" Text="Answer: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbAnswer" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" Text="Submit" />
&nbsp;
        <asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" Text="Reset" />
    
    &nbsp;
        <asp:Button ID="btnReturn" runat="server" 
            Text="Return Online User List Page" onclick="btnReturn_Click" />
    
        <br />
        <asp:Label ID="lbMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
    
    </div>
    </form>
</body>
</html>

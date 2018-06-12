<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Client.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left: 1000px">
    
        <asp:Label ID="lbUserName" runat="server"></asp:Label>
        <asp:HyperLink ID="hlkLogin" runat="server" NavigateUrl="https://[ACS NameSpace].accesscontrol.windows.net:443/v2/wsfederation?wa=wsignin1.0&wtrealm=http%3a%2f%2flocalhost%3a20131%2f">Login</asp:HyperLink>
    
    </div>
        <br />
        <br />
        <br />
        This textbox will show the content response by your web API:<br />
        <asp:TextBox ID="tbContent" runat="server" Height="298px" TextMode="MultiLine" Width="552px"></asp:TextBox>
    </form>
</body>
</html>


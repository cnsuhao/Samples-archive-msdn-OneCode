<%@ Page Language="vb" AutoEventWireup="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        You can use the testing user name(testuser) and password(testuser!) to login. You can also create your own login
        user through <a href="CreateUser.aspx">CreateUser</a>.
    </div>
    <asp:Login ID="Login1" runat="server">
    </asp:Login>   
    </form>
</body>
</html>

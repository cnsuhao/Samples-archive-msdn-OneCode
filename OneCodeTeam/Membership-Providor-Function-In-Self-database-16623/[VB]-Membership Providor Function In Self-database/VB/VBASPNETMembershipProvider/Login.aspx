<%@ Page Language="vb" AutoEventWireup="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        You can use the test user's user name and password to login. The user name is the
        "testuser" and the password is "testuser!". You can also create your own login
        user through <a href="CreateUser.aspx">CreateUser</a>.
    </div>
    <asp:Login ID="Login1" runat="server">
    </asp:Login>   
    </form>
</body>
</html>

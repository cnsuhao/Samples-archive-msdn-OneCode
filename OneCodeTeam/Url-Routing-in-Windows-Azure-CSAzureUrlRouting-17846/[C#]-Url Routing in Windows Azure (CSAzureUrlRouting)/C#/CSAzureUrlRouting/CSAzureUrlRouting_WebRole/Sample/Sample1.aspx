<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sample1.aspx.cs" Inherits="CSAzureUrlRouting_WebRole.Sample.Sample1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Hi, I am sample 1.
            <br />
        <br />
    <asp:Button ID="btnReturn" runat="server"  Text="Return to default page." 
            onclick="btnReturn_Click" />
    </div>
    </form>
</body>
</html>

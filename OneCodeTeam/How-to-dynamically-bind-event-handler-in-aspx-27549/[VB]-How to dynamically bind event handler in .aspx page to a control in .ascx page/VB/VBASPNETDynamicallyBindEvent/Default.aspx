<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="VBASPNETDynamicallyBindEvent._Default" %>

<%@ Register Src="~/ImageController.ascx" TagPrefix="uc1" TagName="ImageController" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:ImageController runat="server" ID="ImageController" />
    </div>
    </form>
</body>
</html>

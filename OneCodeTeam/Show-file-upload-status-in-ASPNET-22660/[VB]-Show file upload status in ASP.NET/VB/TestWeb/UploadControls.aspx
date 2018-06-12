<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UploadControls.aspx.vb" Inherits="UploadControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div>
        <asp:FileUpload ID="fuFile" runat="server" />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="btnUpload" runat="server" OnClientClick="parent.StartGetStatus()"
            Text="Upload" />
    </div>
    </form>
</body>
</html>

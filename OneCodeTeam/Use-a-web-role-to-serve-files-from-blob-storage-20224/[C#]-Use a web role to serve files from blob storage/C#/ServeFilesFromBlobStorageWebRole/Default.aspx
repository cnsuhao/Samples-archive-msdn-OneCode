<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ServeFilesFromBlobStorageWebRole.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    For make this application to run, please upload some resources on Windows Azure Storage.
    <br />
    And This page will help you to upload some default resources (image and css 
        files).

    <br />
    <asp:linkbutton runat="server" onclick="Unnamed1_Click">Add default resources page.</asp:linkbutton>

        <br />
        <br />
        <br />
        <%=embedString %>
    </div>
    </form>
</body>
</html>


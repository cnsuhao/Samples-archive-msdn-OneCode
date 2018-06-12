<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="VBASPNETGloablizationInAssembly._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .Title
        {
            text-align:center;
            font-size:24;
            font-family:Arial;   
       }
       
       .Author
       {
           text-align:center;
           font-size:16;
           font-family:Vrinda;  
       }
       
       .Content
       {
           text-align:center;
           font-size:20;
           font-family:MS UI Gothic;  
       }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="Title">
        <asp:Label ID="lbTitle" runat="server"></asp:Label>
    </div>
        <br />
    <div class="Author">
        <asp:Label ID="lbAuthor" runat="server" ></asp:Label>
    </div>
        <br />
    <div class="Content">
    <p>
        <%=strContent %>
    </p>
    <p><%=strLink %>: <a href="<%=strUrl %>"><%=strUrl %></a></p>
    </div>
<asp:DropDownList ID="ddlLanguage" runat="server" AutoPostBack="True" 
        onselectedindexchanged="ddlLanguage_SelectedIndexChanged">
        </asp:DropDownList>
    </form>
</body>
</html>

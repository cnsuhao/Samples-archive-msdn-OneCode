   <%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ErrorPage.aspx.vb" Inherits="VBASPNETIntelligentErrorPage.ErrorPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size:24px">
    <p ><b>404 Error.</b></p>    </div>
    <b>Oh! your request is unreachable.</b> 
    <br />
    <br />
    <asp:ListView ID="lvwPageList" runat="server">
        <LayoutTemplate>
        Similar links:<br />
        <ul>
        <asp:PlaceHolder runat="server" id="itemPlaceholder"></asp:PlaceHolder>
        </ul>
        </LayoutTemplate>
        <ItemTemplate>    
	    <li><a href='<%# Eval("Path") %>'><%# Eval("Name") %></a></li>     
        </ItemTemplate>
        <EmptyDataTemplate>
        No similar links.
        </EmptyDataTemplate>
        </asp:ListView>
    </form>
</body>
</html>

<%@ Page Title="Home Page" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="Default.aspx.vb" Inherits="RetryCacheRole._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        <asp:Button ID="btnAddToCache" runat="server" Text="Add To Cache" onclick="btnAddToCache_Click" 
            />
        <asp:Button ID="btnReadFromCache" runat="server" Text="Read From Cache" 
            onclick="btnReadFromCache_Click" />
</h2>
    </asp:Content>

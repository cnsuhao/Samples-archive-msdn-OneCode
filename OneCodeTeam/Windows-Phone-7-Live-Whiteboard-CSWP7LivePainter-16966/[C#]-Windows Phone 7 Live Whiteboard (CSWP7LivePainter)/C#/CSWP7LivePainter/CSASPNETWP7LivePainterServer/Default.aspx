<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="CSASPNETWP7LivePainterServer._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Label ID="label_msg" runat="server"></asp:Label>
    <br/>
    <asp:Button ID="Button1" runat="server" Text="Clear Phones" onclick="Button1_Click" />
</asp:Content>

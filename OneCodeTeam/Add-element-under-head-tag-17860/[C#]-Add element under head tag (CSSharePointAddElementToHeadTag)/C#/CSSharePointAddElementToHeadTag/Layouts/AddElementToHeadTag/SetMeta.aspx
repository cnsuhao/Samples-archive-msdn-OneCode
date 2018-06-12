﻿<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetMeta.aspx.cs" Inherits="AddElementToHeadTag.Layouts.AddElementToHeadTag.SetMeta"
    DynamicMasterPageFile="~masterurl/default.master" %>

<%@ Register TagPrefix="HeadInTagControl" TagName="HeadInTagControl" Src="~/_controltemplates/AddElementToHeadTag/HeadInTag.ascx" %>
<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Head in tag Demo
</asp:Content>
<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea"
    runat="server">
    Head in tag Demo
</asp:Content>
<asp:Content ID="PlaceHolderMain" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <style type="text/css">
        table td
        {
            padding: 4px;
        }
    </style>
    <table>
        <caption>
            Add Meta for the specified page</caption>
        <tr>
            <td>
                Page Name:
            </td>
            <td>
                <asp:TextBox ID="tbPageName" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Key:
            </td>
            <td>
                <asp:TextBox ID="tbKey" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Description:
            </td>
            <td>
                <asp:TextBox ID="tbDescription" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="cmdAddMeta" runat="server" Text="Set Meta" OnClick="cmdAddMeta_Click" />
            </td>
        </tr>
    </table>
    <table>
        <caption>
            Default Meta:for all pages.</caption>
        <tr>
            <td>
                Key:
            </td>
            <td>
                <asp:TextBox ID="tbDefaultKey" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Description:
            </td>
            <td>
                <asp:TextBox ID="tbDefaultDescription" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="cmdAddDefaultMeta" runat="server" Text="Set Default Meta" OnClick="cmdAddDefaultMeta_Click" />
            </td>
        </tr>
    </table>
    <asp:Literal ID="ltrMsg" runat="server"></asp:Literal>
</asp:Content>
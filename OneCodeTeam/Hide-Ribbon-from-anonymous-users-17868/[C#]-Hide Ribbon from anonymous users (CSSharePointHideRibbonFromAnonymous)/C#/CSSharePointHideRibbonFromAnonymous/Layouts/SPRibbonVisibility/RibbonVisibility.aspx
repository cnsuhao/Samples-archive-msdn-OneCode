<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" Src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" Src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RibbonVisibility.aspx.cs"
    Inherits="RibbonVisibility.Layouts.RibbonVisibilitySettings"
    DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <wssuc:InputFormSection runat="server" Title="Ribbon Visibility Settings" Description="Use this section to define for which groups the ribbon need to be displayed">
        <template_inputformcontrols>       
  
     <div runat="server" id="divParameters">   
     <div runat="server" id="divConditional">
     <table>
        <tr>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td>
                Anonymous user 
            </td>
            <td>
                <asp:CheckBox runat="server" ID="chkAnonymous" Text="Hide the ribbon for anonymous user" />
            </td>
        </tr>      
        </table>
        </div>
        </div>
        <br /><br />
        <div>
                <asp:CheckBox runat="server" ID="chkApplyToChildren" Text="Apply this setting to all subsites" /><br />
                <asp:Button runat="server" ID="btnSave" Text="Save" />
                <asp:Button runat="server" ID="btnCancel" Text="Cancel" />
        </div>
    </template_inputformcontrols>
    </wssuc:InputFormSection>
</asp:Content>
<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Ribbon Visibility Settings
</asp:Content>
<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea"
    runat="server">
    Ribbon Visibility Settings
</asp:Content>

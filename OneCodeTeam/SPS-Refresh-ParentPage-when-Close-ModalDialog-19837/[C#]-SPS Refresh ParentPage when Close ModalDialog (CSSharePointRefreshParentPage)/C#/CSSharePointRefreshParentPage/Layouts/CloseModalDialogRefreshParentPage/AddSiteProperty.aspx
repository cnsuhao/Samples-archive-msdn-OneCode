<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSiteProperty.aspx.cs" Inherits="CSSharePointRefreshParentPage.Layouts.CloseModalDialogRefreshParentPage.AddSiteProperty" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
<script language="javascript" type="text/javascript">
    // <![CDATA[
    function _spFormOnSubmit() {
	    var L_alert1_text = "<SharePoint:EncodedLiteral runat='server' text='Site property name cannot be empty.' EncodeMethod='EcmaScriptStringLiteralEncode'/>";
	    document.getElementById(<%SPHttpUtility.AddQuote(SPHttpUtility.NoEncode(NameInputFormTextBox.ClientID),Response.Output);%>).value = TrimSpaces(document.getElementById(<%SPHttpUtility.AddQuote(SPHttpUtility.NoEncode(NameInputFormTextBox.ClientID),Response.Output);%>).value);
	    if (document.getElementById(<%SPHttpUtility.AddQuote(SPHttpUtility.NoEncode(NameInputFormTextBox.ClientID),Response.Output);%>).value.length < 1) {
		    window.alert(L_alert1_text);
		    document.getElementById(<%SPHttpUtility.AddQuote(SPHttpUtility.NoEncode(NameInputFormTextBox.ClientID),Response.Output);%>).focus();
		    return false;
	    }
    }
    function _spBodyOnLoad() {
	    try {
            document.getElementById(<%SPHttpUtility.AddQuote(SPHttpUtility.NoEncode(NameInputFormTextBox.ClientID),Response.Output);%>).focus();
        } catch(e) {}
    }
    // ]]>
</script>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    <SharePoint:EncodedLiteral runat="server" text="Add Site Property" EncodeMethod='HtmlEncode'/>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <table class="propertysheet" border="0" width="100%" cellspacing="0" cellpadding="0">
    <wssuc:InputFormSection Title="Property Name" Description="Type a value for this custom property." runat="server">
	    <Template_InputFormControls>
		    <wssuc:InputFormControl LabelText="Name" runat="server">
                <Template_Control>
                    <wssawc:InputFormTextBox ID="NameInputFormTextBox" Title="Name" class="ms-input" Columns="40" Runat="server" MaxLength="255" /><br/><asp:Label ID="NameErrorLabel" CssClass="ms-error" EnableViewState="false" runat="server" />
                </Template_Control>
		    </wssuc:InputFormControl>
	    </Template_InputFormControls>
    </wssuc:InputFormSection>
    <wssuc:InputFormSection Title="Property Value" Description="Type a value for this custom property." runat="server">
	    <Template_InputFormControls>
		    <wssuc:InputFormControl LabelText="Value" runat="server">
                <Template_Control>
                    <wssawc:InputFormTextBox ID="ValueInputFormTextBox" Title="Value" class="ms-input" Columns="40" Runat="server" MaxLength="255" />
                </Template_Control>
		    </wssuc:InputFormControl>
	    </Template_InputFormControls>
    </wssuc:InputFormSection>
    <wssuc:ButtonSection BottomSpacing="0" runat="server">
        <Template_Buttons>
            <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="OKButton_Click" Text="<%$Resources:wss,multipages_okbutton_text%>" ID="OKButton" accesskey="<%$Resources:wss,okbutton_accesskey%>"/>
        </Template_Buttons>
    </wssuc:ButtonSection>
    </table>
</asp:Content>
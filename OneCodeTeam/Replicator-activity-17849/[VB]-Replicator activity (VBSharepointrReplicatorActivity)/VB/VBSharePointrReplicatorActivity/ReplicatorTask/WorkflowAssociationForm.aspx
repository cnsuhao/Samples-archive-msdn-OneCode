﻿<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Register TagPrefix="wssuc" TagName="LinksTable" Src="/_controltemplates/LinksTable.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" Src="/_controltemplates/InputFormSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" Src="/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="LinkSection" Src="/_controltemplates/LinkSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" Src="/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ActionBar" Src="/_controltemplates/ActionBar.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ToolBar" Src="/_controltemplates/ToolBar.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ToolBarButton" Src="/_controltemplates/ToolBarButton.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="Welcome" Src="/_controltemplates/Welcome.ascx" %>
<%@ Register TagPrefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Workflow" Namespace="Microsoft.SharePoint.Workflow" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="VB" AutoEventWireup="true" CodeBehind="WorkflowAssociationForm.aspx.vb"
    Inherits="VBSharePointReplicatorActivity.Layouts.VBSharePointReplicatorActivity.WorkflowAssociationForm"
    DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <table border="0" cellspacing="0" cellpadding="0" class="ms-propertysheet">
        <wssuc:InputFormSection ID="InputFormSection1" runat="server" Title="Partners">
            <template_description>These are the person who will participate in the workflow.</template_description>
            <template_inputformcontrols>
				<tr valign="top">
					<td class="ms-authoringcontrols" width="10">&#160;</td>
					<td class="ms-authoringcontrols" colspan="2">
						<label for="ContentTypeSelector">
              <SharePoint:EncodedLiteral 
                ID="EncodedLiteral2" 
                runat="server" 
                text="Select Approver" 
                EncodeMethod='HtmlEncode'/></label>
						<br/>
						<table border="0" cellspacing="1">
						<tr>
						<td>&#160;</td>
						<td class="ms-authoringcontrols">
	            <SharePoint:PeopleEditor
                id ="pickerApprover"
                runat="server"    
                width='330px' 
                MultiSelect="true"
		            ValidatorEnabled="true"/>
					
						</td>
						</tr>			
						</table>
					</td>
				</tr>
			</template_inputformcontrols>
        </wssuc:InputFormSection>
        <wssuc:InputFormSection ID="InputFormSection3" runat="server" Title="Instructions to approver">
            <template_description>Default instructions to approver.</template_description>
            <template_inputformcontrols>
				<tr valign="top">
					<td class="ms-authoringcontrols" width="10">&#160;</td>
					<td class="ms-authoringcontrols" colspan="2">
					     <asp:TextBox 
                  ID="txtInstructions" 
                  runat="server" 
                  TextMode="MultiLine" 
                  Width="400"
                  Rows="12"/>
					</td>
				</tr>
			</template_inputformcontrols>
        </wssuc:InputFormSection>
        <wssuc:ButtonSection runat="server" ID="btnsSaveCancel" ShowStandardCancelButton="false"
            ShowSectionLine="true" TopButtons="true">
            <template_buttons>
			<asp:PlaceHolder ID="PlaceHolder1" runat="server">
				<asp:Button ID="AssociateWorkflow" runat="server" OnClick="AssociateWorkflow_Click" Text="Save Association" CssClass="ms-ButtonHeightWidth" />
			</asp:PlaceHolder>
			<asp:PlaceHolder ID="PlaceHolder2" runat="server">
		    <asp:Button ID="Cancel" runat="server" Text="Cancel" OnClick="Cancel_Click" CssClass="ms-ButtonHeightWidth"  />		
			</asp:PlaceHolder>
		</template_buttons>
        </wssuc:ButtonSection>
    </table>
</asp:Content>
<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Association Form
</asp:Content>
<asp:Content ID="PageTitleInTitleArea" runat="server" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea">
    Association Form
</asp:Content>
<asp:Content ID="AdditionalPageHead" runat="server" ContentPlaceHolderID="PlaceHolderAdditionalPageHead">
    <SharePoint:ScriptLink ID="PickerHierarchyControl" runat="server" LoadAfterUI="true"
        Localizable="false" Name="PickerHierarchyControl.js" />
    <style type="text/css">
        #divFormBody
        {
            padding: 8px;
            width: 600px;
            background-color: #EEEEEE;
        }
        
        #divCommandButtons
        {
            padding: 20px;
            text-align: right;
        }
        
        .FormTitle
        {
            font-size: 14pt;
        }
        
        
        .FormCaption
        {
            font-size: 10pt;
            font-weight: bold;
            margin-top: 10px;
            margin-bottom: 4px;
        }
    </style>
</asp:Content>

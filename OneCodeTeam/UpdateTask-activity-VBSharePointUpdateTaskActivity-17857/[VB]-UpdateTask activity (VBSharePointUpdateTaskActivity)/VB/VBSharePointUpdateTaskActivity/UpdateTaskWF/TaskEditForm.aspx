<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
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

<%@ Page Language="VB" AutoEventWireup="true" CodeBehind="TaskEditForm.aspx.vb" Inherits="VBSharePointUpdateTaskActivity.MyWorkflow.Layouts.UpdateTaskWF.TaskEditForm"
 DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <table border="0" cellspacing="0" cellpadding="0" class="ms-propertysheet">
        <%-- Hyperlink to item/document --%>
        <wssuc:InputFormSection Title="Approval Request" Description="Please review this document."
            runat="server">
            <template_description>You must approve or reject this proposal.</template_description>
            <template_inputformcontrols>
                <wssuc:InputFormControl LabelText="Click on item hyperlink below to review document" runat="server">                  
                  <Template_Control>
                      <tr>
                        <td style="padding: 4px" >Item:</td>
                        <td style="padding: 4px" ><asp:HyperLink runat="Server" ID="lnkItem" Target="_blank" /></td>
                      </tr>
                      <tr>
                        <td style="padding: 4px" >List:</td>
                        <td style="padding: 4px" ><asp:Label runat="server" ID="lblListName" /></td>
                      </tr>
                      <tr>
                        <td style="padding: 4px" >Site:</td>
                        <td style="padding: 4px" ><asp:Label runat="server" ID="lblSiteUrl" /></td>
                      </tr>              
                  </Template_Control>
                </wssuc:InputFormControl>
            </template_inputformcontrols>
        </wssuc:InputFormSection>
        <wssuc:InputFormSection ID="InputFormSection1" runat="server" Title="Instructions to approver">
            <template_description>read before approving or rejecting proposal.</template_description>
            <template_inputformcontrols>
				<tr valign="top">
					<td class="ms-authoringcontrols" width="10">&#160;</td>
					<td class="ms-authoringcontrols" colspan="2">
					    <asp:Label runat="server" ID="lblInstructions" Width="400" ForeColor="Red">
            Please review then approve or reject this  proposal.
                        </asp:Label>                        						
					</td>
				</tr>
			</template_inputformcontrols>
        </wssuc:InputFormSection>
        <wssuc:InputFormSection ID="InputFormSection2" runat="server" Title="Approver Comments">
            <template_description>Enter comments about your decision.</template_description>
            <template_inputformcontrols>
				<tr valign="top">
					<td class="ms-authoringcontrols" width="10">&#160;</td>
					<td class="ms-authoringcontrols" colspan="2">
						<label for="ContentTypeSelector">
              <SharePoint:EncodedLiteral 
                ID="EncodedLiteral1" 
                runat="server" 
                text="Add Your Comments" 
                EncodeMethod='HtmlEncode'/></label>
						<br/>
						<table border="0" cellspacing="1">
						<tr>
						<td>&#160;</td>
						<td class="ms-authoringcontrols">
               <asp:TextBox 
                  ID="txtComments" 
                  runat="server" 
                  TextMode="MultiLine" 
                  Width="400"
                  Rows="8"/>
						</td>
						</tr>				
						</table>
					</td>
				</tr>
			</template_inputformcontrols>
        </wssuc:InputFormSection>
        <wssuc:ButtonSection ID="ButtonSection1" runat="server" ShowStandardCancelButton="false">
            <template_buttons>
      <asp:PlaceHolder ID="PlaceHolder1" runat="server">                
        <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="btnCancel_Click" Text="Approve" id="btnApprove" /> &nbsp;
        <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="btnReject_Click" Text="Reject" id="btnReject"  /> &nbsp;
        <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="btnCancel_Click" Text="Cancel" id="btnCancel"  />
      </asp:PlaceHolder>
      </template_buttons>
        </wssuc:ButtonSection>
    </table>
</asp:Content>
<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Approval Initiation Form
</asp:Content>
<asp:Content ID="PageTitleInTitleArea" runat="server" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea">
    Approval Initiation Form
</asp:Content>
<asp:Content ID="AdditionalPageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead"
    runat="server">
    <SharePoint:CssRegistration ID="CssRegistration1" Name="forms.css" runat="server" />
    <SharePoint:CssRegistration ID="CssRegistration2" Name="layouts.css" runat="server" />
</asp:Content>

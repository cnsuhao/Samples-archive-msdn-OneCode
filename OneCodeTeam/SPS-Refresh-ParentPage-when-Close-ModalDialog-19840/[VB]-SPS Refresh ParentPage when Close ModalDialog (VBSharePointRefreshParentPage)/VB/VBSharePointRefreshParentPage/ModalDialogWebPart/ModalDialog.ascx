<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="wssuc" TagName="ToolBar" Src="~/_controltemplates/ToolBar.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ToolBarButton" Src="~/_controltemplates/ToolBarButton.ascx" %>
<%@ Control Language="VB" AutoEventWireup="true" CodeBehind="ModalDialog.ascx.vb"
    Inherits="VBSharePointRefreshParentPage.ModalDialogWebPartUserControl" %>
<script type="text/javascript">
     // <![CDATA[
    function openSitePropertyDialog(url) {
        var dialogOptions = SP.UI.$create_DialogOptions();
        dialogOptions.width = 800;
        dialogOptions.height = 400;
        dialogOptions.dialogReturnValueCallback = Function.createDelegate(null, sitePropertiesDialogCallback);
        commonModalDialogOpen(
				url,
				dialogOptions,
				sitePropertiesDialogCallback,
				null);
    }
    function sitePropertiesDialogCallback(dialogResult, returnValue) {
        if (returnValue != null) {
            var notificationId = SP.UI.Notify.addNotification(returnValue, false);
        }
        SP.UI.ModalDialog.RefreshPage(dialogResult);
        //refreshUpdatePanelOnDialogCallback(dialogResult);
    }
    function refreshUpdatePanelOnDialogCallback(dialogResult) {
        if (dialogResult == SP.UI.DialogResult.OK) {
            __doPostBack(<%SPHttpUtility.AddQuote(SPHttpUtility.NoEncode(SitePropertiesUpdatePanel.ClientID),Response.Output)%>);
        }
    }
    // ]]>    
</script>
<div>
    <wssuc:ToolBar ID="AddToolBar" runat="server">
        <Template_Buttons>
            <wssuc:ToolBarButton runat="server" Text="<%$Resources:wss,multipages_createbutton_text%>"
                ID="AddToolBarButton" ToolTip="Add site property" NavigateUrl="javascript:openSitePropertyDialog(ADD_SITE_PROPERTY_URL);"
                ImageUrl="/_layouts/images/newitem.gif" AccessKey="C" />
        </Template_Buttons>
    </wssuc:ToolBar>
</div>
<asp:UpdatePanel ID="SitePropertiesUpdatePanel" ChildrenAsTriggers="true" UpdateMode="Conditional"
    runat="server">
    <ContentTemplate>
        <SharePoint:SPGridView runat="server" ID="SitePropertiesGridView" Width="100%" AutoGenerateColumns="false"
            EnableViewState="false">
            <AlternatingRowStyle CssClass="ms-alternating" />
            <Columns>
                <asp:TemplateField HeaderText="Property Name" HeaderStyle-Width="30%" HeaderStyle-CssClass="ms-vh2-nofilter">
                    <ItemTemplate>

                         <a href="#" onclick="openSitePropertyDialog('<%# GetEditSitePropertyUrl(SPHttpUtility.UrlKeyValueEncode(DirectCast(DataBinder.Eval(Container.DataItem, "Name"), String))) %>');return false;">
                           
                           <%# SPHttpUtility.HtmlEncode(DirectCast(DataBinder.Eval(Container.DataItem, "Name"), String)) %>
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Value" HeaderText="Property Value" HeaderStyle-Width="70%"
                    HeaderStyle-CssClass="ms-vh2-nofilter" />
            </Columns>
        </SharePoint:SPGridView>
    </ContentTemplate>
</asp:UpdatePanel>

<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisualWebPart1UserControl.ascx.cs"
    Inherits="CSSharePointshowDataWithMultipleValueField.VisualWebPart1.VisualWebPart1UserControl" %>
<SharePoint:SPGridView runat="server" ID="MyGridView" Width="100%" EnableViewState="false"
    AutoGenerateColumns="false" OnRowDataBound="SPGridView1_RowDataBound">
    <Columns>
        <asp:BoundField DataField="Title" HeaderText="Title" HeaderStyle-Width="70%" HeaderStyle-CssClass="ms-vh2-nofilter" />
        <asp:TemplateField HeaderText="AssignedTo" HeaderStyle-Width="70%" HeaderStyle-CssClass="ms-vh2-nofilter">
            <ItemTemplate>
                <SharePoint:SPGridView runat="server" ID="gdvPeople" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Uname" HeaderText="" HeaderStyle-Width="70%" HeaderStyle-CssClass="ms-vh2-nofilter" />
                    </Columns>
                </SharePoint:SPGridView>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="LastModifiedTime" HeaderText="LastModifiedTime" HeaderStyle-Width="70%"
            HeaderStyle-CssClass="ms-vh2-nofilter" />    
    </Columns>
</SharePoint:SPGridView>

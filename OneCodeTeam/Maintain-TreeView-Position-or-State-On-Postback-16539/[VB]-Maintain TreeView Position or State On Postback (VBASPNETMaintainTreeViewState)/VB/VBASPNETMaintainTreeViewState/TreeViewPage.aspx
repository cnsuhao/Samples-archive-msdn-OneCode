<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TreeViewPage.aspx.vb" Inherits="VBASPNETMaintainTreeViewState.TreeViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Maintain TreeView&#39;s state across postbacks..<br />
        <br />
    
        <asp:TreeView ID="tvwNodes" runat="server" EnableViewState="False" 
            ImageSet="Msdn" NodeIndent="10" Font-Size="Large">
            <HoverNodeStyle BackColor="#CCCCCC" BorderColor="#888888" BorderStyle="Solid" 
                Font-Underline="True" />
            <Nodes>
                <asp:TreeNode Expanded="False" Text="node 1" Value="1">
                    <asp:TreeNode Text="node 1-1" Value="node 1-1">
                        <asp:TreeNode Text="node 1-1-1" Value="node 1-1-1"></asp:TreeNode>
                        <asp:TreeNode Text="node 1-1-2" Value="node 1-1-2"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="node 1-2" Value="node 1-2"></asp:TreeNode>
                    <asp:TreeNode Text="node 1-3" Value="node 1-3"></asp:TreeNode>
                    <asp:TreeNode Text="node 1-4" Value="node 1-4">
                        <asp:TreeNode Text="node 1-4-1" Value="node 1-4-1"></asp:TreeNode>
                        <asp:TreeNode Text="node 1-4-2" Value="node 1-4-2"></asp:TreeNode>
                        <asp:TreeNode Text="node 1-4-3" Value="node 1-4-3"></asp:TreeNode>
                    </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="node 2" Value="node 2">
                    <asp:TreeNode Text="node 2-1" Value="node 2-1">
                        <asp:TreeNode Text="node 2-1-1" Value="node 2-1-1"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="node 2-2" Value="node 2-2">
                        <asp:TreeNode Text="node 2-2-1" Value="node 2-2-1"></asp:TreeNode>
                        <asp:TreeNode Text="node 2-2-2" Value="node 2-2-2"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="node 2-3" Value="node 2-3"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="node 3" Value="node 3"></asp:TreeNode>
            </Nodes>
            <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
                HorizontalPadding="5px" NodeSpacing="1px" VerticalPadding="2px" />
            <ParentNodeStyle Font-Bold="False" />
            <SelectedNodeStyle BackColor="White" BorderColor="#888888" BorderStyle="Solid" 
                BorderWidth="1px" Font-Underline="False" HorizontalPadding="3px" 
                VerticalPadding="1px" />
        </asp:TreeView>
        <br />
        <asp:Button ID="btnSaveTreeViewState" runat="server" 
            onclick="btnSaveTreeViewState_Click" Text="Save TreeView State" />
    
        &nbsp;&nbsp;&nbsp;
    
        <asp:Button ID="btnRefresh" runat="server" onclick="btnRefresh_Click" 
            Text="Refresh This Page" />
    </div>
    </form>
</body>
</html>

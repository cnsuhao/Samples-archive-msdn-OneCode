<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OnlineFileSystem.aspx.vb" Inherits="VBASPNETOnlineFileSystem.OnlineFileSystem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .style1
        {
            width: 110px;
        }
        </style>
</head>
<body style="font-family:Calibri;font-size:11pt">
    <form id="form1" runat="server">
    <div>
        <h1>
            Basic Online File System</h1>
    </div>
    <div>
    </div>
    <div id="divFileUpload">
        Choose the file you want to upload:
        <br />
        <asp:FileUpload ID="fuChooseFile" runat="server" Width="506px" />
        <asp:Button ID="btnUpload" runat="server" Height="23px" 
            onclick="btnUpload_Click" Text="Upload File" Width="100px" />
    </div>
    <div id="divNewFolder">
        Input the name of the folder you want to create:
        <br />
        <asp:TextBox ID="tbNewFolderName" runat="server" Width="500px"></asp:TextBox>
        <asp:Button ID="btnNewFolder" runat="server" Height="23px" 
            onclick="btnNewFolder_Click" Text="Create Folder" Width="100px" />
        <asp:Panel ID="pnlRename" runat="server" Visible="false">
            <table style="width: 100%;">
                <tr>
                    <td align="center" colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp; Old Name:
                    </td>
                    <td class="style2">
                        &nbsp;<asp:Label ID="lbOldName" runat="server"></asp:Label>
                        &nbsp;</td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp; New Name:</td>
                    <td class="style2">
                        &nbsp;<asp:TextBox ID="tbNewName" runat="server" Width="300px"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp;</td>
                    <td class="style2">
                        <asp:Button ID="btnCancle" runat="server" Height="23px" 
                            onclick="btnCancle_Click" Text="Cancle" Width="100px" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnRename" runat="server" Height="23px" 
                            onclick="btnRename_Click" Text="Rename" Width="100px" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <div>
        <asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <div>
        <table style="width: 100%;">
            <tr>
                <td class="style1">
                    Current Location:
                </td>
                <td>
                    <asp:Panel ID="pnlCurrentLocation" runat="server" style="margin-left: 0px">
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    <asp:GridView ID="gvFileSystem" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataKeyNames="Type,FullPath,Location,Name" Font-Size="Small" 
        ForeColor="#333333" GridLines="None" onrowcommand="gvFileSystem_RowCommand" 
        onrowdatabound="gvFileSystem_RowDataBound">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:ButtonField CommandName="Open" DataTextField="Name" HeaderText="Name">
            <HeaderStyle HorizontalAlign="Left" Width="300px" />
            </asp:ButtonField>
            <asp:BoundField DataField="Size" HeaderText="Size">
            <HeaderStyle HorizontalAlign="Left" Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="UploadTime" HeaderText="Upload Time">
            <HeaderStyle HorizontalAlign="Left" Width="140px" />
            </asp:BoundField>
            <asp:BoundField DataField="Type" HeaderText="Type">
            <HeaderStyle HorizontalAlign="Left" Width="70px" />
            </asp:BoundField>
            <asp:ButtonField CommandName="DeleteFileOrFolder" DataTextField="FullPath" 
                DataTextFormatString="Delete" HeaderText="Delete">
            <HeaderStyle Width="50px" HorizontalAlign="Left" />
            <ItemStyle Width="50px" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Rename" DataTextField="FullPath" 
                DataTextFormatString="Rename" Text="ButtonField" HeaderText="Rename" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
            Height="18px" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" Height="16px" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Content.aspx.cs" Inherits="CSASPNETCompressFilesIntoSingleZip.Content" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to compress files into a single Zip file for download in ASP.NET</title>
    <style type="text/css">
        .hiddencol {
            display: none;
        }
    </style>

    <script type="text/javascript">

        function Validate(sender,args) {
            var gridView = document.getElementById("<%=gdvFolderContents.ClientID %>");
            var checkBoxes = gridView.getElementsByTagName("input");
            for (var i = 0; i < checkBoxes.length; i++) {
                if (checkBoxes[i].type == "checkbox" && checkBoxes[i].checked) {                    
                   return true;
                }
            }
            alert('Select at least one record');
            return false;
        }
    </script>  

</head>
<body>
    <form id="FolderContentsForm" runat="server">
        <div>
            <p>Select the files to download as Zip</p>
            <asp:GridView ID="gdvFolderContents" runat="server" AutoGenerateColumns="false" EmptyDataText="Folder is Empty">
                <Columns>
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Text" HeaderText="File Name" />                    
                    <asp:BoundField DataField="Value" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btnDownload" runat="server" Text="Download" OnClick="btnDownload_Click" OnClientClick="return Validate()"   />
        </div>
    </form>
</body>
</html>

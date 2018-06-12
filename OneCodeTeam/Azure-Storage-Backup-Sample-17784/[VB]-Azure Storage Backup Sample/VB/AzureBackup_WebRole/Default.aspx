<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="AzureBackup_WebRole._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button ID="btnUpload" runat="server" Text="Upload Resources to Storage" 
            onclick="btnUpload_Click" />
       
        <br />
        <asp:Label ID="lbContent" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <div style="border: 2px solid;">
        <div style="font-style:italic;font-weight:bold">
        Back up Blob Storage 
        Name Rule:
        <p>
            - Container names must start with a letter or number, and can contain only letters, numbers, and the dash (-) character.
        </p>
        <p>
            - Every dash (-) character must be immediately preceded and followed by a letter or number; consecutive dashes are not permitted in container names.
        </p>
        <p>
            - All letters in a container name must be lowercase.
        </p>
        <p>
            Container names must be from 3 through 63 characters long.
        </p>
        <p> Check: 
            <a href="http://msdn.microsoft.com/en-us/library/windowsazure/dd135715.aspx">http://msdn.microsoft.com/en-us/library/windowsazure/dd135715.aspx</a>&nbsp; </p>
        </div>
        <br />
        <br />
        Source Container Name:
        <asp:TextBox ID="tbSource" runat="server"></asp:TextBox>
        <br />
        Backup Container Name:
        <asp:TextBox ID="tbCopies" runat="server"></asp:TextBox>
        &nbsp;<br />
        <asp:Button ID="btnBackup" runat="server" Text="Back up your Blob" 
            onclick="btnBackup_Click" />
        <br />
        &nbsp;<br />
        <asp:Label ID="lbBackup" runat="server" ForeColor="Red"></asp:Label>
        </div>
        <br />
        <br />
        <div style="border: 2px solid;">
        <div style="font-style:italic;font-weight:bold">
        Back up Table Storage 
        Name Rule:<br />
         <p> - Table names may contain only alphanumeric characters.</p>


         <p> - Table names cannot begin with a numeric character. </p>


         <p> - Table names are case-insensitive.</p>


         <p> - Table names must be from 3 to 63 characters long.</p>
         <p> Check: 
             <a href="http://msdn.microsoft.com/en-us/library/windowsazure/dd179338.aspx">http://msdn.microsoft.com/en-us/library/windowsazure/dd179338.aspx</a>&nbsp; </p>
         </div>
        <br />
        <br />
        Source Table Name:
        <asp:TextBox ID="tbTabelSource" runat="server"></asp:TextBox>
        <br />
        Backup Table Name:
        <asp:TextBox ID="tbTableCopies" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnBackupTable" runat="server" Text="Back up your Table" onclick="btnBackupTable_Click" 
             />
        &nbsp;<br />
        <asp:Label ID="lbBackupTable" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>

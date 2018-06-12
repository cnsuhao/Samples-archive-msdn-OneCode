# How to set folder permissions in Office 365
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Exchange Online
* Office 365
## Topics
* Office 365
* folder permissions
## IsPublished
* True
## ModifiedDate
* 2013-06-05 12:10:06
## Description

<h1></h1>
<h1>How to Set Folder Permissions in Office 365 Exchange Online (VBOffice365SetPermissions)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">In this sample, we will demonstrate how to set the permissions in the folder of Office 365 Exchange online so that the customers can share their folders with the other customers.</p>
<p class="MsoNormal">We will finish the following the steps in the sample:</p>
<p class="MsoNormal">1. Add two permissions into the Calendar folder;</p>
<p class="MsoNormal">2. Update the permission in the Calendar;</p>
<p class="MsoNormal">3. Remove two permissions from the Calendar.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Press F5 to run the sample, the following is the result.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/83438/1/image.png" alt="" width="530" height="281" align="middle">
</span></p>
<p class="MsoNormal">Before any operations, we can find there're two permissions.</p>
<p class="MsoNormal">Then we need to input two email addresses to set the permissions later. So if we want to run the sample, we need one account and the according password to connect the Exchange, and need two email addresses to set the folder permissions.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/83439/1/image.png" alt="" width="532" height="129" align="middle">
</span><span style="">&nbsp;</span></p>
<p class="MsoNormal">After add two permissions, we can find two new permissions in the last two lines.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/83440/1/image.png" alt="" width="540" height="124" align="middle">
</span></p>
<p class="MsoNormal">After update the firs user's permission, we can find the third permission has changed.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/83441/1/image.png" alt="" width="642" height="127" align="middle">
</span></p>
<p class="MsoNormal">After remove two permissions, we can find there're only two permissions left.</p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
1. Add permissions</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
First, we create the new permissions.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim newPermissions() As FolderPermission =
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; New FolderPermission(users(0), FolderPermissionLevel.None),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; New FolderPermission(users(1), FolderPermissionLevel.Editor)
&nbsp;&nbsp;&nbsp; }

</pre>
<pre id="codePreview" class="vb">
Dim newPermissions() As FolderPermission =
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; New FolderPermission(users(0), FolderPermissionLevel.None),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; New FolderPermission(users(1), FolderPermissionLevel.Editor)
&nbsp;&nbsp;&nbsp; }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
We can't add duplicate permissions. So if we want to add some permission and there's permission belong to the same user, we should first remove it.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim permission As FolderPermission
permission = (
From op In folder.Permissions
Join np In newPermissions On
GetUpperString(op.UserId.PrimarySmtpAddress) Equals np.UserId.PrimarySmtpAddress.ToUpper()
Select op).FirstOrDefault()


If permission IsNot Nothing Then
&nbsp;&nbsp;&nbsp; RemoveFolderPermission(folder)
End If

</pre>
<pre id="codePreview" class="vb">
Dim permission As FolderPermission
permission = (
From op In folder.Permissions
Join np In newPermissions On
GetUpperString(op.UserId.PrimarySmtpAddress) Equals np.UserId.PrimarySmtpAddress.ToUpper()
Select op).FirstOrDefault()


If permission IsNot Nothing Then
&nbsp;&nbsp;&nbsp; RemoveFolderPermission(folder)
End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
At last, we add the permissions.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
folder.Permissions.AddRange(newPermissions)
folder.Update()

</pre>
<pre id="codePreview" class="vb">
folder.Permissions.AddRange(newPermissions)
folder.Update()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
2. Update permission</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
First, we get the permission that we want to update.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim permission As FolderPermission = (
&nbsp;&nbsp;&nbsp; From op In folder.Permissions
&nbsp;&nbsp;&nbsp; Where String.Compare(op.UserId.PrimarySmtpAddress, user.PrimarySmtpAddress, True) = 0
&nbsp;&nbsp;&nbsp; Select op).FirstOrDefault()

</pre>
<pre id="codePreview" class="vb">
Dim permission As FolderPermission = (
&nbsp;&nbsp;&nbsp; From op In folder.Permissions
&nbsp;&nbsp;&nbsp; Where String.Compare(op.UserId.PrimarySmtpAddress, user.PrimarySmtpAddress, True) = 0
&nbsp;&nbsp;&nbsp; Select op).FirstOrDefault()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Then we change the properties of the permission and save the changes.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
permission.PermissionLevel = FolderPermissionLevel.Reviewer
permission.ReadItems = FolderPermissionReadAccess.FullDetails
permission.IsFolderVisible = True
permission.EditItems = PermissionScope.None


folder.Update()

</pre>
<pre id="codePreview" class="vb">
permission.PermissionLevel = FolderPermissionLevel.Reviewer
permission.ReadItems = FolderPermissionReadAccess.FullDetails
permission.IsFolderVisible = True
permission.EditItems = PermissionScope.None


folder.Update()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
3. Remove Permissions</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
First we get the permissions list that we want to remove.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim permissions As IList(Of FolderPermission)
permissions = (
&nbsp;&nbsp; From op In folder.Permissions
&nbsp;&nbsp; Join u In users On
&nbsp;&nbsp; GetUpperString(op.UserId.PrimarySmtpAddress) Equals u.PrimarySmtpAddress.ToUpper()
&nbsp;&nbsp; Select op).ToList()

</pre>
<pre id="codePreview" class="vb">
Dim permissions As IList(Of FolderPermission)
permissions = (
&nbsp;&nbsp; From op In folder.Permissions
&nbsp;&nbsp; Join u In users On
&nbsp;&nbsp; GetUpperString(op.UserId.PrimarySmtpAddress) Equals u.PrimarySmtpAddress.ToUpper()
&nbsp;&nbsp; Select op).ToList()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Then we remove all the permissions.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
If folder.Permissions.Remove(permission) Then
&nbsp;&nbsp;&nbsp; folder.Update()
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;It's success to remove the permission of {0}.&quot;,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; permission.UserId.PrimarySmtpAddress)

</pre>
<pre id="codePreview" class="vb">
If folder.Permissions.Remove(permission) Then
&nbsp;&nbsp;&nbsp; folder.Update()
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;It's success to remove the permission of {0}.&quot;,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; permission.UserId.PrimarySmtpAddress)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/microsoft.exchange.webservices.data.folder.permissions(v=exchg.80).aspx">Folder.Permissions Property</a></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/dd633709(v=exchg.80).aspx">EWS Managed API 2.0</a>
<span class="MsoHyperlink"><span style="color:windowtext; text-decoration:none"></span></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

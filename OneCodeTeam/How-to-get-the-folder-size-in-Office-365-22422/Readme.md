# How to get the folder size in Office 365
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Exchange Online
* Office 365
## Topics
* Office 365
* foder size
## IsPublished
* True
## ModifiedDate
* 2013-06-05 12:12:33
## Description

<h1>How to Get the Folder and Subfolders Size in Office 365 Exchange Online (VBOffice365GetFolderSize)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">In this sample, we will demonstrate how to get the size of the folders and the subfolders.</p>
<p class="MsoNormal">In this sample, we will use two extended properties:</p>
<p class="MsoNormal">1. PidTagMessageSize(Property ID: 0x0E08);</p>
<p class="MsoNormal">2. PR_FOLDER_PATHNAME (Property ID: 0x66B5).</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Press F5 to run the sample, the following is the result.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/83472/1/image.png" alt="" width="519" height="406" align="middle">
</span></p>
<p class="MsoNormal">First, we need to input the account and the password.</p>
<p class="MsoNormal">Second, the AutoDiscoverUrl method will connect to the server and get the url.</p>
<p class="MsoNormal">Finally, we will get the folder (&quot;Inbox&quot;) and the subfolders, and then output the size of them.</p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
1. We use two extended properties to get the size and path of the folders.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
We use the <span style="color:black">PidTagMessageSizeExtended extended property to get the size of the folders.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Const PidTagMessageSizeExtended As Int32 = 3592
Dim exPropFolderSize As New ExtendedPropertyDefinition(PidTagMessageSizeExtended, MapiPropertyType.Integer)

</pre>
<pre id="codePreview" class="vb">
Const PidTagMessageSizeExtended As Int32 = 3592
Dim exPropFolderSize As New ExtendedPropertyDefinition(PidTagMessageSizeExtended, MapiPropertyType.Integer)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="color:black"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
We use the <span style="color:black">PR_FOLDER_PATHNAME extended property to get the path of the folders.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Const PR_FOLDER_PATHNAME As Int32 = 26293
Dim exPropPathName As New ExtendedPropertyDefinition(PR_FOLDER_PATHNAME, MapiPropertyType.String)

</pre>
<pre id="codePreview" class="vb">
Const PR_FOLDER_PATHNAME As Int32 = 26293
Dim exPropPathName As New ExtendedPropertyDefinition(PR_FOLDER_PATHNAME, MapiPropertyType.String)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
2. We first get the &quot;Inbox&quot; folder.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
We use the SearchFilter to set the filter.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim searchFilter As SearchFilter.RelationalFilter =
&nbsp;&nbsp;&nbsp; New SearchFilter.IsEqualTo(FolderSchema.DisplayName, &quot;Inbox&quot;)

</pre>
<pre id="codePreview" class="vb">
Dim searchFilter As SearchFilter.RelationalFilter =
&nbsp;&nbsp;&nbsp; New SearchFilter.IsEqualTo(FolderSchema.DisplayName, &quot;Inbox&quot;)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Then we get the folder.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
searchResults = service.FindFolders(WellKnownFolderName.MsgFolderRoot, filter, folderView)

</pre>
<pre id="codePreview" class="vb">
searchResults = service.FindFolders(WellKnownFolderName.MsgFolderRoot, filter, folderView)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
We also need to get the subfolders.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
If filter IsNot Nothing Then
&nbsp;&nbsp;&nbsp; GetFoldersSize(service, f)
End If

</pre>
<pre id="codePreview" class="vb">
If filter IsNot Nothing Then
&nbsp;&nbsp;&nbsp; GetFoldersSize(service, f)
End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
3. Get the subfolders</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
We set the <span style="color:black">folderView.Traversal with FolderTraversal.Deep so that we can get all the subfolders.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
folderView.Traversal = FolderTraversal.Deep
searchResults = folder.FindFolders(folderView)

</pre>
<pre id="codePreview" class="vb">
folderView.Traversal = FolderTraversal.Deep
searchResults = folder.FindFolders(folderView)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/cc433490(v=exchg.80).aspx"><span style="">[MS-OXPROPS]: Exchange Server Protocols Master Property List</span></a><span class="MsoHyperlink">
</span></p>
<p class="MsoNormal"><span class="MsoHyperlink"><a href="http://msdn.microsoft.com/en-us/library/dd634678(v=exchg.80).aspx"><span style="">&nbsp;</span>ExtendedPropertyDefinition Class</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

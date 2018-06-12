# How to sort task list items by categories in Office 365
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Exchange Online
* Office 365
## Topics
* Office 365
* sort tasks
## IsPublished
* True
## ModifiedDate
* 2013-06-04 11:42:15
## Description

<h1>How to Sort Task List Items by Categories in Office 365 Exchange Online (VBOffice365SortTasks)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">We can sort the task list items in Outlook, but the feature isn't implemented in Outlook Web App (OWA). In this sample, we will demonstrate how to sort task list items by categories in Office 365 Exchange Online.</p>
<p class="MsoNormal">We will add the category name as a prefix in the Subject property of a task item so that we can use sort by Subject to sort by category.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Press F5 to run the sample, the following is the result.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/83375/1/image.png" alt="" width="436" height="280" align="middle">
</span></p>
<p class="MsoNormal">First, we use our account to connect the Exchange Online.</p>
<p class="MsoNormal">And then get the folders that contain the task items. After that, we will add the category name as<span style="">&nbsp;
</span>a prefix in the Subject property of a task item.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/83376/1/image.png" alt="" width="373" height="224" align="middle">
</span><span style="">&nbsp;</span></p>
<p class="MsoNormal">Now the task items are sorted by the categories by choosing &quot;Arrange by Subject&quot;.</p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
1. Get the task folders.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
We will get all the folders that contain the task items. And you can define the specific name of the folder that need to implement the sorting operation.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim filters As New SearchFilter.SearchFilterCollection(LogicalOperator.And)


If Not String.IsNullOrEmpty(folderName) Then
&nbsp;&nbsp;&nbsp; Dim searchFilterName As SearchFilter =
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; New SearchFilter.IsEqualTo(FolderSchema.DisplayName, folderName)
&nbsp;&nbsp;&nbsp; filters.Add(searchFilterName)
End If


Dim searchFilterClass As SearchFilter =
&nbsp;&nbsp;&nbsp; New SearchFilter.IsEqualTo(FolderSchema.FolderClass, &quot;IPF.Task&quot;)
filters.Add(searchFilterClass)


Dim taskFolders As List(Of Folder) =
&nbsp;&nbsp;&nbsp; GetFolders(service, filters, WellKnownFolderName.Root, True)

</pre>
<pre id="codePreview" class="vb">
Dim filters As New SearchFilter.SearchFilterCollection(LogicalOperator.And)


If Not String.IsNullOrEmpty(folderName) Then
&nbsp;&nbsp;&nbsp; Dim searchFilterName As SearchFilter =
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; New SearchFilter.IsEqualTo(FolderSchema.DisplayName, folderName)
&nbsp;&nbsp;&nbsp; filters.Add(searchFilterName)
End If


Dim searchFilterClass As SearchFilter =
&nbsp;&nbsp;&nbsp; New SearchFilter.IsEqualTo(FolderSchema.FolderClass, &quot;IPF.Task&quot;)
filters.Add(searchFilterClass)


Dim taskFolders As List(Of Folder) =
&nbsp;&nbsp;&nbsp; GetFolders(service, filters, WellKnownFolderName.Root, True)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
2. Rename the task items.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
For each task items in the folders, we will rename it.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
findResults = folder.FindItems(itemView)
For Each item As Item In findResults.Items
&nbsp;&nbsp;&nbsp; ' If the item is the task, rename the item.
&nbsp;&nbsp;&nbsp; If TypeOf item Is Task Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RenameTask(TryCast(item, Task))
&nbsp;&nbsp;&nbsp; End If
Next item

</pre>
<pre id="codePreview" class="vb">
findResults = folder.FindItems(itemView)
For Each item As Item In findResults.Items
&nbsp;&nbsp;&nbsp; ' If the item is the task, rename the item.
&nbsp;&nbsp;&nbsp; If TypeOf item Is Task Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RenameTask(TryCast(item, Task))
&nbsp;&nbsp;&nbsp; End If
Next item

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Add the category name as the prefix in the Subject property of the task item so that we can sort it by the category by sorting by the Subject.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim preCategory As String = &quot;[&quot; & task.Categories(0).ToString() & &quot;]&quot;


If Not task.Subject.Contains(preCategory) Then
&nbsp;&nbsp;&nbsp; task.Subject = preCategory & task.Subject
&nbsp;&nbsp;&nbsp; task.Update(ConflictResolutionMode.AutoResolve)
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Rename task as {0}&quot;, task.Subject)
End If

</pre>
<pre id="codePreview" class="vb">
Dim preCategory As String = &quot;[&quot; & task.Categories(0).ToString() & &quot;]&quot;


If Not task.Subject.Contains(preCategory) Then
&nbsp;&nbsp;&nbsp; task.Subject = preCategory & task.Subject
&nbsp;&nbsp;&nbsp; task.Update(ConflictResolutionMode.AutoResolve)
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Rename task as {0}&quot;, task.Subject)
End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/dd633709(v=exchg.80).aspx">EWS Managed API 2.0</a>
</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/query/dev10.query?appId=Dev10IDEF1&l=EN-US&k=k(MICROSOFT.EXCHANGE.WEBSERVICES.DATA.TASK);k(TargetFrameworkMoniker-%22.NETFRAMEWORK%2cVERSION%3dV4.0%22);k(DevLang-CSHARP)&rd=true">Task Class</a><span class="MsoHyperlink"><span style="color:windowtext; text-decoration:none">
</span></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

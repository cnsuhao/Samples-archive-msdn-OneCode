# How to Get Large Mailbox Statistics in Office365
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Exchange Online
* Office 365
## Topics
* office365
* Folder Statistics
## IsPublished
* True
## ModifiedDate
* 2013-06-05 12:09:53
## Description

<h1>How to Get Folder Statistics for Large Mailbox in Office 365 Exchange Online (CSOffice365GetFolderStatistics)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">Some of you find your Outlook is frozen when receiving emails. One workaround is moving the large emails to a new folder to allow Outlook finish the synchronization. But before moving these large emails, we need to identify these large
 email messages and find a proper destination folder for these emails. In this sample, we will demonstrate how to get the statistics of the folders and the subfolders.
</p>
<p class="MsoNormal">In this sample, we will use two extended properties: </p>
<p class="MsoNormal">1. PidTagMessageSize(Property ID: 0x0E08); </p>
<p class="MsoNormal">2. PR_FOLDER_PATHNAME (Property ID: 0x66B5). </p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Press F5 to run the sample, the following is the result.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/83432/1/image.png" alt="" width="641" height="112" align="middle">
</span></p>
<p class="MsoNormal">First, we use our account to connect the Exchange Online.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/83433/1/image.png" alt="" width="643" height="374" align="middle">
</span><span style="">&nbsp;</span></p>
<p class="MsoNormal">After get the root folders and the subfolders, this sample will show the folders' DisplayName, the path, the size, the number of all the items, the number of the items with attachments, the number of the large items.</p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
1. Get the root folders and the subfolders</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
a. Two extend properties.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
We use two extend properties in this sample to get the size and path information of the folders.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
const Int32 pidTagMessageSizeExtended = 3592;
ExtendedPropertyDefinition exPropFolderSize = 
&nbsp;&nbsp;&nbsp;&nbsp;new ExtendedPropertyDefinition(pidTagMessageSizeExtended, MapiPropertyType.Integer);
const Int32 PR_FOLDER_PATHNAME = 26293;
ExtendedPropertyDefinition exPropDefPathName = 
&nbsp;&nbsp;&nbsp;&nbsp;new ExtendedPropertyDefinition(PR_FOLDER_PATHNAME, MapiPropertyType.String);

</pre>
<pre id="codePreview" class="csharp">
const Int32 pidTagMessageSizeExtended = 3592;
ExtendedPropertyDefinition exPropFolderSize = 
&nbsp;&nbsp;&nbsp;&nbsp;new ExtendedPropertyDefinition(pidTagMessageSizeExtended, MapiPropertyType.Integer);
const Int32 PR_FOLDER_PATHNAME = 26293;
ExtendedPropertyDefinition exPropDefPathName = 
&nbsp;&nbsp;&nbsp;&nbsp;new ExtendedPropertyDefinition(PR_FOLDER_PATHNAME, MapiPropertyType.String);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
b. Get the root folders.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
SearchFilter rootFilter = new SearchFilter.IsEqualTo(FolderSchema.DisplayName, &quot;Inbox&quot;);


List&lt;Folder&gt; rootFolders = GetFolders(service, rootFilter, 
&nbsp;&nbsp;&nbsp;&nbsp;WellKnownFolderName.MsgFolderRoot, false,folderPropertySet);

</pre>
<pre id="codePreview" class="csharp">
SearchFilter rootFilter = new SearchFilter.IsEqualTo(FolderSchema.DisplayName, &quot;Inbox&quot;);


List&lt;Folder&gt; rootFolders = GetFolders(service, rootFilter, 
&nbsp;&nbsp;&nbsp;&nbsp;WellKnownFolderName.MsgFolderRoot, false,folderPropertySet);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
c. Get the subfolders.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
We will get all the subfolders of each root folder one time.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
foreach (Folder root in rootFolders)
{


&nbsp;&nbsp;&nbsp; List&lt;Folder&gt; subFolders = GetFolders(root, null, true, folderPropertySet);

</pre>
<pre id="codePreview" class="csharp">
foreach (Folder root in rootFolders)
{


&nbsp;&nbsp;&nbsp; List&lt;Folder&gt; subFolders = GetFolders(root, null, true, folderPropertySet);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
2. Get the number of emails with attachments and the number of large items.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
a. Set the filter to get the items with attachments or the large items.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
SearchFilter.SearchFilterCollection filters =
&nbsp;&nbsp;&nbsp; new SearchFilter.SearchFilterCollection(LogicalOperator.Or);


SearchFilter filterAttachment = new SearchFilter.IsEqualTo(ItemSchema.HasAttachments, true);
SearchFilter filterLargeEmail = new SearchFilter.IsGreaterThan(ItemSchema.Size, largeSize);
filters.Add(filterAttachment);
filters.Add(filterLargeEmail);

</pre>
<pre id="codePreview" class="csharp">
SearchFilter.SearchFilterCollection filters =
&nbsp;&nbsp;&nbsp; new SearchFilter.SearchFilterCollection(LogicalOperator.Or);


SearchFilter filterAttachment = new SearchFilter.IsEqualTo(ItemSchema.HasAttachments, true);
SearchFilter filterLargeEmail = new SearchFilter.IsGreaterThan(ItemSchema.Size, largeSize);
filters.Add(filterAttachment);
filters.Add(filterLargeEmail);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
b. Get the items with attachments or the large items. </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
ItemView itemView = new ItemView(pageSize);
itemView.PropertySet = itemPropertySet;
itemView.Traversal = ItemTraversal.Shallow;


FindItemsResults&lt;Item&gt; searchResults = null;
List&lt;Item&gt; items = new List&lt;Item&gt;();


do
{
&nbsp;&nbsp;&nbsp; searchResults = folder.FindItems(filters, itemView);
&nbsp;&nbsp;&nbsp; items.AddRange(searchResults.Items);


&nbsp;&nbsp;&nbsp; itemView.Offset &#43;= pageSize;
} while (searchResults.MoreAvailable);

</pre>
<pre id="codePreview" class="csharp">
ItemView itemView = new ItemView(pageSize);
itemView.PropertySet = itemPropertySet;
itemView.Traversal = ItemTraversal.Shallow;


FindItemsResults&lt;Item&gt; searchResults = null;
List&lt;Item&gt; items = new List&lt;Item&gt;();


do
{
&nbsp;&nbsp;&nbsp; searchResults = folder.FindItems(filters, itemView);
&nbsp;&nbsp;&nbsp; items.AddRange(searchResults.Items);


&nbsp;&nbsp;&nbsp; itemView.Offset &#43;= pageSize;
} while (searchResults.MoreAvailable);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
c. Get the number of emails with attachments and the number of large items. </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
Int32 itemsWithAttachmentNum = (from i in items
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; where i.HasAttachments
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; select i).Count();


Int32 largeItemNum = (from i in items
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; where i.Size &gt; largeSize
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; select i).Count();

</pre>
<pre id="codePreview" class="csharp">
Int32 itemsWithAttachmentNum = (from i in items
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; where i.HasAttachments
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; select i).Count();


Int32 largeItemNum = (from i in items
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; where i.Size &gt; largeSize
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; select i).Count();

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/dd633709(v=exchg.80).aspx">EWS Managed API 2.0</a>
</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/cc433490(v=exchg.80).aspx"><span style="">[MS-OXPROPS]: Exchange Server Protocols Master Property List</span></a><span class="MsoHyperlink">
</span></p>
<p class="MsoNormal"><span class="MsoHyperlink"><a href="http://msdn.microsoft.com/en-us/library/dd634678(v=exchg.80).aspx"><span style="">&nbsp;</span><span class="SpellE">ExtendedPropertyDefinition</span> Class</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

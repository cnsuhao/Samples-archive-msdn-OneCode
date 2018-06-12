# How to recover deleted items in Office 365 Exchange Online
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Exchange Online
* Office 365
## Topics
* Office 365
* revoder
## IsPublished
* True
## ModifiedDate
* 2014-04-24 02:35:51
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<h1>How to Recover Deleted Items in Office 365 Exchange Online (CSOffice365RestoreItems)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">Outlook Web App(OWA) currently allows us to recover deleted items. But it is inconvenient to recover large number of deleted items. Additionally, we may need to recover items of specific type. In this sample, we will demonstrate how to
 recover deleted items in Office 365 Exchange Online. </p>
<p class="MsoNormal">We can recover deleted items from the following folders: </p>
<p class="MsoNormal">1. DeletedItems: The Deleted Items folder. </p>
<p class="MsoNormal">2. RecoverableItemsDeletions: The root of the folder hierarchy of recoverable items that have been soft-deleted from the Deleted Items folder.
</p>
<p class="MsoNormal">3. RecoverableItemsPurges: The root of the folder hierarchy of recoverable items that have been hard-deleted from the Deleted Items folder.
</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Press F5 to run the sample, the following is the result.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/113478/1/image.png" alt="" width="641" height="112" align="middle">
</span></p>
<p class="MsoNormal">First, we use our account to connect the Exchange Online.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/113479/1/image.png" alt="" width="642" height="85" align="middle">
</span></p>
<p class="MsoNormal">Then, the application recovers the folders from DeletedItems.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/113480/1/image.png" alt="" width="641" height="80" align="middle">
</span></p>
<p class="MsoNormal">And the application also recovers the items from DeletedItems.</p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
1. Restore the folders</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
a. Define the SearchFilter and get the subfolders</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
SearchFilter searchFilter = null;
if (String.IsNullOrWhiteSpace(displayName))
{
&nbsp;&nbsp;&nbsp; searchFilter = new SearchFilter.Exists(FolderSchema.DisplayName);
}
else
{
&nbsp;&nbsp;&nbsp; searchFilter = new SearchFilter.ContainsSubstring(FolderSchema.DisplayName,displayName);
}


// Get all the subfolders from the rootFolder
List&lt;Folder&gt; folders = GetFolders(service, searchFilter, rootFolder, false, 
&nbsp;&nbsp;&nbsp;&nbsp;PropertySet.FirstClassProperties);

</pre>
<pre id="codePreview" class="csharp">
SearchFilter searchFilter = null;
if (String.IsNullOrWhiteSpace(displayName))
{
&nbsp;&nbsp;&nbsp; searchFilter = new SearchFilter.Exists(FolderSchema.DisplayName);
}
else
{
&nbsp;&nbsp;&nbsp; searchFilter = new SearchFilter.ContainsSubstring(FolderSchema.DisplayName,displayName);
}


// Get all the subfolders from the rootFolder
List&lt;Folder&gt; folders = GetFolders(service, searchFilter, rootFolder, false, 
&nbsp;&nbsp;&nbsp;&nbsp;PropertySet.FirstClassProperties);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
b. Move the folder to the specific folders basing the FolderClass</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
foreach (Folder folder in folders)
{
&nbsp;&nbsp;&nbsp; Console.WriteLine(folder.FolderClass);


&nbsp;&nbsp;&nbsp; switch (folder.FolderClass)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;IPF.Appointment&quot;: 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;folder.Move(WellKnownFolderName.Calendar);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Folder-{0}-to Calendar&quot;, folder.DisplayName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;IPF.Contact&quot;:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; folder.Move(WellKnownFolderName.Contacts);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Folder-{0}-to Contacts&quot;, folder.DisplayName);
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;IPF.Journal&quot;:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; folder.Move(WellKnownFolderName.Journal);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Folder-{0}-to Journal&quot;, folder.DisplayName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;IPF.Note&quot;:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; folder.Move(WellKnownFolderName.Inbox);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Folder-{0}-to Inbox&quot;, folder.DisplayName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;IPF.StickyNote&quot;:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; folder.Move(WellKnownFolderName.Notes);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Folder-{0}-to Notes&quot;, folder.DisplayName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;IPF.Task&quot;:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; folder.Move(WellKnownFolderName.Tasks);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Folder-{0}-to Tasks&quot;, folder.DisplayName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; default:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; folder.Move(WellKnownFolderName.Root);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Folder-{0}-to Root&quot;, folder.DisplayName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp; }

</pre>
<pre id="codePreview" class="csharp">
foreach (Folder folder in folders)
{
&nbsp;&nbsp;&nbsp; Console.WriteLine(folder.FolderClass);


&nbsp;&nbsp;&nbsp; switch (folder.FolderClass)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;IPF.Appointment&quot;: 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;folder.Move(WellKnownFolderName.Calendar);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Folder-{0}-to Calendar&quot;, folder.DisplayName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;IPF.Contact&quot;:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; folder.Move(WellKnownFolderName.Contacts);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Folder-{0}-to Contacts&quot;, folder.DisplayName);
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;IPF.Journal&quot;:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; folder.Move(WellKnownFolderName.Journal);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Folder-{0}-to Journal&quot;, folder.DisplayName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;IPF.Note&quot;:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; folder.Move(WellKnownFolderName.Inbox);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Folder-{0}-to Inbox&quot;, folder.DisplayName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;IPF.StickyNote&quot;:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; folder.Move(WellKnownFolderName.Notes);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Folder-{0}-to Notes&quot;, folder.DisplayName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;IPF.Task&quot;:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; folder.Move(WellKnownFolderName.Tasks);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Folder-{0}-to Tasks&quot;, folder.DisplayName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; default:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; folder.Move(WellKnownFolderName.Root);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Folder-{0}-to Root&quot;, folder.DisplayName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp; }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
2. Restore the items.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
a. Define the SearchFilter.SearchFilterCollection and get the items</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
SearchFilter.SearchFilterCollection filterCollection = 
&nbsp;&nbsp;&nbsp;&nbsp;new SearchFilter.SearchFilterCollection(LogicalOperator.And);


SearchFilter subjectFilter = null;
if (String.IsNullOrWhiteSpace(subject))
{
&nbsp;&nbsp;&nbsp; subjectFilter = new SearchFilter.Exists(ItemSchema.Subject);
}
else
{
&nbsp;&nbsp;&nbsp; subjectFilter = new SearchFilter.ContainsSubstring(ItemSchema.Subject, subject);
}


SearchFilter startTimeFilter = 
&nbsp;&nbsp;&nbsp;&nbsp;new SearchFilter.IsGreaterThanOrEqualTo(ItemSchema.LastModifiedTime, startDate);
SearchFilter endTimeFilter = 
&nbsp;&nbsp;&nbsp;&nbsp;new SearchFilter.IsLessThanOrEqualTo(ItemSchema.LastModifiedTime, endDate);


filterCollection.Add(subjectFilter);
filterCollection.Add(startTimeFilter);
filterCollection.Add(endTimeFilter);


// Get all the items from the rootFolder
List&lt;Item&gt; items = 
&nbsp;&nbsp;&nbsp;&nbsp;GetItems(service, filterCollection, rootFolder,PropertySet.FirstClassProperties);

</pre>
<pre id="codePreview" class="csharp">
SearchFilter.SearchFilterCollection filterCollection = 
&nbsp;&nbsp;&nbsp;&nbsp;new SearchFilter.SearchFilterCollection(LogicalOperator.And);


SearchFilter subjectFilter = null;
if (String.IsNullOrWhiteSpace(subject))
{
&nbsp;&nbsp;&nbsp; subjectFilter = new SearchFilter.Exists(ItemSchema.Subject);
}
else
{
&nbsp;&nbsp;&nbsp; subjectFilter = new SearchFilter.ContainsSubstring(ItemSchema.Subject, subject);
}


SearchFilter startTimeFilter = 
&nbsp;&nbsp;&nbsp;&nbsp;new SearchFilter.IsGreaterThanOrEqualTo(ItemSchema.LastModifiedTime, startDate);
SearchFilter endTimeFilter = 
&nbsp;&nbsp;&nbsp;&nbsp;new SearchFilter.IsLessThanOrEqualTo(ItemSchema.LastModifiedTime, endDate);


filterCollection.Add(subjectFilter);
filterCollection.Add(startTimeFilter);
filterCollection.Add(endTimeFilter);


// Get all the items from the rootFolder
List&lt;Item&gt; items = 
&nbsp;&nbsp;&nbsp;&nbsp;GetItems(service, filterCollection, rootFolder,PropertySet.FirstClassProperties);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
b. Move the item to the specific folders basing the ItemClass </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
foreach (Item item in items)
{
&nbsp;&nbsp;&nbsp; Console.WriteLine(item.ItemClass);


&nbsp;&nbsp;&nbsp; switch (item.ItemClass)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;IPM.Appointment&quot;:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; item.Move(WellKnownFolderName.Calendar);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Item-{0}-to Calendar&quot;,item.Subject);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;IPM.Contact&quot;:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; item.Move(WellKnownFolderName.Contacts);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Item-{0}-to Contacts&quot;, item.Subject);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;IPM.Activity&quot;:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; item.Move(WellKnownFolderName.Journal);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Item-{0}-to Journal&quot;, item.Subject);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;IPM.Note&quot;:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (item.IsFromMe)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; item.Move(WellKnownFolderName.SentItems);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Item-{0}-to SentItems&quot;, item.Subject);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; item.Move(WellKnownFolderName.Inbox);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Item-{0}-to Inbox&quot;, item.Subject);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;IPM.StickyNote&quot;:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; item.Move(WellKnownFolderName.Notes);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Item-{0}-to Notes&quot;, item.Subject);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;IPM.Task&quot;:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; item.Move(WellKnownFolderName.Tasks);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Item-{0}-to Tasks&quot;, item.Subject);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; default:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; item.Move(WellKnownFolderName.Inbox);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Item-{0}-to Inbox&quot;, item.Subject);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp; }

</pre>
<pre id="codePreview" class="csharp">
foreach (Item item in items)
{
&nbsp;&nbsp;&nbsp; Console.WriteLine(item.ItemClass);


&nbsp;&nbsp;&nbsp; switch (item.ItemClass)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;IPM.Appointment&quot;:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; item.Move(WellKnownFolderName.Calendar);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Item-{0}-to Calendar&quot;,item.Subject);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;IPM.Contact&quot;:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; item.Move(WellKnownFolderName.Contacts);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Item-{0}-to Contacts&quot;, item.Subject);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;IPM.Activity&quot;:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; item.Move(WellKnownFolderName.Journal);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Item-{0}-to Journal&quot;, item.Subject);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;IPM.Note&quot;:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (item.IsFromMe)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; item.Move(WellKnownFolderName.SentItems);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Item-{0}-to SentItems&quot;, item.Subject);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; item.Move(WellKnownFolderName.Inbox);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Item-{0}-to Inbox&quot;, item.Subject);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;IPM.StickyNote&quot;:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; item.Move(WellKnownFolderName.Notes);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Item-{0}-to Notes&quot;, item.Subject);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;IPM.Task&quot;:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; item.Move(WellKnownFolderName.Tasks);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Item-{0}-to Tasks&quot;, item.Subject);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; default:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; item.Move(WellKnownFolderName.Inbox);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Move Item-{0}-to Inbox&quot;, item.Subject);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp; }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/dd633709(v=exchg.80).aspx">EWS Managed API 2.0</a>
</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/jj221817(v=exchg.80).aspx"><span class="SpellE">WellKnownFolderName</span> Enumeration</a></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers’ pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers’ frequently asked programming tasks, and allow
 developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

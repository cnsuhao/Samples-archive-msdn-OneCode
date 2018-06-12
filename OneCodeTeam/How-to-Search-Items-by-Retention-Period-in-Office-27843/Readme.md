# How to Search Items by Retention Period in Office 365 Exchange Online
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Exchange Online
* Office 365
## Topics
* Search
* O365
* retention period
## IsPublished
* True
## ModifiedDate
* 2014-03-26 11:01:54
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<h1>How to Search Items by Retention Period in Office 365 Exchange Online (CSO365SearchByRetention)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">Now we can easily search email messages by retention policy in Outlook. But this feature is not available in Outlook Web App(OWA). In this application, we demonstrate how to search email messages with retention policy enabled in Office
 365 Exchange Online by using Exchange Web Service Managed API.</p>
<p class="MsoNormal">We use the following extend properties to search and get the information: 1. PidTagRetentionPeriod (Property ID:0x301A);2. PidTagRetentionDate (Property ID:0x301C).
</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Press F5 to run the sample, the following is the result.</p>
<p class="MsoNormal">First, we input the retention periods that we want to search by. We can input multiple periods that are separated by space.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/111197/1/image.png" alt="" width="627" height="37" align="middle">
</span></p>
<p class="MsoNormal">Then, we use our account to connect the Exchange Online.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/111198/1/image.png" alt="" width="543" height="63" align="middle">
</span></p>
<p class="MsoNormal">After connected the server, we get the search results.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/111199/1/image.png" alt="" width="616" height="62" align="middle">
</span></p>
<p class="MsoNormal">We can also input char-'*' at first to get all the messages that are applied the retention policies.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/111200/1/image.png" alt="" width="608" height="203" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
1. Set two extend properties.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Use two extend properties to get the retention period and the expire date.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
const Int32 pidTagRetentionPeriod = 12314;
ExtendedPropertyDefinition exPropRetentionPeriod = 
&nbsp;&nbsp;&nbsp;&nbsp;new ExtendedPropertyDefinition(pidTagRetentionPeriod, MapiPropertyType.Integer);


const Int32 pidTagRetentionDate = 12316;
ExtendedPropertyDefinition exPropRetentionDate = 
&nbsp;&nbsp;&nbsp;&nbsp;new ExtendedPropertyDefinition(pidTagRetentionDate, MapiPropertyType.SystemTime);

</pre>
<pre id="codePreview" class="csharp">
const Int32 pidTagRetentionPeriod = 12314;
ExtendedPropertyDefinition exPropRetentionPeriod = 
&nbsp;&nbsp;&nbsp;&nbsp;new ExtendedPropertyDefinition(pidTagRetentionPeriod, MapiPropertyType.Integer);


const Int32 pidTagRetentionDate = 12316;
ExtendedPropertyDefinition exPropRetentionDate = 
&nbsp;&nbsp;&nbsp;&nbsp;new ExtendedPropertyDefinition(pidTagRetentionDate, MapiPropertyType.SystemTime);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
2. Set the search filters.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Set the search filters for each retention period.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
searchFilterCollection.LogicalOperator = LogicalOperator.Or;


foreach (Int32 period in periods)
{
&nbsp;&nbsp;&nbsp; SearchFilter.IsEqualTo searchFilter = new SearchFilter.IsEqualTo(exPropRetentionPeriod, period);
&nbsp;&nbsp;&nbsp; searchFilterCollection.Add(searchFilter);
}

</pre>
<pre id="codePreview" class="csharp">
searchFilterCollection.LogicalOperator = LogicalOperator.Or;


foreach (Int32 period in periods)
{
&nbsp;&nbsp;&nbsp; SearchFilter.IsEqualTo searchFilter = new SearchFilter.IsEqualTo(exPropRetentionPeriod, period);
&nbsp;&nbsp;&nbsp; searchFilterCollection.Add(searchFilter);
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
3. Set search folder</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Use search folder to search messages.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
SearchFolder searchFolder = new SearchFolder(service);
searchFolder.SearchParameters.RootFolderIds.Add(rootFolder);
searchFolder.SearchParameters.Traversal = SearchFolderTraversal.Deep;
searchFolder.SearchParameters.SearchFilter = searchFilterCollection;
searchFolder.DisplayName = DateTime.Now.ToString(&quot;yyyyMMddhhmmss&quot;);
searchFolder.Save(WellKnownFolderName.SearchFolders);

</pre>
<pre id="codePreview" class="csharp">
SearchFolder searchFolder = new SearchFolder(service);
searchFolder.SearchParameters.RootFolderIds.Add(rootFolder);
searchFolder.SearchParameters.Traversal = SearchFolderTraversal.Deep;
searchFolder.SearchParameters.SearchFilter = searchFilterCollection;
searchFolder.DisplayName = DateTime.Now.ToString(&quot;yyyyMMddhhmmss&quot;);
searchFolder.Save(WellKnownFolderName.SearchFolders);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
4. Get search results</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
Get search results from search folder and display the information.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
do
{
&nbsp;&nbsp;&nbsp; findResults=searchFolder.FindItems(itemView);


&nbsp;&nbsp;&nbsp; foreach (Item findResult in findResults)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Object rPeriod = findResult.ExtendedProperties[0].Value;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Object expireDateTime = findResult.ExtendedProperties[1].Value;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (!mailboxFolderNames.ContainsKey(findResult.ParentFolderId.UniqueId))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Folder folder = Folder.Bind(service, findResult.ParentFolderId);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; mailboxFolderNames.Add(findResult.ParentFolderId.UniqueId, folder.DisplayName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }




&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; String folderName = mailboxFolderNames[findResult.ParentFolderId.UniqueId];


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-20}{1,-15}{2,-18}{3}&quot;, findResult.Subject, folderName, rPeriod, expireDateTime);
&nbsp;&nbsp;&nbsp; }
} while (findResults.MoreAvailable);

</pre>
<pre id="codePreview" class="csharp">
do
{
&nbsp;&nbsp;&nbsp; findResults=searchFolder.FindItems(itemView);


&nbsp;&nbsp;&nbsp; foreach (Item findResult in findResults)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Object rPeriod = findResult.ExtendedProperties[0].Value;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Object expireDateTime = findResult.ExtendedProperties[1].Value;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (!mailboxFolderNames.ContainsKey(findResult.ParentFolderId.UniqueId))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Folder folder = Folder.Bind(service, findResult.ParentFolderId);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; mailboxFolderNames.Add(findResult.ParentFolderId.UniqueId, folder.DisplayName);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }




&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; String folderName = mailboxFolderNames[findResult.ParentFolderId.UniqueId];


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-20}{1,-15}{2,-18}{3}&quot;, findResult.Subject, folderName, rPeriod, expireDateTime);
&nbsp;&nbsp;&nbsp; }
} while (findResults.MoreAvailable);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/dd633709(v=exchg.80).aspx">EWS Managed API 2.0</a>
</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/cc433490(v=exchg.80).aspx">[MS-OXPROPS]: Exchange Server Protocols Master Property List</a><span class="MsoHyperlink"><span style="color:windowtext; text-decoration:none">
</span></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

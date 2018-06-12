# How to Search Items by Retention Period in Office 365 Exchange Online
## Requires
* Visual Studio 2013
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
* 2014-05-04 11:48:46
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:24pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to Search</span><span style="font-weight:bold; font-size:14pt"> for</span><a name="_GoBack"></a><span style="font-weight:bold; font-size:14pt"> Items by Retention
 Period in Office 365 Exchange Online </span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Now we can easily search</span><span style="font-size:11pt"> for</span><span style="font-size:11pt"> email messages
</span><span style="font-size:11pt">by</span><span style="font-size:11pt"> retention policy in Outlook. But this feature is not available in Outlook Web App(OWA). In this application, we demonstrate how to search
</span><span style="font-size:11pt">for </span><span style="font-size:11pt">email messages
</span><span style="font-size:11pt">by</span><span style="font-size:11pt"> retention policy enabled in Office 365 Exchange Online by using Exchange Web Service Managed API.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">We use the following extend properties to search and get the information: 1. PidTagRetentionPeriod (Property ID:0x301A);2. PidTagRetentionDate (Property ID:0x301C).</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Press F5 to run the sample,
</span><span style="font-size:11pt">you will get the following</span><span style="font-size:11pt"> result.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">First, we input the retention periods that we want to search by. We can input multiple periods that are separated by space.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/114006/1/image.png" alt="" width="626" height="35" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Then, we use our account to connect
</span><span style="font-size:11pt">to </span><span style="font-size:11pt">the Exchange Online.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/114007/1/image.png" alt="" width="542" height="62" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="">Once the connection is successful, we'll get the search results.
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/114008/1/image.png" alt="" width="615" height="61" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">We can also input char-&lsquo;*&rsquo; first to get all the messages that are applied the retention policies.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/114009/1/image.png" alt="" width="607" height="202" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt"><span style="font-size:11pt">1. Set two extend properties.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt"><span style="font-size:11pt">Use two extend properties to get the</span><span style="font-size:11pt"> retention period and the expiring</span><span style="font-size:11pt"> date.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
const Int32 pidTagRetentionPeriod = 12314;
ExtendedPropertyDefinition exPropRetentionPeriod = 
    new ExtendedPropertyDefinition(pidTagRetentionPeriod, MapiPropertyType.Integer);
const Int32 pidTagRetentionDate = 12316;
ExtendedPropertyDefinition exPropRetentionDate = 
    new ExtendedPropertyDefinition(pidTagRetentionDate, MapiPropertyType.SystemTime);
</pre>
<pre class="hidden">
Const pidTagRetentionPeriod As Int32 = 12314
Dim exPropRetentionPeriod As New ExtendedPropertyDefinition(pidTagRetentionPeriod,
                                                            MapiPropertyType.Integer)
Const pidTagRetentionDate As Int32 = 12316
Dim exPropRetentionDate As New ExtendedPropertyDefinition(pidTagRetentionDate,
                                                          MapiPropertyType.SystemTime)
</pre>
<pre id="codePreview" class="csharp">
const Int32 pidTagRetentionPeriod = 12314;
ExtendedPropertyDefinition exPropRetentionPeriod = 
    new ExtendedPropertyDefinition(pidTagRetentionPeriod, MapiPropertyType.Integer);
const Int32 pidTagRetentionDate = 12316;
ExtendedPropertyDefinition exPropRetentionDate = 
    new ExtendedPropertyDefinition(pidTagRetentionDate, MapiPropertyType.SystemTime);
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt"><span style="font-size:11pt">2. Set the search filters.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt"><span style="font-size:11pt">Set the search filters for each retention period.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
searchFilterCollection.LogicalOperator = LogicalOperator.Or;
foreach (Int32 period in periods)
{
    SearchFilter.IsEqualTo searchFilter = new SearchFilter.IsEqualTo(exPropRetentionPeriod, period);
    searchFilterCollection.Add(searchFilter);
}
</pre>
<pre class="hidden">
searchFilterCollection.LogicalOperator = LogicalOperator.Or
For Each period As Int32 In periods
    Dim searchFilter As New SearchFilter.IsEqualTo(exPropRetentionPeriod, period)
    searchFilterCollection.Add(searchFilter)
Next period
</pre>
<pre id="codePreview" class="csharp">
searchFilterCollection.LogicalOperator = LogicalOperator.Or;
foreach (Int32 period in periods)
{
    SearchFilter.IsEqualTo searchFilter = new SearchFilter.IsEqualTo(exPropRetentionPeriod, period);
    searchFilterCollection.Add(searchFilter);
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt"><span style="font-size:11pt">3. Set search folder</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt"><span style="font-size:11pt">Use search folder to search
</span><span style="font-size:11pt">for </span><span style="font-size:11pt">messages.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
SearchFolder searchFolder = new SearchFolder(service);
searchFolder.SearchParameters.RootFolderIds.Add(rootFolder);
searchFolder.SearchParameters.Traversal = SearchFolderTraversal.Deep;
searchFolder.SearchParameters.SearchFilter = searchFilterCollection;
searchFolder.DisplayName = DateTime.Now.ToString(&quot;yyyyMMddhhmmss&quot;);
searchFolder.Save(WellKnownFolderName.SearchFolders);
</pre>
<pre class="hidden">
Dim searchFolder As New SearchFolder(service)
searchFolder.SearchParameters.RootFolderIds.Add(rootFolder)
searchFolder.SearchParameters.Traversal = SearchFolderTraversal.Deep
searchFolder.SearchParameters.SearchFilter = searchFilterCollection
searchFolder.DisplayName = Date.Now.ToString(&quot;yyyyMMddhhmmss&quot;)
searchFolder.Save(WellKnownFolderName.SearchFolders)
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
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt"><span style=""></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt"><span style="font-size:11pt">4. Get search results</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt"><span style="font-size:11pt">Get search results from search folder and display the information.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
do
{
    findResults=searchFolder.FindItems(itemView);
    foreach (Item findResult in findResults)
    {
        Object rPeriod = findResult.ExtendedProperties[0].Value;
        Object expireDateTime = findResult.ExtendedProperties[1].Value;
        if (!mailboxFolderNames.ContainsKey(findResult.ParentFolderId.UniqueId))
        {
            Folder folder = Folder.Bind(service, findResult.ParentFolderId);
            mailboxFolderNames.Add(findResult.ParentFolderId.UniqueId, folder.DisplayName);
        }
        String folderName = mailboxFolderNames[findResult.ParentFolderId.UniqueId];
        Console.WriteLine(&quot;{0,-20}{1,-15}{2,-18}{3}&quot;, findResult.Subject, folderName, rPeriod, expireDateTime);
    }
} while (findResults.MoreAvailable);
</pre>
<pre class="hidden">
Do
    findResults = searchFolder.FindItems(itemView)
    For Each findResult As Item In findResults
        Dim rPeriod As Object = findResult.ExtendedProperties(0).Value
        Dim expireDateTime As Object = findResult.ExtendedProperties(1).Value
        If Not mailboxFolderNames.ContainsKey(findResult.ParentFolderId.UniqueId) Then
            Dim folder As Folder = folder.Bind(service, findResult.ParentFolderId)
            mailboxFolderNames.Add(findResult.ParentFolderId.UniqueId, folder.DisplayName)
        End If
        Dim folderName As String = mailboxFolderNames(findResult.ParentFolderId.UniqueId)
        Console.WriteLine(&quot;{0,-20}{1,-15}{2,-18}{3}&quot;, findResult.Subject, folderName,
                          rPeriod, expireDateTime)
    Next findResult
Loop While findResults.MoreAvailable
</pre>
<pre id="codePreview" class="csharp">
do
{
    findResults=searchFolder.FindItems(itemView);
    foreach (Item findResult in findResults)
    {
        Object rPeriod = findResult.ExtendedProperties[0].Value;
        Object expireDateTime = findResult.ExtendedProperties[1].Value;
        if (!mailboxFolderNames.ContainsKey(findResult.ParentFolderId.UniqueId))
        {
            Folder folder = Folder.Bind(service, findResult.ParentFolderId);
            mailboxFolderNames.Add(findResult.ParentFolderId.UniqueId, folder.DisplayName);
        }
        String folderName = mailboxFolderNames[findResult.ParentFolderId.UniqueId];
        Console.WriteLine(&quot;{0,-20}{1,-15}{2,-18}{3}&quot;, findResult.Subject, folderName, rPeriod, expireDateTime);
    }
} while (findResults.MoreAvailable);
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt"><span style="font-size:11pt"></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/dd633709(v=exchg.80).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">EWS Managed API 2.0</span></a><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="color:#0563C1; color:windowtext"></span><a href="http://msdn.microsoft.com/en-us/library/cc433490(v=exchg.80).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">[MS-OXPROPS]: Exchange
 Server Protocols Master Property List</span></a></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers’ pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers’ frequently asked programming tasks, and allow
 developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

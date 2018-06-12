# How to Get Delegate Information in Office 365 Exchange Online
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Exchange Online
* Office 365
## Topics
* Delegate
* O365
## IsPublished
* True
## ModifiedDate
* 2013-11-20 09:26:35
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<h1><span style="font-size:16.0pt; line-height:115%">How to Get Delegate Information in Office 365 Exchange Online
</span>(CSO365GetDelegates)</h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span style="font-size:12.0pt; line-height:115%">Currently, you can easily get delegates in Outlook. But you find this feature is not available in Outlook Web App (OWA). In this application, we will demonstrate how to get the delegate
 information of multi accounts. </span></p>
<p class="MsoNormal"><span style="font-size:12.0pt; line-height:115%">1. Get the accounts that users input
</span></p>
<p class="MsoNormal"><span style="font-size:12.0pt; line-height:115%">2. Set the ImpersonatedUserId property if the login account has the impersonation permission.
</span></p>
<p class="MsoNormal"><span style="font-size:12.0pt; line-height:115%">3. Get all the delegate information of the accounts.
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Press F5 to run the sample, the following is the result.</p>
<p class="MsoNormal">First, we use our account to connect the Exchange Online.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/101518/1/image.png" alt="" width="408" height="57" align="middle">
</span></p>
<p class="MsoNormal">Then, we can get delegate information of multi accounts if we have the impersonation permission.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/101519/1/image.png" alt="" width="649" height="42" align="middle">
</span></p>
<p class="MsoNormal">Following is the result of delegate information:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/101520/1/image.png" alt="" width="647" height="291" align="middle">
</span></p>
<p class="MsoNormal"><span style="">If we don't have the impersonation permission, we can directly press the Enter to get the delegate information of login account.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/101521/1/image.png" alt="" width="644" height="180" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
If we have impersonation permission, we can get delegate information of multi accounts by set the
<span style="">&nbsp;</span><span style="font-size:12.0pt">ImpersonatedUserId property.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
foreach (String identity in identities)
{
&nbsp;&nbsp;&nbsp; // If the user identity is valid, we will set it as the ImpersonatedUserId.
&nbsp;&nbsp;&nbsp; NameResolutionCollection nameResolutions = 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;service.ResolveName(identity, ResolveNameSearchLocation.DirectoryOnly, true);
&nbsp;&nbsp;&nbsp; if (nameResolutions.Count != 1)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0} is invalid user identity.&quot;, identity);
&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; else
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; String emailAddress = nameResolutions[0].Mailbox.Address;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; service.ImpersonatedUserId = 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;new ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; GetAccountDelegates(service, emailAddress);
&nbsp;&nbsp;&nbsp; }
}

</pre>
<pre id="codePreview" class="csharp">
foreach (String identity in identities)
{
&nbsp;&nbsp;&nbsp; // If the user identity is valid, we will set it as the ImpersonatedUserId.
&nbsp;&nbsp;&nbsp; NameResolutionCollection nameResolutions = 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;service.ResolveName(identity, ResolveNameSearchLocation.DirectoryOnly, true);
&nbsp;&nbsp;&nbsp; if (nameResolutions.Count != 1)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0} is invalid user identity.&quot;, identity);
&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; else
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; String emailAddress = nameResolutions[0].Mailbox.Address;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; service.ImpersonatedUserId = 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;new ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; GetAccountDelegates(service, emailAddress);
&nbsp;&nbsp;&nbsp; }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
If we don't have the impersonation permission, we can only get the delegate information of the login account.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
else
{
&nbsp;&nbsp;&nbsp; // We can also directly press Enter to get the delegate information of the 
&nbsp;&nbsp;&nbsp;&nbsp;// login account.
&nbsp;&nbsp;&nbsp; GetAccountDelegates(service, currentAddress);
}

</pre>
<pre id="codePreview" class="csharp">
else
{
&nbsp;&nbsp;&nbsp; // We can also directly press Enter to get the delegate information of the 
&nbsp;&nbsp;&nbsp;&nbsp;// login account.
&nbsp;&nbsp;&nbsp; GetAccountDelegates(service, currentAddress);
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
We get the delegate information of the specific account.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
static void GetAccountDelegates(ExchangeService service, String emailAddress, params UserId[] userIds)
{
&nbsp;&nbsp;&nbsp; var emailBox = new Mailbox(emailAddress);


&nbsp;&nbsp;&nbsp; DelegateInformation result = service.GetDelegates(emailBox, true, userIds);


 &nbsp;&nbsp;&nbsp;foreach (var response in result.DelegateUserResponses)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (response.ErrorCode != ServiceError.NoError)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(response.ErrorMessage);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;Identity&quot;, emailAddress);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;MeetingRequestsDeliveryScope&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result.MeetingRequestsDeliveryScope);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;DelegateUser&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.DelegateUser.UserId.PrimarySmtpAddress);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;ReceiveCopiesOfMeetingMessages&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.DelegateUser.ReceiveCopiesOfMeetingMessages);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;ViewPrivateItems&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.DelegateUser.ViewPrivateItems);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;CalendarFolderPermissionLevel&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.DelegateUser.Permissions.CalendarFolderPermissionLevel);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;TasksFolderPermissionLevel&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.DelegateUser.Permissions.TasksFolderPermissionLevel);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;InboxFolderPermissionLevel&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.DelegateUser.Permissions.InboxFolderPermissionLevel);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;ContactsFolderPermissionLevel&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.DelegateUser.Permissions.ContactsFolderPermissionLevel);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;NotesFolderPermissionLevel&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.DelegateUser.Permissions.NotesFolderPermissionLevel);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;JournalFolderPermissionLevel&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.DelegateUser.Permissions.JournalFolderPermissionLevel);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; }
}

</pre>
<pre id="codePreview" class="csharp">
static void GetAccountDelegates(ExchangeService service, String emailAddress, params UserId[] userIds)
{
&nbsp;&nbsp;&nbsp; var emailBox = new Mailbox(emailAddress);


&nbsp;&nbsp;&nbsp; DelegateInformation result = service.GetDelegates(emailBox, true, userIds);


 &nbsp;&nbsp;&nbsp;foreach (var response in result.DelegateUserResponses)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (response.ErrorCode != ServiceError.NoError)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(response.ErrorMessage);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;Identity&quot;, emailAddress);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;MeetingRequestsDeliveryScope&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result.MeetingRequestsDeliveryScope);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;DelegateUser&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.DelegateUser.UserId.PrimarySmtpAddress);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;ReceiveCopiesOfMeetingMessages&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.DelegateUser.ReceiveCopiesOfMeetingMessages);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;ViewPrivateItems&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.DelegateUser.ViewPrivateItems);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;CalendarFolderPermissionLevel&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.DelegateUser.Permissions.CalendarFolderPermissionLevel);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;TasksFolderPermissionLevel&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.DelegateUser.Permissions.TasksFolderPermissionLevel);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;InboxFolderPermissionLevel&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.DelegateUser.Permissions.InboxFolderPermissionLevel);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;ContactsFolderPermissionLevel&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.DelegateUser.Permissions.ContactsFolderPermissionLevel);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;NotesFolderPermissionLevel&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.DelegateUser.Permissions.NotesFolderPermissionLevel);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;JournalFolderPermissionLevel&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.DelegateUser.Permissions.JournalFolderPermissionLevel);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/dd633709(v=exchg.80).aspx">EWS Managed API 2.0</a>
</p>
<p class="MsoNormal"><span class="MsoHyperlink"><span style="color:windowtext; text-decoration:none"><a href="http://msdn.microsoft.com/en-us/library/dd633680(v=exchg.80).aspx">Working with impersonation by using the EWS Managed API</a>
</span></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

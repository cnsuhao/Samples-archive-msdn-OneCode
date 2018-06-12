# How to Get Delegate Information in Office 365 Exchange Online
## Requires
* Visual Studio 2013
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
* 2014-04-21 06:47:53
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:24pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-size:16pt">How to Get Delegate Information in Office 365 Exchange Online</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:12pt"></span><span style="font-size:12pt">Currently, you can easily get delegates in Outlook. But you
</span><span style="font-size:12pt">will </span><span style="font-size:12pt">find this feature is not available in Outlook Web App (OWA). In this application, we will demonstrate how get the delegate information of multi accounts.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:12pt"></span><span style="font-size:12pt">1. Get the accounts that users input</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:12pt"></span><span style="font-size:12pt">2. Set the ImpersonatedUserId property if the login account has the impersonation permission.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:12pt"></span><span style="font-size:12pt">3. Get all the delegate information of the accounts.
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Press F5 to run the sample,
</span><span style="font-size:11pt">you will get </span><span style="font-size:11pt">the following result.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">First, we use our account to connect</span><span style="font-size:11pt"> to</span><span style="font-size:11pt"> the Exchange Online.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/113249/1/image.png" alt="" width="407" height="55" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Then, we can get delegate information of multi accounts if we have the impersonation permission.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/113250/1/image.png" alt="" width="647" height="41" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The f</span><span style="font-size:11pt">ollowing is the result of delegate information:</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/113251/1/image.png" alt="" width="646" height="290" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">If we don&rsquo;t have the impersonation permission, we can directly press Enter to get the delegate information of</span><span style="font-size:11pt"> the</span><span style="font-size:11pt"> login account.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/113252/1/image.png" alt="" width="643" height="179" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt"><span style="font-size:11pt">If we have impersonation permission, we can get delegate information of multi accounts by set</span><span style="font-size:11pt">ting</span><a name="_GoBack"></a><span style="font-size:11pt"> the
</span><span style="font-size:12pt">ImpersonatedUserId property.</span></span> </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
foreach (String identity in identities)
{
    // If the user identity is valid, we will set it as the ImpersonatedUserId.
    NameResolutionCollection nameResolutions = 
        service.ResolveName(identity, ResolveNameSearchLocation.DirectoryOnly, true);
    if (nameResolutions.Count != 1)
    {
        Console.WriteLine(&quot;{0} is invalid user identity.&quot;, identity);
    }
    else
    {
        String emailAddress = nameResolutions[0].Mailbox.Address;
        service.ImpersonatedUserId = 
            new ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress);
        GetAccountDelegates(service, emailAddress);
    }
}
</pre>
<pre class="hidden">
For Each identity As String In identities
    ' If the user identity is valid, we will set it as the ImpersonatedUserId.
    Dim nameResolutions As NameResolutionCollection =
        service.ResolveName(identity, ResolveNameSearchLocation.DirectoryOnly, True)
    If nameResolutions.Count &lt;&gt; 1 Then
        Console.WriteLine(&quot;{0} is invalid user identity.&quot;, identity)
    Else
        Dim emailAddress As String = nameResolutions(0).Mailbox.Address
        service.ImpersonatedUserId =
            New ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress)
        GetAccountDelegates(service, emailAddress)
    End If
Next identity
</pre>
<pre id="codePreview" class="csharp">
foreach (String identity in identities)
{
    // If the user identity is valid, we will set it as the ImpersonatedUserId.
    NameResolutionCollection nameResolutions = 
        service.ResolveName(identity, ResolveNameSearchLocation.DirectoryOnly, true);
    if (nameResolutions.Count != 1)
    {
        Console.WriteLine(&quot;{0} is invalid user identity.&quot;, identity);
    }
    else
    {
        String emailAddress = nameResolutions[0].Mailbox.Address;
        service.ImpersonatedUserId = 
            new ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress);
        GetAccountDelegates(service, emailAddress);
    }
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt"><span style="font-size:11pt"></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">If we don&rsquo;t have the impersonation permission, we can only get the delegate information of the login account.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
else
{
    // We can also directly press Enter to get the delegate information of the 
    // login account.
    GetAccountDelegates(service, currentAddress);
}
</pre>
<pre class="hidden">
Else
    ' We can also directly press Enter to get the delegate information of the 
    ' login account.
    GetAccountDelegates(service, currentAddress)
End If
</pre>
<pre id="codePreview" class="csharp">
else
{
    // We can also directly press Enter to get the delegate information of the 
    // login account.
    GetAccountDelegates(service, currentAddress);
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">We get the delegate information of the specific account.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
static void GetAccountDelegates(ExchangeService service, String emailAddress, params UserId[] userIds)
{
    var emailBox = new Mailbox(emailAddress);
    DelegateInformation result = service.GetDelegates(emailBox, true, userIds);
    foreach (var response in result.DelegateUserResponses)
    {
        if (response.ErrorCode != ServiceError.NoError)
        {
            Console.WriteLine(response.ErrorMessage);
        }
        else
        {
            Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;Identity&quot;, emailAddress);
            Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;MeetingRequestsDeliveryScope&quot;, 
                result.MeetingRequestsDeliveryScope);
            Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;DelegateUser&quot;, 
                response.DelegateUser.UserId.PrimarySmtpAddress);
            Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;ReceiveCopiesOfMeetingMessages&quot;, 
                response.DelegateUser.ReceiveCopiesOfMeetingMessages);
            Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;ViewPrivateItems&quot;, 
                response.DelegateUser.ViewPrivateItems);
            Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;CalendarFolderPermissionLevel&quot;, 
                response.DelegateUser.Permissions.CalendarFolderPermissionLevel);
            Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;TasksFolderPermissionLevel&quot;, 
                response.DelegateUser.Permissions.TasksFolderPermissionLevel);
            Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;InboxFolderPermissionLevel&quot;, 
                response.DelegateUser.Permissions.InboxFolderPermissionLevel);
            Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;ContactsFolderPermissionLevel&quot;, 
                response.DelegateUser.Permissions.ContactsFolderPermissionLevel);
            Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;NotesFolderPermissionLevel&quot;, 
                response.DelegateUser.Permissions.NotesFolderPermissionLevel);
            Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;JournalFolderPermissionLevel&quot;, 
                response.DelegateUser.Permissions.JournalFolderPermissionLevel);
            Console.WriteLine();
        }
    }
}
</pre>
<pre class="hidden">
Private Shared Sub GetAccountDelegates(ByVal service As ExchangeService,
                                               ByVal emailAddress As String,
                                               ByVal ParamArray userIds() As UserId)
            Dim emailBox = New Mailbox(emailAddress)
            Dim result As DelegateInformation = service.GetDelegates(emailBox, True, userIds)
            For Each response In result.DelegateUserResponses
                If response.ErrorCode &lt;&gt; ServiceError.NoError Then
                    Console.WriteLine(response.ErrorMessage)
                Else
                    Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;Identity&quot;, emailAddress)
                    Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;MeetingRequestsDeliveryScope&quot;,
                                      result.MeetingRequestsDeliveryScope)
                    Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;DelegateUser&quot;,
                                      response.DelegateUser.UserId.PrimarySmtpAddress)
                    Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;ReceiveCopiesOfMeetingMessages&quot;,
                                      response.DelegateUser.ReceiveCopiesOfMeetingMessages)
                    Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;ViewPrivateItems&quot;,
                                      response.DelegateUser.ViewPrivateItems)
                    Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;CalendarFolderPermissionLevel&quot;,
                                      response.DelegateUser.Permissions.CalendarFolderPermissionLevel)
                    Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;TasksFolderPermissionLevel&quot;,
                                      response.DelegateUser.Permissions.TasksFolderPermissionLevel)
                    Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;InboxFolderPermissionLevel&quot;,
                                      response.DelegateUser.Permissions.InboxFolderPermissionLevel)
                    Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;ContactsFolderPermissionLevel&quot;,
                                      response.DelegateUser.Permissions.ContactsFolderPermissionLevel)
                    Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;NotesFolderPermissionLevel&quot;,
                                      response.DelegateUser.Permissions.NotesFolderPermissionLevel)
                    Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;JournalFolderPermissionLevel&quot;,
                                      response.DelegateUser.Permissions.JournalFolderPermissionLevel)
                    Console.WriteLine()
                End If
            Next response
        End Sub
</pre>
<pre id="codePreview" class="csharp">
static void GetAccountDelegates(ExchangeService service, String emailAddress, params UserId[] userIds)
{
    var emailBox = new Mailbox(emailAddress);
    DelegateInformation result = service.GetDelegates(emailBox, true, userIds);
    foreach (var response in result.DelegateUserResponses)
    {
        if (response.ErrorCode != ServiceError.NoError)
        {
            Console.WriteLine(response.ErrorMessage);
        }
        else
        {
            Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;Identity&quot;, emailAddress);
            Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;MeetingRequestsDeliveryScope&quot;, 
                result.MeetingRequestsDeliveryScope);
            Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;DelegateUser&quot;, 
                response.DelegateUser.UserId.PrimarySmtpAddress);
            Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;ReceiveCopiesOfMeetingMessages&quot;, 
                response.DelegateUser.ReceiveCopiesOfMeetingMessages);
            Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;ViewPrivateItems&quot;, 
                response.DelegateUser.ViewPrivateItems);
            Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;CalendarFolderPermissionLevel&quot;, 
                response.DelegateUser.Permissions.CalendarFolderPermissionLevel);
            Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;TasksFolderPermissionLevel&quot;, 
                response.DelegateUser.Permissions.TasksFolderPermissionLevel);
            Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;InboxFolderPermissionLevel&quot;, 
                response.DelegateUser.Permissions.InboxFolderPermissionLevel);
            Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;ContactsFolderPermissionLevel&quot;, 
                response.DelegateUser.Permissions.ContactsFolderPermissionLevel);
            Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;NotesFolderPermissionLevel&quot;, 
                response.DelegateUser.Permissions.NotesFolderPermissionLevel);
            Console.WriteLine(&quot;{0,-30}:{1}&quot;, &quot;JournalFolderPermissionLevel&quot;, 
                response.DelegateUser.Permissions.JournalFolderPermissionLevel);
            Console.WriteLine();
        }
    }
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/dd633709(v=exchg.80).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">EWS Managed API 2.0</span></a><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="color:#0563C1; color:windowtext"></span><a href="http://msdn.microsoft.com/en-us/library/dd633680(v=exchg.80).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">Working with impersonation
 by using the EWS Managed API</span></a></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers’ pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers’ frequently asked programming tasks, and allow
 developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

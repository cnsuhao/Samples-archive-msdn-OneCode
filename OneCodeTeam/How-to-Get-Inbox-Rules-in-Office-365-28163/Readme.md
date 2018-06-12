# How to Get Inbox Rules in Office 365
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* Exchange Online
* Office 365
## Topics
* Inbox rules
* Impersonated
## IsPublished
* True
## ModifiedDate
* 2014-04-13 07:05:47
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:24pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to Get Inbox Rules in Office 365</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:13pt"><span style="font-size:11pt">Currently, most of you manage email messages by inbox rules. Especially, when you become an owner of a shared mailbox, you find the former owner created a lot of inbox rules to manage email messages
 efficiently. But you need to modify these inbox rules to meet the new business needs. Before changing these inbox rules, you want to find a solution to document these inbox rules in case something goes wrong. But you don't have an out-of-box solution.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">In this application, we will demonstrate how t</span><span style="font-size:11pt">o get Inbox rules in Office 365:</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">1. Get the accounts that users input</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">2. Set the ImpersonatedUserId property if the login account has the impersonation permission.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">3. Get Inbox rules of the accounts.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Press F5 to run the sample.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">First, we use our account to connect
</span><span>to</span><span style="font-size:11pt"> </span><span style="font-size:11pt">Exchange Online.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/112827/1/image.png" alt="" width="407" height="55" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Then, we can get Inbox rules of multi accounts if we have the impersonation permission.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/112828/1/image.png" alt="" width="575" height="37" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The f</span><span style="font-size:11pt">ollowing is the result of
</span><span style="font-size:11pt">Inbox rules</span><span style="font-size:11pt">:</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/112829/1/image.png" alt="" width="574" height="241" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">If we don&rsquo;t have the impersonation permi</span><span style="font-size:11pt">ssion, we can directly press</span><span style="font-size:11pt"> Enter to get the Inbox rules of</span><span style="font-size:11pt">
 the</span><span style="font-size:11pt"> login account.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span></p>
<p style="font-size:10.0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none; margin:0pt">
<span style="font-size:11pt"><span style="font-size:11pt">If we have impersonation permission, we can get Inbox rules of multi accounts by set</span><span style="font-size:11pt">ting</span><span style="font-size:11pt"> the</span><a name="_GoBack"></a><span style="font-size:11pt">
</span><span style="font-size:12pt">ImpersonatedUserId property.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">foreach (String identity in identities)
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
        GetAccountGetInboxRules(service, emailAddress);
    }
}
</pre>
<pre class="hidden">For Each identity As String In identities
    ' If the user identity is valid, we will set it as the ImpersonatedUserId.
    Dim nameResolutions As NameResolutionCollection =
        service.ResolveName(identity, ResolveNameSearchLocation.DirectoryOnly, True)
    If nameResolutions.Count &lt;&gt; 1 Then
        Console.WriteLine(&quot;{0} is invalid user identity.&quot;, identity)
    Else
        Dim emailAddress As String = nameResolutions(0).Mailbox.Address
        service.ImpersonatedUserId =
            New ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress)
        GetAccountGetInboxRules(service, emailAddress)
    End If
Next identity
</pre>
<pre id="codePreview" class="csharp">foreach (String identity in identities)
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
        GetAccountGetInboxRules(service, emailAddress);
    }
}</pre>
</div>
</div>
<p style="font-size:10.0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none; margin:0pt">
<span style="font-size:11pt"><span style="font-size:11pt">If we don&rsquo;t have the impersonation permission, we can only get the Inbox rules of the login account.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">else
{
    // We can also directly press Enter to get the Inbox rules of the 
    // login account.
    GetAccountGetInboxRules(service, currentAddress);
}
</pre>
<pre class="hidden">Else
    ' We can also directly press Enter to get the Inbox rules of the 
    ' login account.
    GetAccountGetInboxRules(service, currentAddress)
End If
</pre>
<pre id="codePreview" class="csharp">else
{
    // We can also directly press Enter to get the Inbox rules of the 
    // login account.
    GetAccountGetInboxRules(service, currentAddress);
}</pre>
</div>
</div>
<p style="font-size:10.0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none; margin:0pt">
<span style="font-size:11pt"><span style="font-size:11pt">We get the Inbox rules of the specific account.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">static void GetAccountGetInboxRules(ExchangeService service, String emailAddress, 
    params UserId[] userIds)
{
    var emailBox = new Mailbox(emailAddress);
    RuleCollection rules=service.GetInboxRules(emailAddress);
    if (rules.Count &lt;= 0)
    {
        Console.WriteLine(&quot;There's no rule for the account {0}.&quot;, emailAddress);
        Console.WriteLine();
    }
    else
    {
        foreach (Rule rule in rules)
        {
            Console.WriteLine(&quot;{0,-20}:{1}&quot;, &quot;Account Identity&quot;, emailAddress);
            Console.WriteLine(&quot;{0,-20}:{1}&quot;, &quot;Id&quot;, rule.DisplayName);
            Console.WriteLine(&quot;{0,-20}:{1}&quot;, &quot;Priority&quot;, rule.Priority);
            Console.WriteLine(&quot;{0,-20}:{1}&quot;, &quot;IsEnabled&quot;, rule.IsEnabled);
            Console.WriteLine(&quot;{0,-20}:{1}&quot;, &quot;IsNotSupported&quot;, rule.IsNotSupported);
            Console.WriteLine(&quot;{0,-20}:{1}&quot;, &quot;IsInError&quot;, rule.IsInError);
            Console.WriteLine(&quot;{0,-20}:{1}&quot;, &quot;Conditions&quot;, rule.Conditions);
            Console.WriteLine(&quot;{0,-20}:{1}&quot;, &quot;Actions&quot;, rule.Actions);
            Console.WriteLine(&quot;{0,-20}:{1}&quot;, &quot;Account Identity&quot;, rule.Exceptions);
            Console.WriteLine();
        }
    }
}
</pre>
<pre class="hidden">Private Shared Sub GetAccountGetInboxRules(ByVal service As ExchangeService,
                                           ByVal emailAddress As String,
                                           ByVal ParamArray userIds() As UserId)
    Dim emailBox = New Mailbox(emailAddress)
    Dim rules As RuleCollection = service.GetInboxRules(emailAddress)
    If rules.Count &lt;= 0 Then
        Console.WriteLine(&quot;There's no rule for the account {0}.&quot;, emailAddress)
        Console.WriteLine()
    Else
        For Each rule As Rule In rules
            Console.WriteLine(&quot;{0,-20}:{1}&quot;, &quot;Account Identity&quot;, emailAddress)
            Console.WriteLine(&quot;{0,-20}:{1}&quot;, &quot;Id&quot;, rule.DisplayName)
            Console.WriteLine(&quot;{0,-20}:{1}&quot;, &quot;Priority&quot;, rule.Priority)
            Console.WriteLine(&quot;{0,-20}:{1}&quot;, &quot;IsEnabled&quot;, rule.IsEnabled)
            Console.WriteLine(&quot;{0,-20}:{1}&quot;, &quot;IsNotSupported&quot;, rule.IsNotSupported)
            Console.WriteLine(&quot;{0,-20}:{1}&quot;, &quot;IsInError&quot;, rule.IsInError)
            Console.WriteLine(&quot;{0,-20}:{1}&quot;, &quot;Conditions&quot;, rule.Conditions)
            Console.WriteLine(&quot;{0,-20}:{1}&quot;, &quot;Actions&quot;, rule.Actions)
            Console.WriteLine(&quot;{0,-20}:{1}&quot;, &quot;Account Identity&quot;, rule.Exceptions)
            Console.WriteLine()
        Next rule
    End If
End Sub
</pre>
<pre id="codePreview" class="csharp">static void GetAccountGetInboxRules(ExchangeService service, String emailAddress, 
    params UserId[] userIds)
{
    var emailBox = new Mailbox(emailAddress);
    RuleCollection rules=service.GetInboxRules(emailAddress);
    if (rules.Count &lt;= 0)
    {
        Console.WriteLine(&quot;There's no rule for the account {0}.&quot;, emailAddress);
        Console.WriteLine();
    }
    else
    {
        foreach (Rule rule in rules)
        {
            Console.WriteLine(&quot;{0,-20}:{1}&quot;, &quot;Account Identity&quot;, emailAddress);
            Console.WriteLine(&quot;{0,-20}:{1}&quot;, &quot;Id&quot;, rule.DisplayName);
            Console.WriteLine(&quot;{0,-20}:{1}&quot;, &quot;Priority&quot;, rule.Priority);
            Console.WriteLine(&quot;{0,-20}:{1}&quot;, &quot;IsEnabled&quot;, rule.IsEnabled);
            Console.WriteLine(&quot;{0,-20}:{1}&quot;, &quot;IsNotSupported&quot;, rule.IsNotSupported);
            Console.WriteLine(&quot;{0,-20}:{1}&quot;, &quot;IsInError&quot;, rule.IsInError);
            Console.WriteLine(&quot;{0,-20}:{1}&quot;, &quot;Conditions&quot;, rule.Conditions);
            Console.WriteLine(&quot;{0,-20}:{1}&quot;, &quot;Actions&quot;, rule.Actions);
            Console.WriteLine(&quot;{0,-20}:{1}&quot;, &quot;Account Identity&quot;, rule.Exceptions);
            Console.WriteLine();
        }
    }
}</pre>
</div>
</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/dd633709(v=exchg.80).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">EWS Managed API 2.0</span></a><span style="font-size:11pt">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/dd633680(v=exchg.80).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">Working with impersonation by using the EWS Managed API</span></a></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

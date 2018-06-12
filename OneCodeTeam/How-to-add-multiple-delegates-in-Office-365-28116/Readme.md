# How to add multiple delegates in Office 365 Exchange Online
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Exchange Online
* Office 365
## Topics
* Impersonation
* Delegate
## IsPublished
* True
## ModifiedDate
* 2014-04-10 02:22:08
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<h1><span style="font-size:16.0pt; line-height:115%">How to add Delegates in Office 365 Exchange Online
</span>(CSO365AddDelegates)</h1>
<h2>Introduction</h2>
<p><span style="font-size:small; line-height:115%">Currently, you can easily add delegates in Outlook. But you may find this feature is not available in Outlook Web App (OWA). In this application, we will demonstrate how to add multi delegates in Office 365
 Exchange Online. </span></p>
<p><span style="font-size:small; line-height:115%">1. Get the addresses of delegates;
</span></p>
<p><span style="font-size:small; line-height:115%">2. Get the addresses of primary accounts;
</span></p>
<p><span style="font-size:small; line-height:115%">3. Set the ImpersonatedUserId property if the login account has the impersonation permission.
</span></p>
<p><span style="font-size:small; line-height:115%">4. Add all the delegates into all the primary accounts.
</span></p>
<h2>Running the Sample</h2>
<p><span style="font-size:small">Press F5 to run the sample, the following is the result.</span></p>
<p><span style="font-size:small">First, we use our account to connect the Exchange Online.</span></p>
<p><span style="font-size:small"><img src="/site/view/file/112621/1/image.png" alt="" width="408" height="57" align="middle">
</span></p>
<p><span style="font-size:small">Then, we need the identities of the delegates.</span></p>
<p><span style="font-size:small"><img src="/site/view/file/112622/1/image.png" alt="" width="641" height="33" align="middle">
</span></p>
<p><span style="font-size:small">And if we have the impersonation permission, we can add the delegates to multi accounts by setting the
<span style="line-height:115%">ImpersonatedUserId property</span>.</span></p>
<p><span style="font-size:small"><img src="/site/view/file/112623/1/image.png" alt="" width="644" height="41" align="middle">
</span></p>
<p><span style="font-size:small">Following is the result: </span></p>
<p><span style="font-size:small"><img src="/site/view/file/112624/1/image.png" alt="" width="650" height="140" align="middle">
</span></p>
<p><span style="font-size:small">If we don't have the impersonation permission, we can directly press the Enter to add the delegates to the login account.
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:small">Before we add the delegates, We need the addresses of the delegates.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">Console.WriteLine(&quot;Please input the user identity(s) that were used as the delegates:&quot;);


 String delegateInfo = Console.ReadLine();


 // We get the addresses related to the identities of delegates.
 List&lt;String&gt; delegateIdentities = new List&lt;string&gt;();
 if (!String.IsNullOrWhiteSpace(delegateInfo))
 {
&nbsp;&nbsp;&nbsp;&nbsp; // You can input the &quot;EXIT&quot; to exit.
&nbsp;&nbsp;&nbsp;&nbsp; if (delegateInfo.ToUpper().CompareTo(&quot;EXIT&quot;) == 0)
&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return;
&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp; foreach (String delegateIdentity in delegateInfo.Split(','))
&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NameResolutionCollection nameResolutions =
&nbsp;&nbsp;&nbsp; service.ResolveName(delegateIdentity, ResolveNameSearchLocation.DirectoryOnly, true);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (nameResolutions.Count != 1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0} is invalid user identity as the delegate.&quot;,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; delegateIdentity);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; delegateIdentities.Add(nameResolutions[0].Mailbox.Address);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp; if (delegateIdentities.Count == 0)
&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;There's not any valid user identity as the delegate.&quot;);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; continue;
&nbsp;&nbsp;&nbsp;&nbsp; }
 }
 else
 {
&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;The delegates cannot be null!&quot;);
&nbsp;&nbsp;&nbsp;&nbsp; continue;
 }

</pre>
<pre id="codePreview" class="csharp">Console.WriteLine(&quot;Please input the user identity(s) that were used as the delegates:&quot;);


 String delegateInfo = Console.ReadLine();


 // We get the addresses related to the identities of delegates.
 List&lt;String&gt; delegateIdentities = new List&lt;string&gt;();
 if (!String.IsNullOrWhiteSpace(delegateInfo))
 {
&nbsp;&nbsp;&nbsp;&nbsp; // You can input the &quot;EXIT&quot; to exit.
&nbsp;&nbsp;&nbsp;&nbsp; if (delegateInfo.ToUpper().CompareTo(&quot;EXIT&quot;) == 0)
&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return;
&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp; foreach (String delegateIdentity in delegateInfo.Split(','))
&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NameResolutionCollection nameResolutions =
&nbsp;&nbsp;&nbsp; service.ResolveName(delegateIdentity, ResolveNameSearchLocation.DirectoryOnly, true);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (nameResolutions.Count != 1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0} is invalid user identity as the delegate.&quot;,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; delegateIdentity);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; delegateIdentities.Add(nameResolutions[0].Mailbox.Address);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp; if (delegateIdentities.Count == 0)
&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;There's not any valid user identity as the delegate.&quot;);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; continue;
&nbsp;&nbsp;&nbsp;&nbsp; }
 }
 else
 {
&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;The delegates cannot be null!&quot;);
&nbsp;&nbsp;&nbsp;&nbsp; continue;
 }

</pre>
</div>
</div>
<div class="endscriptcode"></div>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:small">If we have impersonation permission, we can add the delegates to multi accounts by setting the ImpersonatedUserId property.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">Console.WriteLine(&quot;Please input the user identity you want to set the &quot; &#43;
&nbsp;&nbsp;&nbsp; &quot;delegates(or you can directly press Enter to set delegates in current account):&quot;);
String primaryInfo = Console.ReadLine();


if (!String.IsNullOrWhiteSpace(primaryInfo))
{
&nbsp;&nbsp;&nbsp; // You can input the &quot;EXIT&quot; to exit.
&nbsp;&nbsp;&nbsp; if (primaryInfo.ToUpper().CompareTo(&quot;EXIT&quot;) == 0)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return;
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; String[] primaryIdentities = primaryInfo.Split(',');


&nbsp;&nbsp;&nbsp; foreach (String primaryIdentity in primaryIdentities)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // If the user identity is valid, we will set it as the ImpersonatedUserId.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NameResolutionCollection nameResolutions =
&nbsp;&nbsp;&nbsp;&nbsp; service.ResolveName(primaryIdentity, ResolveNameSearchLocation.DirectoryOnly, true);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (nameResolutions.Count != 1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0} is invalid user identity.&quot;, primaryIdentity);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; String emailAddress = nameResolutions[0].Mailbox.Address;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; service.ImpersonatedUserId =
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; new ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; foreach (String delegateIdentity in delegateIdentities)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AddAccountDelegates(service, emailAddress, delegateIdentity, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;permissionLevelName, permissionLevel);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; }
}

</pre>
<pre id="codePreview" class="csharp">Console.WriteLine(&quot;Please input the user identity you want to set the &quot; &#43;
&nbsp;&nbsp;&nbsp; &quot;delegates(or you can directly press Enter to set delegates in current account):&quot;);
String primaryInfo = Console.ReadLine();


if (!String.IsNullOrWhiteSpace(primaryInfo))
{
&nbsp;&nbsp;&nbsp; // You can input the &quot;EXIT&quot; to exit.
&nbsp;&nbsp;&nbsp; if (primaryInfo.ToUpper().CompareTo(&quot;EXIT&quot;) == 0)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return;
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; String[] primaryIdentities = primaryInfo.Split(',');


&nbsp;&nbsp;&nbsp; foreach (String primaryIdentity in primaryIdentities)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // If the user identity is valid, we will set it as the ImpersonatedUserId.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NameResolutionCollection nameResolutions =
&nbsp;&nbsp;&nbsp;&nbsp; service.ResolveName(primaryIdentity, ResolveNameSearchLocation.DirectoryOnly, true);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (nameResolutions.Count != 1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;{0} is invalid user identity.&quot;, primaryIdentity);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; String emailAddress = nameResolutions[0].Mailbox.Address;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; service.ImpersonatedUserId =
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; new ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; foreach (String delegateIdentity in delegateIdentities)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AddAccountDelegates(service, emailAddress, delegateIdentity, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;permissionLevelName, permissionLevel);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; }
}</pre>
</div>
</div>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:small">If we don't have the impersonation permission, we can directly press the Enter to add the delegates to the login account.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">else
{
&nbsp;&nbsp;&nbsp; // We can also directly press Enter to add the delegates to the login account. 
&nbsp;&nbsp;&nbsp;&nbsp;foreach (String delegateIdentity in delegateIdentities)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AddAccountDelegates(service, currentAddress, delegateIdentity, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;permissionLevelName, permissionLevel);
&nbsp;&nbsp;&nbsp; }
}

</pre>
<pre id="codePreview" class="csharp">else
{
&nbsp;&nbsp;&nbsp; // We can also directly press Enter to add the delegates to the login account. 
&nbsp;&nbsp;&nbsp;&nbsp;foreach (String delegateIdentity in delegateIdentities)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AddAccountDelegates(service, currentAddress, delegateIdentity, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;permissionLevelName, permissionLevel);
&nbsp;&nbsp;&nbsp; }
}

</pre>
</div>
</div>
<div class="endscriptcode"></div>
<p class="MsoNormal" style="margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:small">We add the delegate to the specific account.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">DelegateUser delegateUser = new DelegateUser(delegateAddress);


// Set the permission property of the delegate user.
foreach (PropertyInfo property in typeof(DelegatePermissions).GetProperties())
{
&nbsp;&nbsp;&nbsp; if (String.Compare(property.Name, permissionLevelName) == 0)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; property.SetValue(delegateUser.Permissions, permissionLevel);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp; }
}


Mailbox emailBox = new Mailbox(primaryAddress);
Collection&lt;DelegateUserResponse&gt; responses = service.AddDelegates(emailBox, 
&nbsp;&nbsp;&nbsp;&nbsp;MeetingRequestsDeliveryScope.DelegatesAndSendInformationToMe, delegateUser);
foreach (DelegateUserResponse response in responses)
{
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Add {0} as the delegate to the account {1}:{2}&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;delegateAddress, primaryAddress, response.Result);
&nbsp;&nbsp;&nbsp; Console.WriteLine();
}

</pre>
<pre id="codePreview" class="csharp">DelegateUser delegateUser = new DelegateUser(delegateAddress);


// Set the permission property of the delegate user.
foreach (PropertyInfo property in typeof(DelegatePermissions).GetProperties())
{
&nbsp;&nbsp;&nbsp; if (String.Compare(property.Name, permissionLevelName) == 0)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; property.SetValue(delegateUser.Permissions, permissionLevel);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp; }
}


Mailbox emailBox = new Mailbox(primaryAddress);
Collection&lt;DelegateUserResponse&gt; responses = service.AddDelegates(emailBox, 
&nbsp;&nbsp;&nbsp;&nbsp;MeetingRequestsDeliveryScope.DelegatesAndSendInformationToMe, delegateUser);
foreach (DelegateUserResponse response in responses)
{
&nbsp;&nbsp;&nbsp; Console.WriteLine(&quot;Add {0} as the delegate to the account {1}:{2}&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;delegateAddress, primaryAddress, response.Result);
&nbsp;&nbsp;&nbsp; Console.WriteLine();
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><span style="font-size:small"><a href="http://msdn.microsoft.com/en-us/library/dd633709(v=exchg.80).aspx">EWS Managed API 2.0</a></span></p>
<p class="MsoNormal"><span class="MsoHyperlink" style="font-size:small"><span style="color:windowtext; text-decoration:none"><a href="http://msdn.microsoft.com/en-us/library/dd633680(v=exchg.80).aspx">Working with impersonation by using the EWS Managed
 API</a> </span></span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

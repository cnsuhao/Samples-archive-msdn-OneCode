# How to add multiple delegates in Office 365 Exchange Online
## Requires
* Visual Studio 2013
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
* 2014-04-21 06:47:37
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:24pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-size:16pt">How to Add Delegates in Office 365 Exchange Online</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:12pt"></span><span style="font-size:12pt">Currently, you can easily add delegates in Outlook. But you
</span><span style="font-size:12pt">will </span><span style="font-size:12pt">find this feature is not available in Outlook Web App (OWA). In this application, we will demonstrate how to add multi delegates in Office 365 Exchange Online.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:12pt"></span><span style="font-size:12pt">1. Get the addresses of delegates;</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:12pt"></span><span style="font-size:12pt">2. Get the addresses of primary accounts;</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:12pt"></span><span style="font-size:12pt">3. Set the ImpersonatedUserId property if the login account has the impersonation permission.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:12pt"></span><span style="font-size:12pt">4. Add all the delegates into all the primary accounts.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Press F5 to run the sample,</span><span style="font-size:11pt"> you will get</span><span style="font-size:11pt"> the following result.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">First, we use our account to connect</span><span style="font-size:11pt"> to</span><span style="font-size:11pt"> the Exchange Online.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/113241/1/image.png" alt="" width="407" height="55" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Then, we need the identities of the delegates.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/113242/1/image.png" alt="" width="639" height="31" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">And if we have the impersonation permission, we can add the delegates to multi accounts by set</span><span style="font-size:11pt">ting</span><span style="font-size:11pt"> the
</span><span style="font-size:12pt">ImpersonatedUserId property</span><span style="font-size:11pt">.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/113243/1/image.png" alt="" width="643" height="39" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">The f</span><span style="font-size:11pt">ollowing is the result:</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/113244/1/image.png" alt="" width="649" height="139" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">If we don&rsquo;t have the impersonation permission, we can directly press Enter to add the delegates to the login account.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt"><span style="font-size:11pt">Before we add the delegates,
</span><span style="font-size:11pt">w</span><span style="font-size:11pt">e need the addresses of the delegates.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
Console.WriteLine(&quot;Please input the user identity(s) that were used as the delegates:&quot;);
 String delegateInfo = Console.ReadLine();
 // We get the addresses related to the identities of delegates.
 List&lt;String&gt; delegateIdentities = new List&lt;string&gt;();
 if (!String.IsNullOrWhiteSpace(delegateInfo))
 {
     // You can input the &quot;EXIT&quot; to exit.
     if (delegateInfo.ToUpper().CompareTo(&quot;EXIT&quot;) == 0)
     {
         return;
     }
     foreach (String delegateIdentity in delegateInfo.Split(','))
     {
         NameResolutionCollection nameResolutions =
    service.ResolveName(delegateIdentity, ResolveNameSearchLocation.DirectoryOnly, true);
         if (nameResolutions.Count != 1)
         {
             Console.WriteLine(&quot;{0} is invalid user identity as the delegate.&quot;,
                 delegateIdentity);
         }
         else
         {
             delegateIdentities.Add(nameResolutions[0].Mailbox.Address);
         }
     }
     if (delegateIdentities.Count == 0)
     {
         Console.WriteLine(&quot;There's not any valid user identity as the delegate.&quot;);
         continue;
     }
 }
 else
 {
     Console.WriteLine(&quot;The delegates cannot be null!&quot;);
     continue;
 }
</pre>
<pre class="hidden">
Console.WriteLine(&quot;Please input the user identity(s) that were used as the delegates:&quot;)
Dim delegateInfo As String = Console.ReadLine()
' We get the addresses related to the identities of delegates.
Dim delegateIdentities As New List(Of String)()
If Not String.IsNullOrWhiteSpace(delegateInfo) Then
    ' You can input the &quot;EXIT&quot; to exit.
    If delegateInfo.ToUpper().CompareTo(&quot;EXIT&quot;) = 0 Then
        Return
    End If
    For Each delegateIdentity As String In delegateInfo.Split(&quot;,&quot;c)
        Dim nameResolutions As NameResolutionCollection =
    service.ResolveName(delegateIdentity, ResolveNameSearchLocation.DirectoryOnly, True)
        If nameResolutions.Count &lt;&gt; 1 Then
            Console.WriteLine(&quot;{0} is invalid user identity as the delegate.&quot;,
                              delegateIdentity)
        Else
            delegateIdentities.Add(nameResolutions(0).Mailbox.Address)
        End If
    Next delegateIdentity
    If delegateIdentities.Count = 0 Then
        Console.WriteLine(&quot;There's not any valid user identity as the delegate.&quot;)
        Continue Do
    End If
Else
    Console.WriteLine(&quot;The delegates cannot be null!&quot;)
    Continue Do
End If
</pre>
<pre id="codePreview" class="csharp">
Console.WriteLine(&quot;Please input the user identity(s) that were used as the delegates:&quot;);
 String delegateInfo = Console.ReadLine();
 // We get the addresses related to the identities of delegates.
 List&lt;String&gt; delegateIdentities = new List&lt;string&gt;();
 if (!String.IsNullOrWhiteSpace(delegateInfo))
 {
     // You can input the &quot;EXIT&quot; to exit.
     if (delegateInfo.ToUpper().CompareTo(&quot;EXIT&quot;) == 0)
     {
         return;
     }
     foreach (String delegateIdentity in delegateInfo.Split(','))
     {
         NameResolutionCollection nameResolutions =
    service.ResolveName(delegateIdentity, ResolveNameSearchLocation.DirectoryOnly, true);
         if (nameResolutions.Count != 1)
         {
             Console.WriteLine(&quot;{0} is invalid user identity as the delegate.&quot;,
                 delegateIdentity);
         }
         else
         {
             delegateIdentities.Add(nameResolutions[0].Mailbox.Address);
         }
     }
     if (delegateIdentities.Count == 0)
     {
         Console.WriteLine(&quot;There's not any valid user identity as the delegate.&quot;);
         continue;
     }
 }
 else
 {
     Console.WriteLine(&quot;The delegates cannot be null!&quot;);
     continue;
 }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt"><span style="font-size:11pt"></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">If we have impersonation permission, we can add the delegates to multi accounts by set</span><span style="font-size:11pt">ting</span><span style="font-size:11pt"> the
</span><span style="font-size:12pt">ImpersonatedUserId property</span><span style="font-size:11pt">.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
Console.WriteLine(&quot;Please input the user identity you want to set the &quot; &#43;
    &quot;delegates(or you can directly press Enter to set delegates in current account):&quot;);
String primaryInfo = Console.ReadLine();
if (!String.IsNullOrWhiteSpace(primaryInfo))
{
    // You can input the &quot;EXIT&quot; to exit.
    if (primaryInfo.ToUpper().CompareTo(&quot;EXIT&quot;) == 0)
    {
        return;
    }
    String[] primaryIdentities = primaryInfo.Split(',');
    foreach (String primaryIdentity in primaryIdentities)
    {
        // If the user identity is valid, we will set it as the ImpersonatedUserId.
        NameResolutionCollection nameResolutions =
     service.ResolveName(primaryIdentity, ResolveNameSearchLocation.DirectoryOnly, true);
        if (nameResolutions.Count != 1)
        {
            Console.WriteLine(&quot;{0} is invalid user identity.&quot;, primaryIdentity);
        }
        else
        {
            String emailAddress = nameResolutions[0].Mailbox.Address;
            service.ImpersonatedUserId =
                new ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress);
foreach (String delegateIdentity in delegateIdentities)
                        {
                AddAccountDelegates(service, emailAddress, delegateIdentity, 
                    permissionLevelName, permissionLevel);
            }
        }
    }
}
</pre>
<pre class="hidden">
Console.WriteLine(&quot;Please input the user identity you want to set the &quot; &
            &quot;delegates(or you can directly press Enter to set delegates in current account):&quot;)
Dim primaryInfo As String = Console.ReadLine()
If Not String.IsNullOrWhiteSpace(primaryInfo) Then
    ' You can input the &quot;EXIT&quot; to exit.
    If primaryInfo.ToUpper().CompareTo(&quot;EXIT&quot;) = 0 Then
        Return
    End If
    Dim primaryIdentities() As String = primaryInfo.Split(&quot;,&quot;c)
    For Each primaryIdentity As String In primaryIdentities
        ' If the user identity is valid, we will set it as the ImpersonatedUserId.
        Dim nameResolutions As NameResolutionCollection =
            service.ResolveName(primaryIdentity, ResolveNameSearchLocation.DirectoryOnly,
                                True)
        If nameResolutions.Count &lt;&gt; 1 Then
            Console.WriteLine(&quot;{0} is invalid user identity.&quot;, primaryIdentity)
        Else
            Dim emailAddress As String = nameResolutions(0).Mailbox.Address
            service.ImpersonatedUserId =
                New ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress)
            For Each delegateIdentity As String In delegateIdentities
                AddAccountDelegates(service, emailAddress, delegateIdentity,
                                    permissionLevelName, permissionLevel)
            Next delegateIdentity
        End If
    Next primaryIdentity
</pre>
<pre id="codePreview" class="csharp">
Console.WriteLine(&quot;Please input the user identity you want to set the &quot; &#43;
    &quot;delegates(or you can directly press Enter to set delegates in current account):&quot;);
String primaryInfo = Console.ReadLine();
if (!String.IsNullOrWhiteSpace(primaryInfo))
{
    // You can input the &quot;EXIT&quot; to exit.
    if (primaryInfo.ToUpper().CompareTo(&quot;EXIT&quot;) == 0)
    {
        return;
    }
    String[] primaryIdentities = primaryInfo.Split(',');
    foreach (String primaryIdentity in primaryIdentities)
    {
        // If the user identity is valid, we will set it as the ImpersonatedUserId.
        NameResolutionCollection nameResolutions =
     service.ResolveName(primaryIdentity, ResolveNameSearchLocation.DirectoryOnly, true);
        if (nameResolutions.Count != 1)
        {
            Console.WriteLine(&quot;{0} is invalid user identity.&quot;, primaryIdentity);
        }
        else
        {
            String emailAddress = nameResolutions[0].Mailbox.Address;
            service.ImpersonatedUserId =
                new ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress);
foreach (String delegateIdentity in delegateIdentities)
                        {
                AddAccountDelegates(service, emailAddress, delegateIdentity, 
                    permissionLevelName, permissionLevel);
            }
        }
    }
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt"><span style="font-size:11pt">If we don&rsquo;t have the impersonation permission,
</span><span style="font-size:11pt">we can directly press Enter to add the delegates to the login account.</span></span>
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
    // We can also directly press Enter to add the delegates to the login account. 
    foreach (String delegateIdentity in delegateIdentities)
    {
        AddAccountDelegates(service, currentAddress, delegateIdentity, 
            permissionLevelName, permissionLevel);
    }
}
</pre>
<pre class="hidden">
Else
    ' We can also directly press Enter to add the delegates to the login account. 
    For Each delegateIdentity As String In delegateIdentities
        AddAccountDelegates(service, currentAddress, delegateIdentity,
                            permissionLevelName, permissionLevel)
    Next delegateIdentity
End If
</pre>
<pre id="codePreview" class="csharp">
else
{
    // We can also directly press Enter to add the delegates to the login account. 
    foreach (String delegateIdentity in delegateIdentities)
    {
        AddAccountDelegates(service, currentAddress, delegateIdentity, 
            permissionLevelName, permissionLevel);
    }
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt"><span style="font-size:11pt"></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">We add the delegate to the specifi</span><span style="font-size:11pt">ed</span><span style="font-size:11pt"> a</span><a name="_GoBack"></a><span style="font-size:11pt">ccount.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
DelegateUser delegateUser = new DelegateUser(delegateAddress);
// Set the permission property of the delegate user.
foreach (PropertyInfo property in typeof(DelegatePermissions).GetProperties())
{
    if (String.Compare(property.Name, permissionLevelName) == 0)
    {
        property.SetValue(delegateUser.Permissions, permissionLevel);
        break;
    }
}
Mailbox emailBox = new Mailbox(primaryAddress);
Collection&lt;DelegateUserResponse&gt; responses = service.AddDelegates(emailBox, 
    MeetingRequestsDeliveryScope.DelegatesAndSendInformationToMe, delegateUser);
foreach (DelegateUserResponse response in responses)
{
    Console.WriteLine(&quot;Add {0} as the delegate to the account {1}:{2}&quot;, 
        delegateAddress, primaryAddress, response.Result);
    Console.WriteLine();
}
</pre>
<pre class="hidden">
Dim delegateUser As New DelegateUser(delegateAddress)
' Set the permission property of the delegate user.
For Each [property] As PropertyInfo In GetType(DelegatePermissions).GetProperties()
    If String.Compare([property].Name, permissionLevelName) = 0 Then
        [property].SetValue(delegateUser.Permissions, permissionLevel)
        Exit For
    End If
Next [property]
Dim emailBox As New Mailbox(primaryAddress)
Dim responses As Collection(Of DelegateUserResponse) =
    service.AddDelegates(emailBox,
                         MeetingRequestsDeliveryScope.DelegatesAndSendInformationToMe,
                         delegateUser)
For Each response As DelegateUserResponse In responses
    Console.WriteLine(&quot;Add {0} as the delegate to the account {1}:{2}&quot;,
                      delegateAddress, primaryAddress, response.Result)
    Console.WriteLine()
Next response
        End Sub
</pre>
<pre id="codePreview" class="csharp">
DelegateUser delegateUser = new DelegateUser(delegateAddress);
// Set the permission property of the delegate user.
foreach (PropertyInfo property in typeof(DelegatePermissions).GetProperties())
{
    if (String.Compare(property.Name, permissionLevelName) == 0)
    {
        property.SetValue(delegateUser.Permissions, permissionLevel);
        break;
    }
}
Mailbox emailBox = new Mailbox(primaryAddress);
Collection&lt;DelegateUserResponse&gt; responses = service.AddDelegates(emailBox, 
    MeetingRequestsDeliveryScope.DelegatesAndSendInformationToMe, delegateUser);
foreach (DelegateUserResponse response in responses)
{
    Console.WriteLine(&quot;Add {0} as the delegate to the account {1}:{2}&quot;, 
        delegateAddress, primaryAddress, response.Result);
    Console.WriteLine();
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style=""></span></span></p>
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

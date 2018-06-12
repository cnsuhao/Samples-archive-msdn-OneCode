# How to Export and Import Master Category List in Office 365
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Exchange Online
* Office 365
## Topics
* export
* Import
* category list
## IsPublished
* True
## ModifiedDate
* 2014-04-10 02:37:34
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:24pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to Export and Import Master Category List in Office 365
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Currently, Outlook Web App (OWA) do</span><span style="font-size:11pt">es</span><span style="font-size:11pt"> not allow user</span><span style="font-size:11pt">s</span><span style="font-size:11pt"> to
 export and import Master Category List. But some customers rel</span><span style="font-size:11pt">y</span><span style="font-size:11pt"> on this feature for handling their email messages efficiently. So they need a workaround to mitigate this issue. In this
 application, we will demonstrate how to export and import Master Category List in O365:</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">1. Export the Master Category List</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt">
<span style="font-size:11pt"><span style="font-size:11pt">a. Get the account(s) you want to export the Master Category List from</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt">
<span style="font-size:11pt"><span style="font-size:11pt">b. Get the user configuration of the account(s)</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt">
<span style="font-size:11pt"><span style="font-size:11pt">c. Export the Master Category List from the user configuration</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">2. Import the Master Category List</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt">
<span style="font-size:11pt"><span style="font-size:11pt">a. Get the account(s) you want to import the Master Category List into</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt">
<span style="font-size:11pt"><span style="font-size:11pt">b. Get the file that stores Master Category List</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt">
<span style="font-size:11pt"><span style="font-size:11pt">c. Get the user configuration of the account(s)</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:36pt">
<span style="font-size:11pt"><span style="font-size:11pt">d. Import the Master Category List from the file</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Press F5 to run the sample.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">First,&nbsp;use your account to connect the Exchange Online.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/112658/1/image.png" alt="" width="407" height="55" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">1. Export the Master Category List</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; text-indent:9.75pt">
<span style="font-size:11pt"><span style="font-size:11pt">a. If you have Impersonation permission or you have permission to access the specified accounts, you can export Master Category
</span><span style="font-size:11pt">L</span><span style="font-size:11pt">ist from multi accounts.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/112659/1/image.png" alt="" width="575" height="34" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; text-indent:9.75pt">
<span style="font-size:11pt"><span style="font-size:11pt">b. Input </span><span style="font-size:11pt">the path of folder that
</span><span style="font-size:11pt">will </span><span style="font-size:11pt">be used to
</span><span style="font-size:11pt">store</span><span style="font-size:11pt"> the Master Category List file.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; text-indent:9.75pt">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/112660/1/image.png" alt="" width="575" height="38" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">If you only export Master Category List from one account, you can input the path of file that
</span><span style="font-size:11pt">will </span><span style="font-size:11pt">be used to
</span><span style="font-size:11pt">store</span><span style="font-size:11pt"> the Master Category List.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">2. Import the Master Category List</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; text-indent:9.75pt">
<span style="font-size:11pt"><span style="font-size:11pt">a. </span><span style="font-size:11pt">If you have Impersonation permission or you have permission to access the specified accounts, you can import Master Category List into multi accounts.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/112661/1/image.png" alt="" width="575" height="37" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">b. Input the path of folder that contains the Master Category List file.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/112662/1/image.png" alt="" width="575" height="42" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">If you only import Master Category List into one account, you can input the path of file that</span><span style="font-size:11pt">
</span><span style="">contains</span><span style="font-size:11pt"> the Master Category List.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">1. Export the Master Category List</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; text-indent:9.75pt">
<span style="font-size:11pt"><span style="font-size:11pt">a. Get the accounts that you want to export the Master Category List from.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
Console.WriteLine(&quot;Please input the user identity that you want to export &quot; &#43;
               &quot;Master Category List from(or you can directly press Enter to export the list &quot; &#43;
               &quot;from current account):&quot;);
           String inputInfo = Console.ReadLine();
           if (!String.IsNullOrWhiteSpace(inputInfo))
           {
               String[] identities = inputInfo.Split(',');
               ..................
               foreach (String identity in identities)
               {
                   NameResolutionCollection nameResolutions =
                       service.ResolveName(identity, ResolveNameSearchLocation.DirectoryOnly, true);
                   if (nameResolutions.Count != 1)
                   {
                       Console.WriteLine(&quot;{0} is invalid user identity.&quot;, identity);
                   }
                   else
                   {
                       String emailAddress = nameResolutions[0].Mailbox.Address;
                       String filePath = GetFilePath(path, identity);
                       // If our account have Impersonation permission, we can set it.
                       if (usingImpersonation)
                       {
                           service.ImpersonatedUserId =
                                   new ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress);
                           ExportMasterCategoryListWithImpersonation(service, filePath);
                           service.ImpersonatedUserId = null;
                       }
                       else
                       {
                           ExportMasterCategoryListWithoutImpersonation(service, emailAddress, filePath);
                       }
                   }
               }
           }
           else
           {
               words = &quot;Please input the folder or file(.xml) path:&quot;;
               path = InputPath(words, false, false);
               String filePath = GetFilePath(path, currentAddress);
               ExportMasterCategoryListWithImpersonation(service, filePath);
           }
</pre>
<pre class="hidden">
Console.WriteLine(&quot;Please input the user identity that you want to export &quot; & &quot;Master Category List from(or you can directly press Enter to export the list &quot; & &quot;from current account):&quot;)
           Dim inputInfo As String = Console.ReadLine()
           If Not String.IsNullOrWhiteSpace(inputInfo) Then
               Dim identities() As String = inputInfo.Split(&quot;,&quot;c)
              .....................................................
               For Each identity As String In identities
                   Dim nameResolutions As NameResolutionCollection =
                       service.ResolveName(identity, ResolveNameSearchLocation.DirectoryOnly, True)
                   If nameResolutions.Count &lt;&gt; 1 Then
                       Console.WriteLine(&quot;{0} is invalid user identity.&quot;, identity)
                   Else
                       Dim emailAddress As String = nameResolutions(0).Mailbox.Address
                       Dim filePath As String = GetFilePath(path, identity)
                       ' If our account have Impersonation permission, we can set it.
                       If usingImpersonation Then
                           service.ImpersonatedUserId =
                               New ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress)
                           ExportMasterCategoryListWithImpersonation(service, filePath)
                           service.ImpersonatedUserId = Nothing
                       Else
                           ExportMasterCategoryListWithoutImpersonation(service, emailAddress, filePath)
                       End If
                   End If
               Next identity
           Else
               words = &quot;Please input the folder or file(.xml) path:&quot;
               path = InputPath(words, False, False)
               Dim filePath As String = GetFilePath(path, currentAddress)
               ExportMasterCategoryListWithImpersonation(service, filePath)
           End If
</pre>
<pre id="codePreview" class="csharp">
Console.WriteLine(&quot;Please input the user identity that you want to export &quot; &#43;
               &quot;Master Category List from(or you can directly press Enter to export the list &quot; &#43;
               &quot;from current account):&quot;);
           String inputInfo = Console.ReadLine();
           if (!String.IsNullOrWhiteSpace(inputInfo))
           {
               String[] identities = inputInfo.Split(',');
               ..................
               foreach (String identity in identities)
               {
                   NameResolutionCollection nameResolutions =
                       service.ResolveName(identity, ResolveNameSearchLocation.DirectoryOnly, true);
                   if (nameResolutions.Count != 1)
                   {
                       Console.WriteLine(&quot;{0} is invalid user identity.&quot;, identity);
                   }
                   else
                   {
                       String emailAddress = nameResolutions[0].Mailbox.Address;
                       String filePath = GetFilePath(path, identity);
                       // If our account have Impersonation permission, we can set it.
                       if (usingImpersonation)
                       {
                           service.ImpersonatedUserId =
                                   new ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress);
                           ExportMasterCategoryListWithImpersonation(service, filePath);
                           service.ImpersonatedUserId = null;
                       }
                       else
                       {
                           ExportMasterCategoryListWithoutImpersonation(service, emailAddress, filePath);
                       }
                   }
               }
           }
           else
           {
               words = &quot;Please input the folder or file(.xml) path:&quot;;
               path = InputPath(words, false, false);
               String filePath = GetFilePath(path, currentAddress);
               ExportMasterCategoryListWithImpersonation(service, filePath);
           }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; text-indent:9.75pt">
<span style="font-size:11pt"><span style="font-size:11pt">b. Export the Master Category List from the specified account.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
static void ExportMasterCategoryListWithImpersonation(ExchangeService service, String filePath)
{
    UserConfiguration userConfiguration = 
        UserConfiguration.Bind(service, &quot;CategoryList&quot;, WellKnownFolderName.Calendar, 
        UserConfigurationProperties.XmlData);
    String categoryListString = UTF8Encoding.UTF8.GetString(userConfiguration.XmlData);
    WriteFile(categoryListString, filePath);
}
</pre>
<pre class="hidden">
Private Shared Sub ExportMasterCategoryListWithImpersonation(ByVal service As ExchangeService,
                                                             ByVal filePath As String)
    Dim userConfiguration As UserConfiguration =
        userConfiguration.Bind(service, &quot;CategoryList&quot;, WellKnownFolderName.Calendar,
                               UserConfigurationProperties.XmlData)
    Dim categoryListString As String = UTF8Encoding.UTF8.GetString(userConfiguration.XmlData)
    WriteFile(categoryListString, filePath)
End Sub
</pre>
<pre id="codePreview" class="csharp">
static void ExportMasterCategoryListWithImpersonation(ExchangeService service, String filePath)
{
    UserConfiguration userConfiguration = 
        UserConfiguration.Bind(service, &quot;CategoryList&quot;, WellKnownFolderName.Calendar, 
        UserConfigurationProperties.XmlData);
    String categoryListString = UTF8Encoding.UTF8.GetString(userConfiguration.XmlData);
    WriteFile(categoryListString, filePath);
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">2. Import the Master Category List</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">a. Import the Master Category List into the specified account.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
static void ImportMasterCategoryListWithImpersonation(ExchangeService service, String filePath)
{
    UserConfiguration userConfiguration = UserConfiguration.Bind(service, &quot;CategoryList&quot;, WellKnownFolderName.Calendar, UserConfigurationProperties.XmlData);
    String categoryListString = ReadFile(filePath);
    Byte[] categoryListBytes = UTF8Encoding.UTF8.GetBytes(categoryListString);
    userConfiguration.XmlData = categoryListBytes;
    userConfiguration.Update();
}
</pre>
<pre class="hidden">
Private Shared Sub ImportMasterCategoryListWithImpersonation(ByVal service As ExchangeService,
                                                             ByVal filePath As String)
    Dim userConfiguration As UserConfiguration = userConfiguration.Bind(service, &quot;CategoryList&quot;,
                            WellKnownFolderName.Calendar, UserConfigurationProperties.XmlData)
    Dim categoryListString As String = ReadFile(filePath)
    Dim categoryListBytes() As Byte = UTF8Encoding.UTF8.GetBytes(categoryListString)
    userConfiguration.XmlData = categoryListBytes
    userConfiguration.Update()
End Sub
</pre>
<pre id="codePreview" class="csharp">
static void ImportMasterCategoryListWithImpersonation(ExchangeService service, String filePath)
{
    UserConfiguration userConfiguration = UserConfiguration.Bind(service, &quot;CategoryList&quot;, WellKnownFolderName.Calendar, UserConfigurationProperties.XmlData);
    String categoryListString = ReadFile(filePath);
    Byte[] categoryListBytes = UTF8Encoding.UTF8.GetBytes(categoryListString);
    userConfiguration.XmlData = categoryListBytes;
    userConfiguration.Update();
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span>
</p>
<a name="_GoBack"></a>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"></span><a href="http://msdn.microsoft.com/en-us/library/dd633709(v=exchg.80).aspx"><span style="color:#0563C1; text-decoration:underline">EWS Managed API 2.0</span></a><span style="font-size:11pt">
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

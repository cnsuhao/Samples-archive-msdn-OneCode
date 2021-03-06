# Retrieve office 365 user details and give permission thru c# using EWS and Pow
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* scripting
* Windows PowerShell
## Topics
* C#
* Powershell
* Office 365
* EWS API
## IsPublished
* True
## ModifiedDate
* 2013-07-05 02:50:20
## Description

<h1>O365 Delegates (CSEWSSol)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">Office 365 Delegates Tool has been developed to help Office 365 Exchange administrators to perform get mailbox and the calendar delegate task for the mailboxes in the cloud. Also developers and IT Professional will get benefit out of
 the sample. </p>
<p class="MsoNormal">The tool can be used to: </p>
<p class="Default"><span class="GramE"><span style="font-size:10.5pt; font-family:Wingdings">ü
</span><span style="font-size:10.5pt">Find existing distribution list members.</span></span><span style="font-size:10.5pt">
</span></p>
<p class="Default"><span style="font-size:10.5pt; font-family:Wingdings">ü </span>
<span style="font-size:10.5pt">Allow others to manage your mailbox and calendar by giving delegate permission.
</span></p>
<p class="Default" style="margin-bottom:4.2pt"><span style="font-size:10.5pt; font-family:Wingdings">ü
</span><span style="font-size:10.5pt">List delegate permission. </span></p>
<p class="Default" style="margin-bottom:4.2pt"><span style="font-size:10.5pt; font-family:Wingdings">ü
</span><span style="font-size:10.5pt">Remove delegate permission. </span></p>
<p class="Default" style="margin-bottom:4.2pt"><span style="font-size:10.5pt; font-family:Wingdings">ü
</span><span style="font-size:10.5pt">Modify delegate permission level. </span></p>
<p class="Default" style="margin-bottom:4.2pt"><span style="font-size:10.5pt; font-family:Wingdings">ü
</span><span style="font-size:10.5pt">Grant &amp; Revoke &quot;Full Mailbox&quot; and &quot;Send As&quot; Permission.
</span></p>
<p class="Default" style="margin-bottom:4.2pt"><span style="font-size:10.5pt; font-family:Wingdings">ü
</span><span style="font-size:10.5pt">Run various Office 365 PowerShell commands to retrieve user/mailbox details.
</span></p>
<p class="Default"><span style="font-size:10.5pt; font-family:Wingdings">ü </span>
<span style="font-size:10.5pt">It is provisioned to get LDP dump of the on-premise user through PowerShell.
</span></p>
<p class="Default"><span style="font-size:10.5pt"></span></p>
<p class="MsoNormal">As the tool can be used to perform the task that can be done with other application and thru manual PowerShell, but with less effort, it is named as Office 365 Delegates.
</p>
<p class="MsoNormal">Delegates' synonyms: The Person authorized to act as representative for another; a deputy or an agent.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal" style="margin-top:10.0pt"><b><span style="font-size:13.5pt; line-height:115%">Pre-Requisites:</span></b><span style="font-size:10.5pt; line-height:115%">
</span></p>
<p class="MsoNormal"><b>Operating system: </b>Use Windows 7, Windows 8, Windows Server 2008 R2, or Windows Server 2012.
<span style=""></span></p>
<p class="MsoNormal"><b>Microsoft .NET Framework: </b>By Default, the latest OS windows includes .Net Framework. If you do not have, you must install the Microsoft .NET Framework 4.0 feature and above.
</p>
<p class="MsoNormal">Related Link: <a href="http://www.microsoft.com/en-us/download/details.aspx?id=17851">
http://www.microsoft.com/en-us/download/details.aspx?id=17851</a> </p>
<p class="MsoNormal"><b>Install the Windows Management Framework: </b></p>
<p class="MsoNormal">By Default, the latest OS Windows includes WinRM and PowerShell. If you do not have, you should download and install the Windows Management Framework. Choose the package that includes
<span style="">&nbsp;</span>Windows PowerShell v2 and WinRM 2.0, and that apply to your operating system, system architecture, and language. After you install WinRM and Windows PowerShell, configure the software to work correctly as described in the next steps.
<b>Note </b>If your local computer is protected by a Microsoft Internet Security and Acceleration (ISA) server, you may have to install the Windows Firewall Client or configure a proxy server on your local computer to connect Windows PowerShell to the cloud-based
 service. For more information, see Windows PowerShell: FAQs for Administrators. </p>
<p class="MsoNormal"><b>Install Microsoft Online Services Sign-in Assistant</b>: You must install the appropriate version of the Microsoft Online Services Sign-in Assistant for your operating system from the Microsoft Download Center. Microsoft Online Services
 Sign-In Assistant for IT Professionals RTW. </p>
<p class="MsoNormal"><b>Install the Windows Azure AD Module for Windows PowerShell</b>: You must install the appropriate version of the Windows Azure AD Module for Windows PowerShell for your operating system from the Microsoft Download Center:
</p>
<p class="MsoNormal"><span class="GramE"><span style="font-size:10.0pt; line-height:115%; font-family:&quot;Courier New&quot;">o</span></span><span style="font-size:10.0pt; line-height:115%; font-family:&quot;Courier New&quot;">
</span>Windows Azure Active Directory Module for Windows PowerShell (32-bit version)
</p>
<p class="MsoNormal"><span class="GramE"><span style="font-size:10.0pt; line-height:115%; font-family:&quot;Courier New&quot;">o</span></span><span style="font-size:10.0pt; line-height:115%; font-family:&quot;Courier New&quot;">
</span>Windows Azure Active Directory Module for Windows PowerShell (64-bit version)</p>
<h2>Running the Sample</h2>
<p class="MsoListParagraph" style="text-indent:5.0pt"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><b style="">How to Use the Tool </b></p>
<p class="MsoNormal">It is a stand-alone tool and is multi-instance capable. The tool cannot be run in DOS/Command Prompt as it is GUI based. It creates a Desktop shortcut after installation. The tool tested in Windows 7, Windows 8, Windows 2008 R2 and Windows
 2012. <span style=""></span></p>
<p class="MsoNormal">When you double-click the tool short-cut or the application file, the tool presents you with Disclaimer. If you are fine with the disclaimer, click &quot;I Accept&quot;. Then it will display the
<b>Authentication </b>screen as shown in Picture 1. </p>
<p class="MsoNormal"><b style=""><span style=""><img src="/site/view/file/91879/1/image.png" alt="" width="539" height="307" align="middle">
</span><span style=""></span></b></p>
<p class="MsoNormal"><b>Picture 1: Authentication screen </b></p>
<p class="MsoNormal">The Screen let you input logon details and it is self-explanatory. There are two buttons along with logon input options,
</p>
<p class="MsoNormal"><b>Buttons are, <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></b></p>
<p class="MsoNormal"><span class="SpellE"><b>AutoDiscover</b></span><b> (WS):
</b>It will use the logon details on the screen to makes <span class="SpellE">autodiscover</span> call to find the Exchange Web Service (EWS) URL and establish EWS session. Once the session established, you can use option in tab titled with (WS). As only
 EWS session is setup, you will not be able to use the option in tab titled with (PS).
<span style="">8 </span></p>
<p class="MsoNormal"><b>PowerShell (PS): </b>It will use the logon details on the screen to establish PowerShell Session and Import Exchange and
<span class="SpellE">MSOnline</span> Modules. Once the session established, you can use option in tab titled with (PS). As only PS session is setup, you will not be able to use the option in tab titled with (WS).
</p>
<p class="MsoNormal"><b>Note: Depending on the internet throughput, the tool takes time to create Remote PowerShell / EWS Session.
</b></p>
<p class="MsoNormal">In order to discover EWS endpoint, you have to provide the Email ID of any cloud mailbox user with
<b>Impersonation </b>permission, the password and the tenant domain then click buttons.
</p>
<p class="MsoNormal">You can refer to the following TechNet link for configuring Exchange Impersonation for all users:
<a href="http://msdn.microsoft.com/en-us/library/bb204095(EXCHG.140).aspx"><span style="font-size:10.5pt; line-height:115%">http://msdn.microsoft.com/en-us/library/bb204095(EXCHG.140).aspx</span></a>.
</p>
<p class="MsoNormal">The task buttons in each tab will be enabled only if the EWS endpoints discover process succeeds or the Remote PowerShell Session gets through, otherwise you will not be able to use the tool as EWS Endpoint/Remote PowerShell are crucial
 to the functionality of the tool. </p>
<p class="MsoNormal">During <span class="GramE">the discover</span>/ Remote PowerShell process, the button title changes to &quot;Processing…&quot; You have to wait until it changes back to its original title. Once the sessions are successfully created,
 you can use the tool to perform various tasks.</p>
<p class="MsoListParagraph" style="text-indent:5.0pt"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><b style="">How Tool Works </b></p>
<p class="MsoNormal">As an Office 365 Exchange Administrator, if you want to perform any activity on the mailboxes that are in the cloud, you will use
<b>Remote PowerShell </b>or <b>Online Portal</b>. Both connect to the remote server over the internet.
<span style="font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormal">Similarly, the Office 365 Delegates tool requires internet connection to connect to Office 365 servers.
<span style=""><span style="">&nbsp;</span> </span></p>
<p class="MsoNormal">The tool has to connect to EWS or Remote <span class="SpellE">
Powershell</span> to perform the tasks. It uses the <span class="SpellE"><b>Autodiscover</b></span><b>
</b>feature of Exchange to return EWS endpoint to communicate with the Exchange server. By default, direct EWS access is enabled for all Exchange Online plans except for the
<b>Kiosk </b>plan. So, any mailbox user in the cloud can discover EWS URL using <span class="SpellE">
Autodiscover</span>. You do not need any additional permission. However, if you wish to do other tasks in the tool thru EWS, you need to have
<b>Impersonation </b>permission. When you want to perform a delegate task, the tool makes EWS call to the Exchange Server. So it is crucial to use account with
<b>Impersonation </b>permission. </p>
<p class="MsoNormal">You can refer to the following TechNet link for configuring Exchange Impersonation for all users:
<a href="http://msdn.microsoft.com/en-us/library/bb204095(EXCHG.140).aspx"><span style="font-size:10.5pt; line-height:115%">http://msdn.microsoft.com/en-us/library/bb204095(EXCHG.140).aspx</span></a>.
</p>
<p class="MsoNormal">Secondly the tool also uses Remote PowerShell to perform various SET &amp; GET tasks. It is expected that the machine that runs the tool installed with pre-requisites for the commands to function. For Example: Get-<span class="SpellE">msoluser</span>
 command would require additional module to run. So please refer the pre-requisite section in the documentation before using the tool.
</p>
<p class="MsoNormal"><b>Note: </b>I have titled the fields/options as per Exchange Terminology used with Exchange Shell for the easier understanding.
</p>
<p class="MsoNormal">The options in various tabs are un-uniform. It was done intentionally as I wanted to display the different coding style to help IT Pros/Developers.
</p>
<p class="MsoNormal"><b>Note: </b>The EWS tasks being done may take time on the mailboxes on the cloud. Even if the tool completed the task, the replication on the cloud may be still working. When you attempt to perform the activity on the mailbox for which
 the replication on the cloud, you may get message as &quot;Previous action on the mailbox is still in process. Please try after sometime&quot;.
</p>
<p class="MsoNormal"><b>Note: </b>The tool duplicates PowerShell behavior while executing the commands. That means<span class="GramE">,</span> if there is no output shown to any of the command executed, you will have no detail shown in output file.<b style="">
</b></p>
<h2>Using the Code</h2>
<p class="MsoNormal"><span style="">The code used in the sample can be used for developing applications/tool using EWS API or PowerShell to work on Office 365 mailboxes. I intentionally did not follow the uniformity in the tool to help the developers to get
 an idea on sample code for different requirement. </span></p>
<p class="MsoNormal"><span style="">Although there are many ways to call the PowerShell commands, I used the method to build the PS1 file thru C#, and then execute it.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
if (!File.Exists(psPath))
    {
        using (StreamWriter writeFile = File.CreateText(psPath))
        {
            writeFile.WriteLine(&quot;$error.clear()&quot;);
            writeFile.WriteLine(@&quot;Add-MailboxPermission -Identity  $usr -AccessRights FullAccess -User $tst -InheritanceType All -Confirm:$False &quot;);
            writeFile.WriteLine(@&quot;Get-MailboxPermission -identity $usr | FL | out-file $outPath&quot;);
            writeFile.WriteLine(&quot;if($error -ne $null){$error &gt; $outPath }&quot;);
            writeFile.Close();
        }
    }
    else
    {
        TextWriter writeFile = new StreamWriter(psPath);
        writeFile.WriteLine(&quot;$error.clear()&quot;);
        writeFile.WriteLine(@&quot;Add-MailboxPermission -Identity  $usr -AccessRights FullAccess -User $tst -InheritanceType All -Confirm:$False &quot;);
        writeFile.WriteLine(@&quot;Get-MailboxPermission -identity $usr | FL | out-file $outPath&quot;);
        writeFile.WriteLine(&quot;if($error -ne $null){$error &gt; $outPath }&quot;);
        writeFile.Close();
    }

</pre>
<pre id="codePreview" class="csharp">
if (!File.Exists(psPath))
    {
        using (StreamWriter writeFile = File.CreateText(psPath))
        {
            writeFile.WriteLine(&quot;$error.clear()&quot;);
            writeFile.WriteLine(@&quot;Add-MailboxPermission -Identity  $usr -AccessRights FullAccess -User $tst -InheritanceType All -Confirm:$False &quot;);
            writeFile.WriteLine(@&quot;Get-MailboxPermission -identity $usr | FL | out-file $outPath&quot;);
            writeFile.WriteLine(&quot;if($error -ne $null){$error &gt; $outPath }&quot;);
            writeFile.Close();
        }
    }
    else
    {
        TextWriter writeFile = new StreamWriter(psPath);
        writeFile.WriteLine(&quot;$error.clear()&quot;);
        writeFile.WriteLine(@&quot;Add-MailboxPermission -Identity  $usr -AccessRights FullAccess -User $tst -InheritanceType All -Confirm:$False &quot;);
        writeFile.WriteLine(@&quot;Get-MailboxPermission -identity $usr | FL | out-file $outPath&quot;);
        writeFile.WriteLine(&quot;if($error -ne $null){$error &gt; $outPath }&quot;);
        writeFile.Close();
    }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
//Function runSetCMDlet
                    public void runSetCMDlet(string PSPath, string usr, string tst, string OutPath)
                    {
                       System.Collections.ObjectModel.Collection&lt;PSObject&gt; outPUT = new System.Collections.ObjectModel.Collection&lt;PSObject&gt;();
                       powershell = PowerShell.Create();
                       powershell.Runspace = runspace;
                       System.IO.StreamReader sr = new System.IO.StreamReader(PSPath);
                       powershell.AddScript(sr.ReadToEnd());
                       powershell.Runspace.SessionStateProxy.SetVariable(&quot;usr&quot;, usr);
                       powershell.Runspace.SessionStateProxy.SetVariable(&quot;tst&quot;, tst);
                       powershell.Runspace.SessionStateProxy.SetVariable(&quot;outPath&quot;, OutPath);
                       outPUT = powershell.Invoke();
                       sr.Close();
                     }

</pre>
<pre id="codePreview" class="csharp">
//Function runSetCMDlet
                    public void runSetCMDlet(string PSPath, string usr, string tst, string OutPath)
                    {
                       System.Collections.ObjectModel.Collection&lt;PSObject&gt; outPUT = new System.Collections.ObjectModel.Collection&lt;PSObject&gt;();
                       powershell = PowerShell.Create();
                       powershell.Runspace = runspace;
                       System.IO.StreamReader sr = new System.IO.StreamReader(PSPath);
                       powershell.AddScript(sr.ReadToEnd());
                       powershell.Runspace.SessionStateProxy.SetVariable(&quot;usr&quot;, usr);
                       powershell.Runspace.SessionStateProxy.SetVariable(&quot;tst&quot;, tst);
                       powershell.Runspace.SessionStateProxy.SetVariable(&quot;outPath&quot;, OutPath);
                       outPUT = powershell.Invoke();
                       sr.Close();
                     }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoNormal">You may contact me for any further details thru blog:<span style="">
</span></p>
<p class="MsoNormal"><span style="">&nbsp;</span><a href="http://blogs.technet.com/b/sukum/archive/2013/01/23/coming-soon-office-365-delegates-tool.aspx">http://blogs.technet.com/b/sukum/archive/2013/01/23/coming-soon-office-365-delegates-tool.aspx</a></p>
<p class="MsoNormal" style="">For more details on EWS Managed API, refer</p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/exchange/dd633709(v=exchg.80).aspx">http://msdn.microsoft.com/en-us/library/exchange/dd633709(v=exchg.80).aspx</a></p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

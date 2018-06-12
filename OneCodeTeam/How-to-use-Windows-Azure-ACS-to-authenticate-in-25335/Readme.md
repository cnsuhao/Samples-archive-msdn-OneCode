# How to use Windows Azure ACS to authenticate in WPF application
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
* Access Control Service (ACS)
## Topics
* Azure
## IsPublished
* True
## ModifiedDate
* 2013-10-15 08:25:58
## Description

<h1><span lang="EN-US">Use Windows Azure Access Control Service with WPF and WCF web service (VBAzureACSAuthInWPF)</span></h1>
<h2><span lang="EN-US">Introduction</span></h2>
<p class="MsoNormal"><span lang="EN-US">Windows Azure Access Control Service integrates WIF, so ASP.NET developers can easily create Claims-Aware Application by Identity and Access extension. But for C/S application, developers can't add STS reference to
 their client, it's harder to use ACS with client application and web service.</span></p>
<p class="MsoNormal"><span lang="EN-US">This article and the attached code samples demonstrate how to use Azure ACS work with third part Identity provider such as google, yahoo. You can find the answers for all the following questions in the code sample:</span></p>
<p class="MsoNormal"><a name="OLE_LINK3"></a><a name="OLE_LINK2"><span style=""><span lang="EN-US" style="">How to use third part IDP such as google, yahoo in WPF.
</span></span></a></p>
<p class="MsoNormal"><span style=""><span style=""><span lang="EN-US">How to get RP's claims information in WPF client
<span style="">app. </span></span></span></span></p>
<p class="MsoNormal"><span style=""><span style=""><span lang="EN-US">How to desterilize security token provided by google or yahoo.</span></span></span></p>
<p class="MsoNormal"><span style=""><span style=""><span lang="EN-US">How to secure a web service using Windows Azure ACS.</span></span></span></p>
<p class="MsoNormal"><span style=""><span style=""><span lang="EN-US">How to verify SWT issued by the specific realm in Windows Azure ACS.</span></span></span></p>
<h2><span lang="EN-US">Running the Sample</span></h2>
<p class="Normal"><span lang="EN-US">You should do the steps below before running the code sample.</span></p>
<p class="Normal"><span lang="EN-US">Step 1: To configure the REST web service as a relying party</span></p>
<p style="margin-top:0cm; margin-right:0cm; margin-bottom:0cm; margin-left:21.75pt; margin-bottom:.0001pt; text-indent:-17.8pt; line-height:200%; background:white">
<span lang="EN-US" style="font-size:11.0pt; line-height:200%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:#2A2A2A"><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="font-size:11.0pt; line-height:200%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:#2A2A2A">Go to the<span class="apple-converted-space">&nbsp;</span><a href="http://go.microsoft.com/fwlink/p/?LinkID=275081"><span style="color:#03697A">Windows
 Azure Management Portal</span></a>, sign in, and then click<span class="apple-converted-space">&nbsp;</span><strong><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Active Directory</span></strong>.
</span></p>
<p style="margin-top:0cm; margin-right:0cm; margin-bottom:0cm; margin-left:21.75pt; margin-bottom:.0001pt; text-indent:-17.8pt; line-height:200%; background:white">
<span lang="EN-US" style="font-size:11.0pt; line-height:200%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:#2A2A2A"><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="font-size:11.0pt; line-height:200%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:#2A2A2A">To manage an Access Control namespace, select the namespace, and then click<span class="apple-converted-space">&nbsp;</span><strong><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Manage</span></strong>.
 (Or, click<span class="apple-converted-space">&nbsp;</span><strong><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Access Control Namespaces</span></strong>, select the namespace, and then click<span class="apple-converted-space">&nbsp;</span><strong><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Manage</span></strong>.)
</span></p>
<p style="margin-top:0cm; margin-right:0cm; margin-bottom:0cm; margin-left:21.75pt; margin-bottom:.0001pt; text-indent:-17.8pt; line-height:200%; background:white">
<span lang="EN-US" style="font-size:11.0pt; line-height:200%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:#2A2A2A"><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="font-size:11.0pt; line-height:200%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:#2A2A2A">In the<span class="apple-converted-space">&nbsp;</span><strong><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Trust Relationships</span></strong><span class="apple-converted-space">&nbsp;</span>section,
 click<span class="apple-converted-space">&nbsp;</span><strong><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Relying Party Applications</span></strong>.
</span></p>
<p style="margin-top:0cm; margin-right:0cm; margin-bottom:0cm; margin-left:21.75pt; margin-bottom:.0001pt; text-indent:-17.8pt; line-height:200%; background:white">
<span lang="EN-US" style="font-size:11.0pt; line-height:200%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:#2A2A2A"><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="font-size:11.0pt; line-height:200%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:#2A2A2A">On the<span class="apple-converted-space">&nbsp;</span><strong><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Relying Party
 Applications</span></strong><span class="apple-converted-space">&nbsp;</span>page, click<span class="apple-converted-space">&nbsp;</span><strong><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Add link</span></strong>. The<span class="apple-converted-space">&nbsp;</span><strong><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Add
 Relying Party Application </span></strong>page opens. </span></p>
<p style="margin-top:0cm; margin-right:0cm; margin-bottom:0cm; margin-left:21.75pt; margin-bottom:.0001pt; text-indent:-17.8pt; background:white">
<span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:#2A2A2A"><span style="">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:#2A2A2A">In the<span class="apple-converted-space">&nbsp;</span><strong><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Relying Party Application Settings</span></strong><span class="apple-converted-space">&nbsp;</span>section,
 make the following selections: </span></p>
<p class="MsoNormal" style="margin-bottom:12.0pt; margin-left:21.95pt; text-indent:5.0pt; line-height:normal; background:white">
<span lang="EN-US" style="font-size:10.0pt; font-family:&quot;Courier New&quot;"><span style="">o<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;
</span></span></span><strong><span lang="EN-US" style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Name</span></strong><span lang="EN-US" style="">—Specify a display name for this relying party, for example,<span class="apple-converted-space">&nbsp;</span></span><span lang="EN-US">VBAzureACSAuthInWPF</span><span lang="EN-US" style="">.
</span></p>
<p class="MsoNormal" style="margin-bottom:12.0pt; margin-left:21.95pt; text-indent:5.0pt; line-height:normal; background:white">
<span lang="EN-US" style="font-size:10.0pt; font-family:&quot;Courier New&quot;"><span style="">o<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;
</span></span></span><strong><span lang="EN-US" style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Mode</span></strong><span lang="EN-US" style="">—Select the<span class="apple-converted-space">&nbsp;</span><strong><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Enter
 settings manually</span></strong><span class="apple-converted-space">&nbsp;</span>option.
</span></p>
<p class="MsoNormal" style="margin-bottom:12.0pt; margin-left:21.95pt; text-indent:5.0pt; line-height:normal; background:white">
<strong><span lang="EN-US" style="font-size:10.0pt; font-family:&quot;Courier New&quot;; font-weight:normal"><span style="">o<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;
</span></span></span></strong><strong><span lang="EN-US" style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Realm</span></strong><span lang="EN-US" style="">—Specify the realm of your WCF service, for example,<span class="apple-converted-space">&nbsp;</span></span><span lang="EN-US" style="background:white"><a href="http://localhost:12526/RESTUserService.svc">http://localhost:12526/RESTUserService.svc</a></span><strong><span lang="EN-US" style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">.
</span></strong><strong><span lang="EN-US" style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal"></span></strong></p>
<p class="MsoNormal" style="margin-bottom:12.0pt; margin-left:21.95pt; text-indent:5.0pt; line-height:normal; background:white">
<span lang="EN-US" style="font-size:10.0pt; font-family:&quot;Courier New&quot;"><span style="">o<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;
</span></span></span><strong><span lang="EN-US" style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Return URL</span></strong><span lang="EN-US" style="">—Leave blank.</span></p>
<p class="MsoNormal" style="margin-bottom:12.0pt; margin-left:21.95pt; text-indent:5.0pt; line-height:normal; background:white">
<span lang="EN-US" style="font-size:10.0pt; font-family:&quot;Courier New&quot;"><span style="">o<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;
</span></span></span><strong><span lang="EN-US" style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Error URL</span></strong><span lang="EN-US" style="">—Leave blank.
</span></p>
<p class="MsoNormal" style="margin-bottom:12.0pt; margin-left:21.95pt; text-indent:5.0pt; line-height:normal; background:white">
<span lang="EN-US" style="font-size:10.0pt; font-family:&quot;Courier New&quot;"><span style="">o<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;
</span></span></span><strong><span lang="EN-US" style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Token format</span></strong><span lang="EN-US" style="">—Select the<span class="apple-converted-space">&nbsp;</span><strong><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">SWT</span></strong><span class="apple-converted-space">&nbsp;</span>option.
</span></p>
<p class="MsoNormal" style="margin-bottom:12.0pt; margin-left:21.95pt; text-indent:5.0pt; line-height:normal; background:white">
<span lang="EN-US" style="font-size:10.0pt; font-family:&quot;Courier New&quot;"><span style="">o<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;
</span></span></span><strong><span lang="EN-US" style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Token lifetime (secs)</span></strong><span lang="EN-US" style="">—Leave the default of 600 seconds.
</span></p>
<p style="margin-top:0cm; margin-right:0cm; margin-bottom:0cm; margin-left:21.75pt; margin-bottom:.0001pt; text-indent:-17.8pt; background:white">
<span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">In the<span class="apple-converted-space">&nbsp;</span><strong><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Authentication Settings</span></strong><span class="apple-converted-space">&nbsp;</span>section,
 make the following selections: </span></p>
<p class="MsoNormal" style="margin-bottom:12.0pt; margin-left:21.95pt; text-indent:5.0pt; line-height:normal; background:white">
<span lang="EN-US" style="font-size:10.0pt; font-family:&quot;Courier New&quot;"><span style="">o<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;
</span></span></span><strong><span lang="EN-US" style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Identity providers</span></strong><span lang="EN-US" style="">—checke google and yahoo.
</span></p>
<p class="MsoNormal" style="margin-bottom:12.0pt; margin-left:21.95pt; text-indent:5.0pt; line-height:normal; background:white">
<span lang="EN-US" style="font-size:10.0pt; font-family:&quot;Courier New&quot;"><span style="">o<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;
</span></span></span><strong><span lang="EN-US" style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Rule groups</span></strong><span lang="EN-US" style="">—Select the<span class="apple-converted-space">&nbsp;</span><strong><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Create
 New Rule Group</span></strong><span class="apple-converted-space">&nbsp;</span>option.
</span></p>
<p style="margin-top:0cm; margin-right:0cm; margin-bottom:0cm; margin-left:21.75pt; margin-bottom:.0001pt; text-indent:-17.8pt; background:white">
<span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">7.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">In the<span class="apple-converted-space">&nbsp;</span><strong><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Token Signing Settings</span></strong><span class="apple-converted-space">&nbsp;</span>section,
 make the following selections: </span></p>
<p class="MsoNormal" style="margin-bottom:12.0pt; margin-left:21.95pt; text-indent:5.0pt; line-height:normal; background:white">
<span lang="EN-US" style="font-size:10.0pt; font-family:&quot;Courier New&quot;"><span style="">o<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;
</span></span></span><strong><span lang="EN-US" style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Token signing</span></strong><span lang="EN-US" style="">—Select the<span class="apple-converted-space">&nbsp;</span><strong><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Use
 a dedicated certificate</span></strong><span class="apple-converted-space">&nbsp;</span>option.
</span></p>
<p class="MsoNormal" style="margin-bottom:12.0pt; margin-left:21.95pt; text-indent:5.0pt; line-height:normal; background:white">
<span lang="EN-US" style="font-size:10.0pt; font-family:&quot;Courier New&quot;"><span style="">o<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;
</span></span></span><strong><span lang="EN-US" style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Token signing key</span></strong><span lang="EN-US" style="">—To generate 256–bit symmetric key, click<span class="apple-converted-space">&nbsp;</span><strong><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Generate</span></strong>.
</span></p>
<p class="MsoNormal" style="margin-bottom:12.0pt; margin-left:21.95pt; text-indent:5.0pt; line-height:normal; background:white">
<span lang="EN-US" style="font-size:10.0pt; font-family:&quot;Courier New&quot;"><span style="">o<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;
</span></span></span><strong><span lang="EN-US" style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Effective date</span></strong><span lang="EN-US" style="">—specify the key's effective date.
</span></p>
<p class="MsoNormal" style="margin-bottom:12.0pt; margin-left:21.95pt; text-indent:5.0pt; line-height:normal; background:white">
<span lang="EN-US" style="font-size:10.0pt; font-family:&quot;Courier New&quot;"><span style="">o<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;
</span></span></span><strong><span lang="EN-US" style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Expiration date</span></strong><span lang="EN-US" style="">—specify the key's expiration date.
</span></p>
<p style="margin-top:0cm; margin-right:0cm; margin-bottom:0cm; margin-left:21.75pt; margin-bottom:.0001pt; text-indent:-17.8pt; background:white">
<span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">8.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Click<span class="apple-converted-space">&nbsp;</span><strong><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Save</span></strong>.
</span></p>
<p style=""><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Saving your project will also trigger the creation of a rule group. Now you need to add rules in the rule group.
</span></p>
<p style="margin-top:0cm; margin-right:0cm; margin-bottom:0cm; margin-left:22.0pt; margin-bottom:.0001pt; background:white">
<span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="Normal" style="line-height:normal"><span lang="EN-US">Step 2: Change parameters to your own in below files.</span></p>
<p class="Normal" style="margin-left:36.0pt; text-indent:5.0pt; line-height:normal">
<span lang="EN-US" style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">VBAzureACSAuthInWPF\ Application.xaml.vb file.</span></p>
<p class="Normal" style="margin-left:36.0pt; text-indent:5.0pt; line-height:normal">
<span lang="EN-US" style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US">SecurityModule\ SWTModule.vb.</span></p>
<h2><span lang="EN-US">Using the Code</span></h2>
<p class="MsoNormal"><span lang="EN-US">The code sample provides the following functions to resolve the questions above.
</span></p>
<h3><span lang="EN-US">How to use third part IDP such as google, yahoo in WPF.</span></h3>
<p class="Normal" style=""><span lang="EN-US"></span></p>
<p class="Normal" style=""><span lang="EN-US"></span></p>
<p class="Normal" style=""><span lang="EN-US"></span></p>
<p class="Normal" style=""><span lang="EN-US"></span></p>
<p class="MsoNormal" style=""><span lang="EN-US"><a href="http://msdn.microsoft.com/en-us/library/windowsazure/hh289317.aspx">http://msdn.microsoft.com/en-us/library/windowsazure/hh289317.aspx</a></span></p>
<p class="MsoNormal" style=""><span lang="EN-US"></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

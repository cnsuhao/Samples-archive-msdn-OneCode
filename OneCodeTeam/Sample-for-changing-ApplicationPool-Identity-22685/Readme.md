# Sample for changing ApplicationPool Identity
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* ApplicationPool
## IsPublished
* True
## ModifiedDate
* 2013-07-03 11:44:36
## Description

<h1><span lang="EN-US">Change AppPool identity programmatically (VBAzureChangeAppPoolIdentity)</span></h1>
<h2><span lang="EN-US">Introduction</span></h2>
<p class="MsoNormal"><span lang="EN-US" style="font-size:8.0pt; line-height:115%; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:#384B38">&#8203;</span><span lang="EN-US">Most of customers test their applications to connect to cloud entities like storage, SQL Azure,
 AppFabric services via compute emulator environment. If the customer's machine is behind proxy that does not allow traffic from non-authenticated users, their connections fail. One of the workaround is to change the application identity. This cannot be done
 manually for Azure scenario since the app pool is created by Azure when it is actually running the service. Hence, I have written sample customers can use to change the AppPool identity programmatically.</span></p>
<p class="MsoNormal" align="right" style="text-align:right"><span lang="EN-US"><a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420"><span style="color:windowtext; text-decoration:none"><span style=""><img src="/site/view/file/91718/1/image.png" alt="" width="120" height="90" align="middle">
</span></span></a><br>
<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420">Try Windows Azure for free for 90 Days!</a></span></p>
<h2><span lang="EN-US">Building the Sample</span></h2>
<p class="MsoNormal"><span lang="EN-US">This sample needs to be configured with sitename, domain user/password, before running it.</span></p>
<p class="MsoNormal"><span lang="EN-US" style="">Under OnStart() Method, you will find three variables as mentioned below. These three variables needs to be configured by user before running the sample.</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span lang="EN-US" style="font-size:9.5pt; font-family:Consolas; color:green"></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span lang="EN-US" style="color:black">For non – Azure scenarios, one additional step is needed. Under OnStart() method , locate below line of code.
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span lang="EN-US" style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span lang="EN-US" style="color:black"></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span lang="EN-US" style="color:black">And change the above line to </span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span lang="EN-US" style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span lang="EN-US" style="color:black"></span></p>
<p class="MsoNormal" style=""><span lang="EN-US">Configure the variables as mentioned in the &quot;Building the sample&quot; section and then run the sample by clicking F5 in VS or build the sample and run the exe. Once you confirm that the sample is working,
 take the code from OnStart() method and incorporate with actual application.</span></p>
<p class="MsoNormal" style=""><span lang="EN-US">Add references to Microsoft.Web.Administration (location: &lt;systemdrive&gt;\system32\inetsrv), System.DirectoryServices (Location: .Net framework installation directory) assemblies and add below using statements
 to your project.</span><span lang="EN-US" style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">
</span></p>
<p class="MsoNormal" style=""><span lang="EN-US"></span></p>
<p class="MsoNormal" style=""><span lang="EN-US">Code that gets AppPool using given parameters and changes its identity to configured user.</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span lang="EN-US" style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style=""><span lang="EN-US"></span></p>
<p class="MsoNormal" style=""><span lang="EN-US">For more information on AppPoolIdentityTypes refer to
</span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span lang="EN-US" style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US"><a href="http://www.microsoft.com/technet/prodtechnol/WindowsServer2003/Library/IIS/e3a60d16-1f4d-44a4-9866-5aded450956f.mspx?mfr=true">AppPoolIdentityType Metabase Property (IIS 6.0)</a></span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span lang="EN-US" style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="color:green"><a href="http://learn.iis.net/page.aspx/624/application-pool-identities">Application Pool Identities<span style="">&nbsp;
</span></a><span style="">&nbsp;</span></span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span lang="EN-US" style="font-size:9.5pt; font-family:Consolas; color:green"></span></p>
<p class="MsoNormal" style=""><span lang="EN-US"></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

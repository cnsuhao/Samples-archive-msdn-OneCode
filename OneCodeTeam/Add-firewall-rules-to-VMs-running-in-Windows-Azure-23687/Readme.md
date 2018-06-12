# Add firewall rules to VMs running in Windows Azure
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* Firewall
## IsPublished
* True
## ModifiedDate
* 2013-07-03 11:21:46
## Description

<h1>Add firewall rules to VM's running in Windows <span class="GramE">Azure <span style="">
&nbsp;</span>(</span><span class="SpellE">CSAzureAddFirewallRules</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal" style="margin-bottom:10.0pt; line-height:13.0pt; background:white">
<span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">One of the common asks from developers is the ability to add firewall rules to Windows Azure Compute instances. Startup tasks in Windows Azure can help you add firewall rules.<span style="">&nbsp;
</span>This sample code will add few sample firewall rules to Azure VM's&lt;o:p&gt;.&lt;/o:p&gt;</span></p>
<h2>Building the Sample</h2>
<p class="MsoNormal" style="text-autospace:none"><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black">This sample can be run as-is without making any changes to it.
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Open the sample on the machine where Visual Studio 2012, Windows Azure SDK are installed
</span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">1)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Right click on the cloud service project i.e.
<span class="SpellE">CSAzureAddFirewallRules</span> and choose Publish </span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">2)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Follow the steps in publish Wizard and choose subscription details, deployment slots, etc. and enable remote desktop for all roles
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">3)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">After successful publish, login to Azure VM and verify that 3 inbound firewall rules are added. You can use &quot;Windows Firewall
<span class="GramE">With</span> Advanced Security&quot; program to verify the firewall rules.
</span></p>
<h2>Using the Code</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in; background:white">
<span style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;"><span style="">1)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Create firewallrules.cmd file with below code:</span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-right:-70.65pt; background:white">
<span class="SpellE"><span face="Segoe UI"><span class="GramE"><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">netsh</span></span></span></span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
<span class="SpellE">advfirewall</span> firewall add rule name=&quot;ICMPv6&quot;
<span class="SpellE">dir</span>=in action=allow enable=yes protocol=icmpv6 </span>
</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-right:-70.65pt; background:white">
<span class="SpellE"><span class="GramE"><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">netsh</span></span></span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
<span class="SpellE">advfirewall</span> firewall add rule name=&quot;Windows Remote Management (HTTP-In)&quot;
<span class="SpellE">dir</span>=in action=allow service=any enable=yes profile=any
<span class="SpellE">localport</span>=5985 protocol=<span class="SpellE">tcp</span>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-right:-70.65pt; background:white">
<span class="SpellE"><span class="GramE"><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">netsh</span></span></span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
<span class="SpellE">advfirewall</span> firewall add rule name=&quot;Allowing <span class="SpellE">
Interal</span> Service Traffic&quot;<span style="">&nbsp; </span><span class="SpellE">dir</span>=in action=allow
<span class="SpellE">localport</span>=444 protocol=<span class="SpellE">tcp</span>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in; background:white">
<span style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;"><span style="">2)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Add the firewallrules.cmd file to Web Role / Worker role as required.</span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in; background:white">
<span style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;"><span style="">3)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Configure below file properties for firewallrules.cmd
<span class="GramE">file ,</span> so that it will be copied to bin directory.</span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoNormal" style="margin-left:.5in; background:white"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black"><span face="Segoe UI"><span color="#000000">Build
<span class="GramE">Action :</span> Content</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:5.0pt; margin-left:.5in; background:white">
<span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black"><span face="Segoe UI"><span color="#000000">Copy To Output
<span class="GramE">Directory :</span> Copy Always</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoListParagraph" style="text-indent:-.25in; background:white"><span style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;"><span style="">4)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Finally, define startup task in
<span class="SpellE">ServiceDefinition.csdef</span> file by adding following block of configuration under &lt;<span class="SpellE">Webrole</span>&gt; / &lt;<span class="SpellE">WorkerRole</span>&gt; tag</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;Startup&gt;
&nbsp; &lt;Task commandLine=&quot;firewallrules.cmd&quot; executionContext=&quot;elevated&quot; taskType=&quot;simple&quot;&gt;&nbsp; &lt;/Task&gt;
&lt;/Startup&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;Startup&gt;
&nbsp; &lt;Task commandLine=&quot;firewallrules.cmd&quot; executionContext=&quot;elevated&quot; taskType=&quot;simple&quot;&gt;&nbsp; &lt;/Task&gt;
&lt;/Startup&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.25in; background:white"><span style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;"><span style="">5)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Deploy the application to cloud.
</span></p>
<p class="MsoNormal" style=""><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span face="Segoe UI"></span></p>
<p class="MsoNormal" style=""><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormal"><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormal"><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormal"><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
</span>
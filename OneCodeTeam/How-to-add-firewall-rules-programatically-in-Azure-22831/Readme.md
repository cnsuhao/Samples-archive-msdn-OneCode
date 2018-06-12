# How to add firewall rules programatically in Azure
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
* 2013-06-19 10:08:00
## Description

<h1><span lang="EN-US">Add firewall rules to VM's running in Windows Azure<span style="">&nbsp;
</span>(VBAzureAddFirewallRules)</span></h1>
<h2><span lang="EN-US">Introduction</span></h2>
<p class="MsoNormal" style="margin-bottom:10.0pt; line-height:13.0pt; background:white">
<span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">One of the common asks from developers is the ability to add firewall rules to Windows Azure Compute instances. Startup tasks in Windows Azure can help you add firewall rules.<span style="">&nbsp;
</span>This sample code will add few sample firewall rules to Azure VM's. </span>
</p>
<h2><span lang="EN-US">Building the Sample</span></h2>
<p class="MsoNormal" style="text-autospace:none"><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black">This sample can be run as-is without making any changes to it.
</span></p>
<h2><span lang="EN-US">Running the Sample</span></h2>
<p class="MsoNormal"><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Open the sample on the machine where VS 2010, Windows Azure SDK 1.6 are installed
</span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">1)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Right click on the cloud service project i.e. VBAzureAddFirewallRules and choose Publish
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">2)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Follow the steps in publish Wizard and choose subscription details, deployment slots, etc. and enable remote desktop for all roles
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">3)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">After successful publish, login to Azure VM and verify that 3 inbound firewall rules are added. You can use &quot;Windows Firewall With Advanced Security&quot;
 program to verify the firewall rules. </span></p>
<h2><span lang="EN-US">Using the Code</span></h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt; background:white">
<span lang="EN-US" style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;"><span style="">1)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Create firewallrules.cmd file with below code:</span><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-right:-70.65pt; background:white">
<span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span face="Segoe UI">netsh</span> advfirewall firewall add rule name=&quot;ICMPv6&quot; dir=in action=allow enable=yes protocol=icmpv6
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-right:-70.65pt; background:white">
<span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">netsh advfirewall firewall add rule name=&quot;Windows Remote Management (HTTP-In)&quot; dir=in action=allow service=any enable=yes profile=any localport=5985 protocol=tcp
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-right:-70.65pt; background:white">
<span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">netsh advfirewall firewall add rule name=&quot;Allowing Interal Service Traffic&quot;<span style="">&nbsp;
</span>dir=in action=allow localport=444 protocol=tcp </span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt; background:white">
<span lang="EN-US" style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;"><span style="">2)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Add the firewallrules.cmd file to Web Role / Worker role as required.</span><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt; background:white">
<span lang="EN-US" style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;"><span style="">3)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Configure below file properties for
<span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">firewallrules</span>.cmd file , so that it will be copied to bin directory.</span><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoNormal" style="margin-left:36.0pt; background:white"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black"><span face="Segoe UI"><span color="#000000">Build Action : Content</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoNormal" style="margin-top:0cm; margin-right:0cm; margin-bottom:5.0pt; margin-left:36.0pt; background:white">
<span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black"><span face="Segoe UI"><span color="#000000">Copy To Output Directory : Copy Always</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoListParagraph" style="text-indent:5.0pt; background:white"><span lang="EN-US" style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;"><span style="">4)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Finally, define startup task in ServiceDefinition.vbdef file by adding following block of configuration under &lt;Webrole&gt; / &lt;WorkerRole&gt; tag</span></p>
<p class="MsoListParagraph" style="text-indent:5.0pt; background:white"><span lang="EN-US" style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;"><span style="">5)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Deploy the application to cloud.
</span><span lang="EN-US"></span></p>
<p class="MsoNormal" style=""><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span face="Segoe UI"></span></p>
<p class="MsoNormal" style=""><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormal"><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormal"><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormal"><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
</span>
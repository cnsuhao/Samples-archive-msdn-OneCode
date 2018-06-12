# How to add registry entries to Windows Azure VM programatically
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* Registry
* VM
## IsPublished
* True
## ModifiedDate
* 2013-10-23 10:19:00
## Description

<p class="MsoNormal" style="line-height:13.0pt; background:white"><span lang="EN" style="">One of the common asks from developers is the ability to write to registry in Windows Azure. Startup tasks in Windows Azure can help you write to registry.<span style="">&nbsp;
</span>This sample code will add the registry keys to Azure VM's. </span></p>
<p class="MsoNormal" style="text-autospace:none"><span style="color:black">This sample can be run as-is without making any changes to it.
</span></p>
<p class="MsoNormal" style="margin-left:.5in; text-indent:-.25in; text-autospace:none">
<span style="color:black"><span style="">1)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="color:black">Open the sample on the machine where VS 2012, Windows Azure SDK are installed.</span><span style="color:black">
</span></p>
<p class="MsoNormal" style="margin-left:.5in; text-indent:-.25in; text-autospace:none">
<span style="color:black"><span style="">2)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="color:black">Right click on the cloud service project i.e.
<span class="SpellE">VBAzureAddRegistryKeysToVMs</span> and choose Publish. </span>
</p>
<p class="MsoNormal" style="margin-left:.5in; text-indent:-.25in; text-autospace:none">
<span style="color:black"><span style="">3)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="color:black">Follow the steps in publish Wizard and choose subscription details, deployment slots, etc. and enable remote desktop for all roles.
</span></p>
<p class="MsoNormal" style="margin-left:.5in; text-indent:-.25in; text-autospace:none">
<span style="color:black"><span style="">4)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="color:black">After successful publish, login to Azure VM and verify that 3 registry keys(One for string, One for binary value, One for DWORD value) are created under
</span><span lang="EN" style="color:black">HKEY_LOCAL_MACHINE\System\Test\Test1</span><span style="color:black">
</span></p>
<p class="MsoListParagraph" style="text-indent:-.25in; background:white"><span style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;"><span style="">1)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="">Create sample.reg file with required registry entries. For testing purposes, I'm using sample.reg file with below entries</span>.
<span style="">In real world scenarios, you can create the registry file simply by exporting the section of registry settings you would like to add to Azure VM's.
</span></p>
<p class="MsoNormal" style="margin-left:.5in; background:white"><span lang="EN" style=""><span face="Segoe UI">This sample file adds values settings named &quot;New Binary Setting&quot;, &quot;New DWORD Setting&quot;, &quot;New String Setting&quot; and configures
 with above specified values</span>. </span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in; background:white">
<span style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;"><span style="">2)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="">Add the sample.reg file to web role / worker role project as required.</span><span style="font-size:12.0pt; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;">
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in; background:white">
<span style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;"><span style="">3)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="">Configure below file properties for sample.reg file , so that it will be copied to bin directory.</span>
</p>
<p class="MsoNormal" style="margin-left:.5in; background:white"><span lang="EN" style="color:black"><span face="Segoe UI"><span color="#000000">Build Action : Content</span></span></span><span lang="EN" style="">
</span></p>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:5.0pt; margin-left:.5in; background:white">
<span lang="EN" style="color:black"><span face="Segoe UI"><span color="#000000">Copy To Output Directory : Copy Always</span></span></span><span lang="EN" style="">
</span></p>
<p class="MsoListParagraph" style="text-indent:-.25in; background:white"><span style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;"><span style="">4)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="">Create addreg.cmd file with below code.</span><span style="font-size:12.0pt; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;">
</span></p>
<p class="MsoNormal" style="margin-left:.5in; background:white"><span lang="EN" style=""><span face="Segoe UI">regedit</span> /s sample.reg
<br>
exit /b 0</span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in; background:white">
<span style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;"><span style="">5)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="">Add the addreg.cmd file to Web Role / Worker role as required.</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in; background:white">
<span style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;"><span style="">6)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="">Configure below file properties for addreg.cmd file, so that it will be copied to bin directory.</span>
</p>
<p class="MsoNormal" style="margin-left:.5in; background:white"><span lang="EN" style="color:black"><span face="Segoe UI"><span color="#000000">Build Action : Content</span></span></span><span lang="EN" style="">
</span></p>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:5.0pt; margin-left:.5in; background:white">
<span lang="EN" style="color:black"><span face="Segoe UI"><span color="#000000">Copy To Output Directory : Copy Always</span></span></span><span lang="EN" style="">
</span></p>
<p class="MsoListParagraph" style="text-indent:-.25in; background:white"><span style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;"><span style="">7)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="">Finally, define startup task in ServiceDefinition.csdef file by adding following block of configuration under &lt;Webrole&gt; / &lt;WorkerRole&gt; tag</span><span style="font-size:12.0pt; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;Startup&gt;  
  &lt;Task commandLine=&quot;addreg.cmd&quot; executionContext=&quot;elevated&quot; taskType=&quot;simple&quot;&gt;  &lt;/Task&gt;  
&lt;/Startup&gt; 

</pre>
<pre id="codePreview" class="xml">
&lt;Startup&gt;  
  &lt;Task commandLine=&quot;addreg.cmd&quot; executionContext=&quot;elevated&quot; taskType=&quot;simple&quot;&gt;  &lt;/Task&gt;  
&lt;/Startup&gt; 

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="background:white"><span style="font-size:12.0pt; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;"></span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in; background:white">
<span style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;"><span style="">8)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="">Deploy the application to cloud and you should have &quot;New Binary Setting&quot;, &quot;New DWORD Setting&quot;, &quot;New String Setting&quot; under HKEY_LOCAL_MACHINE\System\Test\Test1 path.</span></p>
<p class="MsoNormal" style="background:white"><span style="font-size:12.0pt; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;"></span></p>
<p class="MsoNormal" style=""><span lang="EN" style=""><a href="http://en.wikipedia.org/wiki/.reg">Below articles gives you additional details regarding adding, modifying, deleting registry sub keys, .<span class="SpellE">reg</span> file syntax</a>
</span><span style=""></span></p>
<p class="MsoNormal" style="background:white"><span lang="EN" style="color:black"><a href="http://support.microsoft.com/kb/310516">How to add, modify, or delete registry
<span class="SpellE">subkeys</span> and values by using a registration entries (.<span class="SpellE">reg</span>) file</a>
</span></p>
<p class="MsoNormal" style="background:white"><span lang="EN" style="">Note: If you want to verify that settings are added properly, enable remote desktop connection and connect to VM to verify the settings. Below article can help you enable remote desktop
 option to your Windows Azure VM's</span> </p>
<p class="MsoNormal" style="background:white"><span lang="EN" style="color:black"><span face="Segoe UI"><a href="http://blogs.msdn.com/b/narahari/archive/2010/12/01/how-to-connect-to-vm-on-windows-azure.aspx"><span color="#000000">How to connect to VM using
 Remote <span class="GramE">Desktop(</span>RDP) on Windows Azure (Cloud)</a></span>
</span></p>
<p class="MsoNormal" style=""><span lang="EN" style="color:black"></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
</span>
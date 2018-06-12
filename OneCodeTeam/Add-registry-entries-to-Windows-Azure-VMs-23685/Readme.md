# Add registry entries to Windows Azure VM’s programatically
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
* 2013-07-03 11:17:05
## Description

<h1>Add registry entries to VM's running in Windows Azure (<span class="SpellE">CSAzureAddRegistryKeysToVMs</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal" style="margin-bottom:10.0pt; line-height:13.0pt; background:white">
<span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">One of the common asks from developers is the ability to write to registry in Windows Azure. Startup tasks in Windows Azure can help you write to registry.<span style="">&nbsp;
</span>This sample code will add the registry keys to Azure VM's. </span></p>
<h2>Building the Sample</h2>
<p class="MsoNormal" style="text-autospace:none"><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black">This sample can be run as-is without making any changes to it.
</span></p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">2)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Right click on the cloud service project i.e.
<span class="SpellE">CSAzureAddRegistryKeysToVMs</span> and choose Publish. </span>
</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">3)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Follow the steps in publish Wizard and choose subscription details, deployment slots, etc. and enable remote desktop for all roles.
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">4)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">After successful publish, login to Azure VM and verify that 3 registry keys(One for string, One for binary value, One for DWORD value) are created under
</span><code><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">HKEY_LOCAL_MACHINE\System\Test\Test1</span></code><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoNormal"><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<h2>Using the Code</h2>
<p class="MsoListParagraph" style="text-indent:-.25in; background:white"><span style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;"><span style="">1)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Create sample.reg file with required registry entries. For testing purposes, I'm using sample.reg file with below entries</span>.
<span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">In real world scenarios, you can create the registry file simply by exporting the section of registry settings you would like to add to Azure VM's.
</span></p>
<p class="MsoNormal" style="margin-left:.5in; background:white"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span face="Segoe UI">This sample file adds values settings named &quot;New Binary Setting&quot;, &quot;New DWORD
 Setting&quot;, &quot;New String Setting&quot; and configures with above specified values</span>.
</span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in; background:white">
<span style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;"><span style="">2)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Add the sample.reg file to web role / worker role project as required.</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in; background:white">
<span style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;"><span style="">3)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Configure below file properties for sample.reg
<span class="GramE">file ,</span> so that it will be copied to bin directory.</span>
</p>
<p class="MsoNormal" style="margin-left:.5in; background:white"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black"><span face="Segoe UI"><span color="#000000">Build
<span class="GramE">Action :</span> Content</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:5.0pt; margin-left:.5in; background:white">
<span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black"><span face="Segoe UI"><span color="#000000">Copy To Output
<span class="GramE">Directory :</span> Copy Always</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoListParagraph" style="text-indent:-.25in; background:white"><span style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;"><span style="">4)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Create addreg.cmd file with below code.</span>
</p>
<p class="MsoNormal" style="margin-left:.5in; background:white"><span class="SpellE"><span face="Segoe UI"><span class="GramE"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">regedit</span></span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
 /s sample.reg <br>
exit /b 0</span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in; background:white">
<span style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;"><span style="">5)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Add the addreg.cmd file to Web Role / Worker role as required.</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in; background:white">
<span style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;"><span style="">6)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Configure below file properties for addreg.cmd file, so that it will be copied to bin directory.</span>
</p>
<p class="MsoNormal" style="margin-left:.5in; background:white"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black"><span face="Segoe UI"><span color="#000000">Build
<span class="GramE">Action :</span> Content</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoNormal" style="margin-top:0in; margin-right:0in; margin-bottom:5.0pt; margin-left:.5in; background:white">
<span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black"><span face="Segoe UI"><span color="#000000">Copy To Output
<span class="GramE">Directory :</span> Copy Always</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoListParagraph" style="text-indent:-.25in; background:white"><span style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;"><span style="">7)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Finally, define startup task in
<span class="SpellE">ServiceDefinition.csdef</span> file by adding following block of configuration under &lt;<span class="SpellE">Webrole</span>&gt; / &lt;<span class="SpellE">WorkerRole</span>&gt; tag</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;Startup&gt;&nbsp; 
&nbsp;&nbsp;&lt;Task commandLine=&quot;addreg.cmd&quot; executionContext=&quot;elevated&quot; taskType=&quot;simple&quot;&gt;&nbsp; &lt;/Task&gt;&nbsp; 
&lt;/Startup&gt; 

</pre>
<pre id="codePreview" class="xml">
&lt;Startup&gt;&nbsp; 
&nbsp;&nbsp;&lt;Task commandLine=&quot;addreg.cmd&quot; executionContext=&quot;elevated&quot; taskType=&quot;simple&quot;&gt;&nbsp; &lt;/Task&gt;&nbsp; 
&lt;/Startup&gt; 

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.25in; background:white"><span style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;"><span style="">8)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Deploy the application to cloud and you should have &quot;New Binary Setting&quot;, &quot;New DWORD Setting&quot;,
<span class="GramE">&quot;</span>New String Setting&quot; under HKEY_LOCAL_MACHINE\System\Test\Test1 path.</span>
</p>
<h2><span face="Segoe UI">More Information</h2>
<p class="MsoNormal"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Below articles gives you additional details regarding adding, modifying, deleting registry sub keys, .<span class="SpellE">reg</span> file syntax
</span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormal"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><a href="http://en.wikipedia.org/wiki/.reg" title="http://en.wikipedia.org/wiki/.reg"><span face="Segoe UI">http://en.wikipedia.org/wiki/.reg</span></a></span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoNormal" style="background:white"><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black"></span></p>
<p class="MsoNormal" style="background:white"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black">How to add, modify, or delete registry
<span class="SpellE">subkeys</span> and values by using a registration entries (.<span class="SpellE">reg</span>) file</span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoNormal" style="margin-bottom:5.0pt; background:white"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><a href="http://support.microsoft.com/kb/310516" style=""><span face="Segoe UI">http://support.microsoft.com/kb/310516</span></a>
</span></p>
<p class="MsoNormal" style="background:white"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span face="Segoe UI">Note: If you want to verify that settings are added properly, enable remote desktop connection and connect to
 VM to verify the settings. Below article can help you enable remote desktop option to your Windows Azure VM's</span>
</span></p>
<p class="MsoNormal" style="background:white"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black"><span face="Segoe UI"><span color="#000000">How to connect to VM using Remote
<span class="GramE">Desktop(</span>RDP) on Windows Azure (Cloud)</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoNormal" style="margin-bottom:7.5pt; background:white"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><a href="http://blogs.msdn.com/b/narahari/archive/2010/12/01/how-to-connect-to-vm-on-windows-azure.aspx" title="http://blogs.msdn.com/b/narahari/archive/2010/12/01/how-to-connect-to-vm-on-windows-azure.aspx" style=""><span face="Segoe UI">http://blogs.msdn.com/b/narahari/archive/2010/12/01/how-to-connect-to-vm-on-windows-azure.aspx</span></a>
</span></p>
<p class="MsoNormal" style=""><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">&nbsp;</span>
</span></p>
<p class="MsoNormal" style=""><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormal"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormal"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormal"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

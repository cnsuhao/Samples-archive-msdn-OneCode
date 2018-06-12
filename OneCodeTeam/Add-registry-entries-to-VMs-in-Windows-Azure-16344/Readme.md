# Add registry entries to VMs in Windows Azure (CSAzureAddRegistryKeysToVMs)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* Registry Key
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:27:19
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<h1>Add registry entries to VM&rsquo;s running in Windows Azure (CSAzureAddRegistryKeysToVMs)</h1>
<h2>Introduction</h2>
<p>One of the common asks from developers is the ability to write to registry in Windows Azure. Startup tasks in Windows Azure can help you write to registry.&nbsp; This sample code will add the registry keys to Azure VM's.</p>
<div align="right">
<p><a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420"><span style="color:windowtext; text-decoration:none"><span><img src="http://code.msdn.microsoft.com/site/view/file/67654/1/image.png" alt="" width="120" height="90" align="middle">
</span></span></a><br>
<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420">Try Windows Azure for free for 90 Days!</a></p>
</div>
<h2>Building the Sample</h2>
<p>This sample can be run as-is without making any changes to it.</p>
<h2>Running the Sample</h2>
<p>Open the sample on the machine where VS 2010, Windows Azure SDK 1.6 are installed.</p>
<p>Right click on the cloud service project i.e. CSAzureAddRegistryKeysToVMs and choose Publish.</p>
<p>Follow the steps in publish Wizard and choose subscription details, deployment slots, etc. and enable remote desktop for all roles.</p>
<p>After successful publish, login to Azure VM and verify that 3 registry keys(One for string, One for binary value, One for DWORD value) are created under HKEY_LOCAL_MACHINE\System\Test\Test1</p>
<h2>Using the Code</h2>
<p>1) Create sample.reg file with required registry entries. For testing purposes, I&rsquo;m using sample.reg file with below entries. In real world scenarios, you can create the registry file simply by exporting the section of registry settings you would like
 to add to Azure VM&rsquo;s.<br>
&nbsp;<br>
&nbsp;Windows Registry Editor Version 5.00 <br>
&nbsp;[HKEY_LOCAL_MACHINE\System\Test\Test1] <br>
&nbsp;&quot;New Binary Setting&quot;=hex:42,69,6e,61,72,79,20,56,61,6c,75,65 <br>
&nbsp;&quot;New DWORD Setting&quot;=dword:00000001 <br>
&nbsp;&quot;New String Setting&quot;=&quot;Something&quot;</p>
<p>This sample file adds values settings named &ldquo;New Binary Setting&rdquo;, &ldquo;New DWORD Setting&rdquo;, &ldquo;New String Setting&rdquo; and configures with above specified values.<br>
&nbsp;<br>
2) Add the sample.reg file to web role / worker role project as required.</p>
<p>3)&nbsp;Configure below file properties for sample.reg file , so that it will be copied to bin directory.</p>
<p>Build Action : Content&nbsp;<br>
Copy To Output Directory : Copy Always<br>
&nbsp;<br>
4)&nbsp;Create addreg.cmd file with below code.<br>
&nbsp;<br>
regedit /s sample.reg <br>
exit /b 0<br>
&nbsp;<br>
5) Add the addreg.cmd file to Web Role / Worker role as required.</p>
<p>6)&nbsp;Configure below file properties for addreg.cmd file, so that it will be copied to bin directory.<br>
&nbsp;<br>
Build Action : Content&nbsp;<br>
Copy To Output Directory : Copy Always<br>
&nbsp;<br>
7)&nbsp;Finally, define startup task in ServiceDefinition.csdef file by adding following block of configuration under &lt;Webrole&gt; / &lt;WorkerRole&gt; tag</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;Startup&gt;  
  &lt;Task commandLine=&quot;addreg.cmd&quot; executionContext=&quot;elevated&quot; taskType=&quot;simple&quot;&gt;  &lt;/Task&gt;  
&lt;/Startup&gt; 
</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;Startup</span><span class="xml__tag_start">&gt;&nbsp;</span><span class="xml__tag_start">&lt;Task</span><span class="xml__attr_name">commandLine</span>=<span class="xml__attr_value">&quot;addreg.cmd&quot;</span><span class="xml__attr_name">executionContext</span>=<span class="xml__attr_value">&quot;elevated&quot;</span><span class="xml__attr_name">taskType</span>=<span class="xml__attr_value">&quot;simple&quot;</span><span class="xml__tag_start">&gt;&nbsp;</span><span class="xml__tag_end">&lt;/Task&gt;</span><span class="xml__tag_end">&lt;/Startup&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">8) Deploy the application to cloud and you should have &ldquo;New Binary Setting&rdquo;, &ldquo;New DWORD Setting&rdquo;, &ldquo;New String Setting&rdquo; under HKEY_LOCAL_MACHINE\System\Test\Test1 path.</div>
<p>&nbsp;</p>
<h2>More Information</h2>
<p>Below articles gives you additional details regarding adding, modifying, deleting registry sub keys, .reg file syntax
<a href="http://en.wikipedia.org/wiki/.reg">http://en.wikipedia.org/wiki/.reg</a></p>
<p>How to add, modify, or delete registry subkeys and values by using a registration entries (.reg) file
<a href="http://support.microsoft.com/kb/310516">http://support.microsoft.com/kb/310516</a></p>
<p>Note: If you want to verify that settings are added properly, enable remote desktop connection and connect to VM to verify the settings. Below article can help you enable remote desktop option to your Windows Azure VM&rsquo;s</p>
<p>How to connect to VM using Remote Desktop(RDP) on Windows Azure (Cloud)<a href="http://blogs.msdn.com/b/narahari/archive/2010/12/01/how-to-connect-to-vm-on-windows-azure.aspx">http://blogs.msdn.com/b/narahari/archive/2010/12/01/how-to-connect-to-vm-on-windows-azure.aspx</a></p>
<p>&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

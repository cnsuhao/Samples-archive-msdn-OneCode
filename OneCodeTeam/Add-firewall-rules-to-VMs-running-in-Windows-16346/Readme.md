# Add firewall rules to VM’s running in Windows Azure  (CSAzureAddFirewallRules)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Microsoft Azure
## Topics
* Firewall Rules
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:31:04
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<h1>Add firewall rules to VM&rsquo;s running in Windows Azure&nbsp; (CSAzureAddFirewallRules)</h1>
<h2>Introduction</h2>
<p>One of the common asks from developers is the ability to add firewall rules to Windows Azure Compute instances. Startup tasks in Windows Azure can help you add firewall rules.&nbsp; This sample code will add few sample firewall rules to Azure VM's.</p>
<h2>Building the Sample</h2>
<p>This sample can be run as-is without making any changes to it.</p>
<h2>Running the Sample</h2>
<p>Open the sample on the machine where VS 2010, Windows Azure SDK 1.6 are installed</p>
<p>Right click on the cloud service project i.e. CSAzureAddFirewallRules and choose Publish</p>
<p>Follow the steps in publish Wizard and choose subscription details, deployment slots, etc. and enable remote desktop for all roles</p>
<p>After successful publish, login to Azure VM and verify that 3 inbound firewall rules are added. You can use &ldquo;Windows Firewall With Advanced Security&rdquo; program to verify the firewall rules.</p>
<h2>Using the Code</h2>
<p>1) Create firewallrules.cmd file with below code:</p>
<p>netsh advfirewall firewall add rule name=&quot;ICMPv6&quot; dir=in action=allow enable=yes protocol=icmpv6<br>
netsh advfirewall firewall add rule name=&quot;Windows Remote Management (HTTP-In)&quot; dir=in action=allow service=any enable=yes profile=any localport=5985 protocol=tcp<br>
netsh advfirewall firewall add rule name=&quot;Allowing Interal Service Traffic&quot;&nbsp; dir=in action=allow localport=444 protocol=tcp</p>
<p>2) Add the firewallrules.cmd file to Web Role / Worker role as required.</p>
<p>3)&nbsp;Configure below file properties for addreg.cmd file , so that it will be copied to bin directory.</p>
<p>Build Action : Content<br>
Copy To Output Directory : Copy Always</p>
<p>4)&nbsp;Finally, define startup task in ServiceDefinition.csdef file by adding following block of configuration under &lt;Webrole&gt; / &lt;WorkerRole&gt; tag</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;Startup&gt;
  &lt;Task commandLine=&quot;firewallrules.cmd&quot; executionContext=&quot;elevated&quot; taskType=&quot;simple&quot;&gt;  &lt;/Task&gt;
&lt;/Startup&gt;
</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;Startup</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;Task</span>&nbsp;<span class="xml__attr_name">commandLine</span>=<span class="xml__attr_value">&quot;firewallrules.cmd&quot;</span>&nbsp;<span class="xml__attr_name">executionContext</span>=<span class="xml__attr_value">&quot;elevated&quot;</span>&nbsp;<span class="xml__attr_name">taskType</span>=<span class="xml__attr_value">&quot;simple&quot;</span><span class="xml__tag_start">&gt;&nbsp;</span>&nbsp;<span class="xml__tag_end">&lt;/Task&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/Startup&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;5) Deploy the application to cloud.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<p>&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

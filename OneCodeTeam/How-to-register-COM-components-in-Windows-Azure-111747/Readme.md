# How to register COM components in Windows Azure programatically
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
* Cloud
## Topics
* COM
## IsPublished
* True
## ModifiedDate
* 2015-01-19 06:56:00
## Description

<p><strong>&nbsp;</strong><strong style="font-size:10px"><a href="http://blogs.msdn.com/b/onecode"><img src="http://bit.ly/onecodesampletopbanner" alt=""></a></strong></p>
<p>&nbsp;</p>
<h1><strong>Register COM Components in Azure&nbsp;</strong></h1>
<h2><strong>Introduction</strong></h2>
<p>While migrating legacy on-premise applications, one of the common questions from developers is the ability to register COM component in Windows Azure. Startup tasks in Windows Azure can be used to achieve this task. This sample provides steps and demonstrates
 how to register COM component in Windows Azure programmatically.</p>
<h2><strong>Building the Sample</strong></h2>
<p>Copy the dll you want to register in to web role&rsquo;s Bin folder.</p>
<p>Then rename it to MyCOM.dll.</p>
<h2><strong>Running the Sample</strong></h2>
<p>Open the sample on the machine where Visual Studio 2012, Windows Azure SDK 2.0 are installed.</p>
<p>1)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Right click on the cloud service project i.e. CSAzureRegisterCOMComponents and choose Publish.</p>
<p>2)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Follow the steps in publish Wizard and choose subscription details, deployment slots, etc. and enable remote desktop for all roles.</p>
<p>3)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; After successful publish, login to Azure VM and verify whether the COM component is registered successfully.</p>
<h2><strong>Using the Code</strong></h2>
<p>1)&nbsp;&nbsp;&nbsp;&nbsp; Define startup task in ServiceDefinition.csdef file by adding following block of configuration under &lt;Webrole&gt; / &lt;WorkerRole&gt; tag.</p>
<pre><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>XML</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">xml</span><pre class="hidden">&lt;Startup&gt;
     &lt;Task commandLine=&quot;RegDll.cmd&quot; executionContext=&quot;elevated&quot; taskType=&quot;simple&quot; /&gt;
&lt;/Startup&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;Startup</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Task</span>&nbsp;<span class="xml__attr_name">commandLine</span>=<span class="xml__attr_value">&quot;RegDll.cmd&quot;</span>&nbsp;<span class="xml__attr_name">executionContext</span>=<span class="xml__attr_value">&quot;elevated&quot;</span>&nbsp;<span class="xml__attr_name">taskType</span>=<span class="xml__attr_value">&quot;simple&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/Startup&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</pre>
<p>2)&nbsp;&nbsp;&nbsp;&nbsp; Create RegDll.cmd file</p>
<p>3)&nbsp;&nbsp;&nbsp;&nbsp; Add the RegDll.cmd file to Web Role / Worker role bin folder as required.</p>
<p>&nbsp;</p>
<h2><strong>More Information</strong></h2>
<p><a href="http://blogs.msdn.com/b/tomholl/archive/2013/05/15/running-scripts-from-a-windows-azure-role-s-onstart-method.aspx">http://blogs.msdn.com/b/tomholl/archive/2013/05/15/running-scripts-from-a-windows-azure-role-s-onstart-method.aspx</a></p>

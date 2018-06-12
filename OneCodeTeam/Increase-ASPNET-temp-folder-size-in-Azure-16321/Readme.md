# Increase ASP.NET temp folder size in Azure (CSAzureIncreaseTempFolderSize)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* Temp Folder Size
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:28:05
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<h1>Increase the size of Asp.net Temporary folder in Azure (CSAzureIncreaseTempFolderSize)</h1>
<h2>Introduction</h2>
<p>By default the ASP.NET temporary folder size in a Windows Azure web role is limited to 100 MB. This is sufficient for the vast majority of applications, but some applications may require more storage space for temporary files. In particular this will happen
 for very large applications which generate a lot of dynamically generated code, or applications which use controls that make use of the temporary folder such as the standard FileUpload control. If you are encountering the problem of running out of temporary
 folder space you will get error messages such as OutOfMemoryException or &lsquo;There is not enough space on the disk.&rsquo;.</p>
<div align="right">
<p><a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420"><span style="color:windowtext; text-decoration:none"><span><img src="http://code.msdn.microsoft.com/site/view/file/67654/1/image.png" alt="" width="120" height="90" align="middle">
</span></span></a><br>
<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420">Try Windows Azure for free for 90 Days!</a></p>
</div>
<h2>Building the Sample</h2>
<p>This sample can be run as-is without making any changes to it.</p>
<h2>Running the Sample</h2>
<ol>
<li>Open the sample on the machine where VS 2010, Windows Azure SDK 1.6 are installed.
</li><li>Right click on the cloud service project i.e. CSAzureIncreaseTempFolderSize and choose Publish.
</li><li>Follow the steps in publish Wizard and choose subscription details, deployment slots, etc. and enable remote desktop for all roles.
</li><li>After successful publish, login to Windows Azure VM via RDP and verify that IIS is using newly created AspNetTemp1GB for storing temporary files instead of default temporary ASP.net folder.
</li></ol>
<h2>Using the Code</h2>
<p>1) In the ServiceDefinition.csdef create one LocalStorage resource in the Web Role, and set the Runtime&nbsp;executionContext to elevated.&nbsp; The elevated executionContext allows us to use the ServerManager class to modify the IIS configuration during
 role startup.&nbsp;&nbsp;&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;WebRole name=&quot;IncreaseAspnetTempFolderSize&quot; vmsize=&quot;Small&quot;&gt;
  &lt;Runtime executionContext=&quot;elevated&quot; /&gt;
  &lt;Sites&gt;
    &lt;Site name=&quot;Web&quot;&gt;
      &lt;Bindings&gt;
        &lt;Binding name=&quot;Endpoint1&quot; endpointName=&quot;Endpoint1&quot; /&gt;
      &lt;/Bindings&gt;
    &lt;/Site&gt;
  &lt;/Sites&gt;
  &lt;Endpoints&gt;
    &lt;InputEndpoint name=&quot;Endpoint1&quot; protocol=&quot;http&quot; port=&quot;80&quot; /&gt;
  &lt;/Endpoints&gt;
  &lt;LocalResources&gt;
    &lt;LocalStorage name=&quot;AspNetTemp1GB&quot; sizeInMB=&quot;1000&quot; /&gt;
  &lt;/LocalResources&gt;
 
  &lt;Imports&gt;
    &lt;Import moduleName=&quot;Diagnostics&quot; /&gt;
  &lt;/Imports&gt;
&lt;/WebRole&gt;
</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;WebRole</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;IncreaseAspnetTempFolderSize&quot;</span>&nbsp;<span class="xml__attr_name">vmsize</span>=<span class="xml__attr_value">&quot;Small&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;Runtime</span>&nbsp;<span class="xml__attr_name">executionContext</span>=<span class="xml__attr_value">&quot;elevated&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;Sites</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Site</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;Web&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Bindings</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Binding</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;Endpoint1&quot;</span>&nbsp;<span class="xml__attr_name">endpointName</span>=<span class="xml__attr_value">&quot;Endpoint1&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Bindings&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Site&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Sites&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;Endpoints</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;InputEndpoint</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;Endpoint1&quot;</span>&nbsp;<span class="xml__attr_name">protocol</span>=<span class="xml__attr_value">&quot;http&quot;</span>&nbsp;<span class="xml__attr_name">port</span>=<span class="xml__attr_value">&quot;80&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Endpoints&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;LocalResources</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;LocalStorage</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;AspNetTemp1GB&quot;</span>&nbsp;<span class="xml__attr_name">sizeInMB</span>=<span class="xml__attr_value">&quot;1000&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/LocalResources&gt;</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;Imports</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Import</span>&nbsp;<span class="xml__attr_name">moduleName</span>=<span class="xml__attr_value">&quot;Diagnostics&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Imports&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/WebRole&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>2) Add reference to Microsoft.Web.Administration (location: &lt;systemdrive&gt;\system32\inetsrv) assembly and add below using statement to your project</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using Microsoft.Web.Administration;</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;Microsoft.Web.Administration;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;3) Add the following code to the OnStart routine in WebRole.cs.&nbsp; This code configures the Website to point to the AspNetTemp1GB LocalStorage resource.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public override bool OnStart()
{
    // For information on handling configuration changes
    // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.
    
    // Get the location of the AspNetTemp1GB resource     
    Microsoft.WindowsAzure.ServiceRuntime.LocalResource aspNetTempFolder = 
        Microsoft.WindowsAzure.ServiceRuntime.RoleEnvironment.GetLocalResource(&quot;AspNetTemp1GB&quot;);   
    
    //Instantiate the IIS ServerManager     
    ServerManager iisManager = new ServerManager();     
 
    // Get the website.  Note that &quot;_Web&quot; is the name of the site in the ServiceDefinition.csdef, 
    // so make sure you change this code if you change the site name in the .csdef     
    Application app = iisManager.Sites[RoleEnvironment.CurrentRoleInstance.Id &#43; &quot;_Web&quot;].Applications[0];    
 
    // Get the web.config for the site     
    Configuration webHostConfig = app.GetWebConfiguration();     
 
    // Get a reference to the system.web/compilation element     
    ConfigurationSection compilationConfiguration = webHostConfig.GetSection(&quot;system.web/compilation&quot;);  
   
    // Set the tempDirectory property to the AspNetTemp1GB folder     
    compilationConfiguration.Attributes[&quot;tempDirectory&quot;].Value = aspNetTempFolder.RootPath;   
  
    // Commit the changes     
    iisManager.CommitChanges();
 
    return base.OnStart();
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;OnStart()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;For&nbsp;information&nbsp;on&nbsp;handling&nbsp;configuration&nbsp;changes</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;see&nbsp;the&nbsp;MSDN&nbsp;topic&nbsp;at&nbsp;http://go.microsoft.com/fwlink/?LinkId=166357.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Get&nbsp;the&nbsp;location&nbsp;of&nbsp;the&nbsp;AspNetTemp1GB&nbsp;resource&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Microsoft.WindowsAzure.ServiceRuntime.LocalResource&nbsp;aspNetTempFolder&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Microsoft.WindowsAzure.ServiceRuntime.RoleEnvironment.GetLocalResource(<span class="cs__string">&quot;AspNetTemp1GB&quot;</span>);&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Instantiate&nbsp;the&nbsp;IIS&nbsp;ServerManager&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ServerManager&nbsp;iisManager&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ServerManager();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Get&nbsp;the&nbsp;website.&nbsp;&nbsp;Note&nbsp;that&nbsp;&quot;_Web&quot;&nbsp;is&nbsp;the&nbsp;name&nbsp;of&nbsp;the&nbsp;site&nbsp;in&nbsp;the&nbsp;ServiceDefinition.csdef,&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;so&nbsp;make&nbsp;sure&nbsp;you&nbsp;change&nbsp;this&nbsp;code&nbsp;if&nbsp;you&nbsp;change&nbsp;the&nbsp;site&nbsp;name&nbsp;in&nbsp;the&nbsp;.csdef&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Application&nbsp;app&nbsp;=&nbsp;iisManager.Sites[RoleEnvironment.CurrentRoleInstance.Id&nbsp;&#43;&nbsp;<span class="cs__string">&quot;_Web&quot;</span>].Applications[<span class="cs__number">0</span>];&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Get&nbsp;the&nbsp;web.config&nbsp;for&nbsp;the&nbsp;site&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Configuration&nbsp;webHostConfig&nbsp;=&nbsp;app.GetWebConfiguration();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Get&nbsp;a&nbsp;reference&nbsp;to&nbsp;the&nbsp;system.web/compilation&nbsp;element&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ConfigurationSection&nbsp;compilationConfiguration&nbsp;=&nbsp;webHostConfig.GetSection(<span class="cs__string">&quot;system.web/compilation&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Set&nbsp;the&nbsp;tempDirectory&nbsp;property&nbsp;to&nbsp;the&nbsp;AspNetTemp1GB&nbsp;folder&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;compilationConfiguration.Attributes[<span class="cs__string">&quot;tempDirectory&quot;</span>].Value&nbsp;=&nbsp;aspNetTempFolder.RootPath;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Commit&nbsp;the&nbsp;changes&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;iisManager.CommitChanges();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.OnStart();&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<h2>More Information</h2>
<p>For more information about the ASP.NET Temporary Folder see <a href="http://msdn.microsoft.com/en-us/magazine/cc163496.aspx">
http://msdn.microsoft.com/en-us/magazine/cc163496.aspx</a></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
</div>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

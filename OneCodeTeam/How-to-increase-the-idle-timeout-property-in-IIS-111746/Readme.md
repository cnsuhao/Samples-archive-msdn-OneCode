# How to increase the idle timeout property in IIS for Windows Azure applications
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
* Cloud
## Topics
* timeout
## IsPublished
* True
## ModifiedDate
* 2015-01-19 06:39:30
## Description

<p><strong style="font-size:10px"><a href="http://blogs.msdn.com/b/onecode"><img src="http://bit.ly/onecodesampletopbanner" alt=""></a></strong></p>
<h1><strong><strong>Increase application pool idle timeout in windows azure cloud applications
</strong><strong>&nbsp;</strong></strong></h1>
<p><strong></p>
<h2><strong>Introduction</strong></h2>
</strong>
<p>App-pool Idle Time-out is the amount of time (in minutes) a worker process will remain idle before it shuts down. A worker process is idle if it is not processing requests and no new requests are received.&nbsp;&nbsp;</p>
<p>Idle Time-out property can be changed in IIS after you RDP into the VM's of Azure, but this is not recommended and remote desktop must be used only for basic troubleshooting. Any changes done on the Virtual Machine manually after RDP will not be persisted.This
 is because, in the event of any hardware failure or automatic OS upgrade in Azure cloud, Fabric controller will bring down the VM instance and automatically deploy your package on another VM/on the same VM (Virtual machine). If this happens all the changes
 done manually on the VM will be lost. Therefore the recommended approach is to perform all the operation by code and deploy the package.</p>
<p>You can implement this by using ServerManager class defined in Microsoft.Web.Administration DLL.</p>
<strong>
<h2><strong>Running the Sample</strong></h2>
</strong>
<p>You can directly publish this sample to your cloud service.</p>
<strong>
<h2><strong>Using the Code</strong></h2>
</strong>
<p>You can use the code below to achieve this:</p>
<p>&nbsp;</p>
<strong>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.Web.Administration;
using Microsoft.WindowsAzure.Diagnostics.Management;
 
 
namespace WebRole
{
    public class WebRole : RoleEntryPoint
    {
 
        public override bool OnStart()
        {
 
            ServerManager iisManager = new ServerManager();
            Application app = iisManager.Sites[RoleEnvironment.CurrentRoleInstance.Id &#43; &quot;_Web&quot;].Applications[0];
 
            //================ idletimeout ====================================================//               
            string dt = iisManager.ApplicationPoolDefaults.ProcessModel.IdleTimeout.ToString();
            TimeSpan ts = new TimeSpan(0, 60, 00);
            iisManager.ApplicationPoolDefaults.ProcessModel.IdleTimeout = ts;
 
 
 
            //================ Enable or disable static/Dynamic compression ===================//
            Configuration config = iisManager.Sites[RoleEnvironment.CurrentRoleInstance.Id &#43; &quot;_Web&quot;].GetWebConfiguration();
            ConfigurationSection urlCompressionSection = config.GetSection(&quot;system.webServer/urlCompression&quot;);
            urlCompressionSection[&quot;doStaticCompression&quot;] = true;
            urlCompressionSection[&quot;doDynamicCompression&quot;] = true;
 
            //================ To change Application pool name ================================//
 
            app.ApplicationPoolName = &quot;ASP.NET v4.0 Classic&quot;;
            // Commit the changes done to server manager. 
 
            iisManager.CommitChanges();
 
            return base.OnStart();
 
        }
 
    }
 
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.WindowsAzure;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.WindowsAzure.Diagnostics;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.WindowsAzure.ServiceRuntime;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.Web.Administration;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.WindowsAzure.Diagnostics.Management;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;WebRole&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">class</span>&nbsp;WebRole&nbsp;:&nbsp;RoleEntryPoint&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">override</span><span class="cs__keyword">bool</span>&nbsp;OnStart()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ServerManager&nbsp;iisManager&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ServerManager();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Application&nbsp;app&nbsp;=&nbsp;iisManager.Sites[RoleEnvironment.CurrentRoleInstance.Id&nbsp;&#43;&nbsp;<span class="cs__string">&quot;_Web&quot;</span>].Applications[<span class="cs__number">0</span>];&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//================&nbsp;idletimeout&nbsp;====================================================//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="cs__keyword">string</span>&nbsp;dt&nbsp;=&nbsp;iisManager.ApplicationPoolDefaults.ProcessModel.IdleTimeout.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TimeSpan&nbsp;ts&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;TimeSpan(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">60</span>,&nbsp;<span class="cs__number">00</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;iisManager.ApplicationPoolDefaults.ProcessModel.IdleTimeout&nbsp;=&nbsp;ts;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//================&nbsp;Enable&nbsp;or&nbsp;disable&nbsp;static/Dynamic&nbsp;compression&nbsp;===================//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Configuration&nbsp;config&nbsp;=&nbsp;iisManager.Sites[RoleEnvironment.CurrentRoleInstance.Id&nbsp;&#43;&nbsp;<span class="cs__string">&quot;_Web&quot;</span>].GetWebConfiguration();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ConfigurationSection&nbsp;urlCompressionSection&nbsp;=&nbsp;config.GetSection(<span class="cs__string">&quot;system.webServer/urlCompression&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;urlCompressionSection[<span class="cs__string">&quot;doStaticCompression&quot;</span>]&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;urlCompressionSection[<span class="cs__string">&quot;doDynamicCompression&quot;</span>]&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//================&nbsp;To&nbsp;change&nbsp;Application&nbsp;pool&nbsp;name&nbsp;================================//</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.ApplicationPoolName&nbsp;=&nbsp;<span class="cs__string">&quot;ASP.NET&nbsp;v4.0&nbsp;Classic&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Commit&nbsp;the&nbsp;changes&nbsp;done&nbsp;to&nbsp;server&nbsp;manager.&nbsp;</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;iisManager.CommitChanges();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span><span class="cs__keyword">base</span>.OnStart();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h2><strong>More Information</strong></h2>
</strong>
<p><a href="http://blogs.msdn.com/b/sriharsha/archive/2012/04/07/how-to-increase-application-pool-idletimeout-in-windows-azure-cloud-applications.aspx">http://blogs.msdn.com/b/sriharsha/archive/2012/04/07/how-to-increase-application-pool-idletimeout-in-windows-azure-cloud-applications.aspx</a></p>
<p></p>

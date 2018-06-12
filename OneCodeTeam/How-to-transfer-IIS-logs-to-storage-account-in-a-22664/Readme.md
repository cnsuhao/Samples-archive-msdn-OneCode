# How to transfer IIS logs to storage account in a custom format
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* Diagnostics
* IIS
## IsPublished
* True
## ModifiedDate
* 2013-06-13 10:43:48
## Description

<p class="MsoNormal"><span style="">Because any log file transfer to Azure storage are billable, custom log file before transfer will help you save money. This sample will show you how to custom IIS logs in your Azure web role. This is a
</span><span style="">frequently asked </span><span style="">question in forum, so we provide this sample code to show how to achieve this</span><span style=""> in .NET</span><span style="">.
</span></p>
<p class="MsoNormal"><span style="">Please follow these demonstration steps below.
</span></p>
<p class="MsoNormal"><span style="">Step 1: Make sure you </span><span style="">have
</span><span style="">enabled IIS in your computer. </span></p>
<p class="MsoNormal"><span style="">Step 2: Right click your cloud project solution, and choose properties, in your Web tab, choose use IIS Web Server.
</span></p>
<p class="MsoNormal"><span style="">Step 3: Press Ctrl&#43;F5 to show the Default.aspx</span>.<span style="">
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84662/1/image.png" alt="" width="800" height="244" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">Step 4: Don't close the web page, wait one minute and use your server explorer open the latest log file in Windows Azure Storage-&gt; (Development) -&gt;Blobs-&gt;wad-iis-logfiles.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84663/1/image.png" alt="" width="924" height="202" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal">Step 5: You will see some log files.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84664/1/image.png" alt="" width="979" height="117" align="middle">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
//using (ServerManager serverManager = new ServerManager())
//{
//    // Get the website.
//    // First make sure your cloud programe use IIS Web Server not IIS express.
//    // Note that &quot;_Web&quot; is the name of the site in the ServiceDefinition.csdef,
//    // so make sure you change this code if you change the site name in the .csdef
//    Site site = serverManager.Sites[RoleEnvironment.CurrentRoleInstance.Id &#43; &quot;_Web&quot;];
//    site.LogFile.LogExtFileFlags = LogExtFileFlags.Date | LogExtFileFlags.Time 
//        | LogExtFileFlags.ClientIP | LogExtFileFlags.Host | LogExtFileFlags.BytesSent 
//        | LogExtFileFlags.BytesRecv;
//    site.LogFile.Period = LoggingRolloverPeriod.Hourly;
//    serverManager.CommitChanges();
//}

</pre>
<pre id="codePreview" class="csharp">
//using (ServerManager serverManager = new ServerManager())
//{
//    // Get the website.
//    // First make sure your cloud programe use IIS Web Server not IIS express.
//    // Note that &quot;_Web&quot; is the name of the site in the ServiceDefinition.csdef,
//    // so make sure you change this code if you change the site name in the .csdef
//    Site site = serverManager.Sites[RoleEnvironment.CurrentRoleInstance.Id &#43; &quot;_Web&quot;];
//    site.LogFile.LogExtFileFlags = LogExtFileFlags.Date | LogExtFileFlags.Time 
//        | LogExtFileFlags.ClientIP | LogExtFileFlags.Host | LogExtFileFlags.BytesSent 
//        | LogExtFileFlags.BytesRecv;
//    site.LogFile.Period = LoggingRolloverPeriod.Hourly;
//    serverManager.CommitChanges();
//}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="">Step 7: Do the step 3, 4, 5 again, and you will get a simpler log file with less filter parameter.</p>
<p class="MsoNormal" style=""><span style=""><img src="/site/view/file/84665/1/image.png" alt="" width="969" height="172" align="middle">
</span></p>
<p class="MsoNormal" style="">Code Logical:</p>
<p class="MsoNormal" style="">Step 1:<span style="">&nbsp; </span>Create a C# windows cloud service with a web role. Service name is &quot;CSAzureTransferringCustomIISLogs&quot;, and web role name is: &quot;AzureTransferringCustomIISLogs&quot;.</p>
<p class="MsoNormal" style="">Step<span style=""> </span>2:<span style="">&nbsp;
</span><span style="">Right click cloud project solution, and choose properties, in Web tab, choose use IIS Web Server.</span><span style="">
</span></p>
<p class="MsoNormal" style=""><span style="">Step 3:<span style="">&nbsp; </span>
Add Microsoft.Web.Administration.dll from<span style="">&nbsp; </span>C:\Windows\System32\inetsrv\Microsoft.Web.Administration.dll
</span></p>
<p class="MsoNormal" style="">Step<span style=""> 4</span>:<span style="">&nbsp;
</span>Open the WebRole.cs file cover the onstart() with the codes below.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public override bool OnStart()
 {
     // Get this connection string in web role's setting tab
     string storageConnectionString = &quot;Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString&quot;;
     
     // Get default config
     DiagnosticMonitorConfiguration config = DiagnosticMonitor.GetDefaultInitialConfiguration();
     
     // Transfer the IIS and IIS Failed Request Logs
     config.Directories.ScheduledTransferPeriod = TimeSpan.FromMinutes(1.0);


     // Custom diagnostic logging
     //using (ServerManager serverManager = new ServerManager())
     //{
     //    // Get the website.
     //    // First make sure your cloud programe use IIS Web Server not IIS express.
     //    // Note that &quot;_Web&quot; is the name of the site in the ServiceDefinition.csdef,
     //    // so make sure you change this code if you change the site name in the .csdef
     //    Site site = serverManager.Sites[RoleEnvironment.CurrentRoleInstance.Id &#43; &quot;_Web&quot;];
     //    site.LogFile.LogExtFileFlags = LogExtFileFlags.Date | LogExtFileFlags.Time 
     //        | LogExtFileFlags.ClientIP | LogExtFileFlags.Host | LogExtFileFlags.BytesSent 
     //        | LogExtFileFlags.BytesRecv;
     //    site.LogFile.Period = LoggingRolloverPeriod.Hourly;
     //    serverManager.CommitChanges();
     //}


     DiagnosticMonitor.Start(storageConnectionString, config);
     RoleEnvironment.Changing &#43;= RoleEnvironmentChanging;


     return base.OnStart();
 }

</pre>
<pre id="codePreview" class="csharp">
public override bool OnStart()
 {
     // Get this connection string in web role's setting tab
     string storageConnectionString = &quot;Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString&quot;;
     
     // Get default config
     DiagnosticMonitorConfiguration config = DiagnosticMonitor.GetDefaultInitialConfiguration();
     
     // Transfer the IIS and IIS Failed Request Logs
     config.Directories.ScheduledTransferPeriod = TimeSpan.FromMinutes(1.0);


     // Custom diagnostic logging
     //using (ServerManager serverManager = new ServerManager())
     //{
     //    // Get the website.
     //    // First make sure your cloud programe use IIS Web Server not IIS express.
     //    // Note that &quot;_Web&quot; is the name of the site in the ServiceDefinition.csdef,
     //    // so make sure you change this code if you change the site name in the .csdef
     //    Site site = serverManager.Sites[RoleEnvironment.CurrentRoleInstance.Id &#43; &quot;_Web&quot;];
     //    site.LogFile.LogExtFileFlags = LogExtFileFlags.Date | LogExtFileFlags.Time 
     //        | LogExtFileFlags.ClientIP | LogExtFileFlags.Host | LogExtFileFlags.BytesSent 
     //        | LogExtFileFlags.BytesRecv;
     //    site.LogFile.Period = LoggingRolloverPeriod.Hourly;
     //    serverManager.CommitChanges();
     //}


     DiagnosticMonitor.Start(storageConnectionString, config);
     RoleEnvironment.Changing &#43;= RoleEnvironmentChanging;


     return base.OnStart();
 }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="">Step <span style="">5</span>: Then check your cloud project, csdef file, make sure this module have been auto import to your project:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;Imports&gt;
  &lt;Import moduleName=&quot;Diagnostics&quot; /&gt;
&lt;/Imports&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;Imports&gt;
  &lt;Import moduleName=&quot;Diagnostics&quot; /&gt;
&lt;/Imports&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="">Step <span style="">6</span>: Build the application.
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
//using (ServerManager serverManager = new ServerManager())
            //{
            //    // Get the website.
            //    // First make sure your cloud programe use IIS Web Server not IIS express.
            //    // Note that &quot;_Web&quot; is the name of the site in the ServiceDefinition.csdef,
            //    // so make sure you change this code if you change the site name in the .csdef
            //    Site site = serverManager.Sites[RoleEnvironment.CurrentRoleInstance.Id &#43; &quot;_Web&quot;];
            //    site.LogFile.LogExtFileFlags = LogExtFileFlags.Date | LogExtFileFlags.Time 
            //        | LogExtFileFlags.ClientIP | LogExtFileFlags.Host | LogExtFileFlags.BytesSent 
            //        | LogExtFileFlags.BytesRecv;
            //    site.LogFile.Period = LoggingRolloverPeriod.Hourly;
            //    serverManager.CommitChanges();
            //}

</pre>
<pre id="codePreview" class="csharp">
//using (ServerManager serverManager = new ServerManager())
            //{
            //    // Get the website.
            //    // First make sure your cloud programe use IIS Web Server not IIS express.
            //    // Note that &quot;_Web&quot; is the name of the site in the ServiceDefinition.csdef,
            //    // so make sure you change this code if you change the site name in the .csdef
            //    Site site = serverManager.Sites[RoleEnvironment.CurrentRoleInstance.Id &#43; &quot;_Web&quot;];
            //    site.LogFile.LogExtFileFlags = LogExtFileFlags.Date | LogExtFileFlags.Time 
            //        | LogExtFileFlags.ClientIP | LogExtFileFlags.Host | LogExtFileFlags.BytesSent 
            //        | LogExtFileFlags.BytesRecv;
            //    site.LogFile.Period = LoggingRolloverPeriod.Hourly;
            //    serverManager.CommitChanges();
            //}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="">Step <span style="">8</span>: Rebuild the application.</p>
<p style="margin:0in; margin-bottom:.0001pt"><a href="http://msdn.microsoft.com/en-us/library/windowsazure/hh411525.aspx"><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">How to: Store and View Diagnostic Data in Windows Azure Storage</span></a><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoNormal" style=""><a href="http://blogs.msdn.com/b/sriharsha/archive/2012/10/26/how-to-transfer-iis-logs-to-storage-account-in-a-custom-format.aspx"><span style="">How to transfer IIS logs to storage account in a custom format</span></a><span lang="EN" style="">
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

# How to retrieve diagnostics messages in Windows Azure storage
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* Diagnostics
## IsPublished
* True
## ModifiedDate
* 2013-10-23 08:22:31
## Description

<h1>Transfer diagnostics messages and retrieve them from Azure storage (CSAzureRetrieveDiagnosticsMessages)</h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span style="">This sample will show you how to retrieve diagnostics message and transfer them to Azure storage. And also it will show you how to view both logs in Table and logs in blob.</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow these demonstration steps below.
</span></p>
<p class="MsoNormal"><span style="">Step 1: Open the Cloud solution property chose the Web tab and select use IIS web server.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/100251/1/image.png" alt="" width="576" height="144" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">Step 2: </span>Press Ctrl&#43;F5 to show the Default.aspx.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/100252/1/image.png" alt="" width="576" height="46" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal">Step 3: Click the first one; you will get your developer storage blob structure.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/100253/1/image.png" alt="" width="576" height="210" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal">Step 4: Then click the leaf node; you will get the file message<span style=""> in a .txt file</span>.<span style="">
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/100254/1/image.png" alt="" width="576" height="428" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal">Step 5: Then go back to the default.aspx choose the second link. You will get a table list.
</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/100255/1/image.png" alt="" width="576" height="210" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal">Step 6: Choose the WADLogsTable, and then you will get the all the
<span class="GramE">tables</span> message.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/100256/1/image.png" alt="" width="576" height="128" align="middle">
</span></p>
<p class="MsoNormal"></p>
<h2>Using the Code</h2>
<p class="MsoNormal">Code Logical:</p>
<p class="MsoNormal">Step 1:<span style="">&nbsp; </span>Create a <span style="">
C#</span> windows cloud service with a web role. Service name is &quot;CSAzureRetrieveDiagnosticsMessages&quot;.</p>
<p class="MsoNormal">Step2:<span style="">&nbsp; </span>Add two classes: WADLogsTable.cs, WADLogsTableDataServiceContext.cs.</p>
<p class="MsoNormal">Step3:<span style="">&nbsp; </span>The WADLogsTable class is a table entity class, WADLogsTableDataServiceContext.cs provides a service for query the table.</p>
<h3>The following code shows how to create a table entity for table in storage.</h3>
<p class="MsoNormal"><b style=""><span style="">WADLogsTable.cs </span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public class WADLogsTable
    : Microsoft.WindowsAzure.StorageClient.TableServiceEntity
{
    public string Message { get; set; }


    public Int64 EventTickCount { get; set; }


    public string DeploymentId { get; set; }


    public string Role { get; set; }


    public string RoleInstance { get; set; }


    public int Level { get; set; }


    public int EventId { get; set; }


    public int Pid { get; set; }


    public int Tid { get; set; }
}

</pre>
<pre id="codePreview" class="csharp">
public class WADLogsTable
    : Microsoft.WindowsAzure.StorageClient.TableServiceEntity
{
    public string Message { get; set; }


    public Int64 EventTickCount { get; set; }


    public string DeploymentId { get; set; }


    public string Role { get; set; }


    public string RoleInstance { get; set; }


    public int Level { get; set; }


    public int EventId { get; set; }


    public int Pid { get; set; }


    public int Tid { get; set; }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<h3>The following code shows how to create a WCF data service.</h3>
<p class="MsoNormal"><b style=""><span style="">WADLogsTableDataServiceContext.cs:
</span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public class WADLogsTableDataServiceContext
    : TableServiceContext
{
    public WADLogsTableDataServiceContext(string baseAddress, StorageCredentials credentials)
        : base(baseAddress, credentials)
    {
    }




    public IQueryable&lt;WADLogsTable&gt; WADLogs
    {
        get
        {
            return this.CreateQuery&lt;WADLogsTable&gt;(&quot;WADLogsTable&quot;);
        }
    }
}

</pre>
<pre id="codePreview" class="csharp">
public class WADLogsTableDataServiceContext
    : TableServiceContext
{
    public WADLogsTableDataServiceContext(string baseAddress, StorageCredentials credentials)
        : base(baseAddress, credentials)
    {
    }




    public IQueryable&lt;WADLogsTable&gt; WADLogs
    {
        get
        {
            return this.CreateQuery&lt;WADLogsTable&gt;(&quot;WADLogsTable&quot;);
        }
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal">Step 4: Open the WebRole.cs file and add below codes to the file.</p>
<h3>The following code showing how to transfer specific log file to the Azure storage.</h3>
<p class="MsoNormal"><b style=""><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">WebRole.cs:</span></b><b style=""><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">
</span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
namespace CSAzureRetrieveDiagnosticsMessages_WebRole
{
    public class WebRole : RoleEntryPoint
    {
        public override bool OnStart()
        {
            DiagnosticMonitorConfiguration config = DiagnosticMonitor.GetDefaultInitialConfiguration();


            // Windows Performance Counters
            List&lt;string&gt; counters = new List&lt;string&gt;();
            counters.Add(@&quot;\Processor(_Total)\% Processor Time&quot;);
            counters.Add(@&quot;\Memory\Available Mbytes&quot;);
            counters.Add(@&quot;\TCPv4\Connections Established&quot;);
            counters.Add(@&quot;\ASP.NET Applications(__Total__)\Requests/Sec&quot;);
            counters.Add(@&quot;\Network Interface(*)\Bytes Received/sec&quot;);
            counters.Add(@&quot;\Network Interface(*)\Bytes Sent/sec&quot;);
            foreach (string counter in counters)
            {
                PerformanceCounterConfiguration counterConfig = new PerformanceCounterConfiguration();
                counterConfig.CounterSpecifier = counter;
                counterConfig.SampleRate = TimeSpan.FromMinutes(5);
                config.PerformanceCounters.DataSources.Add(counterConfig);
            }
            config.PerformanceCounters.ScheduledTransferPeriod = TimeSpan.FromMinutes(5);


            // Windows Event Logs
            // WADWindowsEventLogsTable
            config.WindowsEventLog.DataSources.Add(&quot;System!*&quot;);
            
            // WADLogsTable
            config.WindowsEventLog.DataSources.Add(&quot;Application!*&quot;);
            config.WindowsEventLog.ScheduledTransferPeriod = TimeSpan.FromMinutes(1.0);
            config.WindowsEventLog.ScheduledTransferLogLevelFilter = LogLevel.Verbose;


            // Azure Trace Logs
            config.Logs.ScheduledTransferPeriod = TimeSpan.FromMinutes(1.0);
            config.Logs.ScheduledTransferLogLevelFilter = LogLevel.Verbose;
            
            // Crash Dumps
            CrashDumps.EnableCollection(true);


            // IIS Logs
            config.Directories.ScheduledTransferPeriod = TimeSpan.FromMinutes(1);
            Trace.WriteLine(&quot;WAD Monitor started&quot;, &quot;Information&quot;);
            DiagnosticMonitor.Start(&quot;Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString&quot;, config);
            RoleEnvironment.Changing &#43;= RoleEnvironmentChanging;


            // Enabled IIS faild request logs.
            // This log file only generate after you have a faild request.
            using (ServerManager serverManager = new ServerManager())
            {
                Configuration iisConfig = serverManager.GetApplicationHostConfiguration();


                ConfigurationSection sitesSection = iisConfig.GetSection(&quot;system.applicationHost/sites&quot;);


                ConfigurationElement siteDefaultsElement = sitesSection.GetChildElement(&quot;siteDefaults&quot;);


                ConfigurationElement logFileElement = siteDefaultsElement.GetChildElement(&quot;logFile&quot;);
                logFileElement[&quot;enabled&quot;] = true;




                serverManager.CommitChanges();
            }
            return base.OnStart();
        }


        private void RoleEnvironmentChanging(object sender, RoleEnvironmentChangingEventArgs e)
        {
            if (e.Changes.Any(change =&gt; change is RoleEnvironmentConfigurationSettingChange))
                e.Cancel = true;
        }
    }
}

</pre>
<pre id="codePreview" class="csharp">
namespace CSAzureRetrieveDiagnosticsMessages_WebRole
{
    public class WebRole : RoleEntryPoint
    {
        public override bool OnStart()
        {
            DiagnosticMonitorConfiguration config = DiagnosticMonitor.GetDefaultInitialConfiguration();


            // Windows Performance Counters
            List&lt;string&gt; counters = new List&lt;string&gt;();
            counters.Add(@&quot;\Processor(_Total)\% Processor Time&quot;);
            counters.Add(@&quot;\Memory\Available Mbytes&quot;);
            counters.Add(@&quot;\TCPv4\Connections Established&quot;);
            counters.Add(@&quot;\ASP.NET Applications(__Total__)\Requests/Sec&quot;);
            counters.Add(@&quot;\Network Interface(*)\Bytes Received/sec&quot;);
            counters.Add(@&quot;\Network Interface(*)\Bytes Sent/sec&quot;);
            foreach (string counter in counters)
            {
                PerformanceCounterConfiguration counterConfig = new PerformanceCounterConfiguration();
                counterConfig.CounterSpecifier = counter;
                counterConfig.SampleRate = TimeSpan.FromMinutes(5);
                config.PerformanceCounters.DataSources.Add(counterConfig);
            }
            config.PerformanceCounters.ScheduledTransferPeriod = TimeSpan.FromMinutes(5);


            // Windows Event Logs
            // WADWindowsEventLogsTable
            config.WindowsEventLog.DataSources.Add(&quot;System!*&quot;);
            
            // WADLogsTable
            config.WindowsEventLog.DataSources.Add(&quot;Application!*&quot;);
            config.WindowsEventLog.ScheduledTransferPeriod = TimeSpan.FromMinutes(1.0);
            config.WindowsEventLog.ScheduledTransferLogLevelFilter = LogLevel.Verbose;


            // Azure Trace Logs
            config.Logs.ScheduledTransferPeriod = TimeSpan.FromMinutes(1.0);
            config.Logs.ScheduledTransferLogLevelFilter = LogLevel.Verbose;
            
            // Crash Dumps
            CrashDumps.EnableCollection(true);


            // IIS Logs
            config.Directories.ScheduledTransferPeriod = TimeSpan.FromMinutes(1);
            Trace.WriteLine(&quot;WAD Monitor started&quot;, &quot;Information&quot;);
            DiagnosticMonitor.Start(&quot;Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString&quot;, config);
            RoleEnvironment.Changing &#43;= RoleEnvironmentChanging;


            // Enabled IIS faild request logs.
            // This log file only generate after you have a faild request.
            using (ServerManager serverManager = new ServerManager())
            {
                Configuration iisConfig = serverManager.GetApplicationHostConfiguration();


                ConfigurationSection sitesSection = iisConfig.GetSection(&quot;system.applicationHost/sites&quot;);


                ConfigurationElement siteDefaultsElement = sitesSection.GetChildElement(&quot;siteDefaults&quot;);


                ConfigurationElement logFileElement = siteDefaultsElement.GetChildElement(&quot;logFile&quot;);
                logFileElement[&quot;enabled&quot;] = true;




                serverManager.CommitChanges();
            }
            return base.OnStart();
        }


        private void RoleEnvironmentChanging(object sender, RoleEnvironmentChangingEventArgs e)
        {
            if (e.Changes.Any(change =&gt; change is RoleEnvironmentConfigurationSettingChange))
                e.Cancel = true;
        }
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><b style=""><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;"></span></b></p>
<p class="MsoNormal">Step 5: Create several pages to show the storage information.<span style="">
</span></p>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://www.windowsazure.com/en-us/develop/net/common-tasks/diagnostics/">Enabling Diagnostics in Windows Azure</a></p>
<p class="MsoNormal"><a href="http://download.microsoft.com/download/4/C/B/4CB0167F-B6D9-4B46-8DF1-69CCCA66FDDE/SystemCenterOperationsManagerMonitoringforAzureHostedAppsatMicrosoft.pdf">SystemCenterOperationsManagerMonitoringforAzureHostedAppsatMicrosoft.pdf</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

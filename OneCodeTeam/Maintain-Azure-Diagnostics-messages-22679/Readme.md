# Maintain Azure Diagnostics messages
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* Diagnostics
## IsPublished
* True
## ModifiedDate
* 2013-06-13 10:57:43
## Description

<h1>Transfer diagnostics messages and retrieve them from Azure storage (<span style="">VB</span>AzureRetrieveDiagnosticsMessages)</h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span style="">This sample will show you how to retrieve diagnostics message and transfer them to Azure storage. And also it will show you how to view both logs in Table and logs in blob.</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow these demonstration steps below.
</span></p>
<p class="MsoNormal"><span style="">Step 1: Open the Cloud solution property chose the Web tab and select use IIS web server.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84781/1/image.png" alt="" width="576" height="144" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">Step 2: </span>Press Ctrl&#43;F5 to show the Default.aspx.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84782/1/image.png" alt="" width="576" height="46" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal">Step 3: Click the first one; you will get your developer storage blob structure.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84783/1/image.png" alt="" width="576" height="210" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal">Step 4: Then click the leaf node; you will get the file message<span style=""> in a .txt file</span>.<span style="">
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84784/1/image.png" alt="" width="578" height="429" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal">Step 5: Then go back to the default.aspx choose the second link. You will get a table list.
</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84785/1/image.png" alt="" width="234" height="98" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal">Step 6: Choose the WADLogsTable, and then you will get the all the tables message.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84786/1/image.png" alt="" width="576" height="128" align="middle">
</span></p>
<p class="MsoNormal"></p>
<h2>Using the Code</h2>
<p class="MsoNormal">Code Logical:</p>
<p class="MsoNormal">Step 1:<span style="">&nbsp; </span>Create a <span style="">
VB.NET</span> windows cloud service with a web role. Service name is &quot;<span style="">VB</span>AzureRetrieveDiagnosticsMessages&quot;.</p>
<p class="MsoNormal">Step2:<span style="">&nbsp; </span>Add two classes: WADLogsTable.<span style="">vb</span>, WADLogsTableDataServiceContext.<span style="">vb</span>.</p>
<p class="MsoNormal">Step3:<span style="">&nbsp; </span>The WADLogsTable class is a table entity class, WADLogsTableDataServiceContext.<span style="">vb</span> provide<span style="">s</span> a service for query the table.</p>
<h3>The following code shows how to create a table entity for table in storage.</h3>
<p class="MsoNormal"><b style=""><span style="">WADLogsTable.vb </span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Class WADLogsTable
    Inherits Microsoft.WindowsAzure.StorageClient.TableServiceEntity
    Public Property Message() As String


    Public Property EventTickCount() As Int64


    Public Property DeploymentId() As String


    Public Property Role() As String


    Public Property RoleInstance() As String


    Public Property Level() As Integer


    Public Property EventId() As Integer


    Public Property Pid() As Integer


    Public Property Tid() As Integer
End Class

</pre>
<pre id="codePreview" class="vb">
Public Class WADLogsTable
    Inherits Microsoft.WindowsAzure.StorageClient.TableServiceEntity
    Public Property Message() As String


    Public Property EventTickCount() As Int64


    Public Property DeploymentId() As String


    Public Property Role() As String


    Public Property RoleInstance() As String


    Public Property Level() As Integer


    Public Property EventId() As Integer


    Public Property Pid() As Integer


    Public Property Tid() As Integer
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<h3>The following code shows how to create a WCF data service.</h3>
<p class="MsoNormal"><b style=""><span style="">WADLogsTableDataServiceContext.vb:
</span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Class WADLogsTableDataServiceContext
    Inherits TableServiceContext
    Public Sub New(baseAddress As String, credentials As Microsoft.WindowsAzure.StorageCredentials)
        MyBase.New(baseAddress, credentials)
    End Sub




    Public ReadOnly Property WADLogs() As IQueryable(Of WADLogsTable)
        Get
            Return Me.CreateQuery(Of WADLogsTable)(&quot;WADLogsTable&quot;)
        End Get
    End Property
End Class

</pre>
<pre id="codePreview" class="vb">
Public Class WADLogsTableDataServiceContext
    Inherits TableServiceContext
    Public Sub New(baseAddress As String, credentials As Microsoft.WindowsAzure.StorageCredentials)
        MyBase.New(baseAddress, credentials)
    End Sub




    Public ReadOnly Property WADLogs() As IQueryable(Of WADLogsTable)
        Get
            Return Me.CreateQuery(Of WADLogsTable)(&quot;WADLogsTable&quot;)
        End Get
    End Property
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal">Step 4: Open the WebRole.<span style="">vb</span> file and add below codes to the file.</p>
<h3>The following code showing how to transfer specific log file to the Azure storage.</h3>
<p class="MsoNormal"><b style=""><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">WebRole.</span></b><b style=""><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">vb</span></b><b style=""><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">:</span></b><b style=""><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">
</span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Class WebRole
    Inherits RoleEntryPoint
    Public Overrides Function OnStart() As Boolean
        Dim config As DiagnosticMonitorConfiguration = DiagnosticMonitor.GetDefaultInitialConfiguration()


        ' Windows Performance Counters
        Dim counters As New List(Of String)()
        counters.Add(&quot;\Processor(_Total)\% Processor Time&quot;)
        counters.Add(&quot;\Memory\Available Mbytes&quot;)
        counters.Add(&quot;\TCPv4\Connections Established&quot;)
        counters.Add(&quot;\ASP.NET Applications(__Total__)\Requests/Sec&quot;)
        counters.Add(&quot;\Network Interface(*)\Bytes Received/sec&quot;)
        counters.Add(&quot;\Network Interface(*)\Bytes Sent/sec&quot;)
        For Each counter As String In counters
            Dim counterConfig As New PerformanceCounterConfiguration()
            counterConfig.CounterSpecifier = counter
            counterConfig.SampleRate = TimeSpan.FromMinutes(5)
            config.PerformanceCounters.DataSources.Add(counterConfig)
        Next
        config.PerformanceCounters.ScheduledTransferPeriod = TimeSpan.FromMinutes(5)


        ' Windows Event Logs
        ' WADWindowsEventLogsTable
        config.WindowsEventLog.DataSources.Add(&quot;System!*&quot;)
        ' WADLogsTable
        config.WindowsEventLog.DataSources.Add(&quot;Application!*&quot;)
        config.WindowsEventLog.ScheduledTransferPeriod = TimeSpan.FromMinutes(1.0)
        config.WindowsEventLog.ScheduledTransferLogLevelFilter = LogLevel.Verbose


        ' Azure Trace Logs
        config.Logs.ScheduledTransferPeriod = TimeSpan.FromMinutes(1.0)
        config.Logs.ScheduledTransferLogLevelFilter = LogLevel.Verbose
        ' Crash Dumps
        CrashDumps.EnableCollection(True)


        ' IIS Logs
        config.Directories.ScheduledTransferPeriod = TimeSpan.FromMinutes(1)
        Trace.WriteLine(&quot;WAD Monitor started&quot;, &quot;Information&quot;)
        DiagnosticMonitor.Start(&quot;Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString&quot;, config)
        AddHandler RoleEnvironment.Changing, AddressOf RoleEnvironmentChanging


        ' Enabled IIS faild request logs.
        ' This log file only generate after you have a faild request.
        Using serverManager As New Microsoft.Web.Administration.ServerManager()
            Dim iisConfig = serverManager.GetApplicationHostConfiguration()


            Dim sitesSection = iisConfig.GetSection(&quot;system.applicationHost/sites&quot;)


            Dim siteDefaultsElement = sitesSection.GetChildElement(&quot;siteDefaults&quot;)


            Dim logFileElement = siteDefaultsElement.GetChildElement(&quot;logFile&quot;)
            logFileElement(&quot;enabled&quot;) = True




            serverManager.CommitChanges()
        End Using
        Return MyBase.OnStart()
    End Function


    Private Sub RoleEnvironmentChanging(sender As Object, e As RoleEnvironmentChangingEventArgs)
        If e.Changes.Any(Function(change) TypeOf change Is RoleEnvironmentConfigurationSettingChange) Then
            e.Cancel = True
        End If
    End Sub
End Class

</pre>
<pre id="codePreview" class="vb">
Public Class WebRole
    Inherits RoleEntryPoint
    Public Overrides Function OnStart() As Boolean
        Dim config As DiagnosticMonitorConfiguration = DiagnosticMonitor.GetDefaultInitialConfiguration()


        ' Windows Performance Counters
        Dim counters As New List(Of String)()
        counters.Add(&quot;\Processor(_Total)\% Processor Time&quot;)
        counters.Add(&quot;\Memory\Available Mbytes&quot;)
        counters.Add(&quot;\TCPv4\Connections Established&quot;)
        counters.Add(&quot;\ASP.NET Applications(__Total__)\Requests/Sec&quot;)
        counters.Add(&quot;\Network Interface(*)\Bytes Received/sec&quot;)
        counters.Add(&quot;\Network Interface(*)\Bytes Sent/sec&quot;)
        For Each counter As String In counters
            Dim counterConfig As New PerformanceCounterConfiguration()
            counterConfig.CounterSpecifier = counter
            counterConfig.SampleRate = TimeSpan.FromMinutes(5)
            config.PerformanceCounters.DataSources.Add(counterConfig)
        Next
        config.PerformanceCounters.ScheduledTransferPeriod = TimeSpan.FromMinutes(5)


        ' Windows Event Logs
        ' WADWindowsEventLogsTable
        config.WindowsEventLog.DataSources.Add(&quot;System!*&quot;)
        ' WADLogsTable
        config.WindowsEventLog.DataSources.Add(&quot;Application!*&quot;)
        config.WindowsEventLog.ScheduledTransferPeriod = TimeSpan.FromMinutes(1.0)
        config.WindowsEventLog.ScheduledTransferLogLevelFilter = LogLevel.Verbose


        ' Azure Trace Logs
        config.Logs.ScheduledTransferPeriod = TimeSpan.FromMinutes(1.0)
        config.Logs.ScheduledTransferLogLevelFilter = LogLevel.Verbose
        ' Crash Dumps
        CrashDumps.EnableCollection(True)


        ' IIS Logs
        config.Directories.ScheduledTransferPeriod = TimeSpan.FromMinutes(1)
        Trace.WriteLine(&quot;WAD Monitor started&quot;, &quot;Information&quot;)
        DiagnosticMonitor.Start(&quot;Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString&quot;, config)
        AddHandler RoleEnvironment.Changing, AddressOf RoleEnvironmentChanging


        ' Enabled IIS faild request logs.
        ' This log file only generate after you have a faild request.
        Using serverManager As New Microsoft.Web.Administration.ServerManager()
            Dim iisConfig = serverManager.GetApplicationHostConfiguration()


            Dim sitesSection = iisConfig.GetSection(&quot;system.applicationHost/sites&quot;)


            Dim siteDefaultsElement = sitesSection.GetChildElement(&quot;siteDefaults&quot;)


            Dim logFileElement = siteDefaultsElement.GetChildElement(&quot;logFile&quot;)
            logFileElement(&quot;enabled&quot;) = True




            serverManager.CommitChanges()
        End Using
        Return MyBase.OnStart()
    End Function


    Private Sub RoleEnvironmentChanging(sender As Object, e As RoleEnvironmentChangingEventArgs)
        If e.Changes.Any(Function(change) TypeOf change Is RoleEnvironmentConfigurationSettingChange) Then
            e.Cancel = True
        End If
    End Sub
End Class

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

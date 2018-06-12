# Startup tasks and Internet Information Services (IIS) configuration
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Microsoft Azure
## Topics
* IIS
* Startup Tasks
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:40:30
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<h1>Startup task and Internet Information Services (IIS) configuration(VBAzureStartupTask)</h1>
<p class="MsoNormal" style="margin-top:10.0pt; margin-right:0cm; margin-bottom:.0001pt; margin-left:0cm">
<strong><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">Introduction</span></strong><strong><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">
</span></strong></p>
<p class="MsoNormal">You can use Startup element to specify tasks to configure your role environment. Applications that are deployed on Windows Azure usually have a set of prerequisites that must be installed on the host computer. You can use the start-up
 tasks to install the prerequisites or to modify configuration settings for your environment. Web and worker roles can be configured in this manner.</p>
<p class="MsoNormal" style="margin-top:10.0pt"><strong><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">Building the Sample</span></strong><strong><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">
</span></strong></p>
<p class="MsoNormal">This sample should be <span>run with Windows Azure SDK 1.6, SQL Server 2008 R2 and IIS 7.0.
</span></p>
<p class="MsoNormal" style="margin-top:10.0pt; margin-right:0cm; margin-bottom:.0001pt; margin-left:0cm">
<strong><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">Running the Sample
</span></strong></p>
<p class="MsoNormal">1. <span>The worker role hosts a WCF service, which provides reverse string service via endpoint http://&#43;:81/reversestring</span><span>.</span><span>
</span></p>
<p class="MsoNormal">2.<span> </span>When you deploy this service to Azure without specifying the startup task in the sample, you will find the role instances keep busy and the WCF service doesn't start. The following exception occurs when worker role calls
 ServiceHost.Open()</p>
<p class="MsoNormal" style="background:white"><span style="color:black">Exception object: 00000000064312f8</span><span style="color:black">
</span></p>
<p class="MsoNormal" style="background:white"><span style="color:black">Exception type:<span>&nbsp;&nbsp;
</span>System.ServiceModel.AddressAccessDeniedException </span></p>
<p class="MsoNormal" style="background:white"><span style="color:black">Message:<span>&nbsp;
</span>HTTP could not register URL http:</span><span style="color:green">//&#43;:81/Service/.
</span><span style="color:black"><span>&nbsp;</span>Your process does not have access rights to this namespace (see http:</span><span style="color:green">//go.microsoft.com/fwlink/?LinkId=70353 for details).</span><span style="color:black">
</span></p>
<p class="MsoNormal" style="background:white"><span style="color:black">InnerException:<span>&nbsp;&nbsp;
</span>System.Net.HttpListenerException, Use !PrintException 0000000006417cd8 to see more.
</span></p>
<p class="MsoNormal" style="background:white"><span style="color:black">StackTrace (generated):
</span></p>
<p class="MsoNormal" style="background:white"><span style="color:black"><span>&nbsp;&nbsp;&nbsp;
</span>SP<span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>IP<span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>Function </span></p>
<p class="MsoNormal" style="background:white"><span style="color:black"><span>&nbsp;&nbsp;&nbsp;
</span>0000000024767DC0 000007FF0078A44C system_servicemodel!System.ServiceModel.Channels.SharedHttpTransportManager.OnOpen()&#43;0x82c
</span></p>
<p class="MsoNormal" style="background:white"><span style="color:black"><span>&nbsp;&nbsp;&nbsp;
</span>000000002476E110 000007FF007896A6 system_servicemodel!System.ServiceModel.Channels.TransportManager.Open(System.ServiceModel.Channels.TransportChannelListener)&#43;0x336
</span></p>
<p class="MsoNormal">3. <span>In Windows Azure, every HTTP path is reserved for use by the system administrator by default. The WCF services will fail to start with an AddressAccessDeniedException if it isn't running from an elevated account. Windows 2003
 includes a tool called httpcfg.exe that lets the owner of an HTTP namespace delegate that ownership to another user. In Windows Azure, httpcfg.exe is no longer included and instead there's a new command set available through netsh.exe.
</span></p>
<p class="MsoNormal">4. <span>The sample has a startup task running elevated: </span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;Startup&gt;
&nbsp; &lt;Task commandLine=&quot;Startup\HttpUrl.cmd&quot; executionContext=&quot;elevated&quot; taskType=&quot;simple&quot; /&gt;
&lt;/Startup&gt;

</pre>
<pre id="codePreview" class="xml">&lt;Startup&gt;
&nbsp; &lt;Task commandLine=&quot;Startup\HttpUrl.cmd&quot; executionContext=&quot;elevated&quot; taskType=&quot;simple&quot; /&gt;
&lt;/Startup&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span>and call the following on command to open the access to port 81: netsh http add urlacl url=http://&#43;:81/ReverseString user=everyone listen=yes delegate=yes
</span></p>
<p class="MsoNormal"><span>There is another option to this problem. You can change the binding property HostNameComparisonMode as Exact. You can do it either in code or in .config file like below:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">New BasicHttpBinding() With { _
&nbsp;&nbsp;&nbsp; Key .HostNameComparisonMode = HostNameComparisonMode.Exact _
}

</pre>
<pre id="codePreview" class="vb">New BasicHttpBinding() With { _
&nbsp;&nbsp;&nbsp; Key .HostNameComparisonMode = HostNameComparisonMode.Exact _
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span>Or in config: </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;bindings&gt;
&nbsp; &lt;basicHttpBinding&gt;
&nbsp;&nbsp;&nbsp; &lt;binding name=&quot;basicHttp&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; hostNameComparisonMode=&quot;Exact&quot; /&gt;
&nbsp; &lt;/basicHttpBinding&gt;
&lt;/bindings&gt;

</pre>
<pre id="codePreview" class="xml">&lt;bindings&gt;
&nbsp; &lt;basicHttpBinding&gt;
&nbsp;&nbsp;&nbsp; &lt;binding name=&quot;basicHttp&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; hostNameComparisonMode=&quot;Exact&quot; /&gt;
&nbsp; &lt;/basicHttpBinding&gt;
&lt;/bindings&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span>After re-deploy the project, create a client application, adding the service reference to reverse string service.
</span></p>
<p class="MsoNormal"><span>You can add code in the client as below to consume the WCF service
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Dim proxy As New TestWCFServiceClient()
Dim s As String = proxy.ReverseString(&quot;Hello World&quot;)
Console.WriteLine(s)

</pre>
<pre id="codePreview" class="vb">Dim proxy As New TestWCFServiceClient()
Dim s As String = proxy.ReverseString(&quot;Hello World&quot;)
Console.WriteLine(s)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">5. <span>Validation finished </span></p>
<p class="MsoNormal" style="margin-top:10.0pt; margin-right:0cm; margin-bottom:.0001pt; margin-left:0cm">
<strong><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">Using the Code</span></strong><strong><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">
</span></strong></p>
<p class="MsoNormal"><span>1. Create a WCF reverse string service. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">&lt;ServiceContract()&gt; _
Public Interface ITestWCFService
&nbsp;&nbsp;&nbsp; &lt;OperationContract()&gt; _
&nbsp;&nbsp;&nbsp; Function ReverseString(s As String) As String
End Interface
Public Class TestWCFService
&nbsp;&nbsp;&nbsp; Implements ITestWCFService


&nbsp;&nbsp;&nbsp; Public Function ReverseString(s As String) As String Implements ITestWCFService.ReverseString
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim arr As Char() = s.ToCharArray()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Array.Reverse(arr)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return New String(arr)
&nbsp;&nbsp;&nbsp; End Function
End Class

</pre>
<pre id="codePreview" class="vb">&lt;ServiceContract()&gt; _
Public Interface ITestWCFService
&nbsp;&nbsp;&nbsp; &lt;OperationContract()&gt; _
&nbsp;&nbsp;&nbsp; Function ReverseString(s As String) As String
End Interface
Public Class TestWCFService
&nbsp;&nbsp;&nbsp; Implements ITestWCFService


&nbsp;&nbsp;&nbsp; Public Function ReverseString(s As String) As String Implements ITestWCFService.ReverseString
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim arr As Char() = s.ToCharArray()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Array.Reverse(arr)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return New String(arr)
&nbsp;&nbsp;&nbsp; End Function
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span>2. </span>Create a Windows Azure Worker Role project and add an Endpoint to open port 81 for HTTP protocol.<span>
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;Endpoints&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;InputEndpoint name=&quot;HttpIn&quot; protocol=&quot;http&quot; port=&quot;81&quot; /&gt;
&lt;/Endpoints&gt;

</pre>
<pre id="codePreview" class="xml">&lt;Endpoints&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;InputEndpoint name=&quot;HttpIn&quot; protocol=&quot;http&quot; port=&quot;81&quot; /&gt;
&lt;/Endpoints&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span>&nbsp;</span></p>
<p class="MsoNormal">3. Create the following 2 methods to start and stop service:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Private Sub StartService(retries As Int32)
&nbsp;&nbsp;&nbsp; If retries = 0 Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RoleEnvironment.RequestRecycle()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; Dim httpUri As New Uri([String].Format(&quot;http://{0}/{1}&quot;, RoleEnvironment.CurrentRoleInstance.InstanceEndpoints(&quot;HttpIn&quot;).IPEndpoint.ToString(), &quot;ReverseString&quot;))




&nbsp;&nbsp;&nbsp; serviceHost = New ServiceHost(GetType(TestWCFService), httpUri)
&nbsp;&nbsp;&nbsp; re = retries


&nbsp;&nbsp;&nbsp; AddHandler serviceHost.Faulted, AddressOf FaultedFunc


&nbsp; &nbsp;&nbsp;Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Trace.TraceInformation(&quot;Trying to open service host&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; serviceHost.Open()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Trace.TraceInformation(&quot;Service host started successfully.&quot;)
&nbsp;&nbsp;&nbsp; Catch timeoutException As TimeoutException


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Trace.TraceError(&quot;The service operation time out. {0}&quot;, timeoutException.Message)
&nbsp;&nbsp;&nbsp; Catch communicationException As CommunicationException
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Trace.TraceError(&quot;Could not start service host. {0}&quot;, communicationException.Message)
&nbsp;&nbsp;&nbsp; End Try
End Sub


Private Sub StopService()
&nbsp;&nbsp;&nbsp; If serviceHost IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; serviceHost.Close()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Catch timeoutException As TimeoutException
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Trace.TraceError(&quot;The service close time out. {0}&quot;, timeoutException.Message)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; serviceHost.Abort()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Catch communicationException As CommunicationException
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Trace.TraceError(&quot;Could not close service host. {0}&quot;, communicationException.Message)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; serviceHost.Abort()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Try
&nbsp;&nbsp;&nbsp; End If
End Sub


Sub FaultedFunc(sender, e)
&nbsp;&nbsp;&nbsp; Trace.TraceError(&quot;Host fault occurred. Aborting and restarting the host. Retry count: {0}&quot;, re)


&nbsp;&nbsp;&nbsp; serviceHost.Abort()
&nbsp;&nbsp;&nbsp; StartService(System.Threading.Interlocked.Decrement(re))


End Sub

</pre>
<pre id="codePreview" class="vb">Private Sub StartService(retries As Int32)
&nbsp;&nbsp;&nbsp; If retries = 0 Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RoleEnvironment.RequestRecycle()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; Dim httpUri As New Uri([String].Format(&quot;http://{0}/{1}&quot;, RoleEnvironment.CurrentRoleInstance.InstanceEndpoints(&quot;HttpIn&quot;).IPEndpoint.ToString(), &quot;ReverseString&quot;))




&nbsp;&nbsp;&nbsp; serviceHost = New ServiceHost(GetType(TestWCFService), httpUri)
&nbsp;&nbsp;&nbsp; re = retries


&nbsp;&nbsp;&nbsp; AddHandler serviceHost.Faulted, AddressOf FaultedFunc


&nbsp; &nbsp;&nbsp;Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Trace.TraceInformation(&quot;Trying to open service host&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; serviceHost.Open()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Trace.TraceInformation(&quot;Service host started successfully.&quot;)
&nbsp;&nbsp;&nbsp; Catch timeoutException As TimeoutException


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Trace.TraceError(&quot;The service operation time out. {0}&quot;, timeoutException.Message)
&nbsp;&nbsp;&nbsp; Catch communicationException As CommunicationException
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Trace.TraceError(&quot;Could not start service host. {0}&quot;, communicationException.Message)
&nbsp;&nbsp;&nbsp; End Try
End Sub


Private Sub StopService()
&nbsp;&nbsp;&nbsp; If serviceHost IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; serviceHost.Close()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Catch timeoutException As TimeoutException
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Trace.TraceError(&quot;The service close time out. {0}&quot;, timeoutException.Message)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; serviceHost.Abort()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Catch communicationException As CommunicationException
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Trace.TraceError(&quot;Could not close service host. {0}&quot;, communicationException.Message)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; serviceHost.Abort()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Try
&nbsp;&nbsp;&nbsp; End If
End Sub


Sub FaultedFunc(sender, e)
&nbsp;&nbsp;&nbsp; Trace.TraceError(&quot;Host fault occurred. Aborting and restarting the host. Retry count: {0}&quot;, re)


&nbsp;&nbsp;&nbsp; serviceHost.Abort()
&nbsp;&nbsp;&nbsp; StartService(System.Threading.Interlocked.Decrement(re))


End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">4. Call StartService() in Worker Role's OnStart() method like below:<span>
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Public Overrides Function OnStart() As Boolean
&nbsp;&nbsp;&nbsp;&nbsp; ' Set the maximum number of concurrent connections 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ServicePointManager.DefaultConnectionLimit = 12


&nbsp;&nbsp;&nbsp;&nbsp; StartService(3)


&nbsp;&nbsp;&nbsp;&nbsp; ' For information on handling configuration changes
&nbsp;&nbsp;&nbsp;&nbsp; ' see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.
&nbsp;&nbsp;&nbsp;&nbsp; AddHandler RoleEnvironment.Changing, AddressOf RoleEnvironmentChanging


&nbsp;&nbsp;&nbsp;&nbsp; Return MyBase.OnStart()
 End Function

</pre>
<pre id="codePreview" class="vb">Public Overrides Function OnStart() As Boolean
&nbsp;&nbsp;&nbsp;&nbsp; ' Set the maximum number of concurrent connections 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ServicePointManager.DefaultConnectionLimit = 12


&nbsp;&nbsp;&nbsp;&nbsp; StartService(3)


&nbsp;&nbsp;&nbsp;&nbsp; ' For information on handling configuration changes
&nbsp;&nbsp;&nbsp;&nbsp; ' see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.
&nbsp;&nbsp;&nbsp;&nbsp; AddHandler RoleEnvironment.Changing, AddressOf RoleEnvironmentChanging


&nbsp;&nbsp;&nbsp;&nbsp; Return MyBase.OnStart()
 End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span>&nbsp;</span></p>
<p class="MsoNormal"><span>5. Call StopService() in Worker Role's OnStop() method like below:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Public Overrides Sub OnStop()
&nbsp;&nbsp;&nbsp; StopService()
&nbsp;&nbsp;&nbsp; MyBase.OnStop()
End Sub

</pre>
<pre id="codePreview" class="vb">Public Overrides Sub OnStop()
&nbsp;&nbsp;&nbsp; StopService()
&nbsp;&nbsp;&nbsp; MyBase.OnStop()
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">6. Add a startup task</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;Startup&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Task commandLine=&quot;Startup\HttpUrl.cmd&quot; executionContext=&quot;elevated&quot; taskType=&quot;simple&quot; /&gt;
&lt;/Startup&gt;

</pre>
<pre id="codePreview" class="xml">&lt;Startup&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Task commandLine=&quot;Startup\HttpUrl.cmd&quot; executionContext=&quot;elevated&quot; taskType=&quot;simple&quot; /&gt;
&lt;/Startup&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">In HttpUrl.cmd reserve port 81 for every one netsh http add urlacl url=http://&#43;:81/ReverseString user=everyone listen=yes delegate=yes</p>
<p class="MsoNormal">7. Build the application and you can debug it now.</p>
<p class="MsoNormal" style="margin-top:10.0pt; margin-right:0cm; margin-bottom:.0001pt; margin-left:0cm">
<strong><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">More Information</span></strong><strong><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">
</span></strong></p>
<p class="MsoNormal"><span><a href="http://msdn.microsoft.com/en-us/library/gg456327.aspx"><span>MSDN: How to Define Startup Tasks for a Role</span></a></span><span style="font-size:13.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

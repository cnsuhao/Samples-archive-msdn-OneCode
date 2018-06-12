# Windows Azure startup task demo (CSAzureStartupTask)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* Startup Task
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:42:01
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<h2><span style="font-family:courier new,courier; font-size:large">APPLICATION : CSAzureStartupTask Project Overview</span></h2>
<h3><span style="font-family:courier new,courier; font-size:medium">Summary:</span></h3>
<p><span style="font-family:courier new,courier; font-size:small">You can use Startup element to specify tasks to configure your role environment.
</span><br>
<span style="font-family:courier new,courier; font-size:small">Applications that are deployed on Windows Azure usually have a set of prerequisites
</span><br>
<span style="font-family:courier new,courier; font-size:small">that must be installed on the host computer. You can use the start-up tasks to
</span><br>
<span style="font-family:courier new,courier; font-size:small">install the prerequisites or to modify configuration settings for your environment.
</span><br>
<span style="font-family:courier new,courier; font-size:small">Web and worker roles can be configured in this manner.</span></p>
<h3><span style="font-family:courier new,courier; font-size:medium">Prerequisite:</span></h3>
<p><span style="font-family:courier new,courier; font-size:small">&middot; IIS 7 (with ASP.NET, WCF HTTP Activation)</span><br>
<span style="font-family:courier new,courier; font-size:small">&middot; Microsoft .NET Framework 4.0</span><br>
<span style="font-family:courier new,courier; font-size:small">&middot; Microsoft Visual Studio 2010</span><br>
<span style="font-family:courier new,courier; font-size:small">&middot; Windows Azure Tools for Microsoft Visual Studio 1.4</span></p>
<h3><br>
<span style="font-family:courier new,courier; font-size:medium">Demo:</span></h3>
<p><span style="font-family:courier new,courier; font-size:small">The following steps walk through a demonstration of the CSAzureStartup sample.</span></p>
<p><span style="font-family:courier new,courier; font-size:small">The worker role hosts a WCF service, which provides reverse string service via
</span><br>
<span style="font-family:courier new,courier; font-size:small">endpoint <a href="http://&#43;:81/reversestring">
http://&#43;:81/reversestring</a> . </span><br>
<span style="font-family:courier new,courier; font-size:small">When you deploy this service to Azure without specifying the startup task in the
</span><br>
<span style="font-family:courier new,courier; font-size:small">sample, you will find the role instances keep busy and the WCF service doesn't start.</span><br>
<span style="font-family:courier new,courier; font-size:small">The following exception occurs when worker role calls ServiceHost.Open()</span></p>
<p><span style="font-family:courier new,courier; font-size:small">Exception object: 00000000064312f8</span><br>
<span style="font-family:courier new,courier; font-size:small">Exception type:&nbsp;&nbsp; System.ServiceModel.AddressAccessDeniedException</span><br>
<span style="font-family:courier new,courier; font-size:small">Message:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; HTTP could not register URL
<a href="http://&#43;:81/Service/">http://&#43;:81/Service/</a>. </span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Your process does not have access rights to this namespace</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; (see
<a href="http://go.microsoft.com/fwlink/?LinkId=70353">http://go.microsoft.com/fwlink/?LinkId=70353</a> for details).</span><br>
<span style="font-family:courier new,courier; font-size:small">InnerException:&nbsp;&nbsp; System.Net.HttpListenerException, Use !PrintException 0000000006417cd8 to see more.</span><br>
<span style="font-family:courier new,courier; font-size:small">StackTrace (generated):</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp; SP&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; IP&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Function</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp; 0000000024767DC0 000007FF0078A44C system_servicemodel!System.ServiceModel.Channels.SharedHttpTransportManager.OnOpen()&#43;0x82c</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp; 000000002476E110 000007FF007896A6 system_servicemodel!System.ServiceModel.Channels.TransportManager.Open(System.ServiceModel.Channels.TransportChannelListener)&#43;0x336</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp; 000000002476E1C0 000007FF00786FE9 system_servicemodel!System.ServiceModel.Channels.TransportManagerContainer.Open(System.ServiceModel.Channels.SelectTransportManagersCallback)&#43;0x79</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp; 000000002476E230 000007FF00786F1F system_servicemodel!System.ServiceModel.Channels.HttpChannelListener.OnOpen(System.TimeSpan)&#43;0x14f</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp; 000000002476E2B0 000007FF0052C134 system_servicemodel!System.ServiceModel.Channels.CommunicationObject.Open(System.TimeSpan)&#43;0x2f4</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp; 000000002476E3D0 000007FF007863F7 system_servicemodel!System.ServiceModel.Dispatcher.ChannelDispatcher.OnOpen(System.TimeSpan)&#43;0xc7</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp; 000000002476E420 000007FF0052C134 system_servicemodel!System.ServiceModel.Channels.CommunicationObject.Open(System.TimeSpan)&#43;0x2f4</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp; 000000002476E540 000007FF0052F389 system_servicemodel!System.ServiceModel.ServiceHostBase.OnOpen(System.TimeSpan)&#43;0xb9</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp; 000000002476E5A0 000007FF0052C134 system_servicemodel!System.ServiceModel.Channels.CommunicationObject.Open(System.TimeSpan)&#43;0x2f4</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp; 000000002476E6C0 000007FF005088E9 workerrole1!WorkerRole1.WorkerRole.StartService(Int32)&#43;0x4b9</span><br>
<span style="font-family:courier new,courier; font-size:small">In Windows Azure, every HTTP path is reserved for use by the system administrator by default.
</span><br>
<span style="font-family:courier new,courier; font-size:small">The WCF services will fail to start with an AddressAccessDeniedException if it isn't
</span><br>
<span style="font-family:courier new,courier; font-size:small">running from an elevated account. Windows 2003 includes a tool called httpcfg.exe that
</span><br>
<span style="font-family:courier new,courier; font-size:small">lets the owner of an HTTP namespace delegate that ownership to another user. In Windows
</span><br>
<span style="font-family:courier new,courier; font-size:small">Azure, httpcfg.exe is no longer included and instead there's a new command set available
</span><br>
<span style="font-family:courier new,courier; font-size:small">through netsh.exe.</span></p>
<p><span style="font-family:courier new,courier; font-size:small">The sample has a startup task running elevated
</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp; &lt;Startup&gt;</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Task commandLine=&quot;Startup\HttpUrl.cmd&quot; executionContext=&quot;elevated&quot; taskType=&quot;simple&quot; /&gt;</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp; &lt;/Startup&gt;</span><br>
<span style="font-family:courier new,courier; font-size:small">and call the following on command to open the access to port 81:</span><br>
<span style="font-family:courier new,courier; font-size:small">netsh http add urlacl url=http://&#43;:81/ReverseString user=everyone listen=yes delegate=yes</span></p>
<p><span style="font-family:courier new,courier; font-size:small">There is another option to this problem. You can change the binding property HostNameComparisonMode
</span><br>
<span style="font-family:courier new,courier; font-size:small">as Exact. You can do it either in code or in .config file like below:</span><br>
<span style="font-family:courier new,courier; font-size:small">new BasicHttpBinding</span><br>
<span style="font-family:courier new,courier; font-size:small">{ </span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp; HostNameComparisonMode = HostNameComparisonMode.Exact
</span><br>
<span style="font-family:courier new,courier; font-size:small">};</span></p>
<p><span style="font-family:courier new,courier; font-size:small">Or in config:</span><br>
<span style="font-family:courier new,courier; font-size:small">&lt;bindings&gt;</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;basicHttpBinding&gt;</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;binding name=&quot;basicHttp&quot;</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; hostNameComparisonMode=&quot;Exact&quot; /&gt;</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/basicHttpBinding&gt;</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/bindings&gt;</span></p>
<p><span style="font-family:courier new,courier; font-size:small">After re-deploy the project, create a client application, adding the service reference to reverse
</span><br>
<span style="font-family:courier new,courier; font-size:small">string service. </span>
<br>
<span style="font-family:courier new,courier; font-size:small">You can add code in the client as below to consume the WCF service</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;TestWCFServiceClient proxy = new TestWCFServiceClient();&nbsp;&nbsp;</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;string s = proxy.ReverseString(&quot;Hello World&quot;);</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;Console.WriteLine(s);</span></p>
<p><span style="font-family:courier new,courier; font-size:medium">Implementation</span></p>
<p><span style="font-family:courier new,courier; font-size:small">Step1. Create a WCF reverse string service.</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;[ServiceContract]</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;public interface ITestWCFService</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;{</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;[OperationContract]</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;string ReverseString(string s);</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;}</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;public class TestWCFService : ITestWCFService</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;{</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;#region ITest Members</span></p>
<p><span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;public string ReverseString(string s)</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;{</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;char[] arr = s.ToCharArray();</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;Array.Reverse(arr);</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;return new string(arr);</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;}</span></p>
<p><span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;#endregion</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;}</span></p>
<p><br>
<span style="font-family:courier new,courier; font-size:small">Step2. Create a Windows Azure Worker Role project and add an Endpoint to open port 81 for HTTP protocol.</span><br>
<span style="font-family:courier new,courier; font-size:small">&lt;Endpoints&gt;</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;InputEndpoint name=&quot;HttpIn&quot; protocol=&quot;http&quot; port=&quot;81&quot; /&gt;</span><br>
<span style="font-family:courier new,courier; font-size:small">&lt;/Endpoints&gt;</span></p>
<p><span style="font-family:courier new,courier; font-size:small">Step3. Create the following 2 methods to start and stop service</span><br>
<span style="font-family:courier new,courier; font-size:small">private void StartService(Int32 retries)</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;{</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;if (retries == 0)</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;{</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;RoleEnvironment.RequestRecycle();</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;return;</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;}</span></p>
<p><span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;Uri httpUri = new Uri(String.Format(&quot;<a href="http://{0}/{1">http://{0}/{1</a>}&quot;,</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RoleEnvironment.CurrentRoleInstance.InstanceEndpoints[&quot;HttpIn&quot;].IPEndpoint.ToString(),</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;ReverseString&quot;));</span></p>
<p><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;serviceHost = new ServiceHost(typeof(TestWCFService), httpUri);</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;serviceHost.Faulted &#43;= (sender, e) =&gt;</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;{</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Trace.TraceError(&quot;Host fault occured. Aborting and restarting the host. Retry count: {0}&quot;, retries);</span></p>
<p><span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;serviceHost.Abort();</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StartService(--retries);</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;};</span></p>
<p><span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;try</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;{</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;Trace.TraceInformation(&quot;Trying to open service host&quot;);</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;serviceHost.Open();</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;Trace.TraceInformation(&quot;Service host started successfully.&quot;);</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;}</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;catch (TimeoutException timeoutException)</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;{</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;Trace.TraceError(&quot;The service operation time out. {0}&quot;,</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timeoutException.Message);</span></p>
<p><span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;}</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;catch (CommunicationException communicationException)</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;{</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;Trace.TraceError(&quot;Could not start service host. {0}&quot;,</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; communicationException.Message);</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;}</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;}</span></p>
<p><span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;private void StopService()</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;{</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;if (serviceHost != null)</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;{</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;try</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;{</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;serviceHost.Close();</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;}</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;catch (TimeoutException timeoutException)</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;{</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Trace.TraceError(&quot;The service close time out. {0}&quot;,</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timeoutException.Message);</span></p>
<p><span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;serviceHost.Abort();</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;}</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;catch (CommunicationException communicationException)</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;{</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Trace.TraceError(&quot;Could not close service host. {0}&quot;,</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; communicationException.Message);</span></p>
<p><span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;serviceHost.Abort();</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;}</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;}</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;}</span><br>
<span style="font-family:courier new,courier; font-size:small">Step4. Call StartService() in Worker Role's OnStart() method like below</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;public override bool OnStart()</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;{</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;// Set the maximum number of concurrent connections
</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;ServicePointManager.DefaultConnectionLimit = 12;</span></p>
<p><span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;StartService(3);</span></p>
<p><span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;// For information on handling configuration changes</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;// see the MSDN topic at
<a href="http://go.microsoft.com/fwlink/?LinkId=166357">http://go.microsoft.com/fwlink/?LinkId=166357</a>.</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;RoleEnvironment.Changing &#43;= RoleEnvironmentChanging;</span></p>
<p><span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;return base.OnStart();</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;}</span><br>
<span style="font-family:courier new,courier; font-size:small">Step5. Call StopService() in Worker Role's OnStop() method like below</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;public override void OnStop()</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;{</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;StopService();</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;base.OnStop();</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;}</span><br>
<span style="font-family:courier new,courier; font-size:small">Step6. Add a startup task</span><br>
<span style="font-family:courier new,courier; font-size:small">&lt;Startup&gt;</span><br>
<span style="font-family:courier new,courier; font-size:small">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Task commandLine=&quot;Startup\HttpUrl.cmd&quot; executionContext=&quot;elevated&quot; taskType=&quot;simple&quot; /&gt;</span><br>
<span style="font-family:courier new,courier; font-size:small">&lt;/Startup&gt;</span><br>
<span style="font-family:courier new,courier; font-size:small">In HttpUrl.cmd reserve port 81 for every one.</span><br>
<span style="font-family:courier new,courier; font-size:small">netsh http add urlacl url=http://&#43;:81/ReverseString user=everyone listen=yes delegate=yes</span></p>
<p><br>
<span style="font-family:courier new,courier; font-size:small">Step7. Build and deploy the project to Windows Azure.</span></p>
<p><br>
<span style="font-family:courier new,courier; font-size:medium">References:</span></p>
<h3><span style="font-family:courier new,courier; font-size:small">MSDN: How to Define Startup Tasks for a Role</span><br>
<span style="font-family:courier new,courier; font-size:small"><a href="http://msdn.microsoft.com/en-us/library/gg456327.aspx">http://msdn.microsoft.com/en-us/library/gg456327.aspx</a></span></h3>
<h3><span style="font-family:courier new,courier; font-size:small">
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
</span></h3>

# Protocol Bridging with ServiceBus and WCF4 (VBAzureServiceBusProtocolBridging)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* Service Bus
* AppFabric
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:35:58
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<h1>Protocol Bridging with ServiceBus and WCF4 in Windows Azure</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The <strong>AppFabric Service Bus</strong> provides the communication infrastructure that protects developers from having to create the complex code necessary to achieve seamless connectivity. It allows you to expose a service to the
 Internet from behind your firewall or NAT.</p>
<p class="MsoNormal">WCF4 includes a new routing service found in the <strong>System.ServiceModel.Routing</strong> namespace. The Routing Service is designed to act as a generic, configurable SOAP intermediary. It allows you to configure Content Based Routing,
 set up Protocol Bridging, and handle communication errors that you encounter. The Routing Service also makes it possible for you to update your Routing Configuration while the Routing Service is running without restarting the service.</p>
<p class="MsoNormal">This sample demos how to combine <strong>AppFabric Service Bus</strong> and
<strong>WCF4 Routing Service</strong> to expose an existing net.tcp WCF service through Service Bus using http protocol. For the technical detail, please see the
<a href="#references">References</a> section.</p>
<div align="right">
<p><a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420"><span style="color:windowtext; text-decoration:none"><span><img src="http://code.msdn.microsoft.com/site/view/file/67654/1/image.png" alt="" width="120" height="90" align="middle">
</span></span></a><br>
<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420">Try Windows Azure for free for 90 Days!</a></p>
</div>
<p class="MsoNormal">This solution contains 4 projects:</p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><strong>Common</strong> is a class library, contains classes which are shared by all projects.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><strong>Service</strong> is a console application that hosts a WCF service on local machine.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><strong>RouterService</strong> is a console application, exposes a Routing Service through Service Bus and routes requests to Service that is running on the same machine as RouterService.</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><strong>Client</strong> is a console application, consumes the WCF service through Service Bus.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">You need to install Windows Azure AppFabric SDK in order to build this code sample.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><strong>Step 1</strong>: Run Visual Studio as administrator and open the solution (VBAzureServiceBusProtocolBridging.sln) in Visual Studio.</p>
<p class="MsoNormal"><strong>Step 2</strong>: Input your Service Bus settings.</p>
<p class="MsoNormal">Please open <strong>Settings.vb</strong> class file which belongs to
<strong>Common</strong> project by double clicking it in <strong>Solution Explorer</strong>. Then please input your Service Bus namespace, issuer name and issuer secret. If you don't know how to get these, please refer to
<a href="http://msdn.microsoft.com/en-us/gg282248">Getting Started: Creating a Service Bus Namespace</a>.</p>
<p class="MsoNormal"><strong>Step 3</strong>: Run applications.</p>
<p class="MsoNormal">Please right-click the solution in <strong>Solution Explorer</strong> then click
<strong>Properties</strong> to open the <strong>Solution Property Pages </strong>
window. In the Solution Property Pages window, select <strong>Startup Project</strong> tab and select
<strong>Multiple startup projects</strong> option. Set the <strong>RouterService</strong> project as
<strong>Start without debugging</strong>, the <strong>Service</strong> project as Start and finally click the
<strong>OK</strong> button to close the <strong>Solution Property Pages </strong>
window.</p>
<p class="MsoNormal">Click <strong>Debug &gt; Start Debugging</strong> (or press F5) to start up
<strong>Service</strong> project and <strong>RouterService</strong> project. Wait until both console applications say &quot;Service is Ready...&quot;. It may need several seconds for
<strong>RouterService</strong> application to connect to Service Bus and expose the service on it. Back to the
<strong>Solution Explorer</strong>, please right-click the Client project and select
<strong>Debug &gt; Start new instance</strong> to start up the <strong>Client</strong> application.</p>
<p class="MsoNormal">It also may needs seconds for <strong>Client</strong> application to connect to Service Bus and consume the service. Finally you will get similar outputs like below.</p>
<p class="MsoNormal"><strong>Client application console: </strong></p>
<p class="MsoNormal"><em>Initializing proxy.<br>
Calling Add(36, 15) via <a href="https://[namespace].servicebus.windows.net/MyService">
https://[namespace].servicebus.windows.net/MyService</a><br>
Result: 51<br>
Please press [Enter] to exit. </em></p>
<p class="MsoNormal"><strong>Service application console: </strong></p>
<p class="MsoNormal"><em>Starting service.<br>
Service is ready at net.tcp://localhost:9090/MyService<br>
Please press [Enter] to exit.<br>
Add(36, 15) is called. </em></p>
<p class="MsoNormal"><span>&nbsp;</span></p>
<p class="MsoNormal"><strong>Why can't I debug RouterService project and Client project in the same time?
</strong></p>
<p class="MsoNormal">If you debug RouterService and Client in the same time, the Client application will receive the following error when it calls the service.</p>
<p class="MsoNormal"><em>Multiple headers with name 'VsDebuggerCausalityData'<br>
and namespace 'http://schemas.microsoft.com/vstudio/diagnostics/servicemodelsink' found.
</em></p>
<p class="MsoNormal">This happens because when debugging WCF client application (WCF service consumer) in Visual Studio, Visual Studio will append a 'VsDebuggerCausalityData' header to the request. In this sample, Client sends request to Service Bus and RouterService
 receives request from Service Bus and sends request to Service. The same request is sent twice, thus, if we debug both Client and RouterService, the 'VsDebuggerCausalityData' header will be appended twice.</p>
<p class="MsoNormal">Solution will be either of following options:</p>
<p class="MsoNormal">1) Do not debug them at the same time, either debug Client project or Service project. That means one of them needs to start up without debugging.</p>
<p class="MsoNormal">2) Temporarily disable debugger support for WCF by running the following command:<br>
<em>&quot;C:\Program Files\Microsoft Visual Studio 10.0\Common7\IDE\vsdiag_regwcf.exe&quot; &ndash;u<br>
</em>Then we can debug both Client project and Service project. After debugging, you may need to rollback the change and enable debugger support for WCF:<br>
<em>&quot;C:\Program Files\Microsoft Visual Studio 10.0\Common7\IDE\vsdiag_regwcf.exe&quot; &ndash;i</em></p>
<p class="MsoNormal">&nbsp;</p>
<h2>More Information</h2>
<p class="MsoNormal" style="line-height:normal"><span><a href="http://msdn.microsoft.com/en-us/library/ee732537.aspx">AppFabric Service Bus</a>
</span></p>
<p class="MsoNormal" style="line-height:normal"><span><a href="http://msdn.microsoft.com/en-us/gg282251">Introduction to the AppFabric Service Bus &gt; Exercise 1: Getting a Basic Client and Service Working</a>
</span></p>
<p class="MsoNormal" style="line-height:normal"><span><a href="http://msdn.microsoft.com/en-us/gg465230">What's New in WCF 4? &gt; Exercise 8: Protocol Bridging</a>
</span></p>
<p class="MsoNormal">&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

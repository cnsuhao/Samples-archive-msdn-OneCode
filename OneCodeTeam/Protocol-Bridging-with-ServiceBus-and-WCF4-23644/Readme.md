# Protocol Bridging with ServiceBus and WCF4
## Requires
* Visual Studio 2012
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
* 2013-07-03 11:09:04
## Description

<h1>Protocol Bridging with ServiceBus and WCF4 in Windows Azure</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The <b style="">AppFabric Service Bus</b> provides the communication infrastructure that protects developers from having to create the complex code necessary to achieve seamless connectivity. It allows you to expose a service to the Internet
 from behind your firewall or NAT.</p>
<p class="MsoNormal">WCF4 includes a new routing service found in the <b style="">
System.ServiceModel.Routing</b> namespace. The Routing Service is designed to act as a generic, configurable SOAP intermediary. It allows you to configure Content Based Routing, set up Protocol Bridging, and handle communication errors that you encounter. The
 Routing Service also makes it possible for you to update your Routing Configuration while the Routing Service is running without restarting the service.</p>
<p class="MsoNormal">This sample demos how to combine <b style="">AppFabric Service Bus</b> and
<b style="">WCF4 Routing Service</b> to expose an existing net.tcp WCF service through Service Bus using http protocol. For the technical detail, please see the
<a href="#references">References</a> section.</p>
<p class="MsoNormal">This solution contains 4 projects:</p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><b style="">Common</b> is a class library, contains classes which are shared by all projects.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><b style="">Service</b> is a console application that hosts a WCF service on local machine.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><b style="">RouterService</b> is a console application, exposes a Routing Service through Service Bus and routes requests to Service that is running on the same machine as RouterService.</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><b style="">Client</b> is a console application, consumes the WCF service through Service Bus.</p>
<p class="MsoNormal"></p>
<p class="MsoListParagraph" align="right" style="margin-right:5.5pt; text-align:right">
<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420"><span style="color:windowtext; text-decoration:none"><span style=""><img src="/site/view/file/91633/1/image.png" alt="" width="120" height="90" align="middle">
</span></span></a><br>
<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420">Try Windows Azure for free for 90 Days!</a></p>
<h2>Building the Sample</h2>
<p class="MsoNormal">You need to install Windows Azure AppFabric SDK in order to build this code sample.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><b style="">Step 1</b>: Run Visual Studio as administrator and open the solution (VBAzureServiceBusProtocolBridging.sln) in Visual Studio.</p>
<p class="MsoNormal"><b style="">Step 2</b>: Input your Service Bus settings.</p>
<p class="MsoNormal">Please open <b style="">Settings.vb</b> class file which belongs to
<b style="">Common</b> project by double clicking it in <b style="">Solution Explorer</b>. Then please input your Service Bus namespace, issuer name and issuer secret. If you don't know how to get these, please refer to
<a href="http://msdn.microsoft.com/en-us/gg282248">Getting Started: Creating a Service Bus Namespace</a>.</p>
<p class="MsoNormal"><b style="">Step 3</b>: Run applications.</p>
<p class="MsoNormal">Please right-click the solution in <b style="">Solution Explorer</b> then click
<b style="">Properties</b> to open the <b style="">Solution Property Pages </b>window. In the Solution Property Pages window, select
<b style="">Startup Project</b> tab and select <b style="">Multiple startup projects</b> option. Set the
<b style="">RouterService</b> project as <b style="">Start without debugging</b>, the
<b style="">Service</b> project as Start and finally click the <b style="">OK</b> button to close the
<b style="">Solution Property Pages </b>window.</p>
<p class="MsoNormal">Click <b style="">Debug &gt; Start Debugging</b> (or press F5) to start up
<b style="">Service</b> project and <b style="">RouterService</b> project. Wait until both console applications say &quot;Service is Ready...&quot;. It may need several seconds for
<b style="">RouterService</b> application to connect to Service Bus and expose the service on it. Back to the
<b style="">Solution Explorer</b>, please right-click the Client project and select
<b style="">Debug &gt; Start new instance</b> to start up the <b style="">Client</b> application.</p>
<p class="MsoNormal">It also may needs seconds for <b style="">Client</b> application to connect to Service Bus and consume the service. Finally you will get similar outputs like below.</p>
<p class="MsoNormal"><b style="">Client application console: </b></p>
<p class="MsoNormal"><i style="">Initializing proxy.<br>
Calling Add(36, 15) via <a href="https://[namespace].servicebus.windows.net/MyService">
https://[namespace].servicebus.windows.net/MyService</a><br>
Result: 51<br>
Please press [Enter] to exit. </i></p>
<p class="MsoNormal"><b style="">Service application console: </b></p>
<p class="MsoNormal"><i style="">Starting service.<br>
Service is ready at net.tcp://localhost:9090/MyService<br>
Please press [Enter] to exit.<br>
Add(36, 15) is called. </i></p>
<p class="MsoNormal"><span style="">&nbsp;</span></p>
<p class="MsoNormal"><b style="">Why can't I debug RouterService project and Client project in the same time?
</b></p>
<p class="MsoNormal" style="">If you debug RouterService and Client in the same time, the Client application will receive the following error when it calls the service.</p>
<p class="MsoNormal" style=""><i style="">Multiple headers with name 'VsDebuggerCausalityData'<br>
and namespace 'http://schemas.microsoft.com/vstudio/diagnostics/servicemodelsink' found.
</i></p>
<p class="MsoNormal" style="">This happens because when debugging WCF client application (WCF service consumer) in Visual Studio, Visual Studio will append a 'VsDebuggerCausalityData' header to the request. In this sample, Client sends request to Service
 Bus and RouterService receives request from Service Bus and sends request to Service. The same request is sent twice, thus, if we debug both Client and RouterService, the 'VsDebuggerCausalityData' header will be appended twice.</p>
<p class="MsoNormal" style="">Solution will be either of following options:</p>
<p class="MsoNormal" style="">1) Do not debug them at the same time, either debug Client project or Service project. That means one of them needs to start up without debugging.</p>
<p class="MsoNormal" style="">2) Temporarily disable debugger support for WCF by running the following command:<br>
<i style="">&quot;C:\Program Files\Microsoft Visual Studio 10.0\Common7\IDE\vsdiag_regwcf.exe&quot; –u<br>
</i>Then we can debug both Client project and Service project. After debugging, you may need to rollback the change and enable debugger support for WCF:<br>
<i style="">&quot;C:\Program Files\Microsoft Visual Studio 10.0\Common7\IDE\vsdiag_regwcf.exe&quot; –i</i></p>
<p class="MsoNormal" style=""></p>
<h2>More Information</h2>
<p class="MsoNormal" style="line-height:normal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/ee732537.aspx">AppFabric Service Bus</a>
</span></p>
<p class="MsoNormal" style="line-height:normal"><span style=""><a href="http://msdn.microsoft.com/en-us/gg282251">Introduction to the AppFabric Service Bus &gt; Exercise 1: Getting a Basic Client and Service Working</a>
</span></p>
<p class="MsoNormal" style="line-height:normal"><span style=""><a href="http://msdn.microsoft.com/en-us/gg465230">What's New in WCF 4? &gt; Exercise 8: Protocol Bridging</a>
</span></p>
<p class="MsoNormal" style=""></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

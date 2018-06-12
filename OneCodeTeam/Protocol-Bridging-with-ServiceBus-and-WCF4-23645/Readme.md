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
* 2013-07-03 11:09:02
## Description

<h1><span lang="EN-US">Protocol Bridging with <span class="SpellE">ServiceBus</span> and WCF4 in Windows Azure</span></h1>
<h2><span lang="EN-US">Introduction</span></h2>
<p class="MsoNormal"><span lang="EN-US">The <span class="SpellE"><b style="">AppFabric</b></span><b style=""> Service Bus</b> provides the communication infrastructure that protects developers from having to create the complex code necessary to achieve
 seamless connectivity. It allows you to expose a service to the Internet from behind your firewall or NAT.</span></p>
<p class="MsoNormal"><span lang="EN-US">WCF4 includes a new routing service found in the
<span class="SpellE"><b style="">System.ServiceModel.Routing</b></span> namespace. The Routing Service is designed to act as a generic, configurable SOAP intermediary. It allows you to configure Content Based Routing, set up Protocol Bridging, and handle
 communication errors that you encounter. The Routing Service also makes it possible for you to update your Routing Configuration while the Routing Service is running without restarting the service.</span></p>
<p class="MsoNormal"><span lang="EN-US">This sample demos how to combine <span class="SpellE">
<b style="">AppFabric</b></span><b style=""> Service Bus</b> and <b style="">WCF4 Routing Service</b> to expose an existing
<span class="SpellE">net.tcp</span> WCF service through Service Bus using http protocol. For the technical detail, please see the
<a href="#references">References</a> section.</span></p>
<p class="MsoNormal"><span lang="EN-US">This solution contains 4 projects:</span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span lang="EN-US" style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><b style=""><span lang="EN-US">Common</span></b><span lang="EN-US"> is a class library, contains classes which are shared by all projects.</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span lang="EN-US" style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><b style=""><span lang="EN-US">Service</span></b><span lang="EN-US"> is a console application that hosts a WCF service on local machine.</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span lang="EN-US" style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE"><b style=""><span lang="EN-US">RouterService</span></b></span><span lang="EN-US"> is a console application, exposes a Routing Service through Service Bus and routes requests to Service that is running on the same
 machine as <span class="SpellE">RouterService</span>.</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span lang="EN-US" style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><b style=""><span lang="EN-US">Client</span></b><span lang="EN-US"> is a console application, consumes the WCF service through Service Bus.</span></p>
<p class="MsoNormal"><span lang="EN-US"></span></p>
<p class="MsoListParagraph" align="right" style="margin-right:5.5pt; text-align:right">
<span lang="EN-US"><a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420"><span style="color:windowtext; text-decoration:none"><span style=""><img src="/site/view/file/91632/1/image.png" alt="" width="120" height="90" align="middle">
</span></span></a><br>
<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420">Try Windows Azure for free for 90 Days!</a></span></p>
<h2><span lang="EN-US">Building the Sample</span></h2>
<p class="MsoNormal"><span lang="EN-US">You need to install Windows Azure <span class="SpellE">
AppFabric</span> SDK in order to build this code sample.</span></p>
<h2><span lang="EN-US">Running the Sample</span></h2>
<p class="MsoNormal"><b style=""><span lang="EN-US">Step 1</span></b><span lang="EN-US">: Run Visual Studio as administrator and open the solution (CSAzureServiceBusProtocolBridging.sln) in Visual Studio.</span></p>
<p class="MsoNormal"><b style=""><span lang="EN-US">Step 2</span></b><span lang="EN-US">: Input your Service Bus settings.</span></p>
<p class="MsoNormal"><span lang="EN-US">Please open <span class="SpellE"><b style="">Settings.cs</b></span> class file which belongs to
<b style="">Common</b> project by double clicking it in <b style="">Solution Explorer</b>. Then please input your Service Bus namespace, issuer name and issuer secret. If you don't know how to get these, please refer to
<a href="http://msdn.microsoft.com/en-us/gg282248">Getting Started: Creating a Service Bus Namespace</a>.</span></p>
<p class="MsoNormal"><b style=""><span lang="EN-US">Step 3</span></b><span lang="EN-US">: Run applications.</span></p>
<p class="MsoNormal"><span lang="EN-US">Please right-click the solution in <b style="">
Solution Explorer</b> then click <b style="">Properties</b> to open the <b style="">
Solution Property Pages </b>window. In the Solution Property Pages window, select
<b style="">Startup Project</b> tab and select <span class="GramE"><b style="">Multiple</b></span><b style=""> startup projects</b> option. Set the
<span class="SpellE"><b style="">RouterService</b></span> project as <b style="">
Start without debugging</b>, the <b style="">Service</b> project as Start and finally click the
<b style="">OK</b> button to close the <b style="">Solution Property Pages </b>window.</span></p>
<p class="MsoNormal"><span lang="EN-US">Click <b style="">Debug &gt; Start Debugging</b> (or press F5) to start up
<b style="">Service</b> project and <span class="SpellE"><b style="">RouterService</b></span> project. Wait until both console applications say &quot;Service is Ready...<span class="GramE">&quot;.</span> It may need several seconds for
<span class="SpellE"><b style="">RouterService</b></span> application to connect to Service Bus and expose the service on it. Back to the
<b style="">Solution Explorer</b>, please right-click the Client project and select
<b style="">Debug &gt; Start new instance</b> to start up the <b style="">Client</b> application.</span></p>
<p class="MsoNormal"><span lang="EN-US">It also may needs seconds for <b style="">
Client</b> application to connect to Service Bus and consume the service. Finally you will get similar outputs like below.</span></p>
<p class="MsoNormal"><b style=""><span lang="EN-US">Client application console:
</span></b></p>
<p class="MsoNormal"><i style=""><span lang="EN-US">Initializing proxy.<br>
Calling <span class="GramE">Add(</span>36, 15) via <a href="https://[namespace].servicebus.windows.net/MyService">
https://[namespace].servicebus.windows.net/MyService</a><br>
Result: 51<br>
Please press [Enter] to exit. </span></i></p>
<p class="MsoNormal"><b style=""><span lang="EN-US">Service application console:
</span></b></p>
<p class="MsoNormal"><i style=""><span lang="EN-US">Starting service.<br>
Service is ready at <span class="SpellE">net.tcp</span>://localhost:9090/<span class="SpellE">MyService</span><br>
Please press [Enter] to exit.<br>
<span class="GramE">Add(</span>36, 15) is called. </span></i></p>
<p class="MsoNormal"><span lang="EN-US"><span style="">&nbsp;</span></span></p>
<p class="MsoNormal"><b style=""><span lang="EN-US">Why can't I debug <span class="SpellE">
RouterService</span> project and Client project in the same time? </span></b></p>
<p class="MsoNormal" style=""><span lang="EN-US">If you debug <span class="SpellE">
RouterService</span> and Client in the same time, the Client application will receive the following error when it calls the service.</span></p>
<p class="MsoNormal" style=""><i style=""><span lang="EN-US">Multiple headers with name '<span class="SpellE">VsDebuggerCausalityData</span>'<br>
and namespace 'http<span class="GramE">:/</span>/schemas.microsoft.com/vstudio/diagnostics/servicemodelsink' found.
</span></i></p>
<p class="MsoNormal" style=""><span lang="EN-US">This happens because when debugging WCF client application (WCF service consumer) in Visual Studio, Visual Studio will append a '<span class="SpellE">VsDebuggerCausalityData</span>' header to the request.
 In this sample, Client sends request to Service Bus and <span class="SpellE">RouterService</span> receives request from Service Bus and sends request to Service. The same request is sent twice, thus, if we debug both Client and
<span class="SpellE">RouterService</span>, the '<span class="SpellE">VsDebuggerCausalityData</span>' header will be appended twice.</span></p>
<p class="MsoNormal" style=""><span lang="EN-US">Solution will be either of following options:</span></p>
<p class="MsoNormal" style=""><span lang="EN-US">1) Do not debug them at the same time, either debug Client project or Service project. That means one of them needs to start up without debugging.</span></p>
<p class="MsoNormal" style=""><span lang="EN-US">2) Temporarily disable debugger support for WCF by running the following command:<br>
<i style="">&quot;C:\Program Files\Microsoft Visual Studio 11.0\Common7\IDE\vsdiag_regwcf.exe&quot; –u<br>
</i>Then we can debug both Client project and Service project. After debugging, you may need to
<span class="SpellE">rollback</span> the change and enable debugger support for WCF:<br>
<i style="">&quot;C:\Program Files\Microsoft Visual Studio 11.0\Common7\IDE\vsdiag_regwcf.exe&quot; –<span class="SpellE">i</span></i></span></p>
<p class="MsoNormal" style=""><span lang="EN-US"></span></p>
<h2><span lang="EN-US">More Information</span></h2>
<p class="MsoNormal" style="line-height:normal"><span lang="EN-US" style=""><a href="http://msdn.microsoft.com/en-us/library/ee732537.aspx">AppFabric Service Bus</a>
</span></p>
<p class="MsoNormal" style="line-height:normal"><span lang="EN-US" style=""><a href="http://msdn.microsoft.com/en-us/gg282251">Introduction to the AppFabric Service Bus &gt; Exercise 1: Getting a Basic Client and Service Working</a>
</span></p>
<p class="MsoNormal" style="line-height:normal"><span lang="EN-US" style=""><a href="http://msdn.microsoft.com/en-us/gg465230">What's New in WCF 4? &gt; Exercise 8: Protocol Bridging</a>
</span></p>
<p class="MsoNormal" style=""><span lang="EN-US"></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

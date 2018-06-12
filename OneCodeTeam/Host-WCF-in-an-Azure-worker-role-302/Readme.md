# Host WCF in an Azure worker role (VBAzureWCFWorkerRole)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* WCF
* Microsoft Azure
## Topics
* Worker Role
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:39:16
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<h2>CLOUD SERVICE : VBAzureWCFWorkerRole Solution Overview</h2>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
In some scenarios we need self-hosting WCF services.If we want to create an HTTP based<br>
service, we should use web role. For a TCP based WCF service however, worker role is a<br>
better choice. Due to the existance of load balancer we need to take care of the logic<br>
and physical listening address. The purpose of this sample is to provide a handy working project<br>
that hosts WCF in a Worker Role.</p>
<div align="right">
<p><a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420"><span style="color:windowtext; text-decoration:none"><span><img src="http://code.msdn.microsoft.com/site/view/file/67654/1/image.png" alt="" width="120" height="90" align="middle">
</span></span></a><br>
<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420">Try Windows Azure for free for 90 Days!</a></p>
</div>
<p style="font-family:Courier New"><br>
<br>
This solution contains three projects:<br>
<br>
1. Client project. It's the client application that consumes WCF services.<br>
2. CloudService project. It's a common Cloud Service that has one Worker Role.<br>
3. VBWorkerRoleHostingWCF project. It's the key project in the solution, which demonstrates<br>
how to host WCF in a Worker Role.<br>
<br>
Two endpoints are exposed from the WCF service in VBWorkerRoleHostingWCF project:<br>
1. A metadata endpoint<br>
2. A service endpoint for MyServiceMetaDataEndpoint service contract<br>
<br>
Both endpoints uses TCP bindings.<br>
<br>
<br>
Pre-requests:<br>
Windows Azure Tools for Microsoft Visual Studio<br>
<a href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=7a1089b6-4050-4307-86c4-9dadaa5ed018" target="_blank">http://www.microsoft.com/downloads/en/details.aspx?FamilyID=7a1089b6-4050-4307-86c4-9dadaa5ed018</a><br>
<br>
</p>
<h3>Code Logic of VBWorkerRoleHostingWCF project:</h3>
<p style="font-family:Courier New"><br>
1. Get local ip address and local listening port of Virtual Machine:<br>
<br>
Dim ip As String = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints(&quot;tcpinput&quot;).IPEndpoint.Address.ToString()<br>
Dim tcpport As Integer = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints(&quot;tcpinput&quot;).IPEndpoint.Port<br>
Dim mexport As Integer = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints(&quot;mexinput&quot;).IPEndpoint.Port<br>
<br>
2. Add a metadata TCP endpoint. The logical listening port is 8001. Client should use this port to request metadata.<br>
The physical port is the mexport we got in step 1.<br>
<br>
Dim metadatabehavior As ServiceMetadataBehavior = New ServiceMetadataBehavior()<br>
host.Description.Behaviors.Add(metadatabehavior)<br>
Dim mexBinding As Binding = MetadataExchangeBindings.CreateMexTcpBinding()<br>
Dim mexlistenurl As String = String.Format(&quot;net.tcp://{0}:{1}/MyServiceMetaDataEndpoint&quot;, ip, mexport)<br>
Dim mexendpointurl As String = String.Format(&quot;net.tcp://{0}:{1}/MyServiceMetaDataEndpoint&quot;, RoleEnvironment.GetConfigurationSettingValue(&quot;Domain&quot;), 8001)<br>
host.AddServiceEndpoint(GetType(IMetadataExchange), mexBinding, mexendpointurl, New Uri(mexlistenurl))<br>
<br>
3. Add a TCP endpoint for MyServiceMetaDataEndpoint.The logical listening port is 9001. Client should use this port to send request.<br>
The physical port is the tcpport we got in step 1.<br>
<br>
Dim listenurl As String = String.Format(&quot;net.tcp://{0}:{1}/MyServiceEndpoint &quot;, ip, tcpport)<br>
Dim endpointurl As String = String.Format(&quot;net.tcp://{0}:{1}/MyServiceEndpoint &quot;, RoleEnvironment.GetConfigurationSettingValue (&quot;Domain&quot;), 9001)<br>
host.AddServiceEndpoint(GetType(IMyServiceMetaDataEndpoint), New NetTcpBinding(SecurityMode.None), endpointurl, New Uri(listenurl))<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
A. In Compute Emulator:<br>
<br>
1. Set CloudService project as Startup project.<br>
2. Press F5 to start debugging.<br>
3. Run Client.exe in Client project or debug Client project.<br>
<br>
Note if you want to create your own proxy class, When you add service reference in your client project,
<br>
the metadata endpoint you input should be net.tcp://localhost:8001/MyServiceMetaDataEndpoint.<br>
<br>
B. After deployment to cloud:<br>
<br>
1.Please change the setting in ServiceConfiguration.cscfg of CloudService project to:<br>
<br>
&nbsp; &nbsp;&lt;Setting name=&quot;Domain&quot; value=&quot;[yourdomain.cloudapp.net]&quot; /&gt;<br>
<br>
2.Please change the setting in app.config of Client project to:<br>
<br>
&lt;client&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;endpoint address=&quot;net.tcp://[yourdomain.cloudapp.net]:9001/MyServiceEndpoint &quot; binding=&quot;netTcpBinding&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;bindingConfiguration=&quot;NetTcpBinding_IMyServiceMetaDataEndpoint&quot; contract=&quot;ServiceReference1.IMyServiceMetaDataEndpoint&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;name=&quot;NetTcpBinding_IMyServiceMetaDataEndpoint&quot; /&gt;<br>
&lt;/client&gt;<br>
<br>
Note the metadata endpoint should be net.tcp://[yourdomain.cloudapp.net]:8001/MyServiceMetaDataEndpoint.</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Service Definition Schema<br>
<a href="http://msdn.microsoft.com/en-us/library/ee758711.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/ee758711.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

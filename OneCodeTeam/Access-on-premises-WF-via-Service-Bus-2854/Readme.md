# Access on-premises WF Services via Service Bus (VBAzureWorkflow4ServiceBus)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* Service Bus
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:47:50
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<h2>Overview</h2>
<p>This sample demonstrates how to expose an on-premises WCF Workflow Service to the Internet using Windows Azure Service Bus. It uses Visual Studio 2010 Beta 2 and WF 4.</p>
<p>While the current version Windows Azure is compiled against .NET 3.5, you can use the assemblies in a .NET4 project.</p>
<p>The workflow in this sample uses the standard ReceiveRequest/SendResponse architecture introduced in WF 4. It compares the service operation's parameter's value with 20, and returns &quot;You've entered a small value.&quot; and &quot;You've entered a large value.&quot;, respectively.
 The client application invokes the Workflow Service twice, passing a value less than 20, and a value greater than 20, respectively.</p>
<div align="right">
<p><a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420"><span style="color:windowtext; text-decoration:none"><span><img src="http://code.msdn.microsoft.com/site/view/file/67654/1/image.png" alt="" width="120" height="90" align="middle">
</span></span></a><br>
<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420">Try Windows Azure for free for 90 Days!</a></p>
</div>
<h2>Prerequisites</h2>
<p>For this sample to work, you must install the Windows Azure&nbsp;SDK. You must also have a valid Windows Azure account. More information about Windows Azure can be found here:
<a href="http://msdn.microsoft.com/en-us/library/ee173584.aspx">http://msdn.microsoft.com/en-us/library/ee173584.aspx</a>.</p>
<h2>Running the Sample</h2>
<p>Configure the web.config file for the the VBAZWorkflow4ServiceBus application:</p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&lt;!--</span><span style="font-size:9.5pt; font-family:Consolas; color:green">
 Replace {issuer name} and {issuer secret} with your credential. </span><span style="font-size:9.5pt; font-family:Consolas; color:blue">--&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#a31515">clientCredentials</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#a31515">sharedSecret</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">
</span><span style="font-size:9.5pt; font-family:Consolas; color:red">issuerName</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=</span><span style="font-size:9.5pt; font-family:Consolas">&quot;<span style="color:blue">{issuer name}</span>&quot;<span style="color:blue">
</span><span style="color:red">issuerSecret</span><span style="color:blue">=</span>&quot;<span style="color:blue">{issuer secret}</span>&quot;<span style="color:blue">/&gt;</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&lt;/</span><span style="font-size:9.5pt; font-family:Consolas; color:#a31515">clientCredentials</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span>&lt;o:p&gt;&lt;/o:p&gt;</p>
<p class="MsoNormal">&lt;o:p&gt;&lt;/o:p&gt;</p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;!--</span><span style="font-size:9.5pt; font-family:Consolas; color:green"> Replace {service namespace} with your service name space.
</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">--&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#a31515">endpoint</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">
</span><span style="font-size:9.5pt; font-family:Consolas; color:red">address</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=</span><span style="font-size:9.5pt; font-family:Consolas">&quot;<span style="color:blue">https://{service namespace}.servicebus.windows.net/ProcessDataWorkflowService</span>&quot;<span style="color:blue">
</span><span style="color:red">binding</span><span style="color:blue">=</span>&quot;<span style="color:blue">basicHttpRelayBinding</span>&quot;<span style="color:blue">
</span><span style="color:red">contract</span><span style="color:blue">=</span>&quot;<span style="color:blue">IProcessDataWorkflowService</span>&quot;<span style="color:blue">/&gt;</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p>Config the Program.vb file for the Client application:</p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:green">' Replace {service namespace} with your service name space.</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Dim</span> address <span style="color:blue">As</span>
<span style="color:blue">New</span> <span style="color:#2b91af">EndpointAddress</span>(<span style="color:#2b91af">ServiceBusEnvironment</span>.CreateServiceUri(<span style="color:#a31515">&quot;https&quot;</span>,
<span style="color:#a31515">&quot;{service namespace}&quot;</span>, <span style="color:#a31515">
&quot;ProcessDataWorkflowService&quot;</span>))&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:green">' Replace {issuer name} and {issuer secret} with your credential.</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>sharedSecretServiceBusCredential.Credentials.SharedSecret.IssuerName = <span style="color:#a31515">
&quot;{issuer name}&quot;</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>sharedSecretServiceBusCredential.Credentials.SharedSecret.IssuerSecret = <span style="color:#a31515">
&quot;{issuer secret}&quot;</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal">Then run the VBAZWorkflow4ServiceBus project. Make sure you've set ProcessDataWorkflowService.xamlx as the start page.</p>
<p class="MsoNormal">Go to https://{service namespace}.servicebus.windows.net/ProcessDataWorkflowService, to verify the service is listed on the Service Bus Registry.</p>
<p>Finally, run the Client project to verify the workflow service works properly.</p>
<h2>Description</h2>
<p>The sample solution contains 2 projects.</p>
<h3>VBAZWorkflow4ServiceBus</h3>
<p>The service project. It is a normal ASP.NET project that hosts a WCF Workflow Service. It then exposes the service to the Internet using Service Bus. Working with Service Bus in IIS or ASP.NET Development Server is the similar working with a self hosted
 service. You must provide the AC credentials for Service Bus to listen the service. To do so, you can create a custom ServiceHostFactory and a custom ServiceHost, and then provide the credentials in code. Alternatively, you can put a transportClientEndpointBehavior
 in web.config, as the sample demonstrates.</p>
<p>When you install the Windows Azure SDK, the machine.config file for .NET 3.5 is updated to include the Service Bus related WCF extensions. However, machine.config for .NET 4 remains untouched. To use the extensions in web/app.config in a .NET 4 application,
 or in a .NET 3.5 application that is hosted on a machine without Windows Azure SDK (such as the Windows Azure cloud environment), you must register the extension elements in the web/app.config.</p>
<p>In addition, the sample includes a ServiceRegistrySettingsElement class, which allows you to configure ServiceRegistrySettings in web/app.config. You must also register it in the WCF extensions section.</p>
<p>If you compare this sample with the VBAZWorkflowService35 sample, you'll see WF 4 contains a much more sophisticated programming model compared to WF 3.5. For example, a separate WFServiceLibrary project is no longer needed. Now a .xamlx file can be hosted
 in the web application directly. In addition, with the introduction of workflow variables, binding service parameters and return values to DependencyProperties is no longer needed.</p>
<p>WCF 4 also introduces a lot of improvements. For example, you can now create behavior configurations without names, which will be automatically applied to all endpoints.</p>
<p>However, this sample focuses on Service Bus rather than WCF and WF. For more information about WCF 4 and WF 4, please refer to
<a href="http://msdn.microsoft.com/en-us/library/dd456779(VS.100).aspx">http://msdn.microsoft.com/en-us/library/dd456779(VS.100).aspx</a> and
<a href="http://msdn.microsoft.com/en-us/library/dd489441(VS.100).aspx">http://msdn.microsoft.com/en-us/library/dd489441(VS.100).aspx</a>, respectively. We may also demonstrate more about WCF 4 and WF 4 in future samples.</p>
<h3>Client</h3>
<p>A console client application that invokes the WCF Workflow Service. In the client application, we demonstrate how to take the code only approch to work with Service Bus. Note by default, when you create a client application (such as Console and WPF), the
 target framework is .NET Framework 4 client profile. In order to work with Service Bus, you must change the target framework to the full .NET Framework 4.</p>
<p>&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

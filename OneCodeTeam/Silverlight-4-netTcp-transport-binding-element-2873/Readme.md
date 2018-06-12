# Silverlight 4 netTcp transport binding element (VBSL4WCFNetTcp)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* WCF
* Silverlight
## Topics
* net.tcp
## IsPublished
* True
## ModifiedDate
* 2011-05-05 10:02:13
## Description

<p style="font-family:Courier New"></p>
<h1>SILVERLIGHT APPLICATION : VBSL4WCFNetTcp Project Overview</h1>
<h2>Use</h2>
<p>Silverlight4 support netTcp transport binding element, which gives us a new choice to implement duplex WCF. In this sample, we create a simple weather report subscription application to demonstrate how to consume netTcp WCF in Silverlight.</p>
<h2>Prerequisites</h2>
<p>Silverlight 4 Tools for Visual Studio 2010<br>
<a href="http://www.microsoft.com/downloads/details.aspx?FamilyID=eff8a0da-0a4d-48e8-8366-6ddf2ecad801&displaylang=en">http://www.microsoft.com/downloads/details.aspx?FamilyID=eff8a0da-0a4d-48e8-8366-6ddf2ecad801&amp;displaylang=en</a></p>
<p>Silverilght 4 runtime<br>
<a href="http://silverlight.net/getstarted/">http://silverlight.net/getstarted/</a></p>
<p>Internet Information Services (IIS) <br>
<a href="http://www.iis.net/">http://www.iis.net/</a></p>
<h2>Creation</h2>
<p>To demonstrate silverlight accessing WCF, we may need a WCF service and a Silverlight WCF client. Here we separate the creation progress into three tasks:</p>
<ol>
<li><a href="#Creating_Duplex_WCF_service_with_netTcp_binding">Creating Duplex WCF service with netTcpBinding</a>
</li><li><a href="#Creating_Silverlight_WCF_client">Creating Silverlight WCF client</a>
</li><li><a href="#Deploying_cross_domain_policy_file">Deploying cross domain policy file</a>
</li></ol>
<h3><a name="Creating_Duplex_WCF_service_with_netTcp_binding">Creating Duplex WCF service with netTcpBinding</a></h3>
<p>1. Create a new console project, add a new WCF Service to project, named WeatherService.
</p>
<p>2. Open IWeatherService.vb, define the service contract like this:</p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas">&lt;<span style="color:#2B91AF">ServiceContract</span>(CallbackContract :=
<span style="color:blue">GetType</span>(<span style="color:#2B91AF">IWeatherServiceCallback</span>))&gt; _&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue">Public</span><span style="font-size:9.5pt; font-family:Consolas">
<span style="color:blue">Interface</span> <span style="color:#2B91AF">IWeatherService</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span>&lt;<span style="color:#2B91AF">OperationContract</span>(IsOneWay:=<span style="color:blue">True</span>)&gt; _&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Sub</span> Subscribe()&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&nbsp;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span>&lt;<span style="color:#2B91AF">OperationContract</span>(IsOneWay:=<span style="color:blue">True</span>)&gt; _&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Sub</span> UnSubscribe()&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue">End</span><span style="font-size:9.5pt; font-family:Consolas">
<span style="color:blue">Interface</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&nbsp;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue">Public</span><span style="font-size:9.5pt; font-family:Consolas">
<span style="color:blue">Interface</span> <span style="color:#2B91AF">IWeatherServiceCallback</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span>&lt;<span style="color:#2B91AF">OperationContract</span>(IsOneWay:=<span style="color:blue">True</span>)&gt; _&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Sub</span> WeatherReport(<span style="color:blue">ByVal</span> report
<span style="color:blue">As</span> <span style="color:blue">String</span>)&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue">End</span><span style="font-size:9.5pt; font-family:Consolas">
<span style="color:blue">Interface&lt;o:p&gt;&lt;/o:p&gt;</span></span></p>
<p>3. Open WeatherService.vb. We use static event approach to implement subscription service. Please remember to set service InstanceContextMode to
<em>PerSession</em>.</p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas">&lt;<span style="color:#2B91AF">ServiceBehavior</span>(InstanceContextMode :=
<span style="color:#2B91AF">InstanceContextMode</span>.PerSession)&gt; _&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue">Public</span><span style="font-size:9.5pt; font-family:Consolas">
<span style="color:blue">Class</span> <span style="color:#2B91AF">WeatherService</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Implements</span> <span style="color:#2B91AF">IWeatherService</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&nbsp;&lt;/o:p&gt;&lt;o:p&gt;&nbsp;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Private</span> <span style="color:blue">Shared</span>
<span style="color:blue">Event</span> WeatherReporting <span style="color:blue">As</span>
<span style="color:#2B91AF">EventHandler</span>(<span style="color:blue">Of</span>
<span style="color:#2B91AF">WeatherEventArgs</span>)&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Private</span> _callback <span style="color:blue">
As</span> <span style="color:#2B91AF">IWeatherServiceCallback</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&nbsp;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Public</span> <span style="color:blue">Sub</span> Subscribe()
<span style="color:blue">Implements</span> <span style="color:#2B91AF">IWeatherService</span>.Subscribe&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>_callback = <span style="color:#2B91AF">OperationContext</span>.Current.GetCallbackChannel(<span style="color:blue">Of</span>
<span style="color:#2B91AF">IWeatherServiceCallback</span>)()&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">AddHandler</span> WeatherReporting, <span style="color:blue">
New</span> <span style="color:#2B91AF">EventHandler</span>(<span style="color:blue">Of</span>
<span style="color:#2B91AF">WeatherEventArgs</span>)(<span style="color:blue">AddressOf</span> WeatherService_WeatherReporting)&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">End</span> <span style="color:blue">Sub</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&nbsp;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Public</span> <span style="color:blue">Sub</span> UnSubscribe()
<span style="color:blue">Implements</span> <span style="color:#2B91AF">IWeatherService</span>.UnSubscribe&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">RemoveHandler</span> WeatherReporting, <span style="color:blue">
New</span> <span style="color:#2B91AF">EventHandler</span>(<span style="color:blue">Of</span>
<span style="color:#2B91AF">WeatherEventArgs</span>)(<span style="color:blue">AddressOf</span> WeatherService_WeatherReporting)&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">End</span> <span style="color:blue">Sub</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&nbsp;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Private</span> <span style="color:blue">Sub</span> WeatherService_WeatherReporting(<span style="color:blue">ByVal</span> sender
<span style="color:blue">As</span> <span style="color:blue">Object</span>, <span style="color:blue">
ByVal</span> e <span style="color:blue">As</span> <span style="color:#2B91AF">WeatherEventArgs</span>)&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:green">&#39; Remember check the callback channel&#39;s status before using it.</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">If</span> <span style="color:blue">DirectCast</span>(_callback,
<span style="color:#2B91AF">ICommunicationObject</span>).State = <span style="color:#2B91AF">
CommunicationState</span>.Opened <span style="color:blue">Then</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>_callback.WeatherReport(e.WeatherReport)&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Else</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>UnSubscribe()&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">End</span> <span style="color:blue">If</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">End</span> <span style="color:blue">Sub</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&nbsp;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue">End</span><span style="font-size:9.5pt; font-family:Consolas">
<span style="color:blue">Class</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&nbsp;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue">Class</span><span style="font-size:9.5pt; font-family:Consolas">
<span style="color:#2B91AF">WeatherEventArgs</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Inherits</span> <span style="color:#2B91AF">EventArgs</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Public</span> <span style="color:blue">Property</span> WeatherReport()
<span style="color:blue">As</span> <span style="color:blue">String</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Get</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Return</span> m_WeatherReport&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">End</span> <span style="color:blue">Get</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Set</span>(<span style="color:blue">ByVal</span> value
<span style="color:blue">As</span> <span style="color:blue">String</span>)&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>m_WeatherReport = Value&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">End</span> <span style="color:blue">Set</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">End</span> <span style="color:blue">Property</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Private</span> m_WeatherReport <span style="color:blue">
As</span> <span style="color:blue">String</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue">End</span><span style="font-size:9.5pt; font-family:Consolas">
<span style="color:blue">Class&lt;o:p&gt;&lt;/o:p&gt;</span></span></p>
<p class="MsoNormal">&lt;o:p&gt;&nbsp;&lt;/o:p&gt;</p>
<p>4. Create a separate thread to generate fake weather report periodically.</p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;</span></span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Shared</span> <span style="color:blue">Sub</span>
<span style="color:blue">New</span>()&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:green">&#39; Creating a separate thread to generate fake</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:green">&#39; weather report periodically.</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:#2B91AF">ThreadPool</span>.QueueUserWorkItem(<span style="color:blue">New</span>
<span style="color:#2B91AF">WaitCallback</span>(<span style="color:blue">AddressOf</span> CreateWeatherReport))&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">End</span> <span style="color:blue">Sub</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&nbsp;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Private</span> <span style="color:blue">Shared</span>
<span style="color:blue">Sub</span> CreateWeatherReport()&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Dim</span> weatherArray <span style="color:blue">
As</span> <span style="color:blue">String</span>() = {<span style="color:#A31515">&quot;Sunny&quot;</span>,
<span style="color:#A31515">&quot;Windy&quot;</span>, <span style="color:#A31515">
&quot;Snow&quot;</span>, <span style="color:#A31515">&quot;Rainy&quot;</span>}&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Dim</span> rand <span style="color:blue">As</span>
<span style="color:blue">New</span> <span style="color:#2B91AF">Random</span>()&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&nbsp;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">While</span> <span style="color:blue">True</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:#2B91AF">Thread</span>.Sleep(1000)&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">RaiseEvent</span> WeatherReporting(<span style="color:blue">Nothing</span>,
<span style="color:blue">New</span> <span style="color:#2B91AF">WeatherEventArgs</span>()
<span style="color:blue">With</span> { _&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>.WeatherReport = weatherArray(rand.[Next](weatherArray.Length)) _&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>})&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">End</span> <span style="color:blue">While</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">End</span> <span style="color:blue">Sub</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p>5. Configure the app.config file to add netTcpbinding endpoint to WCF service.
</p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">system.serviceModel</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">behaviors</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">serviceBehaviors</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">behavior</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">
</span><span style="font-size:9.5pt; font-family:Consolas; color:red">name</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=</span><span style="font-size:9.5pt; font-family:Consolas">&quot;<span style="color:blue">NetTcpWCFService.WeatherServiceBehavior</span>&quot;<span style="color:blue">&gt;</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">serviceMetadata</span><span style="font-size:9.5pt; font-family:Consolas; color:blue"> /&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">serviceDebug</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">
</span><span style="font-size:9.5pt; font-family:Consolas; color:red">includeExceptionDetailInFaults</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=</span><span style="font-size:9.5pt; font-family:Consolas">&quot;<span style="color:blue">false</span>&quot;<span style="color:blue">
 /&gt;</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;/</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">behavior</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;/</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">serviceBehaviors</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;/</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">behaviors</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">services</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">service</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">
</span><span style="font-size:9.5pt; font-family:Consolas; color:red">behaviorConfiguration</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=</span><span style="font-size:9.5pt; font-family:Consolas">&quot;<span style="color:blue">NetTcpWCFService.WeatherServiceBehavior</span>&quot;&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span style="font-size:9.5pt; font-family:Consolas; color:red">name</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=</span><span style="font-size:9.5pt; font-family:Consolas">&quot;<span style="color:blue">NetTcpWCFService.WeatherService</span>&quot;<span style="color:blue">&gt;</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">endpoint</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">
</span><span style="font-size:9.5pt; font-family:Consolas; color:red">address</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=</span><span style="font-size:9.5pt; font-family:Consolas">&quot;&quot;<span style="color:blue">
</span><span style="color:red">binding</span><span style="color:blue">=</span>&quot;<span style="color:blue">netTcpBinding</span>&quot;<span style="color:blue">
</span><span style="color:red">bindingConfiguration</span><span style="color:blue">=</span>&quot;<span style="color:blue">b1</span>&quot;&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span style="font-size:9.5pt; font-family:Consolas; color:red">contract</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=</span><span style="font-size:9.5pt; font-family:Consolas">&quot;<span style="color:blue">NetTcpWCFService.IWeatherService</span>&quot;<span style="color:blue">
 /&gt;</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">endpoint</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">
</span><span style="font-size:9.5pt; font-family:Consolas; color:red">address</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=</span><span style="font-size:9.5pt; font-family:Consolas">&quot;<span style="color:blue">mex</span>&quot;<span style="color:blue">
</span><span style="color:red">binding</span><span style="color:blue">=</span>&quot;<span style="color:blue">mexTcpBinding</span>&quot;<span style="color:blue">
</span><span style="color:red">contract</span><span style="color:blue">=</span>&quot;<span style="color:blue">IMetadataExchange</span>&quot;<span style="color:blue"> /&gt;</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">host</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">baseAddresses</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">add</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">
</span><span style="font-size:9.5pt; font-family:Consolas; color:red">baseAddress</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=</span><span style="font-size:9.5pt; font-family:Consolas">&quot;<span style="color:blue">net.tcp://localhost:4504/WeatherService</span>&quot;<span style="color:blue">
 /&gt;</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;/</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">baseAddresses</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;/</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">host</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;/</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">service</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;/</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">services</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">bindings</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">netTcpBinding</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">binding</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">
</span><span style="font-size:9.5pt; font-family:Consolas; color:red">name</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=</span><span style="font-size:9.5pt; font-family:Consolas">&quot;<span style="color:blue">b1</span>&quot;<span style="color:blue">&gt;</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">security</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">
</span><span style="font-size:9.5pt; font-family:Consolas; color:red">mode</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=</span><span style="font-size:9.5pt; font-family:Consolas">&quot;<span style="color:blue">None</span>&quot;<span style="color:blue">/&gt;</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;/</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">binding</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;/</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">netTcpBinding</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;/</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">bindings</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;
</span>&lt;/</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">system.serviceModel</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="auto-style1"><em>Note that, only a few ports are allowed to be accessed by Silverlight, that is 4502-4534, and we need client access policy file to permit Silverlight access, please refer to
<a href="#Deploying_cross_domain_policy_file">Deploying cross domain policy file</a></em></p>
<p>6. Start the ServiceHost in Main method</p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;
</span><span style="color:blue">Sub</span> Main()&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Using</span> host = <span style="color:blue">New</span>
<span style="color:#2B91AF">ServiceHost</span>(<span style="color:blue">GetType</span>(<span style="color:#2B91AF">WeatherService</span>))&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>host.Open()&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:#2B91AF">Console</span>.WriteLine(<span style="color:#A31515">&quot;Service is running...&quot;</span>)&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:#2B91AF">Console</span>.WriteLine(<span style="color:#A31515">&quot;Service address: &quot;</span> &#43; host.BaseAddresses(0).AbsoluteUri)&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:#2B91AF">Console</span>.Read()&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">End</span> <span style="color:blue">Using</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">End</span> <span style="color:blue">Sub&lt;o:p&gt;&lt;/o:p&gt;</span></span></p>
<h3>&nbsp;</h3>
<h3><a name="Creating_Silverlight_WCF_client">Creating Silverlight WCF client</a></h3>
<p>Now, create Silverlight application to consume the WCF. We need one button to subscribe/unsubscribe servicie, and one listbox to display the weather report from service.</p>
<p><img alt="Silverlight application UI layout" height="322" src="images/sl_layout.jpg" width="433"></p>
<p>1. Create a new Silverlight project.</p>
<p>2. Open MainPage.xaml, Add Button, TextBlock and ListBox to MainPage and adjust layout.</p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:#A31515"><span style="">&nbsp;
</span></span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">Grid</span><span style="font-size:9.5pt; font-family:Consolas; color:red"> x</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">:</span><span style="font-size:9.5pt; font-family:Consolas; color:red">Name</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=&quot;LayoutRoot&quot;</span><span style="font-size:9.5pt; font-family:Consolas; color:red">
 Background</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=&quot;White&quot;&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:#A31515"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">Grid.RowDefinitions</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:#A31515"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">RowDefinition</span><span style="font-size:9.5pt; font-family:Consolas; color:red"> Height</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=&quot;46*&quot;
 /&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:#A31515"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">RowDefinition</span><span style="font-size:9.5pt; font-family:Consolas; color:red"> Height</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=&quot;26*&quot;
 /&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:#A31515"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">RowDefinition</span><span style="font-size:9.5pt; font-family:Consolas; color:red"> Height</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=&quot;228*&quot;
 /&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:#A31515"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&lt;/</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">Grid.RowDefinitions</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:#A31515"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">TextBlock</span><span style="font-size:9.5pt; font-family:Consolas; color:red"> Text</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=&quot;Silverlight
 NetTcp Sample&quot;</span><span style="font-size:9.5pt; font-family:Consolas; color:red"> Grid.Row</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=&quot;0&quot;</span><span style="font-size:9.5pt; font-family:Consolas; color:red"> Margin</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=&quot;0,0,0,10&quot;</span><span style="font-size:9.5pt; font-family:Consolas; color:red">
 FontSize</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=&quot;24&quot;/&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:#A31515"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">StackPanel</span><span style="font-size:9.5pt; font-family:Consolas; color:red"> Orientation</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=&quot;Horizontal&quot;</span><span style="font-size:9.5pt; font-family:Consolas; color:red">
 Grid.Row</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=&quot;1&quot;&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:#A31515"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">Button</span><span style="font-size:9.5pt; font-family:Consolas; color:red"> Content</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=&quot;Subscribe
 weather report&quot;</span><span style="font-size:9.5pt; font-family:Consolas; color:red"> Name</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=&quot;btnSubscribe&quot;</span><span style="font-size:9.5pt; font-family:Consolas; color:red">
 Click</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=&quot;Button_Click&quot;/&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:#A31515"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">TextBlock</span><span style="font-size:9.5pt; font-family:Consolas; color:red"> VerticalAlignment</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=&quot;Center&quot;</span><span style="font-size:9.5pt; font-family:Consolas; color:red">
 FontStyle</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=&quot;Italic&quot;</span><span style="font-size:9.5pt; font-family:Consolas; color:red"> Foreground</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=&quot;Red&quot;</span><span style="font-size:9.5pt; font-family:Consolas; color:red">
 Margin</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=&quot;5,0,0,0&quot;</span><span style="font-size:9.5pt; font-family:Consolas; color:red"> Name</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=&quot;tbInfo&quot;/&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:#A31515"><span style="">&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&lt;/</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">StackPanel</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:#A31515"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">ListBox</span><span style="font-size:9.5pt; font-family:Consolas; color:red"> Name</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=&quot;lbWeather&quot;</span><span style="font-size:9.5pt; font-family:Consolas; color:red">
 Grid.Row</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=&quot;2&quot;</span><span style="font-size:9.5pt; font-family:Consolas; color:red"> Margin</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=&quot;0,5,0,0&quot;/&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:#A31515"><span style="">&nbsp;&nbsp;&nbsp;
</span></span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&lt;/</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">Grid</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal">&lt;o:p&gt;&nbsp;&lt;/o:p&gt;</p>
<p>3. Add Service Reference to our “weatherService” WCF service. To do this: First, set NetTcpWCFService project as startup project, press Ctrl&#43;F5 to start the service. Then, right click &nbsp;Silverlight project, select “Add Service Reference”, in dialog,
 input the weather service address, and press OK. After done this, VS would generate wcf proxy code in Silverlight project.
</p>
<p>4. Open MainPage.vb file, Initialize the WCF proxy in Loaded event</p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue">Partial</span><span style="font-size:9.5pt; font-family:Consolas">
<span style="color:blue">Public</span> <span style="color:blue">Class</span> <span style="color:#2B91AF">
MainPage</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Inherits</span> <span style="color:#2B91AF">UserControl</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Implements</span> <span style="color:#2B91AF">IWeatherServiceCallback</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Public</span> <span style="color:blue">Sub</span>
<span style="color:blue">New</span>()&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>InitializeComponent()&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">AddHandler</span> <span style="color:blue">Me</span>.Loaded,
<span style="color:blue">AddressOf</span> MainPage_Loaded&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">End</span> <span style="color:blue">Sub</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&nbsp;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Private</span> _client <span style="color:blue">As</span>
<span style="color:#2B91AF">WeatherServiceClient</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Private</span> <span style="color:blue">Sub</span> MainPage_Loaded(<span style="color:blue">ByVal</span> sender
<span style="color:blue">As</span> <span style="color:blue">Object</span>, <span style="color:blue">
ByVal</span> e <span style="color:blue">As</span> <span style="color:#2B91AF">RoutedEventArgs</span>)&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>_client = <span style="color:blue">New</span> <span style="color:#2B91AF">
WeatherServiceClient</span>(<span style="color:blue">New</span> System.ServiceModel.InstanceContext(<span style="color:blue">Me</span>))&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">AddHandler</span> _client.SubscribeCompleted, <span style="color:blue">
AddressOf</span> _client_SubscribeCompleted&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">AddHandler</span> _client.UnSubscribeCompleted, <span style="color:blue">
AddressOf</span> _client_UnSubscribeCompleted&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">End</span> <span style="color:blue">Sub</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&nbsp;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Private</span> <span style="color:blue">Sub</span> _client_UnSubscribeCompleted(<span style="color:blue">ByVal</span> sender
<span style="color:blue">As</span> <span style="color:blue">Object</span>, <span style="color:blue">
ByVal</span> e <span style="color:blue">As</span> System.ComponentModel.AsyncCompletedEventArgs)&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">If</span> e.[Error] <span style="color:blue">Is</span>
<span style="color:blue">Nothing</span> <span style="color:blue">Then</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>_subscribed = <span style="color:blue">False</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>btnSubscribe.Content = <span style="color:#A31515">&quot;Subscribe weather report&quot;</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>tbInfo.Text = <span style="color:#A31515">&quot;&quot;</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Else</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>tbInfo.Text = <span style="color:#A31515">&quot;Unable to connect to service.&quot;</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">End</span> <span style="color:blue">If</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>btnSubscribe.IsEnabled = <span style="color:blue">True</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">End</span> <span style="color:blue">Sub</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&nbsp;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Private</span> <span style="color:blue">Sub</span> _client_SubscribeCompleted(<span style="color:blue">ByVal</span> sender
<span style="color:blue">As</span> <span style="color:blue">Object</span>, <span style="color:blue">
ByVal</span> e <span style="color:blue">As</span> System.ComponentModel.AsyncCompletedEventArgs)&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">If</span> e.[Error] <span style="color:blue">Is</span>
<span style="color:blue">Nothing</span> <span style="color:blue">Then</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>_subscribed = <span style="color:blue">True</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>btnSubscribe.Content = <span style="color:#A31515">&quot;UnSubscribe weather report&quot;</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>tbInfo.Text = <span style="color:#A31515">&quot;&quot;</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Else</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>tbInfo.Text = <span style="color:#A31515">&quot;Unable to connect to service.&quot;</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">End</span> <span style="color:blue">If</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>btnSubscribe.IsEnabled = <span style="color:blue">True</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp; &nbsp;</span><span style="color:blue">End</span>
<span style="color:blue">Sub</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&nbsp;&lt;/o:p&gt;&lt;o:p&gt;&nbsp;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:green">&#39; Display report when callback channel get called.</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Public</span> <span style="color:blue">Sub</span> WeatherReport(<span style="color:blue">ByVal</span> report
<span style="color:blue">As</span> <span style="color:blue">String</span>) <span style="color:blue">
Implements</span> <span style="color:#2B91AF">IWeatherServiceCallback</span>.WeatherReport&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>lbWeather.Items.Insert(0, <span style="color:blue">New</span> <span style="color:#2B91AF">
ListBoxItem</span>() <span style="color:blue">With</span> { _&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>.Content = <span style="color:blue">String</span>.Format(<span style="color:#A31515">&quot;{0} {1}&quot;</span>, DateTime.Now, report) _&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>})&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">End</span> <span style="color:blue">Sub</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue">End</span><span style="font-size:9.5pt; font-family:Consolas">
<span style="color:blue">Class&lt;o:p&gt;&lt;/o:p&gt;</span></span></p>
<p class="MsoNormal">&nbsp;</p>
<p>5. Add event handler to handle button click event</p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;</span></span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Private</span> _subscribed <span style="color:blue">
As</span> <span style="color:blue">Boolean</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Private</span> <span style="color:blue">Sub</span> Button_Click(<span style="color:blue">ByVal</span> sender
<span style="color:blue">As</span> <span style="color:blue">Object</span>, <span style="color:blue">
ByVal</span> e <span style="color:blue">As</span> <span style="color:#2B91AF">RoutedEventArgs</span>)&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">If</span> <span style="color:blue">Not</span> _subscribed
<span style="color:blue">Then</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>_client.SubscribeAsync()&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">Else</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>_client.UnSubscribeAsync()&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">End</span> <span style="color:blue">If</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>btnSubscribe.IsEnabled = <span style="color:blue">False</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas"><span style="">&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">End</span> <span style="color:blue">Sub</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p>Now, the Silverlight WCF Client is completed. We have one last task to permit the Silverlight access.</p>
<h3><a name="Deploying_cross_domain_policy_file">Deploying cross domain policy file</a></h3>
<p>1. Create a xml file, named &quot;clientaccesspolicy.xml&quot;, set content as below</p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue">&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">access-policy</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;
</span>&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">cross-domain-access</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">policy</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">allow-from</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">domain</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">
</span><span style="font-size:9.5pt; font-family:Consolas; color:red">uri</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=</span><span style="font-size:9.5pt; font-family:Consolas">&quot;<span style="color:blue">*</span>&quot;<span style="color:blue">/&gt;</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;/</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">allow-from</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">grant-to</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">socket-resource</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">
</span><span style="font-size:9.5pt; font-family:Consolas; color:red">port</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">=</span><span style="font-size:9.5pt; font-family:Consolas">&quot;<span style="color:blue">4502-4506</span>&quot;<span style="color:blue">
</span><span style="color:red">protocol</span><span style="color:blue">=</span>&quot;<span style="color:blue">tcp</span>&quot;<span style="color:blue"> /&gt;</span>&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;/</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">grant-to</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;&nbsp;&nbsp;
</span>&lt;/</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">policy</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue"><span style="">&nbsp;
</span>&lt;/</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">cross-domain-access</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; font-family:Consolas; color:blue">&lt;/</span><span style="font-size:9.5pt; font-family:Consolas; color:#A31515">access-policy</span><span style="font-size:9.5pt; font-family:Consolas; color:blue">&gt;</span><span style="font-size:9.5pt; font-family:Consolas">&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p>This file grant permissions to allow Silverlight clients from any domian to access server&#39;s 4502-4506 port</p>
<p>2. Find out the server web site&#39;s root physical path (by default, C:\inetpub\wwwroot), place the policy file in that folder. To verify the deployment, browse
<a href="http://localhost/clientaccesspolicy.xml">http://localhost/clientaccesspolicy.xml</a>, check if you could see the policy xml content.</p>
<h2>Demo</h2>
<p>To test the project</p>
<p>1. Open VBSL4WCFNetTcp solution, build.</p>
<p>2. Follow Creation step &quot;<a href="#Deploying_cross_domain_policy_file">Deploying cross domain policy file</a>&quot; to config your IIS, make sure that you can get cross-domain xml by visiting
<a href="http://localhost/clientaccesspolicy.xml">http://localhost/clientaccesspolicy.xml</a> in your browser, if the wcf server is on the other computer, then try
<a href="http://localhost/clientaccesspolicy.xml">http://[wcf-server-computer-name]/clientaccesspolicy.xml</a>
</p>
<p>3. Start the duplex WCF. Run NetTcpWCFService.exe, it&#39;s under VBSL4WCFNetTcp\Debug folder.</p>
<p><img alt="Self hosted wcf" height="105" src="images/service_console.jpg" width="666"></p>
<p>4. Right click &quot;VBSL4WCFNetTcpTestPage.aspx&quot; in VS, Select &quot;View in Browser&quot;.
</p>
<p>5. When Silverlight application loaded, click &quot;subscribe&quot; button, if all code and configuration are correct, you may find the listbox displaying a new record in each second.</p>
<p><img alt="Silverlight application running" height="406" src="images/sl_run.jpg" width="412">&nbsp;</p>
<h2>References</h2>
<p>Building and Accessing Duplex Services<br>
<a href="http://msdn.microsoft.com/en-us/library/cc645026(VS.95).aspx">http://msdn.microsoft.com/en-us/library/cc645026(VS.95).aspx</a></p>
<p>Network Security Access Restrictions in Silverlight<br>
<a href="http://msdn.microsoft.com/en-us/library/cc645026(VS.95).aspx">http://msdn.microsoft.com/en-us/library/cc645026(VS.95).aspx</a></p>
<p>&nbsp;</p>
<p></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
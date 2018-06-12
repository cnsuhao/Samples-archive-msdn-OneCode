# Access on-premises WCF service via Azure Service Bus (CSAzureServiceBusSLRest)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Silverlight
* Microsoft Azure
## Topics
* Service Bus
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:24:51
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<h2>Overview</h2>
<p>This sample demonstrates how to expose an on-premises WCF service to an internet Silverlight client using Windows Azure Service Bus. The sample creates a WCF REST Service. But you can work with other types of WCF services using the same technique.</p>
<div align="right">
<p><a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420"><span style="color:windowtext; text-decoration:none"><span><img src="http://code.msdn.microsoft.com/site/view/file/67654/1/image.png" alt="" width="120" height="90" align="middle">
</span></span></a><br>
<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420">Try Windows Azure for free for 90 Days!</a></p>
</div>
<h2>Prerequests</h2>
<p>For this sample to work, you must install the Windows Azure SDK. You must also have a valid Windows Azure account. More information about Windows Azure can be found here:
<a href="http://msdn.microsoft.com/en-us/library/ee173584.aspx">http://msdn.microsoft.com/en-us/library/ee173584.aspx</a>.</p>
<h2>Running the Sample</h2>
<p>Please make sure the &quot;ServiceBus&quot; project is set as the starting project of the solution, if not already.</p>
<p>Modify the app.config file in the ServiceBus project. You need to make 2 changes:</p>
<p class="MsoNormal"><span style="font-size:10.0pt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;!--</span><span style="font-size:10.0pt"> Change to your namespace. </span>
<span style="font-size:10.0pt">--&gt;&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:10.0pt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:10.0pt">add</span><span style="font-size:10.0pt">
</span><span style="font-size:10.0pt">key</span><span style="font-size:10.0pt">=</span><span style="font-size:10.0pt">&quot;<span style="color:blue">serviceNamespace</span>&quot;<span style="color:blue">
</span><span style="color:red">value</span><span style="color:blue">=</span>&quot;<span style="color:blue">[namespace]</span>&quot;<span style="color:blue">/&gt;&lt;o:p&gt;&lt;/o:p&gt;</span></span></p>
<p>&nbsp;</p>
<p class="MsoNormal"><span style="font-size:10.0pt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;!--</span><span style="font-size:10.0pt"> Change [name] to your issuer name (by default it should be &quot;owner&quot;), and change [key] to your issuer secret.
</span><span style="font-size:10.0pt">--&gt;&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:10.0pt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:10.0pt">sharedSecret</span><span style="font-size:10.0pt">
</span><span style="font-size:10.0pt">issuerName</span><span style="font-size:10.0pt">=</span><span style="font-size:10.0pt">&quot;<span style="color:blue">[name]</span>&quot;<span style="color:blue">
</span><span style="color:red">issuerSecret</span><span style="color:blue">=</span>&quot;<span style="color:blue">[key]</span>&quot;<span style="color:blue"> /&gt;&lt;o:p&gt;&lt;/o:p&gt;</span></span></p>
<p>Running the service application, and wait until you see information like &quot;The WCF REST service is being listened on...&quot; in the console. This indicates the service has been started.</p>
<p>Now if you like, you can open a browser, and navigate to <a href="https://namespace.servicebus.windows.net/clientaccesspolicy.xml">
https://namespace.servicebus.windows.net/clientaccesspolicy.xml</a> to verify the Silverlight cross domain policy file is being served correctly.</p>
<p>Before running the Silverlight client, please modify MainPage.xaml.cs in the Client project:</p>
<p class="MsoNormal"><span style="font-size:10.0pt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:green">// Change to your namespace.&lt;o:p&gt;&lt;/o:p&gt;</span></span></p>
<p class="MsoNormal"><span style="font-size:10.0pt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:blue">private</span> <span style="color:blue">const</span>
<span style="color:blue">string</span> ServiceNamespace = <span style="color:#a31515">
&quot;[namespace]&quot;</span>;&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p>Now set Client.Web as the starting project of the solution (important, it is Client.Web, not Client), and run it. You will see a Silverlight client that allows you to upload/download files.</p>
<p>After clicking the Upload File Button, wait until you see a message box telling you the file has been uploaded successfully. Then open the \ServiceBus\bin\Debug folder in Windows Explorer, and you should see the file has been uploaded to the folder. In this
 step, we've invoked a WCF REST Service using POST.</p>
<p>Make sure you've typed the correct file name in the TextBox, and click the Download File Button. Wait until you see a message box telling you the file has been downloaded successfully. Then open the folder in which you chose to save the downloaded file,
 and you'll see the file downloaded successfully. In this step, we've invoked a WCF REST Service using GET.</p>
<p>Other HTTP verbs are not demonstrated in this sample, but the usage is similar.</p>
<h2>Description</h2>
<p>The sample solution contains 3 projects.</p>
<h3>ServiceBus</h3>
<p>A console project that hosts the WCF REST Service, and exposes it to the internet using Service Bus. Please make sure to set this project as the starting project of the solution.</p>
<p>In order for a normal Silverlight client (not elevated OOB) to work with a web service on a different domain, a cross domain policy file must be served. To do this in a self-hosted WCF application, we can create a WCF REST service with a UriTemplate as &quot;/clientaccesspolicy.xml&quot;:</p>
<p class="MsoNormal"><span style="font-size:10.0pt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>[<span style="color:#2b91af">OperationContractct</span>, <span style="color:#2b91af">
WebGet</span>(UriTemplate = <span style="color:#a31515">&quot;/clientaccesspolicy.xml&quot;</span>)]&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:10.0pt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="color:#2b91af">Stream</span> GetClientAccessPolicy();&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p>This way, the GetClientAccessPolicy resouce can be obtained with an HTTP GET request:</p>
<p><a href="https://namespace.servicebus.windows.net/clientaccesspolicy.xml">https://namespace.servicebus.windows.net/clientaccesspolicy.xml</a></p>
<p>By default, WebHttpRelayBinding uses transport security to protect your Service Bus credentials. This behavior is different from a normal WebHttpBinding. So by default, we must use the https protocol. You can of course set security mode to None to use http.</p>
<p>In addition, at this time, Access Control (which is by default imposed on client applications that connect to Service Bus) does not have cross domain capabilities. So you have to turn off Access Control in order to serve a Silverlight client.</p>
<p class="MsoNormal"><span style="font-size:10.0pt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;!--</span><span style="font-size:10.0pt"> Turn off client authentication so that the Silverlight client does not need to present credential.
</span><span style="font-size:10.0pt">--&gt;&lt;o:p&gt;&lt;/o:p&gt;</span></p>
<p class="MsoNormal"><span style="font-size:10.0pt"><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;</span><span style="font-size:10.0pt">security</span><span style="font-size:10.0pt">
</span><span style="font-size:10.0pt">relayClientAuthenticationType</span><span style="font-size:10.0pt">=</span><span style="font-size:10.0pt">&quot;<span style="color:blue">None</span>&quot;<span style="color:blue"> /&gt;&lt;o:p&gt;&lt;/o:p&gt;</span></span></p>
<p>The next version of Access Control may provide cross domain capability out of box, so you can connect to a AC protected Service Bus directly from a Silverlight client. An early preview is availabe on
<a href="https://portal.appfabriclabs.com/">https://portal.appfabriclabs.com/</a>. Please note you should not use the preview in production environments.</p>
<p>Other code of this project does not have many differences with a normal WCF REST Services project. We may release samples on how to build normal WCF services in the future, which serve as the pre-requests of this sample. So we will not discuss further about
 WCF in this document.</p>
<h3>Client</h3>
<p>A Silverlight 3 client project that allows you to test the services. Please refer to the &quot;Running the Sample&quot; section on how to use it.</p>
<h3>Client.Web</h3>
<p>A web application that hosts the Silverlight client. In order for a Silverlight application to work with internet resources, it must be hosted in a web application using http(s) scheme. Otherwise you'll run into a cross scheme issue (except for elevated
 OOB). When testing the client, please make sure to run Client.Web rather than Client.</p>
<p>&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

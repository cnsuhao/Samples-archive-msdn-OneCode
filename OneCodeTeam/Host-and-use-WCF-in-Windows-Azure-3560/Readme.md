# Host and use WCF Services in Windows Azure (VBAzureWCFServices)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* WCF
* Microsoft Azure
## Topics
* WCF Service
* WorkerRole
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:39:43
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<h2>VBAzureWCFServices Overview</h2>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
This project shows how to host WCF in Windows Azure, and how to consume it. <br>
It includes<br>
<br>
1) A WCF web role , which hosts WCF in IIS;<br>
2) A work role which hosts a WCF service (self-hosting); and <br>
3) A windows console client that consumes the WCF services above.<br>
<br>
The client application talks to the web role via http protocol defined as an <br>
input endpoint. &nbsp;The client application also talks to the work role directly
<br>
via tcp protocol defined as an input point. This demonstrates how to expose <br>
an Azure worker role to an external connection from the internet. &nbsp;The web <br>
role talks to the worker role via tcp protocol defined in an internal end <br>
point, to demonstrate the inter-role communication within an Azure hosted <br>
service.</p>
<div align="right">
<p><a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420"><span style="color:windowtext; text-decoration:none"><span><img src="http://code.msdn.microsoft.com/site/view/file/67654/1/image.png" alt="" width="120" height="90" align="middle">
</span></span></a><br>
<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420">Try Windows Azure for free for 90 Days!</a></p>
</div>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
To use the Sample, please follow the steps below.<br>
<br>
Step 1: Make sure your Azure development environment and Azure account are <br>
&nbsp; &nbsp; &nbsp; &nbsp;ready. You can get the latest Windows Azure SDK from <br>
&nbsp; &nbsp; &nbsp; &nbsp;<a href="http://www.microsoft.com/windowsazure/sdk/." target="_blank">http://www.microsoft.com/windowsazure/sdk/.</a> &nbsp;<br>
<br>
Step 2: Open VBCSAzureWCFServices.sln. Rebuild it and make sure there's no <br>
&nbsp; &nbsp; &nbsp; &nbsp;error.<br>
<br>
Step 3: Expand project WindowsAzureProject1-&gt;roles. double click on each role <br>
&nbsp; &nbsp; &nbsp; &nbsp;to check the settings. Change settings-&gt; <br>
&nbsp; &nbsp; &nbsp; &nbsp;Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString to your
<br>
&nbsp; &nbsp; &nbsp; &nbsp;own Azure storage account;<br>
<br>
Step 4: Publish WindowsAzureProject1 project. You can directly publish it to <br>
&nbsp; &nbsp; &nbsp; &nbsp;your existing hosted service, or create a deployment package only,
<br>
&nbsp; &nbsp; &nbsp; &nbsp;then manually deploy it via the windows azure management console.
<br>
&nbsp; &nbsp; &nbsp; &nbsp;[NOTE: If you run this sample on local emulation environment,
<br>
&nbsp; &nbsp; &nbsp; &nbsp;sometimes you may receive an error like this: <br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&quot;Windows Azure Diagnostics Agent has stopped working.&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;when you launch the project. &nbsp;Here is a thread about this issue:<br>
&nbsp; &nbsp; &nbsp; &nbsp;<a href="http://social.msdn.microsoft.com/Forums/en/windowsazuretroubleshooting/thread/10d25b51-be08-48bf-b661-340dc380fcc7" target="_blank">http://social.msdn.microsoft.com/Forums/en/windowsazuretroubleshooting/thread/10d25b51-be08-48bf-b661-340dc380fcc7</a>
 ]<br>
<br>
Step 5: Verify the hosted service. Open a web browser and access <br>
&nbsp; &nbsp; &nbsp; &nbsp;http://&lt;your_deployment_URL&gt;/service1.svc and <br>
&nbsp; &nbsp; &nbsp; &nbsp;http://&lt;your_deployment_URL&gt;/service2.svc. Once the hosted service is
<br>
&nbsp; &nbsp; &nbsp; &nbsp;successfully deployed these URL shall return service description.<br>
<br>
Step 6: Open solution VBAzureWCFServicesClient.sln. Refresh the two service <br>
&nbsp; &nbsp; &nbsp; &nbsp;references in project VBAzureWCFServicesClient. Make servicereference1
<br>
&nbsp; &nbsp; &nbsp; &nbsp;point to http://&lt;your_deployment_URL&gt;/service1.svc, and
<br>
&nbsp; &nbsp; &nbsp; &nbsp;servicereference2 point to http://&lt;your_deployment_URL&gt;/service2.svc.
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Change the endpoints in app.config file as well. Make sure the
<br>
&nbsp; &nbsp; &nbsp; &nbsp;endpoint definition contains a complete FQDN URL of each WCF service-<br>
&nbsp; &nbsp; &nbsp; &nbsp;otherwise the automatically generated endpoint uses a Azure inner URL
<br>
&nbsp; &nbsp; &nbsp; &nbsp;which can not be accessed outside of the hosted service. Change the
<br>
&nbsp; &nbsp; &nbsp; &nbsp;endpoint address in method talk2Workrole to point to your own deploy address.
<br>
<br>
Step 7: Run VBAzureWCFServicesClient console application to see the out put <br>
&nbsp; &nbsp; &nbsp; &nbsp;of 3 communications: &nbsp;The client to the web role, the client to the
<br>
&nbsp; &nbsp; &nbsp; &nbsp;worker role via the web role, and the client directly to the worker
<br>
&nbsp; &nbsp; &nbsp; &nbsp;role. <br>
<br>
<br>
Implementation (The Azure WCF services only):<br>
<br>
-------------------<br>
Creating the WCF service contract which will be shared among the web role, <br>
worker role and client. <br>
<br>
Step 1. Create a &nbsp;Windows Class Library project in Visual Studio 2010 , name
<br>
&nbsp; &nbsp; &nbsp; &nbsp;it WCFContract.<br>
Step 2. Add reference to System.ServiceModel.dll. <br>
Step 3. Create a Interface IContract in namespace WCFClient, make it a service <br>
&nbsp; &nbsp; &nbsp; &nbsp;contract with 2 OperationContract functions GetRoleInfo and \<br>
&nbsp; &nbsp; &nbsp; &nbsp;GetCommunicationChannel.<br>
<br>
-------------------<br>
Creating the Windows Azure Service project <br>
<br>
Step 1. Add a new Windows Azure Project in the solution, name it <br>
&nbsp; &nbsp; &nbsp; &nbsp;VBAzureWCFServices. <br>
Step 2. Do not add any service role. <br>
<br>
-------------------<br>
Adding the web role<br>
<br>
Step 1. Add a new WCF web role to VBAzureWCFServices project. Accept the <br>
&nbsp; &nbsp; &nbsp; &nbsp;default role name. <br>
Step 2. Add a project reference to WCFContract project;<br>
Step 3. Remove the default IService1.vb file. Change Service1.svc.vb to <br>
&nbsp; &nbsp; &nbsp; &nbsp;implement WCFContract.IContract. Implement the methods to return the
<br>
&nbsp; &nbsp; &nbsp; &nbsp;web role instance information and the communication channel
<br>
&nbsp; &nbsp; &nbsp; &nbsp;information. <br>
Step 4. Adjust the web.config file, ServiceModel section. Define a service at <br>
&nbsp; &nbsp; &nbsp; &nbsp;address Service1, using basicHttpBinding and contract <br>
&nbsp; &nbsp; &nbsp; &nbsp;WCFContract.IContract. <br>
<br>
-------------------<br>
Adding the worker role<br>
<br>
Step 1. Add a new worker role to VBAzureWCFServices project. Accept the <br>
&nbsp; &nbsp; &nbsp; &nbsp;default role name. <br>
Step 2. Define 2 new end points in the work role settings-&gt;end points page, <br>
&nbsp; &nbsp; &nbsp; &nbsp;one is named &quot;External&quot;, input type. The other is named &quot;Internal&quot;,
<br>
&nbsp; &nbsp; &nbsp; &nbsp;internal type. Both use TCP protocol. <br>
Step 3. Add project reference to WCFContract project. Change the Service1.vb <br>
&nbsp; &nbsp; &nbsp; &nbsp;to implement IContract interface just like that in the web role. &nbsp;<br>
step 4. In workrole.vb file, add a private method StartWCFService to start <br>
&nbsp; &nbsp; &nbsp; &nbsp;the WCF service as a self-hosted service. &nbsp;Add an internal endpoint
<br>
&nbsp; &nbsp; &nbsp; &nbsp;for inter-role communication and an external end point for external
<br>
&nbsp; &nbsp; &nbsp; &nbsp;communication, using the endpoints defined in step 2. Both use TCP
<br>
&nbsp; &nbsp; &nbsp; &nbsp;protocol, and the IContract interface.<br>
<br>
-------------------<br>
Adding a second service in the web role to call the WCF service in the worker <br>
role via internal endpoint. <br>
<br>
Step 1. Add a new WCF service in the web role, using similar steps above. &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;Name it Service2.svc. <br>
Step 2. In Service2.svc.vb file, implement the interface defined methods, in <br>
&nbsp; &nbsp; &nbsp; &nbsp;each method, get the workrole information by<br>
&nbsp; &nbsp; &nbsp; &nbsp;a. get the workrole by RoleEnvironment.Roles(&quot;WorkerRole1&quot;).
<br>
&nbsp; &nbsp; &nbsp; &nbsp;b. enumerate all workrole instances, get the internal endpoint by the
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; endpoint name. Create a channel by the endpoint address and the
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; shared contract. call the workrole's WCF service method accordingly.
<br>
Step 3. Modify the webrole's web.config file, make sure the new service's <br>
&nbsp; &nbsp; &nbsp; &nbsp;endpoint is added correctly. In this sample, it is also a
<br>
&nbsp; &nbsp; &nbsp; &nbsp;basicHttpBinding, using the same contract. It uses a different address
<br>
&nbsp; &nbsp; &nbsp; &nbsp;in order to be separated from service1.svc.<br>
<br>
Now the server side code is ready. Deploy it to Azure, then test it with the <br>
client console application. <br>
<br>
</p>
<h3>Reference:</h3>
<p style="font-family:Courier New"><br>
Windows Azure Platform Training Kit , available at <br>
<a href="http://www.microsoft.com/downloads/en/details.aspx?familyid=413e88f8-5966-4a83-b309-53b7b77edf78" target="_blank">http://www.microsoft.com/downloads/en/details.aspx?familyid=413e88f8-5966-4a83-b309-53b7b77edf78</a> .<br>
Some ideas of this sample code come from the hand-on lab &quot;Worker Role <br>
Communication&quot;<br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

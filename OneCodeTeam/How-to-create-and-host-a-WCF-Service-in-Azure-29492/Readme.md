# How to create and host a WCF Service in Azure
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Azure
* .NET
* Services
* Cloud
* Windows Communication Framework (WCF)
* Azure Cloud Services
## Topics
* WCF Service
## IsPublished
* True
## ModifiedDate
* 2014-06-24 11:03:11
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<h1>How to host a WCF Service in Windows Azure (<span class="SpellE">VBAzureWCFServices</span>)</h1>
<h2>Introduction</h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">This project shows how to host WCF in Windows Azure, and how to consume it.
</span></h2>
<p class="MsoNormal">It includes<span lang="ZH-CN" style="font-family:SimSun">：</span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>A WCF web role , which hosts WCF in IIS;</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>A work role which hosts a WCF service (self-hosting);</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>A windows console client that consumes the WCF services above.</p>
<h2>Running the Sample</h2>
<h3><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">Step 6: Open solution VBAzureWCFServicesClient.sln. Refresh the two service references in project
<span class="SpellE">VBAzureWCFServicesClient</span>. Make servicereference1 point to http ://<span class="GramE">&lt;<span class="SpellE">your</span></span><span class="SpellE">_deployment_URL</span>&gt;/service1.svc, and servicereference2 point to
 http://&lt;your_deployment_URL&gt;/service2.svc. Change the endpoints in <span class="SpellE">
app.config</span> file as well. Make sure the endpoint definition contains a complete FQDN URL of each WCF service-otherwise the automatically generated endpoint uses
<span class="GramE">a</span> Azure inner URL which cannot be accessed outside of the hosted service. Change the endpoint address in method talk2Workrole to point to your own deploy address.
</span></h3>
<h3>Creating the WCF service contract which will be shared among the web role, worker role and client.</h3>
<p class="MsoNormal">Step 1. Create a Windows Class Library project in Visual Studio 2012, name it
<span class="SpellE">WCFContract</span>.</p>
<p class="MsoNormal">Step 2. Add reference to System.ServiceModel.dll.</p>
<p class="MsoNormal">Step 3. Create an Interface <span class="SpellE">IContract</span> in namespace
<span class="SpellE">WCFClient</span>, make it a service contract with 2 <span class="SpellE">
OperationContract</span> functions <span class="SpellE">GetRoleInfo</span> and \<span class="SpellE">GetCommunicationChannel</span>.</p>
<h3>Creating the Windows Azure Service project</h3>
<p class="MsoNormal">Step 1. Add a new Windows Azure Project in the solution, name it
<span class="SpellE">VBAzureWCFServices</span>.</p>
<p class="MsoNormal">Step 2. Do not add any service role.</p>
<h3>Adding the web role</h3>
<p class="MsoNormal">Step 1. Add a new WCF web role to <span class="SpellE">VBAzureWCFServices</span> project. Accept the default role name.</p>
<p class="MsoNormal">Step 2. Add a project reference to <span class="SpellE">
WCFContract</span> project;</p>
<p class="MsoNormal">Step 3. Remove the default IService1.vb file. Change Service1.svc.vb to implement
<span class="SpellE">WCFContract.IContract</span>. Implement the methods to return the web role instance information and the communication channel information.</p>
<p class="MsoNormal">Step 4. Adjust the <span class="SpellE">web.config</span> file,
<span class="SpellE">ServiceModel</span> section. Define a service at address Service1, using
<span class="SpellE">basicHttpBinding</span> and contract <span class="SpellE">
WCFContract.IContract</span>.</p>
<h3>Adding the worker role</h3>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal">Step 1. Add a new worker role to <span class="SpellE">VBAzureWCFServices</span> project. Accept the default role name.</p>
<p class="MsoNormal">Step 2. Define 2 new end points in the work role settings-&gt;end points page, one is named &quot;External&quot;, input type. The other is named &quot;Internal&quot;, internal type. Both use TCP protocol.</p>
<p class="MsoNormal">Step 3. Add project reference to <span class="SpellE">WCFContract</span> project. Change the Service1.vb to implement
<span class="SpellE">IContract</span> interface just like that in the web role.<span>&nbsp;
</span></p>
<p class="MsoNormal">Step 4. In <span class="SpellE">workrole.vb</span> file, add a private method
<span class="SpellE">StartWCFService</span> to start the WCF service as a self-hosted service.<span>&nbsp;
</span>Add an internal endpoint for inter-role communication and an external end point for external communication, using the endpoints defined in step 2. Both use TCP protocol, and the
<span class="SpellE">IContract</span> interface.</p>
<h3>Adding a second service in the web role to call the WCF service in the worker role via internal endpoint.</h3>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal">Step 1. Add a new WCF service in the web role, using similar steps above.<span>&nbsp;
</span>Name it Service2.svc.</p>
<p class="MsoNormal">Step 2. In Service2.svc.vb file, implement the interface defined methods, in each method, get the
<span class="SpellE">workrole</span> information by</p>
<p class="MsoNormal">A. get the <span class="SpellE">workrole</span> by <span class="SpellE">
<span class="GramE">RoleEnvironment.Roles</span></span><span class="GramE">(</span>&quot;WorkerRole1&quot;).</p>
<p class="MsoNormal">B. enumerate all <span class="SpellE">workrole</span> instances, get the internal endpoint by the endpoint name. Create a channel by the endpoint address and the shared contract. Call the
<span class="SpellE">workrole's</span> WCF service method accordingly.</p>
<p class="MsoNormal">Step 3. Modify the <span class="SpellE">webrole's</span>
<span class="SpellE">web.config</span> file, make sure the new service's endpoint is added correctly. In this sample, it is also a
<span class="SpellE">basicHttpBinding</span>, using the same contract. It uses a different address in order to be separated from service1.svc.</p>
<p class="MsoNormal">Now the server side code is ready. Deploy it to Azure, then test it with the client console application.</p>
<p class="MsoNormal">&nbsp;</p>
<h2>More Information</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://www.microsoft.com/en-us/download/details.aspx?id=8396">Windows Azure Platform Training Kit</a></p>
<p class="MsoListParagraphCxSpLast">&nbsp;</p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

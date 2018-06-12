# Azure WebRole for frontend + backend work (CSAzureWebRoleBackendProcessing)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* WebRole
* Backend Operation
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:48:02
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<h1>WINDOWS AZURE APPLICATION : CSAzureWebRoleBackendProcessing Project Overview</h1>
<h2>Prerequisites</h2>
<ol>
<li>Visual Studio 2010. The trial version can be downloaded from <a href="http://www.microsoft.com/visualstudio/en-us/try">
Visual Studio 2010 Trial Downloads</a> </li><li>Windows Azure SDK which can be downloaded from <a href="http://www.microsoft.com/windowsazure/sdk/">
Download Windows Azure SDK</a> </li></ol>
<h2>Summary</h2>
<p>Windows Azure provides a worker role to perform backend processing. A worker role will be deployed to one or more separated instances. However, sometimes we want to perform backend processing in the same instance of web role for cost saving purpose etc.</p>
<p>This sample shows how to achieve this goal by using startup task in a web role to run a console application in the backend. The backend processor works much similar to a worker role. The difference is that it runs as a startup task in the same instance of
 the web role.</p>
<p>Please note if a VM crashes both the frontend web role and the backend processor on the VM stop working, and the scalability of the backend processor is coupled with scalability of the web role, which may not be suitable in some scenario.</p>
<div align="right">
<p><a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420"><span style="color:windowtext; text-decoration:none"><span><img src="http://code.msdn.microsoft.com/site/view/file/67654/1/image.png" alt="" width="120" height="90" align="middle">
</span></span></a><br>
<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420">Try Windows Azure for free for 90 Days!</a></p>
</div>
<p>This solution contains 4 projects:</p>
<ul>
<li><strong>Common</strong> is a Class Library that acts as both data access layer and bussiness layer. DataSources class, WordDataContext class, WordEntry are for accessing Table Storage and Queue Storage. BackendProcessor class contains the logic that will
 be run in backend. </li><li><strong>Processor</strong> is a Console Application that runs the backend logic.
</li><li><strong>WebRole</strong> is a Web Role project that contains a web page to demo this sample.
</li><li><strong>AzureService</strong> is a Windows Azure Service project that configures the web role and the startup task.
</li></ul>
<h2>How to demo this sample</h2>
<h3>How to run this sample on local machine</h3>
<p>Please open the solution in Visual Studio 2010 in Administrator mode, set AzureService project as startup project and press F5 (or click &quot;Start Debugging&quot; from Debug menu).The browser will be opened automatically and will be displaying a sample web page.</p>
<p>Please input some words into the text box and press the Process button. The words will be added to Azure Table Storage. Then later, these words will be processed to be upper case by a backend processor.</p>
<h3>How to debug this sample locally</h3>
<p>Please temporarily comment out Startup element from ServiceDefinition.csdef file.Press F5 to start debugging the web role. For now, the Processor is not started up. When the web role is running, please right click the Processor project in Solution Explorer
 window and click Debug -&gt; Start new instance. Now you are debugging both the WebRole project and the Processor project.</p>
<h3>How to publish this sample to the cloud</h3>
<p>Open the solution in Visual Studio 2010 in Administrator mode. Right click the AzureService project in Solution Explorer window and click Publish. Please see
<a href="http://msdn.microsoft.com/en-us/library/ee460772.aspx">Publishing a Windows Azure Application from Visual Studio</a> for more information.</p>
<p>Please make sure you have a valid storage account when you test the application published to cloud. To change the connection string, please open up
<a href="https://windows.azure.com/">Azure Platform Management Portal</a>, select the published service project, and click the
<strong>Configure</strong> button. In the <strong>Configure Deployment</strong> dialog, select
<strong>Edit current configuration</strong> and edit the DataConnectionString setting as followed:</p>
<pre>&lt;Setting name=&quot;DataConnectionString&quot; value=&quot;<strong>DefaultEndpointsProtocol=https;AccountName=[YourAccountName];AccountKey=[YourAccountKey]</strong>&quot; /&gt;
</pre>
<h2>Key Logic</h2>
<h3>useLegacyV2RuntimeActivationPolicy</h3>
<p>The Processor project relies on Microsoft.WindowsAzure.ServiceRuntime assembly which is a mixed mode assembly. The useLegacyV2RuntimeActivationPolicy attribute is required for referencing any mixed mode assembly.So the configuration file Processor project
 contains the following setting:</p>
<pre>&lt;startup <strong>useLegacyV2RuntimeActivationPolicy=&quot;true&quot;</strong>&gt;
    &lt;supportedRuntime version=&quot;v4.0&quot; sku=&quot;.NETFramework,Version=v4.0&quot;/&gt;
&lt;/startup&gt;
</pre>
<h3>Use a console application within the same solution in startup task</h3>
<p>Firstly create the Processor console application in the same solution. Then in the WebRole project, add a reference to the console application project.Adding the reference will cause the console application to be built and copied to the output folder of
 WebRole project when a build action is applied to WebRole project.</p>
<p>By default, when we add reference to a project, the application configuration file will not be copied to the target output folder.To overcome this, we create a second config file called CSAzureWebRoleBackendProcessing.Processor.exe.config (CSAzureWebRoleBackendProcessing.Processor.exe
 is the file name of the console application) in the console project. Set <strong>
Copy to Output Directory</strong> as <strong>Copy always.</strong> This configuration file will be used when the console application is loaded as startup task by the web role.</p>
<p>In AzureService project, open ServiceDefinition.csdef file. Add a Startup element within WebRole element to start up the the console application.</p>
<pre>&lt;Startup&gt;
    &lt;Task commandLine=&quot;CSAzureWebRoleBackendProcessing.Processor.exe&quot; executionContext=&quot;elevated&quot; taskType=&quot;background&quot; /&gt;
&lt;/Startup&gt;
</pre>
<h2>References</h2>
<ul>
<li><a href="http://msdn.microsoft.com/en-us/library/hh180155.aspx">Starting Tasks Before Role Instances Start in Windows Azure</a>
</li><li><a href="http://msdn.microsoft.com/en-us/library/bbx34a2h.aspx">&lt;startup&gt; Element&lt;startup&gt; Element</a>
</li></ul>
<p>&nbsp;</p>
<hr>
<p><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></p>

# Run WCF Workflow Service on Windows Azure (CSAzureWorkflowService4)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
* WF
## Topics
* WCF Workflow Service
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:32:39
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<h2>Overview</h2>
<p>This sample demonstrates how to run a WCF Workflow Service on Windows Azure. It uses Visual Studio 2010 and WF 4.</p>
<p>While currently Windows Azure does not contain a Workflow Service component, you can run WCF Workflow Services directly in a Windows Azure Web Role. By default, a Web Role runs under full trust, so it supports the workflow environment.</p>
<p>The workflow in this sample contains a single Receive activity. It compares the service operation's parameter's value with 20, and returns &quot;You've entered a small value.&quot; and &quot;You've entered a large value.&quot;, respectively. The client application invokes the
 Workflow Service twice, passing a value less than 20, and a value grater than 20, respectively.</p>
<div align="right">
<p><a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420"><span style="color:windowtext; text-decoration:none"><span><img src="http://code.msdn.microsoft.com/site/view/file/67654/1/image.png" alt="" width="120" height="90" align="middle">
</span></span></a><br>
<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420">Try Windows Azure for free for 90 Days!</a></p>
</div>
<h2>Prerequests</h2>
<p>For this sample to work, you must install the Windows Azure SDK and the Windows Azure Tools for Visual Studio. This sample works on the local Compute Emulator (included in the Windows Azure SDK) and also in the Windows Azure cloud service. To run the sample
 in the cloud service, you must also have a valid Windows Azure account. More information about Windows Azure can be found here:
<a href="http://msdn.microsoft.com/en-us/library/dd179367.aspx">http://msdn.microsoft.com/en-us/library/dd179367.aspx</a>. Please note that the Windows Azure SDK also has a number of its own pre-requisites (including IIS and SQL Server).</p>
<h2>Running the Sample</h2>
<p>You must start Visual Studio in elevated (administrator) mode. Right-click on Visual Studio and then click Run as Administrator. This is required by the Windows Azure simulation environment.</p>
<p>Configure the app.config file for the the Client application:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;!-- Modify address if you host the Workflow Service in the cloud, or if your Compute Emulator is not listening on port 81. --&gt;
            &lt;endpoint address=&quot;http://127.0.0.1:81/ProcessDataWorkflowService.xamlx&quot;
                binding=&quot;basicHttpBinding&quot; bindingConfiguration=&quot;BasicHttpBinding_IService&quot;
                contract=&quot;WorkflowServiceReference.IService&quot; name=&quot;BasicHttpBinding_IService&quot; /&gt;
</pre>
<div class="preview">
<pre class="xml"><span class="xml__comment">&lt;!--&nbsp;Modify&nbsp;address&nbsp;if&nbsp;you&nbsp;host&nbsp;the&nbsp;Workflow&nbsp;Service&nbsp;in&nbsp;the&nbsp;cloud,&nbsp;or&nbsp;if&nbsp;your&nbsp;Compute&nbsp;Emulator&nbsp;is&nbsp;not&nbsp;listening&nbsp;on&nbsp;port&nbsp;81.&nbsp;--&gt;</span><span class="xml__tag_start">&lt;endpoint</span><span class="xml__attr_name">address</span>=<span class="xml__attr_value">&quot;http://127.0.0.1:81/ProcessDataWorkflowService.xamlx&quot;</span><span class="xml__attr_name">binding</span>=<span class="xml__attr_value">&quot;basicHttpBinding&quot;</span><span class="xml__attr_name">bindingConfiguration</span>=<span class="xml__attr_value">&quot;BasicHttpBinding_IService&quot;</span><span class="xml__attr_name">contract</span>=<span class="xml__attr_value">&quot;WorkflowServiceReference.IService&quot;</span><span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;BasicHttpBinding_IService&quot;</span><span class="xml__tag_start">/&gt;</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>Then run the CSAzureWorkflowService4 project in the Windows Azure local Compute Emulator or package and deploy the solution to the Windows Azure service. For more information about running Windows Azure applications locally or in the cloud please refer to
 the Windows Azure documentation at <a href="http://msdn.microsoft.com/en-us/library/ee405484.aspx05484.aspx">
http://msdn.microsoft.com/en-us/library/ee405484.aspx05484.aspx</a>.</p>
<p>Finally, run the Client project to verify the workflow service works properly</p>
<h2>Description</h2>
<p>The sample solution contains 3 projects.</p>
<p>&nbsp;</p>
<h3>CSAzureWorkflowService4</h3>
<p>The cloud service project. When testing in Compute Emulator, please make sure to run this project instead of the WorkflowServiceWebRole project.</p>
<h3>WorkflowServiceWebRole</h3>
<p>The Web Role project. It is a normal ASP.NET project that hosts a WCF Workflow Service. Hosting a Workflow Service in Windows Azure is the same as hosting in IIS. The service contract is defined in the xamlx file.</p>
<p>There's also nothing special about configuration. We add a default service behavior to enable metadata.</p>
<h3>Client</h3>
<p>A console client application that invokes the WCF Workflow Service.w Service.</p>
<p>&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

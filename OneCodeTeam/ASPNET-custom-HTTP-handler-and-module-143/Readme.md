# ASP.NET custom HTTP handler and module (CSASPNETCustomHttpHandlerandModule)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* HTTP Module
* HTTP Handler
## IsPublished
* True
## ModifiedDate
* 2011-05-05 04:56:31
## Description

<p style="font-family:Courier New"></p>
<h2>ASP.NET APPLICATION: CSASPNETCustomHttpHandlerandModule Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This sample introduces how to write custom Http Handler and Http Module and<br>
use them in ASP.NET web application on IIS.<br>
<br>
It includes two projects: CSASPNETCustomHttpHandlerandModule and <br>
CustomHandlerandModuleProject.<br>
<br>
CSASPNETCustomHttpHandlerandModule is ASP.NET web application to use custom<br>
Http Handler and Module.<br>
<br>
CustomHandlerandModuleProject is Class Library project to implement custom<br>
Http Handler and Module.<br>
<br>
The sample can be running on IIS 7.0 directly. To use it on IIS 6 or earlier <br>
version, we need to register the extension .demo in aspnet_isapi.dll.<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
Step1. Create Class Library project named &quot;CustomHandlerandModuleProject&quot;.<br>
<br>
Step2. Add two classes to inherit IHttpHandler and IHttpModule to implement<br>
its methods. <br>
<br>
&nbsp; note: Need to add reference to System.Web assembly.<br>
<br>
Step3. Create ASP.NET web application named &quot;CSASPNETCustomHttpHandlerandModule&quot;. &nbsp;<br>
<br>
Step4. Add reference to project &quot;CustomHandlerandModuleProject&quot; from <br>
CSASPNETCustomHttpHandlerandModule and registercustom Http Handler and Module <br>
in IIS:<br>
<br>
&lt;handlers&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;add name=&quot;CustomHandlerFor.demo&quot; verb=&quot;*&quot; path=&quot;*.demo&quot; type=&quot;CustomHandlerandModuleProject.CustomHttpHandler&quot;/&gt;<br>
&lt;/handlers&gt;<br>
<br>
&lt;modules&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;add name=&quot;CustomModule&quot; type=&quot;CustomHandlerandModuleProject.CustomHttpModule&quot;/&gt;<br>
&lt;/modules&gt;<br>
<br>
Step5. Publish ASP.NET web application and deploy it on IIS 7 and request <br>
default.htm page to view sample.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
HTTP Handlers and HTTP Modules Overview<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb398986.aspx">http://msdn.microsoft.com/en-us/library/bb398986.aspx</a><br>
<br>
How to: Configure an HTTP Handler Extension in IIS<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb515343.aspx">http://msdn.microsoft.com/en-us/library/bb515343.aspx</a><br>
<br>
Walkthrough: Creating and Registering a Custom HTTP Module<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms227673.aspx">http://msdn.microsoft.com/en-us/library/ms227673.aspx</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

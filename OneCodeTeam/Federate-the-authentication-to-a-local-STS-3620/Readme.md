# Federate the authentication to a local STS (CSAzureWebRoleIdentity)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* ADFS Authentication
* STS
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:30:02
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<h2>APPLICATION : CSAzureWebRoleIdentity Project Overview</h2>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
CSAzureWebRoleIdentity is a web role hosted in Windows Azure. It federates the <br>
authentication to a local STS. This breaks the authentication code from the business
<br>
logic so that web developer can offload the authentication and authorization to <br>
the STS with the help of WIF.</p>
<div align="right">
<p><a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420"><span style="color:windowtext; text-decoration:none"><span><img src="http://code.msdn.microsoft.com/site/view/file/67654/1/image.png" alt="" width="120" height="90" align="middle">
</span></span></a><br>
<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420">Try Windows Azure for free for 90 Days!</a></p>
</div>
<h3>Prerequisite:</h3>
<p style="font-family:Courier New"><br>
1. Microsoft Windows Vista SP2 (32-bits or 64-bits) , Microsoft Windows Server 2008 SP2
<br>
&nbsp; (32-bit or 64-bit), Microsoft Windows Server 2008 R2, &nbsp;Microsoft Windows 7 RTM (32-bits or 64-bits)<br>
2. Microsoft Internet Information Services (IIS) 7.0 with IIS Metabase and IIS <br>
&nbsp; 6 configuration compatibility.<br>
3. Microsoft .NET Framework 4<br>
4. Microsoft Visual Studio 2010<br>
5. Microsoft Windows Identity Foundation Runtime<br>
6. Microsoft Windows Identity Foundation SDK 4.0<br>
7. Windows Azure Tools for Microsoft Visual Studio 1.4<br>
<br>
</p>
<h3>Setup:</h3>
<p style="font-family:Courier New"><br>
1.&nbsp;&nbsp;&nbsp;&nbsp;Create a New Hosted Service on Windows Azure. In this sample, it is csazurewebroleidentity.<br>
2.&nbsp;&nbsp;&nbsp;&nbsp;Create certificate for the service. The subject name should be the same as the service name.<br>
3.&nbsp;&nbsp;&nbsp;&nbsp;Import the certificate into Personal and Trusted Root Certification Authorities<br>
4.&nbsp;&nbsp;&nbsp;&nbsp;Upload the certificate to the hosted service.<br>
5.&nbsp;&nbsp;&nbsp;&nbsp;Deploy the solution to Windows Azure<br>
6.&nbsp;&nbsp;&nbsp;&nbsp;Copy csazurewebroleidentity_sts in STS folder to C:\inetpub\wwwroot\ folder and create a
<br>
&nbsp; &nbsp;Virtual Directory in Default Web Site for it.<br>
<br>
<br>
Please note:<br>
<br>
1. You need to make sure the certificate used for SSL has the same name as your hosted service.
<br>
&nbsp; You can use CreateCert script in sample Assert folder to create such folder<br>
<br>
&nbsp; &gt;CreateCert yourservicename<br>
<br>
2. If you run into exception, &quot;A potentially dangerous Request.Form value was detected from the client<br>
&nbsp; &quot;after click &quot;Submit&quot; button on STS, you need to add the following in web.config of the
<br>
&nbsp; replying party. It will disable the validation in ASP.NET.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;...<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;httpRuntime requestValidationMode=&quot;2.0&quot;/&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;pages validateRequest=&quot;false&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/system.web&gt;<br>
<br>
3. Make sure &quot;Copy Local&quot; attribute of Microsoft.IdentityModel assembly in Web role replying party set as True.<br>
<br>
Test:<br>
When browse to the web role ( please note, you need to use HTTPS instead of HTTP protocol ), which
<br>
is now hosted in Windows Azure. You will be redirected to the local STS first. You can observe
<br>
this from the browser address bar. After log in, the web role will display your claim in the default page.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
Local STS will first validate the incoming request. If it is coming from the local host or Windows Azure
<br>
domain, then it will reject the request by throwing an InvalidRequestException. After validation, STS
<br>
will issue claims of identity. These claims include: name and role. This is done in ValidateReplyTo()
<br>
and GetOutputClaimsIdentity() method in CustomSecurityTokenService.cs<br>
<br>
The ASP.NET web role uses default template except it displays login user&rsquo;s claims on default page.<br>
<br>
All its authentication and authorization work now is federated to local STS. <br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Identity Management: Windows Identity Foundation<br>
<a href="http://msdn.microsoft.com/en-us/security/aa570351" target="_blank">http://msdn.microsoft.com/en-us/security/aa570351</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

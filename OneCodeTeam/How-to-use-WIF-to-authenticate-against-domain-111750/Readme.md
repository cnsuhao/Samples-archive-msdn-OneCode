# How to use WIF to authenticate against domain ADFS in Windows Azure Web Role app
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
* Cloud
## Topics
* Authentication
* adfs
## IsPublished
* True
## ModifiedDate
* 2015-01-19 07:32:10
## Description

<h1>
<hr>
<div><a href="http://blogs.msdn.com/b/onecode"><img src="http://bit.ly/onecodesampletopbanner" alt=""></a></div>
</h1>
<h1>How to use WIF to authenticate against domain ADFS in Windows Azure Web Role application&nbsp;</h1>
<h2>Introduction</h2>
<p>CSAzureWebRoleIdentity is a web role hosted in Windows Azure. It federates the authentication to a local STS. This breaks the authentication code from the business logic so that web developer can offload the authentication and authorization to the STS with
 the help of WIF.</p>
<h2>Running the Sample</h2>
<p>You must run this code sample on</p>
<p>1. Microsoft Windows Vista SP2 (32-bits or 64-bits), Microsoft Windows Server 2008 SP2 (32-bit or 64-bit), Microsoft Windows Server 2008 R2, Microsoft Windows 7 RTM (32-bits or 64-bits)</p>
<p>2. Microsoft Internet Information Services (IIS) 7.0 with IIS Metabase and IIS 6 configuration compatibility.</p>
<p>3. Microsoft .NET Framework 4</p>
<p>4. Microsoft Visual Studio 2010</p>
<p>5. Microsoft Windows Identity Foundation Runtime</p>
<p>6. Microsoft Windows Identity Foundation SDK 4.0</p>
<p>7. Windows Azure Tools for Microsoft Visual Studio 1.4</p>
<p>1. You need to make sure the certificate used for SSL has the same name as your hosted service.</p>
<p>&nbsp;&nbsp; You can use CreateCert script in sample Assert folder to create such folder</p>
<p>&nbsp;&gt;CreateCert yourservicename</p>
<p>&nbsp;</p>
<p>2. If you run into exception, &quot;A potentially dangerous Request.Form value was detected from the client&quot;after click &quot;Submit&quot; button on STS, you need to add the following in web.config of the replying party. It will disable the validation in ASP.NET....</p>
<p>&lt;httpRuntime requestValidationMode=&quot;2.0&quot;/&gt;</p>
<p>&lt;pages validateRequest=&quot;false&quot; /&gt;</p>
<p>&lt;/system.web&gt;</p>
<p>&nbsp;</p>
<p>3. Make sure &quot;Copy Local&quot; attribute of Microsoft.IdentityModel assembly in Web role replying party set as True.</p>
<p>Test:</p>
<p>When browse to the web role (please note, you need to use HTTPS instead of HTTP protocol ), which is now hosted in Windows Azure. You will be redirected to the local STS first. You can observe this from the browser address bar. After log in, the web role
 will display your claim in the default page.</p>
<p>Local STS will first validate the incoming request. If it is coming from the local host or Windows Azure domain, then it will reject the request by throwing an InvalidRequestException. After validation, STS will issue claims of identity. These claims include:
 name and role. This is done in ValidateReplyTo() and GetOutputClaimsIdentity() method in CustomSecurityTokenService.cs</p>
<p>The ASP.NET web role uses default template except it displays login user&rsquo;s claims on default page.</p>
<p>All its authentication and authorization work now is federated to local STS.</p>
<h2>More Information</h2>
<ul>
<li><a href="http://msdn.microsoft.com/en-us/security/aa570351">Identity Management: Windows Identity Foundation</a>
</li></ul>

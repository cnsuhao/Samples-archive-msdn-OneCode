# Windows Azure Access Control for Single Sign-On(SSO)
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* Single Sign-On
* SSO
## IsPublished
* True
## ModifiedDate
* 2013-07-03 11:15:18
## Description

<h1><span lang="EN-US">Windows Azure Access control service for Web Role (CSAzureAccessControlService)</span></h1>
<h2><span lang="EN-US">Introduction</span></h2>
<p class="MsoNormal"><span lang="EN-US">This sample code demonstrates how to implement for Access Control Service for your web role application, As we know most of websites and web application has their own user validation system, such simple UserName-Password
 way, Active Directory, etc. If your web application must support multiple user validation, you must handle different token with different methods, but when you try to move your application to Windows Azure, you will find we can use Access Control for solve
 this problem, your azure application need only handle one kind of Token from Windows Azure Access Control Service</span><span lang="EN-US" style="">
</span></p>
<p class="MsoNormal" align="right" style="text-align:right"><span lang="EN-US"><a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420"><span style="color:windowtext; text-decoration:none"><span style=""><img src="/site/view/file/91638/1/image.png" alt="" width="120" height="90" align="middle">
</span></span></a><br>
<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420">Try Windows Azure for free for 90 Days!</a></span><span lang="EN-US" style="">
</span></p>
<h2><span lang="EN-US">Building the Sample</span></h2>
<p class="MsoNormal"><span lang="EN-US">Before running this sample, please install latest Windows Azure SDK and Windows Azure Toolkit for Visual Studio</span></p>
<p class="MsoNormal"><span lang="EN-US"><a href="http://www.windowsazure.com/en-us/develop/downloads/">http://www.windowsazure.com/en-us/develop/downloads/</a></span></p>
<p class="MsoNormal"><span lang="EN-US">SQL Server 2008 R2 Express:</span></p>
<p class="MsoNormal"><span lang="EN-US"><a href="http://www.microsoft.com/download/en/details.aspx?id=23650">http://www.microsoft.com/download/en/details.aspx?id=23650</a>
</span></p>
<h2><span lang="EN-US">Running the Sample</span></h2>
<p class="MsoNormal"><span lang="EN-US" style="">Before run your application, you have to create a Access Control Service in Windows Azure platform and</span><span lang="EN-US"> create some identity providers with your subscription. Following the ACS Management
 Portal Wizard and input your information.</span></p>
<p class="MsoNormal"><b style=""><span lang="EN-US">Step 1</span></b><span lang="EN-US">, create preconfigured Identity Providers:</span></p>
<p class="MsoNormal"><span lang="EN-US">Your work is adding Windows Live ID, Google, Yahoo! Identity providers in your Access Control Service Management Portal.</span></p>
<p class="MsoNormal"><b style=""><span lang="EN-US">Step 2</span></b><span lang="EN-US">, create Relying-Party Application:</span></p>
<p class="MsoNormal"><span lang="EN-US" style="">Name: Your RP (Relying-Party application name) Name.
</span></p>
<p class="MsoNormal"><span lang="EN-US" style="">Mode: Enter settings manually </span>
</p>
<p class="MsoNormal"><span lang="EN-US" style="">Realm: Your application directory path.
</span></p>
<p class="MsoNormal"><span lang="EN-US" style="">Return URL: Your application return page path.
</span></p>
<p class="MsoNormal"><span lang="EN-US" style="">Token Format: SAML 2.0 </span>
</p>
<p class="MsoNormal"><span lang="EN-US" style="">Token LifeTime: 600 </span></p>
<p class="MsoNormal"><span lang="EN-US" style="">Identity Providers: Google, Windows Live ID, Yahoo!
</span></p>
<p class="MsoNormal"><span lang="EN-US" style="">Token Singing: Use Service namespace certificate (standard)
</span></p>
<p class="MsoNormal"><span lang="EN-US">Then add ACS as the STS reference in your application:</span></p>
<p class="MsoNormal"><b style=""><span lang="EN-US">Step 3</span></b><span lang="EN-US">:<span style="">&nbsp;
</span>Please press F5 to start debugging, you will see the following page in your browser:</span></p>
<p class="MsoNormal"><span lang="EN-US" style=""><img src="/site/view/file/91639/1/image.png" alt="" width="576" height="527" align="middle">
</span></p>
<p class="MsoNormal"><b style=""><span lang="EN-US" style="">Step 4</span></b><span lang="EN-US" style="">: Click &quot;Login&quot; button and you can find 3 ways to login your website.
</span></p>
<p class="MsoNormal"><span lang="EN-US" style=""><img src="/site/view/file/91640/1/image.png" alt="" width="576" height="527" align="middle">
</span></p>
<p class="MsoNormal"><b style=""><span lang="EN-US" style="">Step 5</span></b><span lang="EN-US" style="">: If User name and password are correct, you can visit the whole web application now.
</span></p>
<p class="MsoNormal"><span lang="EN-US" style=""><img src="/site/view/file/91641/1/image.png" alt="" width="576" height="527" align="middle">
</span></p>
<p class="MsoNormal"><b style=""><span lang="EN-US">Step </span></b><b style=""><span lang="EN-US" style="">6</span></b><span lang="EN-US">: Validation is finished.</span></p>
<h2><span lang="EN-US">Using the Code</span></h2>
<p class="MsoNormal"><span lang="EN-US">Control Service</span></p>
<p class="MsoNormal"><b style=""><span lang="EN-US">Step 1</span></b><span lang="EN-US">. Create a C# &quot;Windows Azure Project&quot; in Visual Studio 2012. Name it as &quot;<span style="">CSAzureAccessControlService</span>&quot;. Add a Web Role and named
 it as &quot;<span style="">CSAzureAccessControlService</span>WebRole&quot;.</span></p>
<p class="MsoNormal"><b style=""><span lang="EN-US">Step 2</span></b><span lang="EN-US">. Please following the step 2 of section &quot;Running the sample&quot; create ACS with Azure subscription. Add two web pages in CSAzureAccessControlServiceWebRole application,
 the Default.aspx can be accessed by anyone.<b style=""> </b></span></p>
<h3><span lang="EN-US">The following xml is used to set &quot;All&quot; folder as the public folder.</span></h3>
<p class="MsoNormal"><b style=""><span lang="EN-US">Step 3</span></b><span lang="EN-US">. The next step, display customers' user name in Content.aspx page.
</span></p>
<h3><span lang="EN-US">The following code shows how to display user identity name in Content.aspx page.
</span></h3>
<p class="MsoNormal"><b style=""><span lang="EN-US">Step 4</span></b><span lang="EN-US">. Build the application and you can debug it.</span></p>
<h2><span lang="EN-US">More Information</span></h2>
<p class="MsoNormal" style=""><span lang="EN-US"><a href="http://msdn.microsoft.com/en-us/library/windowsazure/gg429786.aspx">Access Control Service 2.0</a></span></p>
<p class="MsoNormal"><span lang="EN-US"></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

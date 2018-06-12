# Windows Azure Access Control for Single Sign-On (VBAzureAccessControlService)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Microsoft Azure
## Topics
* Single Sign-On
* SSO
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:39:03
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<h1>Windows Azure Access control service for Web Role (VBAzureAccessControlService)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample code demonstrates how to implement for Access Control Service for your web role application, As we know most of websites and web application has their own user validation system, such simple UserName-Password way, Active Directory,
 etc. If your web application must support multiple user validation, you must handle different token with different methods, but when you try to move your application to Windows Azure, you will find we can use Access Control for solve this problem, your azure
 application need only handle one kind of Token from Windows Azure Access Control Service<span>
</span></p>
<p class="MsoNormal" style="text-align:right"><a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420"><span style="color:windowtext; text-decoration:none"><span><img src="/site/view/file/67670/1/image.png" alt="" width="120" height="90" align="middle">
</span></span></a><br>
<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420">Try Windows Azure for free for 90 Days!</a><span>
</span></p>
<h2>Building the Sample</h2>
<p class="MsoNormal">Before running this sample, please install Windows Azure SDK 1.6 and Windows Azure Toolkit for Visual Studio</p>
<p class="MsoNormal"><a href="http://www.windowsazure.com/en-us/develop/downloads/">http://www.windowsazure.com/en-us/develop/downloads/</a></p>
<p class="MsoNormal">SQL Server 2008 R2 Express:</p>
<p class="MsoNormal"><a href="http://www.microsoft.com/download/en/details.aspx?id=23650">http://www.microsoft.com/download/en/details.aspx?id=23650</a></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span>Before run your application, you have to create a Access Control Service in Windows Azure platform and</span> create some identity providers with your subscription. Following the ACS Management Portal Wizard and input your information.</p>
<p class="MsoNormal"><strong>Step 1</strong>, create preconfigured Identity Providers:</p>
<p class="MsoNormal">Your work is adding Windows Live ID, Google, Yahoo! Identity providers in your Access Control Service Management Portal.</p>
<p class="MsoNormal"><strong>Step 2</strong>, create Relying-Party Application:</p>
<p class="MsoNormal"><span>Name: Your RP (Relying-Party application name) Name.
</span></p>
<p class="MsoNormal"><span>Mode: Enter settings manually </span></p>
<p class="MsoNormal"><span>Realm: Your application directory path. </span></p>
<p class="MsoNormal"><span>Return URL: Your application return page path. </span>
</p>
<p class="MsoNormal"><span>Token Format: SAML 2.0 </span></p>
<p class="MsoNormal"><span>Token LifeTime: 600 </span></p>
<p class="MsoNormal"><span>Identity Providers: Google, Windows Live ID, Yahoo! </span>
</p>
<p class="MsoNormal"><span>Token Singing: Use Service namespace certificate (standard)
</span></p>
<p class="MsoNormal">Then add ACS as the STS reference in your application:</p>
<p class="MsoNormal"><strong>Step 3</strong>:<span>&nbsp; </span>Please press F5 to start debugging, you will see the following page in your browser:</p>
<h2><span><img src="/site/view/file/67671/1/image.png" alt="" width="576" height="527" align="middle">
</span></h2>
<p class="MsoNormal"><strong><span>Step 4</span></strong><span>: Click &quot;Login&quot; button and you can find 3 ways to login your website.
</span></p>
<p class="MsoNormal"><span><img src="/site/view/file/67672/1/image.png" alt="" width="576" height="527" align="middle">
</span></p>
<p class="MsoNormal"><strong><span>Step 5</span></strong><span>: If User name and password is ok, you can visit the whole web application now.
</span></p>
<p class="MsoNormal"><span><img src="/site/view/file/67673/1/image.png" alt="" width="576" height="527" align="middle">
</span></p>
<p class="MsoNormal"><strong>Step </strong><strong><span>6</span></strong>: Validation finished.</p>
<h2>Using the Code</h2>
<p class="MsoNormal">Control Service</p>
<p class="MsoNormal"><strong>Step 1</strong>. Create a VB &quot;Windows Azure Project&quot; in Visual Studio 2010. Name it as &quot;<span>VBAzureAccessControlService</span>&quot;. Add a Web Role and named it as &quot;<span>VBAzureAccessControlService</span>WebRole&quot;.</p>
<p class="MsoNormal"><strong>Step 2</strong>. Please following the step 2 of section &quot;Running the sample&quot; create ACS with Azure subscription. Add two web pages in VBAzureAccessControlServiceWebRole application, the Default.aspx can be accessed by anyone.<strong>
</strong></p>
<h3>The following xml is used to set &quot;All&quot; folder as the public folder.</h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;location path=&quot;All&quot;&gt;
  &lt;system.web&gt;
    &lt;authorization&gt;
      &lt;allow users=&quot;*&quot; /&gt;
    &lt;/authorization&gt;
  &lt;/system.web&gt;
&lt;/location&gt;

</pre>
<pre id="codePreview" class="xml">&lt;location path=&quot;All&quot;&gt;
  &lt;system.web&gt;
    &lt;authorization&gt;
      &lt;allow users=&quot;*&quot; /&gt;
    &lt;/authorization&gt;
  &lt;/system.web&gt;
&lt;/location&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><strong>Step 3</strong>. The next step, display customers' user name in Content.aspx page.</p>
<h3>The following code shows how to display user identity name in Content.aspx page.</h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Public userName As String = String.Empty
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    userName = Thread.CurrentPrincipal.Identity.Name
End Sub

</pre>
<pre id="codePreview" class="vb">Public userName As String = String.Empty
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    userName = Thread.CurrentPrincipal.Identity.Name
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><strong>Step 4</strong>. Build the application and you can debug it.</p>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windowsazure/gg429786.aspx">Access Control Service 2.0</a></p>
<p class="MsoNormal">&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

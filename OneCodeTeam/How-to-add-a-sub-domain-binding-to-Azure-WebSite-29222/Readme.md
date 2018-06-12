# How to add a sub-domain binding to Azure WebSite Programmatically
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* Azure
## IsPublished
* True
## ModifiedDate
* 2014-06-11 08:43:19
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<h1>How to add a sub-domain binding to an Azure <span class="SpellE">WebSite</span> Programmatically</h1>
<h2>Introduction</h2>
<p class="MsoNormal">When you create a web site, Windows Azure provides a friendly subdomain on the azurewebsites.net domain so your users can access your web site using a URL like http://&lt;mysite&gt;.azurewebsites.net. However, if you configure your web
 site for Shared or Standard mode, you can map your web site to your own domain name.</p>
<p class="MsoNormal">This sample demonstrates how to use Windows Azure Class Libraries to add a sub-domain binding to a Windows Azure website.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">This sample requires Windows Azure management class libraries. Please run the following command in the
<span style="color:#333333"><a href="http://docs.nuget.org/docs/start-here/using-the-package-manager-console"><span style="color:#0071bc">Package Manager Console</span></a>
</span></p>
<p class="MsoNormal"><span style="font-size:14.0pt; line-height:115%; font-family:&quot;Lucida Console&quot;; color:#e2e2e2; background:#202020">PM&gt; Install-Package Microsoft.WindowsAzure.Management.Libraries -Pre
</span></p>
<p class="MsoNormal">Before running the sample, you need to get some information.</p>
<p class="MsoNormal"><span style="font-size:10.0pt; line-height:115%; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:#222222; background:white">Download the&nbsp;</span><strong><span style="font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;">publishsettings file</span></strong><span>&nbsp;from:</span></p>
<p class="MsoNormal"><a href="https://manage.windowsazure.com/publishsettings/index?client=vs&schemaversion=2.0&whr=azure.com"><span style="font-size:10.0pt; line-height:115%; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:#960bb4; background:white; text-decoration:none">https://manage.windowsazure.com/publishsettings/index?client=vs&amp;schemaversion=2.0&amp;whr=azure.com</span></a><span style="font-size:10.0pt; line-height:115%; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:#222222; background:white"><span>&nbsp;</span>
</span></p>
<p class="MsoNormal" style="margin-bottom:11.25pt; line-height:normal; background:white">
<span style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:#222222">And get&nbsp;<strong>SubscriptionID</strong>&nbsp;and&nbsp;<strong>ManagementCertificate Base64 string</strong>.
</span></p>
<p class="MsoNormal" style="margin-bottom:11.25pt; line-height:normal; background:white">
<span style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:#222222"><img src="/site/view/file/116694/1/image.png" alt="" width="1184" height="565" align="middle">
</span><span style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:#222222">&nbsp;</span></p>
<p class="MsoNormal"><span style="font-size:10.0pt; line-height:115%; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:#222222; background:white">Open the project, fill them to the&nbsp;variables below.</span><span>
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public const string base64EncodedCertificate = &quot;{Your-sertificate-base64string}&quot;;
public const string subscriptionId = &quot;{Your-subscription-id}&quot;;

</pre>
<pre id="codePreview" class="csharp">public const string base64EncodedCertificate = &quot;{Your-sertificate-base64string}&quot;;
public const string subscriptionId = &quot;{Your-subscription-id}&quot;;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="font-size:10.0pt; line-height:115%; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:#222222; background:white">&nbsp;</span></p>
<p class="MsoNormal"><span style="font-size:10.0pt; line-height:115%; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:#222222; background:white">Then get your Website Name and the sub domain address, fill them to the variables below:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static string websiteName = &quot;{Your-web-site-name}&quot;;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public static string subDomainName = &quot;{sub-domain-name}&quot;;

</pre>
<pre id="codePreview" class="csharp">public static string websiteName = &quot;{Your-web-site-name}&quot;;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public static string subDomainName = &quot;{sub-domain-name}&quot;;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoNormal">Now you can run the sample directly.</p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://www.windowsazure.com/en-us/documentation/articles/web-sites-custom-domain-name/">Configuring a custom domain name for a Windows Azure web site</a></p>
<p class="MsoListParagraphCxSpLast">&nbsp;</p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

# Enable static compression in Azure (CSAzureEnableCompression)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* Static Compression
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:29:23
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<h1>Enable static compression in Azure (CSAzureEnableCompression)</h1>
<h2>Introduction</h2>
<p>Static compression is the feature that is shipped out of the box in IIS. Using static compression, developers/administrators can enable faster downloads of their web site static content like javascripts, text files, Microsoft office documents, html/htm files,
 cs files, etc.&nbsp; So, how can we make use of this feature when hosting the web application in Windows Azure? By default static compression is enabled in Windows Azure, however, there are only few mime types that will be compressed. This sample demonstrates
 adding new mime types for static compression.</p>
<div align="right">
<p><a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420"><span style="color:windowtext; text-decoration:none"><span><img src="http://code.msdn.microsoft.com/site/view/file/67654/1/image.png" alt="" width="120" height="90" align="middle">
</span></span></a><br>
<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420">Try Windows Azure for free for 90 Days!</a></p>
</div>
<h2>Building the Sample</h2>
<p>This sample can be run as-is without making any changes to it.</p>
<h2>Running the Sample</h2>
<ol>
<li>Open the sample on the machine where VS 2010, Windows Azure SDK 1.6 are installed
</li><li>Right click on the cloud service project i.e. CSAzureEnableCompression and choose Publish
</li><li>Follow the steps in publish Wizard and choose subscription details, deployment slots, etc. and enable remote desktop for all roles
</li><li>After successful publish, browse to a page that has javascript files and then login to Azure VM and verify that the cache directory has the compressed files.
</li></ol>
<h2>Using the Code</h2>
<p>To customize static compression settings in Windows Azure, you can use startup tasks. Below are the steps I have followed to successfully enable static compression for few of the mime types my application needed.</p>
<p>1. Configure following tag in Application&rsquo;s web.config @Configuration/System.WebServer</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;urlCompression doStaticCompression=&quot;true&quot;/&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;urlCompression</span><span class="xml__attr_name">doStaticCompression</span>=<span class="xml__attr_value">&quot;true&quot;</span><span class="xml__tag_start">/&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">2. Create iisconfigchanges.cmd file with required commands to customize ApplicationHost.config configuration of IIS</div>
<p>&nbsp;</p>
<p><strong>iisconfigchanges.cmd</strong></p>
<p>%windir%\system32\inetsrv\appcmd.exe set config -section:system.webServer/httpCompression /&#43;&quot;staticTypes.[mimeType='application/x-javascript',enabled='True']&quot; /commit:apphost</p>
<p>%windir%\system32\inetsrv\appcmd.exe set config -section:system.webServer/httpCompression /&#43;&quot;staticTypes.[mimeType='text/javascript',enabled='True']&quot; /commit:apphost</p>
<p>%windir%\system32\inetsrv\appcmd.exe set config -section:system.webServer/httpCompression /&#43;&quot;staticTypes.[mimeType='application/vnd.openxmlformats-officedocument.wordprocessingml.document',enabled='True']&quot; /commit:apphost</p>
<p>%windir%\system32\inetsrv\appcmd.exe set config -section:system.webServer/httpCompression /&#43;&quot;staticTypes.[mimeType='application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',enabled='True']&quot; /commit:apphost</p>
<p>%windir%\system32\inetsrv\appcmd.exe set config -section:system.webServer/httpCompression /&#43;&quot;staticTypes.[mimeType='application/vnd.openxmlformats-officedocument.presentationml.presentation',enabled='True']&quot; /commit:apphost</p>
<p>%windir%\system32\inetsrv\appcmd.exe set config -section:serverruntime /frequentHitThreshold:1 /commit:APPHOST</p>
<p>exit /b 0</p>
<p>Above commands configures MIME types for javascripts, word documents (docx), Excel documents(xlsx), Powerpoint documents(pptx). If you need to compress any specific files other than mentioned above, find out the MIME types per your requirement and add similar
 commands to the file.</p>
<p><strong>Note</strong>: I have changed frequentHitThreshold parameter since I could not see compression happening without explicitly specifying this parameter.</p>
<p>3. Add below startup task that will execute iisconfigchanges.cmd during startup of the rule. This configuration should be added in ServiceConfiguration.csdef under webrole/workerrole tag.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;Startup&gt;
  &lt;Task commandLine=&quot;iisconfigchanges.cmd&quot; executionContext=&quot;elevated&quot; taskType=&quot;simple&quot; /&gt;
&lt;/Startup&gt;</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;Startup</span><span class="xml__tag_start">&gt;&nbsp;
</span><span class="xml__tag_start">&lt;Task</span><span class="xml__attr_name">commandLine</span>=<span class="xml__attr_value">&quot;iisconfigchanges.cmd&quot;</span><span class="xml__attr_name">executionContext</span>=<span class="xml__attr_value">&quot;elevated&quot;</span><span class="xml__attr_name">taskType</span>=<span class="xml__attr_value">&quot;simple&quot;</span><span class="xml__tag_start">/&gt;</span><span class="xml__tag_end">&lt;/Startup&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">4. Add iisconfigchanges.cmd file to webrole/workerrole project</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">5. Configure below file properties for iisconfigchanges.cmd file , so that it will be copied to bin directory</div>
<p>&nbsp;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp; Build Action : Content<br>
&nbsp;&nbsp;&nbsp;&nbsp; Copy To Output Directory : Copy Always</p>
<p>&nbsp;</p>
<h2>More Information</h2>
<p>Caution: Compression settings should be tweaked carefully, It might result in undesired performance too if not configured properly. For example, images like png are already compressed and compressing these types again, will cause additional CPU on the system
 without any significant gain in the bandwidth. I recommend you to research and thoroughly test your application with the compression settings before you apply the changes to production.&nbsp; I recommend below blog entry for further reading on IIS7 compression.</p>
<p>&nbsp;IIS 7 Compression. Good? Bad? How much? &nbsp;<a href="http://weblogs.asp.net/owscott/archive/2009/02/22/iis-7-compression-good-bad-how-much.aspx">http://weblogs.asp.net/owscott/archive/2009/02/22/iis-7-compression-good-bad-how-much.aspx</a></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

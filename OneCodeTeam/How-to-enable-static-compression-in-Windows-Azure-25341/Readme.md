# How to enable static compression in Windows Azure applications
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* VM
* Compression
## IsPublished
* True
## ModifiedDate
* 2013-10-15 08:37:39
## Description

<h1><span lang="EN-US">Enable static compression in Azure (VBAzureEnableCompression)</span></h1>
<h2><span lang="EN-US" style="color:black">Introduction </span></h2>
<p class="MsoNormal" style="margin-bottom:10.0pt; line-height:13.0pt; background:white">
<span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black">Static compression is the feature that is shipped out of the box in IIS. Using static compression, developers/administrators can enable faster downloads of their web site
 static content like javascripts, text files, Microsoft office documents, html/htm files, vb files, etc.<span style="">&nbsp;
</span>So, how can we make use of this feature when hosting the web application in Windows Azure? By default static compression is enabled in Windows Azure, however, there are only few mime types that will be compressed. This sample demonstrates adding new
 mime types for static compression.</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<h2><span lang="EN-US" style="color:black">Building the Sample </span></h2>
<p class="MsoNormal" style="text-autospace:none"><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black">This sample can be run as-is without making any changes to it.
</span></p>
<h2><span lang="EN-US" style="color:black">Running the Sample</span><span lang="EN-US" style="color:black">
</span></h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">2)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Right click on the cloud service project i.e. VBAzureEnableCompression and choose Publish&lt;o:p&gt;.&lt;/o:p&gt;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">3)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Follow the steps in publish Wizard and choose subscription details, deployment slots, etc. and enable remote desktop for all roles&lt;o:p&gt;.&lt;/o:p&gt;</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">4)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">After successful publish, browse to a page that has javascript files and then login to Azure VM and verify that the cache directory has the compressed files.
</span></p>
<h2><span lang="EN-US" style="color:black">Using the Code</span><span lang="EN-US" style="color:black">
</span></h2>
<p class="MsoNormal" style="background:white"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black">To customize static compression settings in Windows Azure, you can use startup tasks. Below are the steps I have followed
 to successfully enable static compression for few of the mime types my application needed.</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoListParagraph" style="text-indent:5.0pt; background:white"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black"><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black">Configure following tag in Application's web.config @Configuration/System.WebServer</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoNormal" style="margin-left:18.0pt; background:white"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoListParagraph" style="text-indent:5.0pt; background:white"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black"><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black">Create iisconfigchanges.cmd file with required commands to customize ApplicationHost.config configuration of IIS
</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormal" style="margin-left:61.5pt; background:white"><b style=""><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black">iisconfigchanges.cmd
</span></b><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormal" style="margin-left:61.5pt; background:white"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:#3B3B3B">%windir%\system32\inetsrv\appcmd.exe set config -section:system.webServer/httpCompression /&#43;&quot;staticTypes.[mimeType='application/x-javascript',enabled='True']&quot;
 /commit:apphost</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoNormal" style="margin-left:61.5pt; background:white"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:#3B3B3B">%windir%\system32\inetsrv\appcmd.exe set config -section:system.webServer/httpCompression /&#43;&quot;staticTypes.[mimeType='text/javascript',enabled='True']&quot;
 /commit:apphost</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoNormal" style="margin-left:61.5pt; background:white"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:#3B3B3B">%windir%\system32\inetsrv\appcmd.exe set config -section:system.webServer/httpCompression /&#43;&quot;staticTypes.[mimeType='application/vnd.openxmlformats-officedocument.wordprocessingml.document',enabled='True']&quot;
 /commit:apphost</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoNormal" style="margin-left:61.5pt; background:white"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:#3B3B3B">%windir%\system32\inetsrv\appcmd.exe set config -section:system.webServer/httpCompression /&#43;&quot;staticTypes.[mimeType='application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',enabled='True']&quot;
 /commit:apphost</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoNormal" style="margin-left:61.5pt; background:white"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:#3B3B3B">%windir%\system32\inetsrv\appcmd.exe set config -section:system.webServer/httpCompression /&#43;&quot;staticTypes.[mimeType='application/vnd.openxmlformats-officedocument.presentationml.presentation',enabled='True']&quot;
 /commit:apphost</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoNormal" style="margin-left:61.5pt; background:white"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:#3B3B3B">%windir%\system32\inetsrv\appcmd.exe set config -section:serverruntime /frequentHitThreshold:1 /commit:APPHOST</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoNormal" style="margin-left:61.5pt; background:white"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:#3B3B3B">exit /b 0</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoNormal" style="margin-left:25.5pt; background:white"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black">Above commands configures MIME types for javascripts, word documents (docx), Excel documents(xlsx),
 Powerpoint documents(pptx). If you need to compress any specific files other than mentioned above, find out the MIME types per your requirement and add similar commands to the file.
</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormal" style="margin-left:25.5pt; background:white"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black">Note: I have changed
</span><b style=""><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:#3B3B3B">frequentHitThreshold</span></b><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:#3B3B3B"> parameter since I could
 not see compression happening without explicitly specifying this parameter.</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoListParagraph" style="text-indent:5.0pt; background:white"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black"><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black">Add below startup task that will execute
</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black">iisconfigchanges.cmd during startup of the rule. This configuration should be added in
<b style="">ServiceConfiguration.csdef</b> under webrole/workerrole tag.</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoNormal" style="margin-left:43.5pt; background:white"><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:blue"></span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt; background:white">
<span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black"><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black">Add</span><b style=""><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black"> iisconfigchanges.cmd</span></b><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black">
 file to webrole/workerrole project </span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">&lt;o:p&gt;.&lt;/o:p&gt;</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-top:7.5pt; margin-right:51.0pt; margin-bottom:7.5pt; margin-left:36.0pt; text-indent:5.0pt; background:white">
<span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black"><span style="">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Configure below file properties for
<b style=""><span style="color:black">iisconfigchanges.cmd</span></b> file , so that it will be copied to bin directory&lt;o:p&gt;.&lt;/o:p&gt;</span></p>
<p class="MsoNormalCxSpFirst" style="margin-top:7.5pt; margin-right:51.0pt; margin-bottom:7.5pt; margin-left:43.5pt; background:white">
<span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black">Build Action : Content</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoNormalCxSpMiddle" style="margin-top:7.5pt; margin-right:51.0pt; margin-bottom:0cm; margin-left:43.5pt; margin-bottom:.0001pt; background:white">
<span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black">Copy To Output Directory : Copy Always</span><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span></p>
<p class="MsoNormal" style=""><span lang="EN-US"></span></p>
<p class="MsoNormal" style=""><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Caution: Compression settings should be tweaked carefully, It might result in undesired performance too if not configured properly. For example,
 images like png are already compressed and compressing these types again, will cause additional CPU on the system without any significant gain in the bandwidth. I recommend you to research and thoroughly test your application with the compression settings
 before you apply the changes to production.<span style="">&nbsp; </span>I recommend below blog entry for further reading on IIS7 compression.
</span></p>
<p class="MsoNormal" style=""><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoNormal" style=""><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">&nbsp;</span>IIS 7 Compression. Good? Bad? How much?
</span></p>
<p class="MsoNormal" style=""><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">&nbsp;</span><a href="http://weblogs.asp.net/owscott/archive/2009/02/22/iis-7-compression-good-bad-how-much.aspx">http://weblogs.asp.net/owscott/archive/2009/02/22/iis-7-compression-good-bad-how-much.aspx</a>
</span></p>
<p class="MsoNormal" style=""><span lang="EN-US" style=""></span></p>
<p class="MsoNormal" style=""><span lang="EN-US" style=""></span></p>
<p class="MsoNormal" style=""><span lang="EN-US" style=""></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

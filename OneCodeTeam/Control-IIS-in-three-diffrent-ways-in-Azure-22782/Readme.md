# Control IIS in three diffrent ways in Azure
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
* 2013-06-17 07:18:50
## Description

<h1><span lang="EN-US">Full control IIS on cloud service (VBAuzreControlIIS)</span></h1>
<h2><span lang="EN-US">Introduction</span></h2>
<h2><span lang="EN-US" style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">As we know, cloud service can full control IIS. If someone want to change IIS, they will probably first think about using startup script,
 since it has been documented in Azure training kit. </span></h2>
<h2><span lang="EN-US" style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">That&#39;s a good way but not the only way. Actually we can use site class and Configuration config to achieve that.
</span></h2>
<h2><span lang="EN-US" style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">This sample will show you how can we control IIS by two different ways in Azure Cloud service.
</span></h2>
<h2><span lang="EN-US">Running the Sample</span></h2>
<p class="Normal" style="margin-left:18.0pt"><span lang="EN-US">1. Open your cloud service property, make sure your cloud service run with IIS web server.</span></p>
<p class="Normal" style="margin-left:18.0pt"><span lang="EN-US" style=""><img src="/site/view/file/85198/1/image.png" alt="" width="576" height="197" align="middle">
</span></p>
<p class="Normal" style="margin-left:18.0pt"><span lang="EN-US">2. Press Ctrl&#43;F5 to run the application.</span></p>
<p class="Normal" style="margin-left:18.0pt"><span lang="EN-US">3. Open your IIS, you can find that you have a temp application pool, and pipeline mode is set to Classic and logExtFileFlags only has tow filters.</span></p>
<p class="Normal" style="margin-left:18.0pt"><span lang="EN-US" style=""><img src="/site/view/file/85199/1/image.png" alt="" width="576" height="132" align="middle">
</span></p>
<p class="Normal" style="margin-left:18.0pt"><span lang="EN-US" style=""><img src="/site/view/file/85200/1/image.png" alt="" width="576" height="186" align="middle">
</span></p>
<p class="Normal" style="margin-left:18.0pt"><span lang="EN-US"></span></p>
<h2><span lang="EN-US">Using code</span></h2>
<p class="Normal"><span lang="EN-US">We can create a class inherits RoleEntryPoint Class, and override OnStart () method.</span></p>
<p class="Normal"><span lang="EN-US">And control your server's Pipeline mode by code.</span></p>
<h3><span lang="EN-US">Control the web role on instance by VB.</span></h3>
<p class="Normal"><span lang="EN-US"></span></p>
<p class="Normal"><b><span lang="EN-US" style="font-family:&quot;Calibri Light&quot;,&quot;sans-serif&quot;">Show the server application pool Pipe mode.
</span></b></p>
<p class="Normal"><span lang="EN-US"></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

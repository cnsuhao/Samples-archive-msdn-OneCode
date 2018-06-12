# Multithreaded web downloader
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Networking
* Windows Desktop App Development
## Topics
* threading
* Download
## IsPublished
* True
## ModifiedDate
* 2013-07-28 10:51:40
## Description

<h1>How to Download a File on Web Using Multiple Threads (<span class="SpellE">CSMultiThreadedWebDownloader</span>)</h1>
<h2>Introduction</h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">The sample demonstrates how to download a file on Web using multiple threads.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">The class
<span class="SpellE">System.Net.WebClient</span> has a <span class="SpellE">DownloadProgressChanged</span> event, and you can register this event to show the progress. But this class does not support Pause/Resume.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">The class
<span class="SpellE">MultiThreadedWebDownloader</span> in this sample could be used to download data through internet and supports following features:
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">1. Download the whole file using multiple threads.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">2. Set the proxy.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">3. Set the buffer and cache size.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">4. Start, Pause, Resume and Cancel a download.<span style="">&nbsp;
</span></span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">5. Supply the file size, download speed and used time.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">6. Expose the events
<span class="SpellE">StatusChanged</span>, <span class="SpellE">DownloadProgressChanged</span> and
<span class="SpellE">DownloadCompleted</span>. </span></h2>
<h2>Building the Sample<span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">1. To pause and resume a download, or download a file using multi-threads, the server must support &quot;Accept-Ranges&quot; header, so that we can
 add range to the <span class="SpellE">webrequset</span> to download a specified block of the file.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal"></span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">2. If you are trying to download a single file using multiple threads/
<span class="GramE">multiple <span style="">&nbsp;</span><span class="SpellE">HttpWebRequest's</span></span>, multiple requests (each asking for a different range) will all be pipelined over a single connection (not necessarily all). You have to take into consideration
 as to how many threads you are spinning, and how many max Connections you have set for the
<span class="SpellE">ServicePointManager</span>. By default, <span class="SpellE">
ServicePointManager</span> has a default of 2 max connections for console applications, so only 2 requests can be active at a time and will be downloading 2 parts of the large file. So yes, your approach will speed up the download, but you also need to take
 into account the maximum number of connections. If you increase the number of available connections, you will get a better download rate. But, do not increase it to a very large
<span class="GramE">value,</span> otherwise you will end up spiking the CPU due to the overhead of creating multiple connections simultaneously. Try to limit the max Conn number = 12.
</span></h2>
<h2>Running the Sample</h2>
<p class="MsoNormal">Step1. Build the sample project in Visual Studio 2012.</p>
<p class="MsoNormal">Step2. Run CSMultiThreadedWebDownloader.exe</p>
<p class="MsoNormal">Step3. Type following link as <span class="SpellE"><span class="GramE">url</span></span>.
</p>
<p class="MsoNormal">http://download.microsoft.com/download/9/5/A/95A9616B-7A37-4AF6-BC36-D6EA96C8DAAE/dotNetFx40_Full_x86_x64.exe</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/93185/1/image.png" alt="" width="576" height="162" align="middle">
</span></p>
<p class="MsoNormal">Step4. Type a local path like D:\DotNetFx4.exe.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/93186/1/image.png" alt="" width="576" height="162" align="middle">
</span></p>
<p class="MsoNormal">Step5. Click the button &quot;Download&quot;<span class="GramE">,</span> you will see the status &quot;Downloading&quot;.</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><span style=""><img src="/site/view/file/93187/1/image.png" alt="" width="576" height="162" align="middle">
</span><span style="">&nbsp;</span></p>
<p class="MsoNormal">In Windows Explorer, you will find a <span class="GramE">
file<span style="">&nbsp; </span>D</span>:\DotNetFx4.exe.tmp.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/93188/1/image.png" alt="" width="79" height="127" align="middle">
</span></p>
<p class="MsoNormal">Step6. Click the button &quot;Pause&quot;<span class="GramE">,</span> you will see the status &quot;Paused&quot;.</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><span style=""><img src="/site/view/file/93189/1/image.png" alt="" width="576" height="162" align="middle">
</span></p>
<p class="MsoNormal">If the server does not support &quot;Accept-Ranges&quot; header, the &quot;Pause&quot; button is disabled.
</p>
<p class="MsoNormal">Step7. Click the button &quot;Resume&quot;.</p>
<p class="MsoNormal">Step8. When the download completes, you will see the status &quot;Completed&quot;.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/93190/1/image.png" alt="" width="576" height="162" align="middle">
</span><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>
<p class="MsoNormal">In Windows Explorer, you will find a file D:\DotNetFx4.exe.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/93191/1/image.png" alt="" width="95" height="113" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span class="MsoHyperlink"><a href="http://msdn.microsoft.com/en-us/library/system.net.webrequest.aspx"><span class="SpellE"><span class="GramE">system.net.webrequest</span></span> class</a>
</span></p>
<p class="MsoNormal" style=""><span class="MsoHyperlink"><a href="http://social.msdn.microsoft.com/Forums/en-US/csharpgeneral/thread/e115d4a1-5800-4f2a-98d8-079de6cf8a1a">How can
<span class="SpellE">i</span> check if file download completed</a> </span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

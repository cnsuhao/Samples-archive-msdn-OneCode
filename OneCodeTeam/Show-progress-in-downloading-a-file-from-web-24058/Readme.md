# Show progress in downloading a file from web
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Networking
* Windows Desktop App Development
## Topics
* Download Progress
## IsPublished
* True
## ModifiedDate
* 2013-07-28 10:52:02
## Description

<h1>How to Create a Simple Web Downloader and Show the Download Progress (<span class="SpellE">CSWebDownloader</span>)</h1>
<h2>Introduction</h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">The sample demonstrates how to show progress during the download.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">The class
<span class="SpellE">System.Net.WebClient</span> has a <span class="SpellE">DownloadProgressChanged</span> event, and you can register this event to show the progress. But this class does not support Pause/Resume.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">The class
<span class="SpellE">HttpDownloadClient</span> in this sample could be used to download data through internet and supports following features:
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">1. Set the buffer and cache size.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">2. Download a specified block data of the whole file.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">3. Start, Pause, Resume and Cancel a download.<span style="">&nbsp;
</span></span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">4. Supply the file size, download speed and used time.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">5. Expose the events
<span class="SpellE">StatusChanged</span>, <span class="SpellE">DownloadProgressChanged</span> and
<span class="SpellE">DownloadCompleted</span>. </span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">NOTE: To enable the Feature2 and Feature3, the server must support the http &quot;Accept-Ranges&quot; header.
</span></h2>
<h2>Running the Sample</h2>
<p class="MsoNormal">Step1. Build the sample project in Visual Studio 2012.</p>
<p class="MsoNormal">Step2. Run CSWebDownloader.exe</p>
<p class="MsoNormal">Step3. Type following link as <span class="SpellE"><span class="GramE">url</span></span>.
</p>
<p class="MsoNormal">http://download.microsoft.com/download/9/5/A/95A9616B-7A37-4AF6-BC36-D6EA96C8DAAE/dotNetFx40_Full_x86_x64.exe</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/93193/1/image.png" alt="" width="576" height="166" align="middle">
</span></p>
<p class="MsoNormal">Step4. Type a local path like D:\DotNetFx4.exe.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/93194/1/image.png" alt="" width="576" height="166" align="middle">
</span></p>
<p class="MsoNormal">Step5. Click the button &quot;Download&quot;<span class="GramE">,</span> you will see the status &quot;Downloading&quot;.</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><span style=""><img src="/site/view/file/93195/1/image.png" alt="" width="576" height="166" align="middle">
</span><span style="">&nbsp;</span></p>
<p class="MsoNormal">In Windows Explorer, you will find a <span class="GramE">
file<span style="">&nbsp; </span>D</span>:\DotNetFx4.exe.tmp.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/93196/1/image.png" alt="" width="79" height="127" align="middle">
</span></p>
<p class="MsoNormal">Step6. Click the button &quot;Pause&quot;<span class="GramE">,</span> you will see the status &quot;Paused&quot;.</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><span style=""><img src="/site/view/file/93197/1/image.png" alt="" width="576" height="166" align="middle">
</span></p>
<p class="MsoNormal">If the server does not support &quot;Accept-Ranges&quot; header, the &quot;Pause&quot; button is disabled.
</p>
<p class="MsoNormal">Step7. Click the button &quot;Resume&quot;, you will see the status &quot;Downloading&quot;.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/93198/1/image.png" alt="" width="576" height="166" align="middle">
</span></p>
<p class="MsoNormal">Step8. When the download completes, you will see the status &quot;Completed&quot;.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/93199/1/image.png" alt="" width="576" height="166" align="middle">
</span><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>
<p class="MsoNormal">In Windows Explorer, you will find a <span class="GramE">
file<span style="">&nbsp; </span>D</span>:\DotNetFx4.exe.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/93200/1/image.png" alt="" width="95" height="113" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span class="MsoHyperlink"><a href="http://msdn.microsoft.com/en-us/library/system.net.httpwebrequest.aspx"><span class="SpellE">HttpWebRequest</span> Class</a>
</span></p>
<p class="MsoNormal" style=""><span class="MsoHyperlink"><a href="http://msdn.microsoft.com/en-us/library/7fy67z6d.aspx"><span class="SpellE">AddRange</span> Method</a>
</span></p>
<p class="MsoNormal" style=""><span class="MsoHyperlink"><a href="http://social.msdn.microsoft.com/Forums/en-US/csharpgeneral/thread/e115d4a1-5800-4f2a-98d8-079de6cf8a1a">How can
<span class="SpellE">i</span> check if file download completed</a> </span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

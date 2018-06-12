# Show progress in downloading a file from web (VBWebDownloader)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Windows General
* Network
## Topics
* HTTP Download
## IsPublished
* True
## ModifiedDate
* 2011-08-08 02:54:04
## Description

<p style="font-family:Courier New"></p>
<h2>Windows APPLICATION: VBWebDownloader</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New">The sample demonstrates how to show progress during the download.<br>
<br>
The class System.Net.WebClient has a DownloadProgressChanged event, and you can register<br>
this event to show the progress. But this class does not support Pause/Resume.<br>
<br>
The class HttpDownloadClient in this sample could be used to download data through
<br>
internet and supports following features:<br>
1. Set the buffer and cache size.<br>
2. Download a specified block data of the whole file. <br>
3. Start, Pause, Resume and Cancel a download. &nbsp;<br>
4. Supply the file size, download speed and used time.<br>
5. Expose the events StatusChanged, DownloadProgressChanged and DownloadCompleted.<br>
<br>
NOTE: To enable the Feature2 and Feature3, the server must support the http<br>
&nbsp; &nbsp; &nbsp;&quot;Accept-Ranges&quot; header. <br>
&nbsp; </p>
<h3>Demo:</h3>
<p style="font-family:Courier New">Step1. Build the sample project in Visual Studio 2008.<br>
<br>
Step2. Run VBWebDownloader.exe<br>
<br>
Step3. Type following link as url.<br>
<a target="_blank" href="http://download.microsoft.com/download/9/5/A/95A9616B-7A37-4AF6-BC36-D6EA96C8DAAE/dotNetFx40_Full_x86_x64.exe">http://download.microsoft.com/download/9/5/A/95A9616B-7A37-4AF6-BC36-D6EA96C8DAAE/dotNetFx40_Full_x86_x64.exe</a><br>
<br>
Step4. Type a local path like D:\DotNetFx4.exe.<br>
<br>
Step5. Click the button &quot;Download&quot;, you will see the status &quot;Downloading&quot; and the summary
<br>
&quot;Received: ***KB, Total: ***KB, Speed: ***KB/s&quot;, the progressbar will also change.<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; In Windows Explorer, you will find a file &nbsp;D:\DotNetFx4.exe.tmp.<br>
<br>
Step6. Click the button &quot;Pause&quot;, you will see the status &quot;Paused&quot; and the summary
<br>
&quot;Received: ***KB, Total: ***KB, Time: ***&quot;, the progressbar will also stop.<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; If the server does not support &quot;Accept-Ranges&quot; header, the &quot;Pause&quot; button is<br>
&nbsp; &nbsp; &nbsp; disabled. <br>
<br>
Step7. Click the button &quot;Resume&quot;, you will see the status &quot;Downloading&quot; and the summary
<br>
&quot;Received: ***KB, Total: ***KB, Speed: ***KB/s&quot;, the progressbar will also change.<br>
<br>
Step8. When the download completes, you will see the status &quot;Completed&quot; and the summary
<br>
&quot;Received: ***KB, Total: ***KB, Time: ***&quot;, the progressbar will also stop.<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; In Windows Explorer, you will find a file &nbsp;D:\DotNetFx4.exe.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. When a HttpDownloadClient object is created, initialize the fields/properties<br>
&nbsp; StartPoint, EndPoint, BufferSize, MaxCacheSize, BufferCountPerNotification, Url<br>
&nbsp; DownloadPath and Status.<br>
<br>
2. When the download starts, check whether the destination file exists. If not, create<br>
&nbsp; a local file with the same size as the file to be downloaded, then download
<br>
&nbsp; the file in a background thread.<br>
<br>
3. The download thread will read a buffer of bytes from the response stream, and store the<br>
&nbsp; buffer to a MemoryStream cache first. If the cache is full, or the download is paused,
<br>
&nbsp; canceled or completed, write the data in cache to local file.<br>
<br>
4. Raise the event DownloadProgressChanged when read a specified number of buffers.<br>
<br>
5. If the download is paused, store the downloaded size. When it is resumed, start to
<br>
&nbsp; download the file from a start point.<br>
<br>
6. Update the used time and status when the current download stops.<br>
<br>
7. Raise the event DownloadCompleted when the download is completed or canceled.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
HttpWebRequest Class <br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.net.httpwebrequest.aspx">http://msdn.microsoft.com/en-us/library/system.net.httpwebrequest.aspx</a><br>
AddRange Method <br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/7fy67z6d.aspx">http://msdn.microsoft.com/en-us/library/7fy67z6d.aspx</a><br>
How can i check if file download completed<br>
<a target="_blank" href="http://social.msdn.microsoft.com/Forums/en-US/csharpgeneral/thread/e115d4a1-5800-4f2a-98d8-079de6cf8a1a">http://social.msdn.microsoft.com/Forums/en-US/csharpgeneral/thread/e115d4a1-5800-4f2a-98d8-079de6cf8a1a</a><br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

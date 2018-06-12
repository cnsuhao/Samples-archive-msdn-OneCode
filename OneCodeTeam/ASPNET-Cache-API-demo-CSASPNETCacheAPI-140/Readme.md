# ASP.NET Cache API demo (CSASPNETCacheAPI)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Caching
## IsPublished
* True
## ModifiedDate
* 2011-05-05 04:54:55
## Description

<p style="font-family:Courier New"></p>
<h2>ASP.NET web application project : CSASPNETCacheAPI OverView</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The example shows how to use Cache API. You can open the Default.aspx page <br>
and then choose the one to view:<br>
<br>
1. Simple Cache object.<br>
<br>
2. Use Cache with File-Based dependence. <br>
<br>
3. Use Cache with Key-Based dependence. <br>
<br>
4. Use Cache with absolute Time-Based dependence. <br>
<br>
5. Use Cache with sliding Time-Based dependence. <br>
<br>
6. Use Cache with CallBack. <br>
<br>
</p>
<h3>Project Relation:</h3>
<p style="font-family:Courier New"><br>
CustomDataSource.xml is the data source file, which is used in File-Based<br>
dependence Cache.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. Simple Cache object.<br>
<br>
&nbsp;Cache is key/value pair object. We can simple add value to it and save it<br>
&nbsp;in memory. To remove it, you can use Cache.Remove method. <br>
<br>
<br>
2. Use Cache with File-Based dependence. <br>
<br>
&nbsp;Set file dependence for Cache. In this demo, the cached time will be changed<br>
&nbsp;when you change the file &quot;CustomDataSource.xml&quot; in App_Data folder.<br>
<br>
<br>
3. Use Cache with Key-Based dependence. <br>
<br>
&nbsp; Use another Cache object as dependence.When that Cache is expiration <br>
&nbsp; the current Cache will be expiration too.<br>
<br>
4. Use Cache with sliding Time-Based dependence.<br>
<br>
&nbsp; Set Cache's sliding expiration to 10 seconds. So the cached datetime will <br>
&nbsp; be changed when the Cache is not requested within 10 seconds.<br>
<br>
5. Use Cache with absolute Time-Based dependence.<br>
<br>
&nbsp; Set Cache's absolute expiration to 10 seconds. So the cached datetime will
<br>
&nbsp; be changed after 10 seconds.<br>
<br>
6. Use Cache with CallBack. <br>
<br>
&nbsp; &nbsp;Set Cache's absolute time to 10s and call RemovedCallback method when
<br>
&nbsp; &nbsp;Cache is expiration.&nbsp;&nbsp;&nbsp;&nbsp;<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
ASP.NET Caching Overview<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms178597(VS.80).aspx">http://msdn.microsoft.com/en-us/library/ms178597(VS.80).aspx</a><br>
<br>
Cache Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.caching.cache.aspx">http://msdn.microsoft.com/en-us/library/system.web.caching.cache.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

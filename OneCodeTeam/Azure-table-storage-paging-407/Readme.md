# Azure table storage paging (CSAzureTableStoragePaging)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* Paging
* Table Storage
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:29:08
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<h2>WINDOWSAZURE : CSAzureTableStoragePaging Solution Overview</h2>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
It's a common scenario that we want to use paging for table storage. However,<br>
due to current limitation of Table storage it only supports continuation token<br>
that can help us implement a simple previous/next paging. This sample demonstrates<br>
how to implement previous/next paging in a MVC application. The classes in the <br>
TableStoragePagingUtility.cs file can be reused for other applications. If you want
<br>
to reuse the code, what you need to do is to implement custom ICachedDataProvider&lt;T&gt;
<br>
class to store data required by TableStoragePagingUtility&lt;T&gt;.<br>
<br>
Please note due to the limitation of the Table storage we could only do forward-only<br>
reading, which means if we want to get the latest data we have to read from the begining.<br>
In this sample we just fetch data from Table storage and save it in cache. All data<br>
is read from cache.</p>
<div align="right">
<p><a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420"><span style="color:windowtext; text-decoration:none"><span><img src="http://code.msdn.microsoft.com/site/view/file/67654/1/image.png" alt="" width="120" height="90" align="middle">
</span></span></a><br>
<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420">Try Windows Azure for free for 90 Days!</a></p>
</div>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
Windows Azure Tools for Microsoft Visual Studio<br>
<a href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=7a1089b6-4050-4307-86c4-9dadaa5ed018" target="_blank">http://www.microsoft.com/downloads/en/details.aspx?FamilyID=7a1089b6-4050-4307-86c4-9dadaa5ed018</a><br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
A. Make sure CloudService is set as start up project. Press F5 to start debugging.<br>
B. Click &quot;Add data to test first&quot; link on the page.<br>
C. View the table shown on the page.<br>
D. Click &quot;Next&quot; or &quot;Previous&quot; link to test the paging function.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Query Timeout and Pagination<br>
<a href="http://msdn.microsoft.com/en-us/library/dd135718.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/dd135718.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

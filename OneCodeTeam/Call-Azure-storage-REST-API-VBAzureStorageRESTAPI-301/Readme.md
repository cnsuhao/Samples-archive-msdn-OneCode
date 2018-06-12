# Call Azure storage REST API (VBAzureStorageRESTAPI)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* REST
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:46:33
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<h2>AZURESTORAGE : VBAzureStorageRESTAPI Solution Overview</h2>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
Sometimes we need to use raw REST API instead of the StorageClient class<br>
provided by SDK. i.e. inserting an entity to table storage without schema, writing<br>
a &quot;StorageClient&quot; library in other programming languages, etc.This sample shows<br>
how to generate an HTTP message that uses the List Blobs API. You may reuse the<br>
code to add authentication header to call other REST APIs.<br>
<br>
</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
Windows Azure Tools for Microsoft Visual Studio<br>
<a href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=7a1089b6-4050-4307-86c4-9dadaa5ed018" target="_blank">http://www.microsoft.com/downloads/en/details.aspx?FamilyID=7a1089b6-4050-4307-86c4-9dadaa5ed018</a><br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
A. Make sure Storage Emulator is running.<br>
<br>
B. Start debugging.<br>
<br>
C. Input the name of a container in Blob storage and press &lt;ENTER&gt;.<br>
<br>
D. Observe the output that lists all blobs information in that container.<br>
<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Differences Between the Storage Emulator and Windows Azure Storage Services<br>
<a href="http://msdn.microsoft.com/en-us/library/gg433135.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/gg433135.aspx</a><br>
<br>
List Blobs<br>
<a href="http://msdn.microsoft.com/en-us/library/dd135734.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/dd135734.aspx</a><br>
<br>
Authentication Schemes<br>
<a href="http://msdn.microsoft.com/en-us/library/dd179428.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/dd179428.aspx</a></p>
<p style="font-family:Courier New"><a href="http://msdn.microsoft.com/en-us/library/dd179428.aspx" target="_blank"></a><span style="font-family:Verdana,Arial,Helvetica,sans-serif">Initialize the Storage Emulator by Using the DSInit Command-Line Tool</span></p>
<p><a href="http://msdn.microsoft.com/en-us/library/gg433132.aspx">http://msdn.microsoft.com/en-us/library/gg433132.aspx</a></p>
<p style="font-family:Courier New">&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

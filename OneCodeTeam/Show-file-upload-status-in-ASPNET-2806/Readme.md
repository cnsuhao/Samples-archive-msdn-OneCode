# Show file upload status in ASP.NET (CSASPNETFileUploadStatus)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Upload
* Download
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:00:45
## Description

<p style="font-family:Courier New"></p>
<h2>CSASPNETFileUploadStatus Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The project illustrates how to show the file upload status based on AJAX<br>
without a third part component like ActiveX control, Flash or Silverlight.<br>
It's also a solution for big file uploading.<br>
</p>
<h3>Principle:</h3>
<p style="font-family:Courier New"><br>
When a file is uploading, the server will get the request data like below.<br>
(P.S. we can get this part when we upload a file by a tool like Fiddler.)<br>
<br>
/*---------Sample reference Start------*/<br>
POST <a target="_blank" href="&lt;a target=" href="http://jerrywengserver/UploadControls.aspx">
http://jerrywengserver/UploadControls.aspx</a>'&gt;<a target="_blank" href="http://jerrywengserver/UploadControls.aspx">http://jerrywengserver/UploadControls.aspx</a> HTTP/1.1<br>
Accept: application/x-ms-application, image/jpeg, application/xaml&#43;xml, <br>
&nbsp; &nbsp; &nbsp; &nbsp;image/gif, image/pjpeg, application/x-ms-xbap,<br>
&nbsp; &nbsp; &nbsp; &nbsp;application/x-shockwave-flash, */*<br>
Referer: <a target="_blank" href="&lt;a target=" href="http://jerrywengserver/UploadControls.aspx">
http://jerrywengserver/UploadControls.aspx</a>'&gt;<a target="_blank" href="http://jerrywengserver/UploadControls.aspx">http://jerrywengserver/UploadControls.aspx</a><br>
Accept-Language: en-US<br>
User-Agent: Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; WOW64;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;.NET CLR 3.0.30729; Media Center PC 6.0; InfoPath.3; MS-RTC LM 8;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;.NET4.0C; .NET4.0E)<br>
Content-Type: multipart/form-data; boundary=---------------------------7da106f207ba<br>
Accept-Encoding: gzip, deflate<br>
Host: jerrywengserver<br>
Content-Length: 1488<br>
Connection: Keep-Alive<br>
Pragma: no-cache<br>
<br>
-----------------------------7da106f207ba<br>
Content-Disposition: form-data; name=&quot;__VIEWSTATE&quot;<br>
<br>
/wEPDwUKMTI3MTMxMTcxNw9kFgICAw8WAh4HZW5jdHlwZQUTbXVsdGlwYXJ0L2Zvcm0tZGF0YWRkcrWP136t6D4d&#43;g8BDfyR5WF&#43;aP/yi4YARRyuOuRsO1M=<br>
-----------------------------7da106f207ba<br>
Content-Disposition: form-data; name=&quot;__EVENTVALIDATION&quot;<br>
<br>
/wEWAgL5mtyRBALt3oXMA9W4TniGaEKs/xcWf28H93S&#43;wRcfLHr35wNo&#43;N1v9gQ5<br>
-----------------------------7da106f207ba<br>
Content-Disposition: form-data; name=&quot;fuFile&quot;; filename=&quot;C:\******\FileUploadTest.txt&quot;<br>
Content-Type: text/plain<br>
<br>
*****This part is the content of the uploaed file!*****<br>
-----------------------------7da106f207ba<br>
Content-Disposition: form-data; name=&quot;btnUpload&quot;<br>
<br>
Upload<br>
-----------------------------7da106f207ba--<br>
/*---------Sample reference End-----*/<br>
<br>
There are some useful information in the head part, for example,<br>
&nbsp;The content-Type of this request.<br>
&nbsp;The boundary which seperate the body part.<br>
&nbsp;The content-length of this request.<br>
&nbsp;Some request variables.<br>
&nbsp;The filename of the uploaded file and its content-type.<br>
<br>
If we analyze the data, we can find some tips like below.<br>
&nbsp;1. All the request data is sperated by a boundary which is defined in <br>
&nbsp; &nbsp; the content-type of the head part.<br>
&nbsp;2. The name and the value of one parameter is seperated by a newline.<br>
&nbsp;3. If the parameter is a file, we can get the filename and<br>
&nbsp; &nbsp; content-type of the file<br>
&nbsp;4. The data of the file followed the content-type of the file.<br>
<br>
So when the server has got all these data, the uploading will be finished.<br>
The prolem left here is how can we get to know that how much data <br>
the server had read and is there a way that we can control the length <br>
which the server read by one time.<br>
<br>
For IIS and .Net Framework, we can control this by a HTTPModule.<br>
Data reading will be started in BeginRequest event.<br>
And the HttpWorkerRequest class could control the reading process.<br>
<br>
We can use HttpWorkerRequest.GetPreloadedEntityBody() to get <br>
the first part of the request data which the server read. <br>
If the data is too large, HttpWorkerRequest.IsEntireEntityBodyIsPreloaded <br>
will return false, we can use HttpWorkerRequest.ReadEntityBody() to read the<br>
left data. By this way, we can know how much data loaded and how much left.<br>
At last, we need to send the status back to the server,<br>
here I store the status to the Cache.<br>
<br>
Another important issue is how the client side get the status from <br>
the server side without postback to the server.<br>
The answer is to use AJAX feature. Here we use ICallBackEventHandler, <br>
because it is easy to handle and clear enough for us to understand the process.<br>
We can learn how to use it from the reference at the bottom of this readme file.<br>
We can also use jQuery ajax to call back a web service or generic handler to<br>
get the status.<br>
<br>
Demo the Sample. <br>
<br>
Step 1. Build the website &quot;WSFileUploadStatus&quot;.<br>
<br>
Step 2. View the Default.aspx in the browser.<br>
<br>
Step 3. Select a file which you want to test the sample.<br>
<br>
Step 4. Click Upload button. And you will see the upload status in details.<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step 1. &nbsp;Create a C# Code Project in Visual Studio 2010 or Visual Web<br>
Developer 2010. Name it as UploadStatus.<br>
<br>
Step 2. &nbsp;Add the two references into the project, System.Web.Extension and <br>
System.Web.<br>
<br>
Step 3. &nbsp;Copy the code from the UploadStatus.cs from the sample folder, <br>
&quot;FileUploadStatus&quot;.<br>
<br>
Step 4. &nbsp;Add an ASP.NET Module and named it as UploadProcessModule.<br>
<br>
Step 5. &nbsp;Copy the code from the UploadProcessModule.cs in the sample folder,
<br>
&quot;FileUploadStatus&quot;.<br>
<br>
Step 6. &nbsp;Also create the files: BinaryHelper.cs, UploadFile.cs, <br>
UploadFileCollection.cs and FileUploadDataManager.cs, and copy the codes.<br>
<br>
Step 7. &nbsp;Save and Build the project.<br>
[Caution] Be sure the project is released on &quot;ANY CPU&quot;.<br>
We can't add this project reference which is x86 version to the website <br>
deployed on an x64 system platform.<br>
<br>
Step 8. &nbsp;Add a new Empty ASP.NET WebSite into the solution,<br>
name it as WSFileUploadStatus.<br>
<br>
Step 9. &nbsp;Add the project reference, &quot;UploadStatus&quot;, which we created at first.<br>
<br>
Step 10. &nbsp;Create a new Web User Control named as UploadStatusWindow.ascx.<br>
We will use this user control to hold a Popup window to show <br>
the status information. Copy the markups from the UploadStatusWindow.ascx<br>
in the sample folder, &quot;WSFileUploadStatus&quot;.<br>
<br>
Step 11. Create an ASP.NET web page named as UploadControls.aspx. Add one<br>
FileUpload web control and one Button web control into the page. <br>
Copy the markups from UploadControls.aspx in the sample folder, <br>
&quot;WSFileUploadStatus&quot;.<br>
<br>
Step 12. Create an ASP.NET web page named as Deafult.aspx.<br>
Add an iframe into the page. Set the src to &quot;UploadControls.aspx&quot;.<br>
Copy the javascript function and markups from the Default.aspx <br>
in the sample folder, &quot;WSFileUploadStatus&quot;.<br>
<br>
Step 13. Copy the follow two folders in the sapmle folder into the website,<br>
&quot;styles&quot; and &quot;scripts&quot;.<br>
<br>
Step 14. Modify the web.config. Register the HttpModule. <br>
Set the maxRequestLength to 1048576, means max request data will be <br>
limited to 1GB. If we delpoy the website to IIS7, we need set <br>
the requestLimits in the system.webServer block.<br>
<br>
Step 15. Make sure we have made the page same as the sample.<br>
Build the solution.<br>
<br>
Step 16. Test the site.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: HttpModules<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/zec9k340(VS.71).aspx">http://msdn.microsoft.com/en-us/library/zec9k340(VS.71).aspx</a><br>
<br>
MSDN: HttpWorkerRequest Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.httpworkerrequest.aspx">http://msdn.microsoft.com/en-us/library/system.web.httpworkerrequest.aspx</a><br>
<br>
MSDN: ICallBackEventHandler Interface<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.icallbackeventhandler.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.icallbackeventhandler.aspx</a><br>
<br>
MSDN: An Introduction to JavaScript Object Notation (JSON) in JavaScript and .NET<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb299886.aspx">http://msdn.microsoft.com/en-us/library/bb299886.aspx</a><br>
<br>
MSDN: JavaScriptSerializer Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.script.serialization.javascriptserializer.aspx">http://msdn.microsoft.com/en-us/library/system.web.script.serialization.javascriptserializer.aspx</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

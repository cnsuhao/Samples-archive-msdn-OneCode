# Show file upload status in ASP.NET
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Upload
## IsPublished
* True
## ModifiedDate
* 2013-06-13 10:42:23
## Description

<h1>Show the file upload status based on AJAX (VBASPNETFileUploadStatus)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The project illustrates how to show the file upload status based on AJAX without a third part component like ActiveX control, Flash or Silverlight. It's also a solution for big file uploading.</p>
<p class="MsoNormal"><b style="">Principle</b>: <br>
When a file is uploading, the server will get the request data like below.<br>
(<b style="">P.S.</b> we can get this part when we upload a file by a tool like Fiddler.)</p>
<p class="MsoNormal">/*---------Sample reference Start------*/</p>
<p class="MsoNormal">POST http://jerrywengserver/UploadControls.aspx HTTP/1.1</p>
<p class="MsoNormal">Accept: application/x-ms-application, image/jpeg, application/xaml&#43;xml,
</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>Image/gif, image/pjpeg, application/x-ms-xbap,</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>application/x-shockwave-flash, */*</p>
<p class="MsoNormal">Referrer: http://jerrywengserver/UploadControls.aspx</p>
<p class="MsoNormal">Accept-Language: en-US</p>
<p class="MsoNormal">User-Agent: Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; WOW64;</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729;</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>.NET CLR 3.0.30729; Media Center PC 6.0; InfoPath.3; MS-RTC LM 8;</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>.NET4.0C; .NET4.0E)</p>
<p class="MsoNormal">Content-Type: multipart/form-data; boundary=---------------------------7da106f207ba</p>
<p class="MsoNormal">Accept-Encoding: gzip, deflate</p>
<p class="MsoNormal">Host: jerrywengserver</p>
<p class="MsoNormal">Content-Length: 1488</p>
<p class="MsoNormal">Connection: Keep-Alive</p>
<p class="MsoNormal">Pragma: no-cache</p>
<p class="MsoNormal"></p>
<p class="MsoNormal">-----------------------------7da106f207ba</p>
<p class="MsoNormal">Content-Disposition: form-data; name=&quot;__VIEWSTATE&quot;</p>
<p class="MsoNormal"></p>
<p class="MsoNormal">/wEPDwUKMTI3MTMxMTcxNw9kFgICAw8WAh4HZW5jdHlwZQUTbXVsdGlwYXJ0L2Zvcm0tZGF0YWRkcrWP136t6D4d&#43;g8BDfyR5WF&#43;aP/yi4YARRyuOuRsO1M=</p>
<p class="MsoNormal">-----------------------------7da106f207ba</p>
<p class="MsoNormal">Content-Disposition: form-data; name=&quot;__EVENTVALIDATION&quot;</p>
<p class="MsoNormal"></p>
<p class="MsoNormal">/wEWAgL5mtyRBALt3oXMA9W4TniGaEKs/xcWf28H93S&#43;wRcfLHr35wNo&#43;N1v9gQ5</p>
<p class="MsoNormal">-----------------------------7da106f207ba</p>
<p class="MsoNormal">Content-Disposition: form-data; name=&quot;fuFile&quot;; filename=&quot;C:\******\FileUploadTest.txt&quot;</p>
<p class="MsoNormal">Content-Type: text/plain</p>
<p class="MsoNormal">*****This part is the content of the uploaed file!*****</p>
<p class="MsoNormal">-----------------------------7da106f207ba</p>
<p class="MsoNormal">Content-Disposition: form-data; name=&quot;btnUpload&quot;</p>
<p class="MsoNormal"></p>
<p class="MsoNormal">Upload</p>
<p class="MsoNormal">-----------------------------7da106f207ba--</p>
<p class="MsoNormal">/*---------Sample reference End-----*/</p>
<p class="MsoNormal">There are some useful information in the head part, for example,</p>
<p class="MsoNormal"><span style="">&nbsp; </span>The content-Type of this request.</p>
<p class="MsoNormal"><span style="">&nbsp; </span>The boundary which separate the body part.</p>
<p class="MsoNormal"><span style="">&nbsp; </span>The content-length of this request.</p>
<p class="MsoNormal"><span style="">&nbsp; </span>Some request variables.</p>
<p class="MsoNormal"><span style="">&nbsp; </span>The filename of the uploaded file and its content-type.</p>
<p class="MsoNormal"></p>
<p class="MsoNormal">If we analyze the data, we can find some tips like below.</p>
<p class="MsoNormal"><span style="">&nbsp; </span>1. All the request data is separated by a boundary which is defined in the content-type of the head part.</p>
<p class="MsoNormal"><span style="">&nbsp; </span>2. The name and the value of one parameter is separated by a newline.</p>
<p class="MsoNormal"><span style="">&nbsp; </span>3. If the parameter is a file, we can get the filename and content-type of the file</p>
<p class="MsoNormal"><span style="">&nbsp; </span>4. The data of the file followed the content-type of the file.</p>
<p class="MsoNormal">So when the server has got all these data, the uploading will be finished.</p>
<p class="MsoNormal">The problem left here is how we can get to know that how much data the server had read and is there a way that we can control the length which the server read by one time.</p>
<p class="MsoNormal">For IIS and .Net Framework, we can control this by an HTTPModule. Data reading will be started in BeginRequest event. And the HttpWorkerRequest class could control the reading process.</p>
<p class="MsoNormal">We can use HttpWorkerRequest.GetPreloadedEntityBody() to get the first part of the request data which the server read. If the data is too large, HttpWorkerRequest.IsEntireEntityBodyIsPreloaded will return false, we can use HttpWorkerRequest.ReadEntityBody()
 to read the left data. By this way, we can know how much data loaded and how much left. At last, we need to send the status back to the server, here I store the status to the Cache.</p>
<p class="MsoNormal">Another important issue is how the client side get the status from the server side without postback to the server. The answer is to use AJAX feature. Here we use ICallBackEventHandler, because it is easy to handle and clear enough for
 us to understand the process. We can learn how to use it from the reference at the bottom of this readme file. We can also use jQuery Ajax to call back a web service or generic handler to get the status.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Step 1. Build the website &quot;TestWeb&quot;.<br>
Step 2. View the Default.aspx in the browser.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84637/1/image.png" alt="" width="326" height="67" align="middle">
</span><br>
Step 3. Select a file which you want to test the sample.<br>
Step 4. Click Upload button. And you will see the upload status in details.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84638/1/image.png" alt="" width="576" height="182" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">Step 1.<span style="">&nbsp; </span>Create a VB &quot;Class Library&quot; Project in Visual Studio 2012 or Visual Web Developer 2012. Name it as &quot;UploadStatus.&quot;<br>
<br>
Step 2.<span style="">&nbsp; </span>Add the two references into the project, <b style="">
System.Web.Extension</b> and <b style="">System.Web</b>.</p>
<p class="MsoNormal">Step 3.<span style="">&nbsp; </span>Copy the code from the UploadStatus.vb from the sample folder, &quot;FileUploadStatus&quot;.</p>
<p class="MsoNormal">Step 4.<span style="">&nbsp; </span>Add an ASP.NET Module and named it as UploadProcessModule.</p>
<p class="MsoNormal">Step 5.<span style="">&nbsp; </span>Copy the code from the UploadProcessModule.vb in the sample folder, &quot;FileUploadStatus&quot;.</p>
<p class="MsoNormal">Step 6.<span style="">&nbsp; </span>Also create the files: BinaryHelper.vb, UploadFile.vb, UploadFileCollection.vb and FileUploadDataManager.vb, and copy the codes.</p>
<p class="MsoNormal">Step 7.<span style="">&nbsp; </span>Save and Build the project.</p>
<p class="MsoNormal">[<b style="">Note</b>] Be sure the project is released on &quot;<b style="">ANY CPU</b>&quot;.<br>
We can't add this project reference which is x86 version to the website deployed on an x64 system platform.</p>
<p class="MsoNormal">Step 8.<span style="">&nbsp; </span>Add a new Empty ASP.NET WebSite into the solution, name it as TestWeb.</p>
<p class="MsoNormal">Step 9.<span style="">&nbsp; </span>Add the project reference, &quot;UploadStatus&quot;, which we created at first.</p>
<p class="MsoNormal">Step 10.<span style="">&nbsp; </span>Create a new Web User Control named as UploadStatusWindow.ascx.We will use this user control to hold a Popup window to show the status information. Copy the markups from the UploadStatusWindow.ascx in the
 sample folder, &quot;TestWeb&quot;.</p>
<p class="MsoNormal">Step 11. Create an ASP.NET web page named as UploadControls.aspx. Add one FileUpload web control and one Button web control into the page. Copy the markups from UploadControls.aspx in the sample folder, &quot;TestWeb&quot;.</p>
<p class="MsoNormal"></p>
<p class="MsoNormal">Step 12. Create an ASP.NET web page named as Deafult.aspx. Add an iframe into the page. Set the src to &quot;UploadControls.aspx&quot;. Copy the javascript function and markups from the Default.aspx in the sample folder, &quot;TestWeb&quot;.</p>
<p class="MsoNormal">Step 13. Copy the follow two folders in the sample folder into the website, &quot;styles&quot; and &quot;scripts&quot;.</p>
<p class="MsoNormal">Step 14. Modify the web.config. Register the HttpModule. Set the maxRequestLength to 1048576, means max request data will be limited to 1GB. If we deploy the website to IIS7, we need set the requestLimits in the
<b style="">system.webServer</b> block.</p>
<p class="MsoNormal">Step 15. Make sure we have made the page same as the sample. Build the solution and then test the site.</p>
<h2>More Information</h2>
<p class="MsoNormal">MSDN: HttpModules<br>
<a href="http://msdn.microsoft.com/en-us/library/zec9k340(VS.71).aspx">http://msdn.microsoft.com/en-us/library/zec9k340(VS.71).aspx</a><br>
MSDN: HttpWorkerRequest Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.httpworkerrequest.aspx">http://msdn.microsoft.com/en-us/library/system.web.httpworkerrequest.aspx</a><br>
MSDN: ICallBackEventHandler Interface<br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.icallbackeventhandler.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.icallbackeventhandler.aspx</a><br>
MSDN: An Introduction to JavaScript Object Notation (JSON) in JavaScript and .NET<br>
<a href="http://msdn.microsoft.com/en-us/library/bb299886.aspx">http://msdn.microsoft.com/en-us/library/bb299886.aspx</a><br>
MSDN: JavaScriptSerializer Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.script.serialization.javascriptserializer.aspx">http://msdn.microsoft.com/en-us/library/system.web.script.serialization.javascriptserializer.aspx</a><br>
<br style="">
<br style="">
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

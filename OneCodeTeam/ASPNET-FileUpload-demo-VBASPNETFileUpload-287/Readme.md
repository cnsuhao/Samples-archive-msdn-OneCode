# ASP.NET FileUpload demo (VBASPNETFileUpload)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Controls
* FileUpload
## IsPublished
* True
## ModifiedDate
* 2011-05-05 07:28:08
## Description

<p style="font-family:Courier New"></p>
<h2>ASP.NET APPLICATION : VBASPNETFileUpload Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
&nbsp;The project illustrates how to upload files in an ASP.NET project by use <br>
&nbsp;of FileUpload control and VB.NET language. When submit Button is clicked,<br>
&nbsp;the HasFile property of the FileUpload control is checked to verify that<br>
&nbsp;a file has been selected to upload. Before the file is saved, File.Exists <br>
&nbsp;method is called to check whether a file that has the same name already <br>
&nbsp;exists in the path. If so, the name of uploaded file is postfixed with a <br>
&nbsp;increasing number so that the exsited file will not be overwritten. After<br>
&nbsp;the file is uploaded successfully, some basic information is displayed, <br>
&nbsp;including the original path, name, the size and the content type of the<br>
&nbsp;uploaded file. All the information is get from the HttpPostedFile object<br>
&nbsp;pointed by FileUpload.PostedFile property. <br>
&nbsp;<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step1. Create a Visual Basic ASP.NET Web Application named VBASPFileUpload in<br>
Visual Studio 2008 / Visual Web Developer.<br>
<br>
Step2. Add a FileUpload control and a Button control into the ASP.NET HTML <br>
page and rename them according to the following way:<br>
<br>
&nbsp; &nbsp;FileUpload1 -&gt; FileUploader<br>
&nbsp; &nbsp;Button1 &nbsp; &nbsp; -&gt; btnSubmit<br>
<br>
[NOTE] The file in the FileUpload control cannot be automatically saved to<br>
server after a user selects it. Another control, typically like a Button, <br>
must be provided to submit the page, so that the file can be posted to server. <br>
<br>
Step3: Create a new folder and rename it as UploadFiles, which is used to <br>
store the uploaded files.<br>
<br>
Step4: Double-click the Button in page's Designer View to open the Code-Behind <br>
page in Visual Basic .NET language.<br>
<br>
Step5: Import the namespace System.IO and System.Text at the very beginning<br>
of the page. Or you can use the complete function name like System.IO.Path in<br>
the code.<br>
<br>
Step6: Create SaveUploadFile() function which calls HttpPostedFile.SaveAs() <br>
method to save the file to the server. Actually, FileUpload.SaveAs() method <br>
does the same thing that calling HttpPostedFile.SaveAs() method itself.<br>
<br>
&nbsp; &nbsp;Protected Function SaveUploadFile(ByVal uploadedFile As HttpPostedFile, _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ByVal SavePath As String) As Boolean<br>
&nbsp; &nbsp; &nbsp; &nbsp;'...<br>
&nbsp; &nbsp; &nbsp; &nbsp;uploadedFile.SaveAs(Path.Combine(SavePath, fileName))<br>
&nbsp; &nbsp; &nbsp; &nbsp;'...<br>
&nbsp; &nbsp;End Function<br>
<br>
[NOTE] When SaveAs() method is called, the full path of the directory on the <br>
server must be specified, in which the file to upload will be saved. If not, <br>
an HttpException exception is thrown. This behavior helps to keep the files <br>
on the server secure, by preventing users from being able to write uploaded <br>
files to arbitrary locations to server, like some sensitive root directories. <br>
<br>
Step7: Create GetUploadFileInfo() funtion to get the basic information of <br>
the uploaded file.<br>
<br>
&nbsp; &nbsp;Protected Function GetUploadFileInfo(ByVal uploadedFile As HttpPostedFile) _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; As String<br>
&nbsp; &nbsp; &nbsp; &nbsp;'...<br>
&nbsp; &nbsp;End Function<br>
<br>
Step8: Eidt the Button's click event handler to call SaveUploadFile() to save<br>
the file. After uploading, call GetUploadFileInfo() function to show file's <br>
information. <br>
<br>
[NOTE] Before calling SaveUploadFile() function, FileUpload.HasFile property<br>
need to be checked to verify the FileUpload control contains a file. If it <br>
returns false, display a message to tell the user no file has been selected <br>
to upload. Do not check the PostedFile.Length property to validate whether a &nbsp; &nbsp;<br>
file to upload exists because this property could contain 0 bytes even when <br>
FileUpload control is blank. As a result, the PostedFile property can return <br>
a non-null value. <br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: FileUpload Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.fileupload.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.fileupload.aspx</a><br>
<br>
MSDN: Uploading Files in ASP.NET 2.0<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa479405.aspx">http://msdn.microsoft.com/en-us/library/aa479405.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

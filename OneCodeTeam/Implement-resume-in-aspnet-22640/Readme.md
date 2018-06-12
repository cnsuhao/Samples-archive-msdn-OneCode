# Implement resume download in asp.net
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* resume download
## IsPublished
* True
## ModifiedDate
* 2013-06-13 10:31:13
## Description

<h2><span style="font-size:14.0pt; line-height:115%">ASP.NET resume download sample (<span class="SpellE">VBASPNETResumeDownload</span>)
</span></h2>
<h2>Introduction</h2>
<p class="MsoNormal"><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">The project
<span class="SpellE">VBASPNETResumeDownload</span> demonstrates how to implement resume download feature in ASP.NET. As we know, due to network interruptions,</span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Downloading file may meet a problem when the size of file is large</span><span style="font-size:11.0pt; font-family:SimSun">.</span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
</span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">A</span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">t this time we need to support resume download if the connection is broken.</span><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
 In this sample, we need two classes: <b style="">HttpRequest</b> and <b style="">
HttpResponse</b>.<span style="">&nbsp; </span><b style="">HttpRequest</b> is used to get the downloaded partial file's length from the Range header and the other one
<b style="">HttpResponse </b>is for setting the start position of the reading file. And then read and send the rest of the file to client. You can find the answers for all the following questions in the code sample:
</span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>How to get and process the HTTP Web request by custom <span class="SpellE">
HttpHandler</span>?<span style=""> </span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>H<span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">ow to get the </span>
HTTP <span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">response header informa</span>tion?<span style="">
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>How to send the file to client <span style="">by </span>using HttpResponse<span style=""> class</span>?<span style="">
</span></p>
<p class="MsoNormal">Running the Sample<span style=""> </span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Open the <span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
<span class="SpellE">VBASPNETResumeDownload</span> </span>.sln. Expand the <span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">
<span class="SpellE">VBASPNETResumeDownload</span> </span>web application. Double click the
<span class="SpellE">Web.config</span> file and find the &quot;<span class="SpellE">appSettings</span>&quot; node, then modify the value of the &quot;<span class="SpellE">FilePath</span>&quot; key with the physical path of the download file.</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Right click the ResumeDownloadPage.htm, select and click the &quot;Set
<span class="GramE">As</span> Start Page&quot; item then press &quot;F5&quot; to start debug<span style="">ging</span> the project.<span style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:10.0pt; line-height:115%"><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><img src="/site/view/file/84471/1/image.png" alt="" width="452" height="288" align="middle">
</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">&nbsp;</span>We will see a Button control named &quot;Download&quot; on the page. Please click it.
</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">&nbsp;</span>After completing Step 3 you will see the IE download file dialog on the bottom of the browser.
</p>
<p class="MsoNormal" style="margin-bottom:10.0pt; line-height:115%"><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><img src="/site/view/file/84472/1/image.png" alt="" width="591" height="340" align="middle">
</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoListParagraph" style="text-indent:5.0pt"><span style=""><span style="">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">&nbsp;</span>Please click &quot;Save&quot; button and select a path to save the file, then IE download file dialog will show like below.<span style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:10.0pt; line-height:115%"><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><img src="/site/view/file/84473/1/image.png" alt="" width="591" height="348" align="middle">
</span></p>
<p class="MsoListParagraph" style="text-indent:5.0pt"><span style=""><span style="">6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">&nbsp;</span>You can click the &quot;Pause&quot; button then the download operation will in<span style="">terrupt.
</span></p>
<p class="MsoNormal" style="margin-bottom:10.0pt; line-height:115%"><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><img src="/site/view/file/84474/1/image.png" alt="" width="595" height="348" align="middle">
</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoListParagraph" style="text-indent:5.0pt"><span style=""><span style="">7.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">&nbsp;</span>Click the &quot;Resume&quot; button to restart the download operation.</p>
<p class="MsoNormal" style="margin-bottom:10.0pt; line-height:115%"><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><img src="/site/view/file/84475/1/image.png" alt="" width="592" height="348" align="middle">
</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoListParagraph" style="text-indent:5.0pt"><span style=""><span style="">8.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">&nbsp;</span>When the download is finished, the dialog will show like below.</p>
<p class="MsoNormal" style="margin-bottom:10.0pt; line-height:115%"><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><img src="/site/view/file/84476/1/image.png" alt="" width="595" height="350" align="middle">
</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<h2>Using the Code</h2>
<p class="MsoNormal"><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">The code sample provides the following reusable functions:
</span></p>
<p class="MsoNormal"><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"></span></p>
<p class="MsoListParagraph" style="margin-bottom:0cm; margin-bottom:.0001pt; text-indent:-26.95pt">
<b><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;"><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b><span style="font-family:&quot;Cambria&quot;,&quot;serif&quot;">How to get and process the HTTP Web request by custom
<span class="SpellE">HttpHandler</span>? </span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Class DownloadHttpHandler
&nbsp;&nbsp;&nbsp; Implements System.Web.IHttpHandler


&nbsp;&nbsp;&nbsp; Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim filePath As String = ConfigurationManager.AppSettings(&quot;FilePath&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; VBASPNETResumeDownload.Downloader.DownloadFile(context, filePath)


&nbsp;&nbsp;&nbsp; End Sub


&nbsp;&nbsp;&nbsp; ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return False
&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End Get
&nbsp;&nbsp;&nbsp; End Property

</pre>
<pre id="codePreview" class="vb">
Public Class DownloadHttpHandler
&nbsp;&nbsp;&nbsp; Implements System.Web.IHttpHandler


&nbsp;&nbsp;&nbsp; Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim filePath As String = ConfigurationManager.AppSettings(&quot;FilePath&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; VBASPNETResumeDownload.Downloader.DownloadFile(context, filePath)


&nbsp;&nbsp;&nbsp; End Sub


&nbsp;&nbsp;&nbsp; ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return False
&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End Get
&nbsp;&nbsp;&nbsp; End Property

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' Get the response header by the http request.
''' &lt;/summary&gt;
''' &lt;param name=&quot;httpRequest&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;fileInfo&quot;&gt;&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
Private Shared Function GetResponseHeader(ByVal httpRequest As HttpRequest, ByVal fileInfo As FileInfo) As HttpResponseHeader
&nbsp;&nbsp;&nbsp; If httpRequest Is Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return Nothing
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; If fileInfo Is Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return Nothing
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; Dim startPosition As Long = 0
&nbsp;&nbsp;&nbsp; Dim contentRange As String = &quot;&quot;


&nbsp;&nbsp;&nbsp; Dim fileName As String = fileInfo.Name
&nbsp;&nbsp;&nbsp; Dim fileLength As Long = fileInfo.Length
&nbsp;&nbsp;&nbsp; Dim lastUpdateTimeStr As String = fileInfo.LastWriteTimeUtc.ToString()


&nbsp;&nbsp;&nbsp; Dim eTag As String = HttpUtility.UrlEncode(fileName, Encoding.UTF8) & &quot; &quot; & lastUpdateTimeStr
&nbsp;&nbsp;&nbsp; Dim contentDisposition As String = &quot;attachment;filename=&quot; & HttpUtility.UrlEncode(fileName, Encoding.UTF8).Replace(&quot;&#43;&quot;, &quot;%20&quot;)


&nbsp;&nbsp;&nbsp; If httpRequest.Headers(&quot;Range&quot;) IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim range As String() = httpRequest.Headers(&quot;Range&quot;).Split(New Char() {&quot;=&quot;c, &quot;-&quot;c})
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; startPosition = Convert.ToInt64(range(1))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If startPosition &lt; 0 OrElse startPosition &gt;= fileLength Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return Nothing
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; If httpRequest.Headers(&quot;If-Range&quot;) IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If httpRequest.Headers(&quot;If-Range&quot;).Replace(&quot;&quot;&quot;&quot;, &quot;&quot;) &lt;&gt; eTag Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; startPosition = 0
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;End If
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; Dim contentLength As String = (fileLength - startPosition).ToString()


&nbsp;&nbsp;&nbsp; If startPosition &gt; 0 Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; contentRange = String.Format(&quot; bytes {0}-{1}/{2}&quot;, startPosition, fileLength - 1, fileLength)
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; Dim responseHeader As New HttpResponseHeader()


&nbsp;&nbsp;&nbsp; responseHeader.AcceptRanges = &quot;bytes&quot;
&nbsp;&nbsp;&nbsp; responseHeader.Connection = &quot;Keep-Alive&quot;
&nbsp;&nbsp;&nbsp; responseHeader.ContentDisposition = contentDisposition
&nbsp;&nbsp;&nbsp; responseHeader.ContentEncoding = Encoding.UTF8
&nbsp;&nbsp;&nbsp; responseHeader.ContentLength = contentLength
&nbsp;&nbsp;&nbsp; responseHeader.ContentRange = contentRange
&nbsp;&nbsp;&nbsp; responseHeader.ContentType = &quot;application/octet-stream&quot;
&nbsp;&nbsp;&nbsp; responseHeader.Etag = eTag
&nbsp;&nbsp;&nbsp; responseHeader.LastModified = lastUpdateTimeStr


&nbsp;&nbsp;&nbsp; Return responseHeader
End Function

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' Get the response header by the http request.
''' &lt;/summary&gt;
''' &lt;param name=&quot;httpRequest&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;fileInfo&quot;&gt;&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
Private Shared Function GetResponseHeader(ByVal httpRequest As HttpRequest, ByVal fileInfo As FileInfo) As HttpResponseHeader
&nbsp;&nbsp;&nbsp; If httpRequest Is Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return Nothing
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; If fileInfo Is Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return Nothing
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; Dim startPosition As Long = 0
&nbsp;&nbsp;&nbsp; Dim contentRange As String = &quot;&quot;


&nbsp;&nbsp;&nbsp; Dim fileName As String = fileInfo.Name
&nbsp;&nbsp;&nbsp; Dim fileLength As Long = fileInfo.Length
&nbsp;&nbsp;&nbsp; Dim lastUpdateTimeStr As String = fileInfo.LastWriteTimeUtc.ToString()


&nbsp;&nbsp;&nbsp; Dim eTag As String = HttpUtility.UrlEncode(fileName, Encoding.UTF8) & &quot; &quot; & lastUpdateTimeStr
&nbsp;&nbsp;&nbsp; Dim contentDisposition As String = &quot;attachment;filename=&quot; & HttpUtility.UrlEncode(fileName, Encoding.UTF8).Replace(&quot;&#43;&quot;, &quot;%20&quot;)


&nbsp;&nbsp;&nbsp; If httpRequest.Headers(&quot;Range&quot;) IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim range As String() = httpRequest.Headers(&quot;Range&quot;).Split(New Char() {&quot;=&quot;c, &quot;-&quot;c})
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; startPosition = Convert.ToInt64(range(1))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If startPosition &lt; 0 OrElse startPosition &gt;= fileLength Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return Nothing
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; If httpRequest.Headers(&quot;If-Range&quot;) IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If httpRequest.Headers(&quot;If-Range&quot;).Replace(&quot;&quot;&quot;&quot;, &quot;&quot;) &lt;&gt; eTag Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; startPosition = 0
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;End If
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; Dim contentLength As String = (fileLength - startPosition).ToString()


&nbsp;&nbsp;&nbsp; If startPosition &gt; 0 Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; contentRange = String.Format(&quot; bytes {0}-{1}/{2}&quot;, startPosition, fileLength - 1, fileLength)
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; Dim responseHeader As New HttpResponseHeader()


&nbsp;&nbsp;&nbsp; responseHeader.AcceptRanges = &quot;bytes&quot;
&nbsp;&nbsp;&nbsp; responseHeader.Connection = &quot;Keep-Alive&quot;
&nbsp;&nbsp;&nbsp; responseHeader.ContentDisposition = contentDisposition
&nbsp;&nbsp;&nbsp; responseHeader.ContentEncoding = Encoding.UTF8
&nbsp;&nbsp;&nbsp; responseHeader.ContentLength = contentLength
&nbsp;&nbsp;&nbsp; responseHeader.ContentRange = contentRange
&nbsp;&nbsp;&nbsp; responseHeader.ContentType = &quot;application/octet-stream&quot;
&nbsp;&nbsp;&nbsp; responseHeader.Etag = eTag
&nbsp;&nbsp;&nbsp; responseHeader.LastModified = lastUpdateTimeStr


&nbsp;&nbsp;&nbsp; Return responseHeader
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' Send the download file to the client.
''' &lt;/summary&gt;
''' &lt;param name=&quot;httpResponse&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;responseHeader&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;fileStream&quot;&gt;&lt;/param&gt;
Private Shared Sub SendDownloadFile(ByVal httpResponse As HttpResponse, ByVal responseHeader As HttpResponseHeader, ByVal fileStream As Stream)
&nbsp;&nbsp;&nbsp; If httpResponse Is Nothing OrElse responseHeader Is Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; If Not String.IsNullOrEmpty(responseHeader.ContentRange) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; httpResponse.StatusCode = 206


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Set the start position of the reading files.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim range As String() = responseHeader.ContentRange.Split(New Char() {&quot; &quot;c, &quot;=&quot;c, &quot;-&quot;c})
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; fileStream.Position = Convert.ToInt64(range(2))
&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; httpResponse.Clear()
&nbsp;&nbsp;&nbsp; httpResponse.Buffer = False
&nbsp;&nbsp;&nbsp; httpResponse.AppendHeader(&quot;Accept-Ranges&quot;, responseHeader.AcceptRanges)
&nbsp;&nbsp;&nbsp; httpResponse.AppendHeader(&quot;Connection&quot;, responseHeader.Connection)
&nbsp;&nbsp;&nbsp; httpResponse.AppendHeader(&quot;Content-Disposition&quot;, responseHeader.ContentDisposition)
&nbsp;&nbsp;&nbsp; httpResponse.ContentEncoding = responseHeader.ContentEncoding
&nbsp;&nbsp;&nbsp; httpResponse.AppendHeader(&quot;Content-Length&quot;, responseHeader.ContentLength)
&nbsp;&nbsp; &nbsp;If Not String.IsNullOrEmpty(responseHeader.ContentRange) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; httpResponse.AppendHeader(&quot;Content-Range&quot;, responseHeader.ContentRange)
&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; httpResponse.ContentType = responseHeader.ContentType
&nbsp;&nbsp;&nbsp; httpResponse.AppendHeader(&quot;Etag&quot;, &quot;&quot;&quot;&quot; & responseHeader.Etag & &quot;&quot;&quot;&quot;)
&nbsp;&nbsp;&nbsp; httpResponse.AppendHeader(&quot;Last-Modified&quot;, responseHeader.LastModified)


&nbsp;&nbsp;&nbsp; Dim buffer As [Byte]() = New [Byte](10239) {}
&nbsp;&nbsp;&nbsp; Dim fileLength As Long = Convert.ToInt64(responseHeader.ContentLength)


&nbsp;&nbsp;&nbsp; ' Send file to client.
&nbsp;&nbsp;&nbsp; While fileLength &gt; 0
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If httpResponse.IsClientConnected Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim length As Integer = fileStream.Read(buffer, 0, 10240)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; httpResponse.OutputStream.Write(buffer, 0, length)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; httpResponse.Flush()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; fileLength = fileLength - length
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; fileLength = -1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; End While
End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' Send the download file to the client.
''' &lt;/summary&gt;
''' &lt;param name=&quot;httpResponse&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;responseHeader&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;fileStream&quot;&gt;&lt;/param&gt;
Private Shared Sub SendDownloadFile(ByVal httpResponse As HttpResponse, ByVal responseHeader As HttpResponseHeader, ByVal fileStream As Stream)
&nbsp;&nbsp;&nbsp; If httpResponse Is Nothing OrElse responseHeader Is Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; If Not String.IsNullOrEmpty(responseHeader.ContentRange) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; httpResponse.StatusCode = 206


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Set the start position of the reading files.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim range As String() = responseHeader.ContentRange.Split(New Char() {&quot; &quot;c, &quot;=&quot;c, &quot;-&quot;c})
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; fileStream.Position = Convert.ToInt64(range(2))
&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; httpResponse.Clear()
&nbsp;&nbsp;&nbsp; httpResponse.Buffer = False
&nbsp;&nbsp;&nbsp; httpResponse.AppendHeader(&quot;Accept-Ranges&quot;, responseHeader.AcceptRanges)
&nbsp;&nbsp;&nbsp; httpResponse.AppendHeader(&quot;Connection&quot;, responseHeader.Connection)
&nbsp;&nbsp;&nbsp; httpResponse.AppendHeader(&quot;Content-Disposition&quot;, responseHeader.ContentDisposition)
&nbsp;&nbsp;&nbsp; httpResponse.ContentEncoding = responseHeader.ContentEncoding
&nbsp;&nbsp;&nbsp; httpResponse.AppendHeader(&quot;Content-Length&quot;, responseHeader.ContentLength)
&nbsp;&nbsp; &nbsp;If Not String.IsNullOrEmpty(responseHeader.ContentRange) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; httpResponse.AppendHeader(&quot;Content-Range&quot;, responseHeader.ContentRange)
&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; httpResponse.ContentType = responseHeader.ContentType
&nbsp;&nbsp;&nbsp; httpResponse.AppendHeader(&quot;Etag&quot;, &quot;&quot;&quot;&quot; & responseHeader.Etag & &quot;&quot;&quot;&quot;)
&nbsp;&nbsp;&nbsp; httpResponse.AppendHeader(&quot;Last-Modified&quot;, responseHeader.LastModified)


&nbsp;&nbsp;&nbsp; Dim buffer As [Byte]() = New [Byte](10239) {}
&nbsp;&nbsp;&nbsp; Dim fileLength As Long = Convert.ToInt64(responseHeader.ContentLength)


&nbsp;&nbsp;&nbsp; ' Send file to client.
&nbsp;&nbsp;&nbsp; While fileLength &gt; 0
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If httpResponse.IsClientConnected Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim length As Integer = fileStream.Read(buffer, 0, 10240)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; httpResponse.OutputStream.Write(buffer, 0, length)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; httpResponse.Flush()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; fileLength = fileLength - length
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; fileLength = -1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; End While
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/system.web.httprequest.aspx">MSDN: HttpRequest</a></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/system.web.httpresponse.aspx">MSDN: HttpResponse</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

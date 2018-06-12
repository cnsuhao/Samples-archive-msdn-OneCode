# Making an await WebClient
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Windows Phone
* Windows Phone 8
* Windows Phone Development
## Topics
* WebClient
* await
## IsPublished
* True
## ModifiedDate
* 2013-06-05 12:23:32
## Description

<h1>How to make an await WebClient (VBWP8AwaitWebClient)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample will show how to make an <b style="">await <span class="SpellE">
WebClient</span></b> (similar to HttpClient in Windows 8).In this sample, we will implement the
<span class="SpellE"><span class="GramE"><b style="">GetStringAsync</b></span></span><span class="GramE">(</span>) method and the
<span class="SpellE"><b style="">GetByteArrayAsync</b></span>() method.</p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">Step 1:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Open <b style="">VBWP8AwaitWebClient.sln</b>.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">Step 2:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press Ctrl &#43; F5. The emulator looks as follows:</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/83506/1/image.png" alt="" width="308" height="387" align="middle">
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">Step 3:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Uncomment the following lines:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
strResult = CStr(dataArray.Length)

</pre>
<pre id="codePreview" class="vb">
strResult = CStr(dataArray.Length)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">Step 4:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Close the emulator and reopen it. The emulator looks as follows:</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/83507/1/image.png" alt="" width="229" height="76" align="middle">
</span><span style="">&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">Step 5:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>The validation is complete.</p>
<p class="MsoNormal"></p>
<h2>Using the Code</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">Step 1:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">&nbsp;&nbsp;</span>Create a Visual Basic &quot;<b style="">Windows Phone App</b>&quot; in Visual Studio 2012 or Visual Studio Express 2012 for Windows Phone. Name it as &quot;VBWP8AwaitWebClient.&quot;</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">Step 2:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">&nbsp;&nbsp;</span>Add a class in the root directory of project, naming it to
<b style="">HttpClient</b>. The HttpClient class inherits from the WebClient class and it will override the
<b style="">GetWebRequest</b> method.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; ''' Override the GetWebRequest method.
&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;address&quot;&gt;The Uri the request is sent to.&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;returns&gt;HttpWebRequest&lt;/returns&gt;
&nbsp;&nbsp;&nbsp; Protected Overrides Function GetWebRequest(address As Uri) As WebRequest
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim request As HttpWebRequest = TryCast(MyBase.GetWebRequest(address), HttpWebRequest)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If request IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; request.Method = &quot;GET&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; request.CookieContainer = cookieContainer
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return request
&nbsp;&nbsp;&nbsp; End Function

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; ''' Override the GetWebRequest method.
&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;address&quot;&gt;The Uri the request is sent to.&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;returns&gt;HttpWebRequest&lt;/returns&gt;
&nbsp;&nbsp;&nbsp; Protected Overrides Function GetWebRequest(address As Uri) As WebRequest
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim request As HttpWebRequest = TryCast(MyBase.GetWebRequest(address), HttpWebRequest)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If request IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; request.Method = &quot;GET&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; request.CookieContainer = cookieContainer
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return request
&nbsp;&nbsp;&nbsp; End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">Step 3:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>In HttpClient class, add the following variables above the <b style="">
MainPage</b> constructor:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private cookieContainer As New CookieContainer()
&nbsp;&nbsp; Dim tcsGetByteArray As New TaskCompletionSource(Of Byte())()
&nbsp;&nbsp; Dim tcsGetString As New TaskCompletionSource(Of String)()

</pre>
<pre id="codePreview" class="vb">
Private cookieContainer As New CookieContainer()
&nbsp;&nbsp; Dim tcsGetByteArray As New TaskCompletionSource(Of Byte())()
&nbsp;&nbsp; Dim tcsGetString As New TaskCompletionSource(Of String)()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">Step 4:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>The HttpClient class of Windows 8 has six <b style="">GetXXXAsync</b> methods and we will implement the
<b style="">GetByteArrayAsync</b> method and <b style="">GetStringAsync</b> method in this sample.</p>
<p class="MsoListParagraphCxSpMiddle">The <b style="">GetXXXAsync</b> methods need an URI as parameter and they will return
<b style="">System.Threading.Tasks.Task&lt;TResult&gt;</b> as result. In the methods, we will
<span style="color:black">enable a <b style="">Task (Of TResult)</b> to represent an external asynchronous operation by using
<b style="">TaskCompletionSource (Of TResult)</b>.</span></p>
<p class="MsoListParagraphCxSpLast"><span style="">&nbsp;</span>First, we will implement the
<b style="">GetStringAsync</b> method.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
&nbsp;&nbsp; ''' Get the string by URI string.
&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;strUri&quot;&gt;The Uri the request is sent to.&lt;/param&gt;
&nbsp;&nbsp; ''' &lt;returns&gt;string&lt;/returns&gt;
&nbsp;&nbsp; Public Async Function GetStringAsync(strUri As String) As Task(Of String)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim uri As New Uri(strUri)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim result As String = Await GetStringAsync(uri)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return result
&nbsp;&nbsp; End Function


&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp; ''' Get the string by URI.
&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;requestUri&quot;&gt;The Uri the request is sent to.&lt;/param&gt;
&nbsp;&nbsp; ''' &lt;returns&gt;string&lt;/returns&gt;
&nbsp;&nbsp; Public Function GetStringAsync(requestUri As Uri) As Task(Of String)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AddHandler Me.DownloadStringCompleted, AddressOf MyDownloadStringCompleted
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.DownloadStringAsync(requestUri)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Catch ex As Exception
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tcsGetString.TrySetException(ex)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Try


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If tcsGetString.Task.Exception IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Throw tcsGetString.Task.Exception
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return tcsGetString.Task
&nbsp;&nbsp; End Function


&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp; ''' DownloadCompleted event of String.
&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;sender&quot;&gt;Me.DownloadStringCompleted&lt;/param&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;e&quot;&gt;DownloadStringCompletedEventArgs&lt;/param&gt;
&nbsp;&nbsp; ''' &lt;returns&gt;Nothing&lt;/returns&gt;
&nbsp;&nbsp; ''' &lt;remarks&gt;&lt;/remarks&gt;
&nbsp;&nbsp; Function MyDownloadStringCompleted(ByVal sender As Object, _
ByVal e As System.Net.DownloadStringCompletedEventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If e.[Error] Is Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tcsGetString.TrySetResult(e.Result)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tcsGetString.TrySetException(e.[Error])
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return Nothing
&nbsp;&nbsp; End Function

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
&nbsp;&nbsp; ''' Get the string by URI string.
&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;strUri&quot;&gt;The Uri the request is sent to.&lt;/param&gt;
&nbsp;&nbsp; ''' &lt;returns&gt;string&lt;/returns&gt;
&nbsp;&nbsp; Public Async Function GetStringAsync(strUri As String) As Task(Of String)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim uri As New Uri(strUri)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim result As String = Await GetStringAsync(uri)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return result
&nbsp;&nbsp; End Function


&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp; ''' Get the string by URI.
&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;requestUri&quot;&gt;The Uri the request is sent to.&lt;/param&gt;
&nbsp;&nbsp; ''' &lt;returns&gt;string&lt;/returns&gt;
&nbsp;&nbsp; Public Function GetStringAsync(requestUri As Uri) As Task(Of String)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AddHandler Me.DownloadStringCompleted, AddressOf MyDownloadStringCompleted
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.DownloadStringAsync(requestUri)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Catch ex As Exception
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tcsGetString.TrySetException(ex)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Try


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If tcsGetString.Task.Exception IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Throw tcsGetString.Task.Exception
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return tcsGetString.Task
&nbsp;&nbsp; End Function


&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp; ''' DownloadCompleted event of String.
&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;sender&quot;&gt;Me.DownloadStringCompleted&lt;/param&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;e&quot;&gt;DownloadStringCompletedEventArgs&lt;/param&gt;
&nbsp;&nbsp; ''' &lt;returns&gt;Nothing&lt;/returns&gt;
&nbsp;&nbsp; ''' &lt;remarks&gt;&lt;/remarks&gt;
&nbsp;&nbsp; Function MyDownloadStringCompleted(ByVal sender As Object, _
ByVal e As System.Net.DownloadStringCompletedEventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If e.[Error] Is Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tcsGetString.TrySetResult(e.Result)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tcsGetString.TrySetException(e.[Error])
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return Nothing
&nbsp;&nbsp; End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">Step 5:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Next, we will implement the <b style="">GetByteArrayAsync</b> method.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; '''&nbsp; Send a GET request to the specified Uri and return the response body as a
&nbsp;&nbsp;&nbsp; '''&nbsp; byte array in an asynchronous operation.
&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;requestUri&quot;&gt;The Uri the request is sent to.&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;returns&gt;
&nbsp;&nbsp;&nbsp; ''' Returns System.Threading.Tasks.Task TResult&gt;.The task object
&nbsp;&nbsp;&nbsp; ''' representing the asynchronous operation.
&nbsp; &nbsp;&nbsp;'''&nbsp; &lt;/returns&gt;
&nbsp;&nbsp;&nbsp; Public Async Function GetByteArrayAsync(requestUri As String) As Task(Of Byte())
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim uri As New Uri(requestUri)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim data As Byte() = Await GetByteArrayAsync(uri)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return data
&nbsp;&nbsp;&nbsp; End Function


&nbsp;&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; '''&nbsp; Send a GET request to the specified Uri and return the response body as a
&nbsp;&nbsp;&nbsp; '''&nbsp; byte array in an asynchronous operation.
&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;requestUri&quot;&gt;The Uri the request is sent to.&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;returns&gt;Returns byte array.The task object
&nbsp;&nbsp;&nbsp; ''' representing the asynchronous operation.&lt;/returns&gt;
&nbsp;&nbsp;&nbsp; Public Function GetByteArrayAsync(requestUri As Uri) As Task(Of Byte())
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AddHandler Me.DownloadStringCompleted, AddressOf MyDownloadByteArrayCompleted


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.DownloadStringAsync(requestUri)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Catch ex As Exception
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tcsGetByteArray.TrySetException(ex)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Try


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If tcsGetByteArray.Task.Exception IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Throw tcsGetByteArray.Task.Exception
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return tcsGetByteArray.Task
&nbsp;&nbsp;&nbsp; End Function


&nbsp;&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; ''' DownloadCompleted event of ByteArray.
&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;sender&quot;&gt;Me.DownloadStringCompleted&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;e&quot;&gt;DownloadStringCompletedEventArgs&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;returns&gt;Nothing&lt;/returns&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;remarks&gt;&lt;/remarks&gt;
&nbsp;&nbsp;&nbsp; Function MyDownloadByteArrayCompleted(ByVal sender As Object, _
ByVal e As System.Net.DownloadStringCompletedEventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If e.[Error] Is Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim data As Byte() = ConvertStringToByte(e.Result)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tcsGetByteArray.TrySetResult(data)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tcsGetByteArray.TrySetException(e.[Error])
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return Nothing
&nbsp;&nbsp;&nbsp; End Function

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; '''&nbsp; Send a GET request to the specified Uri and return the response body as a
&nbsp;&nbsp;&nbsp; '''&nbsp; byte array in an asynchronous operation.
&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;requestUri&quot;&gt;The Uri the request is sent to.&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;returns&gt;
&nbsp;&nbsp;&nbsp; ''' Returns System.Threading.Tasks.Task TResult&gt;.The task object
&nbsp;&nbsp;&nbsp; ''' representing the asynchronous operation.
&nbsp; &nbsp;&nbsp;'''&nbsp; &lt;/returns&gt;
&nbsp;&nbsp;&nbsp; Public Async Function GetByteArrayAsync(requestUri As String) As Task(Of Byte())
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim uri As New Uri(requestUri)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim data As Byte() = Await GetByteArrayAsync(uri)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return data
&nbsp;&nbsp;&nbsp; End Function


&nbsp;&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; '''&nbsp; Send a GET request to the specified Uri and return the response body as a
&nbsp;&nbsp;&nbsp; '''&nbsp; byte array in an asynchronous operation.
&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;requestUri&quot;&gt;The Uri the request is sent to.&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;returns&gt;Returns byte array.The task object
&nbsp;&nbsp;&nbsp; ''' representing the asynchronous operation.&lt;/returns&gt;
&nbsp;&nbsp;&nbsp; Public Function GetByteArrayAsync(requestUri As Uri) As Task(Of Byte())
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AddHandler Me.DownloadStringCompleted, AddressOf MyDownloadByteArrayCompleted


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.DownloadStringAsync(requestUri)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Catch ex As Exception
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tcsGetByteArray.TrySetException(ex)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Try


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If tcsGetByteArray.Task.Exception IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Throw tcsGetByteArray.Task.Exception
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return tcsGetByteArray.Task
&nbsp;&nbsp;&nbsp; End Function


&nbsp;&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; ''' DownloadCompleted event of ByteArray.
&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;sender&quot;&gt;Me.DownloadStringCompleted&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;e&quot;&gt;DownloadStringCompletedEventArgs&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;returns&gt;Nothing&lt;/returns&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;remarks&gt;&lt;/remarks&gt;
&nbsp;&nbsp;&nbsp; Function MyDownloadByteArrayCompleted(ByVal sender As Object, _
ByVal e As System.Net.DownloadStringCompletedEventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If e.[Error] Is Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim data As Byte() = ConvertStringToByte(e.Result)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tcsGetByteArray.TrySetResult(data)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; tcsGetByteArray.TrySetException(e.[Error])
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return Nothing
&nbsp;&nbsp;&nbsp; End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">Step 6:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>To convert string to byte array, we will create a small conversion method.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Shared Function ConvertStringToByte(strTemp As String) As Byte()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim encoding As New System.Text.UTF8Encoding()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim data As Byte() = encoding.GetBytes(strTemp)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return data
&nbsp;&nbsp; End Function

</pre>
<pre id="codePreview" class="vb">
Private Shared Function ConvertStringToByte(strTemp As String) As Byte()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim encoding As New System.Text.UTF8Encoding()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim data As Byte() = encoding.GetBytes(strTemp)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return data
&nbsp;&nbsp; End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">Step 7:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Right-click <b style="">MainPage.xaml</b> and then click View Code. Replace the code with the following code:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Partial Public Class MainPage
&nbsp;&nbsp;&nbsp; Inherits PhoneApplicationPage


&nbsp;&nbsp;&nbsp; ' Constructor
&nbsp;&nbsp;&nbsp; Public Sub New()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; InitializeComponent()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SupportedOrientations = SupportedPageOrientation.Portrait Or SupportedPageOrientation.Landscape


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AddHandler Loaded, AddressOf MainPage_Loaded
&nbsp;&nbsp;&nbsp; End Sub


&nbsp;&nbsp;&nbsp; Private Async Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Await getResult()
&nbsp;&nbsp;&nbsp; End Sub


&nbsp;&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; ''' Get content of URL.
&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; Private Async Function getResult() As Tasks.Task
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim strRequestUri As String = &quot;http://www.bing.com&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim strResult As String = String.Empty


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Create a new instance.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim httpClient As New HttpClient()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' GetStringAsync
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strResult = Await httpClient.GetStringAsync(strRequestUri)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' GetByteArrayAsync
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim dataArray As System.Byte() = Await httpClient.GetByteArrayAsync(strRequestUri)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strResult = CStr(dataArray.Length)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Catch ex As Exception
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strResult = ex.Message
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Catch ex As Exception
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strResult = ex.Message
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Finally
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Show the result.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.Dispatcher.BeginInvoke(Sub() tbResult.Text = strResult)
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;End Try
&nbsp;&nbsp;&nbsp; End Function


End Class

</pre>
<pre id="codePreview" class="vb">
Partial Public Class MainPage
&nbsp;&nbsp;&nbsp; Inherits PhoneApplicationPage


&nbsp;&nbsp;&nbsp; ' Constructor
&nbsp;&nbsp;&nbsp; Public Sub New()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; InitializeComponent()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SupportedOrientations = SupportedPageOrientation.Portrait Or SupportedPageOrientation.Landscape


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AddHandler Loaded, AddressOf MainPage_Loaded
&nbsp;&nbsp;&nbsp; End Sub


&nbsp;&nbsp;&nbsp; Private Async Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Await getResult()
&nbsp;&nbsp;&nbsp; End Sub


&nbsp;&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; ''' Get content of URL.
&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; Private Async Function getResult() As Tasks.Task
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim strRequestUri As String = &quot;http://www.bing.com&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim strResult As String = String.Empty


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Create a new instance.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim httpClient As New HttpClient()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' GetStringAsync
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strResult = Await httpClient.GetStringAsync(strRequestUri)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' GetByteArrayAsync
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim dataArray As System.Byte() = Await httpClient.GetByteArrayAsync(strRequestUri)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strResult = CStr(dataArray.Length)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Catch ex As Exception
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strResult = ex.Message
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Catch ex As Exception
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; strResult = ex.Message
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Finally
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Show the result.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.Dispatcher.BeginInvoke(Sub() tbResult.Text = strResult)
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;End Try
&nbsp;&nbsp;&nbsp; End Function


End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">Step 8:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Build the application, and you can debug it.</p>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoNormal">TaskCompletionSource(Of TResult) Class<br>
<a href="http://msdn.microsoft.com/en-us/library/vstudio/dd449174(v=vs.95).aspx">http://msdn.microsoft.com/en-us/library/vstudio/dd449174(v=vs.95).aspx</a><br>
HttpClient.GetByteArrayAsync Method<br>
<a href="http://msdn.microsoft.com/en-us/library/system.net.http.httpclient.getbytearrayasync.aspx">http://msdn.microsoft.com/en-us/library/system.net.http.httpclient.getbytearrayasync.aspx</a><br>
HttpClient.GetStringAsync Method<br>
<a href="http://msdn.microsoft.com/en-us/library/system.net.http.httpclient.getstringasync.aspx">http://msdn.microsoft.com/en-us/library/system.net.http.httpclient.getstringasync.aspx</a><br>
HttpClient Class<br>
<a href="http://msdn.microsoft.com/en-us/library/hh193681.aspx">http://msdn.microsoft.com/en-us/library/hh193681.aspx</a><br>
Asynchronous Programming with Async and Await (C# and Visual Basic)<br>
<a href="http://msdn.microsoft.com/en-us/library/hh191443.aspx">http://msdn.microsoft.com/en-us/library/hh191443.aspx</a><br>
<br style="">
<br style="">
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

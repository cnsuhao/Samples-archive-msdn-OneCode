# Call web services through service bus by Windows Phone
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
* Windows Phone
* Windows Phone Development
## Topics
* Service Bus
## IsPublished
* True
## ModifiedDate
* 2013-06-13 09:54:39
## Description

<h1>Azure Service Bus on Windows Phone (VBWP8AzureServiceBusRest)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to perform management operations on the Service Bus using REST on Windows Phone, specifically:<br>
Generate Token<br>
Create a queue<br>
Send a message to a queue<br>
Receive a message from a queue<br>
List queues</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">Prerequisite: Visual Studio 2012 with Windows Phone SDK 8.0.<br>
You can download Visual Studio 2012 from here:<br>
<a href="http://www.microsoft.com/visualstudio/eng/downloads">http://www.microsoft.com/visualstudio/eng/downloads</a><br>
You can download Windows Phone SDK 8.0 from here:<br>
<a href="https://dev.windowsphone.com/en-us/downloadsdk">https://dev.windowsphone.com/en-us/downloadsdk</a><br>
<span style="">&nbsp;</span>You can get start by checking this link: <br>
<a href="http://create.msdn.com/en-us/home/getting_started">http://create.msdn.com/en-us/home/getting_started</a></p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">Step 1:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Open <b style="">VBWP8AzureServiceBusRest</b> in Visual Studio 2012 or Visual Studio Express 2012 for Windows Phone.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">Step 2:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Replace the <b style="">Service Bus Namespace</b>, <b style="">
issuer name</b> and <b style="">issuer secret</b> with your own's.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">Step 3:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press Ctrl &#43; F5. The emulator looks as follows:</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/84247/1/image.png" alt="" width="262" height="259" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle">If you debug the project, the output window looks as follows:</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/84248/1/image.png" alt="" width="754" height="154" align="middle">
</span><span style="">&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">Step 4:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>The validation is complete.</p>
<h2>Using the Code</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">Step 1:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create a new <b style="">Windows Phone project</b> in Visual Studio 2012 or Visual Studio Express 2012 for Windows Phone.
</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">Step 2:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>The code for generating token resembles the following :</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Async Function post(url As String, postdata As String) As Task(Of String)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim request As HttpWebRequest = TryCast(WebRequest.Create(New Uri(url)), HttpWebRequest)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; request.ContentType = &quot;application/x-www-form-urlencoded&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; request.Method = &quot;POST&quot;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim data As Byte() = Encoding.UTF8.GetBytes(postdata)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; request.ContentLength = data.Length


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using requestStream = Await Task(Of Stream).Factory.FromAsync(AddressOf request.BeginGetRequestStream, AddressOf request.EndGetRequestStream, request)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Await requestStream.WriteAsync(data, 0, data.Length)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '' Start the asynchronous operation to get the response 


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim responseObject As WebResponse = Await Task(Of WebResponse).Factory.FromAsync(AddressOf request.BeginGetResponse, AddressOf request.EndGetResponse, request)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim responseStream = responseObject.GetResponseStream()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim sr = New StreamReader(responseStream)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim received As String = Await sr.ReadToEndAsync()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return received
&nbsp; End Function

</pre>
<pre id="codePreview" class="vb">
Private Async Function post(url As String, postdata As String) As Task(Of String)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim request As HttpWebRequest = TryCast(WebRequest.Create(New Uri(url)), HttpWebRequest)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; request.ContentType = &quot;application/x-www-form-urlencoded&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; request.Method = &quot;POST&quot;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim data As Byte() = Encoding.UTF8.GetBytes(postdata)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; request.ContentLength = data.Length


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using requestStream = Await Task(Of Stream).Factory.FromAsync(AddressOf request.BeginGetRequestStream, AddressOf request.EndGetRequestStream, request)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Await requestStream.WriteAsync(data, 0, data.Length)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '' Start the asynchronous operation to get the response 


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim responseObject As WebResponse = Await Task(Of WebResponse).Factory.FromAsync(AddressOf request.BeginGetResponse, AddressOf request.EndGetResponse, request)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim responseStream = responseObject.GetResponseStream()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim sr = New StreamReader(responseStream)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim received As String = Await sr.ReadToEndAsync()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return received
&nbsp; End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">Step 3:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>We use the generate method resembles the following:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim postdata As String = &quot;wrap_name=&quot; & Uri.EscapeDataString(issuerName) & _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;&wrap_password=&quot; & Uri.EscapeDataString(issuerSecret) & _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;&wrap_scope=&quot; & Uri.EscapeDataString(realm)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim strResponse As String = Await post(acsEndpoint, postdata)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim responseProperties = strResponse.Split(&quot;&&quot;c)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim tokenProperty = responseProperties(0).Split(&quot;=&quot;c)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; token = Uri.UnescapeDataString(tokenProperty(1))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; token = &quot;WRAP access_token=&quot;&quot;&quot; & token & &quot;&quot;&quot;&quot;

</pre>
<pre id="codePreview" class="vb">
Dim postdata As String = &quot;wrap_name=&quot; & Uri.EscapeDataString(issuerName) & _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;&wrap_password=&quot; & Uri.EscapeDataString(issuerSecret) & _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;&wrap_scope=&quot; & Uri.EscapeDataString(realm)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim strResponse As String = Await post(acsEndpoint, postdata)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim responseProperties = strResponse.Split(&quot;&&quot;c)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim tokenProperty = responseProperties(0).Split(&quot;=&quot;c)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; token = Uri.UnescapeDataString(tokenProperty(1))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; token = &quot;WRAP access_token=&quot;&quot;&quot; & token & &quot;&quot;&quot;&quot;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">Step 4:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>The code for creating Queue resembles the following:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub CreateQueue(queueName As String, token As String)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Create the URI of the new Queue, note that this uses the HTTPS scheme
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim queueAddress = baseAddress & queueName
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim webClient As New WebClient()
&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;webClient.Headers(HttpRequestHeader.Authorization) = token


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Prepare the body of the create queue request
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim putData = &quot;&lt;entry xmlns=&quot;&quot;http://www.w3.org/2005/Atom&quot;&quot;&gt;&quot; & vbCr & vbLf & _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;&lt;title type=&quot;&quot;text&quot;&quot;&gt;&quot; & queueName & &quot;&lt;/title&gt;&quot; & vbCr & vbLf & _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot; &lt;content type=&quot;&quot;application/xml&quot;&quot;&gt;&quot; & vbCr & vbLf & _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;&nbsp; &lt;QueueDescription xmlns:i=&quot;&quot;http://www.w3.org/2001/XMLSchema-instance&quot;&quot; xmlns=&quot;&quot;http://schemas.microsoft.com/netservices/2010/10/servicebus/connect&quot;&quot; /&gt;&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp; &lt;/content&gt;&quot; & vbCr & vbLf & _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;&lt;/entry&gt;&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Debug.WriteLine(vbLf & &quot;Creating queue {0}&quot;, queueAddress)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AddHandler webClient.UploadStringCompleted, New UploadStringCompletedEventHandler(AddressOf webClient_CreateQueueCompleted)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; webClient.UploadStringAsync(New Uri(queueAddress), &quot;PUT&quot;, putData, token)
&nbsp;&nbsp; End Sub

</pre>
<pre id="codePreview" class="vb">
Private Sub CreateQueue(queueName As String, token As String)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Create the URI of the new Queue, note that this uses the HTTPS scheme
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim queueAddress = baseAddress & queueName
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim webClient As New WebClient()
&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;webClient.Headers(HttpRequestHeader.Authorization) = token


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Prepare the body of the create queue request
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim putData = &quot;&lt;entry xmlns=&quot;&quot;http://www.w3.org/2005/Atom&quot;&quot;&gt;&quot; & vbCr & vbLf & _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;&lt;title type=&quot;&quot;text&quot;&quot;&gt;&quot; & queueName & &quot;&lt;/title&gt;&quot; & vbCr & vbLf & _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot; &lt;content type=&quot;&quot;application/xml&quot;&quot;&gt;&quot; & vbCr & vbLf & _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;&nbsp; &lt;QueueDescription xmlns:i=&quot;&quot;http://www.w3.org/2001/XMLSchema-instance&quot;&quot; xmlns=&quot;&quot;http://schemas.microsoft.com/netservices/2010/10/servicebus/connect&quot;&quot; /&gt;&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp; &lt;/content&gt;&quot; & vbCr & vbLf & _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;&lt;/entry&gt;&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Debug.WriteLine(vbLf & &quot;Creating queue {0}&quot;, queueAddress)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AddHandler webClient.UploadStringCompleted, New UploadStringCompletedEventHandler(AddressOf webClient_CreateQueueCompleted)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; webClient.UploadStringAsync(New Uri(queueAddress), &quot;PUT&quot;, putData, token)
&nbsp;&nbsp; End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">Step 5:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>The code for sending message resembles the following:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub SendMessage(relativeAddress As String, body As String)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim fullAddress As String = baseAddress & relativeAddress & &quot;/messages&quot; & &quot;?timeout=60&quot;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim webClient As New WebClient()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; webClient.Headers(HttpRequestHeader.Authorization) = token


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Debug.WriteLine(vbLf & &quot;Sending message {0} - to address {1}&quot;, body, fullAddress)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AddHandler webClient.UploadStringCompleted, New UploadStringCompletedEventHandler(AddressOf webClient_UploadStringCompleted)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; webClient.UploadStringAsync(New Uri(fullAddress), &quot;POST&quot;, body, token)
&nbsp;&nbsp; End Sub

</pre>
<pre id="codePreview" class="vb">
Private Sub SendMessage(relativeAddress As String, body As String)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim fullAddress As String = baseAddress & relativeAddress & &quot;/messages&quot; & &quot;?timeout=60&quot;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim webClient As New WebClient()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; webClient.Headers(HttpRequestHeader.Authorization) = token


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Debug.WriteLine(vbLf & &quot;Sending message {0} - to address {1}&quot;, body, fullAddress)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AddHandler webClient.UploadStringCompleted, New UploadStringCompletedEventHandler(AddressOf webClient_UploadStringCompleted)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; webClient.UploadStringAsync(New Uri(fullAddress), &quot;POST&quot;, body, token)
&nbsp;&nbsp; End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">Step 6:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>The code for receiving data resembles the following:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Shared Sub DownloadData(fullAddress As String, strMessage As String)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim webClient As New WebClient()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; webClient.Headers(HttpRequestHeader.Authorization) = token


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Debug.WriteLine(strMessage)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AddHandler webClient.DownloadStringCompleted, New DownloadStringCompletedEventHandler(AddressOf DownloadStringCompletedEventArgs)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; webClient.DownloadStringAsync(New Uri(fullAddress))
&nbsp;&nbsp; End Sub


&nbsp;&nbsp; Private Shared Sub DownloadStringCompletedEventArgs(sender As Object, e As DownloadStringCompletedEventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If e.[Error] IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Debug.WriteLine(e.Result)
&nbsp;&nbsp; End Sub

</pre>
<pre id="codePreview" class="vb">
Private Shared Sub DownloadData(fullAddress As String, strMessage As String)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim webClient As New WebClient()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; webClient.Headers(HttpRequestHeader.Authorization) = token


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Debug.WriteLine(strMessage)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AddHandler webClient.DownloadStringCompleted, New DownloadStringCompletedEventHandler(AddressOf DownloadStringCompletedEventArgs)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; webClient.DownloadStringAsync(New Uri(fullAddress))
&nbsp;&nbsp; End Sub


&nbsp;&nbsp; Private Shared Sub DownloadStringCompletedEventArgs(sender As Object, e As DownloadStringCompletedEventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If e.[Error] IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Debug.WriteLine(e.Result)
&nbsp;&nbsp; End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">Step 7:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Build the application, and then you can debug it. </p>
<h2>More Information</h2>
<p class="MsoNormal">For more info about AppFabric Service Bus REST API Reference, please see this link:
<br>
<a href="http://msdn.microsoft.com/en-us/library/gg278338.aspx">http://msdn.microsoft.com/en-us/library/gg278338.aspx</a><br>
For more info about WebClient Class, please see this link: <br>
<a href="http://msdn.microsoft.com/en-us/library/tt0f69eh.aspx">http://msdn.microsoft.com/en-us/library/tt0f69eh.aspx</a><br>
For more info about WebClient.DownloadStringAsync Method, please see this link: <br>
<a href="http://msdn.microsoft.com/en-us/library/ms144202.aspx">http://msdn.microsoft.com/en-us/library/ms144202.aspx</a><br>
For more info about WebClient.UploadStringAsync Method, please see this link: <br>
<a href="http://msdn.microsoft.com/en-us/library/ms144241.aspx">http://msdn.microsoft.com/en-us/library/ms144241.aspx</a><br>
<br>
<span style="">&nbsp;</span><br>
<br>
<br style="">
<br style="">
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

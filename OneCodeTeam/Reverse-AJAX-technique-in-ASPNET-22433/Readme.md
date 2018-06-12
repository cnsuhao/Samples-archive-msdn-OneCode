# Reverse AJAX technique in ASP.NET
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* AJAX
## IsPublished
* True
## ModifiedDate
* 2013-06-05 12:37:27
## Description

<h1>Use Comet/Reverse Ajax technology in ASP.NET Web Site (CSASPNETReverseAJAX)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">Reverse Ajax is also known as Comet Ajax, Ajax Push, Two-way-web and HTTP server push. This technique persists a HTTP request to allow the server push data to a browser, without requesting the server in a<span style="">n</span> individual
 time.<br>
This sample shows how to use this technique in ASP.NET Ajax.<span style=""> </span>
</p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 1:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Open the CSASPNETReverseAJAX.sln.<span style=""> </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 2:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Expand the <span class="SpellE">CSASPNETReverseAJAX</span> web application.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 3:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">Open Receiver.aspx page in one or more windows (not browser tabs).
<br>
<span style="">&nbsp;&nbsp; </span>Log in with different user names. </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><img src="/site/view/file/83553/1/image.png" alt="" width="813" height="94" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 4:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">Open Sender.aspx page. Input recipient name and message content.<br>
<span style="">&nbsp;&nbsp; </span>Click the send button. </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><img src="/site/view/file/83554/1/image.png" alt="" width="632" height="345" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 5:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Validation finished.</p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 1:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Create a C# &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2012 or Visual Web Developer 2012. Name it as &quot;CSASPNETReverseAJAX&quot;.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 2:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">&nbsp;</span>Add two web forms in the root directory, name them as &quot;Receiver.aspx.aspx&quot;, &quot;<span style="">Sender</span>.aspx&quot;.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 3:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">Create a class file and name it as &quot;Message&quot;. It represents a message entity.</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 4:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">Create a class file and name it as &quot;Client&quot;.
</span>It represents a client that can receive messages from server. Also the server can send a message to the client. The class contains two private members and two public methods.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public class Client
&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; private ManualResetEvent messageEvent = new ManualResetEvent(false);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; private Queue&lt;Message&gt; messageQueue = new Queue&lt;Message&gt;();


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public void EnqueueMessage(Message message)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lock (messageQueue)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; messageQueue.Enqueue(message);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; messageEvent.Set();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public Message DequeueMessage()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; messageEvent.WaitOne();
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lock (messageQueue)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (messageQueue.Count == 1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; messageEvent.Reset();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return messageQueue.Dequeue();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp; }

</pre>
<pre id="codePreview" class="csharp">
public class Client
&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; private ManualResetEvent messageEvent = new ManualResetEvent(false);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; private Queue&lt;Message&gt; messageQueue = new Queue&lt;Message&gt;();


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public void EnqueueMessage(Message message)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lock (messageQueue)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; messageQueue.Enqueue(message);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; messageEvent.Set();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public Message DequeueMessage()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; messageEvent.WaitOne();
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lock (messageQueue)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (messageQueue.Count == 1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; messageEvent.Reset();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return messageQueue.Dequeue();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp; }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.25in"><span class="SpellE">EnqueueMessage</span> method is designed for the sender to send a message to that client, as well as DequeueMessage is designed for the recipient to receive messages.<span style="">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 5:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">Create a class file and name it as &quot;ClientAdapter&quot;. It is used to manage multiple clients. The presentation layer can easily call its methods to send and receive messages.</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 6:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">Add a web service to project. It is designed to be called by Ajax to receive messages.</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.25in; text-indent:-.25in">
<span style=""><span style="">Step 7:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>The Receiver.aspx page contains a JavaScript function waitEvent. When the function is called, it will persist a request until a new message. And then it will persist the next request immediately.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
function waitEvent() {


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CSASPNETReverseAJAX.Dispatcher.WaitMessage(&quot;&lt;%= Session[&quot;userName&quot;] %&gt;&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;function (result) {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; displayMessage(result);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;setTimeout(waitEvent, 0);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }, function () {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; setTimeout(waitEvent, 0);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; });
&nbsp;&nbsp;&nbsp; }

</pre>
<pre id="codePreview" class="csharp">
function waitEvent() {


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CSASPNETReverseAJAX.Dispatcher.WaitMessage(&quot;&lt;%= Session[&quot;userName&quot;] %&gt;&quot;, 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;function (result) {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; displayMessage(result);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;setTimeout(waitEvent, 0);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }, function () {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; setTimeout(waitEvent, 0);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; });
&nbsp;&nbsp;&nbsp; }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:.25in; text-indent:-.25in"><span style=""><span style="">Step 8:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Build the application and you can debug it<span style="">.</span></p>
<h2>More Information</h2>
<p class="MsoNormal">ManualResetEvent Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.threading.manualresetevent.aspx">http://msdn.microsoft.com/en-us/library/system.threading.manualresetevent.aspx</a><br>
ScriptManager Control Overview<br>
<a href="http://msdn.microsoft.com/en-us/library/bb398863.aspx">http://msdn.microsoft.com/en-us/library/bb398863.aspx</a><br>
Web Services in ASP.NET AJAX<br>
<a href="http://msdn.microsoft.com/en-us/library/bb398785(v=VS.90).aspx">http://msdn.microsoft.com/en-us/library/bb398785(v=VS.90).aspx</a><span style="">
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

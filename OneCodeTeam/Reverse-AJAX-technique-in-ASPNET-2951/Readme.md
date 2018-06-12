# Reverse AJAX technique in ASP.NET (CSASPNETReverseAJAX)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* AJAX
* Reverse Ajax
* Comet Ajax
* Ajax Push
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:07:02
## Description

<p style="font-family:Courier New"></p>
<h2>ASP.NET APPLICATION : CSASPNETReverseAJAX Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
Reverse Ajax is also known as Comet Ajax, Ajax Push, Two-way-web and HTTP server push.
<br>
This technique persists a HTTP request to allow the server push data to a browser,
<br>
without requesting the server in a individual time.<br>
<br>
This sample shows how to use this technique in ASP.NET Ajax.<br>
</p>
<h3>Demo the Sample:</h3>
<p style="font-family:Courier New"><br>
1. Open Receiver.aspx page in one or more windows (not browser tabs). <br>
&nbsp; Log in with different user names.<br>
<br>
2. Open Sender.aspx page. Input recipient name and message content.<br>
&nbsp; Click the send button.<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
1. The Message class represents a message entity.<br>
<br>
2. The Client class represents a client that can receive messages from server. <br>
&nbsp; Also the server can send a message to the client. The class contains two <br>
&nbsp; private members and two public methods. <br>
&nbsp; <br>
&nbsp; &nbsp;public class Client<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;private ManualResetEvent messageEvent = new ManualResetEvent(false);<br>
&nbsp; &nbsp; &nbsp; &nbsp;private Queue&lt;Message&gt; messageQueue = new Queue&lt;Message&gt;();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public void EnqueueMessage(Message message)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lock (messageQueue)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;messageQueue.Enqueue(message);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;messageEvent.Set();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;public Message DequeueMessage()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;messageEvent.WaitOne();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;lock (messageQueue)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (messageQueue.Count == 1)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;messageEvent.Reset();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return messageQueue.Dequeue();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;}<br>
<br>
&nbsp; EnqueueMessage method is designed for the sender to send a message to that
<br>
&nbsp; client, as well as DequeueMessage is designed for the recipient to receive
<br>
&nbsp; messages.<br>
<br>
3. The ClientAdapter class is used to manage multiple clients. The presentation <br>
&nbsp; layer can easily call its methods to send and receive messages.<br>
<br>
4. Dispatcher.asmx web service is designed to be called by Ajax to receive messages.<br>
<br>
5. The Receiver.aspx page contains a JavaScript function waitEvent. When the function<br>
&nbsp; is called, it will persist a request until a new message. And then it will persist
<br>
&nbsp; the next request immediately.<br>
<br>
&nbsp; &nbsp;function waitEvent() {<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;CSASPNETReverseAJAX.Dispatcher.WaitMessage(&quot;&lt;%= Session[&quot;userName&quot;] %&gt;&quot;,
<br>
&nbsp; &nbsp; &nbsp; &nbsp;function (result) {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;displayMessage(result);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;setTimeout(waitEvent, 0);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}, function () {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;setTimeout(waitEvent, 0);<br>
&nbsp; &nbsp; &nbsp; &nbsp;});<br>
&nbsp; &nbsp;}<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
ManualResetEvent Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.threading.manualresetevent.aspx">http://msdn.microsoft.com/en-us/library/system.threading.manualresetevent.aspx</a><br>
<br>
ScriptManager Control Overview<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb398863.aspx">http://msdn.microsoft.com/en-us/library/bb398863.aspx</a><br>
<br>
Web Services in ASP.NET AJAX<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb398785(v=VS.90).aspx">http://msdn.microsoft.com/en-us/library/bb398785(v=VS.90).aspx</a><br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

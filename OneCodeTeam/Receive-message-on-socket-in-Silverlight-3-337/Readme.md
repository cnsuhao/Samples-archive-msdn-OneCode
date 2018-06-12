# Receive message on socket in Silverlight 3 (VBSL3SocketServer)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Silverlight
* Network
## Topics
* Socket
## IsPublished
* False
## ModifiedDate
* 2011-05-05 08:18:52
## Description

<p style="font-family:Courier New"></p>
<h2>SILVERLIGHT APPLICATION : VBSL3SocketServer Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This project create a socket server sample, which could serve both sivlerlight<br>
and normal socket client.<br>
This socket server will accept client connection, then receive string message and
<br>
send back the respone message. &nbsp; &nbsp; <br>
&nbsp; &nbsp;<br>
</p>
<h3>Project Relation:</h3>
<p style="font-family:Courier New"><br>
VBSL3SocketServer &lt;--&gt; VBSL3SocketClient<br>
VBSL3SocketClient is Silverlight Socket client.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
To run the socket sample, please try the following steps:<br>
1. To start socket server<br>
&nbsp;&nbsp;&nbsp;&nbsp;a. Open CSSLSocketServer solution with Administrator account, compile.<br>
&nbsp;&nbsp;&nbsp;&nbsp;b. Run the project.<br>
2. To run the silverlight socket client<br>
&nbsp;&nbsp;&nbsp;&nbsp;a. Open VBSL3SocketClient solution, compile and run.<br>
&nbsp;&nbsp;&nbsp;&nbsp;b. When Silverlight application loaded, follow the instructions displayed on page:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1) Click &quot;connect&quot; to connect to socket server.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2) Input text in textbox and click &quot;send&quot; button.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3) Server will receive and handle string message, then send back after 1 second.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. What's the difference between socket server for Silverlight and normal socket server?<br>
&nbsp;&nbsp;&nbsp;&nbsp;Due to security reason, before Silverlight client connect to socket server, it will<br>
&nbsp;&nbsp;&nbsp;&nbsp;try to connect server 943 port to request access policy. This project create two<br>
&nbsp;&nbsp;&nbsp;&nbsp;socket listener, one for serving client communication, another is listening to 943<br>
&nbsp;&nbsp;&nbsp;&nbsp;port to respond silverlight client's policy request.<br>
&nbsp;&nbsp;&nbsp;&nbsp;For details about how Socket server works, please refer to another socket server
<br>
&nbsp;&nbsp;&nbsp;&nbsp;sample project: CSSocketServer<br>
&nbsp; </p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Socket Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.net.sockets.socket.aspx">http://msdn.microsoft.com/en-us/library/system.net.sockets.socket.aspx</a><br>
<br>
Network Security Access Restrictions in Silverlight<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc645032(VS.95).aspx">http://msdn.microsoft.com/en-us/library/cc645032(VS.95).aspx</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

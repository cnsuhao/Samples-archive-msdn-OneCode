# C# app receives message on socket (CSSocketServer)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* IPC and RPC
* Windows General
## Topics
* Network
* Socket
* Inter-process Communication
## IsPublished
* True
## ModifiedDate
* 2013-02-19 05:59:00
## Description

<p style="font-family:Courier New">&nbsp;</p>
<h2>CONSOLE APPLICATION : CSSocketServer Project Overview</h2>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
Sockets are an application programming interface (API) in an operating system,<br>
used for in inter-process communication. Sockets constitute a mechanism for <br>
delivering incoming data packets to the appropriate application process or <br>
thread, based on a combination of local and remote IP addresses and port <br>
numbers. Each socket is mapped by the operational system to a communicating<br>
application process or thread.<br>
<br>
<br>
.NET supplies a Socket class which implements the Berkeley sockets interface.<br>
It provides a rich set of methods and properties for network communications. <br>
The Socket class allows you to perform both synchronous and asynchronous data<br>
transfer using any of the communication protocols listed in the ProtocolType<br>
enumeration. It supplies the following types of socket:<br>
<br>
Stream: Supports reliable, two-way, connection-based byte streams without <br>
the duplication of data and without preservation of boundaries.<br>
<br>
Dgram:Supports datagrams, which are connectionless, unreliable messages of<br>
a fixed (typically small) maximum length. <br>
<br>
Raw: Supports access to the underlying transport protocol.Using the <br>
SocketTypeRaw, you can communicate using protocols like Internet Control <br>
Message Protocol (Icmp) and Internet Group Management Protocol (Igmp). <br>
<br>
Rdm: Supports connectionless, message-oriented, reliably delivered messages, <br>
and preserves message boundaries in data. <br>
<br>
Seqpacket:Provides connection-oriented and reliable two-way transfer of <br>
ordered byte streams across a network.<br>
<br>
Unknown:Specifies an unknown Socket type.<br>
<br>
There are some limitations on this sample:<br>
<br>
1. Due to the socket buffer size, the string message including EOM marker shouldn't<br>
bigger than 1024 bytes when encoded to bytes by Unicode.<br>
<br>
2. The sample is designed for receiving and sending only one string message.<br>
<br>
To overcome the limitations above, the developer need handle message separating<br>
and merging operations on socket buffer. <br>
<br>
</p>
<h3>Project Relation:</h3>
<p style="font-family:Courier New"><br>
CSSocketClient &lt;--&gt; CSSocketServer<br>
CSSocketClient is the client process to communicate the server process<br>
via the socket.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. Create a socket to listen the incoming TCP connection.<br>
<br>
2. After get the client connection,asynchronously receive the data and listen<br>
the TCP connection again.<br>
<br>
3. Finishing receiving data, send the response to client process.<br>
<br>
4. If user inputs the word quit to exit the program<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Chapter4: Using Sockets of Professional .NET Network Prgromming<br>
<a href="http://www.amazon.com/Professional-Network-Programming-Srinivasa-Sivakumar/dp/1861007353" target="_blank">http://www.amazon.com/Professional-Network-Programming-Srinivasa-Sivakumar/dp/1861007353</a><br>
<br>
Socket Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.net.sockets.socket.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/system.net.sockets.socket.aspx</a><br>
<br>
Asynchronous Server Socket Example<br>
<a href="http://msdn.microsoft.com/en-us/library/fx6588te.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/fx6588te.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

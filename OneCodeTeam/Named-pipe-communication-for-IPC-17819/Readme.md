# Named-pipe communication for IPC (VBNamedPipeCommunication)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Windows SDK
* IPC and RPC
## Topics
* Communication
* named-pipe
## IsPublished
* True
## ModifiedDate
* 2013-02-19 06:06:19
## Description

<h1><span>VB.NET</span> named-pipe <span>communication </span>for IPC (VBNamedPipeCommunication)</h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span>Named pipe is a mechanism for one-way or duplex inter-process communication between the pipe server and one or more pipe clients in the local machine or across the computers in the intranet:
</span></p>
<p class="MsoNormal"><span>PIPE_ACCESS_INBOUND: </span></p>
<p class="MsoNormal"><span>Client (GENERIC_WRITE) ---&gt; Server (GENERIC_READ)
</span></p>
<p class="MsoNormal"><span>PIPE_ACCESS_OUTBOUND: </span></p>
<p class="MsoNormal"><span>Client (GENERIC_READ) &lt;--- Server (GENERIC_WRITE)
</span></p>
<p class="MsoNormal"><span>PIPE_ACCESS_DUPLEX: </span></p>
<p class="MsoNormal"><span>Client (GENERIC_READ or GENERIC_WRITE, or both) &lt;--&gt; Server (GENERIC_READ and GENERIC_WRITE)
</span></p>
<p class="MsoNormal"><span>This code sample demonstrates two methods to use named pipe in VB.NET.
</span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span><span>&nbsp;</span>Use the <span class="SpellE"><strong>System.IO.Pipes</strong></span> namespace
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>The <a href="http://msdn.microsoft.com/en-us/library/system.io.pipes.aspx">
<span class="SpellE">System.IO.Pipes</span></a> namespace contains types that provide a means for
<span class="SpellE">interprocess</span> communication through anonymous and/or named pipes. These classes make the programming of named pipe in .NET much easier and safer than P/Invoking native APIs directly. However, the
<span class="SpellE"><strong>System.IO.Pipes</strong></span> namespace is not available before .NET Framework 3.5. So, if you are programming against .NET Framework 2.0, you have to P/Invoke native APIs to use named pipe.
</span></p>
<p class="MsoListParagraphCxSpLast"><span>The sample code in <span class="SpellE">
<span class="GramE">SystemIONamedPipeClient.Run</span></span><span class="GramE">(</span>) uses the
<span class="SpellE">Systen.IO.Pipes.NamedPipeClientStream</span> class to connect to the named pipe &quot;\\.\pipe\SamplePipe&quot; to perform message-based duplex communication. The client then writes a message to the pipe and receives the response from the pipe
 server. </span></p>
<p class="MsoNormal"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span><span>&nbsp;</span>P/Invoke the native APIs related to named pipe operations.
</span></p>
<p class="MsoListParagraphCxSpLast"><span>The .NET <span class="SpellE">interop</span> services make it possible to call native APIs related to named pipe operations from .NET. The sample code in
<span class="SpellE">NativeNamedPipeClient.Run</span>() demonstrates calling <span class="SpellE">
<strong>CreateFile</strong></span> to connect to the named pipe &quot;\\.\pipe\SamplePipe&quot; with the GENERIC_READ and GENERIC_WRITE accesses, and calling
<span class="SpellE">WriteFile</span> and <span class="SpellE">ReadFile</span> to write a message to the pipe and receive the response from the pipe server. Please note that if you are programming against .NET Framework 3.5 or any newer releases of .NET
 Framework, it is safer and easier to use the types in the <span class="SpellE">
System.IO.Pipes</span> namespace to operate named pipes. </span></p>
<h2>Running the Sample<span> </span></h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Build the solution, and you will get 2 application: </span>
</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt; text-indent:5.0pt">
<span><span>a.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>VBNamedPipeServer.exe </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt; text-indent:5.0pt">
<span><span>b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>VBNamedPipeClient.exe </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Run VBNamedPipeServer.exe in a command prompt to start up the server end of the named pipe.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>If the command is &quot;VBNamedPipeServer.exe&quot;, the pipe server is created by the types in the
<span class="SpellE">System.IO.Pipes</span> namespace. If the command is &quot;VBNamedPipeServer.exe -native&quot;, the pipe server is created by P/Invoking the native APIs related to named pipe operations. In both cases, the application outputs the following information
 in the command prompt if the pipe is created successfully. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/61875/1/image.png" alt="" width="571" height="68" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Run VBNamedPipeClient.exe in another command prompt to start up the client end of the named pipe. If the command is &quot;VBNamedPipeClient.exe&quot;, the client connects to the pipe by using the types in the
<span class="SpellE"><strong>System.IO.Pipes</strong></span> namespace. If the command is &quot;VBNamedPipeClient.exe -native&quot;, the client connects to the pipe by P/Invoking the native APIs related to named pipe operations. In both cases, the
<strong>client application</strong> should output the message below in the command prompt when the client successfully connects to the named pipe.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/61876/1/image.png" alt="" width="573" height="21" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>In the meantime, the <strong>server application</strong> outputs this message to indicate that the pipe is connected by a client.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/61877/1/image.png" alt="" width="569" height="48" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span><span>4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>The <strong>client application</strong> attempts to write a message to the named pipe. You will see the message below in the command prompt running the
<strong>client application</strong>. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/61878/1/image.png" alt="" width="571" height="34" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>When the <a name="OLE_LINK1"></a><a name="OLE_LINK2"><span><strong>server application</strong>
</span></a>reads the message from the client, it prints:<span> </span></span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/61879/1/image.png" alt="" width="566" height="68" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>Next, the <strong>server application</strong> writes a response to the pipe.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/61880/1/image.png" alt="" width="569" height="89" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>And the <strong>client application</strong> receives the response:
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/61881/1/image.png" alt="" width="569" height="62" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast"><span>The connection is disconnected and the pipe is closed after that.
</span></p>
<h2>Using the Code<span> </span></h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE"><strong><span>NamedPipeServer</span></strong></span><span>.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt; text-indent:5.0pt">
<span><span>a.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Named pipe server by using the <span class="SpellE">
System.IO.Pipes</span> namespace. (<span class="SpellE">SystemIONamedPipeServer.Run</span>())
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt; text-indent:5.0pt">
<span><span><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>i.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Create a named pipe server (<span class="SpellE">System.IO.Pipes.NamedPipeServerStream</span>) object and specify pipe name, pipe direction, options, transmission mode, security attributes, etc.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">' Create the named pipe.
  pipeServer = New NamedPipeServerStream( _
  PipeName, _
  PipeDirection.InOut, _
  NamedPipeServerStream.MaxAllowedServerInstances, _
  PipeTransmissionMode.Message, _
  PipeOptions.None, _
  BufferSize, _
  BufferSize, _
  pipeSecurity, _
  HandleInheritability.None)

</pre>
<pre id="codePreview" class="vb">' Create the named pipe.
  pipeServer = New NamedPipeServerStream( _
  PipeName, _
  PipeDirection.InOut, _
  NamedPipeServerStream.MaxAllowedServerInstances, _
  PipeTransmissionMode.Message, _
  PipeOptions.None, _
  BufferSize, _
  BufferSize, _
  pipeSecurity, _
  HandleInheritability.None)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span>In this code sample, the pipe server support message-based duplex communications. The security attributes of the pipe are customized to allow
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt"><span>Authenticated Users read and write access to a pipe, and to allow the Administrators group full access to the pipe.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">' Allow Everyone read and write access to the pipe.
pipeSecurity.SetAccessRule(New PipeAccessRule(&quot;Authenticated Users&quot;, _
    PipeAccessRights.ReadWrite, AccessControlType.Allow))


' Allow the Administrators group full access to the pipe.
pipeSecurity.SetAccessRule(New PipeAccessRule(&quot;Administrators&quot;, _
    PipeAccessRights.FullControl, AccessControlType.Allow))

</pre>
<pre id="codePreview" class="vb">' Allow Everyone read and write access to the pipe.
pipeSecurity.SetAccessRule(New PipeAccessRule(&quot;Authenticated Users&quot;, _
    PipeAccessRights.ReadWrite, AccessControlType.Allow))


' Allow the Administrators group full access to the pipe.
pipeSecurity.SetAccessRule(New PipeAccessRule(&quot;Administrators&quot;, _
    PipeAccessRights.FullControl, AccessControlType.Allow))

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt; text-indent:5.0pt">
<span><span><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>ii.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Wait for the client to connect by calling <span class="SpellE">
<span class="GramE">NamedPipeServerStream.WaitForConnection</span></span><span class="GramE">(</span>).
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">' Wait for the client to connect.
Console.WriteLine(&quot;Waiting for the client's connection...&quot;)
pipeServer.WaitForConnection()

</pre>
<pre id="codePreview" class="vb">' Wait for the client to connect.
Console.WriteLine(&quot;Waiting for the client's connection...&quot;)
pipeServer.WaitForConnection()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt; text-indent:5.0pt">
<span><span><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>iii.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Read the client's request from the pipe and write a response by calling
<span class="SpellE">NamedPipeServerStream.Read</span> and <span class="SpellE">
NamedPipeServerStream.Write</span>. The named pipe was created to support message-based communication. This allows a reading process to read varying-length messages precisely as sent by the writing process. In this mode you should not use
<span class="SpellE">StreamWriter</span> to write the pipe, or use <span class="SpellE">
StreamReader</span> to read the pipe. You can read more about the difference from the article:
<a href="http://go.microsoft.com/?linkid=9721786">http://go.microsoft.com/?linkid=9721786</a>.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Dim message As String
Do
    Dim bRequest(BufferSize - 1) As Byte
    Dim cbRequest As Integer = bRequest.Length, cbRead As Integer


    cbRead = pipeServer.Read(bRequest, 0, cbRequest)


    ' Unicode-encode the received byte array and trim all the '\0' 
    ' characters at the end.
    message = Encoding.Unicode.GetString(bRequest).TrimEnd( _
        ControlChars.NullChar)
    Console.WriteLine(&quot;Receive {0} bytes from client: &quot;&quot;{1}&quot;&quot;&quot;, _
        cbRead, message)
Loop While Not pipeServer.IsMessageComplete


' 
' Send a response from server to client.
' 


message = ResponseMessage
Dim bResponse As Byte() = Encoding.Unicode.GetBytes(message)
Dim cbResponse As Integer = bResponse.Length


pipeServer.Write(bResponse, 0, cbResponse)


Console.WriteLine(&quot;Send {0} bytes to client: &quot;&quot;{1}&quot;&quot;&quot;, _
    cbResponse, message.TrimEnd(ControlChars.NullChar))

</pre>
<pre id="codePreview" class="vb">Dim message As String
Do
    Dim bRequest(BufferSize - 1) As Byte
    Dim cbRequest As Integer = bRequest.Length, cbRead As Integer


    cbRead = pipeServer.Read(bRequest, 0, cbRequest)


    ' Unicode-encode the received byte array and trim all the '\0' 
    ' characters at the end.
    message = Encoding.Unicode.GetString(bRequest).TrimEnd( _
        ControlChars.NullChar)
    Console.WriteLine(&quot;Receive {0} bytes from client: &quot;&quot;{1}&quot;&quot;&quot;, _
        cbRead, message)
Loop While Not pipeServer.IsMessageComplete


' 
' Send a response from server to client.
' 


message = ResponseMessage
Dim bResponse As Byte() = Encoding.Unicode.GetBytes(message)
Dim cbResponse As Integer = bResponse.Length


pipeServer.Write(bResponse, 0, cbResponse)


Console.WriteLine(&quot;Send {0} bytes to client: &quot;&quot;{1}&quot;&quot;&quot;, _
    cbResponse, message.TrimEnd(ControlChars.NullChar))

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt; text-indent:5.0pt">
<span><span><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>iv.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Flush the pipe to allow the client to read the pipe's contents before disconnecting. Then disconnect the client's connection.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">pipeServer.WaitForPipeDrain()
pipeServer.Disconnect()

</pre>
<pre id="codePreview" class="vb">pipeServer.WaitForPipeDrain()
pipeServer.Disconnect()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt; text-indent:5.0pt">
<span><span><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>v.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Close the server end of the pipe by calling <span class="SpellE">
<span class="GramE">NamedPipeServerStream.Close</span></span><span class="GramE">(</span>).
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">pipeServer.Close()

</pre>
<pre id="codePreview" class="vb">pipeServer.Close()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt; text-indent:5.0pt">
<span><span>b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Named pipe server by P/Invoke the native APIs related to named pipe operations. (<span class="SpellE">NativeNamedPipeServer.Run</span>())
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt; text-indent:5.0pt">
<span><span><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>i.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Create a named pipe server by P/Invoking <span class="SpellE">
CreateNamedPipe</span> and specifying the pipe name, pipe direction, options, transmission mode, security attributes, etc.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">' Create the named pipe.
hNamedPipe = NativeMethod.CreateNamedPipe( _
    FullPipeName, _
    PipeOpenMode.PIPE_ACCESS_DUPLEX, _
    PipeMode.PIPE_TYPE_MESSAGE _
    Or PipeMode.PIPE_READMODE_MESSAGE _
    Or PipeMode.PIPE_WAIT, _
    PIPE_UNLIMITED_INSTANCES, _
    BufferSize, _
    BufferSize, _
    NMPWAIT_USE_DEFAULT_WAIT, _
    sa)

</pre>
<pre id="codePreview" class="vb">' Create the named pipe.
hNamedPipe = NativeMethod.CreateNamedPipe( _
    FullPipeName, _
    PipeOpenMode.PIPE_ACCESS_DUPLEX, _
    PipeMode.PIPE_TYPE_MESSAGE _
    Or PipeMode.PIPE_READMODE_MESSAGE _
    Or PipeMode.PIPE_WAIT, _
    PIPE_UNLIMITED_INSTANCES, _
    BufferSize, _
    BufferSize, _
    NMPWAIT_USE_DEFAULT_WAIT, _
    sa)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span>In this code sample, the pipe server support message-based duplex communications. The security attributes of the pipe are customized to allow
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span>Authenticated Users read and write access to a pipe, and to allow the Administrators group full access to the pipe.
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">' Define the SDDL for the security descriptor that allows read/write to 
' authenticated users and allows full control to administrators.
Dim sddl As String = &quot;D:(A;OICI;GRGW;;;AU)(A;OICI;GA;;;BA)&quot;


Dim pSecurityDescriptor As New SafeLocalMemHandle
If (Not NativeMethod.ConvertStringSecurityDescriptorToSecurityDescriptor( _
    sddl, 1, pSecurityDescriptor, IntPtr.Zero)) Then
    Throw New Win32Exception
End If


Dim sa As New SECURITY_ATTRIBUTES()
sa.nLength = Marshal.SizeOf(sa)
sa.lpSecurityDescriptor = pSecurityDescriptor
sa.bInheritHandle = False

</pre>
<pre id="codePreview" class="vb">' Define the SDDL for the security descriptor that allows read/write to 
' authenticated users and allows full control to administrators.
Dim sddl As String = &quot;D:(A;OICI;GRGW;;;AU)(A;OICI;GA;;;BA)&quot;


Dim pSecurityDescriptor As New SafeLocalMemHandle
If (Not NativeMethod.ConvertStringSecurityDescriptorToSecurityDescriptor( _
    sddl, 1, pSecurityDescriptor, IntPtr.Zero)) Then
    Throw New Win32Exception
End If


Dim sa As New SECURITY_ATTRIBUTES()
sa.nLength = Marshal.SizeOf(sa)
sa.lpSecurityDescriptor = pSecurityDescriptor
sa.bInheritHandle = False

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt; text-indent:5.0pt">
<span><span><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>ii.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Wait for the client to connect by calling <span class="SpellE">
ConnectNamedPipe</span>. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">' Wait for the client to connect.
Console.WriteLine(&quot;Waiting for the client's connection...&quot;)
If (Not NativeMethod.ConnectNamedPipe(hNamedPipe, IntPtr.Zero)) Then
    If (Marshal.GetLastWin32Error() &lt;&gt; ERROR_PIPE_CONNECTED) Then
        Throw New Win32Exception
    End If
End If

</pre>
<pre id="codePreview" class="vb">' Wait for the client to connect.
Console.WriteLine(&quot;Waiting for the client's connection...&quot;)
If (Not NativeMethod.ConnectNamedPipe(hNamedPipe, IntPtr.Zero)) Then
    If (Marshal.GetLastWin32Error() &lt;&gt; ERROR_PIPE_CONNECTED) Then
        Throw New Win32Exception
    End If
End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt; text-indent:5.0pt">
<span><span><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>iii.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Read the client's request from the pipe and write a response by calling
<span class="SpellE">ReadFile</span> and <span class="SpellE">WriteFile</span>.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Dim message As String
Dim finishRead As Boolean = False
Do
    Dim bRequest(BufferSize - 1) As Byte
    Dim cbRequest As Integer = bRequest.Length, cbRead As Integer


    finishRead = NativeMethod.ReadFile(hNamedPipe, bRequest, _
        cbRequest, cbRead, IntPtr.Zero)


    If (Not finishRead _
        AndAlso Marshal.GetLastWin32Error() &lt;&gt; ERROR_MORE_DATA) Then
        Throw New Win32Exception
    End If


    ' Unicode-encode the received byte array and trim all the '\0' 
    ' characters at the end.
    message = Encoding.Unicode.GetString(bRequest).TrimEnd( _
        ControlChars.NullChar)
    Console.WriteLine(&quot;Receive {0} bytes from client: &quot;&quot;{1}&quot;&quot;&quot;, _
        cbRead, message)
Loop While Not finishRead   ' Repeat loop if ERROR_MORE_DATA


'
' Send a response from server to client.
' 


message = ResponseMessage
Dim bResponse As Byte() = Encoding.Unicode.GetBytes(message)
Dim cbResponse As Integer = bResponse.Length, cbWritten As Integer


If (Not NativeMethod.WriteFile(hNamedPipe, bResponse, cbResponse, _
    cbWritten, IntPtr.Zero)) Then
    Throw New Win32Exception
End If


Console.WriteLine(&quot;Send {0} bytes to client: &quot;&quot;{1}&quot;&quot;&quot;, _
    cbWritten, message.TrimEnd(ControlChars.NullChar))

</pre>
<pre id="codePreview" class="vb">Dim message As String
Dim finishRead As Boolean = False
Do
    Dim bRequest(BufferSize - 1) As Byte
    Dim cbRequest As Integer = bRequest.Length, cbRead As Integer


    finishRead = NativeMethod.ReadFile(hNamedPipe, bRequest, _
        cbRequest, cbRead, IntPtr.Zero)


    If (Not finishRead _
        AndAlso Marshal.GetLastWin32Error() &lt;&gt; ERROR_MORE_DATA) Then
        Throw New Win32Exception
    End If


    ' Unicode-encode the received byte array and trim all the '\0' 
    ' characters at the end.
    message = Encoding.Unicode.GetString(bRequest).TrimEnd( _
        ControlChars.NullChar)
    Console.WriteLine(&quot;Receive {0} bytes from client: &quot;&quot;{1}&quot;&quot;&quot;, _
        cbRead, message)
Loop While Not finishRead   ' Repeat loop if ERROR_MORE_DATA


'
' Send a response from server to client.
' 


message = ResponseMessage
Dim bResponse As Byte() = Encoding.Unicode.GetBytes(message)
Dim cbResponse As Integer = bResponse.Length, cbWritten As Integer


If (Not NativeMethod.WriteFile(hNamedPipe, bResponse, cbResponse, _
    cbWritten, IntPtr.Zero)) Then
    Throw New Win32Exception
End If


Console.WriteLine(&quot;Send {0} bytes to client: &quot;&quot;{1}&quot;&quot;&quot;, _
    cbWritten, message.TrimEnd(ControlChars.NullChar))

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt; text-indent:5.0pt">
<span><span><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>iv.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Flush the pipe to allow the client to read the pipe's contents before disconnecting. Then disconnect the client's connection.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">' Flush the pipe to allow the client to read the pipe's contents 
' before disconnecting. Then disconnect the client's connection.
NativeMethod.FlushFileBuffers(hNamedPipe)
NativeMethod.DisconnectNamedPipe(hNamedPipe)

</pre>
<pre id="codePreview" class="vb">' Flush the pipe to allow the client to read the pipe's contents 
' before disconnecting. Then disconnect the client's connection.
NativeMethod.FlushFileBuffers(hNamedPipe)
NativeMethod.DisconnectNamedPipe(hNamedPipe)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt; text-indent:5.0pt">
<span><span><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>v.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Close the server end of the pipe. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">hNamedPipe.Close()

</pre>
<pre id="codePreview" class="vb">hNamedPipe.Close()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><strong><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></strong><span class="SpellE"><strong><span>NamedPipeClient</span></strong></span><strong><span>
</span></strong></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt; text-indent:5.0pt">
<span><span>a.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Named pipe client by using the <span class="SpellE">
System.IO.Pipes</span> namespace. (<span class="SpellE">SystemIONamedPipeClient.Run</span>())
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt; text-indent:5.0pt">
<span><span><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>i.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Create a <span class="SpellE">NamedPipeClientStream</span> object and specify the pipe server, name, pipe direction, options, etc.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">pipeClient = New NamedPipeClientStream(ServerName, PipeName, _
    PipeDirection.InOut, PipeOptions.None)

</pre>
<pre id="codePreview" class="vb">pipeClient = New NamedPipeClientStream(ServerName, PipeName, _
    PipeDirection.InOut, PipeOptions.None)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt; text-indent:5.0pt">
<span><span><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>ii.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Connect to the named pipe by calling <span class="SpellE">
<span class="GramE">NamedPipeClientStream.Connect</span></span><span class="GramE">(</span>).
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">pipeClient.Connect(5000)

</pre>
<pre id="codePreview" class="vb">pipeClient.Connect(5000)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt; text-indent:5.0pt">
<span><span><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>iii.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Set the read mode and the blocking mode of the named pipe. In this sample, we set data to be read from the pipe as a stream of messages. This allows a reading process to read varying-length messages precisely as sent by the writing
 process. In this mode, you should not use <span class="SpellE">StreamWriter</span> to write the pipe, or use
<span class="SpellE">StreamReader</span> to read the pipe. You can read more about the difference from
<a href="http://go.microsoft.com/?linkid=9721786">http://go.microsoft.com/?linkid=9721786</a>.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">pipeClient.ReadMode = PipeTransmissionMode.Message

</pre>
<pre id="codePreview" class="vb">pipeClient.ReadMode = PipeTransmissionMode.Message

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt; text-indent:5.0pt">
<span><span><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>iv.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Send a message to the pipe server and receive its response through
<span class="SpellE">NamedPipeClientStream.Read</span> and <span class="SpellE">
NamedPipeClientStream.Write</span>. Because <span class="SpellE">pipeClient.ReadMode</span> =
<span class="SpellE">PipeTransmissionMode.Message</span>, you should not use <span class="SpellE">
StreamWriter</span> to write the pipe, or use <span class="SpellE">StreamReader</span> to read the pipe.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Dim message As String = RequestMessage
Dim bRequest As Byte() = Encoding.Unicode.GetBytes(message)
Dim cbRequest As Integer = bRequest.Length


pipeClient.Write(bRequest, 0, cbRequest)


Console.WriteLine(&quot;Send {0} bytes to server: &quot;&quot;{1}&quot;&quot;&quot;, _
    cbRequest, message.TrimEnd(ControlChars.NullChar))


'
' Receive a response from server.
'


Do
    Dim bResponse(BufferSize - 1) As Byte
    Dim cbResponse As Integer = bResponse.Length, cbRead As Integer


    cbRead = pipeClient.Read(bResponse, 0, cbResponse)


    ' Unicode-encode the received byte array and trim all the '\0' 
    ' characters at the end.
    message = Encoding.Unicode.GetString(bResponse).TrimEnd( _
        ControlChars.NullChar)
    Console.WriteLine(&quot;Receive {0} bytes from server: &quot;&quot;{1}&quot;&quot;&quot;, _
        cbRead, message)
Loop While Not pipeClient.IsMessageComplete

</pre>
<pre id="codePreview" class="vb">Dim message As String = RequestMessage
Dim bRequest As Byte() = Encoding.Unicode.GetBytes(message)
Dim cbRequest As Integer = bRequest.Length


pipeClient.Write(bRequest, 0, cbRequest)


Console.WriteLine(&quot;Send {0} bytes to server: &quot;&quot;{1}&quot;&quot;&quot;, _
    cbRequest, message.TrimEnd(ControlChars.NullChar))


'
' Receive a response from server.
'


Do
    Dim bResponse(BufferSize - 1) As Byte
    Dim cbResponse As Integer = bResponse.Length, cbRead As Integer


    cbRead = pipeClient.Read(bResponse, 0, cbResponse)


    ' Unicode-encode the received byte array and trim all the '\0' 
    ' characters at the end.
    message = Encoding.Unicode.GetString(bResponse).TrimEnd( _
        ControlChars.NullChar)
    Console.WriteLine(&quot;Receive {0} bytes from server: &quot;&quot;{1}&quot;&quot;&quot;, _
        cbRead, message)
Loop While Not pipeClient.IsMessageComplete

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt; text-indent:5.0pt">
<span><span><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>v.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Close the client end of the pipe by calling <span class="SpellE">
<span class="GramE">NamedPipeClientStream.Close</span></span><span class="GramE">(</span>).
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">pipeClient.Close()

</pre>
<pre id="codePreview" class="vb">pipeClient.Close()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt; text-indent:5.0pt">
<span><span>b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Named pipe client by P/Invoke the native APIs related to named pipe operations. (<span class="SpellE">NativeNamedPipeClient.Run</span>())
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt; text-indent:5.0pt">
<span><span><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>i.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Try to connect to a named pipe by P/Invoking <span class="SpellE">
CreateFile</span> and specifying the target pipe server, name, desired access, etc.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">hNamedPipe = NativeMethod.CreateFile(FullPipeName, _
    FileDesiredAccess.GENERIC_READ Or _
    FileDesiredAccess.GENERIC_WRITE, _
    FileShareMode.Zero, Nothing, _
    FileCreationDisposition.OPEN_EXISTING, _
    0, IntPtr.Zero)

</pre>
<pre id="codePreview" class="vb">hNamedPipe = NativeMethod.CreateFile(FullPipeName, _
    FileDesiredAccess.GENERIC_READ Or _
    FileDesiredAccess.GENERIC_WRITE, _
    FileShareMode.Zero, Nothing, _
    FileCreationDisposition.OPEN_EXISTING, _
    0, IntPtr.Zero)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt"><span>If all pipe instances are busy, wait for 5 seconds and connect again.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">If (Marshal.GetLastWin32Error() &lt;&gt; ERROR_PIPE_BUSY) Then
    Throw New Win32Exception
End If

</pre>
<pre id="codePreview" class="vb">If (Marshal.GetLastWin32Error() &lt;&gt; ERROR_PIPE_BUSY) Then
    Throw New Win32Exception
End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt">&nbsp;</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt">&nbsp;</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt; text-indent:5.0pt">
<span><span><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>ii.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Set the read mode and the blocking mode of the named pipe. In this sample, we set data to be read from the pipe as a stream of messages.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Dim mode As PipeMode = PipeMode.PIPE_READMODE_MESSAGE
If (Not NativeMethod.SetNamedPipeHandleState(hNamedPipe, mode, _
    IntPtr.Zero, IntPtr.Zero)) Then
    Throw New Win32Exception
End If

</pre>
<pre id="codePreview" class="vb">Dim mode As PipeMode = PipeMode.PIPE_READMODE_MESSAGE
If (Not NativeMethod.SetNamedPipeHandleState(hNamedPipe, mode, _
    IntPtr.Zero, IntPtr.Zero)) Then
    Throw New Win32Exception
End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt">&nbsp;</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt">&nbsp;</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt; text-indent:5.0pt">
<span><span><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>iii.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Send a message to the pipe server and receive its response by calling the
<span class="SpellE">WriteFile</span> and <span class="SpellE">ReadFile</span> functions.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Dim message As String = RequestMessage
Dim bRequest As Byte() = Encoding.Unicode.GetBytes(message)
Dim cbRequest As Integer = bRequest.Length, cbWritten As Integer


If (Not NativeMethod.WriteFile(hNamedPipe, bRequest, cbRequest, _
    cbWritten, IntPtr.Zero)) Then
    Throw New Win32Exception
End If


Console.WriteLine(&quot;Send {0} bytes to server: &quot;&quot;{1}&quot;&quot;&quot;, _
    cbWritten, message.TrimEnd(ControlChars.NullChar))


'
' Receive a response from server.
'


Dim finishRead As Boolean = False
Do
    Dim bResponse(BufferSize - 1) As Byte
    Dim cbResponse As Integer = bResponse.Length, cbRead As Integer


    finishRead = NativeMethod.ReadFile(hNamedPipe, bResponse, _
        cbResponse, cbRead, IntPtr.Zero)


    If (Not finishRead _
        AndAlso Marshal.GetLastWin32Error() &lt;&gt; ERROR_MORE_DATA) Then
        Throw New Win32Exception
    End If


    ' Unicode-encode the received byte array and trim all the '\0' 
    ' characters at the end.
    message = Encoding.Unicode.GetString(bResponse).TrimEnd( _
        ControlChars.NullChar)
    Console.WriteLine(&quot;Receive {0} bytes from server: &quot;&quot;{1}&quot;&quot;&quot;, _
        cbRead, message)


Loop While Not finishRead   ' Repeat loop if ERROR_MORE_DATA

</pre>
<pre id="codePreview" class="vb">Dim message As String = RequestMessage
Dim bRequest As Byte() = Encoding.Unicode.GetBytes(message)
Dim cbRequest As Integer = bRequest.Length, cbWritten As Integer


If (Not NativeMethod.WriteFile(hNamedPipe, bRequest, cbRequest, _
    cbWritten, IntPtr.Zero)) Then
    Throw New Win32Exception
End If


Console.WriteLine(&quot;Send {0} bytes to server: &quot;&quot;{1}&quot;&quot;&quot;, _
    cbWritten, message.TrimEnd(ControlChars.NullChar))


'
' Receive a response from server.
'


Dim finishRead As Boolean = False
Do
    Dim bResponse(BufferSize - 1) As Byte
    Dim cbResponse As Integer = bResponse.Length, cbRead As Integer


    finishRead = NativeMethod.ReadFile(hNamedPipe, bResponse, _
        cbResponse, cbRead, IntPtr.Zero)


    If (Not finishRead _
        AndAlso Marshal.GetLastWin32Error() &lt;&gt; ERROR_MORE_DATA) Then
        Throw New Win32Exception
    End If


    ' Unicode-encode the received byte array and trim all the '\0' 
    ' characters at the end.
    message = Encoding.Unicode.GetString(bResponse).TrimEnd( _
        ControlChars.NullChar)
    Console.WriteLine(&quot;Receive {0} bytes from server: &quot;&quot;{1}&quot;&quot;&quot;, _
        cbRead, message)


Loop While Not finishRead   ' Repeat loop if ERROR_MORE_DATA

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt">&nbsp;</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt">&nbsp;</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt; text-indent:5.0pt">
<span><span><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>iv.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Close the pipe. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">hNamedPipe.Close()

</pre>
<pre id="codePreview" class="vb">hNamedPipe.Close()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:108.0pt">&nbsp;</p>
<h2>More Information<span> </span></h2>
<p class="MsoNormal"><span><a href="http://msdn.microsoft.com/en-us/library/system.io.pipes.aspx">MSDN:
<span class="SpellE">System.IO.Pipes</span> Namespace</a> </span></p>
<p class="MsoNormal"><span><a href="http://msdn.microsoft.com/en-us/library/system.io.pipes.namedpipeclientstream.aspx">MSDN:
<span class="SpellE">NamedPipeClientStream</span></a> </span></p>
<p class="MsoNormal"><span><a href="http://msdn.microsoft.com/en-us/library/bb546085.aspx">How to: Use Named Pipes to Communicate Between Processes over a Network</a>
</span></p>
<p class="MsoNormal"><span><a href="http://blogs.msdn.com/bclteam/archive/2006/12/07/introducing-pipes-justin-van-patten.aspx">Introducing Pipes [Justin Van Patten]</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
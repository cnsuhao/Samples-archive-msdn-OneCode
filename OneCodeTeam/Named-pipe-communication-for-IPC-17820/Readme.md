# Named-pipe communication for IPC (CSNamedPipeCommunication)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows SDK
* IPC and RPC
## Topics
* Communication
* named-pipe
## IsPublished
* True
## ModifiedDate
* 2013-02-19 05:14:16
## Description

<h1>C#&nbsp; named-pipe <span>communication </span>for IPC (CSNamedPipeCommunication)</h1>
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
<p class="MsoNormal"><span>This code sample demonstrates two methods to use named pipe in Visual C#.
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
</span></span></span><span>CSNamedPipeServer.exe </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt; text-indent:5.0pt">
<span><span>b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>CSNamedPipeClient.exe </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Run CSNamedPipeServer.exe in a command prompt to start up the server end of the named pipe.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>If the command is &quot;CSNamedPipeServer.exe&quot;, the pipe server is created by the types in the
<span class="SpellE">System.IO.Pipes</span> namespace. If the command is &quot;CSNamedPipeServer.exe -native&quot;, the pipe server is created by P/Invoking the native APIs related to named pipe operations. In both cases, the application outputs the following information
 in the command prompt if the pipe is created successfully. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/61890/1/image.png" alt="" width="571" height="68" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Run CSNamedPipeClient.exe in another command prompt to start up the client end of the named pipe. If the command is &quot;CSNamedPipeClient.exe&quot;, the client connects to the pipe by using the types in the
<span class="SpellE"><strong>System.IO.Pipes</strong></span> namespace. If the command is &quot;CSNamedPipeClient.exe -native&quot;, the client connects to the pipe by P/Invoking the native APIs related to named pipe operations. In both cases, the
<strong>client application</strong> should output the message below in the command prompt when the client successfully connects to the named pipe.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/61891/1/image.png" alt="" width="573" height="21" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>In the meantime, the <strong>server application</strong> outputs this message to indicate that the pipe is connected by a client.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/61892/1/image.png" alt="" width="569" height="48" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span><span>4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>The <strong>client application</strong> attempts to write a message to the named pipe. You will see the message below in the command prompt running the
<strong>client application</strong>. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/61893/1/image.png" alt="" width="571" height="34" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>When the <a name="OLE_LINK2"></a><a name="OLE_LINK1"><span><strong>server application</strong>
</span></a>reads the message from the client, it prints:<span> </span></span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/61894/1/image.png" alt="" width="566" height="68" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>Next, the <strong>server application</strong> writes a response to the pipe.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/61895/1/image.png" alt="" width="569" height="89" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>And the <strong>client application</strong> receives the response:
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/61896/1/image.png" alt="" width="569" height="62" align="middle">
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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// Create the named pipe.
pipeServer = new NamedPipeServerStream(
    Program.PIPE_NAME,              // The unique pipe name.
    PipeDirection.InOut,            // The pipe is duplex
    NamedPipeServerStream.MaxAllowedServerInstances,
    PipeTransmissionMode.Message,   // Message-based communication
    PipeOptions.None,               // No additional parameters
    Program.BUFFER_SIZE,            // Input buffer size
    Program.BUFFER_SIZE,            // Output buffer size
    pipeSecurity,                   // Pipe security attributes
    HandleInheritability.None       // Not inheritable
    );

</pre>
<pre id="codePreview" class="csharp">// Create the named pipe.
pipeServer = new NamedPipeServerStream(
    Program.PIPE_NAME,              // The unique pipe name.
    PipeDirection.InOut,            // The pipe is duplex
    NamedPipeServerStream.MaxAllowedServerInstances,
    PipeTransmissionMode.Message,   // Message-based communication
    PipeOptions.None,               // No additional parameters
    Program.BUFFER_SIZE,            // Input buffer size
    Program.BUFFER_SIZE,            // Output buffer size
    pipeSecurity,                   // Pipe security attributes
    HandleInheritability.None       // Not inheritable
    );

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">PipeSecurity pipeSecurity = new PipeSecurity();


// Allow Everyone read and write access to the pipe.
pipeSecurity.SetAccessRule(new PipeAccessRule(&quot;Authenticated Users&quot;,
    PipeAccessRights.ReadWrite, AccessControlType.Allow));


// Allow the Administrators group full access to the pipe.
pipeSecurity.SetAccessRule(new PipeAccessRule(&quot;Administrators&quot;,
    PipeAccessRights.FullControl, AccessControlType.Allow));

</pre>
<pre id="codePreview" class="csharp">PipeSecurity pipeSecurity = new PipeSecurity();


// Allow Everyone read and write access to the pipe.
pipeSecurity.SetAccessRule(new PipeAccessRule(&quot;Authenticated Users&quot;,
    PipeAccessRights.ReadWrite, AccessControlType.Allow));


// Allow the Administrators group full access to the pipe.
pipeSecurity.SetAccessRule(new PipeAccessRule(&quot;Administrators&quot;,
    PipeAccessRights.FullControl, AccessControlType.Allow));

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">pipeServer.WaitForConnection();

</pre>
<pre id="codePreview" class="csharp">pipeServer.WaitForConnection();

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// 
// Receive a request from client.
// 
string message;
do
{
    byte[] bRequest = new byte[Program.BUFFER_SIZE];
    int cbRequest = bRequest.Length, cbRead;


    cbRead = pipeServer.Read(bRequest, 0, cbRequest);


    // Unicode-encode the received byte array and trim all the 
    // '\0' characters at the end.
    message = Encoding.Unicode.GetString(bRequest).TrimEnd('\0');
    Console.WriteLine(&quot;Receive {0} bytes from client: \&quot;{1}\&quot;&quot;,
        cbRead, message);
}
while (!pipeServer.IsMessageComplete);


// 
// Send a response from server to client.
// 


message = Program.RESPONSE_MESSAGE;
byte[] bResponse = Encoding.Unicode.GetBytes(message);
int cbResponse = bResponse.Length;


pipeServer.Write(bResponse, 0, cbResponse);


Console.WriteLine(&quot;Send {0} bytes to client: \&quot;{1}\&quot;&quot;,
    cbResponse, message.TrimEnd('\0'));

</pre>
<pre id="codePreview" class="csharp">// 
// Receive a request from client.
// 
string message;
do
{
    byte[] bRequest = new byte[Program.BUFFER_SIZE];
    int cbRequest = bRequest.Length, cbRead;


    cbRead = pipeServer.Read(bRequest, 0, cbRequest);


    // Unicode-encode the received byte array and trim all the 
    // '\0' characters at the end.
    message = Encoding.Unicode.GetString(bRequest).TrimEnd('\0');
    Console.WriteLine(&quot;Receive {0} bytes from client: \&quot;{1}\&quot;&quot;,
        cbRead, message);
}
while (!pipeServer.IsMessageComplete);


// 
// Send a response from server to client.
// 


message = Program.RESPONSE_MESSAGE;
byte[] bResponse = Encoding.Unicode.GetBytes(message);
int cbResponse = bResponse.Length;


pipeServer.Write(bResponse, 0, cbResponse);


Console.WriteLine(&quot;Send {0} bytes to client: \&quot;{1}\&quot;&quot;,
    cbResponse, message.TrimEnd('\0'));

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">pipeServer.WaitForPipeDrain();
pipeServer.Disconnect();

</pre>
<pre id="codePreview" class="csharp">pipeServer.WaitForPipeDrain();
pipeServer.Disconnect();

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">pipeServer.Close();

</pre>
<pre id="codePreview" class="csharp">pipeServer.Close();

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// Create the named pipe.
hNamedPipe = NativeMethod.CreateNamedPipe(
    Program.FULL_PIPE_NAME,             // The unique pipe name.
    PipeOpenMode.PIPE_ACCESS_DUPLEX,    // The pipe is duplex
    PipeMode.PIPE_TYPE_MESSAGE |        // Message type pipe 
    PipeMode.PIPE_READMODE_MESSAGE |    // Message-read mode 
    PipeMode.PIPE_WAIT,                 // Blocking mode is on
    PIPE_UNLIMITED_INSTANCES,           // Max server instances
    Program.BUFFER_SIZE,                // Output buffer size
    Program.BUFFER_SIZE,                // Input buffer size
    NMPWAIT_USE_DEFAULT_WAIT,           // Time-out interval
    sa                                  // Pipe security attributes
    );

</pre>
<pre id="codePreview" class="csharp">// Create the named pipe.
hNamedPipe = NativeMethod.CreateNamedPipe(
    Program.FULL_PIPE_NAME,             // The unique pipe name.
    PipeOpenMode.PIPE_ACCESS_DUPLEX,    // The pipe is duplex
    PipeMode.PIPE_TYPE_MESSAGE |        // Message type pipe 
    PipeMode.PIPE_READMODE_MESSAGE |    // Message-read mode 
    PipeMode.PIPE_WAIT,                 // Blocking mode is on
    PIPE_UNLIMITED_INSTANCES,           // Max server instances
    Program.BUFFER_SIZE,                // Output buffer size
    Program.BUFFER_SIZE,                // Input buffer size
    NMPWAIT_USE_DEFAULT_WAIT,           // Time-out interval
    sa                                  // Pipe security attributes
    );

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// Define the SDDL for the security descriptor.
string sddl = &quot;D:&quot; &#43;        // Discretionary ACL
    &quot;(A;OICI;GRGW;;;AU)&quot; &#43;  // Allow read/write to authenticated users
    &quot;(A;OICI;GA;;;BA)&quot;;     // Allow full control to administrators


SafeLocalMemHandle pSecurityDescriptor = null;
if (!NativeMethod.ConvertStringSecurityDescriptorToSecurityDescriptor(
    sddl, 1, out pSecurityDescriptor, IntPtr.Zero))
{
    throw new Win32Exception();
}


SECURITY_ATTRIBUTES sa = new SECURITY_ATTRIBUTES();
sa.nLength = Marshal.SizeOf(sa);
sa.lpSecurityDescriptor = pSecurityDescriptor;
sa.bInheritHandle = false;

</pre>
<pre id="codePreview" class="csharp">// Define the SDDL for the security descriptor.
string sddl = &quot;D:&quot; &#43;        // Discretionary ACL
    &quot;(A;OICI;GRGW;;;AU)&quot; &#43;  // Allow read/write to authenticated users
    &quot;(A;OICI;GA;;;BA)&quot;;     // Allow full control to administrators


SafeLocalMemHandle pSecurityDescriptor = null;
if (!NativeMethod.ConvertStringSecurityDescriptorToSecurityDescriptor(
    sddl, 1, out pSecurityDescriptor, IntPtr.Zero))
{
    throw new Win32Exception();
}


SECURITY_ATTRIBUTES sa = new SECURITY_ATTRIBUTES();
sa.nLength = Marshal.SizeOf(sa);
sa.lpSecurityDescriptor = pSecurityDescriptor;
sa.bInheritHandle = false;

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">if (!NativeMethod.ConnectNamedPipe(hNamedPipe, IntPtr.Zero))
{
    if (Marshal.GetLastWin32Error() != ERROR_PIPE_CONNECTED)
    {
        throw new Win32Exception();
    }
}

</pre>
<pre id="codePreview" class="csharp">if (!NativeMethod.ConnectNamedPipe(hNamedPipe, IntPtr.Zero))
{
    if (Marshal.GetLastWin32Error() != ERROR_PIPE_CONNECTED)
    {
        throw new Win32Exception();
    }
}

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// 
// Receive a request from client.
// 


string message;
bool finishRead = false;
do
{
    byte[] bRequest = new byte[Program.BUFFER_SIZE];
    int cbRequest = bRequest.Length, cbRead;


    finishRead = NativeMethod.ReadFile(
        hNamedPipe,             // Handle of the pipe
        bRequest,               // Buffer to receive data
        cbRequest,              // Size of buffer in bytes
        out cbRead,             // Number of bytes read 
        IntPtr.Zero             // Not overlapped 
        );


    if (!finishRead &amp;&amp;
        Marshal.GetLastWin32Error() != ERROR_MORE_DATA)
    {
        throw new Win32Exception();
    }


    // Unicode-encode the received byte array and trim all the 
    // '\0' characters at the end.
    message = Encoding.Unicode.GetString(bRequest).TrimEnd('\0');
    Console.WriteLine(&quot;Receive {0} bytes from client: \&quot;{1}\&quot;&quot;,
        cbRead, message);
}
while (!finishRead);  // Repeat loop if ERROR_MORE_DATA


// 
// Send a response from server to client.
// 


message = Program.RESPONSE_MESSAGE;
byte[] bResponse = Encoding.Unicode.GetBytes(message);
int cbResponse = bResponse.Length, cbWritten;


if (!NativeMethod.WriteFile(
    hNamedPipe,                 // Handle of the pipe
    bResponse,                  // Message to be written
    cbResponse,                 // Number of bytes to write
    out cbWritten,              // Number of bytes written
    IntPtr.Zero                 // Not overlapped
    ))
{
    throw new Win32Exception();
}


Console.WriteLine(&quot;Send {0} bytes to client: \&quot;{1}\&quot;&quot;,
    cbWritten, message.TrimEnd('\0'));

</pre>
<pre id="codePreview" class="csharp">// 
// Receive a request from client.
// 


string message;
bool finishRead = false;
do
{
    byte[] bRequest = new byte[Program.BUFFER_SIZE];
    int cbRequest = bRequest.Length, cbRead;


    finishRead = NativeMethod.ReadFile(
        hNamedPipe,             // Handle of the pipe
        bRequest,               // Buffer to receive data
        cbRequest,              // Size of buffer in bytes
        out cbRead,             // Number of bytes read 
        IntPtr.Zero             // Not overlapped 
        );


    if (!finishRead &amp;&amp;
        Marshal.GetLastWin32Error() != ERROR_MORE_DATA)
    {
        throw new Win32Exception();
    }


    // Unicode-encode the received byte array and trim all the 
    // '\0' characters at the end.
    message = Encoding.Unicode.GetString(bRequest).TrimEnd('\0');
    Console.WriteLine(&quot;Receive {0} bytes from client: \&quot;{1}\&quot;&quot;,
        cbRead, message);
}
while (!finishRead);  // Repeat loop if ERROR_MORE_DATA


// 
// Send a response from server to client.
// 


message = Program.RESPONSE_MESSAGE;
byte[] bResponse = Encoding.Unicode.GetBytes(message);
int cbResponse = bResponse.Length, cbWritten;


if (!NativeMethod.WriteFile(
    hNamedPipe,                 // Handle of the pipe
    bResponse,                  // Message to be written
    cbResponse,                 // Number of bytes to write
    out cbWritten,              // Number of bytes written
    IntPtr.Zero                 // Not overlapped
    ))
{
    throw new Win32Exception();
}


Console.WriteLine(&quot;Send {0} bytes to client: \&quot;{1}\&quot;&quot;,
    cbWritten, message.TrimEnd('\0'));

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">NativeMethod.FlushFileBuffers(hNamedPipe);
NativeMethod.DisconnectNamedPipe(hNamedPipe);

</pre>
<pre id="codePreview" class="csharp">NativeMethod.FlushFileBuffers(hNamedPipe);
NativeMethod.DisconnectNamedPipe(hNamedPipe);

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">hNamedPipe.Close();

</pre>
<pre id="codePreview" class="csharp">hNamedPipe.Close();

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">pipeClient = new NamedPipeClientStream(
    Program.SERVER_NAME,        // The server name
    Program.PIPE_NAME,          // The unique pipe name
    PipeDirection.InOut,        // The pipe is duplex
    PipeOptions.None            // No additional parameters
    );

</pre>
<pre id="codePreview" class="csharp">pipeClient = new NamedPipeClientStream(
    Program.SERVER_NAME,        // The server name
    Program.PIPE_NAME,          // The unique pipe name
    PipeDirection.InOut,        // The pipe is duplex
    PipeOptions.None            // No additional parameters
    );

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">pipeClient.Connect(5000);

</pre>
<pre id="codePreview" class="csharp">pipeClient.Connect(5000);

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">pipeClient.ReadMode = PipeTransmissionMode.Message;

</pre>
<pre id="codePreview" class="csharp">pipeClient.ReadMode = PipeTransmissionMode.Message;

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// 
// Send a request from client to server
// 


string message = Program.REQUEST_MESSAGE;
byte[] bRequest = Encoding.Unicode.GetBytes(message);
int cbRequest = bRequest.Length;


pipeClient.Write(bRequest, 0, cbRequest);


Console.WriteLine(&quot;Send {0} bytes to server: \&quot;{1}\&quot;&quot;,
    cbRequest, message.TrimEnd('\0'));


//
// Receive a response from server.
// 


do
{
    byte[] bResponse = new byte[Program.BUFFER_SIZE];
    int cbResponse = bResponse.Length, cbRead;


    cbRead = pipeClient.Read(bResponse, 0, cbResponse);


    // Unicode-encode the received byte array and trim all the 
    // '\0' characters at the end.
    message = Encoding.Unicode.GetString(bResponse).TrimEnd('\0');
    Console.WriteLine(&quot;Receive {0} bytes from server: \&quot;{1}\&quot;&quot;,
        cbRead, message);
}
while (!pipeClient.IsMessageComplete);

</pre>
<pre id="codePreview" class="csharp">// 
// Send a request from client to server
// 


string message = Program.REQUEST_MESSAGE;
byte[] bRequest = Encoding.Unicode.GetBytes(message);
int cbRequest = bRequest.Length;


pipeClient.Write(bRequest, 0, cbRequest);


Console.WriteLine(&quot;Send {0} bytes to server: \&quot;{1}\&quot;&quot;,
    cbRequest, message.TrimEnd('\0'));


//
// Receive a response from server.
// 


do
{
    byte[] bResponse = new byte[Program.BUFFER_SIZE];
    int cbResponse = bResponse.Length, cbRead;


    cbRead = pipeClient.Read(bResponse, 0, cbResponse);


    // Unicode-encode the received byte array and trim all the 
    // '\0' characters at the end.
    message = Encoding.Unicode.GetString(bResponse).TrimEnd('\0');
    Console.WriteLine(&quot;Receive {0} bytes from server: \&quot;{1}\&quot;&quot;,
        cbRead, message);
}
while (!pipeClient.IsMessageComplete);

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">pipeClient.Close();

</pre>
<pre id="codePreview" class="csharp">pipeClient.Close();

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">hNamedPipe = NativeMethod.CreateFile(
    Program.FULL_PIPE_NAME,                 // Pipe name
    FileDesiredAccess.GENERIC_READ |        // Read access
    FileDesiredAccess.GENERIC_WRITE,        // Write access
    FileShareMode.Zero,                     // No sharing 
    null,                                   // Default security attributes
    FileCreationDisposition.OPEN_EXISTING,  // Opens existing pipe
    0,                                      // Default attributes
    IntPtr.Zero                             // No template file
    );

</pre>
<pre id="codePreview" class="csharp">hNamedPipe = NativeMethod.CreateFile(
    Program.FULL_PIPE_NAME,                 // Pipe name
    FileDesiredAccess.GENERIC_READ |        // Read access
    FileDesiredAccess.GENERIC_WRITE,        // Write access
    FileShareMode.Zero,                     // No sharing 
    null,                                   // Default security attributes
    FileCreationDisposition.OPEN_EXISTING,  // Opens existing pipe
    0,                                      // Default attributes
    IntPtr.Zero                             // No template file
    );

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt"><span>If all pipe instances are busy, wait for 5 seconds and connect again.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">if (!NativeMethod.WaitNamedPipe(Program.FULL_PIPE_NAME, 5000))
{
    throw new Win32Exception();
}

</pre>
<pre id="codePreview" class="csharp">if (!NativeMethod.WaitNamedPipe(Program.FULL_PIPE_NAME, 5000))
{
    throw new Win32Exception();
}

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">PipeMode mode = PipeMode.PIPE_READMODE_MESSAGE;
if (!NativeMethod.SetNamedPipeHandleState(hNamedPipe, ref mode,
    IntPtr.Zero, IntPtr.Zero))
{
    throw new Win32Exception();
}

</pre>
<pre id="codePreview" class="csharp">PipeMode mode = PipeMode.PIPE_READMODE_MESSAGE;
if (!NativeMethod.SetNamedPipeHandleState(hNamedPipe, ref mode,
    IntPtr.Zero, IntPtr.Zero))
{
    throw new Win32Exception();
}

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// 
// Send a request from client to server
// 


string message = Program.REQUEST_MESSAGE;
byte[] bRequest = Encoding.Unicode.GetBytes(message);
int cbRequest = bRequest.Length, cbWritten;


if (!NativeMethod.WriteFile(
    hNamedPipe,     // Handle of the pipe
    bRequest,       // Message to be written
    cbRequest,      // Number of bytes to write
    out cbWritten,  // Number of bytes written
    IntPtr.Zero     // Not overlapped
    ))
{
    throw new Win32Exception();
}


Console.WriteLine(&quot;Send {0} bytes to server: \&quot;{1}\&quot;&quot;, 
    cbWritten, message.TrimEnd('\0'));


//
// Receive a response from server.
// 


bool finishRead = false;
do
{
    byte[] bResponse = new byte[Program.BUFFER_SIZE];
    int cbResponse = bResponse.Length, cbRead;


    finishRead = NativeMethod.ReadFile(
        hNamedPipe,             // Handle of the pipe
        bResponse,              // Buffer to receive data
        cbResponse,             // Size of buffer in bytes
        out cbRead,             // Number of bytes read 
        IntPtr.Zero             // Not overlapped 
        );


    if (!finishRead &amp;&amp; 
        Marshal.GetLastWin32Error() != ERROR_MORE_DATA)
    {
        throw new Win32Exception();
    }


    // Unicode-encode the received byte array and trim all the 
    // '\0' characters at the end.
    message = Encoding.Unicode.GetString(bResponse).TrimEnd('\0');
    Console.WriteLine(&quot;Receive {0} bytes from server: \&quot;{1}\&quot;&quot;,
        cbRead, message);
}
while (!finishRead);  // Repeat loop if ERROR_MORE_DATA

</pre>
<pre id="codePreview" class="csharp">// 
// Send a request from client to server
// 


string message = Program.REQUEST_MESSAGE;
byte[] bRequest = Encoding.Unicode.GetBytes(message);
int cbRequest = bRequest.Length, cbWritten;


if (!NativeMethod.WriteFile(
    hNamedPipe,     // Handle of the pipe
    bRequest,       // Message to be written
    cbRequest,      // Number of bytes to write
    out cbWritten,  // Number of bytes written
    IntPtr.Zero     // Not overlapped
    ))
{
    throw new Win32Exception();
}


Console.WriteLine(&quot;Send {0} bytes to server: \&quot;{1}\&quot;&quot;, 
    cbWritten, message.TrimEnd('\0'));


//
// Receive a response from server.
// 


bool finishRead = false;
do
{
    byte[] bResponse = new byte[Program.BUFFER_SIZE];
    int cbResponse = bResponse.Length, cbRead;


    finishRead = NativeMethod.ReadFile(
        hNamedPipe,             // Handle of the pipe
        bResponse,              // Buffer to receive data
        cbResponse,             // Size of buffer in bytes
        out cbRead,             // Number of bytes read 
        IntPtr.Zero             // Not overlapped 
        );


    if (!finishRead &amp;&amp; 
        Marshal.GetLastWin32Error() != ERROR_MORE_DATA)
    {
        throw new Win32Exception();
    }


    // Unicode-encode the received byte array and trim all the 
    // '\0' characters at the end.
    message = Encoding.Unicode.GetString(bResponse).TrimEnd('\0');
    Console.WriteLine(&quot;Receive {0} bytes from server: \&quot;{1}\&quot;&quot;,
        cbRead, message);
}
while (!finishRead);  // Repeat loop if ERROR_MORE_DATA

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">hNamedPipe.Close();

</pre>
<pre id="codePreview" class="csharp">hNamedPipe.Close();

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

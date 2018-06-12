# Named-pipe communication for IPC (CppNamedPipeCommunication)
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
* 2013-02-19 05:16:24
## Description

<h1>C<span>&#43;&#43;</span><span class="GramE">&nbsp; named</span>-pipe <span>communication
</span>for IPC (<span class="SpellE">C<span>pp</span>NamedPipeCommunication</span>)</h1>
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
<p class="MsoNormal"><span>This code sample demonstrates calling CreateNamedPipe to create a pipe named &quot;\\.\pipe\SamplePipe&quot;, which supports duplex connections so that both client and server can read from and write to the pipe. The security attributes of
 the pipe are customized to allow Authenticated Users read and write access to a pipe, and to allow the dministrators group full access to the pipe. When the pipe is connected by a client, the server attempts to read the client's message from the pipe by calling
 ReadFile, and write a response by calling WriteFile.</span><span> </span></p>
<h2>Running the Sample<span> </span></h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Build the solution, and you will get 2 application: </span>
</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt; text-indent:5.0pt">
<span><span>a.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>CppNamedPipeServer.exe </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt; text-indent:5.0pt">
<span><span>b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>CppNamedPipeClient.exe </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Run CppNamedPipeServer.exe in a command prompt to start up the server end of the named pipe, the application outputs the following information in the command prompt if the pipe is created successfully.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/61860/1/image.png" alt="" width="571" height="68" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Run CppNamedPipeClient.exe in another command prompt to start up the client end of the named pipe, the
<strong>client application</strong> should output the message below in the command prompt when the client successfully connects to the named pipe.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/61861/1/image.png" alt="" width="573" height="21" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>In the meantime, the <strong>server application</strong> outputs this message to indicate that the pipe is connected by a client.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/61862/1/image.png" alt="" width="569" height="48" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span><span>4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>The <strong>client application</strong> attempts to write a message to the named pipe. You will see the message below in the command prompt running the
<strong>client application</strong>. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/61863/1/image.png" alt="" width="571" height="34" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>When the <a name="OLE_LINK1"></a><a name="OLE_LINK2"><span><strong>server application</strong>
</span></a>reads the message from the client, it prints:<span> </span></span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/61864/1/image.png" alt="" width="566" height="68" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>Next, the <strong>server application</strong> writes a response to the pipe.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/61865/1/image.png" alt="" width="569" height="89" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>And the <strong>client application</strong> receives the response:
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/61866/1/image.png" alt="" width="569" height="62" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast"><span>The connection is disconnected and the pipe is closed after that.
</span></p>
<h2>Using the Code<span> </span></h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE"><strong><span>NamedPipeServer</span></strong></span><span>.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt; text-indent:5.0pt">
<span><span>a.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Create a named pipe server by calling <span class="SpellE">
<strong>CreateNamedPipe</strong></span> and specifying the pipe name, pipe direction, transmission mode, security attributes, etc.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">// Create the named pipe.
hNamedPipe = CreateNamedPipe(
    FULL_PIPE_NAME,             // Pipe name.
    PIPE_ACCESS_DUPLEX,         // The pipe is duplex; both server and 
                                // client processes can read from and 
                                // write to the pipe
    PIPE_TYPE_MESSAGE |         // Message type pipe 
    PIPE_READMODE_MESSAGE |     // Message-read mode 
    PIPE_WAIT,                  // Blocking mode is enabled
    PIPE_UNLIMITED_INSTANCES,   // Max. instances
    BUFFER_SIZE,                // Output buffer size in bytes
    BUFFER_SIZE,                // Input buffer size in bytes
    NMPWAIT_USE_DEFAULT_WAIT,   // Time-out interval
    pSa                         // Security attributes
    );

</pre>
<pre id="codePreview" class="cplusplus">// Create the named pipe.
hNamedPipe = CreateNamedPipe(
    FULL_PIPE_NAME,             // Pipe name.
    PIPE_ACCESS_DUPLEX,         // The pipe is duplex; both server and 
                                // client processes can read from and 
                                // write to the pipe
    PIPE_TYPE_MESSAGE |         // Message type pipe 
    PIPE_READMODE_MESSAGE |     // Message-read mode 
    PIPE_WAIT,                  // Blocking mode is enabled
    PIPE_UNLIMITED_INSTANCES,   // Max. instances
    BUFFER_SIZE,                // Output buffer size in bytes
    BUFFER_SIZE,                // Input buffer size in bytes
    NMPWAIT_USE_DEFAULT_WAIT,   // Time-out interval
    pSa                         // Security attributes
    );

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span>In this code sample, the pipe server support message-based duplex communications. The security attributes of the pipe are customized to allow Authenticated Users read and write access to
 a pipe, and to allow the Administrators group full access to the pipe. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">//
//   FUNCTION: CreatePipeSecurity(PSECURITY_ATTRIBUTES *)
//
//   PURPOSE: The CreatePipeSecurity function creates and initializes a new 
//   SECURITY_ATTRIBUTES structure to allow Authenticated Users read and 
//   write access to a pipe, and to allow the Administrators group full 
//   access to the pipe.
//
//   PARAMETERS:
//   * ppSa - output a pointer to a SECURITY_ATTRIBUTES structure that allows 
//     Authenticated Users read and write access to a pipe, and allows the 
//     Administrators group full access to the pipe. The structure must be 
//     freed by calling FreePipeSecurity.
//
//   RETURN VALUE: Returns TRUE if the function succeeds..
//
//   EXAMPLE CALL:
//
//     PSECURITY_ATTRIBUTES pSa = NULL;
//     if (CreatePipeSecurity(&amp;pSa))
//     {
//         // Use the security attributes
//         // ...
//
//         FreePipeSecurity(pSa);
//     }
//
BOOL CreatePipeSecurity(PSECURITY_ATTRIBUTES *ppSa)

</pre>
<pre id="codePreview" class="cplusplus">//
//   FUNCTION: CreatePipeSecurity(PSECURITY_ATTRIBUTES *)
//
//   PURPOSE: The CreatePipeSecurity function creates and initializes a new 
//   SECURITY_ATTRIBUTES structure to allow Authenticated Users read and 
//   write access to a pipe, and to allow the Administrators group full 
//   access to the pipe.
//
//   PARAMETERS:
//   * ppSa - output a pointer to a SECURITY_ATTRIBUTES structure that allows 
//     Authenticated Users read and write access to a pipe, and allows the 
//     Administrators group full access to the pipe. The structure must be 
//     freed by calling FreePipeSecurity.
//
//   RETURN VALUE: Returns TRUE if the function succeeds..
//
//   EXAMPLE CALL:
//
//     PSECURITY_ATTRIBUTES pSa = NULL;
//     if (CreatePipeSecurity(&amp;pSa))
//     {
//         // Use the security attributes
//         // ...
//
//         FreePipeSecurity(pSa);
//     }
//
BOOL CreatePipeSecurity(PSECURITY_ATTRIBUTES *ppSa)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt; text-indent:5.0pt">
<span><span>b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Wait for the client to connect by calling <span class="SpellE">
ConnectNamedPipe</span>. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">if (!ConnectNamedPipe(hNamedPipe, NULL))
{
    if (ERROR_PIPE_CONNECTED != GetLastError())
    {
        dwError = GetLastError();
        wprintf(L&quot;ConnectNamedPipe failed w/err 0x%08lx\n&quot;, dwError);
        goto Cleanup;
    }
}

</pre>
<pre id="codePreview" class="cplusplus">if (!ConnectNamedPipe(hNamedPipe, NULL))
{
    if (ERROR_PIPE_CONNECTED != GetLastError())
    {
        dwError = GetLastError();
        wprintf(L&quot;ConnectNamedPipe failed w/err 0x%08lx\n&quot;, dwError);
        goto Cleanup;
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt; text-indent:5.0pt">
<span><span>c.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Read the client's request from the pipe and write a response by calling
<span class="SpellE">ReadFile</span> and <span class="SpellE">WriteFile</span>.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">// 
// Receive a request from client.
// 


BOOL fFinishRead = FALSE;
do
{
    wchar_t chRequest[BUFFER_SIZE];
    DWORD cbRequest, cbRead;
    cbRequest = sizeof(chRequest);


    fFinishRead = ReadFile(
        hNamedPipe,     // Handle of the pipe
        chRequest,      // Buffer to receive data
        cbRequest,      // Size of buffer in bytes
        &amp;cbRead,        // Number of bytes read
        NULL            // Not overlapped I/O
        );


    if (!fFinishRead &amp;&amp; ERROR_MORE_DATA != GetLastError())
    {
        dwError = GetLastError();
        wprintf(L&quot;ReadFile from pipe failed w/err 0x%08lx\n&quot;, dwError);
        goto Cleanup;
    }


    wprintf(L&quot;Receive %ld bytes from client: \&quot;%s\&quot;\n&quot;, cbRead, chRequest);


} while (!fFinishRead); // Repeat loop if ERROR_MORE_DATA


// 
// Send a response from server to client.
// 


wchar_t chResponse[] = RESPONSE_MESSAGE;
DWORD cbResponse, cbWritten;
cbResponse = sizeof(chResponse);


if (!WriteFile(
    hNamedPipe,     // Handle of the pipe
    chResponse,     // Buffer to write
    cbResponse,     // Number of bytes to write 
    &amp;cbWritten,     // Number of bytes written 
    NULL            // Not overlapped I/O
    ))
{
    dwError = GetLastError();
    wprintf(L&quot;WriteFile to pipe failed w/err 0x%08lx\n&quot;, dwError);
    goto Cleanup;
}


wprintf(L&quot;Send %ld bytes to client: \&quot;%s\&quot;\n&quot;, cbWritten, chResponse);

</pre>
<pre id="codePreview" class="cplusplus">// 
// Receive a request from client.
// 


BOOL fFinishRead = FALSE;
do
{
    wchar_t chRequest[BUFFER_SIZE];
    DWORD cbRequest, cbRead;
    cbRequest = sizeof(chRequest);


    fFinishRead = ReadFile(
        hNamedPipe,     // Handle of the pipe
        chRequest,      // Buffer to receive data
        cbRequest,      // Size of buffer in bytes
        &amp;cbRead,        // Number of bytes read
        NULL            // Not overlapped I/O
        );


    if (!fFinishRead &amp;&amp; ERROR_MORE_DATA != GetLastError())
    {
        dwError = GetLastError();
        wprintf(L&quot;ReadFile from pipe failed w/err 0x%08lx\n&quot;, dwError);
        goto Cleanup;
    }


    wprintf(L&quot;Receive %ld bytes from client: \&quot;%s\&quot;\n&quot;, cbRead, chRequest);


} while (!fFinishRead); // Repeat loop if ERROR_MORE_DATA


// 
// Send a response from server to client.
// 


wchar_t chResponse[] = RESPONSE_MESSAGE;
DWORD cbResponse, cbWritten;
cbResponse = sizeof(chResponse);


if (!WriteFile(
    hNamedPipe,     // Handle of the pipe
    chResponse,     // Buffer to write
    cbResponse,     // Number of bytes to write 
    &amp;cbWritten,     // Number of bytes written 
    NULL            // Not overlapped I/O
    ))
{
    dwError = GetLastError();
    wprintf(L&quot;WriteFile to pipe failed w/err 0x%08lx\n&quot;, dwError);
    goto Cleanup;
}


wprintf(L&quot;Send %ld bytes to client: \&quot;%s\&quot;\n&quot;, cbWritten, chResponse);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt; text-indent:5.0pt">
<span><span>d.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Flush the pipe to allow the client to read the pipe's contents before disconnecting. Then disconnect the client's connection.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">FlushFileBuffers(hNamedPipe);
DisconnectNamedPipe(hNamedPipe);

</pre>
<pre id="codePreview" class="cplusplus">FlushFileBuffers(hNamedPipe);
DisconnectNamedPipe(hNamedPipe);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt; text-indent:5.0pt">
<span><span>e.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Close the server end of the pipe. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">CloseHandle(hNamedPipe);

</pre>
<pre id="codePreview" class="cplusplus">CloseHandle(hNamedPipe);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt">&nbsp;</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><strong><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></strong><span class="SpellE"><strong><span>NamedPipeClient</span></strong></span><strong><span>
</span></strong></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt; text-indent:5.0pt">
<span><span>a.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Try to connect to a named pipe by calling <span class="SpellE">
<strong>CreateFile</strong></span> and specifying the target pipe server, name, desired access, etc.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">// Try to open the named pipe identified by the pipe name.
while (TRUE) 
{
    hPipe = CreateFile( 
        FULL_PIPE_NAME,                 // Pipe name 
        GENERIC_READ | GENERIC_WRITE,   // Read and write access
        0,                              // No sharing 
        NULL,                           // Default security attributes
        OPEN_EXISTING,                  // Opens existing pipe
        0,                              // Default attributes
        NULL                            // No template file
        );


    // If the pipe handle is opened successfully ...
    if (hPipe != INVALID_HANDLE_VALUE)
    {
        wprintf(L&quot;The named pipe (%s) is connected.\n&quot;, FULL_PIPE_NAME);
        break;
    }


    dwError = GetLastError();


    // Exit if an error other than ERROR_PIPE_BUSY occurs.
    if (ERROR_PIPE_BUSY != dwError)
    {
        wprintf(L&quot;Unable to open named pipe w/err 0x%08lx\n&quot;, dwError);
        goto Cleanup;
    }


    // All pipe instances are busy, so wait for 5 seconds.
    if (!WaitNamedPipe(FULL_PIPE_NAME, 5000))
    {
        dwError = GetLastError();
        wprintf(L&quot;Could not open pipe: 5 second wait timed out.&quot;);
        goto Cleanup;
    }
}

</pre>
<pre id="codePreview" class="cplusplus">// Try to open the named pipe identified by the pipe name.
while (TRUE) 
{
    hPipe = CreateFile( 
        FULL_PIPE_NAME,                 // Pipe name 
        GENERIC_READ | GENERIC_WRITE,   // Read and write access
        0,                              // No sharing 
        NULL,                           // Default security attributes
        OPEN_EXISTING,                  // Opens existing pipe
        0,                              // Default attributes
        NULL                            // No template file
        );


    // If the pipe handle is opened successfully ...
    if (hPipe != INVALID_HANDLE_VALUE)
    {
        wprintf(L&quot;The named pipe (%s) is connected.\n&quot;, FULL_PIPE_NAME);
        break;
    }


    dwError = GetLastError();


    // Exit if an error other than ERROR_PIPE_BUSY occurs.
    if (ERROR_PIPE_BUSY != dwError)
    {
        wprintf(L&quot;Unable to open named pipe w/err 0x%08lx\n&quot;, dwError);
        goto Cleanup;
    }


    // All pipe instances are busy, so wait for 5 seconds.
    if (!WaitNamedPipe(FULL_PIPE_NAME, 5000))
    {
        dwError = GetLastError();
        wprintf(L&quot;Could not open pipe: 5 second wait timed out.&quot;);
        goto Cleanup;
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt">&nbsp;</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt">&nbsp;</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt; text-indent:5.0pt">
<span><span>b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Set the read mode and the blocking mode of the named pipe. In this sample, we set data to be read from the pipe as a stream of messages.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">DWORD dwMode = PIPE_READMODE_MESSAGE;
if (!SetNamedPipeHandleState(hPipe, &amp;dwMode, NULL, NULL))
{
    dwError = GetLastError();
    wprintf(L&quot;SetNamedPipeHandleState failed w/err 0x%08lx\n&quot;, dwError);
    goto Cleanup;
}

</pre>
<pre id="codePreview" class="cplusplus">DWORD dwMode = PIPE_READMODE_MESSAGE;
if (!SetNamedPipeHandleState(hPipe, &amp;dwMode, NULL, NULL))
{
    dwError = GetLastError();
    wprintf(L&quot;SetNamedPipeHandleState failed w/err 0x%08lx\n&quot;, dwError);
    goto Cleanup;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt">&nbsp;</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt">&nbsp;</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt; text-indent:5.0pt">
<span><span>c.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Send a message to the pipe server and receive its response by calling the
<span class="SpellE">WriteFile</span> and <span class="SpellE">ReadFile</span> functions.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">// 
// Send a request from client to server
// 


wchar_t chRequest[] = REQUEST_MESSAGE;
DWORD cbRequest, cbWritten;
cbRequest = sizeof(chRequest);


if (!WriteFile(
    hPipe,                      // Handle of the pipe
    chRequest,                  // Message to be written
    cbRequest,                  // Number of bytes to write
    &amp;cbWritten,                 // Number of bytes written
    NULL                        // Not overlapped
    ))
{
    dwError = GetLastError();
    wprintf(L&quot;WriteFile to pipe failed w/err 0x%08lx\n&quot;, dwError);
    goto Cleanup;
}


wprintf(L&quot;Send %ld bytes to server: \&quot;%s\&quot;\n&quot;, cbWritten, chRequest);


//
// Receive a response from server.
// 


BOOL fFinishRead = FALSE;
do
{
    wchar_t chResponse[BUFFER_SIZE];
    DWORD cbResponse, cbRead;
    cbResponse = sizeof(chResponse);


    fFinishRead = ReadFile(
        hPipe,                  // Handle of the pipe
        chResponse,             // Buffer to receive the reply
        cbResponse,             // Size of buffer in bytes
        &amp;cbRead,                // Number of bytes read 
        NULL                    // Not overlapped 
        );


    if (!fFinishRead &amp;&amp; ERROR_MORE_DATA != GetLastError())
    {
        dwError = GetLastError();
        wprintf(L&quot;ReadFile from pipe failed w/err 0x%08lx\n&quot;, dwError);
        goto Cleanup;
    }


    wprintf(L&quot;Receive %ld bytes from server: \&quot;%s\&quot;\n&quot;, cbRead, chResponse);


} while (!fFinishRead); // Repeat loop if ERROR_MORE_DATA

</pre>
<pre id="codePreview" class="cplusplus">// 
// Send a request from client to server
// 


wchar_t chRequest[] = REQUEST_MESSAGE;
DWORD cbRequest, cbWritten;
cbRequest = sizeof(chRequest);


if (!WriteFile(
    hPipe,                      // Handle of the pipe
    chRequest,                  // Message to be written
    cbRequest,                  // Number of bytes to write
    &amp;cbWritten,                 // Number of bytes written
    NULL                        // Not overlapped
    ))
{
    dwError = GetLastError();
    wprintf(L&quot;WriteFile to pipe failed w/err 0x%08lx\n&quot;, dwError);
    goto Cleanup;
}


wprintf(L&quot;Send %ld bytes to server: \&quot;%s\&quot;\n&quot;, cbWritten, chRequest);


//
// Receive a response from server.
// 


BOOL fFinishRead = FALSE;
do
{
    wchar_t chResponse[BUFFER_SIZE];
    DWORD cbResponse, cbRead;
    cbResponse = sizeof(chResponse);


    fFinishRead = ReadFile(
        hPipe,                  // Handle of the pipe
        chResponse,             // Buffer to receive the reply
        cbResponse,             // Size of buffer in bytes
        &amp;cbRead,                // Number of bytes read 
        NULL                    // Not overlapped 
        );


    if (!fFinishRead &amp;&amp; ERROR_MORE_DATA != GetLastError())
    {
        dwError = GetLastError();
        wprintf(L&quot;ReadFile from pipe failed w/err 0x%08lx\n&quot;, dwError);
        goto Cleanup;
    }


    wprintf(L&quot;Receive %ld bytes from server: \&quot;%s\&quot;\n&quot;, cbRead, chResponse);


} while (!fFinishRead); // Repeat loop if ERROR_MORE_DATA

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt">&nbsp;</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt; text-indent:5.0pt">
<span><span>d.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Close the pipe. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">CloseHandle(hPipe);

</pre>
<pre id="codePreview" class="cplusplus">CloseHandle(hPipe);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:108.0pt">&nbsp;</p>
<h2>More Information<span> </span></h2>
<p class="MsoNormal"><span><a href="http://msdn.microsoft.com/en-us/library/aa365590.aspx">MSDN: Named Pipes</a>
</span></p>
<p class="MsoNormal"><span><a href="http://msdn.microsoft.com/en-us/library/aa365592.aspx">MSDN: Using Pipes / Named Pipe Client</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

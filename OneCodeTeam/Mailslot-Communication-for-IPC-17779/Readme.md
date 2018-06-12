# Mailslot Communication for IPC (VBMailslotCommunication)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Windows SDK
* IPC and RPC
## Topics
* mailslot
## IsPublished
* True
## ModifiedDate
* 2013-02-19 06:03:30
## Description

<h1><span>VB</span> mailslot <span>communication </span>(<span class="SpellE"><span>VBMailslotcommunication</span></span>)
<span>&nbsp;</span></h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span>Mailslot is a mechanism for one-way inter-process communication in the local</span><span>
</span><span>machine or across the computers in the intranet. Any clients can store messages in a mailslot. The creator of the slot, i.e. the server, retrieves the messages that are stored there:
</span></p>
<p class="MsoNormal"><span>Client (GENERIC_WRITE) ---&gt; Server (GENERIC_READ)
</span></p>
<p class="MsoNormal"><span>This sample demonstrates a mailslot client that connects and writes to the mailslot &quot;\\.\mailslot\SampleMailslot&quot;.
</span><strong><span>&nbsp;</span></strong></p>
<h2>Running the Sample<span> </span></h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Build the solution, and you will get 2 application: </span>
</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt; text-indent:5.0pt">
<span><span>a.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>VBMailslotServer.exe </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt; text-indent:5.0pt">
<span><span>b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>VBMailslotClient.exe </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Run VBMailslotServer.exe in a command prompt to start up the server end of the mailslot. The application will output the following information in the command prompt if the mailslot is created successfully.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/61478/1/image.png" alt="" width="560" height="135" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Run VBMailslotClient.exe in another command prompt to start up the client end of the mailslot. The application should output the message below in the command prompt when the client successfully opens the mailslot, and write three
 messages to the mailslot. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/61479/1/image.png" alt="" width="555" height="79" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>There is a three seconds' interval between the second message and the third one. During the interval, if you press ENTER in the server application, the mailslot server will retrieve the first two messages and display
 them. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/61480/1/image.png" alt="" width="475" height="73" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>After the interval, the client writes the third message. If you press ENTER again in the server application, the mailslot server prints the message:
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span><img src="/site/view/file/61481/1/image.png" alt="" width="507" height="66" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span><span>4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Enter 'Q' in the server application. This will close the mailslot and quit the server.
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span>&nbsp;</span></p>
<h2>Using the Code<span> </span></h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE"><strong><span>MailslotServer</span></strong></span><span>.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt; text-indent:5.0pt">
<span><span>a.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Create a mailslot. </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt; text-indent:5.0pt">
<span><span><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>i.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Prepare the security attributes for the mailslot. </span>
</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span>This is optional. If the<span>&nbsp;&nbsp;
</span><span class="SpellE"><strong>lpSecurityAttributes</strong></span> parameter of
<span class="SpellE"><strong>CreateMailslot</strong></span> is NULL, the mailslot gets<span>&nbsp;&nbsp;
</span>a default security descriptor and the handle cannot be inherited. The ACLs<span>&nbsp;&nbsp;
</span>in the default security descriptor of a mailslot grant full control to the
<span class="SpellE">LocalSystem</span> account, (elevated) <span class="SpellE">
dministrators</span>, and the creator owner. They also give only read access to members of the
<span class="GramE"><strong>Everyone</strong></span> group and the anonymous account. However, if you want to customize the security permission of the mailslot, (e.g. to allow Authenticated Users to read from and write to the mailslot), you need to create
 a SECURITY_ATTRIBUTES structure. </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt"><span>The <span class="SpellE">
CreateMailslotSecurity</span> helper function creates and initializes a new SECURITY_ATTRIBUTES structure to allow Authenticated Users read and write access to a mailslot, and to allow the Administrators group full access to the mailslot.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">''' &lt;summary&gt;
''' The CreateMailslotSecurity function creates and initializes a new 
''' SECURITY_ATTRIBUTES object to allow Authenticated Users read and 
''' write access to a mailslot, and to allow the Administrators group full 
''' access to the mailslot.
''' &lt;/summary&gt;
''' &lt;returns&gt;
''' A SECURITY_ATTRIBUTES object that allows Authenticated Users read and 
''' write access to a mailslot, and allows the Administrators group full 
''' access to the mailslot.
''' &lt;/returns&gt;
''' &lt;see cref=&quot;http://msdn.microsoft.com/en-us/library/aa365600.aspx&quot;/&gt;
Private Function CreateMailslotSecurity() As NativeMethods.SECURITY_ATTRIBUTES
    ' Define the SDDL for the security descriptor.
    Dim sddl As String = &quot;D:&quot; &amp; &quot;(A;OICI;GRGW;;;AU)&quot; &amp; &quot;(A;OICI;GA;;;BA)&quot; ' Allow full control to administrators -  Allow read/write to authenticated users -  Discretionary ACL


    Dim pSecurityDescriptor As NativeMethods.SafeLocalMemHandle = Nothing
    If Not NativeMethods.ConvertStringSecurityDescriptorToSecurityDescriptor(sddl, 1, pSecurityDescriptor, IntPtr.Zero) Then
        Throw New Win32Exception()
    End If


    Dim sa As New NativeMethods.SECURITY_ATTRIBUTES()
    sa.nLength = Marshal.SizeOf(sa)
    sa.lpSecurityDescriptor = pSecurityDescriptor
    sa.bInheritHandle = False
    Return sa
End Function

</pre>
<pre id="codePreview" class="vb">''' &lt;summary&gt;
''' The CreateMailslotSecurity function creates and initializes a new 
''' SECURITY_ATTRIBUTES object to allow Authenticated Users read and 
''' write access to a mailslot, and to allow the Administrators group full 
''' access to the mailslot.
''' &lt;/summary&gt;
''' &lt;returns&gt;
''' A SECURITY_ATTRIBUTES object that allows Authenticated Users read and 
''' write access to a mailslot, and allows the Administrators group full 
''' access to the mailslot.
''' &lt;/returns&gt;
''' &lt;see cref=&quot;http://msdn.microsoft.com/en-us/library/aa365600.aspx&quot;/&gt;
Private Function CreateMailslotSecurity() As NativeMethods.SECURITY_ATTRIBUTES
    ' Define the SDDL for the security descriptor.
    Dim sddl As String = &quot;D:&quot; &amp; &quot;(A;OICI;GRGW;;;AU)&quot; &amp; &quot;(A;OICI;GA;;;BA)&quot; ' Allow full control to administrators -  Allow read/write to authenticated users -  Discretionary ACL


    Dim pSecurityDescriptor As NativeMethods.SafeLocalMemHandle = Nothing
    If Not NativeMethods.ConvertStringSecurityDescriptorToSecurityDescriptor(sddl, 1, pSecurityDescriptor, IntPtr.Zero) Then
        Throw New Win32Exception()
    End If


    Dim sa As New NativeMethods.SECURITY_ATTRIBUTES()
    sa.nLength = Marshal.SizeOf(sa)
    sa.lpSecurityDescriptor = pSecurityDescriptor
    sa.bInheritHandle = False
    Return sa
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt; text-indent:5.0pt">
<span><span><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>ii.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Create the mailslot. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">''' &lt;summary&gt;
''' Creates an instance of a mailslot and returns a handle for subsequent 
''' operations.
''' &lt;/summary&gt;
''' &lt;param name=&quot;mailslotName&quot;&gt;Mailslot name&lt;/param&gt;
''' &lt;param name=&quot;nMaxMessageSize&quot;&gt;
''' The maximum size of a single message
''' &lt;/param&gt;
''' &lt;param name=&quot;lReadTimeout&quot;&gt;
''' The time a read operation can wait for a message.
''' &lt;/param&gt;
''' &lt;param name=&quot;securityAttributes&quot;&gt;Security attributes&lt;/param&gt;
''' &lt;returns&gt;
''' If the function succeeds, the return value is a handle to the server 
''' end of a mailslot instance.
''' &lt;/returns&gt;
&lt;DllImport(&quot;kernel32.dll&quot;, CharSet:=CharSet.Auto, SetLastError:=True)&gt; _
Public Shared Function CreateMailslot(ByVal mailslotName As String, ByVal nMaxMessageSize As UInteger, ByVal lReadTimeout As Integer, ByVal securityAttributes As SECURITY_ATTRIBUTES) As SafeMailslotHandle
End Function

</pre>
<pre id="codePreview" class="vb">''' &lt;summary&gt;
''' Creates an instance of a mailslot and returns a handle for subsequent 
''' operations.
''' &lt;/summary&gt;
''' &lt;param name=&quot;mailslotName&quot;&gt;Mailslot name&lt;/param&gt;
''' &lt;param name=&quot;nMaxMessageSize&quot;&gt;
''' The maximum size of a single message
''' &lt;/param&gt;
''' &lt;param name=&quot;lReadTimeout&quot;&gt;
''' The time a read operation can wait for a message.
''' &lt;/param&gt;
''' &lt;param name=&quot;securityAttributes&quot;&gt;Security attributes&lt;/param&gt;
''' &lt;returns&gt;
''' If the function succeeds, the return value is a handle to the server 
''' end of a mailslot instance.
''' &lt;/returns&gt;
&lt;DllImport(&quot;kernel32.dll&quot;, CharSet:=CharSet.Auto, SetLastError:=True)&gt; _
Public Shared Function CreateMailslot(ByVal mailslotName As String, ByVal nMaxMessageSize As UInteger, ByVal lReadTimeout As Integer, ByVal securityAttributes As SECURITY_ATTRIBUTES) As SafeMailslotHandle
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">' Create the mailslot.
hMailslot = NativeMethods.CreateMailslot(MailslotName, _
                                         0, _
                                         NativeMethods.MAILSLOT_WAIT_FOREVER, _
                                         sa) ' Mailslot security attributes -  Waits forever for a message -  No maximum message size -  The name of the mailslot

</pre>
<pre id="codePreview" class="vb">' Create the mailslot.
hMailslot = NativeMethods.CreateMailslot(MailslotName, _
                                         0, _
                                         NativeMethods.MAILSLOT_WAIT_FOREVER, _
                                         sa) ' Mailslot security attributes -  Waits forever for a message -  No maximum message size -  The name of the mailslot

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt; text-indent:5.0pt">
<span><span>b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Check messages in the mailslot. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">''' &lt;summary&gt;
''' Retrieves information about the specified mailslot.
''' &lt;/summary&gt;
''' &lt;param name=&quot;hMailslot&quot;&gt;A handle to a mailslot&lt;/param&gt;
''' &lt;param name=&quot;lpMaxMessageSize&quot;&gt;
''' The maximum message size, in bytes, allowed for this mailslot.
''' &lt;/param&gt;
''' &lt;param name=&quot;lpNextSize&quot;&gt;
''' The size of the next message in bytes.
''' &lt;/param&gt;
''' &lt;param name=&quot;lpMessageCount&quot;&gt;
''' The total number of messages waiting to be read.
''' &lt;/param&gt;
''' &lt;param name=&quot;lpReadTimeout&quot;&gt;
''' The amount of time, in milliseconds, a read operation can wait for a 
''' message to be written to the mailslot before a time-out occurs. 
''' &lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
&lt;DllImport(&quot;kernel32.dll&quot;, CharSet:=CharSet.Auto, SetLastError:=True)&gt; _
Public Shared Function GetMailslotInfo(ByVal hMailslot As SafeMailslotHandle, ByVal lpMaxMessageSize As IntPtr, &lt;System.Runtime.InteropServices.Out()&gt; ByRef lpNextSize As Integer, &lt;System.Runtime.InteropServices.Out()&gt; ByRef lpMessageCount As Integer, ByVal lpReadTimeout As IntPtr) As &lt;MarshalAs(UnmanagedType.Bool)&gt; Boolean
End Function




''' &lt;summary&gt;
''' Reads data from the specified file or input/output (I/O) device.
''' &lt;/summary&gt;
''' &lt;param name=&quot;handle&quot;&gt;
''' A handle to the device (for example, a file, file stream, physical 
''' disk, volume, console buffer, tape drive, socket, communications 
''' resource, mailslot, or pipe).
''' &lt;/param&gt;
''' &lt;param name=&quot;bytes&quot;&gt;
''' A buffer that receives the data read from a file or device.
''' &lt;/param&gt;
''' &lt;param name=&quot;numBytesToRead&quot;&gt;
''' The maximum number of bytes to be read.
''' &lt;/param&gt;
''' &lt;param name=&quot;numBytesRead&quot;&gt;
''' The number of bytes read when using a synchronous IO.
''' &lt;/param&gt;
''' &lt;param name=&quot;overlapped&quot;&gt;
''' A pointer to an OVERLAPPED structure if the file was opened with 
''' FILE_FLAG_OVERLAPPED.
''' &lt;/param&gt; 
''' &lt;returns&gt;
''' If the function succeeds, the return value is true. If the function 
''' fails, or is completing asynchronously, the return value is false.
''' &lt;/returns&gt;
&lt;DllImport(&quot;kernel32.dll&quot;, CharSet:=CharSet.Auto, SetLastError:=True)&gt; _
Public Shared Function ReadFile(ByVal handle As SafeMailslotHandle, ByVal bytes() As Byte, ByVal numBytesToRead As Integer, &lt;System.Runtime.InteropServices.Out()&gt; ByRef numBytesRead As Integer, ByVal overlapped As IntPtr) As &lt;MarshalAs(UnmanagedType.Bool)&gt; Boolean
End Function

</pre>
<pre id="codePreview" class="vb">''' &lt;summary&gt;
''' Retrieves information about the specified mailslot.
''' &lt;/summary&gt;
''' &lt;param name=&quot;hMailslot&quot;&gt;A handle to a mailslot&lt;/param&gt;
''' &lt;param name=&quot;lpMaxMessageSize&quot;&gt;
''' The maximum message size, in bytes, allowed for this mailslot.
''' &lt;/param&gt;
''' &lt;param name=&quot;lpNextSize&quot;&gt;
''' The size of the next message in bytes.
''' &lt;/param&gt;
''' &lt;param name=&quot;lpMessageCount&quot;&gt;
''' The total number of messages waiting to be read.
''' &lt;/param&gt;
''' &lt;param name=&quot;lpReadTimeout&quot;&gt;
''' The amount of time, in milliseconds, a read operation can wait for a 
''' message to be written to the mailslot before a time-out occurs. 
''' &lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
&lt;DllImport(&quot;kernel32.dll&quot;, CharSet:=CharSet.Auto, SetLastError:=True)&gt; _
Public Shared Function GetMailslotInfo(ByVal hMailslot As SafeMailslotHandle, ByVal lpMaxMessageSize As IntPtr, &lt;System.Runtime.InteropServices.Out()&gt; ByRef lpNextSize As Integer, &lt;System.Runtime.InteropServices.Out()&gt; ByRef lpMessageCount As Integer, ByVal lpReadTimeout As IntPtr) As &lt;MarshalAs(UnmanagedType.Bool)&gt; Boolean
End Function




''' &lt;summary&gt;
''' Reads data from the specified file or input/output (I/O) device.
''' &lt;/summary&gt;
''' &lt;param name=&quot;handle&quot;&gt;
''' A handle to the device (for example, a file, file stream, physical 
''' disk, volume, console buffer, tape drive, socket, communications 
''' resource, mailslot, or pipe).
''' &lt;/param&gt;
''' &lt;param name=&quot;bytes&quot;&gt;
''' A buffer that receives the data read from a file or device.
''' &lt;/param&gt;
''' &lt;param name=&quot;numBytesToRead&quot;&gt;
''' The maximum number of bytes to be read.
''' &lt;/param&gt;
''' &lt;param name=&quot;numBytesRead&quot;&gt;
''' The number of bytes read when using a synchronous IO.
''' &lt;/param&gt;
''' &lt;param name=&quot;overlapped&quot;&gt;
''' A pointer to an OVERLAPPED structure if the file was opened with 
''' FILE_FLAG_OVERLAPPED.
''' &lt;/param&gt; 
''' &lt;returns&gt;
''' If the function succeeds, the return value is true. If the function 
''' fails, or is completing asynchronously, the return value is false.
''' &lt;/returns&gt;
&lt;DllImport(&quot;kernel32.dll&quot;, CharSet:=CharSet.Auto, SetLastError:=True)&gt; _
Public Shared Function ReadFile(ByVal handle As SafeMailslotHandle, ByVal bytes() As Byte, ByVal numBytesToRead As Integer, &lt;System.Runtime.InteropServices.Out()&gt; ByRef numBytesRead As Integer, ByVal overlapped As IntPtr) As &lt;MarshalAs(UnmanagedType.Bool)&gt; Boolean
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:72.0pt"><span>&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">''' &lt;summary&gt;
''' Read the messages from a mailslot by using the mailslot handle in a call 
''' to the ReadFile function. 
''' &lt;/summary&gt;
''' &lt;param name=&quot;hMailslot&quot;&gt;The handle of the mailslot&lt;/param&gt;
''' &lt;returns&gt; 
''' If the function succeeds, the return value is true.
''' &lt;/returns&gt;
Private Function ReadMailslot(ByVal hMailslot As NativeMethods.SafeMailslotHandle) As Boolean
    Dim cbMessageBytes As Integer = 0 ' Size of the message in bytes
    Dim cbBytesRead As Integer = 0 ' Number of bytes read from the mailslot
    Dim cMessages As Integer = 0 ' Number of messages in the slot
    Dim nMessageId As Integer = 0 ' Message ID


    Dim succeeded As Boolean = False


    ' Check for the number of messages in the mailslot.
    succeeded = NativeMethods.GetMailslotInfo(hMailslot, IntPtr.Zero, cbMessageBytes, cMessages, IntPtr.Zero) ' No read time-out -  Number of messages -  Size of next message -  No maximum message size -  Handle of the mailslot
    If Not succeeded Then
        Console.WriteLine(&quot;GetMailslotInfo failed w/err 0x{0:X}&quot;, Marshal.GetLastWin32Error())
        Return succeeded
    End If


    If cbMessageBytes = NativeMethods.MAILSLOT_NO_MESSAGE Then
        ' There are no new messages in the mailslot at present
        Console.WriteLine(&quot;No new messages.&quot;)
        Return succeeded
    End If


    ' Retrieve the messages one by one from the mailslot.
    Do While cMessages &lt;&gt; 0
        nMessageId &#43;= 1


        ' Declare a byte array to fetch the data
        Dim bBuffer(cbMessageBytes - 1) As Byte
        succeeded = NativeMethods.ReadFile(hMailslot, bBuffer, cbMessageBytes, cbBytesRead, IntPtr.Zero) ' Not overlapped I/O -  Number of bytes read from mailslot -  Size of buffer in bytes -  Buffer to receive data -  Handle of mailslot
        If Not succeeded Then
            Console.WriteLine(&quot;ReadFile failed w/err 0x{0:X}&quot;, Marshal.GetLastWin32Error())
            Exit Do
        End If


        ' Display the message. 
        Console.WriteLine(&quot;Message #{0}: {1}&quot;, nMessageId, Encoding.Unicode.GetString(bBuffer))


        ' Get the current number of un-read messages in the slot. The number
        ' may not equal the initial message number because new messages may 
        ' arrive while we are reading the items in the slot.
        succeeded = NativeMethods.GetMailslotInfo(hMailslot, IntPtr.Zero, cbMessageBytes, cMessages, IntPtr.Zero) ' No read time-out -  Number of messages -  Size of next message -  No maximum message size -  Handle of the mailslot
        If Not succeeded Then
            Console.WriteLine(&quot;GetMailslotInfo failed w/err 0x{0:X}&quot;, Marshal.GetLastWin32Error())
            Exit Do
        End If
    Loop


    Return succeeded
End Function

</pre>
<pre id="codePreview" class="vb">''' &lt;summary&gt;
''' Read the messages from a mailslot by using the mailslot handle in a call 
''' to the ReadFile function. 
''' &lt;/summary&gt;
''' &lt;param name=&quot;hMailslot&quot;&gt;The handle of the mailslot&lt;/param&gt;
''' &lt;returns&gt; 
''' If the function succeeds, the return value is true.
''' &lt;/returns&gt;
Private Function ReadMailslot(ByVal hMailslot As NativeMethods.SafeMailslotHandle) As Boolean
    Dim cbMessageBytes As Integer = 0 ' Size of the message in bytes
    Dim cbBytesRead As Integer = 0 ' Number of bytes read from the mailslot
    Dim cMessages As Integer = 0 ' Number of messages in the slot
    Dim nMessageId As Integer = 0 ' Message ID


    Dim succeeded As Boolean = False


    ' Check for the number of messages in the mailslot.
    succeeded = NativeMethods.GetMailslotInfo(hMailslot, IntPtr.Zero, cbMessageBytes, cMessages, IntPtr.Zero) ' No read time-out -  Number of messages -  Size of next message -  No maximum message size -  Handle of the mailslot
    If Not succeeded Then
        Console.WriteLine(&quot;GetMailslotInfo failed w/err 0x{0:X}&quot;, Marshal.GetLastWin32Error())
        Return succeeded
    End If


    If cbMessageBytes = NativeMethods.MAILSLOT_NO_MESSAGE Then
        ' There are no new messages in the mailslot at present
        Console.WriteLine(&quot;No new messages.&quot;)
        Return succeeded
    End If


    ' Retrieve the messages one by one from the mailslot.
    Do While cMessages &lt;&gt; 0
        nMessageId &#43;= 1


        ' Declare a byte array to fetch the data
        Dim bBuffer(cbMessageBytes - 1) As Byte
        succeeded = NativeMethods.ReadFile(hMailslot, bBuffer, cbMessageBytes, cbBytesRead, IntPtr.Zero) ' Not overlapped I/O -  Number of bytes read from mailslot -  Size of buffer in bytes -  Buffer to receive data -  Handle of mailslot
        If Not succeeded Then
            Console.WriteLine(&quot;ReadFile failed w/err 0x{0:X}&quot;, Marshal.GetLastWin32Error())
            Exit Do
        End If


        ' Display the message. 
        Console.WriteLine(&quot;Message #{0}: {1}&quot;, nMessageId, Encoding.Unicode.GetString(bBuffer))


        ' Get the current number of un-read messages in the slot. The number
        ' may not equal the initial message number because new messages may 
        ' arrive while we are reading the items in the slot.
        succeeded = NativeMethods.GetMailslotInfo(hMailslot, IntPtr.Zero, cbMessageBytes, cMessages, IntPtr.Zero) ' No read time-out -  Number of messages -  Size of next message -  No maximum message size -  Handle of the mailslot
        If Not succeeded Then
            Console.WriteLine(&quot;GetMailslotInfo failed w/err 0x{0:X}&quot;, Marshal.GetLastWin32Error())
            Exit Do
        End If
    Loop


    Return succeeded
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt; text-indent:5.0pt">
<span><span>c.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Close the handle of the mailslot instance. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">If hMailslot IsNot Nothing Then
    hMailslot.Close()
    hMailslot = Nothing
End If

</pre>
<pre id="codePreview" class="vb">If hMailslot IsNot Nothing Then
    hMailslot.Close()
    hMailslot = Nothing
End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt">&nbsp;</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><strong><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></strong><span class="SpellE"><strong><span>MailslotClient</span></strong></span><strong><span>
</span></strong></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt; text-indent:5.0pt">
<span><span>a.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Open the mailslot. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">' Try to open the mailslot with the write access.
hMailslot = NativeMethods.CreateFile(MailslotName, _
                                     NativeMethods.FileDesiredAccess.GENERIC_WRITE, _
                                     NativeMethods.FileShareMode.FILE_SHARE_READ, _
                                     IntPtr.Zero, _
                                     NativeMethods.FileCreationDisposition.OPEN_EXISTING, _
                                     0, _
                                     IntPtr.Zero) ' No template file -  No other attributes set -  Opens existing mailslot -  Default security attributes -  Share mode -  Write access -  The name of the mailslot
If hMailslot.IsInvalid Then
    Throw New Win32Exception()
End If

</pre>
<pre id="codePreview" class="vb">' Try to open the mailslot with the write access.
hMailslot = NativeMethods.CreateFile(MailslotName, _
                                     NativeMethods.FileDesiredAccess.GENERIC_WRITE, _
                                     NativeMethods.FileShareMode.FILE_SHARE_READ, _
                                     IntPtr.Zero, _
                                     NativeMethods.FileCreationDisposition.OPEN_EXISTING, _
                                     0, _
                                     IntPtr.Zero) ' No template file -  No other attributes set -  Opens existing mailslot -  Default security attributes -  Share mode -  Write access -  The name of the mailslot
If hMailslot.IsInvalid Then
    Throw New Win32Exception()
End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt">&nbsp;</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt">&nbsp;</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt; text-indent:5.0pt">
<span><span>b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Write messages to the mailslot. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">''' &lt;summary&gt;
''' Write a message to the specified mailslot
''' &lt;/summary&gt;
''' &lt;param name=&quot;hMailslot&quot;&gt;Handle to the mailslot&lt;/param&gt;
''' &lt;param name=&quot;lpszMessage&quot;&gt;The message to be written to the slot&lt;/param&gt;
Private Sub WriteMailslot(ByVal hMailslot As NativeMethods.SafeMailslotHandle, _
                          ByVal message As String)
    Dim cbMessageBytes As Integer = 0 ' Message size in bytes
    Dim cbBytesWritten As Integer = 0 ' Number of bytes written to the slot


    Dim bMessage() As Byte = Encoding.Unicode.GetBytes(message)
    cbMessageBytes = bMessage.Length


    Dim succeeded As Boolean = NativeMethods.WriteFile(hMailslot, _
                                                       bMessage, _
                                                       cbMessageBytes, _
                                                       cbBytesWritten, _
                                                       IntPtr.Zero) ' Not overlapped -  Number of bytes written -  Number of bytes to write -  Message to be written -  Handle to the mailslot
    If (Not succeeded) OrElse cbMessageBytes &lt;&gt; cbBytesWritten Then
        Console.WriteLine(&quot;WriteFile failed w/err 0x{0:X}&quot;, Marshal.GetLastWin32Error())
    Else
        Console.WriteLine(&quot;The message &quot;&quot;{0}&quot;&quot; is written to the slot&quot;, message)
    End If
End Sub

</pre>
<pre id="codePreview" class="vb">''' &lt;summary&gt;
''' Write a message to the specified mailslot
''' &lt;/summary&gt;
''' &lt;param name=&quot;hMailslot&quot;&gt;Handle to the mailslot&lt;/param&gt;
''' &lt;param name=&quot;lpszMessage&quot;&gt;The message to be written to the slot&lt;/param&gt;
Private Sub WriteMailslot(ByVal hMailslot As NativeMethods.SafeMailslotHandle, _
                          ByVal message As String)
    Dim cbMessageBytes As Integer = 0 ' Message size in bytes
    Dim cbBytesWritten As Integer = 0 ' Number of bytes written to the slot


    Dim bMessage() As Byte = Encoding.Unicode.GetBytes(message)
    cbMessageBytes = bMessage.Length


    Dim succeeded As Boolean = NativeMethods.WriteFile(hMailslot, _
                                                       bMessage, _
                                                       cbMessageBytes, _
                                                       cbBytesWritten, _
                                                       IntPtr.Zero) ' Not overlapped -  Number of bytes written -  Number of bytes to write -  Message to be written -  Handle to the mailslot
    If (Not succeeded) OrElse cbMessageBytes &lt;&gt; cbBytesWritten Then
        Console.WriteLine(&quot;WriteFile failed w/err 0x{0:X}&quot;, Marshal.GetLastWin32Error())
    Else
        Console.WriteLine(&quot;The message &quot;&quot;{0}&quot;&quot; is written to the slot&quot;, message)
    End If
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt">&nbsp;</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt">&nbsp;</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt; text-indent:5.0pt">
<span><span>c.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Close the slot. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">If hMailslot IsNot Nothing Then
    hMailslot.Close()
    hMailslot = Nothing
End If

</pre>
<pre id="codePreview" class="vb">If hMailslot IsNot Nothing Then
    hMailslot.Close()
    hMailslot = Nothing
End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:72.0pt">&nbsp;</p>
<h2>More Information<span> </span></h2>
<p class="MsoNormal"><span><a href="http://msdn.microsoft.com/en-us/library/aa365785.aspx">Using
<span class="SpellE">Mailslots</span> / Reading from a Mailslot</a> </span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

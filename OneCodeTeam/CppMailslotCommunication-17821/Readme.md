# CppMailslotCommunication
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows SDK
## Topics
* mailslot
## IsPublished
* False
## ModifiedDate
* 2012-07-22 07:03:07
## Description

<h1>C# mailslot <span style="">communication </span>(<span class="SpellE"><span style="">CSMailslotcommunication</span></span>)
<span style=""></span></h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span style="">Mailslot is a mechanism for one-way inter-process communication in the local</span><span style="">
</span><span style="">machine or across the computers in the intranet. Any clients can store messages in a mailslot. The creator of the slot, i.e. the server, retrieves the messages that are stored there:
</span></p>
<p class="MsoNormal"><span style="">Client (GENERIC_WRITE) ---&gt; Server (GENERIC_READ)
</span></p>
<p class="MsoNormal"><span style="">This sample demonstrates a mailslot client that connects and writes to the mailslot &quot;\\.\mailslot\SampleMailslot&quot;.
</span><b><span style=""></span></b></p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Build the solution, and you will get 2 application:
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt; text-indent:5.0pt">
<span style=""><span style="">a.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">CSMailslotServer.exe </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt; text-indent:5.0pt">
<span style=""><span style="">b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">CSMailslotClient.exe </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Run CSMailslotServer.exe in a command prompt to start up the server end of the mailslot. The application will output the following information in the command prompt if the mailslot is created successfully.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/61592/1/image.png" alt="" width="560" height="135" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Run CSMailslotClient.exe in another command prompt to start up the client end of the mailslot. The application should output the message below in the command prompt when the client successfully opens the mailslot, and write
 three messages to the mailslot. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/61593/1/image.png" alt="" width="555" height="79" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">There is a three seconds' interval between the second message and the third one. During the interval, if you press ENTER in the server application, the mailslot server will retrieve the first two messages
 and display them. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/61594/1/image.png" alt="" width="475" height="73" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">After the interval, the client writes the third message. If you press ENTER again in the server application, the mailslot server prints the message:
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/61595/1/image.png" alt="" width="507" height="66" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Enter 'Q' in the server application. This will close the mailslot and quit the server.
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""></span></p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE"><b style=""><span style="">MailslotServer</span></b></span><span style="">.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt; text-indent:5.0pt">
<span style=""><span style="">a.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Create a mailslot. </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt; text-indent:5.0pt">
<span style=""><span style=""><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>i.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Prepare the security attributes for the mailslot.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span style="">This is optional. If the
<span style="">&nbsp;&nbsp;</span><span class="SpellE"><b style="">lpSecurityAttributes</b></span> parameter of
<span class="SpellE"><b style="">CreateMailslot</b></span> is NULL, the mailslot gets
<span style="">&nbsp;&nbsp;</span>a default security descriptor and the handle cannot be inherited. The ACLs
<span style="">&nbsp;&nbsp;</span>in the default security descriptor of a mailslot grant full control to the
<span class="SpellE">LocalSystem</span> account, (elevated) <span class="SpellE">
dministrators</span>, and the creator owner. They also give only read access to members of the
<span class="GramE"><b style="">Everyone</b></span> group and the anonymous account. However, if you want to customize the security permission of the mailslot, (e.g. to allow Authenticated Users to read from and write to the mailslot), you need to create
 a SECURITY_ATTRIBUTES structure. </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span style="">The
<span class="SpellE">CreateMailslotSecurity</span> helper function creates and initializes a new SECURITY_ATTRIBUTES structure to allow Authenticated Users read and write access to a mailslot, and to allow the Administrators group full access to the mailslot.
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt"><span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
/// The CreateMailslotSecurity function creates and initializes a new 
/// SECURITY_ATTRIBUTES object to allow Authenticated Users read and 
/// write access to a mailslot, and to allow the Administrators group full 
/// access to the mailslot.
/// &lt;/summary&gt;
/// &lt;returns&gt;
/// A SECURITY_ATTRIBUTES object that allows Authenticated Users read and 
/// write access to a mailslot, and allows the Administrators group full 
/// access to the mailslot.
/// &lt;/returns&gt;
/// &lt;see cref=&quot;http://msdn.microsoft.com/en-us/library/aa365600.aspx&quot;/&gt;
static NativeMethods.SECURITY_ATTRIBUTES CreateMailslotSecurity()
{
    // Define the SDDL for the security descriptor.
    string sddl = &quot;D:&quot; &#43;        // Discretionary ACL
        &quot;(A;OICI;GRGW;;;AU)&quot; &#43;  // Allow read/write to authenticated users
        &quot;(A;OICI;GA;;;BA)&quot;;     // Allow full control to administrators


    NativeMethods.SafeLocalMemHandle pSecurityDescriptor = null;
    if (!NativeMethods.ConvertStringSecurityDescriptorToSecurityDescriptor(
        sddl, 1, out pSecurityDescriptor, IntPtr.Zero))
    {
        throw new Win32Exception();
    }


    NativeMethods.SECURITY_ATTRIBUTES sa = new NativeMethods.SECURITY_ATTRIBUTES();
    sa.nLength = Marshal.SizeOf(sa);
    sa.lpSecurityDescriptor = pSecurityDescriptor;
    sa.bInheritHandle = false;
    return sa;
}

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
/// The CreateMailslotSecurity function creates and initializes a new 
/// SECURITY_ATTRIBUTES object to allow Authenticated Users read and 
/// write access to a mailslot, and to allow the Administrators group full 
/// access to the mailslot.
/// &lt;/summary&gt;
/// &lt;returns&gt;
/// A SECURITY_ATTRIBUTES object that allows Authenticated Users read and 
/// write access to a mailslot, and allows the Administrators group full 
/// access to the mailslot.
/// &lt;/returns&gt;
/// &lt;see cref=&quot;http://msdn.microsoft.com/en-us/library/aa365600.aspx&quot;/&gt;
static NativeMethods.SECURITY_ATTRIBUTES CreateMailslotSecurity()
{
    // Define the SDDL for the security descriptor.
    string sddl = &quot;D:&quot; &#43;        // Discretionary ACL
        &quot;(A;OICI;GRGW;;;AU)&quot; &#43;  // Allow read/write to authenticated users
        &quot;(A;OICI;GA;;;BA)&quot;;     // Allow full control to administrators


    NativeMethods.SafeLocalMemHandle pSecurityDescriptor = null;
    if (!NativeMethods.ConvertStringSecurityDescriptorToSecurityDescriptor(
        sddl, 1, out pSecurityDescriptor, IntPtr.Zero))
    {
        throw new Win32Exception();
    }


    NativeMethods.SECURITY_ATTRIBUTES sa = new NativeMethods.SECURITY_ATTRIBUTES();
    sa.nLength = Marshal.SizeOf(sa);
    sa.lpSecurityDescriptor = pSecurityDescriptor;
    sa.bInheritHandle = false;
    return sa;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt; text-indent:5.0pt">
<span style=""><span style=""><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>ii.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Create the mailslot. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
/// Creates an instance of a mailslot and returns a handle for subsequent 
/// operations.
/// &lt;/summary&gt;
/// &lt;param name=&quot;mailslotName&quot;&gt;Mailslot name&lt;/param&gt;
/// &lt;param name=&quot;nMaxMessageSize&quot;&gt;
/// The maximum size of a single message
/// &lt;/param&gt;
/// &lt;param name=&quot;lReadTimeout&quot;&gt;
/// The time a read operation can wait for a message.
/// &lt;/param&gt;
/// &lt;param name=&quot;securityAttributes&quot;&gt;Security attributes&lt;/param&gt;
/// &lt;returns&gt;
/// If the function succeeds, the return value is a handle to the server 
/// end of a mailslot instance.
/// &lt;/returns&gt;
[DllImport(&quot;kernel32.dll&quot;, CharSet = CharSet.Auto, SetLastError = true)]
public static extern SafeMailslotHandle CreateMailslot(string mailslotName,
    uint nMaxMessageSize, int lReadTimeout,
    SECURITY_ATTRIBUTES securityAttributes);

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
/// Creates an instance of a mailslot and returns a handle for subsequent 
/// operations.
/// &lt;/summary&gt;
/// &lt;param name=&quot;mailslotName&quot;&gt;Mailslot name&lt;/param&gt;
/// &lt;param name=&quot;nMaxMessageSize&quot;&gt;
/// The maximum size of a single message
/// &lt;/param&gt;
/// &lt;param name=&quot;lReadTimeout&quot;&gt;
/// The time a read operation can wait for a message.
/// &lt;/param&gt;
/// &lt;param name=&quot;securityAttributes&quot;&gt;Security attributes&lt;/param&gt;
/// &lt;returns&gt;
/// If the function succeeds, the return value is a handle to the server 
/// end of a mailslot instance.
/// &lt;/returns&gt;
[DllImport(&quot;kernel32.dll&quot;, CharSet = CharSet.Auto, SetLastError = true)]
public static extern SafeMailslotHandle CreateMailslot(string mailslotName,
    uint nMaxMessageSize, int lReadTimeout,
    SECURITY_ATTRIBUTES securityAttributes);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:108.0pt"><span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Create the mailslot.
hMailslot = NativeMethods.CreateMailslot(
  MailslotName,               // The name of the mailslot
  0,                          // No maximum message size
  NativeMethods. MAILSLOT_WAIT_FOREVER,      // Waits forever for a message
  sa                          // Mailslot security attributes
  );

</pre>
<pre id="codePreview" class="csharp">
// Create the mailslot.
hMailslot = NativeMethods.CreateMailslot(
  MailslotName,               // The name of the mailslot
  0,                          // No maximum message size
  NativeMethods. MAILSLOT_WAIT_FOREVER,      // Waits forever for a message
  sa                          // Mailslot security attributes
  );

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt; text-indent:5.0pt">
<span style=""><span style="">b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Check messages in the mailslot. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
/// Retrieves information about the specified mailslot.
/// &lt;/summary&gt;
/// &lt;param name=&quot;hMailslot&quot;&gt;A handle to a mailslot&lt;/param&gt;
/// &lt;param name=&quot;lpMaxMessageSize&quot;&gt;
/// The maximum message size, in bytes, allowed for this mailslot.
/// &lt;/param&gt;
/// &lt;param name=&quot;lpNextSize&quot;&gt;
/// The size of the next message in bytes.
/// &lt;/param&gt;
/// &lt;param name=&quot;lpMessageCount&quot;&gt;
/// The total number of messages waiting to be read.
/// &lt;/param&gt;
/// &lt;param name=&quot;lpReadTimeout&quot;&gt;
/// The amount of time, in milliseconds, a read operation can wait for a 
/// message to be written to the mailslot before a time-out occurs. 
/// &lt;/param&gt;
/// &lt;returns&gt;&lt;/returns&gt;
[DllImport(&quot;kernel32.dll&quot;, CharSet = CharSet.Auto, SetLastError = true)]
[return: MarshalAs(UnmanagedType.Bool)]
public static extern bool GetMailslotInfo(SafeMailslotHandle hMailslot,
    IntPtr lpMaxMessageSize, out int lpNextSize, out int lpMessageCount,
    IntPtr lpReadTimeout);




/// &lt;summary&gt;
/// Reads data from the specified file or input/output (I/O) device.
/// &lt;/summary&gt;
/// &lt;param name=&quot;handle&quot;&gt;
/// A handle to the device (for example, a file, file stream, physical 
/// disk, volume, console buffer, tape drive, socket, communications 
/// resource, mailslot, or pipe).
/// &lt;/param&gt;
/// &lt;param name=&quot;bytes&quot;&gt;
/// A buffer that receives the data read from a file or device.
/// &lt;/param&gt;
/// &lt;param name=&quot;numBytesToRead&quot;&gt;
/// The maximum number of bytes to be read.
/// &lt;/param&gt;
/// &lt;param name=&quot;numBytesRead&quot;&gt;
/// The number of bytes read when using a synchronous IO.
/// &lt;/param&gt;
/// &lt;param name=&quot;overlapped&quot;&gt;
/// A pointer to an OVERLAPPED structure if the file was opened with 
/// FILE_FLAG_OVERLAPPED.
/// &lt;/param&gt; 
/// &lt;returns&gt;
/// If the function succeeds, the return value is true. If the function 
/// fails, or is completing asynchronously, the return value is false.
/// &lt;/returns&gt;
[DllImport(&quot;kernel32.dll&quot;, CharSet = CharSet.Auto, SetLastError = true)]
[return: MarshalAs(UnmanagedType.Bool)]
public static extern bool ReadFile(SafeMailslotHandle handle,
    byte[] bytes, int numBytesToRead, out int numBytesRead,
    IntPtr overlapped);

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
/// Retrieves information about the specified mailslot.
/// &lt;/summary&gt;
/// &lt;param name=&quot;hMailslot&quot;&gt;A handle to a mailslot&lt;/param&gt;
/// &lt;param name=&quot;lpMaxMessageSize&quot;&gt;
/// The maximum message size, in bytes, allowed for this mailslot.
/// &lt;/param&gt;
/// &lt;param name=&quot;lpNextSize&quot;&gt;
/// The size of the next message in bytes.
/// &lt;/param&gt;
/// &lt;param name=&quot;lpMessageCount&quot;&gt;
/// The total number of messages waiting to be read.
/// &lt;/param&gt;
/// &lt;param name=&quot;lpReadTimeout&quot;&gt;
/// The amount of time, in milliseconds, a read operation can wait for a 
/// message to be written to the mailslot before a time-out occurs. 
/// &lt;/param&gt;
/// &lt;returns&gt;&lt;/returns&gt;
[DllImport(&quot;kernel32.dll&quot;, CharSet = CharSet.Auto, SetLastError = true)]
[return: MarshalAs(UnmanagedType.Bool)]
public static extern bool GetMailslotInfo(SafeMailslotHandle hMailslot,
    IntPtr lpMaxMessageSize, out int lpNextSize, out int lpMessageCount,
    IntPtr lpReadTimeout);




/// &lt;summary&gt;
/// Reads data from the specified file or input/output (I/O) device.
/// &lt;/summary&gt;
/// &lt;param name=&quot;handle&quot;&gt;
/// A handle to the device (for example, a file, file stream, physical 
/// disk, volume, console buffer, tape drive, socket, communications 
/// resource, mailslot, or pipe).
/// &lt;/param&gt;
/// &lt;param name=&quot;bytes&quot;&gt;
/// A buffer that receives the data read from a file or device.
/// &lt;/param&gt;
/// &lt;param name=&quot;numBytesToRead&quot;&gt;
/// The maximum number of bytes to be read.
/// &lt;/param&gt;
/// &lt;param name=&quot;numBytesRead&quot;&gt;
/// The number of bytes read when using a synchronous IO.
/// &lt;/param&gt;
/// &lt;param name=&quot;overlapped&quot;&gt;
/// A pointer to an OVERLAPPED structure if the file was opened with 
/// FILE_FLAG_OVERLAPPED.
/// &lt;/param&gt; 
/// &lt;returns&gt;
/// If the function succeeds, the return value is true. If the function 
/// fails, or is completing asynchronously, the return value is false.
/// &lt;/returns&gt;
[DllImport(&quot;kernel32.dll&quot;, CharSet = CharSet.Auto, SetLastError = true)]
[return: MarshalAs(UnmanagedType.Bool)]
public static extern bool ReadFile(SafeMailslotHandle handle,
    byte[] bytes, int numBytesToRead, out int numBytesRead,
    IntPtr overlapped);

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:72.0pt"><span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
/// Read the messages from a mailslot by using the mailslot handle in a call 
/// to the ReadFile function. 
/// &lt;/summary&gt;
/// &lt;param name=&quot;hMailslot&quot;&gt;The handle of the mailslot&lt;/param&gt;
/// &lt;returns&gt; 
/// If the function succeeds, the return value is true.
/// &lt;/returns&gt;
static bool ReadMailslot(NativeMethods.SafeMailslotHandle hMailslot)
{
    int cbMessageBytes = 0;         // Size of the message in bytes
    int cbBytesRead = 0;            // Number of bytes read from the mailslot
    int cMessages = 0;              // Number of messages in the slot
    int nMessageId = 0;             // Message ID


    bool succeeded = false;


    // Check for the number of messages in the mailslot.
    succeeded = NativeMethods.GetMailslotInfo(
        hMailslot,                  // Handle of the mailslot
        IntPtr.Zero,                // No maximum message size 
        out cbMessageBytes,         // Size of next message 
        out cMessages,              // Number of messages 
        IntPtr.Zero                 // No read time-out
        );
    if (!succeeded)
    {
        Console.WriteLine(&quot;GetMailslotInfo failed w/err 0x{0:X}&quot;,
            Marshal.GetLastWin32Error());
        return succeeded;
    }


    if (cbMessageBytes == NativeMethods. MAILSLOT_NO_MESSAGE)
    {
        // There are no new messages in the mailslot at present
        Console.WriteLine(&quot;No new messages.&quot;);
        return succeeded;
    }


    // Retrieve the messages one by one from the mailslot.
    while (cMessages != 0)
    {
        nMessageId&#43;&#43;;


        // Declare a byte array to fetch the data
        byte[] bBuffer = new byte[cbMessageBytes];
        succeeded = NativeMethods.ReadFile(
            hMailslot,              // Handle of mailslot
            bBuffer,                // Buffer to receive data
            cbMessageBytes,         // Size of buffer in bytes
            out cbBytesRead,        // Number of bytes read from mailslot
            IntPtr.Zero             // Not overlapped I/O
            );
        if (!succeeded)
        {
            Console.WriteLine(&quot;ReadFile failed w/err 0x{0:X}&quot;, 
                Marshal.GetLastWin32Error());
            break;
        }


        // Display the message. 
        Console.WriteLine(&quot;Message #{0}: {1}&quot;, nMessageId, 
            Encoding.Unicode.GetString(bBuffer));


        // Get the current number of un-read messages in the slot. The number
        // may not equal the initial message number because new messages may 
        // arrive while we are reading the items in the slot.
        succeeded = NativeMethods.GetMailslotInfo(
            hMailslot,              // Handle of the mailslot
            IntPtr.Zero,            // No maximum message size 
            out cbMessageBytes,     // Size of next message 
            out cMessages,          // Number of messages 
            IntPtr.Zero             // No read time-out 
            );
        if (!succeeded)
        {
            Console.WriteLine(&quot;GetMailslotInfo failed w/err 0x{0:X}&quot;,
                Marshal.GetLastWin32Error());
            break;
        }
    }


    return succeeded;
}

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
/// Read the messages from a mailslot by using the mailslot handle in a call 
/// to the ReadFile function. 
/// &lt;/summary&gt;
/// &lt;param name=&quot;hMailslot&quot;&gt;The handle of the mailslot&lt;/param&gt;
/// &lt;returns&gt; 
/// If the function succeeds, the return value is true.
/// &lt;/returns&gt;
static bool ReadMailslot(NativeMethods.SafeMailslotHandle hMailslot)
{
    int cbMessageBytes = 0;         // Size of the message in bytes
    int cbBytesRead = 0;            // Number of bytes read from the mailslot
    int cMessages = 0;              // Number of messages in the slot
    int nMessageId = 0;             // Message ID


    bool succeeded = false;


    // Check for the number of messages in the mailslot.
    succeeded = NativeMethods.GetMailslotInfo(
        hMailslot,                  // Handle of the mailslot
        IntPtr.Zero,                // No maximum message size 
        out cbMessageBytes,         // Size of next message 
        out cMessages,              // Number of messages 
        IntPtr.Zero                 // No read time-out
        );
    if (!succeeded)
    {
        Console.WriteLine(&quot;GetMailslotInfo failed w/err 0x{0:X}&quot;,
            Marshal.GetLastWin32Error());
        return succeeded;
    }


    if (cbMessageBytes == NativeMethods. MAILSLOT_NO_MESSAGE)
    {
        // There are no new messages in the mailslot at present
        Console.WriteLine(&quot;No new messages.&quot;);
        return succeeded;
    }


    // Retrieve the messages one by one from the mailslot.
    while (cMessages != 0)
    {
        nMessageId&#43;&#43;;


        // Declare a byte array to fetch the data
        byte[] bBuffer = new byte[cbMessageBytes];
        succeeded = NativeMethods.ReadFile(
            hMailslot,              // Handle of mailslot
            bBuffer,                // Buffer to receive data
            cbMessageBytes,         // Size of buffer in bytes
            out cbBytesRead,        // Number of bytes read from mailslot
            IntPtr.Zero             // Not overlapped I/O
            );
        if (!succeeded)
        {
            Console.WriteLine(&quot;ReadFile failed w/err 0x{0:X}&quot;, 
                Marshal.GetLastWin32Error());
            break;
        }


        // Display the message. 
        Console.WriteLine(&quot;Message #{0}: {1}&quot;, nMessageId, 
            Encoding.Unicode.GetString(bBuffer));


        // Get the current number of un-read messages in the slot. The number
        // may not equal the initial message number because new messages may 
        // arrive while we are reading the items in the slot.
        succeeded = NativeMethods.GetMailslotInfo(
            hMailslot,              // Handle of the mailslot
            IntPtr.Zero,            // No maximum message size 
            out cbMessageBytes,     // Size of next message 
            out cMessages,          // Number of messages 
            IntPtr.Zero             // No read time-out 
            );
        if (!succeeded)
        {
            Console.WriteLine(&quot;GetMailslotInfo failed w/err 0x{0:X}&quot;,
                Marshal.GetLastWin32Error());
            break;
        }
    }


    return succeeded;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt; text-indent:5.0pt">
<span style=""><span style="">c.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Close the handle of the mailslot instance. </span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
if (hMailslot != null)
{
    hMailslot.Close();
    hMailslot = null;
}

</pre>
<pre id="codePreview" class="csharp">
if (hMailslot != null)
{
    hMailslot.Close();
    hMailslot = null;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><b style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><span class="SpellE"><b style=""><span style="">MailslotClient</span></b></span><b style=""><span style="">
</span></b></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt; text-indent:5.0pt">
<span style=""><span style="">a.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Open the mailslot. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Try to open the mailslot with the write access.
hMailslot = NativeMethods.CreateFile(
    MailslotName,                           // The name of the mailslot
    NativeMethods.FileDesiredAccess.GENERIC_WRITE,        // Write access 
    NativeMethods.FileShareMode.FILE_SHARE_READ,          // Share mode
    IntPtr.Zero,                            // Default security attributes
    NativeMethods.FileCreationDisposition.OPEN_EXISTING,  // Opens existing mailslot
    0,                                      // No other attributes set
    IntPtr.Zero                             // No template file
    );

</pre>
<pre id="codePreview" class="csharp">
// Try to open the mailslot with the write access.
hMailslot = NativeMethods.CreateFile(
    MailslotName,                           // The name of the mailslot
    NativeMethods.FileDesiredAccess.GENERIC_WRITE,        // Write access 
    NativeMethods.FileShareMode.FILE_SHARE_READ,          // Share mode
    IntPtr.Zero,                            // Default security attributes
    NativeMethods.FileCreationDisposition.OPEN_EXISTING,  // Opens existing mailslot
    0,                                      // No other attributes set
    IntPtr.Zero                             // No template file
    );

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt; text-indent:5.0pt">
<span style=""><span style="">b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Write messages to the mailslot. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
/// Write a message to the specified mailslot
/// &lt;/summary&gt;
/// &lt;param name=&quot;hMailslot&quot;&gt;Handle to the mailslot&lt;/param&gt;
/// &lt;param name=&quot;lpszMessage&quot;&gt;The message to be written to the slot&lt;/param&gt;
static void WriteMailslot(NativeMethods.SafeMailslotHandle hMailslot, string message)
{
    int cbMessageBytes = 0;         // Message size in bytes
    int cbBytesWritten = 0;         // Number of bytes written to the slot


    byte[] bMessage = Encoding.Unicode.GetBytes(message);
    cbMessageBytes = bMessage.Length;


    bool succeeded = NativeMethods.WriteFile(
        hMailslot,                  // Handle to the mailslot
        bMessage,                   // Message to be written
        cbMessageBytes,             // Number of bytes to write
        out cbBytesWritten,         // Number of bytes written
        IntPtr.Zero                 // Not overlapped
        );
    if (!succeeded || cbMessageBytes != cbBytesWritten)
    {
        Console.WriteLine(&quot;WriteFile failed w/err 0x{0:X}&quot;, 
            Marshal.GetLastWin32Error());
    }
    else
    {
        Console.WriteLine(&quot;The message \&quot;{0}\&quot; is written to the slot&quot;, 
            message);
    }
}

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
/// Write a message to the specified mailslot
/// &lt;/summary&gt;
/// &lt;param name=&quot;hMailslot&quot;&gt;Handle to the mailslot&lt;/param&gt;
/// &lt;param name=&quot;lpszMessage&quot;&gt;The message to be written to the slot&lt;/param&gt;
static void WriteMailslot(NativeMethods.SafeMailslotHandle hMailslot, string message)
{
    int cbMessageBytes = 0;         // Message size in bytes
    int cbBytesWritten = 0;         // Number of bytes written to the slot


    byte[] bMessage = Encoding.Unicode.GetBytes(message);
    cbMessageBytes = bMessage.Length;


    bool succeeded = NativeMethods.WriteFile(
        hMailslot,                  // Handle to the mailslot
        bMessage,                   // Message to be written
        cbMessageBytes,             // Number of bytes to write
        out cbBytesWritten,         // Number of bytes written
        IntPtr.Zero                 // Not overlapped
        );
    if (!succeeded || cbMessageBytes != cbBytesWritten)
    {
        Console.WriteLine(&quot;WriteFile failed w/err 0x{0:X}&quot;, 
            Marshal.GetLastWin32Error());
    }
    else
    {
        Console.WriteLine(&quot;The message \&quot;{0}\&quot; is written to the slot&quot;, 
            message);
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt; text-indent:5.0pt">
<span style=""><span style="">c.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Close the slot. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
if (hMailslot != null)
{
    hMailslot.Close();
    hMailslot = null;
}

</pre>
<pre id="codePreview" class="csharp">
if (hMailslot != null)
{
    hMailslot.Close();
    hMailslot = null;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:72.0pt"><span style=""></span></p>
<h2>More Information<span style=""> </span></h2>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/aa365785.aspx">Using
<span class="SpellE">Mailslots</span> / Reading from a Mailslot</a> </span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

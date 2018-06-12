# User impersonation demo (VBImpersonateUser)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* Windows SDK
## Topics
* Impersonation
## IsPublished
* True
## ModifiedDate
* 2012-03-01 11:55:20
## Description

<h1>User impersonation demo (<span class="SpellE">VBImpersonateUser</span>)<span style="">
</span></h1>
<h2>Introduction<span style=""> </span></h2>
<p class="MsoNormal"><span style="">Windows Impersonation is a powerful feature Windows uses frequently in its security model. In general Windows also uses impersonation in its client/server programming model. Impersonation lets a server to temporarily adopt
 the security profile of a client making a resource request. The server can then access resources on behalf of the client, and the OS carries out the access validations.
</span></p>
<p class="MsoNormal"><span style="">A server impersonates a client only within the thread that makes the impersonation request. Thread-control data structures contain an optional entry for an impersonation token. However, a thread's primary token, which represents
 the thread's real security credentials, is always accessible in the process's control structure.
</span></p>
<p class="MsoNormal"><span style="">After the server thread finishes its task, it reverts to its primary security profile. These forms of impersonation are convenient for carrying out specific actions at the request of a client and for ensuring that object
 accesses are audited correctly. </span></p>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal"><span style="">In this code sample we use the <span class="SpellE">
<b style="">LogonUser</b></span> API and the <span class="SpellE"><b style="">WindowsIdentity</b>.<b style="">Impersonate</b></span> method to impersonate the user represented by the specified user token. Then display the current user via the
<span class="SpellE"><b style="">WindowsIdentity.GetCurrent</b></span> method to show user impersonation.
<span class="SpellE"><b style="">LogonUser</b></span> can only be used to log onto the local machine; it cannot log you onto a remote computer. The account that you use in the
<span class="SpellE"><b style="">LogonUser</b></span> call must also be known to the local machine, either as a local account or as a domain account that is visible to the local computer. If
<span class="SpellE"><b style="">LogonUser</b></span> is successful, then it will give you an access token that specifies the credentials of the user account you chose.
</span></p>
<h2>Running the Sample:<span style=""> </span></h2>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal">P<span style="">ress <b style="">F5</b> to run this application, you will see following instruction.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53338/1/image.png" alt="" width="390" height="83" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">Type a valid local account or domain account, and then you will see
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53339/1/image.png" alt="" width="390" height="179" align="middle">
</span><span style=""></span></p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoListParagraph" style="margin-left:54.0pt"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Gather the credential information of the impersonated user.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' Get user's password with SecureString
''' &lt;/summary&gt;
''' &lt;returns&gt;&lt;/returns&gt;
Public Function GetPassword() As SecureString
    Dim password As New SecureString()


    ' Get the first character of the password
    Dim nextKey As ConsoleKeyInfo = Console.ReadKey(True)
    Do While nextKey.Key &lt;&gt; ConsoleKey.Enter
        If nextKey.Key = ConsoleKey.Backspace Then
            If password.Length &gt; 0 Then
                password.RemoveAt(password.Length - 1)
                ' Erase the last * as well
                Console.Write(nextKey.KeyChar)
                Console.Write(&quot; &quot;)
                Console.Write(nextKey.KeyChar)
            End If
        Else
            password.AppendChar(nextKey.KeyChar)
            Console.Write(&quot;*&quot;)
        End If
        nextKey = Console.ReadKey(True)
    Loop
    Console.WriteLine()


    ' Lock the password down
    password.MakeReadOnly()
    Return password
End Function

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' Get user's password with SecureString
''' &lt;/summary&gt;
''' &lt;returns&gt;&lt;/returns&gt;
Public Function GetPassword() As SecureString
    Dim password As New SecureString()


    ' Get the first character of the password
    Dim nextKey As ConsoleKeyInfo = Console.ReadKey(True)
    Do While nextKey.Key &lt;&gt; ConsoleKey.Enter
        If nextKey.Key = ConsoleKey.Backspace Then
            If password.Length &gt; 0 Then
                password.RemoveAt(password.Length - 1)
                ' Erase the last * as well
                Console.Write(nextKey.KeyChar)
                Console.Write(&quot; &quot;)
                Console.Write(nextKey.KeyChar)
            End If
        Else
            password.AppendChar(nextKey.KeyChar)
            Console.Write(&quot;*&quot;)
        End If
        nextKey = Console.ReadKey(True)
    Loop
    Console.WriteLine()


    ' Lock the password down
    password.MakeReadOnly()
    Return password
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:54.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:54.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:54.0pt"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">P/Invoke <span class="SpellE">LogonUser</span> with the credential information to get a token
<span class="GramE">for<span style="">&nbsp; </span>the</span> user. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' The LogonUser function attempts to log a user on to the local computer.
''' The local computer is the computer from which LogonUser was called.
''' You cannot use LogonUser to log on to a remote computer. You specify 
''' the user with a user name and domain and authenticate the user with a
''' plaintext password. If the function succeeds, you receive a handle to 
''' a token that represents the logged-on user. You can then use this token 
''' handle to impersonate the specified user or, in most cases, to create 
''' a process that runs in the context of the specified user.
''' &lt;/summary&gt;
''' &lt;param name=&quot;lpszUsername&quot;&gt;he name of the user&lt;/param&gt;
''' &lt;param name=&quot;lpszDomain&quot;&gt;The name of the domain&lt;/param&gt;
''' &lt;param name=&quot;lpszPassword&quot;&gt;The user's password&lt;/param&gt;
''' &lt;param name=&quot;dwLogonType&quot;&gt;The type of logon operation to perform&lt;/param&gt;
''' &lt;param name=&quot;dwLogonProvider&quot;&gt;The logon provider&lt;/param&gt;
''' &lt;param name=&quot;phToken&quot;&gt;Token handle of the specified user&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
&lt;DllImport(&quot;advapi32.dll&quot;, SetLastError:=True, CharSet:=CharSet.Auto)&gt;
Friend Shared Function LogonUser(&lt;MarshalAs(UnmanagedType.LPWStr)&gt; ByVal lpszUsername As String,
                                 &lt;MarshalAs(UnmanagedType.LPWStr)&gt; ByVal lpszDomain As String,
                                 ByVal lpszPassword As IntPtr,
                                 ByVal dwLogonType As LogonType,
                                 ByVal dwLogonProvider As LogonProvider,
                                 &lt;Out()&gt; ByRef phToken As IntPtr) As Boolean

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' The LogonUser function attempts to log a user on to the local computer.
''' The local computer is the computer from which LogonUser was called.
''' You cannot use LogonUser to log on to a remote computer. You specify 
''' the user with a user name and domain and authenticate the user with a
''' plaintext password. If the function succeeds, you receive a handle to 
''' a token that represents the logged-on user. You can then use this token 
''' handle to impersonate the specified user or, in most cases, to create 
''' a process that runs in the context of the specified user.
''' &lt;/summary&gt;
''' &lt;param name=&quot;lpszUsername&quot;&gt;he name of the user&lt;/param&gt;
''' &lt;param name=&quot;lpszDomain&quot;&gt;The name of the domain&lt;/param&gt;
''' &lt;param name=&quot;lpszPassword&quot;&gt;The user's password&lt;/param&gt;
''' &lt;param name=&quot;dwLogonType&quot;&gt;The type of logon operation to perform&lt;/param&gt;
''' &lt;param name=&quot;dwLogonProvider&quot;&gt;The logon provider&lt;/param&gt;
''' &lt;param name=&quot;phToken&quot;&gt;Token handle of the specified user&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
&lt;DllImport(&quot;advapi32.dll&quot;, SetLastError:=True, CharSet:=CharSet.Auto)&gt;
Friend Shared Function LogonUser(&lt;MarshalAs(UnmanagedType.LPWStr)&gt; ByVal lpszUsername As String,
                                 &lt;MarshalAs(UnmanagedType.LPWStr)&gt; ByVal lpszDomain As String,
                                 ByVal lpszPassword As IntPtr,
                                 ByVal dwLogonType As LogonType,
                                 ByVal dwLogonProvider As LogonProvider,
                                 &lt;Out()&gt; ByRef phToken As IntPtr) As Boolean

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:54.0pt"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Pass the token to <span class="SpellE"><b style="">WindowsIdentity.Impersonate</b></span> and get the impersonation context.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim passwordPtr As IntPtr = IntPtr.Zero
Dim tokenHandle As IntPtr
Dim context As WindowsImpersonationContext = Nothing




Try
    ' Convert the password to a string
    passwordPtr = Marshal.SecureStringToBSTR(password)
    Dim handle As IntPtr = IntPtr.Zero


    ' Attempts to log a user on to the local computer
    If Not NativeMethods.LogonUser(userName, domain, passwordPtr, logonMethod, provider, tokenHandle) Then
        Throw New Win32Exception()
    Else
        context = WindowsIdentity.Impersonate(tokenHandle)


        ' Call out to the work function
        Return impersonationWork(parameter)


    End If
Finally
    ' Erase the memory that the password was stored in
    If Not IntPtr.Zero.Equals(passwordPtr) Then
        Marshal.ZeroFreeBSTR(passwordPtr)
    End If


    ' Clean up
    If context IsNot Nothing Then
        context.Undo()
        context = Nothing
    End If
End Try

</pre>
<pre id="codePreview" class="vb">
Dim passwordPtr As IntPtr = IntPtr.Zero
Dim tokenHandle As IntPtr
Dim context As WindowsImpersonationContext = Nothing




Try
    ' Convert the password to a string
    passwordPtr = Marshal.SecureStringToBSTR(password)
    Dim handle As IntPtr = IntPtr.Zero


    ' Attempts to log a user on to the local computer
    If Not NativeMethods.LogonUser(userName, domain, passwordPtr, logonMethod, provider, tokenHandle) Then
        Throw New Win32Exception()
    Else
        context = WindowsIdentity.Impersonate(tokenHandle)


        ' Call out to the work function
        Return impersonationWork(parameter)


    End If
Finally
    ' Erase the memory that the password was stored in
    If Not IntPtr.Zero.Equals(passwordPtr) Then
        Marshal.ZeroFreeBSTR(passwordPtr)
    End If


    ' Clean up
    If context IsNot Nothing Then
        context.Undo()
        context = Nothing
    End If
End Try

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:54.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:54.0pt"><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Undo impersonation. (<span class="SpellE"><b style="">WindowsImpersonationContext.Undo</b></span>)
</span></p>
<h2>More Information<span style=""> </span></h2>
<p class="MsoNormal"><span style=""><a href="http://blogs.msdn.com/shawnfa/archive/2005/03/24/401905.aspx">Safe Impersonation
<span class="GramE">With</span> Whidbey</a> </span></p>
<p class="MsoNormal"><span style=""><a href="http://blogs.msdn.com/shawnfa/archive/2005/03/21/400088.aspx">How to Impersonate</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

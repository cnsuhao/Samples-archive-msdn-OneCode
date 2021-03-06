# Check OS bitness in VB.NET (VBCheckOSBitness)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows SDK
## Topics
* OS bitness
## IsPublished
* True
## ModifiedDate
* 2012-03-11 06:51:33
## Description

<h1>Check OS <span class="SpellE">bitness</span> in <span style="">VB</span> (<span class="SpellE"><span style="">VB</span>CheckOSBitness</span>)<span style="">
</span></h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span style="">The code sample demonstrates how to determine whether the operating system of the current machine or any remote machine is a 64-bit operating system.</span><span style="">
</span></p>
<h2>Running the Sample:<span style=""> </span></h2>
<p class="MsoNormal"><span style="">When the current OS is 64bit, if you press <b style="">
F5</b> to run this application, you will see following result. </span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/54156/1/image.png" alt="" width="339" height="126" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">If the OS is 32bit, you will see </span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/54157/1/image.png" alt="" width="341" height="119" align="middle">
</span><span style=""></span></p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoNormal"><span style="">The sample introduces two solutions of detecting programmatically whether you are running on 64-bit operating system.
</span></p>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Use the <b style="">IsWow64Process</b> function.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">To compile an application that uses this function, define _WIN32_WINNT as 0x0501 or later. For more information, see Using the Windows Headers:
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa383745(v=vs.85).aspx">
http://msdn.microsoft.com/en-us/library/windows/desktop/aa383745(v=vs.85).aspx</a>
</span></p>
<p class="MsoListParagraphCxSpLast"><span style="">For compatibility with operating systems that do not support this function, call
<span class="SpellE">GetProcAddress</span> to detect whether IsWow64Process is implemented in Kernel32.dll. If
<span class="SpellE">GetProcAddress</span> succeeds, it is safe to call this function. Otherwise, WOW64 is not present. Note that this technique is not a reliable way to detect whether the operating system is a 64-bit version of Windows because the Kernel32.dll
 in current versions of 32-bit Windows also contains this function. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
#Region &quot;Is64BitOS (IsWow64Process)&quot;


    ''' &lt;summary&gt;
    ''' The function determines whether the current operating system is a 
    ''' 64-bit operating system.
    ''' &lt;/summary&gt;
    ''' &lt;returns&gt;
    ''' The function returns true if the operating system is 64-bit; 
    ''' otherwise, it returns false.
    ''' &lt;/returns&gt;
    Public Function Is64BitOS() As Boolean
        If IntPtr.Size = 8 Then ' 64-bit programs run only on Win64
            Return True
        Else ' 32-bit programs run on both 32-bit and 64-bit Windows
            ' Detect whether the current process is a 32-bit process 
            ' running on a 64-bit system.
            Dim flag As Boolean
            Return ((DoesWin32MethodExist(&quot;kernel32.dll&quot;, &quot;IsWow64Process&quot;) AndAlso IsWow64Process(GetCurrentProcess(), flag)) AndAlso flag)
        End If
    End Function


    ''' &lt;summary&gt;
    ''' The function determins whether a method exists in the export 
    ''' table of a certain module.
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;moduleName&quot;&gt;The name of the module&lt;/param&gt;
    ''' &lt;param name=&quot;methodName&quot;&gt;The name of the method&lt;/param&gt;
    ''' &lt;returns&gt;
    ''' The function returns true if the method specified by methodName 
    ''' exists in the export table of the module specified by moduleName.
    ''' &lt;/returns&gt;
    Private Function DoesWin32MethodExist(ByVal moduleName As String, ByVal methodName As String) As Boolean
        Dim moduleHandle As IntPtr = GetModuleHandle(moduleName)
        If moduleHandle = IntPtr.Zero Then
            Return False
        End If
        Return (GetProcAddress(moduleHandle, methodName) &lt;&gt; IntPtr.Zero)
    End Function


    &lt;DllImport(&quot;kernel32.dll&quot;, CharSet:=CharSet.Auto, SetLastError:=True)&gt; _
     Function GetCurrentProcess() As IntPtr
    End Function


    &lt;DllImport(&quot;kernel32.dll&quot;, CharSet:=CharSet.Auto, SetLastError:=True)&gt; _
     Function GetModuleHandle(ByVal moduleName As String) As IntPtr
    End Function


    &lt;DllImport(&quot;kernel32.dll&quot;, CharSet:=CharSet.Auto, SetLastError:=True)&gt; _
     Function GetProcAddress(ByVal hModule As IntPtr, &lt;MarshalAs(UnmanagedType.LPStr)&gt; ByVal procName As String) As IntPtr
    End Function


    &lt;DllImport(&quot;kernel32.dll&quot;, CharSet:=CharSet.Auto, SetLastError:=True)&gt; _
    Function IsWow64Process(ByVal hProcess As IntPtr, &lt;System.Runtime.InteropServices.Out()&gt; ByRef wow64Process As Boolean) As &lt;MarshalAs(UnmanagedType.Bool)&gt; Boolean
    End Function


#End Region

</pre>
<pre id="codePreview" class="vb">
#Region &quot;Is64BitOS (IsWow64Process)&quot;


    ''' &lt;summary&gt;
    ''' The function determines whether the current operating system is a 
    ''' 64-bit operating system.
    ''' &lt;/summary&gt;
    ''' &lt;returns&gt;
    ''' The function returns true if the operating system is 64-bit; 
    ''' otherwise, it returns false.
    ''' &lt;/returns&gt;
    Public Function Is64BitOS() As Boolean
        If IntPtr.Size = 8 Then ' 64-bit programs run only on Win64
            Return True
        Else ' 32-bit programs run on both 32-bit and 64-bit Windows
            ' Detect whether the current process is a 32-bit process 
            ' running on a 64-bit system.
            Dim flag As Boolean
            Return ((DoesWin32MethodExist(&quot;kernel32.dll&quot;, &quot;IsWow64Process&quot;) AndAlso IsWow64Process(GetCurrentProcess(), flag)) AndAlso flag)
        End If
    End Function


    ''' &lt;summary&gt;
    ''' The function determins whether a method exists in the export 
    ''' table of a certain module.
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;moduleName&quot;&gt;The name of the module&lt;/param&gt;
    ''' &lt;param name=&quot;methodName&quot;&gt;The name of the method&lt;/param&gt;
    ''' &lt;returns&gt;
    ''' The function returns true if the method specified by methodName 
    ''' exists in the export table of the module specified by moduleName.
    ''' &lt;/returns&gt;
    Private Function DoesWin32MethodExist(ByVal moduleName As String, ByVal methodName As String) As Boolean
        Dim moduleHandle As IntPtr = GetModuleHandle(moduleName)
        If moduleHandle = IntPtr.Zero Then
            Return False
        End If
        Return (GetProcAddress(moduleHandle, methodName) &lt;&gt; IntPtr.Zero)
    End Function


    &lt;DllImport(&quot;kernel32.dll&quot;, CharSet:=CharSet.Auto, SetLastError:=True)&gt; _
     Function GetCurrentProcess() As IntPtr
    End Function


    &lt;DllImport(&quot;kernel32.dll&quot;, CharSet:=CharSet.Auto, SetLastError:=True)&gt; _
     Function GetModuleHandle(ByVal moduleName As String) As IntPtr
    End Function


    &lt;DllImport(&quot;kernel32.dll&quot;, CharSet:=CharSet.Auto, SetLastError:=True)&gt; _
     Function GetProcAddress(ByVal hModule As IntPtr, &lt;MarshalAs(UnmanagedType.LPStr)&gt; ByVal procName As String) As IntPtr
    End Function


    &lt;DllImport(&quot;kernel32.dll&quot;, CharSet:=CharSet.Auto, SetLastError:=True)&gt; _
    Function IsWow64Process(ByVal hProcess As IntPtr, &lt;System.Runtime.InteropServices.Out()&gt; ByRef wow64Process As Boolean) As &lt;MarshalAs(UnmanagedType.Bool)&gt; Boolean
    End Function


#End Region

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Query the <b style="">Win32_Processor</b> WMI class's
<span class="SpellE"><b style="">AddressWidth</b></span> property. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">The Win32_Processor WMI class represents a device that can interpret a sequence of instructions on a computer running on a Windows operating system. On a multiprocessor computer, one instance of the Win32_Processor
 class exists for each processor. </span></p>
<p class="MsoListParagraphCxSpLast"><span style="">On a 32-bit operating system, the return value of
<span class="SpellE">AddressWidth</span> is 32 and on a 64-bit operating system it is 64. This property is inherited from
<span class="SpellE">CIM_<span class="GramE">Processor</span></span><span class="GramE">(</span>Details:
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa387978(v=vs.85).aspx">
http://msdn.microsoft.com/en-us/library/windows/desktop/aa387978(v=vs.85).aspx</a>).
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
#Region &quot;Is64BitOS (WMI)&quot;


    ''' &lt;summary&gt;
    ''' The function determines whether the operating system of the 
    ''' current machine of any remote machine is a 64-bit operating 
    ''' system through Windows Management Instrumentation (WMI).
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;machineName&quot;&gt;
    ''' The full computer name or IP address of the target machine. &quot;.&quot; 
    ''' or null means the local machine. 
    ''' &lt;/param&gt;
    ''' &lt;param name=&quot;userName&quot;&gt;
    ''' The user name you need for a connection. A null value indicates 
    ''' the current security context. If the user name is from a domain 
    ''' other than the current domain, the string should contain the 
    ''' domain name and user name, separated by a backslash: string 
    ''' 'username' = &quot;DomainName\\UserName&quot;. 
    ''' &lt;/param&gt;
    ''' &lt;param name=&quot;password&quot;&gt;
    ''' The password for the specified user.
    ''' &lt;/param&gt;
    ''' &lt;returns&gt;
    ''' The function returns true if the operating system is 64-bit; 
    ''' otherwise, it returns false.
    ''' &lt;/returns&gt;
    ''' &lt;exception cref=&quot;System.Management.ManagementException&quot;&gt;
    ''' The ManagementException exception is generally thrown with the  
    ''' error message &quot;User credentials cannot be used for local 
    ''' connections&quot;. To solve it, do not specify userName and password
    ''' when machineName refers to the local computer.
    ''' &lt;/exception&gt;
    ''' &lt;exception cref=&quot;System.UnauthorizedAccessException&quot;&gt;
    ''' This exception is usually caused by incorrect user name or 
    ''' password.
    ''' &lt;/exception&gt;
    ''' &lt;exception cref=&quot;System.Runtime.InteropServices.COMException&quot;&gt;
    ''' A common error accompanied with the COMException is &quot;The RPC 
    ''' server is unavailable. (Exception from HRESULT: 0x800706BA)&quot;. 
    ''' This is usually caused by the firewall on the target machine that 
    ''' blocks the WMI connection or some network problem.
    ''' &lt;/exception&gt;
    Public Function Is64BitOS(ByVal machineName As String, ByVal userName As String, ByVal password As String) As Boolean
        Dim options As ConnectionOptions = Nothing


        ' Build a ConnectionOptions object for the remote connection 
        ' if you plan to connect to the remote with a different user 
        ' name and password than the one you are currently using.
        If Not String.IsNullOrEmpty(userName) Then
            options = New ConnectionOptions()
            options.Username = userName
            options.Password = password
        End If
        ' Else the connection will use the current user token.


        ' Make a connection to the target computer.
        If String.IsNullOrEmpty(machineName) Then
            machineName = &quot;.&quot;
        End If
        Dim path As String = &quot;\\&quot; & machineName & &quot;\root\cimv2&quot;
        Dim scope As New ManagementScope(path, options)
        scope.Connect()


        ' Query Win32_Processor.AddressWidth which dicates the current 
        ' operating mode of the processor (on a 32-bit OS, it would be 
        ' &quot;32&quot;; on a 64-bit OS, it would be &quot;64&quot;).
        ' Note: Win32_Processor.DataWidth indicates the capability of 
        ' the processor. On a 64-bit processor, it is &quot;64&quot;.
        ' Note: Win32_OperatingSystem.OSArchitecture tells the bitness
        ' of OS too. On a 32-bit OS, it would be &quot;32-bit&quot;. However, it 
        ' is only available on Windows Vista and newer OS.
        Dim query As New ObjectQuery(&quot;SELECT AddressWidth FROM Win32_Processor&quot;)


        ' Perform the query and get the result.
        Dim searcher As New ManagementObjectSearcher(scope, query)
        Dim queryCollection As ManagementObjectCollection = searcher.Get()
        For Each queryObj As ManagementObject In queryCollection
            If queryObj(&quot;AddressWidth&quot;).ToString() = &quot;64&quot; Then
                Return True
            End If
        Next queryObj


        Return False
    End Function


#End Region

</pre>
<pre id="codePreview" class="vb">
#Region &quot;Is64BitOS (WMI)&quot;


    ''' &lt;summary&gt;
    ''' The function determines whether the operating system of the 
    ''' current machine of any remote machine is a 64-bit operating 
    ''' system through Windows Management Instrumentation (WMI).
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;machineName&quot;&gt;
    ''' The full computer name or IP address of the target machine. &quot;.&quot; 
    ''' or null means the local machine. 
    ''' &lt;/param&gt;
    ''' &lt;param name=&quot;userName&quot;&gt;
    ''' The user name you need for a connection. A null value indicates 
    ''' the current security context. If the user name is from a domain 
    ''' other than the current domain, the string should contain the 
    ''' domain name and user name, separated by a backslash: string 
    ''' 'username' = &quot;DomainName\\UserName&quot;. 
    ''' &lt;/param&gt;
    ''' &lt;param name=&quot;password&quot;&gt;
    ''' The password for the specified user.
    ''' &lt;/param&gt;
    ''' &lt;returns&gt;
    ''' The function returns true if the operating system is 64-bit; 
    ''' otherwise, it returns false.
    ''' &lt;/returns&gt;
    ''' &lt;exception cref=&quot;System.Management.ManagementException&quot;&gt;
    ''' The ManagementException exception is generally thrown with the  
    ''' error message &quot;User credentials cannot be used for local 
    ''' connections&quot;. To solve it, do not specify userName and password
    ''' when machineName refers to the local computer.
    ''' &lt;/exception&gt;
    ''' &lt;exception cref=&quot;System.UnauthorizedAccessException&quot;&gt;
    ''' This exception is usually caused by incorrect user name or 
    ''' password.
    ''' &lt;/exception&gt;
    ''' &lt;exception cref=&quot;System.Runtime.InteropServices.COMException&quot;&gt;
    ''' A common error accompanied with the COMException is &quot;The RPC 
    ''' server is unavailable. (Exception from HRESULT: 0x800706BA)&quot;. 
    ''' This is usually caused by the firewall on the target machine that 
    ''' blocks the WMI connection or some network problem.
    ''' &lt;/exception&gt;
    Public Function Is64BitOS(ByVal machineName As String, ByVal userName As String, ByVal password As String) As Boolean
        Dim options As ConnectionOptions = Nothing


        ' Build a ConnectionOptions object for the remote connection 
        ' if you plan to connect to the remote with a different user 
        ' name and password than the one you are currently using.
        If Not String.IsNullOrEmpty(userName) Then
            options = New ConnectionOptions()
            options.Username = userName
            options.Password = password
        End If
        ' Else the connection will use the current user token.


        ' Make a connection to the target computer.
        If String.IsNullOrEmpty(machineName) Then
            machineName = &quot;.&quot;
        End If
        Dim path As String = &quot;\\&quot; & machineName & &quot;\root\cimv2&quot;
        Dim scope As New ManagementScope(path, options)
        scope.Connect()


        ' Query Win32_Processor.AddressWidth which dicates the current 
        ' operating mode of the processor (on a 32-bit OS, it would be 
        ' &quot;32&quot;; on a 64-bit OS, it would be &quot;64&quot;).
        ' Note: Win32_Processor.DataWidth indicates the capability of 
        ' the processor. On a 64-bit processor, it is &quot;64&quot;.
        ' Note: Win32_OperatingSystem.OSArchitecture tells the bitness
        ' of OS too. On a 32-bit OS, it would be &quot;32-bit&quot;. However, it 
        ' is only available on Windows Vista and newer OS.
        Dim query As New ObjectQuery(&quot;SELECT AddressWidth FROM Win32_Processor&quot;)


        ' Perform the query and get the result.
        Dim searcher As New ManagementObjectSearcher(scope, query)
        Dim queryCollection As ManagementObjectCollection = searcher.Get()
        For Each queryObj As ManagementObject In queryCollection
            If queryObj(&quot;AddressWidth&quot;).ToString() = &quot;64&quot; Then
                Return True
            End If
        Next queryObj


        Return False
    End Function


#End Region

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information<span style=""> </span></h2>
<p class="MsoNormal"><span style="">How to detect programmatically whether you are running on 64-bit Windows</span><span style="">
</span></p>
<p class="MsoNormal"><span style=""><a href="http://blogs.msdn.com/oldnewthing/archive/2005/02/01/364563.aspx">http://blogs.msdn.com/oldnewthing/archive/2005/02/01/364563.aspx</a>
</span></p>
<p class="MsoNormal"><span style="">MSDN: Win32_Processor Class</span><span style="">
</span></p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/aa394373(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa394373(VS.85).aspx</a>
</span></p>
<p class="MsoNormal"><span style="">MSDN: Win32_OperatingSystem Class</span><span style="">
</span></p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/aa394239(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa394239(VS.85).aspx</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

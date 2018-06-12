# Check OS bitness in C++ (CppCheckOSBitness)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Windows General
## Topics
* OS bitness
## IsPublished
* True
## ModifiedDate
* 2011-05-05 04:20:39
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CppCheckOSBitness Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The code sample demonstrates how to determine whether the operating system of <br>
the current machine or any remote machine is a 64-bit operating system.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
The following steps walk through a demonstration of the sample.<br>
<br>
Step1. After you successfully build the sample project in Visual Studio 2008, <br>
you will get an application: CppCheckOSBitness.exe. <br>
<br>
Step2. Run the application in a command prompt (cmd.exe) on a 32-bit <br>
operating system (e.g. Windows 7 x86). The application prints the following <br>
content in the command prompt:<br>
<br>
&nbsp;Current OS is not 64-bit<br>
&nbsp;Current OS is not 64-bit<br>
<br>
It dictates that the current operating system is not a 64-bit operating <br>
system.<br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
The sample introduces two solutions of detecting programmatically whether you <br>
are running on 64-bit operating system.<br>
<br>
Solution 1. Use the IsWow64Process function<br>
<br>
&nbsp; &nbsp;//<br>
&nbsp; &nbsp;// &nbsp; FUNCTION: Is64BitOS()<br>
&nbsp; &nbsp;//<br>
&nbsp; &nbsp;// &nbsp; PURPOSE: The function determines whether the current operating system is
<br>
&nbsp; &nbsp;// &nbsp; a 64-bit operating system.<br>
&nbsp; &nbsp;//<br>
&nbsp; &nbsp;// &nbsp; RETURN VALUE: The function returns TRUE if the operating system is
<br>
&nbsp; &nbsp;// &nbsp; 64-bit; otherwise, it returns FALSE.<br>
&nbsp; &nbsp;//<br>
&nbsp; &nbsp;BOOL Is64BitOS()<br>
<br>
If the running process is a 64-bit process, the operating system must be a <br>
64-bit operating system.<br>
<br>
#if defined(_WIN64)<br>
&nbsp; &nbsp;return TRUE; &nbsp; // 64-bit programs run only on Win64<br>
<br>
To detect programmatically whether your 32-bit program is running on 64-bit <br>
operating system, you can use the IsWow64Process function. <br>
<br>
#elif defined(_WIN32)<br>
&nbsp; &nbsp;// 32-bit programs run on both 32-bit and 64-bit Windows<br>
&nbsp; &nbsp;BOOL f64bitOS = FALSE;<br>
&nbsp; &nbsp;return (SafeIsWow64Process(GetCurrentProcess(), &f64bitOS) && f64bitOS);<br>
<br>
SafeIsWow64Process is a wrapper of the IsWow64Process API. It determines <br>
whether the specified process is running under WOW64. IsWow64Process does not <br>
exist prior to Windows XP with SP2 and Window Server 2003 &nbsp;with SP1. For <br>
compatibility with operating systems that do not support IsWow64Process, call <br>
GetProcAddress to detect whether IsWow64Process is implemented in <br>
Kernel32.dll. If GetProcAddress succeeds, it is safe to call IsWow64Process <br>
dynamically. Otherwise, WOW64 is not present.<br>
<br>
Solution 2. Query the Win32_Processor WMI class's AddressWidth property<br>
<br>
&nbsp; &nbsp;//<br>
&nbsp; &nbsp;// &nbsp; FUNCTION: Is64BitOS(LPCWSTR, LPCWSTR, LPCWSTR)<br>
&nbsp; &nbsp;//<br>
&nbsp; &nbsp;// &nbsp; PURPOSE: The function determines whether the operating system of the
<br>
&nbsp; &nbsp;// &nbsp; current machine of any remote machine is a 64-bit operating system
<br>
&nbsp; &nbsp;// &nbsp; through Windows Management Instrumentation (WMI).<br>
&nbsp; &nbsp;//<br>
&nbsp; &nbsp;// &nbsp; PARAMETERS:<br>
&nbsp; &nbsp;// &nbsp; * pszMachineName - the full computer name or IP address of the target
<br>
&nbsp; &nbsp;// &nbsp; &nbsp; machine. &quot;.&quot; or NULL means the local machine.
<br>
&nbsp; &nbsp;// &nbsp; * pszUserName - the user name you need for a connection. A null value
<br>
&nbsp; &nbsp;// &nbsp; &nbsp; indicates the current security context. If the user name is from a
<br>
&nbsp; &nbsp;// &nbsp; &nbsp; domain other than the current domain, the string should contain the
<br>
&nbsp; &nbsp;// &nbsp; &nbsp; domain name and user name, separated by a backslash: string 'username'
<br>
&nbsp; &nbsp;// &nbsp; &nbsp; = &quot;DomainName\\UserName&quot;. <br>
&nbsp; &nbsp;// &nbsp; * pszPassword - the password for the specified user.<br>
&nbsp; &nbsp;//<br>
&nbsp; &nbsp;// &nbsp; RETURN VALUE: The function returns true if the operating system is
<br>
&nbsp; &nbsp;// &nbsp; 64-bit; otherwise, it returns false.<br>
&nbsp; &nbsp;//<br>
&nbsp; &nbsp;// &nbsp; EXCEPTION: If this function fails, it throws a C&#43;&#43; exception which
<br>
&nbsp; &nbsp;// &nbsp; contains the HRESULT of the failure. For example, <br>
&nbsp; &nbsp;// &nbsp; WBEM_E_LOCAL_CREDENTIALS (0x80041064) is thrown when user credentials
<br>
&nbsp; &nbsp;// &nbsp; (pszUserName, pszPassword) are specified for local connections.<br>
&nbsp; &nbsp;// &nbsp; COR_E_UNAUTHORIZEDACCESS (0x80070005) is thrown because of incorrect
<br>
&nbsp; &nbsp;// &nbsp; user name or password. <br>
&nbsp; &nbsp;// &nbsp; RPC_S_SERVER_UNAVAILABLE (0x800706BA) is usually caused by the firewall
<br>
&nbsp; &nbsp;// &nbsp; on the target machine that blocks the WMI connection or some network
<br>
&nbsp; &nbsp;// &nbsp; problem.<br>
&nbsp; &nbsp;//<br>
&nbsp; &nbsp;// &nbsp; EXAMPLE CALL:<br>
&nbsp; &nbsp;// &nbsp; &nbsp; try<br>
&nbsp; &nbsp;// &nbsp; &nbsp; {<br>
&nbsp; &nbsp;// &nbsp; &nbsp; &nbsp; &nbsp; f64bitOS = Is64BitOS(L&quot;.&quot;, NULL, NULL);<br>
&nbsp; &nbsp;// &nbsp; &nbsp; &nbsp; &nbsp; wprintf(L&quot;Current OS %s 64-bit.\n&quot;,
<br>
&nbsp; &nbsp;// &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; f64bitOS ? L&quot;is&quot; : L&quot;is not&quot;);<br>
&nbsp; &nbsp;// &nbsp; &nbsp; }<br>
&nbsp; &nbsp;// &nbsp; &nbsp; catch (HRESULT hr)<br>
&nbsp; &nbsp;// &nbsp; &nbsp; {<br>
&nbsp; &nbsp;// &nbsp; &nbsp; &nbsp; &nbsp; wprintf(L&quot;Is64BitOS failed with HRESULT 0x%08lx\n&quot;, hr);<br>
&nbsp; &nbsp;// &nbsp; &nbsp; }<br>
&nbsp; &nbsp;//<br>
&nbsp; &nbsp;BOOL Is64BitOS(LPCWSTR pszMachineName, LPCWSTR pszUserName, <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;LPCWSTR pszPassword);<br>
<br>
It queries Win32_Processor.AddressWidth which dicates the current operating <br>
mode of the processor (on a 32-bit OS, it would be 32; on a 64-bit OS, it <br>
would be 64). In contrast, Win32_Processor.DataWidth indicates the capability<br>
of the processor. On a 64-bit processor, it is &quot;64&quot;. The OSArchitecture
<br>
property of the Win32_OperatingSystem WMI class can also tell the bitness of <br>
OS. On a 32-bit OS, it would be &quot;32-bit&quot;. However, the property is only
<br>
available on Windows Vista and newer operating systems.<br>
<br>
Note: The first solution of using IsWow64Process is the preferred way to <br>
detect OS bitness of the current system because it is much easier and faster. <br>
The WMI solution is useful when you want to find this information on a remote <br>
system. The remote computer must be configured for remote connections of WMI:<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa389290(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa389290(VS.85).aspx</a><br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
How to detect programmatically whether you are running on 64-bit Windows<br>
<a target="_blank" href="http://blogs.msdn.com/oldnewthing/archive/2005/02/01/364563.aspx">http://blogs.msdn.com/oldnewthing/archive/2005/02/01/364563.aspx</a><br>
<br>
MSDN: Win32_Processor Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa394373(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa394373(VS.85).aspx</a><br>
<br>
MSDN: Win32_OperatingSystem Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa394239(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa394239(VS.85).aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

# Detect the process running platform in C++ (CppPlatformDetector)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Windows General
## Topics
* Platform Detector
## IsPublished
* True
## ModifiedDate
* 2011-05-05 08:47:39
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CppPlatformDetector Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The CppPlatformDetector code sample demonstrates the following tasks related <br>
to platform detection:<br>
<br>
1. Detect the name of the current operating system. <br>
&nbsp; (e.g. &quot;Microsoft Windows 7 Enterprise&quot;)<br>
2. Detect the version of the current operating system.<br>
&nbsp; (e.g. &quot;Microsoft Windows NT 6.1.7600.0&quot;)<br>
3. Determine whether the current operating system is a 64-bit operating <br>
&nbsp; system. <br>
4. Determine whether the current process is a 64-bit process. <br>
5. Determine whether an arbitrary process running on the system is 64-bit. <br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
The following steps walk through a demonstration of the sample.<br>
<br>
Step1. In Visual Studio 2010, configure the sample project to target the x64<br>
platform. After you successfully build the sample project, you will get an <br>
application: CppPlatformDetector.exe. <br>
<br>
Step2. Run the application in a command prompt (cmd.exe) on a 64-bit <br>
operating system (e.g. Windows 7 x64 Ultimate). The application prints the <br>
following information in the command prompt:<br>
<br>
&nbsp;Current OS: Microsoft Windows 7 Ultimate<br>
&nbsp;Version: Microsoft Windows NT 6.1.7600.0 Workstation<br>
&nbsp;Current OS is 64-bit<br>
&nbsp;Current process is 64-bit<br>
<br>
It dictates that the current operating system is Microsoft Windows 7 Ultimate. <br>
Its version is 6.1.7600.0. The OS is a workstation instead of a server or <br>
domain controller. The system is 64-bit. The current process is a 64-bit <br>
process. <br>
<br>
Step3. In Task Manager, find a 32-bit process running on the system, and get <br>
its process ID (e.g. 6100). Run CppPlatformDetector.exe with the process ID <br>
as the first argument. For example, <br>
<br>
&nbsp; &nbsp;CppPlatformDetector.exe 6100<br>
<br>
The application will output:<br>
<br>
&nbsp;...<br>
&nbsp;Process 6100 is not 64-bit<br>
<br>
It indicates that the specified process is not a 64-bit process.<br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
A. Get the name of the current operating system. <br>
&nbsp; (e.g. &quot;Microsoft Windows 7 Enterprise&quot;)<br>
<br>
The name of the operating system (e.g. &quot;Microsoft Windows 7 Ultimate&quot;) can be
<br>
retrieved from the Caption property of the Win32_OperatingSystem WMI class <br>
(<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa394239.aspx).">http://msdn.microsoft.com/en-us/library/aa394239.aspx).</a> You can find the C&#43;&#43;
<br>
code that queries the value of Win32_OperatingSystem.Caption in the GetOSName <br>
function of PlatformDetector.h/cpp.<br>
<br>
Alternatively, you can build the string of the operating system name by using <br>
the GetVersionEx, GetSystemMetrics, GetProductInfo, and GetNativeSystemInfo <br>
functions. The MSDN article &quot;Getting the System Version&quot; gives an example:<br>
<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/ms724429.aspx">http://msdn.microsoft.com/en-us/library/ms724429.aspx</a>.'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms724429.aspx">http://msdn.microsoft.com/en-us/library/ms724429.aspx</a>.
 However, the solution <br>
is not flexible for new releases of operating systems. <br>
<br>
--------------------<br>
<br>
B. Get the version of the current operating system.<br>
&nbsp; (e.g. &quot;Microsoft Windows NT 6.1.7600.0&quot;)<br>
<br>
The OSVERSIONINFOEX structure outputted by GetVersionEx tells the major, <br>
minor version numbers (dwMajorVersion, dwMinorVersion), the build number <br>
(dwBuildNumber), and the major, minor version number of the latest Service <br>
Pack (wServicePackMajor, wServicePackMinor). You can use these numbers to <br>
quickly determine what the operating system is, whether a certain Service Pack <br>
is installed, etc. OSVERSIONINFOEX.wProductType can tell whether the <br>
operating system is a workstation or a server or a domain controller. <br>
<br>
The GetOSVersionString function in PlatformDetector.h/cpp retrieves the <br>
concatenated string representation of the platform identifier, version, and <br>
service pack that are currently installed on the operating system. For <br>
example, &quot;Microsoft Windows NT 6.1.7600.0 Workstation&quot;.<br>
<br>
--------------------<br>
<br>
C. Determine the whether the current OS is a 64-bit operating system. &nbsp;<br>
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
64-bit operating system. <br>
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
--------------------<br>
<br>
D. Determine whether the current process or an arbitrary process running on <br>
the system is a 64-bit process. <br>
<br>
If you are determining whether the currently running process is a 64-bit <br>
process, you can use the VC&#43;&#43; preprocessor symbols which get set during the <br>
build to simply return true/false.<br>
<br>
&nbsp; &nbsp;BOOL Is64BitProcess(void)<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp;#if defined(_WIN64)<br>
&nbsp; &nbsp; &nbsp; &nbsp;return TRUE; &nbsp; // 64-bit program<br>
&nbsp; &nbsp;#else<br>
&nbsp; &nbsp; &nbsp; &nbsp;return FALSE;<br>
&nbsp; &nbsp;#endif<br>
&nbsp; &nbsp;}<br>
<br>
If you are detecting whether an arbitrary application running on the system <br>
is a 64-bit process, you need to determine the OS bitness and if it is 64-bit, <br>
call IsWow64Process() with the target process handle.<br>
<br>
&nbsp; &nbsp;BOOL Is64BitProcess(HANDLE hProcess)<br>
&nbsp; &nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;BOOL f64bitProc = FALSE;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;if (Is64BitOS())<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;// On 64bit OS, if a process is not running under Wow64 mode, the
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// process must be a 64bit process.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;f64bitProc = !(SafeIsWow64Process(hProcess, &f64bitProc) && f64bitProc);<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;return f64bitProc;<br>
&nbsp; &nbsp;}<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Getting the System Version<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms724429.aspx">http://msdn.microsoft.com/en-us/library/ms724429.aspx</a><br>
<br>
How to detect programmatically whether you are running on 64-bit Windows<br>
<a target="_blank" href="http://blogs.msdn.com/oldnewthing/archive/2005/02/01/364563.aspx">http://blogs.msdn.com/oldnewthing/archive/2005/02/01/364563.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

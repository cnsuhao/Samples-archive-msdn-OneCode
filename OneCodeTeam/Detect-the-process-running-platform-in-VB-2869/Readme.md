# Detect the process running platform in VB (VBPlatformDetector)
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
* 2011-05-05 09:59:23
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : VBPlatformDetector Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The VBPlatformDetector code sample demonstrates the following tasks related <br>
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
Step1. After you successfully build the sample project in Visual Studio 2010 <br>
targeting the &quot;Any CPU&quot; platform, you will get an application: <br>
VBPlatformDetector.exe. <br>
<br>
Step2. Run the application in a command prompt (cmd.exe) on a 64-bit <br>
operating system (e.g. Windows 7 x64 Ultimate). The application prints the <br>
following information in the command prompt:<br>
<br>
&nbsp;Current OS: Microsoft Windows 7 Ultimate<br>
&nbsp;Version: Microsoft Windows NT 6.1.7600.0<br>
&nbsp;Current OS is 64-bit<br>
&nbsp;Current process is 64-bit<br>
<br>
It dictates that the current operating system is Microsoft Windows 7 Ultimate. <br>
Its version is 6.1.7600.0. The OS is a workstation instead of a server or <br>
domain controller. The system is 64-bit. The current process is a 64-bit <br>
process. <br>
<br>
Step3. In Task Manager, find a 32-bit process running on the system, and get <br>
its process ID (e.g. 6100). Run VBPlatformDetector.exe with the process ID <br>
as the first argument. For example, <br>
<br>
&nbsp; &nbsp;VBPlatformDetector.exe 6100<br>
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
(<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa394239.aspx).">http://msdn.microsoft.com/en-us/library/aa394239.aspx).</a> You can find the VC#
<br>
code that queries the value of Win32_OperatingSystem.Caption in the GetOSName <br>
method.<br>
<br>
Alternatively, you can build the string of the operating system name by using <br>
the GetVersionEx, GetSystemMetrics, GetProductInfo, and GetNativeSystemInfo <br>
functions. The MSDN article &quot;Getting the System Version&quot; gives an C&#43;&#43; example:<br>
<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/ms724429.aspx">http://msdn.microsoft.com/en-us/library/ms724429.aspx</a>.'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms724429.aspx">http://msdn.microsoft.com/en-us/library/ms724429.aspx</a>.
 However, the solution <br>
is not flexible for new releases of operating systems. <br>
<br>
--------------------<br>
<br>
B. Get the version of the current operating system.<br>
&nbsp; (e.g. &quot;Microsoft Windows NT 6.1.7600.0&quot;)<br>
<br>
The System.Environment.OSVersion property returns an OperatingSystem object <br>
that contains the current platform identifier and version numbers.<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.environment.osversion.aspx">http://msdn.microsoft.com/en-us/library/system.environment.osversion.aspx</a><br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.operatingsystem.aspx">http://msdn.microsoft.com/en-us/library/system.operatingsystem.aspx</a><br>
You can use these numbers to quickly determine what the operating system is, <br>
whether a certain Service Pack is installed, etc. <br>
<br>
In the code sample, Environment.OSVersion.VersionString gets the concatenated <br>
string representation of the platform identifier, version, and service pack <br>
that are currently installed on the operating system. For example, <br>
&quot;Microsoft Windows NT 6.1.7600.0&quot;.<br>
<br>
--------------------<br>
<br>
C. Determine the whether the current OS is a 64-bit operating system. &nbsp;<br>
<br>
The Environment.Is64BitOperatingSystem property new in .NET Framework 4 <br>
determines whether the current operating system is a 64-bit operating system.<br>
<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/system.environment.is64bitoperatingsystem.aspx">http://msdn.microsoft.com/en-us/library/system.environment.is64bitoperatingsystem.aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.environment.is64bitoperatingsystem.aspx">http://msdn.microsoft.com/en-us/library/system.environment.is64bitoperatingsystem.aspx</a><br>
<br>
The implementation of Environment.Is64BitOperatingSystem is based on this <br>
logic:<br>
<br>
&nbsp;If the running process is a 64-bit process, the operating system must be a <br>
&nbsp;64-bit operating system. <br>
<br>
&nbsp;If the running process is a 32-bit process, the process may be running in a
<br>
&nbsp;32-bit operating system, or under WOW64 of a 64-bit operating system. To <br>
&nbsp;detect whether the 32-bit program is running in a 64-bit operating system, <br>
&nbsp;you can use the IsWow64Process function. <br>
<br>
&nbsp; &nbsp;Dim flag As Boolean<br>
&nbsp; &nbsp;Return ((Win32Native.DoesWin32MethodExist(&quot;kernel32.dll&quot;, &quot;IsWow64Process&quot;) _<br>
&nbsp; &nbsp; &nbsp; &nbsp;AndAlso Win32Native.IsWow64Process(Win32Native.GetCurrentProcess, flag)) _<br>
&nbsp; &nbsp; &nbsp; &nbsp;AndAlso flag)<br>
<br>
--------------------<br>
<br>
D. Determine whether the current process or an arbitrary process running on <br>
the system is a 64-bit process. <br>
<br>
If you are determining whether the currently running process is a 64-bit <br>
process, you can use the Environment.Is64BitProcess property new in .NET <br>
Framework 4. <br>
<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/system.environment.is64bitprocess.aspx">http://msdn.microsoft.com/en-us/library/system.environment.is64bitprocess.aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.environment.is64bitprocess.aspx">http://msdn.microsoft.com/en-us/library/system.environment.is64bitprocess.aspx</a><br>
<br>
If you are detecting whether an arbitrary application running on the system <br>
is a 64-bit process, you need to determine the OS bitness and if it is 64-bit, <br>
call IsWow64Process() with the target process handle.<br>
<br>
&nbsp; &nbsp;Function Is64BitProcess(ByVal hProcess As IntPtr) As Boolean<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim flag As Boolean = False<br>
&nbsp; &nbsp; &nbsp; &nbsp;If Environment.Is64BitOperatingSystem Then<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' On 64-bit OS, if a process is not running under Wow64 mode,
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' the process must be a 64-bit process.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;flag = Not (NativeMethods.IsWow64Process(hProcess, flag) AndAlso flag)<br>
&nbsp; &nbsp; &nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;Return flag<br>
&nbsp; &nbsp;End Function<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Environment.Is64BitOperatingSystem Property <br>
<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/system.environment.is64bitoperatingsystem.aspx">http://msdn.microsoft.com/en-us/library/system.environment.is64bitoperatingsystem.aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.environment.is64bitoperatingsystem.aspx">http://msdn.microsoft.com/en-us/library/system.environment.is64bitoperatingsystem.aspx</a><br>
<br>
MSDN: Environment.Is64BitProcess Property <br>
<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/system.environment.is64bitprocess.aspx">http://msdn.microsoft.com/en-us/library/system.environment.is64bitprocess.aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.environment.is64bitprocess.aspx">http://msdn.microsoft.com/en-us/library/system.environment.is64bitprocess.aspx</a><br>
<br>
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

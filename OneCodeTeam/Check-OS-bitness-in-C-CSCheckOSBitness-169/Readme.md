# Check OS bitness in C# (CSCheckOSBitness)
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
* 2011-05-05 05:18:46
## Description

<p style="font-family:Courier New"></p>
<h2>APPLICATION : CSCheckOSBitness Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary: </h3>
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
you will get an application: CSCheckOSBitness.exe. <br>
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
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
The sample introduces two solutions of detecting programmatically whether you <br>
are running on 64-bit operating system.<br>
<br>
Solution 1. Use the IsWow64Process function<br>
<br>
&nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp;/// The function determines whether the current operating system is a
<br>
&nbsp; &nbsp;/// 64-bit operating system.<br>
&nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp;/// &lt;returns&gt;<br>
&nbsp; &nbsp;/// The function returns true if the operating system is 64-bit; <br>
&nbsp; &nbsp;/// otherwise, it returns false.<br>
&nbsp; &nbsp;/// &lt;/returns&gt;<br>
&nbsp; &nbsp;public static bool Is64BitOS()<br>
<br>
To detect programmatically whether your 32-bit program is running on 64-bit <br>
operating system, you can use the IsWow64Process function. <br>
<br>
&nbsp; &nbsp;bool flag;<br>
&nbsp; &nbsp;return ((DoesWin32MethodExist(&quot;kernel32.dll&quot;, &quot;IsWow64Process&quot;) &&<br>
&nbsp; &nbsp; &nbsp; &nbsp;IsWow64Process(GetCurrentProcess(), out flag)) && flag);<br>
<br>
If the running process is a 64-bit process, the operating system must be a <br>
64-bit operating system.<br>
<br>
&nbsp; &nbsp;if (IntPtr.Size == 8) &nbsp;// 64-bit programs run only on Win64<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;return true;<br>
&nbsp; &nbsp;}<br>
<br>
Solution 2. Query the Win32_Processor WMI class's AddressWidth property<br>
<br>
&nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp;/// The function determines whether the operating system of the <br>
&nbsp; &nbsp;/// current machine of any remote machine is a 64-bit operating <br>
&nbsp; &nbsp;/// system through Windows Management Instrumentation (WMI).<br>
&nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp;/// &lt;param name=&quot;machineName&quot;&gt;<br>
&nbsp; &nbsp;/// The full computer name or IP address of the target machine. &quot;.&quot;
<br>
&nbsp; &nbsp;/// or null means the local machine. <br>
&nbsp; &nbsp;/// &lt;/param&gt;<br>
&nbsp; &nbsp;/// &lt;param name=&quot;userName&quot;&gt;<br>
&nbsp; &nbsp;/// The user name you need for a connection. A null value indicates <br>
&nbsp; &nbsp;/// the current security context. If the user name is from a domain <br>
&nbsp; &nbsp;/// other than the current domain, the string should contain the <br>
&nbsp; &nbsp;/// domain name and user name, separated by a backslash: string <br>
&nbsp; &nbsp;/// 'username' = &quot;DomainName\\UserName&quot;. <br>
&nbsp; &nbsp;/// &lt;/param&gt;<br>
&nbsp; &nbsp;/// &lt;param name=&quot;password&quot;&gt;<br>
&nbsp; &nbsp;/// The password for the specified user.<br>
&nbsp; &nbsp;/// &lt;/param&gt;<br>
&nbsp; &nbsp;/// &lt;returns&gt;<br>
&nbsp; &nbsp;/// The function returns true if the operating system is 64-bit; <br>
&nbsp; &nbsp;/// otherwise, it returns false.<br>
&nbsp; &nbsp;/// &lt;/returns&gt;<br>
&nbsp; &nbsp;/// &lt;exception cref=&quot;System.Management.ManagementException&quot;&gt;<br>
&nbsp; &nbsp;/// The ManagementException exception is generally thrown with the &nbsp;<br>
&nbsp; &nbsp;/// error message &quot;User credentials cannot be used for local <br>
&nbsp; &nbsp;/// connections&quot;. To solve it, do not specify userName and password<br>
&nbsp; &nbsp;/// when machineName refers to the local computer.<br>
&nbsp; &nbsp;/// &lt;/exception&gt;<br>
&nbsp; &nbsp;/// &lt;exception cref=&quot;System.UnauthorizedAccessException&quot;&gt;<br>
&nbsp; &nbsp;/// This exception is usually caused by incorrect user name or <br>
&nbsp; &nbsp;/// password.<br>
&nbsp; &nbsp;/// &lt;/exception&gt;<br>
&nbsp; &nbsp;/// &lt;exception cref=&quot;System.Runtime.InteropServices.COMException&quot;&gt;<br>
&nbsp; &nbsp;/// A common error accompanied with the COMException is &quot;The RPC
<br>
&nbsp; &nbsp;/// server is unavailable. (Exception from HRESULT: 0x800706BA)&quot;.
<br>
&nbsp; &nbsp;/// This is usually caused by the firewall on the target machine that
<br>
&nbsp; &nbsp;/// blocks the WMI connection or some network problem.<br>
&nbsp; &nbsp;/// &lt;/exception&gt;<br>
&nbsp; &nbsp;public static bool Is64BitOS(string machineName, string userName, <br>
&nbsp; &nbsp; &nbsp; &nbsp;string password)<br>
<br>
It queries Win32_Processor.AddressWidth which dicates the current operating <br>
mode of the processor (on a 32-bit OS, it would be &quot;32&quot;; on a 64-bit OS, it
<br>
would be &quot;64&quot;). In contrast, Win32_Processor.DataWidth indicates the <br>
capability of the processor. On a 64-bit processor, it is &quot;64&quot;. The <br>
OSArchitecture property of the Win32_OperatingSystem WMI class can also tell <br>
the bitness of OS. On a 32-bit OS, it would be &quot;32-bit&quot;. However, the <br>
property is only available on Windows Vista and newer operating systems. <br>
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

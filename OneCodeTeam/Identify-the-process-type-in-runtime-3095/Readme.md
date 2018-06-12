# Identify the process type in runtime (VBCheckProcessType)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Windows General
## Topics
* Process type
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:50:49
## Description

<p style="font-family:Courier New"></p>
<h2>Windows APPLICATION: VBCheckProcessType Overview </h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The sample demonstrates how to identify the process type in run time, including <br>
whether this process is a 64bit process, managed process, .NET 4.0 process, WPF <br>
process or console process.<br>
<br>
NOTE: This application must run on Windows Vista or later versions because the <br>
&nbsp; &nbsp; &nbsp;EnumProcessModulesEx function is only available on these Windows versions.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Step1. Run VBCheckProcessType.exe.<br>
<br>
Step2. Click the Refresh button, you will see all the processes in the data grid<br>
&nbsp; &nbsp; &nbsp; view.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. Create the NativeMethods class to wrap the necessary Windows APIs in kernel32.dll<br>
&nbsp; and psapi.dll, including<br>
<br>
&nbsp; GetConsoleMode<br>
&nbsp; GetStdHandle<br>
&nbsp; AttachConsole<br>
&nbsp; FreeConsole<br>
&nbsp; IsWow64Process<br>
&nbsp; EnumProcessModulesEx<br>
&nbsp; GetModuleFileNameEx<br>
<br>
<br>
2. Design the &nbsp;RunningProcess class to wrap a System.Diagnostics.Process instance and<br>
&nbsp; check the process type.<br>
<br>
&nbsp; To determine whether a process is a 64bit process on x64 OS, we can use the Windows
<br>
&nbsp; API IsWow64Process Function<br>
&nbsp;<br>
&nbsp;<br>
&nbsp; To determine whether a process is a managed process, we can check whether the
<br>
&nbsp; .Net Runtime Execution engine MSCOREE.dll is loaded.<br>
&nbsp; <br>
&nbsp; To determine whether a process is a managed process, we can check whether the
<br>
&nbsp; CLR.dll is loaded. Before .Net 4.0, the workstation CLR runtime is called <br>
&nbsp; MSCORWKS.DLL. In .Net 4.0, this DLL is replaced by CLR.dll. <br>
&nbsp; <br>
&nbsp; To determine whether a process is a WPF process, we can check whether the <br>
&nbsp; PresentationCore.dll is loaded.<br>
&nbsp; <br>
&nbsp; To determine whether a process is a console process, we can check whether<br>
&nbsp; the target process has a console window.<br>
<br>
3. Design the MainForm to display all the running processes type.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
GetConsoleMode Function<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms683167(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms683167(VS.85).aspx</a><br>
<br>
GetStdHandle Function<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms683231(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms683231(VS.85).aspx</a><br>
<br>
AttachConsole Function<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms681952(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms681952(VS.85).aspx</a><br>
<br>
FreeConsole Function<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms683150(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms683150(VS.85).aspx</a><br>
<br>
Determine Whether a Program Is a Console or GUI Application<br>
<a target="_blank" href="http://www.devx.com/tips/Tip/33584">http://www.devx.com/tips/Tip/33584</a><br>
<br>
EnumProcessModulesEx Function<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms682633(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms682633(VS.85).aspx</a><br>
<br>
GetModuleFileNameEx Function<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms683198(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms683198(VS.85).aspx</a><br>
<br>
IsWow64Process Function<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms684139(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms684139(VS.85).aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

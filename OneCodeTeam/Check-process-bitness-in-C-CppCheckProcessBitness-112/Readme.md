# Check process bitness in C++ (CppCheckProcessBitness)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Windows General
## Topics
* Process Bitness
## IsPublished
* True
## ModifiedDate
* 2011-05-05 04:21:26
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CppCheckProcessBitness Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The code sample demonstrates how to determine whether the given process is<br>
a 64-bit process or not.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
The following steps walk through a demonstration of the sample.<br>
<br>
Step1. After you successfully build the sample project in Visual Studio 2008<br>
targeting the *x64* platform, you will get an application: <br>
CppCheckProcessBitness.exe. <br>
<br>
Step2. Run the application in a command prompt (cmd.exe) on a 64bit <br>
operating system (e.g. Windows 7 x64). The application prints the following <br>
content in the command prompt:<br>
<br>
&nbsp;Current process is 64-bit<br>
<br>
It indictates that the current process is a 64-bit process.<br>
<br>
Step3. If you specify the process ID of a 32bit process as the argument of <br>
CppCheckProcessBitness.exe (e.g. CppCheckProcessBitness 987), the application <br>
will print the following content in the command prompt:<br>
<br>
&nbsp;Process XXX is not 64-bit<br>
<br>
It indictates that the given process is not a 64-bit process.<br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
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
How to detect programmatically whether you are running on 64-bit Windows<br>
<a target="_blank" href="http://blogs.msdn.com/oldnewthing/archive/2005/02/01/364563.aspx">http://blogs.msdn.com/oldnewthing/archive/2005/02/01/364563.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

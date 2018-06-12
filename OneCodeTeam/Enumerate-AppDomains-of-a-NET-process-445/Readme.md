# Enumerate AppDomains of a .NET process (VBEnumerateAppDomains)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Windows General
## Topics
* CLR
* AppDomain
## IsPublished
* False
## ModifiedDate
* 2011-05-05 09:54:59
## Description

<p style="font-family:Courier New"></p>
<h2>Windows APPLICATION: VBEnumerateAppDomains Overview </h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The sample demonstrates how to enumerate the managed processes and AppDomains <br>
using hosting API and debugging API. All these APIs are unmanaged, but <br>
MdbgCore.dll and mscoree wrapped them.<br>
<br>
To identify whether a process is a managed process, you can check whether it <br>
loads CLRs using hosting API. If you want to enumerate the AppDomains in the <br>
process, attach a debugger to the process using debugging API.<br>
<br>
Notice that <br>
1. You cannot debug your own process, so if you want to enumerate the <br>
&nbsp; AppDomains in the current process, you can use ICorRuntimeHost.<br>
2. If you want to enumerate x86 managed processes in a 64bit OS, you have to <br>
&nbsp; set the platform of this application to x86.<br>
3. Some processes cannot be attached because <br>
&nbsp; 3.1 The processes have already been attached, like *.exe.vshost.<br>
&nbsp; 3.2 The processes are not in Synchronized state. Some steps of the Attach <br>
&nbsp; &nbsp; &nbsp; operation require that the processes should be in Synchronized state.
<br>
&nbsp; &nbsp; &nbsp; See <a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms404528.aspx">
http://msdn.microsoft.com/en-us/library/ms404528.aspx</a><br>
&nbsp; </p>
<h3>Demo:</h3>
<p style="font-family:Courier New">Step1. Build the sample project in Visual Studio 2010.<br>
<br>
Step2. Run VBEnumerateAppDomains.exe. This application will show following <br>
help text. <br>
<br>
&nbsp; &nbsp;Please choose a command:<br>
&nbsp; &nbsp;1: Show AppDomains in current process.<br>
&nbsp; &nbsp;2: List all managed processes.<br>
&nbsp; &nbsp;3: Show help text.<br>
&nbsp; &nbsp;4: Exit this application.<br>
&nbsp; &nbsp;To show the AppDomains in a specified process, please type &quot;&quot;PID&quot;&quot; and<br>
&nbsp; &nbsp;the ID of the process directly, like PID1234.<br>
<br>
Step3. Type 1 and press Enter, you can see all AppDomains in current process.<br>
<br>
Step4. Type 2 and press Enter, you can see all managed processes that are <br>
running.<br>
<br>
Step5. Type PIDxxxx(xxxx is a process ID that you get in Step4, like PID1234), <br>
you will see all AppDomains in the spcified process.<br>
<br>
You can use following code to create a AppDomain in an application which is <br>
to test. <br>
<br>
&nbsp; &nbsp;var newDomain = AppDomain.CreateDomain(&quot;Hello World!&quot;);<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
First, copy mdbgcore.dll to the _External_Dependencies folder and add the <br>
assembly to the project references.<br>
<br>
This assembly is a part of Windows SDK. If you installed VS2010, the assembly <br>
is under <br>
<br>
C:\Program Files\Microsoft SDKs\Windows\v7.0A\Bin\ (32 bit OS) or<br>
C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin\x64(64 bit OS). <br>
<br>
You can also download the latest Windows SDK in following link. <br>
<a target="_blank" href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=35AEDA01-421D-4BA5-B44B-543DC8C33A20">http://www.microsoft.com/downloads/en/details.aspx?FamilyID=35AEDA01-421D-4BA5-B44B-543DC8C33A20</a><br>
<br>
Second, add a COM reference: Common Language Runtime Execution Engine 2.4 <br>
Library.<br>
<br>
Third, this application supports 2 ways to start. One as demo, the other is <br>
to start with a argument, like <br>
<br>
VBEnumerateAppDomains.exe CurrentProcess<br>
VBEnumerateAppDomains.exe ListAllManagedProcesses<br>
VBEnumerateAppDomains.exe PID1234.<br>
<br>
Forth, use mscoree.ICorRuntimeHost to show AppDomains in current process.<br>
<br>
Fifth, use CLRMetaHost to enumerate the loaded runtimes of a process. If a <br>
process loads one or more Common Language Runtimes, it could be considered as <br>
a managed process.<br>
<br>
At last, use MDbgEngine to attach a CorDebugger to the specified process, and <br>
then enumerate the AppDomains.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: ICorRuntimeHost Interface<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms164320.aspx">http://msdn.microsoft.com/en-us/library/ms164320.aspx</a><br>
<br>
MSDN: ICLRMetaHost Interface<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/dd233134.aspx">http://msdn.microsoft.com/en-us/library/dd233134.aspx</a><br>
<br>
MSDN: Debugging (Unmanaged API Reference)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms404520.aspx">http://msdn.microsoft.com/en-us/library/ms404520.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

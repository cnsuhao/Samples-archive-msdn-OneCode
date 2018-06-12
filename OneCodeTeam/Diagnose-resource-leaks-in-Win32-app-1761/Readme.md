# Diagnose resource leaks in Win32 app (CppResourceLeaks)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Diagnostics
## Topics
* Handle Leak
* Memory Leak
* Resource Leak
## IsPublished
* True
## ModifiedDate
* 2011-05-05 04:34:18
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CppResourceLeaks Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
CppResourceLeaks is designed to show typical resource leaks and their <br>
consequences. It focuses on two situations of resource leaks:<br>
<br>
1. Handle Leak:<br>
<br>
A handle leak is a type of software bug that occurs when a computer program <br>
asks for a handle to a resource but does not free the handle when it is no <br>
longer used. If this occurs frequently or repeatedly over an extended period <br>
of time, a large number of handles may be marked in-use and thus unavailable, <br>
causing performance problems or a crash. The leak of handle itself is not a <br>
big problem. The problem is that handle leak causes the leak of kernel paged <br>
pool.<br>
<br>
2. Memory Leak:<br>
<br>
A memory leak is a particular type of unintentional memory consumption by a <br>
computer program where the program fails to release memory when no longer <br>
needed. This condition is normally the result of a bug in a program that <br>
prevents it from freeing up memory that it no longer needs. Memory is <br>
allocated to a program, and that program subsequently loses the ability to <br>
access it due to program logic flaws.<br>
<br>
</p>
<h3>Symptoms:</h3>
<p style="font-family:Courier New"><br>
A. Handle Leaks<br>
<br>
1. System running out of non-paged pool.<br>
<br>
2. Failing handle allocations.<br>
<br>
3. Degradation in system performance.<br>
<br>
4. Excessive paging.<br>
<br>
5. Tools like Task Manager and PerfMon show increasing handle count.<br>
<br>
B. Memory Leaks<br>
<br>
1. System running out of virtual memory.<br>
<br>
2. Failing memory allocations.<br>
<br>
3. Degradation in system performance.<br>
<br>
4. Excessive paging.<br>
<br>
5. Tools like Task Manager and PerfMon show increasing memory counters for <br>
Working Set Size, Commit Size and Virtual Memory Size.<br>
<br>
</p>
<h3>Causes:</h3>
<p style="font-family:Courier New"><br>
A. Handle Leaks<br>
<br>
1. The programmer mistakenly forget to close the handles. The OPEN and CLOSE <br>
operations are not in pairs.<br>
<br>
2. Incorrect error handling.<br>
<br>
3. Other process inject (duplicate) the handle to the current one, who is not<br>
aware of the injection, and thus, does not close the injected handle.<br>
<br>
B. Memory Leaks<br>
<br>
1. Incorrect error handling.<br>
<br>
2. Synchronization issues.<br>
<br>
3. Heap block caching (like BSTR etc).<br>
<br>
C. Heap Fragmentation<br>
<br>
1. Mixing long-term with short-term allocations.<br>
<br>
2. Mixing small size with large size allocations.<br>
<br>
3. Using realloc to shrink blocks.<br>
<br>
4. Heap leaks.<br>
<br>
</p>
<h3>Detections and Debugging:</h3>
<p style="font-family:Courier New"><br>
A. Handle Leaks<br>
<br>
- Step1. Is It Even a Handle Leak?<br>
<br>
The first step of investigating a potential resource leak is to confirm that<br>
there really is one. Handle leaks can be easily detected by using Task <br>
Manager. You can display the number of handles for a given process by <br>
clicking the Process tab of Task Manager followed by selecting the View and <br>
Select Columns submenu. This brings up a dialog box that displays a host of <br>
options that Task Manager is capable of displaying. Check the Handle Count <br>
check box, and click OK. If the Handles column shows a big number or its <br>
value continues going up and does not go down after letting the application <br>
sit idle for a while, the application is likely leaking handles. <br>
<br>
In the example of LeakFileHandle, the handle count increases by 2 and doesn't <br>
go down.<br>
<br>
- Step2. Initial analysis<br>
<br>
If we could identify what type of object the handle is associated with, it <br>
might give us a better clue to the source of the leak. For example, if all <br>
the preceding handles are thread handles, we could focus our efforts in those <br>
parts of the code. Process Explorer is an excellent tool that has the <br>
capability to show different handles and associated types in a process. <br>
(<a target="_blank" href="http://technet.microsoft.com/en-us/sysinternals/bb896653.aspx)">http://technet.microsoft.com/en-us/sysinternals/bb896653.aspx)</a><br>
The newly created handles are highlighted for a short period. This facilitates &nbsp;<br>
the detection of the leaky handles. <br>
<br>
In the example of LeakFileHandle, Process Explorer displays the addition of <br>
the following two handles after the execution.<br>
<br>
File&nbsp;&nbsp;&nbsp;&nbsp;C:\Users\Jialiang Ge\AppData\Local\Temp\HLeEF15.tmp<br>
File&nbsp;&nbsp;&nbsp;&nbsp;C:\Users\Jialiang Ge\AppData\Local\Temp\HLeEF15.tmp<br>
<br>
With the information of the leaky handles, we can try to spot the culprit by <br>
a simple code review. If the problem cannot be easily spotted, go on to the &nbsp;<br>
next step.<br>
<br>
- Step3. Using Handle Leak Detection Tools<br>
<br>
Several tools are available to help efficiently track down handle leaks. They <br>
are Application Verifier and !htrace.<br>
<br>
Application Verifier<br>
<br>
Application Verifier option &quot;Disable invalid handle usage&quot; or <br>
&quot;appverif -enable Handles&quot;. This functionality is provided by appverif on
<br>
Windows XP and later versions of OS. By activating Application Verifier, <br>
stack trace information is saved each time the process opens a handle, <br>
closes a handle, or references an invalid handle. It is this stack trace <br>
information that !htrace displays.<br>
<br>
Handle Leak Detection Tools (!htrace)<br>
<br>
!htrace, an extension command of windbg, can help you detect where the leak <br>
is occurring. Htrace stands for handle trace, and the basic idea behind the <br>
command is to enable the operating system to track all calls (with associated <br>
stack traces) that result in handles being opened and closed. When a leak has <br>
been identified, you can then use the !htrace extension command to display <br>
all the stack traces in the debugger. After all stack traces are shown, you <br>
can track down sporadic handle leaks in a much easier fashion.<br>
<br>
The general strategy for using !htrace is<br>
<br>
1. Prior to starting the actual reproducing of the leak, enable handle <br>
tracing (using !htrace �Cenable).<br>
2. Run the reproduction and let the process handle leaks.<br>
3. Use !htrace �Cdiff to find the offending stacks.<br>
<br>
Repeating steps 1�C3 will give you enough information to narrow the problem <br>
down in the code and find the leak by using code reviews.<br>
<br>
Before !htrace can be used, Application Verifier must be activated for the <br>
target process, and the Detect invalid handle usage option must be selected. <br>
By activating Application Verifier, stack trace information is saved each <br>
time the process opens a handle, closes a handle, or references an invalid<br>
handle. It is this stack trace information that !htrace displays.<br>
<br>
First, let's enable the handle trace:<br>
<br>
0:000&gt; !htrace -enable<br>
Handle tracing enabled.<br>
Handle tracing information snapshot successfully taken.<br>
<br>
The �Cenable switch is a two-step operation. First, it enables stack tracing, <br>
and second, it takes a snapshot of the current state of the process with <br>
regard to handles (as indicated by the second line in the output). As soon as <br>
stack tracing has been enabled, Windows starts recording all calls that <br>
result in handle creation and deletion. <br>
<br>
0:000&gt; g<br>
(19ec.153c): Break instruction exception - code 80000003 (first chance)<br>
eax=7ffde000 ebx=00000000 ecx=00000000 edx=7798b412 esi=00000000 edi=00000000<br>
eip=7794433c esp=0065fd0c ebp=0065fd38 iopl=0 &nbsp; &nbsp; &nbsp; &nbsp; nv up ei pl zr na pe nc<br>
cs=001b &nbsp;ss=0023 &nbsp;ds=0023 &nbsp;es=0023 &nbsp;fs=003b &nbsp;gs=0000 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; efl=00000246<br>
ntdll!DbgBreakPoint:<br>
7794433c cc &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;int &nbsp; &nbsp; 3<br>
<br>
The next time you take a snapshot <br>
(using the �Csnapshot option), the !htrace extension command queries the <br>
operating system for all stack traces that result in handle creation and <br>
deletion and displays them.<br>
<br>
0:000&gt; !htrace<br>
--------------------------------------<br>
Handle = 0x0000003c - OPEN<br>
Thread ID = 0x000017ec, Process ID = 0x000017e8<br>
<br>
0x77ca310c: ntdll!ZwDuplicateObject&#43;0x0000000c<br>
0x75e68ad9: KERNELBASE!DuplicateHandle&#43;0x00000069<br>
0x77be34e1: kernel32!DuplicateHandleStub&#43;0x000000b3<br>
** WARNING: Unable to verify checksum for CppResourceLeaks.exe<br>
0x00ab1627: CppResourceLeaks!LeakFileHandle&#43;0x00000207<br>
0x00ab1843: CppResourceLeaks!wmain&#43;0x00000023<br>
0x00ab1e48: CppResourceLeaks!__tmainCRTStartup&#43;0x000001a8<br>
0x00ab1c8f: CppResourceLeaks!wmainCRTStartup&#43;0x0000000f<br>
0x77be36d6: kernel32!BaseThreadInitThunk&#43;0x0000000e<br>
0x77c9883c: ntdll!__RtlUserThreadStart&#43;0x00000070<br>
0x77c9880f: ntdll!_RtlUserThreadStart&#43;0x0000001b<br>
--------------------------------------<br>
Handle = 0x00000038 - OPEN<br>
Thread ID = 0x000017ec, Process ID = 0x000017e8<br>
<br>
0x77ca2e3c: ntdll!ZwCreateFile&#43;0x0000000c<br>
0x75e9679f: KERNELBASE!CreateFileW&#43;0x0000035e<br>
0x77be51b3: kernel32!CreateFileWStub&#43;0x00000069<br>
0x00ab158f: CppResourceLeaks!LeakFileHandle&#43;0x0000016f<br>
0x00ab1843: CppResourceLeaks!wmain&#43;0x00000023<br>
0x00ab1e48: CppResourceLeaks!__tmainCRTStartup&#43;0x000001a8<br>
0x00ab1c8f: CppResourceLeaks!wmainCRTStartup&#43;0x0000000f<br>
0x77be36d6: kernel32!BaseThreadInitThunk&#43;0x0000000e<br>
0x77c9883c: ntdll!__RtlUserThreadStart&#43;0x00000070<br>
0x77c9880f: ntdll!_RtlUserThreadStart&#43;0x0000001b<br>
--------------------------------------<br>
Handle = 0x00000034 - CLOSE<br>
Thread ID = 0x000017ec, Process ID = 0x000017e8<br>
<br>
0x77ca2d3c: ntdll!NtClose&#43;0x0000000c<br>
0x75e87772: KERNELBASE!GetTempFileNameW&#43;0x00000293<br>
0x00ab14fe: CppResourceLeaks!LeakFileHandle&#43;0x000000de<br>
0x00ab1843: CppResourceLeaks!wmain&#43;0x00000023<br>
0x00ab1e48: CppResourceLeaks!__tmainCRTStartup&#43;0x000001a8<br>
0x00ab1c8f: CppResourceLeaks!wmainCRTStartup&#43;0x0000000f<br>
0x77be36d6: kernel32!BaseThreadInitThunk&#43;0x0000000e<br>
0x77c9883c: ntdll!__RtlUserThreadStart&#43;0x00000070<br>
0x77c9880f: ntdll!_RtlUserThreadStart&#43;0x0000001b<br>
--------------------------------------<br>
Handle = 0x00000034 - OPEN<br>
Thread ID = 0x000017ec, Process ID = 0x000017e8<br>
<br>
0x77ca2e3c: ntdll!ZwCreateFile&#43;0x0000000c<br>
0x75e9679f: KERNELBASE!CreateFileW&#43;0x0000035e<br>
0x75e87762: KERNELBASE!GetTempFileNameW&#43;0x00000208<br>
0x00ab14fe: CppResourceLeaks!LeakFileHandle&#43;0x000000de<br>
0x00ab1843: CppResourceLeaks!wmain&#43;0x00000023<br>
0x00ab1e48: CppResourceLeaks!__tmainCRTStartup&#43;0x000001a8<br>
0x00ab1c8f: CppResourceLeaks!wmainCRTStartup&#43;0x0000000f<br>
0x77be36d6: kernel32!BaseThreadInitThunk&#43;0x0000000e<br>
0x77c9883c: ntdll!__RtlUserThreadStart&#43;0x00000070<br>
0x77c9880f: ntdll!_RtlUserThreadStart&#43;0x0000001b<br>
--------------------------------------<br>
...<br>
...<br>
--------------------------------------<br>
Handle = 0x00000024 - OPEN<br>
Thread ID = 0x000017ec, Process ID = 0x000017e8<br>
<br>
...<br>
--------------------------------------<br>
Handle = 0x00000020 - OPEN<br>
Thread ID = 0x000017ec, Process ID = 0x000017e8<br>
<br>
...<br>
<br>
--------------------------------------<br>
Parsed 0xC stack traces.<br>
Dumped 0xC stack traces.<br>
<br>
The output of !htrace shows all stack traces recorded for openning and <br>
closing handles. Some entries are in pairs. For example,<br>
<br>
Handle = 0x00000034 - CLOSE<br>
Thread ID = 0x000017ec, Process ID = 0x000017e8<br>
...<br>
--------------------------------------<br>
Handle = 0x00000034 - OPEN<br>
Thread ID = 0x000017ec, Process ID = 0x000017e8<br>
...<br>
<br>
It means that the handle 0x00000034 was opened and closed properply and was <br>
not leaked. !htrace has a handy command option, -diff, that correlates all <br>
paths that resulted in creation and deletion (since the last snapshot) and <br>
reports only the stack traces that do not have a delete stack associated.<br>
<br>
0:000&gt; !htrace -diff<br>
Handle tracing information snapshot successfully taken.<br>
0xd9 new stack traces since the previous snapshot.<br>
Ignoring handles that were already closed...<br>
Outstanding handles opened since the previous snapshot:<br>
--------------------------------------<br>
Handle = 0x0000003c - OPEN<br>
Thread ID = 0x000017ec, Process ID = 0x000017e8<br>
<br>
0x77ca310c: ntdll!ZwDuplicateObject&#43;0x0000000c<br>
0x75e68ad9: KERNELBASE!DuplicateHandle&#43;0x00000069<br>
0x77be34e1: kernel32!DuplicateHandleStub&#43;0x000000b3<br>
0x00ab1627: CppResourceLeaks!LeakFileHandle&#43;0x00000207<br>
0x00ab1843: CppResourceLeaks!wmain&#43;0x00000023<br>
0x00ab1e48: CppResourceLeaks!__tmainCRTStartup&#43;0x000001a8<br>
0x00ab1c8f: CppResourceLeaks!wmainCRTStartup&#43;0x0000000f<br>
0x77be36d6: kernel32!BaseThreadInitThunk&#43;0x0000000e<br>
0x77c9883c: ntdll!__RtlUserThreadStart&#43;0x00000070<br>
0x77c9880f: ntdll!_RtlUserThreadStart&#43;0x0000001b<br>
--------------------------------------<br>
Handle = 0x00000038 - OPEN<br>
Thread ID = 0x000017ec, Process ID = 0x000017e8<br>
<br>
0x77ca2e3c: ntdll!ZwCreateFile&#43;0x0000000c<br>
0x75e9679f: KERNELBASE!CreateFileW&#43;0x0000035e<br>
0x77be51b3: kernel32!CreateFileWStub&#43;0x00000069<br>
0x00ab158f: CppResourceLeaks!LeakFileHandle&#43;0x0000016f<br>
0x00ab1843: CppResourceLeaks!wmain&#43;0x00000023<br>
0x00ab1e48: CppResourceLeaks!__tmainCRTStartup&#43;0x000001a8<br>
0x00ab1c8f: CppResourceLeaks!wmainCRTStartup&#43;0x0000000f<br>
0x77be36d6: kernel32!BaseThreadInitThunk&#43;0x0000000e<br>
0x77c9883c: ntdll!__RtlUserThreadStart&#43;0x00000070<br>
0x77c9880f: ntdll!_RtlUserThreadStart&#43;0x0000001b<br>
--------------------------------------<br>
Handle = 0x00000024 - OPEN<br>
Thread ID = 0x000017ec, Process ID = 0x000017e8<br>
...<br>
--------------------------------------<br>
Handle = 0x00000020 - OPEN<br>
Thread ID = 0x000017ec, Process ID = 0x000017e8<br>
...<br>
--------------------------------------<br>
Displayed 0x4 stack traces for outstanding handles opened since the previous <br>
snapshot.<br>
<br>
Therefore, our focus should be on the handles 0x3c, 0x38, 0x24, 0x20. <br>
!handle &lt;handle&gt; tells the type of the handle. For example, <br>
<br>
0:000&gt; !handle 0x3c <br>
Handle 3c<br>
&nbsp;Type &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;File<br>
<br>
The call-stacks in the output of !htrace give the hint of the culprit <br>
functions that open the leaky handles. Take the <br>
CppResourceLeaks!LeakFileHandle function as an example:<br>
<br>
--------------------------------------<br>
Handle = 0x00000038 - OPEN<br>
Thread ID = 0x000017ec, Process ID = 0x000017e8<br>
<br>
0x77ca2e3c: ntdll!ZwCreateFile&#43;0x0000000c<br>
0x75e9679f: KERNELBASE!CreateFileW&#43;0x0000035e<br>
0x77be51b3: kernel32!CreateFileWStub&#43;0x00000069<br>
0x00ab158f: CppResourceLeaks!LeakFileHandle&#43;0x0000016f<br>
0x00ab1843: CppResourceLeaks!wmain&#43;0x00000023<br>
0x00ab1e48: CppResourceLeaks!__tmainCRTStartup&#43;0x000001a8<br>
0x00ab1c8f: CppResourceLeaks!wmainCRTStartup&#43;0x0000000f<br>
0x77be36d6: kernel32!BaseThreadInitThunk&#43;0x0000000e<br>
0x77c9883c: ntdll!__RtlUserThreadStart&#43;0x00000070<br>
0x77c9880f: ntdll!_RtlUserThreadStart&#43;0x0000001b<br>
<br>
One exception is that, if the call-stack looks very convoluted and does not <br>
make any sense for the target process, the handle is likedly to be injected <br>
(duplicated) from another process. Take the LeakInjectedHandle as an example:<br>
<br>
0:000&gt; !htrace -diff<br>
Handle tracing information snapshot successfully taken.<br>
0x1 new stack traces since the previous snapshot.<br>
Ignoring handles that were already closed...<br>
Outstanding handles opened since the previous snapshot:<br>
--------------------------------------<br>
Handle = 0x00000114 - OPEN<br>
Thread ID = 0x00001700, Process ID = 0x00000d30<br>
<br>
0x77ca310c: ntdll!ZwDuplicateObject&#43;0x0000000c<br>
0x75e68ad9: KERNELBASE!DuplicateHandle&#43;0x00000069<br>
0x77be34e1: kernel32!DuplicateHandleStub&#43;0x000000b3<br>
0x00101991: &#43;0x00101991<br>
0x00101b78: &#43;0x00101b78<br>
0x00102188: &#43;0x00102188<br>
0x00101fcf: &#43;0x00101fcf<br>
0x77be36d6: kernel32!BaseThreadInitThunk&#43;0x0000000e<br>
0x77c9883c: ntdll!__RtlUserThreadStart&#43;0x00000070<br>
0x77c9880f: ntdll!_RtlUserThreadStart&#43;0x0000001b<br>
--------------------------------------<br>
<br>
Another example:<br>
--------------------------------------<br>
Handle = 0x000007D8 - OPEN<br>
Thread ID = 0x00001700, Process ID = 0x00000d30<br>
<br>
0x01001363: 09htarget!XcptFilter&#43;0x00000009<br>
0x010014D3: 09htarget!_NULL_IMPORT_DESCRIPTOR&#43;0x000000CB<br>
0x7C816FD7: kernel32!BaseProcessStart&#43;0x00000023<br>
--------------------------------------<br>
<br>
The Process ID and Thread ID reported by !htrace -diff belong to the <br>
injecting process. We can therefore find out who duplicated the handle to <br>
the leaking proecss.<br>
<br>
B. Memory Leaks<br>
<br>
- Step1. Is It Even a Memory Leak?<br>
<br>
We use Task Manager or Process Explorer to identify the potential memory <br>
leak. First, bring up Task Manager and select the Memory Usage and Virtual <br>
Memory Size columns in Pre-Vista machines, and the Memory - Working Set and <br>
Memory - Commit Size columns in Post-Vista machines. Virtual memory (aka. <br>
Commit Size or Private Bytes) indicates how much memory the process is using <br>
overall (both in and out of physical memory), whereas the Mem Usage (aka. <br>
Working Set) column shows how much physical memory the process is consuming. <br>
Typically, the best indicator for memory leaks is an increase in virtual <br>
memory size (e.g. Commmit Size) and not fluctuations in working set size.<br>
<br>
Virtual Memmory<br>
&nbsp;Private Bytes (aka. Commit Size or Virtual Memory Size) <br>
&nbsp;Peak Private Bytes<br>
&nbsp;Virtual Size<br>
&nbsp;Page Faults<br>
&nbsp;Page Fault Delta<br>
<br>
Physical Memory<br>
&nbsp;Working Set (aka. Mem Usage)<br>
&nbsp; &nbsp;WS Private: physical memory owned by just this process<br>
&nbsp; &nbsp;WS Shareable: physical memory that could be shared with other processes<br>
&nbsp; &nbsp;WS Shared: shareable memory that is current shared with other processes
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;(It is a subset of shareable WS. It tells the possible size of memory
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;that will still be in use after the current process exits)<br>
&nbsp;Peak Working Set<br>
<br>
Note: Private Bytes may be bigger than Working Set Size when much virtual <br>
memory is paged out. Private Bytes may also be smaller than Working Set Size <br>
because the memory allocations are in pages (influencing working set size) <br>
while the virtual memory size is in bytes which must be smaller than or equal <br>
to one page of memory.<br>
<br>
In the example of LeakHeapMemory, we can observe in Task Manager the <br>
continous increase of both virtual memory size and memory usage.<br>
<br>
- Step2. Using Memory Leak Detection Tools<br>
<br>
Several tools are available to help efficiently track down memory leaks. They <br>
are UMDH, LeakDiag, !address, !heap, Pageheap, and CRTDBG.<br>
<br>
UMDH<br>
<a target="_blank" href="&lt;a target=" href="http://support.microsoft.com/kb/268343">http://support.microsoft.com/kb/268343</a>'&gt;<a target="_blank" href="http://support.microsoft.com/kb/268343">http://support.microsoft.com/kb/268343</a><br>
<br>
UMDH works by taking snapshots of the virtual memory usage of a process at <br>
different points in time and logging them to text files. UMDH can compare the <br>
log files taken at 2 instances of time and list the allocations that are <br>
leaking. It requires GFLAGS &quot;User Stack Trace Database Option&quot; (&#43;ust) to be
<br>
enabled in order to record the stack traces of the memory allocation requests <br>
made by the process. Allocations and assocated stack traces in the log file <br>
are tagged with &quot;BackTracexxxxx&quot;. UMDH uses these tags as identifiers for
<br>
reporting leaks.<br>
<br>
Note: UMDH tracks heap allocations only. In other words, it cannot track <br>
allocations that are originating from non-heap-related memory activity (such <br>
as calls to VirtualAlloc).<br>
<br>
First, we need to enable stack traces for memory allocations. To accomplish <br>
this, we use the gflags tool and enable &quot;Create user mode stack trace <br>
database&quot; for CppResourceLeaks.exe.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;gflags -i CppResourceLeaks.exe &#43;ust<br>
<br>
The command needs to be run as administrator. It does not enable stack <br>
tracing for processes that are already running, but it enables stack tracing <br>
for all future executions of CppResourceLeaks.exe. Alternatively, you can set <br>
the flag through the GFLAGS user interface. Use the -ust option for gflags to <br>
disable the stack tracing when you are finished debugging. <br>
<br>
Second, we need to configure the debug symbols. One of the most important <br>
steps to using UMDH is to make sure that you have good symbol files (.dbg or <br>
.pdb file) to get a good stack trace. You can use the Microsoft Symbol Server <br>
to obtain debug symbol files (<a target="_blank" href="http://support.microsoft.com/kb/311503/).">http://support.microsoft.com/kb/311503/).</a> UMDH
<br>
is capable of using dbghelp.dll to reading symbol files and resolving <br>
addresses to symbolic function names.<br>
<br>
Third, start CppResourceLeaks.exe and get its process ID from Task Manager.<br>
<br>
Fourth, use UMDH to get a heap dump before the apparent leak happens with the <br>
following command:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;umdh -p:PID -f:CppResourceLeaks1.log<br>
<br>
Now you have a complete heap dump of the CppResourceLeaks process in the <br>
CppResourceLeaks1.log file. This file shows all of the allocations that were <br>
made and the callstacks where the allocations were made. The log in this <br>
state is not readable as the symbols are not resolved. UMDH can be instructed <br>
to resolve the symbols by simulating a log comparison with an empty log, <br>
using the command:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;umdh -v CppResourceLeaks1.log &nbsp;&gt; CppResourceLeaks1.txt<br>
<br>
The resulting log contains something like:<br>
<br>
&#43; &nbsp; &nbsp;2018 ( &nbsp;2018 - &nbsp; &nbsp; 0) &nbsp; &nbsp; &nbsp;1 allocs&nbsp;&nbsp;&nbsp;&nbsp;BackTrace73F28<br>
&#43; &nbsp; &nbsp; &nbsp; 1 ( &nbsp; &nbsp; 1 - &nbsp; &nbsp; 0)&nbsp;&nbsp;&nbsp;&nbsp;BackTrace73F28&nbsp;&nbsp;&nbsp;&nbsp;allocations<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;ntdll!RtlAllocateHeap&#43;00000274<br>
&nbsp;&nbsp;&nbsp;&nbsp;kernel32!ConsoleAllocateCaptureBuffer&#43;0000006F<br>
&nbsp;&nbsp;&nbsp;&nbsp;kernel32!ReadConsoleInternal&#43;0000007E<br>
&nbsp;&nbsp;&nbsp;&nbsp;kernel32!ReadConsoleA&#43;00000040<br>
&nbsp;&nbsp;&nbsp;&nbsp;kernel32!ReadFileImplementation&#43;00000075<br>
&nbsp;&nbsp;&nbsp;&nbsp;MSVCR90D!_read_nolock&#43;0000062C<br>
&nbsp;&nbsp;&nbsp;&nbsp;MSVCR90D!_read&#43;00000219<br>
&nbsp;&nbsp;&nbsp;&nbsp;MSVCR90D!_filbuf&#43;00000113<br>
&nbsp;&nbsp;&nbsp;&nbsp;MSVCR90D!getc&#43;00000208<br>
&nbsp;&nbsp;&nbsp;&nbsp;MSVCR90D!_fgetchar&#43;00000010<br>
&nbsp;&nbsp;&nbsp;&nbsp;MSVCR90D!getchar&#43;0000000A<br>
&nbsp;&nbsp;&nbsp;&nbsp;CppResourceLeaks!LeakHeapMemory&#43;0000003D (...\cppresourceleaks.cpp, 221)<br>
&nbsp;&nbsp;&nbsp;&nbsp;CppResourceLeaks!wmain&#43;00000023 (...\cppresourceleaks.cpp, 260)<br>
&nbsp;&nbsp;&nbsp;&nbsp;CppResourceLeaks!__tmainCRTStartup&#43;000001A8 (crtexe.c, 583)<br>
&nbsp;&nbsp;&nbsp;&nbsp;CppResourceLeaks!wmainCRTStartup&#43;0000000F (crtexe.c, 403)<br>
&nbsp;&nbsp;&nbsp;&nbsp;kernel32!BaseThreadInitThunk&#43;0000000E<br>
&nbsp;&nbsp;&nbsp;&nbsp;ntdll!__RtlUserThreadStart&#43;00000070<br>
&nbsp;&nbsp;&nbsp;&nbsp;ntdll!_RtlUserThreadStart&#43;0000001B<br>
<br>
Fifth, while memory is leaking, take the second snapshot of the heap:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;umdh -p:PID -f:CppResourceLeaks2.log<br>
<br>
Last, use UMDH to compare the UMDH logs:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;UMDH CppResourceLeaks1.log CppResourceLeaks2.log &gt; cmp12.txt<br>
<br>
In cmp12.txt, each log entry has the following syntax:<br>
<br>
&#43; BYTES_DELTA (NEW_BYTES - OLD_BYTES) NEW_COUNT allocs BackTrace TRACEID<br>
&#43; COUNT_DELTA (NEW_COUNT - OLD_COUNT) BackTrace TRACEID allocations<br>
... stack trace ...<br>
<br>
where:<br>
<br>
BYTES_DELTA - increase in bytes between before and after log<br>
NEW_BYTES - bytes in after log<br>
OLD_BYTES - bytes in before log<br>
COUNT_DELTA - increase in allocations between before and after log<br>
NEW_COUNT - number of allocations in after log<br>
OLD_COUNT - number of allocations in before log<br>
TRACEID - decimal index of the stack trace in the trace database (can be <br>
used to search for allocation instances in the original UMDH logs).<br>
<br>
For example (LeakHeapMemory()), <br>
<br>
&#43; 2a98c90 ( 2a98c90 - &nbsp; &nbsp; 0) &nbsp;15cf4 allocs&nbsp;&nbsp;&nbsp;&nbsp;BackTrace74050<br>
&#43; &nbsp; 15cf4 ( 15cf4 - &nbsp; &nbsp; 0)&nbsp;&nbsp;&nbsp;&nbsp;BackTrace74050&nbsp;&nbsp;&nbsp;&nbsp;allocations<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;ntdll!RtlAllocateHeap&#43;00000274<br>
&nbsp;&nbsp;&nbsp;&nbsp;CppResourceLeaks!LeakHeapMemory&#43;00000083 (...\cppresourceleaks.cpp, 228)<br>
&nbsp;&nbsp;&nbsp;&nbsp;CppResourceLeaks!wmain&#43;00000023 (...\cppresourceleaks.cpp, 260)<br>
&nbsp;&nbsp;&nbsp;&nbsp;CppResourceLeaks!__tmainCRTStartup&#43;000001A8 (crtexe.c, 583)<br>
&nbsp;&nbsp;&nbsp;&nbsp;CppResourceLeaks!wmainCRTStartup&#43;0000000F (crtexe.c, 403)<br>
&nbsp;&nbsp;&nbsp;&nbsp;kernel32!BaseThreadInitThunk&#43;0000000E<br>
&nbsp;&nbsp;&nbsp;&nbsp;ntdll!__RtlUserThreadStart&#43;00000070<br>
&nbsp;&nbsp;&nbsp;&nbsp;ntdll!_RtlUserThreadStart&#43;0000001B<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
- &nbsp; &nbsp;2018 ( &nbsp; &nbsp; 0 - &nbsp;2018) &nbsp; &nbsp; &nbsp;0 allocs&nbsp;&nbsp;&nbsp;&nbsp;BackTrace73F28<br>
- &nbsp; &nbsp; &nbsp; 1 ( &nbsp; &nbsp; 0 - &nbsp; &nbsp; 1)&nbsp;&nbsp;&nbsp;&nbsp;BackTrace73F28&nbsp;&nbsp;&nbsp;&nbsp;allocations<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;ntdll!RtlAllocateHeap&#43;00000274<br>
&nbsp;&nbsp;&nbsp;&nbsp;kernel32!ConsoleAllocateCaptureBuffer&#43;0000006F<br>
&nbsp;&nbsp;&nbsp;&nbsp;kernel32!ReadConsoleInternal&#43;0000007E<br>
&nbsp;&nbsp;&nbsp;&nbsp;kernel32!ReadConsoleA&#43;00000040<br>
&nbsp;&nbsp;&nbsp;&nbsp;kernel32!ReadFileImplementation&#43;00000075<br>
&nbsp;&nbsp;&nbsp;&nbsp;MSVCR90D!_read_nolock&#43;0000062C<br>
&nbsp;&nbsp;&nbsp;&nbsp;MSVCR90D!_read&#43;00000219<br>
&nbsp;&nbsp;&nbsp;&nbsp;MSVCR90D!_filbuf&#43;00000113<br>
&nbsp;&nbsp;&nbsp;&nbsp;MSVCR90D!getc&#43;00000208<br>
&nbsp;&nbsp;&nbsp;&nbsp;MSVCR90D!_fgetchar&#43;00000010<br>
&nbsp;&nbsp;&nbsp;&nbsp;MSVCR90D!getchar&#43;0000000A<br>
&nbsp;&nbsp;&nbsp;&nbsp;CppResourceLeaks!LeakHeapMemory&#43;0000003D (...\cppresourceleaks.cpp, 221)<br>
&nbsp;&nbsp;&nbsp;&nbsp;CppResourceLeaks!wmain&#43;00000023 (...\cppresourceleaks.cpp, 260)<br>
&nbsp;&nbsp;&nbsp;&nbsp;CppResourceLeaks!__tmainCRTStartup&#43;000001A8 (crtexe.c, 583)<br>
&nbsp;&nbsp;&nbsp;&nbsp;CppResourceLeaks!wmainCRTStartup&#43;0000000F (crtexe.c, 403)<br>
&nbsp;&nbsp;&nbsp;&nbsp;kernel32!BaseThreadInitThunk&#43;0000000E<br>
&nbsp;&nbsp;&nbsp;&nbsp;ntdll!__RtlUserThreadStart&#43;00000070<br>
&nbsp;&nbsp;&nbsp;&nbsp;ntdll!_RtlUserThreadStart&#43;0000001B<br>
<br>
According to the comparison, the first call-stack appears for 15cf4 times, <br>
and 2a98c90 bytes were leaked because of the LeakHeapMemory function.<br>
<br>
!address<br>
<br>
The !address extension command comes in very handy when you want to get a <br>
quick overview of where the memory in your process is really located. The <br>
command gives statistics, such as memory region usage in heaps, stack, free, <br>
and so on.<br>
<br>
For example (LeakHeapMemory()), <br>
<br>
0:000&gt; !address -summary<br>
ProcessParametrs 00381a18 in range 00380000 0039c000<br>
Environment 00380810 in range 00380000 0039c000<br>
<br>
-------------------- Usage SUMMARY --------------------------<br>
&nbsp; &nbsp;TotSize ( &nbsp; &nbsp; &nbsp;KB) &nbsp; Pct(Tots) Pct(Busy) &nbsp; Usage<br>
&nbsp; &nbsp;11c4000 ( &nbsp; 18192) : 00.87% &nbsp; &nbsp;02.27% &nbsp; &nbsp;: RegionUsageIsVAD<br>
&nbsp; 4f132000 ( 1295560) : 61.78% &nbsp; &nbsp;00.00% &nbsp; &nbsp;: RegionUsageFree<br>
&nbsp; &nbsp; 397000 ( &nbsp; &nbsp;3676) : 00.18% &nbsp; &nbsp;00.46% &nbsp; &nbsp;: RegionUsageImage<br>
&nbsp; &nbsp; 200000 ( &nbsp; &nbsp;2048) : 00.10% &nbsp; &nbsp;00.26% &nbsp; &nbsp;: RegionUsageStack<br>
&nbsp; &nbsp; &nbsp; 2000 ( &nbsp; &nbsp; &nbsp; 8) : 00.00% &nbsp; &nbsp;00.00% &nbsp; &nbsp;: RegionUsageTeb<br>
&nbsp; 2f760000 ( &nbsp;777600) : 37.08% &nbsp; &nbsp;97.01% &nbsp; &nbsp;: RegionUsageHeap<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;0 ( &nbsp; &nbsp; &nbsp; 0) : 00.00% &nbsp; &nbsp;00.00% &nbsp; &nbsp;: RegionUsagePageHeap<br>
&nbsp; &nbsp; &nbsp; 1000 ( &nbsp; &nbsp; &nbsp; 4) : 00.00% &nbsp; &nbsp;00.00% &nbsp; &nbsp;: RegionUsagePeb<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;0 ( &nbsp; &nbsp; &nbsp; 0) : 00.00% &nbsp; &nbsp;00.00% &nbsp; &nbsp;: RegionUsageProcessParametrs<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;0 ( &nbsp; &nbsp; &nbsp; 0) : 00.00% &nbsp; &nbsp;00.00% &nbsp; &nbsp;: RegionUsageEnvironmentBlock<br>
&nbsp; &nbsp; &nbsp; Tot: 7fff0000 (2097088 KB) Busy: 30ebe000 (801528 KB)<br>
<br>
-------------------- Type SUMMARY --------------------------<br>
&nbsp; &nbsp;TotSize ( &nbsp; &nbsp; &nbsp;KB) &nbsp; Pct(Tots) &nbsp;Usage<br>
&nbsp; 4f132000 ( 1295560) : 61.78% &nbsp; : &lt;free&gt;<br>
&nbsp; &nbsp; 398000 ( &nbsp; &nbsp;3680) : 00.18% &nbsp; : MEM_IMAGE<br>
&nbsp; &nbsp; 1be000 ( &nbsp; &nbsp;1784) : 00.09% &nbsp; : MEM_MAPPED<br>
&nbsp; 30968000 ( &nbsp;796064) : 37.96% &nbsp; : MEM_PRIVATE<br>
<br>
-------------------- State SUMMARY --------------------------<br>
&nbsp; &nbsp;TotSize ( &nbsp; &nbsp; &nbsp;KB) &nbsp; Pct(Tots) &nbsp;Usage<br>
&nbsp; 2f4cf000 ( &nbsp;774972) : 36.95% &nbsp; : MEM_COMMIT<br>
&nbsp; 4f132000 ( 1295560) : 61.78% &nbsp; : MEM_FREE<br>
&nbsp; &nbsp;19ef000 ( &nbsp; 26556) : 01.27% &nbsp; : MEM_RESERVE<br>
<br>
Largest free region: Base 30f00000 - Size 2a970000 (697792 KB)<br>
<br>
The column Pct(Tots) means the percentage of the entry in total virtual <br>
memory. The column Pct(Busy) means the percentage of the entry in busy <br>
virtual memory.<br>
<br>
RegionUsageIsVAD - memory allocated by VirtualAlloc in VMM<br>
RegionUsageHeap - memory allocated by heap manager<br>
<br>
From the output<br>
<br>
&nbsp; &nbsp;11c4000 ( &nbsp; 18192) : 00.87% &nbsp; &nbsp;02.27% &nbsp; &nbsp;: RegionUsageIsVAD<br>
&nbsp; 2f760000 ( &nbsp;777600) : 37.08% &nbsp; &nbsp;97.01% &nbsp; &nbsp;: RegionUsageHeap<br>
<br>
we see that most used memory is heap alloc, instead of virtual alloc, so it's <br>
a heap memory leak.<br>
<br>
!heap -s, !heap -a, and !heap -x -v<br>
<br>
The !heap -s command allows you to get a detailed look at the heap summary of <br>
the process and the suspicious heaps. Judging from the pattern of allocations <br>
in the !heap extension command output (e.g. there are tons of blocks <br>
allocated of same user size), chances are good that we can locate the heap <br>
blocks that are leaked. Furthermore, by looking around at the heap block <br>
contents (e.g. does it contain ASCII characters? does it correspond to the <br>
address of some function / symbol?) we may see how / why the block was <br>
allocated. <br>
<br>
Please note that because a lot of changes happened to the heap manager in <br>
Windows Vista and the later operating system, the allocation of heap entries <br>
may vary. For example, the allocated block may be bigger than requested, or <br>
the allocation granually grows in size.<br>
<br>
To prove that this is indeed a leak, you can search for references to the <br>
block in the process's memory space. If these potentially leaked blocks were <br>
being used (perhaps cached), there would need to be a reference somewhere in <br>
memory that points to that heap block. If there are no references, it means <br>
that we definitely have a leak. The !heap -x -v allows you to search the <br>
entire memory space of the process for the presence of a specified address.<br>
<br>
For example (LeakHeapMemory()), <br>
<br>
0:000&gt; !heap -s<br>
&nbsp;Heap &nbsp; &nbsp; Flags &nbsp; Reserv &nbsp;Commit &nbsp;Virt &nbsp; Free &nbsp;List &nbsp; UCR &nbsp;Virt &nbsp;Lock &nbsp;Fast
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;(k) &nbsp; &nbsp; (k) &nbsp; &nbsp;(k) &nbsp; &nbsp; (k) length &nbsp; &nbsp; &nbsp;blocks cont. heap
<br>
-----------------------------------------------------------------------------<br>
00150000 00000002 &nbsp; 16384 &nbsp;16352 &nbsp;16352 &nbsp; &nbsp; &nbsp;2 &nbsp; &nbsp; 0 &nbsp; &nbsp; 1 &nbsp; &nbsp;0 &nbsp; &nbsp; &nbsp;0 &nbsp; L &nbsp;<br>
00250000 00008000 &nbsp; &nbsp; &nbsp;64 &nbsp; &nbsp; 12 &nbsp; &nbsp; 12 &nbsp; &nbsp; 10 &nbsp; &nbsp; 1 &nbsp; &nbsp; 1 &nbsp; &nbsp;0 &nbsp; &nbsp; &nbsp;0 &nbsp; &nbsp; &nbsp;<br>
00380000 00001002 &nbsp; &nbsp; &nbsp;64 &nbsp; &nbsp; 44 &nbsp; &nbsp; 44 &nbsp; &nbsp; &nbsp;9 &nbsp; &nbsp; 2 &nbsp; &nbsp; 1 &nbsp; &nbsp;0 &nbsp; &nbsp; &nbsp;0 &nbsp; L &nbsp;<br>
-----------------------------------------------------------------------------<br>
<br>
The heap 00150000 occupies abnormally large memory.<br>
<br>
0:000&gt; !heap -a 00120000<br>
&nbsp; &nbsp; &nbsp; &nbsp;...<br>
&nbsp; &nbsp; &nbsp; &nbsp;00246240: 00200 . 00200 [01] - busy (1f4)<br>
&nbsp; &nbsp; &nbsp; &nbsp;00246440: 00200 . 00200 [01] - busy (1f4)<br>
&nbsp; &nbsp; &nbsp; &nbsp;00246640: 00200 . 00200 [01] - busy (1f4)<br>
&nbsp; &nbsp; &nbsp; &nbsp;00246840: 00200 . 00200 [01] - busy (1f4)<br>
&nbsp; &nbsp; &nbsp; &nbsp;00246a40: 00200 . 00200 [01] - busy (1f4)<br>
&nbsp; &nbsp; &nbsp; &nbsp;00246c40: 00200 . 00200 [01] - busy (1f4)<br>
&nbsp; &nbsp; &nbsp; &nbsp;00246e40: 00200 . 00200 [01] - busy (1f4)<br>
&nbsp; &nbsp; &nbsp; &nbsp;00247040: 00200 . 00200 [01] - busy (1f4)<br>
&nbsp; &nbsp; &nbsp; &nbsp;00247240: 00200 . 00200 [01] - busy (1f4)<br>
&nbsp; &nbsp; &nbsp; &nbsp;...<br>
<br>
We find a large number of blocks with the same user allocation size (1f4). <br>
This is usually a good indicator that they are potentially leaked blocks. <br>
The next step is to find out what these blocks actually contain. If we were <br>
leaking memory, it would be reasonable to expect data related to our <br>
application contained within those blocks:<br>
<br>
0:000&gt; db 00246c40&#43;0x8<br>
00246c48 &nbsp;41 6c 6c 2d 49 6e 2d 4f-6e 65 20 43 6f 64 65 20 &nbsp;All-In-One Code
<br>
00246c58 &nbsp;46 72 61 6d 65 77 6f 72-6b 00 00 00 00 00 00 00 &nbsp;Framework.......<br>
<br>
Before we come to the conclusion that this is in fact a leak, we should <br>
verify it by searching for references to the block in the process's memory <br>
space. <br>
<br>
0:000&gt; !heap -x -v 00246c40&#43;0x8<br>
Entry &nbsp; &nbsp; User &nbsp; &nbsp; &nbsp;Heap &nbsp; &nbsp; &nbsp;Segment &nbsp; &nbsp; &nbsp; Size &nbsp;PrevSize &nbsp;Unused &nbsp; &nbsp;Flags<br>
-----------------------------------------------------------------------------<br>
00246c40 &nbsp;00246c48 &nbsp;00150000 &nbsp;00150640 &nbsp; &nbsp; &nbsp; 200 &nbsp; &nbsp; &nbsp; 200 &nbsp; &nbsp; &nbsp; &nbsp; c &nbsp;busy
<br>
<br>
Search VM for address range 00246c40 - 00246e3f : <br>
<br>
The search yielded zero results. As stated before, if a currently allocated <br>
heap block is not referenced anywhere in memory, we can safely say that we <br>
are leaking that block.<br>
<br>
!heap -l<br>
<br>
The !heap -l command causes debugger to look for leaked heap blocks. It <br>
automates the act of dumping out all heap blocks (!heap -s) and <br>
systematically searching for any potentially leaked blocks (!heap -x -v). <br>
Please note that !heap -l does not work if full page heap is enabled for the <br>
process.<br>
<br>
For example (LeakHeapMemory()), <br>
<br>
0:000&gt; !heap -l<br>
Searching the memory for potential unreachable busy blocks.<br>
Heap 00150000<br>
Heap 00250000<br>
Heap 00380000<br>
Scanning VM ...<br>
Scanning references from 32822 busy blocks (16 MBytes) ....<br>
Entry &nbsp; &nbsp; User &nbsp; &nbsp; &nbsp;Heap &nbsp; &nbsp; &nbsp;Segment &nbsp; &nbsp; &nbsp; Size &nbsp;PrevSize &nbsp;Unused &nbsp; &nbsp;Flags<br>
-----------------------------------------------------------------------------<br>
00154640 &nbsp;00154648 &nbsp;00150000 &nbsp;00150000 &nbsp; &nbsp; &nbsp; 200 &nbsp; &nbsp; &nbsp; 200 &nbsp; &nbsp; &nbsp; &nbsp; c &nbsp;busy
<br>
00154840 &nbsp;00154848 &nbsp;00150000 &nbsp;00150000 &nbsp; &nbsp; &nbsp; 200 &nbsp; &nbsp; &nbsp; 200 &nbsp; &nbsp; &nbsp; &nbsp; c &nbsp;busy
<br>
00154a40 &nbsp;00154a48 &nbsp;00150000 &nbsp;00150000 &nbsp; &nbsp; &nbsp; 200 &nbsp; &nbsp; &nbsp; 200 &nbsp; &nbsp; &nbsp; &nbsp; c &nbsp;busy
<br>
00154e40 &nbsp;00154e48 &nbsp;00150000 &nbsp;00150000 &nbsp; &nbsp; &nbsp; 200 &nbsp; &nbsp; &nbsp; 200 &nbsp; &nbsp; &nbsp; &nbsp; c &nbsp;busy
<br>
00155040 &nbsp;00155048 &nbsp;00150000 &nbsp;00150000 &nbsp; &nbsp; &nbsp; 200 &nbsp; &nbsp; &nbsp; 200 &nbsp; &nbsp; &nbsp; &nbsp; c &nbsp;busy
<br>
00155240 &nbsp;00155248 &nbsp;00150000 &nbsp;00150000 &nbsp; &nbsp; &nbsp; 200 &nbsp; &nbsp; &nbsp; 200 &nbsp; &nbsp; &nbsp; &nbsp; c &nbsp;busy
<br>
00155640 &nbsp;00155648 &nbsp;00150000 &nbsp;00150000 &nbsp; &nbsp; &nbsp; 200 &nbsp; &nbsp; &nbsp; 200 &nbsp; &nbsp; &nbsp; &nbsp; c &nbsp;busy
<br>
00155840 &nbsp;00155848 &nbsp;00150000 &nbsp;00150000 &nbsp; &nbsp; &nbsp; 200 &nbsp; &nbsp; &nbsp; 200 &nbsp; &nbsp; &nbsp; &nbsp; c &nbsp;busy
<br>
...<br>
<br>
29050 potential unreachable blocks were detected.<br>
<br>
Pageheap, and !heap -p -a<br>
<br>
After you have identified a potential leak culprit using the above !heap <br>
commands, it would be useful to see which stack trace made the allocation to <br>
begin with. If we had that, we could find out exactly what the code was doing <br>
and what it was allocating.<br>
<br>
First, we need to enable stack tracing using Application Verifier. Second, <br>
run !heap -p -a upon the address that we thought was leaking. Not only will <br>
we see general information about the leaked address (such as which heap it's <br>
in and the trace ID), but we also get the full stack trace of the code that <br>
made the allocation. From here, it is a trivial exercise to code review and <br>
find the culprit code.<br>
<br>
Note, while using page heap, !heap -s, !heap -a, !heap -x -v and !heap -l may <br>
not work at all! We should find the culprit memory block and run !heap -p -a <br>
upon it directly.<br>
<br>
For example (LeakHeapMemory()), <br>
<br>
0:000&gt; !address 0b768e08<br>
Usage: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;PageHeap<br>
Base Address: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 0b768000<br>
End Address: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;0b769000<br>
Region Size: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;00001000<br>
Type: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 00020000&nbsp;&nbsp;&nbsp;&nbsp;MEM_PRIVATE<br>
State: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;00001000&nbsp;&nbsp;&nbsp;&nbsp;MEM_COMMIT<br>
Protect: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;00000004&nbsp;&nbsp;&nbsp;&nbsp;PAGE_READWRITE<br>
More info: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;!heap -p 0x150000<br>
More info: &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;!heap -p -a 0xb768e08<br>
<br>
0:000&gt; !heap -p -a 0xb768e08<br>
&nbsp; &nbsp;address 0b768e08 found in<br>
&nbsp; &nbsp;_DPH_HEAP_ROOT @ 151000<br>
&nbsp; &nbsp;in busy allocation ( &nbsp;DPH_HEAP_BLOCK: &nbsp;UserAddr &nbsp;UserSize - VirtAddr VirtSize)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; b72e700: &nbsp;b768e08 &nbsp; 1f4 - &nbsp; &nbsp; &nbsp;b768000 &nbsp;2000<br>
&nbsp; &nbsp;7c83d9aa ntdll!RtlAllocateHeap&#43;0x00000e9f<br>
&nbsp; &nbsp;0039fd2c vfbasics!AVrfpRtlAllocateHeap&#43;0x000000b1<br>
&nbsp; &nbsp;00401046 CppResourceLeaks!LeakHeapMemory&#43;0x00000046<br>
<br>
Not only do we see general information about the leaked address (such as <br>
which heap it's in and the trace ID), but we also get the full stack trace of <br>
the code that made the allocation. From here, it is a trivial exercise to <br>
code review and find the culprit code.<br>
<br>
CRTDBG<br>
<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/x98tx3cf.aspx">http://msdn.microsoft.com/en-us/library/x98tx3cf.aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/x98tx3cf.aspx">http://msdn.microsoft.com/en-us/library/x98tx3cf.aspx</a><br>
<br>
Debug version of C Run Time Library has facilities to debug C Run Time Heap <br>
related problems like leaks and corruption. It requires application to be <br>
rebuilt with debug CRT. <br>
<br>
When _DEBUG is defined the following functions call the respective _xxx_dbg() <br>
versions which provide extra debugging capabilities: malloc, realloc, calloc, <br>
expand, free, msize.<br>
<br>
When _CRTDBG_MAP_ALLOC is defined the _xxx_dbg() versions of the CRT heap <br>
functions are call directly instead of the standard versions. This enables <br>
the _xxx_dbg() funtions to record the location (source file path & line <br>
number) where the allocation function is being invoked. The information can <br>
be used to identify the location in the source code where the block was <br>
allocated.<br>
<br>
After enabling the above flags, debug CRT heap manager can perform various <br>
types of checking like heap corruptions and heap leaks in run-time or debug-<br>
time:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;_CrtSetDbgFlag() retrieves and modifies the behavior of the debug heap<br>
&nbsp;&nbsp;&nbsp;&nbsp;_CrtCheckMemory() performs integrity check on memory blocks<br>
&nbsp;&nbsp;&nbsp;&nbsp;_CrtDumpMemoryLeaks() dumps all heap blocks when memory leaks occurs<br>
<br>
For example ((LeakCRTHeapMemory()), <br>
<br>
First, we enable the debug heap functions, include the following statements <br>
in the program:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;#define _CRTDBG_MAP_ALLOC<br>
&nbsp;&nbsp;&nbsp;&nbsp;#include &lt;stdlib.h&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;#include &lt;crtdbg.h&gt;<br>
<br>
Note: The #include statements must be in the order shown here. If you change <br>
the order, the functions you use may not work properly. <br>
<br>
By including crtdbg.h, you map the malloc and free functions to their debug <br>
versions, _malloc_dbg and _free_dbg, which keep track of memory allocation <br>
and deallocation. This mapping occurs only in a debug build (in which _DEBUG <br>
is defined). Release builds use the ordinary malloc and free functions.<br>
<br>
At the end of the function LeakCRTHeapMemory, add the line <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;_CrtDumpMemoryLeaks();<br>
<br>
When you run your program under the debugger, _CrtDumpMemoryLeaks displays <br>
memory leak information in the Output window. The memory leak information <br>
looks like this:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Detected memory leaks!<br>
&nbsp;&nbsp;&nbsp;&nbsp;Dumping objects -&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;...\cppresourceleaks.cpp(257) : {101} normal block at 0x00511F40, 500 bytes long.<br>
&nbsp;&nbsp;&nbsp;&nbsp; Data: &lt; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&gt; CD CD CD CD CD CD CD CD CD CD CD CD CD CD CD CD
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Object dump complete.<br>
<br>
</p>
<h3>Fixes:</h3>
<p style="font-family:Courier New"><br>
A. Handle Leaks<br>
<br>
1. Be careful to close the handles after they are created.<br>
<br>
2. Consider employing an auto acquire/release construct. Very similar to auto <br>
pointers, this construct allows you to acquire a handle at any given scope <br>
and automatically free it when the auto construct goes out of scope. <br>
<br>
B. Memory Leaks<br>
<br>
1. Be careful that the allocation and deallocation of memory on the heap <br>
should be paired and should target the same heap. The most common pairs are:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;new&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;delete<br>
&nbsp;&nbsp;&nbsp;&nbsp;malloc&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;free<br>
&nbsp;&nbsp;&nbsp;&nbsp;GlobalAlloc&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GlobalFree<br>
&nbsp;&nbsp;&nbsp;&nbsp;LocalAlloc&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LocalFree<br>
&nbsp;&nbsp;&nbsp;&nbsp;CoTaskMemAlloc&nbsp;&nbsp;&nbsp;&nbsp;-&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CoTaskMemFree<br>
&nbsp;&nbsp;&nbsp;&nbsp;SysAllocString&nbsp;&nbsp;&nbsp;&nbsp;-&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SysFreeString<br>
<br>
2. Consider using an auto construct that automatically deletes memory when <br>
the variable goes out of scope, such as auto_ptr in STL.<br>
<br>
3. Consider overloading the allocation APIs used in your application. This <br>
allows for trapping all calls to memory allocations, thereby giving you hooks <br>
to all memory allocations performed by your applications. The allocation <br>
hooks can then be used to track memory allocations, simulate failures in <br>
memory allocations, and much more.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Mario Hewardt & Daniel Pravat, Advanced Windows Debugging Ch. 9 (2007), at <br>
<a target="_blank" href="http://advancedwindowsdebugging.com/.">http://advancedwindowsdebugging.com/.</a> &nbsp;Copyright 2008 by Pearson Education,
<br>
Inc. This material may be distributed only subject to the terms and <br>
conditions set forth in the Open Publication License, v1.0 or later (the <br>
latest version is presently available at <a target="_blank" href="http://www.opencontent.org/openpub/).">
http://www.opencontent.org/openpub/).</a> &nbsp;<br>
Excerpted by Jialiang Ge, 2009. <br>
<br>
Wiki: Handle leak<br>
<a target="_blank" href="http://en.wikipedia.org/wiki/Handle_leak">http://en.wikipedia.org/wiki/Handle_leak</a><br>
<br>
Debug Tutorial Part 5: Handle Leaks<br>
<a target="_blank" href="http://www.codeproject.com/KB/debug/cdbntsd5.aspx">http://www.codeproject.com/KB/debug/cdbntsd5.aspx</a><br>
<br>
Use !htrace to debug handle leak<br>
<a target="_blank" href="http://blogs.msdn.com/junfeng/archive/2008/04/21/use-htrace-to-debug-handle-leak.aspx">http://blogs.msdn.com/junfeng/archive/2008/04/21/use-htrace-to-debug-handle-leak.aspx</a><br>
<br>
Resource Leaks: Detecting, Locating, and Repairing Your Leaky GDI Code<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/magazine/cc301756.aspx">http://msdn.microsoft.com/en-us/magazine/cc301756.aspx</a><br>
<br>
Wiki: Memory leak<br>
<a target="_blank" href="http://en.wikipedia.org/wiki/Memory_leak">http://en.wikipedia.org/wiki/Memory_leak</a><br>
<br>
The poor man's way of identifying memory leaks<br>
<a target="_blank" href="http://blogs.msdn.com/oldnewthing/archive/2005/08/15/451752.aspx">http://blogs.msdn.com/oldnewthing/archive/2005/08/15/451752.aspx</a><br>
<br>
Umdhtools.exe: How to use Umdh.exe to find memory leaks<br>
<a target="_blank" href="&lt;a target=" href="http://support.microsoft.com/kb/268343">http://support.microsoft.com/kb/268343</a>'&gt;<a target="_blank" href="http://support.microsoft.com/kb/268343">http://support.microsoft.com/kb/268343</a><br>
<br>
MSDN: Memory Leak Detection and Isolation<br>
<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/x98tx3cf.aspx">http://msdn.microsoft.com/en-us/library/x98tx3cf.aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/x98tx3cf.aspx">http://msdn.microsoft.com/en-us/library/x98tx3cf.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

# Diagnose stack corruption in Win32 app (CppStackCorruption)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Diagnostics
## Topics
* Stack Corruption
## IsPublished
* True
## ModifiedDate
* 2011-05-05 04:37:16
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CppStackCorruption Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
CppStackCorruption is designed to show stack corruption and its consequences.<br>
It demonstrates two typical situations of statck corruption: <br>
<br>
A. Stack Overrun<br>
&nbsp; 1. Array indexing errors cause the stack overrun.<br>
&nbsp; 2. Static buffer overrun on the stack.<br>
<br>
B. Calling Convention Mismatch<br>
<br>
You can run the example in either Debug or Release mode. The Release <br>
configuration is better because the disassembly is simpler and the asserts <br>
are off. In this example, we also disable the optimizations in the Release <br>
configuration. It makes sure that the sample functions are run by the <br>
processor.<br>
<br>
</p>
<h3>Symptoms:</h3>
<p style="font-family:Courier New"><br>
Unlike stack overflow, stack corruption does not have an explicit error <br>
called &quot;stack corruption&quot; or &quot;stack overrun&quot;. Instead, it is presented in the
<br>
form of:<br>
<br>
1. Crash (generally with an Access Violation error resulting from the EIP <br>
register pointing to an invalid memory).<br>
<br>
2. Unpredictable behavior of the application.<br>
<br>
3. Security holes.<br>
<br>
</p>
<h3>Causes:</h3>
<p style="font-family:Courier New"><br>
Stack Overrun and Calling Convention Mismatch are the two typical causes <br>
(situations) of the Stack Corruption problems:<br>
<br>
A. Stack Overrun<br>
<br>
As the book 'Advanced Windows Debugging' writes, A stack overrun occurs when <br>
a thread indiscriminately overwrites portions of its call stack reserved for <br>
other purposes. This can include, but is not limited to, overwriting the <br>
return address for a particular frame, overwriting entire frames, or even <br>
exhausting the stack completely. The net effect of stack overruns ranges from <br>
crashes to unpredictable behavior and even serious security holes. Stack <br>
overruns have become one of the most common attack angles for malicious <br>
software, as they can potentially allow the attacker to gain complete control <br>
of the computer on which the faulty software runs, by overwriting the return <br>
address of the current function on the stack.<br>
<br>
1. Array indexing errors cause the stack overrun. (See ArrayIndexingError)<br>
Array indexing errors are a source of memory overruns. Careful bounds <br>
checking and index management will help prevent this type of memory overrun.<br>
<br>
2. Static buffer overrun on the stack. (See: OverrunStaticBuffer)<br>
A static buffer overrun occurs when a buffer, which has been declared on the <br>
stack, is written to with more data than it was allocated to hold. The less <br>
apparent versions of this error occur when unverified user input data is <br>
copied directly to a static variable using operations such as CopyMemory, <br>
strcat, strcpy, or wcscpy, causing potential stack corruption.<br>
<br>
The above overruns may overwrite the return address for the current frame, <br>
or overwrite entire frames, or even exhaust the stack completely, and thus <br>
cause the stack corruption. <br>
<br>
&nbsp; &nbsp;a) If the overwritten return address points to an invalid memory, the
<br>
&nbsp; &nbsp;application crashes with Access Violation once the current function <br>
&nbsp; &nbsp;returns. (See: ArrayIndexingError/b)<br>
<br>
&nbsp; &nbsp;b) If the overwritten return address happens to point to a valid memory,
<br>
&nbsp; &nbsp;the application will have unpredictable behavior depending on the content
<br>
&nbsp; &nbsp;in that memory. The application may also crash at some point.<br>
<br>
&nbsp; &nbsp;c) If the overwritten return address points to malicious codes that <br>
&nbsp; &nbsp;attackers injected, it will cause serious security problems.<br>
&nbsp; &nbsp;(See: ArrayIndexingError/a)<br>
<br>
B. Calling Convention Mismatch (See: MismatchCallingConvention)<br>
<br>
When the called function takes parameters, the mismatch of the calling <br>
convention results in the incorrect cleanup of the stack for parameters:<br>
<br>
&nbsp; &nbsp;a) The caller uses _cdecl to call a _stdcall function: <br>
&nbsp; &nbsp;The stack space for the function parameters is double freed.<br>
<br>
&nbsp; &nbsp;b) The caller uses _stdcall to call a _cdecl function:<br>
&nbsp; &nbsp;The stack space for the function parameters is not freed by mistake.<br>
<br>
The concequence of the mismatch of the calling convention is unpredictable. <br>
It may crash the application soon after the function returns, or it may have <br>
no impact on the process's execution at all.<br>
<br>
</p>
<h3>Debugging:</h3>
<p style="font-family:Courier New"><br>
Here we take the AV-crash caused by stack overrun as an example.<br>
<br>
Step1. Fire up the application under the debugger and let it run until the <br>
crash occurs.<br>
<br>
Step2. Dump the call-stack:<br>
<br>
0:000&gt; k<br>
ChildEBP RetAddr &nbsp;<br>
WARNING: Frame IP not in any known module. Following frames may be wrong.<br>
0029fe70 0029feb8 0xbad4<br>
0029fe74 009211a5 0x29feb8<br>
0029feb8 75c436d6 CppStackCorruption!__tmainCRTStartup&#43;0x10f<br>
0029fec4 770b883c kernel32!BaseThreadInitThunk&#43;0xe<br>
0029ff04 770b880f ntdll!__RtlUserThreadStart&#43;0x70<br>
0029ff1c 00000000 ntdll!_RtlUserThreadStart&#43;0x1b<br>
<br>
The stack looks broken.<br>
<br>
Step3. Check the instruction that was processed when the crash happened by <br>
dumping the EIP register, and looking at the memory that EIP is pointing to.<br>
<br>
0:000&gt; r eip<br>
eip=0000bad4<br>
<br>
0:000&gt; dd eip<br>
0000bad4 &nbsp;???????? ???????? ???????? ????????<br>
0000bae4 &nbsp;???????? ???????? ???????? ????????<br>
0000baf4 &nbsp;???????? ???????? ???????? ????????<br>
0000bb04 &nbsp;???????? ???????? ???????? ????????<br>
0000bb14 &nbsp;???????? ???????? ???????? ????????<br>
0000bb24 &nbsp;???????? ???????? ???????? ????????<br>
0000bb34 &nbsp;???????? ???????? ???????? ????????<br>
0000bb44 &nbsp;???????? ???????? ???????? ????????<br>
<br>
0:000&gt; !address eip<br>
ProcessParametrs 003f29a0 in range 003f0000 0040d000<br>
Environment 003f07f8 in range 003f0000 0040d000<br>
&nbsp; &nbsp;00000000 : 00000000 - 00010000<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Type &nbsp; &nbsp; 00000000
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Protect &nbsp;00000001 PAGE_NOACCESS<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;State &nbsp; &nbsp;00010000 MEM_FREE<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Usage &nbsp; &nbsp;RegionUsageFree<br>
<br>
The contents of that memory location are a series of question marks, which we <br>
know indicate inaccessible memory. The output of !address also proves it. <br>
From this trivial exercise, we can hypothesize that the instruction pointer <br>
the processor uses to control the flow of execution in our application has <br>
gotten into a corrupt state. Both the corrupted stack and the corrupted eip <br>
tell us that, it's very likely to be a overwritting of the return address of <br>
some function that causes the corruptions. Next, we need to find out the <br>
erroneous function.<br>
<br>
Unfortunately, finding the erroneous function is the most difficult part of <br>
the problem, because the record of the previous function call is cleaned up <br>
in the meantime. Microsoft is currently in progress of developing a tracing <br>
tool named TTT (tttrace.exe). TTT stands for Time Travel Tracing, it captures <br>
the execution of the program at instruction level, preserving scheduling <br>
information of all the threads and all memory updates. Once this information <br>
is captured in a trace file, it can be opened in windbg (which is the only <br>
debugger that supports it) and then it can be used to replay the execution of <br>
the program. It allows you almost everything that you can do during normal <br>
live debugging and since it is a recorded trace so you can go forward and <br>
backward in time with it. This gives you the unique ability to debug the <br>
problems efficiently and without holding the machine. Moreover if you see the <br>
effect of a bug after the cause is gone, then you can rewind the trace and <br>
then investigate it. Therefore, the job of finding the erroneous function for <br>
the crash problem caused by stack corruption will be much easier with the <br>
help of TTT.<br>
<br>
</p>
<h3>Detections:</h3>
<p style="font-family:Courier New"><br>
1. Detect stack overrun at compile time.<br>
<br>
Because stack buffer overruns are such common problems, there is a tool that <br>
can help detect these errors at compile time: PREfast.<br>
<br>
PREfast is the codename for the /analyze compiler switch and SAL annotations:<br>
<a target="_blank" href="http://blogs.msdn.com/vcblog/archive/2008/02/05/prefast-and-sal-annotations.aspx">http://blogs.msdn.com/vcblog/archive/2008/02/05/prefast-and-sal-annotations.aspx</a><br>
To enable PREfast, open the project's properties, and turn to the Code <br>
Analysis / General node. Change the value of &quot;Enable Code Analysis For C/C&#43;&#43;
<br>
on Build&quot; to &quot;Yes (/analyze)&quot;, then rebuild the project. You will see warning
<br>
messages of buffer overrun in the Error List window of Visual Studio. In this <br>
example, it throws these warnings for ArrayIndexingError:<br>
<br>
warning C6386: Buffer overrun: accessing 'n', the writable size is '8' bytes, <br>
but '12' bytes might be written<br>
warning C6201: Index '2' is out of valid index range '0' to '1' for possibly <br>
stack allocated buffer 'n'&nbsp;&nbsp;&nbsp;&nbsp;<br>
warning C6201: Index '3' is out of valid index range '0' to '1' for possibly <br>
stack allocated buffer 'n'&nbsp;&nbsp;&nbsp;&nbsp;<br>
<br>
, and these warnings for StaticBufferOverrun:<br>
<br>
warning C6204: Possible buffer overrun in call to 'wcscpy': use of unchecked <br>
parameter 'pszSource'<br>
warning C4996: 'wcscpy': This function or variable may be unsafe. Consider <br>
using wcscpy_s instead. To disable deprecation, use _CRT_SECURE_NO_WARNINGS. <br>
<br>
2. Detect stack overrun and calling convention mismatch at run-time.<br>
<br>
Unfortunately, Application Verifier cannot detect stack overrun and calling <br>
convention mismatch effectively at run-time. <br>
<br>
In VC&#43;&#43; compiler, there is an option to enable the stack frame runtime error <br>
checking: Project Properties / C/C&#43;&#43; / Code Generation / Basic Runtime Check. <br>
Stack frame checking is enabled when the option is set to &quot;Stack Frames <br>
(/RTCs)&quot;. The stack frame checking switch is on in Debug build, and it is off
<br>
in Release build by default. The option helps protect against a number of <br>
different stack corruptions:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Each time a function is called, it initializes all local variables to
<br>
&nbsp;&nbsp;&nbsp;&nbsp;nonzero values to prevent them from retaining old values from prior
<br>
&nbsp;&nbsp;&nbsp;&nbsp;function calls.<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;It verifies the stack pointer (esp register) to ensure that stack
<br>
&nbsp;&nbsp;&nbsp;&nbsp;corruptions caused by calling convention mismatches do not occur.<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;Protects against buffer overruns and underruns of local variables.<br>
<br>
When any of the three corruptions happens, the application is broken into a <br>
debugger with a break instruction exception. The callstack is like this:<br>
<br>
0:000&gt; k<br>
ChildEBP RetAddr &nbsp;<br>
0014efc4 00ac1ba9 ntdll!DbgBreakPoint<br>
0014fe18 00ac1bef CppStackCorruption!failwithmessage&#43;0x1ea<br>
0014fe28 00ac18a6 CppStackCorruption!_RTC_Failure&#43;0x37<br>
0014fe4c 00ac1091 CppStackCorruption!_RTC_CheckEsp&#43;0x18<br>
0014fe54 00ac11fc CppStackCorruption!wmain&#43;0x11<br>
0014fe98 75c436d6 CppStackCorruption!__tmainCRTStartup&#43;0x10f<br>
0014fea4 770b883c kernel32!BaseThreadInitThunk&#43;0xe<br>
0014fee4 770b880f ntdll!__RtlUserThreadStart&#43;0x70<br>
0014fefc 00000000 ntdll!_RtlUserThreadStart&#43;0x1b<br>
<br>
It is important to note that the /RTC compiler options are designed to work <br>
with debug builds and, as such, have no impact on released builds. The /RTC <br>
switch is meant solely to test your code during development.<br>
<br>
Other viable options to detect stack corruption at run-time include Rational's<br>
Purify or NuMega's BoundsChecker.<br>
<br>
</p>
<h3>Fixes:</h3>
<p style="font-family:Courier New"><br>
1. Array indexing errors are generally caused by the developers' carelessness. <br>
We can use PREfast to eliminate such errors.<br>
<br>
2. While copying a buffer, if the source buffer can be of variable length <br>
without upper boundaries, allocating the target buffer memory on the stack is <br>
not proper. Without knowing the size of the source at compile time, it is <br>
impossible to allocate a buffer on the stack that could hold the source. If <br>
this is the case, allocating the buffer from the heap is a better approach.<br>
<br>
3. It is recommended to replace all occurences of the unsafe buffer-copy APIs <br>
such as strcat, strcpy, or wcscpy with the secure ones like StringCchCopy, <br>
strcpy_s, and wcscpy_s, _mbscpy_s. The secure APIs allow you to specify the <br>
size of the destination string to ensure that no more than the specified <br>
number of characters are ever copied to the destination. We can use PREfast <br>
to find all unsafe uses of buffer-copy APIs, and replace them one by one.<br>
<br>
4. The developer should study the calling convention of the target function <br>
when dynamically loading a DLL. The calling convention can be studied by <br>
either reading the prolog and epilog of the target function, or by reading <br>
the document of the library if it exists, or by looking at the linker <br>
decoration of the export.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Mario Hewardt & Daniel Pravat, Advanced Windows Debugging Ch. 5 (2007), at <br>
<a target="_blank" href="http://advancedwindowsdebugging.com/.">http://advancedwindowsdebugging.com/.</a> &nbsp;Copyright 2008 by Pearson Education,
<br>
Inc. This material may be distributed only subject to the terms and <br>
conditions set forth in the Open Publication License, v1.0 or later (the <br>
latest version is presently available at <a target="_blank" href="http://www.opencontent.org/openpub/).">
http://www.opencontent.org/openpub/).</a> &nbsp;<br>
Excerpted by Jialiang Ge, 2009. <br>
<br>
Avoiding Buffer Overruns<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms717795.aspx">http://msdn.microsoft.com/en-us/library/ms717795.aspx</a><br>
<br>
Debug Tutorial Part 2: The Stack<br>
<a target="_blank" href="http://www.codeproject.com/KB/debug/cdbntsd2.aspx">http://www.codeproject.com/KB/debug/cdbntsd2.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

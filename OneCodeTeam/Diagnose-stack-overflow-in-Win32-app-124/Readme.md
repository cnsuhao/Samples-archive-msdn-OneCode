# Diagnose stack overflow in Win32 app (CppStackOverflow)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Diagnostics
## Topics
* Stack Overflow
## IsPublished
* True
## ModifiedDate
* 2011-05-05 04:37:42
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CppStackOverflow Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
CppStackOverflow is designed to show how stack overflow happens in C&#43;&#43; <br>
applications. When a thread is created, 1MB of virtual memory is reserved for <br>
use by the thread as a stack. Unlike the heap, it does not expand as needed. <br>
Its initial size can be changed via /STACK linker switch (See Project <br>
Property Pages / Linker / System / Stack Reserve Size). When too much memory <br>
is used on the call stack the stack is said to overflow, typically resulting <br>
in a program crash. This class of software bug is usually caused by one of <br>
two types of programming errors: allocation of large stack variable and <br>
deeply recursive function calls.<br>
<br>
</p>
<h3>Symptoms:</h3>
<p style="font-family:Courier New"><br>
The application crashes with the Stack Overflow error.<br>
<br>
</p>
<h3>Causes:</h3>
<p style="font-family:Courier New"><br>
There are three possible causes of the Stack Overflow error:<br>
<br>
1. A thread uses the entire stack reserved for it. This is often caused by <br>
deep recursion or allocation of very large stack variable.<br>
<br>
2. A thread cannot extend the stack because the page file is maxed out, and <br>
therefore no additional pages can be committed to extend the stack. <br>
<br>
3. A thread cannot extend the stack because the system is within the brief <br>
period used to extend the page file. <br>
<br>
</p>
<h3>Debugging:</h3>
<p style="font-family:Courier New"><br>
A. Visual Studio<br>
<br>
Step1. Set a breakpoint (F9) at the end of the StackOverflow() function where <br>
it is calling StackOverflow() again recursively.<br>
<br>
Step2. Press F5 to start debugging.<br>
<br>
Step3. Press Ctrl&#43;Alt&#43;M or Click the Memory button in the Debug / Windows <br>
menu item to bring up the Memory window.<br>
<br>
Step4. Type ESP in the Memory window, and press ENTER. &nbsp;Note the block of &nbsp;<br>
memory on the stack set to zero.<br>
<br>
Step5. Press F5 to recursively call StackOverflow. This hits the breakpoint <br>
again.<br>
<br>
Step6. Type ESP in the Memory window, and press ENTER. This time the block of <br>
memory on the stack was filled with 0x01 bytes. But if you scroll down, the <br>
block of 0x00 bytes is below. The recursive calls to StackOverflow means that <br>
the stack space will not get cleaned up until all of the nested functions <br>
return. In this case, that will never happen.<br>
<br>
Step7. Press F5 for several more times. Eventually, you get a stack overflow <br>
error.<br>
<br>
B. Windbg<br>
<br>
Step1. See what event caused the debugger to break in:<br>
<br>
0:000&gt; .lastevent<br>
Last event: 2388.2f4c: Stack overflow - code c00000fd (!!! second chance !!!)<br>
&nbsp;debugger time: Thu Apr &nbsp;2 16:35:59.191 2009 (GMT&#43;8)<br>
<br>
Step2 Dump the callstack:<br>
<br>
0:000&gt; k<br>
ChildEBP RetAddr &nbsp;<br>
0013abd4 00da1453 CppStackOverflow!_chkstk&#43;0x27<br>
00153370 00da1453 CppStackOverflow!StackOverflow&#43;0x93 <br>
0016bb0c 00da1453 CppStackOverflow!StackOverflow&#43;0x93 <br>
001842a8 00da1453 CppStackOverflow!StackOverflow&#43;0x93 <br>
0019ca44 00da1453 CppStackOverflow!StackOverflow&#43;0x93 <br>
001b51e0 00da1453 CppStackOverflow!StackOverflow&#43;0x93 <br>
001cd97c 00da1453 CppStackOverflow!StackOverflow&#43;0x93 <br>
001e6118 00da1453 CppStackOverflow!StackOverflow&#43;0x93 <br>
001fe8b4 00da1453 CppStackOverflow!StackOverflow&#43;0x93 <br>
00217050 00da1453 CppStackOverflow!StackOverflow&#43;0x93 <br>
0022f7ec 00da1515 CppStackOverflow!StackOverflow&#43;0x93 <br>
0022f8c4 00da1b18 CppStackOverflow!wmain&#43;0x25 <br>
0022f914 00da195f CppStackOverflow!__tmainCRTStartup&#43;0x1a8 <br>
0022f91c 76e04911 CppStackOverflow!wmainCRTStartup&#43;0xf <br>
0022f928 77d6e4b6 kernel32!BaseThreadInitThunk&#43;0xe<br>
0022f968 77d6e489 ntdll!__RtlUserThreadStart&#43;0x23<br>
0022f980 00000000 ntdll!_RtlUserThreadStart&#43;0x1b<br>
<br>
Step3. Calculate the approximate size of the current stack:<br>
<br>
0:000&gt; ?? (0x0022f980 - @esp)<br>
unsigned int 0xf4db4<br>
<br>
The current size is 0xf4db4 bytes (i.e. 979KB), which is near the limit (1MB).<br>
<br>
</p>
<h3>Detections:</h3>
<p style="font-family:Courier New"><br>
1. Detecting stack overflow at compile time.<br>
<br>
The VC&#43;&#43; compiler itself is capable of detecting infinite recursion to some <br>
extent. When the compiler finds such a problem, it throws the following <br>
warning in the error list.<br>
<br>
warning C4717: 'StackOverflow' : recursive on all control paths, function <br>
will cause runtime stack overflow<br>
<br>
If we enable PREfast in the compiler (Project Properties / Code Analysis / <br>
General node. Change the value of &quot;Enable Code Analysis For C/C&#43;&#43; on Build&quot;
<br>
to &quot;Yes (/analyze)&quot;), the compiler will also report the overuse of the stack:<br>
<br>
warning C6262: Function uses '100012' bytes of stack: exceeds <br>
/analyze:stacksize'16384'. Consider moving some data to heap<br>
<br>
2. Detecting stack overflow at run-time.<br>
<br>
The application directly crashes with the Stack Overflow error at run-time.<br>
<br>
</p>
<h3>Fixes:</h3>
<p style="font-family:Courier New"><br>
1. Limit the recursion depth.<br>
<br>
2. Keep large allocations on the heap rather than the stack.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Wiki: Stack overflow<br>
<a target="_blank" href="http://en.wikipedia.org/wiki/Stack_overflow">http://en.wikipedia.org/wiki/Stack_overflow</a><br>
<br>
Debugging Tools for Windows: Debugging a Stack Overflow<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc267849.aspx">http://msdn.microsoft.com/en-us/library/cc267849.aspx</a><br>
<br>
How to trap stack overflow in a Visual C&#43;&#43; application<br>
<a target="_blank" href="http://support.microsoft.com/kb/315937">http://support.microsoft.com/kb/315937</a><br>
<br>
MSDN: 6.1.4 Stack Overflow Handling<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa227159.aspx">http://msdn.microsoft.com/en-us/library/aa227159.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

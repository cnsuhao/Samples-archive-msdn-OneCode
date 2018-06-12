# Use shared memory for IPC in VB (VBFileMappingServer)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* IPC and RPC
* Windows General
## Topics
* File mapping
* Shared Memory
* Inter-process Communication
## IsPublished
* True
## ModifiedDate
* 2013-02-19 05:31:52
## Description

<p style="font-family:Courier New">&nbsp;</p>
<h2>CONSOLE APPLICATION : VBFileMappingServer Project Overview</h2>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
File mapping is a mechanism for one-way or duplex inter-process communication <br>
among two or more processes in the local machine. To share a file or memory, <br>
all of the processes must use the name or the handle of the same file mapping <br>
object.<br>
<br>
To share a file, the first process creates or opens a file by using the <br>
CreateFile function. Next, it creates a file mapping object by using the <br>
CreateFileMapping function, specifying the file handle and a name for the <br>
file mapping object. The names of event, semaphore, mutex, waitable timer, <br>
job, and file mapping objects share the same name space. Therefore, the <br>
CreateFileMapping and OpenFileMapping functions fail if they specify a name<br>
that is in use by an object of another type.<br>
<br>
To share memory that is not associated with a file, a process must use the <br>
CreateFileMapping function and specify INVALID_HANDLE_VALUE as the hFile <br>
parameter instead of an existing file handle. The corresponding file mapping <br>
object accesses memory backed by the system paging file. You must specify <br>
a size greater than zero when you use an hFile of INVALID_HANDLE_VALUE in a <br>
call to CreateFileMapping.<br>
<br>
Processes that share files or memory must create file views by using the <br>
MapViewOfFile or MapViewOfFileEx function. They must coordinate their access <br>
using semaphores, mutexes, events, or some other mutual exclusion technique.<br>
<br>
The VB.NET code sample demonstrates creating a file mapping object named <br>
&quot;Local\SampleMap&quot; and writing a string to the file mapping. Because the Base <br>
Class Library of .NET Framework 2/3/3.5 does not have any public classes to <br>
operate on file mapping objects, you have to P/Invoke the Windows APIs as <br>
shown in this code sample.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
The following steps walk through a demonstration of the file mapping sample.<br>
<br>
Step1. After you successfully build the VBFileMappingClient and <br>
VBFileMappingServer sample projects in Visual Studio 2008, you will get the <br>
applications: VBFileMappingClient.exe and VBFileMappingServer.exe. <br>
<br>
Step2. Run VBFileMappingServer.exe in a command prompt. The application will <br>
create a file mapping object of a specified size that is backed by the system <br>
paging file. Its name is &quot;Local\SampleMap&quot;.<br>
<br>
&nbsp;The file mapping (Local\SampleMap) is created<br>
<br>
Next, the application maps a view of the file mapping into the address space <br>
of the process, and writes a string to the view.<br>
<br>
&nbsp;The file view is mapped<br>
&nbsp;This message is written to the view:<br>
&nbsp;&quot;Message from the first process.&quot;<br>
<br>
Step3. Run VBFileMappingClient.exe in another command prompt. <br>
VBFileMappingClient opens the file mapping object &quot;Local\SampleMap&quot;, maps <br>
the same view of the file mapping into its address space, and read the string <br>
written by the first process from the view.<br>
<br>
&nbsp;The file mapping (Local\SampleMap) is opened<br>
&nbsp;The file view is mapped<br>
&nbsp;Read from the file mapping:<br>
&nbsp;&quot;Message from the first process.&quot;<br>
<br>
Step4. Press ENTER in both command prompts to close VBFileMappingServer and <br>
VBFileMappingClient.<br>
<br>
</p>
<h3>Sample Relation:</h3>
<p style="font-family:Courier New">(The relationship between the current sample and the rest samples in
<br>
Microsoft All-In-One Code Framework <a href="http://1code.codeplex.com)" target="_blank">
http://1code.codeplex.com)</a><br>
<br>
VBFileMappingClient -&gt; VBFileMappingServer<br>
VBFileMappingServer creates the file mapping named &quot;Local\SampleMap&quot; and <br>
writes a string to it. VBFileMappingClient reads the string from the file <br>
mapping.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. Create a file mapping named &quot;Local\SampleMap&quot; by P/Invoking <br>
CreateFileMapping.<br>
<br>
2. Map a view of the file mapping into the address space of the current <br>
process by P/Invoking MapViewOfFile.<br>
<br>
3. Write a string to the file view.<br>
<br>
4. Unmap the file view (UnmapViewOfFile) and close the file mapping object <br>
(CloseHandle).<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Creating Named Shared Memory<br>
<a href="http://msdn.microsoft.com/en-us/library/aa366551.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/aa366551.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

# Synchronous file I/O operation demo (CppSynchronousIO)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* File System
## Topics
* IO
* CreateFile
* WriteFile
* ReadFile
## IsPublished
* True
## ModifiedDate
* 2011-05-05 04:39:21
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CppSynchronousIO Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
CppSynchronousIO demonstrates the synchronous file I/O operations. In <br>
synchronous file I/O, a thread starts an I/O operation and immediately <br>
enters a wait state until the I/O request has completed. <br>
<br>
</p>
<h3>Project Relation:</h3>
<p style="font-family:Courier New"><br>
CppSynchronousIO - CppAsynchronousIO<br>
CppSynchronousIO demonstrates synchronous I/O and CppAsynchronousIO shows <br>
asynchronous I/O operations.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. Create/open a file for read and write without the FILE_FLAG_OVERLAPPED <br>
flag. If the FILE_FLAG_OVERLAPPED flag is specified, the system will think <br>
that you want to perform asynchronous I/O with the device. (CreateFile)<br>
<br>
2. Synchronously write bytes to the file by calling WriteFile. The OVERLAPPED <br>
structure is optional for the API. Its return value indicates whether the <br>
synchronous write operation succeeds or not.<br>
<br>
3. Synchronously read bytes from the file by calling ReadFile. The OVERLAPPED <br>
structure is optional for the API. Its return value indicates whether the <br>
synchronous read operation succeeds or not.<br>
<br>
4. Pay attention to the current file pointer while reading and writing the <br>
file using the same file handle. Calling CreateFile causes the system to <br>
create a file kernel object that manages operations on the file. Inside this <br>
kernel object is a file pointer. &nbsp;This file pointer indicates the 64-bit <br>
offset within the file where the next synchronous read or write should be <br>
performed. Initially, this file pointer is set to 0, so if you call ReadFile <br>
immediately after a call to CreateFile, you will start reading the file from <br>
offset 0. If you read 10 bytes of the file into memory, the system updates <br>
the pointer associated with the file handle so that the next call to ReadFile <br>
starts reading at the eleventh byte in the file at offset 10. To set the <br>
position of the current file pointer, use the SetFilePointerEx API.<br>
<br>
5. Close the file. (CloseHandle)<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Synchronous and Asynchronous I/O<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa365683.aspx">http://msdn.microsoft.com/en-us/library/aa365683.aspx</a>
<br>
<br>
MSDN: Opening a File for Reading or Writing<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb540534.aspx">http://msdn.microsoft.com/en-us/library/bb540534.aspx</a><br>
<br>
Windows via C/C&#43;&#43;, Fifth Edition. Performing Synchronous Device I/O<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc500402.aspx">http://msdn.microsoft.com/en-us/library/cc500402.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

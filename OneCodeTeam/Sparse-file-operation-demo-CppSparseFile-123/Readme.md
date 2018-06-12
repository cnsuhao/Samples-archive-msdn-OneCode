# Sparse file operation demo (CppSparseFile)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* File System
## Topics
* Sparse File
## IsPublished
* True
## ModifiedDate
* 2011-05-05 04:36:37
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CppSparseFile Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
CppSparseFile demonstrates the common operations on sparse files. A sparse <br>
file is a type of computer file that attempts to use file system space more <br>
efficiently when blocks allocated to the file are mostly empty. This is <br>
achieved by writing brief information (metadata) representing the empty <br>
blocks to disk instead of the actual &quot;empty&quot; space which makes up the block,
<br>
using less disk space. You can find in this example the creation of sparse <br>
file, the detection of sparse attribute, the retrieval of sparse file size, <br>
and the query of sparse file layout.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
A. Determine if the volume support sparse streams.<br>
<br>
The Win32 API function GetVolumeInformation returns a set of file system <br>
flags that you can analyze to determine if the drive supports sparse streams. <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;DWORD dwVolFlags;<br>
&nbsp;&nbsp;&nbsp;&nbsp;GetVolumeInformation(lpRootPathName, NULL, MAX_PATH, NULL, NULL,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&dwVolFlags, NULL, MAX_PATH);<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;return (dwVolFlags & FILE_SUPPORTS_SPARSE_FILES) ? TRUE : FALSE;<br>
<br>
B. Create a sparse file.<br>
<br>
After creating a normal file, you must use the DeviceIoControl function with <br>
the FSCTL_SET_SPARSE control code to mark the file as sparse. Then you write <br>
blocks of data to the file and specify the region of data as sparse using <br>
the DeviceIoControl function with the FSCTL_SET_ZERO_DATA control code. The <br>
function also requires the starting and the ending address (not the size) of <br>
the sparse zero block. Note, however, that this operation does not perform <br>
actual file I/O, and unlike the WriteFile function, it does not move the <br>
current file I/O pointer or sets the end-of-file pointer. That is, if you <br>
want to place a sparse zero block in the end of the file, you must move the <br>
file pointer accordingly using the SetFilePointer function and call the <br>
SetEndOfFile function, otherwise DeviceIoControl will have no effect. <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// Create a normal file<br>
&nbsp;&nbsp;&nbsp;&nbsp;HANDLE hSparseFile = CreateFile(lpFileName, GENERIC_WRITE, 0, NULL,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;if (hSparseFile == INVALID_HANDLE_VALUE)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return hSparseFile;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// Use the DeviceIoControl function with the FSCTL_SET_SPARSE control
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// code to mark the file as sparse. If you don't mark the file as sparse,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// the FSCTL_SET_ZERO_DATA control code will actually write zero bytes to
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// the file instead of marking the region as sparse zero area.<br>
&nbsp;&nbsp;&nbsp;&nbsp;DWORD dwTemp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;DeviceIoControl(hSparseFile, FSCTL_SET_SPARSE, NULL, 0, NULL, 0, &dwTemp,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NULL);<br>
<br>
C. Determine if a file is sparse.<br>
<br>
In order to check if a file is sparse, use GetFileAttributes to check for <br>
the FILE_ATTRIBUTE_SPARSE_FILE attribute.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// Open the file for read<br>
&nbsp;&nbsp;&nbsp;&nbsp;HANDLE hFile = CreateFile(lpFileName, GENERIC_READ, 0, NULL,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);<br>
&nbsp;&nbsp;&nbsp;&nbsp;if (hFile == INVALID_HANDLE_VALUE)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return FALSE;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// Get file information<br>
&nbsp;&nbsp;&nbsp;&nbsp;BY_HANDLE_FILE_INFORMATION bhfi;<br>
&nbsp;&nbsp;&nbsp;&nbsp;GetFileInformationByHandle(hFile, &bhfi);<br>
&nbsp;&nbsp;&nbsp;&nbsp;CloseHandle(hFile);<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;return (bhfi.dwFileAttributes & FILE_ATTRIBUTE_SPARSE_FILE)
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;? TRUE : FALSE;<br>
<br>
D. Get file size.<br>
<br>
Use the GetCompressedFileSize function to obtain the actual size allocated on <br>
disk for a sparse file. This total does not include the size of the regions <br>
which were deallocated because they were filled with zeroes. Use the <br>
GetFileSizeEx function to determine the total size of a file, including the <br>
size of the sparse regions that were deallocated.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// Retrieves the size of the specified file, in bytes. The size includes
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// both allocated ranges and sparse ranges.<br>
&nbsp;&nbsp;&nbsp;&nbsp;HANDLE hFile = CreateFile(lpFileName, GENERIC_READ, 0, NULL,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);<br>
&nbsp;&nbsp;&nbsp;&nbsp;if (hFile == INVALID_HANDLE_VALUE)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return FALSE;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;LARGE_INTEGER liSparseFileSize;<br>
&nbsp;&nbsp;&nbsp;&nbsp;GetFileSizeEx(hFile, &liSparseFileSize);<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;// Retrieves the file's actual size on disk, in bytes. The size does not
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// include the sparse ranges.<br>
&nbsp;&nbsp;&nbsp;&nbsp;LARGE_INTEGER liSparseFileCompressedSize;<br>
&nbsp;&nbsp;&nbsp;&nbsp;liSparseFileCompressedSize.LowPart = GetCompressedFileSize(lpFileName,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(LPDWORD)&liSparseFileCompressedSize.HighPart);<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// Print the result<br>
&nbsp;&nbsp;&nbsp;&nbsp;wprintf(L&quot;\nFile total size: %I64uKB\nActual size on disk: %I64uKB\n&quot;,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;liSparseFileSize.QuadPart / 1024,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;liSparseFileCompressedSize.QuadPart / 1024);<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;CloseHandle(hFile);<br>
<br>
E. Query the sparse file layout.<br>
<br>
You can specify the range to query in DeviceIoControl with the <br>
FSCTL_QUERY_ALLOCATED_RANGES control code, and provide a sufficient buffer <br>
for output info. The output contains the allocated (not sparse) regions in <br>
the sparse file.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Sparse Files<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa365564.aspx">http://msdn.microsoft.com/en-us/library/aa365564.aspx</a><br>
<br>
NTFS Sparse Files For Programmers<br>
<a target="_blank" href="http://www.flexhex.com/docs/articles/sparse-files.phtml">http://www.flexhex.com/docs/articles/sparse-files.phtml</a><br>
<br>
Technet: Fsutil sparse<br>
<a target="_blank" href="http://technet.microsoft.com/en-us/library/cc788025.aspx">http://technet.microsoft.com/en-us/library/cc788025.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

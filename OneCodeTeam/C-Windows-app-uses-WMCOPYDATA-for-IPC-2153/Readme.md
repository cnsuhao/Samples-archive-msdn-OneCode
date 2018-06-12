# C++ Windows app uses WM_COPYDATA for IPC (CppReceiveWM_COPYDATA)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Windows General
## Topics
* WM_COPYDATA
* Inter-process Communication
## IsPublished
* True
## ModifiedDate
* 2011-05-05 04:32:16
## Description

<p style="font-family:Courier New"></p>
<h2>WIN32 APPLICATION : CppReceiveWM_COPYDATA Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
Inter-process Communication (IPC) based on the Windows message WM_COPYDATA is <br>
a mechanism for exchanging data among Windows applications in the local <br>
machine. The receiving application must be a Windows application. The data <br>
being passed must not contain pointers or other references to objects not <br>
accessible to the application receiving the data. While WM_COPYDATA is being <br>
sent, the referenced data must not be changed by another thread of the <br>
sending process. The receiving application should consider the data read-only. <br>
If the receiving application must access the data after SendMessage returns, <br>
it needs to copy the data into a local buffer.<br>
<br>
This code sample demonstrates receiving a custom data structure (MY_STRUCT) <br>
from the sending application (CppSendWM_COPYDATA) by handling WM_COPYDATA <br>
messages.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
The following steps walk through a demonstration of the WM_COPYDATA samples.<br>
<br>
Step1. After you successfully build the CppSendWM_COPYDATA and <br>
CppReceiveWM_COPYDATA sample projects in Visual Studio 2008, you will get the <br>
applications: CppSendWM_COPYDATA.exe and CppReceiveWM_COPYDATA.exe. <br>
<br>
Step2. Run CppSendWM_COPYDATA.exe and CppReceiveWM_COPYDATA.exe. In <br>
CppSendWM_COPYDATA, input the Number and Message fields.<br>
<br>
&nbsp;Number: 123456<br>
&nbsp;Message: Hello World<br>
<br>
Then click the SendMessage button. The number and the message will be sent <br>
to CppReceiveWM_COPYDATA through a WM_COPYDATA message. When <br>
CppReceiveWM_COPYDATA receives the message, the application extracts the <br>
number and the message, and display them in the window.<br>
<br>
</p>
<h3>Sample Relation:</h3>
<p style="font-family:Courier New">(The relationship between the current sample and the rest samples in
<br>
Microsoft All-In-One Code Framework <a target="_blank" href="http://1code.codeplex.com)">
http://1code.codeplex.com)</a><br>
<br>
CppSendWM_COPYDATA -&gt; CppReceiveWM_COPYDATA<br>
CppSendWM_COPYDATA sends data to CppReceiveWM_COPYDATA through the &nbsp;<br>
WM_COPYDATA message.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. In DiagProc or WndProc, capture and handle the WM_COPYDATA message<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;HANDLE_MSG (hWnd, WM_COPYDATA, OnCopyData);<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;BOOL OnCopyData(HWND hWnd, HWND hwndFrom, PCOPYDATASTRUCT pcds)<br>
&nbsp;&nbsp;&nbsp;&nbsp;{ &nbsp;}<br>
<br>
2. In OnCopyData, get the COPYDATASTRUCT struct from lparam of the <br>
WM_COPYDATA message, and fetch the data struct (MY_STRUCT) from <br>
COPYDATASTRUCT.lpData.<br>
<br>
The receiving application should consider the data (COPYDATASTRUCT-&gt;lpData) <br>
read-only. It is valid only during the processing of the message. The <br>
receiving application should not free the memory referenced by the paramter. <br>
If the receiving application must access the data after SendMessage returns, <br>
it must copy the data into a local buffer. <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;MY_STRUCT myStruct;<br>
&nbsp;&nbsp;&nbsp;&nbsp;memcpy_s(&myStruct, sizeof(myStruct), pcds-&gt;lpData, pcds-&gt;cbData);<br>
<br>
4. Display the data in the window.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: WM_COPYDATA Message<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms649011.aspx">http://msdn.microsoft.com/en-us/library/ms649011.aspx</a><br>
<br>
MSDN: Using Data Copy<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms649009.aspx">http://msdn.microsoft.com/en-us/library/ms649009.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

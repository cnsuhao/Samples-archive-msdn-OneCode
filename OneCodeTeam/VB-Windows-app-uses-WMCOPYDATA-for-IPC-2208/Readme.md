# VB Windows app uses WM_COPYDATA for IPC (VBReceiveWM_COPYDATA)
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
* 2011-05-05 08:04:17
## Description

<p style="font-family:Courier New"></p>
<h2>WINDOWS APPLICATION : VBReceiveWM_COPYDATA Project Overview</h2>
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
This code sample demonstrates receiving a custom data structure (MyStruct) <br>
from the sending application (VBSendWM_COPYDATA) by handling WM_COPYDATA <br>
messages.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
The following steps walk through a demonstration of the WM_COPYDATA samples.<br>
<br>
Step1. After you successfully build the VBSendWM_COPYDATA and <br>
VBReceiveWM_COPYDATA sample projects in Visual Studio 2008, you will get the <br>
applications: VBSendWM_COPYDATA.exe and VBReceiveWM_COPYDATA.exe. <br>
<br>
Step2. Run VBSendWM_COPYDATA.exe and VBReceiveWM_COPYDATA.exe. In <br>
VBSendWM_COPYDATA, input the Number and Message fields.<br>
<br>
&nbsp;Number: 123456<br>
&nbsp;Message: Hello World<br>
<br>
Then click the SendMessage button. The number and the message will be sent <br>
to VBReceiveWM_COPYDATA through a WM_COPYDATA message. When <br>
VBReceiveWM_COPYDATA receives the message, the application extracts the <br>
number and the message, and display them in the window.<br>
<br>
</p>
<h3>Sample Relation:</h3>
<p style="font-family:Courier New">(The relationship between the current sample and the rest samples in
<br>
Microsoft All-In-One Code Framework <a target="_blank" href="http://1code.codeplex.com)">
http://1code.codeplex.com)</a><br>
<br>
VBSendWM_COPYDATA -&gt; VBReceiveWM_COPYDATA<br>
VBSendWM_COPYDATA sends data to VBReceiveWM_COPYDATA through the WM_COPYDATA <br>
message.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. Override the WndProc method in the Windows Form.<br>
<br>
&nbsp; &nbsp;Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)<br>
&nbsp; &nbsp;End Sub<br>
<br>
2. Handle the WM_COPYDATA message in WndProc <br>
<br>
&nbsp; &nbsp;If (m.Msg = WM_COPYDATA) Then<br>
&nbsp; &nbsp;End If<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
3. Get the COPYDATASTRUCT struct from lParam of the WM_COPYDATA message, and <br>
fetch the data (MyStruct object) from COPYDATASTRUCT.lpData.<br>
<br>
&nbsp; &nbsp;' Get the COPYDATASTRUCT struct from lParam.<br>
&nbsp; &nbsp;Dim cds As COPYDATASTRUCT = m.GetLParam(GetType(COPYDATASTRUCT))<br>
<br>
&nbsp; &nbsp;' If the size matches<br>
&nbsp; &nbsp;If (cds.cbData = Marshal.SizeOf(GetType(MyStruct))) Then<br>
&nbsp; &nbsp; &nbsp; &nbsp;' Marshal the data from the unmanaged memory block to a MyStruct
<br>
&nbsp; &nbsp; &nbsp; &nbsp;' managed struct.<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim myStruct As MyStruct = Marshal.PtrToStructure(cds.lpData, _<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;GetType(MyStruct))<br>
&nbsp; &nbsp;End If<br>
<br>
4. Display the data in the form.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
WM_COPYDATA Message<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms649011.aspx">http://msdn.microsoft.com/en-us/library/ms649011.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

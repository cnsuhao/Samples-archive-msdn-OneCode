# C++ mailslot client for IPC (CppMailslotClient)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Windows General
## Topics
* mailslot
* Inter-process Communication
## IsPublished
* True
## ModifiedDate
* 2011-05-05 04:29:24
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CppMailslotClient Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
Mailslot is a mechanism for one-way inter-process communication in the local<br>
machine or across the computers in the intranet. Any clients can store <br>
messages in a mailslot. The creator of the slot, i.e. the server, retrieves <br>
the messages that are stored there:<br>
<br>
Client (GENERIC_WRITE) ---&gt; Server (GENERIC_READ)<br>
<br>
This sample demonstrates a mailslot client that connects and writes to the <br>
mailslot &quot;\\.\mailslot\SampleMailslot&quot;. <br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
The following steps walk through a demonstration of the mailslot sample.<br>
<br>
Step1. After you successfully build the CppMailslotClient and <br>
CppMailslotServer sample projects in Visual Studio 2008, you will get the <br>
applications: CppMailslotClient.exe and CppMailslotServer.exe. <br>
<br>
Step2. Run CppMailslotServer.exe in a command prompt to start up the server <br>
end of the mailslot. The application will output the following information <br>
in the command prompt if the mailslot is created successfully.<br>
<br>
&nbsp;Server:<br>
&nbsp; &nbsp;The mailslot (\\.\mailslot\SampleMailslot) is created.<br>
<br>
Step3. Run CppMailslotClient.exe in another command prompt to start up the <br>
client end of the mailslot. The application should output the message below <br>
in the command prompt when the client successfully opens the mailslot.<br>
<br>
&nbsp;Client:<br>
&nbsp; &nbsp;The mailslot (\\.\mailslot\SampleMailslot) is opened.<br>
<br>
Step4. The client attempts to write three messages to the mailslot. <br>
<br>
&nbsp;Client:<br>
&nbsp; &nbsp;The message &quot;Message 1 for mailslot&quot; is written to the slot<br>
&nbsp; &nbsp;The message &quot;Message 2 for mailslot&quot; is written to the slot<br>
&nbsp; &nbsp;The message &quot;Message 3 for mailslot&quot; is written to the slot<br>
<br>
There is a three seconds' interval between the second message and the third <br>
one. During the interval, if you press ENTER in the server application, the <br>
mailslot server will retrieve the first two messages and display them. <br>
<br>
&nbsp;Server:<br>
&nbsp; &nbsp;Checking new messages...<br>
&nbsp; &nbsp;Message #1: Message 1 for mailslot<br>
&nbsp; &nbsp;Message #2: Message 2 for mailslot<br>
<br>
After the interval, the client writes the thrid message. If you press ENTER <br>
again in the server application, the mailslot server prints the message:<br>
<br>
&nbsp;Server:<br>
&nbsp; &nbsp;Checking new messages...<br>
&nbsp; &nbsp;Message #1: Message 3 for mailslot<br>
<br>
Step5. Enter 'Q' in the server application. This will close the mailslot and <br>
quit the server.<br>
<br>
</p>
<h3>Sample Relation:</h3>
<p style="font-family:Courier New">(The relationship between the current sample and the rest samples in
<br>
Microsoft All-In-One Code Framework <a target="_blank" href="http://1code.codeplex.com)">
http://1code.codeplex.com)</a><br>
<br>
CppMailslotClient -&gt; CppMailslotServer<br>
CppMailslotServer creates the mailslot. CppMailslotClient opens the mailslot <br>
and writes messages to it.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. Open the mailslot. (CreateFile)<br>
<br>
2. Write messages to the mailslot. (WriteFile)<br>
<br>
3. Close the mailslot. (CloseHandle)<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Using Mailslots / Writing to a Mailslot<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/aa365802.aspx">http://msdn.microsoft.com/en-us/library/aa365802.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

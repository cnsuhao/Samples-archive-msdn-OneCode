# Create low-integrity process in VB (VBCreateLowIntegrityProcess)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows SDK
## Topics
* Security
* UAC
* Integrity Level
## IsPublished
* True
## ModifiedDate
* 2012-03-01 11:56:07
## Description

<h1>Create low-integrity process in <span style="">VB</span> (<span style="">VB</span>CreateLowIntegrityProcess)<span style="">
</span></h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span style="">The code sample demonstrates how to start a low-integrity process. The application launches itself at the low integrity level when you click the &quot;Launch myself at low integrity level&quot; button on the application.
 Low integrity processes can only write to low integrity locations, such as the %USERPROFILE%\AppData\LocalLow folder or the HKEY_CURRENT_USER\Software\AppDataLow key. If you attempt to gain write access to objects at a higher integrity levels, you will get
 an access denied error even though the user's SID is granted write access in the discretionary access control list (DACL).
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">By default, child processes inherit the integrity level of their parent process. To start a low-integrity process, you must start a new child processwith a low-integrity access token by using CreateProcessAsUser. Please
 refer to the CreateLowIntegrityProcess sample function for details.</span><span style="">
</span></p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoNormal"><span style="">You must run this sample on Windows Vista or newer operating systems.
</span></p>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Press F5 to run this application, and you will see following window if you are an administrator of this machine.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/53345/1/image.png" alt="" width="229" height="185" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">If you click <b style="">Write to the LocalAppData folder</b> button or
<b style="">Write to the LocalAppDataLow folder</b> button, these operations will succeed.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/53346/1/image.png" alt="" width="347" height="171" align="middle">
<img src="/site/view/file/53347/1/image.png" alt="" width="370" height="171" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Click <b style="">Launch myself at low integrity level</b> button, a new instance of this application will be launched.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/53348/1/image.png" alt="" width="229" height="185" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">If you click <b style="">Write to the LocalAppData folder</b> button, the operation will fail.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/53349/1/image.png" alt="" width="468" height="171" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">If you click <b style="">Write to the LocalAppDataLow folder</b> button, the operation will succeed.
</span></p>
<p class="MsoListParagraphCxSpLast"><span style=""><img src="/site/view/file/53350/1/image.png" alt="" width="370" height="171" align="middle">
</span><span style=""></span></p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">A.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><b style=""><span style="">Starting a process at low integrity</span></b><span style="">
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">By default, child processes inherit the integrity level of their parent process. To start a low-integrity process, you must start a new child process with a low-integrity access token using the function
<b style="">CreateProcessAsUser</b>. </span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">To start a low-integrity process
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">1)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Duplicate the handle of the current process, which is at medium integrity level by P/Invoking
<b style="">OpenProcessToken</b> and <b style="">DuplicateTokenEx</b>. </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">2)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">P/Invoke <b style="">SetTokenInformation</b> to set the integrity level in the access token to Low.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">3)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">P/Invoke <b style="">CreateProcessAsUser</b> to create a new process using the handle to the low integrity access token.
</span></p>
<p class="MsoListParagraphCxSpLast"><b style=""><span style="">CreateProcessAsUser</span></b><span style=""> updates the security descriptor in the new child process and the security descriptor for the access token to match the integrity level of the low-integrity
 access token. The <b style="">CreateLowIntegrityProcess</b> function in the code sample demonstrates this process.
</span></p>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">B.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><b style=""><span style="">Detecting the integrity level of the current process</span></b><span style="">
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">The <b style="">GetProcessIntegrityLevel</b> function in the code sample demonstrates how to get the integrity level of the current process.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">1)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Open the primary access token of the process with TOKEN_QUERY by P/Invoking
<b style="">OpenProcessToken</b>. </span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""><span style="">2)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">P/Invoke <b style="">GetTokenInformation</b> to query the
<b style="">TokenIntegrityLevel</b> information from the primary access token. </span>
</p>
<h2>More Information<span style=""> </span></h2>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/bb625960.aspx">MSDN: Designing Applications to Run at a Low Integrity Level</a></span><span style="">
</span></p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/bb250462(VS.85).aspx">MSDN: Understanding and Working in Protected Mode Internet Explorer</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

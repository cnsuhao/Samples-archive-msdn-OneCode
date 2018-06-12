# How to find the local group membership of a user in Windows
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Windows Service
* Windows SDK
* Windows Desktop App Development
* Windows SDK for Windows 8
## Topics
* Platform SDK
## IsPublished
* True
## ModifiedDate
* 2014-10-29 07:21:06
## Description

<p>&nbsp;</p>
<hr>
<div><a href="http://blogs.msdn.com/b/onecode"><img src="http://bit.ly/onecodesampletopbanner" alt=""></a></div>
<p>&nbsp;</p>
<p><span style="font-size:medium"><strong><span>How to find the local group membership of a user in Windows</span></strong></span></p>
<p><span style="font-size:medium"><strong>&nbsp;</strong></span><br>
<span style="font-size:small"><strong>Introduction</strong></span></p>
<p>This sample lists the group membership of the user, similar to what command &quot;whoami&quot; does. This sample can also list the group membership for the user when the machine is not connected. It gets the details from cache.</p>
<p><br>
<span style="font-size:small"><strong>Building the Sample</strong></span></p>
<p>This sample is built using Visual Studio 2012. There are no extra steps to build the sample.&nbsp;<br>
Running the SampleAfter building the sample, you can use the exe without any arguments.<br>
<br>
<span style="font-size:small"><strong>Using the Code</strong></span></p>
<p>The sample code opens the process token of current process using OpenProcessToken() and then uses GetTokenInformation() with TokenGroups.&nbsp;With the Sids for the groups received, we need to convert them to readable form. Here LookupAccountSid() is used.&nbsp;<br>
For disconnected state, the sample gets the information from local cache. Ignore error 1789 to continue the sample in disconnected state.&nbsp;&nbsp;You may compare the results with &quot;whoami /all&quot; output for same user.&nbsp;</p>
<p><br>
<span style="font-size:small"><strong>More Information</strong></span></p>
<p><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa379295(v=vs.85).aspx" target="_blank">http://msdn.microsoft.com/en-us/library/windows/desktop/aa379295(v=vs.85).aspx</a></p>
<p><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa446671(v=vs.85).aspx" target="_blank">http://msdn.microsoft.com/en-us/library/windows/desktop/aa446671(v=vs.85).aspx</a></p>
<p><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa375213(v=vs.85).aspx" target="_blank">http://msdn.microsoft.com/en-us/library/windows/desktop/aa375213(v=vs.85).aspx</a></p>
<p><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa379166(v=vs.85).aspx" target="_blank">http://msdn.microsoft.com/en-us/library/windows/desktop/aa379166(v=vs.85).aspx</a></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640"><img src="http://bit.ly/onecodelogo" alt=""></a></div>

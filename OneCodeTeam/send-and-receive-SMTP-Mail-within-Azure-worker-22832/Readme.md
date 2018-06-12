# send and receive SMTP Mail within Azure worker role
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* Azure
## IsPublished
* True
## ModifiedDate
* 2013-06-19 11:46:31
## Description

<p class="MsoNormal"><span lang="EN-US" style="">As you know, System.Net.Mail API can't be used in Windows Runtime application,
</span></p>
<p class="MsoNormal"><span lang="EN-US" style="">However, we can create a WCF service to consume the API, and hold this service
</span></p>
<p class="MsoNormal"><span lang="EN-US" style="">on Azure. In this way, we can use this service to send email in Windows Store app.
</span></p>
<p class="MsoNormal"><span lang="EN-US" style="">Please follow these demonstration steps below.
</span></p>
<p class="MsoNormal"><span lang="EN-US" style="">Step 1: Set the email address and other email information in client project.
</span></p>
<p class="MsoNormal"><span lang="EN-US" style="">Step 2: Press </span><span lang="EN-US">Ctrl&#43;F5 start the work role on compute emulator.
</span><span lang="EN-US" style=""></span></p>
<p class="MsoNormal"><span lang="EN-US">Step 3: Right click Client project, choose debug-&gt;start new instance.</span><span lang="EN-US" style="">
</span></p>
<p class="MsoNormal"><span lang="EN-US">Step 4: Check your target mail box, make sure you can receive the email.</span><span lang="EN-US" style="">
</span></p>
<p class="MsoNormal"><span lang="EN-US">Code Logical:</span></p>
<p class="MsoNormal"><span lang="EN-US">Step 1:<span style="">&nbsp; </span>Create the WCF Mail service class library.</span></p>
<p class="MsoNormal"><b style=""><span lang="EN-US" style="">MailOperationService.vb:
</span></b></p>
<p class="MsoNormal" style=""><span lang="EN-US"></span></p>
<p class="MsoNormal" style=""><span lang="EN-US">Step2:<span style="">&nbsp; </span>
Start the WCF host on the work role.</span></p>
<p class="MsoNormal" style=""><b style=""><span lang="EN-US" style="">WorkerRole.vb:
</span></b></p>
<p class="MsoNormal" style=""><span lang="EN-US"></span></p>
<p class="MsoNormal" style=""><span lang="EN-US">Step3:<span style="">&nbsp; </span>
Invoke the WCF service on client project.</span></p>
<p class="MsoNormal" style=""><b style=""><span lang="EN-US" style="">app.config:
</span></b></p>
<p class="MsoNormal" style=""><span lang="EN-US"></span></p>
<p class="MsoNormal" style=""><b style=""><span lang="EN-US" style="">Program.vb
</span></b></p>
<p class="MsoNormal" style=""><span lang="EN-US">Step 5: Build the application and you can debug it.</span></p>
<p class="MsoNormal" style=""><span lang="EN-US"><a href="http://msdn.microsoft.com/en-us/library/system.net.mail.smtpclient.aspx">http://msdn.microsoft.com/en-us/library/system.net.mail.smtpclient.aspx</a>
</span></p>
<p class="MsoNormal" style=""><span lang="EN-US"><a href="http://msdn.microsoft.com/en-us/library/system.net.mail.smtpclient.send.aspx">http://msdn.microsoft.com/en-us/library/system.net.mail.smtpclient.send.aspx</a>
</span></p>
<p class="MsoNormal" style=""><span lang="EN-US"><a href="http://msdn.microsoft.com/en-us/library/system.net.mail.aspx">http://msdn.microsoft.com/en-us/library/system.net.mail.aspx</a>
</span></p>
<p class="MsoNormal" style=""><span lang="EN-US"><a href="http://code.msdn.microsoft.com/CSSMTPSendEmail-c241f55d">http://code.msdn.microsoft.com/CSSMTPSendEmail-c241f55d</a>
</span></p>
<p class="MsoNormal" style=""><span lang="EN-US" style=""></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

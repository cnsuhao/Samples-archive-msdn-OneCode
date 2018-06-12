# How to increase the size of the ASP.NET Temporary Folder in Azure
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
## Topics
* Temporary Folder
## IsPublished
* True
## ModifiedDate
* 2013-07-03 11:21:52
## Description

<h1><span lang="EN-US">Increase the size of Asp.net Temporary folder in Azure (<span class="SpellE">CSAzureIncreaseTempFolderSize</span>)</span></h1>
<h2><span lang="EN-US">Introduction</span></h2>
<h2><span lang="EN" style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">By default the ASP.NET temporary folder size in a Windows Azure web role is limited to 100 MB. This is sufficient for the vast majority of
 applications, but some applications may require more storage space for temporary files. In particular this will happen for very large applications which generate a lot of dynamically generated code, or applications which use controls that make use of the temporary
 folder such as the standard <span class="SpellE">FileUpload</span> control. If you are encountering the problem of running out of temporary folder space you will get error messages such as
<span class="SpellE">OutOfMemoryException</span> or 'There is not enough space on the disk.'
</span></h2>
<h2><span lang="EN-US">Building the Sample</span></h2>
<p class="MsoNormal" style="text-autospace:none"><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black">This sample can be run as-is without making any changes to it.
</span></p>
<h2><span lang="EN-US">Running the Sample</span></h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">2)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Right click on the cloud service project i.e.
<span class="SpellE">CSAzureIncreaseTempFolderSize</span> and choose Publish. </span>
</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">3)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Follow the steps in publish Wizard and choose subscription details, deployment slots, etc. and enable remote desktop for all roles.
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span style="">4)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">After successful publish, login to Windows Azure VM via RDP and verify that IIS is using newly created AspNetTemp1GB for storing temporary files instead of
 default temporary ASP.net folder. </span></p>
<h2><span lang="EN-US">Using the Code</span></h2>
<p class="MsoNormal"><span lang="EN-US" style=""></span></p>
<p class="MsoListParagraph" style="text-indent:5.0pt; text-autospace:none"><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black"><span style="">1)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black">In the
<span class="SpellE">ServiceDefinition.csdef</span> create one <span class="SpellE">
LocalStorage</span> resource in the Web Role, and set the Runtime <span class="SpellE">
executionContext</span> to elevated. <span style="">&nbsp;</span>The elevated <span class="SpellE">
executionContext</span> allows us to use the <span class="SpellE">ServerManager</span> class to modify the IIS configuration during role startup.<span style="">&nbsp;&nbsp;&nbsp;
</span></span></p>
<p style="margin-left:36.0pt; text-indent:5.0pt"><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:#384B38"><span style="">2)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Add reference to
<span class="SpellE"><span style="color:#384B38">Microsoft.Web.Administration</span></span><span style="color:#384B38"> (location: &lt;<span class="SpellE">systemdrive</span>&gt;\system32\<span class="SpellE">inetsrv</span>) assembly and add below using
 statement to your project </span></span></p>
<p class="MsoNormal" style="text-indent:36.0pt; text-autospace:none"><span lang="EN-US" style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoListParagraph" style="text-indent:5.0pt; text-autospace:none"><span lang="EN-US" style="font-size:9.5pt; font-family:Consolas"><span style="">3)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;
</span></span></span><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Add the following code to the
<span class="SpellE">OnStart</span> routine in <span class="SpellE">WebRole.cs</span>.<span style="">&nbsp;
</span>This code configures the Website to point to the AspNetTemp1GB <span class="SpellE">
LocalStorage</span> resource.</span><span lang="EN-US" style="font-size:9.5pt; font-family:Consolas">
</span></p>
<p class="MsoNormal" style=""><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">For more information about the ASP.NET Temporary Folder see
<a href="http://msdn.microsoft.com/en-us/magazine/cc163496.aspx">http://msdn.microsoft.com/en-us/magazine/cc163496.aspx</a>
</span></p>
<p class="MsoNormal" style=""><span lang="EN-US" style=""></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

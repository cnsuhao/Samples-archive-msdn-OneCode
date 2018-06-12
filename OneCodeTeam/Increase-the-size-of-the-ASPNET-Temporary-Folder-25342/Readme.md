# Increase the size of the ASP.NET Temporary Folder in Windows Azure role instance
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
* 2013-10-16 11:51:32
## Description

<h1><span lang="EN-US">Increase the size of Asp.net Temporary folder in Azure (VBAzureIncreaseTempFolderSize)</span></h1>
<h2><span lang="EN-US">Introduction</span></h2>
<h2><span lang="EN" style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">By default the ASP.NET temporary folder size in a Windows Azure web role is limited to 100 MB. This is sufficient for the vast majority of
 applications, but some applications may require more storage space for temporary files. In particular this will happen for very large applications which generate a lot of dynamically generated code, or applications which use controls that make use of the temporary
 folder such as the standard FileUpload control. If you are encountering the problem of running out of temporary folder space you will get error messages such as OutOfMemoryException or 'There is not enough space on the disk.'
</span></h2>
<h2><span lang="EN-US">Building the Sample</span></h2>
<p class="MsoNormal" style="text-autospace:none"><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black">This sample can be run as-is without making any changes to it.
</span></p>
<h2><span lang="EN-US">Running the Sample</span></h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span>2)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Right click on the cloud service project i.e. VBAzureIncreaseTempFolderSize and choose Publish.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span>3)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Follow the steps in publish Wizard and choose subscription details, deployment slots, etc. and enable remote desktop for all roles.
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;"><span>4)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">After successful publish, login to Windows Azure VM via RDP and verify that IIS is using newly created AspNetTemp1GB for storing temporary files instead of
 default temporary ASP.net folder. </span></p>
<h2><span lang="EN-US">Using the Code</span></h2>
<p class="MsoNormal"><span lang="EN-US">&nbsp;</span></p>
<p class="MsoListParagraph" style="text-indent:5.0pt; text-autospace:none"><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black"><span>1)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:black">In the ServiceDefinition.csdef create one LocalStorage resource in the Web Role, and set the Runtime executionContext to elevated.<span>&nbsp;
</span>The elevated executionContext allows us to use the ServerManager class to modify the IIS configuration during role startup.<span>&nbsp;&nbsp;&nbsp;
</span></span></p>
<p style="margin-left:36.0pt; text-indent:5.0pt"><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; color:#384b38"><span>2)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Add reference to
<span style="color:#384b38">Microsoft.Web.Administration (location: &lt;systemdrive&gt;\system32\inetsrv) assembly and add below using statement to your project
</span></span></p>
<p class="MsoNormal" style="text-indent:36.0pt; text-autospace:none"><span lang="EN-US" style="font-size:9.5pt; font-family:Consolas">&nbsp;</span></p>
<p class="MsoListParagraph" style="text-indent:5.0pt; text-autospace:none"><span lang="EN-US" style="font-size:9.5pt; font-family:Consolas"><span>3)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;
</span></span></span><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Add the following code to the OnStart routine in WebRole.cs.<span>&nbsp;
</span>This code configures the Website to point to the AspNetTemp1GB LocalStorage resource.</span><span lang="EN-US" style="font-size:9.5pt; font-family:Consolas">
</span></p>
<p class="MsoNormal"><span lang="EN-US" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">For more information about the ASP.NET Temporary Folder see
<a href="http://msdn.microsoft.com/en-us/magazine/cc163496.aspx">http://msdn.microsoft.com/en-us/magazine/cc163496.aspx</a>
</span></p>
<p class="MsoNormal"><span lang="EN-US">&nbsp;</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

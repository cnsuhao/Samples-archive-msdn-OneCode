# Automate VS from outside VS IDE (CSVSAutomationOutsideIDE)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* VSX
## Topics
* Automation
* Visual Studio
## IsPublished
* False
## ModifiedDate
* 2011-05-05 06:29:25
## Description

<p style="font-family:Courier New"></p>
<h2>Visual Studio Automation : CSVSAutomationOutsideIDE Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
Demostrate how to automate Visual Studio outside the IDE. One can use <br>
existing Visual Studio instance or create a new one to execute specified <br>
command or automate by DTE object, like macro or add-in.<br>
<br>
In this sample, we first find an existing Visual Studio instance or create <br>
a new one and navigate its browser to All-In-One homepage.<br>
<br>
</p>
<h3>Steps:</h3>
<p style="font-family:Courier New"><br>
Step1. Reference EnvDTE object which is located at GAC and Visual Studio<br>
PublicAssembly folder.<br>
<br>
Step2. Find an existing IDE instance and obtain its DTE object.<br>
<br>
Step3. If there is no existing one, create a new one.<br>
<br>
Step4. Display the UI of the IDE by setting its visiblity property.<br>
<br>
Step5. Using DTE object to execute a command: View.URL to navigate Visual <br>
Studio embeded browser to All-In-One homepage.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
How to start Visual Studio programmatically<br>
<a target="_blank" href="http://blogs.msdn.com/kirillosenkov/archive/2009/03/03/how-to-start-visual-studio-programmatically.aspx">http://blogs.msdn.com/kirillosenkov/archive/2009/03/03/how-to-start-visual-studio-programmatically.aspx</a><br>
<br>
How to: Get References to the DTE and DTE2 Objects<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/68shb4dw.aspx">http://msdn.microsoft.com/en-us/library/68shb4dw.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

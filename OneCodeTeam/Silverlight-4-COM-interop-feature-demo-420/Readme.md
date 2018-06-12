# Silverlight 4 COM interop feature demo (CSSL4COMInterop)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* COM
* Silverlight
## Topics
* Interop
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:26:00
## Description

<p style="font-family:Courier New"></p>
<h2>SILVERLIGHT APPLICATION : CSSL4COMInterop Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This project created a simple application, which could interoperate with COM components,<br>
exporting data to notepad or Microsoft Excel applications.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
To test the silverlight4 COM interaction feature, please try the following steps:<br>
1. Install the silverlight application to local machine with evaluated permission.<br>
&nbsp;&nbsp;&nbsp;&nbsp;a. Open CSSL4COMInterop solution and compile.<br>
&nbsp;&nbsp;&nbsp;&nbsp;b. Run the project.<br>
&nbsp;&nbsp;&nbsp;&nbsp;c. Right click the silverlight application in browser, select &quot;Install CSSL4COMInterop<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; application on to this computer...&quot;, then click &quot;Install&quot; button in the popup panel.<br>
2. Test the application in OOB mode<br>
&nbsp; &nbsp;a. double click &quot;CSSL4COMInterop Application&quot; shortcut on desktop to start the<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; application.<br>
&nbsp;&nbsp;&nbsp;&nbsp;b. edit data by manipulating the datagrid.<br>
&nbsp;&nbsp;&nbsp;&nbsp;c. click the buttons to export data to different application.<br>
</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
Silverlight 4 Tools RC2 for Visual Studio 2010<br>
<a target="_blank" href="http://www.microsoft.com/downloads/details.aspx?FamilyID=bf5ab940-c011-4bd1-ad98-da671e491009&displaylang=en">http://www.microsoft.com/downloads/details.aspx?FamilyID=bf5ab940-c011-4bd1-ad98-da671e491009&displaylang=en</a><br>
<br>
Silverilght 4 runtime<br>
<a target="_blank" href="http://silverlight.net/getstarted/">http://silverlight.net/getstarted/</a><br>
<br>
Microsoft Office 2007 or higher<br>
<a target="_blank" href="http://office.microsoft.com/en-us/default.aspx">http://office.microsoft.com/en-us/default.aspx</a><br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. What's the precondition of interoperating COM in silverlight?<br>
&nbsp; &nbsp;Interoperate with COM is the new feature in Silverlight4, to develop the COM interop
<br>
&nbsp;&nbsp;&nbsp;&nbsp;silverlight&nbsp;&nbsp;&nbsp;&nbsp;application, we need use Silverlight4 SDK. Also, to interop with COM, the silverlight<br>
&nbsp;&nbsp;&nbsp;&nbsp;application need to be running under elevated trust OOB mode.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;For details about Trusted Application, please refer to<br>
&nbsp;&nbsp;&nbsp;&nbsp;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ee721083(VS.95).aspx">http://msdn.microsoft.com/en-us/library/ee721083(VS.95).aspx</a><br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;To determine if COM interop is available, we could use this code:<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;System.Runtime.InteropServices.Automation.AutomationFactory.IsAvailable<br>
<br>
2. How to manipulate the Microsoft Word automation in silverlight?<br>
&nbsp; &nbsp;1. Use AutomationFactory to create word application automation object.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dynamic word = AutomationFactory.CreateObject(&quot;Word.Application&quot;);<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;2. Create new word document, and then write Text and apply format.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;dynamic doc = word.Documents.Add();<br>
&nbsp; &nbsp; &nbsp; &nbsp;dynamic range1 = doc.Paragraphs[1].Range;<br>
&nbsp; &nbsp; &nbsp; &nbsp;range1.Text = &quot;Silverlight4 Word Automation Sample\n&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp;range1.Font.Size = 24;<br>
&nbsp; &nbsp; &nbsp; &nbsp;range1.Font.Bold = true;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;3. Print document<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;doc.PrintOut();<br>
<br>
3. How to manipulate the Windows Notepad in silverlight?<br>
&nbsp;&nbsp;&nbsp;&nbsp;1. Use AutomationFactory to create WSHShell object.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dynamic shell = AutomationFactory.CreateObject(&quot;WScript.Shell&quot;);<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;2. Run Notepad.exe<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shell.Run(@&quot;%windir%\notepad&quot;, 5);<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;3. Send Keys to Notepad application<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shell.SendKeys(&quot;Name{Tab}Age{Tab}Gender{Enter}&quot;);<br>
&nbsp; &nbsp;</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
AutomationFactory Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.runtime.interopservices.automation.automationfactory(VS.95).aspx">http://msdn.microsoft.com/en-us/library/system.runtime.interopservices.automation.automationfactory(VS.95).aspx</a><br>
<br>
How to: Use Automation in Trusted Applications<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ff457794(VS.95).aspx">http://msdn.microsoft.com/en-us/library/ff457794(VS.95).aspx</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

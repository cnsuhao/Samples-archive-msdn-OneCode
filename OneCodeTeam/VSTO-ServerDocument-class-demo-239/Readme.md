# VSTO ServerDocument class demo (CSVstoServerDocument)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Office
## Topics
* VSTO
## IsPublished
* True
## ModifiedDate
* 2011-05-05 06:39:43
## Description

<p style="font-family:Courier New"></p>
<h2>VSTO : CSVstoServerDocument Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The CSVstoServerDocument project demonstrates how to use the ServerDocument<br>
class to extract information from a VSTO customized Word document or Excel<br>
Workbook; and also how to programmatically add / remove VSTO customizations.<br>
</p>
<h3></h3>
<p style="font-family:Courier New">Note: The project must be compiled as x86 for it to work.<br>
The 2003 Office version of ServerDocument calls VSTOStorageWrapper.dll which<br>
is an x86 COM component, so the calling application must be an x86 process.<br>
<br>
There are two versions of ServerDocument class, one for 2003 Office and the<br>
other for 2007 Office.<br>
<br>
The 2003 Office version can be found in assembly (part of VSTO 2005 SE):<br>
Microsoft.VisualStudio.Tools.Applications.Runtime.dll<br>
<br>
The 2007 Office version can be found in assembly (part of VSTO 3.0):<br>
Microsoft.VisualStudio.Tools.Applications.ServerDocument.v9.0.dll<br>
<br>
To add/remove the VSTO customization, call the static methods AddCustomization<br>
and RemoveCustomization of the ServerDocument class.<br>
<br>
To get detailed VSTO customization info from a document/workbook, construct<br>
an instance of ServerDocument and then access its properties and methods.<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
ServerDocument Class (2003 System)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.tools.applications.runtime.serverdocument(VS.89).aspx">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.tools.applications.runtime.serverdocument(VS.89).aspx</a><br>
<br>
ServerDocument Class (2007 System)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.tools.applications.serverdocument.aspx">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.tools.applications.serverdocument.aspx</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

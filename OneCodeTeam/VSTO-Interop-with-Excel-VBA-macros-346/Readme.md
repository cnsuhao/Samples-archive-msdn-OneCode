# VSTO Interop with Excel VBA macros (VBVstoVBAInterop)
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
* 2011-05-05 08:25:56
## Description

<p style="font-family:Courier New"></p>
<h2>VSTO : VBVstoVBAInterop Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The VBVstoVBAInterop project demonstrates how to interop with VBA project<br>
object model in VSTO projects. Including how to programmatically add Macros<br>
(or VBA UDF in Excel) into an Office document; how to call Macros / VBA UDFs <br>
from VSTO code; and how to call VSTO code from VBA code.<br>
<br>
On Excel Ribbon -&gt; VSTO Samples, click Interop Form (C#) button.<br>
<br>
</p>
<h3></h3>
<p style="font-family:Courier New">To access the VBA object model from VSTO code, you must reference the<br>
following assembly:<br>
<br>
Microsoft.Vbe.Interop<br>
<br>
Starting from Office 2003, programmatically access VBA project object model<br>
is disabled by default. You must enable this option either manually in Office<br>
application settings or programmatically modify the registry<br>
(see VBEHelper.cs).<br>
<br>
To access the VBA project OM, use Application.VBE property.<br>
To get the VBA project associated to a specific Workbook, use the<br>
Workbook.VBProject property.<br>
<br>
In order to expose your .NET objects to VBA code in Office, you must define<br>
the class with ComVisible attribute and the class must expose the IDispatch<br>
interface (see VstoClass.cs).<br>
<br>
Then you can override the ThisAddIn.RequestComAddInAutomationService method <br>
and return an instance of the class (in this sample VstoClass).<br>
<br>
To call VBA code within VSTO add-in, use the Application.Run method (see<br>
InteropForm.cs).<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Calling Code in Application-Level Add-ins from Other Solutions<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb608621.aspx">http://msdn.microsoft.com/en-us/library/bb608621.aspx</a><br>
<br>
Walkthrough: Calling Code in an Application-Level Add-in from VBA<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb608614.aspx">http://msdn.microsoft.com/en-us/library/bb608614.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

# ASP.NET app exports ReportViewer data (CSASPNETReportViewerExport)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Controls
* Reports
## IsPublished
* True
## ModifiedDate
* 2011-05-05 05:09:38
## Description

<p style="font-family:Courier New"></p>
<h2>Web APPLICATION : CSASPNETReportViewerExport Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
Sometimes we may have to hide the toolbar of the ReportViewer control, or the <br>
users only want to view the report in the PDF or EXCEL directly, then we must<br>
achieve the export function programmatically. This sample demonstrates how to<br>
export the rdlc as PDF and EXCEL programmatically. <br>
<br>
</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
ReportViewer installation:<br>
Microsoft Report Viewer 2008 SP1 Redistributable<br>
<a target="_blank" href="http://www.microsoft.com/downloads/details.aspx?displaylang=en&FamilyID=bb196d5d-76c2-4a0e-9458-267d22b6aac6">http://www.microsoft.com/downloads/details.aspx?displaylang=en&FamilyID=bb196d5d-76c2-4a0e-9458-267d22b6aac6</a><br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1.Create a export function which accepts a file type parameter.<br>
<br>
2.In order to export the RDLC report into other forms, We have to get the <br>
byte data of the RDLC report with LocalReport.Render Method. <br>
<br>
3.Use a FileStream to create a PDF file or EXCEL file.<br>
<br>
4.Write the aboved byte data to the FileStream, then the report records will be <br>
exported into the PDF file or the Excel file.<br>
<br>
</p>
<h3>Assemble reference:</h3>
<p style="font-family:Courier New"><br>
Microsoft.ReportViewer.WebForms 9.0<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
LocalReport.Render Method <br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms251839(VS.80).aspx">http://msdn.microsoft.com/en-us/library/ms251839(VS.80).aspx</a><br>
<br>
FileStream.Write Method<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.io.filestream.write.aspx">http://msdn.microsoft.com/en-us/library/system.io.filestream.write.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

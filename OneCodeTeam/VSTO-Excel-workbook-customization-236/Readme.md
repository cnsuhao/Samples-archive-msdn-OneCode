# VSTO Excel workbook customization (CSVstoExcelWorkbook)
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
* 2011-04-05 06:06:12
## Description

<p style="font-family:Courier New"></p>
<h2>EXCEL WORKBOOK : CSVstoExcelWorkbook Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The CSVstoExcelWorkbook provides the examples on how to customize Excel <br>
Workbooks by using the ListObject and the document Actions Pane. <br>
</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
The code sample requires Microsoft Excel 2007.<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
Actions Pane<br>
<br>
1. Create a User Control named CourseQueryPane.<br>
2. In ThisWorkbook class, add the User Control to the Actions Pane using the<br>
&nbsp; following code:<br>
&nbsp; <br>
&nbsp; this.ActionsPane.Controls.Add(new CourseQueryPane());<br>
&nbsp; <br>
List Object<br>
<br>
1. Drag & drop a ListObject from the Toolbox onto Sheet1.<br>
2. Set the DataSource property of the ListObject.<br>
3. At runtime, update related tables and the ListObject will reflect the data.<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
ListObject Class:<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/microsoft.office.tools.excel.listobject.aspx">http://msdn.microsoft.com/en-us/library/microsoft.office.tools.excel.listobject.aspx</a><br>
<br>
ActionsPane Class:<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/microsoft.office.tools.actionspane.aspx">http://msdn.microsoft.com/en-us/library/microsoft.office.tools.actionspane.aspx</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

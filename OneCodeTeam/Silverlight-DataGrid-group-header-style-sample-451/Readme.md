# Silverlight DataGrid group header style sample (VBSL4DataGridGroupHeaderStyle)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Silverlight
## Topics
* Controls
## IsPublished
* True
## ModifiedDate
* 2011-05-05 10:01:31
## Description

<p style="font-family:Courier New"></p>
<h2>SILVERLIGHT APPLICATION : VBSL4DataGridGroupHeaderStyle Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
This project created a sample application, which illustrates how to define <br>
group header style of different levels and define group header style <br>
according to group header content.<br>
<br>
</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
Silverlight 4 Tools RTM for Visual Studio 2010<br>
<a target="_blank" href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=b3deb194-ca86-4fb6-a716-b67c2604a139&displaylang=en">http://www.microsoft.com/downloads/en/details.aspx?FamilyID=b3deb194-ca86-4fb6-a716-b67c2604a139&displaylang=en</a><br>
<br>
Silverlight 4 Toolkit for Visual Studio 2010<br>
<a target="_blank" href="http://silverlight.codeplex.com/">http://silverlight.codeplex.com/</a><br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
1.&nbsp;&nbsp;&nbsp;&nbsp;How to define group header style of different levels. <br>
Group header style can be defined using DataGrid.RowGroupHeaderStyle Property <br>
and the styles are applied to different levels based on the order of style tag. <br>
The first one is applied to the most top level, the second for the second level <br>
and so on. <br>
<br>
2.&nbsp;&nbsp;&nbsp;&nbsp;How to vary group header style in one level. <br>
In this sample, StackPanel is defined within the DataGrid.RowGroupHeaderStyle <br>
using Control.Template. The Background of StackPanel is binded to <br>
GroupHeaderName, and the background value is set based on GroupHeaderName <br>
using IValueConverter. <br>
<br>
&nbsp; &nbsp;</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
DataGrid.RowGroupHeaderStyles Property<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.windows.controls.datagrid.rowgroupheaderstyles.aspx">http://msdn.microsoft.com/en-us/library/system.windows.controls.datagrid.rowgroupheaderstyles.aspx</a><br>
<br>
Control.Template Property<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.windows.controls.control.template.aspx">http://msdn.microsoft.com/en-us/library/system.windows.controls.control.template.aspx</a><br>
<br>
Style.TargetType Property<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.windows.style.targettype.aspx">http://msdn.microsoft.com/en-us/library/system.windows.style.targettype.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

# Cascade WPF DataGrid combobox columns (CSWPFCascadeDataGridComboBoxColumns)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* WPF
## Topics
* Controls
## IsPublished
* True
## ModifiedDate
* 2011-05-05 07:10:37
## Description

<p style="font-family:Courier New"></p>
<h2>WPF Cascade DataGridcomboBoxColumn Project Overview </h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The sample demonstrates how to show cascade data in the loop up list in two DataGrid
<br>
combobox columns.<br>
&nbsp; </p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
You need to install WPF toolkit on your machine before running this sample.<br>
Visit the following link to get WPF toolkit:<br>
<a target="_blank" href="http://wpf.codeplex.com/">http://wpf.codeplex.com/</a><br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Step1. Build the sample project in Visual Studio 2008.<br>
<br>
Step2. Select &quot;China&quot; in the first column, and click the cell under the second<br>
column in the same row. You'll see two items &quot;Beijing&quot; and &quot;Shanghai&quot; in the<br>
drop down list of the ComboBox.<br>
<br>
Step3. Select &quot;UnitedStates&quot; in the first column, and click the cell under the second<br>
column in the same row. You'll see two items &quot;NewYork&quot; and &quot;Washington&quot; in the<br>
drop down list of the ComboBox.<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
Firstly, bind the first column to the parent data source and bind the second <br>
column to the whole child data source. <br>
<br>
In order to show cascade look up list in the second column, handle its <br>
PreparingCellEditing event to get the hosted editing element, in this case a <br>
ComboBox. <br>
<br>
Then rebind the ComboBox so as to show the corresponding child data in the <br>
ComboBox's drop down list.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
<a target="_blank" href="http://windowsclient.net/wpf/wpf35/wpf-dg-preview-ctrl-investments.aspx">http://windowsclient.net/wpf/wpf35/wpf-dg-preview-ctrl-investments.aspx</a><br>
<a target="_blank" href="http://windowsclient.net/wpf/wpf35/wpf-video-datagrid-ctp-preview.aspx">http://windowsclient.net/wpf/wpf35/wpf-video-datagrid-ctp-preview.aspx</a>
<br>
<a target="_blank" href="http://windowsclient.net/wpf/wpf35/wpf-35sp1-toolkit-datagrid-feature-walkthrough.aspx">http://windowsclient.net/wpf/wpf35/wpf-35sp1-toolkit-datagrid-feature-walkthrough.aspx</a> &nbsp;<br>
</p>
<h3></h3>
<p style="font-family:Courier New"><br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

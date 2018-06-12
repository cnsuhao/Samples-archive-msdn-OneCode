# Cascade WPF DataGrid combobox columns (VBWPFCascadeDataGridComboBoxColumns)
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
* 2011-05-05 08:41:18
## Description

<p style="font-family:Courier New"></p>
<h2>WPF Cascade DataGridcomboBoxColumn Project Overview </h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The sample demonstrates how to show cascade the loop up list in two DataGrid <br>
combobox columns.<br>
&nbsp; <br>
</p>
<h3></h3>
<p style="font-family:Courier New">Firstly, bind the first column to the parent data source and bind the second
<br>
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
&nbsp; <br>
</p>
<h3>Demo</h3>
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
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

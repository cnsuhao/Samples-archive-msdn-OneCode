# Databinding in Windows Forms demo (CSWinFormDataBinding)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Windows Forms
## Topics
* Data Binding
## IsPublished
* True
## ModifiedDate
* 2011-05-05 06:53:21
## Description

<p style="font-family:Courier New"></p>
<h2>WINDOWS FORMS APPLICATION : CSWinFormDtaBinding Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The CSWinFormDataBinding sample demonstrates the Windows Forms Data Binding <br>
technology. It shows how to perform simple binding and complex binding in a <br>
Windows Forms application. It also shows how to navigate through items in a <br>
data source. <br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. Simple binding example 1.<br>
<br>
&nbsp; This example binds TextBox.Text property to CheckBox.Checked property using
<br>
&nbsp; simple binding, so that when the CheckBox is checked, the TextBox shows<br>
&nbsp; &quot;true&quot;, otherwise shows &quot;false&quot;.<br>
<br>
2. Simple binding example 2.<br>
<br>
&nbsp; This example bind TextBox.Text property to Form.Size property using simple
<br>
&nbsp; binding with update mode set to DataSourceUpdateMode.Never, so that the data<br>
&nbsp; source won't update unless we explicitly call the Binding.WriteValue() method.<br>
&nbsp; <br>
3. Simple binding example 3.<br>
<br>
&nbsp; This example bind TextBox.Text property to one of the fields of a DataTable.<br>
<br>
&nbsp; 1). Create a DataTable with two columns and several rows of data.<br>
&nbsp; <br>
&nbsp; 2). Bind TextBox.Text property to one of the fields of the DataTable through a
<br>
&nbsp; BindingSource object.<br>
&nbsp; <br>
&nbsp; 3). Call BindingSource.MovePrevious, BindingSource.MoveNext methods to navigate
<br>
&nbsp; through the records.<br>
&nbsp; <br>
4. Complex binding example 1.<br>
<br>
&nbsp; This example demonstrates how to display data from database in a DataGridView
<br>
&nbsp; by Visual Studio designer.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; Steps:<br>
&nbsp;&nbsp;&nbsp;&nbsp; <br>
&nbsp; 1). Click the smart tag glyph (Smart Tag Glyph) on the upper-right corner of
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; the DataGridView control.<br>
&nbsp; 2). Click the drop-down arrow for the Choose Data Source option.<br>
&nbsp; 3). If your project does not already have a data source, click <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &quot;Add Project Data Source..&quot; and follow the steps indicated by the wizard.
<br>
&nbsp; 4). Expand the Other Data Sources and Project Data Sources nodes if they are
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; not already expanded, and then select the data source to bind the control to.
<br>
&nbsp; 5). If your data source contains more than one member, such as if you have
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; created a DataSet that contains multiple tables, expand the data source,
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; and then select the specific member to bind to. <br>
<br>
5. Complex binding example 2.<br>
&nbsp; <br>
&nbsp; This example use business objects as data source for data binding.<br>
&nbsp; <br>
6. Complex binding example 3.<br>
<br>
&nbsp; This example demonstrates how to perform Master/Detail binding in Windows Forms.<br>
&nbsp; <br>
&nbsp; 1). Create a master DataTable and a detail DataTable.<br>
&nbsp; 2). Add some records to both tables.<br>
&nbsp; 3). Create a DataSet object to hold both table.<br>
&nbsp; 4). Add a relationship to he DataSet.<br>
&nbsp; 5). Create two BindingSource objects, one for the master table, the other for the
<br>
&nbsp; &nbsp; &nbsp; corresponding detail records.<br>
&nbsp; 6). Use the BindingSource objects to bind the DataGridView controls.<br>
&nbsp; <br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
1. Roadmap for Windows Forms data binding<br>
&nbsp; <a target="_blank" href="http://support.microsoft.com/kb/313482">http://support.microsoft.com/kb/313482</a><br>
<br>
2. Windows Forms Data Binding<br>
&nbsp; <a target="_blank" href="http://msdn.microsoft.com/en-us/library/ef2xyb33.aspx">
http://msdn.microsoft.com/en-us/library/ef2xyb33.aspx</a><br>
<br>
3. Windows Forms Data Controls and Databinding FAQ<br>
&nbsp; <a target="_blank" href="http://social.msdn.microsoft.com/Forums/en-US/winformsdatacontrols/thread/a44622c0-74e1-463b-97b9-27b87513747e">
http://social.msdn.microsoft.com/Forums/en-US/winformsdatacontrols/thread/a44622c0-74e1-463b-97b9-27b87513747e</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

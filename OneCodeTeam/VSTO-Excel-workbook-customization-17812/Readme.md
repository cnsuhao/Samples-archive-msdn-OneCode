# VSTO Excel workbook customization (VBVstoExcelWorkbook)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Office
## Topics
* Excel
* VSTO
## IsPublished
* True
## ModifiedDate
* 2012-07-22 06:57:36
## Description

<h1><span style="">EXCEL WORKBOOK</span> (<span style="">VB</span>VstoExcelWorkbook)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The <span style="">VB</span>VstoExcelWorkbook provides the examples on how to customize Excel Workbooks by using the ListObject and the document Actions Pane.<span style="">&nbsp;
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">The <span class="SpellE">Microsoft.Office.Interop.Excel.Workbook</span> class represents a single workbook within the Excel application. Visual Studio Tools for Office extends the
<span class="SpellE">Microsoft.Office.Interop.Excel.Workbook</span> class by providing the
<span class="SpellE">Microsoft.Office.Tools.Excel.Workbook</span> class (<a href="http://msdn.microsoft.com/en-us/library/microsoft.office.tools.excel.workbook(v=vs.80).aspx">http://msdn.microsoft.com/en-us/library/microsoft.office.tools.excel.workbook(v=vs.80).aspx</a>),
 which gives you access to all members of the Workbooks collection (<a href="http://msdn.microsoft.com/en-us/library/microsoft.office.interop.excel.workbooks.aspx">http://msdn.microsoft.com/en-us/library/microsoft.office.interop.excel.workbooks.aspx</a>), as
 well as data binding capabilities and additional events. </span></p>
<p class="MsoNormal"><span style="">Every document-level customization for Excel or Word exposes an
<span class="SpellE"><b>ActionsPane</b></span> object. You can use this object to customize the user interface of the
<b>Document Actions</b> task pane in a document-level project. To get the <span class="SpellE">
<b>ActionsPane</b></span> object, use the <span class="SpellE">ActionsPane</span> field of the
<span class="SpellE">ThisDocument</span> class (for Word) or the <span class="SpellE">
ThisWorkbook</span> class (for Excel) in your project. For more information, see <a href="http://msdn.microsoft.com/en-us/library/7we49he1.aspx">
<span style="color:windowtext; text-decoration:none">Actions Pane Overview</span></a>(<a href="http://msdn.microsoft.com/en-us/library/7we49he1.aspx">http://msdn.microsoft.com/en-us/library/7we49he1.aspx</a>).
</span></p>
<h2><span style="">Building the Sample </span></h2>
<p class="MsoNormal"><span style="">The code sample requires Microsoft Excel 2010.
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style=""><img src="/site/view/file/61547/1/image.png" alt="" width="719" height="239" align="middle">
</span><span style="">&nbsp;</span><span style=""> </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">1. Create a User Control named CourseQueryPane.<span style="">
</span></p>
<p class="MsoNormal"><span style="">2. Set the DataSource property of the comboBox and add the following code to CourseQueryPane.cs:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub CourseQueryPane_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
       ' Fill the student names list.
       Me.StudentListTableAdapter.Fill(Me.SchoolDataSet.StudentList)
   End Sub


   Private Sub cmdQuery_Click(sender As System.Object, e As System.EventArgs) Handles cmdQuery.Click
       ' Update course list for selected student.
       Globals.Sheet1.UpdateCourseList(cboName.Text.Trim())
   End Sub

</pre>
<pre id="codePreview" class="vb">
Private Sub CourseQueryPane_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
       ' Fill the student names list.
       Me.StudentListTableAdapter.Fill(Me.SchoolDataSet.StudentList)
   End Sub


   Private Sub cmdQuery_Click(sender As System.Object, e As System.EventArgs) Handles cmdQuery.Click
       ' Update course list for selected student.
       Globals.Sheet1.UpdateCourseList(cboName.Text.Trim())
   End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">3</span>. In ThisWorkbook class, add the User Control to the Actions Pane using the following code:<span style="">&nbsp;&nbsp;
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Me.ActionsPane.Controls.Add(New CourseQueryPane())

</pre>
<pre id="codePreview" class="vb">
Me.ActionsPane.Controls.Add(New CourseQueryPane())

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">4</span>. Drag &amp; drop a ListObject from the Toolbox onto Sheet1.</p>
<p class="MsoNormal"><span style="">5</span>. Set the DataSource property of the ListObject.</p>
<p class="MsoNormal"><span style="">6</span>. At runtime, update related tables and the ListObject will reflect the data.</p>
<h2>More Information<span style=""> </span></h2>
<p class="MsoNormal" style="margin-left:18.0pt"><span class="SpellE">ListObject</span> Class</p>
<p class="MsoNormal" style="margin-left:18.0pt"><a href="http://msdn.microsoft.com/en-us/library/microsoft.office.tools.excel.listobject.aspx">http://msdn.microsoft.com/en-us/library/microsoft.office.tools.excel.listobject.aspx</a><span style="">
</span></p>
<p class="MsoNormal" style="margin-left:18.0pt"><span class="SpellE"><span style="">ListObject</span></span><span style=""> Control
</span></p>
<p class="MsoNormal" style="margin-left:18.0pt"><span style=""><a href="http://msdn.microsoft.com/en-us/library/2ttzcbhb.aspx">http://msdn.microsoft.com/en-us/library/2ttzcbhb.aspx</a>
</span></p>
<p class="MsoNormal" style="margin-left:18.0pt"><span class="SpellE">ActionsPane</span> Class<span style="">
</span></p>
<p class="MsoNormal" style="margin-left:18.0pt"><span style=""><a href="http://msdn.microsoft.com/en-us/library/microsoft.office.tools.actionspane.aspx">http://msdn.microsoft.com/en-us/library/microsoft.office.tools.actionspane.aspx</a>
</span></p>
<p class="MsoNormal" style="margin-left:18.0pt"><span style="">Excel Object Model Overview
</span></p>
<p class="MsoNormal" style="margin-left:18.0pt"><span style=""><a href="http://msdn.microsoft.com/en-us/library/wss56bz7(v=vs.80).aspx">http://msdn.microsoft.com/en-us/library/wss56bz7(v=vs.80).aspx</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

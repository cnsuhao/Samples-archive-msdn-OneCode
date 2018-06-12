# How to implement Pivot and Unpivot in Entity Framework
## Requires
* Visual Studio 2012
## License
* MS-LPL
## Technologies
* ADO.NET
## Topics
* pivot
* Unpivot
## IsPublished
* True
## ModifiedDate
* 2013-02-16 07:28:50
## Description

<h1>Implement the Pivot and Unpivot Operation in Entity Framework (VBEFPivotOperation)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to implement the Pivot and Unpivot operation in Entity Framework.</p>
<p class="MsoNormal">In this sample, we use two classes to store the data from the database by EF, and then display the data in Pivot/Unpivot format.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">Before you run the sample, you need to finish the following steps:</p>
<p class="MsoNormal">Step1. Attach the database file MySchool.mdf under the folder _External_Dependecies to your SQL Server 2008 database instance.</p>
<p class="MsoNormal">Step2. Modify the connection string in the App.config file according to your SQL Server 2008 database instance name.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Press F5 to run the sample, the following is the result.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/76131/1/image.png" alt="" width="639" height="352" align="middle">
</span></p>
<p class="MsoNormal">1.<span style="">&nbsp; </span>We get the Pivot data by EF, and then translate the result into a Pivot table that uses the names of courses as the columns.</p>
<p class="MsoNormal">2.<span style="">&nbsp; </span>We get the person data by EF, and then unpivot the data into the UnpivotRow list.</p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
1. Implement the Pivot operation in Entity Framework</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span>a. PivotRow Class</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span>We use the PivotRow class to store the Pivot result.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Class PivotRow(Of TypeId, TypeAttr, TypeValue)
&nbsp;&nbsp;&nbsp; Public Property ObjectId() As TypeId
&nbsp;&nbsp;&nbsp; Public Property Attributes() As IEnumerable(Of TypeAttr)
&nbsp;&nbsp;&nbsp; Public Property Values() As IEnumerable(Of TypeValue)
End Class

</pre>
<pre id="codePreview" class="vb">
Public Class PivotRow(Of TypeId, TypeAttr, TypeValue)
&nbsp;&nbsp;&nbsp; Public Property ObjectId() As TypeId
&nbsp;&nbsp;&nbsp; Public Property Attributes() As IEnumerable(Of TypeAttr)
&nbsp;&nbsp;&nbsp; Public Property Values() As IEnumerable(Of TypeValue)
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span>We translate the Pivot data into a Pivot table that uses the names of attributes as the columns.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Shared Function GetPivotTable(ByVal attributeNames As List(Of TypeAttr), ByVal source As List(Of PivotRow(Of TypeId, TypeAttr, TypeValue))) As DataTable
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim dt As New DataTable()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim dc As New DataColumn(&quot;ID&quot;, GetType(TypeId))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dt.Columns.Add(dc)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;' Creat the new DataColumn for each attribute
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; attributeNames.ForEach(Sub(name)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dc = New DataColumn(name.ToString(), GetType(TypeValue))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dt.Columns.Add(dc)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End Sub)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Insert the data into the Pivot table
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each row As PivotRow(Of TypeId, TypeAttr, TypeValue) In source
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim dr As DataRow = dt.NewRow()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dr(&quot;ID&quot;) = row.ObjectId


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim attributes As List(Of TypeAttr) = row.Attributes.ToList()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim values As List(Of TypeValue) = row.Values.ToList()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Set the value basing the attribute names.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For i As Integer = 0 To values.Count - 1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dr(attributes(i).ToString()) = values(i)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next i


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dt.Rows.Add(dr)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next row


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return dt
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Function

</pre>
<pre id="codePreview" class="vb">
Public Shared Function GetPivotTable(ByVal attributeNames As List(Of TypeAttr), ByVal source As List(Of PivotRow(Of TypeId, TypeAttr, TypeValue))) As DataTable
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim dt As New DataTable()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim dc As New DataColumn(&quot;ID&quot;, GetType(TypeId))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dt.Columns.Add(dc)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;' Creat the new DataColumn for each attribute
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; attributeNames.ForEach(Sub(name)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dc = New DataColumn(name.ToString(), GetType(TypeValue))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dt.Columns.Add(dc)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End Sub)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Insert the data into the Pivot table
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each row As PivotRow(Of TypeId, TypeAttr, TypeValue) In source
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim dr As DataRow = dt.NewRow()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dr(&quot;ID&quot;) = row.ObjectId


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim attributes As List(Of TypeAttr) = row.Attributes.ToList()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim values As List(Of TypeValue) = row.Values.ToList()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Set the value basing the attribute names.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For i As Integer = 0 To values.Count - 1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dr(attributes(i).ToString()) = values(i)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next i


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dt.Rows.Add(dr)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next row


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return dt
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span>b. Get the Pivot result</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span>Get the Pivot data by EF, and store the data into the PivotRow list.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
studentGrade = (
&nbsp;&nbsp;&nbsp; From sg In school.StudentGrades
&nbsp;&nbsp;&nbsp; Group sg By sg.StudentID Into sgGroup = Group
&nbsp;&nbsp;&nbsp; Select New PivotRow(Of Person, String, Decimal) With
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .ObjectId = sgGroup.Select(Function(g) g.Person).FirstOrDefault(),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Attributes = sgGroup.Select(Function(g) g.Course.Title),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Values = sgGroup.Select(Function(g) g.Grade)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }).ToList()

</pre>
<pre id="codePreview" class="vb">
studentGrade = (
&nbsp;&nbsp;&nbsp; From sg In school.StudentGrades
&nbsp;&nbsp;&nbsp; Group sg By sg.StudentID Into sgGroup = Group
&nbsp;&nbsp;&nbsp; Select New PivotRow(Of Person, String, Decimal) With
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .ObjectId = sgGroup.Select(Function(g) g.Person).FirstOrDefault(),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Attributes = sgGroup.Select(Function(g) g.Course.Title),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Values = sgGroup.Select(Function(g) g.Grade)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }).ToList()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span>Get the list of attributes. In this sample, we use the names of the courses as the attributes.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
courses = school.Courses.Select(Function(c) c.Title).ToList()

</pre>
<pre id="codePreview" class="vb">
courses = school.Courses.Select(Function(c) c.Title).ToList()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">2. Implement the Unpivot operation in Entity Framework.</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span>a. UnpivotRow class</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span>We use the UnpivotRow class to store the Unpivot result.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Class UnpivotRow(Of TypeId, TypeAttr, TypeValue)
&nbsp;&nbsp;&nbsp; Public Property ObjectId() As TypeId
&nbsp;&nbsp;&nbsp; Public Property Attribute() As TypeAttr
&nbsp;&nbsp;&nbsp; Public Property Value() As TypeValue
End Class

</pre>
<pre id="codePreview" class="vb">
Public Class UnpivotRow(Of TypeId, TypeAttr, TypeValue)
&nbsp;&nbsp;&nbsp; Public Property ObjectId() As TypeId
&nbsp;&nbsp;&nbsp; Public Property Attribute() As TypeAttr
&nbsp;&nbsp;&nbsp; Public Property Value() As TypeValue
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span>b. Get the Unpivot result</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span>First, we set the function list of attributes.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim attrFuncList As New Dictionary(Of String, Func(Of Person, Date?))()
attrFuncList(&quot;HireDate&quot;) = Function(p) p.HireDate
attrFuncList(&quot;EnrollmentDate&quot;) = Function(p) p.EnrollmentDate

</pre>
<pre id="codePreview" class="vb">
Dim attrFuncList As New Dictionary(Of String, Func(Of Person, Date?))()
attrFuncList(&quot;HireDate&quot;) = Function(p) p.HireDate
attrFuncList(&quot;EnrollmentDate&quot;) = Function(p) p.EnrollmentDate

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span>Then, we get the data by EF.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim persons = (
&nbsp;&nbsp;&nbsp; From person In school.People
&nbsp;&nbsp;&nbsp; Select person).ToList()

</pre>
<pre id="codePreview" class="vb">
Dim persons = (
&nbsp;&nbsp;&nbsp; From person In school.People
&nbsp;&nbsp;&nbsp; Select person).ToList()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span>At last, we get the Pivot result by LinqToObject.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
For Each key As String In attrFuncList.Keys
&nbsp;&nbsp;&nbsp; Dim k As String = key
&nbsp;&nbsp;&nbsp; ' Get the value of a certain attribute.
&nbsp;&nbsp;&nbsp; Dim query As IEnumerable(Of UnpivotRow(Of String, String, Date)) = (
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; From person In persons
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Where attrFuncList(k)(person) IsNot Nothing
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select New UnpivotRow(Of String, String, Date) With
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .ObjectId = person.FirstName & &quot; &quot; & person.LastName,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Attribute = k,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Value = CDate(attrFuncList(k)(person))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; })


&nbsp;&nbsp;&nbsp; ' Concat the results.
&nbsp;&nbsp;&nbsp; result = If(result Is Nothing, query, result.Concat(query))
Next key

</pre>
<pre id="codePreview" class="vb">
For Each key As String In attrFuncList.Keys
&nbsp;&nbsp;&nbsp; Dim k As String = key
&nbsp;&nbsp;&nbsp; ' Get the value of a certain attribute.
&nbsp;&nbsp;&nbsp; Dim query As IEnumerable(Of UnpivotRow(Of String, String, Date)) = (
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; From person In persons
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Where attrFuncList(k)(person) IsNot Nothing
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select New UnpivotRow(Of String, String, Date) With
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .ObjectId = person.FirstName & &quot; &quot; & person.LastName,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Attribute = k,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Value = CDate(attrFuncList(k)(person))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; })


&nbsp;&nbsp;&nbsp; ' Concat the results.
&nbsp;&nbsp;&nbsp; result = If(result Is Nothing, query, result.Concat(query))
Next key

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/bwabdf9z(v=vs.110).aspx">List&lt;T&gt;.ForEach Method</a><span class="MsoHyperlink">
</span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/b05d59ty(v=vs.110).aspx">PropertyInfo.GetValue Method (Object, Object[])</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

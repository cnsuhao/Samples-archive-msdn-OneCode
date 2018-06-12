# How to automically update the structure of a cloned DataTable
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* ADO.NET
* Data Access
* .NET Development
## Topics
* clone
* update structure
## IsPublished
* True
## ModifiedDate
* 2013-07-05 02:32:30
## Description

<h1>How to <span class="SpellE">Automically</span> Update the Structure of a Cloned
<span class="SpellE">DataTable</span> as the Source is Modified (<span class="SpellE">VBDataTableUpdate</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">In this sample, we will demonstrate how to update the structure and constraints of the destination table after
<span class="SpellE">DataTable.Clone</span>:</p>
<p class="MsoNormal">1. Update the changes of the columns in source table.</p>
<p class="MsoNormal">2. Update the changes of the <span class="SpellE">UniqueConstraint</span> in source table.</p>
<p class="MsoNormal">3. Update the changes of the <span class="SpellE">ForeignKeyConstraint</span> in source table.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Press F5 to run the sample, the following is the result.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/91773/1/image.png" alt="" width="642" height="400" align="middle">
</span></p>
<p class="MsoNormal">First, after we add a column(&quot;Credits&quot;) in source table, we can also see it in the destination table.</p>
<p class="MsoNormal">Second, after we add the UniqueConstraint in the source table, we can't add the duplicate rows into the destination table.</p>
<p class="MsoNormal">Third, after we add the ForeignKeyConstraint in the source table, we can't add the rows without the parent into the destination table.</p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
1. Updating the added columns.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
After the source table adds a column, the method will be trigged and add the same column in destination table if there isn't the same name column.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
If e.Action = CollectionChangeAction.Add Then
&nbsp;&nbsp;&nbsp; Dim column As DataColumn = TryCast(e.Element, DataColumn)


&nbsp;&nbsp;&nbsp; If column IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim newColumn As New DataColumn(column.ColumnName, column.DataType,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; column.Expression, column.ColumnMapping)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not destinationDataTable.Columns.Contains(newColumn.ColumnName) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; destinationDataTable.Columns.Add(newColumn)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; End If
End If

</pre>
<pre id="codePreview" class="vb">
If e.Action = CollectionChangeAction.Add Then
&nbsp;&nbsp;&nbsp; Dim column As DataColumn = TryCast(e.Element, DataColumn)


&nbsp;&nbsp;&nbsp; If column IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim newColumn As New DataColumn(column.ColumnName, column.DataType,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; column.Expression, column.ColumnMapping)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not destinationDataTable.Columns.Contains(newColumn.ColumnName) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; destinationDataTable.Columns.Add(newColumn)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; End If
End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
2. Updating the deleted columns.</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
After the source table deletes a column, the method will be trigged and delete the same column in destination table if there's the same name column.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
If e.Action = CollectionChangeAction.Remove Then
&nbsp;&nbsp;&nbsp; Dim column As DataColumn = TryCast(e.Element, DataColumn)


&nbsp;&nbsp;&nbsp; If column IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If destinationDataTable.Columns.Contains(column.ColumnName) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; destinationDataTable.Columns.Remove(column.ColumnName)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; End If
End If

</pre>
<pre id="codePreview" class="vb">
If e.Action = CollectionChangeAction.Remove Then
&nbsp;&nbsp;&nbsp; Dim column As DataColumn = TryCast(e.Element, DataColumn)


&nbsp;&nbsp;&nbsp; If column IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If destinationDataTable.Columns.Contains(column.ColumnName) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; destinationDataTable.Columns.Remove(column.ColumnName)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; End If
End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">3. Updating the added UniqueConstraint</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
After the source table adds the UniqueConstraint, the method will be trigged and adds<span style="">&nbsp;
</span>the same UniqueConstraint in destination table if there isn't the same name UniqueConstraint.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
If e.Action = CollectionChangeAction.Add Then
&nbsp;&nbsp;&nbsp; Dim columns(constraint.Columns.Count() - 1) As DataColumn
&nbsp;&nbsp;&nbsp; Dim isPrimaryKey As Boolean = constraint.IsPrimaryKey


&nbsp;&nbsp;&nbsp; ' Get the columns used in new constraint from the destiantion table.
&nbsp;&nbsp;&nbsp; For i As Int32 = 0 To constraint.Columns.Count() - 1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim columnName As String = constraint.Columns(i).ColumnName


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If destinationDataTable.Columns.Contains(columnName) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; columns(i) = destinationDataTable.Columns(columnName)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; Next i


&nbsp;&nbsp;&nbsp; Dim newConstraint As New UniqueConstraint(constraintName, columns, isPrimaryKey)


&nbsp;&nbsp;&nbsp; If Not destinationDataTable.Constraints.Contains(constraintName) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; destinationDataTable.Constraints.Add(newConstraint)
&nbsp;&nbsp;&nbsp; End If

</pre>
<pre id="codePreview" class="vb">
If e.Action = CollectionChangeAction.Add Then
&nbsp;&nbsp;&nbsp; Dim columns(constraint.Columns.Count() - 1) As DataColumn
&nbsp;&nbsp;&nbsp; Dim isPrimaryKey As Boolean = constraint.IsPrimaryKey


&nbsp;&nbsp;&nbsp; ' Get the columns used in new constraint from the destiantion table.
&nbsp;&nbsp;&nbsp; For i As Int32 = 0 To constraint.Columns.Count() - 1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim columnName As String = constraint.Columns(i).ColumnName


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If destinationDataTable.Columns.Contains(columnName) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; columns(i) = destinationDataTable.Columns(columnName)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; Next i


&nbsp;&nbsp;&nbsp; Dim newConstraint As New UniqueConstraint(constraintName, columns, isPrimaryKey)


&nbsp;&nbsp;&nbsp; If Not destinationDataTable.Constraints.Contains(constraintName) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; destinationDataTable.Constraints.Add(newConstraint)
&nbsp;&nbsp;&nbsp; End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">4. Updating the deleted UniqueConstraint</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
After the source table deletes the UniqueConstraint, the method will be trigged and deletes<span style="">&nbsp;
</span>the same UniqueConstraint in destination table if there's the same name UniqueConstraint.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
ElseIf e.Action = CollectionChangeAction.Remove Then
&nbsp;&nbsp;&nbsp; If destinationDataTable.Constraints.Contains(constraintName) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; destinationDataTable.Constraints.Remove(constraintName)
&nbsp;&nbsp;&nbsp; End If
End If

</pre>
<pre id="codePreview" class="vb">
ElseIf e.Action = CollectionChangeAction.Remove Then
&nbsp;&nbsp;&nbsp; If destinationDataTable.Constraints.Contains(constraintName) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; destinationDataTable.Constraints.Remove(constraintName)
&nbsp;&nbsp;&nbsp; End If
End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="font-size:10.0pt; line-height:115%; font-family:&quot;Courier New&quot;"></span></p>
<p class="MsoNormal">5. Updating the added ForeignKeyConstraint</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
After the source table adds the ForeignKeyConstraint, the method will be trigged and adds<span style="">&nbsp;
</span>the same ForeignKeyConstraint in destination table if there isn't the same name ForeignKeyConstraint.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
If e.Action = CollectionChangeAction.Add Then
&nbsp;&nbsp;&nbsp; Dim columns(constraint.Columns.Count() - 1) As DataColumn
&nbsp;&nbsp;&nbsp; Dim parentColumns() As DataColumn = constraint.RelatedColumns


&nbsp;&nbsp; &nbsp;' Get the columns used in new constraint from the destination table.
&nbsp;&nbsp;&nbsp; For i As Integer = 0 To constraint.Columns.Count() - 1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim columnName As String = constraint.Columns(i).ColumnName


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If destinationDataTable.Columns.Contains(columnName) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; columns(i) = destinationDataTable.Columns(columnName)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; Next i


&nbsp;&nbsp;&nbsp; Dim newConstraint As New ForeignKeyConstraint(constraintName, parentColumns, columns)
&nbsp;&nbsp;&nbsp; newConstraint.AcceptRejectRule = constraint.AcceptRejectRule
&nbsp;&nbsp;&nbsp; newConstraint.DeleteRule = constraint.DeleteRule
&nbsp;&nbsp;&nbsp; newConstraint.UpdateRule = constraint.UpdateRule


&nbsp;&nbsp;&nbsp; If Not destinationDataTable.Constraints.Contains(constraintName) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; destinationDataTable.Constraints.Add(newConstraint)
&nbsp;&nbsp;&nbsp; End If

</pre>
<pre id="codePreview" class="vb">
If e.Action = CollectionChangeAction.Add Then
&nbsp;&nbsp;&nbsp; Dim columns(constraint.Columns.Count() - 1) As DataColumn
&nbsp;&nbsp;&nbsp; Dim parentColumns() As DataColumn = constraint.RelatedColumns


&nbsp;&nbsp; &nbsp;' Get the columns used in new constraint from the destination table.
&nbsp;&nbsp;&nbsp; For i As Integer = 0 To constraint.Columns.Count() - 1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim columnName As String = constraint.Columns(i).ColumnName


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If destinationDataTable.Columns.Contains(columnName) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; columns(i) = destinationDataTable.Columns(columnName)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; Next i


&nbsp;&nbsp;&nbsp; Dim newConstraint As New ForeignKeyConstraint(constraintName, parentColumns, columns)
&nbsp;&nbsp;&nbsp; newConstraint.AcceptRejectRule = constraint.AcceptRejectRule
&nbsp;&nbsp;&nbsp; newConstraint.DeleteRule = constraint.DeleteRule
&nbsp;&nbsp;&nbsp; newConstraint.UpdateRule = constraint.UpdateRule


&nbsp;&nbsp;&nbsp; If Not destinationDataTable.Constraints.Contains(constraintName) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; destinationDataTable.Constraints.Add(newConstraint)
&nbsp;&nbsp;&nbsp; End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">6. Updating the deleted ForeignKeyConstraint</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
After the source table deletes the ForeignKeyConstraint, the method will be trigged and deletes<span style="">&nbsp;
</span>the same ForeignKeyConstraint in destination table if there's the same name ForeignKeyConstraint.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
ElseIf e.Action = CollectionChangeAction.Remove Then
&nbsp;&nbsp;&nbsp; If destinationDataTable.Constraints.Contains(constraintName) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; destinationDataTable.Constraints.Remove(constraintName)
&nbsp;&nbsp;&nbsp; End If
End If

</pre>
<pre id="codePreview" class="vb">
ElseIf e.Action = CollectionChangeAction.Remove Then
&nbsp;&nbsp;&nbsp; If destinationDataTable.Constraints.Contains(constraintName) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; destinationDataTable.Constraints.Remove(constraintName)
&nbsp;&nbsp;&nbsp; End If
End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><span class="MsoHyperlink"><a href="http://msdn.microsoft.com/en-us/library/system.data.datatable.clone(v=vs.110).aspx"><span class="SpellE">DataTable.Clone</span> Method</a>
</span></p>
<p class="MsoNormal"><span class="MsoHyperlink"><a href="http://msdn.microsoft.com/en-us/library/system.data.uniqueconstraint(v=vs.110).aspx"><span class="SpellE">UniqueConstraint</span> Class</a>
</span></p>
<p class="MsoNormal"><span class="MsoHyperlink"><a href="http://msdn.microsoft.com/en-us/library/system.data.foreignkeyconstraint(v=vs.110).aspx"><span class="SpellE">ForeignKeyConstraint</span> Class</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

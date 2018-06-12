# How to modify data in DataTable and update to the data source
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* ADO.NET
* Data Access
* .NET Development
## Topics
* DataTable Edit
* constraints
* deletion
## IsPublished
* False
## ModifiedDate
* 2014-04-24 02:42:50
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:24pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><a name="OLE_LINK1"></a><a name="OLE_LINK2"></a><span style="font-weight:bold; font-size:14pt">How to Modify data in DataTable and Update</span><a name="_GoBack"></a></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">We have several ways to modify the data in DataTable. In this application, we will demonstrate how to use different ways to modify data in DataTable and update to the source.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">1. We use SqlDataAdapter to fill the DataTables.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">2. We set DataTable Constraints in DataTables.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">4. We use DataTable Edits to modify data.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">3. We use DataRow.Delete Method and DataRowCollection.Remove Method to delete the rows, and then compare them.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">5. We use SqlDataAdapter to update the datasource.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Building the Sample</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Before you run the sample, you need to finish the following steps:</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Step1. Please choose one of the following ways to build the database:</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:63.15pt; text-indent:-18pt">
<span style="font-size:11pt"><span style="font-style:normal; text-decoration:none; font-weight:normal">&bull;&nbsp;</span><span style="font-size:11pt">Attach the database file MySchool.mdf under the folder _External_Dependecies to your SQL Server 2008 database
 instance.</span></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal; margin-left:63.15pt; text-indent:-18pt">
<span style="font-size:11pt"><span style="font-style:normal; text-decoration:none; font-weight:normal">&bull;&nbsp;</span><span style="font-size:11pt">Run the MySchool.sql script under the folder _External_Dependecies in your SQL Server 2008 database instance.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Step2. Modify the connection string in the Project Properties-&gt;Settings according-&gt; MySchoolConnectionString to your SQL Server 2008 database instance name.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Running the Sample</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Press F5 to run the sample, the following is the result.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">First, we get the data from database.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/113541/1/image.png" alt="" width="641" height="287" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Second, we use DataTable Edits to edit the data.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">a. We change two values in Credits column, and one will cause the following display and cancel the Edit.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/113542/1/image.png" alt="" width="391" height="43" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">b. We change the first two values of Credits, but only the second value is changed.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/113543/1/image.png" alt="" width="639" height="134" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Third, we delete and remove the rows in Datatable.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">a. Because we set the foreign key constraint, the related rows in child table will be deleted when the rows in parent table are deleted.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/113544/1/image.png" alt="" width="639" height="303" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Then we can update the delete operations. Now the deleted row is removed from the DataTable and the database.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/113545/1/image.png" alt="" width="641" height="135" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">b. We can also remove the rows from DataTable, and the row isn&rsquo;t exist in the table.
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/113546/1/image.png" alt="" width="639" height="91" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">After update the delete operations, however, we can also find the row in database. The Remove operation only remove the rows from DataTable, and doesn&rsquo;t change the value in Database.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"><img src="/site/view/file/113547/1/image.png" alt="" width="343" height="98" align="middle">
</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt"><span style="font-size:11pt">1. Use SqlDataAdapter to get data.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
private static void GetDataTables(String connectionString,String selectString,
    DataSet dataSet,params DataTable[] tables)
{
    using (SqlDataAdapter adapter = new SqlDataAdapter())
    {               
        adapter.SelectCommand = new SqlCommand(selectString);
        adapter.SelectCommand.Connection = new SqlConnection(connectionString);
        adapter.Fill(0, 0,tables);
        foreach (DataTable table in dataSet.Tables)
        {
            Console.WriteLine(&quot;Data in {0}:&quot;,table.TableName);
            ShowDataTable(table);
            Console.WriteLine();
        }
    }
}
</pre>
<pre class="hidden">
Private Shared Sub GetDataTables(ByVal connectionString As String, ByVal selectString As String,
                                 ByVal dataSet As DataSet, ByVal ParamArray tables() As DataTable)
    Using adapter As New SqlDataAdapter()
        adapter.SelectCommand = New SqlCommand(selectString)
        adapter.SelectCommand.Connection = New SqlConnection(connectionString)
        adapter.Fill(0, 0, tables)
        For Each table As DataTable In dataSet.Tables
            Console.WriteLine(&quot;Data in {0}:&quot;, table.TableName)
            ShowDataTable(table)
            Console.WriteLine()
        Next table
    End Using
End Sub
</pre>
<pre id="codePreview" class="csharp">
private static void GetDataTables(String connectionString,String selectString,
    DataSet dataSet,params DataTable[] tables)
{
    using (SqlDataAdapter adapter = new SqlDataAdapter())
    {               
        adapter.SelectCommand = new SqlCommand(selectString);
        adapter.SelectCommand.Connection = new SqlConnection(connectionString);
        adapter.Fill(0, 0,tables);
        foreach (DataTable table in dataSet.Tables)
        {
            Console.WriteLine(&quot;Data in {0}:&quot;,table.TableName);
            ShowDataTable(table);
            Console.WriteLine();
        }
    }
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt"><span style="font-size:11pt"></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">2. Use DataTable Edits to modify the data.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
row.BeginEdit();
row[&quot;Credits&quot;] = credits;
row.EndEdit();
</pre>
<pre class="hidden">
row.BeginEdit()
row(&quot;Credits&quot;) = credits
row.EndEdit()
</pre>
<pre id="codePreview" class="csharp">
row.BeginEdit();
row[&quot;Credits&quot;] = credits;
row.EndEdit();
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt"><span style="font-size:11pt">The following method will be invoked when the value in table is changed. If the new value of Credits is negative, we&rsquo;ll reject the modify.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
private static void OnColumnChanged(Object sender, DataColumnChangeEventArgs args)
{
    Int32 credits = 0;
    // If Credits is changed and the value is negative, we'll cancel the edit.
    if ((args.Column.ColumnName == &quot;Credits&quot;)&&
        (!Int32.TryParse(args.ProposedValue.ToString(),out credits)||credits&lt;0))
        {
            Console.WriteLine(&quot;The value of Credits is invalid. Edit canceled.&quot;);
            args.Row.CancelEdit();
        }
}
</pre>
<pre class="hidden">
Private Shared Sub OnColumnChanged(ByVal sender As Object,
                                   ByVal args As DataColumnChangeEventArgs)
    Dim credits As Int32 = 0
    ' If Credits is changed and the value is negative, we'll cancel the edit.
    If (args.Column.ColumnName = &quot;Credits&quot;) AndAlso
        ((Not Int32.TryParse(args.ProposedValue.ToString(), credits)) OrElse credits &lt; 0) Then
        Console.WriteLine(&quot;The value of Credits is invalid. Edit canceled.&quot;)
        args.Row.CancelEdit()
    End If
End Sub
</pre>
<pre id="codePreview" class="csharp">
private static void OnColumnChanged(Object sender, DataColumnChangeEventArgs args)
{
    Int32 credits = 0;
    // If Credits is changed and the value is negative, we'll cancel the edit.
    if ((args.Column.ColumnName == &quot;Credits&quot;)&&
        (!Int32.TryParse(args.ProposedValue.ToString(),out credits)||credits&lt;0))
        {
            Console.WriteLine(&quot;The value of Credits is invalid. Edit canceled.&quot;);
            args.Row.CancelEdit();
        }
}
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt"><span style="font-size:11pt"></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt"><span style="font-size:11pt">3. Delete and remove rows from DataTable.</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal; text-autospace:none">
<span style="font-size:11pt"><span style="font-size:11pt">a. Delete rows</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">Create the foreign key constraint, and set the DeleteRule with Cascade.</span></span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
ForeignKeyConstraint courseDepartFK = 
    new ForeignKeyConstraint(&quot;CourseDepartFK&quot;, 
        department.Columns[&quot;DepartmentID&quot;], 
        course.Columns[&quot;DepartmentID&quot;]);
courseDepartFK.DeleteRule = Rule.Cascade;
courseDepartFK.UpdateRule = Rule.Cascade;
courseDepartFK.AcceptRejectRule = AcceptRejectRule.None;
course.Constraints.Add(courseDepartFK);
</pre>
<pre class="hidden">
Dim courseDepartFK As New ForeignKeyConstraint(&quot;CourseDepartFK&quot;,
                                               department.Columns(&quot;DepartmentID&quot;),
                                               course.Columns(&quot;DepartmentID&quot;))
courseDepartFK.DeleteRule = Rule.Cascade
courseDepartFK.UpdateRule = Rule.Cascade
courseDepartFK.AcceptRejectRule = AcceptRejectRule.None
course.Constraints.Add(courseDepartFK)
</pre>
<pre id="codePreview" class="csharp">
ForeignKeyConstraint courseDepartFK = 
    new ForeignKeyConstraint(&quot;CourseDepartFK&quot;, 
        department.Columns[&quot;DepartmentID&quot;], 
        course.Columns[&quot;DepartmentID&quot;]);
courseDepartFK.DeleteRule = Rule.Cascade;
courseDepartFK.UpdateRule = Rule.Cascade;
courseDepartFK.AcceptRejectRule = AcceptRejectRule.None;
course.Constraints.Add(courseDepartFK);
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"></span><span style="font-size:11pt">We delete one row in department, and the related rows in Course table will also be deleted. And then we update Course table with the deleted operation, the row in
 database is also be deleted.</span></span> </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
department.Rows[0].Delete();
</pre>
<pre class="hidden">
department.Rows(0).Delete()
</pre>
<pre id="codePreview" class="csharp">
department.Rows[0].Delete();
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"></span><span style="font-size:11pt">b. Remove rows</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt">We remove one row from course table. And then we update Course table with the deleted operation, we can still find the row in database. The Remove operation only remove the rows from DataTable, and doesn&rsquo;t
 change the value in Database.</span></span> </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">
course.Rows.RemoveAt(0);
</pre>
<pre class="hidden">
course.Rows.RemoveAt(0)
</pre>
<pre id="codePreview" class="csharp">
course.Rows.RemoveAt(0);
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-bottom:0pt; line-height:24pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="font-size:11pt"></span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; margin-top:10pt; margin-bottom:0pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="color:#0563C1; text-decoration:underline"></span><a href="http://msdn.microsoft.com/en-us/library/ch2aw0w6(VS.110).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">DataTable
 Edits</span></a></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="color:#0563C1; text-decoration:underline"></span><a href="http://msdn.microsoft.com/en-us/library/st1t2c35(VS.110).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">DataTable
 Constraints</span></a></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="color:#0563C1; text-decoration:underline"></span><a href="http://msdn.microsoft.com/en-us/library/03c7a3zb(VS.110).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">DataRow Deletion</span></a></span>
</p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="color:#0563C1; text-decoration:underline"></span><a href="http://msdn.microsoft.com/en-us/library/system.data.datarowcollection.remove(VS.110).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">DataRowCollection.Remove
 Method</span></a></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="color:#0563C1; text-decoration:underline"></span><a href="http://msdn.microsoft.com/en-us/library/system.data.datarowcollection.indexof.aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">DataRowCollection.IndexOf
 Method</span></a></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="color:#0563C1; text-decoration:underline"></span><a href="http://msdn.microsoft.com/en-us/library/at8a576f(VS.100).aspx" style="text-decoration:none"><span style="color:#0563C1; text-decoration:underline">DbDataAdapter.Update
 Method (DataSet)</span></a></span> </p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:.0001pt; font-size:10.0pt; line-height:27.6pt; margin-bottom:10pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt">&nbsp;</span> </p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers’ pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers’ frequently asked programming tasks, and allow
 developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

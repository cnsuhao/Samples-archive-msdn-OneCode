# How to horizontally partition data in Windows Azure SQL Database
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
* Windows Azure SQL Database
## Topics
* Partitioning
## IsPublished
* True
## ModifiedDate
* 2013-10-23 08:15:30
## Description
<a name="OLE_LINK1"><span style=""><b><span style="font-size:14.0pt; line-height:115%; font-family:&quot;Cambria&quot;,&quot;serif&quot;">VBSqlAzurePartitioning</span></b></span></a>
<p class="MsoNormal">This sample should be <span style="">run with Windows Azure SDK 1.6, Sql Server.
</span></p>
<p class="MsoNormal" style=""><span style="">1. Please refer to Demo section to create databases/tables.
</span></p>
<p class="MsoNormal" style=""><span style="">2. Create a Windows Azure project and add an ASP.NET Web Role with the default name.
</span></p>
<p class="MsoNormal" style=""><span style="">3. Add two WebForms, name them &quot;Vertical Partitioning.aspx&quot;, &quot;Horizontal Partitioning.aspx&quot;.
</span></p>
<p class="MsoNormal" style=""><span style="">4. In Default.aspx, add two HyperLink controls and set the NavigateUrl=&quot;~/Vertical Partitioning.aspx&quot; and NavigateUrl=&quot;~/Horizontal Partitioning.aspx&quot; respectively.
</span></p>
<p class="MsoNormal" style=""><span style="">5. In Vertical Partitioning.aspx, add three GridViews, use GridView Tasks Wizard to set data source for GridView1 and GridView2.<span style="">&nbsp;
</span>GridView1's DataSource should be Students.Student table. GridView2's DataSource should be Courses.Course table. For more detail, you can look into Vertical Partitioning.aspx.
</span></p>
<p class="MsoNormal" style=""><span style="">6. In Vertical Partitioning.aspx.vb, set the data source for GridView3 as follows.
</span>6. Build the application and you can debug it now.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim studentDataReader = SQLAzureHelper.ExecuteReader(ConfigurationManager.ConnectionStrings(&quot;StudentsConnectionString&quot;).ConnectionString, Function(sqlConnection) 
Dim sqlCommand As New SqlCommand(&quot;SELECT StudentId, StudentName FROM Student&quot;, sqlConnection)
Return (sqlCommand.ExecuteReader())


End Function)


Dim courseDataReader = SQLAzureHelper.ExecuteReader(ConfigurationManager.ConnectionStrings(&quot;CoursesConnectionString&quot;).ConnectionString, Function(sqlConnection) 
Dim sqlCommand As New SqlCommand(&quot;SELECT CourseName, StudentId FROM Course&quot;, sqlConnection)
Return (sqlCommand.ExecuteReader())


End Function)


' Join two tables on different SQL Azure databases using LINQ. 
Dim query = From student In studentDataReaderJoin course In courseDataReader On DirectCast(student(&quot;StudentId&quot;), Int32) = DirectCast(course(&quot;StudentId&quot;), Int32)New With { _
    Key .CourseName = DirectCast(course(&quot;CourseName&quot;), String), _
    Key .StudentName = DirectCast(student(&quot;StudentName&quot;), String) _
}


Me.GridView3.DataSource = query
Me.GridView3.DataBind()

</pre>
<pre id="codePreview" class="vb">
Dim studentDataReader = SQLAzureHelper.ExecuteReader(ConfigurationManager.ConnectionStrings(&quot;StudentsConnectionString&quot;).ConnectionString, Function(sqlConnection) 
Dim sqlCommand As New SqlCommand(&quot;SELECT StudentId, StudentName FROM Student&quot;, sqlConnection)
Return (sqlCommand.ExecuteReader())


End Function)


Dim courseDataReader = SQLAzureHelper.ExecuteReader(ConfigurationManager.ConnectionStrings(&quot;CoursesConnectionString&quot;).ConnectionString, Function(sqlConnection) 
Dim sqlCommand As New SqlCommand(&quot;SELECT CourseName, StudentId FROM Course&quot;, sqlConnection)
Return (sqlCommand.ExecuteReader())


End Function)


' Join two tables on different SQL Azure databases using LINQ. 
Dim query = From student In studentDataReaderJoin course In courseDataReader On DirectCast(student(&quot;StudentId&quot;), Int32) = DirectCast(course(&quot;StudentId&quot;), Int32)New With { _
    Key .CourseName = DirectCast(course(&quot;CourseName&quot;), String), _
    Key .StudentName = DirectCast(student(&quot;StudentName&quot;), String) _
}


Me.GridView3.DataSource = query
Me.GridView3.DataBind()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span style="">7. In Horizontal Partioning.aspx. Add two GridViews, use GridView Tasks Wizard to set data source for GridView1 and GridView2.<span style="">&nbsp;
</span>GridView1's DataSource should be Database001.Accounts table. GridView2's DataSource should be Database002.Accounts table. For more detail, you can look into Horizontal Partioning.aspx.
</span></p>
<p class="MsoNormal" style=""><span style=""><a href="http://msdn.microsoft.com/en-us/library/ee730903.aspx">Development Considerations in SQL Azure</a>
</span></p>
<p class="MsoNormal" style=""><span style=""><a href="http://msdn.microsoft.com/en-us/library/ee621781.aspx">How to: Connect to SQL Azure Through ASP.NET</a>
</span></p>
<p class="MsoNormal" style=""><span style=""><a href="http://blogs.msdn.com/b/sqlazure/archive/2010/05/05/10007304.aspx">Unique identifier and Clustered Indexes</a>
</span></p>
<p class="MsoNormal" style=""><span style=""><a href="http://blogs.msdn.com/b/sqlazure/archive/2010/05/17/10014011.aspx">Vertical Partitioning in SQL Azure: Part 1</a>
</span></p>
<p class="MsoNormal" style=""><span style=""><a href="http://blogs.msdn.com/b/sqlazure/archive/2010/06/24/10029719.aspx">SQL Azure Horizontal Partitioning: Part 2</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

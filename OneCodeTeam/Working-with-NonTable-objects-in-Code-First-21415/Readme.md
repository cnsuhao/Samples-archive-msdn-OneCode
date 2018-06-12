# Working with NonTable objects in Code First
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ADO.NET
## Topics
* stored procedure
* view
* non-table
## IsPublished
* True
## ModifiedDate
* 2013-03-24 06:57:17
## Description

<h1>Work with Non-Table Database Object in Code First (VBEFCodeFirstNonTableObjects)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to work with nontable database objects in Code First. We can use Code First to map tables in the database, but database also supports many other types of objects, including stored procedures and views.In the
 sample, we will demonstrates how to use the stored procedure and views in Code First.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">Before you run the sample, you need to finish the following steps:</p>
<p class="MsoNormal">Step1. Attach the database file MySchool.mdf under the folder _External_Dependecies to your SQL Server 2008 database instance.</p>
<p class="MsoNormal">Step2. Modify the connection string in the App.config file according to your SQL Server 2008 database instance name.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Press F5 to run the sample, the following is the result.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/78908/1/image.png" alt="" width="641" height="311" align="middle">
</span></p>
<p class="MsoNormal">First, we get the result from the EnglishCourse view.</p>
<p class="MsoNormal">Second, we get the result from the dbo.CourseExtInfoSP stored procedure, and then change it. After save the change, we get and show the result again. You will notice the two results are same.</p>
<p class="MsoNormal">Finally, we get the result from the dbo.DepartmentInfo stored procedure, and then change it. After save the change, we get and show the result again. You will notice the Budget values of the two results are different.</p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
1. Get the English Course list from the EnglishCourse view.</p>
<p class="MsoNormal"><span style="">&nbsp;</span>Because the view doesn't have the same column name of the CourseName property on Course class, we need to alias the Title column in the Select statement.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim courses As DbSqlQuery(Of Course) = school.Courses.SqlQuery(
&nbsp;&nbsp;&nbsp; &quot;Select CourseID,&quot; & ControlChars.CrLf & _
&nbsp;&nbsp;&nbsp; &quot;Title as CourseName,&quot; & ControlChars.CrLf & _
&nbsp;&nbsp;&nbsp; &quot;Credits,&quot; & ControlChars.CrLf & _
&nbsp;&nbsp;&nbsp; &quot;DepartmentID&quot; & ControlChars.CrLf & _
&nbsp;&nbsp;&nbsp; &quot;from dbo.EnglishCourse&quot;)

</pre>
<pre id="codePreview" class="vb">
Dim courses As DbSqlQuery(Of Course) = school.Courses.SqlQuery(
&nbsp;&nbsp;&nbsp; &quot;Select CourseID,&quot; & ControlChars.CrLf & _
&nbsp;&nbsp;&nbsp; &quot;Title as CourseName,&quot; & ControlChars.CrLf & _
&nbsp;&nbsp;&nbsp; &quot;Credits,&quot; & ControlChars.CrLf & _
&nbsp;&nbsp;&nbsp; &quot;DepartmentID&quot; & ControlChars.CrLf & _
&nbsp;&nbsp;&nbsp; &quot;from dbo.EnglishCourse&quot;)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
2. Get the CourseDepartment class object from the stored procedure dbo.CourseExtInfo.<span style="font-size:9.5pt; font-family:Consolas; color:green">
</span></p>
<p class="MsoNormal">a. First, get the CourseDepartment from the dbo.CourseExtInfoSP, and change the Title of Course. Then get the CourseDepartment again, and show the Title of it. Because the CourseDepartment isn't the Entity model object, the change of
 it isn't saved.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Console.WriteLine(&quot;Execute the dbo.CourseExtInfoSP stored procedure:&quot;)
ExecuteCourseExtInfoSP(firstCourse.CourseID, True)
Console.WriteLine(&quot;After change the Course.Title:&quot;)
ExecuteCourseExtInfoSP(firstCourse.CourseID, False)

</pre>
<pre id="codePreview" class="vb">
Console.WriteLine(&quot;Execute the dbo.CourseExtInfoSP stored procedure:&quot;)
ExecuteCourseExtInfoSP(firstCourse.CourseID, True)
Console.WriteLine(&quot;After change the Course.Title:&quot;)
ExecuteCourseExtInfoSP(firstCourse.CourseID, False)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">b.<span style="font-size:9.5pt; line-height:115%; font-family:Consolas">
</span>Entity Framework will take care of wrapping the parameters of SqlQuery into DbParameter objects to help prevent against SQL injection attacks. It use a @p prefix for parameters followed by an integer index. Entity Framework willwill match these indexes
 up with the list of parameters you provide after the query string.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim courseSP As IEnumerable(Of CourseDepartment) =
&nbsp;&nbsp;&nbsp; school.Database.SqlQuery(Of CourseDepartment)(&quot;Exec dbo.CourseExtInfo @p0&quot;, courseID)
Dim courseDepartment As CourseDepartment = courseSP.SingleOrDefault()

</pre>
<pre id="codePreview" class="vb">
Dim courseSP As IEnumerable(Of CourseDepartment) =
&nbsp;&nbsp;&nbsp; school.Database.SqlQuery(Of CourseDepartment)(&quot;Exec dbo.CourseExtInfo @p0&quot;, courseID)
Dim courseDepartment As CourseDepartment = courseSP.SingleOrDefault()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
3. Get the Department class object from the stored procedure dbo.DepartmentInfo.</p>
<p class="MsoNormal">a. First, get the Department from the dbo.dbo.DepartmentInfo, and change the Budget of Department. Then get the Department again, and show the Budget of it. Because the Department is the Entity model object, the change of it is saved.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Console.WriteLine(&quot;Execute the dbo.DepartmentInfo stored procedure:&quot;)
ExecuteDepartmentSP(firstCourse.DepartmentID, True)
Console.WriteLine(&quot;After change the Department.Budget:&quot;)
ExecuteDepartmentSP(firstCourse.DepartmentID, False)

</pre>
<pre id="codePreview" class="vb">
Console.WriteLine(&quot;Execute the dbo.DepartmentInfo stored procedure:&quot;)
ExecuteDepartmentSP(firstCourse.DepartmentID, True)
Console.WriteLine(&quot;After change the Department.Budget:&quot;)
ExecuteDepartmentSP(firstCourse.DepartmentID, False)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">b.<span style="font-size:9.5pt; line-height:115%; font-family:Consolas">
</span>We add the SqlParameter objects in the SqlQuery method, and use the parameter names in the query string.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Dim departmentId_Renamed As New SqlParameter(&quot;@DepartmentID&quot;, departmentID)
Dim courseCount As SqlParameter = New SqlParameter With
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .ParameterName = &quot;@CourseCount&quot;,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Value = -1,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Direction = ParameterDirection.Output
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }




Dim departmentSP As IEnumerable(Of Department) = school.Departments.SqlQuery(
&nbsp;&nbsp;&nbsp; &quot;Exec dbo.DepartmentInfo @DepartmentID,@CourseCount out&quot;, departmentId_Renamed, courseCount)
Dim department As Department = departmentSP.SingleOrDefault()

</pre>
<pre id="codePreview" class="vb">
Dim departmentId_Renamed As New SqlParameter(&quot;@DepartmentID&quot;, departmentID)
Dim courseCount As SqlParameter = New SqlParameter With
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .ParameterName = &quot;@CourseCount&quot;,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Value = -1,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Direction = ParameterDirection.Output
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }




Dim departmentSP As IEnumerable(Of Department) = school.Departments.SqlQuery(
&nbsp;&nbsp;&nbsp; &quot;Exec dbo.DepartmentInfo @DepartmentID,@CourseCount out&quot;, departmentId_Renamed, courseCount)
Dim department As Department = departmentSP.SingleOrDefault()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/query/dev10.query?appId=Dev10IDEF1&l=EN-US&k=k(%22SYSTEM.DATA.ENTITY.DATABASE.SQLQUERY%60%601%22);k(TargetFrameworkMoniker-%22.NETFRAMEWORK%2cVERSION%3dV4.0%22);k(DevLang-CSHARP)&rd=true">Database.SqlQuery
 Method</a></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/gg679467(v=vs.103).aspx">DbContext Constructor (String)</a></p>
<p class="MsoNormal"><span class="MsoHyperlink"><a href="http://blogs.msdn.com/b/diego/archive/2012/01/10/how-to-execute-stored-procedures-sqlquery-in-the-dbcontext-api.aspx">Stored procedures with output parameters using SqlQuery in the DbContext API</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

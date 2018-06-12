# EF4 CodeOnly feature demo (CSEFCodeOnly)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ADO.NET
* Entity Framework
## Topics
* Data Access
* Code Only
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:17:09
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CSEFCodeOnly Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The CSEFCodeOnly example illustrates how to use the new feature Code Only<br>
in the Entity Framework 4.0 to use create the Entity Data Model metadata<br>
and the corresponding .edmx file with POCO entity classes and ObjectContext<br>
class at runtime. &nbsp;It also demostrates some insert and query operations to <br>
test the created the Entity Data Model metadata.<br>
<br>
</p>
<h3>Prerequisite:</h3>
<p style="font-family:Courier New"><br>
1. Please install ADO.NET Entity Framework 4 CTP3. <br>
&nbsp; (Please see the reference section)<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Please directly run the executable file built from this project. &nbsp;It will <br>
create the Entity Data Model metadata during the runtime, create the <br>
corresponding .edmx file, generate the database &quot;CodeOnlyDB&quot; on your <br>
SQL Server Express instance, and then insert and query some relational data.<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
1. Add Reference &quot;Microsoft.Data.Entity.CTP&quot; which is installed by ADO.NET<br>
&nbsp; Entity Framework 4.0 CTP2.<br>
2. Create POCO entities and the corresponding custom ObjectContext class.<br>
&nbsp; 1) Create a file named &quot;CodeOnlyContainer.cs&quot; to hold the entity classes.<br>
&nbsp; 2) Add POCO entity classes: <br>
&nbsp; &nbsp; &nbsp;Type-per-Table series: PersonTPT, AdminTPT, InstructorTPT, StudentTPT
<br>
&nbsp; &nbsp; &nbsp;and BusinessStudentTPT. <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Type-per-Hierarchy series: PersonTPH, AdminTPH, InstructorTPH and<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;StudentTPH.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Other relational entities: Department, Course, CourseStudent.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Complex Type classes: Name and Address.<br>
&nbsp; 3) Create a class named CodeOnlyContainer which inherits ObjectContext <br>
&nbsp; &nbsp; &nbsp;and add some IbjectSet&lt;&gt; collection according to the POCO entities.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;(ICollection&lt;&gt;, IObjectSet&lt;&gt;)<br>
<br>
3. Create EntityConfiguration and ComplexTypeConfiguration classes to map the<br>
&nbsp; POCO entities to the database tables. <br>
&nbsp; 1) Create a file named &quot;EntityConfiguration.cs&quot; to hold the <br>
&nbsp; &nbsp; &nbsp;EntityConfiguration and ComplexTypeConfiguration classes. <br>
&nbsp; 2) Add EntityConfiguration and ComplexTypeConfiguration classes to map<br>
&nbsp; &nbsp; &nbsp;the POCO entities to the database tables.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;(EntityConfiguration.HasKey, EntityConfiguration.Property,<br>
&nbsp; &nbsp; &nbsp; EntityConfiguration.MapHierarchy, EntityConfiguration.Relationship,<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; EntityConfiguration.MapHierarchy.Case, StringPropertyConfiguration.IsMax,<br>
&nbsp; &nbsp; &nbsp; StringPropertyConfiguration.IsRequired, DecimalConfiguration.Precision,<br>
&nbsp; &nbsp; &nbsp; StringPropertyConfiguration.HasMaxLength, DecimalConfiguration.Scale,<br>
&nbsp; &nbsp; &nbsp; NavigationPropertyConfiguration.FromProperty, EntityMap.ToTable,
<br>
&nbsp; &nbsp; &nbsp; NavigationPropertyConfiguration.HasConstraint, <br>
&nbsp; &nbsp; &nbsp; NavigationProeprtyConfiguration.IsRequired)<br>
&nbsp; 3) Create testing methods to create the Entity Data Model metadata during<br>
&nbsp; &nbsp; &nbsp;runtime, generate .edmx file, create the database and inser/query some<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;relational data.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Code Only (Entity Framework Design blog)<br>
<a target="_blank" href="http://blogs.msdn.com/efdesign/archive/2009/06/10/code-only.aspx">http://blogs.msdn.com/efdesign/archive/2009/06/10/code-only.aspx</a><br>
<br>
Code Only Enhancements (Entity Framework Design blog)<br>
<a target="_blank" href="http://blogs.msdn.com/efdesign/archive/2009/08/03/code-only-enhancements.aspx">http://blogs.msdn.com/efdesign/archive/2009/08/03/code-only-enhancements.aspx</a><br>
<br>
Code Only – Further Enhancements (Entity Framework Design blog)<br>
<a target="_blank" href="http://blogs.msdn.com/efdesign/archive/2009/10/12/code-only-further-enhancements.aspx">http://blogs.msdn.com/efdesign/archive/2009/10/12/code-only-further-enhancements.aspx</a><br>
<br>
Feature CTP Walkthrough: Code Only for the Entity Framework (Updated)<br>
<a target="_blank" href="http://blogs.msdn.com/adonet/pages/feature-ctp-walkthrough-code-only-for-the-entity-framework.aspx">http://blogs.msdn.com/adonet/pages/feature-ctp-walkthrough-code-only-for-the-entity-framework.aspx</a><br>
<br>
ADO.NET Entity Framework 4.0 CTP3<br>
<a target="_blank" href="http://www.microsoft.com/downloads/details.aspx?FamilyID=af18e652-9ea7-478b-8b41-8424b94e3f58&displayLang=en">http://www.microsoft.com/downloads/details.aspx?FamilyID=af18e652-9ea7-478b-8b41-8424b94e3f58&displayLang=en</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

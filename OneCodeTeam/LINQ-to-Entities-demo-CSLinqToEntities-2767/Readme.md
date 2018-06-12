# LINQ to Entities demo (CSLinqToEntities)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ADO.NET
* LINQ
## Topics
* Data Access
* EDM
* LINQ to Entities
## IsPublished
* True
## ModifiedDate
* 2011-05-05 05:38:44
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CSLinqToEntities Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The CSLinqToEntities example demonstrates the Microsoft Language-Integrated <br>
Query (LINQ) technology to access ADO.NET Entity Data Model using Visual C#. <br>
It shows the basic structure of connecting and querying the data source and<br>
inserting data into the database with LINQ. &nbsp;It especially demonstrates the<br>
new features of LINQ to Entities comparing with LINQ to SQL, Inheritance<br>
and Many-to-Many Relationship (without payload).<br>
<br>
</p>
<h3>Project Relation:</h3>
<p style="font-family:Courier New"><br>
CSLinqToEntites -&gt; SQLServer2005DB<br>
CSLinqToEntites accesses the database created by SQLServer2005DB.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. Generating ADO.NET Entity Data Model in Visual Studio 2008.<br>
&nbsp; <br>
&nbsp; Steps:<br>
&nbsp; (1) Right-click on the project and add a new item. Add an <br>
&nbsp; &nbsp; &nbsp; &quot;ADO.NET Entity Data Model&quot; and call it &quot;School.edmx&quot; to correspond to
<br>
&nbsp; &nbsp; &nbsp; your database.<br>
&nbsp; <br>
&nbsp; (2) The Entity Data Model Wizard shows up and you now can use this to query
<br>
&nbsp; &nbsp; &nbsp; your database and generate the model diagram, as long as you supply it
<br>
&nbsp; &nbsp; &nbsp; with the right credentials. In the Wizard, click &quot;Generate from Database&quot;
<br>
&nbsp; &nbsp; &nbsp; and click &quot;Next&quot;.<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; (3) Supply it with the right server name, authentication, credentials, and
<br>
&nbsp; &nbsp; &nbsp; the database name.<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; (4) Modify &quot;Save entity connections settings in App.Config as&quot; to
<br>
&nbsp; &nbsp; &nbsp; &quot;SchoolEntities&quot; to correspond to your database.<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; (5) In the next dialog box, choose all of the options—tables, views, and <br>
&nbsp; &nbsp; &nbsp; stored procedures—and the model will be generated for you. &nbsp;Here we
<br>
&nbsp; &nbsp; &nbsp; choose the table, Course, CourseGrade, CourseInstructor, Person. &nbsp;<br>
&nbsp; &nbsp; &nbsp; <br>
2. Create Table-per-Hierarchy Inheritance. &nbsp;<br>
&nbsp; <br>
&nbsp; Steps:<br>
&nbsp; (1) Right Click on the model diagram. From the context menu select <br>
&nbsp; &nbsp; &nbsp; &quot;Add&quot; -&gt; &quot;Entity&quot;.<br>
&nbsp; (2) On Add Entity dialog window, set Entity name to &quot;Student&quot;. Set Base
<br>
&nbsp; &nbsp; &nbsp; type to &quot;Person&quot;, this should define the inheritance. Note that once
<br>
&nbsp; &nbsp; &nbsp; you define Base type, all other properties on the dialog will be
<br>
&nbsp; &nbsp; &nbsp; disabled. Click &quot;Ok&quot;.<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; (3) Delete &quot;EnrollmentDate&quot; property on &quot;Person&quot; Entity as it will be
<br>
&nbsp; &nbsp; &nbsp; specific &quot;Student&quot; Entity. Do the same for &quot;HireDate&quot; as it will be
<br>
&nbsp; &nbsp; &nbsp; specific for &quot;Instructor&quot; Entity.<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; (4) Right-click on &quot;Student&quot; Entity. Select &quot;Add&quot; -&gt; &quot;Scalar Property&quot;.
<br>
&nbsp; &nbsp; &nbsp; Name the property &quot;EnrollmentDate&quot;. Set its data type on the property
<br>
&nbsp; &nbsp; &nbsp; window to DateTime. <br>
<br>
3. Define data mappings:<br>
<br>
&nbsp; Steps:<br>
&nbsp; (1) Right-click on &quot;Student&quot; Entity and select &quot;Table Mapping&quot;. This
<br>
&nbsp; &nbsp; &nbsp; should display Mapping Details Pan for &quot;Student&quot; Entity.<br>
&nbsp; &nbsp;<br>
&nbsp; (2) From Mapping Details pan under Tables click on &lt;Add a Table or View&gt;
<br>
&nbsp; &nbsp; &nbsp; and select &quot;Person&quot;.<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; (3) Click on &lt;Add a Condition&gt; and select &quot;PersonCategory&quot;. Leave the
<br>
&nbsp; &nbsp; &nbsp; Operator as &quot;=&quot; and set the Value/Property to 1. <br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; (4) Under Column Mappings make sure that &quot;EnrollmentDate&quot; column is mapped
<br>
&nbsp; &nbsp; &nbsp; to &quot;EnrollmentDate&quot; property. <br>
<br>
&nbsp; Repeat the above steps for Instructor Entity and set the mapping condition
<br>
&nbsp; to its proper values. Delete the &quot;PersonCategory&quot; property from &quot;Person&quot;
<br>
&nbsp; Entity as it is not needed anymore.<br>
&nbsp; <br>
4. Perform the Insert operation and display the query results.<br>
<br>
5. Perform the query operation in one data table and display the query <br>
&nbsp; results.<br>
<br>
6. Perform the query operation across multiple data tables and display the <br>
&nbsp; query results.<br>
<br>
7. Perform the query operation across multiple related data tables and <br>
&nbsp; display the query results.<br>
<br>
8. Perform the query operation accross Many-to-Many related data tables and <br>
&nbsp; display the query results.<br>
&nbsp; <br>
&nbsp; </p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
LINQ to Entities<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb386964.aspx">http://msdn.microsoft.com/en-us/library/bb386964.aspx</a><br>
<br>
ADO.NET Entity Framework<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb399572.aspx">http://msdn.microsoft.com/en-us/library/bb399572.aspx</a><br>
<br>
Introducing LINQ to Relational Data<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc161164.aspx">http://msdn.microsoft.com/en-us/library/cc161164.aspx</a><br>
<br>
Defining Advanced Data Models<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb738640.aspx">http://msdn.microsoft.com/en-us/library/bb738640.aspx</a><br>
<br>
How to: Define a Model with Table-per-Type Inheritance (Entity Framework)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb738685.aspx">http://msdn.microsoft.com/en-us/library/bb738685.aspx</a><br>
<br>
How to: Define a Model with Table-per-Hierarchy Inheritance (Entity Framework)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb738443.aspx">http://msdn.microsoft.com/en-us/library/bb738443.aspx</a><br>
<br>
Entity Data Model 101: Part 1<br>
<a target="_blank" href="http://blogs.msdn.com/adonet/archive/2007/01/30/entity-data-model-part-1.aspx">http://blogs.msdn.com/adonet/archive/2007/01/30/entity-data-model-part-1.aspx</a><br>
<br>
Entity Data Model 101: Part 2<br>
<a target="_blank" href="http://blogs.msdn.com/adonet/archive/2007/02/12/entity-data-model-101-part-2.aspx">http://blogs.msdn.com/adonet/archive/2007/02/12/entity-data-model-101-part-2.aspx</a><br>
<br>
Inheritance in the Entity Framework<br>
<a target="_blank" href="http://blogs.msdn.com/adonet/archive/2007/03/15/inheritance-in-the-entity-framework.aspx">http://blogs.msdn.com/adonet/archive/2007/03/15/inheritance-in-the-entity-framework.aspx</a><br>
<br>
ADO.NET Entity Framework Tutorial and Basics<br>
<a target="_blank" href="http://www.codeguru.com/csharp/csharp/cs_linq/article.php/c15489/">http://www.codeguru.com/csharp/csharp/cs_linq/article.php/c15489/</a><br>
<br>
Inheritance and Associations with Entity Framework Part 1<br>
<a target="_blank" href="http://mosesofegypt.net/post/Inheritance-and-Associations-with-Entity-Framework-Part-1.aspx">http://mosesofegypt.net/post/Inheritance-and-Associations-with-Entity-Framework-Part-1.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

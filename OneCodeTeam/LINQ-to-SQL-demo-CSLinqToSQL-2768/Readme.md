# LINQ to SQL demo (CSLinqToSQL)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ADO.NET
* LINQ
## Topics
* LINQ to SQL
* Data Access
## IsPublished
* True
## ModifiedDate
* 2011-05-05 05:40:05
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CSLinqToSQL Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The CSLinqToSQL sample demonstrates the Microsoft Language-Integrated Query <br>
(LINQ) technology to access databases using Visual C#. It shows the basic <br>
structure of connecting to a data source with LINQ, and how to query and <br>
manipulate data in database with LINQ. This example contains manually-created <br>
entities and designer-generated entities.<br>
<br>
</p>
<h3>Project Relation:</h3>
<p style="font-family:Courier New"><br>
CSLinqToSQL -&gt; SQLServer2005DB<br>
CSLinqToSQL accesses the database created by SQLServer2005DB.<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
Please refer to the MSDN article <br>
<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/bb387007.aspx">http://msdn.microsoft.com/en-us/library/bb387007.aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb387007.aspx">http://msdn.microsoft.com/en-us/library/bb387007.aspx</a><br>
for the typical steps of using LINQ to SQL.<br>
<br>
A. Creating the Object Model (LINQ to SQL)<br>
<br>
Step1. Select a tool to create the model.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;* The Object Relational Designer <br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;1. Right-click the project in the Solution Explorer and select Add New
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Item on the shortcut menu.<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;2. Select the LINQ to SQL Classes template, and type School.dbml as the
<br>
&nbsp;&nbsp;&nbsp;&nbsp;name. Click Add.<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;3. In the Server Explorer window, select the SQLServer2005DB database and<br>
&nbsp;&nbsp;&nbsp;&nbsp;toss the tables (Person, Course, CourseGrade) onto the O/R designer to<br>
&nbsp;&nbsp;&nbsp;&nbsp;generate the entities and the DataContext.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;* A code editor<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;1. Add a class named SchoolDB into the project.<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;2. In the class, define all the entities as well as their relationship.<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;3. Define the DataContext class: SchoolDataContext.<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
Step2. Select the kind of code you want to generate.<br>
<br>
Step3. Refine the code file to reflect the needs of your application.<br>
<br>
B. Using the Object Model <br>
<br>
Step1. Perform the Insert operation<br>
<br>
Step2. Perform the Query operations<br>
<br>
</p>
<h3>Usage of designer:</h3>
<p style="font-family:Courier New"><br>
1. From within a C# application, on the Project menu, click Add New Item.<br>
<br>
2. Select the LINQ to SQL Classes template.<br>
<br>
3. Type Scholl.dbml as the name and click Add.<br>
<br>
4. In the Server Explorer windows, select the School Database and drop the <br>
&nbsp; tables(Person, Course, CourseGrade) onto the O/R designer to create data <br>
&nbsp; classes and DataContext methods.<br>
&nbsp; <br>
5. Rename the Context Namespace and Entity Namespace to CSLinqToSQL.Designer<br>
<br>
6. Build and run the project.<br>
<br>
</p>
<h3>Handle the column that has a default value in the database:</h3>
<p style="font-family:Courier New"><br>
&quot;When you insert an entity using LINQ to SQL you first create an instance of
<br>
that entity. &nbsp;At this point the DataContext has no means by which to <br>
determine that you would like certain fields to be assigned their default on <br>
the server during SubmitChanges. &nbsp;For example, you give a default value of 10
<br>
for an integer column in the database. When you create the entity that field <br>
in the object is defaulted to zero. The DataContext cannot distinguish between <br>
a field with an assigned value of zero and one that is merely unassigned. &nbsp;So,
<br>
the DataContext must assume that the zero was assigned and send it as part of <br>
the generated insert statement.&quot; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
<br>
Possible workaround we use in this example is to set the property to the <br>
default value in the entity's constructor manually. &nbsp;<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Getting Started (LINQ to SQL)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb399398.aspx">http://msdn.microsoft.com/en-us/library/bb399398.aspx</a><br>
<br>
Typical Steps for Using LINQ to SQL<br>
<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/bb387007.aspx">http://msdn.microsoft.com/en-us/library/bb387007.aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb387007.aspx">http://msdn.microsoft.com/en-us/library/bb387007.aspx</a><br>
<br>
How to: Insert Rows Into the Database (LINQ to SQL)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb386941.aspx">http://msdn.microsoft.com/en-us/library/bb386941.aspx</a><br>
<br>
LINQ to SQL: .NET Language-Integrated Query for Relational Data<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb425822.aspx">http://msdn.microsoft.com/en-us/library/bb425822.aspx</a><br>
<br>
101 LINQ Samples<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/vcsharp/aa336746.aspx">http://msdn.microsoft.com/en-us/vcsharp/aa336746.aspx</a><br>
<br>
Linq to SQL: Columns with NOT NULL and DEFAULT<br>
<a target="_blank" href="http://social.msdn.microsoft.com/forums/en-US/linqprojectgeneral/thread/f5753fc9-89bd-4f9a-94d9-be616a8d9a14/">http://social.msdn.microsoft.com/forums/en-US/linqprojectgeneral/thread/f5753fc9-89bd-4f9a-94d9-be616a8d9a14/</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

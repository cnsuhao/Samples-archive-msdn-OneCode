# Entity Data Model demo (VBEFEntityDataModel)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ADO.NET
* Entity Framework
## Topics
* Data Access
* EDM
## IsPublished
* True
## ModifiedDate
* 2011-05-05 07:49:28
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : VBEFEntityDataaModel Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This example illustrates how to work with EDM in various ways. It includes <br>
many to many association, one to many association, one to one association, <br>
table merging, table splitting, table per hierarchy inheritance, and table <br>
per type inheritance. In the example, you will see the insert, update and <br>
query operations to entities.<br>
<br>
</p>
<h3>Prerequisite:</h3>
<p style="font-family:Courier New"><br>
1, Please attach database file EFDemoDB.mdf under the foler <br>
_External_Dependencies to your SQL Server 2005 Express or SQL Server 2005 <br>
database instance. &nbsp;<br>
<br>
2. Please modify the connection string in the App.config file according to <br>
your database instance name. <br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"></p>
<h3>Many To Many Association</h3>
<p style="font-family:Courier New"></p>
<h3></h3>
<p style="font-family:Courier New">Tables:(main related columns)<br>
[Course]<br>
CourseID [PK]<br>
Title<br>
<br>
[CourseInstructor]<br>
CourseID [PK] [FK]<br>
PersonID [PK] [FK]<br>
<br>
[Person]<br>
PersonID [PK]<br>
LastName<br>
FirstName<br>
<br>
Create EDM Steps:<br>
1) Add -&gt; New Item -&gt; ADO.NET Entity Data Model.<br>
2) Choose EFDemoDB -&gt; Select the three tables above.<br>
3) Get the model with many to many association.<br>
4) Build the solution.<br>
<br>
</p>
<h3>One To Many Association</h3>
<p style="font-family:Courier New"></p>
<h3></h3>
<p style="font-family:Courier New">Tables:(main related columns)<br>
[Department]<br>
DepartmentID [PK]<br>
Name<br>
<br>
[Course]<br>
CourseID [PK]<br>
Title<br>
DepartmentID [FK]<br>
<br>
Create EDM Steps:<br>
1) Add -&gt; New Item -&gt; ADO.NET Entity Data Model.<br>
2) Choose EFDemoDB -&gt; Select the two tables above.<br>
3) Get the model with one to many association.<br>
4) Build the solution.<br>
<br>
</p>
<h3>One To One Association</h3>
<p style="font-family:Courier New"></p>
<h3></h3>
<p style="font-family:Courier New">Tables:(main related columns)<br>
[Person]<br>
PersonID [PK]<br>
LastName<br>
FirstName<br>
<br>
[PersonAddress]<br>
PersonID [PK] [FK]<br>
Address<br>
Postcode<br>
<br>
Create EDM Steps:<br>
1) Add -&gt; New Item -&gt; ADO.NET Entity Data Model.<br>
2) Choose EFDemoDB -&gt; Select the two tables above.<br>
3) Get the model with one to one association.<br>
4) Build the solution.<br>
<br>
</p>
<h3>Table Merging</h3>
<p style="font-family:Courier New"></p>
<h3></h3>
<p style="font-family:Courier New">Tables:(main related columns)<br>
[Person]<br>
PersonID [PK]<br>
LastName<br>
FirstName<br>
<br>
[PersonAddress]<br>
PersonID [PK] [FK]<br>
Address<br>
Postcode<br>
<br>
Create EDM Steps:<br>
1) Add -&gt; New Item -&gt; ADO.NET Entity Data Model.<br>
2) Choose EFDemoDB -&gt; Select the two tables.<br>
3) Cut(Ctrl&#43;X) the Address and Postcode properties in PersonAddress entity <br>
&nbsp; and paste(Ctrl&#43;V) it to Person entity.<br>
4) Delete the PersonAddress entity.<br>
5) Right click Person entity -&gt; Table Mapping -&gt; Add a Table or View -&gt; <br>
&nbsp; Choose PersonAddress table in the dropdown list.<br>
6) Build the solution.<br>
<br>
</p>
<h3>Table Per Hierarchy Inheritance</h3>
<p style="font-family:Courier New"></p>
<h3></h3>
<p style="font-family:Courier New">Tables:(main related columns)<br>
[Person]<br>
PersonID [PK]<br>
LastName<br>
FirstName<br>
PersonCategory<br>
HireDate<br>
EnrollmentDate<br>
Picture<br>
BusinessCredits<br>
AdminDate<br>
<br>
Create EDM Steps:<br>
1) Add -&gt; New Item -&gt; ADO.NET Entity Data Model.<br>
2) Choose EFDemoDB -&gt; Select the Person table.<br>
3) Right click the canvas -&gt; Add -&gt; Entity.<br>
4) Entity name: Student Base type: Person.<br>
5) Repeat the third step and add entities as follows,<br>
&nbsp; Entity name: Instructor &nbsp; &nbsp; &nbsp;Base type: Person<br>
&nbsp; Entity name: Admin &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Base type: Person<br>
&nbsp; Entity name: BusinessStudent Base type: Student<br>
6) Simply single-click on the property in the Person entity and press ctrl&#43;x. &nbsp;<br>
&nbsp; Then single-click on the Scalar Properties section of the appropriate <br>
&nbsp; entity and press 'ctrl &#43; v'. <br>
&nbsp; The properties to cut and paste are as follows:<br>
<br>
&nbsp; EnrollmentDate –&gt; Student <br>
&nbsp; AdminDate &nbsp; &nbsp; &nbsp;–&gt; Admin <br>
&nbsp; HireDate &nbsp; &nbsp; &nbsp; –&gt; Instructor <br>
&nbsp; BusinessCredits–&gt; BusinessStudent<br>
<br>
7) Ritht click Student entity -&gt; Table Mapping -&gt; Map the entity to Person <br>
&nbsp; table.Do the same to Admin,Instructor and &nbsp;BusinessStudent. &nbsp;<br>
8) Right click Person entity -&gt; Table Mapping -&gt; Click Add a Condition -&gt;
<br>
&nbsp; Choose PersonCategory -&gt; Value = 0.<br>
&nbsp; Do the same to other entities and set as follows,<br>
&nbsp; Student &nbsp; &nbsp; &nbsp; &nbsp; 1<br>
&nbsp; Instrutor &nbsp; &nbsp; &nbsp; 2<br>
&nbsp; Admin &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 3<br>
&nbsp; BusinessStudent 4<br>
&nbsp; <br>
9) Delete PersonCategory in the Person entity. <br>
&nbsp; It must be done after the step7.<br>
10)Build the solution. &nbsp; <br>
<br>
</p>
<h3>Table Per Type Inheritance</h3>
<p style="font-family:Courier New"></p>
<h3></h3>
<p style="font-family:Courier New">Tables:(main related columns)<br>
[PersonTPT]<br>
PersonID [PK]<br>
LastName<br>
FirstName<br>
<br>
[StudentTPT]<br>
PersonID [PK] [FKtoPersonTPT]<br>
Degree<br>
EnrollmentDate<br>
<br>
[InstructorTPT]<br>
PersonID [PK] [FKtoPersonTPT]<br>
HireDate<br>
<br>
[AdminTPT]<br>
PersonID [PK] [FKtoPersonTPT]<br>
AdminDate<br>
<br>
[BusinessStudentTPT]<br>
PersonID [PK] [FKtoStudentTPT]<br>
BusinessCredits<br>
<br>
Create EDM Steps:<br>
1) Add -&gt; New Item -&gt; ADO.NET Entity Data Model<br>
2) Choose EFDemoDB -&gt; Select the five tables<br>
3) Rename the PersonTPT to Person and do the same to other entities.<br>
4) Renmae the Person entity's Entity Set Name as People.<br>
5) Delete all the one to many associations generated.<br>
6) Create inheritance to Person (base type) and Student. Do the same to <br>
&nbsp; Instructor and Admin entities.<br>
7) Create inheritance to Student (base type) and BusinessStudent.<br>
8) Keep then PersonID property in Person entity and delete the PersonID <br>
&nbsp; propery in all derived entities.<br>
9) Right click the Student entity -&gt; Table Mapping -&gt; Map the PersonID <br>
&nbsp; propery to PersonID in the dropdown list.Do the same to Instructor, <br>
&nbsp; Admin and BusinessStudent.<br>
10)Build the solution<br>
<br>
</p>
<h3>Table Splitting</h3>
<p style="font-family:Courier New"></p>
<h3></h3>
<p style="font-family:Courier New">Tables:(main related columns)<br>
[Person]<br>
PersonID [PK]<br>
LastName<br>
FirstName<br>
PersonCategory<br>
Picture<br>
<br>
Create EDM Steps:<br>
1) Add -&gt; New Item -&gt; ADO.NET Entity Data Model.<br>
2) Choose EFDemoDB -&gt; Select the Person table.<br>
3) Click the Person table -&gt; Copy the Person entity(Ctrl&#43; C).<br>
4) Click the canvas -&gt; Paste the Person entity(Ctrl &#43; V) -&gt; <br>
&nbsp; Rename it to &quot;PersonDetail&quot;.<br>
5) Delete all the properties in Person entity except PersonID, LastName and<br>
&nbsp; FirstName.<br>
6) Delete LastName and FirstName properties in PersonDetail entity.<br>
7) Add a 1:1 association between &quot;Person&quot; and &quot;PersonDetail&quot; named
<br>
&nbsp; PersonPersonDetail.<br>
8) Right click the PersonDetail -&gt; Table Mapping -&gt; Map the entity<br>
&nbsp; to Person table.<br>
9) Right click the TblSplitEntitie.edmx -&gt; Open With -&gt; XML Editor.<br>
10)Add ReferentialConstraint element to PersonPersonDetail in CSDL as follows<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Association Name=&quot;PersonPersonDetail&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;End Type=&quot;EFTblSplitModel.Person&quot; Role=&quot;Person&quot; Multiplicity=&quot;1&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;End Type=&quot;EFTblSplitModel.PersonDetail&quot; Role=&quot;PersonDetail&quot;
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Multiplicity=&quot;1&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;ReferentialConstraint&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Principal Role=&quot;Person&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;PropertyRef Name=&quot;PersonID&quot;/&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Principal&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Dependent Role=&quot;PersonDetail&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;PropertyRef Name=&quot;PersonID&quot;/&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Dependent&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;/ReferentialConstraint&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Association&gt;<br>
11)Build solution.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
ADO.NET Entity Framework<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb399572.aspx">http://msdn.microsoft.com/en-us/library/bb399572.aspx</a><br>
<br>
Entity Data Model<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb387122.aspx">http://msdn.microsoft.com/en-us/library/bb387122.aspx</a><br>
<br>
Table Merging<br>
<a target="_blank" href="http://blogs.msdn.com/simonince/archive/2009/03/23/mapping-two-tables-to-one-entity-in-the-entity-framework.aspx">http://blogs.msdn.com/simonince/archive/2009/03/23/mapping-two-tables-to-one-entity-in-the-entity-framework.aspx</a><br>
<br>
Table Per Hierarchy Inheritance<br>
<a target="_blank" href="http://www.robbagby.com/entity-framework/entity-framework-modeling-table-per-Hierarchy-inheritance/">http://www.robbagby.com/entity-framework/entity-framework-modeling-table-per-Hierarchy-inheritance/</a><br>
<br>
Table Per Type Inheritance<br>
<a target="_blank" href="http://www.robbagby.com/entity-framework/entity-framework-modeling-table-per-type-inheritance/">http://www.robbagby.com/entity-framework/entity-framework-modeling-table-per-type-inheritance/</a><br>
<br>
Table Splitting<br>
<a target="_blank" href="http://blogs.msdn.com/adonet/archive/2008/12/05/table-splitting-mapping-multiple-entity-types-to-the-same-table.aspx">http://blogs.msdn.com/adonet/archive/2008/12/05/table-splitting-mapping-multiple-entity-types-to-the-same-table.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

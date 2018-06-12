# EF4 Foreign Key Association demo (VBEFForeignKeyAssociation)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ADO.NET
* Entity Framework
## Topics
* Data Access
* Foreign Key Association
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:52:56
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : VBEFForeignKeyAssociation Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
VBEFForeignKeyAssociation example demonstrates one of the new features of<br>
Entity Framework(EF) 4.0, Foreign Key Association. &nbsp;This example compares <br>
the new Foreign Key Association and the Independent Association and shows <br>
how to insert new related entities, insert by existing entities and update<br>
existing entities with the two associations.<br>
<br>
</p>
<h3>Prerequisite:</h3>
<p style="font-family:Courier New"><br>
1. Please attach the database file EFDemoDB.mdf under the folder <br>
_External_Dependencies to your SQL Server 2008 database instance.<br>
<br>
2. Please modify the connection string in the App.config according to your<br>
database instance name.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
Foreign Key Association:<br>
<br>
1. Create an Entity Data Model with Foreign Key Association. &nbsp;<br>
&nbsp; 1) Create folder FKAssociation.<br>
&nbsp; 2) Add an ADO.NET Entity Data Model named FKAssociation.edmx into the <br>
&nbsp; &nbsp; &nbsp;folder FKAssociation. &nbsp;<br>
&nbsp; 3) Set the connection string information of the EFDemoDB database.<br>
&nbsp; &nbsp; &nbsp;Note: Please see the &quot;Prerequisite&quot; section first!<br>
&nbsp; 4) Select the data tables Course and Department.<br>
&nbsp; &nbsp; &nbsp;Note: Remember to select the check box &quot;Include the foreign key columns
<br>
&nbsp; &nbsp; &nbsp;&quot;in the model&quot; to allow the Foreign Key Association!<br>
&nbsp; 5) Click &quot;Show All Files&quot; in the Solution Explorer and open the file<br>
&nbsp; &nbsp; &nbsp;FKAssociation.Designer.vb.<br>
&nbsp; 6) Add namespace &quot;VBEFForeignKeyAssociation.FKAssociation&quot; after the
<br>
&nbsp; &nbsp; &nbsp;metadata region, and add &quot;Imports&quot; codes before the metadata region.<br>
<br>
2. Create a static class named FKAssociationClass to test the insert and <br>
&nbsp; update methods with the Foreign Key Association.<br>
&nbsp; 1) Add namespace &quot;VBEFForeignKeyAssociation.FKAssociation&quot;.<br>
&nbsp; 2) Create method InsertNewRelatedEntities to insert a new Course and its <br>
&nbsp; &nbsp; &nbsp;Department entity by Foreign Key Association.<br>
&nbsp; 3) Create method InsertByExistingEntities to insert a new Course and set <br>
&nbsp; &nbsp; &nbsp;it belong to an existing Department by Foreign Key Association.<br>
&nbsp; 4) Create method UpdateExistingEntities to update an existing Course <br>
&nbsp; &nbsp; &nbsp;entity as well as its relationship.<br>
&nbsp; 5) Create method Query to query the Course entities and the corresponding <br>
&nbsp; &nbsp; &nbsp;Department entities.<br>
&nbsp; 6) Create method Test to run the insert and update methods with the <br>
&nbsp; &nbsp; &nbsp;Foreign Key Association.<br>
<br>
Independent Association:<br>
<br>
1. Create an Entity Data Model with Independent Association.<br>
&nbsp; 1) Create a folder IndependentAssociation.<br>
&nbsp; 2) Add an ADO.NET Entity Data Model named IndependentAssociation.edmx into<br>
&nbsp; &nbsp; &nbsp;the folder IndependentAssociation.<br>
&nbsp; 3) Set the connection string information of the EFDemoDB database.<br>
&nbsp; &nbsp; &nbsp;Note: Please see the &quot;Prerequisite&quot; section first!<br>
&nbsp; 4) Select the data tables Course and Department.<br>
&nbsp; &nbsp; &nbsp;Note: Remember to uncheck the check box &quot;Include the foreign key columns
<br>
&nbsp; &nbsp; &nbsp;&quot;in the model&quot; to allow the Independent Association!<br>
&nbsp; 5) Click &quot;Show All Files&quot; in the Solution Explorer and open the file<br>
&nbsp; &nbsp; &nbsp;IndependentAssociation.Designer.vb.<br>
&nbsp; 6) Add namespace &quot;VBEFForeignKeyAssociation.IndependentAssociation&quot; after
<br>
&nbsp; &nbsp; &nbsp;the metadate region, and add &quot;Imports&quot; codes before the metadata region.<br>
<br>
2. Create a static class named IndependentAssociationClass to test the insert<br>
&nbsp; and update methods with the IndependentAssociation.<br>
&nbsp; 1) Add namespace &quot;VBEFForeignKeyAssociation.IndependentAssociation&quot;.<br>
&nbsp; 2) Create method InsertNewRelatedEntities to insert a new Course and its <br>
&nbsp; &nbsp; &nbsp;Department entity by Independent Association.<br>
&nbsp; 3) Create method InsertByExistingEntities to insert a new Course and set <br>
&nbsp; &nbsp; &nbsp;it belong to an existing Department by Independent Association.<br>
&nbsp; 4) Create method UpdateExistingEntities to update an existing Course <br>
&nbsp; &nbsp; &nbsp;entity (only regular properties).<br>
&nbsp; 5) Create method Query to query the Course entities and the corresponding <br>
&nbsp; &nbsp; &nbsp;Department entities.<br>
&nbsp; 6) Create method Test to run the insert and update methods with the <br>
&nbsp; &nbsp; &nbsp;Independent Association.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Defining and Managing Relationships (Entity Framework)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ee373856%28VS.100%29.aspx">http://msdn.microsoft.com/en-us/library/ee373856%28VS.100%29.aspx</a><br>
<br>
How to: Use EntityReference Object to Change Relationships Between Objects(Entity Framework)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc716754(VS.100).aspx">http://msdn.microsoft.com/en-us/library/cc716754(VS.100).aspx</a><br>
<br>
How to: Use the Foreign Key Property to Change Relationships Between Objects<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ee473440(VS.100).aspx">http://msdn.microsoft.com/en-us/library/ee473440(VS.100).aspx</a><br>
<br>
Foreign Keys in the Entity Framework<br>
<a target="_blank" href="http://blogs.msdn.com/efdesign/archive/2009/03/16/foreign-keys-in-the-entity-framework.aspx">http://blogs.msdn.com/efdesign/archive/2009/03/16/foreign-keys-in-the-entity-framework.aspx</a><br>
<br>
Foreign Keys in the Conceptual and Object Models<br>
<a target="_blank" href="http://blogs.msdn.com/efdesign/archive/2008/10/27/foreign-keys-in-the-conceptual-and-object-models.aspx">http://blogs.msdn.com/efdesign/archive/2008/10/27/foreign-keys-in-the-conceptual-and-object-models.aspx</a><br>
<br>
Foreign Key Relationships in the Entity Framework<br>
<a target="_blank" href="http://blogs.msdn.com/adonet/archive/2009/11/06/foreign-key-relationships-in-the-entity-framework.aspx">http://blogs.msdn.com/adonet/archive/2009/11/06/foreign-key-relationships-in-the-entity-framework.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

# EF4 Complex Type Objects demo (VBEFComplexType)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ADO.NET
* Entity Framework
## Topics
* Data Access
* Complex Type
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:52:25
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : VBEFComplexType Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The VBEFComplexType example illustrates how to work with the Complex Type<br>
which is new in Entity Framework 4.0. &nbsp;It shows how to add Complex Type <br>
properties to entities, how to map Complex Type properties to table columns,<br>
and how to map a Function Import to a Complex Type.<br>
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
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
1. Create an ADO.NET Entity Data Model <br>
&nbsp; 1) Name it ComplexType.edmx.<br>
&nbsp; 2) Set the connection string information of the EFDemoDB database.<br>
&nbsp; 3) Select the data tables Person and PersonAddress, and select the <br>
&nbsp; &nbsp; &nbsp;GetPersonNameByPersonID Stored Procedure.<br>
<br>
2. Delete the entity PersonAddress.<br>
&nbsp; Note: When the dialog &quot;Delete Unmapped Tables and Views&quot; shows, select
<br>
&nbsp; &quot;No&quot; to keep the PersonAddress table in the SSDL. <br>
<br>
3. Add Complex Type PersonDate.<br>
&nbsp; 1) Right click the EDM designer -&gt; Add -&gt; Complex Type to add a new Complex<br>
&nbsp; &nbsp; &nbsp;Type and set its name to PersonDate. <br>
&nbsp; 2) Right click the Complex Type PersonDate -&gt; Add -&gt; Scalar Property -&gt;
<br>
&nbsp; &nbsp; &nbsp;DateTime to add three DateTime properties to the PersonDate type.<br>
&nbsp; &nbsp; &nbsp;(HireDate, EnrollmentDate and AdminDate) &nbsp;<br>
&nbsp; 3) Set all the three properties's Nullable value to True.<br>
<br>
4. Add Complex Type PersonAddress.<br>
&nbsp; 1) Right click the EDM designer -&gt; Add -&gt; Complex Type to add a new Complex<br>
&nbsp; &nbsp; &nbsp;Type and set its name to PersonAddress. <br>
&nbsp; 2) Right click the Complex Type PersonDate -&gt; Add -&gt; Scalar Property -&gt;
<br>
&nbsp; &nbsp; &nbsp;String to add two String properties to the PersonDate type.<br>
&nbsp; &nbsp; &nbsp;(Address and Postcode) &nbsp;<br>
&nbsp; 3) Set both the two properties's Nullable value to True.<br>
<br>
5. Add PersonDate Complex Type property into Person entity.<br>
&nbsp; 1) Delete the HireDate, EnrollmentDate, and AdminDate in the Person entity.<br>
&nbsp; 2) Right click the Person entity -&gt; Add -&gt; Complex Property to add a new<br>
&nbsp; &nbsp; &nbsp;Complex property named PersonDate in type of PersonDate.<br>
<br>
6. Similar with step 7 to add a new Complex Property named PersonAddress in<br>
&nbsp; type of PersonAddress into the Person entity.<br>
<br>
7. Map the Complex Properties to table columns.<br>
&nbsp; 1) Right click the Person entity -&gt; Table Mapping to open the Mapping <br>
&nbsp; &nbsp; &nbsp;Details window.<br>
&nbsp; 2) Map the HireDate, EnrollmentDate, and AdminDate columns to <br>
&nbsp; &nbsp; &nbsp;PersonDate.HireDate, PersonDate.EnrollmentDate, and PersonDate.AdminDate.<br>
&nbsp; 3) Add a Table to PersonAddress table.<br>
&nbsp; 4) Map the PersonID column to PersonID property and Address, Postcode <br>
&nbsp; &nbsp; &nbsp;columns to Complex Property PersonAddress.Address and <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;PersonAddress.Postcode.<br>
<br>
8. Add a Function Import of the stored procedure GetPersonNameByPersonID.<br>
&nbsp; 1) Right click the EDM designer -&gt; Add -&gt; Function Import... to open the
<br>
&nbsp; &nbsp; &nbsp;&quot;Add Function Import&quot; dialog.<br>
&nbsp; 2) Select Stored Procedure Name &quot;GetPersonNameByPersonID&quot; and make it as
<br>
&nbsp; &nbsp; &nbsp;the name of the Function Import.<br>
&nbsp; 3) Click the &quot;Get Column Information&quot; button to get the stored procedure<br>
&nbsp; &nbsp; &nbsp;return value's column information. <br>
&nbsp; 4) Click the &quot;Create New Complex Type&quot; button to create a new Complex Type<br>
&nbsp; &nbsp; &nbsp;based on the stored procedure return value.<br>
&nbsp; 5) Change the newly created Complex Type name to PersonName and click &quot;OK&quot;.<br>
<br>
9. Build the project.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Complex Type Objects (Entity Framework)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb738472(VS.100).aspx">http://msdn.microsoft.com/en-us/library/bb738472(VS.100).aspx</a><br>
<br>
How to: Add a Complex Type Property to an Entity (Entity Data Model Tools)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/dd456823(VS.100).aspx">http://msdn.microsoft.com/en-us/library/dd456823(VS.100).aspx</a><br>
<br>
How to: Create and Modify Complex Types (Entity Data Model Tools)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/dd456820(VS.100).aspx">http://msdn.microsoft.com/en-us/library/dd456820(VS.100).aspx</a><br>
<br>
How to: Map Complex Type Properties to Table Columns (Entity Data Model Tools)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/dd456822(VS.100).aspx">http://msdn.microsoft.com/en-us/library/dd456822(VS.100).aspx</a><br>
<br>
How to: Map a Function Import to a Complex Type (Entity Data Model Tools)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/dd456824(VS.100).aspx">http://msdn.microsoft.com/en-us/library/dd456824(VS.100).aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

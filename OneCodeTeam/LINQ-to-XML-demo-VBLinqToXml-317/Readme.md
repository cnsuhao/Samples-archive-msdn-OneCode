# LINQ to XML demo (VBLinqToXml)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* XML
* Data Platform
## Topics
* LINQ
* XML
## IsPublished
* True
## ModifiedDate
* 2011-05-05 07:58:35
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : VBLinqToXml Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This example illustrates how to use Linq to XML in VB.NET to create XML <br>
document from in-memory objects and SQL Server database. It also demonstrates <br>
how to write Linq to XML queries in VB.NET. &nbsp;It uses Linq to SQL when querying
<br>
data from SQL Server database. In this example, you will see VB.NET XML <br>
literals methods to create, query and edit XML document.<br>
<br>
</p>
<h3>Project Relation:</h3>
<p style="font-family:Courier New"><br>
VBLinqToXml -&gt; SQLServer2005DB<br>
VBLinqToXml accesses the database created by SQLServer2005DB.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
The following steps walk through a demonstration of the LINQ to XML sample: <br>
<br>
Step 1: Open the DB project SQLServer2005DB, right click the project file and<br>
select Deploy to create the SQLServer2005DB database in your database <br>
instance.<br>
<br>
Step 2: Modify the connection string information to consistent with your <br>
database instance and account. &nbsp;<br>
<br>
&nbsp;&lt;add name=&quot;...SQLServer2005DBConnectionString&quot; connectionString=...<br>
<br>
Step 3: Build the project VBLinqToXml..<br>
<br>
Step 4: Run the output executable file of project VBLinqToXml,<br>
VBLinqToXml.exe.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
Query the in-memory object XML document<br>
<br>
1. Create the in-memory objects based on the All-In-One Code Framework <br>
&nbsp; examples information.<br>
&nbsp; (VB.NET 9.0 new features: object initializers)<br>
&nbsp; <br>
2. Create the XML document based on the in-memory objects.<br>
&nbsp; (VB.NET XML literals)<br>
&nbsp; <br>
3. Query the in-memory object XML document.<br>
&nbsp; (VB.NET XML literals)<br>
&nbsp; <br>
Query the database XML document<br>
<br>
1. Create the XML document based on the Person table in SQLServer2005DB <br>
&nbsp; database in All-In-One Code Framework.<br>
&nbsp; (VB.NET XML literals)<br>
&nbsp; <br>
2. queries the database XML document.<br>
&nbsp; (VB.NET XML literals)<br>
&nbsp; <br>
Note: To query the SQLServer2005DB data, we use Linq to SQL technology.<br>
&nbsp; &nbsp; &nbsp;For detail about Linq to SQL examples, please see the CSLinqToSQL<br>
&nbsp; &nbsp; &nbsp;project in All-In-One Code Framework.<br>
&nbsp; &nbsp; &nbsp;<br>
Edit an XML document in file system<br>
<br>
1. Insert new XML elements to the XML document.<br>
&nbsp; (XElement.Add, VB.NET XML literals)<br>
&nbsp; <br>
2. Modify the value of certain XML element<br>
&nbsp; (XElement.Value, VB.NET XML literals)<br>
&nbsp; <br>
3. Delete certain XML element<br>
&nbsp; (XElement.Remove) <br>
&nbsp; <br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Object Initializers: Named and Anonymous Types<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb385125.aspx">http://msdn.microsoft.com/en-us/library/bb385125.aspx</a><br>
<br>
Namespaces in Visual Basic (LINQ to XML)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb387016.aspx">http://msdn.microsoft.com/en-us/library/bb387016.aspx</a><br>
<br>
Creating XML in Visual Basic<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb384808.aspx">http://msdn.microsoft.com/en-us/library/bb384808.aspx</a><br>
<br>
Embedded Expressions in XML<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb384964.aspx">http://msdn.microsoft.com/en-us/library/bb384964.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

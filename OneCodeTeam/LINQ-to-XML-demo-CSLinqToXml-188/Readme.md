# LINQ to XML demo (CSLinqToXml)
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
* 2011-05-05 05:40:38
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CSLinqToXml Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This example illustrates how to use Linq to XML in C# to create XML document<br>
from in-memory objects and SQL Server database. It also demonstrates how to<br>
write Linq to XML queries in C#. &nbsp;It uses Linq to SQL when querying data <br>
from SQL Server database. In this example, you will see the basic Linq to<br>
XML methods to create XML document and the axis methods to query and edit <br>
XML document. <br>
<br>
</p>
<h3>Project Relation:</h3>
<p style="font-family:Courier New"><br>
CSLinqToXml -&gt; SQLServer2005DB<br>
CSLinqToXml accesses the database created by SQLServer2005DB.<br>
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
Step 3: Build the project CSLinqToXml..<br>
<br>
Step 4: Run the output executable file of project CSLinqToXml,<br>
CSLinqToXml.exe.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
Query the in-memory object XML document<br>
<br>
1. Create the in-memory objects based on the All-In-One Code Framework <br>
&nbsp; examples information.<br>
&nbsp; (C# 3.0 new features: object initializers and collection initializers)<br>
&nbsp; <br>
2. Create the XML document based on the in-memory objects.<br>
&nbsp; (XDocument, XElement, XDeclaration, XAttribute, XNamespace)<br>
&nbsp; <br>
3. Query the in-memory object XML document.<br>
&nbsp; (XContainer.Descendants, XContainer.Elements, XElement.Element,<br>
&nbsp; XElement.Attribute)<br>
&nbsp; <br>
Query the database XML document<br>
<br>
1. Create the XML document based on the Person table in SQLServer2005DB <br>
&nbsp; database in All-In-One Code Framework.<br>
&nbsp; (XDocument, XElement, XDeclaration, XAttribute, XNamespace)<br>
&nbsp; <br>
2. Queries the database XML document.<br>
&nbsp; (XContainer.Descendants, XElement.Element)<br>
&nbsp; <br>
Note: To query the SQLServer2005DB data, we use Linq to SQL technology.<br>
&nbsp; &nbsp; &nbsp;For detail about Linq to SQL examples, please see the CSLinqToSQL<br>
&nbsp; &nbsp; &nbsp;project in All-In-One Code Framework.<br>
&nbsp; &nbsp; &nbsp;<br>
Edit an XML document in file system<br>
<br>
1. Insert new XML elements to the XML document.<br>
&nbsp; {XElement.Add, XAttribute, XNamespace}<br>
&nbsp; <br>
2. Modify the value of certain XML element<br>
&nbsp; (XElement.Value, XAttribute)<br>
&nbsp; <br>
3. Delete certain XML element<br>
&nbsp; (XElement.Remove) <br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Object and Collection Initializers (C# Programming Guide)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb384062.aspx">http://msdn.microsoft.com/en-us/library/bb384062.aspx</a><br>
<br>
How to: Create a Document with Namespaces (C#) (LINQ to XML)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb387075.aspx">http://msdn.microsoft.com/en-us/library/bb387075.aspx</a><br>
<br>
Scope of Default Namespaces in C# (LINQ to XML)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb943852.aspx">http://msdn.microsoft.com/en-us/library/bb943852.aspx</a><br>
<br>
Namespaces in C# (LINQ to XML)<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb387042.aspx">http://msdn.microsoft.com/en-us/library/bb387042.aspx</a><br>
<br>
</p>
<h3></h3>
<p style="font-family:Courier New"><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

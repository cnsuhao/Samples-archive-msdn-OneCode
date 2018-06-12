# LINQ to DataSets demo (CSLinqToDataSets)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ADO.NET
* LINQ
## Topics
* Data Access
* LINQ to DataSets
## IsPublished
* True
## ModifiedDate
* 2011-05-05 05:38:05
## Description

<p style="font-family:Courier New"></p>
<h2>CONSOLE APPLICATION : CSLinqToDataSets Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The CSLinqToDataSets sample demonstrates the Microsoft Language-Integrated <br>
Query (LINQ) technology to access untyped DataSet and strong typed DataSet <br>
using Visual C#. <br>
<br>
</p>
<h3>Project Relation:</h3>
<p style="font-family:Courier New"><br>
CSLinqToDataSets -&gt; SQLServer2005DB<br>
CSLinqToDataSets accesses the database created by SQLServer2005DB.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
Query the untyped DataSet:<br>
<br>
1. Fill the untyped DataSet and insert data into database.<br>
&nbsp; (System.Data.SqlClient.SqlDataAdapter.Fill)<br>
&nbsp; (System.Data.SqlClient.SqlDataAdapter.Update)<br>
&nbsp; <br>
2. Perform the query operation in one DataTable and display the query results.<br>
<br>
3. Perform the query operation across multiple DataTables and display the <br>
&nbsp; query results.<br>
&nbsp; <br>
Query the strong typed DataSet:<br>
<br>
1. Create the strong typed DataSet.<br>
<br>
&nbsp; Steps to create a strong typed DataSet in Visual Studio 2008:<br>
&nbsp; <br>
&nbsp; (1) On the &quot;Data&quot; menu, click Show Data Sources. <br>
&nbsp; <br>
&nbsp; (2) In the &quot;Data Sources&quot; window, click &quot;Add New Data Source&quot; to start the
<br>
&nbsp; &nbsp; &nbsp; &quot;Data Source Configuration Wizard&quot;. <br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; (3) On the &quot;Choose a Data Source Type&quot; page, click &quot;Database&quot; and then
<br>
&nbsp; &nbsp; &nbsp; click &quot;Next&quot;. <br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; (4) On the &quot;Choose Your Data Connection&quot; page, perform one of the
<br>
&nbsp; &nbsp; &nbsp; following actions: <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If a data connection to the Northwind sample database is available
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;in the drop-down list box, click it.
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-or- <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Click &quot;New Connection&quot; to open the &quot;Add/Modify Connection&quot; dialog
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;box. For more information, please see
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/c3t1z354.aspx.">http://msdn.microsoft.com/en-us/library/c3t1z354.aspx.</a>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp; (5) If the database requires a password, select the option to include <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; sensitive data, and then click &quot;Next&quot;. <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
&nbsp; (6) Click &quot;Next&quot; on the &quot;Save the Connection String to the Application
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; Configuration File&quot; page. <br>
<br>
&nbsp; (7) Expand the &quot;Tables&quot; node on the &quot;Choose Your Database Objects&quot; page.
<br>
<br>
&nbsp; (8) Click the check boxes for the tables you want in the DataSet, and then<br>
&nbsp; &nbsp; &nbsp; click &quot;Finish&quot;. <br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; (9) Click the &quot;PersonCategory&quot; column of the &quot;Person&quot; DataTable to open
<br>
&nbsp; &nbsp; &nbsp; the properties window. &nbsp;Set the &quot;DefaultValue&quot; property to 1.<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; To create a strong typed DataSet by XSD.exe, please see<br>
&nbsp; <a target="_blank" href="http://msdn.microsoft.com/en-us/library/wha85tzb.aspx">
http://msdn.microsoft.com/en-us/library/wha85tzb.aspx</a><br>
&nbsp; <br>
2. Fill the strong typed DataSet and insert data into database.<br>
&nbsp; <br>
3. Perform the query operation in one DataTable and display the query results.<br>
<br>
4. Perform the query operation across multiple DataTables and display the <br>
&nbsp; query results.<br>
&nbsp; <br>
5. Perform the query operation across multiple related DataTables and display<br>
&nbsp; the query results.<br>
&nbsp; <br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
LINQ to DataSet<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb386977.aspx">http://msdn.microsoft.com/en-us/library/bb386977.aspx</a><br>
<br>
LINQ to DataSet Samples<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/vbasic/bb688086.aspx">http://msdn.microsoft.com/en-us/vbasic/bb688086.aspx</a><br>
<br>
101 LINQ Samples<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/vcsharp/aa336746.aspx">http://msdn.microsoft.com/en-us/vcsharp/aa336746.aspx</a><br>
<br>
Usage of LINQ and DataSets in Compact Framework 3.5<br>
<a target="_blank" href="http://www.codeproject.com/KB/mobile/DatasetsAndLINQ.aspx">http://www.codeproject.com/KB/mobile/DatasetsAndLINQ.aspx</a><br>
<br>
Querying DataSets - Introduction to LINQ to DataSet<br>
<a target="_blank" href="http://blogs.msdn.com/adonet/archive/2007/01/26/querying-datasets-introduction-to-linq-to-dataset.aspx">http://blogs.msdn.com/adonet/archive/2007/01/26/querying-datasets-introduction-to-linq-to-dataset.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

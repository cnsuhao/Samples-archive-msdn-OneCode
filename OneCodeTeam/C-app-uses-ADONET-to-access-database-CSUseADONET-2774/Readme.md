# C# app uses ADO.NET to access database (CSUseADONET)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ADO.NET
## Topics
* Data Access
## IsPublished
* False
## ModifiedDate
* 2012-06-06 06:38:14
## Description

<p style="font-family:Courier New">&nbsp;</p>
<h2>CONSOLE APPLICATION : CSUseADONET Project Overview</h2>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The CSUseADONET example demonstrates the Microsoft ADO.NET technology to <br>
access databases using Visual C#. It shows the basic structure of <br>
connecting to a data source, issuing SQL commands, using Untyped DataSet,<br>
using Strong Typed DataSet, updating related data tables and performing the <br>
cleanup. <br>
<br>
</p>
<h3>Project Relation:</h3>
<p style="font-family:Courier New"><br>
CSUseADONET -&gt; SQLServer2005DB<br>
CSUseADONET accesses the database created by SQLServer2005DB.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. Connect to data source. (System.Data.SqlClient.SqlConnection.Open)<br>
<br>
2. Build and Execute an ADO.NET Command. <br>
&nbsp; (System.Data.SqlCommand.ExecuteNonQuery)<br>
&nbsp; It can be a SQL statement (SELECT/UPDATE/INSERT/DELETE), or a stored <br>
&nbsp; procedure call.<br>
&nbsp; <br>
3. Use the Untyped DataSet Object. <br>
&nbsp; (System.Data.SqlClient.SqlDataAdapter.Fill)<br>
&nbsp; The DataSet, which is an in-memory cache of data retrieved from a data <br>
&nbsp; source, is a major component of the ADO.NET architecture. &nbsp;The DataSet
<br>
&nbsp; consists of a collection of DataTable objects that you can relate to each <br>
&nbsp; other with DataRelation objects.<br>
&nbsp; <br>
4. Use the Strong Typed DataSet Object.<br>
&nbsp; A typed DataSet is a class that derives from a DataSet. As such, it <br>
&nbsp; inherits all the methods, events, and properties of a DataSet. <br>
&nbsp; Additionally, a typed DataSet provides strongly typed methods, events, and<br>
&nbsp; properties. This means you can access tables and columns by name, instead <br>
&nbsp; of using collection-based methods. Aside from the improved readability of <br>
&nbsp; the code, a typed DataSet also allows the Visual Studio .NET code editor <br>
&nbsp; to automatically complete lines as you type.<br>
&nbsp; <br>
&nbsp; Steps to create a strong typed DataSet in Visual Studio 2008:<br>
&nbsp; <br>
&nbsp; (1) On the &quot;Data&quot; menu, click Show Data Sources. <br>
&nbsp; <br>
&nbsp; (2) In the &quot;Data Sources&quot; window, click &quot;Add New Data Source&quot; to start the
<br>
&nbsp; &nbsp; &nbsp; &quot;Data Source Configuration Wizard&quot;. <br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; (3) On the &quot;Choose a Data Source Type&quot; page, click &quot;Database&quot; and then <br>
&nbsp; &nbsp; &nbsp; click &quot;Next&quot;. <br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; (4) On the &quot;Choose Your Data Connection&quot; page, perform one of the <br>
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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="http://msdn.microsoft.com/en-us/library/c3t1z354.aspx." target="_blank">http://msdn.microsoft.com/en-us/library/c3t1z354.aspx.</a>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp; (5) If the database requires a password, select the option to include <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; sensitive data, and then click &quot;Next&quot;. <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
&nbsp; (6) Click &quot;Next&quot; on the &quot;Save the Connection String to the Application <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; Configuration File&quot; page. <br>
<br>
&nbsp; (7) Expand the &quot;Tables&quot; node on the &quot;Choose Your Database Objects&quot; page. <br>
<br>
&nbsp; (8) Click the check boxes for the tables you want in the DataSet, and then<br>
&nbsp; &nbsp; &nbsp; click &quot;Finish&quot;. <br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; (9) Click the &quot;PersonCategory&quot; column of the &quot;Person&quot; DataTable to open <br>
&nbsp; &nbsp; &nbsp; the properties window. &nbsp;Set the &quot;DefaultValue&quot; property to 1.<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; To create a strong typed DataSet by XSD.exe, please see<br>
&nbsp; <a href="&lt;a target=" target="_blank">http://msdn.microsoft.com/en-us/library/wha85tzb.aspx</a>'&gt;<a href="http://msdn.microsoft.com/en-us/library/wha85tzb.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/wha85tzb.aspx</a><br>
&nbsp; <br>
5. Update Two Related Data Tables by TableAdapterManager and writting codes <br>
&nbsp; manually. &nbsp; <br>
&nbsp; <br>
&nbsp; Steps when we use TableAdapterManager:<br>
&nbsp; (1) Create a Windows Form application.<br>
&nbsp; &nbsp; &nbsp; For detail, please see <br>
&nbsp; &nbsp; &nbsp; <a href="&lt;a target=" target="_blank">http://msdn.microsoft.com/en-us/library/54xbah2z.aspx.</a>'&gt;<a href="http://msdn.microsoft.com/en-us/library/54xbah2z.aspx." target="_blank">http://msdn.microsoft.com/en-us/library/54xbah2z.aspx.</a><br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; (2) Create a strong typed DataSet. <br>
&nbsp; &nbsp; &nbsp; For detail, please see Item 4. &nbsp;<br>
&nbsp; <br>
&nbsp; (3) Change the default data-bound controls to be created.<br>
&nbsp; &nbsp; &nbsp; After populating the Data Sources window, you can choose the controls
<br>
&nbsp; &nbsp; &nbsp; to be created when you drag items to a Windows Form. For this
<br>
&nbsp; &nbsp; &nbsp; example, the data from the Department table will be displayed in
<br>
&nbsp; &nbsp; &nbsp; individual controls (Details). The data from the Course table will be
<br>
&nbsp; &nbsp; &nbsp; displayed in a DataGridView control (DataGridView). <br>
<br>
&nbsp; (4) Create the data-bound Form.<br>
&nbsp; &nbsp; &nbsp; After choosing the controls in the Data Sources window, create the
<br>
&nbsp; &nbsp; &nbsp; data-bound controls by dragging items in the Data Sources window onto
<br>
&nbsp; &nbsp; &nbsp; the form.<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; (5) Update the code to commit changes to the related before saving.<br>
&nbsp; &nbsp; &nbsp; Add a line of code to call the courseBindingSource.EndEdit method
<br>
&nbsp; &nbsp; &nbsp; after the line that calls the departmentBindingSource.EndEdit method<br>
&nbsp; &nbsp; &nbsp; in departmentBindingNavigatorSaveItem_Click event.<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; (6) Add code to commit parent records in the DataSet before adding new<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; child records<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; Create an event handler for the courseBindingSource.AddingNew event.
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; Add to the event handler a line of code that calls the
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; DepartmentBindingSource.EndEdit method.<br>
<br>
&nbsp; Steps when we write code manually:<br>
&nbsp; (1) Create a Windows Form application.<br>
&nbsp; &nbsp; &nbsp; For detail, please see <br>
&nbsp; &nbsp; &nbsp; <a href="&lt;a target=" target="_blank">http://msdn.microsoft.com/en-us/library/54xbah2z.aspx.</a>'&gt;<a href="http://msdn.microsoft.com/en-us/library/54xbah2z.aspx." target="_blank">http://msdn.microsoft.com/en-us/library/54xbah2z.aspx.</a><br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; (2) Create a strong typed DataSet. <br>
&nbsp; &nbsp; &nbsp; For detail, please see Item 4. &nbsp;<br>
&nbsp; <br>
&nbsp; (3) Change the default data-bound controls to be created.<br>
&nbsp; &nbsp; &nbsp; After populating the Data Sources window, you can choose the controls
<br>
&nbsp; &nbsp; &nbsp; to be created when you drag items to a Windows Form. For this
<br>
&nbsp; &nbsp; &nbsp; example, the data from the Department table will be displayed in
<br>
&nbsp; &nbsp; &nbsp; individual controls (Details). The data from the Course table will be
<br>
&nbsp; &nbsp; &nbsp; displayed in a DataGridView control (DataGridView). <br>
<br>
&nbsp; (4) Create the data-bound Form.<br>
&nbsp; &nbsp; &nbsp; After choosing the controls in the Data Sources window, create the
<br>
&nbsp; &nbsp; &nbsp; data-bound controls by dragging items in the Data Sources window onto
<br>
&nbsp; &nbsp; &nbsp; the form.<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; (5) Add code to update the database.<br>
&nbsp; &nbsp; &nbsp; Replace the code in the event handler to call the Update methods of
<br>
&nbsp; &nbsp; &nbsp; the related TableAdapterManager.<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; Note: For clarity this example(Updating related data tables with manually<br>
&nbsp; written code) does not use a transaction, but if you are updating two or <br>
&nbsp; more related tables, then you should include all the update logic within <br>
&nbsp; a transaction. A transaction is a process that assures all related changes
<br>
&nbsp; to a database are successful before committing any changes. <br>
&nbsp; For more information, please see <br>
&nbsp; <a href="http://msdn.microsoft.com/en-us/library/777e5ebh.aspx." target="_blank">
http://msdn.microsoft.com/en-us/library/777e5ebh.aspx.</a><br>
<br>
6. Clean up objects before exit. (System.Data.SqlClient.SqlConnection.Close)<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
ADO.NET Introduction<br>
<a href="http://msdn.microsoft.com/en-us/library/e80y5yhx.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/e80y5yhx.aspx</a><br>
<br>
Using DataSets in ADO.NET<br>
<a href="http://msdn.microsoft.com/en-us/library/ss7fbaez.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/ss7fbaez.aspx</a><br>
<br>
Storing and Retrieving Images from SQL Server using Visual C# .NET<br>
<a href="http://www.codeproject.com/KB/database/ImageSaveInDataBase.aspx" target="_blank">http://www.codeproject.com/KB/database/ImageSaveInDataBase.aspx</a><br>
<br>
Handling Null Values (ADO.NET)<br>
<a href="http://msdn.microsoft.com/en-us/library/ms172138.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/ms172138.aspx</a><br>
<br>
Best Practices for Using ADO.NET<br>
<a href="http://msdn.microsoft.com/en-us/library/ms971481.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/ms971481.aspx</a><br>
<br>
How to Call a Parameterized Stored Procedure by Using ADO.NET and Visual <br>
C#.NET<br>
<a href="http://support.microsoft.com/kb/310070/" target="_blank">http://support.microsoft.com/kb/310070/</a><br>
<br>
Typed DataSets (ADO.NET)<br>
<a href="http://msdn.microsoft.com/en-us/library/esbykkzb.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/esbykkzb.aspx</a><br>
<br>
Generating Strongly Typed DataSets (ADO.NET)<br>
<a href="&lt;a target=" target="_blank">http://msdn.microsoft.com/en-us/library/wha85tzb.aspx</a>'&gt;<a href="http://msdn.microsoft.com/en-us/library/wha85tzb.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/wha85tzb.aspx</a><br>
<br>
HOW TO: Create and Use a Typed DataSet by Using Visual C# .NET<br>
<a href="http://support.microsoft.com/kb/320714/en-us" target="_blank">http://support.microsoft.com/kb/320714/en-us</a><br>
<br>
Saving Data from Related Data Tables (Hierarchical Update)<br>
<a href="http://msdn.microsoft.com/en-us/library/bb384432.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/bb384432.aspx</a><br>
<br>
Saving Data to a Database (Multiple Tables)<br>
<a href="http://msdn.microsoft.com/en-us/library/4esb49b4.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/4esb49b4.aspx</a><br>
<br>
MSDN: DataSet<br>
<a href="http://msdn.microsoft.com/en-us/library/system.data.dataset.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/system.data.dataset.aspx</a><br>
<br>
MSDN: SqlDataAdapter<br>
<a href="http://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqldataadapter.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqldataadapter.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

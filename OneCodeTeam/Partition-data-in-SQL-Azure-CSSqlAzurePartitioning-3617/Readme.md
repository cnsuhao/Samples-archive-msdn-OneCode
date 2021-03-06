# Partition data in SQL Azure (CSSqlAzurePartitioning)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* SQL Azure
## Topics
* Partitioning
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:41:41
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<h2>Windows Azure APPLICATION: CSSqlAzurePartitioning Overview</h2>
<p style="font-family:Courier New"><br>
Summary: &nbsp;<br>
<br>
This sample demonstrates how to partition your data in SQL Azure. It shows two<br>
ways: one is vertical partitioning while the other is horizontal partitioning.<br>
<br>
In this version of vertically partitioning for SQL Azure we are dividing all the <br>
tables in the schema across two or more SQL Azure databases. In choosing which <br>
tables to group together on a single database you need to understand how large <br>
each of your tables are and their potential future growth �C the goal is to evenly
<br>
distribute the tables so that each database is the same size.<br>
<br>
When partitioning your workload across SQL Azure databases, you lose some of the <br>
features of having all the tables in a single database. Some of the considerations
<br>
when using this technique include:<br>
<br>
1. Foreign keys across databases are not support. In other words, a primary key in
<br>
&nbsp; a lookup table in one database cannot be referenced by a foreign key in a table
<br>
&nbsp; on another database. This is a similar restriction to SQL Server��s cross database
<br>
&nbsp; support for foreign keys.<br>
2. You cannot have transactions that span databases, even if you are using Microsoft
<br>
&nbsp; Distributed Transaction Manager on the client side. This means that you cannot
<br>
&nbsp; rollback an insert on one database, if an insert on another database fails. This
<br>
&nbsp; restriction can be negated through client side coding �C you need to catch exceptions
<br>
&nbsp; and execute &quot;undo&quot; scripts against the successfully completed statements.<br>
<br>
In this version of horizontal partitioning, every table exists in all the databases
<br>
in the partition set. We are using a hash base partitioning schema in this example
<br>
�C hashing on the primary key of the row. The middle layer determines which database
<br>
to write each row based on the primary key of the data being written. This allows
<br>
us to evenly divide the data across all the databases, regardless of individual <br>
table growth. The data access knows how to find the data based on the primary key,
<br>
and combines the results to return one result set to the caller.<br>
<br>
When horizontal partitioning your database you lose some of the features of <br>
having all the data in a single database. Some considerations when using this <br>
technique include:<br>
<br>
1. Foreign keys across databases are not supported. In other words, a primary <br>
&nbsp; key in a lookup table in one database cannot be referenced by a foreign <br>
&nbsp; key in a table on another database. This is a similar restriction to SQL <br>
&nbsp; Server��s cross database support for foreign keys.<br>
2. You cannot have transactions that span two databases, even if you are <br>
&nbsp; using Microsoft Distributed Transaction Manager on the client side. This <br>
&nbsp; means that you cannot rollback an insert on one database, if an insert on <br>
&nbsp; another database fails. This restriction can be mitigated through client <br>
&nbsp; side coding �C you need to catch exceptions and execute &quot;undo&quot; scripts <br>
&nbsp; against the successfully completed statements.<br>
3. All the primary keys need to be unique identifier. This allows us to <br>
&nbsp; guarantee the uniqueness of the primary key in the middle layer.<br>
4. The example code shown in this sample doesn��t allow you to dynamically <br>
&nbsp; change the number of databases that are in the partition set. The number <br>
&nbsp; of databases is hard coded in the SqlAzureHelper class in the <br>
&nbsp; ConnectionStringNames property.<br>
5. Importing data from SQL Server to a horizontally partitioned database <br>
&nbsp; requires that you move each row one at a time emulating the hashing of the
<br>
&nbsp; primary keys.<br>
<br>
</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
If you would like to test this sample project locally, you need to install<br>
<br>
Microsoft SQL Server 2008 R2 Express <br>
Microsoft SQL Server 2008 R2 Management Studio Express<br>
<br>
You can get them from:<br>
<a href="http://blogs.msdn.com/b/petersad/archive/2009/11/13/how-to-install-sql-server-2008-r2-express-edition-november-ctp.aspx" target="_blank">http://blogs.msdn.com/b/petersad/archive/2009/11/13/how-to-install-sql-server-2008-r2-express-edition-november-ctp.aspx</a><br>
<br>
<br>
Demo: &nbsp; &nbsp; &nbsp; &nbsp; <br>
<br>
Step 1. You can run this sample by logging into SQL Azure or local SQL Server.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;[NOTE: Since the SQL Azure only support the SQL Server Authentication
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mode, so if you run this sample against your local server you should
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;configure SQL Server to accept SQL Authentication mode.]<br>
<br>
Step 2. Create two databases(either on SQL Azure or local Server): &quot;Courses&quot; <br>
&nbsp; &nbsp; &nbsp; &nbsp;and &quot;Students&quot;, then execute the scripts in Course.sql and Student.sql
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;respectively. <br>
<br>
Step 3. Execute the scripts in StudentSQLQuery.sql on database &quot;Students&quot; and <br>
&nbsp; &nbsp; &nbsp; &nbsp;execute CourseSQLQuery.sql on database &quot;Courses&quot; to generate some
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;trivial data for testing purpose.<br>
<br>
Step 4. Create another two databases, and name them &quot;Database001&quot;, <br>
&nbsp; &nbsp; &nbsp; &nbsp;&quot;Database002&quot;.<br>
&nbsp;<br>
Step 5. Execute the scripts in Accounts.sql on both databases &quot;Database001&quot; <br>
&nbsp; &nbsp; &nbsp; &nbsp;and &quot;Database002&quot;. Then Database001 and Database002 will both have a
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;same schema table &quot;Accounts&quot;.<br>
<br>
Step 6. You have to modify the connectionString in Web.config to make them <br>
&nbsp; &nbsp; &nbsp; &nbsp;point to your SQL Azure server or local SQL server.<br>
<br>
Step 7. Build the solution and make sure the Default.aspx is the Startup Page, <br>
&nbsp; &nbsp; &nbsp; &nbsp;then run it.<br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
Step 1. Please refer to Demo section to create databases/tables.<br>
<br>
Step 2. Create a Windows Azure project and add an ASP.NET Web Role with the <br>
&nbsp; &nbsp; &nbsp; &nbsp;default name.<br>
<br>
Step 3. Add two WebForms, name them &quot;Vertical Partitioning.aspx&quot;, &quot;Horizontal <br>
&nbsp; &nbsp; &nbsp; &nbsp;Partitioning.aspx&quot;.<br>
<br>
Step 4. In Default.aspx, add two HyperLink controls and set the <br>
&nbsp; &nbsp; &nbsp; &nbsp;NavigateUrl=&quot;~/Vertical Partitioning.aspx&quot; and <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NavigateUrl=&quot;~/Horizontal Partitioning.aspx&quot; respectively.<br>
<br>
Step 5. In Vertical Partitioning.aspx, add three GridViews, use GridView <br>
&nbsp; &nbsp; &nbsp; &nbsp;Tasks Wizard to set data source for GridView1 and GridView2. &nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GridView1's DataSource should be Students.Student table. GridView2's
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataSource should be Courses.Course table. For more detail, you can
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;look into Vertical Partitioning.aspx.<br>
<br>
Step 6. In Vertical Partitioning.aspx.cs, set the data source for GridView3 <br>
&nbsp; &nbsp; &nbsp; &nbsp;as follows.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Code snippets]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Load data.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var studentDataReader = SQLAzureHelper.ExecuteReader(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ConfigurationManager.ConnectionStrings[&quot;StudentsConnectionString&quot;].ConnectionString,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;sqlConnection =&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SqlCommand sqlCommand =<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;new SqlCommand(&quot;SELECT StudentId, StudentName FROM Student&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;sqlConnection);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return (sqlCommand.ExecuteReader());<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;});<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var courseDataReader = SQLAzureHelper.ExecuteReader(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ConfigurationManager.ConnectionStrings[&quot;CoursesConnectionString&quot;].ConnectionString,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;sqlConnection =&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SqlCommand sqlCommand =<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;new SqlCommand(&quot;SELECT CourseName, StudentId FROM Course&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;sqlConnection);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return (sqlCommand.ExecuteReader());<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;});<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Join two tables on different SQL Azure databases using LINQ.
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var query =<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;from student in studentDataReader<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;join course in courseDataReader on<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;(Int32)student[&quot;StudentId&quot;] equals (Int32)course[&quot;StudentId&quot;]<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;select new<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CourseName = (string)course[&quot;CourseName&quot;],<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;StudentName = (string)student[&quot;StudentName&quot;]<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;};<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.GridView3.DataSource = query;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.GridView3.DataBind();<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/Code snippets]<br>
<br>
Step 7. In Horizontal Partioning.aspx. add two GridViews, use GridView Tasks <br>
&nbsp; &nbsp; &nbsp; &nbsp;Wizard to set data source for GridView1 and GridView2. &nbsp;GridView1's
<br>
&nbsp; &nbsp; &nbsp; &nbsp;DataSource should be Database001.Accounts table. GridView2's
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataSource should be Database002.Accounts table. For more detail, you
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;can look into Horizontal Partioning.aspx.<br>
<br>
<br>
References: &nbsp;<br>
<br>
Development Considerations in SQL Azure<br>
<a href="http://msdn.microsoft.com/en-us/library/ee730903.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/ee730903.aspx</a><br>
<br>
How to: Connect to SQL Azure Through ASP.NET<br>
<a href="http://msdn.microsoft.com/en-us/library/ee621781.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/ee621781.aspx</a><br>
<br>
Unique identifier and Clustered Indexes<br>
<a href="http://blogs.msdn.com/b/sqlazure/archive/2010/05/05/10007304.aspx" target="_blank">http://blogs.msdn.com/b/sqlazure/archive/2010/05/05/10007304.aspx</a><br>
<br>
Vertical Partitioning in SQL Azure: Part 1<br>
<a href="http://blogs.msdn.com/b/sqlazure/archive/2010/05/17/10014011.aspx" target="_blank">http://blogs.msdn.com/b/sqlazure/archive/2010/05/17/10014011.aspx</a><br>
<br>
SQL Azure Horizontal Partitioning: Part 2<br>
<a href="http://blogs.msdn.com/b/sqlazure/archive/2010/06/24/10029719.aspx" target="_blank">http://blogs.msdn.com/b/sqlazure/archive/2010/06/24/10029719.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

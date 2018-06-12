# Implement Search Engine in ASP.NET Web Site
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Search
## IsPublished
* True
## ModifiedDate
* 2013-06-05 02:10:26
## Description
==============================================================================<br>
ASP.NET APPLICATION : CSASPNETSearchEngine Project Overview<br>
==============================================================================<br>
<br>
//////////////////////////////////////////////////////////////////////////////<br>
Summary:<br>
<br>
This sample shows how to implement a simple search engine in an ASP.NET web site.<br>
<br>
//////////////////////////////////////////////////////////////////////////////<br>
Demo the Sample:<br>
<br>
Open Default.aspx page, input one or more keywords into the text box. <br>
Click the submit button.<br>
<br>
//////////////////////////////////////////////////////////////////////////////<br>
Code Logical:<br>
<br>
1. Create the database.<br>
&nbsp; a. Create a SQL Server database named &quot;MyDatabase.mdf&quot; within App_Data folder.<br>
&nbsp; b. Create a Table named &quot;Articles&quot; in the database.<br>
<br>
&nbsp; &nbsp; &nbsp;ID &nbsp; &nbsp; &nbsp; bigint (Primary Key)<br>
&nbsp; &nbsp; &nbsp;Title &nbsp; &nbsp;nvarchar(50)<br>
&nbsp; &nbsp; &nbsp;Content &nbsp;varchar(MAX)<br>
<br>
&nbsp; c. Input some sample records to the Table.<br>
<br>
2. Data Access.<br>
&nbsp; a. Create a class named &quot;Article&quot; represents a record.<br>
&nbsp; b. Create a class named &quot;DataAccess&quot; to access database. This class contains
<br>
&nbsp; &nbsp; &nbsp;public methods GetArticle(), GetAll() and Search(). Within Search() method,<br>
&nbsp; &nbsp; &nbsp;the key code is generating a complex Sql command which is used to search database.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Generate a complex Sql command.<br>
&nbsp; &nbsp; &nbsp; &nbsp;StringBuilder builder = new StringBuilder();<br>
&nbsp; &nbsp; &nbsp; &nbsp;builder.Append(&quot;select * from [Articles] where &quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp;foreach (string item in keywords)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;builder.AppendFormat(&quot;([Title] like '%{0}%' or [Content] like '%{0}%') and &quot;, item);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Remove unnecessary string &quot; and &quot; at the end of the command.<br>
&nbsp; &nbsp; &nbsp; &nbsp;string sql = builder.ToString(0, builder.Length - 5);<br>
3. Search Page.<br>
&nbsp; The key controls of this page is TextBox control named &quot;txtKeyWords&quot; which
<br>
&nbsp; is used to input keywords, and Repeater control which is used to display<br>
&nbsp; result.<br>
&nbsp; And there is a JavaScript function which is used to hightlight keywords<br>
&nbsp; in the result.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;for (var i = 0; i &lt; keywords.length; i&#43;&#43;)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var a = new RegExp(keywords[i], &quot;igm&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;container.innerHTML = container.innerHTML.replace(a, &quot;<span style="background:#FF0">$0</span>&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
4. The Detail Page.<br>
&nbsp; This page receives a parameter from Query String named &quot;id&quot;, and then call
<br>
&nbsp; DataAccess class to retrieve a individual record from database to show in the page.<br>
&nbsp; <br>
<br>
//////////////////////////////////////////////////////////////////////////////<br>
References:<br>
<br>
SQL Server and ADO.NET<br>
http://msdn.microsoft.com/en-us/library/kb9s9ks0.aspx<br>
<br>
Connecting to a Data Source (ADO.NET)<br>
http://msdn.microsoft.com/en-us/library/32c5dh3b.aspx<br>
<br>
LIKE (Transact-SQL)<br>
http://msdn.microsoft.com/en-us/library/ms179859.aspx<br>
<br>
Repeater Web Server Control Overview<br>
http://msdn.microsoft.com/en-us/library/x8f2zez5.aspx<br>
<br>
How to: Pass Values Between ASP.NET Web Pages<br>
http://msdn.microsoft.com/en-us/library/6c3yckfw.aspx<br>

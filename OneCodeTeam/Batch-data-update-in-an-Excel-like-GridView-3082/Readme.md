# Batch data update in an Excel-like GridView (CSASPNETExcelLikeGridView)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Controls
* GridView
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:00:14
## Description

<p style="font-family:Courier New"></p>
<h2>ASP.NET APPLICATION : CSASPNETExcelLikeGridView Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
&nbsp;The project illustrates how to do a batch insert,delete and update instead<br>
&nbsp;of inserting,delting,updating row by row.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
1) Open the project and right click the &quot;Default.aspx&quot;, choose &quot;View In Browser&quot;;<br>
2) When you check a checkbox inside a GridView to mark the row to be deleted,<br>
&nbsp;the Cell will change to red.<br>
3) When you add a new row by clicking the Add button, the new row is green<br>
&nbsp;by default.<br>
4) When you change a value from a cell inside the GridView, the background<br>
&nbsp;of the cell will turn blue.<br>
5) When you click the Save button, all the changes (including modified,<br>
&nbsp;deleted as well as added data) will be batch executed.<br>
<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step1. Create a Web Application by referring “New”--&gt;“Project…”--&gt;“Visual C#”--&gt;“ASPNET Web Application”,
<br>
name it as “CSASPNETExcelLikeGridView”.<br>
<br>
Step2. Right click your project tag, choose “Add…”--&gt;“New Item…”. <br>
Expand the “Visual Studio C#” tag and select “Sql Server Database”. Name it as “db_Persons.mdf”.<br>
Then right click the newly-created database in the “App_Data” folder, choose “Open”. In the left
<br>
“Server Explorer” panel please expand the tag “db_Persons.mdf”, and right click the folder called “Tables”,
<br>
choose “Add New Table” to create a table as what you can in the App_Data folder's structure and save it as<br>
&quot;tb_personInfo&quot;.<br>
<br>
<br>
[ NOTE: You can download the free Web Developer from:<br>
<a target="_blank" href="http://www.microsoft.com/express/Web/">http://www.microsoft.com/express/Web/</a> ]<br>
<br>
[ NOTE: You can also download the free SQL 2008 from:<br>
<a target="_blank" href="http://www.microsoft.com/express/Database/">http://www.microsoft.com/express/Database/</a> &nbsp;]<br>
<br>
Step3. Delete the following default folders and files created automatically <br>
by Visual Studio.<br>
<br>
Account folder<br>
Script folder<br>
Style folder<br>
About.aspx file<br>
Default.aspx file<br>
Global.asax file<br>
Site.Master file<br>
<br>
Step4. Add a connection string in web.config file:<br>
&lt;connectionStrings&gt;<br>
&nbsp; &nbsp;&lt;add name=&quot;MyConn&quot; <br>
&nbsp;&nbsp;&nbsp;&nbsp;connectionString=&quot;Data Source=.\SQLEXPRESS;AttachDbFileName=|DataDirectory|db_Persons.mdf;Integrated Security=True;User Instance=True&quot;/&gt;<br>
&lt;/connectionStrings&gt;<br>
<br>
Step5. Right click the mouse button to create a class named &quot;DBProcess.cs&quot;.
<br>
Create a class like what you can see in the file to process with DB <br>
(For more functions please see the detail comments).<br>
<br>
Step6. Drag and drop a GridView, add some template fields, some checkboxes as well<br>
as an &quot;Add&quot; button, a &quot;Save&quot; button and set all properties as what I've mentioned<br>
in the aspx markups.<br>
<br>
Step7. In order to implement non-refresh modification symbol (cell backcolors).<br>
We should write some JQuery functions. You can find them in the same Default.aspx<br>
HTML markups with detail comments.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
ASP.NET QuickStart Torturial:<br>
<br>
1）<a target="_blank" href="http://www.asp.net/data-access/tutorials/batch-deleting-cs">http://www.asp.net/data-access/tutorials/batch-deleting-cs</a><br>
<br>
2）<a target="_blank" href="http://www.asp.net/data-access/tutorials/batch-updating-vb">http://www.asp.net/data-access/tutorials/batch-updating-vb</a><br>
<br>
3）<a target="_blank" href="http://www.asp.net/data-access/tutorials/batch-inserting-vb">http://www.asp.net/data-access/tutorials/batch-inserting-vb</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

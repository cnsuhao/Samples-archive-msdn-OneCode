# Create RSS feed in ASP.NET (VBASPNETRssFeeds)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* RSS
## IsPublished
* True
## ModifiedDate
* 2011-05-05 07:35:38
## Description

<p style="font-family:Courier New"></p>
<h2>VBASPNETRssFeeds Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Note Before Start:</h3>
<p style="font-family:Courier New"><br>
&nbsp;When you go on through this sample, we assume that you are familiar with <br>
&nbsp;Rss, including its usage, &nbsp;format, and so forth. If not, please refer to this link<br>
&nbsp;first. It tells what is rss, the format of a standard rss file.<br>
<br>
&nbsp;<a target="_blank" href="&lt;a target=" href="http://www.mnot.net/rss/tutorial/">http://www.mnot.net/rss/tutorial/</a>'&gt;<a target="_blank" href="http://www.mnot.net/rss/tutorial/">http://www.mnot.net/rss/tutorial/</a><br>
</p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
&nbsp;The project shows how to create a rss feed using ASP.NET. The AddArticle<br>
&nbsp;page in the sample is used to update the database. We can add, edit, update<br>
&nbsp;and delete a record, an article it is in this sample, and then turn to Rss page
<br>
&nbsp;to find the change. Using classes within XML namespace, Rss page create a<br>
&nbsp;rss feed that can be subscribed by users so that users can be noticed as soon<br>
&nbsp;as there is any change happened in the website. &nbsp;<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step1: Create a Visual Basic ASP.NET Web Application in Visual Studio 2008 /<br>
Visual Web Developer and name it as VBASPNETRssFeeds.<br>
<br>
Step2: Add a database file into the application folder App_Data. In this sample,<br>
the database is the same name as the project name.<br>
<br>
Step3: Create a table named Article in the database and add these columns into<br>
the table: ArticleID, Title, Author, Link, Description, PubDate.<br>
<br>
Step4: Insert a new record into this table as a test. We will use this test record
<br>
later.<br>
<br>
Step5: Add a new ASP.NET page called AddArticle.aspx to the project, which is<br>
used to update the database table.<br>
<br>
Step6: Add a DataSource and a FormView control into this page. In short, set <br>
the DataSource connect to the Article table and bind this DataSource to the <br>
FormView. Enable the paging of the FormView and run the page to find that the <br>
datatable is totally under the control, which means records can be inserted, <br>
edited, updated and deleted from the FormView.<br>
<br>
Step7: &nbsp;Add a new ASP.NET page called Rss.aspx to the project. This is the star<br>
of this project.<br>
<br>
Step8: Write a function to get the data from the Article table in the codebehind of
<br>
the rss page. It could be look like this.<br>
<br>
&nbsp; &nbsp;Private Function GetDateSet() As DataTable<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim ArticlesRssTable As New DataTable()<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim strconn As String = ConfigurationManager.ConnectionStrings(&quot;ConnStr4Articles&quot;).ConnectionString<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim conn As New SqlConnection(strconn)<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim strsqlquery As String = &quot;SELECT * FROM [Articles]&quot;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Dim da As New SqlDataAdapter(strsqlquery, conn)<br>
&nbsp; &nbsp; &nbsp; &nbsp;da.Fill(ArticlesRssTable)<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;Return ArticlesRssTable<br>
&nbsp; &nbsp;End Function<br>
<br>
[NOTE] This function returns a DataTable containing the records selected from <br>
the Article table via the SQL query string above. As a test, it returns all records<br>
from the table. However, usually we only selecte 20 records of the latest article<br>
from the table so that the process will not be too long and the rss page will not<br>
be too big. Anyway, it depends on the requirement of the rss feed.<br>
<br>
Step9: Write code to create the rss xml file. As it is only the code work, please
<br>
refer to ths Rss.aspx.vb file in this sample.<br>
<br>
[NOTE] Because a rss feed is an XML format file instead of a normal web<br>
page, we need to modify the Response.ContentType property. Also, unicode<br>
might be contained in the rss feed, we need to change the ContentEncoding <br>
property of current response as well.<br>
<br>
&nbsp; &nbsp;Response.ContentType = &quot;application/rss&#43;xml&quot;<br>
&nbsp; &nbsp;Response.ContentEncoding = Encoding.UTF8<br>
<br>
As the rss feed content contains three parts: the opening, the body and the <br>
ending. We separate them into three methods: WriteRssOpening, WriteRssBody<br>
and WriteRssEnding. When writing the body, we use For Each to loop through<br>
the records in the DataTable and write them in an item node and write the title,<br>
author, link, description and pubDate fileds as the attributes under the item node.<br>
<br>
&nbsp; &nbsp;For Each rssitem As DataRow In data.Rows<br>
&nbsp; &nbsp; &nbsp; &nbsp;rsswriter.WriteStartElement(&quot;item&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp;rsswriter.WriteElementString(&quot;title&quot;, rssitem(1).ToString())<br>
&nbsp; &nbsp; &nbsp; &nbsp;rsswriter.WriteElementString(&quot;author&quot;, rssitem(2).ToString())<br>
&nbsp; &nbsp; &nbsp; &nbsp;rsswriter.WriteElementString(&quot;link&quot;, rssitem(3).ToString())<br>
&nbsp; &nbsp; &nbsp; &nbsp;rsswriter.WriteElementString(&quot;description&quot;, rssitem(4).ToString())<br>
&nbsp; &nbsp; &nbsp; &nbsp;rsswriter.WriteElementString(&quot;pubDate&quot;, rssitem(5).ToString())<br>
&nbsp; &nbsp; &nbsp; &nbsp;rsswriter.WriteEndElement()<br>
&nbsp; &nbsp;Next<br>
<br>
Finally, when all work has been doen, we need to end the response. Otherwise,<br>
some error will occur to destory all things we did before and only return an error
<br>
message &quot;Internet Explorer cannot display this feed&quot; on the page. So, do NOT<br>
forget to add the code at the end of Page_Load event handler.<br>
<br>
&nbsp; &nbsp;Response.End()<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: XmlTextWriter Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.xml.xmltextwriter.aspx">http://msdn.microsoft.com/en-us/library/system.xml.xmltextwriter.aspx</a><br>
<br>
MSDN: RSS Tutorial<br>
<a target="_blank" href="&lt;a target=" href="http://www.mnot.net/rss/tutorial/">http://www.mnot.net/rss/tutorial/</a>'&gt;<a target="_blank" href="http://www.mnot.net/rss/tutorial/">http://www.mnot.net/rss/tutorial/</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

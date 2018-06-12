# General Multiple Filter User Control (VBASPNETMultiFiltering)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* User Control
## IsPublished
* True
## ModifiedDate
* 2012-07-22 07:48:02
## Description
<a name="OLE_LINK2"><span style="">(</span></a>
<p class="MsoNormal">The&nbsp;project&nbsp;<span style="">gives you a general and useful multiple-filtering control and
</span>shows&nbsp;how&nbsp;to&nbsp;use&nbsp;this&nbsp;general&nbsp;multiple&nbsp;filtering&nbsp;control&nbsp;to&nbsp;filter<span style="">
</span>records&nbsp;with&nbsp;the&nbsp;help&nbsp;of&nbsp;<span class="SpellE">SqlDataSource</span>.
</p>
<p class="MsoNormal"><a name="OLE_LINK5"></a><a name="OLE_LINK6"><span style="">To run this code sample, you must install the SQL Server 2008 R2 Express</span></a><span style=""><span style=""><span style=""> and you can generate the test database file
 through <span class="SpellE">SQLQuery.sql</span> under the <span class="SpellE">
App_Data</span> folder</span>, since the sample contains a SQL Server database file.
</span></span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://www.microsoft.com/download/en/details.aspx?id=16978">SQL Server 2008 R2 details</a>
</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://www.microsoft.com/download/en/details.aspx?displaylang=en&id=3743">Download SQL Server 2008 R2 Express</a>
</p>
<p class="MsoNormal">Please follow these demonstration steps below. </p>
<p class="MsoNormal">Step 1:&nbsp;Open the VBASPNETMultiFiltering.sln. <span style="">
Right click the </span>&quot;<span style="">Default.aspx&quot; to run it.</span></p>
<p class="MsoNormal">Step 2: You will see a <span class="SpellE">GirdView</span> on the page,
<span style="">with a multi-filtering panel on the top. The default setting will show all the contents.
</span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;</span> <img src="/site/view/file/62047/1/image.png" alt="" width="1007" height="374" align="middle">
</span></p>
<p class="MsoNormal">Step 3: <span style="">Uncheck the &quot;All Records&quot; and choose the specific column from the &quot;FieldName&quot; column, choose an operator from &quot;Condition&quot; and input value, you can get the results by clicking &quot;Search&quot;.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/62048/1/image.png" alt="" width="1057" height="169" align="middle">
</span></p>
<p class="MsoNormal">Step 4: <span style="">If you want to add multiple filtering conditons, just click &quot;AddFilter&quot; to add a new one or click &quot;Remove&quot; to remove an existing filtering condition:
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/62049/1/image.png" alt="" width="1062" height="392" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal">Code Logical: </p>
<p class="MsoNormal">Step 1. Create a <span style="">VB</span> &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or Visual Web Developer 2010. Name it as &quot; VBASPNETMultiFiltering &quot;.
<span style=""></span></p>
<p class="MsoNormal"><span class="GramE">Step 2.</span> Before we start to write code, we need install SQL Server 2008 R2 Express and create a database file as the data source of
<span class="SpellE">GridView</span> control. Add an ASP.NET folder &quot;<span class="SpellE">App_Data</span>&quot; and create a SQL Server Database,&quot;<span class="SpellE">db_test.mdf</span>&quot;. You can refer to
<span class="SpellE">SQLQuery.sql</span> file for the definition of the database.<span style="">
</span></p>
<p class="MsoNormal"><span class="GramE">Step 3.</span> Drag and drop a <span class="SpellE">
GridView</span> control<span style=""> into the page</span>, <span style="">and set the data source as follows.
</span></p>
<p class="MsoNormal"></p>
<p class="MsoNormal">Step 4. <span style="">Right click the project and create a Web User Control<span style="">&nbsp;
</span>and name it as &quot;MultiFiltering.ascx&quot;, and then put a Repeater, with two buttons called &quot;Search&quot; and &quot;Add Filter&quot; , as well as a CheckBox inside it. Here's what it looks like:
</span></p>
<p class="MsoNormal"></p>
<p class="MsoNormal">Step 5. <span style="">Handle the events of &quot;Add Filter&quot;, &quot;Search&quot; as well as Repeater's
<span class="SpellE">DataBinding</span> event to <a name="OLE_LINK9"></a><a name="OLE_LINK10"><span style="">deal with
</span></a>adding filtering conditions, removing certain condition and doing filter.
</span></p>
<a name="OLE_LINK3"></a>
<p class="MsoNormal"><span style=""><span style=""><span style=""></span></span></span></p>
<p class="MsoNormal">Step 6. <span style="">Define another partial class to create a structure called &quot;Structure&quot;. This structure is used to store each filtering condition as a record.
</span></p>
<p class="MsoNormal"></p>
<p class="MsoNormal">Step 7. <span style="">In the end, drag and drop the &quot;MultiFiltering.ascx&quot; user control onto the top of the default.aspx and you can run it to see the result.
</span></p>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-au/library/system.web.ui.webcontrols.sqldatasource.filterexpression(v=VS.80).aspx">http://msdn.microsoft.com/en-au/library/system.web.ui.webcontrols.sqldatasource.filterexpression(v=VS.80).aspx</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

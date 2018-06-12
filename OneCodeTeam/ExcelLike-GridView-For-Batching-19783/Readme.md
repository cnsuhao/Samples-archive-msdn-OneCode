# ExcelLike GridView For Batching (VBASPNETExcelLikeGridView)
## Requires
* Visual Studio 2012
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* Controls
* GridView
## IsPublished
* True
## ModifiedDate
* 2012-12-03 08:01:44
## Description

<h1>ExcelLike GridView <span class="GramE">For</span> Batching (<span class="SpellE">VBASPNETExcelLikeGridView</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The project illustrates how to do a batch insert,delete and update instead of inserting,delting,updating row by row.<span style="">
</span></p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.25in"><span style=""><span style="">Step 1:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Open the VBASPNETExcelLikeGridView.sln.<span style=""> </span>
</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><span style="">Step 2:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Expand the <span class="SpellE">VBASPNETExcelLikeGridView</span> web application and press Ctrl &#43; F5 to show the Default.aspx.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><span style="">Step 3:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">When you check a checkbox inside a GridView to mark the row to be deleted, the Cell will change to red.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><span style="">Step 4:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">When you add a new row by clicking the Add button, the new row is green by default.</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><span style="">Step 5:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">When you change a value from a cell inside the GridView, the background of the cell will turn blue.<br>
</span><span style=""><img src="/site/view/file/71727/1/image.png" alt="" width="818" height="373" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><span style="">Step 6:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>When you click the Save button, all the changes (including modified, deleted as well as added data) will be batch executed.</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.25in"><span style=""><span style="">Step 7:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Validation finished.</p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.25in"><span style=""><span style="">Step 1:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Create a VB &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2012 or Visual Web Developer 2012. Name it as &quot;<span class="SpellE">VBASPNETExcelLikeGridView</span>&quot;.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><span style="">Step 2:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">&nbsp;</span>Right click your project tag, choose &quot;Add…&quot;--&gt;&quot;New Item…&quot;. Expand the &quot;Visual Basic&quot; tag and select &quot;Sql Server Database&quot;. Name it as &quot;db_Persons.mdf&quot;. Then right
 click the newly-created database in the &quot;App_Data&quot; folder, choose &quot;Open&quot;. In the left &quot;Server Explorer&quot; panel please expand the tag &quot;db_Persons.mdf&quot;, and right click the folder called &quot;Tables&quot;, choose &quot;Add
 New Table&quot; to create a table as what you can in the App_Data folder's structure and save it as &quot;tb_personInfo&quot;.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><span style="">Step 3:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">Delete the following default folders and files created automatically by Visual Studio.<br>
</span>Account folder<br>
Script folder<br>
Style folder<br>
About.aspx file<br>
Default.aspx file<br>
Global.asax file<br>
Site.Master file</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.25in"><span style=""><span style="">Step 4:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Add a connection string in web.config file:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;connectionStrings&gt;
&nbsp;&nbsp;&nbsp; &lt;add name=&quot;MyConn&quot; connectionString=&quot;Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\db_Persons.mdf;Integrated Security=True&quot; /&gt;
&nbsp; &lt;/connectionStrings&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;connectionStrings&gt;
&nbsp;&nbsp;&nbsp; &lt;add name=&quot;MyConn&quot; connectionString=&quot;Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\db_Persons.mdf;Integrated Security=True&quot; /&gt;
&nbsp; &lt;/connectionStrings&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.25in"><span style=""><span style="">Step 5:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Right click the mouse button to create a class named &quot;DBProcess.cs&quot;. Create a class like what you can see in the file to process with DB (For more functions please see the detail comments).</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><span style="">Step 6:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Drag and drop a GridView, add some template fields, some checkboxes as well as an &quot;Add&quot; button, a &quot;Save&quot; button and set all properties as what I've mentioned in the aspx markups.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><span style="">Step 7:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>In order to implement non-refresh modification symbol (cell backcolors).We should write some JQuery functions. You can find them in the same Default.aspx HTML markups with detail comments.</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.25in"><span style=""><span style="">Step 8:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Build the application and you can debug it<span style="">.</span></p>
<h2>More Information</h2>
<p class="MsoNormal">ASP.NET QuickStart Tutorial:</p>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.25in"><span style=""><span style="">1)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://www.asp.net/data-access/tutorials/batch-deleting-cs">http://www.asp.net/data-access/tutorials/batch-deleting-cs</a><span style="">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><span style="">2)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://www.asp.net/data-access/tutorials/batch-updating-vb">http://www.asp.net/data-access/tutorials/batch-updating-vb</a><span style="">
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.25in"><span style=""><span style="">3)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://www.asp.net/data-access/tutorials/batch-inserting-vb">http://www.asp.net/data-access/tutorials/batch-inserting-vb</a><span style="">
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

# How to make a Multiple-Head GridView
## Requires
* Visual Studio 2012
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* GridView
* Multiple-Head
## IsPublished
* True
## ModifiedDate
* 2013-01-22 07:31:44
## Description

<h1>How to make a Multiple-Head GridView (VBASPNETMultiHeadGridView)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample will demo you how to make a Multiple-Header GridView. The default GridView only lets us do with a Single-headed Table, compared with this, sometimes it would be better to make a Multiple-Headed GridView to show sub items or
 something else.<span style=""> </span></p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.25in"><span style=""><span style="">Step 1:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Open the VBASPNETMultiHeadGridView.sln.<span style=""> </span>
</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><span style="">Step 2:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Expand the VBASPNETMultiHeadGridView web application and press Ctrl &#43; F5 to show the Default.aspx.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><img src="/site/view/file/75053/1/image.png" alt="" width="249" height="319" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.25in"><span style=""><span style="">Step 3:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Validation finished.</p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.25in"><span style=""><span style="">Step 1:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Create a <span style="">VB</span> &quot;ASP.NET Empty Web Application&quot; in Visual Studio 201<span style="">2</span> or Visual Web Developer 201<span style="">2</span>. Name it as &quot;VBASPNETMultiHeadGridView&quot;.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><span style="">Step 2:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Delete the following default folders and files created automatically by Visual Studio.<br>
<span style="">&nbsp;&nbsp;&nbsp; </span>Account folder<br>
<span style="">&nbsp;&nbsp;&nbsp; </span>Script folder<br>
<span style="">&nbsp;&nbsp;&nbsp; </span>Style folder<br>
<span style="">&nbsp;&nbsp;&nbsp; </span>About.aspx file<br>
<span style="">&nbsp;&nbsp;&nbsp; </span>Default.aspx file<br>
<span style="">&nbsp;&nbsp;&nbsp; </span>Global.asax file<br>
<span style="">&nbsp;&nbsp;&nbsp; </span>Site.Master file</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.25in"><span style=""><span style="">Step 3:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Add App_Data folder to project and add a &quot;SQL Server Database&quot; item to the folder. Name it as &quot;sample&quot;. Add a table to the Database and name it as &quot;PersonData&quot;. The definition of the table &quot;PersonData&quot;
 as show below:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">mysql</span>
<pre class="hidden">
CREATE TABLE [dbo].[PersonData](
&nbsp;&nbsp;&nbsp; [Id] [int] IDENTITY(1,1) NOT NULL,
&nbsp;&nbsp;&nbsp; [Name] [nvarchar](50) NULL,
&nbsp;&nbsp;&nbsp; [Age] [int] NULL,
&nbsp;&nbsp;&nbsp; [Sex] [nchar](6)NULL
)

</pre>
<pre id="codePreview" class="mysql">
CREATE TABLE [dbo].[PersonData](
&nbsp;&nbsp;&nbsp; [Id] [int] IDENTITY(1,1) NOT NULL,
&nbsp;&nbsp;&nbsp; [Name] [nvarchar](50) NULL,
&nbsp;&nbsp;&nbsp; [Age] [int] NULL,
&nbsp;&nbsp;&nbsp; [Sex] [nchar](6)NULL
)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>The test Data as shown below:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">mysql</span>
<pre class="hidden">
SET IDENTITY_INSERT [dbo].[PersonData] ON
INSERT [dbo].[PersonData] ([Id], [Name], [Age], [Sex]) VALUES (1, N'test1', 21, N'male&nbsp; ')
INSERT [dbo].[PersonData] ([Id], [Name], [Age], [Sex]) VALUES (2, N'test2', 23, N'female')
INSERT [dbo].[PersonData] ([Id], [Name], [Age], [Sex]) VALUES (3, N'test3', 21, N'male&nbsp; ')
INSERT [dbo].[PersonData] ([Id], [Name], [Age], [Sex]) VALUES (4, N'test4', 23, N'male&nbsp; ')
INSERT [dbo].[PersonData] ([Id], [Name], [Age], [Sex]) VALUES (5, N'test5', 25, N'female')
INSERT [dbo].[PersonData] ([Id], [Name], [Age], [Sex]) VALUES (6, N'test6', 28, N'male&nbsp; ')
INSERT [dbo].[PersonData] ([Id], [Name], [Age], [Sex]) VALUES (7, N'test7', 21, N'female')
INSERT [dbo].[PersonData] ([Id], [Name], [Age], [Sex]) VALUES (8, N'test8', 26, N'male&nbsp; ')
INSERT [dbo].[PersonData] ([Id], [Name], [Age], [Sex]) VALUES (9, N'test9', 21, N'female')
INSERT [dbo].[PersonData] ([Id], [Name], [Age], [Sex]) VALUES (10, N'test10', 21, N'female')
INSERT [dbo].[PersonData] ([Id], [Name], [Age], [Sex]) VALUES (11, N'test11', 21, N'female')
SET IDENTITY_INSERT [dbo].[PersonData] OFF

</pre>
<pre id="codePreview" class="mysql">
SET IDENTITY_INSERT [dbo].[PersonData] ON
INSERT [dbo].[PersonData] ([Id], [Name], [Age], [Sex]) VALUES (1, N'test1', 21, N'male&nbsp; ')
INSERT [dbo].[PersonData] ([Id], [Name], [Age], [Sex]) VALUES (2, N'test2', 23, N'female')
INSERT [dbo].[PersonData] ([Id], [Name], [Age], [Sex]) VALUES (3, N'test3', 21, N'male&nbsp; ')
INSERT [dbo].[PersonData] ([Id], [Name], [Age], [Sex]) VALUES (4, N'test4', 23, N'male&nbsp; ')
INSERT [dbo].[PersonData] ([Id], [Name], [Age], [Sex]) VALUES (5, N'test5', 25, N'female')
INSERT [dbo].[PersonData] ([Id], [Name], [Age], [Sex]) VALUES (6, N'test6', 28, N'male&nbsp; ')
INSERT [dbo].[PersonData] ([Id], [Name], [Age], [Sex]) VALUES (7, N'test7', 21, N'female')
INSERT [dbo].[PersonData] ([Id], [Name], [Age], [Sex]) VALUES (8, N'test8', 26, N'male&nbsp; ')
INSERT [dbo].[PersonData] ([Id], [Name], [Age], [Sex]) VALUES (9, N'test9', 21, N'female')
INSERT [dbo].[PersonData] ([Id], [Name], [Age], [Sex]) VALUES (10, N'test10', 21, N'female')
INSERT [dbo].[PersonData] ([Id], [Name], [Age], [Sex]) VALUES (11, N'test11', 21, N'female')
SET IDENTITY_INSERT [dbo].[PersonData] OFF

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.25in"><span style=""><span style="">Step 4:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Add a web forms in the root directory, name it as &quot;Default.aspx&quot;.</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.25in"><span style=""><span style="">Step 5:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">Add a GridView Control and a SqlDataSource Control to the Default page, the SqlDataSource will be bound to the GridView.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;asp:GridView ID=&quot;gdvData&quot; runat=&quot;server&quot; AllowPaging=&quot;True&quot; AllowSorting=&quot;True&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AutoGenerateColumns=&quot;True&quot; OnRowCreated=&quot;gdvData_RowCreated&quot; DataKeyNames=&quot;Id&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DataSourceID=&quot;SqlDataSource1&quot;&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:GridView&gt;
&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:SqlDataSource ID=&quot;SqlDataSource1&quot; runat=&quot;server&quot; ConnectionString=&quot;&lt;%$ ConnectionStrings:ConnectionString %&gt;&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SelectCommand=&quot;SELECT [Id], [Name], [Age], [Sex] FROM [PersonData]&quot;&gt;&lt;/asp:SqlDataSource&gt;

</pre>
<pre id="codePreview" class="html">
&lt;asp:GridView ID=&quot;gdvData&quot; runat=&quot;server&quot; AllowPaging=&quot;True&quot; AllowSorting=&quot;True&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AutoGenerateColumns=&quot;True&quot; OnRowCreated=&quot;gdvData_RowCreated&quot; DataKeyNames=&quot;Id&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DataSourceID=&quot;SqlDataSource1&quot;&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:GridView&gt;
&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:SqlDataSource ID=&quot;SqlDataSource1&quot; runat=&quot;server&quot; ConnectionString=&quot;&lt;%$ ConnectionStrings:ConnectionString %&gt;&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SelectCommand=&quot;SELECT [Id], [Name], [Age], [Sex] FROM [PersonData]&quot;&gt;&lt;/asp:SqlDataSource&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:.25in"><span style=""><span style="">Step 6:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">We will handle the GridView's RowCreated event to create Multiple-Header.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub gdvData_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gdvData.RowCreated


...
End Sub

</pre>
<pre id="codePreview" class="vb">
Private Sub gdvData_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gdvData.RowCreated


...
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:.25in">First<span style="">ly, judge</span> whether the Row is RowHeader.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
If e.Row.RowType = DataControlRowType.Header Then
...
End If

</pre>
<pre id="codePreview" class="vb">
If e.Row.RowType = DataControlRowType.Header Then
...
End If

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:.25in">Then <span style="">c</span>reate some TableCell's instance.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' TableCell for Header 1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim headerCell1 As TableCell = New TableCell()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim headerCell2 As TableCell = New TableCell()


&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' The TableCell's definition
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell1.ColumnSpan = 3
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell1.Text = &quot;Main Header 1&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell1.BackColor = Drawing.Color.LightGray
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell1.HorizontalAlign = HorizontalAlign.Center


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;' The TableCell's definition
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell2.ColumnSpan = 2
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell2.Text = &quot;Main Header 2&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell2.BackColor = Drawing.Color.LightGray
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell2.HorizontalAlign = HorizontalAlign.Center

</pre>
<pre id="codePreview" class="vb">
' TableCell for Header 1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim headerCell1 As TableCell = New TableCell()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim headerCell2 As TableCell = New TableCell()


&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' The TableCell's definition
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell1.ColumnSpan = 3
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell1.Text = &quot;Main Header 1&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell1.BackColor = Drawing.Color.LightGray
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell1.HorizontalAlign = HorizontalAlign.Center


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;' The TableCell's definition
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell2.ColumnSpan = 2
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell2.Text = &quot;Main Header 2&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell2.BackColor = Drawing.Color.LightGray
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell2.HorizontalAlign = HorizontalAlign.Center

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:.25in">And then add the TableCell's instance to the Header Row.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Add TableCell to TableRow.Cells and then add tableRow to GridView(gdvData)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim rowHeader1 As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rowHeader1.Cells.Add(headerCell1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rowHeader1.Cells.Add(headerCell2)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rowHeader1.ForeColor = Drawing.Color.Black
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rowHeader1.Font.Bold = True
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rowHeader1.Visible = True

</pre>
<pre id="codePreview" class="vb">
' Add TableCell to TableRow.Cells and then add tableRow to GridView(gdvData)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim rowHeader1 As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rowHeader1.Cells.Add(headerCell1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rowHeader1.Cells.Add(headerCell2)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rowHeader1.ForeColor = Drawing.Color.Black
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rowHeader1.Font.Bold = True
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rowHeader1.Visible = True

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:.25in">Finally, add the Header Row to the GridView's ControlCollection.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
gdvData.Controls(0).Controls.AddAt(0, rowHeader1)

</pre>
<pre id="codePreview" class="vb">
gdvData.Controls(0).Controls.AddAt(0, rowHeader1)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Repeat above operate to add more header.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' TableCell for Header 2
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim fields2 As TableCellCollection = e.Row.Cells
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim headerCell11 As TableCell = New TableCell()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim headerCell12 As TableCell = New TableCell()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell11.ColumnSpan = 2
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell11.Text = &quot;ID and Name&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell11.BackColor = Drawing.Color.Maroon


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell12.ColumnSpan = 3
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell12.Text = &quot;Age and Sex&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell12.BackColor = Drawing.Color.Maroon


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Add TableCell to TableRow.Cells and then add tableRow to GridView(gdvData)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim rowHeader2 As GridViewRow = New GridViewRow(1, 1, DataControlRowType.Header, DataControlRowState.Normal)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rowHeader2.Cells.Add(headerCell11)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rowHeader2.Cells.Add(headerCell12)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rowHeader2.Font.Size = 12
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rowHeader2.ForeColor = Drawing.Color.White
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rowHeader2.HorizontalAlign = HorizontalAlign.Center
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rowHeader2.Visible = True
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rowHeader2.Font.Bold = True
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; gdvData.Controls(0).Controls.AddAt(1, rowHeader2)

</pre>
<pre id="codePreview" class="vb">
' TableCell for Header 2
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim fields2 As TableCellCollection = e.Row.Cells
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim headerCell11 As TableCell = New TableCell()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim headerCell12 As TableCell = New TableCell()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell11.ColumnSpan = 2
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell11.Text = &quot;ID and Name&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell11.BackColor = Drawing.Color.Maroon


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell12.ColumnSpan = 3
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell12.Text = &quot;Age and Sex&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; headerCell12.BackColor = Drawing.Color.Maroon


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Add TableCell to TableRow.Cells and then add tableRow to GridView(gdvData)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim rowHeader2 As GridViewRow = New GridViewRow(1, 1, DataControlRowType.Header, DataControlRowState.Normal)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rowHeader2.Cells.Add(headerCell11)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rowHeader2.Cells.Add(headerCell12)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rowHeader2.Font.Size = 12
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rowHeader2.ForeColor = Drawing.Color.White
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rowHeader2.HorizontalAlign = HorizontalAlign.Center
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rowHeader2.Visible = True
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rowHeader2.Font.Bold = True
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; gdvData.Controls(0).Controls.AddAt(1, rowHeader2)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:.25in"><span style=""><span style="">Step 7:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Build the application and you can debug it<span style="">.</span></p>
<h2>More Information</h2>
<p class="MsoNormal">GridViewRow Class <br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.gridviewrow.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.gridviewrow.aspx</a><br>
<span style="">TableRow.Cells Property <br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.tablerow.cells.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.tablerow.cells.aspx</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

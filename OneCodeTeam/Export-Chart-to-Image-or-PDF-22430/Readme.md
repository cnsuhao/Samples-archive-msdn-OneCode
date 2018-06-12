# Export Chart to Image or PDF
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Image
* export
* MS Chart
* PDF file
## IsPublished
* False
## ModifiedDate
* 2013-06-05 12:23:59
## Description

<h1>How to Export MS Chart to an Image or a PDF file (VBASPNETChartExport)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to export Chart to an Image or a PDF file.<span style="">&nbsp;
</span>There are two pages in this sample: A page directly save the chart as Image, another by using a TOTALLY FREE (No-license) PDF convertor named iTextSharp directly save chart a pdf.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">You can download the iTextSharp from here: <a href="http://sourceforge.net/projects/itextsharp/">
http://sourceforge.net/projects/itextsharp/</a>.</p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">Step 1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Open the VBASPNETChartExport.sln.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">Step 2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Right click SaveToImage.aspx and choose &quot;View in Browser&quot;. The Browser looks as follows:</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/83524/1/image.png" alt="" width="576" height="389" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle">Click the &quot;Save to Image&quot; button. A pop-up box will be prompted to the save path of the image.</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/83525/1/image.png" alt="" width="483" height="176" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle">If you navigate to the path of prompt, you can see an image resembles the following.</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/83526/1/image.png" alt="" width="142" height="39" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">Step 3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Right click SaveToPdf.aspx and choose &quot;View in Browser&quot;. The Browser looks as follows:</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/83527/1/image.png" alt="" width="576" height="394" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle">Click the &quot;Save to Pdf&quot; button. You can choose to save or open in pdf.</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/83528/1/image.png" alt="" width="576" height="29" align="middle">
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">Step 4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>The validation is complete.</p>
<p class="MsoNormal"></p>
<h2>Using the Code</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">Step 1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create a Visual Basic &quot;ASP.Net Empty Web Application&quot; in Visual Studio 2012 or Visual Studio Express 2012. Name it as &quot;VBASPNETChartExport.&quot;</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">Step 2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Add two web forms in the website root directory, name them as &quot;SaveToImage&quot; and &quot;SaveToPdf.&quot; Drag a Chart control and a button to two pages. The html code resembles following:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;asp:Chart ID=&quot;myChart&quot; runat=&quot;server&quot; Height=&quot;400px&quot; Width=&quot;500px&quot;&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Series&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Series Name=&quot;Series1&quot; ChartType=&quot;Column&quot; ChartArea=&quot;ChartArea1&quot;&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:Series&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Series Name=&quot;Series2&quot; ChartType=&quot;Column&quot; ChartArea=&quot;ChartArea1&quot;&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:Series&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Series&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ChartAreas&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:ChartArea Name=&quot;ChartArea1&quot;&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:ChartArea&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ChartAreas&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:Chart&gt; 


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:Button ID=&quot;btnSave&quot; runat=&quot;server&quot; Text=&quot;Save to Pdf&quot; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;onclick=&quot;btnSave_Click&quot; /&gt;&nbsp;&nbsp;&nbsp;&nbsp; 

</pre>
<pre id="codePreview" class="html">
&lt;asp:Chart ID=&quot;myChart&quot; runat=&quot;server&quot; Height=&quot;400px&quot; Width=&quot;500px&quot;&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Series&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Series Name=&quot;Series1&quot; ChartType=&quot;Column&quot; ChartArea=&quot;ChartArea1&quot;&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:Series&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Series Name=&quot;Series2&quot; ChartType=&quot;Column&quot; ChartArea=&quot;ChartArea1&quot;&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:Series&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Series&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ChartAreas&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:ChartArea Name=&quot;ChartArea1&quot;&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:ChartArea&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ChartAreas&gt; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:Chart&gt; 


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:Button ID=&quot;btnSave&quot; runat=&quot;server&quot; Text=&quot;Save to Pdf&quot; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;onclick=&quot;btnSave_Click&quot; /&gt;&nbsp;&nbsp;&nbsp;&nbsp; 

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">Step 3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Add a utility class to project. In this class, there are two methods: one is used to generate Chart's data source, another bind the data source to Chart for rendering.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
&nbsp;&nbsp; ''' Create a DataTable as the data source of the Chart control 
&nbsp;&nbsp;&nbsp;''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;returns&gt;DataTable&lt;/returns&gt;
&nbsp;&nbsp; Public Shared Function CreateDataTable() As DataTable
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Temp DataTable
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim dt As New DataTable()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 'Add three columns to the DataTable 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Columns.Add(&quot;Date&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dt.Columns.Add(&quot;Volume1&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dt.Columns.Add(&quot;Volume2&quot;)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim dr As DataRow


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Add rows to the table which contains some random data for demonstration 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dr = dt.NewRow()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dr(&quot;Date&quot;) = &quot;Jan&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dr(&quot;Volume1&quot;) = 3731
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dr(&quot;Volume2&quot;) = 4101
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dt.Rows.Add(dr)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dr = dt.NewRow()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dr(&quot;Date&quot;) = &quot;Feb&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dr(&quot;Volume1&quot;) = 6024
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dr(&quot;Volume2&quot;) = 4324
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dt.Rows.Add(dr)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dr = dt.NewRow()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dr(&quot;Date&quot;) = &quot;Mar&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dr(&quot;Volume1&quot;) = 4935
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dr(&quot;Volume2&quot;) = 2935
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dt.Rows.Add(dr)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return dt
&nbsp;&nbsp; End Function


&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp; ''' Render the chart.
&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;myChart&quot;&gt;The Chart will be bound to&lt;/param&gt;
&nbsp;&nbsp; Public Shared Sub DisplayChart(myChart As Chart)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; myChart.DataSource = CreateDataTable()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 'Give two columns of data to Y-axle 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myChart.Series(0).YValueMembers = &quot;Volume1&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; myChart.Series(1).YValueMembers = &quot;Volume2&quot;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 'Set the X-axle as date value 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myChart.Series(0).XValueMember = &quot;Date&quot;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 'Bind the Chart control with the setting above 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myChart.DataBind()
&nbsp;&nbsp; End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
&nbsp;&nbsp; ''' Create a DataTable as the data source of the Chart control 
&nbsp;&nbsp;&nbsp;''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;returns&gt;DataTable&lt;/returns&gt;
&nbsp;&nbsp; Public Shared Function CreateDataTable() As DataTable
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Temp DataTable
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim dt As New DataTable()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 'Add three columns to the DataTable 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Columns.Add(&quot;Date&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dt.Columns.Add(&quot;Volume1&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dt.Columns.Add(&quot;Volume2&quot;)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim dr As DataRow


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Add rows to the table which contains some random data for demonstration 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dr = dt.NewRow()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dr(&quot;Date&quot;) = &quot;Jan&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dr(&quot;Volume1&quot;) = 3731
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dr(&quot;Volume2&quot;) = 4101
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dt.Rows.Add(dr)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dr = dt.NewRow()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dr(&quot;Date&quot;) = &quot;Feb&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dr(&quot;Volume1&quot;) = 6024
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dr(&quot;Volume2&quot;) = 4324
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dt.Rows.Add(dr)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dr = dt.NewRow()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dr(&quot;Date&quot;) = &quot;Mar&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dr(&quot;Volume1&quot;) = 4935
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dr(&quot;Volume2&quot;) = 2935
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; dt.Rows.Add(dr)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return dt
&nbsp;&nbsp; End Function


&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp; ''' Render the chart.
&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;myChart&quot;&gt;The Chart will be bound to&lt;/param&gt;
&nbsp;&nbsp; Public Shared Sub DisplayChart(myChart As Chart)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; myChart.DataSource = CreateDataTable()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 'Give two columns of data to Y-axle 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myChart.Series(0).YValueMembers = &quot;Volume1&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; myChart.Series(1).YValueMembers = &quot;Volume2&quot;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 'Set the X-axle as date value 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myChart.Series(0).XValueMember = &quot;Date&quot;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 'Bind the Chart control with the setting above 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myChart.DataBind()
&nbsp;&nbsp; End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">Step 4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>In the code-behind file of SaveToImage.aspx, we will use Chart Control's SaveImage method to save chart as image.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim exportFileName As String = Server.MapPath(&quot;Images&quot;) & &quot;/testImage.jpg&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; myChart.SaveImage(exportFileName, ChartImageFormat.Jpeg)
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Me.ClientScript.RegisterStartupScript(Me.GetType(), &quot;exportChart&quot;, String.Format(&quot;alert('Has been successfully exported to:{0}');&quot;, exportFileName.Replace(&quot;\&quot;c, &quot;/&quot;c)), True)
&nbsp;&nbsp;&nbsp; End Sub

</pre>
<pre id="codePreview" class="vb">
Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim exportFileName As String = Server.MapPath(&quot;Images&quot;) & &quot;/testImage.jpg&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; myChart.SaveImage(exportFileName, ChartImageFormat.Jpeg)
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Me.ClientScript.RegisterStartupScript(Me.GetType(), &quot;exportChart&quot;, String.Format(&quot;alert('Has been successfully exported to:{0}');&quot;, exportFileName.Replace(&quot;\&quot;c, &quot;/&quot;c)), True)
&nbsp;&nbsp;&nbsp; End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">Step 5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>In the code-behind file of SaveToPdf.aspx, we will set the options of Response at the same time by means of the TOTALLY FREE (No-license) PDF convertor called iTextSharp to output pdf file.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Specify the content type.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Response.ContentType = &quot;application/pdf&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Add a Content-Disposition header.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Response.AddHeader(&quot;Content-Disposition&quot;, [String].Format(&quot;attachment; filename={0}.pdf&quot;, &quot;test&quot;))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Render the chart.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Utilities.DisplayChart(myChart)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '#Region &quot;Generate the exported content and send it to the client.&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 'Create a Document object
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim doc As New Document()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Create a writer to dump the contents of the Document to the Response.OutputStream stream
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim writer As PdfWriter = PdfWriter.GetInstance(doc, Response.OutputStream)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; doc.Open()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Now create the chart image and add it to the PDF
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using imgStream As New MemoryStream()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Save the chart to a MemoryStream
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; myChart.SaveImage(imgStream, ChartImageFormat.Png)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Create an Image object from the MemoryStream data
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim img As Image = Image.GetInstance(imgStream.ToArray())


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Scale the Image object to fit within the boundary of the PDF document and add it
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;img.ScaleToFit(doc.PageSize.Width - (doc.LeftMargin &#43; doc.RightMargin), doc.PageSize.Height - (doc.TopMargin &#43; doc.BottomMargin))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; doc.Add(img)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Finally
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; doc.Close()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '#End Region


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Indicate that the data to send to the client has ended
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Response.[End]()


&nbsp;&nbsp;&nbsp; End Sub

</pre>
<pre id="codePreview" class="vb">
Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Specify the content type.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Response.ContentType = &quot;application/pdf&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Add a Content-Disposition header.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Response.AddHeader(&quot;Content-Disposition&quot;, [String].Format(&quot;attachment; filename={0}.pdf&quot;, &quot;test&quot;))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Render the chart.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Utilities.DisplayChart(myChart)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '#Region &quot;Generate the exported content and send it to the client.&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 'Create a Document object
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim doc As New Document()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Create a writer to dump the contents of the Document to the Response.OutputStream stream
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim writer As PdfWriter = PdfWriter.GetInstance(doc, Response.OutputStream)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; doc.Open()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Now create the chart image and add it to the PDF
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using imgStream As New MemoryStream()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Save the chart to a MemoryStream
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; myChart.SaveImage(imgStream, ChartImageFormat.Png)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Create an Image object from the MemoryStream data
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim img As Image = Image.GetInstance(imgStream.ToArray())


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Scale the Image object to fit within the boundary of the PDF document and add it
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;img.ScaleToFit(doc.PageSize.Width - (doc.LeftMargin &#43; doc.RightMargin), doc.PageSize.Height - (doc.TopMargin &#43; doc.BottomMargin))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; doc.Add(img)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Finally
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; doc.Close()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '#End Region


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Indicate that the data to send to the client has ended
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Response.[End]()


&nbsp;&nbsp;&nbsp; End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">Step 6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Build the application, and then you can debug it.</p>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoNormal">Tutorial: Data Binding a Chart to a Database (Chart Controls)<br>
<a href="http://msdn.microsoft.com/en-us/library/dd489231(VS.100).aspx">http://msdn.microsoft.com/en-us/library/dd489231(VS.100).aspx</a>
<br>
Chart Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.datavisualization.charting.chart(VS.100).aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.datavisualization.charting.chart(VS.100).aspx</a><br>
Chart.SaveImage Method<br>
<a href="http://msdn.microsoft.com/en-us/library/dd455382(v=vs.100).aspx">http://msdn.microsoft.com/en-us/library/dd455382(v=vs.100).aspx</a><br style="">
<br style="">
</p>
<p class="MsoNormal"></p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

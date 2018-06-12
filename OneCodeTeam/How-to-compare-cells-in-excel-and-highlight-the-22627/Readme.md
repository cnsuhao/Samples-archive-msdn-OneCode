# How to compare cells in excel and highlight the cells that are different
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Office
* Office Development
## Topics
* Highlight
* compare cells
## IsPublished
* True
## ModifiedDate
* 2013-06-13 10:15:07
## Description

<h1>How to compare cells in Excel and highlight the cells that are different (VBExcelCompareCells)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The sample demonstrates how to compare cells in different columns of the same sheet in an excel file and compare cells in different sheets of the excel file.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">Before you run the sample, you should make sure Microsoft Office 2010 installed on your computer.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Step1. Open <span style="">&quot;</span>VBExcelCompareCells.sln&quot; to open the project and then press F5 on the keyboard to run the sample. The form resembles the following:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84403/1/image.png" alt="" width="576" height="188" align="middle">
</span></p>
<p class="MsoNormal">Step2.<span style="">&nbsp; </span>Click &quot;Select&quot; button to choose an existing excel file which need to compare cells. Then you should input valid source column and target column. At last, you can click &quot;Compare Columns&quot;
 to compare cells in different columns of the same sheet<span style="">.</span> If the manipulation is successful, you will receive &quot;Compare Columns successfully, Please check in the excel file&quot; message.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84404/1/image.png" alt="" width="576" height="272" align="middle">
</span></p>
<p class="MsoNormal">Step3. If you want to compare cells in different sheets of the excel file, you should input valid source sheet and target sheet, then Click &quot;Compare Sheets&quot; button to compare cells in different sheets. You also can receive the
 &quot;Compare Sheets successfully, Please check in the excel file&quot; message when the manipulation is successful.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84405/1/image.png" alt="" width="576" height="299" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">Step1. Create Windows Forms Application from template of Visual Studio.</p>
<p class="MsoNormal">Step2. Add &quot;Microsoft.Office.Interop.Excel.dll&quot; reference to your project</p>
<p class="MsoNormal">Step3. Add a helper class to the project and named it as &quot;CompareHelper.vb&quot;. Then code the two functions by using the following code snippets:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
   ''' Compare Cells in different columns in the same sheet of an excel file
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;sourceCol&quot;&gt;Source Column&lt;/param&gt;
   ''' &lt;param name=&quot;targetCol&quot;&gt;Taget Column&lt;/param&gt;
   ''' &lt;param name=&quot;excelFile&quot;&gt;The Path of Excel File&lt;/param&gt;
   Public Sub CompareColumns(sourceCol As String, targetCol As String, excelFile As String)
       Try
           ' Create an instance of Microsoft Excel and make it invisible
           excelApp = New Excel.Application()
           excelApp.Visible = False


           ' open a Workbook and get the active Worksheet
           excelWorkbook = excelApp.Workbooks.Open(excelFile)
           excelWorkSheet1 = excelWorkbook.ActiveSheet


           ' maximum Row
           lastLine = excelWorkSheet1.UsedRange.Rows.Count
           For row As Integer = 1 To lastLine
               ' Compare cell value
               If excelWorkSheet1.Range(sourceCol & row.ToString()).Value &lt;&gt; excelWorkSheet1.Range(targetCol & row.ToString()).Value Then
                   excelWorkSheet1.Range(sourceCol & row.ToString()).Interior.Color = 255
                   excelWorkSheet1.Range(targetCol & row.ToString()).Interior.Color = 5296274
               End If
           Next


           ' Save WorkBook and close
           excelWorkbook.Save()
           excelWorkbook.Close()


           ' Quit Excel Application
           excelApp.Quit()
       Catch
           Throw
       End Try
   End Sub


   ''' &lt;summary&gt;
   ''' Compare Cells in different sheets of an excel file
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;sourceSheetNum&quot;&gt;Source Sheet Number&lt;/param&gt;
   ''' &lt;param name=&quot;targetSheetNum&quot;&gt;Target Sheet Number&lt;/param&gt;
   ''' &lt;param name=&quot;excelFile&quot;&gt;Path of Excel File&lt;/param&gt;
   Public Sub CompareSheets(sourceSheetNum As Integer, targetSheetNum As Integer, excelFile As String)
       Try
           ' Create an instance of Microsoft Excel and make it invisible
           excelApp = New Excel.Application()
           excelApp.Visible = False
           excelWorkbook = excelApp.Workbooks.Open(excelFile)
           excelWorkSheet1 = excelWorkbook.Sheets(sourceSheetNum)
           excelWorkSheet2 = excelWorkbook.Sheets(targetSheetNum)
           lastLine = Math.Max(excelWorkSheet1.UsedRange.Rows.Count, excelWorkSheet2.UsedRange.Rows.Count)
           For row As Integer = 1 To lastLine
               ' maximum column 
               Dim lastCol As Integer = Math.Max(excelWorkSheet1.UsedRange.Columns.Count, excelWorkSheet2.UsedRange.Columns.Count)
               For column As Integer = 1 To lastCol
                   If excelWorkSheet1.Cells(row, column).Value &lt;&gt; excelWorkSheet2.Cells(row, column).Value Then
                       DirectCast(excelWorkSheet1.Cells(row, column), Excel.Range).Interior.Color = 255
                       DirectCast(excelWorkSheet2.Cells(row, column), Excel.Range).Interior.Color = 5296274
                   End If
               Next
           Next


           ' Save WorkBook and close
           excelWorkbook.Save()
           excelWorkbook.Close()


           ' Quit Excel Application
           excelApp.Quit()
       Catch
           Throw
       End Try
   End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
   ''' Compare Cells in different columns in the same sheet of an excel file
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;sourceCol&quot;&gt;Source Column&lt;/param&gt;
   ''' &lt;param name=&quot;targetCol&quot;&gt;Taget Column&lt;/param&gt;
   ''' &lt;param name=&quot;excelFile&quot;&gt;The Path of Excel File&lt;/param&gt;
   Public Sub CompareColumns(sourceCol As String, targetCol As String, excelFile As String)
       Try
           ' Create an instance of Microsoft Excel and make it invisible
           excelApp = New Excel.Application()
           excelApp.Visible = False


           ' open a Workbook and get the active Worksheet
           excelWorkbook = excelApp.Workbooks.Open(excelFile)
           excelWorkSheet1 = excelWorkbook.ActiveSheet


           ' maximum Row
           lastLine = excelWorkSheet1.UsedRange.Rows.Count
           For row As Integer = 1 To lastLine
               ' Compare cell value
               If excelWorkSheet1.Range(sourceCol & row.ToString()).Value &lt;&gt; excelWorkSheet1.Range(targetCol & row.ToString()).Value Then
                   excelWorkSheet1.Range(sourceCol & row.ToString()).Interior.Color = 255
                   excelWorkSheet1.Range(targetCol & row.ToString()).Interior.Color = 5296274
               End If
           Next


           ' Save WorkBook and close
           excelWorkbook.Save()
           excelWorkbook.Close()


           ' Quit Excel Application
           excelApp.Quit()
       Catch
           Throw
       End Try
   End Sub


   ''' &lt;summary&gt;
   ''' Compare Cells in different sheets of an excel file
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;sourceSheetNum&quot;&gt;Source Sheet Number&lt;/param&gt;
   ''' &lt;param name=&quot;targetSheetNum&quot;&gt;Target Sheet Number&lt;/param&gt;
   ''' &lt;param name=&quot;excelFile&quot;&gt;Path of Excel File&lt;/param&gt;
   Public Sub CompareSheets(sourceSheetNum As Integer, targetSheetNum As Integer, excelFile As String)
       Try
           ' Create an instance of Microsoft Excel and make it invisible
           excelApp = New Excel.Application()
           excelApp.Visible = False
           excelWorkbook = excelApp.Workbooks.Open(excelFile)
           excelWorkSheet1 = excelWorkbook.Sheets(sourceSheetNum)
           excelWorkSheet2 = excelWorkbook.Sheets(targetSheetNum)
           lastLine = Math.Max(excelWorkSheet1.UsedRange.Rows.Count, excelWorkSheet2.UsedRange.Rows.Count)
           For row As Integer = 1 To lastLine
               ' maximum column 
               Dim lastCol As Integer = Math.Max(excelWorkSheet1.UsedRange.Columns.Count, excelWorkSheet2.UsedRange.Columns.Count)
               For column As Integer = 1 To lastCol
                   If excelWorkSheet1.Cells(row, column).Value &lt;&gt; excelWorkSheet2.Cells(row, column).Value Then
                       DirectCast(excelWorkSheet1.Cells(row, column), Excel.Range).Interior.Color = 255
                       DirectCast(excelWorkSheet2.Cells(row, column), Excel.Range).Interior.Color = 5296274
                   End If
               Next
           Next


           ' Save WorkBook and close
           excelWorkbook.Save()
           excelWorkbook.Close()


           ' Quit Excel Application
           excelApp.Quit()
       Catch
           Throw
       End Try
   End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step4. Design UI of main Form and then code the event handle by using the following code snippets:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
   ''' Select Excel File
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
   ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
   Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
       Using openFileDialog As New OpenFileDialog()
           openFileDialog.Filter = &quot;Excel Files(*.xls;*.xlsx)|*.xls;*.xlsx&quot;
           openFileDialog.Title = &quot;Select an excel file&quot;
           If openFileDialog.ShowDialog() = DialogResult.OK Then
               txbExcelPath.Text = openFileDialog.FileName
           End If
       End Using
   End Sub


   ''' &lt;summary&gt;
   ''' Compare Cells in different columns in the same sheet of an excel file
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
   ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
   Private Sub btnCompareCol_Click(sender As Object, e As EventArgs) Handles btnCompareCol.Click
       If Not File.Exists(txbExcelPath.Text) Then
           MessageBox.Show(&quot;Please Select valid path of word document!&quot;, &quot;Error&quot;, MessageBoxButtons.OK, MessageBoxIcon.[Error])
           Return
       End If


       Dim reg As New Regex(&quot;^[A-Z]&#43;$&quot;)
       If txbSourceCol.Text &lt;&gt; String.Empty AndAlso txbTargetCol.Text &lt;&gt; String.Empty Then
           If reg.IsMatch(txbSourceCol.Text.ToUpper()) AndAlso reg.IsMatch(txbTargetCol.Text.ToUpper()) Then
               Try
                   Dim compareHelper As New CompareHelper
                   compareHelper.CompareColumns(txbSourceCol.Text, txbTargetCol.Text, txbExcelPath.Text)


                   ' Clean up the unmanaged Excel COM resources by explicitly
                   GC.Collect()
                   GC.WaitForPendingFinalizers()
                   GC.Collect()
                   GC.WaitForPendingFinalizers()
                   MessageBox.Show(&quot;Compare Columns successfully,Please check in the excel file&quot;)
               Catch ex As Exception
                   MessageBox.Show(&quot;Exception occur, the Exception Message is: &quot; & ex.Message)
                   Return
               End Try
           Else
               MessageBox.Show(&quot;Source Column and Target Column must be letter&quot;)
               Return
           End If
       Else
           MessageBox.Show(&quot;Please input Source Column and Target Column&quot;)
           Return
       End If
   End Sub


   ''' &lt;summary&gt;
   ''' Compare Cells in different sheets of an excel file
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
   ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
   Private Sub btnCompareSheet_Click(sender As Object, e As EventArgs) Handles btnCompareSheet.Click
       If Not File.Exists(txbExcelPath.Text) Then
           MessageBox.Show(&quot;Please Select valid path of word document!&quot;, &quot;Error&quot;, MessageBoxButtons.OK, MessageBoxIcon.[Error])
           Return
       End If


       Dim reg As New Regex(&quot;^[0-9]*$&quot;)
       If txbSourceSheet.Text &lt;&gt; String.Empty AndAlso txbTargetSheet.Text &lt;&gt; String.Empty Then
           If reg.IsMatch(txbSourceSheet.Text.ToUpper()) AndAlso reg.IsMatch(txbTargetSheet.Text.ToUpper()) Then
               Try
                   Dim compareHelper As New CompareHelper
                   compareHelper.CompareSheets(Integer.Parse(txbSourceSheet.Text), Integer.Parse(txbTargetSheet.Text), txbExcelPath.Text)


                   ' Clean up the unmanaged Excel COM resources by explicitly
                   GC.Collect()
                   GC.WaitForPendingFinalizers()
                   GC.Collect()
                   GC.WaitForPendingFinalizers()
                   MessageBox.Show(&quot;Compare sheets successfully,Please check in the excel file&quot;)
               Catch ex As Exception
                   MessageBox.Show(&quot;Exception occur, the Exception Message is: &quot; & ex.Message)
                   Return
               End Try
           Else
               MessageBox.Show(&quot;Source Sheet and Target Sheet must be Number&quot;)
               Return
           End If
       Else
           MessageBox.Show(&quot;Please input Source Sheet and Target Sheet&quot;)
           Return
       End If
   End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
   ''' Select Excel File
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
   ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
   Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
       Using openFileDialog As New OpenFileDialog()
           openFileDialog.Filter = &quot;Excel Files(*.xls;*.xlsx)|*.xls;*.xlsx&quot;
           openFileDialog.Title = &quot;Select an excel file&quot;
           If openFileDialog.ShowDialog() = DialogResult.OK Then
               txbExcelPath.Text = openFileDialog.FileName
           End If
       End Using
   End Sub


   ''' &lt;summary&gt;
   ''' Compare Cells in different columns in the same sheet of an excel file
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
   ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
   Private Sub btnCompareCol_Click(sender As Object, e As EventArgs) Handles btnCompareCol.Click
       If Not File.Exists(txbExcelPath.Text) Then
           MessageBox.Show(&quot;Please Select valid path of word document!&quot;, &quot;Error&quot;, MessageBoxButtons.OK, MessageBoxIcon.[Error])
           Return
       End If


       Dim reg As New Regex(&quot;^[A-Z]&#43;$&quot;)
       If txbSourceCol.Text &lt;&gt; String.Empty AndAlso txbTargetCol.Text &lt;&gt; String.Empty Then
           If reg.IsMatch(txbSourceCol.Text.ToUpper()) AndAlso reg.IsMatch(txbTargetCol.Text.ToUpper()) Then
               Try
                   Dim compareHelper As New CompareHelper
                   compareHelper.CompareColumns(txbSourceCol.Text, txbTargetCol.Text, txbExcelPath.Text)


                   ' Clean up the unmanaged Excel COM resources by explicitly
                   GC.Collect()
                   GC.WaitForPendingFinalizers()
                   GC.Collect()
                   GC.WaitForPendingFinalizers()
                   MessageBox.Show(&quot;Compare Columns successfully,Please check in the excel file&quot;)
               Catch ex As Exception
                   MessageBox.Show(&quot;Exception occur, the Exception Message is: &quot; & ex.Message)
                   Return
               End Try
           Else
               MessageBox.Show(&quot;Source Column and Target Column must be letter&quot;)
               Return
           End If
       Else
           MessageBox.Show(&quot;Please input Source Column and Target Column&quot;)
           Return
       End If
   End Sub


   ''' &lt;summary&gt;
   ''' Compare Cells in different sheets of an excel file
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
   ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
   Private Sub btnCompareSheet_Click(sender As Object, e As EventArgs) Handles btnCompareSheet.Click
       If Not File.Exists(txbExcelPath.Text) Then
           MessageBox.Show(&quot;Please Select valid path of word document!&quot;, &quot;Error&quot;, MessageBoxButtons.OK, MessageBoxIcon.[Error])
           Return
       End If


       Dim reg As New Regex(&quot;^[0-9]*$&quot;)
       If txbSourceSheet.Text &lt;&gt; String.Empty AndAlso txbTargetSheet.Text &lt;&gt; String.Empty Then
           If reg.IsMatch(txbSourceSheet.Text.ToUpper()) AndAlso reg.IsMatch(txbTargetSheet.Text.ToUpper()) Then
               Try
                   Dim compareHelper As New CompareHelper
                   compareHelper.CompareSheets(Integer.Parse(txbSourceSheet.Text), Integer.Parse(txbTargetSheet.Text), txbExcelPath.Text)


                   ' Clean up the unmanaged Excel COM resources by explicitly
                   GC.Collect()
                   GC.WaitForPendingFinalizers()
                   GC.Collect()
                   GC.WaitForPendingFinalizers()
                   MessageBox.Show(&quot;Compare sheets successfully,Please check in the excel file&quot;)
               Catch ex As Exception
                   MessageBox.Show(&quot;Exception occur, the Exception Message is: &quot; & ex.Message)
                   Return
               End Try
           Else
               MessageBox.Show(&quot;Source Sheet and Target Sheet must be Number&quot;)
               Return
           End If
       Else
           MessageBox.Show(&quot;Please input Source Sheet and Target Sheet&quot;)
           Return
       End If
   End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information</h2>
<p class="MsoNormal"><span style=""><span style="">&nbsp;</span>Office Dev Center
</span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/office/aa905340">http://msdn.microsoft.com/en-us/office/aa905340</a>
</p>
<p class="MsoNormal"><span style="">&nbsp;</span>Excel Object Model Overview</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/wss56bz7(v=vs.100).aspx">http://msdn.microsoft.com/en-us/library/wss56bz7(v=vs.100).aspx</a>
</p>
<p class="MsoNormal">Regex Class</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex.aspx">http://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex.aspx</a>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

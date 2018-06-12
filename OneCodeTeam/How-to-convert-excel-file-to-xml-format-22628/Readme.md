# How to convert excel file to xml format
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Office
* Office Development
## Topics
* Excel
* XML
* Convert
## IsPublished
* True
## ModifiedDate
* 2013-06-13 10:15:15
## Description

<h1>How to Convert excel file to xml format (VBOpenXmlExcelToXml)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The sample demonstrates how to convert excel file to xml format using Open XML SDK.
</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">Before building the sample, please make sure you have installed
<a href="http://www.microsoft.com/en-us/download/details.aspx?id=5124">Open XML SDK 2.0 for Microsoft Office</a>.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Step 1. Open &quot;VBOpenXmlExcelToXml.sln&quot; and click Ctrl&#43;F5 to run this project. You will see the following form:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84407/1/image.png" alt="" width="399" height="298" align="middle">
</span></p>
<p class="MsoNormal">Step 2. <span style="">You can click &quot;Browser&quot; button to select an existing excel file and then click
</span><span style="">&quot;</span><span style="">Convert</span><span style="">&quot;
</span><span style="">button to convert the excel document to xml format string. If this operation is successful, the xml string will show in textbox control on form. At this moment, the &quot;Save as&quot; button will be enabled.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84408/1/image.png" alt="" width="406" height="331" align="middle">
</span></p>
<p class="MsoNormal">Step 3. Click &quot;Save as&quot; button to save xml string as xml file on client. When click &quot;Save as&quot; button, there is &quot;Saveas&quot; dialog pops up as below:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84409/1/image.png" alt="" width="576" height="222" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">Step 1. Create &quot;WinForm Application&quot; project via Visual Studio.</p>
<p class="MsoNormal">Step 2. <span style="">After you have installed the Open XML SDK 2.0, add the Open xml reference to the project. To reference the Open XML, right click the project file and click the &quot;Add Reference&quot; button. In the Add Reference
 dialog, navigate to the .Net tab, find DocumentFormat.OpenXml and WindowsBase, click Ok button.
</span></p>
<p class="MsoNormal"><span style="">Step 3. Create ConvertExcelToXml class to convert excel file using Open XML API.
</span></p>
<p class="MsoNormal"><span style="">Step 4. Import Open XML namespace into the class.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet

</pre>
<pre id="codePreview" class="vb">
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step 5. Read the data in excel to DataTable object.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
    '''  Read Data from selected excel file into DataTable
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;filename&quot;&gt;Excel File Path&lt;/param&gt;
    ''' &lt;returns&gt;&lt;/returns&gt;
    Private Function ReadExcelFile(filename As String) As DataTable
        ' Initialize an instance of DataTable
        Dim dt As New DataTable()


        Try
            ' Use SpreadSheetDocument class of Open XML SDK to open excel file
            Using spreadsheetDocument__1 As SpreadsheetDocument = SpreadsheetDocument.Open(filename, False)
                ' Get Workbook Part of Spread Sheet Document
                Dim workbookPart As WorkbookPart = spreadsheetDocument__1.WorkbookPart


                ' Get all sheets in spread sheet document 
                Dim sheetcollection As IEnumerable(Of Sheet) = spreadsheetDocument__1.WorkbookPart.Workbook.GetFirstChild(Of Sheets)().Elements(Of Sheet)()


                ' Get relationship Id
                Dim relationshipId As String = sheetcollection.First().Id.Value


                ' Get sheet1 Part of Spread Sheet Document
                Dim worksheetPart As WorksheetPart = DirectCast(spreadsheetDocument__1.WorkbookPart.GetPartById(relationshipId), WorksheetPart)


                ' Get Data in Excel file
                Dim sheetData As SheetData = worksheetPart.Worksheet.Elements(Of SheetData)().First()
                Dim rowcollection As IEnumerable(Of Row) = sheetData.Descendants(Of Row)()


                If rowcollection.Count() = 0 Then
                    Return dt
                End If


                ' Add columns
                For Each cell As Cell In rowcollection.ElementAt(0)
                    dt.Columns.Add(GetValueOfCell(spreadsheetDocument__1, cell))
                Next


                ' Add rows into DataTable
                For Each row As Row In rowcollection
                    Dim temprow As DataRow = dt.NewRow()
                    Dim columnIndex As Integer = 0
                    For Each cell As Cell In row.Descendants(Of Cell)()
                        ' Get Cell Column Index
                        Dim cellColumnIndex As Integer = GetColumnIndex(GetColumnName(cell.CellReference))


                        If columnIndex &lt; cellColumnIndex Then
                            Do
                                temprow(columnIndex) = String.Empty
                                columnIndex &#43;= 1


                            Loop While columnIndex &lt; cellColumnIndex
                        End If


                        temprow(columnIndex) = GetValueOfCell(spreadsheetDocument__1, cell)
                        columnIndex &#43;= 1
                    Next


                    ' Add the row to DataTable
                    ' the rows include header row
                    dt.Rows.Add(temprow)
                Next
            End Using


            ' Here remove header row
            dt.Rows.RemoveAt(0)
            Return dt
        Catch ex As IOException
            Throw New IOException(ex.Message)
        End Try
    End Function


    ''' &lt;summary&gt;
    '''  Get Value of Cell 
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;spreadsheetdocument&quot;&gt;SpreadSheet Document Object&lt;/param&gt;
    ''' &lt;param name=&quot;cell&quot;&gt;Cell Object&lt;/param&gt;
    ''' &lt;returns&gt;The Value in Cell&lt;/returns&gt;
    Private Shared Function GetValueOfCell(spreadsheetdocument As SpreadsheetDocument, cell As Cell) As String
        ' Get value in Cell
        Dim sharedString As SharedStringTablePart = spreadsheetdocument.WorkbookPart.SharedStringTablePart
        If cell.CellValue Is Nothing Then
            Return String.Empty
        End If


        Dim cellValue As String = cell.CellValue.InnerText


        ' The condition that the Cell DataType is SharedString
        If cell.DataType IsNot Nothing AndAlso cell.DataType.Value = CellValues.SharedString Then
            Return sharedString.SharedStringTable.ChildElements(Integer.Parse(cellValue)).InnerText
        Else
            Return cellValue
        End If
    End Function

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
    '''  Read Data from selected excel file into DataTable
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;filename&quot;&gt;Excel File Path&lt;/param&gt;
    ''' &lt;returns&gt;&lt;/returns&gt;
    Private Function ReadExcelFile(filename As String) As DataTable
        ' Initialize an instance of DataTable
        Dim dt As New DataTable()


        Try
            ' Use SpreadSheetDocument class of Open XML SDK to open excel file
            Using spreadsheetDocument__1 As SpreadsheetDocument = SpreadsheetDocument.Open(filename, False)
                ' Get Workbook Part of Spread Sheet Document
                Dim workbookPart As WorkbookPart = spreadsheetDocument__1.WorkbookPart


                ' Get all sheets in spread sheet document 
                Dim sheetcollection As IEnumerable(Of Sheet) = spreadsheetDocument__1.WorkbookPart.Workbook.GetFirstChild(Of Sheets)().Elements(Of Sheet)()


                ' Get relationship Id
                Dim relationshipId As String = sheetcollection.First().Id.Value


                ' Get sheet1 Part of Spread Sheet Document
                Dim worksheetPart As WorksheetPart = DirectCast(spreadsheetDocument__1.WorkbookPart.GetPartById(relationshipId), WorksheetPart)


                ' Get Data in Excel file
                Dim sheetData As SheetData = worksheetPart.Worksheet.Elements(Of SheetData)().First()
                Dim rowcollection As IEnumerable(Of Row) = sheetData.Descendants(Of Row)()


                If rowcollection.Count() = 0 Then
                    Return dt
                End If


                ' Add columns
                For Each cell As Cell In rowcollection.ElementAt(0)
                    dt.Columns.Add(GetValueOfCell(spreadsheetDocument__1, cell))
                Next


                ' Add rows into DataTable
                For Each row As Row In rowcollection
                    Dim temprow As DataRow = dt.NewRow()
                    Dim columnIndex As Integer = 0
                    For Each cell As Cell In row.Descendants(Of Cell)()
                        ' Get Cell Column Index
                        Dim cellColumnIndex As Integer = GetColumnIndex(GetColumnName(cell.CellReference))


                        If columnIndex &lt; cellColumnIndex Then
                            Do
                                temprow(columnIndex) = String.Empty
                                columnIndex &#43;= 1


                            Loop While columnIndex &lt; cellColumnIndex
                        End If


                        temprow(columnIndex) = GetValueOfCell(spreadsheetDocument__1, cell)
                        columnIndex &#43;= 1
                    Next


                    ' Add the row to DataTable
                    ' the rows include header row
                    dt.Rows.Add(temprow)
                Next
            End Using


            ' Here remove header row
            dt.Rows.RemoveAt(0)
            Return dt
        Catch ex As IOException
            Throw New IOException(ex.Message)
        End Try
    End Function


    ''' &lt;summary&gt;
    '''  Get Value of Cell 
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;spreadsheetdocument&quot;&gt;SpreadSheet Document Object&lt;/param&gt;
    ''' &lt;param name=&quot;cell&quot;&gt;Cell Object&lt;/param&gt;
    ''' &lt;returns&gt;The Value in Cell&lt;/returns&gt;
    Private Shared Function GetValueOfCell(spreadsheetdocument As SpreadsheetDocument, cell As Cell) As String
        ' Get value in Cell
        Dim sharedString As SharedStringTablePart = spreadsheetdocument.WorkbookPart.SharedStringTablePart
        If cell.CellValue Is Nothing Then
            Return String.Empty
        End If


        Dim cellValue As String = cell.CellValue.InnerText


        ' The condition that the Cell DataType is SharedString
        If cell.DataType IsNot Nothing AndAlso cell.DataType.Value = CellValues.SharedString Then
            Return sharedString.SharedStringTable.ChildElements(Integer.Parse(cellValue)).InnerText
        Else
            Return cellValue
        End If
    End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step 6. Get Xml format string from DataTable object.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
   ''' Convert DataTable to Xml format
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;filename&quot;&gt;Excel File Path&lt;/param&gt;
   ''' &lt;returns&gt;Xml format string&lt;/returns&gt;
   Public Function GetXML(filename As String) As String
       Using ds As New DataSet()
           ds.Tables.Add(Me.ReadExcelFile(filename))
           Return ds.GetXml()
       End Using
   End Function

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
   ''' Convert DataTable to Xml format
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;filename&quot;&gt;Excel File Path&lt;/param&gt;
   ''' &lt;returns&gt;Xml format string&lt;/returns&gt;
   Public Function GetXML(filename As String) As String
       Using ds As New DataSet()
           ds.Tables.Add(Me.ReadExcelFile(filename))
           Return ds.GetXml()
       End Using
   End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step 7. Click &quot;Browse&quot; button to choose the existing excel file on client and then click convert button to convert the data in excel to xml format string and show the string in textbox control.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
   '''  Open an dialog to let users select Excel file
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
   ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
   Private Sub btnBrowser_Click(sender As Object, e As EventArgs) Handles btnBrowser.Click
       ' Initializes a OpenFileDialog instance 
       Using openfileDialog As New OpenFileDialog()
           openfileDialog.RestoreDirectory = True
           openfileDialog.Filter = &quot;Excel files(*.xlsx;*.xls)|*.xlsx;*.xls&quot;


           If openfileDialog.ShowDialog() = DialogResult.OK Then
               tbExcelName.Text = openfileDialog.FileName
           End If
       End Using
   End Sub


   ''' &lt;summary&gt;
   '''  Convert Excel file to Xml format and view in Listbox control
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
   ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
   Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
       tbXmlView.Clear()
       Dim excelfileName As String = tbExcelName.Text


       If String.IsNullOrEmpty(excelfileName) OrElse Not File.Exists(excelfileName) Then
           MessageBox.Show(&quot;The Excel file is invalid! Please select a valid file.&quot;)
           Return
       End If


       Try
           Dim xmlFormatstring As String = New ConvertExcelToXml().GetXML(excelfileName)
           If String.IsNullOrEmpty(xmlFormatstring) Then
               MessageBox.Show(&quot;The content of Excel file is Empty!&quot;)
               Return
           End If


           tbXmlView.Text = xmlFormatstring


           ' If txbXmlView has text, set btnSaveAs button to be enable
           btnSaveAs.Enabled = True
       Catch ex As Exception
           MessageBox.Show(&quot;There is error occurs! The error message is: &quot; &#43; ex.Message)
       End Try
   End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
   '''  Open an dialog to let users select Excel file
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
   ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
   Private Sub btnBrowser_Click(sender As Object, e As EventArgs) Handles btnBrowser.Click
       ' Initializes a OpenFileDialog instance 
       Using openfileDialog As New OpenFileDialog()
           openfileDialog.RestoreDirectory = True
           openfileDialog.Filter = &quot;Excel files(*.xlsx;*.xls)|*.xlsx;*.xls&quot;


           If openfileDialog.ShowDialog() = DialogResult.OK Then
               tbExcelName.Text = openfileDialog.FileName
           End If
       End Using
   End Sub


   ''' &lt;summary&gt;
   '''  Convert Excel file to Xml format and view in Listbox control
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
   ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
   Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
       tbXmlView.Clear()
       Dim excelfileName As String = tbExcelName.Text


       If String.IsNullOrEmpty(excelfileName) OrElse Not File.Exists(excelfileName) Then
           MessageBox.Show(&quot;The Excel file is invalid! Please select a valid file.&quot;)
           Return
       End If


       Try
           Dim xmlFormatstring As String = New ConvertExcelToXml().GetXML(excelfileName)
           If String.IsNullOrEmpty(xmlFormatstring) Then
               MessageBox.Show(&quot;The content of Excel file is Empty!&quot;)
               Return
           End If


           tbXmlView.Text = xmlFormatstring


           ' If txbXmlView has text, set btnSaveAs button to be enable
           btnSaveAs.Enabled = True
       Catch ex As Exception
           MessageBox.Show(&quot;There is error occurs! The error message is: &quot; &#43; ex.Message)
       End Try
   End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step 8. Click &quot;Save as&quot; button to save xml string in textbox control as xml file on client.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
  '''  Save the XMl format string as Xml file
  ''' &lt;/summary&gt;
  ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
  ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
  Private Sub btnSaveAs_Click(sender As Object, e As EventArgs) Handles btnSaveAs.Click
      ' Initiializes a SaveFileDialog instance 
      Using savefiledialog As New SaveFileDialog()
          savefiledialog.RestoreDirectory = True
          savefiledialog.DefaultExt = &quot;xml&quot;
          savefiledialog.Filter = &quot;All Files(*.xml)|*.xml&quot;
          If savefiledialog.ShowDialog() = DialogResult.OK Then
              Dim filestream As Stream = savefiledialog.OpenFile()
              Dim streamwriter As New StreamWriter(filestream)
              streamwriter.Write(&quot;&lt;?xml version='1.0'?&gt;&quot; &#43; Environment.NewLine &#43; tbXmlView.Text)
              streamwriter.Close()
          End If
      End Using
  End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
  '''  Save the XMl format string as Xml file
  ''' &lt;/summary&gt;
  ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
  ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
  Private Sub btnSaveAs_Click(sender As Object, e As EventArgs) Handles btnSaveAs.Click
      ' Initiializes a SaveFileDialog instance 
      Using savefiledialog As New SaveFileDialog()
          savefiledialog.RestoreDirectory = True
          savefiledialog.DefaultExt = &quot;xml&quot;
          savefiledialog.Filter = &quot;All Files(*.xml)|*.xml&quot;
          If savefiledialog.ShowDialog() = DialogResult.OK Then
              Dim filestream As Stream = savefiledialog.OpenFile()
              Dim streamwriter As New StreamWriter(filestream)
              streamwriter.Write(&quot;&lt;?xml version='1.0'?&gt;&quot; &#43; Environment.NewLine &#43; tbXmlView.Text)
              streamwriter.Close()
          End If
      End Using
  End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoNormal" style=""><span style=""><a href="http://msdn.microsoft.com/en-us/library/documentformat.openxml.spreadsheet(v=office.14).aspx">Spreadsheet Namespace</a>
</span></p>
<p class="MsoNormal" style=""><span style=""><a href="http://msdn.microsoft.com/en-us/office/bb265236.aspx">Open XML for Office Developers</a>
</span></p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

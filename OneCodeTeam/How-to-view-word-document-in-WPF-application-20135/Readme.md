# How to view word document in WPF application (VBVSTOViewWordInWPF)
## Requires
* Visual Studio 2012
## License
* MS-LPL
## Technologies
* Office
* Office Development
## Topics
* Word
* WPF application
## IsPublished
* True
## ModifiedDate
* 2012-12-25 02:01:36
## Description

<h1>How to view word document in WPF application (VBVSTOViewWordInWPF)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The Sample demonstrates how to view word document in WPF application. WPF does not support to view Word documents directly but some customers want to show word document in WPF. So we can use WPF DocumentViewer control to host fixed document
 such as XPS document. And we also can convert word document to xps document using VSTO.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">Before building the sample, please make sure that you have Installed Microsoft Office 2010 on your machine.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Step 1. Open VBVSTOViewWordInWPF.sln and click Ctrl&#43;F5 to run the project. You will see the following form:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/73470/1/image.png" alt="" width="576" height="325" align="middle">
</span></p>
<p class="MsoNormal">Step 2. Click &quot;Select Word File&quot; button to select an existing word document on your machine</p>
<p class="MsoNormal">Step 3. Click &quot;View Word Doc&quot; button to View Word document in WPF DocumentViewer control. If word document isn't exist, when you click the &quot;View Word Doc&quot;, you will get the prompt message with &quot;The file is invalid.
 Please select an existing file again.&quot;</p>
<p class="MsoNormal">If word document is existing on machine and there is no error occurs, you will see the following form:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/73471/1/image.png" alt="" width="576" height="325" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">Step 1. Create WPF Application project via Visual Studio</p>
<p class="MsoNormal">Step 2. Add needed references to the project</p>
<p class="MsoNormal">Step 3. Import the needed namespace into the mainWindow.xaml.vb class.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Imports System.IO
Imports System.Windows
Imports System.Windows.Xps.Packaging
Imports Microsoft.Office.Interop.Word
Imports Microsoft.Win32
Imports Word = Microsoft.Office.Interop.Word

</pre>
<pre id="codePreview" class="vb">
Imports System.IO
Imports System.Windows
Imports System.Windows.Xps.Packaging
Imports Microsoft.Office.Interop.Word
Imports Microsoft.Win32
Imports Word = Microsoft.Office.Interop.Word

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step 4. Design WPF UI form using XAML codes</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;Grid&gt;
       &lt;Grid.RowDefinitions&gt;
           &lt;RowDefinition Height=&quot;70&quot;&gt;&lt;/RowDefinition&gt;
           &lt;RowDefinition&gt;&lt;/RowDefinition&gt;
       &lt;/Grid.RowDefinitions&gt;
       &lt;Label Name=&quot;lable1&quot; Margin=&quot;3,6,0,0&quot; Content=&quot;Word Document :&quot; VerticalAlignment=&quot;Top&quot; HorizontalAlignment=&quot;Left&quot; /&gt;
       &lt;TextBox  Name=&quot;txbSelectedWordFile&quot; VerticalAlignment=&quot;Top&quot;  HorizontalAlignment=&quot;Stretch&quot; Margin=&quot;110,10,300,0&quot; HorizontalContentAlignment=&quot;Left&quot; /&gt;
       &lt;Button HorizontalAlignment=&quot;Right&quot; VerticalAlignment=&quot;Top&quot; Width=&quot;150&quot; Content=&quot;Select Word File&quot; Name=&quot;btnSelectWord&quot; Margin=&quot;0,10,130,0&quot; Click=&quot;btnSelectWord_Click&quot; /&gt;
       &lt;Button HorizontalAlignment=&quot;Left&quot; Margin=&quot;3,40,0,0&quot; VerticalAlignment=&quot;Top&quot; Content=&quot;View Word Doc&quot; Width=&quot;100&quot; Name=&quot;btnViewDoc&quot; Click=&quot;btnViewDoc_Click&quot; /&gt;
       &lt;DocumentViewer Grid.Row=&quot;1&quot; Name=&quot;documentviewWord&quot; VerticalAlignment=&quot;Top&quot; HorizontalAlignment=&quot;Left&quot;/&gt;
   &lt;/Grid&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;Grid&gt;
       &lt;Grid.RowDefinitions&gt;
           &lt;RowDefinition Height=&quot;70&quot;&gt;&lt;/RowDefinition&gt;
           &lt;RowDefinition&gt;&lt;/RowDefinition&gt;
       &lt;/Grid.RowDefinitions&gt;
       &lt;Label Name=&quot;lable1&quot; Margin=&quot;3,6,0,0&quot; Content=&quot;Word Document :&quot; VerticalAlignment=&quot;Top&quot; HorizontalAlignment=&quot;Left&quot; /&gt;
       &lt;TextBox  Name=&quot;txbSelectedWordFile&quot; VerticalAlignment=&quot;Top&quot;  HorizontalAlignment=&quot;Stretch&quot; Margin=&quot;110,10,300,0&quot; HorizontalContentAlignment=&quot;Left&quot; /&gt;
       &lt;Button HorizontalAlignment=&quot;Right&quot; VerticalAlignment=&quot;Top&quot; Width=&quot;150&quot; Content=&quot;Select Word File&quot; Name=&quot;btnSelectWord&quot; Margin=&quot;0,10,130,0&quot; Click=&quot;btnSelectWord_Click&quot; /&gt;
       &lt;Button HorizontalAlignment=&quot;Left&quot; Margin=&quot;3,40,0,0&quot; VerticalAlignment=&quot;Top&quot; Content=&quot;View Word Doc&quot; Width=&quot;100&quot; Name=&quot;btnViewDoc&quot; Click=&quot;btnViewDoc_Click&quot; /&gt;
       &lt;DocumentViewer Grid.Row=&quot;1&quot; Name=&quot;documentviewWord&quot; VerticalAlignment=&quot;Top&quot; HorizontalAlignment=&quot;Left&quot;/&gt;
   &lt;/Grid&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step 5. Handle the events in behind class.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
  ''' &lt;summary&gt;
  '''  Select Word file 
  ''' &lt;/summary&gt;
  ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
  ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
  Private Sub btnSelectWord_Click(sender As Object, e As RoutedEventArgs)
      ' Initialize an OpenFileDialog
      Dim openFileDialog As New OpenFileDialog()


      ' Set filter and RestoreDirectory
      openFileDialog.RestoreDirectory = True
      openFileDialog.Filter = &quot;Word documents(*.doc;*.docx)|*.doc;*.docx&quot;


      Dim result As System.Nullable(Of Boolean) = openFileDialog.ShowDialog()
      If result = True Then
          If openFileDialog.FileName.Length &gt; 0 Then
              txbSelectedWordFile.Text = openFileDialog.FileName
          End If
      End If
  End Sub


  ''' &lt;summary&gt;
  '''  Convert the word document to xps document
  ''' &lt;/summary&gt;
  ''' &lt;param name=&quot;wordFilename&quot;&gt;Word document Path&lt;/param&gt;
  ''' &lt;param name=&quot;xpsFilename&quot;&gt;Xps document Path&lt;/param&gt;
  ''' &lt;returns&gt;&lt;/returns&gt;
  Private Function ConvertWordToXps(wordFilename As String, xpsFilename As String) As XpsDocument
      ' Create a WordApplication and host word document
      Dim wordApp As Word.Application = New Microsoft.Office.Interop.Word.Application()
      Try
          wordApp.Documents.Open(wordFilename)


          ' To Invisible the word document
          wordApp.Application.Visible = False


          ' Minimize the opened word document
          wordApp.WindowState = WdWindowState.wdWindowStateMinimize


          Dim doc As Document = wordApp.ActiveDocument


          doc.SaveAs(xpsFilename, WdSaveFormat.wdFormatXPS)


          Dim xpsDocument As New XpsDocument(xpsFilename, FileAccess.Read)
          Return xpsDocument
      Catch ex As Exception
          MessageBox.Show(&quot;Error occurs, The error message is  &quot; & ex.ToString())
          Return Nothing
      Finally
          wordApp.Documents.Close()
          DirectCast(wordApp, _Application).Quit(WdSaveOptions.wdDoNotSaveChanges)
      End Try
  End Function


  ''' &lt;summary&gt;
  '''  View Word Document in WPF DocumentView Control
  ''' &lt;/summary&gt;
  ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
  ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
  Private Sub btnViewDoc_Click(sender As Object, e As RoutedEventArgs)
      Dim wordDocument As String = txbSelectedWordFile.Text
      If String.IsNullOrEmpty(wordDocument) OrElse Not File.Exists(wordDocument) Then
          MessageBox.Show(&quot;The file is invalid. Please select an existing file again.&quot;)
      Else
          Dim convertedXpsDoc As String = String.Concat(Path.GetTempPath(), &quot;\&quot;, Guid.NewGuid().ToString(), &quot;.xps&quot;)
          Dim xpsDocument As XpsDocument = ConvertWordToXps(wordDocument, convertedXpsDoc)
          If xpsDocument Is Nothing Then
              Return
          End If


          documentviewWord.Document = xpsDocument.GetFixedDocumentSequence()
      End If
  End Sub

</pre>
<pre id="codePreview" class="vb">
  ''' &lt;summary&gt;
  '''  Select Word file 
  ''' &lt;/summary&gt;
  ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
  ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
  Private Sub btnSelectWord_Click(sender As Object, e As RoutedEventArgs)
      ' Initialize an OpenFileDialog
      Dim openFileDialog As New OpenFileDialog()


      ' Set filter and RestoreDirectory
      openFileDialog.RestoreDirectory = True
      openFileDialog.Filter = &quot;Word documents(*.doc;*.docx)|*.doc;*.docx&quot;


      Dim result As System.Nullable(Of Boolean) = openFileDialog.ShowDialog()
      If result = True Then
          If openFileDialog.FileName.Length &gt; 0 Then
              txbSelectedWordFile.Text = openFileDialog.FileName
          End If
      End If
  End Sub


  ''' &lt;summary&gt;
  '''  Convert the word document to xps document
  ''' &lt;/summary&gt;
  ''' &lt;param name=&quot;wordFilename&quot;&gt;Word document Path&lt;/param&gt;
  ''' &lt;param name=&quot;xpsFilename&quot;&gt;Xps document Path&lt;/param&gt;
  ''' &lt;returns&gt;&lt;/returns&gt;
  Private Function ConvertWordToXps(wordFilename As String, xpsFilename As String) As XpsDocument
      ' Create a WordApplication and host word document
      Dim wordApp As Word.Application = New Microsoft.Office.Interop.Word.Application()
      Try
          wordApp.Documents.Open(wordFilename)


          ' To Invisible the word document
          wordApp.Application.Visible = False


          ' Minimize the opened word document
          wordApp.WindowState = WdWindowState.wdWindowStateMinimize


          Dim doc As Document = wordApp.ActiveDocument


          doc.SaveAs(xpsFilename, WdSaveFormat.wdFormatXPS)


          Dim xpsDocument As New XpsDocument(xpsFilename, FileAccess.Read)
          Return xpsDocument
      Catch ex As Exception
          MessageBox.Show(&quot;Error occurs, The error message is  &quot; & ex.ToString())
          Return Nothing
      Finally
          wordApp.Documents.Close()
          DirectCast(wordApp, _Application).Quit(WdSaveOptions.wdDoNotSaveChanges)
      End Try
  End Function


  ''' &lt;summary&gt;
  '''  View Word Document in WPF DocumentView Control
  ''' &lt;/summary&gt;
  ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
  ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
  Private Sub btnViewDoc_Click(sender As Object, e As RoutedEventArgs)
      Dim wordDocument As String = txbSelectedWordFile.Text
      If String.IsNullOrEmpty(wordDocument) OrElse Not File.Exists(wordDocument) Then
          MessageBox.Show(&quot;The file is invalid. Please select an existing file again.&quot;)
      Else
          Dim convertedXpsDoc As String = String.Concat(Path.GetTempPath(), &quot;\&quot;, Guid.NewGuid().ToString(), &quot;.xps&quot;)
          Dim xpsDocument As XpsDocument = ConvertWordToXps(wordDocument, convertedXpsDoc)
          If xpsDocument Is Nothing Then
              Return
          End If


          documentviewWord.Document = xpsDocument.GetFixedDocumentSequence()
      End If
  End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoNormal">XpsDocument Class:</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/system.windows.xps.packaging.xpsdocument(v=VS.85).aspx">http://msdn.microsoft.com/en-us/library/system.windows.xps.packaging.xpsdocument(v=VS.85).aspx</a></p>
<p class="MsoNormal">DocumentViewer Class:</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/system.windows.controls.documentviewer.aspx">http://msdn.microsoft.com/en-us/library/system.windows.controls.documentviewer.aspx</a></p>
<p class="MsoNormal">Office development with Visual Studio (VSTO):</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-US/office/hh133430">http://msdn.microsoft.com/en-US/office/hh133430</a></p>
<p class="MsoNormal"></p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

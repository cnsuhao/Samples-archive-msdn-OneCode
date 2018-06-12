# Get Plain Text of a Word Document using Open XML (VBOpenXmlGetPlainText)
## Requires
* Visual Studio 2012
## License
* MS-LPL
## Technologies
* Office Development
## Topics
* Word
* Open XML
## IsPublished
* True
## ModifiedDate
* 2012-12-03 07:59:04
## Description

<h1><span style="">How to g</span>et Plain Text of a Word Document using Open XML (<span style="">VB</span>OpenXmlGetPlainText)</h1>
<h2>Introduction</h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">This sample demonstrates how to <span id="ms-rterangepaste-start">
</span>extract the plain text from word document and export it to text files. </span>
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">The sample also can keep the basic style of the document, like white space and new line. Customers don't need to install Office Software and also can read the plain text of a word document.
</span></p>
<p class="MsoNormal"><span style=""></span></p>
<h2>Building the Sample</h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Before building the sample , please make sure you have installed <a href="http://www.microsoft.com/en-us/download/details.aspx?id=5124">
Open XML SDK 2.0 for Microsoft Office</a>. </span></p>
<p class="MsoNormal" style="margin-bottom:7.5pt; line-height:normal"><span style="font-size:12.0pt; font-family:&quot;Times New Roman&quot;,&quot;serif&quot;; color:black"></span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">The following steps walk through a demonstration of Getting plain text of a word document.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step1. Open VB</span>OpenXmlGetPlainText<span style="">.sln and then click F5 to run this project. You will see the following form:
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/71691/1/image.png" alt="" width="507" height="398" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step2. Click &quot;Open&quot; button to choose an existing word document
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step3. Click &quot;Get Plain Text&quot; button to extract plain text from a word document and display the text in
<b style="">RichTextBox</b> Control. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/71692/1/image.png" alt="" width="502" height="397" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step4. Click &quot;Save as Text&quot; button to export the text in RichTextBox to a text file, if the process success, users can get successful message box.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/71693/1/image.png" alt="" width="449" height="148" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoNormal"><span style="">Step1. Create Windows Form project. On the File Menu, choose New, Project, in the templates pane, select Windows Forms Application and enter the name of the project.
</span></p>
<p class="MsoNormal"><span style="">Step2. Add the Open xml reference to the project. To reference the Open XML, right click the project file and click the &quot;Add Reference…&quot; button. In the Add Reference dialog, navigate to the .Net tab, find DocumentFormat.OpenXml
 and click OK. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step3. Create <b style="">GetWordPlainText </b>class to read word document using Open XML. Import the Open XML namespace in this class.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging

</pre>
<pre id="codePreview" class="vb">
Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:新宋体; color:green"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step4. Create ReadWordDocument method to read plain text of a word document
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
   '''  Read Word Document
   ''' &lt;/summary&gt;
   ''' &lt;returns&gt;Plain Text in document &lt;/returns&gt;
   Public Function ReadWordDocument() As String
       Dim sb As New StringBuilder()
       Dim element As OpenXmlElement = package.MainDocumentPart.Document.Body
       If element Is Nothing Then
           Return String.Empty
       End If


       sb.Append(GetPlainText(element))
       Return sb.ToString()
   End Function


   ''' &lt;summary&gt;
   '''  Read Plain Text in all XmlElements of word document
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;element&quot;&gt;XmlElement in document&lt;/param&gt;
   ''' &lt;returns&gt;Plain Text in XmlElement&lt;/returns&gt;
   Public Function GetPlainText(element As OpenXmlElement) As String
       Dim PlainTextInWord As New StringBuilder()
       For Each section As OpenXmlElement In element.Elements()
           Select Case section.LocalName
               ' Text
               Case &quot;t&quot;
                   PlainTextInWord.Append(section.InnerText)
                   Exit Select


                   ' Carriage return
               Case &quot;cr&quot;, &quot;br&quot;
                   ' Page break
                   PlainTextInWord.Append(Environment.NewLine)
                   Exit Select


                   ' Tab
               Case &quot;tab&quot;
                   PlainTextInWord.Append(vbTab)
                   Exit Select


                   ' Paragraph
               Case &quot;p&quot;
                   PlainTextInWord.Append(GetPlainText(section))
                   PlainTextInWord.AppendLine(Environment.NewLine)
                   Exit Select
               Case Else


                   PlainTextInWord.Append(GetPlainText(section))
                   Exit Select
           End Select
       Next


       Return PlainTextInWord.ToString()
   End Function

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
   '''  Read Word Document
   ''' &lt;/summary&gt;
   ''' &lt;returns&gt;Plain Text in document &lt;/returns&gt;
   Public Function ReadWordDocument() As String
       Dim sb As New StringBuilder()
       Dim element As OpenXmlElement = package.MainDocumentPart.Document.Body
       If element Is Nothing Then
           Return String.Empty
       End If


       sb.Append(GetPlainText(element))
       Return sb.ToString()
   End Function


   ''' &lt;summary&gt;
   '''  Read Plain Text in all XmlElements of word document
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;element&quot;&gt;XmlElement in document&lt;/param&gt;
   ''' &lt;returns&gt;Plain Text in XmlElement&lt;/returns&gt;
   Public Function GetPlainText(element As OpenXmlElement) As String
       Dim PlainTextInWord As New StringBuilder()
       For Each section As OpenXmlElement In element.Elements()
           Select Case section.LocalName
               ' Text
               Case &quot;t&quot;
                   PlainTextInWord.Append(section.InnerText)
                   Exit Select


                   ' Carriage return
               Case &quot;cr&quot;, &quot;br&quot;
                   ' Page break
                   PlainTextInWord.Append(Environment.NewLine)
                   Exit Select


                   ' Tab
               Case &quot;tab&quot;
                   PlainTextInWord.Append(vbTab)
                   Exit Select


                   ' Paragraph
               Case &quot;p&quot;
                   PlainTextInWord.Append(GetPlainText(section))
                   PlainTextInWord.AppendLine(Environment.NewLine)
                   Exit Select
               Case Else


                   PlainTextInWord.Append(GetPlainText(section))
                   Exit Select
           End Select
       Next


       Return PlainTextInWord.ToString()
   End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:新宋体; color:green"></span></p>
<p class="MsoNormal" style=""><span style="">Step5. Click &quot;Open&quot; button to choose an existing word document
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
   '''  Handle the btnOpen Click event to load an Word file.
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
   ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
   Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
       SelectWordFile()
   End Sub


   ''' &lt;summary&gt;
   ''' Show an OpenFileDialog to select a Word document.
   ''' &lt;/summary&gt;
   ''' &lt;returns&gt;
   ''' The file name.
   ''' &lt;/returns&gt;
   Private Function SelectWordFile() As String
       Dim fileName As String = Nothing
       Using dialog As New OpenFileDialog()
           dialog.Filter = &quot;Word document (*.docx)|*.docx&quot;
           dialog.InitialDirectory = Environment.CurrentDirectory


           ' Retore the directory before closing
           dialog.RestoreDirectory = True
           If dialog.ShowDialog() = DialogResult.OK Then
               fileName = dialog.FileName
               tbxFile.Text = dialog.FileName
               rtbText.Clear()
           End If
       End Using


       Return fileName
   End Function

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
   '''  Handle the btnOpen Click event to load an Word file.
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
   ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
   Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
       SelectWordFile()
   End Sub


   ''' &lt;summary&gt;
   ''' Show an OpenFileDialog to select a Word document.
   ''' &lt;/summary&gt;
   ''' &lt;returns&gt;
   ''' The file name.
   ''' &lt;/returns&gt;
   Private Function SelectWordFile() As String
       Dim fileName As String = Nothing
       Using dialog As New OpenFileDialog()
           dialog.Filter = &quot;Word document (*.docx)|*.docx&quot;
           dialog.InitialDirectory = Environment.CurrentDirectory


           ' Retore the directory before closing
           dialog.RestoreDirectory = True
           If dialog.ShowDialog() = DialogResult.OK Then
               fileName = dialog.FileName
               tbxFile.Text = dialog.FileName
               rtbText.Clear()
           End If
       End Using


       Return fileName
   End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span style=""></span></p>
<p class="MsoNormal" style=""><span style="">Step6. Click &quot;Get Plain text&quot; to call ReadWordDocument in GetWordPlainText class
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
    ''' Get Plain Text from Word file
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
    Private Sub btnGetPlainText_Click(sender As Object, e As EventArgs) Handles btnGetPlainText.Click
        Try
            getWordPlainText = New GetWordPlainText(tbxFile.Text)
            Me.rtbText.Clear()
            Me.rtbText.Text = getWordPlainText.ReadWordDocument()


            ' After read text in word document successfully&iuml;&frac14;&#338;make &quot;save as text&quot; button to be enabled.
            Me.btnSaveas.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, &quot;Error&quot;, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            If getWordPlainText IsNot Nothing Then
                getWordPlainText.Dispose()
            End If
        End Try
    End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
    ''' Get Plain Text from Word file
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
    Private Sub btnGetPlainText_Click(sender As Object, e As EventArgs) Handles btnGetPlainText.Click
        Try
            getWordPlainText = New GetWordPlainText(tbxFile.Text)
            Me.rtbText.Clear()
            Me.rtbText.Text = getWordPlainText.ReadWordDocument()


            ' After read text in word document successfully&iuml;&frac14;&#338;make &quot;save as text&quot; button to be enabled.
            Me.btnSaveas.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, &quot;Error&quot;, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            If getWordPlainText IsNot Nothing Then
                getWordPlainText.Dispose()
            End If
        End Try
    End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span style=""></span></p>
<p class="MsoNormal" style=""><span style="">Step7. Click &quot;Save as Text&quot; to save the text to text file.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
   '''  Save the text to text file
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
   ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
   Private Sub btnSaveas_Click(sender As Object, e As EventArgs) Handles btnSaveas.Click
       Using savefileDialog As New SaveFileDialog()
           savefileDialog.Filter = &quot;txt document(*.txt)|*.txt&quot;


           ' default file name extension
           savefileDialog.DefaultExt = &quot;.txt&quot;


           ' Retore the directory before closing
           savefileDialog.RestoreDirectory = True
           If savefileDialog.ShowDialog() = DialogResult.OK Then
               Dim filename As String = savefileDialog.FileName
               rtbText.SaveFile(filename, RichTextBoxStreamType.PlainText)
               MessageBox.Show(&quot;Save Text file successfully, the file path is&iuml;&frac14;&#353; &quot; & filename)
           End If
       End Using
   End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
   '''  Save the text to text file
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
   ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
   Private Sub btnSaveas_Click(sender As Object, e As EventArgs) Handles btnSaveas.Click
       Using savefileDialog As New SaveFileDialog()
           savefileDialog.Filter = &quot;txt document(*.txt)|*.txt&quot;


           ' default file name extension
           savefileDialog.DefaultExt = &quot;.txt&quot;


           ' Retore the directory before closing
           savefileDialog.RestoreDirectory = True
           If savefileDialog.ShowDialog() = DialogResult.OK Then
               Dim filename As String = savefileDialog.FileName
               rtbText.SaveFile(filename, RichTextBoxStreamType.PlainText)
               MessageBox.Show(&quot;Save Text file successfully, the file path is&iuml;&frac14;&#353; &quot; & filename)
           End If
       End Using
   End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span style=""></span></p>
<p class="MsoNormal" style=""><span style=""><a href="http://msdn.microsoft.com/en-us/library/bb448854.aspx" target="_top">Open XML SDK 2.0</a></span><span style="">
</span></p>
<p class="MsoNormal" style=""><span style=""><a href="http://msdn.microsoft.com/en-us/library/cc850833.aspx">Word Processing</a>
</span></p>
<p class="MsoNormal" style=""><span style=""><a href="http://msdn.microsoft.com/en-us/office/bb265236">Open XML Developer Center</a>
</span></p>
<p class="MsoNormal" style=""><span style=""></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

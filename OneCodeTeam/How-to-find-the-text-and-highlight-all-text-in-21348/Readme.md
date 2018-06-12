# How to find the text and highlight all text in RichTextBox of windows form
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Windows Forms
## Topics
* RichTextBox
* hightlight
## IsPublished
* True
## ModifiedDate
* 2013-03-22 05:27:34
## Description

<p class="MsoNormal"><span style="">The sample demonstrates how to find and highlight all matched text in RichTextBox of Windows Form.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Users can input text that they want to search in search combobox, and then they also can select find options and highlight color, if the searched text exists in richtextbox, the searched text will be highlighted with the selected color; and if
 the searched text can't be found in the text of richtextbox control, <span style="">
a prompt message will be shown.</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">We can run the sample according to the following steps: </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step1. Open &quot;VBWinFormSearchAndHighlightText.sln&quot; and then click Ctrl&#43;F5 to run the project. You can see the following form:
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/78774/1/image.png" alt="" width="465" height="370" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step2. Input text in Search combobox and click &quot;panelColor&quot; to choose the highlight color, when click &quot;panelColor&quot; control,
<span style="">a popup form will be shown and you can choose color from the popup form</span>:
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/78775/1/image.png" alt="" width="230" height="324" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step3. </span><span style="">After choose the highlight color and click &quot;OK&quot; button, then click &quot;SearchAndHightlight&quot; button, if the searched text exists in richtextbox control, the text will be highlighted with selected color,
 and if the text doesn't exist, a prompt message: &quot;Can't find the &quot;XXXX&quot; in RichTextBox control&quot; will be shown.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step1. Create Windows Form project via visual studio and named it as &quot;VBWinFormSearchAndHighlightText&quot;
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step2. Add Component Class into the project and named the class as &quot;CustomRichTextBox&quot;.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
'''  Custom RichTextBox control
''' &lt;/summary&gt;
Partial Public Class CustomRichTextBox
    Inherits RichTextBox
    
    ''' &lt;summary&gt;
    '''  Search and Highlight all text in RichTextBox Control 
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;findWhat&quot;&gt;Find What&lt;/param&gt;
    ''' &lt;param name=&quot;highlightColor&quot;&gt;Highlight Color&lt;/param&gt;
    ''' &lt;param name=&quot;ismatchCase&quot;&gt;Is Match Case&lt;/param&gt;
    ''' &lt;param name=&quot;ismatchWholeWord&quot;&gt;Is Match Whole Word&lt;/param&gt;
    ''' &lt;returns&gt;&lt;/returns&gt;
    Public Function Highlight(findWhat As String, highlightColor As Color, ismatchCase As Boolean, ismatchWholeWord As Boolean) As Boolean
        ' Clear all highlights before searching text again
        ClearHighlight()


        Dim startSearch As Integer = 0
        'int searchLength = findWhat.Length;
        Dim findoptions As RichTextBoxFinds = Nothing


        ' Setup the search options.
        If ismatchCase AndAlso ismatchWholeWord Then
            findoptions = RichTextBoxFinds.MatchCase Or RichTextBoxFinds.WholeWord
        ElseIf ismatchCase Then
            findoptions = RichTextBoxFinds.MatchCase
        ElseIf ismatchWholeWord Then
            findoptions = RichTextBoxFinds.WholeWord
        Else
            findoptions = RichTextBoxFinds.None
        End If


        ' detect whether search text exists in richtextbox
        Dim isfind As Boolean = False
        Dim index As Integer = -1


        ' Search text in RichTextBox and highlight them with color.
        While (InlineAssignHelper(index, Me.Find(findWhat, startSearch, findoptions))) &gt; -1
            isfind = True


            Me.SelectionBackColor = highlightColor


            ' Continue after the one we searched
            startSearch = index &#43; 1
        End While


        ' If the text exist in RichTextBox control, then return true, otherwise, return false
        Return isfind
    End Function


    ''' &lt;summary&gt;
    '''  Clear all Highlights 
    ''' &lt;/summary&gt;
    Private Sub ClearHighlight()
        Me.SelectAll()
        Me.SelectionBackColor = Color.White
    End Sub
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function
End Class

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
'''  Custom RichTextBox control
''' &lt;/summary&gt;
Partial Public Class CustomRichTextBox
    Inherits RichTextBox
    
    ''' &lt;summary&gt;
    '''  Search and Highlight all text in RichTextBox Control 
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;findWhat&quot;&gt;Find What&lt;/param&gt;
    ''' &lt;param name=&quot;highlightColor&quot;&gt;Highlight Color&lt;/param&gt;
    ''' &lt;param name=&quot;ismatchCase&quot;&gt;Is Match Case&lt;/param&gt;
    ''' &lt;param name=&quot;ismatchWholeWord&quot;&gt;Is Match Whole Word&lt;/param&gt;
    ''' &lt;returns&gt;&lt;/returns&gt;
    Public Function Highlight(findWhat As String, highlightColor As Color, ismatchCase As Boolean, ismatchWholeWord As Boolean) As Boolean
        ' Clear all highlights before searching text again
        ClearHighlight()


        Dim startSearch As Integer = 0
        'int searchLength = findWhat.Length;
        Dim findoptions As RichTextBoxFinds = Nothing


        ' Setup the search options.
        If ismatchCase AndAlso ismatchWholeWord Then
            findoptions = RichTextBoxFinds.MatchCase Or RichTextBoxFinds.WholeWord
        ElseIf ismatchCase Then
            findoptions = RichTextBoxFinds.MatchCase
        ElseIf ismatchWholeWord Then
            findoptions = RichTextBoxFinds.WholeWord
        Else
            findoptions = RichTextBoxFinds.None
        End If


        ' detect whether search text exists in richtextbox
        Dim isfind As Boolean = False
        Dim index As Integer = -1


        ' Search text in RichTextBox and highlight them with color.
        While (InlineAssignHelper(index, Me.Find(findWhat, startSearch, findoptions))) &gt; -1
            isfind = True


            Me.SelectionBackColor = highlightColor


            ' Continue after the one we searched
            startSearch = index &#43; 1
        End While


        ' If the text exist in RichTextBox control, then return true, otherwise, return false
        Return isfind
    End Function


    ''' &lt;summary&gt;
    '''  Clear all Highlights 
    ''' &lt;/summary&gt;
    Private Sub ClearHighlight()
        Me.SelectAll()
        Me.SelectionBackColor = Color.White
    End Sub
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step3. Design UI of the main form and implement behind code according to the following codes.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Class MainForm


    Public Sub New()
        InitializeComponent()


        ' Initialize the state of SearchAndHighlight button
        Me.btnSearchAndHighlight.Enabled = False
    End Sub


    ''' &lt;summary&gt;
    '''  Select Highlight color
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
    Private Sub panelColor_Click(sender As Object, e As EventArgs) Handles panelColor.Click
        Using colorDialog As New ColorDialog()
            colorDialog.Color = Me.panelColor.BackColor
            If colorDialog.ShowDialog() = DialogResult.OK Then
                Me.panelColor.BackColor = colorDialog.Color
            End If
        End Using
    End Sub


    ''' &lt;summary&gt;
    '''  Search the text and Highlight them in RichTextBox
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
    Private Sub btnSearchAndHighlight_Click(sender As Object, e As EventArgs) Handles btnSearchAndHighlight.Click
        Dim isexist As Boolean = rtbSource.Highlight(cboSearch.Text, panelColor.BackColor, chkMatchCase.Checked, chkMatchWholeWord.Checked)


        If Not isexist Then
            Dim format As String = String.Format(&quot;Can't find the &quot;&quot;{0}&quot;&quot; in RichTextBox control&quot;, cboSearch.Text)
            MessageBox.Show(format)
        End If
        If Not cboSearch.Items.Contains(cboSearch.Text) Then
            Me.cboSearch.Items.Add(Me.cboSearch.Text)
        End If
    End Sub


    ''' &lt;summary&gt;
    '''  The Event for Text change in ComboBox Control
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
    Private Sub cboSearch_TextChanged(sender As Object, e As EventArgs) Handles cboSearch.TextChanged
        ' Disable the SearchAndHightlight button
        If cboSearch.Text.Length = 0 Then
            Me.btnSearchAndHighlight.Enabled = False
        Else
            ' Enable the SearchAndHightlight button
            Me.btnSearchAndHighlight.Enabled = True
        End If
    End Sub


    ''' &lt;summary&gt;
    '''  Key Press event 
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
    Private Sub cboSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboSearch.KeyPress
        If e.KeyChar = ChrW(13) Then
            btnSearchAndHighlight.PerformClick()
        End If
    End Sub


End Class


</pre>
<pre id="codePreview" class="vb">
Public Class MainForm


    Public Sub New()
        InitializeComponent()


        ' Initialize the state of SearchAndHighlight button
        Me.btnSearchAndHighlight.Enabled = False
    End Sub


    ''' &lt;summary&gt;
    '''  Select Highlight color
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
    Private Sub panelColor_Click(sender As Object, e As EventArgs) Handles panelColor.Click
        Using colorDialog As New ColorDialog()
            colorDialog.Color = Me.panelColor.BackColor
            If colorDialog.ShowDialog() = DialogResult.OK Then
                Me.panelColor.BackColor = colorDialog.Color
            End If
        End Using
    End Sub


    ''' &lt;summary&gt;
    '''  Search the text and Highlight them in RichTextBox
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
    Private Sub btnSearchAndHighlight_Click(sender As Object, e As EventArgs) Handles btnSearchAndHighlight.Click
        Dim isexist As Boolean = rtbSource.Highlight(cboSearch.Text, panelColor.BackColor, chkMatchCase.Checked, chkMatchWholeWord.Checked)


        If Not isexist Then
            Dim format As String = String.Format(&quot;Can't find the &quot;&quot;{0}&quot;&quot; in RichTextBox control&quot;, cboSearch.Text)
            MessageBox.Show(format)
        End If
        If Not cboSearch.Items.Contains(cboSearch.Text) Then
            Me.cboSearch.Items.Add(Me.cboSearch.Text)
        End If
    End Sub


    ''' &lt;summary&gt;
    '''  The Event for Text change in ComboBox Control
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
    Private Sub cboSearch_TextChanged(sender As Object, e As EventArgs) Handles cboSearch.TextChanged
        ' Disable the SearchAndHightlight button
        If cboSearch.Text.Length = 0 Then
            Me.btnSearchAndHighlight.Enabled = False
        Else
            ' Enable the SearchAndHightlight button
            Me.btnSearchAndHighlight.Enabled = True
        End If
    End Sub


    ''' &lt;summary&gt;
    '''  Key Press event 
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
    Private Sub cboSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboSearch.KeyPress
        If e.KeyChar = ChrW(13) Then
            btnSearchAndHighlight.PerformClick()
        End If
    End Sub


End Class


</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><a href="http://msdn.microsoft.com/en-us/library/3134f2f7.aspx">RichTextBox.Find Method</a>
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><a href="http://msdn.microsoft.com/en-us/library/f3fk1e1k(v=vs.90).aspx">ColorDialog Class</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

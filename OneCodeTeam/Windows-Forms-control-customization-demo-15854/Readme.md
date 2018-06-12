# Windows Forms control customization demo (VBWinFormControls)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows Forms
## Topics
* Controls
## IsPublished
* True
## ModifiedDate
* 2012-03-01 11:41:09
## Description

<h1><span style="font-family:������">WINDOWS FORMS APPLICATION</span> (<span style="font-family:������">VBWinFormControls</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The Control Customization sample demonstrates how to customize the Windows Forms controls.
</p>
<p class="MsoNormal">In this sample, there're 4 examples: </p>
<p class="MsoNormal">1. Multiple Column ComboBox. </p>
<p class="MsoNormal">2. ListBox Items <span class="GramE">With</span> Different ToolTips.
</p>
<p class="MsoNormal">3. Numeric-only TextBox. </p>
<p class="MsoNormal">4. A Round Button. </p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoNormal">1. Multiple Column ComboBox. </p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>Demonstrates how to display multiple columns of data in the dropdown of a ComboBox.<span style="">
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53203/1/image.png" alt="" width="576" height="391" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal">2. ListBox Items With Different ToolTips. </p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>Demonstrates how to display different tooltips on each items of the ListBox.<span style="">
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53204/1/image.png" alt="" width="576" height="391" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal">3. Numeric-only TextBox. </p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>Demonstrates how to make a TextBox only accepts numbers.<span style="">
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53205/1/image.png" alt="" width="576" height="391" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal">4. A Round Button. </p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>Demonstrates how to create a Button with irregular shape.<span style="">&nbsp;
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53206/1/image.png" alt="" width="576" height="391" align="middle">
</span><span style=""></span></p>
<h2><span style="">Using the code</span> </h2>
<p class="MsoNormal">1. Example 1: &quot;Multiple Column ComboBox&quot;. </p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>1). Create a DataTable with several columns and rows of data;
</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>2). Data bind the ComboBox control to the DataTable;
</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>3). Enable the owner draw on ComboBox by setting the DrawMode property to DrawMode.OwnerDrawFixed;
</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>4). Handle the DrawItem event on the ComboBox;<span style="">
</span></p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>5). In the DrawItem event handler, compute the bounds for each column and draw corresponding value for each column on its bounds.<span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub MultipleColumnComboBox()
        Dim dtTest As DataTable = New DataTable()
        dtTest.Columns.Add(&quot;ID&quot;, GetType(Integer))
        dtTest.Columns.Add(&quot;Name&quot;, GetType(String))


        dtTest.Rows.Add(1, &quot;John&quot;)
        dtTest.Rows.Add(2, &quot;Amy&quot;)
        dtTest.Rows.Add(3, &quot;Tony&quot;)
        dtTest.Rows.Add(4, &quot;Bruce&quot;)
        dtTest.Rows.Add(5, &quot;Allen&quot;)


        ' Bind the ComboBox to the DataTable
        Me.comboBox1.DataSource = dtTest
        Me.comboBox1.DisplayMember = &quot;Name&quot;
        Me.comboBox1.ValueMember = &quot;ID&quot;


        ' Enable the owner draw on the ComboBox.
        Me.comboBox1.DrawMode = DrawMode.OwnerDrawFixed
        ' Handle the DrawItem event to draw the items.
    End Sub


    Private Sub comboBox1_DrawItem(ByVal sender As System.Object, _
                                   ByVal e As System.Windows.Forms.DrawItemEventArgs) _
                                   Handles comboBox1.DrawItem
        ' Draw the default background
        e.DrawBackground()


        ' The ComboBox is bound to a DataTable,
        ' so the items are DataRowView objects.
        Dim drv As DataRowView = CType(comboBox1.Items(e.Index), DataRowView)


        ' Retrieve the value of each column.
        Dim id As Integer = drv(&quot;ID&quot;).ToString()
        Dim name As String = drv(&quot;Name&quot;).ToString()


        ' Get the bounds for the first column
        Dim r1 As Rectangle = e.Bounds
        r1.Width = r1.Width / 2


        ' Draw the text on the first column
        Using sb As SolidBrush = New SolidBrush(e.ForeColor)
            e.Graphics.DrawString(id, e.Font, sb, r1)
        End Using


        ' Draw a line to isolate the columns 
        Using p As Pen = New Pen(Color.Black)
            e.Graphics.DrawLine(p, r1.Right, 0, r1.Right, r1.Bottom)
        End Using


        ' Get the bounds for the second column
        Dim r2 As Rectangle = e.Bounds
        r2.X = e.Bounds.Width / 2
        r2.Width = r2.Width / 2


        ' Draw the text on the second column
        Using sb As SolidBrush = New SolidBrush(e.ForeColor)
            e.Graphics.DrawString(name, e.Font, sb, r2)
        End Using
    End Sub

</pre>
<pre id="codePreview" class="vb">
Private Sub MultipleColumnComboBox()
        Dim dtTest As DataTable = New DataTable()
        dtTest.Columns.Add(&quot;ID&quot;, GetType(Integer))
        dtTest.Columns.Add(&quot;Name&quot;, GetType(String))


        dtTest.Rows.Add(1, &quot;John&quot;)
        dtTest.Rows.Add(2, &quot;Amy&quot;)
        dtTest.Rows.Add(3, &quot;Tony&quot;)
        dtTest.Rows.Add(4, &quot;Bruce&quot;)
        dtTest.Rows.Add(5, &quot;Allen&quot;)


        ' Bind the ComboBox to the DataTable
        Me.comboBox1.DataSource = dtTest
        Me.comboBox1.DisplayMember = &quot;Name&quot;
        Me.comboBox1.ValueMember = &quot;ID&quot;


        ' Enable the owner draw on the ComboBox.
        Me.comboBox1.DrawMode = DrawMode.OwnerDrawFixed
        ' Handle the DrawItem event to draw the items.
    End Sub


    Private Sub comboBox1_DrawItem(ByVal sender As System.Object, _
                                   ByVal e As System.Windows.Forms.DrawItemEventArgs) _
                                   Handles comboBox1.DrawItem
        ' Draw the default background
        e.DrawBackground()


        ' The ComboBox is bound to a DataTable,
        ' so the items are DataRowView objects.
        Dim drv As DataRowView = CType(comboBox1.Items(e.Index), DataRowView)


        ' Retrieve the value of each column.
        Dim id As Integer = drv(&quot;ID&quot;).ToString()
        Dim name As String = drv(&quot;Name&quot;).ToString()


        ' Get the bounds for the first column
        Dim r1 As Rectangle = e.Bounds
        r1.Width = r1.Width / 2


        ' Draw the text on the first column
        Using sb As SolidBrush = New SolidBrush(e.ForeColor)
            e.Graphics.DrawString(id, e.Font, sb, r1)
        End Using


        ' Draw a line to isolate the columns 
        Using p As Pen = New Pen(Color.Black)
            e.Graphics.DrawLine(p, r1.Right, 0, r1.Right, r1.Bottom)
        End Using


        ' Get the bounds for the second column
        Dim r2 As Rectangle = e.Bounds
        r2.X = e.Bounds.Width / 2
        r2.Width = r2.Width / 2


        ' Draw the text on the second column
        Using sb As SolidBrush = New SolidBrush(e.ForeColor)
            e.Graphics.DrawString(name, e.Font, sb, r2)
        End Using
    End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">2. Example 2: &quot;ListBox Items <span class="GramE">With</span> Different ToolTips&quot;.
</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>1). Add some items to the ListBox control;
</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>2). Handle the MouseMove event on the ListBox control;
</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>3). Call the ListBox.IndexFromPoint method to retrieve the item index at where the mouse hovers;
</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>4). If the mouse is over the items, call ToolTip.SetToolTip method to display a tooltip for the individual item.<span style="">&nbsp;&nbsp;
</span><span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
   Private Sub ListBoxWithDiffToolTips()
       ' Setup the ListBox items
       Me.listBox1.Items.Add(&quot;Item1&quot;)
       Me.listBox1.Items.Add(&quot;Item2&quot;)
       Me.listBox1.Items.Add(&quot;Item3&quot;)
       Me.listBox1.Items.Add(&quot;Item4&quot;)
       Me.listBox1.Items.Add(&quot;Item5&quot;)
   End Sub


   Private Sub listBox1_MouseMove(ByVal sender As System.Object, _
                   ByVal e As System.Windows.Forms.MouseEventArgs) _
                                  Handles listBox1.MouseMove
       Dim hoverIndex As Integer = Me.listBox1.IndexFromPoint(e.Location)


       If hoverIndex &gt;= 0 And hoverIndex &lt; listBox1.Items.Count Then
           Me.toolTip1.SetToolTip(listBox1, listBox1.Items(hoverIndex).ToString())
       End If
   End Sub

</pre>
<pre id="codePreview" class="vb">
   Private Sub ListBoxWithDiffToolTips()
       ' Setup the ListBox items
       Me.listBox1.Items.Add(&quot;Item1&quot;)
       Me.listBox1.Items.Add(&quot;Item2&quot;)
       Me.listBox1.Items.Add(&quot;Item3&quot;)
       Me.listBox1.Items.Add(&quot;Item4&quot;)
       Me.listBox1.Items.Add(&quot;Item5&quot;)
   End Sub


   Private Sub listBox1_MouseMove(ByVal sender As System.Object, _
                   ByVal e As System.Windows.Forms.MouseEventArgs) _
                                  Handles listBox1.MouseMove
       Dim hoverIndex As Integer = Me.listBox1.IndexFromPoint(e.Location)


       If hoverIndex &gt;= 0 And hoverIndex &lt; listBox1.Items.Count Then
           Me.toolTip1.SetToolTip(listBox1, listBox1.Items(hoverIndex).ToString())
       End If
   End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">3. Example 3: &quot;Numeric-only TextBox&quot;. </p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>The make a TextBox accepts only numbers, we can handle the TextBox.KeyPress event, in the event handler use char.IsNumber method to filter the input keys.<span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
    Private Sub textBox1_KeyPress(ByVal sender As System.Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                                 Handles textBox1.KeyPress
       If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = vbBack) Then
           e.Handled = True
       End If
   End Sub

</pre>
<pre id="codePreview" class="vb">
    Private Sub textBox1_KeyPress(ByVal sender As System.Object, _
                   ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                                 Handles textBox1.KeyPress
       If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = vbBack) Then
           e.Handled = True
       End If
   End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>4. Example 4: &quot;A Round Button&quot;.
</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>The key point of creating a round button is changing its Region property.
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">   
Public Class RoundButton
    Inherits Button


    Protected Overrides Sub OnPaint(ByVal pevent As System.Windows.Forms.PaintEventArgs)
        Dim path As GraphicsPath = New GraphicsPath()
        path.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height)
        Me.Region = New Region(path)
        MyBase.OnPaint(pevent)
    End Sub
End Class

</pre>
<pre id="codePreview" class="vb">   
Public Class RoundButton
    Inherits Button


    Protected Overrides Sub OnPaint(ByVal pevent As System.Windows.Forms.PaintEventArgs)
        Dim path As GraphicsPath = New GraphicsPath()
        path.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height)
        Me.Region = New Region(path)
        MyBase.OnPaint(pevent)
    End Sub
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://social.msdn.microsoft.com/Forums/en-US/winforms/thread/77a66f05-804e-4d58-8214-0c32d8f43191">Windows Forms General FAQ.</a><span style="">&nbsp;
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/aa289517.aspx">Shaped Windows Forms and Controls in Visual Studio .NET</a><span style="">&nbsp;&nbsp;
</span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://www.codeproject.com/KB/buttons/RoundButton_csharp.aspx">Round Button in C#</a><span style="">&nbsp;&nbsp;
</span></p>
<p class="MsoListParagraphCxSpLast"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

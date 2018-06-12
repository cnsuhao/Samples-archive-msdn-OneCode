# Databinding in Windows Forms demo (VBWinFormDataBinding)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* Windows Forms
## Topics
* Data Binding
## IsPublished
* True
## ModifiedDate
* 2012-03-04 08:07:53
## Description

<h1><span style="font-family:������">WINDOWS FORMS APPLICATION</span> (<span style="font-family:������">VBWinFormDtaBinding</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The <span style="">VB</span>WinFormDataBinding sample demonstrates the Windows Forms Data Binding technology. It shows how to perform simple binding and complex binding in a Windows Forms application. It also shows how to navigate through
 items in a data source<span style="">. </span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53685/1/image.png" alt="" width="576" height="569" align="middle">
</span><span style="">&nbsp;</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">1. Simple binding example 1.</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>This example binds TextBox.Text property to CheckBox.Checked property using simple binding, so that when the CheckBox is checked, the TextBox shows<span style="">&nbsp;
</span>&quot;true&quot;, otherwise shows &quot;false&quot;.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub SimpleBindingExp1()
    ' In this example the CheckBox is the data source
    Me.textBox1.DataBindings.Add(&quot;Text&quot;, Me.checkBox1, &quot;Checked&quot;)
End Sub

</pre>
<pre id="codePreview" class="vb">
Private Sub SimpleBindingExp1()
    ' In this example the CheckBox is the data source
    Me.textBox1.DataBindings.Add(&quot;Text&quot;, Me.checkBox1, &quot;Checked&quot;)
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">2. Simple binding example 2.</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>This example binds TextBox.Text property to Form.Size property using simple<span style="">&nbsp;
</span>binding with update mode set to DataSourceUpdateMode.Never, so that the data source won't update unless we explicitly call the Binding.WriteValue() method.<span style="">&nbsp;&nbsp;
</span><span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub SimpleBindingExp2()
    ' In this example the Form itself is the data source.
    ' With the update mode set to DataSourceUpdateMode.Never the data source won't
    ' update unless we explicitly call the Binding.WriteValue() method.
    Dim bdSize As Binding = New Binding(&quot;Text&quot;, Me, &quot;Size&quot;, True, DataSourceUpdateMode.Never)
    Me.textBox2.DataBindings.Add(bdSize)
End Sub


Private Sub btnSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSet.Click
    Dim bdSize As Binding = textBox2.DataBindings(0)
    ' Force the value to store in the data source
    bdSize.WriteValue()
End Sub

</pre>
<pre id="codePreview" class="vb">
Private Sub SimpleBindingExp2()
    ' In this example the Form itself is the data source.
    ' With the update mode set to DataSourceUpdateMode.Never the data source won't
    ' update unless we explicitly call the Binding.WriteValue() method.
    Dim bdSize As Binding = New Binding(&quot;Text&quot;, Me, &quot;Size&quot;, True, DataSourceUpdateMode.Never)
    Me.textBox2.DataBindings.Add(bdSize)
End Sub


Private Sub btnSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSet.Click
    Dim bdSize As Binding = textBox2.DataBindings(0)
    ' Force the value to store in the data source
    bdSize.WriteValue()
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">3. Simple binding example 3.</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>This example binds TextBox.Text property to one of the fields of a DataTable.<span style="">
</span></p>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create a DataTable with two columns and several rows of data.<span style="">&nbsp;&nbsp;
</span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">2)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Bind TextBox.Text property to one of the fields of the DataTable through a<span style="">&nbsp;&nbsp;
</span>BindingSource object.<span style="">&nbsp;&nbsp; </span></p>
<p class="MsoListParagraphCxSpLast" style=""><span style=""><span style="">3)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Call BindingSource.MovePrevious, BindingSource.MoveNext methods to navigate<span style="">&nbsp;
</span>through the records.<span style=""> </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Sub SimpleBindingExp3()


        '  DataSource setup:
        '  
        '  Create a Table named Test and add 2 columns
        '   ID:     int
        '   Name:   string        '
        Dim dtTest As DataTable = New DataTable()
        dtTest.Columns.Add(&quot;ID&quot;, GetType(Integer))
        dtTest.Columns.Add(&quot;Name&quot;, GetType(String))


        dtTest.Rows.Add(1, &quot;John&quot;)
        dtTest.Rows.Add(2, &quot;Amy&quot;)
        dtTest.Rows.Add(3, &quot;Tony&quot;)


        Dim bsTest As BindingSource = New BindingSource()
        bsTest.DataSource = dtTest


        ' Bind the TextBoxes
        Me.textBox3.DataBindings.Add(&quot;Text&quot;, bsTest, &quot;ID&quot;)
        Me.textBox4.DataBindings.Add(&quot;Text&quot;, bsTest, &quot;Name&quot;)
    End Sub


    ' Handle the button's click event to navigate the binding.
    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        Dim bsTest As BindingSource = CType(textBox3.DataBindings(0).DataSource, BindingSource)
        bsTest.MovePrevious()
    End Sub


    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Dim bsTest As BindingSource = CType(textBox3.DataBindings(0).DataSource, BindingSource)
        bsTest.MoveNext()
    End Sub

</pre>
<pre id="codePreview" class="vb">
Public Sub SimpleBindingExp3()


        '  DataSource setup:
        '  
        '  Create a Table named Test and add 2 columns
        '   ID:     int
        '   Name:   string        '
        Dim dtTest As DataTable = New DataTable()
        dtTest.Columns.Add(&quot;ID&quot;, GetType(Integer))
        dtTest.Columns.Add(&quot;Name&quot;, GetType(String))


        dtTest.Rows.Add(1, &quot;John&quot;)
        dtTest.Rows.Add(2, &quot;Amy&quot;)
        dtTest.Rows.Add(3, &quot;Tony&quot;)


        Dim bsTest As BindingSource = New BindingSource()
        bsTest.DataSource = dtTest


        ' Bind the TextBoxes
        Me.textBox3.DataBindings.Add(&quot;Text&quot;, bsTest, &quot;ID&quot;)
        Me.textBox4.DataBindings.Add(&quot;Text&quot;, bsTest, &quot;Name&quot;)
    End Sub


    ' Handle the button's click event to navigate the binding.
    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        Dim bsTest As BindingSource = CType(textBox3.DataBindings(0).DataSource, BindingSource)
        bsTest.MovePrevious()
    End Sub


    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Dim bsTest As BindingSource = CType(textBox3.DataBindings(0).DataSource, BindingSource)
        bsTest.MoveNext()
    End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>4. Complex binding example 1.</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>This example demonstrates how to display data from database in a DataGridView by Visual Studio designer.<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>Steps:<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Click the smart tag glyph (Smart Tag Glyph) on the upper-right corner of the DataGridView control.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">2)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Click the drop-down arrow for the Choose Data Source option.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">3)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>If your project does not already have a data source, click &quot;Add Project Data Source..&quot; and follow the steps indicated by the wizard.
</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">4)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Expand the Other Data Sources and Project Data Sources nodes if they are not already expanded, and then select the data source to bind the control to.
</p>
<p class="MsoListParagraphCxSpLast" style=""><span style=""><span style="">5)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>If your data source contains more than one member, such as if you have created a DataSet that contains multiple tables, expand the data source, and then select the specific member to bind to.
</p>
<p class="MsoNormal">5. Complex binding example 2.<span style="">&nbsp;&nbsp; </span>
</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>This example uses business objects as data source for data binding.<span style="">&nbsp;&nbsp;
</span><span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub ComplexBindingExp2()
    ' Data Source Setup:
    Dim blc As BindingList(Of Customer) = New BindingList(Of Customer)()
    blc.Add(New Customer(1, &quot;John&quot;, 10.0))
    blc.Add(New Customer(2, &quot;Amy&quot;, 15.0))
    blc.Add(New Customer(3, &quot;Tony&quot;, 20.0))


    ' Bind the DataGridView to the list of Customers using complex binding.
    Me.dataGridView2.DataSource = blc
End Sub

</pre>
<pre id="codePreview" class="vb">
Private Sub ComplexBindingExp2()
    ' Data Source Setup:
    Dim blc As BindingList(Of Customer) = New BindingList(Of Customer)()
    blc.Add(New Customer(1, &quot;John&quot;, 10.0))
    blc.Add(New Customer(2, &quot;Amy&quot;, 15.0))
    blc.Add(New Customer(3, &quot;Tony&quot;, 20.0))


    ' Bind the DataGridView to the list of Customers using complex binding.
    Me.dataGridView2.DataSource = blc
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">6. Complex binding example 3.</p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp; </span>This example demonstrates how to perform Master/Detail binding in Windows Forms.<span style="">&nbsp;&nbsp;
</span></p>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create a master DataTable and a detail DataTable.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">2)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Add some records to both tables.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">3)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create a DataSet object to hold both table.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">4)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Add a relationship to he DataSet.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">5)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create two BindingSource objects, one for the master table, the other for the corresponding detail records.</p>
<p class="MsoListParagraphCxSpLast" style=""><span style=""><span style="">6)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Use the BindingSource objects to bind the DataGridView controls.<span style="">&nbsp;&nbsp;
</span><span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
    Public Sub ComplexBindingExp3()
        ' Data Source Setup:
        Dim dtMaster As DataTable = New DataTable(&quot;Customer&quot;)
        Dim dtDetail As DataTable = New DataTable(&quot;Order&quot;)
        dtMaster.Columns.Add(&quot;CustomerID&quot;, GetType(Integer))
        dtMaster.Columns.Add(&quot;CustomerName&quot;, GetType(String))


        dtDetail.Columns.Add(&quot;OrderID&quot;, GetType(Integer))
        dtDetail.Columns.Add(&quot;OrderDate&quot;, GetType(DateTime))
        dtDetail.Columns.Add(&quot;CustomerID&quot;, GetType(Integer))


        For j As Integer = 0 To 5 - 1
            dtMaster.Rows.Add(j, &quot;Customer &quot; &#43; j.ToString())
            dtDetail.Rows.Add(j, DateTime.Now.AddDays(j), j)
            dtDetail.Rows.Add(j &#43; 5, DateTime.Now.AddDays(j &#43; 5), j)
        Next


        ' Create a DataSet to hold the two DataTables
        Dim ds As DataSet = New DataSet()
        ds.Tables.Add(dtMaster)
        ds.Tables.Add(dtDetail)


        ' Add a relationship to the DataSet
        ds.Relations.Add(&quot;CustomerOrder&quot;, _
            ds.Tables(&quot;Customer&quot;).Columns(&quot;CustomerID&quot;), _
            ds.Tables(&quot;Order&quot;).Columns(&quot;CustomerID&quot;))


        Dim bsMaster As BindingSource = New BindingSource()
        bsMaster.DataSource = ds
        bsMaster.DataMember = &quot;Customer&quot;


        Dim bsDetail As BindingSource = New BindingSource()
        ' Bind the details data connector to the master data connector,
        ' using the DataRelation name to filter the information in the
        ' details table based on the current row in the master table.
        bsDetail.DataSource = bsMaster
        bsDetail.DataMember = &quot;CustomerOrder&quot;


        Me.dgvMaster.DataSource = bsMaster
        Me.dgvDetail.DataSource = bsDetail
    End Sub

</pre>
<pre id="codePreview" class="vb">
    Public Sub ComplexBindingExp3()
        ' Data Source Setup:
        Dim dtMaster As DataTable = New DataTable(&quot;Customer&quot;)
        Dim dtDetail As DataTable = New DataTable(&quot;Order&quot;)
        dtMaster.Columns.Add(&quot;CustomerID&quot;, GetType(Integer))
        dtMaster.Columns.Add(&quot;CustomerName&quot;, GetType(String))


        dtDetail.Columns.Add(&quot;OrderID&quot;, GetType(Integer))
        dtDetail.Columns.Add(&quot;OrderDate&quot;, GetType(DateTime))
        dtDetail.Columns.Add(&quot;CustomerID&quot;, GetType(Integer))


        For j As Integer = 0 To 5 - 1
            dtMaster.Rows.Add(j, &quot;Customer &quot; &#43; j.ToString())
            dtDetail.Rows.Add(j, DateTime.Now.AddDays(j), j)
            dtDetail.Rows.Add(j &#43; 5, DateTime.Now.AddDays(j &#43; 5), j)
        Next


        ' Create a DataSet to hold the two DataTables
        Dim ds As DataSet = New DataSet()
        ds.Tables.Add(dtMaster)
        ds.Tables.Add(dtDetail)


        ' Add a relationship to the DataSet
        ds.Relations.Add(&quot;CustomerOrder&quot;, _
            ds.Tables(&quot;Customer&quot;).Columns(&quot;CustomerID&quot;), _
            ds.Tables(&quot;Order&quot;).Columns(&quot;CustomerID&quot;))


        Dim bsMaster As BindingSource = New BindingSource()
        bsMaster.DataSource = ds
        bsMaster.DataMember = &quot;Customer&quot;


        Dim bsDetail As BindingSource = New BindingSource()
        ' Bind the details data connector to the master data connector,
        ' using the DataRelation name to filter the information in the
        ' details table based on the current row in the master table.
        bsDetail.DataSource = bsMaster
        bsDetail.DataMember = &quot;CustomerOrder&quot;


        Me.dgvMaster.DataSource = bsMaster
        Me.dgvDetail.DataSource = bsDetail
    End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information<span style=""> </span></h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://support.microsoft.com/kb/313482">Roadmap for Windows Forms data binding</a><span style="">&nbsp;&nbsp;
</span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/ef2xyb33.aspx">Windows Forms Data Binding</a><span style="">&nbsp;
</span></p>
<p class="MsoListParagraphCxSpLast" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://social.msdn.microsoft.com/Forums/en-US/winformsdatacontrols/thread/a44622c0-74e1-463b-97b9-27b87513747e">Windows Forms Data Controls and Databinding FAQ</a><b><span style="">
</span></b></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

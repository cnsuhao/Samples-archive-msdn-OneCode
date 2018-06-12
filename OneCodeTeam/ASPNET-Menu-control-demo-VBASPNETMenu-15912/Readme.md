# ASP.NET Menu control demo (VBASPNETMenu)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* Controls
* Menu
## IsPublished
* True
## ModifiedDate
* 2012-03-04 07:59:13
## Description

<h1><a name="OLE_LINK2"></a><a name="OLE_LINK1"><span style="">ASP.NET Menu Control (</span></a>VBASPNETMenu)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The sample demonstrates how to bind the ASP.NET Menu Control to the Database. All the contents of the Menu control are generated dynamically, if we want to add some new navigation items into the website, we only need to insert some data
 to the database instead of modifying the source code. </p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Please follow these demonstration steps below.</p>
<p class="MsoNormal">Step 1:&nbsp;Open the VBASPNETMenu.sln. Expand the VBASPNETMenu web application and press Ctrl &#43; F5 to show the VBASPNETMenu.aspx.
</p>
<p class="MsoNormal">Step 2: We will see a Menu control on the page, you can click the Menu items and jump to the Test.aspx page.</p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;</span> <img src="/site/view/file/53631/1/image.png" alt="" width="533" height="372" align="middle">
</span></p>
<p class="MsoNormal">Step 3: If you want to change the url string variables to your website��s pages, you need to modify the DataTable object in the code-bebind page (VBASPNETMenu.aspx.vb). Perhaps we need a table in DataBase for managing menu items content
 and navigator url, you can also create a database file to constitute a DataTable like this sample.<span style="">&nbsp;
</span></p>
<p class="MsoNormal">Step 4: Validation finished.</p>
<h2>Using the Code</h2>
<p class="MsoNormal">Code Logical: </p>
<p class="MsoNormal">Step 1. Create a VB &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or Visual Web Developer 2010. Name it as &quot;VBASPNETMenu &quot;. The project includes two web form pages for demonstrating how to bind Menu control
 with a DataTable variable.</p>
<p class="MsoNormal">Step 2. Add two web form pages in the root directory of the application, name them as ��VBASPNETMenu.aspx��, ��Test.aspx��. The VBASPNETMenu page is used to show Menu control and redirect to the Test page by clicking the items of Menu.</p>
<p class="MsoNormal">Step 3. Drag and Drop a Menu control to the VBASPNETMenu page, you can set the styles of the Menu to make it looks better. Then you can begin to write VB code for generating DataTable variable and bind it to the Menu control, in this
 sample, we create a GetData() method to generate data. </p>
<h3>The following code is used to generate a DataTable variable and fill it with some default value:<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Function GetData() As DataSet
    ' In order to test, we use the memory tables as the datasource.
    Dim mainTB As New DataTable()
    Dim mainIdCol As New DataColumn(&quot;mainId&quot;)
    Dim mainNameCol As New DataColumn(&quot;mainName&quot;)
    Dim mainUrlCol As New DataColumn(&quot;mainUrl&quot;)
    mainTB.Columns.Add(mainIdCol)
    mainTB.Columns.Add(mainNameCol)
    mainTB.Columns.Add(mainUrlCol)


    Dim childTB As New DataTable()
    Dim childIdCol As New DataColumn(&quot;childId&quot;)
    Dim childNameCol As New DataColumn(&quot;childName&quot;)


    ' The MainId column of the child table is the foreign key to the main table.
    Dim childMainIdCol As New DataColumn(&quot;MainId&quot;)
    Dim childUrlCol As New DataColumn(&quot;childUrl&quot;)


    childTB.Columns.Add(childIdCol)
    childTB.Columns.Add(childNameCol)
    childTB.Columns.Add(childMainIdCol)
    childTB.Columns.Add(childUrlCol)




    ' Insert some test records to the main table.
    Dim dr As DataRow = mainTB.NewRow()
    dr(0) = &quot;1&quot;
    dr(1) = &quot;Home&quot;
    dr(2) = &quot;Test.aspx&quot;
    mainTB.Rows.Add(dr)
    Dim dr1 As DataRow = mainTB.NewRow()
    dr1(0) = &quot;2&quot;
    dr1(1) = &quot;Articles&quot;
    dr1(2) = &quot;Test.aspx&quot;
    mainTB.Rows.Add(dr1)
    Dim dr2 As DataRow = mainTB.NewRow()
    dr2(0) = &quot;3&quot;
    dr2(1) = &quot;Help&quot;
    dr2(2) = &quot;Test.aspx&quot;
    mainTB.Rows.Add(dr2)
    Dim dr3 As DataRow = mainTB.NewRow()
    dr3(0) = &quot;4&quot;
    dr3(1) = &quot;DownLoad&quot;
    dr3(2) = &quot;Test.aspx&quot;
    mainTB.Rows.Add(dr3)




    ' Insert some test records to the child table
    Dim dr5 As DataRow = childTB.NewRow()
    dr5(0) = &quot;1&quot;
    dr5(1) = &quot;ASP.NET&quot;
    dr5(2) = &quot;2&quot;
    dr5(3) = &quot;Test.aspx&quot;
    childTB.Rows.Add(dr5)
    Dim dr6 As DataRow = childTB.NewRow()
    dr6(0) = &quot;2&quot;
    dr6(1) = &quot;SQL Server&quot;
    dr6(2) = &quot;2&quot;
    dr6(3) = &quot;Test.aspx&quot;
    childTB.Rows.Add(dr6)
    Dim dr7 As DataRow = childTB.NewRow()
    dr7(0) = &quot;3&quot;
    dr7(1) = &quot;JavaScript&quot;
    dr7(2) = &quot;2&quot;
    dr7(3) = &quot;Test.aspx&quot;
    childTB.Rows.Add(dr7)


    ' Use the DataSet to contain that two tables.
    Dim ds As New DataSet()
    ds.Tables.Add(mainTB)
    ds.Tables.Add(childTB)


    ' Build the relation between the main table and the child table.
    ds.Relations.Add(&quot;Child&quot;, ds.Tables(0).Columns(&quot;mainId&quot;), ds.Tables(1).Columns(&quot;MainId&quot;))




    Return ds
End Function

</pre>
<pre id="codePreview" class="vb">
Public Function GetData() As DataSet
    ' In order to test, we use the memory tables as the datasource.
    Dim mainTB As New DataTable()
    Dim mainIdCol As New DataColumn(&quot;mainId&quot;)
    Dim mainNameCol As New DataColumn(&quot;mainName&quot;)
    Dim mainUrlCol As New DataColumn(&quot;mainUrl&quot;)
    mainTB.Columns.Add(mainIdCol)
    mainTB.Columns.Add(mainNameCol)
    mainTB.Columns.Add(mainUrlCol)


    Dim childTB As New DataTable()
    Dim childIdCol As New DataColumn(&quot;childId&quot;)
    Dim childNameCol As New DataColumn(&quot;childName&quot;)


    ' The MainId column of the child table is the foreign key to the main table.
    Dim childMainIdCol As New DataColumn(&quot;MainId&quot;)
    Dim childUrlCol As New DataColumn(&quot;childUrl&quot;)


    childTB.Columns.Add(childIdCol)
    childTB.Columns.Add(childNameCol)
    childTB.Columns.Add(childMainIdCol)
    childTB.Columns.Add(childUrlCol)




    ' Insert some test records to the main table.
    Dim dr As DataRow = mainTB.NewRow()
    dr(0) = &quot;1&quot;
    dr(1) = &quot;Home&quot;
    dr(2) = &quot;Test.aspx&quot;
    mainTB.Rows.Add(dr)
    Dim dr1 As DataRow = mainTB.NewRow()
    dr1(0) = &quot;2&quot;
    dr1(1) = &quot;Articles&quot;
    dr1(2) = &quot;Test.aspx&quot;
    mainTB.Rows.Add(dr1)
    Dim dr2 As DataRow = mainTB.NewRow()
    dr2(0) = &quot;3&quot;
    dr2(1) = &quot;Help&quot;
    dr2(2) = &quot;Test.aspx&quot;
    mainTB.Rows.Add(dr2)
    Dim dr3 As DataRow = mainTB.NewRow()
    dr3(0) = &quot;4&quot;
    dr3(1) = &quot;DownLoad&quot;
    dr3(2) = &quot;Test.aspx&quot;
    mainTB.Rows.Add(dr3)




    ' Insert some test records to the child table
    Dim dr5 As DataRow = childTB.NewRow()
    dr5(0) = &quot;1&quot;
    dr5(1) = &quot;ASP.NET&quot;
    dr5(2) = &quot;2&quot;
    dr5(3) = &quot;Test.aspx&quot;
    childTB.Rows.Add(dr5)
    Dim dr6 As DataRow = childTB.NewRow()
    dr6(0) = &quot;2&quot;
    dr6(1) = &quot;SQL Server&quot;
    dr6(2) = &quot;2&quot;
    dr6(3) = &quot;Test.aspx&quot;
    childTB.Rows.Add(dr6)
    Dim dr7 As DataRow = childTB.NewRow()
    dr7(0) = &quot;3&quot;
    dr7(1) = &quot;JavaScript&quot;
    dr7(2) = &quot;2&quot;
    dr7(3) = &quot;Test.aspx&quot;
    childTB.Rows.Add(dr7)


    ' Use the DataSet to contain that two tables.
    Dim ds As New DataSet()
    ds.Tables.Add(mainTB)
    ds.Tables.Add(childTB)


    ' Build the relation between the main table and the child table.
    ds.Relations.Add(&quot;Child&quot;, ds.Tables(0).Columns(&quot;mainId&quot;), ds.Tables(1).Columns(&quot;MainId&quot;))




    Return ds
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal">Step 4. Then we need to create a GenerateMenuItem method for binding DataTable to the Menu control, and we need only execute this method when VBASPMETMenu page is loaded for the first time.</p>
<h3>The following code is used to bind DataTable to the Menu control when page is loaded for the first time.
</h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then
        GenerateMenuItem()
    End If
End Sub
Public Sub GenerateMenuItem()
    ' Get the data from database.
    Dim ds As DataSet = GetData()


    For Each mainRow As DataRow In ds.Tables(0).Rows
        ' Load the records from the main table to the menu control.
        Dim masterItem As New MenuItem(mainRow(&quot;mainName&quot;).ToString())
        masterItem.NavigateUrl = mainRow(&quot;mainUrl&quot;).ToString()
        Menu1.Items.Add(masterItem)


        For Each childRow As DataRow In mainRow.GetChildRows(&quot;Child&quot;)
            ' According to the relation of the main table and the child table, load the data from the child table.
            Dim childItem As New MenuItem(DirectCast(childRow(&quot;childName&quot;), String))
            childItem.NavigateUrl = childRow(&quot;childUrl&quot;).ToString()
            masterItem.ChildItems.Add(childItem)
        Next
    Next
End Sub

</pre>
<pre id="codePreview" class="vb">
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then
        GenerateMenuItem()
    End If
End Sub
Public Sub GenerateMenuItem()
    ' Get the data from database.
    Dim ds As DataSet = GetData()


    For Each mainRow As DataRow In ds.Tables(0).Rows
        ' Load the records from the main table to the menu control.
        Dim masterItem As New MenuItem(mainRow(&quot;mainName&quot;).ToString())
        masterItem.NavigateUrl = mainRow(&quot;mainUrl&quot;).ToString()
        Menu1.Items.Add(masterItem)


        For Each childRow As DataRow In mainRow.GetChildRows(&quot;Child&quot;)
            ' According to the relation of the main table and the child table, load the data from the child table.
            Dim childItem As New MenuItem(DirectCast(childRow(&quot;childName&quot;), String))
            childItem.NavigateUrl = childRow(&quot;childUrl&quot;).ToString()
            masterItem.ChildItems.Add(childItem)
        Next
    Next
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal">Step 5. Build the application and you can debug it.</p>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoListParagraph" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/ecs0x9w5(VS.80).aspx">ASP.NET Menu Control Overview</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

# Customized DropDownList.SelectedValue (VBASPNETSmartDropdownlist)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* Controls
* DropDownList
## IsPublished
* True
## ModifiedDate
* 2011-11-01 09:08:22
## Description

<h1>VBASPNETSmartDropdownlist Overview</h1>
<h2><span>Summary</span></h2>
<p>The code sample customizes the SelectedValue property of ASP.NET DropDownList control so that it handles the situation more nicely when the SelectedValue property is set to a value that does not exist in the DropDownList value collection.&nbsp; By default,
 an ArguementOutOfRangeException exception is thrown when SelectedValue is set invalidly.&nbsp; With the customization, the DropDownList will select a &quot;None&quot; item when the SelectedValue is invalid.</p>
<h2>Demo</h2>
<p>Please follow these demonstration steps below.</p>
<p>Step 1: Open the vbASPNETSmartDropdownlist.sln.</p>
<p>Step 2: Right click TestObjectDataSource.aspx.aspx and choose &quot;View in Browser&quot;.</p>
<p>Step 3: You will see a DropDownList and a GridView in the page, note the DropDwonList has four valid items while the GridView has six.</p>
<p>Step 4: If you click the &quot;Select DropDownList option&quot; button you may notice that the selected item of DropDownList will change accordingly to the related one.&nbsp;&nbsp; If the item which you selected by clicking button is not contained in DropDownList
 control, the selected item of DropDownList will be &quot;None&quot;.</p>
<p>Step 5: You can also change the selectedValue in page_load event.</p>
<p>Step 6: View and test the TestSqlDataSource.aspx.aspx page as the forward one.<br>
&nbsp; [Note]<br>
The two test page are ues Sql data source and Object data source to test&nbsp; this smart DropDownList control, the Sql data source is not means SqlDataSource control, it means generiec data source, we can convert it to DataTable variable, and object data source
 can convert to IEnumerable object variable.<br>
&nbsp; [/Note]</p>
<p>Step 7: Validation finished.</p>
<p>&nbsp;</p>
<h2>Implementation</h2>
<p>Step 1. Create a&nbsp;VB.NET &quot;ASP.NET Server Control&quot; in Visual Studio 2010 or Visual Web Developer 2010. Name it as &quot;VBASPNETSmartDropdownlist&quot;.</p>
<p>Step 2. Add a Server control and name it as &quot;CustomizedDropDownList.VB&quot;.</p>
<p>Step 3. Remove the Text property and override RenderContent method. Override the Render method, the VB.NET&nbsp;code as shown below:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        MyBase.Render(writer)
    End Sub</pre>
<div class="preview">
<pre class="vb">&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Render(<span class="visualBasic__keyword">ByVal</span>&nbsp;writer&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.Web.UI.HtmlTextWriter)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.Render(writer)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">Step 4. Override the SelectedValue property.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">    Public Overrides Property SelectedValue As String
        Get
            Return MyBase.SelectedValue
        End Get
        Set(ByVal value As String)
            ' If data source is SqlDataSource.
            If TypeOf DataSource Is DataView Then
                Dim dataView As DataView = TryCast(DataSource, DataView)
                Dim tabView As DataTable = dataView.Table
                Dim typeColumns As Type = tabView.Columns(DataValueField).DataType
                Dim rowFilter As String = String.Empty
                If typeColumns.Equals(Type.[GetType](&quot;System.String&quot;)) Then
                    rowFilter = String.Format(&quot;{0}='{1}'&quot;, DataValueField, value)
                ElseIf typeColumns.Equals(Type.[GetType](&quot;System.Int32&quot;)) OrElse typeColumns.Equals(Type.[GetType](&quot;System.Int64&quot;)) Then
                    rowFilter = String.Format(&quot;{0}={1}&quot;, DataValueField, value)
                Else
                    Throw New NotImplementedException(&quot;unsupported type&quot;)
                End If

                dataView.RowFilter = rowFilter
                If dataView.Count &lt;&gt; 0 Then
                    dataView.RowFilter = String.Empty
                    MyBase.SelectedValue = value
                Else
                    dataView.RowFilter = String.Empty
                    MyBase.SelectedValue = Items(0).Value
                End If
                ' If data source is ObjectDataSource
            ElseIf TypeOf DataSource Is IEnumerable Then
                Dim bolFlag As Boolean = False
                For Each obj As Object In TryCast(DataSource, IEnumerable)
                    Dim typeObj As Type = obj.[GetType]()
                    Dim info As PropertyInfo = typeObj.GetProperty(DataValueField)
                    Dim valueProperty As String = info.GetValue(obj, Nothing).ToString()
                    If valueProperty.Equals(value) Then
                        bolFlag = True
                        Exit For
                    End If
                Next

                If bolFlag Then
                    MyBase.SelectedValue = value
                Else
                    MyBase.SelectedValue = Items(0).Value
                End If
            End If

            ' If user change the selected value after postback.
            If DataSource Is Nothing Then
                Dim bolFlag As Boolean = False
                For i As Integer = 0 To Items.Count - 1
                    If Items(i).Value.Equals(value) Then
                        bolFlag = True
                        Exit For
                    End If
                Next
                If bolFlag Then
                    MyBase.SelectedValue = value
                Else
                    MyBase.SelectedValue = Items(0).Value
                End If
            End If

        End Set
    End Property</pre>
<div class="preview">
<pre class="vb">&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;SelectedValue&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">MyBase</span>.SelectedValue&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;If&nbsp;data&nbsp;source&nbsp;is&nbsp;SqlDataSource.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">TypeOf</span>&nbsp;DataSource&nbsp;<span class="visualBasic__keyword">Is</span>&nbsp;DataView&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dataView&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DataView&nbsp;=&nbsp;<span class="visualBasic__keyword">TryCast</span>(DataSource,&nbsp;DataView)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;tabView&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DataTable&nbsp;=&nbsp;dataView.Table&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;typeColumns&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Type&nbsp;=&nbsp;tabView.Columns(DataValueField).DataType&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;rowFilter&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">String</span>.Empty&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;typeColumns.Equals(Type.[<span class="visualBasic__keyword">GetType</span>](<span class="visualBasic__string">&quot;System.String&quot;</span>))&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowFilter&nbsp;=&nbsp;<span class="visualBasic__keyword">String</span>.Format(<span class="visualBasic__string">&quot;{0}='{1}'&quot;</span>,&nbsp;DataValueField,&nbsp;value)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;typeColumns.Equals(Type.[<span class="visualBasic__keyword">GetType</span>](<span class="visualBasic__string">&quot;System.Int32&quot;</span>))&nbsp;<span class="visualBasic__keyword">OrElse</span>&nbsp;typeColumns.Equals(Type.[<span class="visualBasic__keyword">GetType</span>](<span class="visualBasic__string">&quot;System.Int64&quot;</span>))&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowFilter&nbsp;=&nbsp;<span class="visualBasic__keyword">String</span>.Format(<span class="visualBasic__string">&quot;{0}={1}&quot;</span>,&nbsp;DataValueField,&nbsp;value)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Throw</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;NotImplementedException(<span class="visualBasic__string">&quot;unsupported&nbsp;type&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataView.RowFilter&nbsp;=&nbsp;rowFilter&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;dataView.Count&nbsp;&lt;&gt;&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataView.RowFilter&nbsp;=&nbsp;<span class="visualBasic__keyword">String</span>.Empty&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.SelectedValue&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataView.RowFilter&nbsp;=&nbsp;<span class="visualBasic__keyword">String</span>.Empty&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.SelectedValue&nbsp;=&nbsp;Items(<span class="visualBasic__number">0</span>).Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;If&nbsp;data&nbsp;source&nbsp;is&nbsp;ObjectDataSource</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;<span class="visualBasic__keyword">TypeOf</span>&nbsp;DataSource&nbsp;<span class="visualBasic__keyword">Is</span>&nbsp;IEnumerable&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;bolFlag&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;obj&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;<span class="visualBasic__keyword">TryCast</span>(DataSource,&nbsp;IEnumerable)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;typeObj&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Type&nbsp;=&nbsp;obj.[<span class="visualBasic__keyword">GetType</span>]()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;info&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;PropertyInfo&nbsp;=&nbsp;typeObj.GetProperty(DataValueField)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;valueProperty&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;info.GetValue(obj,&nbsp;<span class="visualBasic__keyword">Nothing</span>).ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;valueProperty.Equals(value)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bolFlag&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;bolFlag&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.SelectedValue&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.SelectedValue&nbsp;=&nbsp;Items(<span class="visualBasic__number">0</span>).Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;If&nbsp;user&nbsp;change&nbsp;the&nbsp;selected&nbsp;value&nbsp;after&nbsp;postback.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;DataSource&nbsp;<span class="visualBasic__keyword">Is</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;bolFlag&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;i&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;Items.Count&nbsp;-&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;Items(i).Value.Equals(value)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bolFlag&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;bolFlag&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.SelectedValue&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.SelectedValue&nbsp;=&nbsp;Items(<span class="visualBasic__number">0</span>).Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span></pre>
</div>
</div>
</div>
</div>
<p>Step 5. Add an &quot;ASP.NET Empty Web Application&quot; in solution, the project is used to test the customized DropDownList we've created. Add two web form pages and named them as &quot;TestSqlDataSource.aspx.aspx&quot;, &quot;TestObjectDataSource.aspx.aspx&quot;.</p>
<p>Step 6. Add a GridView and a DropDownList control on TestDropDownList page, and add code like this:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">    ''' &lt;summary&gt;
    ''' Normal data source
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
    ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
    ''' &lt;remarks&gt;&lt;/remarks&gt;
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Load the xml file and convert it to DataTable variable.
            Dim xmlDoc As XDocument = XDocument.Load(Server.MapPath(&quot;~/Data.xml&quot;))
            Dim results = From result In xmlDoc.Element(&quot;Root&quot;).Elements()
                          Select result
            Dim tabXml As New DataTable()
            tabXml.Columns.Add(&quot;ID&quot;, Type.[GetType](&quot;System.Int32&quot;))
            tabXml.Columns.Add(&quot;Name&quot;, Type.[GetType](&quot;System.String&quot;))
            tabXml.Columns.Add(&quot;Age&quot;, Type.[GetType](&quot;System.Int32&quot;))
            tabXml.Columns.Add(&quot;Telephone&quot;, Type.[GetType](&quot;System.String&quot;))
            tabXml.Columns.Add(&quot;Comment&quot;, Type.[GetType](&quot;System.String&quot;))
            Dim row As DataRow = tabXml.NewRow()
            row(&quot;ID&quot;) = 0
            row(&quot;Name&quot;) = &quot;None&quot;
            row(&quot;Age&quot;) = 0
            row(&quot;Telephone&quot;) = &quot;None&quot;
            row(&quot;Comment&quot;) = &quot;None&quot;
            tabXml.Rows.Add(row)
            For Each result As Object In results
                Dim tabRow As DataRow = tabXml.NewRow()
                tabRow(&quot;ID&quot;) = Convert.ToInt32(result.Element(&quot;ID&quot;).Value)
                tabRow(&quot;Name&quot;) = result.Element(&quot;Name&quot;).Value
                tabRow(&quot;Age&quot;) = Convert.ToInt32(result.Element(&quot;Age&quot;).Value)
                tabRow(&quot;Telephone&quot;) = result.Element(&quot;Telephone&quot;).Value
                tabRow(&quot;Comment&quot;) = result.Element(&quot;Comment&quot;).Value
                tabXml.Rows.Add(tabRow)
            Next

            ' Customized DropDownList control data binding by DataTable.
            customizedDropDownList.DataSource = tabXml.AsDataView()
            customizedDropDownList.DataTextField = &quot;Name&quot;
            customizedDropDownList.DataValueField = &quot;ID&quot;
            customizedDropDownList.DataBind()
            customizedDropDownList.SelectedValue = &quot;13&quot;

            ' GridView control data binding by DataTable.
            Dim rowGridView As DataRow = tabXml.NewRow()
            rowGridView(&quot;ID&quot;) = 1000
            rowGridView(&quot;Name&quot;) = &quot;Ann Anna&quot;
            rowGridView(&quot;Age&quot;) = 21
            rowGridView(&quot;Telephone&quot;) = &quot;111111&quot;
            rowGridView(&quot;Comment&quot;) = &quot;None&quot;
            tabXml.Rows.Add(rowGridView)
            Dim rowGridView2 As DataRow = tabXml.NewRow()
            rowGridView2(&quot;ID&quot;) = 1001
            rowGridView2(&quot;Name&quot;) = &quot;Bill Brand&quot;
            rowGridView2(&quot;Age&quot;) = 41
            rowGridView2(&quot;Telephone&quot;) = &quot;111112&quot;
            rowGridView2(&quot;Comment&quot;) = &quot;None&quot;
            tabXml.Rows.Add(rowGridView2)
            tabXml.Rows.Remove(row)
            gvwDropDownListSource.DataSource = tabXml
            gvwDropDownListSource.DataBind()
        End If

    End Sub

    Protected Sub gvwDropDownListSource_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvwDropDownListSource.RowCommand
        If e.CommandName = &quot;Select&quot; Then
            Dim rowIndex As Integer
            Dim convertFlag As Boolean = Integer.TryParse(e.CommandArgument.ToString(), rowIndex)
            If convertFlag Then
                customizedDropDownList.SelectedValue = gvwDropDownListSource.Rows(rowIndex).Cells(0).Text
            Else
                Response.Write(&quot;The row index is not correct.&quot;)
            End If
        End If

    End Sub</pre>
<div class="preview">
<pre class="vb">&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Normal&nbsp;data&nbsp;source</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;sender&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;e&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;remarks&gt;&lt;/remarks&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Page_Load(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;<span class="visualBasic__keyword">Me</span>.Load&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;IsPostBack&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Load&nbsp;the&nbsp;xml&nbsp;file&nbsp;and&nbsp;convert&nbsp;it&nbsp;to&nbsp;DataTable&nbsp;variable.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;xmlDoc&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;XDocument&nbsp;=&nbsp;XDocument.Load(Server.MapPath(<span class="visualBasic__string">&quot;~/Data.xml&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;results&nbsp;=&nbsp;From&nbsp;result&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;xmlDoc.Element(<span class="visualBasic__string">&quot;Root&quot;</span>).Elements()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;result&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;tabXml&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;DataTable()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabXml.Columns.Add(<span class="visualBasic__string">&quot;ID&quot;</span>,&nbsp;Type.[<span class="visualBasic__keyword">GetType</span>](<span class="visualBasic__string">&quot;System.Int32&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabXml.Columns.Add(<span class="visualBasic__string">&quot;Name&quot;</span>,&nbsp;Type.[<span class="visualBasic__keyword">GetType</span>](<span class="visualBasic__string">&quot;System.String&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabXml.Columns.Add(<span class="visualBasic__string">&quot;Age&quot;</span>,&nbsp;Type.[<span class="visualBasic__keyword">GetType</span>](<span class="visualBasic__string">&quot;System.Int32&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabXml.Columns.Add(<span class="visualBasic__string">&quot;Telephone&quot;</span>,&nbsp;Type.[<span class="visualBasic__keyword">GetType</span>](<span class="visualBasic__string">&quot;System.String&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabXml.Columns.Add(<span class="visualBasic__string">&quot;Comment&quot;</span>,&nbsp;Type.[<span class="visualBasic__keyword">GetType</span>](<span class="visualBasic__string">&quot;System.String&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;row&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DataRow&nbsp;=&nbsp;tabXml.NewRow()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;row(<span class="visualBasic__string">&quot;ID&quot;</span>)&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;row(<span class="visualBasic__string">&quot;Name&quot;</span>)&nbsp;=&nbsp;<span class="visualBasic__string">&quot;None&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;row(<span class="visualBasic__string">&quot;Age&quot;</span>)&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;row(<span class="visualBasic__string">&quot;Telephone&quot;</span>)&nbsp;=&nbsp;<span class="visualBasic__string">&quot;None&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;row(<span class="visualBasic__string">&quot;Comment&quot;</span>)&nbsp;=&nbsp;<span class="visualBasic__string">&quot;None&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabXml.Rows.Add(row)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;result&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;results&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;tabRow&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DataRow&nbsp;=&nbsp;tabXml.NewRow()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabRow(<span class="visualBasic__string">&quot;ID&quot;</span>)&nbsp;=&nbsp;Convert.ToInt32(result.Element(<span class="visualBasic__string">&quot;ID&quot;</span>).Value)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabRow(<span class="visualBasic__string">&quot;Name&quot;</span>)&nbsp;=&nbsp;result.Element(<span class="visualBasic__string">&quot;Name&quot;</span>).Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabRow(<span class="visualBasic__string">&quot;Age&quot;</span>)&nbsp;=&nbsp;Convert.ToInt32(result.Element(<span class="visualBasic__string">&quot;Age&quot;</span>).Value)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabRow(<span class="visualBasic__string">&quot;Telephone&quot;</span>)&nbsp;=&nbsp;result.Element(<span class="visualBasic__string">&quot;Telephone&quot;</span>).Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabRow(<span class="visualBasic__string">&quot;Comment&quot;</span>)&nbsp;=&nbsp;result.Element(<span class="visualBasic__string">&quot;Comment&quot;</span>).Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabXml.Rows.Add(tabRow)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Customized&nbsp;DropDownList&nbsp;control&nbsp;data&nbsp;binding&nbsp;by&nbsp;DataTable.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customizedDropDownList.DataSource&nbsp;=&nbsp;tabXml.AsDataView()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customizedDropDownList.DataTextField&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Name&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customizedDropDownList.DataValueField&nbsp;=&nbsp;<span class="visualBasic__string">&quot;ID&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customizedDropDownList.DataBind()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customizedDropDownList.SelectedValue&nbsp;=&nbsp;<span class="visualBasic__string">&quot;13&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;GridView&nbsp;control&nbsp;data&nbsp;binding&nbsp;by&nbsp;DataTable.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;rowGridView&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DataRow&nbsp;=&nbsp;tabXml.NewRow()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowGridView(<span class="visualBasic__string">&quot;ID&quot;</span>)&nbsp;=&nbsp;<span class="visualBasic__number">1000</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowGridView(<span class="visualBasic__string">&quot;Name&quot;</span>)&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Ann&nbsp;Anna&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowGridView(<span class="visualBasic__string">&quot;Age&quot;</span>)&nbsp;=&nbsp;<span class="visualBasic__number">21</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowGridView(<span class="visualBasic__string">&quot;Telephone&quot;</span>)&nbsp;=&nbsp;<span class="visualBasic__string">&quot;111111&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowGridView(<span class="visualBasic__string">&quot;Comment&quot;</span>)&nbsp;=&nbsp;<span class="visualBasic__string">&quot;None&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabXml.Rows.Add(rowGridView)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;rowGridView2&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DataRow&nbsp;=&nbsp;tabXml.NewRow()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowGridView2(<span class="visualBasic__string">&quot;ID&quot;</span>)&nbsp;=&nbsp;<span class="visualBasic__number">1001</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowGridView2(<span class="visualBasic__string">&quot;Name&quot;</span>)&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Bill&nbsp;Brand&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowGridView2(<span class="visualBasic__string">&quot;Age&quot;</span>)&nbsp;=&nbsp;<span class="visualBasic__number">41</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowGridView2(<span class="visualBasic__string">&quot;Telephone&quot;</span>)&nbsp;=&nbsp;<span class="visualBasic__string">&quot;111112&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowGridView2(<span class="visualBasic__string">&quot;Comment&quot;</span>)&nbsp;=&nbsp;<span class="visualBasic__string">&quot;None&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabXml.Rows.Add(rowGridView2)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabXml.Rows.Remove(row)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvwDropDownListSource.DataSource&nbsp;=&nbsp;tabXml&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvwDropDownListSource.DataBind()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;gvwDropDownListSource_RowCommand(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.Web.UI.WebControls.GridViewCommandEventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;gvwDropDownListSource.RowCommand&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;e.CommandName&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Select&quot;</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;rowIndex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;convertFlag&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">Integer</span>.TryParse(e.CommandArgument.ToString(),&nbsp;rowIndex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;convertFlag&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customizedDropDownList.SelectedValue&nbsp;=&nbsp;gvwDropDownListSource.Rows(rowIndex).Cells(<span class="visualBasic__number">0</span>).Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.Write(<span class="visualBasic__string">&quot;The&nbsp;row&nbsp;index&nbsp;is&nbsp;not&nbsp;correct.&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Step 7. Add a GridView and a DropDownList control on TestObjectDataSource.aspx page, and add code like this:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Load Xml file and convert it to List&lt;T&gt; variable.
        If Not IsPostBack Then
            Dim xmlDoc As XDocument = XDocument.Load(Server.MapPath(&quot;~/Data.xml&quot;))
            Dim entities As List(Of DataEntity) = (From result In xmlDoc.Descendants(&quot;Person&quot;)
                                                   Select New DataEntity() With { _
             .ID = Convert.ToInt32(result.Element(&quot;ID&quot;).Value), _
             .Name = result.Element(&quot;Name&quot;).Value, _
             .Age = Convert.ToInt32(result.Element(&quot;Age&quot;).Value), _
             .Telephone = result.Element(&quot;Telephone&quot;).Value, _
             .Comment = result.Element(&quot;Comment&quot;).Value _
            }).ToList()

            ' Customized DropDownList control data binding by IEnumberable.
            customizedDropDownList.DataSource = TryCast(entities, IEnumerable(Of DataEntity))
            customizedDropDownList.DataTextField = &quot;Name&quot;
            customizedDropDownList.DataValueField = &quot;ID&quot;
            customizedDropDownList.DataBind()
            customizedDropDownList.Items.Insert(0, New ListItem(&quot;None&quot;, &quot;0&quot;))
            customizedDropDownList.SelectedValue = &quot;12&quot;

            ' GridView control data binding by IEnumberable.
            Dim list As List(Of DataEntity) = TryCast(entities, List(Of DataEntity))
            Dim entitySingle As New DataEntity()
            entitySingle.ID = 1000
            entitySingle.Name = &quot;Ann Anna&quot;
            entitySingle.Age = 21
            entitySingle.Telephone = &quot;111111&quot;
            entitySingle.Comment = &quot;None&quot;
            list.Add(entitySingle)
            Dim entitySingle2 As New DataEntity()
            entitySingle2.ID = 1001
            entitySingle2.Name = &quot;Bill Brand&quot;
            entitySingle2.Age = 41
            entitySingle2.Telephone = &quot;111112&quot;
            entitySingle2.Comment = &quot;None&quot;
            list.Add(entitySingle2)

            gvwDropDownListSource.DataSource = TryCast(entities, IEnumerable(Of DataEntity))
            gvwDropDownListSource.DataBind()
        End If

    End Sub

    Protected Sub gvwDropDownListSource_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvwDropDownListSource.RowCommand
        If e.CommandName = &quot;Select&quot; Then
            Dim rowIndex As Integer
            Dim convertFlag As Boolean = Integer.TryParse(e.CommandArgument.ToString(), rowIndex)
            If convertFlag Then
                Dim num As Integer = gvwDropDownListSource.Rows.Count
                customizedDropDownList.SelectedValue = gvwDropDownListSource.Rows(rowIndex).Cells(0).Text
            Else
                Response.Write(&quot;The row index is not correct.&quot;)
            End If
        End If

    End Sub</pre>
<div class="preview">
<pre class="vb">&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Page_Load(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;<span class="visualBasic__keyword">Me</span>.Load&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Load&nbsp;Xml&nbsp;file&nbsp;and&nbsp;convert&nbsp;it&nbsp;to&nbsp;List&lt;T&gt;&nbsp;variable.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;IsPostBack&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;xmlDoc&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;XDocument&nbsp;=&nbsp;XDocument.Load(Server.MapPath(<span class="visualBasic__string">&quot;~/Data.xml&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;entities&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;List(<span class="visualBasic__keyword">Of</span>&nbsp;DataEntity)&nbsp;=&nbsp;(From&nbsp;result&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;xmlDoc.Descendants(<span class="visualBasic__string">&quot;Person&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;DataEntity()&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;{&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.ID&nbsp;=&nbsp;Convert.ToInt32(result.Element(<span class="visualBasic__string">&quot;ID&quot;</span>).Value),&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Name&nbsp;=&nbsp;result.Element(<span class="visualBasic__string">&quot;Name&quot;</span>).Value,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Age&nbsp;=&nbsp;Convert.ToInt32(result.Element(<span class="visualBasic__string">&quot;Age&quot;</span>).Value),&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Telephone&nbsp;=&nbsp;result.Element(<span class="visualBasic__string">&quot;Telephone&quot;</span>).Value,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Comment&nbsp;=&nbsp;result.Element(<span class="visualBasic__string">&quot;Comment&quot;</span>).Value&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).ToList()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Customized&nbsp;DropDownList&nbsp;control&nbsp;data&nbsp;binding&nbsp;by&nbsp;IEnumberable.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customizedDropDownList.DataSource&nbsp;=&nbsp;<span class="visualBasic__keyword">TryCast</span>(entities,&nbsp;IEnumerable(<span class="visualBasic__keyword">Of</span>&nbsp;DataEntity))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customizedDropDownList.DataTextField&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Name&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customizedDropDownList.DataValueField&nbsp;=&nbsp;<span class="visualBasic__string">&quot;ID&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customizedDropDownList.DataBind()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customizedDropDownList.Items.Insert(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;ListItem(<span class="visualBasic__string">&quot;None&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;0&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customizedDropDownList.SelectedValue&nbsp;=&nbsp;<span class="visualBasic__string">&quot;12&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;GridView&nbsp;control&nbsp;data&nbsp;binding&nbsp;by&nbsp;IEnumberable.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;list&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;List(<span class="visualBasic__keyword">Of</span>&nbsp;DataEntity)&nbsp;=&nbsp;<span class="visualBasic__keyword">TryCast</span>(entities,&nbsp;List(<span class="visualBasic__keyword">Of</span>&nbsp;DataEntity))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;entitySingle&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;DataEntity()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entitySingle.ID&nbsp;=&nbsp;<span class="visualBasic__number">1000</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entitySingle.Name&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Ann&nbsp;Anna&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entitySingle.Age&nbsp;=&nbsp;<span class="visualBasic__number">21</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entitySingle.Telephone&nbsp;=&nbsp;<span class="visualBasic__string">&quot;111111&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entitySingle.Comment&nbsp;=&nbsp;<span class="visualBasic__string">&quot;None&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;list.Add(entitySingle)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;entitySingle2&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;DataEntity()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entitySingle2.ID&nbsp;=&nbsp;<span class="visualBasic__number">1001</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entitySingle2.Name&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Bill&nbsp;Brand&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entitySingle2.Age&nbsp;=&nbsp;<span class="visualBasic__number">41</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entitySingle2.Telephone&nbsp;=&nbsp;<span class="visualBasic__string">&quot;111112&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entitySingle2.Comment&nbsp;=&nbsp;<span class="visualBasic__string">&quot;None&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;list.Add(entitySingle2)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvwDropDownListSource.DataSource&nbsp;=&nbsp;<span class="visualBasic__keyword">TryCast</span>(entities,&nbsp;IEnumerable(<span class="visualBasic__keyword">Of</span>&nbsp;DataEntity))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvwDropDownListSource.DataBind()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;gvwDropDownListSource_RowCommand(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.Web.UI.WebControls.GridViewCommandEventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;gvwDropDownListSource.RowCommand&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;e.CommandName&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Select&quot;</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;rowIndex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;convertFlag&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">Integer</span>.TryParse(e.CommandArgument.ToString(),&nbsp;rowIndex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;convertFlag&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;num&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;gvwDropDownListSource.Rows.Count&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customizedDropDownList.SelectedValue&nbsp;=&nbsp;gvwDropDownListSource.Rows(rowIndex).Cells(<span class="visualBasic__number">0</span>).Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.Write(<span class="visualBasic__string">&quot;The&nbsp;row&nbsp;index&nbsp;is&nbsp;not&nbsp;correct.&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
</div>
<div class="endscriptcode">
<h2 class="endscriptcode">More Information</h2>
</div>
<p>MSDN: ASP.NET server controls overview<br>
<a href="http://support.microsoft.com/kb/306459">http://support.microsoft.com/kb/306459</a></p>
<p>MSDN: ListControl.SelectedValue Property <br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.listcontrol.selectedvalue.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.listcontrol.selectedvalue.aspx</a></p>
<p>MSDN: DataView Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.data.dataview.aspx">http://msdn.microsoft.com/en-us/library/system.data.dataview.aspx</a></p>
<p>MSDN: IEnumerable Interface<br>
<a href="http://msdn.microsoft.com/en-us/library/system.collections.ienumerable.aspx">http://msdn.microsoft.com/en-us/library/system.collections.ienumerable.aspx</a></p>
<p><em>&nbsp;</em></p>
<p><em>&nbsp;</em></p>
<p><em>&nbsp;</em></p>
<p><em>&nbsp;</em></p>
<p><em>&nbsp;</em></p>
<p><em></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
</em>
<p></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
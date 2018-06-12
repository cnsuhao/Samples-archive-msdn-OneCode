# Customized DropDownList.SelectedValue (CSASPNETSmartDropdownlist)
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
* 2011-11-01 08:47:53
## Description

<h1>CSASPNETSmartDropdownlist Overview</h1>
<h2><span>Summary</span></h2>
<p>The code sample customizes the SelectedValue property of ASP.NET DropDownList control so that it handles the situation more nicely when the SelectedValue property is set to a value that does not exist in the DropDownList value collection.&nbsp; By default,
 an ArguementOutOfRangeException exception is thrown when SelectedValue is set invalidly.&nbsp; With the customization, the DropDownList will select a &quot;None&quot; item when the SelectedValue is invalid.</p>
<h2>Demo</h2>
<p>Please follow these demonstration steps below.</p>
<p>Step 1: Open the CSASPNETSmartDropdownlist.sln.</p>
<p>Step 2: Right click TestObjectDataSource.aspx.aspx and choose &quot;View in Browser&quot;.</p>
<p>Step 3: You will see a DropDownList and a GridView in the page, note the&nbsp;DropDwonList has four valid items while the GridView has six.</p>
<p>Step 4: If you click the &quot;Select DropDownList option&quot; button you may notice that&nbsp;the selected item of DropDownList will change accordingly to the related one.&nbsp;&nbsp;&nbsp;If the item which you selected by clicking button is not contained in&nbsp;DropDownList
 control, the selected item of DropDownList will be &quot;None&quot;.</p>
<p>Step 5: You can also change the selectedValue in page_load event.</p>
<p>Step 6: View and test the TestSqlDataSource.aspx.aspx page as the forward one.<br>
&nbsp; [Note]<br>
The two test page are ues Sql data source and Object data source to test&nbsp;&nbsp;this smart DropDownList control, the Sql data source is not means SqlDataSource&nbsp;control, it means generiec data source, we can convert it to DataTable variable,&nbsp;and
 object data source can convert to IEnumerable object variable.<br>
&nbsp;&nbsp;[/Note]</p>
<p>Step 7: Validation finished.</p>
<p>&nbsp;</p>
<h2>Implementation</h2>
<p>Step 1. Create a C# &quot;ASP.NET Server Control&quot; in Visual Studio 2010 or Visual Web Developer 2010. Name it as &quot;CSASPNETSmartDropdownlist&quot;.</p>
<p>Step 2. Add a Server control and name it as &quot;CustomizedDropDownList.cs&quot;.</p>
<p>Step 3. Remove the Text property and override RenderContent method. Override the Render method, the C# code as shown below:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">protected override void Render(HtmlTextWriter writer)
{
     base.Render(writer);
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Render(HtmlTextWriter&nbsp;writer)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.Render(writer);&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">Step 4. Override the SelectedValue property.&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">		/// &lt;summary&gt;
        /// Override SelectedValue property.
        /// For testing purpose, here we only provide three types of data field,
        /// Int, Long and String.
        /// &lt;/summary&gt;
        public override string SelectedValue
        {
            get
            {
                return base.SelectedValue;
            }
            set
            {
                // If data source is SqlDataSource.
                if (DataSource is DataView)
                {
                    DataView dataView = DataSource as DataView;
                    DataTable tabView = dataView.Table;
                    Type typeColumns = tabView.Columns[DataValueField].DataType;
                    string rowFilter = string.Empty;
                    if (typeColumns.Equals(Type.GetType(&quot;System.String&quot;)))
                    {
                        rowFilter = string.Format(&quot;{0}='{1}'&quot;, DataValueField, value);
                    }
                    else if (typeColumns.Equals(Type.GetType(&quot;System.Int32&quot;)) || typeColumns.Equals(Type.GetType(&quot;System.Int64&quot;)))
                    {
                        rowFilter = string.Format(&quot;{0}={1}&quot;, DataValueField, value);
                    }
                    else
                    {
                        throw new NotImplementedException(&quot;unsupported type&quot;);
                    }

                    dataView.RowFilter = rowFilter;
                    if (dataView.Count != 0)
                    {
                        dataView.RowFilter = string.Empty;
                        base.SelectedValue = value;
                    }
                    else
                    {
                        dataView.RowFilter = string.Empty;
                        base.SelectedValue = Items[0].Value;
                    }
                }
                // If data source is ObjectDataSource
                else if (DataSource is IEnumerable)
                {
                    bool bolFlag = false;
                    foreach (object obj in DataSource as IEnumerable)
                    {
                        Type type = obj.GetType();
                        //if (!type.Equals(Type.GetType(&quot;System.String&quot;)) &amp;&amp; !type.Equals(Type.GetType(&quot;System.Int32&quot;))
                        //    &amp;&amp; !type.Equals(Type.GetType(&quot;System.Int64&quot;)) &amp;&amp; !type.ToString().Equals(&quot;TestPage.DataEntity&quot;))
                        //{
                        //    throw new NotImplementedException(&quot;unsupported type&quot;);
                        //}
                        PropertyInfo info = type.GetProperty(DataValueField);
                        string valueProperty = info.GetValue(obj,null).ToString();
                        if (valueProperty.Equals(value))
                        {
                            bolFlag = true;
                            break;
                        }
                    }

                    if (bolFlag)
                    {
                        base.SelectedValue = value;
                    }
                    else
                    {
                        base.SelectedValue = Items[0].Value;
                    }
                }

                // If user change the selected value after postback.
                if(DataSource == null)
                {
                    bool bolFlag = false;
                    for (int i = 0; i &lt; Items.Count; i&#43;&#43;)
                    {
                        if (Items[i].Value.Equals(value))
                        {
                            bolFlag = true;
                            break;
                        }
                    }
                    if (bolFlag)
                    {
                        base.SelectedValue = value;
                    }
                    else
                    {
                        base.SelectedValue = Items[0].Value;
                    }                        
                }
            }
        }</pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span><span class="js__sl_comment">///&nbsp;Override&nbsp;SelectedValue&nbsp;property.</span><span class="js__sl_comment">///&nbsp;For&nbsp;testing&nbsp;purpose,&nbsp;here&nbsp;we&nbsp;only&nbsp;provide&nbsp;three&nbsp;types&nbsp;of&nbsp;data&nbsp;field,</span><span class="js__sl_comment">///&nbsp;Int,&nbsp;Long&nbsp;and&nbsp;String.</span><span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;override&nbsp;string&nbsp;SelectedValue&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;get&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">return</span>&nbsp;base.SelectedValue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;set&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__sl_comment">//&nbsp;If&nbsp;data&nbsp;source&nbsp;is&nbsp;SqlDataSource.</span><span class="js__statement">if</span>&nbsp;(DataSource&nbsp;is&nbsp;DataView)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataView&nbsp;dataView&nbsp;=&nbsp;DataSource&nbsp;as&nbsp;DataView;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataTable&nbsp;tabView&nbsp;=&nbsp;dataView.Table;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Type&nbsp;typeColumns&nbsp;=&nbsp;tabView.Columns[DataValueField].DataType;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;rowFilter&nbsp;=&nbsp;string.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(typeColumns.Equals(Type.GetType(<span class="js__string">&quot;System.String&quot;</span>)))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowFilter&nbsp;=&nbsp;string.Format(<span class="js__string">&quot;{0}='{1}'&quot;</span>,&nbsp;DataValueField,&nbsp;value);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__statement">else</span><span class="js__statement">if</span>&nbsp;(typeColumns.Equals(Type.GetType(<span class="js__string">&quot;System.Int32&quot;</span>))&nbsp;||&nbsp;typeColumns.Equals(Type.GetType(<span class="js__string">&quot;System.Int64&quot;</span>)))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowFilter&nbsp;=&nbsp;string.Format(<span class="js__string">&quot;{0}={1}&quot;</span>,&nbsp;DataValueField,&nbsp;value);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__statement">else</span><span class="js__brace">{</span><span class="js__statement">throw</span><span class="js__operator">new</span>&nbsp;NotImplementedException(<span class="js__string">&quot;unsupported&nbsp;type&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataView.RowFilter&nbsp;=&nbsp;rowFilter;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(dataView.Count&nbsp;!=&nbsp;<span class="js__num">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataView.RowFilter&nbsp;=&nbsp;string.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;base.SelectedValue&nbsp;=&nbsp;value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__statement">else</span><span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataView.RowFilter&nbsp;=&nbsp;string.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;base.SelectedValue&nbsp;=&nbsp;Items[<span class="js__num">0</span>].Value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span><span class="js__sl_comment">//&nbsp;If&nbsp;data&nbsp;source&nbsp;is&nbsp;ObjectDataSource</span><span class="js__statement">else</span><span class="js__statement">if</span>&nbsp;(DataSource&nbsp;is&nbsp;IEnumerable)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bool&nbsp;bolFlag&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(object&nbsp;obj&nbsp;<span class="js__operator">in</span>&nbsp;DataSource&nbsp;as&nbsp;IEnumerable)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Type&nbsp;type&nbsp;=&nbsp;obj.GetType();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//if&nbsp;(!type.Equals(Type.GetType(&quot;System.String&quot;))&nbsp;&amp;&amp;&nbsp;!type.Equals(Type.GetType(&quot;System.Int32&quot;))</span><span class="js__sl_comment">//&nbsp;&nbsp;&nbsp;&nbsp;&amp;&amp;&nbsp;!type.Equals(Type.GetType(&quot;System.Int64&quot;))&nbsp;&amp;&amp;&nbsp;!type.ToString().Equals(&quot;TestPage.DataEntity&quot;))</span><span class="js__sl_comment">//{</span><span class="js__sl_comment">//&nbsp;&nbsp;&nbsp;&nbsp;throw&nbsp;new&nbsp;NotImplementedException(&quot;unsupported&nbsp;type&quot;);</span><span class="js__sl_comment">//}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PropertyInfo&nbsp;info&nbsp;=&nbsp;type.GetProperty(DataValueField);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;valueProperty&nbsp;=&nbsp;info.GetValue(obj,null).ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(valueProperty.Equals(value))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bolFlag&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span><span class="js__statement">if</span>&nbsp;(bolFlag)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;base.SelectedValue&nbsp;=&nbsp;value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__statement">else</span><span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;base.SelectedValue&nbsp;=&nbsp;Items[<span class="js__num">0</span>].Value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span><span class="js__sl_comment">//&nbsp;If&nbsp;user&nbsp;change&nbsp;the&nbsp;selected&nbsp;value&nbsp;after&nbsp;postback.</span><span class="js__statement">if</span>(DataSource&nbsp;==&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bool&nbsp;bolFlag&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(int&nbsp;i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;Items.Count;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">if</span>&nbsp;(Items[i].Value.Equals(value))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bolFlag&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span><span class="js__statement">if</span>&nbsp;(bolFlag)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;base.SelectedValue&nbsp;=&nbsp;value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__statement">else</span><span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;base.SelectedValue&nbsp;=&nbsp;Items[<span class="js__num">0</span>].Value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span><span class="js__brace">}</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>Step 5. Add an &quot;ASP.NET Empty Web Application&quot; in solution, the project is used to test the customized DropDownList we've created. Add two web form pages and named them&nbsp;as &quot;TestSqlDataSource.aspx.aspx&quot;, &quot;TestObjectDataSource.aspx.aspx&quot;.</p>
<p>Step 6. Add a GridView and a DropDownList control on TestDropDownList page, and add code like this:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">        public partial class TestSqlDataSource.aspx : System.Web.UI.Page
        {
        /// &lt;summary&gt;
        /// Normal SqlDataSource.
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load the xml file and convert it to DataTable variable.
                XDocument xmlDoc = XDocument.Load(Server.MapPath(&quot;~/Data.xml&quot;));
                var results = from result in xmlDoc.Element(&quot;Root&quot;).Elements()
                              select result;
                DataTable tabXml = new DataTable();
                tabXml.Columns.Add(&quot;ID&quot;, Type.GetType(&quot;System.Int32&quot;));
                tabXml.Columns.Add(&quot;Name&quot;, Type.GetType(&quot;System.String&quot;));
                tabXml.Columns.Add(&quot;Age&quot;, Type.GetType(&quot;System.Int32&quot;));
                tabXml.Columns.Add(&quot;Telephone&quot;, Type.GetType(&quot;System.String&quot;));
                tabXml.Columns.Add(&quot;Comment&quot;, Type.GetType(&quot;System.String&quot;));
                DataRow row = tabXml.NewRow();
                row[&quot;ID&quot;] = 0;
                row[&quot;Name&quot;] = &quot;None&quot;;
                row[&quot;Age&quot;] = 0;
                row[&quot;Telephone&quot;] = &quot;None&quot;;
                row[&quot;Comment&quot;] = &quot;None&quot;;
                tabXml.Rows.Add(row);
                foreach (var result in results)
                {
                    DataRow tabRow = tabXml.NewRow();
                    tabRow[&quot;ID&quot;] = Convert.ToInt32(result.Element(&quot;ID&quot;).Value);
                    tabRow[&quot;Name&quot;] = result.Element(&quot;Name&quot;).Value;
                    tabRow[&quot;Age&quot;] = Convert.ToInt32(result.Element(&quot;Age&quot;).Value);
                    tabRow[&quot;Telephone&quot;] = result.Element(&quot;Telephone&quot;).Value;
                    tabRow[&quot;Comment&quot;] = result.Element(&quot;Comment&quot;).Value;
                    tabXml.Rows.Add(tabRow);
                }

                // Customized DropDownList control data binding by DataTable.
                customizedDropDownList.DataSource = tabXml.AsDataView();
                customizedDropDownList.DataTextField = &quot;Name&quot;;
                customizedDropDownList.DataValueField = &quot;ID&quot;;
                customizedDropDownList.DataBind();
                customizedDropDownList.SelectedValue = &quot;13&quot;;

                // GridView control data binding by DataTable.
                DataRow rowGridView = tabXml.NewRow();
                rowGridView[&quot;ID&quot;] = 1000;
                rowGridView[&quot;Name&quot;] = &quot;Ann Anna&quot;;
                rowGridView[&quot;Age&quot;] = 21;
                rowGridView[&quot;Telephone&quot;] = &quot;111111&quot;;
                rowGridView[&quot;Comment&quot;] = &quot;None&quot;;
                tabXml.Rows.Add(rowGridView);
                DataRow rowGridView2 = tabXml.NewRow();
                rowGridView2[&quot;ID&quot;] = 1001;
                rowGridView2[&quot;Name&quot;] = &quot;Bill Brand&quot;;
                rowGridView2[&quot;Age&quot;] = 41;
                rowGridView2[&quot;Telephone&quot;] = &quot;111112&quot;;
                rowGridView2[&quot;Comment&quot;] = &quot;None&quot;;
                tabXml.Rows.Add(rowGridView2);
                tabXml.Rows.Remove(row);
                gvwDropDownListSource.DataSource = tabXml;
                gvwDropDownListSource.DataBind();
            }
        }

        /// &lt;summary&gt;
        /// Change DropDownList selected value.
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
        protected void gvwDropDownListSource_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == &quot;Select&quot;)
            {
                int rowIndex;
                bool convertFlag = int.TryParse(e.CommandArgument.ToString(), out rowIndex);
                if (convertFlag)
                {
                    customizedDropDownList.SelectedValue = gvwDropDownListSource.Rows[rowIndex].Cells[0].Text;
                }
                else
                {
                    Response.Write(&quot;The row index is not correct.&quot;);
                }
            }
        }</pre>
<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;partial&nbsp;class&nbsp;TestSqlDataSource.aspx&nbsp;:&nbsp;System.Web.UI.Page&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span><span class="js__sl_comment">///&nbsp;Normal&nbsp;SqlDataSource.</span><span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span><span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;sender&quot;&gt;&lt;/param&gt;</span><span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;e&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;protected&nbsp;<span class="js__operator">void</span>&nbsp;Page_Load(object&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">if</span>&nbsp;(!IsPostBack)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__sl_comment">//&nbsp;Load&nbsp;the&nbsp;xml&nbsp;file&nbsp;and&nbsp;convert&nbsp;it&nbsp;to&nbsp;DataTable&nbsp;variable.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XDocument&nbsp;xmlDoc&nbsp;=&nbsp;XDocument.Load(Server.MapPath(<span class="js__string">&quot;~/Data.xml&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;results&nbsp;=&nbsp;from&nbsp;result&nbsp;<span class="js__operator">in</span>&nbsp;xmlDoc.Element(<span class="js__string">&quot;Root&quot;</span>).Elements()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;result;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataTable&nbsp;tabXml&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataTable();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabXml.Columns.Add(<span class="js__string">&quot;ID&quot;</span>,&nbsp;Type.GetType(<span class="js__string">&quot;System.Int32&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabXml.Columns.Add(<span class="js__string">&quot;Name&quot;</span>,&nbsp;Type.GetType(<span class="js__string">&quot;System.String&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabXml.Columns.Add(<span class="js__string">&quot;Age&quot;</span>,&nbsp;Type.GetType(<span class="js__string">&quot;System.Int32&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabXml.Columns.Add(<span class="js__string">&quot;Telephone&quot;</span>,&nbsp;Type.GetType(<span class="js__string">&quot;System.String&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabXml.Columns.Add(<span class="js__string">&quot;Comment&quot;</span>,&nbsp;Type.GetType(<span class="js__string">&quot;System.String&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataRow&nbsp;row&nbsp;=&nbsp;tabXml.NewRow();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;row[<span class="js__string">&quot;ID&quot;</span>]&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;row[<span class="js__string">&quot;Name&quot;</span>]&nbsp;=&nbsp;<span class="js__string">&quot;None&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;row[<span class="js__string">&quot;Age&quot;</span>]&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;row[<span class="js__string">&quot;Telephone&quot;</span>]&nbsp;=&nbsp;<span class="js__string">&quot;None&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;row[<span class="js__string">&quot;Comment&quot;</span>]&nbsp;=&nbsp;<span class="js__string">&quot;None&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabXml.Rows.Add(row);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(<span class="js__statement">var</span>&nbsp;result&nbsp;<span class="js__operator">in</span>&nbsp;results)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataRow&nbsp;tabRow&nbsp;=&nbsp;tabXml.NewRow();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabRow[<span class="js__string">&quot;ID&quot;</span>]&nbsp;=&nbsp;Convert.ToInt32(result.Element(<span class="js__string">&quot;ID&quot;</span>).Value);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabRow[<span class="js__string">&quot;Name&quot;</span>]&nbsp;=&nbsp;result.Element(<span class="js__string">&quot;Name&quot;</span>).Value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabRow[<span class="js__string">&quot;Age&quot;</span>]&nbsp;=&nbsp;Convert.ToInt32(result.Element(<span class="js__string">&quot;Age&quot;</span>).Value);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabRow[<span class="js__string">&quot;Telephone&quot;</span>]&nbsp;=&nbsp;result.Element(<span class="js__string">&quot;Telephone&quot;</span>).Value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabRow[<span class="js__string">&quot;Comment&quot;</span>]&nbsp;=&nbsp;result.Element(<span class="js__string">&quot;Comment&quot;</span>).Value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabXml.Rows.Add(tabRow);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__sl_comment">//&nbsp;Customized&nbsp;DropDownList&nbsp;control&nbsp;data&nbsp;binding&nbsp;by&nbsp;DataTable.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customizedDropDownList.DataSource&nbsp;=&nbsp;tabXml.AsDataView();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customizedDropDownList.DataTextField&nbsp;=&nbsp;<span class="js__string">&quot;Name&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customizedDropDownList.DataValueField&nbsp;=&nbsp;<span class="js__string">&quot;ID&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customizedDropDownList.DataBind();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customizedDropDownList.SelectedValue&nbsp;=&nbsp;<span class="js__string">&quot;13&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;GridView&nbsp;control&nbsp;data&nbsp;binding&nbsp;by&nbsp;DataTable.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataRow&nbsp;rowGridView&nbsp;=&nbsp;tabXml.NewRow();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowGridView[<span class="js__string">&quot;ID&quot;</span>]&nbsp;=&nbsp;<span class="js__num">1000</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowGridView[<span class="js__string">&quot;Name&quot;</span>]&nbsp;=&nbsp;<span class="js__string">&quot;Ann&nbsp;Anna&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowGridView[<span class="js__string">&quot;Age&quot;</span>]&nbsp;=&nbsp;<span class="js__num">21</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowGridView[<span class="js__string">&quot;Telephone&quot;</span>]&nbsp;=&nbsp;<span class="js__string">&quot;111111&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowGridView[<span class="js__string">&quot;Comment&quot;</span>]&nbsp;=&nbsp;<span class="js__string">&quot;None&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabXml.Rows.Add(rowGridView);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataRow&nbsp;rowGridView2&nbsp;=&nbsp;tabXml.NewRow();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowGridView2[<span class="js__string">&quot;ID&quot;</span>]&nbsp;=&nbsp;<span class="js__num">1001</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowGridView2[<span class="js__string">&quot;Name&quot;</span>]&nbsp;=&nbsp;<span class="js__string">&quot;Bill&nbsp;Brand&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowGridView2[<span class="js__string">&quot;Age&quot;</span>]&nbsp;=&nbsp;<span class="js__num">41</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowGridView2[<span class="js__string">&quot;Telephone&quot;</span>]&nbsp;=&nbsp;<span class="js__string">&quot;111112&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowGridView2[<span class="js__string">&quot;Comment&quot;</span>]&nbsp;=&nbsp;<span class="js__string">&quot;None&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabXml.Rows.Add(rowGridView2);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tabXml.Rows.Remove(row);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvwDropDownListSource.DataSource&nbsp;=&nbsp;tabXml;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvwDropDownListSource.DataBind();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span><span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span><span class="js__sl_comment">///&nbsp;Change&nbsp;DropDownList&nbsp;selected&nbsp;value.</span><span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span><span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;sender&quot;&gt;&lt;/param&gt;</span><span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;e&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;protected&nbsp;<span class="js__operator">void</span>&nbsp;gvwDropDownListSource_RowCommand(object&nbsp;sender,&nbsp;GridViewCommandEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">if</span>&nbsp;(e.CommandName&nbsp;==&nbsp;<span class="js__string">&quot;Select&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;rowIndex;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bool&nbsp;convertFlag&nbsp;=&nbsp;int.TryParse(e.CommandArgument.ToString(),&nbsp;out&nbsp;rowIndex);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(convertFlag)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customizedDropDownList.SelectedValue&nbsp;=&nbsp;gvwDropDownListSource.Rows[rowIndex].Cells[<span class="js__num">0</span>].Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__statement">else</span><span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.Write(<span class="js__string">&quot;The&nbsp;row&nbsp;index&nbsp;is&nbsp;not&nbsp;correct.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">Step 7. Add a GridView and a DropDownList control on TestObjectDataSource.aspx page, and add code like this:</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">		/// &lt;summary&gt;
        /// IEnumberable&lt;T&gt; types as the ObjectDataSource.
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Load Xml file and convert it to List&lt;T&gt; variable.
            if (!IsPostBack)
            {
                XDocument xmlDoc = XDocument.Load(Server.MapPath(&quot;~/Data.xml&quot;));
                List&lt;DataEntity&gt; entities = (from result in xmlDoc.Descendants(&quot;Person&quot;)
                                             select new DataEntity
                                             {
                                                 ID = Convert.ToInt32(result.Element(&quot;ID&quot;).Value),
                                                 Name = result.Element(&quot;Name&quot;).Value,
                                                 Age = Convert.ToInt32(result.Element(&quot;Age&quot;).Value),
                                                 Telephone = result.Element(&quot;Telephone&quot;).Value,
                                                 Comment = result.Element(&quot;Comment&quot;).Value
                                             }).ToList&lt;DataEntity&gt;();

                // Customized DropDownList control data binding by IEnumberable.
                customizedDropDownList.DataSource = entities as IEnumerable&lt;DataEntity&gt;;
                customizedDropDownList.DataTextField = &quot;Name&quot;;
                customizedDropDownList.DataValueField = &quot;ID&quot;;
                customizedDropDownList.DataBind();
                customizedDropDownList.Items.Insert(0, new ListItem(&quot;None&quot;, &quot;0&quot;));
                customizedDropDownList.SelectedValue = &quot;12&quot;;

                // GridView control data binding by IEnumberable.
                List&lt;DataEntity&gt; list = entities as List&lt;DataEntity&gt;;
                DataEntity entitySingle = new DataEntity();
                entitySingle.ID = 1000;
                entitySingle.Name = &quot;Ann Anna&quot;;
                entitySingle.Age = 21;
                entitySingle.Telephone = &quot;111111&quot;;
                entitySingle.Comment = &quot;None&quot;;
                list.Add(entitySingle);
                DataEntity entitySingle2 = new DataEntity();
                entitySingle2.ID = 1001;
                entitySingle2.Name = &quot;Bill Brand&quot;;
                entitySingle2.Age = 41;
                entitySingle2.Telephone = &quot;111112&quot;;
                entitySingle2.Comment = &quot;None&quot;;
                list.Add(entitySingle2);

                gvwDropDownListSource.DataSource = entities as IEnumerable&lt;DataEntity&gt;;
                gvwDropDownListSource.DataBind();             
            }

        }

        /// &lt;summary&gt;
        /// Change DropDownList selected value.
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
        protected void gvwDropDownListSource_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == &quot;Select&quot;)
            {
                int rowIndex;
                bool convertFlag = int.TryParse(e.CommandArgument.ToString(), out rowIndex);
                if (convertFlag)
                {
                    int num = gvwDropDownListSource.Rows.Count;
                    customizedDropDownList.SelectedValue = gvwDropDownListSource.Rows[rowIndex].Cells[0].Text;
                }
                else
                {
                    Response.Write(&quot;The row index is not correct.&quot;);
                }
            }
        }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">///&nbsp;&lt;summary&gt;</span><span class="cs__com">///&nbsp;IEnumberable&lt;T&gt;&nbsp;types&nbsp;as&nbsp;the&nbsp;ObjectDataSource.</span><span class="cs__com">///&nbsp;&lt;/summary&gt;</span><span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;sender&quot;&gt;&lt;/param&gt;</span><span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;e&quot;&gt;&lt;/param&gt;</span><span class="cs__keyword">protected</span><span class="cs__keyword">void</span>&nbsp;Page_Load(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Load&nbsp;Xml&nbsp;file&nbsp;and&nbsp;convert&nbsp;it&nbsp;to&nbsp;List&lt;T&gt;&nbsp;variable.</span><span class="cs__keyword">if</span>&nbsp;(!IsPostBack)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XDocument&nbsp;xmlDoc&nbsp;=&nbsp;XDocument.Load(Server.MapPath(<span class="cs__string">&quot;~/Data.xml&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;DataEntity&gt;&nbsp;entities&nbsp;=&nbsp;(from&nbsp;result&nbsp;<span class="cs__keyword">in</span>&nbsp;xmlDoc.Descendants(<span class="cs__string">&quot;Person&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;<span class="cs__keyword">new</span>&nbsp;DataEntity&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ID&nbsp;=&nbsp;Convert.ToInt32(result.Element(<span class="cs__string">&quot;ID&quot;</span>).Value),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name&nbsp;=&nbsp;result.Element(<span class="cs__string">&quot;Name&quot;</span>).Value,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Age&nbsp;=&nbsp;Convert.ToInt32(result.Element(<span class="cs__string">&quot;Age&quot;</span>).Value),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Telephone&nbsp;=&nbsp;result.Element(<span class="cs__string">&quot;Telephone&quot;</span>).Value,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Comment&nbsp;=&nbsp;result.Element(<span class="cs__string">&quot;Comment&quot;</span>).Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).ToList&lt;DataEntity&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Customized&nbsp;DropDownList&nbsp;control&nbsp;data&nbsp;binding&nbsp;by&nbsp;IEnumberable.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customizedDropDownList.DataSource&nbsp;=&nbsp;entities&nbsp;<span class="cs__keyword">as</span>&nbsp;IEnumerable&lt;DataEntity&gt;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customizedDropDownList.DataTextField&nbsp;=&nbsp;<span class="cs__string">&quot;Name&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customizedDropDownList.DataValueField&nbsp;=&nbsp;<span class="cs__string">&quot;ID&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customizedDropDownList.DataBind();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customizedDropDownList.Items.Insert(<span class="cs__number">0</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;ListItem(<span class="cs__string">&quot;None&quot;</span>,&nbsp;<span class="cs__string">&quot;0&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customizedDropDownList.SelectedValue&nbsp;=&nbsp;<span class="cs__string">&quot;12&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;GridView&nbsp;control&nbsp;data&nbsp;binding&nbsp;by&nbsp;IEnumberable.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;DataEntity&gt;&nbsp;list&nbsp;=&nbsp;entities&nbsp;<span class="cs__keyword">as</span>&nbsp;List&lt;DataEntity&gt;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataEntity&nbsp;entitySingle&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataEntity();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entitySingle.ID&nbsp;=&nbsp;<span class="cs__number">1000</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entitySingle.Name&nbsp;=&nbsp;<span class="cs__string">&quot;Ann&nbsp;Anna&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entitySingle.Age&nbsp;=&nbsp;<span class="cs__number">21</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entitySingle.Telephone&nbsp;=&nbsp;<span class="cs__string">&quot;111111&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entitySingle.Comment&nbsp;=&nbsp;<span class="cs__string">&quot;None&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;list.Add(entitySingle);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataEntity&nbsp;entitySingle2&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataEntity();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entitySingle2.ID&nbsp;=&nbsp;<span class="cs__number">1001</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entitySingle2.Name&nbsp;=&nbsp;<span class="cs__string">&quot;Bill&nbsp;Brand&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entitySingle2.Age&nbsp;=&nbsp;<span class="cs__number">41</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entitySingle2.Telephone&nbsp;=&nbsp;<span class="cs__string">&quot;111112&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entitySingle2.Comment&nbsp;=&nbsp;<span class="cs__string">&quot;None&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;list.Add(entitySingle2);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvwDropDownListSource.DataSource&nbsp;=&nbsp;entities&nbsp;<span class="cs__keyword">as</span>&nbsp;IEnumerable&lt;DataEntity&gt;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvwDropDownListSource.DataBind();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span><span class="cs__com">///&nbsp;Change&nbsp;DropDownList&nbsp;selected&nbsp;value.</span><span class="cs__com">///&nbsp;&lt;/summary&gt;</span><span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;sender&quot;&gt;&lt;/param&gt;</span><span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;e&quot;&gt;&lt;/param&gt;</span><span class="cs__keyword">protected</span><span class="cs__keyword">void</span>&nbsp;gvwDropDownListSource_RowCommand(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;GridViewCommandEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(e.CommandName&nbsp;==&nbsp;<span class="cs__string">&quot;Select&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;rowIndex;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;convertFlag&nbsp;=&nbsp;<span class="cs__keyword">int</span>.TryParse(e.CommandArgument.ToString(),&nbsp;<span class="cs__keyword">out</span>&nbsp;rowIndex);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(convertFlag)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;num&nbsp;=&nbsp;gvwDropDownListSource.Rows.Count;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customizedDropDownList.SelectedValue&nbsp;=&nbsp;gvwDropDownListSource.Rows[rowIndex].Cells[<span class="cs__number">0</span>].Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.Write(<span class="cs__string">&quot;The&nbsp;row&nbsp;index&nbsp;is&nbsp;not&nbsp;correct.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h2 class="endscriptcode">More Information</h2>
</div>
<p>&nbsp;</p>
<p>MSDN: ASP.NET server controls overview<br>
<a href="http://support.microsoft.com/kb/306459">http://support.microsoft.com/kb/306459</a></p>
<p>MSDN: ListControl.SelectedValue Property <br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.listcontrol.selectedvalue.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.listcontrol.selectedvalue.aspx</a></p>
<p>MSDN: DataView Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.data.dataview.aspx">http://msdn.microsoft.com/en-us/library/system.data.dataview.aspx</a></p>
<p>MSDN: IEnumerable Interface<br>
<a href="http://msdn.microsoft.com/en-us/library/system.collections.ienumerable.aspx">http://msdn.microsoft.com/en-us/library/system.collections.ienumerable.aspx</a></p>
<p><em><br>
</em></p>
<p><em></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
</em>
<p></p>
<p>&nbsp;</p>

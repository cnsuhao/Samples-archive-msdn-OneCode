# Set value to "IN Parameter" of SqlDataSource
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* ASP.NET
## IsPublished
* True
## ModifiedDate
* 2013-01-13 07:35:43
## Description

<h1>How to set value to &quot;IN Parameter&quot; of SqlDataSource (VBASPNETInParameterOfSql)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample code will demonstrate how to set value to &quot;IN Parameter&quot; of SqlDataSource. Generally speaking, we can map SQL parameters in order to prevent SQL injection in SQL statement with placeholders. However, sometimes we
 cannot directly do so: a typical scenario when we have to use keywords in, assume that your SqlDataSource Control's select statement: &quot;select * from xxx where [some field] in (@ of value)&quot;. You specify value for the parameters @ value as follows:
 &quot;a, b, c &quot;. In fact the entire string will be compiled and run as: select * from xxx where [some field] in 'a, b, c'. Notice that the parameter will add a pair of single quote! This will cause a wrong result; maybe you get nothing after executing
 that ......This sample will resolve this issue.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow the steps below. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 1: Open the VBASPNETInParameterOfSql.sln file. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 2: Right-Click at Default.aspx page and then select &quot;view in browser&quot;.&nbsp;
<br>
<span style=""><img src="/site/view/file/74587/1/image.png" alt="" width="332" height="551" align="middle">
</span><br>
Step 3: To select some id, then click the ShowDynamicData button. The GridView looks like this:
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""><img src="/site/view/file/74588/1/image.png" alt="" width="289" height="286" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Click ShowStaticData button. The GridView will show as below:<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""><span style="">&nbsp;</span><span style=""> <img src="/site/view/file/74589/1/image.png" alt="" width="313" height="328" align="middle">
</span><br>
No matter which ids we've chosen, when we click ShowStaticData button it will only use the specified static ids (1, 2, 3, 4, 5).
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 4: Validation is completed. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal"><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span></span></p>
<p class="MsoNormal"><span style="">Step 1: Create a VB.NET &quot;ASP.NET Web Application&quot; in Visual Studio or Visual Web Developer and name it as &quot;VBASPNETInParameterOfSql&quot;.
</span></p>
<p class="MsoNormal"><span style="">Step 2: Drag and drop a GridView onto the Default page.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; background:white">
<span style="">Step 3: Drag and drop a SqlDataSource onto the Default page and then named it &quot;SqlDataSource1&quot;, with the Select statement:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
Select * from TableName where [SomeField] In @Value

</pre>
<pre id="codePreview" class="html">
Select * from TableName where [SomeField] In @Value

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; background:white">
<span style="">Within this sample, the select statement of SqlDataSource1 is &quot;SELECT [Id], [Name] FROM [Test]&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; background:white">
<span style="color:black"><span style="">&nbsp;</span></span><span style=""> </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; background:white">
<span style="">Step 4:<span style="">&nbsp; </span>Drag and drop a <span style="">CheckBoxList, a SqlDataSource and two Buttons to the page. And then to rename them as &quot;CheckBoxList1&quot;,&quot;btnDynamicShow&quot;,&quot;btnStaticShow&quot; and &quot;</span>SqlDataSource2<span style="">&quot;.</span>
 SqlDataSource1 is used to get the selected data from table then bind to gridview. SqlDataSource2 is used to get all data's id from table then bind to the CheckBoxList.<span style="">&nbsp;
</span><span style="">btnDynamicShow is used to get data by selected ids dynamically. btnStaticShow is used to get data by
</span>specified static ids.<span style=""> </span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; background:white">
<span style=""><span style="">&nbsp;</span>After we checked some item of CheckBoxList then click the button, SqlDataSource1 will refresh the data bound to gridview by selected items.<br>
Then full source code of page will show as below: </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
<div>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; List of ID:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:CheckBoxList ID=&quot;CheckBoxList1&quot; runat=&quot;server&quot; DataSourceID=&quot;SqlDataSource2&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RepeatColumns=&quot;6&quot; RepeatDirection=&quot;Horizontal&quot; DataTextField=&quot;ID&quot; DataValueField=&quot;ID&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/asp:CheckBoxList&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:Button ID=&quot;btnDynamicShow&quot; runat=&quot;server&quot; Text=&quot;ShowDynamicData&quot; OnClick=&quot;btnDynamicShow_Click&quot; /&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:Button ID=&quot;btnStaticShow&quot; runat=&quot;server&quot; Text=&quot;ShowStaticData&quot; OnClick=&quot;btnStaticShow_Click&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Data of selected:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:GridView ID=&quot;GridView1&quot; runat=&quot;server&quot; DataSourceID=&quot;SqlDataSource1&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/asp:GridView&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:SqlDataSource ID=&quot;SqlDataSource1&quot; runat=&quot;server&quot; ConnectionString=&quot;&lt;%$ ConnectionStrings:ConnectionString %&gt;&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SelectCommand=&quot;SELECT [Id], [Name] FROM [Test]&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;%--&nbsp;&nbsp; SelectCommand=&quot;SELECT [Id], [Name] FROM [Test] WHERE ([Id] IN (@Id))&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;SelectParameters&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Parameter DefaultValue=&quot;1&quot; Name=&quot;Id&quot; Type=&quot;Int32&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/SelectParameters&gt;--%&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/asp:SqlDataSource&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:SqlDataSource ID=&quot;SqlDataSource2&quot; runat=&quot;server&quot; ConnectionString=&quot;&lt;%$ ConnectionStrings:ConnectionString %&gt;&quot;
&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SelectCommand=&quot;SELECT [Id], [Name] FROM [Test]&quot;&gt;&lt;/asp:SqlDataSource&gt;
&nbsp;&nbsp;&nbsp; </div>

</pre>
<pre id="codePreview" class="html">
<div>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; List of ID:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:CheckBoxList ID=&quot;CheckBoxList1&quot; runat=&quot;server&quot; DataSourceID=&quot;SqlDataSource2&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RepeatColumns=&quot;6&quot; RepeatDirection=&quot;Horizontal&quot; DataTextField=&quot;ID&quot; DataValueField=&quot;ID&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/asp:CheckBoxList&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:Button ID=&quot;btnDynamicShow&quot; runat=&quot;server&quot; Text=&quot;ShowDynamicData&quot; OnClick=&quot;btnDynamicShow_Click&quot; /&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:Button ID=&quot;btnStaticShow&quot; runat=&quot;server&quot; Text=&quot;ShowStaticData&quot; OnClick=&quot;btnStaticShow_Click&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Data of selected:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:GridView ID=&quot;GridView1&quot; runat=&quot;server&quot; DataSourceID=&quot;SqlDataSource1&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/asp:GridView&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:SqlDataSource ID=&quot;SqlDataSource1&quot; runat=&quot;server&quot; ConnectionString=&quot;&lt;%$ ConnectionStrings:ConnectionString %&gt;&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SelectCommand=&quot;SELECT [Id], [Name] FROM [Test]&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;%--&nbsp;&nbsp; SelectCommand=&quot;SELECT [Id], [Name] FROM [Test] WHERE ([Id] IN (@Id))&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;SelectParameters&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Parameter DefaultValue=&quot;1&quot; Name=&quot;Id&quot; Type=&quot;Int32&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/SelectParameters&gt;--%&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/asp:SqlDataSource&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:SqlDataSource ID=&quot;SqlDataSource2&quot; runat=&quot;server&quot; ConnectionString=&quot;&lt;%$ ConnectionStrings:ConnectionString %&gt;&quot;
&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SelectCommand=&quot;SELECT [Id], [Name] FROM [Test]&quot;&gt;&lt;/asp:SqlDataSource&gt;
&nbsp;&nbsp;&nbsp; </div>

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">You can comment the current SelectCommand of SqlDataSource1 and uncomment the other one. It only gets the specified data:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
SelectCommand=&quot;SELECT [Id], [Name] FROM [Test] WHERE ([Id] IN (@Id))&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;SelectParameters&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:Parameter DefaultValue=&quot;1&quot; Name=&quot;Id&quot; Type=&quot;Int32&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/SelectParameters&gt;

</pre>
<pre id="codePreview" class="html">
SelectCommand=&quot;SELECT [Id], [Name] FROM [Test] WHERE ([Id] IN (@Id))&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;SelectParameters&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:Parameter DefaultValue=&quot;1&quot; Name=&quot;Id&quot; Type=&quot;Int32&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/SelectParameters&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Handle the </span><span style="">click event of button.<span style="color:#A31515">
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' set the id dynamically
''' &lt;/summary&gt;
''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Protected Sub btnDynamicShow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDynamicShow.Click
&nbsp;&nbsp;&nbsp; ' list of selected id
&nbsp;&nbsp;&nbsp; Dim IDList As New List(Of String)()


&nbsp;&nbsp;&nbsp; For Each li As ListItem In CheckBoxList1.Items
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If li.Selected Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; IDList.Add(li.Value)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; Next


&nbsp;&nbsp;&nbsp; SqlDataSource1.SelectCommand = [String].Format(&quot;SELECT [Id], [Name] FROM [Test] WHERE ([Id] IN ({0}))&quot;, [String].Join(&quot;, &quot;, IDList.ToArray()))


End Sub


''' &lt;summary&gt;
''' Static id
''' &lt;/summary&gt;
''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Protected Sub btnStaticShow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnStaticShow.Click


&nbsp;&nbsp;&nbsp; 'Static id
&nbsp;&nbsp;&nbsp; Dim s As String = &quot;1,2,3,4,5&quot;
&nbsp;&nbsp;&nbsp; Dim strings As String() = s.Split(&quot;,&quot;c)


&nbsp;&nbsp;&nbsp; SqlDataSource1.SelectCommand = [String].Format(&quot;SELECT [Id], [Name] FROM [Test] WHERE ([Id] IN ({0}))&quot;, [String].Join(&quot;, &quot;, strings.ToArray()))
End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' set the id dynamically
''' &lt;/summary&gt;
''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Protected Sub btnDynamicShow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDynamicShow.Click
&nbsp;&nbsp;&nbsp; ' list of selected id
&nbsp;&nbsp;&nbsp; Dim IDList As New List(Of String)()


&nbsp;&nbsp;&nbsp; For Each li As ListItem In CheckBoxList1.Items
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If li.Selected Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; IDList.Add(li.Value)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; Next


&nbsp;&nbsp;&nbsp; SqlDataSource1.SelectCommand = [String].Format(&quot;SELECT [Id], [Name] FROM [Test] WHERE ([Id] IN ({0}))&quot;, [String].Join(&quot;, &quot;, IDList.ToArray()))


End Sub


''' &lt;summary&gt;
''' Static id
''' &lt;/summary&gt;
''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Protected Sub btnStaticShow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnStaticShow.Click


&nbsp;&nbsp;&nbsp; 'Static id
&nbsp;&nbsp;&nbsp; Dim s As String = &quot;1,2,3,4,5&quot;
&nbsp;&nbsp;&nbsp; Dim strings As String() = s.Split(&quot;,&quot;c)


&nbsp;&nbsp;&nbsp; SqlDataSource1.SelectCommand = [String].Format(&quot;SELECT [Id], [Name] FROM [Test] WHERE ([Id] IN ({0}))&quot;, [String].Join(&quot;, &quot;, strings.ToArray()))
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><sup><span style="color:red"><br>
</span></sup><span style="">Step 5: You can test and debug it. </span></p>
<h2>More Information</h2>
<p class="MsoNormal" style="">SqlDataSource.SelectCommand Property<br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.sqldatasource.selectcommand.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.sqldatasource.selectcommand.aspx</a><br>
SqlDataSource.SelectParameters Property<br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.sqldatasource.selectparameters">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.sqldatasource.selectparameters</a></p>
<p class="MsoNormal" style=""></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

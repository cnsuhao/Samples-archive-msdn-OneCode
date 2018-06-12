# Get selected item by code (VBASPNETGetSelectedValueOfAutoCompleteExtender)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* AJAX
* ASP.NET
## Topics
* AJAX
* AutoCompleteExtender
## IsPublished
* True
## ModifiedDate
* 2012-07-22 07:49:12
## Description

<h1>Get the selected item of AutoCompleteExtender at code behind (VBASPNETGetSelectedValueOfAutoCompleteExtender)</h1>
<h2>Introduction </h2>
<p class="MsoNormal">This demo shows how you can get selected item when you select an item from list populated by
<span class="SpellE">AutoCompleteExtender</span> at code behind. Normally, <span class="SpellE">
AutoCompleteExtender</span> works at client side and you can bind <span class="SpellE">
javascript</span> function to work with its selected value. However, sometimes we need this value to perform tasks that cannot be performed at client side, for example database operation, or sending new request to other web services. &#8203;In this sample,
 we just simulate a simple search statistics by operating database. </p>
<h2>Prerequisite </h2>
<p class="MsoNormal"><b style="">You need to install the <span class="SpellE">
AjaxControlToolkit</span>,</b> <b style="">you can download it here: <a href="http://ajaxcontroltoolkit.codeplex.com/">
http://ajaxcontroltoolkit.codeplex.com/</a></b> </p>
<h2>Running the Sample </h2>
<p class="MsoNormal">Please follow these demonstration steps below. </p>
<p class="MsoNormal">Step 1:&nbsp;Open the <span style="">VBASPNETGetSelectedValueOfAutoCompleteExtender</span>.sln. Expand the
<a name="OLE_LINK1"></a><span class="SpellE"><span style=""><span style="">VBASPNETGetSelectedValueOfAutoCompleteExtender</span></span></span><span style="">
</span>web application and press Ctrl &#43; F5 to show the Default.aspx. </p>
<p class="MsoNormal">Step 2: Enter part or complete name of the movie. </p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/62061/1/image.png" alt="" width="479" height="219" align="middle">
</span></p>
<p class="MsoNormal">Select an item. You can see the corresponding records. </p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/62062/1/image.png" alt="" width="424" height="115" align="middle">
</span></p>
<p class="MsoNormal">Step 3: Validation finished.</p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal">Step 1: Create a VB &quot;ASP.NET Web Application&quot; in Visual Studio 2010. Name it as &quot;<span style="">VBASPNETGetSelectedValueOfAutoCompleteExtender</span>&quot;.
</p>
<p class="MsoNormal">Step 2.<span style="">&nbsp; </span>Add a WebService and rename it to &quot;<span style="">AutoComplete</span>&quot;. This WebService is used to search for movies under the conditions. . Move the code file to the
<span class="SpellE">App_Code</span> folder.<span style=""> </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;%@ WebService Language=&quot;VB&quot; CodeBehind=&quot;~/App_Code/AutoComplete.vb&quot; Class=&quot;AutoComplete&quot; %&gt;

</pre>
<pre id="codePreview" class="vb">
&lt;%@ WebService Language=&quot;VB&quot; CodeBehind=&quot;~/App_Code/AutoComplete.vb&quot; Class=&quot;AutoComplete&quot; %&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><br>
The code of the WebService as shown below, _movies is a list of queries.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;System.Web.Services.WebService(Namespace:=&quot;http://tempuri.org/&quot;)&gt; _
&lt;System.Web.Script.Services.ScriptService()&gt; _
Public Class AutoComplete
    Inherits System.Web.Services.WebService


    Private _movies As New List(Of String)()


    Public Sub New()
        _movies.Add(&quot;a1&quot;)
        _movies.Add(&quot;a2&quot;)
        _movies.Add(&quot;b1&quot;)
        _movies.Add(&quot;China&quot;)
        _movies.Add(&quot;c21&quot;)
        _movies.Add(&quot;Dead&quot;)
        _movies.Add(&quot;Dear&quot;)
        _movies.Add(&quot;Dream&quot;)
        _movies.Add(&quot;Empty&quot;)
        _movies.Add(&quot;Egg&quot;)
        _movies.Add(&quot;Flower&quot;)
        _movies.Add(&quot;Floor&quot;)
        _movies.Add(&quot;Great&quot;)
        _movies.Add(&quot;g&quot;)
        _movies.Add(&quot;h1&quot;)
        _movies.Add(&quot;h2&quot;)
        _movies.Add(&quot;i1&quot;)
        _movies.Add(&quot;jeep&quot;)
        _movies.Add(&quot;k&quot;)
        _movies.Add(&quot;Loop&quot;)
        _movies.Add(&quot;Man&quot;)
        _movies.Add(&quot;Nice&quot;)
        _movies.Add(&quot;O1&quot;)
        _movies.Add(&quot;Pear&quot;)
        _movies.Add(&quot;Queen&quot;)
        _movies.Add(&quot;Rest&quot;)
        _movies.Add(&quot;S1&quot;)
        _movies.Add(&quot;S2&quot;)
        _movies.Add(&quot;T1 &quot;)
        _movies.Add(&quot;T2 &quot;)
        _movies.Add(&quot;US&quot;)
        _movies.Add(&quot;UK&quot;)
        _movies.Add(&quot;V&quot;)
        _movies.Add(&quot;W&quot;)
        _movies.Add(&quot;X&quot;)
        _movies.Add(&quot;Y&quot;)
        _movies.Add(&quot;Z&quot;)
    End Sub


    &lt;WebMethod()&gt; _
    Public Function GetMovies(ByVal prefixText As String, ByVal count As Integer) As String()
        If count = 0 Then
            count = 10
        End If


        Dim matches = (From m In _movies Where (m.StartsWith(prefixText, StringComparison.CurrentCultureIgnoreCase)) Select m).Take(count)
        Return matches.ToArray()
    End Function
End Class

</pre>
<pre id="codePreview" class="vb">
&lt;System.Web.Services.WebService(Namespace:=&quot;http://tempuri.org/&quot;)&gt; _
&lt;System.Web.Script.Services.ScriptService()&gt; _
Public Class AutoComplete
    Inherits System.Web.Services.WebService


    Private _movies As New List(Of String)()


    Public Sub New()
        _movies.Add(&quot;a1&quot;)
        _movies.Add(&quot;a2&quot;)
        _movies.Add(&quot;b1&quot;)
        _movies.Add(&quot;China&quot;)
        _movies.Add(&quot;c21&quot;)
        _movies.Add(&quot;Dead&quot;)
        _movies.Add(&quot;Dear&quot;)
        _movies.Add(&quot;Dream&quot;)
        _movies.Add(&quot;Empty&quot;)
        _movies.Add(&quot;Egg&quot;)
        _movies.Add(&quot;Flower&quot;)
        _movies.Add(&quot;Floor&quot;)
        _movies.Add(&quot;Great&quot;)
        _movies.Add(&quot;g&quot;)
        _movies.Add(&quot;h1&quot;)
        _movies.Add(&quot;h2&quot;)
        _movies.Add(&quot;i1&quot;)
        _movies.Add(&quot;jeep&quot;)
        _movies.Add(&quot;k&quot;)
        _movies.Add(&quot;Loop&quot;)
        _movies.Add(&quot;Man&quot;)
        _movies.Add(&quot;Nice&quot;)
        _movies.Add(&quot;O1&quot;)
        _movies.Add(&quot;Pear&quot;)
        _movies.Add(&quot;Queen&quot;)
        _movies.Add(&quot;Rest&quot;)
        _movies.Add(&quot;S1&quot;)
        _movies.Add(&quot;S2&quot;)
        _movies.Add(&quot;T1 &quot;)
        _movies.Add(&quot;T2 &quot;)
        _movies.Add(&quot;US&quot;)
        _movies.Add(&quot;UK&quot;)
        _movies.Add(&quot;V&quot;)
        _movies.Add(&quot;W&quot;)
        _movies.Add(&quot;X&quot;)
        _movies.Add(&quot;Y&quot;)
        _movies.Add(&quot;Z&quot;)
    End Sub


    &lt;WebMethod()&gt; _
    Public Function GetMovies(ByVal prefixText As String, ByVal count As Integer) As String()
        If count = 0 Then
            count = 10
        End If


        Dim matches = (From m In _movies Where (m.StartsWith(prefixText, StringComparison.CurrentCultureIgnoreCase)) Select m).Take(count)
        Return matches.ToArray()
    End Function
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><br>
Step 3:<span style="">&nbsp; </span>Add an AutoCompleteExtender Control, a TextBox Control, a HiddenField Control and a
<span class="SpellE">LinkButton</span> control to the Default.aspx. </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;AjaxControlToolkit:ToolkitScriptManager CombineScripts=&quot;false&quot; runat=&quot;server&quot; EnablePartialRendering=&quot;true&quot;&gt;
 &lt;/AjaxControlToolkit:ToolkitScriptManager&gt;        
 <div>
     <table border="1"><caption>
             Search Movies
         </caption><tbody><tr><td colspan="4">You
 can input part or complete of the movie name, and then select one item. </td></tr><tr><td>MovieName: &lt;asp:TextBox ID=&quot;tbMovies&quot; runat=&quot;server&quot; Text=''&gt;&lt;/asp:TextBox&gt; &lt;AjaxControlToolkit:AutoCompleteExtender ID=&quot;AutoCompleteExtender1&quot; BehaviorID=&quot;ACE&quot; runat=&quot;server&quot;
 TargetControlID=&quot;tbMovies&quot; ServicePath=&quot;AutoComplete.asmx&quot; ServiceMethod=&quot;GetMovies&quot; MinimumPrefixLength=&quot;1&quot; CompletionInterval=&quot;10&quot; CompletionSetCount=&quot;10&quot; EnableCaching=&quot;true&quot; /&gt; </td><td>&lt;asp:GridView runat=&quot;server&quot; ID=&quot;gdvKeyword&quot; EnableModelValidation=&quot;True&quot;
 AutoGenerateColumns=&quot;False&quot; DataKeyNames=&quot;Id&quot;&gt; &lt;Columns&gt; &lt;asp:BoundField DataField=&quot;Id&quot; HeaderText=&quot;Id&quot; InsertVisible=&quot;False&quot; ReadOnly=&quot;True&quot; SortExpression=&quot;Id&quot; /&gt; &lt;asp:BoundField DataField=&quot;Keywords&quot; HeaderText=&quot;Keywords&quot; SortExpression=&quot;Keywords&quot; /&gt; &lt;asp:BoundField
 DataField=&quot;Count&quot; HeaderText=&quot;Count&quot; SortExpression=&quot;Count&quot; /&gt; &lt;/Columns&gt; &lt;/asp:GridView&gt; </td></tr></tbody></table>
     &lt;asp:LinkButton ID=&quot;LinkButton1&quot; runat=&quot;server&quot; OnClick=&quot;LinkButton1_Click&quot;&gt;&lt;/asp:LinkButton&gt;
     &lt;asp:HiddenField ID=&quot;hf1&quot; runat=&quot;server&quot; /&gt;
 </div>


 &lt;script src=&quot;AutoComplete.js&quot; type=&quot;text/javascript&quot;&gt;&lt;/script&gt;

</pre>
<pre id="codePreview" class="html">
&lt;AjaxControlToolkit:ToolkitScriptManager CombineScripts=&quot;false&quot; runat=&quot;server&quot; EnablePartialRendering=&quot;true&quot;&gt;
 &lt;/AjaxControlToolkit:ToolkitScriptManager&gt;        
 <div>
     <table border="1"><caption>
             Search Movies
         </caption><tbody><tr><td colspan="4">You
 can input part or complete of the movie name, and then select one item. </td></tr><tr><td>MovieName: &lt;asp:TextBox ID=&quot;tbMovies&quot; runat=&quot;server&quot; Text=''&gt;&lt;/asp:TextBox&gt; &lt;AjaxControlToolkit:AutoCompleteExtender ID=&quot;AutoCompleteExtender1&quot; BehaviorID=&quot;ACE&quot; runat=&quot;server&quot;
 TargetControlID=&quot;tbMovies&quot; ServicePath=&quot;AutoComplete.asmx&quot; ServiceMethod=&quot;GetMovies&quot; MinimumPrefixLength=&quot;1&quot; CompletionInterval=&quot;10&quot; CompletionSetCount=&quot;10&quot; EnableCaching=&quot;true&quot; /&gt; </td><td>&lt;asp:GridView runat=&quot;server&quot; ID=&quot;gdvKeyword&quot; EnableModelValidation=&quot;True&quot;
 AutoGenerateColumns=&quot;False&quot; DataKeyNames=&quot;Id&quot;&gt; &lt;Columns&gt; &lt;asp:BoundField DataField=&quot;Id&quot; HeaderText=&quot;Id&quot; InsertVisible=&quot;False&quot; ReadOnly=&quot;True&quot; SortExpression=&quot;Id&quot; /&gt; &lt;asp:BoundField DataField=&quot;Keywords&quot; HeaderText=&quot;Keywords&quot; SortExpression=&quot;Keywords&quot; /&gt; &lt;asp:BoundField
 DataField=&quot;Count&quot; HeaderText=&quot;Count&quot; SortExpression=&quot;Count&quot; /&gt; &lt;/Columns&gt; &lt;/asp:GridView&gt; </td></tr></tbody></table>
     &lt;asp:LinkButton ID=&quot;LinkButton1&quot; runat=&quot;server&quot; OnClick=&quot;LinkButton1_Click&quot;&gt;&lt;/asp:LinkButton&gt;
     &lt;asp:HiddenField ID=&quot;hf1&quot; runat=&quot;server&quot; /&gt;
 </div>


 &lt;script src=&quot;AutoComplete.js&quot; type=&quot;text/javascript&quot;&gt;&lt;/script&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">[Note]: The following section is very important.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;AjaxControlToolkit:ToolkitScriptManager CombineScripts=&quot;false&quot; runat=&quot;server&quot; EnablePartialRendering=&quot;true&quot;&gt;
    &lt;/AjaxControlToolkit:ToolkitScriptManager&gt;

</pre>
<pre id="codePreview" class="html">
&lt;AjaxControlToolkit:ToolkitScriptManager CombineScripts=&quot;false&quot; runat=&quot;server&quot; EnablePartialRendering=&quot;true&quot;&gt;
    &lt;/AjaxControlToolkit:ToolkitScriptManager&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><br>
Step 4: Write the JavaScript file for the feature.</p>
<p class="MsoNormal" style="">Step 5: <span style="">The database name is &quot;sample&quot; and the definition of the table &quot;<span class="SpellE">KeywordsStatistics</span>&quot; as shown below:</span><span style="color:black">
<span style="">&nbsp;&nbsp;&nbsp; </span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">mysql</span>
<pre class="hidden">
CREATE TABLE [dbo].[KeywordsStatistics](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Keywords] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Count] [int] NULL,
 CONSTRAINT [PK_KeywordsStatistics] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

</pre>
<pre id="codePreview" class="mysql">
CREATE TABLE [dbo].[KeywordsStatistics](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Keywords] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Count] [int] NULL,
 CONSTRAINT [PK_KeywordsStatistics] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="">Write the Server Side code.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
    ''' Bind datatable to GridView
    ''' &lt;/summary&gt;
    Private Sub BindGrid()
        'Query string
        Dim queryString As String = &quot;SELECT [Id], [Keywords], [Count] FROM [KeywordsStatistics]&quot;
        Dim adapter As New SqlDataAdapter()
        'set query string
        adapter.SelectCommand = New SqlCommand(queryString, connection)
        'Open connection
        connection.Open()
        'Sql data is stored DataSet.                 
        Dim sqlData As New DataSet()
        adapter.Fill(sqlData, &quot;KeywordsStatistics&quot;)
        'Close connection
        connection.Close()


        'Bind datatable to GridView
        gdvKeyword.DataSource = sqlData.Tables(0)
        gdvKeyword.DataBind()
    End Sub


    'database operation
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Get the selected value of the AutoCompleteExtender
        Dim hifvalue As String = hf1.Value


        Dim queryString As String = &quot;SELECT id FROM [KeywordsStatistics] where Keywords=@Keyword&quot;
        Dim para As New SqlParameter(&quot;Keyword&quot;, hifvalue)
        Dim command As New SqlCommand(queryString, connection)
        command.Parameters.Add(para)
        connection.Open()
        Dim reader As SqlDataReader = command.ExecuteReader()


        'If there is a corresponding search records, update the statistics.Otherwise, add a new record
        If reader.HasRows Then
            'Update the statistics
            queryString = &quot;update KeywordsStatistics set Count=count&#43;1 where Keywords=@Keyword&quot;
        Else
            'Add a new record
            queryString = &quot;Insert into [KeywordsStatistics](Keywords, Count)values(@Keyword,1)&quot;
        End If
        reader.Close()
        command.CommandText = queryString
        command.ExecuteNonQuery()
        connection.Close()


        BindGrid()
    End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
    ''' Bind datatable to GridView
    ''' &lt;/summary&gt;
    Private Sub BindGrid()
        'Query string
        Dim queryString As String = &quot;SELECT [Id], [Keywords], [Count] FROM [KeywordsStatistics]&quot;
        Dim adapter As New SqlDataAdapter()
        'set query string
        adapter.SelectCommand = New SqlCommand(queryString, connection)
        'Open connection
        connection.Open()
        'Sql data is stored DataSet.                 
        Dim sqlData As New DataSet()
        adapter.Fill(sqlData, &quot;KeywordsStatistics&quot;)
        'Close connection
        connection.Close()


        'Bind datatable to GridView
        gdvKeyword.DataSource = sqlData.Tables(0)
        gdvKeyword.DataBind()
    End Sub


    'database operation
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Get the selected value of the AutoCompleteExtender
        Dim hifvalue As String = hf1.Value


        Dim queryString As String = &quot;SELECT id FROM [KeywordsStatistics] where Keywords=@Keyword&quot;
        Dim para As New SqlParameter(&quot;Keyword&quot;, hifvalue)
        Dim command As New SqlCommand(queryString, connection)
        command.Parameters.Add(para)
        connection.Open()
        Dim reader As SqlDataReader = command.ExecuteReader()


        'If there is a corresponding search records, update the statistics.Otherwise, add a new record
        If reader.HasRows Then
            'Update the statistics
            queryString = &quot;update KeywordsStatistics set Count=count&#43;1 where Keywords=@Keyword&quot;
        Else
            'Add a new record
            queryString = &quot;Insert into [KeywordsStatistics](Keywords, Count)values(@Keyword,1)&quot;
        End If
        reader.Close()
        command.CommandText = queryString
        command.ExecuteNonQuery()
        connection.Close()


        BindGrid()
    End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="">Step 6: Build the application and you can debug it.</p>
<p class="MsoNormal" style=""><a href="http://www.asp.net/ajaxLibrary/AjaxControlToolkitSampleSite/Rating/Rating.aspx"><span class="SpellE">AjaxControlToolkitSampleSite</span></a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
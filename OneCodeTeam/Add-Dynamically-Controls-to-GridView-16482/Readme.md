# Add Dynamically Controls to GridView (AddDynamicallyControlstoGridView)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* GridView
## IsPublished
* True
## ModifiedDate
* 2012-04-20 01:09:37
## Description

<h1>Add Dynamic LinkButton in Gridview(VBASPNETAddDynamicControltoGridView)</h1>
<h2>Introduction </h2>
<p class="MsoNormal">The sample code demonstrates how to add dynamically created controls to the GridView in the CodeBehind page. For some people, when the refresh or the page is PostBack, the dynamically created controls will disappear from GridView, this
 sample will show how to resolve this issue.</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Please follow these demonstration steps below.</p>
<p class="MsoNormal">Step 1:&nbsp;Open the <span style="">VBASPNETAddDynamicControltoGridView</span>.sln. Expand the
<a name="OLE_LINK1"><span style="">VBASPNETAddDynamicControltoGridView</span> </a>
web application and press Ctrl &#43; F5 to show the Default.aspx. </p>
<p class="MsoNormal">Step 2: We will see a web page like show below:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/56385/1/image.png" alt="" width="567" height="314" align="middle">
</span></p>
<p class="MsoNormal">Step 3:<span style="">&nbsp; </span>Click on a LinkButton to do a PostBack operations, the page will like show below:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/56386/1/image.png" alt="" width="509" height="336" align="middle">
</span></p>
<p class="MsoNormal">Step 4:<span style="">&nbsp;&nbsp; </span>Validation finished.</p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal">Step 1. Create a VB &quot;ASP.NET Web Application&quot; in Visual Studio 2010/Visual Web Developer 2010. Name it as ��<span style="">VBASPNETAddDynamicControltoGridView</span>&quot;.
</p>
<p class="MsoNormal">Step 2.<span style="">&nbsp; </span>Add a GridView Control to ��Default.aspx�� page then rename it to &quot;gdvCustomer&quot;. This page will bind the data and show the dynamically created LinkButton Control. In order to realize this
 page:</p>
<p class="MsoNormal">First, we need to bind data to gdvCustomer<span style="color:black">.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;asp:GridView ID=&quot;gdvCustomer&quot; runat=&quot;server&quot; AutoGenerateColumns=&quot;False&quot; OnDataBound=&quot;gdvCustomer_DataBound&quot;
           DataKeyNames=&quot;Id&quot; DataSourceID=&quot;SqlDataSource1&quot; &gt;
           &lt;Columns&gt;
               &lt;asp:BoundField DataField=&quot;Id&quot; HeaderText=&quot;Id&quot; InsertVisible=&quot;False&quot; ReadOnly=&quot;True&quot;
                   SortExpression=&quot;Id&quot; /&gt;
               &lt;asp:BoundField DataField=&quot;Name&quot; HeaderText=&quot;Name&quot; SortExpression=&quot;Name&quot; /&gt;
               &lt;asp:BoundField DataField=&quot;Email&quot; HeaderText=&quot;Email&quot; SortExpression=&quot;Email&quot; /&gt;              
           &lt;/Columns&gt;
       &lt;/asp:GridView&gt;
       &lt;asp:SqlDataSource ID=&quot;SqlDataSource1&quot; runat=&quot;server&quot; 
           ConnectionString=&quot;&lt;%$ ConnectionStrings:ConnectionString %&gt;&quot; 
           SelectCommand=&quot;SELECT [Id], [Name], [Email] FROM [CustomerInfo]&quot;&gt;
       &lt;/asp:SqlDataSource&gt;

</pre>
<pre id="codePreview" class="html">
&lt;asp:GridView ID=&quot;gdvCustomer&quot; runat=&quot;server&quot; AutoGenerateColumns=&quot;False&quot; OnDataBound=&quot;gdvCustomer_DataBound&quot;
           DataKeyNames=&quot;Id&quot; DataSourceID=&quot;SqlDataSource1&quot; &gt;
           &lt;Columns&gt;
               &lt;asp:BoundField DataField=&quot;Id&quot; HeaderText=&quot;Id&quot; InsertVisible=&quot;False&quot; ReadOnly=&quot;True&quot;
                   SortExpression=&quot;Id&quot; /&gt;
               &lt;asp:BoundField DataField=&quot;Name&quot; HeaderText=&quot;Name&quot; SortExpression=&quot;Name&quot; /&gt;
               &lt;asp:BoundField DataField=&quot;Email&quot; HeaderText=&quot;Email&quot; SortExpression=&quot;Email&quot; /&gt;              
           &lt;/Columns&gt;
       &lt;/asp:GridView&gt;
       &lt;asp:SqlDataSource ID=&quot;SqlDataSource1&quot; runat=&quot;server&quot; 
           ConnectionString=&quot;&lt;%$ ConnectionStrings:ConnectionString %&gt;&quot; 
           SelectCommand=&quot;SELECT [Id], [Name], [Email] FROM [CustomerInfo]&quot;&gt;
       &lt;/asp:SqlDataSource&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><br>
Then, we need to call DataBound method to add dynamically created Control<span style="color:black">.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Protected Sub gdvCustomer_DataBound(ByVal sender As Object, ByVal e As EventArgs)
       AddLinkButton()
   End Sub


''' &lt;summary&gt;
   ''' Add a LinkButton To GridView Row.
   ''' &lt;/summary&gt;
   Private Sub AddLinkButton()
       For Each row As GridViewRow In gdvCustomer.Rows
           If row.RowType = DataControlRowType.DataRow Then
               Dim lb As New LinkButton()
               lb.Text = &quot;Approve&quot;
               lb.CommandName = &quot;ApproveVacation&quot;
               AddHandler lb.Command, AddressOf LinkButton_Command
               row.Cells(0).Controls.Add(lb)
           End If
       Next
   End Sub

</pre>
<pre id="codePreview" class="vb">
Protected Sub gdvCustomer_DataBound(ByVal sender As Object, ByVal e As EventArgs)
       AddLinkButton()
   End Sub


''' &lt;summary&gt;
   ''' Add a LinkButton To GridView Row.
   ''' &lt;/summary&gt;
   Private Sub AddLinkButton()
       For Each row As GridViewRow In gdvCustomer.Rows
           If row.RowType = DataControlRowType.DataRow Then
               Dim lb As New LinkButton()
               lb.Text = &quot;Approve&quot;
               lb.CommandName = &quot;ApproveVacation&quot;
               AddHandler lb.Command, AddressOf LinkButton_Command
               row.Cells(0).Controls.Add(lb)
           End If
       Next
   End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">To<span style="color:black"> test the LinkButton, we add an event for the LinkButton .
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Protected Sub LinkButton_Command(ByVal sender As Object, ByVal e As CommandEventArgs)
       If e.CommandName = &quot;ApproveVacation&quot; Then
           'This is to test 
           Dim lb As LinkButton = DirectCast(sender, LinkButton)
           lb.Text = &quot;OK&quot;
       End If
   End Sub

</pre>
<pre id="codePreview" class="vb">
Protected Sub LinkButton_Command(ByVal sender As Object, ByVal e As CommandEventArgs)
       If e.CommandName = &quot;ApproveVacation&quot; Then
           'This is to test 
           Dim lb As LinkButton = DirectCast(sender, LinkButton)
           lb.Text = &quot;OK&quot;
       End If
   End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="color:black"><br>
<b style="">[Note]</b>Finally, add LinkButton in the Page_Init event and override the OnInit method.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
       gdvCustomer.DataBind()
   End Sub


   Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
       If Not IsPostBack Then
           AddLinkButton()
       End If
   End Sub


   ''' &lt;summary&gt;
   ''' To initialize the page.
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
   Protected Overrides Sub OnInit(ByVal e As EventArgs)
       'AddHandler Me.Init, AddressOf Page_Init
       MyBase.OnInit(e)
   End Sub

</pre>
<pre id="codePreview" class="vb">
Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
       gdvCustomer.DataBind()
   End Sub


   Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
       If Not IsPostBack Then
           AddLinkButton()
       End If
   End Sub


   ''' &lt;summary&gt;
   ''' To initialize the page.
   ''' &lt;/summary&gt;
   ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
   Protected Overrides Sub OnInit(ByVal e As EventArgs)
       'AddHandler Me.Init, AddressOf Page_Init
       MyBase.OnInit(e)
   End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><br>
Step 3. Build the application and you can debug it.</p>
<h2>More Information</h2>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/ms178472.aspx">ASP.NET Page Life Cycle Overview</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

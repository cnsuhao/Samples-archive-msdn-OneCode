# Pagination using SPquery (VBSharePointPaginationWebPart)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* SharePoint
## Topics
* SharePoint
* Pagination
* SPquery
## IsPublished
* True
## ModifiedDate
* 2012-07-22 07:36:51
## Description

<h1><span style="">How to implement </span>pagination through <span class="SpellE">
SPQuery</span> (<span class="SpellE">VBSharePointPaginationWebPart</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal" style=""><span style="">This sample code demonstrates <a name="OLE_LINK2">
</a><a name="OLE_LINK1"><span style="">how to implement pagination through </span>
</a><span class="SpellE"><span style=""><span style="">SPquery</span></span></span><span style=""></span><span style=""></span>. The sample will fetch the list items from a specified web site. You can set how many pages have to be shown for our custom pagination.
 For e.g., if you have 100 items in a list, and <span class="SpellE">rowlimt</span>=50 then the total number of pages should be 2.
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style=""><span style="">&nbsp;</span>Please follow the steps below.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 1: Open the VBSharePointPaginationWebPart.sln file and then set the &quot;Site URL&quot; to your own site.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Open the <span class="SpellE">PaginationWebPartUserControl.ascx.vb</span> file to modify the &quot;SiteCollectionUrl&quot; and list name. The &quot;SiteCollectionUrl&quot; specifies the site we will search. And the List Name specifies
 the list from which we will get data for our data control. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><br>
Step 3: After that right-click the &quot;VBSharePointPaginationWebPart&quot; project and click &quot;Deploy&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""><br>
Step 4: Open the SharePoint site in the browser and then select &quot;Page&quot;<br>
</span><span style="font-size:9.5pt"><img src="/site/view/file/61937/1/image.png" alt="" width="1041" height="350" align="middle">
</span><span style="font-size:9.5pt"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 5: Select Edit.<br>
<span style=""><img src="/site/view/file/61938/1/image.png" alt="" width="895" height="222" align="middle">
</span><br>
<br style="">
<br style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 6: Select &quot;Insert&quot; Tab and click &quot;Web Part&quot;.<br>
<span style="color:black">In &quot;Categories&quot;, select &quot;Custom&quot; and in &quot;Web Parts&quot; column select &quot;<span class="SpellE">PaginationWebPart</span>&quot;. Click on &quot;Add&quot; button, then click &quot;OK&quot;, you will see our
<span class="SpellE">PaginationWebPart</span> appears in the SharePoint site as follows</span>:
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/61939/1/image.png" alt="" width="628" height="252" align="middle">
</span></p>
<p class="MsoNormal"><span style="">Then we can view the list data by clicking the &quot;Pre&quot; button and the &quot;Next&quot; button.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 8: Validation is completed. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Create a VB &quot;Empty SharePoint Project&quot; in Visual Studio 2010 and named it as &quot;VBSharePointPaginationWebPart &quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal"><span style="">Step 2: Right-click the project and add a new &quot;Visual Web Part&quot; item to our project and named it as &quot;VBSharePointPaginationWebPart&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: To show the List Data, we should <span style="color:black">
add a <span class="SpellE">SPGridView</span> on the User Control. For the custom Pagination we
</span>add two buttons to the page and edit the text to &quot;Pre&quot; and &quot;Next&quot;. The source code of the page as shown below:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;SharePoint:SPGridView runat=&quot;server&quot; ID=&quot;GridView2&quot; AutoGenerateColumns=&quot;false&quot;&gt;
    &lt;Columns&gt;
        &lt;asp:BoundField DataField=&quot;Title&quot; HeaderText=&quot;Title&quot; SortExpression=&quot;Title&quot; /&gt;
    &lt;/Columns&gt;
&lt;/SharePoint:SPGridView&gt;


&lt;asp:Button ID=&quot;btnPre&quot; runat=&quot;server&quot; Text=&quot;Pre&quot; OnClick=&quot;btnPre_Click&quot; /&gt;
&nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:Button ID=&quot;btnNext&quot; runat=&quot;server&quot; Text=&quot;Next&quot; OnClick=&quot;btnNext_Click&quot; /&gt;

</pre>
<pre id="codePreview" class="html">
&lt;SharePoint:SPGridView runat=&quot;server&quot; ID=&quot;GridView2&quot; AutoGenerateColumns=&quot;false&quot;&gt;
    &lt;Columns&gt;
        &lt;asp:BoundField DataField=&quot;Title&quot; HeaderText=&quot;Title&quot; SortExpression=&quot;Title&quot; /&gt;
    &lt;/Columns&gt;
&lt;/SharePoint:SPGridView&gt;


&lt;asp:Button ID=&quot;btnPre&quot; runat=&quot;server&quot; Text=&quot;Pre&quot; OnClick=&quot;btnPre_Click&quot; /&gt;
&nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:Button ID=&quot;btnNext&quot; runat=&quot;server&quot; Text=&quot;Next&quot; OnClick=&quot;btnNext_Click&quot; /&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas; color:maroon"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 4: <span style="color:black">At the code-behind, first we add the reference of &quot;</span><span class="SpellE">Microsoft.SharePoint</span>&quot;. Then we add a method which is used to query the list data by
<span class="SpellE">SPQuery</span>. We will pass two parameters for the method:
<span class="SpellE">rowlimit</span> and <span class="SpellE">pageNo</span>. The method returns a
<span class="SpellE"><span style="color:black">SPListItemCollection</span></span><span style="color:#2B91AF">.
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' your siteurl
       Dim SiteCollectionUrl As String = &quot;http://localhost:7947&quot;


       ' Connect to Sharepoint Site
       Using site As New SPSite(SiteCollectionUrl)
           ' Open Sharepoint Site
           Using oWebsiteRoot As SPWeb = site.OpenWeb()
               ' Get the list by list name
               Dim oList As SPList = oWebsiteRoot.Lists(&quot;test1&quot;)  'list_name


               ' Get the number of the items in the list
               Dim TotalListItems As Integer = oList.ItemCount
               ' Get the count of the page
               Dim iPageCount As Integer = CInt(Math.Ceiling(TotalListItems / CDec(rowlimit)))


               ViewState(&quot;PageCount&quot;) = iPageCount


               ' SPQuery
               Dim query As New SPQuery()
               query.RowLimit = CUInt(rowlimit)
               query.Query = &quot;&lt;OrderBy Override=&quot;&quot;TRUE&quot;&quot;&gt;&lt;FieldRef Name=&quot;&quot;FileLeafRef&quot;&quot; /&gt;&lt;/OrderBy&gt;&quot;


               Dim index As Integer = 1
               Dim items As SPListItemCollection


               Do
                   items = oList.GetItems(query)
                   If index = pageNo Then
                       Exit Do
                   End If
                   query.ListItemCollectionPosition = items.ListItemCollectionPosition
                   index &#43;= 1
               Loop While query.ListItemCollectionPosition IsNot Nothing


               Return items
           End Using
       End Using

</pre>
<pre id="codePreview" class="vb">
' your siteurl
       Dim SiteCollectionUrl As String = &quot;http://localhost:7947&quot;


       ' Connect to Sharepoint Site
       Using site As New SPSite(SiteCollectionUrl)
           ' Open Sharepoint Site
           Using oWebsiteRoot As SPWeb = site.OpenWeb()
               ' Get the list by list name
               Dim oList As SPList = oWebsiteRoot.Lists(&quot;test1&quot;)  'list_name


               ' Get the number of the items in the list
               Dim TotalListItems As Integer = oList.ItemCount
               ' Get the count of the page
               Dim iPageCount As Integer = CInt(Math.Ceiling(TotalListItems / CDec(rowlimit)))


               ViewState(&quot;PageCount&quot;) = iPageCount


               ' SPQuery
               Dim query As New SPQuery()
               query.RowLimit = CUInt(rowlimit)
               query.Query = &quot;&lt;OrderBy Override=&quot;&quot;TRUE&quot;&quot;&gt;&lt;FieldRef Name=&quot;&quot;FileLeafRef&quot;&quot; /&gt;&lt;/OrderBy&gt;&quot;


               Dim index As Integer = 1
               Dim items As SPListItemCollection


               Do
                   items = oList.GetItems(query)
                   If index = pageNo Then
                       Exit Do
                   End If
                   query.ListItemCollectionPosition = items.ListItemCollectionPosition
                   index &#43;= 1
               Loop While query.ListItemCollectionPosition IsNot Nothing


               Return items
           End Using
       End Using

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="color:#333333"><br>
If you need to specify the sort condition, please modify the following code: </span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
query.Query = &quot;&lt;OrderBy Override=&quot;&quot;TRUE&quot;&quot;&gt;&lt;FieldRef Name=&quot;&quot;FileLeafRef&quot;&quot; /&gt;&lt;/OrderBy&gt;&quot;

</pre>
<pre id="codePreview" class="vb">
query.Query = &quot;&lt;OrderBy Override=&quot;&quot;TRUE&quot;&quot;&gt;&lt;FieldRef Name=&quot;&quot;FileLeafRef&quot;&quot; /&gt;&lt;/OrderBy&gt;&quot;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 5: Create a &quot;<span class="SpellE">BindData</span>&quot; method for binding data. This method needs a string parameter which is used to change Page No.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Current Page No
       Dim intCurrentPageNo As Integer = 1


       If Not String.IsNullOrEmpty(strOperation) Then
           ' The Page count of the list data by the rowlimit
           Dim iPageCount As Integer = 0


           ' Store the PageNo and PageCount by ViewState.
           If ViewState(&quot;CurrentPageNo&quot;) IsNot Nothing Then
               intCurrentPageNo = Convert.ToInt32(ViewState(&quot;CurrentPageNo&quot;))
           End If
           If ViewState(&quot;PageCount&quot;) IsNot Nothing Then
               iPageCount = Convert.ToInt32(ViewState(&quot;PageCount&quot;))
               ViewState(&quot;PageCount&quot;) = iPageCount
           End If


           ' Into the page logic if the current page number is not greater than the total number of pages.
           If intCurrentPageNo &lt;= iPageCount Then
               Select Case strOperation
                   Case &quot;Pre&quot; 'Pervious Page
                       If intCurrentPageNo &gt; 1 Then
                           intCurrentPageNo = intCurrentPageNo - 1
                       End If
                       Exit Select
                   Case &quot;Next&quot; 'Next Page
                       intCurrentPageNo = intCurrentPageNo &#43; 1
                       Exit Select
                   Case Else
                       Exit Select
               End Select
           End If
       End If


       ViewState(&quot;CurrentPageNo&quot;) = intCurrentPageNo


       ' Get current page's data and then bind to SPGridView
       Dim items As SPListItemCollection = GetListItems(5, intCurrentPageNo)
       GridView2.DataSource = items
       GridView2.DataBind()

</pre>
<pre id="codePreview" class="vb">
' Current Page No
       Dim intCurrentPageNo As Integer = 1


       If Not String.IsNullOrEmpty(strOperation) Then
           ' The Page count of the list data by the rowlimit
           Dim iPageCount As Integer = 0


           ' Store the PageNo and PageCount by ViewState.
           If ViewState(&quot;CurrentPageNo&quot;) IsNot Nothing Then
               intCurrentPageNo = Convert.ToInt32(ViewState(&quot;CurrentPageNo&quot;))
           End If
           If ViewState(&quot;PageCount&quot;) IsNot Nothing Then
               iPageCount = Convert.ToInt32(ViewState(&quot;PageCount&quot;))
               ViewState(&quot;PageCount&quot;) = iPageCount
           End If


           ' Into the page logic if the current page number is not greater than the total number of pages.
           If intCurrentPageNo &lt;= iPageCount Then
               Select Case strOperation
                   Case &quot;Pre&quot; 'Pervious Page
                       If intCurrentPageNo &gt; 1 Then
                           intCurrentPageNo = intCurrentPageNo - 1
                       End If
                       Exit Select
                   Case &quot;Next&quot; 'Next Page
                       intCurrentPageNo = intCurrentPageNo &#43; 1
                       Exit Select
                   Case Else
                       Exit Select
               End Select
           End If
       End If


       ViewState(&quot;CurrentPageNo&quot;) = intCurrentPageNo


       ' Get current page's data and then bind to SPGridView
       Dim items As SPListItemCollection = GetListItems(5, intCurrentPageNo)
       GridView2.DataSource = items
       GridView2.DataBind()

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">At the beginning of the method, we check and calculate the page no.<span style="">&nbsp;
</span>The argument &quot;</span><span class="SpellE"><span style="color:black">strOperation</span></span><span style="color:black">&quot;</span><span style=""> is passed from the click event of the button. At the end of the method, we bind the current list
 data to <span class="SpellE">SPGridView</span>. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">&quot;Pre&quot; and &quot;Next&quot; buttons work by using the following code:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Protected Sub btnPre_Click(ByVal sender As Object, ByVal e As EventArgs)
       BindData(&quot;Pre&quot;)
   End Sub
Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As EventArgs)
       BindData(&quot;Next&quot;)
   End Sub

</pre>
<pre id="codePreview" class="vb">
Protected Sub btnPre_Click(ByVal sender As Object, ByVal e As EventArgs)
       BindData(&quot;Pre&quot;)
   End Sub
Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As EventArgs)
       BindData(&quot;Next&quot;)
   End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"><br>
</span><span style="">Step 6: You can debug and test it. </span></p>
<p class="MsoNormal" style="">SPQuery<span>.</span>ListItemCollectionPosition Property<br>
<a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spquery.listitemcollectionposition.aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spquery.listitemcollectionposition.aspx</a><br>
SPQuery<span>.</span>RowLimit Property<br>
<a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spquery.rowlimit.aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spquery.rowlimit.aspx</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

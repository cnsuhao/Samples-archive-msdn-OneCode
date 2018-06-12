# Pagination using SPquery (CSSharePointPaginationWebPart)
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
* 2012-07-22 07:37:06
## Description

<h1><a name="OLE_LINK3"></a><a name="OLE_LINK4"><span style=""><span style="">How to implement
</span>pagination through </span></a><span class="SpellE"><span style=""><span style="">SPQuery</span></span></span><span style=""><span style=""> (<span class="SpellE">CSSharePointPaginationWebPart</span>)</span></span></h1>
<h2>Introduction</h2>
<p class="MsoNormal" style=""><span style="">This sample code demonstrates <a name="OLE_LINK1">
</a><a name="OLE_LINK2"><span style="">how to implement pagination through SPquery</span></a>. The sample will fetch the list items from a specified web site. You can set how many pages have to be shown for our custom pagination. For e.g., if you have 100
 items in a list, and <span class="SpellE">rowlimt</span>=50 then the total number of pages should be 2.</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style=""><span style="">&nbsp;</span>Please follow the steps below.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 1: Open the CSSharePointPaginationWebPart.sln file and then set the &quot;Site URL&quot; to your own site.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Open the <span style="color:#1F497D">Paginati</span><span style="color:black">onWebPartUserControl.ascx.cs f</span>ile to modify the &quot;SiteCollectionUrl&quot;
<span style="color:black">and list name. </span>The &quot;SiteCollectionUrl&quot; specifies the site we will search. And the List Name specifies the list
<a name="OLE_LINK5"></a><a name="OLE_LINK6"><span style="">from which </span>
</a>we will get data for our data control. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><br>
Step 3: After that, right-click the &quot;<span class="SpellE">CSSharePointPaginationWebPart</span>&quot; project and click &quot;Deploy&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""><br>
Step 4: Open the SharePoint site in the browser and then select &quot;Page&quot;.<br>
</span><span style="font-size:9.5pt"><img src="/site/view/file/61940/1/image.png" alt="" width="1041" height="350" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="font-size:9.5pt"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 5: Select Edit.<br>
<span style=""><img src="/site/view/file/61941/1/image.png" alt="" width="895" height="222" align="middle">
</span><br>
<br style="">
<br style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 6: Select &quot;Insert&quot; Tab and click &quot;Web Part&quot;.<span style="color:black"><br>
In &quot;Categories&quot;, select &quot;Custom&quot; and in &quot;Web Parts&quot; column select &quot;<span class="SpellE">PaginationWebPart</span>&quot;. Click on &quot;Add&quot; button, then click &quot;OK&quot;, you will see our PaginationWebPart appears
 in the SharePoint site as follows: </span></span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/61942/1/image.png" alt="" width="628" height="252" align="middle">
</span></p>
<p class="MsoNormal"><span style="">Then we can view the list data by clicking the &quot;Pre&quot; button and the &quot;Next&quot; button.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 8: Validation is completed. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Create a C# &quot;Empty SharePoint Project&quot; in Visual Studio 2010 and named it as &quot;<span class="SpellE">CSSharePointPaginationWebPart</span>&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal"><span style="">Step 2: Right-click the project and add a new &quot;Visual Web Part&quot; item to our project and named it as &quot;CSSharePointPaginationWebPart&quot;.
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
<span style="">Step 4: <span style="color:black">At the code-behind, first we add the reference of &quot;</span>Microsoft.SharePoint&quot;. Then we add a method which is used to query the list data by SPQuery. We will pass two parameters for the method: rowlimit
 and pageNo. The method returns a <span class="SpellE"><span style="color:black">SPListItemCollection</span></span><span style="color:#2B91AF">.
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="color:#333333"><br>
If you need to specify the sort condition, please modify the following code: </span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
query.Query = &quot;&lt;OrderBy Override=\&quot;TRUE\&quot;&gt;&lt;FieldRef Name=\&quot;FileLeafRef\&quot; /&gt;&lt;/OrderBy&gt;&quot;;

</pre>
<pre id="codePreview" class="csharp">
query.Query = &quot;&lt;OrderBy Override=\&quot;TRUE\&quot;&gt;&lt;FieldRef Name=\&quot;FileLeafRef\&quot; /&gt;&lt;/OrderBy&gt;&quot;;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 5: Create a &quot;<span class="SpellE">BindData</span>&quot; method for binding data. This method needs a string parameter which is used to change Page No.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">At the beginning of the method, we check and calculate the page no.<span style="">&nbsp;
</span>The argument &quot;</span><span class="SpellE"><span style="color:black">strOperation</span></span><span style="color:black">&quot;</span><span style=""> is passed from the click event of the button. At the end of the method, we bind the current list
 data to SPGridView. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">&quot;Pre&quot; and &quot;Next&quot; buttons work by using the following code:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
protected void btnPre_Click(object sender, EventArgs e)
       {
           BindData(&quot;Pre&quot;);
       }


       protected void btnNext_Click(object sender, EventArgs e)
       {
           BindData(&quot;Next&quot;);
       }

</pre>
<pre id="codePreview" class="csharp">
protected void btnPre_Click(object sender, EventArgs e)
       {
           BindData(&quot;Pre&quot;);
       }


       protected void btnNext_Click(object sender, EventArgs e)
       {
           BindData(&quot;Next&quot;);
       }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"><br>
</span><span style="">Step 6: You can debug and test it. </span></p>
<p class="MsoNormal" style="">SPQuery.ListItemCollectionPosition Property<br>
<a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spquery.listitemcollectionposition.aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spquery.listitemcollectionposition.aspx</a><br>
SPQuery.RowLimit Property<br>
<a href="http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spquery.rowlimit.aspx">http://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spquery.rowlimit.aspx</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

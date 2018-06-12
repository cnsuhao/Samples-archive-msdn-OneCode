# Add query string to ASP.NET breadcrumb (VBASPNETBreadcrumbWithQueryString)
## Requires
* Visual Studio 2012
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* Sitemap
* Breadcrumbs
## IsPublished
* True
## ModifiedDate
* 2012-12-03 08:01:13
## Description

<h1>Add query string to ASP.NET breadcrumb (<span class="SpellE">VBASPNETBreadcrumbWithQueryString</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">By default, SiteMapPath control is very static. It only shows the nodes whose location can be matched in the site map. Sometimes we want to change SiteMapPath control's titles and paths according to Query String values. And sometimes
 we want to create the SiteMapPath dynamically. This code sample shows how to achieve these goals by handling SiteMap.SiteMapResolve event<span style="">.
</span></p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.25in"><span style=""><span style="">Step 1:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Open the VBASPNETBreadcrumbWithQueryString.sln.<span style="">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><span style="">Step 2:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Expand the <span class="SpellE">VBASPNETBreadcrumbWithQueryString</span> web application and press Ctrl &#43; F5 to show the Default.aspx.<br>
<span style=""><img src="/site/view/file/71719/1/image.png" alt="" width="359" height="263" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><span style="">Step 3:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">Click a link in the categories list to navigate to page Category.aspx, and then click a link to navigate to page Item.aspx. You can see that the breadcrumb is showing the dynamic nodes according to Query String values.<br>
<span style=""><img src="/site/view/file/71720/1/image.png" alt="" width="218" height="135" align="middle">
</span></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><span style="">Step 4:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">Open page DynamicBreadcrumb.aspx to see the dynamically created breadcrumb.<br>
<span style=""><img src="/site/view/file/71721/1/image.png" alt="" width="429" height="103" align="middle">
</span></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.25in"><span style=""><span style="">Step 5:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Validation finished.</p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.25in"><span style=""><span style="">Step 1:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Create a <span style="">Visual Basic</span> &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2012 or Visual Web Developer 2012. Name it as &quot;<span class="SpellE">VBASPNETBreadcrumbWithQueryString</span>&quot;.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.25in"><span style=""><span style="">Step 2:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">&nbsp;</span>Add <span style="">four</span> web forms in the root directory, name them as &quot;Default.aspx&quot;, &quot;<span style="">Category</span>.aspx&quot;, &quot;<span style="">DynamicBreadcrumb</span>.aspx&quot;, &quot;<span style="">Item</span>.aspx&quot;.</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.25in"><span style=""><span style="">Step 3:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span><span style="">T</span>he point of this sample project is that we handle SiteMap.SiteMapResolve event to dynamically create/change current SiteMapNode.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
AddHandler SiteMap.SiteMapResolve, AddressOf SiteMap_SiteMapResolve


&nbsp;&nbsp;&nbsp; Private Function SiteMap_SiteMapResolve(ByVal sender As Object,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ByVal e As SiteMapResolveEventArgs) As SiteMapNode
&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' Only need one execution in one request.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RemoveHandler SiteMap.SiteMapResolve, AddressOf SiteMap_SiteMapResolve


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If SiteMap.CurrentNode IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' SiteMap.CurrentNode is readonly, so we need to clone one to operate.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim currentNode As SiteMapNode = SiteMap.CurrentNode.Clone(True)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; currentNode.Title = Request.QueryString(&quot;name&quot;)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Use the changed one in the breadcrumb.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return currentNode
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return Nothing
&nbsp;&nbsp;&nbsp; End Function

</pre>
<pre id="codePreview" class="vb">
AddHandler SiteMap.SiteMapResolve, AddressOf SiteMap_SiteMapResolve


&nbsp;&nbsp;&nbsp; Private Function SiteMap_SiteMapResolve(ByVal sender As Object,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ByVal e As SiteMapResolveEventArgs) As SiteMapNode
&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' Only need one execution in one request.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RemoveHandler SiteMap.SiteMapResolve, AddressOf SiteMap_SiteMapResolve


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If SiteMap.CurrentNode IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' SiteMap.CurrentNode is readonly, so we need to clone one to operate.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim currentNode As SiteMapNode = SiteMap.CurrentNode.Clone(True)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; currentNode.Title = Request.QueryString(&quot;name&quot;)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Use the changed one in the breadcrumb.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return currentNode
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return Nothing
&nbsp;&nbsp;&nbsp; End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.25in"><span style=""><span style="">Step 4:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Add a class file and rename it as &quot;Database&quot;;<span style="font-size:9.5pt; line-height:115%; font-family:Consolas; background:white">
</span><span style="background:white">it is a very simple in-code database for demo purpose</span><span style="">.</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.25in"><span style=""><span style="">Step 5:<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span>Build the application and you can debug it<span style="">.</span></p>
<h2>More Information</h2>
<p class="MsoNormal">SiteMapPath Web Server Control Overview<br>
<a href="http://msdn.microsoft.com/en-us/library/x20z8c51.aspx">http://msdn.microsoft.com/en-us/library/x20z8c51.aspx</a><br>
SiteMap Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.sitemap.aspx">http://msdn.microsoft.com/en-us/library/system.web.sitemap.aspx</a><br>
SiteMap.SiteMapResolve Event<br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.sitemap.sitemapresolve.aspx">http://msdn.microsoft.com/en-us/library/system.web.sitemap.sitemapresolve.aspx</a><span style="">
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

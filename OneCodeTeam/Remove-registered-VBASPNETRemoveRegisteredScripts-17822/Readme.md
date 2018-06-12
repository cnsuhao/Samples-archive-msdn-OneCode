# Remove registered scripts (VBASPNETRemoveRegisteredScripts)
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
* 2012-07-22 07:34:35
## Description

<h1>Remove registered scripts (VBASPNETRemoveRegisteredScripts)</h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span style="">This sample code will demonstrate how to remove scripts registered by RegisterStartupScript and RegisterClientScriptBlock. Users can register scripts by RegisterStartupScript or RegisterClientScriptBlock. But sometimes,
 after these scripts are successfully run, users want to remove these scripts as they don't need to use again. For example, user press a button that they do not want to receive alert messages or do not want that server tracks his behavior on the site.
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow the steps below. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 1: Open the VBASPNETRemoveRegisteredScripts.sln file. </span>
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 2: Right-Click at AjaxTest.aspx page and then select &quot;view in browser&quot;.<br>
<span style=""><img src="/site/view/file/61905/1/image.png" alt="" width="231" height="158" align="middle">
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">If we simply click on the Name, it will throw an exception. </span>
</p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Click the Register button after that click the &quot;Name…&quot; and then the data will show as below:
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""><img src="/site/view/file/61906/1/image.png" alt="" width="315" height="150" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Click the Remove button and click the &quot;Name…&quot; and we will get an exception again.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""><br>
Step 3: Right-Click at NonAjaxTest.aspx page and then select &quot;view in browser&quot;.<br>
<span style=""><img src="/site/view/file/61907/1/image.png" alt="" width="313" height="55" align="middle">
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">If we simply click on the CallFunction button, it will throw an exception.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Click the Register button and then click the CallFunction button, it will be shown as below:
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<img src="/site/view/file/61908/1/image.png" alt="" width="363" height="241" align="middle">
<span style=""><br clear="all" style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Click the Remove button followed by clicking the CallFunction button; we will get an exception again.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""><br>
Step 4: Validation is completed. </span></p>
<p class="MsoNormal"><span style="">&nbsp;</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal"><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span></span></p>
<p class="MsoNormal"><span style="">Step 1: Create a VB &quot;ASP.NET Web Application&quot; in Visual Studio or Visual Web Developer and name it as &quot;VBASPNETRemoveRegisteredScripts&quot;.
</span></p>
<p class="MsoNormal"><span style="">Step 2: Add two pages to our project and rename them to &quot;AjaxTest.aspx&quot; and &quot;NonAjaxTest.aspx&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; background:white">
<span style="">Step 3: Add three buttons to the NonAjaxTest page. The first one is used to register script, the second one is used to remove script, and the last one is used to call the function.<span style="">&nbsp;&nbsp;&nbsp;
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;asp:Button ID=&quot;btnRegister&quot; runat=&quot;server&quot; Text=&quot;Register&quot; OnClick=&quot;btnRegister_Click&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;asp:Button ID=&quot;btnRemove&quot; runat=&quot;server&quot; Text=&quot;Remove&quot; OnClick=&quot;btnRemove_Click&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;input type=&quot;button&quot; onclick=&quot;javascript:test()&quot; value=&quot;CallFunction&quot; /&gt;</pre>
</div>
<pre></pre>
<pre id="codePreview" class="html">
&lt;asp:Button ID=&quot;btnRegister&quot; runat=&quot;server&quot; Text=&quot;Register&quot; OnClick=&quot;btnRegister_Click&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;asp:Button ID=&quot;btnRemove&quot; runat=&quot;server&quot; Text=&quot;Remove&quot; OnClick=&quot;btnRemove_Click&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;input type=&quot;button&quot; onclick=&quot;javascript:test()&quot; value=&quot;CallFunction&quot; /&gt;</pre>
</div>
<pre></pre>
<div></div>
<div></div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; background:white">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; background:white">
<span style="">Then register and remove client scripts at code-behind. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; ''' Register client script.
&nbsp;&nbsp;&nbsp; ''' RegisterStartupScript puts the javascript before the closing tag of the page
&nbsp;&nbsp;&nbsp; ''' and RegisterClientScriptBlock puts it right after the starting tag of the page 
&nbsp;&nbsp;&nbsp;&nbsp;''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp; Protected Sub btnRegister_Click(ByVal sender As Object, ByVal e As EventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not ClientScript.IsClientScriptBlockRegistered(&quot;RegisterKey&quot;) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Client script
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim sbAlertScript As New StringBuilder()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; sbAlertScript.Append(&quot;&lt;script language='javascript'&gt;&quot; & vbLf)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; sbAlertScript.Append(&quot;function test()&quot; & vbLf)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; sbAlertScript.Append(&quot;{&quot; & vbLf)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; sbAlertScript.Append(&quot;alert(&quot;&quot;test1&quot;&quot;);&quot; & vbLf)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; sbAlertScript.Append(&quot;}&quot; & vbLf)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; sbAlertScript.Append(&quot;&lt;/script&gt;&quot; & vbLf)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Register the client script


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' You can comment the code above and uncomment the code below
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' ClientScript.RegisterStartupScript(this.GetType(), &quot;RegisterKey&quot;, sbAlertScript.ToString());&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ClientScript.RegisterClientScriptBlock(Me.[GetType](), &quot;RegisterKey&quot;, sbAlertScript.ToString())
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; End Sub


&nbsp;&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; ''' Remove script: Register a null value to the existing key.
&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp; Protected Sub btnRemove_Click(ByVal sender As Object, ByVal e As EventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ClientScript.RegisterClientScriptBlock(Me.[GetType](), &quot;RegisterKey&quot;, &quot;&quot;)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' You can comment the code above and uncomment the code below
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' ClientScript.RegisterStartupScript(this.GetType(), &quot;RegisterKey&quot;, &quot;&quot;);&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;End Sub

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; ''' Register client script.
&nbsp;&nbsp;&nbsp; ''' RegisterStartupScript puts the javascript before the closing tag of the page
&nbsp;&nbsp;&nbsp; ''' and RegisterClientScriptBlock puts it right after the starting tag of the page 
&nbsp;&nbsp;&nbsp;&nbsp;''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp; Protected Sub btnRegister_Click(ByVal sender As Object, ByVal e As EventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not ClientScript.IsClientScriptBlockRegistered(&quot;RegisterKey&quot;) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Client script
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim sbAlertScript As New StringBuilder()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; sbAlertScript.Append(&quot;&lt;script language='javascript'&gt;&quot; & vbLf)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; sbAlertScript.Append(&quot;function test()&quot; & vbLf)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; sbAlertScript.Append(&quot;{&quot; & vbLf)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; sbAlertScript.Append(&quot;alert(&quot;&quot;test1&quot;&quot;);&quot; & vbLf)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; sbAlertScript.Append(&quot;}&quot; & vbLf)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; sbAlertScript.Append(&quot;&lt;/script&gt;&quot; & vbLf)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Register the client script


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' You can comment the code above and uncomment the code below
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' ClientScript.RegisterStartupScript(this.GetType(), &quot;RegisterKey&quot;, sbAlertScript.ToString());&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ClientScript.RegisterClientScriptBlock(Me.[GetType](), &quot;RegisterKey&quot;, sbAlertScript.ToString())
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; End Sub


&nbsp;&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; ''' Remove script: Register a null value to the existing key.
&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp; Protected Sub btnRemove_Click(ByVal sender As Object, ByVal e As EventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ClientScript.RegisterClientScriptBlock(Me.[GetType](), &quot;RegisterKey&quot;, &quot;&quot;)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' You can comment the code above and uncomment the code below
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' ClientScript.RegisterStartupScript(this.GetType(), &quot;RegisterKey&quot;, &quot;&quot;);&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; background:white">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; background:white">
<span style="">Step 4: Add two buttons to the AjaxTest page. The first one is used to register script and the second one is used to remove script.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; background:white">
<span style="">Add a <span style="">ScriptManager and UpdatePanel control to page, then add a DataList and a XmlDataSource to the UpdatePanel. The source code of page will shown as below:
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;asp:Button ID=&quot;btnRegister&quot; runat=&quot;server&quot; Text=&quot;Register&quot; OnClick=&quot;btnRegister_Click&quot; /&gt;
&nbsp;&nbsp; &nbsp;&lt;asp:Button ID=&quot;btnRemove&quot; runat=&quot;server&quot; Text=&quot;Remove&quot; OnClick=&quot;btnRemove_Click&quot; /&gt;
&nbsp;&nbsp; <div>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:ScriptManager ID=&quot;ScriptManager1&quot; EnablePartialRendering=&quot;true&quot; runat=&quot;server&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/asp:ScriptManager&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:UpdatePanel ID=&quot;UpdatePanel1&quot; UpdateMode=&quot;Conditional&quot; runat=&quot;server&quot;&gt;
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ContentTemplate&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:XmlDataSource ID=&quot;XmlDataSource1&quot; DataFile=&quot;~/App_Data/Contacts.xml&quot; XPath=&quot;Contacts/Contact&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; runat=&quot;server&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:DataList ID=&quot;DataList1&quot; DataSourceID=&quot;XmlDataSource1&quot; CellPadding=&quot;3&quot; GridLines=&quot;Horizontal&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; runat=&quot;server&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ItemTemplate&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <div style="font-size:larger; font-weight:bold">Name:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;%# Eval(&quot;Name&quot;) %&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </div>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <div id="div&lt;%#" style="">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;%# Eval(&quot;Age&quot;) %&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </div>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ItemTemplate&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;AlternatingItemStyle BackColor=&quot;#F7F7F7&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ItemStyle BackColor=&quot;#E7E7FF&quot; ForeColor=&quot;#4A3C8C&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/asp:DataList&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ContentTemplate&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/asp:UpdatePanel&gt;
&nbsp;&nbsp; </div>

</pre>
<pre id="codePreview" class="html">
&lt;asp:Button ID=&quot;btnRegister&quot; runat=&quot;server&quot; Text=&quot;Register&quot; OnClick=&quot;btnRegister_Click&quot; /&gt;
&nbsp;&nbsp; &nbsp;&lt;asp:Button ID=&quot;btnRemove&quot; runat=&quot;server&quot; Text=&quot;Remove&quot; OnClick=&quot;btnRemove_Click&quot; /&gt;
&nbsp;&nbsp; <div>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:ScriptManager ID=&quot;ScriptManager1&quot; EnablePartialRendering=&quot;true&quot; runat=&quot;server&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/asp:ScriptManager&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:UpdatePanel ID=&quot;UpdatePanel1&quot; UpdateMode=&quot;Conditional&quot; runat=&quot;server&quot;&gt;
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ContentTemplate&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:XmlDataSource ID=&quot;XmlDataSource1&quot; DataFile=&quot;~/App_Data/Contacts.xml&quot; XPath=&quot;Contacts/Contact&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; runat=&quot;server&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;asp:DataList ID=&quot;DataList1&quot; DataSourceID=&quot;XmlDataSource1&quot; CellPadding=&quot;3&quot; GridLines=&quot;Horizontal&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; runat=&quot;server&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ItemTemplate&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <div style="font-size:larger; font-weight:bold">Name:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;%# Eval(&quot;Name&quot;) %&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </div>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <div id="div&lt;%#" style="">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;%# Eval(&quot;Age&quot;) %&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </div>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ItemTemplate&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;AlternatingItemStyle BackColor=&quot;#F7F7F7&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ItemStyle BackColor=&quot;#E7E7FF&quot; ForeColor=&quot;#4A3C8C&quot; /&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/asp:DataList&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ContentTemplate&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/asp:UpdatePanel&gt;
&nbsp;&nbsp; </div>

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; background:white">
<span style="">Then register and remove client scripts at code-behind. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Client script
&nbsp;&nbsp; Private script As String = vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; function ToggleItem(id)&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var elem = $get('div'&#43;id);&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (elem) &quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot; {&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (elem.style.display != 'block') &quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; elem.style.display = 'block';&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; elem.style.visibility = 'visible';&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; } &quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; elem.style.display = 'none';&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; elem.style.visibility = 'hidden';&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;


&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp; ''' Register client script.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp; Protected Sub btnRegister_Click(ByVal sender As Object, ByVal e As EventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), &quot;ToggleScript&quot;, script, True)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' You can comment the code above and uncomment the code below
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' ScriptManager.RegisterStartupScript(this,typeof(Page),&quot;ToggleScript&quot;,script,true);
&nbsp;&nbsp; End Sub


&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp; ''' Remove script: Register a null value to the existing key.
&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp; Protected Sub btnRemove_Click(ByVal sender As Object, ByVal e As EventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), &quot;ToggleScript&quot;, &quot;&quot;, True)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' You can comment the code above and uncomment the code below
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;' ScriptManager.RegisterStartupScript(this,typeof(Page),&quot;ToggleScript&quot;,&quot;&quot;,true);
&nbsp;&nbsp; End Sub

</pre>
<pre id="codePreview" class="vb">
' Client script
&nbsp;&nbsp; Private script As String = vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; function ToggleItem(id)&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var elem = $get('div'&#43;id);&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (elem) &quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot; {&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (elem.style.display != 'block') &quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; elem.style.display = 'block';&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; elem.style.visibility = 'visible';&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; } &quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; elem.style.display = 'none';&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; elem.style.visibility = 'hidden';&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }&quot; _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; & vbCr & vbLf & &quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &quot;


&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp; ''' Register client script.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp; Protected Sub btnRegister_Click(ByVal sender As Object, ByVal e As EventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), &quot;ToggleScript&quot;, script, True)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' You can comment the code above and uncomment the code below
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' ScriptManager.RegisterStartupScript(this,typeof(Page),&quot;ToggleScript&quot;,script,true);
&nbsp;&nbsp; End Sub


&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp; ''' Remove script: Register a null value to the existing key.
&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp; Protected Sub btnRemove_Click(ByVal sender As Object, ByVal e As EventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), &quot;ToggleScript&quot;, &quot;&quot;, True)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' You can comment the code above and uncomment the code below
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;' ScriptManager.RegisterStartupScript(this,typeof(Page),&quot;ToggleScript&quot;,&quot;&quot;,true);
&nbsp;&nbsp; End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><b style=""><span style="">[Note]</span></b><span style="">
</span><span style="color:black">Scripts registered by RegisterStartupScript and RegisterClientScriptBlock have a second parameter in string format. This&nbsp;parameter&nbsp;indicates the key of the script. If there are two keys exactly the same, the second
 script will not be registered. To use this feature, register a script has the same key as one which been registered and pass&nbsp;an empty string value&nbsp;to the third parameter &quot;script&quot;. This will&nbsp;overrides&nbsp;the script with the same key.&nbsp;<br>
Note that it is not the second script overrides the first one; it is that the second script becomes unavailable. Therefore, the registration of the second script needs to be checked, let it became the first registered in its life cycle.<br>
</span><sup><span style="color:red"><br>
</span></sup><span style="">Step 5: You can test and debug it. </span></p>
<h2>More Information</h2>
<p class="MsoNormal">Page<span>.</span>RegisterStartupScript Method<br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.page.registerstartupscript.aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.page.registerstartupscript.aspx</a><br>
Page<span>.</span>RegisterClientScriptBlock Method<br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.page.registerclientscriptblock">http://msdn.microsoft.com/en-us/library/system.web.ui.page.registerclientscriptblock</a><br>
ScriptManager<span>.</span>RegisterClientScriptBlock Method<br>
<a href="http://msdn.microsoft.com/en-us/library/bb299228">http://msdn.microsoft.com/en-us/library/bb299228</a><br>
ScriptManager<span>.</span>RegisterStartupScript Method<br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.scriptmanager.registerstartupscript">http://msdn.microsoft.com/en-us/library/system.web.ui.scriptmanager.registerstartupscript</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

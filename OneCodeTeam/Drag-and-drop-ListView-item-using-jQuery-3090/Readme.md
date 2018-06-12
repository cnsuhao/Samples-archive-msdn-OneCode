# Drag and drop ListView item using jQuery (VBASPNETDragItemInListView)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* jQuery
* Drag and Drop
* ListView
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:38:32
## Description

<p style="font-family:Courier New"></p>
<h2>VBASPNETDragItemInListView Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The project illustrates how to drag and drop items in ListView using jquery.<br>
The jQuery library used in this code sample comes from <a target="_blank" href="&lt;a target=" href="http://jqueryui.com/">
http://jqueryui.com/</a>.'&gt;<a target="_blank" href="http://jqueryui.com/">http://jqueryui.com/</a>.<br>
This code-sample includes two ListView controls, user can drag, sort and move<br>
items from one controls to another. this sample can be used in many areas.For <br>
example, you can create an application of online shopping, it will give customer <br>
better feelings with your application.<br>
<br>
<br>
Demo the Sample. <br>
<br>
Please follow these demonstration steps below.<br>
<br>
Step 1: Open the VBASPNETDragItemInListView.sln.<br>
<br>
Step 2: Expand the VBASPNETDragItemInListView web application and press <br>
&nbsp; &nbsp; &nbsp; &nbsp;Ctrl &#43; F5 to show the Default.aspx page.<br>
<br>
Step 3: You will see two ListView controls, use mouse drag items to another <br>
&nbsp; &nbsp; &nbsp; &nbsp;ListView or itself, you can also sort the items by drag them to correct<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;position you want.<br>
<br>
Step 4: Double click items in ListView controls to remove it.<br>
<br>
Step 5: Validation finished.<br>
<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step 1. Create a VB &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or<br>
&nbsp; &nbsp; &nbsp; &nbsp;Visual Web Developer 2010. Name it as &quot;VBASPNETDragItemInListView&quot;.<br>
<br>
Step 2. Add a web form named &quot;Default.aspx&quot; in root directory.<br>
<br>
Step 3. Create a &quot;XmlFile&quot; folder and add two XML files in it, &quot;ListView1.xml&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp;&quot;ListView2.xml&quot;.<br>
<br>
Step 4. Filling some elements in XML file like code-sample and these data will<br>
&nbsp; &nbsp; &nbsp; &nbsp;bind in ListView controls.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;root&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;data open=&quot;0&quot;&gt;element 1&lt;/data&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;data open=&quot;1&quot;&gt;element 2&lt;/data&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;data open=&quot;1&quot;&gt;element 3&lt;/data&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;data open=&quot;1&quot;&gt;element 4&lt;/data&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;data open=&quot;1&quot;&gt;element 5&lt;/data&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;data open=&quot;1&quot;&gt;element 6&lt;/data&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;data open=&quot;1&quot;&gt;element 7&lt;/data&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/root&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;[/code]<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;Import some Jquery Javascript library in &lt;head&gt; tag like this:<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &lt;link href=&quot;JQuery/jquery-ui.css&quot; rel=&quot;stylesheet&quot; type=&quot;text/css&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;script src=&quot;JQuery/jquery-1.4.4.min.js&quot; type=&quot;text/javascript&quot;&gt;&lt;/script&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;script src=&quot;JQuery/jquery-ui.min.js&quot; type=&quot;text/javascript&quot;&gt;&lt;/script&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;[/code] <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;Add Jquery functions in Default.aspx page,these two Jquery functions use
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;to drag and drop items in ListView control :<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&lt;script type=&quot;text/javascript&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;$(function () {<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;$(&quot;#sortable1, #sortable2&quot;).sortable({<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; connectWith: &quot;.connectedSortable&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}).disableSelection();<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;});<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;$(document).ready(function () {<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;$(&quot;li&quot;).dblclick(function () {<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; $(this).closest('li').remove();<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;});<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}); &nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&lt;/script&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;[/code]<br>
<br>
Step 5. Write VB code in Default.aspx.vb page to bind XML files data:<br>
&nbsp; &nbsp; &nbsp; &nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;'bind two xml data file to ListView control, actually you can change the &quot;open&quot; property to &quot;0&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;'in that way, it will not display in ListView control.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim xmlDocument As New XmlDocument()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim tabListView1 As New DataTable()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tabListView1.Columns.Add(&quot;value&quot;, Type.[GetType](&quot;System.String&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;xmlDocument.Load(AppDomain.CurrentDomain.BaseDirectory &#43; &quot;/XmlFile/ListView1.xml&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim xmlNodeList As XmlNodeList = xmlDocument.SelectNodes(&quot;root/data[@open='1']&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;For Each xmlNode As XmlNode In xmlNodeList<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim dr As DataRow = tabListView1.NewRow()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dr(&quot;value&quot;) = xmlNode.InnerText<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tabListView1.Rows.Add(dr)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Next<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ListView1.DataSource = tabListView1<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ListView1.DataBind()<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
<br>
Step 6. Build the application and you can debug it.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
ASP.NET: JQuery <br>
<a target="_blank" href="http://wiki.asp.net/page.aspx/1047/jquery/">http://wiki.asp.net/page.aspx/1047/jquery/</a><br>
<br>
jQuery UI library<br>
<a target="_blank" href="http://jqueryui.com/">http://jqueryui.com/</a><br>
<br>
MSDN: ListView Web Server Control<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb398790.aspx#Y8454">http://msdn.microsoft.com/en-us/library/bb398790.aspx#Y8454</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

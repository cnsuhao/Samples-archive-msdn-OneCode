# Fix the position of GridView header (VBASPNETFixedHeaderGridView)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Controls
* jQuery
* GridView
## IsPublished
* True
## ModifiedDate
* 2011-06-27 09:35:18
## Description

<p style="font-family:Courier New">&nbsp;</p>
<h2>VBASPNETFixedHeaderGridView Overview</h2>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
As we know, GridView usually has many rows with a vertical scroll bar. <br>
When users scroll using vertical bar, the header of the GridView will &nbsp;<br>
move and disappear. This sample illustrates how to fix the header<br>
of GridView via JQuery, and this approach can also cross multiple browsers<br>
at client side.<br>
<br>
Demo the Sample. <br>
<br>
Please follow these demonstration steps below.<br>
<br>
Step 1: Open the VBASPNETFixedHeaderGridView.sln.<br>
<br>
Step 2: Expand the VBASPNETFixedHeaderGridView web application and press <br>
&nbsp; &nbsp; &nbsp; &nbsp;Ctrl &#43; F5 to show the Default.aspx page.<br>
<br>
Step 3: You will see a GridView control on the page, please scroll the <br>
&nbsp; &nbsp; &nbsp; &nbsp;vertical scroll bar, the header line of the GridView not move
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;with the scroll bar.<br>
<br>
Step 5: Please browser this page with some other browsers, such as Chrome,<br>
&nbsp; &nbsp; &nbsp; &nbsp;FireFox, Safari, etc.<br>
<br>
Step 6: Validation finished.</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step 1. Create a VB &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or<br>
&nbsp; &nbsp; &nbsp; &nbsp;Visual Web Developer 2010. Name it as &quot;VBASPNETFixedHeaderGridView&quot;.<br>
<br>
Step 2. Add one web form and named it as &quot;Default.aspx&quot;.<br>
<br>
Step 3. Create a folder named &quot;JScript&quot; and copy the code of sample file in<br>
&nbsp; &nbsp; &nbsp; &nbsp;your JS files. You can also download of them from these websites:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="http://docs.jquery.com/Downloading_jQuery" target="_blank">http://docs.jquery.com/Downloading_jQuery</a><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="http://plugins.jquery.com/project/fixedtableheader" target="_blank">http://plugins.jquery.com/project/fixedtableheader</a><br>
<br>
Step 4. Add a GridView on Default.aspx page, and add create a data table as <br>
&nbsp; &nbsp; &nbsp; &nbsp;GridView's data source. Here we give the code of Default.aspx.vb file.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Define a data table as GridView's data source.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim tab As New DataTable()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tab.Columns.Add(&quot;a&quot;, Type.[GetType](&quot;System.String&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tab.Columns.Add(&quot;b&quot;, Type.[GetType](&quot;System.String&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tab.Columns.Add(&quot;c&quot;, Type.[GetType](&quot;System.String&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tab.Columns.Add(&quot;d&quot;, Type.[GetType](&quot;System.String&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tab.Columns.Add(&quot;e&quot;, Type.[GetType](&quot;System.String&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tab.Columns.Add(&quot;f&quot;, Type.[GetType](&quot;System.String&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tab.Columns.Add(&quot;g&quot;, Type.[GetType](&quot;System.String&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tab.Columns.Add(&quot;h&quot;, Type.[GetType](&quot;System.String&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tab.Columns.Add(&quot;i&quot;, Type.[GetType](&quot;System.String&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tab.Columns.Add(&quot;j&quot;, Type.[GetType](&quot;System.String&quot;))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;For i As Integer = 0 To 34<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Dim dr As DataRow = tab.NewRow()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dr(&quot;a&quot;) = String.Format(&quot;row:{0} columns:a&quot;, i.ToString().PadLeft(2, &quot;0&quot;c))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dr(&quot;b&quot;) = String.Format(&quot;row:{0} columns:b&quot;, i.ToString().PadLeft(2, &quot;0&quot;c))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dr(&quot;c&quot;) = String.Format(&quot;row:{0} columns:c&quot;, i.ToString().PadLeft(2, &quot;0&quot;c))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dr(&quot;d&quot;) = String.Format(&quot;row:{0} columns:d&quot;, i.ToString().PadLeft(2, &quot;0&quot;c))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dr(&quot;e&quot;) = String.Format(&quot;row:{0} columns:e&quot;, i.ToString().PadLeft(2, &quot;0&quot;c))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dr(&quot;f&quot;) = String.Format(&quot;row:{0} columns:f&quot;, i.ToString().PadLeft(2, &quot;0&quot;c))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dr(&quot;g&quot;) = String.Format(&quot;row:{0} columns:g&quot;, i.ToString().PadLeft(2, &quot;0&quot;c))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dr(&quot;h&quot;) = String.Format(&quot;row:{0} columns:h&quot;, i.ToString().PadLeft(2, &quot;0&quot;c))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dr(&quot;i&quot;) = String.Format(&quot;row:{0} columns:i&quot;, i.ToString().PadLeft(2, &quot;0&quot;c))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dr(&quot;j&quot;) = String.Format(&quot;row:{0} columns:j&quot;, i.ToString().PadLeft(2, &quot;0&quot;c))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;tab.Rows.Add(dr)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Next<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;' Data bind method.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;gvwList.DataSource = tab<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;gvwList.DataBind()<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;[/code]<br>
<br>
Step 5. Now we need bind the specifically columns of data table to GridView's columns,<br>
&nbsp; &nbsp; &nbsp; &nbsp;The code of Default.aspx page will be like this:<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&lt;Columns&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:BoundField DataField=&quot;a&quot; FooterText=&quot;titile a&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;HeaderText=&quot;titile a&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:BoundField DataField=&quot;b&quot; FooterText=&quot;titile b&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;HeaderText=&quot;titile b&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:BoundField DataField=&quot;c&quot; FooterText=&quot;titile c&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;HeaderText=&quot;titile c&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:BoundField DataField=&quot;d&quot; FooterText=&quot;titile d&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;HeaderText=&quot;titile d&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:BoundField DataField=&quot;e&quot; FooterText=&quot;titile e&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;HeaderText=&quot;titile e&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:BoundField DataField=&quot;f&quot; FooterText=&quot;titile f&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;HeaderText=&quot;titile f&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:BoundField DataField=&quot;g&quot; FooterText=&quot;titile g&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;HeaderText=&quot;titile g&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:BoundField DataField=&quot;h&quot; FooterText=&quot;titile h&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;HeaderText=&quot;titile h&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:BoundField DataField=&quot;i&quot; FooterText=&quot;titile i&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;HeaderText=&quot;titile i&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:BoundField DataField=&quot;j&quot; FooterText=&quot;titile j&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;HeaderText=&quot;titile j&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/Columns&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
<br>
Step 6. The last of step, involve the JQuery libraries and write the JQuery <br>
&nbsp; &nbsp; &nbsp; &nbsp;function to fixed the header of GridView control.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;The JQuery code will be like this:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[code]<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&lt;script src=&quot;JScript/jquery-1.4.4.min.js&quot; type=&quot;text/javascript&quot;&gt;&lt;/script&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;script src=&quot;JScript/ScrollableGridPlugin.js&quot; type=&quot;text/javascript&quot;&gt;&lt;/script&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;script type = &quot;text/javascript&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;$(document).ready(function () {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;//Invoke Scrollable function.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;$('#&lt;%=gvwList.ClientID %&gt;').Scrollable({<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ScrollHeight: 600, &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;});<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;});<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/script&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[/code]<br>
<br>
Step 7. Build the application and you can debug it.</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: JQuery<br>
<a href="http://wiki.asp.net/page.aspx/1047/jquery/" target="_blank">http://wiki.asp.net/page.aspx/1047/jquery/</a><br>
<br>
MSDN: GridView Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.gridview.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.gridview.aspx</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

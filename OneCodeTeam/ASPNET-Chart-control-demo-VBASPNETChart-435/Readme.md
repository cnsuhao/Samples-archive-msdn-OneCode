# ASP.NET Chart control demo (VBASPNETChart)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Controls
* Chart
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:37:47
## Description

<p style="font-family:Courier New"></p>
<h2>ASP.NET APPLICATION : VBASPNETChart Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
&nbsp;The project illustrates how to use the new Chart control to create an chart<br>
&nbsp;in the web page.<br>
</p>
<h3>Code Logical:</h3>
<p style="font-family:Courier New"><br>
Step1. Create a Visual Basic ASP.NET Web Application in Visual Studio 2010 /<br>
Visual Web Developer 2010 and name it as VBASPNETChart.<br>
<br>
[NOTE] As Visual Studio 2010 has not been realsed, you can download its<br>
express version from <a target="_blank" href="http://www.microsoft.com/express/Web/">
http://www.microsoft.com/express/Web/</a><br>
<br>
Step2. Delete the following default folders and files created automatically <br>
by Visual Studio.<br>
<br>
Account folder<br>
Script folder<br>
Style folder<br>
About.aspx file<br>
Default.aspx file<br>
Global.asax file<br>
Site.Master file<br>
<br>
Step3. Add a new web form page to the website and name it as Default.aspx.<br>
<br>
Step4. Add a Chart control into the page. You can find it in the Data <br>
category of the Toolbox.<br>
<br>
[NOTE] When a Chart control is added into the page, such a Register Info will<br>
be added to the same page automatically.<br>
<br>
&lt;%@ Register Assembly=&quot;System.Web.DataVisualization, Version=4.0.0.0, <br>
&nbsp; &nbsp;Culture=neutral, PublicKeyToken=31bf3856ad364e35&quot;<br>
&nbsp; &nbsp;Namespace=&quot;System.Web.UI.DataVisualization.Charting&quot; TagPrefix=&quot;asp&quot; %&gt;<br>
<br>
Also, a new reference /System.Web.DataVisualization/ will be added to the web<br>
application as well.<br>
<br>
Step5: Add two Series into the Chart tag as the sample below.<br>
<br>
&nbsp; &nbsp;&lt;Series&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:Series Name=&quot;Series1&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/asp:Series&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:Series Name=&quot;Series2&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/asp:Series&gt;<br>
&nbsp; &nbsp;&lt;/Series&gt;<br>
<br>
[NOTE] The Series collection property stores Series objects, which are used to <br>
store data that is to be displayed, along with attributes of that data.<br>
<br>
Step6: Edit the two Series to add ChartType property which equals to Column and<br>
ChartArea property with the value as ChartArea1.<br>
<br>
[NOTE] The Series ChartType value that indicates the chart type that will be <br>
used to represent the series. For all items in this collectin, please refer <br>
to this link: <a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.datavisualization.charting.seriescharttype(VS.100).aspx">
http://msdn.microsoft.com/en-us/library/system.web.ui.datavisualization.charting.seriescharttype(VS.100).aspx</a><br>
The ChartAreas collection property stores ChartArea objects, which are primarily <br>
used to draw one or more charts using one set of axes. You will finally find the <br>
HTML code looks like this.<br>
<br>
&lt;asp:Chart ID=&quot;Chart1&quot; runat=&quot;server&quot; Height=&quot;400px&quot; Width=&quot;500px&quot;&gt;<br>
&nbsp; &nbsp;&lt;Series&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:Series Name=&quot;Series1&quot; ChartType=&quot;Column&quot; ChartArea=&quot;ChartArea1&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/asp:Series&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:Series Name=&quot;Series2&quot; ChartType=&quot;Column&quot; ChartArea=&quot;ChartArea1&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/asp:Series&gt;<br>
&nbsp; &nbsp;&lt;/Series&gt;<br>
&nbsp; &nbsp;&lt;ChartAreas&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;asp:ChartArea Name=&quot;ChartArea1&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/asp:ChartArea&gt;<br>
&nbsp; &nbsp;&lt;/ChartAreas&gt;<br>
&lt;/asp:Chart&gt;<br>
<br>
Step7: Create data source for the Chart control via DataTable in the behind<br>
code. In this step, please directly follow the method CreateDataTable in <br>
Default.aspx.cs, as this is not what we are talking about in this project.<br>
<br>
Step8: Bind the data source to the Chart control.<br>
<br>
&nbsp; &nbsp;Chart1.Series(0).YValueMembers = &quot;Volume1&quot;<br>
&nbsp; &nbsp;Chart1.Series(1).YValueMembers = &quot;Volume2&quot;<br>
&nbsp; &nbsp;Chart1.Series(0).XValueMember = &quot;Date&quot;<br>
<br>
[NOTE] Series.YValueMembers property is used to get or set member columns of <br>
the chart data source used to bind data to the Y-values of the series. Alike,<br>
Series.XValueMember property is for getting or setting the member column of <br>
the chart data source used to data bind to the X-value of the series.<br>
<br>
Step9: Now, you can run the page to see the achievement we did before :-)<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Chart Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.web.ui.datavisualization.charting.chart(VS.100).aspx">http://msdn.microsoft.com/en-us/library/system.web.ui.datavisualization.charting.chart(VS.100).aspx</a><br>
<br>
MSDN: Chart Controls Tutorial<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/dd489231(VS.100).aspx">http://msdn.microsoft.com/en-us/library/dd489231(VS.100).aspx</a><br>
<br>
ASP.NET: Chart Control<br>
<a target="_blank" href="http://www.asp.net/learn/aspnet-4-quick-hit-videos/video-8770.aspx">http://www.asp.net/learn/aspnet-4-quick-hit-videos/video-8770.aspx</a> (Quick Hit Videl)<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

# RDLC mraster-detail report in ASP.NET (CSASPNETRDLCMainSubReport)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Controls
* Reports
## IsPublished
* True
## ModifiedDate
* 2011-05-05 05:09:04
## Description

<p style="font-family:Courier New"></p>
<h2>Web APPLICATION : CSASPNETRDLCMainSubReport Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Introduction:</h3>
<p style="font-family:Courier New"><br>
This sample demonstrates how to build a sub-report which get data from<br>
SQL Server based on a primary key passed from the main-report, then use <br>
the ReportViewer control to show that Main/Sub report in the web page.<br>
<br>
</p>
<h3>Creation steps:</h3>
<p style="font-family:Courier New"><br>
1.Create the main report with the report wizard, follow these steps: <br>
&nbsp;a.In the Solution Explorer of the Visual Studio, add a new item, <br>
&nbsp; &nbsp;then select the report wizard template and name it &quot;MainReport&quot;.
<br>
&nbsp;b.In the Data Source configuration wizard, connect to the SQLServer2005DB<br>
&nbsp; &nbsp;database and create DepDataSet which includes the Department table. <br>
&nbsp;c.Select the tabular as the report type.<br>
&nbsp;d.Drag the fields: DepartmentID and Name to the Details columns.<br>
&nbsp;e.Finish the report wizard.<br>
<br>
2.Create the sub report with the report wizard, follow these steps: <br>
&nbsp;a.In the Solution Explorer of the Visual Studio, add a new item, <br>
&nbsp; &nbsp;then select the report wizard template and name it ��SubReport��. <br>
&nbsp;b.In the Data Source configuration wizard, connect to the SQLServer2005DB <br>
&nbsp; &nbsp;database and create CourseDataSet which includes the Course table.<br>
&nbsp;c.Select the tabular as the report type.<br>
&nbsp;d.Drag the fields: CourseID and Title to the Details columns.<br>
&nbsp;e.Finish the report wizard.<br>
<br>
3.Filter the sub report with the Department ID and create a parameter <br>
&nbsp;to incept the Department ID from the main report, follow these steps: <br>
&nbsp;a.Switch to sub report, select the report menu in the report designer interface,<br>
&nbsp; &nbsp;and then select report parameter item, in the popup window, add a new<br>
&nbsp; &nbsp;parameter named DepartmentID, change its type into Integer, then click ok.<br>
&nbsp;b.Select the report menu in the report designer interface, <br>
&nbsp; &nbsp;and then select Data sources item &nbsp;in the popup window, click the property
<br>
&nbsp; &nbsp;of the sub report datasource. Switch to the filter tab, <br>
&nbsp; &nbsp;use &nbsp;&quot;=Fields! DepartmentID.Value&quot; &nbsp;for the expression<br>
&nbsp; &nbsp;and &quot;=Parameters! DepartmentID.Value&quot; for value, and the operator is &quot;=&quot;.<br>
<br>
4.Add the sub report control into the main report, follow these steps: <br>
&nbsp;a.Select the detail row of the table in main report,<br>
&nbsp; &nbsp;right click and insert a new detail row below. <br>
&nbsp;b.Merge the cells of the second detail row.<br>
&nbsp;c.Drag a sub report control from the tool box into the second detail row. <br>
&nbsp;d.Right click the sub report control, then select the property. <br>
&nbsp; &nbsp;In the general tab of the popup window, select the sub report name, <br>
&nbsp; &nbsp;then switch to the parameters tab, use &quot;DepartmentID&quot; for the parameter name<br>
&nbsp; &nbsp;and &quot;=Fields! DepartmentID.Value&quot; for parameter value.<br>
&nbsp;e.Select the report menu in the report designer interface, <br>
&nbsp; &nbsp;and then select Data sources item, &nbsp;in the popup window, <br>
&nbsp; &nbsp;select the sub report datasource and add it into the main report. <br>
&nbsp; &nbsp;Otherwise we will get the error message &quot;Error:Subreport could not be shown&quot;
<br>
&nbsp; &nbsp;during the report running.<br>
<br>
5.Use the Report Viewer control to display the report, follow these steps: <br>
&nbsp;a.In the Solution Explorer of the Visual Studio, add a new item, <br>
&nbsp; &nbsp;then select the web form template and name it &quot;CSASPNETRDLCMainSubReport.aspx&quot;. &nbsp;<br>
&nbsp;b.From the Reporting node of the ToolBox, add a ReportViewer control to the webpage,
<br>
&nbsp; &nbsp;then in the report tasks, select MainReport.rdlc.<br>
&nbsp;c.Use the following code to supply the data for the sub report. <br>
&nbsp;protected void Page_Load(object sender, EventArgs e)<br>
&nbsp;{<br>
&nbsp; ReportViewer1.LocalReport.SubreportProcessing &#43;= new SubreportProcessingEventHandler(SetSubDataSource);<br>
&nbsp; this.ReportViewer1.LocalReport.Refresh();<br>
&nbsp;}<br>
&nbsp;public void SetSubDataSource(object sender, SubreportProcessingEventArgs e)<br>
&nbsp;{<br>
&nbsp; e.DataSources.Add(new ReportDataSource(&quot;CourseDataSet_Course&quot;, &quot;ObjectDataSource2&quot;));<br>
&nbsp;}<br>
<br>
<br>
<br>
<br>
<br>
</p>
<h3>Database usage:</h3>
<p style="font-family:Courier New"><br>
We use Course and Department tables that belong to SQLServer2005DB database as the datasource.<br>
<br>
The sample data:<br>
<br>
Department table<br>
<br>
DepartmentID&nbsp;&nbsp;&nbsp;&nbsp;Name<br>
1&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Computer Department
<br>
2&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Mathematics<br>
<br>
Course table<br>
<br>
courseid&nbsp;&nbsp;&nbsp;&nbsp;title<br>
1&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ASPNET<br>
2&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;JAVA<br>
3&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;linear algebra<br>
4&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;higher mathematics<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
LocalReport.SubreportProcessing Event <br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/microsoft.reporting.webforms.localreport.subreportprocessing.aspx">http://msdn.microsoft.com/en-us/library/microsoft.reporting.webforms.localreport.subreportprocessing.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

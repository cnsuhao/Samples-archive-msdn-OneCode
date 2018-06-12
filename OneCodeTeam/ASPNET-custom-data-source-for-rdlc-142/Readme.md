# ASP.NET custom data source for rdlc (CSASPNETCustomDataSourceForRDLC)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Reports
## IsPublished
* True
## ModifiedDate
* 2011-05-05 04:56:00
## Description

<p style="font-family:Courier New"></p>
<h2>Web APPLICATION : CSASPNETCustomDataSourceForRDLC Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New">This sample demonstrates how to use custom class as the datasource for the RDLC.<br>
In order to explain the sample more clearly, we will simulate some customers'<br>
information.<br>
<br>
</p>
<h3></h3>
<p style="font-family:Courier New">ReportViewer installation:<br>
Microsoft Report Viewer 2008 SP1 Redistributable<br>
<a target="_blank" href="http://www.microsoft.com/downloads/details.aspx?displaylang=en&FamilyID=bb196d5d-76c2-4a0e-9458-267d22b6aac6">http://www.microsoft.com/downloads/details.aspx?displaylang=en&FamilyID=bb196d5d-76c2-4a0e-9458-267d22b6aac6</a><br>
</p>
<h3></h3>
<p style="font-family:Courier New">The principle of the sample:<br>
<br>
1.Create a class &quot;Customer&quot; as the template to store the customers' information,<br>
like:ID,Name and country.<br>
<br>
2.Then create a GetPersons class which includes a generic list to store all the <br>
instances of the Customers as the datasource for RDLC.<br>
<br>
3.Add a report to the solution and use a table control to show the customers' <br>
information.<br>
<br>
4.Add a report parameter &quot;CountryName&quot; to filter the customers' information.<br>
<br>
5. Go to the datasource property of the report, then set the filter with the<br>
following expression.<br>
<br>
Expression:<br>
=iif(Parameters!CountryName.Value=&quot;&quot;,Parameters!CountryName.Value,Fields!Country.Value)<br>
<br>
Operation: &quot;=&quot;<br>
<br>
Value: =Parameters!CountryName.Value<br>
</p>
<h3></h3>
<p style="font-family:Courier New">Assemble reference:<br>
Microsoft.ReportViewer.WebForms 9.0<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New">LocalReport.SetParameters Method<br>
<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms251790(VS.80).aspx">http://msdn.microsoft.com/en-us/library/ms251790(VS.80).aspx</a><br>
<br>
<br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

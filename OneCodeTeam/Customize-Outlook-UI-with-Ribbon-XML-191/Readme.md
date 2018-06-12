# Customize Outlook UI with Ribbon XML (CSOutlookRibbonXml)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Office
## Topics
* VSTO
## IsPublished
* True
## ModifiedDate
* 2011-04-05 05:36:37
## Description

<p style="font-family:Courier New"></p>
<h2>OFFICE ADD-IN : CSOutlookRibbonXml Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The CSOutlookRibbonXml provides the examples on how to customize Office UI <br>
using the Ribbon XML. This sample also shows a way on how to keep & track the <br>
same control's property status (e.g. Checked) in different inspectors.<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
1. We need to create an XML file containing description of our customized<br>
&nbsp; Ribbon contents. (See Ribbon.xml)<br>
2. Create a class that implements the <br>
&nbsp; Microsoft.Office.Core.IRibbonExtensibility class. (See Ribbon.cs)<br>
3. In Ribbon.cs, implement the GetCustomUI (memeber of IRibbonExtensibility)<br>
&nbsp; method. In this method, we return Ribbon XML according to the RibbonID<br>
&nbsp; passed in.<br>
4. In Ribbon.cs, implement the callback methods.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Customizing the Ribbon in Outlook 2007<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb226712.aspx">http://msdn.microsoft.com/en-us/library/bb226712.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

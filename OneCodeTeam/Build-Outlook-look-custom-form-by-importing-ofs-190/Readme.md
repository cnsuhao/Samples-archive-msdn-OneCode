# Build Outlook-look custom form by importing .ofs (CSOutlookImportedFormRegion)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Office
## Topics
* VSTO
* Outlook
* Form Region
## IsPublished
* True
## ModifiedDate
* 2011-05-05 05:46:44
## Description

<p style="font-family:Courier New"></p>
<h2>Outlook Imported Form Region Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This Sample demonstrates how to build a Outlook look&feel custom form via<br>
Outlook Frorm Region in Visual Studio 2008<br>
<br>
</p>
<h3></h3>
<p style="font-family:Courier New">Creation:<br>
&nbsp;&nbsp;&nbsp;&nbsp;Outlook Side:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.Create a Form Region<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; a.Go to &quot;Tools&quot; menu,select &quot;Form&quot;, select &quot;Design a Form&quot;.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; b.Select &quot;Message&quot; at &quot;Design From&quot; dialog<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; c.On the Active Inspector,go to &quot;Developer&quot; tab, Click &quot;Form Region&quot;, Select &quot;New Form Region&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; d.Add Controls into the Form Region.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; e.Save the Form Region as &quot;CodeFxFormRegion.ofs&quot;.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;Visual Studio Side:<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1.Create a Outlook 2007 AddIn project<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2.Add a New Item<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3.At &quot;Add New Item&quot; dialog select Outlook Form Region<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;4.At &quot;Select how you want to create the form region&quot; dialog select &quot;Import an Outlook Form Storage file&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;5.At &quot;Select the type of form region you want to create&quot;dialog choose &quot;Replace-all&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;6.Next Name the Form Retion as ImportedFormRegion, and check &quot;Inspectors that are in compose mode&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&quot;Inspectors that are in read mode&quot;, &quot;Reading Pane&quot; check boxes.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;7.Go to ImportedFormRegion.cs file and add event handler for all the controls.<br>
<br>
<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Walkthrough: Importing a Form Region That Is Designed in Outlook<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb608611.aspx">http://msdn.microsoft.com/en-us/library/bb608611.aspx</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

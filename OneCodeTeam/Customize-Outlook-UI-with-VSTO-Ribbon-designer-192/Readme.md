# Customize Outlook UI with VSTO Ribbon designer (CSOutlookUIDesigner)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Office
## Topics
* VSTO
* Ribbon
## IsPublished
* True
## ModifiedDate
* 2011-05-05 05:48:26
## Description

<p style="font-family:Courier New"></p>
<h2>OFFICE ADD-IN : CSOutlookUIDesigner Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The CSOutlookUIDesigner provides samples on how to customize Office UI using<br>
the VSTO Designers. It will demonstrate all Ribbon Controls available in the<br>
Ribbon Designer. It will also demonstrate how to add FormRegions and <br>
TaskPanes to the Outlook UI.<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
A. Ribbon<br>
<br>
In order to make the ribbon show corresponding controls on different types<br>
of Inspectors, we need to:<br>
1. Group the controls on the designer. One group per type of Inspector.<br>
2. In the Ribbon's Load event, get a reference to current Inspector using<br>
&nbsp; the Context property.<br>
3. Determine the type of the Inspector by checking the CurrentItem property.<br>
&nbsp; Sample: if (inspector.CurrentItem is MailItem) { ... }<br>
4. Set the Visible property of corresponding Group on Ribbon to show / hide<br>
&nbsp; the controls.<br>
&nbsp; <br>
MyRibbon uses both custom PNG files stored in project resource file and<br>
Office built in images as control images. For those controls using Office<br>
built in images, please note their OfficeImageId property.<br>
<br>
B. Custom Task Pane (CTP)<br>
<br>
In order to associate a CTP with specific types of Inspectors, we need to:<br>
1. Handle the Application.Inspectors.NewInspector event.<br>
2. In the event handler, get the item type of the Inspector and decide<br>
&nbsp; whether to associate a CTP with the Inspector.<br>
3. If the item type is right, we can use ThisAddIn's CustomTaskPanes.Add<br>
&nbsp; method to have the job done.<br>
<br>
In order to access the parent CTP / Window object within our UserControl<br>
code, we need to:<br>
1. Add a property of type CustomTaskPane to the UserControl.<br>
2. After creating the CTP, pass the CTP reference to the property created<br>
&nbsp; in step 1.<br>
3. Within the UserControl code, access the property to get the CTP reference.<br>
&nbsp; <br>
In MyRibbon class, we have a button once clicked, will show the CTP associated<br>
with the current Inspector. In order to achieve this, we need to:<br>
1. Go through the Globals.ThisAddIn.CustomTaskPanes, compare each CTP's<br>
&nbsp; Window property with current Inspector.<br>
2. If Window == Current Inspector, that CTP is the one associated with the<br>
&nbsp; Inspector.<br>
3. Do whatever necessary with the CTP.<br>
<br>
C. FormRegion<br>
To get the current Outlook item within the FormRegion code, use:<br>
this.OutlookItem<br>
<br>
To get the current Outlook Inspector within the FormRegion code, use:<br>
this.OutlookFormRegion.Inspector<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Ribbon Designer<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb386089.aspx">http://msdn.microsoft.com/en-us/library/bb386089.aspx</a><br>
<br>
Office Ribbon Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/microsoft.office.tools.ribbon.officeribbon.aspx">http://msdn.microsoft.com/en-us/library/microsoft.office.tools.ribbon.officeribbon.aspx</a><br>
<br>
CustomTaskPane Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/microsoft.office.tools.customtaskpane.aspx">http://msdn.microsoft.com/en-us/library/microsoft.office.tools.customtaskpane.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

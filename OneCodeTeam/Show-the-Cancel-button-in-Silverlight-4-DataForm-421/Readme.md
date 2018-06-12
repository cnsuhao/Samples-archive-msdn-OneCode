# Show the Cancel button in Silverlight 4 DataForm (CSSL4DataFormCancelButton)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Silverlight
## Topics
* Controls
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:26:24
## Description

<p style="font-family:Courier New"></p>
<h2>SILVERLIGHT APPLICATION : CSSL4DataFormCancelButton Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This project demonstrates how to show Cancel Button in DataForm when editting<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
To test this sample, please try the following steps:<br>
&nbsp;&nbsp;&nbsp;&nbsp;1. Make sure you have Silverlight 4 Tools for Visual Studio 2010 and
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; Silverlight Toolkit installed.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; This demo uses Silverlight 4 Toolkit - April 2010
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; (<a target="_blank" href="&lt;a target=" href="http://silverlight.codeplex.com/releases/view/43528">http://silverlight.codeplex.com/releases/view/43528</a>)'&gt;<a target="_blank" href="http://silverlight.codeplex.com/releases/view/43528">http://silverlight.codeplex.com/releases/view/43528</a>)<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; It is recommended to install Silverlight_4_Toolkit_April_2010.msi.
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; After installation, all related dlls will be added to GAC.
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; Otherwise, you need to unzip Silverlight_4_Toolkit_April_2010.zip
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; and replace the reference to <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; System.Windows.Controls.Data.DataForm.Toolkit.dll.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; You can find it under <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; April 2010 Silverlight Toolkit\April 2010 Silverlight Toolkit\Bin.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; (Right click on your project--&gt;Add Reference --&gt;choose the dll)<br>
&nbsp;&nbsp;&nbsp;&nbsp;2. Open CSSL4DataFormCancelButton solution and compile.<br>
&nbsp;&nbsp;&nbsp;&nbsp;3. Run the project.<br>
&nbsp; &nbsp;4. The Cancel Button will be disabled by default and will be enabled
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; when you modify any of the fields or add a new record. &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<br>
<br>
</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
Silverlight 4 Tools RTM for Visual Studio 2010<br>
<a target="_blank" href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=b3deb194-ca86-4fb6-a716-b67c2604a139&displaylang=en">http://www.microsoft.com/downloads/en/details.aspx?FamilyID=b3deb194-ca86-4fb6-a716-b67c2604a139&displaylang=en</a><br>
<br>
<br>
Silverlight 4 Toolkit for Visual Studio 2010<br>
<a target="_blank" href="http://silverlight.codeplex.com/releases/view/43528">http://silverlight.codeplex.com/releases/view/43528</a><br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
How to achieve the Cancel function?<br>
&nbsp; &nbsp;1. Create a class which implements IEditableObject Interface and <br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; BeginEdit,CancelEdit,EndEdit three methods.<br>
&nbsp;&nbsp;&nbsp;&nbsp;2. Copy the current item when BeginEdit.<br>
&nbsp;&nbsp;&nbsp;&nbsp;3. Restore the original value When CancelEdit.<br>
&nbsp; &nbsp;</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
IEditableObject Interface<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.componentmodel.ieditableobject_members%28v=VS.95%29.aspx">http://msdn.microsoft.com/en-us/library/system.componentmodel.ieditableobject_members%28v=VS.95%29.aspx</a><br>
<br>
DataAnnotation Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations%28VS.95%29.aspx">http://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations%28VS.95%29.aspx</a><br>
<br>
RangeAttribute Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.rangeattribute%28v=VS.95%29.aspx">http://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.rangeattribute%28v=VS.95%29.aspx</a><br>
<br>
INotifyPropertyChanged Interface<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.componentmodel.inotifypropertychanged%28VS.95%29.aspx">http://msdn.microsoft.com/en-us/library/system.componentmodel.inotifypropertychanged%28VS.95%29.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

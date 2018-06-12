# Customize the 'Add Reference' dialog in VSPackage (CSVSPackageAddReferenceTab)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* VSX
## Topics
* Extend Add Reference Tab
## IsPublished
* True
## ModifiedDate
* 2011-05-05 06:30:58
## Description

<p style="font-family:Courier New"></p>
<h2>VSX application : CSVSPackageAddReferenceTab Project Overview </h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
Visual Studio supports to extend the Add Reference dialog and add custom<br>
tab page into the dialog.<br>
<br>
This sample demostrate you how to add a custom .NET user control as a tab <br>
page into the add reference dialog, and how to enable select button and<br>
handle item selection events.<br>
<br>
All the sample code is based on MPF.<br>
<br>
The sample is initiated by the thread on the forum:<br>
<a target="_blank" href="&lt;a target=" href="http://social.msdn.microsoft.com/Forums/en-US/vsx/thread/ddb0f935-b8ac-400d-9e3d-64d74be85031">http://social.msdn.microsoft.com/Forums/en-US/vsx/thread/ddb0f935-b8ac-400d-9e3d-64d74be85031</a>'&gt;<a target="_blank" href="http://social.msdn.microsoft.com/Forums/en-US/vsx/thread/ddb0f935-b8ac-400d-9e3d-64d74be85031">http://social.msdn.microsoft.com/Forums/en-US/vsx/thread/ddb0f935-b8ac-400d-9e3d-64d74be85031</a><br>
<br>
</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
VS 2008 SDK must be installed on the machine. You can download it from:<br>
<a target="_blank" href="http://www.microsoft.com/downloads/details.aspx?FamilyID=30402623-93ca-479a-867c-04dc45164f5b&displaylang=en">http://www.microsoft.com/downloads/details.aspx?FamilyID=30402623-93ca-479a-867c-04dc45164f5b&displaylang=en</a><br>
<br>
Otherwise the project may not be opened by Visual Studio.<br>
<br>
If you run this project on a x64 OS, please also config the Debug tab of the project<br>
Setting. Set the &quot;Start external program&quot; to <br>
C:\Program Files(x86)\Microsoft Visual Studio 9.0\Common7\IDE\devenv.exe<br>
<br>
NOTE: The Package Load Failure Dialog occurs because there is no PLK(Package Load Key)<br>
&nbsp; &nbsp; &nbsp;Specified in this package. To obtain a PLK, please to go to WebSite:<br>
&nbsp; &nbsp; &nbsp;<a target="_blank" href="http://msdn.microsoft.com/en-us/vsx/cc655795.aspx">http://msdn.microsoft.com/en-us/vsx/cc655795.aspx</a><br>
&nbsp; &nbsp; &nbsp;More info<br>
&nbsp; &nbsp; &nbsp;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb165395.aspx">http://msdn.microsoft.com/en-us/library/bb165395.aspx</a><br>
</p>
<h3></h3>
<p style="font-family:Courier New">Steps:<br>
In order to implement this sample, following are the essential steps:<br>
(For detailed informaiton, please view sample code)<br>
<br>
1. Create ProvideReferencePageAttribute<br>
This attribute is derived from RegistrationAttribute, so it main purpose <br>
is to write information into registry.<br>
VSRoot\ComponentPickerPages\&lt;Tab Name&gt;<br>
#AddToMru = 1<br>
#ComponentType = .NET Assembly<br>
#Package = &lt;package guid&gt;<br>
#Page = &lt;.Net user control guid&gt;<br>
#Sort = 0x35<br>
<br>
2. Apply the ProvideReferencePageAttribute to the package<br>
<br>
3. The package implements IVsComponentSelectorProvider interface<br>
This interface has method GetComponentSelectorPage, which will be called <br>
when Visual Studio first time load add reference tabs.<br>
<br>
So implement the GetComponentSelectorPage method and VSPROPSHEETPAGE <br>
structure to invoker.The most important thing is its hwndDlg, which should<br>
be the handle of the tab page control.<br>
<br>
4. Implement ReferencePageDialog by inheriting from UserControl<br>
Add a ListView control into the user control<br>
<br>
5. Handle ListView's OnSelectionChange and OnDoubleClick events<br>
Send CPDN_SELCHANGED and CPDN_SELDBLCLICK messages to its great grandparent<br>
respectively to notify for those two events.<br>
<br>
6. Override the WinProc method and handle the following messages:<br>
CPPM_INITIALIZELIST: Initialize the list<br>
CPPM_QUERYCANSELECT: Check if select button is enabled<br>
CPPM_SETMULTISELECT: Set if multiple select is supported<br>
CPPM_CLEARSELECTION: Clear the selection<br>
CPPM_GETSELECTION: Get selected items<br>
<br>
7. Initialize the list<br>
Add demo items into ListView control<br>
<br>
8. Get selected items<br>
See the HandleGetSelectionMessage method.<br>
m.WParam = the count of the items<br>
m.LParam = the pointer of VSCOMPONENTSELECTORDATA data array<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Adding a tab to the Add Reference dialog<br>
<a target="_blank" href="&lt;a target=" href="http://social.msdn.microsoft.com/Forums/en-US/vsx/thread/ddb0f935-b8ac-400d-9e3d-64d74be85031">http://social.msdn.microsoft.com/Forums/en-US/vsx/thread/ddb0f935-b8ac-400d-9e3d-64d74be85031</a>'&gt;<a target="_blank" href="http://social.msdn.microsoft.com/Forums/en-US/vsx/thread/ddb0f935-b8ac-400d-9e3d-64d74be85031">http://social.msdn.microsoft.com/Forums/en-US/vsx/thread/ddb0f935-b8ac-400d-9e3d-64d74be85031</a><br>
<br>
IDE Constants<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb165453.aspx">http://msdn.microsoft.com/en-us/library/bb165453.aspx</a><br>
<br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

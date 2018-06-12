# VSPackage state persisting (CSVSPackageState)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* VSX
## Topics
* Persisting Visual Studio package state
## IsPublished
* True
## ModifiedDate
* 2011-05-05 06:34:19
## Description

<p style="font-family:Courier New"></p>
<h2>VSX application : CSVSPackageState Project Overview<br>
<br>
Visual Studio Package State Sample<br>
</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The Visual Studio package state sample demostrate the state persisting for<br>
application options and show object states in properties window.<br>
<br>
The sample doesn't include the state management for solution and project,<br>
which will be included in project package sample.<br>
<br>
*Tools/Options Page*<br>
<br>
1. Open menu [Tools]/[Options]<br>
2. Select [CSVSPackageState Category]<br>
3. Change the value of [Option Integer Property]<br>
4. Open registry editor<br>
5. Find key: &quot;HKEY_CURRENT_USER\Software\Microsoft\VisualStudio\<br>
&nbsp; 9.0Exp\UserSettings\DialogPage\<br>
&nbsp; AllInOne.CSVSPackageState.OptionPageGrid&quot;<br>
&nbsp; The [OptionInteger] value stores user settings.<br>
&nbsp; <br>
*Property Window*<br>
In this sample, we use ToolWindow to demostrate property window.<br>
<br>
1. Open menu [View]/[Other Windows]/[All-In-One Tool Window]<br>
2. Open menu [View]/[Properties Window]<br>
3. In the All-In-One Tool Window, change the value of <br>
&nbsp; PropertyInteger or PropertyString<br>
4. Change the focus by clicking Properties window<br>
5. The PropertyInteger or PropertyString will be changed <br>
&nbsp; according to the value set in the tool window.</p>
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
<h3>Concepts:</h3>
<p style="font-family:Courier New"><br>
*Tools/Options Page*<br>
Selecting Options on the Tools menu opens the Options <br>
dialog box. The options in this dialog box are collectively <br>
referred to as Tools/Options pages. The tree control in the <br>
navigation pane includes option categories, and each category <br>
has option pages. When you select a page, its options appear <br>
in the right pane. These pages let you change the values of <br>
the options that determine the state of a VSPackage.<br>
<br>
The DialogPage class implements IProfileManager, which provides <br>
persistence for both options pages and user settings. The default <br>
implementations of the LoadSettingsFromStorage and SaveSettingsToStorage<br>
methods persist property changes into a user's section of the registry <br>
if the property can be converted to and from a string.<br>
<br>
*Property Window*<br>
When you select an object in Visual Studio, the public properties <br>
of that object appear in the Properties window. To select an object <br>
programmatically, you add the object to a list of selectable and <br>
selected objects in a selection container. You use the STrackSelection <br>
service to notify Visual Studio of the selection.<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
*Tools/Options Page*<br>
1. Create a new Visual Studio Integration Package project.<br>
2. On the Select a Programming Language page, select Visual Basic or Visual C#.<br>
3. On the Select VSPackage Options page, select Menu Command.<br>
4. On the Command Options page, change the Command name to Get internal <br>
option VB or Get internal option CS for Visual Basic or Visual C# respectively, <br>
and then click Finish.<br>
5. Declare an OptionPageGrid class and derive it from DialogPage.<br>
6. Apply a System.Runtime.InteropServices.ClassInterfaceAttribute <br>
to the OptionPageGrid class.<br>
This creates a COM dual interface that lets Visual Studio Automation use <br>
GetAutomationObject to access the public members of the class programmatically.<br>
7. Apply a ProvideOptionPageAttribute to the VSPackage class to assign to the <br>
class an options category and options page name for the OptionPageGrid.<br>
8. Add an OptionInteger property to the OptionPageGrid class.<br>
<br>
*Property Window*<br>
1. Create a new Visual Studio Integration Package project.<br>
2. In the Select a Programming Language page, select Visual C#.<br>
3. In the Select VSPackage Options page, select Tool Window.<br>
4. In the Tool Window Options page, change the Window Name to <br>
&quot;All-In-One Tool Window&quot;, and then click Finish.<br>
5. The wizard creates the managed project.<br>
6. Open the file, MyToolWindow.cs, and add the following fields to <br>
the MyToolWindow class:<br>
a. ITrackSelection service <br>
The TrackSelection property uses GetService to obtain an STrackSelection <br>
service, which provides an ITrackSelection interface. <br>
b. OnToolWindowCreated event<br>
c. SelectList method<br>
The OnToolWindowCreated event handler and SelectList method together create a list
<br>
of selected objects that contains only the tool window pane object itself.<br>
d. UpdateSelection method<br>
The UpdateSelection method tells the Properties window to display the public <br>
properties of the tool window pane.</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
VSPackage State<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb165693.aspx">http://msdn.microsoft.com/en-us/library/bb165693.aspx</a><br>
<br>
Support for Options Pages<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb166553.aspx">http://msdn.microsoft.com/en-us/library/bb166553.aspx</a><br>
<br>
Support for the Property Browser<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb165050.aspx">http://msdn.microsoft.com/en-us/library/bb165050.aspx</a></p>
<h3></h3>
<p style="font-family:Courier New"><br>
<br>
<br>
<br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

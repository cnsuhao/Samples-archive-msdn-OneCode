# Monitor file change through VS Service (CSVSPackageMonitorFileChange)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* VSX
## Topics
* Monitor File Change through VS Service
## IsPublished
* True
## ModifiedDate
* 2011-05-05 06:32:56
## Description

<p style="font-family:Courier New"></p>
<h2>VSX application : CSVSPackageMonitorFileChange Project Overview </h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
Visual Studio provides SVsFileChangeEx service enables arbitrary components <br>
to register to be notified when a file is modified outside of the Environment.<br>
<br>
This service is useful when you are performing some operation which will be <br>
interupted by file changes from outside environment.<br>
<br>
The service is similar with FileSystemWatcher Class.<br>
<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/system.io.filesystemwatcher.aspx">http://msdn.microsoft.com/en-us/library/system.io.filesystemwatcher.aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.io.filesystemwatcher.aspx">http://msdn.microsoft.com/en-us/library/system.io.filesystemwatcher.aspx</a><br>
<br>
To use this sample, follow the steps as below:<br>
<br>
1. Start experimental VS instance<br>
2. The package will be autoloaded automatically when there is no any solution <br>
loaded.<br>
3. The demo monitors user's desktop directory, so please do file or directory <br>
changes in desktop.<br>
4. Visual Studio will popup window whenever a change is made.<br>
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
In order to implement this sample, following are the core steps:<br>
(For detailed informaiton, please view sample code)<br>
<br>
1. Create package class and specify AutoLoad attribute:<br>
[ProvideAutoLoad(&quot;{adfc4e64-0397-11d1-9f4e-00a0c911004f}&quot;)]<br>
adfc4e64-0397-11d1-9f4e-00a0c911004f represents context that there is <br>
no solution is loaded.<br>
<br>
2. In the package's initializate method, add following code:<br>
<br>
IVsFileChangeEx fileChangeService =<br>
&nbsp; &nbsp;GetService(typeof(SVsFileChangeEx)) as IVsFileChangeEx;<br>
monitor = new CSVSMonitorFileChange();<br>
uint cookie;<br>
<br>
// Enables a client to receive notifications of changes to a directory.<br>
fileChangeService.AdviseDirChange(<br>
<br>
&nbsp; &nbsp;// String form of the moniker identifier of <br>
&nbsp; &nbsp;// the directory in the project system.<br>
&nbsp; &nbsp;Environment.GetFolderPath(<br>
&nbsp; &nbsp; &nbsp; &nbsp;Environment.SpecialFolder.Desktop),<br>
<br>
&nbsp; &nbsp;// If true, then events should also be fired <br>
&nbsp; &nbsp;// for changes to sub directories. If false, <br>
&nbsp; &nbsp;// then events should not be fired for changes <br>
&nbsp; &nbsp;// to sub directories.<br>
&nbsp; &nbsp;Convert.ToInt32(true),<br>
<br>
&nbsp; &nbsp;// IVsFileChangeEvents Interface on the object <br>
&nbsp; &nbsp;// requesting notification of file change events.<br>
&nbsp; &nbsp;monitor,<br>
<br>
&nbsp; &nbsp;// Unique identifier for the file that is <br>
&nbsp; &nbsp;// associated with the event sink.<br>
&nbsp; &nbsp;out cookie<br>
);<br>
<br>
3. Implements CSVSMonitorFileChange class which inherited from IVsFileChangeEvents<br>
Implements DirectoryChanged and FilesChanged methods to popup message box<br>
when a change is monitored.<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
How to get notifications in editor when the file is modified outside of the editor?<br>
<a target="_blank" href="http://blogs.msdn.com/dr._ex/archive/2005/11/01/487721.aspx">http://blogs.msdn.com/dr._ex/archive/2005/11/01/487721.aspx</a><br>
<br>
IVsFileChangeEvents Interface<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop.ivsfilechangeevents.aspx">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop.ivsfilechangeevents.aspx</a><br>
<br>
SVsFileChangeEx Interface<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop.svsfilechangeex(VS.80).aspx">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop.svsfilechangeex(VS.80).aspx</a><br>
<br>
FileSystemWatcher Class<br>
<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/system.io.filesystemwatcher.aspx">http://msdn.microsoft.com/en-us/library/system.io.filesystemwatcher.aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.io.filesystemwatcher.aspx">http://msdn.microsoft.com/en-us/library/system.io.filesystemwatcher.aspx</a><br>
<br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

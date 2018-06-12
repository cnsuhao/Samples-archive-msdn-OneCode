# TFS WorkItem Object Model demo (CSTFSWorkItemObjectModel)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* TFS
## Topics
* TFS
* Manage TFS work items
## IsPublished
* True
## ModifiedDate
* 2011-05-05 06:23:05
## Description

<p style="font-family:Courier New"></p>
<h2>C# TFS: CSTFSWorkItemObjectModel Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use: </h3>
<p style="font-family:Courier New"><br>
This C# sample works in machines where Team Explorer 2008 is installed. This <br>
sample uses object model from Team Explorer 2008 to access TFS. It will <br>
demostrate how to programatically manage work items. You may want to select a<br>
team project for experimental purpose. Set the team project name and TFS URL in <br>
the App.config. <br>
<br>
</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
Team Explorer 2008 must be installed on the machine. You can download it from:<br>
https://www.microsoft.com/downloads/details.aspx?FamilyID=0ed12659-3d41-4420-bbb0-a46e51bfca86&displaylang=en<br>
<br>
Otherwise the project may not be able to reference to work item object model.<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
1. Create a new Windows Console application named &quot;CSTFSWorkItemObjectModel&quot;.<br>
<br>
2. Add reference to Microsoft.TeamFoundation.Client.dll and<br>
&nbsp; Microsoft.TeamFoundation.WorkItemTracking.Client.dll. They are located in<br>
&nbsp; %ProgramFiles%\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies.<br>
&nbsp; <br>
3. Add an App.config to the solution with the following content. Please replace<br>
&nbsp; TfsUrl value to your TFS server and TeamProject value to an existing team <br>
&nbsp; project for experiment. <br>
&nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;configuration&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;appSettings&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;add key=&quot;TfsUrl&quot; value=&quot;<a target="_blank" href="http://170112m3:8080&quot;/&gt;">http://170112m3:8080&quot;/&gt;</a><br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;add key=&quot;TeamProject&quot; value=&quot;WIT Test&quot;/&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;/appSettings&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/configuration&gt;<br>
<br>
4. Copy the content in the Programs.cs in the sample to your project. <br>
<br>
7. To build and debug this sample you can press F5 from your keyboard, or click <br>
&nbsp; Debug menu and choose &quot;Start Debugging&quot;. <br>
<br>
</p>
<h3>Changes to your machine: </h3>
<p style="font-family:Courier New"><br>
1. Import a work item type &quot;My WIT&quot; to the specified team project.<br>
<br>
2. Create work items of type &quot;My WIT&quot; in the specified team project.<br>
<br>
3. Create a work item query &quot;My WITs&quot; in the specified team project.<br>
&nbsp; team project and create work items.<br>
<br>
</p>
<h3>How do I rollback changes:</h3>
<p style="font-family:Courier New"><br>
1. To destroy a work item, you can use &quot;tfpt destroywi&quot; from TFS power tool.
<br>
<br>
2. To destroy a work item type, you can use &quot;tfpt destroywitd&quot; from TFS power tool.<br>
<br>
3. To delete a work item query, you can right click the query in Team Explorer and<br>
&nbsp; select &quot;Delete&quot;.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
1. Work Item Tracking Extensibility<br>
&nbsp; <a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb130347.aspx">
http://msdn.microsoft.com/en-us/library/bb130347.aspx</a><br>
<br>
<br>
&nbsp; <br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

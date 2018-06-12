# TFS custom WorkItem control demo (CSTFSCustomWorkItemControl)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* TFS
## Topics
* Custom Workitem Control
* TFS
## IsPublished
* True
## ModifiedDate
* 2011-05-05 06:21:50
## Description

<p style="font-family:Courier New"></p>
<h2>C# TFS : CSTFSCustomWorkItemControl Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The logic of Work Item Type Definition can meet most our requirement, <br>
but Custom Wok Item Control can do more.<br>
This C# sample works in machines where Team Explorer 2008 is installed. The <br>
OpenOtherWorkItemControl demonstrates how to create and deploy a Custom <br>
Workitem Control that can open another work item in Visual Studio 2008.<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
The following steps walk through a demonstration of the deploy the control<br>
<br>
Step1. After you successfully build the sample project in Visual Studio 2008, <br>
you will get &nbsp;assemblies: CSTFSCustomWorkItemControl.dll and some reference <br>
assemblies<br>
<br>
Step2. Copy the assemblies and OpenOtherWorkItemControl.wicc(under project folder)
<br>
to�� C:\Documents and Settings\All Users\Application Data\Microsoft\Team Foundation<br>
\Work Item Tracking\Custom Controls\9.0�� (Windows XP/2003)or &nbsp;&quot;C:\ProgramData\<br>
Microsoft\Team Foundation\Work Item Tracking\Custom Controls\9.0&quot;(Vista or later).<br>
If this location does not exist, create it.<br>
<br>
Step3. Import Task_OpenOtherWorkItem.xml to TFS using TF.exe or TFS Power Tools.<br>
<br>
Step4. Refresh Work Items node in Team Explorer, add a new work item <br>
��Task_OpenOtherWorkItem��<br>
<br>
Step5. Type a valid work item ID in WIID, then click GO. If there is no error,<br>
VS will show a new work item UI.<br>
<br>
<br>
<br>
</p>
<h3>Build:</h3>
<p style="font-family:Courier New"><br>
Set the platform target to ��X86��.<br>
</p>
<h3>Deployment:</h3>
<p style="font-family:Courier New"><br>
Copy the assemblies (under bin folder) and OpenOtherWorkItemControl.wicc<br>
(under project folder) to�� C:\Documents and Settings\All Users\Application Data\<br>
Microsoft\Team Foundation\Work Item Tracking\Custom Controls\9.0�� (Windows XP/2003)<br>
or &quot;C:\ProgramData\Microsoft\Team Foundation\Work Item Tracking\Custom Controls\9.0&quot;<br>
(Vista or later). If this location does not exist, create it.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
<br>
A. Creating a Class Library Project in Visual Studio 2008<br>
<br>
B. Adding following assemblies to Project Reference<br>
<br>
EnvDTE<br>
EnvDTE80<br>
EnvDTE90<br>
Extensibility<br>
Microsoft.TeamFoundation<br>
Microsoft.TeamFoundation.Client<br>
Microsoft.TeamFoundation.WorkItemTracking.Client<br>
Microsoft.TeamFoundation.WorkItemTracking.Controls<br>
Microsoft.VisualStudio.TeamFoundation<br>
Microsoft.VisualStudio.TeamFoundation.WorkItemTracking<br>
<br>
C. Adding an User Control to project<br>
<br>
D. Adding a textbox and a button to User Control<br>
<br>
E. Adding fields and properties<br>
&nbsp; &nbsp; &nbsp; &nbsp;private EventHandlerList m_events;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private static object EventBeforeUpdateDatasource = new object();<br>
&nbsp; &nbsp; &nbsp; &nbsp;private static object EventAfterUpdateDatasource = new object();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;private StringDictionary m_properties;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private bool m_readOnly;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private IServiceProvider m_serviceProvider;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private WorkItem m_workItem;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private string m_fieldName;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;EnvDTE80.DTE2 dte2;<br>
<br>
F. Implementing IWorkItemControl Interface<br>
<br>
G. Handling button click event.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
<br>
Work Item Tracking Custom Controls<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb286959.aspx">http://msdn.microsoft.com/en-us/library/bb286959.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

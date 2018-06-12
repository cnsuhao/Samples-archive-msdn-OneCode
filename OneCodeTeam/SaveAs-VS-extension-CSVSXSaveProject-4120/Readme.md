# Project SaveAs VS extension (CSVSXSaveProject)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* VSX
## Topics
* Extension
## IsPublished
* True
## ModifiedDate
* 2011-08-08 07:25:01
## Description

<p style="font-family:Courier New"></p>
<h2>ProjectName: CSVSXSaveProject</h2>
<p style="font-family:Courier New"></p>
<h3>Summary</h3>
<p style="font-family:Courier New"><br>
This sample demonstrates that you can save an existing project to different location via<br>
IDE menu. It supplies following features:<br>
1. Copy the whole project to a new location.<br>
2. Enable a user to select the files.<br>
3. Open the new project in the current IDE.<br>
<br>
NOTE: This sample only supports to copy the files in the project folder. <br>
&nbsp;</p>
<h3>Requirement</h3>
<p style="font-family:Courier New"><br>
Visual Studio 2010 and Visual Studio 2010 SDK.<br>
<br>
You can download the Visual Studio 2010 SDK from<br>
<a target="_blank" href="http://www.microsoft.com/downloads/en/details.aspx?FamilyID=47305CF4-2BEA-43C0-91CD-1B853602DCC5">http://www.microsoft.com/downloads/en/details.aspx?FamilyID=47305CF4-2BEA-43C0-91CD-1B853602DCC5</a><br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Step1. Open the project in VS2010.<br>
<br>
Step2. Set the CSVSXSaveProject as the StartUp Project, and open its property pages.
<br>
<br>
&nbsp; &nbsp; &nbsp; 1. Select the Debug tab. Set the Start Option to Start external program and browse
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;the devenv.exe (The default location is C:\Program Files\Microsoft Visual Studio<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;10.0\Common7\IDE\devenv.exe), and add &quot;/rootsuffix Exp&quot; (no quote) to the Command<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;line arguments.<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; 2. Select the VSIX tab, make sure &quot;Create VSIX Container during build&quot; and
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&quot;Deploy VSIX content to Experimental Instance for debugging&quot; are checked.<br>
<br>
Step3. Build the solution. &nbsp;<br>
<br>
Step4. Press F5, and the Experimental Instance of Microsoft Visual Studio 2010 will
<br>
&nbsp; &nbsp; &nbsp; be launched.<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; In the VS Experimental Instance, click Tool=&gt;Extension Manager, you will find
<br>
&nbsp; &nbsp; &nbsp; CSVSXSaveProject is loaded.<br>
<br>
Step5. In the VS Experimental Instance, open an existing project. <br>
&nbsp; &nbsp; &nbsp; <br>
Step6. Right click a project node in the Solution Explorer, then click the menu <br>
&nbsp; &nbsp; &nbsp; &quot;CSVSXSaveProject&quot;. Click this menu, the SaveProjectDialog will show.<br>
&nbsp; &nbsp; &nbsp; <br>
Step7. Select the files you want to copy in the SaveProjectDialog, check &quot;Open new project&quot;,<br>
&nbsp; &nbsp; &nbsp; and then click the &quot;Save as&quot; button and choose a folder.<br>
<br>
&nbsp; &nbsp; &nbsp; You will find the current VS open the new project.<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
<br>
A. Create a VS Package named CSVSXSaveProject.<br>
<br>
&nbsp; You can check the detailed steps in &nbsp;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc138589.aspx">http://msdn.microsoft.com/en-us/library/cc138589.aspx</a><br>
<br>
<br>
B. Add the Command to File menu and the solution explorer context menu. <br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp; 1. Add a menu item to File menu.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &lt;Group guid=&quot;guidCSVSXSaveProjectCmdSet&quot; id=&quot;CSVSXSaveProjectGroup&quot; priority=&quot;0x0600&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Parent guid=&quot;guidSHLMainMenu&quot; id=&quot;IDM_VS_MENU_FILE&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;/Group&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &lt;Button guid=&quot;guidCSVSXSaveProjectCmdSet&quot; id=&quot;cmdidCSVSXSaveProjectCommandID&quot;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;priority=&quot;0x0100&quot; type=&quot;Button&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;Parent guid=&quot;guidCSVSXSaveProjectCmdSet&quot; id=&quot;CSVSXSaveProjectGroup&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;Icon guid=&quot;guidImages&quot; id=&quot;bmpPic1&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;Strings&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;CommandName&gt;cmdidCSVSXSaveProjectCommandID&lt;/CommandName&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;ButtonText&gt;CSVSXSaveProject&lt;/ButtonText&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;/Strings&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &lt;/Button&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &lt;!--Dynamic visibility--&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &lt;VisibilityConstraints&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;VisibilityItem guid=&quot;guidCSVSXSaveProjectCmdSet&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;id=&quot;cmdidCSVSXSaveProjectCommandID&quot; context=&quot;UICONTEXT_SolutionExists&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &lt;/VisibilityConstraints&gt;<br>
<br>
&nbsp; 2. Add the command to the solution explorer context menu. <br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;Group guid=&quot;guidCSVSXSaveProjectContextCmdSet&quot; id=&quot;menuidCSVSXSaveProjectContextGroup&quot; priority=&quot;0x01&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&lt;Parent guid=&quot;guidSolutionExplorerMenu&quot; id=&quot;menuidSolutionExplorerMenu&quot;/&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;&lt;/Group&gt;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Button guid=&quot;guidCSVSXSaveProjectCmdSet&quot; id=&quot;cmdidCSVSXSaveProjectCommandID&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;priority=&quot;0x0100&quot; type=&quot;Button&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Parent guid=&quot;guidCSVSXSaveProjectCmdSet&quot; id=&quot;CSVSXSaveProjectGroup&quot; /&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Icon guid=&quot;guidImages&quot; id=&quot;bmpPic1&quot; /&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;!--Add the dynamic visibility about the command menu.--&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;CommandFlag&gt;DynamicVisibility&lt;/CommandFlag&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Strings&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;CommandName&gt;cmdidCSVSXSaveProjectCommandID&lt;/CommandName&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;ButtonText&gt;CSVSXSaveProject&lt;/ButtonText&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Strings&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Button&gt;&nbsp;&nbsp;&nbsp;&nbsp;<br>
<br>
C. Get the files included in the project or in the project folder.<br>
&nbsp; <br>
&nbsp; 1. Get the files in the project folder.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;public static List&lt;ProjectFileItem&gt; GetFilesInProjectFolder(string projectFilePath)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Get the folder that includes the project file.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;FileInfo projFile = new FileInfo(projectFilePath);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;DirectoryInfo projFolder = projFile.Directory;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (projFolder.Exists)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Get all files information in project folder.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var files = projFolder.GetFiles(&quot;*&quot;, SearchOption.AllDirectories);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return files.Select(f =&gt; new ProjectFileItem { Fileinfo = f,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;IsUnderProjectFolder = true }).ToList();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// The project folder does not exist.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return null;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;<br>
&nbsp; 2. Get the files included in the project.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public List&lt;ProjectFileItem&gt; GetIncludedFiles()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;var files = new List&lt;ProjectFileItem&gt;();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Add the project file (*.csproj or *.vbproj...) to the list of files.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;files.Add(new ProjectFileItem<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Fileinfo = new FileInfo(Project.FullName),<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;NeedCopy = true,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;IsUnderProjectFolder = true<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;});<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Add the files included in the project.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;foreach (ProjectItem item in Project.ProjectItems)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;GetProjectItem(item, files);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return files;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;void GetProjectItem(ProjectItem item, List&lt;ProjectFileItem&gt; files)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;for (short i = 0; i &lt; item.FileCount; i&#43;&#43;)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (File.Exists(item.FileNames[i]))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ProjectFileItem fileItem = new ProjectFileItem();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;fileItem.Fileinfo = new FileInfo(item.FileNames[i]);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (fileItem.FullName.StartsWith(this.ProjectFolder.FullName,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;StringComparison.OrdinalIgnoreCase))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;fileItem.IsUnderProjectFolder = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;fileItem.NeedCopy = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;files.Add(fileItem);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;foreach (ProjectItem subItem in item.ProjectItems)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;GetProjectItem(subItem, files);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;} &nbsp;<br>
<br>
<br>
D. Design the UI of SaveProjectDialog<br>
&nbsp; <br>
&nbsp; This dialog is used to display the files included in the project, or under the project<br>
&nbsp; folder. Users can select the files that need to be copied.<br>
<br>
E. Open new project in the current IDE<br>
&nbsp; <br>
&nbsp; &nbsp;string cmd = string.Format(&quot;File.OpenProject \&quot;{0}\&quot;&quot;, newProjectPath);<br>
&nbsp; &nbsp;this.DTEObject.ExecuteCommand(cmd); &nbsp; &nbsp; </p>
<h3>References:</h3>
<p style="font-family:Courier New">Walkthroughs for Customizing Visual Studio By Using VSPackages<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc138565.aspx">http://msdn.microsoft.com/en-us/library/cc138565.aspx</a><br>
<br>
Creating Your First VSPackage<br>
<a target="_blank" href="http://blogs.msdn.com/b/vsxue/archive/2007/11/15/tutorial-2-creating-your-first-vspackage.aspx">http://blogs.msdn.com/b/vsxue/archive/2007/11/15/tutorial-2-creating-your-first-vspackage.aspx</a><br>
<br>
How to: Dynamically Add Menu Items <br>
ms-help://MS.VSCC.v90/MS.VSIPCC.v90/ms.vssdk.v90/dv_vsintegration/html/d281e9c9-b289-4d64-8d0a-094bac6c333c.htm<br>
<br>
Dynamic Menu Commands in Visual Studio Packages <br>
<a target="_blank" href="http://blogs.rev-net.com/ddewinter/2008/03/14/dynamic-menu-commands-in-visual-studio-packages-part-1/">http://blogs.rev-net.com/ddewinter/2008/03/14/dynamic-menu-commands-in-visual-studio-packages-part-1/</a><br>
<br>
Managing Solutions, Projects, and Files<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/wbzbtw81.aspx">http://msdn.microsoft.com/en-us/library/wbzbtw81.aspx</a><br>
<br>
_Solution Members<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/envdte._solution_members(v=VS.90).aspx">http://msdn.microsoft.com/en-us/library/envdte._solution_members(v=VS.90).aspx</a><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

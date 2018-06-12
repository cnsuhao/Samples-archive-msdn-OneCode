# Win7 taskbar Application ID (CSWin7TaskbarAppID)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* Windows 7
* Windows SDK
## Topics
* Windows Shell
* Taskbar
## IsPublished
* False
## ModifiedDate
* 2012-03-04 08:06:07
## Description

<h1><span style="">Win7 taskbar Application ID (CSWin7TaskbarAppID) </span></h1>
<h2>Introduction</h2>
<p class="MsoNormal"><br>
Application User Model IDs (AppUserModelIDs) are used extensively by the taskbar in Windows 7 and later systems to associate processes, files, and windows with a particular application. In some cases, it is sufficient to rely on the internal AppUserModelID
 assigned to a process by the system. However, an application that owns multiple processes or an application that is running in a host process might need to explicitly identify itself so that it can group its otherwise disparate windows under a single taskbar
 button and control the contents of that application's Jump List.</p>
<p class="MsoNormal">CSWin7TaskbarAppID example demostrates how to set process level Application User Model IDs (AppUserModelIDs or AppIDs) and modify the AppIDs for a specific window using Taskbar related APIs in Windows API Code Pack.</p>
<p class="MsoNormal"></p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoNormal"><span style="">Press F5 to run this application, and click the Open Sub Form button, you will see following result.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53668/1/image.png" alt="" width="838" height="280" align="middle">
</span><span style=""></span></p>
<h2>Creation</h2>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">In form load event, check the Windows version.<span style="">�
</span>If the current system is Windows 7 or Windows Server 2008 R2, set the process level AppID.<span style="">�
</span>Otherwise exit the process. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Check the Windows version, then set the current process's AppID or
// exit the current process
private void MainForm_Load(object sender, EventArgs e)
{
��� // Check whether the current system is Windows 7 or 
����// Windows Server 2008 R2
��� if (TaskbarManager.IsPlatformSupported)
��� {
������� // Set the AppID for the current process, it calls the 
��������// Windows API SetCurrentProcessExplicitAppUserModelID
������� // TaskbarManager.Instance represents an instance of the
������� // Windows Taskbar
������� TaskbarManager.Instance.ApplicationId = MainFormAppID;


������� // Set the Title of the MainForm to the AppID
������� this.Text = TaskbarManager.Instance.ApplicationId;


������� // Initialize the list holding the SubForms references
������� SubFormList = new List&lt;SubForm&gt;();
��� }
��� else
��� {
������� MessageBox.Show(&quot;Taskbar Application ID is not supported in&quot; 
������������&#43; &quot; your operation system!&quot; &#43; Environment.NewLine &#43;
����������� &quot;Please launch the application in Windows 7 or &quot; &#43; 
������������&quot;Windows Server 2008 R2 systems.&quot;);


������� // Exit the current process
������� Application.Exit();
��� }
}

</pre>
<pre id="codePreview" class="csharp">
// Check the Windows version, then set the current process's AppID or
// exit the current process
private void MainForm_Load(object sender, EventArgs e)
{
��� // Check whether the current system is Windows 7 or 
����// Windows Server 2008 R2
��� if (TaskbarManager.IsPlatformSupported)
��� {
������� // Set the AppID for the current process, it calls the 
��������// Windows API SetCurrentProcessExplicitAppUserModelID
������� // TaskbarManager.Instance represents an instance of the
������� // Windows Taskbar
������� TaskbarManager.Instance.ApplicationId = MainFormAppID;


������� // Set the Title of the MainForm to the AppID
������� this.Text = TaskbarManager.Instance.ApplicationId;


������� // Initialize the list holding the SubForms references
������� SubFormList = new List&lt;SubForm&gt;();
��� }
��� else
��� {
������� MessageBox.Show(&quot;Taskbar Application ID is not supported in&quot; 
������������&#43; &quot; your operation system!&quot; &#43; Environment.NewLine &#43;
����������� &quot;Please launch the application in Windows 7 or &quot; &#43; 
������������&quot;Windows Server 2008 R2 systems.&quot;);


������� // Exit the current process
������� Application.Exit();
��� }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">In open SubForm button, create a SubForm instance, add it into a List, and set specific AppID for the SubForm.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Create a SubForm and set a new AppID for it
private void openSubFormButton_Click(object sender, EventArgs e)
{
��� // Create a new SubForm
��� SubForm subForm = new SubForm();


��� // Set the SubForm's AppID, it calls Windows API
��� // SHGetPropertyStoreForWindow
��� TaskbarManager.Instance.SetApplicationIdForSpecificWindow(
������� subForm.Handle, SubFormAppID);


��� // Set the SubForm Title to the new AppID
��� subForm.Text = SubFormAppID;


��� // Display the SubForm
��� subForm.Show();


��� // Add this SubForm's reference into list
��� SubFormList.Add(subForm);


��� // Update the buttons' enable status
��� resetSubFormAppIDButton.Enabled = true;
��� setSubFormAppIDButton.Enabled = false;
}

</pre>
<pre id="codePreview" class="csharp">
// Create a SubForm and set a new AppID for it
private void openSubFormButton_Click(object sender, EventArgs e)
{
��� // Create a new SubForm
��� SubForm subForm = new SubForm();


��� // Set the SubForm's AppID, it calls Windows API
��� // SHGetPropertyStoreForWindow
��� TaskbarManager.Instance.SetApplicationIdForSpecificWindow(
������� subForm.Handle, SubFormAppID);


��� // Set the SubForm Title to the new AppID
��� subForm.Text = SubFormAppID;


��� // Display the SubForm
��� subForm.Show();


��� // Add this SubForm's reference into list
��� SubFormList.Add(subForm);


��� // Update the buttons' enable status
��� resetSubFormAppIDButton.Enabled = true;
��� setSubFormAppIDButton.Enabled = false;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">In set button, set all the SubForms a specific AppID.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Set all the SubForms's AppIDs to the SubFormAppID
private void setSubFormAppIDButton_Click(object sender, EventArgs e)
{
��� // Set all the SubForms's AppIDs and update the button enable 
����// status
��� if (SetAllSubFormAppIDs(SubFormAppID))
��� {
� ������resetSubFormAppIDButton.Enabled = true;
��� }
��� setSubFormAppIDButton.Enabled = false;
}������� 


/// &lt;summary&gt;
/// Set all the SubForms' AppID
/// &lt;/summary&gt;
/// &lt;param name=&quot;AppID&quot;&gt;The AppID to be set&lt;/param&gt;
/// &lt;returns&gt;Whether the operation successes&lt;/returns&gt;
private bool SetAllSubFormAppIDs(string AppID)
{
��� // Check whether there are any SubForms exist
��� if (SubFormList.Count &gt; 0)
��� {
������� foreach (var subForm in SubFormList)
������� {
����������� // Set each SubForm's AppID, it calls Windows API
����������� // SHGetPropertyStoreForWindow
����������� TaskbarManager.Instance.SetApplicationIdForSpecificWindow(
��������������� subForm.Handle, AppID);


����������� // Set the SubForm Title to the new AppID 
������������subForm.Text = AppID;
������� }
������� return true;
��� }
��� else
��� {
������� MessageBox.Show(&quot;No SubForms now!&quot;);
������� return false;
��� }
}

</pre>
<pre id="codePreview" class="csharp">
// Set all the SubForms's AppIDs to the SubFormAppID
private void setSubFormAppIDButton_Click(object sender, EventArgs e)
{
��� // Set all the SubForms's AppIDs and update the button enable 
����// status
��� if (SetAllSubFormAppIDs(SubFormAppID))
��� {
� ������resetSubFormAppIDButton.Enabled = true;
��� }
��� setSubFormAppIDButton.Enabled = false;
}������� 


/// &lt;summary&gt;
/// Set all the SubForms' AppID
/// &lt;/summary&gt;
/// &lt;param name=&quot;AppID&quot;&gt;The AppID to be set&lt;/param&gt;
/// &lt;returns&gt;Whether the operation successes&lt;/returns&gt;
private bool SetAllSubFormAppIDs(string AppID)
{
��� // Check whether there are any SubForms exist
��� if (SubFormList.Count &gt; 0)
��� {
������� foreach (var subForm in SubFormList)
������� {
����������� // Set each SubForm's AppID, it calls Windows API
����������� // SHGetPropertyStoreForWindow
����������� TaskbarManager.Instance.SetApplicationIdForSpecificWindow(
��������������� subForm.Handle, AppID);


����������� // Set the SubForm Title to the new AppID 
������������subForm.Text = AppID;
������� }
������� return true;
��� }
��� else
��� {
������� MessageBox.Show(&quot;No SubForms now!&quot;);
������� return false;
��� }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">In reset button, reset all the SubForms to the MainForm's AppID.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Reset all the SubForm's AppIDs to the MainFormAppID
private void resetSubFormAppIDButton_Click(object sender, EventArgs e)
{
��� // Set all the SubForms's AppIDs and update the button enable 
����// status
��� if (SetAllSubFormAppIDs(MainFormAppID))
��� {
������� setSubFormAppIDButton.Enabled = true;
��� }
��� resetSubFormAppIDButton.Enabled = false;
}

</pre>
<pre id="codePreview" class="csharp">
// Reset all the SubForm's AppIDs to the MainFormAppID
private void resetSubFormAppIDButton_Click(object sender, EventArgs e)
{
��� // Set all the SubForms's AppIDs and update the button enable 
����// status
��� if (SetAllSubFormAppIDs(MainFormAppID))
��� {
������� setSubFormAppIDButton.Enabled = true;
��� }
��� resetSubFormAppIDButton.Enabled = false;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style=""><span style=""></span></p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/dd378459(VS.85).aspx">Application User Model IDs (AppUserModelIDs)</a></p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/dd378422(VS.85).aspx">SetCurrentProcessExplicitAppUserModelID Function</a></p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/library/dd378430(VS.85).aspx">SHGetPropertyStoreForWindow Function</a></p>
<p class="MsoNormal" style=""><a href="http://code.msdn.microsoft.com/WindowsAPICodePack">Windows� API Code Pack for Microsoft� .NET Framework</a></p>
<p class="MsoNormal" style=""><a href="http://www.microsoft.com/downloads/details.aspx?familyid=1C333F06-FADB-4D93-9C80-402621C600E7&displaylang=en">Windows 7 Training Kit For Developers</a></p>
<p class="MsoNormal" style=""><a href="http://blogs.microsoft.co.il/blogs/sasha/archive/2009/02/15/windows-7-taskbar-application-id.aspx">Windows 7 Taskbar: Application Id</a></p>
<p class="MsoNormal" style=""><a href="http://windowsteamblog.com/blogs/developers/archive/2009/06/18/developing-for-the-windows-7-taskbar-application-id.aspx">Developing for the Windows 7 Taskbar � Application ID</a></p>
<p class="MsoNormal" style=""><a href="http://windowsteamblog.com/blogs/developers/archive/2009/06/19/developing-for-the-windows-7-taskbar-application-id-part-2.aspx">Developing for the Windows 7 Taskbar � Application ID � Part 2</a></p>
<p class="MsoNormal" style=""></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

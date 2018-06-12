# Subscribe to VS shell command events in VS addin (CSVSAddInCommandEvents)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* VSX
## Topics
* Capture Visual Studio add-in Command Events
## IsPublished
* True
## ModifiedDate
* 2011-05-05 06:28:02
## Description

<p style="font-family:Courier New"></p>
<h2>Visual Studio Add-In : CSVSAddInCommandEvents Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This sample demonstrates how to subscribe to the shell command executing and<br>
how to change the menu item's caption dynamically.<br>
<br>
The EnvDTE Automation has provided CommandEvents interface to represent the<br>
specific command events in the shell.<br>
The DTE.Events.get_CommandEvents() method gives the way to get the specific<br>
command events, then you could add your personal actions before/after the<br>
command executing.<br>
<br>
To change the text of menu item in AddIn, you need to get the CommandBar<br>
which contains the menu item controls firstly, then use<br>
CommandBarControl.Caption property to specify the caption of menu item.<br>
<br>
</p>
<h3>Deployment:</h3>
<p style="font-family:Courier New"><br>
1. Open CSVSAddInCommandEvents.AddIn file and change the Assembly element to<br>
the path of the CSVSAddInCommandEvents.dll file.<br>
<br>
2. Copy the CSVSAddInCommandEvents.AddIn file to directory:<br>
%userprofile%\Documents\Visual Studio 2008\Addins\<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
Step1. Create Visual Studio Add-in project from File -&gt; New -&gt; Project<br>
-&gt; Other Project Types -&gt; Extensibility -&gt; Visual Studio Add-In.<br>
<br>
Step2. When you create an add-in by using the Add-In Wizard and select<br>
the option to display it as a command, the command is on the Tools<br>
menu by default.<br>
<br>
Step3. In the add-in's Connect class and OnConnection() procedure,<br>
modify the command with name CSVSAddInCommandEvents and button text<br>
Add CommandEvent Subscription:<br>
<br>
Command command<br>
&nbsp; &nbsp;= commands.AddNamedCommand2(_addInInstance,<br>
&nbsp; &nbsp;&quot;CSVSAddInCommandEvents&quot;,<br>
&nbsp; &nbsp;&quot;Add CommandEvent Subscription&quot;,<br>
&nbsp; &nbsp;&quot;Executes the command for CSVSAddInCommandEvents&quot;,<br>
&nbsp; &nbsp;true, 59, ref contextGUIDS,<br>
&nbsp; &nbsp;(int)vsCommandStatus.vsCommandStatusSupported<br>
&nbsp; &nbsp;&#43; (int)vsCommandStatus.vsCommandStatusEnabled,<br>
&nbsp; &nbsp;(int)vsCommandStyle.vsCommandStylePictAndText,<br>
&nbsp; &nbsp;vsCommandControlType.vsCommandControlTypeButton);<br>
<br>
Step4. Add variables for the CommandEvents and menu item's state:<br>
<br>
private CommandEvents addReferenceEvents; // Command events.<br>
private bool isSubscribe; // Flag to indicate the menu item's current work.<br>
<br>
Step5. Initialize the isSubscribe to true in constructor:<br>
isSubscribe = true;<br>
<br>
Step6. Define a method to add subscription of the Project.AddReference<br>
command with below contents:<br>
<br>
public void AddSubscription()<br>
{<br>
&nbsp; &nbsp;// &quot;{1496A755-94DE-11D0-8C3F-00C04FC2AAE2}, 1113&quot; Guid-ID pair refer to<br>
&nbsp; &nbsp;// Project.AddReference command.<br>
&nbsp; &nbsp;// About how to get the Guid and ID of the specific command, please take<br>
&nbsp; &nbsp;// a look at this link on Dr.eX's blog:<br>
&nbsp; &nbsp;// <a target="_blank" href="http://blogs.msdn.com/dr._ex/archive/2007/04/17/using-">
http://blogs.msdn.com/dr._ex/archive/2007/04/17/using-</a><br>
&nbsp; &nbsp;// enablevsiplogging-to-identify-menus-and-commands-with-vs-2005-sp1.aspx<br>
&nbsp; &nbsp;try<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;addReferenceEvents<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;= _applicationObject.Events.get_CommandEvents(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&quot;{1496A755-94DE-11D0-8C3F-00C04FC2AAE2}&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;1113);<br>
&nbsp; &nbsp; &nbsp; &nbsp;addReferenceEvents.BeforeExecute<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&#43;= new _dispCommandEvents_BeforeExecuteEventHandler<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;(addReferenceEvents_BeforeExecute);<br>
&nbsp; &nbsp; &nbsp; &nbsp;addReferenceEvents.AfterExecute<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&#43;= new _dispCommandEvents_AfterExecuteEventHandler<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;(addReferenceEvents_AfterExecute);<br>
&nbsp; &nbsp;}<br>
&nbsp; &nbsp;catch (Exception e)<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;System.Windows.Forms.MessageBox.Show(e.Message);<br>
&nbsp; &nbsp;}<br>
}<br>
<br>
Step7. Define a method to remove subscription of the Project.AddReference<br>
command with below contents:<br>
<br>
public void RemoveSubscription()<br>
{<br>
&nbsp; &nbsp;try<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;addReferenceEvents.BeforeExecute<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;-= new _dispCommandEvents_BeforeExecuteEventHandler<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;(addReferenceEvents_BeforeExecute);<br>
&nbsp; &nbsp; &nbsp; &nbsp;addReferenceEvents.AfterExecute<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;-= new _dispCommandEvents_AfterExecuteEventHandler<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;(addReferenceEvents_AfterExecute);<br>
&nbsp; &nbsp;}<br>
&nbsp; &nbsp;catch (Exception e)<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;System.Windows.Forms.MessageBox.Show(e.Message);<br>
&nbsp; &nbsp;}<br>
}<br>
<br>
Step8. Implement the BeforeExecute/AfterExecute event handlers:<br>
<br>
public void addReferenceEvents_BeforeExecute(string Guid,<br>
&nbsp; &nbsp;int ID,<br>
&nbsp; &nbsp;object CustomIn,<br>
&nbsp; &nbsp;object CustomOut,<br>
&nbsp; &nbsp;ref bool CancelDefault)<br>
{<br>
&nbsp; &nbsp;System.Windows.Forms.MessageBox.Show(&quot;Before adding reference.&quot;);<br>
<br>
&nbsp; &nbsp;// If you want to cancel the default handler for this command, specify<br>
&nbsp; &nbsp;// the CancelDefault to true.<br>
<br>
&nbsp; &nbsp;//CancelDefault = true;<br>
}<br>
<br>
public void addReferenceEvents_AfterExecute(string Guid,<br>
&nbsp; &nbsp;int ID,<br>
&nbsp; &nbsp;object CustomIn,<br>
&nbsp; &nbsp;object CustomOut)<br>
{<br>
&nbsp; &nbsp;System.Windows.Forms.MessageBox.Show(&quot;After adding reference.&quot;);<br>
}<br>
<br>
Step9. Modify the Exec() procedure.<br>
Call the AddSubscription() or RemoveSubscription() method, change the caption<br>
of menu item depends on the flag isSubscribe:<br>
<br>
public void Exec(string commandName,<br>
&nbsp; &nbsp;vsCommandExecOption executeOption,<br>
&nbsp; &nbsp;ref object varIn,<br>
&nbsp; &nbsp;ref object varOut,<br>
&nbsp; &nbsp;ref bool handled)<br>
{<br>
&nbsp; &nbsp;handled = false;<br>
&nbsp; &nbsp;if (executeOption == vsCommandExecOption.vsCommandExecOptionDoDefault)<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;if (commandName<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;== &quot;CSVSAddInCommandEvents.Connect.CSVSAddInCommandEvents&quot;)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Get the Tools command bar.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Microsoft.VisualStudio.CommandBars.CommandBar menuBarCommandBar<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;= ((Microsoft.VisualStudio.CommandBars.CommandBars)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;_applicationObject.CommandBars)[&quot;MenuBar&quot;];<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CommandBarControl toolsControl<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;= menuBarCommandBar.Controls[&quot;Tools&quot;];<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CommandBarPopup toolsPopup = (CommandBarPopup)toolsControl;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CommandBar toolsCommandBar = toolsPopup.CommandBar;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (isSubscribe)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Subscribe to the command events.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;AddSubscription();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Next clicking will remove the subscription.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;isSubscribe = false;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Get the menu item control.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CommandBarControl menuItemControl<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;= toolsCommandBar.Controls[&quot;Add Subscription&quot;];<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Change its caption to Remove Subscription.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;menuItemControl.Caption = &quot;Remove CommandEvent Subscription&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Remove the subscription.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;RemoveSubscription();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Next clicking will add the subscription.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;isSubscribe = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Get the menu item control.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CommandBarControl menuItemControl<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;= toolsCommandBar.Controls[&quot;Remove Subscription&quot;];<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Change its caption to Add Subscription.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;menuItemControl.Caption = &quot;Add CommandEvent Subscription&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;handled = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;}<br>
}<br>
<br>
Step10. Compile the project.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Using EnableVSIPLogging to identify menus and commands with VS 2005 &#43; SP1:<br>
<a target="_blank" href="http://blogs.msdn.com/dr._ex/archive/2007/04/17/using-">http://blogs.msdn.com/dr._ex/archive/2007/04/17/using-</a>enablevsiplogging-to-<br>
identify-menus-and-commands-with-vs-2005-sp1.aspx<br>
<br>
CommandEvents Interface:<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/envdte.commandevents.aspx">http://msdn.microsoft.com/en-us/library/envdte.commandevents.aspx</a><br>
<br>
_DTE.Events Property:<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/envdte._dte.events.aspx">http://msdn.microsoft.com/en-us/library/envdte._dte.events.aspx</a>
<br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

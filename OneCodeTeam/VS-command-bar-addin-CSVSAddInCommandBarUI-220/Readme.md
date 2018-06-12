# VS command bar addin (CSVSAddInCommandBarUI)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* VSX
## Topics
* Display add-in in Visual Studio Toolbar
## IsPublished
* True
## ModifiedDate
* 2011-05-05 06:27:22
## Description

<p style="font-family:Courier New"></p>
<h2>Visual Studio Add-In : CSVSAddInCommandBarUI Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The CSVSAddInCommandBarUI project demostrates how to display Visual Studio<br>
add-in in toolbar or menubar. <br>
<br>
Visual Studio offers three kinds of CommandBar objects:<br>
<br>
1. Toolbars — Contain one or more menu bars.<br>
<br>
2. Menu bars — Commands on toolbars, such as File, Edit, and View.<br>
<br>
3. Shortcut menus (also known as context or popup menus.) — Menus that appear <br>
on the screen when you right-click a menu or object (such as a file or project). <br>
Submenus cascade off menu commands or off shortcut menus. Shortcut menus are <br>
similar to other menus in Visual Studio. However, you access them by pointing <br>
to an arrow in a menu bar, or by right-clicking an item in the integrated <br>
development environment (IDE).<br>
<br>
This sample displays three commandbars:<br>
<br>
1. In Menubar -&gt; Tool menu -&gt; All-In-One Command<br>
2. In Toolbar -&gt; All-In-One command<br>
3. In Task List toolbox -&gt; right click content menu -&gt; All-In-One command<br>
<br>
</p>
<h3>Deployment:</h3>
<p style="font-family:Courier New"><br>
1. Open CSVSAddInCommandBarUI.AddIn file and change the Assembly element to<br>
the path of the CSVSAddInCommandBarUI.dll file.<br>
<br>
2. Copy the CSVSAddInCommandBarUI.AddIn file to directory:<br>
%userprofile%\Documents\Visual Studio 2008\Addins\<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
Step1. Create Visual Studio Add-in project from File -&gt; New -&gt; Project <br>
-&gt; Other Project Types -&gt; Extensibility -&gt; Visual Studio Add-In<br>
<br>
Step2. When you create an add-in by using the Add-In Wizard and select <br>
the option to display it as a command, the command is on the Tools <br>
menu by default. <br>
<br>
Step3. In the add-in's Connect class and OnConnection() procedure,<br>
Creates Command with name CSVSAddInCommandBarUI and set its<br>
icon ID as 6743, which is red star instead of its default smiley<br>
face icon.<br>
<br>
Step4. Add command to Tool menubar by getting CommandBar with name &quot;MenuBar&quot;<br>
and its child CommandBarPopup control &quot;Tools&quot; and adding command into it.
<br>
<br>
Step5. Add command to toolbar by getting CommandBar &quot;Standard&quot; and adding<br>
command into its last item, then set its caption.<br>
<br>
Step6. Add command to shortcut menu by getting CommandBar &quot;Task List&quot; and<br>
adding command into its last item, then set its caption <br>
<br>
Step7. When any of those three button or menu item is clicked, execute <br>
command &quot;View.URL&quot; to navigate Visual Studio web browser to All-In-One<br>
home page.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Displaying Add-ins on Toolbars and Menus<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms165623.aspx">http://msdn.microsoft.com/en-us/library/ms165623.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

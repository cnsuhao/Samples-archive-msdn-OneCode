# VSPackage custom tool window (CSVSToolWindow)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* VSX
## Topics
* VSPackage with Tool Window
## IsPublished
* True
## ModifiedDate
* 2012-03-01 11:46:23
## Description

<h1>Customize Visual Studio Tool Window (<span class="SpellE">CSVSToolWindow</span>)</h1>
<h2>Introduction</h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">VSPackages are software modules that make up and extend the Visual Studio integrated development environment (IDE) by providing UI elements, services,
 projects, editors, and designers. VSPackages are the principal architectural unit of Visual Studio, and are the unit of deployment, licensing, and security also. Visual Studio itself is written mostly as a collection of VSPackages.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">This sample demonstrates how to create a simple VSPackage with a tool window that has a toolbar and an image.
</span></h2>
<h2>Building the Sample</h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">VS 2010 SP1 SDK must be installed on the machine. You can download it from:
</span></h2>
<p class="MsoNormal"><span lang="EN" style=""><a href="http://www.microsoft.com/download/en/details.aspx?id=21835">Visual Studio 2010 SP1 SDK</a></span></p>
<p class="MsoNormal">Set the Start Action and Start Options of Debug.</p>
<p class="MsoNormal">Start Action: <u>C:\Program Files\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe</u> (32bit OS) or
<u>C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe</u> (64bit OS)<u>
</u></p>
<p class="MsoNormal">Start Option: <u>/<span class="SpellE">rootsuffix</span>
<span class="SpellE">Exp</span></u></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53259/1/image.png" alt="" width="576" height="364" align="middle">
</span></p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press <b style="">F5</b> to debug this project.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>In the new instance of Visual Studio, click <b style="">View=&gt;Other Windows =&gt; My Tool Window</b>, or Press<b style=""> Ctrl &#43; Shift &#43;Y</b>, you will see the Tool Window.</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/53260/1/image.png" alt="" width="336" height="336" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Click the <b style="">Load File</b> button on the Tool Window, and select an image, the image will be displayed in the Tool Windows.
</p>
<p class="MsoListParagraphCxSpLast"><span style=""><img src="/site/view/file/53261/1/image.png" alt="" width="333" height="333" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoListParagraphCxSpFirst" style=""><b style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style="">Create a VS Package <span class="GramE">Project .</span>
</b></p>
<p class="MsoListParagraphCxSpMiddle">Use Visual Studio Integration Package Wizard to create a simple VSPackage project. You can follow the steps in
<a href="http://msdn.microsoft.com/en-us/library/cc138567.aspx">Walkthrough: Creating a Tool Window</a></p>
<p class="MsoListParagraphCxSpMiddle" style=""><b style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style="">Modify the Command Table (.<span class="SpellE">vsct</span> file).
</b></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""><span style="">a.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Add a button to <b style="">View=&gt;Other Windows</b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;!-- Add a button to  View=&gt;Other Window--&gt;
&lt;Button guid=&quot;guidCSVSToolWindowCmdSet&quot; id=&quot;cmdidMyTool&quot; priority=&quot;0x0100&quot; type=&quot;Button&quot;&gt;
    &lt;Parent guid=&quot;guidSHLMainMenu&quot; id=&quot;IDG_VS_WNDO_OTRWNDWS1&quot;/&gt;
    &lt;Icon guid=&quot;guidImages&quot; id=&quot;bmpPic2&quot; /&gt;
    &lt;Strings&gt;
        &lt;CommandName&gt;cmdidMyTool&lt;/CommandName&gt;
        &lt;ButtonText&gt;My Tool Window&lt;/ButtonText&gt;
    &lt;/Strings&gt;
&lt;/Button&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;!-- Add a button to  View=&gt;Other Window--&gt;
&lt;Button guid=&quot;guidCSVSToolWindowCmdSet&quot; id=&quot;cmdidMyTool&quot; priority=&quot;0x0100&quot; type=&quot;Button&quot;&gt;
    &lt;Parent guid=&quot;guidSHLMainMenu&quot; id=&quot;IDG_VS_WNDO_OTRWNDWS1&quot;/&gt;
    &lt;Icon guid=&quot;guidImages&quot; id=&quot;bmpPic2&quot; /&gt;
    &lt;Strings&gt;
        &lt;CommandName&gt;cmdidMyTool&lt;/CommandName&gt;
        &lt;ButtonText&gt;My Tool Window&lt;/ButtonText&gt;
    &lt;/Strings&gt;
&lt;/Button&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""><span style="">b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Define a Menu which will be displayed as a Toolbar in the Tool Window.
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;!--Define the toolbar of the ToolWindow. This toolbar will be added in the MyToolWindow.cs--&gt;
&lt;Menu guid=&quot;guidCSVSToolWindowCmdSet&quot; id=&quot;ToolbarID&quot;
      priority=&quot;0x0000&quot; type=&quot;ToolWindowToolbar&quot;&gt;
    &lt;Parent guid=&quot;guidCSVSToolWindowCmdSet&quot; id=&quot;ToolbarID&quot; /&gt;
    &lt;Strings&gt;
        &lt;ButtonText&gt;Tool Window Toolbar&lt;/ButtonText&gt;
        &lt;CommandName&gt;Tool Window Toolbar&lt;/CommandName&gt;
    &lt;/Strings&gt;
&lt;/Menu&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;!--Define the toolbar of the ToolWindow. This toolbar will be added in the MyToolWindow.cs--&gt;
&lt;Menu guid=&quot;guidCSVSToolWindowCmdSet&quot; id=&quot;ToolbarID&quot;
      priority=&quot;0x0000&quot; type=&quot;ToolWindowToolbar&quot;&gt;
    &lt;Parent guid=&quot;guidCSVSToolWindowCmdSet&quot; id=&quot;ToolbarID&quot; /&gt;
    &lt;Strings&gt;
        &lt;ButtonText&gt;Tool Window Toolbar&lt;/ButtonText&gt;
        &lt;CommandName&gt;Tool Window Toolbar&lt;/CommandName&gt;
    &lt;/Strings&gt;
&lt;/Menu&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""><span style="">c.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Add a button to the Toolbar.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;!--Define a child group of the Toolbar, any button of this group will be added the Toolbar--&gt;
&lt;Group guid=&quot;guidCSVSToolWindowCmdSet&quot; id=&quot;ToolbarGroupID&quot; priority=&quot;0x0000&quot;&gt;
    &lt;Parent guid=&quot;guidCSVSToolWindowCmdSet&quot; id=&quot;ToolbarID&quot;/&gt;
&lt;/Group&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;!--Define a child group of the Toolbar, any button of this group will be added the Toolbar--&gt;
&lt;Group guid=&quot;guidCSVSToolWindowCmdSet&quot; id=&quot;ToolbarGroupID&quot; priority=&quot;0x0000&quot;&gt;
    &lt;Parent guid=&quot;guidCSVSToolWindowCmdSet&quot; id=&quot;ToolbarID&quot;/&gt;
&lt;/Group&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;!-- Add a button to the ToolbarGroup, which means that it will be added to the ToolBar--&gt;
&lt;Button guid=&quot;guidCSVSToolWindowCmdSet&quot; id=&quot;cmdidOpenImage&quot; priority=&quot;0x0101&quot; type=&quot;Button&quot;&gt;
    &lt;Parent guid=&quot;guidCSVSToolWindowCmdSet&quot; id=&quot;ToolbarGroupID&quot;/&gt;
    &lt;Icon guid=&quot;guidImages&quot; id=&quot;bmpPic1&quot; /&gt;
    &lt;CommandFlag&gt;IconAndText&lt;/CommandFlag&gt;
    &lt;Strings&gt;
        &lt;CommandName&gt;cmdidOpenImage&lt;/CommandName&gt;
        &lt;ButtonText&gt;Load File&lt;/ButtonText&gt;
    &lt;/Strings&gt;
&lt;/Button&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;!-- Add a button to the ToolbarGroup, which means that it will be added to the ToolBar--&gt;
&lt;Button guid=&quot;guidCSVSToolWindowCmdSet&quot; id=&quot;cmdidOpenImage&quot; priority=&quot;0x0101&quot; type=&quot;Button&quot;&gt;
    &lt;Parent guid=&quot;guidCSVSToolWindowCmdSet&quot; id=&quot;ToolbarGroupID&quot;/&gt;
    &lt;Icon guid=&quot;guidImages&quot; id=&quot;bmpPic1&quot; /&gt;
    &lt;CommandFlag&gt;IconAndText&lt;/CommandFlag&gt;
    &lt;Strings&gt;
        &lt;CommandName&gt;cmdidOpenImage&lt;/CommandName&gt;
        &lt;ButtonText&gt;Load File&lt;/ButtonText&gt;
    &lt;/Strings&gt;
&lt;/Button&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""><span style="">d.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Define the Key Binding of the command to open the Toolbar.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;!-- Set the key binding of the cmdidMyTool command--&gt;
&lt;KeyBindings&gt;
    &lt;KeyBinding guid=&quot;guidCSVSToolWindowCmdSet&quot;
                id=&quot;cmdidMyTool&quot;
                editor=&quot;guidVSStd97&quot;
                key1=&quot;Y&quot;
                mod1=&quot;Control Shift&quot;/&gt;
&lt;/KeyBindings&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;!-- Set the key binding of the cmdidMyTool command--&gt;
&lt;KeyBindings&gt;
    &lt;KeyBinding guid=&quot;guidCSVSToolWindowCmdSet&quot;
                id=&quot;cmdidMyTool&quot;
                editor=&quot;guidVSStd97&quot;
                key1=&quot;Y&quot;
                mod1=&quot;Control Shift&quot;/&gt;
&lt;/KeyBindings&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style=""><b style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style="">Handle the <span class="SpellE">cmdidMyTool</span> command in Package.
</b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
/// Initialization of the package; this method is called right after the package is sited, so this is the place
/// where you can put all the initilaization code that rely on services provided by VisualStudio.
/// &lt;/summary&gt;
protected override void Initialize()
{
    Trace.WriteLine (string.Format(CultureInfo.CurrentCulture, &quot;Entering Initialize() of: {0}&quot;, this.ToString()));
    base.Initialize();


    // Add our command handlers for menu (commands must exist in the .vsct file)
    OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
    if ( null != mcs )
    {
        // Create the command for the tool window
        CommandID toolwndCommandID = new CommandID(GuidList.guidCSVSToolWindowCmdSet, (int)PkgCmdIDList.cmdidMyTool);
        MenuCommand menuToolWin = new MenuCommand(ShowToolWindow, toolwndCommandID);
        mcs.AddCommand( menuToolWin );
    }
}

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
/// Initialization of the package; this method is called right after the package is sited, so this is the place
/// where you can put all the initilaization code that rely on services provided by VisualStudio.
/// &lt;/summary&gt;
protected override void Initialize()
{
    Trace.WriteLine (string.Format(CultureInfo.CurrentCulture, &quot;Entering Initialize() of: {0}&quot;, this.ToString()));
    base.Initialize();


    // Add our command handlers for menu (commands must exist in the .vsct file)
    OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
    if ( null != mcs )
    {
        // Create the command for the tool window
        CommandID toolwndCommandID = new CommandID(GuidList.guidCSVSToolWindowCmdSet, (int)PkgCmdIDList.cmdidMyTool);
        MenuCommand menuToolWin = new MenuCommand(ShowToolWindow, toolwndCommandID);
        mcs.AddCommand( menuToolWin );
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"><b style=""></b></p>
<p class="MsoListParagraphCxSpLast" style=""><b style=""><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style="">Open the Tool Window </b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private void ShowToolWindow(object sender, EventArgs e)
{
    // Get the instance number 0 of this tool window. This window is single instance so this instance
    // is actually the only one.
    // The last flag is set to true so that if the tool window does not exists it will be created.
    ToolWindowPane window = this.FindToolWindow(typeof(MyToolWindow), 0, true);
    if ((null == window) || (null == window.Frame))
    {
        throw new NotSupportedException(Resources.CanNotCreateWindow);
    }
    IVsWindowFrame windowFrame = (IVsWindowFrame)window.Frame;
    Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(windowFrame.Show());
}

</pre>
<pre id="codePreview" class="csharp">
private void ShowToolWindow(object sender, EventArgs e)
{
    // Get the instance number 0 of this tool window. This window is single instance so this instance
    // is actually the only one.
    // The last flag is set to true so that if the tool window does not exists it will be created.
    ToolWindowPane window = this.FindToolWindow(typeof(MyToolWindow), 0, true);
    if ((null == window) || (null == window.Frame))
    {
        throw new NotSupportedException(Resources.CanNotCreateWindow);
    }
    IVsWindowFrame windowFrame = (IVsWindowFrame)window.Frame;
    Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(windowFrame.Show());
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"><b style=""></b></p>
<p class="MsoListParagraphCxSpLast" style=""><b style=""><span style=""><span style="">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style="">Add a Toolbar to the Tool Window and set its content.
</b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
/// Standard constructor for the tool window.
/// &lt;/summary&gt;
public MyToolWindow() :
    base(null)
{
    // Set the window title reading it from the resources.
    this.Caption = Resources.ToolWindowTitle;
    // Set the image that will appear on the tab of the window frame
    // when docked with an other window
    // The resource ID correspond to the one defined in the resx file
    // while the Index is the offset in the bitmap strip. Each image in
    // the strip being 16x16.
    this.BitmapResourceID = 301;
    this.BitmapIndex = 1;


    // Create the toolbar.
    this.ToolBar = new CommandID(GuidList.guidCSVSToolWindowCmdSet,
        PkgCmdIDList.ToolbarID);
    this.ToolBarLocation = (int)VSTWT_LOCATION.VSTWT_TOP;


    // Create the handlers for the toolbar commands.
    var mcs = GetService(typeof(IMenuCommandService))
        as OleMenuCommandService;
    if (null != mcs)
    {
        var toolbarbtnCmdID = new CommandID(
            GuidList.guidCSVSToolWindowCmdSet,
            PkgCmdIDList.cmdidOpenImage);
        var menuItem = new MenuCommand(new EventHandler(
            ButtonHandler), toolbarbtnCmdID);
        mcs.AddCommand(menuItem);
    }




    // This is the user control hosted by the tool window
    control = new MyControl();
    base.Content = control;
}

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
/// Standard constructor for the tool window.
/// &lt;/summary&gt;
public MyToolWindow() :
    base(null)
{
    // Set the window title reading it from the resources.
    this.Caption = Resources.ToolWindowTitle;
    // Set the image that will appear on the tab of the window frame
    // when docked with an other window
    // The resource ID correspond to the one defined in the resx file
    // while the Index is the offset in the bitmap strip. Each image in
    // the strip being 16x16.
    this.BitmapResourceID = 301;
    this.BitmapIndex = 1;


    // Create the toolbar.
    this.ToolBar = new CommandID(GuidList.guidCSVSToolWindowCmdSet,
        PkgCmdIDList.ToolbarID);
    this.ToolBarLocation = (int)VSTWT_LOCATION.VSTWT_TOP;


    // Create the handlers for the toolbar commands.
    var mcs = GetService(typeof(IMenuCommandService))
        as OleMenuCommandService;
    if (null != mcs)
    {
        var toolbarbtnCmdID = new CommandID(
            GuidList.guidCSVSToolWindowCmdSet,
            PkgCmdIDList.cmdidOpenImage);
        var menuItem = new MenuCommand(new EventHandler(
            ButtonHandler), toolbarbtnCmdID);
        mcs.AddCommand(menuItem);
    }




    // This is the user control hosted by the tool window
    control = new MyControl();
    base.Content = control;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph"><b style=""></b></p>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/cc138567.aspx">Walkthrough: Creating a Tool Window</a></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/bb164699.aspx">Visual Studio Command Table (.<span class="SpellE">Vsct</span>) Files</a></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/bb165399.aspx">Commands Element</a>
</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/bb165085.aspx"><span class="SpellE">KeyBindings</span> Element</a>
</p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

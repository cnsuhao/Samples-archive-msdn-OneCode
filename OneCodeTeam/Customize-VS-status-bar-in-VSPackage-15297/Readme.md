# Customize VS status bar in VSPackage (CSVSPackageStatusBar)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* VSX
## Topics
* VSX
* Visual Studio Status Bar
## IsPublished
* True
## ModifiedDate
* 2012-02-23 10:45:38
## Description

<h1>Customize VS status bar in VSPackage (<span class="SpellE">CSVSPackageStatusBar</span>)<span style="">
</span></h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span style="">The Visual Studio status bar, the horizontal region at the bottom of the Visual Studio design surface, provides a convenient way to convey information about the current state of the integrated development environment (IDE).
 The status bar comprises four programmable regions, as shown in the following table:
</span></p>
<p class="MsoNormal"><b style=""><span style="">Feedback: </span></b><span style="">Displays text. You can set and retrieve text, display static text, and highlight the displayed text.
</span></p>
<p class="MsoNormal"><b style=""><span style="">Progress Bar: </span></b><span style="">Displays incremental progress for quick operations, such as saving a single file to disk.
</span></p>
<p class="MsoNormal"><b style=""><span style="">Animation: </span></b><span style="">Displays a continuously looped animation, which indicates either a lengthy operation or an operation of indeterminate length (for example, building multiple projects in a
 solution). </span></p>
<p class="MsoNormal"><b style=""><span style="">Designer: </span></b><span style="">Displays information pertinent to editing, such as the line number or column number of the cursor location.
</span></p>
<p class="MsoNormal"><span style="">In this sample, we will demo: </span></p>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Write highlighted text in feedback region </span>
</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Read text from feedback region </span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Show progress bar in status bar </span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Show animation in the status bar </span></p>
<p class="MsoListParagraphCxSpLast" style=""><span style=""><span style="">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Write row, column and char to designer region
</span></p>
<h2>Building the Sample</h2>
<p class="MsoNormal">VS 2010 SP1 SDK must be installed on the machine. You can download it from:
</p>
<p class="MsoNormal"><span lang="EN" style=""><a href="http://www.microsoft.com/download/en/details.aspx?id=21835">Visual Studio 2010 SP1 SDK</a></span></p>
<p class="MsoNormal">Set the Start Action and Start Options of Debug.</p>
<p class="MsoNormal">Start Action: <u>C:\Program Files\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe</u> (32bit OS) or
<u>C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe</u> (64bit OS)<u>
</u></p>
<p class="MsoNormal">Start Option: <u>/<span class="SpellE">rootsuffix</span>
<span class="SpellE">Exp</span></u></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/50647/1/image.png" alt="" width="576" height="364" align="middle">
</span></p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press <b style="">F5</b> to debug this project.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>In the new instance of Visual Studio, click <b style="">View=&gt;Other Windows =&gt;
</b><b style=""><span style="">Status Bar Demo</span></b>, you will see the Tool Window.</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/50648/1/image.png" alt="" width="306" height="285" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Click the <b style="">Write Feedback in Status Bar</b><b style=""><span style="">
</span></b>button on the Tool Window<span style="">, you will see following message in the status bar.</span>
</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/50649/1/image.png" alt="" width="927" height="28" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Click the <b style=""><span style="">Read</span> Feedback in Status Bar</b><b style=""><span style="">
</span></b>button on the Tool Window<span style="">, you will see following message box.</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/50650/1/image.png" alt="" width="274" height="202" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Click the <b style=""><span style="">Show Progress Bar </span>
</b>button on the Tool Window<span style="">, you will see following progress bar in the status bar.</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/50651/1/image.png" alt="" width="938" height="33" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/50652/1/image.png" alt="" width="936" height="28" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Click the <b style=""><span style="">Show Animation</span> in Status Bar</b><b style=""><span style="">
</span></b>button on the Tool Window<span style="">, you will see following animation in the status bar.</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><span style="">&nbsp;</span>
<img src="/site/view/file/50653/1/image.png" alt="" width="295" height="221" align="middle">
<span style="">&nbsp;</span> <img src="/site/view/file/50654/1/image.png" alt="" width="298" height="219" align="middle">
<img src="/site/view/file/50655/1/image.png" alt="" width="296" height="219" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">7.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Click the <b style=""><span style="">Update Designer Region </span>
</b>button on the Tool Window<span style="">, you will see following message in the status bar.</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/50656/1/image.png" alt="" width="949" height="28" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast"></p>
<h2>Using the Code</h2>
<p class="MsoListParagraphCxSpFirst" style=""><b style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style="">Create a VS Package Project. </b></p>
<p class="MsoListParagraphCxSpMiddle">Use Visual Studio Integration Package Wizard to create a simple VSPackage project. You can follow the steps in
<a href="http://msdn.microsoft.com/en-us/library/cc138567.aspx">Walkthrough: Creating a Tool Window</a><span style="">
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style=""><b style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style="">Modify the Command Table (.<span class="SpellE">vsct</span> file).
</b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;!-- Add a button to  View=&gt;Other Window--&gt;
&lt;Button guid=&quot;guidCSVSPackageStatusBarCmdSet&quot; id=&quot;cmdidStatusBarDemo&quot; priority=&quot;0x0100&quot; type=&quot;Button&quot;&gt;
    &lt;Parent guid=&quot;guidSHLMainMenu&quot; id=&quot;IDG_VS_WNDO_OTRWNDWS1&quot;/&gt;
    &lt;Icon guid=&quot;guidImages&quot; id=&quot;bmpPic2&quot; /&gt;
    &lt;Strings&gt;
        &lt;CommandName&gt;cmdidStatusBarDemo&lt;/CommandName&gt;
        &lt;ButtonText&gt;Status Bar Demo&lt;/ButtonText&gt;
    &lt;/Strings&gt;
&lt;/Button&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;!-- Add a button to  View=&gt;Other Window--&gt;
&lt;Button guid=&quot;guidCSVSPackageStatusBarCmdSet&quot; id=&quot;cmdidStatusBarDemo&quot; priority=&quot;0x0100&quot; type=&quot;Button&quot;&gt;
    &lt;Parent guid=&quot;guidSHLMainMenu&quot; id=&quot;IDG_VS_WNDO_OTRWNDWS1&quot;/&gt;
    &lt;Icon guid=&quot;guidImages&quot; id=&quot;bmpPic2&quot; /&gt;
    &lt;Strings&gt;
        &lt;CommandName&gt;cmdidStatusBarDemo&lt;/CommandName&gt;
        &lt;ButtonText&gt;Status Bar Demo&lt;/ButtonText&gt;
    &lt;/Strings&gt;
&lt;/Button&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"></p>
<p class="MsoListParagraphCxSpLast" style=""><b style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style="">Handle the <span class="SpellE">cmdidStatusBarDemo</span> command in Package.
</b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
protected override void Initialize()
{
    Trace.WriteLine (string.Format(CultureInfo.CurrentCulture, &quot;Entering Initialize() of: {0}&quot;, this.ToString()));
    base.Initialize();


    // Add our command handlers for menu (commands must exist in the .vsct file)
    OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
    if ( null != mcs )
    {
        // Create the command for the tool window
        CommandID toolwndCommandID = new CommandID(GuidList.guidCSVSPackageStatusBarCmdSet, (int)PkgCmdIDList.cmdidStatusBarDemo);
        MenuCommand menuToolWin = new MenuCommand(ShowToolWindow, toolwndCommandID);
        mcs.AddCommand( menuToolWin );
    }
}

</pre>
<pre id="codePreview" class="csharp">
protected override void Initialize()
{
    Trace.WriteLine (string.Format(CultureInfo.CurrentCulture, &quot;Entering Initialize() of: {0}&quot;, this.ToString()));
    base.Initialize();


    // Add our command handlers for menu (commands must exist in the .vsct file)
    OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
    if ( null != mcs )
    {
        // Create the command for the tool window
        CommandID toolwndCommandID = new CommandID(GuidList.guidCSVSPackageStatusBarCmdSet, (int)PkgCmdIDList.cmdidStatusBarDemo);
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
</span></span></span></b><b style=""><span style="">Set the content of the</span> Tool Window and set its content.
</b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public class MyToolWindow : ToolWindowPane
{
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


        // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
        // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on 
        // the object returned by the Content property.
        base.Content = new MyControl();
    }


    /// &lt;summary&gt;
    /// Initialize the SvcStatusBar property of the control.
    /// &lt;/summary&gt;
    public override void OnToolWindowCreated()
    {
        base.OnToolWindowCreated();
        (base.Content as MyControl).SvcStatusBar = GetService(typeof(SVsStatusbar)) as IVsStatusbar;
    }

</pre>
<pre id="codePreview" class="csharp">
public class MyToolWindow : ToolWindowPane
{
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


        // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
        // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on 
        // the object returned by the Content property.
        base.Content = new MyControl();
    }


    /// &lt;summary&gt;
    /// Initialize the SvcStatusBar property of the control.
    /// &lt;/summary&gt;
    public override void OnToolWindowCreated()
    {
        base.OnToolWindowCreated();
        (base.Content as MyControl).SvcStatusBar = GetService(typeof(SVsStatusbar)) as IVsStatusbar;
    }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><b style=""><span style=""></span></b></p>
<p class="MsoListParagraphCxSpFirst" style=""><b style=""><span style=""><span style="">6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">Write the Feedback region of the Visual Studio Status bar</span>
</b></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:54.0pt"><span style=""><span style="">a)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Obtain an instance of the <span class="SpellE"><b style="">IVsStatusbar</b></span> interface, which is made available through the
<span class="SpellE"><b style="">SVsStatusbar</b></span> service.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:54.0pt"><span style=""><span style="">b)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE"><b style="">SetColorText</b></span> only displays white text on a dark blue background.</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:54.0pt"><span style=""><span style="">c)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE"><b style="">SetText</b></span> to set text in the feedback region</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private void btnWriteFeedback_Click(object sender, System.EventArgs e)
{
    // Checks to see if the status bar is frozen 
    // by calling the IsFrozen method.
    int frozen;
    SvcStatusBar.IsFrozen(out frozen);
    if (frozen == 0)
    {
        // SetColorText only displays white text on a 
        // dark blue background.
        SvcStatusBar.SetColorText(&quot;Here's some highlighted text&quot;, 0, 0);
        System.Windows.Forms.MessageBox.Show(&quot;Pause&quot;);
        SvcStatusBar.SetText(&quot;Done&quot;);
    }
}

</pre>
<pre id="codePreview" class="csharp">
private void btnWriteFeedback_Click(object sender, System.EventArgs e)
{
    // Checks to see if the status bar is frozen 
    // by calling the IsFrozen method.
    int frozen;
    SvcStatusBar.IsFrozen(out frozen);
    if (frozen == 0)
    {
        // SetColorText only displays white text on a 
        // dark blue background.
        SvcStatusBar.SetColorText(&quot;Here's some highlighted text&quot;, 0, 0);
        System.Windows.Forms.MessageBox.Show(&quot;Pause&quot;);
        SvcStatusBar.SetText(&quot;Done&quot;);
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:54.0pt"></p>
<p class="MsoListParagraphCxSpMiddle" style=""><b style=""><span style=""><span style="">7.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">R</span>ead the Feedback region of the Visual Studio Status bar
</b></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">a)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Obtain an instance of the <span class="SpellE"><b style="">IVsStatusbar</b></span> interface, which is made available through the
<span class="SpellE"><b style="">SVsStatusbar</b></span> service.</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""><span style="">b)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE"><b style="">GetText</b></span> to get the text from the feedback region</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private void btnReadFeedback_Click(object sender, System.EventArgs e)
{
    // Retrieve the status bar text.
    string text;
    SvcStatusBar.GetText(out text);
    System.Windows.Forms.MessageBox.Show(text);


    // Clear the status bar text.
    SvcStatusBar.FreezeOutput(0);
    SvcStatusBar.Clear();
}

</pre>
<pre id="codePreview" class="csharp">
private void btnReadFeedback_Click(object sender, System.EventArgs e)
{
    // Retrieve the status bar text.
    string text;
    SvcStatusBar.GetText(out text);
    System.Windows.Forms.MessageBox.Show(text);


    // Clear the status bar text.
    SvcStatusBar.FreezeOutput(0);
    SvcStatusBar.Clear();
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"></p>
<p class="MsoListParagraphCxSpMiddle" style=""><b style=""><span style=""><span style="">8.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">S</span>how progress bar in the status bar
</b></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">a)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Obtains an instance of the <span class="SpellE"><b style="">IVsStatusbar</b></span> interface from the
<span class="SpellE"><b style="">SVsStatusbar</b></span> service.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">b)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Initializes the progress bar to given starting values by calling the Progress method.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">c)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Simulates an operation by iterating through <span class="GramE">
a <b style="">for</b></span> loop and updating the progress bar values using the Progress method.</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""><span style="">d)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Clears the progress bar using the Clear method.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private void btnShowProgressBar_Click(object sender, System.EventArgs e)
{
    uint cookie = 0;
    string label = &quot;Progress bar label...&quot;;


    // Initialize the progress bar.
    SvcStatusBar.Progress(ref cookie, 1, &quot;&quot;, 0, 0);


    for (uint i = 0, total = 100; i &lt;= total; i&#43;&#43;)
    {
        // Display incremental progress.
        SvcStatusBar.Progress(ref cookie, 1, label, i, total);
        System.Threading.Thread.Sleep(10);
    }


    // Clear the progress bar.
    SvcStatusBar.Progress(ref cookie, 0, &quot;&quot;, 0, 0);
}

</pre>
<pre id="codePreview" class="csharp">
private void btnShowProgressBar_Click(object sender, System.EventArgs e)
{
    uint cookie = 0;
    string label = &quot;Progress bar label...&quot;;


    // Initialize the progress bar.
    SvcStatusBar.Progress(ref cookie, 1, &quot;&quot;, 0, 0);


    for (uint i = 0, total = 100; i &lt;= total; i&#43;&#43;)
    {
        // Display incremental progress.
        SvcStatusBar.Progress(ref cookie, 1, label, i, total);
        System.Threading.Thread.Sleep(10);
    }


    // Clear the progress bar.
    SvcStatusBar.Progress(ref cookie, 0, &quot;&quot;, 0, 0);
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"></p>
<p class="MsoListParagraphCxSpMiddle" style=""><b style=""><span style=""><span style="">9.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">U</span>se the animation region of status bar
</b></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">a)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Obtain an instance of the <span class="SpellE"><b style="">IVsStatusbar</b></span> interface, which is made available through the
<span class="SpellE"><b style="">SVsStatusbar</b></span> service.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">b)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Start the animation by calling the <b style="">Animation</b> method of the status bar. Pass in 1 as the value of the first parameter, and a reference to an animated icon as the value of the second parameter.</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""><span style="">c)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Stop the animation by calling the <b style="">Animation</b> method of the status bar. Pass in 0 as the value of the first parameter, and a reference to the animated icon as the value of the second parameter.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private void btnShowAnimation_Click(object sender, System.EventArgs e)
{
    object icon =
        (short)Microsoft.VisualStudio.Shell.Interop.Constants.SBAI_General;


    // Display the animated Visual Studio icon in the Animation region.
    // Start the animation by calling the Animation method of the status bar. 
    // Pass in 1 as the value of the first parameter, and a reference to an 
    // animated icon as the value of the second parameter.
    SvcStatusBar.Animation(1, ref icon);


    System.Windows.Forms.MessageBox.Show(
        &quot;Click OK to end status bar animation.&quot;);


    // Stop the animation by calling the Animation method of the status bar. 
    // Pass in 0 as the value of the first parameter, and a reference to the 
    // animated icon as the value of the second parameter.
    SvcStatusBar.Animation(0, ref icon);
}

</pre>
<pre id="codePreview" class="csharp">
private void btnShowAnimation_Click(object sender, System.EventArgs e)
{
    object icon =
        (short)Microsoft.VisualStudio.Shell.Interop.Constants.SBAI_General;


    // Display the animated Visual Studio icon in the Animation region.
    // Start the animation by calling the Animation method of the status bar. 
    // Pass in 1 as the value of the first parameter, and a reference to an 
    // animated icon as the value of the second parameter.
    SvcStatusBar.Animation(1, ref icon);


    System.Windows.Forms.MessageBox.Show(
        &quot;Click OK to end status bar animation.&quot;);


    // Stop the animation by calling the Animation method of the status bar. 
    // Pass in 0 as the value of the first parameter, and a reference to the 
    // animated icon as the value of the second parameter.
    SvcStatusBar.Animation(0, ref icon);
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"></p>
<p class="MsoListParagraphCxSpMiddle" style=""><b style=""><span style=""><span style="">10.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">P</span>rogram the designer region of the status bar
</b></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">a)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Obtain an instance of the <span class="SpellE"><b style="">IVsStatusbar</b></span> interface, which is made available through the
<span class="SpellE"><b style="">SVsStatusbar</b></span> service.</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""><span style="">b)<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Update the Designer region of the status bar by calling the <span class="SpellE">
<b style="">SetInsMode</b></span> and <span class="SpellE"><b style="">SetLineColChar</b></span> methods of the
<span class="SpellE"><b style="">IVsStatusbar</b></span> instance.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private void btnUpdateDesignerRegion_Click(object sender, System.EventArgs e)
{
    // Set insert/overstrike mode.
    object mode = 1; // Insert mode
    SvcStatusBar.SetInsMode(ref mode);


    // Display Ln ## Col ## Ch ## information.
    object ln = &quot;##&quot;, col = &quot;##&quot;, ch = &quot;##&quot;;
    SvcStatusBar.SetLineColChar(ref ln, ref col, ref ch);
}

</pre>
<pre id="codePreview" class="csharp">
private void btnUpdateDesignerRegion_Click(object sender, System.EventArgs e)
{
    // Set insert/overstrike mode.
    object mode = 1; // Insert mode
    SvcStatusBar.SetInsMode(ref mode);


    // Display Ln ## Col ## Ch ## information.
    object ln = &quot;##&quot;, col = &quot;##&quot;, ch = &quot;##&quot;;
    SvcStatusBar.SetLineColChar(ref ln, ref col, ref ch);
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"></p>
<p class="MsoListParagraphCxSpLast"><b style=""></b></p>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/cc138567.aspx">Walkthrough: Creating a Tool Window</a></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/bb164699.aspx">Visual Studio Command Table (.<span class="SpellE">Vsct</span>) Files</a></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/bb166795.aspx">MSDN: Status Bar</a></p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

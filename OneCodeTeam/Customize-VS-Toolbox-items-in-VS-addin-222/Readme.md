# Customize VS Toolbox items in VS addin (CSVSAddInToolboxItem)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* VSX
## Topics
* Toolbox
## IsPublished
* True
## ModifiedDate
* 2012-03-01 11:50:44
## Description

<h1>Customize VS Toolbox items in VS addin (CSVSAddInToolboxItem)<span style=""> </span>
</h1>
<h2>Introduction<span style=""> </span></h2>
<p class="MsoNormal">The CSVSAddInToolboxItem project demonstrates how to customize Toolbox items<span style="">
</span>in DTE automation model or by Toolbox service.</p>
<p class="MsoNormal">In this sample, an add-in command button named &quot;Add Customized Toolbox Item&quot; will be registered in the Tool menu. By clicking the menu, sample code will<span style="">
</span>do follow<span style="">ing</span> two things:</p>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Use DTE automation model to add an item under CustomTab tab<span style="">
</span></p>
<p class="MsoListParagraphCxSpLast" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Use VS Toolbox service to add an item under CustomTab tab<span style="">
</span></p>
<p class="MsoNormal">Both items are HTML content, <span style=""><span style="">&nbsp;</span>and
</span>they can be used by dragging and dropping to a web page designer.<b><span style="">
</span></b></p>
<h2>Building the Sample</h2>
<p class="MsoNormal">VS 20<span style="">08</span> SP1 SDK must be installed on the machine. You can download it from:
</p>
<p class="MsoNormal"><span lang="EN" style=""><a href="http://www.microsoft.com/download/en/details.aspx?id=21827">Visual Studio 2008 SDK 1.1</a></span><span lang="EN" style="">
</span></p>
<p class="MsoNormal">Set the Start Action and Start Options of Debug.</p>
<p class="MsoNormal">Start Action: <u>C:\Program Files\Microsoft Visual Studio </u>
<u><span style="">9</span>.0\Common7\IDE\devenv.exe</u> (32bit OS) or <u>C:\Program Files (x86)\Microsoft Visual Studio
</u><u><span style="">9</span>.0\Common7\IDE\devenv.exe</u> (64bit OS)<u> </u></p>
<p class="MsoNormal">Start Option: <u>/resetaddin CSVSAddInToolboxItem.Connect</u></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53303/1/image.png" alt="" width="576" height="303" align="middle">
</span></p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoListParagraphCxSpFirst" style=""><a name="OLE_LINK2"></a><a name="OLE_LINK1"><span style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Open CSVSAddInToolboxItem.AddIn file and change the Assembly element to the path of the CSVSAddInToolboxItem.dll file.
</span></span></a></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Copy the CSVSAddInToolboxItem.AddIn file to directory:
<b style="">%userprofile%\Documents\Visual Studio 2008\Addins\.</b></span></span></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><span style=""><b style=""><span style=""></span></b></span></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><span style=""><span style="">Or you can copy both<b style="">
</b>CSVSAddInToolboxItem.AddIn and CSVSAddInToolboxItem.dll to <b style="">%userprofile%\Documents\Visual Studio 2008\Addins\,
</b>so you do not have to modify the CSVSAddInToolboxItem.AddIn file.</span> </span>
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><span style=""></span></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press <b style="">F5</b> to debug this project.</span></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style=""><b style=""><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b>In the new instance of Visual Studio, </span></span><span style=""><span style=""><span style="">open a new HTML page to edit.<b style="">
</b></span></span></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><span style=""><span style=""><img src="/site/view/file/53304/1/image.png" alt="" width="576" height="141" align="middle">
</span></span></span><span style=""><span style=""><b style=""><span style=""></span></b></span></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style=""><span style=""><span style="">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Click <b style="">Tool=&gt; Add item into VS Toolbox</b>,<b style="">
</b>and then you can view the new tab and items in the Toolbox.</span> </span></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><span style=""><b style=""><span style=""></span></b></span></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><span style=""><span style=""><img src="/site/view/file/53305/1/image.png" alt="" width="576" height="83" align="middle">
</span></span></span><span style=""><span style=""><b style=""><span style=""></span></b></span></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><span style=""><span style=""><img src="/site/view/file/53306/1/image.png" alt="" width="253" height="187" align="middle">
</span></span></span><span style=""><span style=""><b style=""><span style=""></span></b></span></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><span style=""><span style=""></span></span></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style=""><span style=""><span style="">6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Drag the items in Toolbox and drop them to the html page, you will see the following 2 new button elements.
</span></span></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><span style=""><span style=""><img src="/site/view/file/53307/1/image.png" alt="" width="576" height="161" align="middle">
</span></span></span><span style=""><span style=""><span style=""></span></span></span></p>
<p class="MsoListParagraphCxSpLast"><span style=""><span style=""><span style=""></span></span></span></p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoListParagraphCxSpFirst" style=""><b style=""><span style=""><span style="">A.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">Background </span></b></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">In VS automation model, it provides functions:
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:90.0pt"><span style=""><span style=""><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>i.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Add a tab to the Toolbox (Add method). </span>
</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:90.0pt"><span style=""><span style=""><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>ii.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Activate a tab in the Toolbox (Activate method).
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:90.0pt"><span style=""><span style=""><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>iii.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Delete a tab from the Toolbox (Delete method).
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:90.0pt"><span style=""><span style=""><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>iv.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Add an item to the Toolbox (Add method). </span>
</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:90.0pt"><span style=""><span style=""><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>v.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Select an item in the Toolbox (Select method).
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:90.0pt"><span style=""><span style=""><span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>vi.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Delete an item from a tab in the Toolbox (Delete method).
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:90.0pt"><span style="">For more detail, please refer to:</span><span style="">
<a href="http://msdn.microsoft.com/en-us/library/6xs853ft.aspx">How to: Control the Toolbox</a>
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">VS Toolbox service provides richer access to toolbox functionality.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style="">See
<a href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop.ivstoolbox.aspx">
IVsToolbox Interface</a> </span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><b style=""><span style=""><span style="">B.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">Creation </span></b></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Create Visual Studio Add-in project from File -&gt; New -&gt; Project -&gt; Other Project Types -&gt; Extensibility -&gt; Visual Studio Add-In</span><span style="">.</span><span style="">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">When you create an add-in by using the Add-In Wizard and select the option to display it as a command, the command is on the Tools menu by default.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">In Connect class, add two methods:AddItemByDTE and AddItemByVsToolboxService with following code:
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Add ConvertToClipboardFormat method. Most of the method code is referenced from
<a href="http://blogs.msdn.com/jmstall/pages/sample-code-html-clipboard.aspx">http://blogs.msdn.com/jmstall/pages/sample-code-html-clipboard.aspx</a></span><span style="">.
</span><span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
/// This method adds a Toolbox item by DTE automation model
/// &lt;/summary&gt;
private void AddItemByDTE()
{
    // Get tabs from automation model
    ToolBoxTabs tabs = _applicationObject.ToolWindows.ToolBox.ToolBoxTabs;
    IEnumerator e = tabs.GetEnumerator();


    ToolBoxTab tab = null;
    while (e.MoveNext())
    {
        ToolBoxTab ct = e.Current as ToolBoxTab;
        if (ct.Name == &quot;CustomTab&quot;)
        {
            tab = ct;
            break;
        }
    }


    // If there is no CustomTab, add one
    if (tab == null)
        tab = tabs.Add(&quot;CustomTab&quot;);


    // Add Toolbox Item, but we can't customize other information for 
    // Toolbox item like icon and transparency.
    tab.ToolBoxItems.Add(
        &quot;DTE Added HTML Content&quot;, 
        &quot;&lt;input id=\&quot;Button1\&quot; type=\&quot;button\&quot; value=\&quot;button\&quot; /&gt;&quot;, 
        vsToolBoxItemFormat.vsToolBoxItemFormatHTML);
}


/// &lt;summary&gt;
/// This method adds a Toolbox item by VS Toolbox service.
/// This way provides more flexibilities than DTE way.
/// &lt;/summary&gt;
private void AddItemByVsToolboxService()
{
    // Get shell service provider.
    ServiceProvider sp =
        new ServiceProvider((Microsoft.VisualStudio.OLE.Interop.IServiceProvider)_applicationObject);


    // Get the IVsToolbox interface.
    IVsToolbox tbs = sp.GetService(typeof(SVsToolbox)) as IVsToolbox;


    // Toolbox Item Info data 
    TBXITEMINFO[] itemInfo = new TBXITEMINFO[1];
    Bitmap bitmap =
        new Bitmap(this.GetType().Assembly.GetManifestResourceStream(&quot;CSVSAddInToolboxItem.Demo.bmp&quot;));
    itemInfo[0].bstrText = &quot;Service Added HTML Content&quot;;
    itemInfo[0].hBmp = bitmap.GetHbitmap(); // Specify the bitmap.
    itemInfo[0].dwFlags = (uint)__TBXITEMINFOFLAGS.TBXIF_DONTPERSIST;


    // OleDataObject to host toolbox data
    OleDataObject tbItem = new OleDataObject();
    tbItem.SetText(
        ConvertToClipboardFormat(&quot;&lt;input id=\&quot;Button1\&quot; type=\&quot;button\&quot; value=\&quot;button\&quot; /&gt;&quot;, null, null),
        TextDataFormat.Html);


    // Add a new toolbox item to MyCustomTab tab
    tbs.AddItem(tbItem, itemInfo, &quot;CustomTab&quot;);
}

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
/// This method adds a Toolbox item by DTE automation model
/// &lt;/summary&gt;
private void AddItemByDTE()
{
    // Get tabs from automation model
    ToolBoxTabs tabs = _applicationObject.ToolWindows.ToolBox.ToolBoxTabs;
    IEnumerator e = tabs.GetEnumerator();


    ToolBoxTab tab = null;
    while (e.MoveNext())
    {
        ToolBoxTab ct = e.Current as ToolBoxTab;
        if (ct.Name == &quot;CustomTab&quot;)
        {
            tab = ct;
            break;
        }
    }


    // If there is no CustomTab, add one
    if (tab == null)
        tab = tabs.Add(&quot;CustomTab&quot;);


    // Add Toolbox Item, but we can't customize other information for 
    // Toolbox item like icon and transparency.
    tab.ToolBoxItems.Add(
        &quot;DTE Added HTML Content&quot;, 
        &quot;&lt;input id=\&quot;Button1\&quot; type=\&quot;button\&quot; value=\&quot;button\&quot; /&gt;&quot;, 
        vsToolBoxItemFormat.vsToolBoxItemFormatHTML);
}


/// &lt;summary&gt;
/// This method adds a Toolbox item by VS Toolbox service.
/// This way provides more flexibilities than DTE way.
/// &lt;/summary&gt;
private void AddItemByVsToolboxService()
{
    // Get shell service provider.
    ServiceProvider sp =
        new ServiceProvider((Microsoft.VisualStudio.OLE.Interop.IServiceProvider)_applicationObject);


    // Get the IVsToolbox interface.
    IVsToolbox tbs = sp.GetService(typeof(SVsToolbox)) as IVsToolbox;


    // Toolbox Item Info data 
    TBXITEMINFO[] itemInfo = new TBXITEMINFO[1];
    Bitmap bitmap =
        new Bitmap(this.GetType().Assembly.GetManifestResourceStream(&quot;CSVSAddInToolboxItem.Demo.bmp&quot;));
    itemInfo[0].bstrText = &quot;Service Added HTML Content&quot;;
    itemInfo[0].hBmp = bitmap.GetHbitmap(); // Specify the bitmap.
    itemInfo[0].dwFlags = (uint)__TBXITEMINFOFLAGS.TBXIF_DONTPERSIST;


    // OleDataObject to host toolbox data
    OleDataObject tbItem = new OleDataObject();
    tbItem.SetText(
        ConvertToClipboardFormat(&quot;&lt;input id=\&quot;Button1\&quot; type=\&quot;button\&quot; value=\&quot;button\&quot; /&gt;&quot;, null, null),
        TextDataFormat.Html);


    // Add a new toolbox item to MyCustomTab tab
    tbs.AddItem(tbItem, itemInfo, &quot;CustomTab&quot;);
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""><span style="">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">In the Exec method, invoke both AddItemByDTE and AddItemByVsToolboxService methods</span><span style="">.</span><span style="">
</span></p>
<h2>More Information</h2>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop.ivstoolbox_members.aspx">IVsToolbox Members</a></span><span style="">
</span></p>
<p class="MsoNormal"><span style=""><a href="http://code.msdn.microsoft.com/EditorwithToolbox">VSSDK IDE Sample: Editor with Toolbox</a></span><span style="">
</span></p>
<p class="MsoNormal"><span style=""><a href="http://blogs.msdn.com/dr._ex/archive/2004/03/23/94991.aspx">How do I manipulate ToolBox Items?</a></span><span style="">
</span></p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/bb166364.aspx">Toolbox (Visual Studio SDK)</a></span><span style="">
</span></p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/6xs853ft.aspx">How to: Control the Toolbox</a></span><span style="">
</span></p>
<p class="MsoNormal"><span style=""><a href="http://blogs.msdn.com/jmstall/pages/sample-code-html-clipboard.aspx">Sample code for copying Html to Clipboard</a>
</span></p>
<p class="MsoNormal"><span style=""></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

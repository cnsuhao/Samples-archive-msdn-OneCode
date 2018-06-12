# Load all Toolbox items in an Assembly in VSPackage (CSVSPackageToolbox)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* VSX
## Topics
* VSPackage
* Load Visual Studio ToolboxItems
## IsPublished
* True
## ModifiedDate
* 2012-03-01 11:46:56
## Description

<h1>Load all Toolbox items in an Assembly in VSPackage (<span class="SpellE">CSVSPackageToolbox</span>)</h1>
<h2>Introduction</h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">VSPackages are software modules that make up and extend the Visual Studio integrated development environment (IDE) by providing UI elements, services,
 projects, editors, and designers. VSPackages are the principal architectural unit of Visual Studio, and are the unit of deployment, licensing, and security also. Visual Studio itself is written mostly as a collection of VSPackages.
</span></h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">This sample demonstrates how to use the Visual Studio Integration Package Wizard to create a simple VSPackage and automatically load all the
<span class="SpellE">ToolboxItem</span> items provided by its own assembly.</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
</span></h2>
<h2>Building the Sample</h2>
<h2><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">VS 20</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">08</span><span style="font-size:11.0pt; line-height:115%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-weight:normal">
 SP1 SDK must be installed on the machine. You can download it from: </span></h2>
<p class="MsoNormal"><span lang="EN" style=""><a href="http://www.microsoft.com/download/en/details.aspx?id=21827">Visual Studio 2008 SDK 1.1</a></span><span lang="EN" style="">
</span></p>
<p class="MsoNormal"><span lang="EN" style="">The Package Load Failure Dialog occurs because there is no PLK (Package Load Key) specified in this package. To obtain a PLK, please to go to Website:
<a href="http://msdn.microsoft.com/en-us/vstudio/cc655795">Generate Load Keys</a>. More info:
<a href="http://msdn.microsoft.com/en-us/library/bb165395.aspx">How to: Obtain a PLK for a VSPackage</a>
</span></p>
<p class="MsoNormal">Set the Start Action and Start Options of Debug.</p>
<p class="MsoNormal">Start Action: <u>C:\Program Files\Microsoft Visual Studio </u>
<u><span style="">9</span>.0\Common7\IDE\devenv.exe</u> (32bit OS) or <u>C:\Program Files (x86)\Microsoft Visual Studio
</u><u><span style="">9</span>.0\Common7\IDE\devenv.exe</u> (64bit OS)<u> </u></p>
<p class="MsoNormal">Start Option: <u>/<span class="SpellE">ranu</span> /<span class="SpellE">rootsuffix</span>
<span class="SpellE">Exp</span></u></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53264/1/image.png" alt="" width="576" height="404" align="middle">
</span></p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press <b style="">F5</b> to debug this project.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>In the new instance of Visual Studio, <span style="">create a new Windows Forms Application.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Open the designer of the Form1<span class="GramE">,
<span style="">&nbsp;</span>you</span> will find the Tab <span class="SpellE"><b style="">LoadToolboxMemberDemo</b></span><b style="">
</b>and<b style=""> </b>Item<b style=""> <span class="SpellE">ToolboxMemberDemo</span></b> in
<span class="SpellE">ToolBox</span>.</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">You can drag the Item<b style="">
<span class="SpellE">ToolboxMemberDemo</span></b>, and drop it<b style=""> </b>
to the UI of<b style=""> </b>Form1.</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/53265/1/image.png" alt="" width="780" height="302" align="middle">
</span></p>
<p class="MsoListParagraphCxSpLast"></p>
<h2>Using the Code</h2>
<p class="MsoListParagraphCxSpFirst" style=""><b style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style="">Create a VS Package Project. </b></p>
<p class="MsoListParagraphCxSpMiddle">Use Visual Studio Integration Package Wizard to create a simple VSPackage project. You can follow the steps in
<a href="http://msdn.microsoft.com/en-us/library/cc138589.aspx">Walkthrough: Creating a VSPackage
</a><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><b style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">Creating a Toolbox Control</span>.
</b></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">a.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Right-Click the Project and select &quot;Add&quot;-&gt; &quot;Add new Item&quot;, then select
<span class="SpellE"><b style="">UserControl</b></span>, type name &quot;<span class="SpellE"><b style="">MyControl</b></span>&quot;</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""><span style="">b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>In the <span class="SpellE"><b style="">UserControl</b></span> designer, add a
<span class="SpellE"><b style="">TextBox</b></span> and a <span class="GramE">
<b style="">Button</b>,</span> double-click the Button, add the click event handler.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private void button1_Click(object sender, EventArgs e)
{
    OpenFileDialog opg = new OpenFileDialog();
    opg.Multiselect = false;
    if (opg.ShowDialog() == DialogResult.OK)
        this.textBox1.Text = opg.FileName;
}

</pre>
<pre id="codePreview" class="csharp">
private void button1_Click(object sender, EventArgs e)
{
    OpenFileDialog opg = new OpenFileDialog();
    opg.Multiselect = false;
    if (opg.ShowDialog() == DialogResult.OK)
        this.textBox1.Text = opg.FileName;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">c.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Add attributes to the file to enable the VSPackage to query the supplied
<span class="SpellE">ToolboxItem</span> class.</span></p>
<p class="MsoListParagraphCxSpLast"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Set the display name and custom bitmap to use for this item.
// The build action for the bitmap must be &quot;Embedded Resource&quot;.
[DisplayName(&quot;ToolboxMemberDemo&quot;)]
[Description(&quot;Custom toolbox item from package LoadToolboxMembers.&quot;)]
[ToolboxItem(true)]
[ToolboxBitmap(typeof(MyControl), &quot;MyControl.bmp&quot;)]
public partial class MyControl : UserControl
{
    ......
}

</pre>
<pre id="codePreview" class="csharp">
// Set the display name and custom bitmap to use for this item.
// The build action for the bitmap must be &quot;Embedded Resource&quot;.
[DisplayName(&quot;ToolboxMemberDemo&quot;)]
[Description(&quot;Custom toolbox item from package LoadToolboxMembers.&quot;)]
[ToolboxItem(true)]
[ToolboxBitmap(typeof(MyControl), &quot;MyControl.bmp&quot;)]
public partial class MyControl : UserControl
{
    ......
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">d.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Right-Click the Project and select &quot;Add&quot;-&gt; &quot;Add new Item&quot;, then select
<span style="">&nbsp;</span><b style="">Bitmap</b> add a 16*16 bitmap with the name MyControl.bmp</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"></p>
<p class="MsoListParagraphCxSpMiddle" style=""><b style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">Modifying the VSPackage Implementation</span>.
</b></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""><span style="">a.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Register the VSPackage as a <span class="SpellE">ToolboxItem</span> class by adding an instance of
<span class="SpellE"><b style="">ProvideToolboxItemsAttribute</b></span><span style="">.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
[ProvideToolboxItems(1)]
public sealed class CSVSToolboxPackage : Package
{
    ......
}

</pre>
<pre id="codePreview" class="csharp">
[ProvideToolboxItems(1)]
public sealed class CSVSToolboxPackage : Package
{
    ......
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""><span style="">b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Add the following two new private fields to the <span class="SpellE">
CSVSToolboxPackage</span> class<span style="">.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// List for the toolbox items provided by this package.
private ArrayList ToolboxItemList;


// Name for the Toolbox category tab for the package's toolbox items.
private string CategoryTab = &quot;LoadToolboxMemberDemo&quot;;

</pre>
<pre id="codePreview" class="csharp">
// List for the toolbox items provided by this package.
private ArrayList ToolboxItemList;


// Name for the Toolbox category tab for the package's toolbox items.
private string CategoryTab = &quot;LoadToolboxMemberDemo&quot;;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""><span style="">c.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Modify the Initialize method in <span class="SpellE">CSVSToolboxPackage</span> to do the following
<span style="">&nbsp;</span>things:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Add our command handlers for menu (commands must exist in the .vsct file)
OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
if ( null != mcs )
{
    // Create the command for the menu item.
    CommandID menuCommandID = new CommandID(GuidList.guidCSVSToolboxCmdSet, 
    (int)PkgCmdIDList.cmdidInitializeToolbox);
    MenuCommand menuItem = new MenuCommand(MenuItemCallback, menuCommandID );
    mcs.AddCommand( menuItem );


    // Subscribe to the toolbox intitialized and upgraded events.
    ToolboxInitialized &#43;= new EventHandler(OnRefreshToolbox);
    ToolboxUpgraded &#43;= new EventHandler(OnRefreshToolbox);
}


// Use reflection to get the toolbox items provided in this assembly.
ToolboxItemList = CreateItemList(this.GetType().Assembly);
if (null == ToolboxItemList)
{
    // Unable to generate the list.
    // Add error handling code here.
}

</pre>
<pre id="codePreview" class="csharp">
// Add our command handlers for menu (commands must exist in the .vsct file)
OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
if ( null != mcs )
{
    // Create the command for the menu item.
    CommandID menuCommandID = new CommandID(GuidList.guidCSVSToolboxCmdSet, 
    (int)PkgCmdIDList.cmdidInitializeToolbox);
    MenuCommand menuItem = new MenuCommand(MenuItemCallback, menuCommandID );
    mcs.AddCommand( menuItem );


    // Subscribe to the toolbox intitialized and upgraded events.
    ToolboxInitialized &#43;= new EventHandler(OnRefreshToolbox);
    ToolboxUpgraded &#43;= new EventHandler(OnRefreshToolbox);
}


// Use reflection to get the toolbox items provided in this assembly.
ToolboxItemList = CreateItemList(this.GetType().Assembly);
if (null == ToolboxItemList)
{
    // Unable to generate the list.
    // Add error handling code here.
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""><span style="">d.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Add two methods, <span class="SpellE"><b style="">CreateItemList</b></span> and
<span class="SpellE"><b style="">CreateToolboxItem</b></span>, to construct, by using metadata, instances of the
<span class="SpellE">ToolboxItem</span> objects that are available in the <span class="SpellE">
CSVSToolbox</span> assembly, as follows:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Scan for toolbox items in the assembly and return the list of
// toolbox items.
private ArrayList CreateItemList(Assembly assembly)
{
    ArrayList list = new ArrayList();
    foreach (Type possibleItem in assembly.GetTypes())
    {
        ToolboxItem item = CreateToolboxItem(possibleItem);
        if (item != null)
        {
            list.Add(item);
        }
    }
    return list;
}


// If the type represents a toolbox item, return an instance of the type;
// otherwise, return null.
private ToolboxItem CreateToolboxItem(Type possibleItem)
{
    // A toolbox item must implement IComponent and must not be abstract.
    if (!typeof(IComponent).IsAssignableFrom(possibleItem) ||
        possibleItem.IsAbstract)
    {
        return null;
    }


    // A toolbox item must have a constructor that takes a parameter of
    // type Type or a constructor that takes no parameters.
    if (null == possibleItem.GetConstructor(new Type[] { typeof(Type) }) &&
        null == possibleItem.GetConstructor(new Type[0]))
    {
        return null;
    }


    ToolboxItem item = null;


    // Check the custom attributes of the candidate type and attempt to
    // create an instance of the toolbox item type.
    AttributeCollection attribs =
        TypeDescriptor.GetAttributes(possibleItem);
    ToolboxItemAttribute tba =
        attribs[typeof(ToolboxItemAttribute)] as ToolboxItemAttribute;
    if (tba != null && !tba.Equals(ToolboxItemAttribute.None))
    {
        if (!tba.IsDefaultAttribute())
        {
            // This type represents a custom toolbox item implementation.
            Type itemType = tba.ToolboxItemType;
            ConstructorInfo ctor =
                itemType.GetConstructor(new Type[] { typeof(Type) });
            if (ctor != null && itemType != null)
            {
                item = (ToolboxItem)ctor.Invoke(new object[] { possibleItem });
            }
            else
            {
                ctor = itemType.GetConstructor(new Type[0]);
                if (ctor != null)
                {
                    item = (ToolboxItem)ctor.Invoke(new object[0]);
                    item.Initialize(possibleItem);
                }
            }
        }
        else
        {
            // This type represents a default toolbox item.
            item = new ToolboxItem(possibleItem);
        }
    }
    if (item == null)
    {
        throw new ApplicationException(&quot;Unable to create a ToolboxItem &quot; &#43;
            &quot;object from &quot; &#43; possibleItem.FullName &#43; &quot;.&quot;);
    }


    // Update the display name of the toolbox item and add the item to
    // the list.
    DisplayNameAttribute displayName =
        attribs[typeof(DisplayNameAttribute)] as DisplayNameAttribute;
    if (displayName != null && !displayName.IsDefaultAttribute())
    {
        item.DisplayName = displayName.DisplayName;
    }


    return item;
}

</pre>
<pre id="codePreview" class="csharp">
// Scan for toolbox items in the assembly and return the list of
// toolbox items.
private ArrayList CreateItemList(Assembly assembly)
{
    ArrayList list = new ArrayList();
    foreach (Type possibleItem in assembly.GetTypes())
    {
        ToolboxItem item = CreateToolboxItem(possibleItem);
        if (item != null)
        {
            list.Add(item);
        }
    }
    return list;
}


// If the type represents a toolbox item, return an instance of the type;
// otherwise, return null.
private ToolboxItem CreateToolboxItem(Type possibleItem)
{
    // A toolbox item must implement IComponent and must not be abstract.
    if (!typeof(IComponent).IsAssignableFrom(possibleItem) ||
        possibleItem.IsAbstract)
    {
        return null;
    }


    // A toolbox item must have a constructor that takes a parameter of
    // type Type or a constructor that takes no parameters.
    if (null == possibleItem.GetConstructor(new Type[] { typeof(Type) }) &&
        null == possibleItem.GetConstructor(new Type[0]))
    {
        return null;
    }


    ToolboxItem item = null;


    // Check the custom attributes of the candidate type and attempt to
    // create an instance of the toolbox item type.
    AttributeCollection attribs =
        TypeDescriptor.GetAttributes(possibleItem);
    ToolboxItemAttribute tba =
        attribs[typeof(ToolboxItemAttribute)] as ToolboxItemAttribute;
    if (tba != null && !tba.Equals(ToolboxItemAttribute.None))
    {
        if (!tba.IsDefaultAttribute())
        {
            // This type represents a custom toolbox item implementation.
            Type itemType = tba.ToolboxItemType;
            ConstructorInfo ctor =
                itemType.GetConstructor(new Type[] { typeof(Type) });
            if (ctor != null && itemType != null)
            {
                item = (ToolboxItem)ctor.Invoke(new object[] { possibleItem });
            }
            else
            {
                ctor = itemType.GetConstructor(new Type[0]);
                if (ctor != null)
                {
                    item = (ToolboxItem)ctor.Invoke(new object[0]);
                    item.Initialize(possibleItem);
                }
            }
        }
        else
        {
            // This type represents a default toolbox item.
            item = new ToolboxItem(possibleItem);
        }
    }
    if (item == null)
    {
        throw new ApplicationException(&quot;Unable to create a ToolboxItem &quot; &#43;
            &quot;object from &quot; &#43; possibleItem.FullName &#43; &quot;.&quot;);
    }


    // Update the display name of the toolbox item and add the item to
    // the list.
    DisplayNameAttribute displayName =
        attribs[typeof(DisplayNameAttribute)] as DisplayNameAttribute;
    if (displayName != null && !displayName.IsDefaultAttribute())
    {
        item.DisplayName = displayName.DisplayName;
    }


    return item;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""><span style="">e.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Implement the <span class="SpellE"><b style="">OnRefreshToolbox</b></span> method to handle the
<span class="SpellE"><b style="">ToolboxInitialized</b></span> and <span class="SpellE">
<b style="">ToolboxUpgraded</b></span> events.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
void OnRefreshToolbox(object sender, EventArgs e)
{
    // Add new instances of all ToolboxItems contained in ToolboxItemList.
    IToolboxService service =
        GetService(typeof(IToolboxService)) as IToolboxService;
    IVsToolbox toolbox = GetService(typeof(IVsToolbox)) as IVsToolbox;


    //Remove target tab and all controls under it.
    foreach (ToolboxItem oldItem in service.GetToolboxItems(CategoryTab))
    {
        service.RemoveToolboxItem(oldItem);
    }
    toolbox.RemoveTab(CategoryTab);


    foreach (ToolboxItem itemFromList in ToolboxItemList)
    {
        service.AddToolboxItem(itemFromList, CategoryTab);
    }
    service.SelectedCategory = CategoryTab;


    service.Refresh();
}

</pre>
<pre id="codePreview" class="csharp">
void OnRefreshToolbox(object sender, EventArgs e)
{
    // Add new instances of all ToolboxItems contained in ToolboxItemList.
    IToolboxService service =
        GetService(typeof(IToolboxService)) as IToolboxService;
    IVsToolbox toolbox = GetService(typeof(IVsToolbox)) as IVsToolbox;


    //Remove target tab and all controls under it.
    foreach (ToolboxItem oldItem in service.GetToolboxItems(CategoryTab))
    {
        service.RemoveToolboxItem(oldItem);
    }
    toolbox.RemoveTab(CategoryTab);


    foreach (ToolboxItem itemFromList in ToolboxItemList)
    {
        service.AddToolboxItem(itemFromList, CategoryTab);
    }
    service.SelectedCategory = CategoryTab;


    service.Refresh();
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""><span style="">f.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Change the menu item command handler method, <span class="SpellE">
MenuItemCallBack</span>, as follows.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private void MenuItemCallback(object sender, EventArgs e)
{
    IVsPackage pkg = GetService(typeof(Package)) as Package;
    pkg.ResetDefaults((uint)__VSPKGRESETFLAGS.PKGRF_TOOLBOXITEMS);
}

</pre>
<pre id="codePreview" class="csharp">
private void MenuItemCallback(object sender, EventArgs e)
{
    IVsPackage pkg = GetService(typeof(Package)) as Package;
    pkg.ResetDefaults((uint)__VSPKGRESETFLAGS.PKGRF_TOOLBOXITEMS);
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:72.0pt"></p>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/bb164725.aspx">How to: Create VSPackages (C# and Visual Basic)</a><span style="">
</span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/bb166544.aspx">How to: Register a VSPackage (C#)</a><span style="">
</span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/cc138589.aspx">VSPackage Tutorial 1: How to Create a VSPackage</a><span style="">
</span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/bb165325.aspx">Managing the Toolbox</a><span style="">
</span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/bb166364.aspx">Toolbox (Visual Studio SDK)</a><span style="">
</span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/bb166364.aspx">Walkthrough:
<span class="SpellE">Autoloading</span> Toolbox Items</a><span style=""> </span>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

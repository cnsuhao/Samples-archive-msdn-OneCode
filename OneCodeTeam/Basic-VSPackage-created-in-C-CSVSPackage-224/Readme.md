# Basic VSPackage created in C# (CSVSPackage)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* VSX
## Topics
* Visual Studio Integration Package
* VSPackage
## IsPublished
* True
## ModifiedDate
* 2012-03-01 11:50:12
## Description

<h1>Basic VSPackage created in C# (<span class="SpellE">CSVSPackage</span>)<span style="">
</span></h1>
<h2>Introduction</h2>
<p class="MsoNormal">VSPackages are software modules that make up and extend the Visual Studio integrated development environment (IDE) by providing UI elements, services, projects, editors, and designers. VSPackages are the principal architectural unit of
 Visual Studio, and are the unit of deployment, licensing, and security also. Visual Studio itself is written mostly as a collection of VSPackages.</p>
<p class="MsoNormal">This sample demonstrates how to use the Visual Studio Integration Package Wizard to create a simple VSPackage<span style="">.
</span></p>
<h2>Building the Sample</h2>
<p class="MsoNormal">VS 20<span style="">08</span> SP1 SDK must be installed on the machine. You can download it from:
</p>
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
<p class="MsoNormal"><span style=""><img src="/site/view/file/53295/1/image.png" alt="" width="576" height="404" align="middle">
</span></p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press <b style="">F5</b> to debug this project.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>In the new instance of Visual Studio, <span style="">click Tools=&gt;<span class="SpellE">CSVSPackageDemo</span>, and you will see a dialog.</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/53296/1/image.png" alt="" width="576" height="133" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpLast"><span style=""><img src="/site/view/file/53297/1/image.png" alt="" width="475" height="199" align="middle">
</span><span style=""></span></p>
<h2>Using the Code</h2>
<p class="MsoListParagraphCxSpFirst" style=""><b style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style="">Create a VS Package Project. </b></p>
<p class="MsoListParagraphCxSpMiddle">Use Visual Studio Integration Package Wizard to create a simple VSPackage project. You can follow the steps in
<a href="http://msdn.microsoft.com/en-us/library/cc138589.aspx">Walkthrough: Creating a VSPackage
</a><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><b style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">Customize the Menu Command Handler</span>.
</b></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span style=""><span style="">a.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>In Solution Explorer, open <span class="SpellE">CSVSPackagePackage.cs</span>.
</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:108.0pt"><span style=""><span style="">b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Find the <span class="SpellE">CSVSPackagePackage</span> class.</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:108.0pt"><span style=""><span style="">c.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Find the code for the menu handler, which is implemented by the
<span class="SpellE">MenuItemCallback</span><span style=""> </span>method. This method executes when the user click the menu it<span style="">em</span>. By default, it shows a message box.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private void MenuItemCallback(object sender, EventArgs e)
{
    // Show a Message Box to prove we were here
    IVsUIShell uiShell = (IVsUIShell)GetService(typeof(SVsUIShell));
    Guid clsid = Guid.Empty;
    int result;
    Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(uiShell.ShowMessageBox(
               0,
               ref clsid,
               &quot;CSVSPackageDemo&quot;,
               string.Format(CultureInfo.CurrentCulture, 
                             &quot;Inside {0}.MenuItemCallback()&quot;, this.ToString()),
               string.Empty,
               0,
               OLEMSGBUTTON.OLEMSGBUTTON_OK,
               OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST,
               OLEMSGICON.OLEMSGICON_INFO,
               0,        // false
               out result));
}

</pre>
<pre id="codePreview" class="csharp">
private void MenuItemCallback(object sender, EventArgs e)
{
    // Show a Message Box to prove we were here
    IVsUIShell uiShell = (IVsUIShell)GetService(typeof(SVsUIShell));
    Guid clsid = Guid.Empty;
    int result;
    Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(uiShell.ShowMessageBox(
               0,
               ref clsid,
               &quot;CSVSPackageDemo&quot;,
               string.Format(CultureInfo.CurrentCulture, 
                             &quot;Inside {0}.MenuItemCallback()&quot;, this.ToString()),
               string.Empty,
               0,
               OLEMSGBUTTON.OLEMSGBUTTON_OK,
               OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST,
               OLEMSGICON.OLEMSGICON_INFO,
               0,        // false
               out result));
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:108.0pt"></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"></p>
<p class="MsoListParagraphCxSpMiddle" style=""><b style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">Add a Keyboard Shortcut.</span>
</b></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">a.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>In Solution Explorer, open <span class="SpellE">CSVSPackage.vsct</span>.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt">VSCT file stands for Visual Studio Command Table. This is an XML based file that describes the layout and appearance of command items for a VSPackage. Command items include buttons, combo boxes,
 menus, toolbars, and groups of command items.<span style=""> </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Find the end of the Commands element, which is indicated by the &lt;/Commands&gt; tag.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><span style=""><span style="">c.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Add the following lines between the &lt;/Commands&gt; tag and the &lt;Symbols&gt; tag.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;KeyBindings&gt;
    &lt;KeyBinding guid=&quot;guidCSVSPackageCmdSet&quot; 
        id=&quot;cmdidCSVSPackageDemo&quot;  
        editor=&quot;guidVSStd97&quot; 
        key1=&quot;N&quot; 
        mod1=&quot;Control Shift&quot;/&gt;
&lt;/KeyBindings&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;KeyBindings&gt;
    &lt;KeyBinding guid=&quot;guidCSVSPackageCmdSet&quot; 
        id=&quot;cmdidCSVSPackageDemo&quot;  
        editor=&quot;guidVSStd97&quot; 
        key1=&quot;N&quot; 
        mod1=&quot;Control Shift&quot;/&gt;
&lt;/KeyBindings&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:72.0pt"></p>
<p class="MsoListParagraphCxSpMiddle" style=""><b style=""><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">Registration.</span> </b></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">a.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE">PackageRegistration</span>:</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt">The regpkg.exe utility scans types for this attribute to recognize that the type should be registered as a package. Adding this attribute to our class, regpkg.exe will handle it as a package
 and looks for other attributes to register the class according to our intention. In our example this attribute sets the<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span class="SpellE">UseManagedResourcesOnly</span> flag to tell that all resources used by our package are<span style="">&nbsp;&nbsp;
</span>described in the managed package and not in a satellite .<span class="SpellE">dll</span>.<span style="">&nbsp;
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><a href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.packageregistrationattribute.aspx">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.packageregistrationattribute.aspx</a><span style="">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE">DefaultRegistryRoot</span>:</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt">This attribute specifie<span style="">s</span> the default registration root for the package. The default value registers the package to in the Experimental hive.<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><a href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.defaultregistryrootattribute.aspx">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.defaultregistryrootattribute.aspx</a><span style="">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">c.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE">InstalledProductRegistration</span>:</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt">This attribute is responsible to provide information to be displayed by the
<span class="SpellE">Help|About</span> function in the VS IDE. <span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><a href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.installedproductregistrationattribute.aspx">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.installedproductregistrationattribute.aspx</a><span style="">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">d.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE">ProvideLoadKey</span>:</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style="">This</span> attribute specifies that the VSPackage has a load key embedded in it and provides some general information about the
<span class="SpellE">pacakge</span>. Each VS component should be signed with a so-called package load key (PLK) that is used by Visual Studio to check if the package is the one it says about itself it is.
<span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><a href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.provideloadkeyattribute.aspx">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.provideloadkeyattribute.aspx</a><span style="">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">e.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE">ProvideMenuResource</span>:</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt">This attribute tells Visual Studio that the package has some menus inside.<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><a href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.providemenuresourceattribute.aspx">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.providemenuresourceattribute.aspx</a><span style="">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style="">&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style=""><span style="">f.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span class="SpellE">Guid</span>:</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt">This attribute defines the GUID of our package. This GUID is the unique identifier of our package. This is used for the COM class registration, referencing to our package within the IDE, and
 so on.<span style=""> </span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:72.0pt"><a href="http://msdn.microsoft.com/en-us/library/system.runtime.interopservices.guidattribute.aspx">http://msdn.microsoft.com/en-us/library/system.runtime.interopservices.guidattribute.aspx</a><span style="">
</span></p>
<h2>More Information<span style=""> </span></h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/bb164725.aspx">How to: Create VSPackages (C# and Visual Basic)</a><span style="">
</span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/bb166544.aspx">How to: Register a VSPackage (C#)</a><span style="">
</span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/bb165769.aspx">How to: Brand a VSPackage (C#)</a><span style="">
</span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/cc138589.aspx">VSPackage Tutorial 1: How to Create a VSPackage</a><span style="">
</span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/bb166366.aspx">Designing XML Command Table (.<span class="SpellE">Vsct</span>) Files</a><span style="">
</span></p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/bb165085.aspx"><span class="SpellE">KeyBindings</span> Element</a><span style="">
</span></p>
<p class="MsoNormal"><a href="http://dotneteers.net/blogs/divedeeper/archive/2008/01/03/LernVSXNowPart2.aspx">Creating an empty package</a><span style="">
</span></p>
<p class="MsoNormal"><a href="http://dotneteers.net/blogs/divedeeper/archive/2008/01/06/LearnVSXNowPart3.aspx">Creating a package with a simple command</a><span style="">
</span></p>
<p class="MsoNormal"><a href="http://dotneteers.net/blogs/divedeeper/archive/2008/02/22/LearnVSXNowPart13.aspx">Menus and
<span class="SpellE">comands</span> in VS IDE</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

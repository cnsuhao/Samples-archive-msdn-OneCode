# Create a VSX Project SubType (CSVSXProjectSubType)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* VSX
## Topics
* Project SubType
* ProjectFlavor
## IsPublished
* True
## ModifiedDate
* 2011-08-08 07:23:57
## Description

<p style="font-family:Courier New"></p>
<h2>Visual Studio Package Project: CSVSXProjectSubType </h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
A Project SubType, or called ProjectFlavor, let you customize or flavor the <br>
behavior of the project systems of Visual Studio. Customizations include <br>
1. Saving additional data in the project file.<br>
2. Adding or filtering items in the Add New Item dialog box.<br>
3. Controlling how assemblies are debugged and deployed.<br>
4. Extending the project Property Pages dialog box.<br>
<br>
In this sample, we demonstrate how to create a Project SubType with following <br>
features:<br>
1. Removing the Services Property Page.<br>
2. Adding a custom Property Page.<br>
3. Saving the data on the custom Property Page to project file.<br>
<br>
For more detailed information about Project SubTypes, please check <br>
<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/bb166488.aspx">http://msdn.microsoft.com/en-us/library/bb166488.aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb166488.aspx">http://msdn.microsoft.com/en-us/library/bb166488.aspx</a><br>
</p>
<h3>How the Project SubTypes Work:</h3>
<p style="font-family:Courier New"><br>
First, we have to register our CustomPropertyPageProjectFactory to Visual Studio.<br>
<br>
Second, we need a Project Template, which is created by the CSVSXProjectSubTypeTemplate<br>
project.<br>
<br>
The ProjectTemplate.csproj in CSVSXProjectSubTypeTemplate contains following script
<br>
&nbsp; &nbsp;&lt;ProjectTypeGuids&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;{3C53C28F-DC44-46B0-8B85-0C96B85B2042};<br>
&nbsp; &nbsp; &nbsp; &nbsp;{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}<br>
&nbsp; &nbsp;&lt;/ProjectTypeGuids&gt;<br>
<br>
&nbsp; &nbsp;{3C53C28F-DC44-46B0-8B85-0C96B85B2042} is the Guid of the CustomPropertyPageProjectFactory.<br>
&nbsp; &nbsp;{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC} means CSharp project. <br>
<br>
At last, When Visual Studio is creating or opening a CSharp project with above ProjectTypeGuids,<br>
1. The environment calls the base project (CSharp Project)'s CreateProject, and while the
<br>
&nbsp; project parses its project file it discovers that the aggregate project type GUIDs list<br>
&nbsp; is not null. The project discontinues directly creating its project.<br>
<br>
2. If there are multiple project type GUIDs, the environment makes recursive function calls to
<br>
&nbsp; your implementations of PreCreateForOuter, <br>
&nbsp; Microsoft.VisualStudio.Shell.Interop.IVsAggregatableProject.SetInnerProject(System.Object)
<br>
&nbsp; and InitializeForOuter methods while it is walking the list of project type GUIDs,
<br>
&nbsp; starting with the outermost project subtype.<br>
<br>
3. In the PreCreateForOuter method of the ProjectFactory, we can return our ProjectFlavor object,<br>
&nbsp; which can customize the Property Page. <br>
</p>
<h3>Prerequisite</h3>
<p style="font-family:Courier New"><br>
Visual Studio 2010 Professional or Visual Studio 2010 Ultimate. Visual Studio 2010 SDK.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Step1. Open this solution in Visual Studio 2010 Professional or better. <br>
<br>
Step2. Set the CSVSXProjectSubTypeVSIX as the StartUp Project, and open its property pages.
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
&nbsp; &nbsp; &nbsp; &nbsp;<br>
Step3. Build the solution. &nbsp;<br>
<br>
Step4. Press F5, and the Experimental Instance of Microsoft Visual Studio 2010 will
<br>
&nbsp; &nbsp; &nbsp; be launched.<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; In the VS Experimental Instance, click Tool=&gt;Extension Manager, you will find
<br>
&nbsp; &nbsp; &nbsp; CSVSXProjectSubTypeVSIX is loaded.<br>
<br>
Step5. In the VS Experimental Instance, click File=&gt;New=&gt;Project. In the &quot;New Project&quot;<br>
&nbsp; &nbsp; &nbsp; dialog, you will find &quot;CSVSXProjectSubTypeTemplate&quot; in the Visual C# templates.<br>
<br>
&nbsp; &nbsp; &nbsp; Use the CSVSXProjectSubTypeTemplate to create a new project, for example,
<br>
&nbsp; &nbsp; &nbsp; CSVSXProjectSubTypeTemplate1.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; <br>
Step6. Open the property page of CSVSXProjectSubTypeTemplate1, you will find that
<br>
&nbsp; &nbsp; &nbsp; 1. The &quot;Service&quot; Property Page is removed.<br>
&nbsp; &nbsp; &nbsp; 2. A new &quot;Custom&quot; Property Page is added.<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <br>
Step7. Select the &quot;Custom&quot; Property Page of CSVSXProjectSubTypeTemplate1, you will
<br>
&nbsp; &nbsp; &nbsp; see 3 controls: a Label, a TextBox and a CheckBox. <br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; Type some text in the TextBox and check the CheckBox, save it. And then open
<br>
&nbsp; &nbsp; &nbsp; CSVSXProjectSubTypeTemplate1.csproj with NotePad, you will find the text that<br>
&nbsp; &nbsp; &nbsp; you typed.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
A. Create a CSharp Project Template.<br>
<br>
&nbsp; VS SDK supplies a Project Template called &quot;C# Project Template&quot;, with it you can create a
<br>
&nbsp; CSharp Project Template. For more detailed steps, see <a target="_blank" href="http://msdn.microsoft.com/en-us/library/dd885241.aspx">
http://msdn.microsoft.com/en-us/library/dd885241.aspx</a><br>
<br>
&nbsp; Then open the ProjectTemplate.csproj in the CSVSXProjectSubTypeTemplate project, add
<br>
&nbsp; ProjectTypeGuids property to &lt;Project&gt;&lt;PropertyGroup&gt; element.<br>
<br>
&nbsp; &nbsp; &nbsp; &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;<br>
&nbsp; &nbsp; &nbsp; &lt;Project ToolsVersion=&quot;4.0&quot; DefaultTargets=&quot;Build&quot; xmlns=&quot;<a target="_blank" href="http://schemas.microsoft.com/developer/msbuild/2003&quot;&gt;">http://schemas.microsoft.com/developer/msbuild/2003&quot;&gt;</a><br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&lt;PropertyGroup&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ...<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &lt;ProjectTypeGuids&gt;{3C53C28F-DC44-46B0-8B85-0C96B85B2042};{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}&lt;/ProjectTypeGuids&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ...<br>
&nbsp; <br>
&nbsp; {3C53C28F-DC44-46B0-8B85-0C96B85B2042} is the Guid of our Project Factory.<br>
&nbsp; {FAE04EC0-301F-11D3-BF4B-00C04F79EFBC} means CSharp project. <br>
<br>
<br>
B. Create a VSPackage project to Create and Register our Project Factory.<br>
<br>
&nbsp; Follow the steps in <a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb164725.aspx">
http://msdn.microsoft.com/en-us/library/bb164725.aspx</a> to create<br>
&nbsp; an Empty VS Package, NOT to check the &quot;Menu Command&quot; option in step5, and skip the<br>
&nbsp; step6.<br>
<br>
&nbsp; 1. The code files under the PropertyPageBase folder are from VS2005 SDK of April 2006.<br>
<br>
&nbsp; &nbsp; &nbsp;A PropertyPage object contains a PropertyStore object which stores the Properties,<br>
&nbsp; &nbsp; &nbsp;and a PageView object which is a UserControl used to display the Properties.<br>
<br>
&nbsp; &nbsp; &nbsp;The PropertyControlTable class stores the Control / Property Name KeyValuePairs,
<br>
&nbsp; &nbsp; &nbsp;and The PropertyControlMap class is used to initialize the Controls on a PageView<br>
&nbsp; &nbsp; &nbsp;Object by the PropertyPage object. <br>
<br>
&nbsp; 2. The CustomPropertyPage, CustomPropertyPagePropertyStore and CustomPropertyPageView<br>
&nbsp; &nbsp; &nbsp;classed under the ProjectFlavor folder inherit the classes or implement the
<br>
&nbsp; &nbsp; &nbsp;interfaces of the PropertyPageBase.<br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; 3. The CustomPropertyPageProjectFlavor class is our ProjectFlavor, and the
<br>
&nbsp; &nbsp; &nbsp;CustomPropertyPageProjectFlavorCfg class give the project subtype access to various
<br>
&nbsp; &nbsp; &nbsp;configuration interfaces.<br>
<br>
&nbsp; &nbsp; &nbsp;By overriding GetProperty method and using propId parameter containing one of
<br>
&nbsp; &nbsp; &nbsp;the values of the __VSHPROPID2 enumeration, we can filter, add or remove project<br>
&nbsp; &nbsp; &nbsp;properties. <br>
&nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp;For example, to add a page to the configuration-dependent property pages, we<br>
&nbsp; &nbsp; &nbsp;need to filter configuration-dependent property pages and then add a new page
<br>
&nbsp; &nbsp; &nbsp;to the existing list. <br>
<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;protected override int GetProperty(uint itemId, int propId, out object property)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (propId == (int)__VSHPROPID2.VSHPROPID_CfgPropertyPagesCLSIDList)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Get a semicolon-delimited list of clsids of the configuration-dependent<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// property pages.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ErrorHandler.ThrowOnFailure(base.GetProperty(itemId, propId, out property));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Add the CustomPropertyPage property page.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;property &#43;= ';' &#43; typeof(CustomPropertyPage).GUID.ToString(&quot;B&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return VSConstants.S_OK;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (propId == (int)__VSHPROPID2.VSHPROPID_PropertyPagesCLSIDList)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Get the list of priority page guids from the base project system.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ErrorHandler.ThrowOnFailure(base.GetProperty(itemId, propId, out property));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string pageList = (string)property;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Remove the Services page from the project designer.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string servicesPageGuidString = &quot;{43E38D2E-43B8-4204-8225-9357316137A4}&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;RemoveFromCLSIDList(ref pageList, servicesPageGuidString);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;property = pageList;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return VSConstants.S_OK;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return base.GetProperty(itemId, propId, out property);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; <br>
&nbsp; 4. The CustomPropertyPageProjectFactory class &nbsp;is the project factory for our project flavor.<br>
&nbsp; &nbsp; &nbsp;You can read the &quot;How the Project SubTypes Work:&quot; section to learn the code logic of this<br>
&nbsp; &nbsp; &nbsp;Project Factory.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; #region IVsAggregatableProjectFactory<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// Create an instance of CustomPropertyPageProjectFlavor.
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// The initialization will be done later when Visual Studio calls<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// InitalizeForOuter on it.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;outerProjectIUnknown&quot;&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// This value points to the outer project. It is useful if there is a
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// Project SubType of this Project SubType.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// &lt;returns&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// An CustomPropertyPageProjectFlavor instance that has not been initialized.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/returns&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;protected override object PreCreateForOuter(IntPtr outerProjectIUnknown)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CustomPropertyPageProjectFlavor newProject = new CustomPropertyPageProjectFlavor();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;newProject.package = this.package;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return newProject;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;#endregion<br>
<br>
<br>
&nbsp; 5. The VSXProjectSubTypePackage class is a VSPackage that registers our Project Factory
<br>
&nbsp; &nbsp; &nbsp;and Property Page.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; [PackageRegistration(UseManagedResourcesOnly = true)]<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; // Register the PropertyPage.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; [ProvideObject(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; typeof(CustomPropertyPage),<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; RegisterUsing = RegistrationMethod.CodeBase)]<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; // Register the project (note that we do not specify the extension as we use the<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; // same one as the base project).<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; [ProvideProjectFactory(typeof(CustomPropertyPageProjectFactory),<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &quot;Task Project&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; null,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; null,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; null,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; @&quot;..\Templates\Projects&quot;)]<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; [Guid(GuidList.guidCSVSXProjectSubTypePkgString)]<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; public sealed class VSXProjectSubTypePackage : Package<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ...<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; protected override void Initialize()<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; {<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Trace.WriteLine(string.Format(&quot;Entering Initialize() of: {0}&quot;,<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; this.ToString()));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; base.Initialize();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; this.RegisterProjectFactory(new CustomPropertyPageProjectFactory(this));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; }<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ...<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; }<br>
<br>
C. Create a VSIX project to package up the VSPackage and Project Template. <br>
&nbsp; <br>
&nbsp; Follow the steps in <a target="_blank" href="http://msdn.microsoft.com/en-us/library/dd393742.aspx">
http://msdn.microsoft.com/en-us/library/dd393742.aspx</a> to create an <br>
&nbsp; empty VSIX project.<br>
<br>
&nbsp; Double click source.extension.vsixmanifest of CSVSXProjectSubTypeVSIX to open it. Click<br>
&nbsp; &quot;Add Content&quot; button to add the VSPackage of the CSVSXProjectSubType project, and
<br>
&nbsp; Project Template of the CSVSXProjectSubTypeTemplate.<br>
<br>
<br>
<br>
&nbsp; <br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Project Subtypes<br>
<a target="_blank" href="&lt;a target=" href="http://msdn.microsoft.com/en-us/library/bb166488.aspx">http://msdn.microsoft.com/en-us/library/bb166488.aspx</a>'&gt;<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb166488.aspx">http://msdn.microsoft.com/en-us/library/bb166488.aspx</a><br>
<br>
IPropertyPage Interface<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms691246(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ms691246(VS.85).aspx</a><br>
<br>
FlavoredProjectFactoryBase Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.flavor.flavoredprojectfactorybase.aspx">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.flavor.flavoredprojectfactorybase.aspx</a><br>
<br>
FlavoredProjectBase Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.flavor.flavoredprojectbase.aspx">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.flavor.flavoredprojectbase.aspx</a><br>
<br>
IVsProjectFlavorCfgProvider Interface<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop.ivsprojectflavorcfgprovider.aspx">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop.ivsprojectflavorcfgprovider.aspx</a><br>
<br>
IVsProjectFlavorCfg Interface<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop.ivsprojectflavorcfg.aspx">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop.ivsprojectflavorcfg.aspx</a><br>
<br>
IPersistXMLFragment Interface<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop.ipersistxmlfragment.aspx">http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop.ipersistxmlfragment.aspx</a><br>
<br>
VSIX Deployment<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ff363239.aspx">http://msdn.microsoft.com/en-us/library/ff363239.aspx</a><br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

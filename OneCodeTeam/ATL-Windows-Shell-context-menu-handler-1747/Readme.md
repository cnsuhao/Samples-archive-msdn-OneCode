# ATL Windows Shell context menu handler (ATLShellExtContextMenuHandler)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ATL
* Windows Shell
## Topics
* Shell Extension
* Context Menu Handler
## IsPublished
* True
## ModifiedDate
* 2011-05-05 04:14:21
## Description

<p style="font-family:Courier New"></p>
<h2>ACTIVE TEMPLATE LIBRARY : ATLShellExtContextMenuHandler Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The code sample demonstrates creating a Shell context menu handler with C&#43;&#43;. <br>
<br>
A context menu handler is a shell extension handler that adds commands to an <br>
existing context menu. Context menu handlers are associated with a particular <br>
file class and are called any time a context menu is displayed for a member <br>
of the class. While you can add items to a file class context menu with the <br>
registry, the items will be the same for all members of the class. By <br>
implementing and registering such a handler, you can dynamically add items to <br>
an object's context menu, customized for the particular object.<br>
<br>
Context menu handler is the most powerful but also the most complicated method <br>
to implement. It is strongly encouraged that you implement a context menu <br>
using one of the static verb methods if applicable:<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/dd758091.aspx">http://msdn.microsoft.com/en-us/library/dd758091.aspx</a><br>
<br>
</p>
<h3>Build:</h3>
<p style="font-family:Courier New"><br>
To build ATLShellExtContextMenuHandler, please run Visual Studio as <br>
administrator because the component needs to be registered into HKCR.<br>
<br>
</p>
<h3>Deployment:</h3>
<p style="font-family:Courier New"><br>
A. Setup<br>
<br>
Regsvr32.exe ATLShellExtContextMenuHandler.dll<br>
<br>
B. Cleanup<br>
<br>
Regsvr32.exe /u ATLShellExtContextMenuHandler.dll<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
A. Creating the project<br>
<br>
Step1. Create a Visual C&#43;&#43; / ATL / ATL Project named <br>
ATLShellExtContextMenuHandler in Visual Studio 2008.<br>
<br>
Step2. In the page &quot;Application Settings&quot; of ATL Project Wizard, select the
<br>
server type as Dynamic-link library (DLL). Do not allow merging of proxy/stub <br>
code. After the creation of the project, remove the proxy project because the <br>
proxy will never be needed for any extension dlls.<br>
<br>
Step3. After the project is created, delete the file <br>
ATLShellExtContextMenuHandler.rgs from the project. <br>
ATLShellExtContextMenuHandler.rgs is used to set the AppID of the COM <br>
component, which is not necessary for shell extension. Remove the following <br>
line from dllmain.h.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;DECLARE_REGISTRY_APPID_RESOURCEID(IDR_ATLSHELLEXTCONTEXTMENUHANDLER,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;{DEF5FF96-EE4F-4592-BA4A-3AB4C1B3FBC4}&quot;)<br>
<br>
Last, open Resource View of the project, and delete the registry resource <br>
IDR_ATLSHELLEXTCONTEXTMENUHANDLER.<br>
<br>
Step4. Include the following header files in stdafx.h:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;#include &lt;comdef.h&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;#include &lt;shlobj.h&gt;<br>
<br>
Link shlwapi.lib and comctl32.lib in the project (Project properties / Linker <br>
/ Input / Additional Dependencies.<br>
<br>
-----------------------------------------------------------------------------<br>
<br>
B. Creating Context Menu Extension Handler for Files<br>
<br>
Step1. In Solution Explorer, add a new ATL / ATL Simple Object class to the <br>
project.<br>
<br>
Step2. In ATL Simple Object Wizard, specify the short name as <br>
FileContextMenuExt, and select the threading model as Apartment (<br>
corresponding to STA). Because the extension will only be used by Explorer, <br>
so we can change some settings to remove the Automation features: change the <br>
Interface type to Custom, and change the Aggregation setting to No. When you <br>
click OK, the wizard creates a class called CFileContextMenuExt that <br>
contains the basic code for implementing a COM object, and adds this class to <br>
the project.<br>
<br>
Step3. Remove the implementation of IFileContextMenuExt from <br>
CFileContextMenuExt since we are not implementing our own interface.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;class ATL_NO_VTABLE CFileContextMenuExt :<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComObjectRootEx&lt;CComSingleThreadModel&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComCoClass&lt;CFileContextMenuExt, &CLSID_FileContextMenuExt&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public IFileContextMenuExt&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Remove this line<br>
&nbsp; &nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;BEGIN_COM_MAP(CFileContextMenuExt)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;COM_INTERFACE_ENTRY(IFileContextMenuExt)&nbsp;&nbsp;&nbsp;&nbsp;// Remove this line<br>
&nbsp;&nbsp;&nbsp;&nbsp;END_COM_MAP()<br>
<br>
Some registry setting of the component can also be removed safely from <br>
FileContextMenuExt.rgs.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;HKCR<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ATLShellExtContextMenuHandler.FileCon.1 = s 'FileContextMenuExt Class'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CLSID = s '{6ECB0C29-A701-4892-A234-667933E1CC91}'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ATLShellExtContextMenuHandler.FileConte = s 'FileContextMenuExt Class'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CLSID = s '{6ECB0C29-A701-4892-A234-667933E1CC91}'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CurVer = s 'ATLShellExtContextMenuHandler.FileCon.1'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove CLSID<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ForceRemove {6ECB0C29-A701-4892-A234-667933E1CC91} =
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;s 'FileContextMenuExt Class'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ProgID = s 'ATLShellExtContextMenuHandler.FileCon.1'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VersionIndependentProgID =
<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;s 'ATLShellExtContextMenuHandler.FileConte'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InprocServer32 = s '%MODULE%'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;val ThreadingModel = s 'Apartment'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'TypeLib' = s '{DEF5FF96-EE4F-4592-BA4A-3AB4C1B3FBC4}'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
Step4. Register the context menu handler. First, in the file <br>
FileContextMenuExt.rgs add the following content under HKCR to tell ATL <br>
what registry entries to add when the server is registered, and which ones to <br>
delete when the server is unregistered.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;NoRemove *<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove shellex<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove ContextMenuHandlers<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{6ECB0C29-A701-4892-A234-667933E1CC91}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
HKCR\* stands for all file extensions. If you want the context menu handler <br>
to appears only in .txt files' property dialog, replace the line &quot;NoRemove *&quot;
<br>
with &quot;NoRemove txtfile&quot;. {6ECB0C29-A701-4892-A234-667933E1CC91} is the CLSID
<br>
of the context menu handler component.<br>
<br>
Step5. Add the implementation of IShellExtInit and IContextMenu to <br>
CFileContextMenuExt.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;class ATL_NO_VTABLE CFileContextMenuExt :<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComObjectRootEx&lt;CComSingleThreadModel&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComCoClass&lt;CFileContextMenuExt, &CLSID_FileContextMenuExt&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public IShellExtInit, <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public IContextMenu<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;BEGIN_COM_MAP(CFileContextMenuExt)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;COM_INTERFACE_ENTRY(IShellExtInit)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;COM_INTERFACE_ENTRY(IContextMenu)<br>
&nbsp;&nbsp;&nbsp;&nbsp;END_COM_MAP()<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;// IShellExtInit<br>
&nbsp; &nbsp;IFACEMETHODIMP Initialize(LPCITEMIDLIST, LPDATAOBJECT, HKEY);<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// IContextMenu<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP GetCommandString(UINT, UINT, UINT*, LPSTR, UINT);<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP InvokeCommand(LPCMINVOKECOMMANDINFO);<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP QueryContextMenu(HMENU, UINT, UINT, UINT, UINT);<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Initializing Shell Extensions<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc144105.aspx">http://msdn.microsoft.com/en-us/library/cc144105.aspx</a><br>
<br>
MSDN: Creating Context Menu Handlers<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb776881.aspx">http://msdn.microsoft.com/en-us/library/bb776881.aspx</a><br>
<br>
MSDN: Implementing the Context Menu COM Object<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms677106.aspx">http://msdn.microsoft.com/en-us/library/ms677106.aspx</a><br>
<br>
MSDN: Extending Shortcut Menus<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc144101(VS.85).aspx">http://msdn.microsoft.com/en-us/library/cc144101(VS.85).aspx</a><br>
<br>
The Complete Idiot's Guide to Writing Shell Extensions<br>
<a target="_blank" href="http://www.codeproject.com/KB/shell/shellextguide1.aspx">http://www.codeproject.com/KB/shell/shellextguide1.aspx</a><br>
<a target="_blank" href="http://www.codeproject.com/KB/shell/shellextguide2.aspx">http://www.codeproject.com/KB/shell/shellextguide2.aspx</a><br>
<a target="_blank" href="http://www.codeproject.com/KB/shell/shellextguide7.aspx">http://www.codeproject.com/KB/shell/shellextguide7.aspx</a><br>
<br>
How to Use Submenus in a Context Menu Shell Extension<br>
<a target="_blank" href="http://www.codeproject.com/KB/shell/ctxextsubmenu.aspx">http://www.codeproject.com/KB/shell/ctxextsubmenu.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

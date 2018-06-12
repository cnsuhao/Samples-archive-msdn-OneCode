# ATL Windows Shell icon handler (ATLShellExtIconHandler)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ATL
* Windows Shell
## Topics
* Shell Extension
## IsPublished
* False
## ModifiedDate
* 2011-05-05 04:16:03
## Description

<p style="font-family:Courier New"></p>
<h2>ACTIVE TEMPLATE LIBRARY : ATLShellExtIconHandler Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
An shell icon handler is a type of Shell extension handler that allows you to <br>
dynamically assign icons to the members of a file class and replace the <br>
file's default icon with a custom icon on a file-by-file basis. Every time a <br>
file from the class is displayed, the Shell queries the handler for the <br>
appropriate icon. For instance, an icon handler can assign different icons to <br>
different members of the class, or vary the icon based on the current state <br>
of the file. <br>
<br>
FileIconExt in ATLShellExtIconHandler demonstrates a shell icon handler for <br>
.cfx files. After installing the icon handler, &quot;C#.cfx&quot; files show Sample C#
<br>
icon, &quot;VB.cfx&quot; files show Sample VB icon, &quot;C&#43;&#43;.cfx&quot; files show Sample C&#43;&#43;
<br>
icon, and other .cfx files show a Sample icon in Microsoft Windows Explorer. <br>
<br>
</p>
<h3>Build:</h3>
<p style="font-family:Courier New"><br>
To build ATLShellExtIconHandler, please run Visual Studio as administrator <br>
because the component needs to be registered into HKCR.<br>
<br>
</p>
<h3>Deployment:</h3>
<p style="font-family:Courier New"><br>
A. Setup<br>
<br>
Regsvr32.exe ATLShellExtIconHandler.dll<br>
<br>
B. Cleanup<br>
<br>
Regsvr32.exe /u ATLShellExtIconHandler.dll<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
A. Creating the project<br>
<br>
Step1. Create a Visual C&#43;&#43; / ATL / ATL Project named ATLShellExtIconHandler <br>
in Visual Studio 2008.<br>
<br>
Step2. In the page &quot;Application Settings&quot; of ATL Project Wizard, select the
<br>
server type as Dynamic-link library (DLL). Do not allow merging of proxy/stub <br>
code. After the creation of the project, remove the proxy project because the <br>
proxy will never be needed for any extension dlls.<br>
<br>
Step3. After the project is created, delete the file <br>
ATLShellExtIconHandler.rgs from the project. ATLShellExtIconHandler.rgs is <br>
used to set the AppID of the COM component, which is not necessary for shell <br>
extension. Remove the following line from dllmain.h.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;DECLARE_REGISTRY_APPID_RESOURCEID(IDR_ATLSHELLEXTICONHANDLER,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;{C5220BC1-5560-469A-85ED-013A927590EF}&quot;)<br>
<br>
Last, open Resource View of the project, and delete the registry resource <br>
IDR_ATLSHELLEXTICONHANDLER.<br>
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
B. Creating Icon Handler for Files<br>
<br>
Step1. In Solution Explorer, add a new ATL / ATL Simple Object class to the <br>
project.<br>
<br>
Step2. In ATL Simple Object Wizard, specify the short name as FileIconExt, <br>
and select the threading model as Apartment (corresponding to STA). Because <br>
the extension will only be used by Explorer, so we can change some settings <br>
to remove the Automation features: change the Interface type to Custom, and <br>
change the Aggregation setting to No. When you click OK, the wizard creates <br>
a class called CFileIconExt that contains the basic code for implementing a <br>
COM object, and adds this class to the project.<br>
<br>
Step3. Remove the implementation of IFileIconExt from CFileIconExt since we <br>
are not implementing our own interface.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;class ATL_NO_VTABLE CFileIconExt :<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComObjectRootEx&lt;CComSingleThreadModel&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComCoClass&lt;CFileIconExt, &CLSID_FileIconExt&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public IFileIconExt&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Remove this line<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;BEGIN_COM_MAP(CFileIconExt)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;COM_INTERFACE_ENTRY(IFileIconExt)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Remove this line<br>
&nbsp;&nbsp;&nbsp;&nbsp;END_COM_MAP()<br>
<br>
Some registry setting of the component can also be removed safely from <br>
FileIconExt.rgs.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;HKCR<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ATLShellExtIconHandler.FileIconExt.1 = s 'FileIconExt Class'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CLSID = s '{5F2C6E67-3871-4016-9A89-66012AE62B6C}'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ATLShellExtIconHandler.FileIconExt = s 'FileIconExt Class'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CLSID = s '{5F2C6E67-3871-4016-9A89-66012AE62B6C}'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CurVer = s 'ATLShellExtIconHandler.FileIconExt.1'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove CLSID<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ForceRemove {5F2C6E67-3871-4016-9A89-66012AE62B6C} = s 'FileIconExt Class'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ProgID = s 'ATLShellExtIconHandler.FileIconExt.1'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VersionIndependentProgID = s 'ATLShellExtIconHandler.FileIconExt'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InprocServer32 = s '%MODULE%'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;val ThreadingModel = s 'Apartment'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'TypeLib' = s '{41F392DC-25EB-4A91-A01E-C3F5FBC258B0}'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
Step4. Register the icon handler. First, in the file FileIconExt.rgs add the <br>
following content under HKCR to tell ATL what registry entries to add when <br>
the server is registered, and which ones to delete when the server is <br>
unregistered.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;HKCR<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove .cfx<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove DefaultIcon = s '%%1'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove ShellEx<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ForceRemove IconHandler =
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;s '{5F2C6E67-3871-4016-9A89-66012AE62B6C}'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
When you statically register an icon for a file class, you create a <br>
DefaultIcon subkey under the file class. Its default value is set to the file <br>
that contains the icon. To register an icon handler, you must still have the <br>
DefaultIcon subkey, but its default value must be set to &quot;%1&quot;. Add an <br>
IconHandler subkey to the Shellex subkey of the .cfx subkey, and set its <br>
default value to the string form of the handler's class identifier (CLSID) <br>
GUID. There can be only one icon handler for a particular file type, so the <br>
GUID is stored as a value in the IconHandler key, instead of in a subkey <br>
under IconHandler.<br>
<br>
Step5. Add the implementation of IPersistFile and IExtractIcon to <br>
CFileIconExt. Icon handlers must export two interfaces in addition to <br>
IUnknown: IPersistFile and IExtractIcon.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;class ATL_NO_VTABLE CFileIconExt :<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComObjectRootEx&lt;CComSingleThreadModel&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComCoClass&lt;CFileIconExt, &CLSID_FileIconExt&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public IPersistFile,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public IExtractIcon<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;BEGIN_COM_MAP(CFileIconExt)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;COM_INTERFACE_ENTRY(IPersistFile)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;COM_INTERFACE_ENTRY(IExtractIcon)<br>
&nbsp;&nbsp;&nbsp;&nbsp;END_COM_MAP()<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// IPersistFile<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP GetClassID(LPCLSID) &nbsp; &nbsp; &nbsp;{ return E_NOTIMPL; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP IsDirty() &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{ return E_NOTIMPL; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP Load(LPCOLESTR, DWORD);<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP Save(LPCOLESTR, BOOL) &nbsp; &nbsp;{ return E_NOTIMPL; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP SaveCompleted(LPCOLESTR) { return E_NOTIMPL; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP GetCurFile(LPOLESTR*) &nbsp; &nbsp;{ return E_NOTIMPL; }<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// IExtractIcon<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP GetIconLocation(UINT, LPTSTR, UINT, int*, UINT*);<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP Extract(LPCTSTR, UINT, HICON*, HICON*, UINT);<br>
<br>
The Shell initializes the handler through its IPersistFile interface. It uses <br>
this interface to request the handler's CLSID and provides it with the file's <br>
name:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// pszFileName contains the absolute path of the file to be opened<br>
&nbsp;&nbsp;&nbsp;&nbsp;wcscpy_s(m_szFileName, MAX_PATH, pszFileName);<br>
<br>
The rest of the operation takes place through the IExtractIcon interface. The <br>
Shell uses the handler's IExtractIcon interface to request the appropriate <br>
icon. The interface has two methods: GetIconLocation and Extract, and <br>
gives two options of providing icon information to the Shell.<br>
<br>
Option1. <br>
GetIconLocation() can return the icon file name (szIconFile) and the <br>
zero-based index of the icon if there is more than one icon in the file.<br>
Extract() does not have to do anything but return S_FALSE to tell the Shell <br>
to extract the icon itself. When using this option, the Shell normally <br>
attempts to load the icon from its cache. The Shell keeps an icon cache which <br>
holds recently-used icons. <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP CFileIconExt::GetIconLocation(<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UINT uFlags, LPTSTR szIconFile, UINT cchMax, int* piIndex, UINT* pwFlags)<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// The icons are in this shell extension DLL, so get the full path of the
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// module and return through the szIconFile parameter.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GetModuleFileName(_AtlBaseModule.GetResourceInstance(), szIconFile,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MAX_PATH);<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Determine which icon to use, depending on the file name.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Get the file name from the file path<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TCHAR szFileName[_MAX_FNAME];<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_tsplitpath_s(m_szFileName, NULL, 0, NULL, 0, szFileName, _MAX_FNAME,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NULL, 0);<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Check the file name and set piIndex to the correct index of icon<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if (_tcscmp(szFileName, _T(&quot;C#&quot;)) == 0)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// C#.cfx -&gt; the 2nd icon<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*piIndex = 1;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;...<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;else<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Other file name.cfx -&gt; the 1st icon<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*piIndex = 0;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Set pwFlags to 0 to get the default behavior from the Shell, i.e.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// the Shell will attempt to load the icon from its cache.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*pwFlags = 0;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return S_OK;<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP CFileIconExt::Extract(LPCTSTR pszFile, UINT nIconIndex,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HICON* phiconLarge, HICON* phiconSmall, UINT nIconSize)<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Because a file name is provided in GetIconLocation, the handler can
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// return S_FALSE to have the Shell extract the icon by itself.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return S_FALSE;<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
Option2.<br>
To prevent the loading of a cached icon, set the GIL_DONTCACHE flag in the <br>
pwFlags parameter of GetIconLocation(). This tells the Shell not to look in <br>
the icon cache. The Shell will always call Extract(), which is then <br>
responsible for loading the icons and returning handles to those icons that <br>
the Shell will show. The advantage of this option is that you do not have to <br>
worry about keeping your icons' resource IDs in order. The downside is that <br>
it bypasses the Shell's icon cache, which conceivably might slow down file <br>
browsing a bit if you go into a directory with a ton of .cfx files.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP CFileIconExt::GetIconLocation(<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UINT uFlags, LPTSTR szIconFile, UINT cchMax, int* piIndex, UINT* pwFlags)<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Tell the shell not to look at the icon file name or index, and do not
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// check the icon cache.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*pwFlags = GIL_NOTFILENAME | GIL_DONTCACHE;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return S_OK;<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP CFileIconExt::Extract(LPCTSTR pszFile, UINT nIconIndex,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; HICON* phiconLarge,
 HICON* phiconSmall, <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UINT nIconSize)<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Determine which icon to use, depending on the file name.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UINT uIconID;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Get the file name from the file path<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TCHAR szFileName[_MAX_FNAME];<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_tsplitpath_s(m_szFileName, NULL, 0, NULL, 0, szFileName, _MAX_FNAME,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NULL, 0);<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Check the file name and set piIndex to the correct icon id<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if (_tcscmp(szFileName, _T(&quot;C#&quot;)) == 0)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// C#.cfx -&gt; IDI_SAMPLECS<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uIconID = IDI_SAMPLECS;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;...<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;else<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Other file name.cfx -&gt; IDI_SAMPLE<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uIconID = IDI_SAMPLE;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Determine the icon sizes<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WORD wSmallIconSize = HIWORD(nIconSize);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WORD wLargeIconSize = LOWORD(nIconSize);<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Load the icons<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if (NULL != phiconLarge)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*phiconLarge = (HICON)LoadImage(<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_AtlBaseModule.GetResourceInstance(), MAKEINTRESOURCE(uIconID),
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IMAGE_ICON, wLargeIconSize, wLargeIconSize, LR_DEFAULTCOLOR);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if (NULL != phiconSmall)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*phiconSmall = (HICON)LoadImage(<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_AtlBaseModule.GetResourceInstance(), MAKEINTRESOURCE(uIconID),
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IMAGE_ICON, wSmallIconSize, wSmallIconSize, LR_DEFAULTCOLOR);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return S_OK;<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Creating Icon Handlers<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb776857(VS.85).aspx">http://msdn.microsoft.com/en-us/library/bb776857(VS.85).aspx</a><br>
<br>
The Complete Idiot's Guide to Writing Shell Extensions - Part IX<br>
<a target="_blank" href="http://www.codeproject.com/KB/shell/shellextguide9.aspx">http://www.codeproject.com/KB/shell/shellextguide9.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

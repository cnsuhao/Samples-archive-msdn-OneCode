# ATL Windows Shell icon overlay handler (ATLShellExtIconOverlayHandler)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ATL
* Windows Shell
## Topics
* Shell Extension
* Icon Overlay Handler
## IsPublished
* False
## ModifiedDate
* 2011-05-05 04:16:25
## Description

<p style="font-family:Courier New"></p>
<h2>ACTIVE TEMPLATE LIBRARY : ATLShellExtIconOverlayHandler Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
Icon overlays are small images placed at the lower-left corner of the icon <br>
that represents a Shell object. They are normally added to an object's icon <br>
to provide some extra information. For instance, a commonly used icon overlay <br>
is the small arrow that indicates that the icon represents a link, rather <br>
than the actual file or folder. In addition to the standard icon overlays <br>
that are provided by the system, you can request custom icon overlays for <br>
specified Shell objects by implementing and registering an icon overlay <br>
handler.<br>
<br>
FileIconOverlayExt in ATLShellExtIconOverlayHandler demonstrates a shell icon <br>
overlay handler for files with &quot;Sample&quot; in the file paths. After installing
<br>
the icon overlay handler, any file with &quot;Sample&quot; in its file path, e.g.
<br>
&quot;D:\Sample.txt&quot;, shows an icon overlay in Windows Explorer. <br>
<br>
</p>
<h3>Build:</h3>
<p style="font-family:Courier New"><br>
To build ATLShellExtIconOverlayHandler, please run Visual Studio as <br>
dministrator because the component needs to be registered into HKCR.<br>
<br>
</p>
<h3>Deployment:</h3>
<p style="font-family:Courier New"><br>
A. Setup<br>
<br>
Regsvr32.exe ATLShellExtIconOverlayHandler.dll<br>
<br>
B. Cleanup<br>
<br>
Regsvr32.exe /u ATLShellExtIconOverlayHandler.dll<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
A. Creating the project<br>
<br>
Step1. Create a Visual C&#43;&#43; / ATL / ATL Project named <br>
ATLShellExtIconOverlayHandler in Visual Studio 2008.<br>
<br>
Step2. In the page &quot;Application Settings&quot; of ATL Project Wizard, select the
<br>
server type as Dynamic-link library (DLL). Do not allow merging of proxy/stub <br>
code. After the creation of the project, remove the proxy project because the <br>
proxy will never be needed for any extension dlls.<br>
<br>
Step3. After the project is created, delete the file <br>
ATLShellExtIconOverlayHandler.rgs from the project. <br>
ATLShellExtIconOverlayHandler.rgs is used to set the AppID of the COM <br>
component, which is not necessary for shell extension. Remove the following <br>
line from dllmain.h.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;DECLARE_REGISTRY_APPID_RESOURCEID(IDR_ATLSHELLEXTICONOVERLAYHANDLER,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;{2C120B84-1B64-41DF-A6C9-58CA609DDA10}&quot;)<br>
<br>
Last, open Resource View of the project, and delete the registry resource <br>
IDR_ATLSHELLEXTICONOVERLAYHANDLER.<br>
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
B. Creating Icon Overlay Handler for Files<br>
<br>
Step1. In Solution Explorer, add a new ATL / ATL Simple Object class to the <br>
project.<br>
<br>
Step2. In ATL Simple Object Wizard, specify the short name as <br>
FileIconOverlayExt, and select the threading model as Apartment <br>
(corresponding to STA). Because the extension will only be used by Explorer, <br>
so we can change some settings to remove the Automation features: change the <br>
Interface type to Custom, and change the Aggregation setting to No. When you <br>
click OK, the wizard creates a class called CFileIconOverlayExt that contains <br>
the basic code for implementing a COM object, and adds this class to the <br>
project.<br>
<br>
Step3. Remove the implementation of IFileIconOverlayExt from <br>
CFileIconOverlayExt since we are not implementing our own interface.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;class ATL_NO_VTABLE CFileIconOverlayExt :<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComObjectRootEx&lt;CComSingleThreadModel&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComCoClass&lt;CFileIconOverlayExt, &CLSID_FileIconOverlayExt&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public IFileIconOverlayExt&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Remove this line<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;BEGIN_COM_MAP(CFileIconOverlayExt)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;COM_INTERFACE_ENTRY(IFileIconOverlayExt)&nbsp;&nbsp;&nbsp;&nbsp;// Remove this line<br>
&nbsp;&nbsp;&nbsp;&nbsp;END_COM_MAP()<br>
<br>
Some registry setting of the component can also be removed safely from <br>
FileIconOverlayExt.rgs.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;HKCR<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ATLShellExtIconOverlayHandler.FileIco.1 = s 'FileIconOverlayExt Class'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CLSID = s '{B110C7D3-BE8C-43D5-83FD-DC1AAC7605A2}'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ATLShellExtIconOverlayHandler.FileIconO = s 'FileIconOverlayExt Class'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CLSID = s '{B110C7D3-BE8C-43D5-83FD-DC1AAC7605A2}'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CurVer = s 'ATLShellExtIconOverlayHandler.FileIco.1'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove CLSID<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ForceRemove {B110C7D3-BE8C-43D5-83FD-DC1AAC7605A2} =
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;s 'FileIconOverlayExt Class'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ProgID = s 'ATLShellExtIconOverlayHandler.FileIco.1'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VersionIndependentProgID =
<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;s 'ATLShellExtIconOverlayHandler.FileIconO'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InprocServer32 = s '%MODULE%'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;val ThreadingModel = s 'Apartment'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'TypeLib' = s '{26E7F59B-B172-4952-944E-EC15689CD8FB}'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
Step4. Register the icon overlay handler. First, in the file <br>
FileIconOverlayExt.rgs add the following content under HKCR to tell ATL what <br>
registry entries to add when the server is registered, and which ones to <br>
delete when the server is unregistered. In addition to normal COM <br>
registration, you must create a subkey for the handler under the <br>
ShellIconOverlayIdentifiers key:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;HKEY_LOCAL_MACHINE/Software/Microsoft/Windows/CurrentVersion/Explorer/<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShellIconOverlayIdentifiers<br>
<br>
Set the default value of the subkey to the string form of the object's CLSID.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;HKLM<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove Software<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove Microsoft<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove Windows<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove CurrentVersion<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove Explorer<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove ShellIconOverlayIdentifiers<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ForceRemove SampleATLShellExtIconOverlayHandler =
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;s '{B110C7D3-BE8C-43D5-83FD-DC1AAC7605A2}'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
Step5. Add the implementation of IShellIconOverlayIdentifier to <br>
CFileIconOverlayExt. <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;class ATL_NO_VTABLE CFileIconOverlayExt :<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComObjectRootEx&lt;CComSingleThreadModel&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComCoClass&lt;CFileIconOverlayExt, &CLSID_FileIconOverlayExt&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public IShellIconOverlayIdentifier<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;BEGIN_COM_MAP(CFileIconOverlayExt)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;COM_INTERFACE_ENTRY(IShellIconOverlayIdentifier)<br>
&nbsp;&nbsp;&nbsp;&nbsp;END_COM_MAP()<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// IShellIconOverlayIdentifier<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP GetOverlayInfo(LPWSTR, int, int*, DWORD*);<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP GetPriority(int*);<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP IsMemberOf(LPCWSTR, DWORD);<br>
<br>
When the Shell starts up, it initializes all icon overlay handlers by calling <br>
two of their IShellIconOverlayIdentifier methods:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;1.<br>
&nbsp;&nbsp;&nbsp;&nbsp;The Shell calls GetOverlayInfo to request the location of the handler's
<br>
&nbsp;&nbsp;&nbsp;&nbsp;icon overlay. The icon overlay handler returns the name of the file
<br>
&nbsp;&nbsp;&nbsp;&nbsp;containing the overlay image, and its index within that file. The Shell
<br>
&nbsp;&nbsp;&nbsp;&nbsp;then adds the icon overlay to the system image list. <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP CFileIconOverlayExt::GetOverlayInfo(<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LPWSTR pwszIconFile, int cchMax, int* pIndex, DWORD* pdwFlags)<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Get the module's full path<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GetModuleFileNameW(_AtlBaseModule.GetModuleInstance(), pwszIconFile,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cchMax);<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Use the first icon in the resource<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*pIndex = 0;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*pdwFlags = ISIOI_ICONFILE | ISIOI_ICONINDEX;d<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return S_OK;<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;2.<br>
&nbsp;&nbsp;&nbsp;&nbsp;The Shell calls GetPriority to determine the icon overlay's priority. The
<br>
&nbsp;&nbsp;&nbsp;&nbsp;priority value is a number from zero to 100, with 100 indicating the
<br>
&nbsp;&nbsp;&nbsp;&nbsp;lowest priority. If more than one icon overlay is requested for a
<br>
&nbsp;&nbsp;&nbsp;&nbsp;particular file, the Shell uses this value to help it determine which
<br>
&nbsp;&nbsp;&nbsp;&nbsp;icon overlay to display. <br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP CFileIconOverlayExt::GetPriority(int* pPriority)<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Request the highest priority <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*pPriority = 0;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return S_OK;<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
Note &nbsp; Once the image has been loaded into the system image list during <br>
initialization, it cannot be changed. After initialization, the file name and <br>
index are used only to identify the icon overlay. The system will not load a <br>
new icon overlay. <br>
<br>
Before painting an object's icon, the Shell passes the object's name to each <br>
icon overlay handler's IsMemberOf method. An icon overlay handler is normally <br>
associated with a particular group of files. For example, the icon overlay <br>
handler might request an overlay for all members of a file class, such as all <br>
files with an .myp file name extension. If a handler wants to have its icon <br>
overlay displayed, it returns S_OK. The Shell then calls the handler's <br>
GetOverlayInfo method to determine which icon to display.<br>
<br>
Although only one icon overlay can be displayed, it is possible for an object <br>
to have icon overlays requested by more than one handler. In that case, the <br>
Shell resolves the conflict by displaying the highest priority icon overlay. <br>
The Shell resolves many such conflicts with an internal set of rules. If <br>
these rules are not sufficient, the Shell compares the priority values that <br>
were specified by the handlers' GetPriority method during initialization.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP CFileIconOverlayExt::IsMemberOf(LPCWSTR pwszPath,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 &nbsp; DWORD dwAttrib)<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// If the file name contains &quot;Sample&quot;, add the overlay<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if (wcsstr(pwszPath, L&quot;Sample&quot;) != 0)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return S_OK;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;else<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return S_FALSE;<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Creating Icon Overlay Handlers<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb776858(VS.85).aspx">http://msdn.microsoft.com/en-us/library/bb776858(VS.85).aspx</a><br>
<br>
How to overlay an icon over existing shell objects in 3 easy steps<br>
<a target="_blank" href="http://www.codeproject.com/KB/shell/overlayicon.aspx">http://www.codeproject.com/KB/shell/overlayicon.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
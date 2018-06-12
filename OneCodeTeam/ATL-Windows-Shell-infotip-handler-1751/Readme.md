# ATL Windows Shell infotip handler (ATLShellExtInfotipHandler)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ATL
* Windows Shell
## Topics
* Shell Extension
* Infotip Handler
## IsPublished
* False
## ModifiedDate
* 2011-05-05 04:16:48
## Description

<p style="font-family:Courier New"></p>
<h2>ACTIVE TEMPLATE LIBRARY : ATLShellExtInfotipHandler Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
ATLShellExtInfotipHandler demonstrates making Windows shell infotip handler <br>
in VC&#43;&#43;/ATL. Infotip Handler provides pop-up text when the user hovers the <br>
mouse pointer over the object. <br>
<br>
FileInfotipExt is an example of infotip handler for .txt file objects. When <br>
mouse is placed over a .txt file item in Windows Explorer, shell queries for <br>
the registry entry<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;HKEY_CLASSES_ROOT\.txt\ShellEx\{00021500-0000-0000-C000-000000000046}<br>
<br>
It then checks the default value at this key. If it is a valid CLSID, shell <br>
creates an object of that class. Once the object is created, shell queries <br>
for IPersistFile and calls its Load method passing the file name of the item <br>
over which mouse is placed. After that, IQueryInfo is queried for and the <br>
method GetInfoTip is called. GetInfoTip has an out parameter *ppwszTip which <br>
recieves the address of the tool tip buffer. Shell finally displays the info <br>
tip using the value in the tool tip buffer.<br>
<br>
</p>
<h3>Build:</h3>
<p style="font-family:Courier New"><br>
To build ATLShellExtInfotipHandler, please run Visual Studio as administrator <br>
because the component needs to be registered into HKCR.<br>
<br>
</p>
<h3>Deployment:</h3>
<p style="font-family:Courier New"><br>
A. Setup<br>
<br>
Regsvr32.exe ATLShellExtInfotipHandler.dll<br>
<br>
B. Cleanup<br>
<br>
Regsvr32.exe /u ATLShellExtInfotipHandler.dll<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
A. Creating the project<br>
<br>
Step1. Create a Visual C&#43;&#43; / ATL / ATL Project named <br>
ATLShellExtInfotipHandler in Visual Studio 2008.<br>
<br>
Step2. In the page &quot;Application Settings&quot; of ATL Project Wizard, select the
<br>
server type as Dynamic-link library (DLL). Do not allow merging of proxy/stub <br>
code. After the creation of the project, remove the proxy project because the <br>
proxy will never be needed for any extension dlls.<br>
<br>
Step3. After the project is created, delete the file <br>
ATLShellExtInfotipHandler.rgs from the project. ATLShellExtInfotipHandler.rgs <br>
is used to set the AppID of the COM component, which is not necessary for <br>
shell extension. Remove the following line from dllmain.h.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;DECLARE_REGISTRY_APPID_RESOURCEID(IDR_ATLSHELLEXTINFOTIPHANDLER,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;{3FF4636C-8A2F-4074-8E94-B6DB0D4080C9}&quot;)<br>
<br>
Last, open Resource View of the project, and delete the registry resource <br>
IDR_ATLSHELLEXTINFOTIPHANDLER.<br>
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
B. Creating Infotip Extension Handler for Files<br>
<br>
Step1. In Solution Explorer, add a new ATL / ATL Simple Object class to the <br>
project.<br>
<br>
Step2. In ATL Simple Object Wizard, specify the short name as <br>
FileInfotipExt, and select the threading model as Apartment (corresponding to <br>
STA). Because the extension will only be used by Explorer, so we can change <br>
some settings to remove the Automation features: change the Interface type to <br>
Custom, and change the Aggregation setting to No. When you click OK, the <br>
wizard creates a class called CFileInfotipExt that contains the basic code <br>
for implementing a COM object, and adds this class to the project.<br>
<br>
Step3. Remove the implementation of IFilePropSheetExt from <br>
CFilePropSheetExt since we are not implementing our own interface.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;class ATL_NO_VTABLE CFileInfotipExt :<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComObjectRootEx&lt;CComSingleThreadModel&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComCoClass&lt;CFileInfotipExt, &CLSID_FileInfotipExt&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public IFileInfotipExt&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Remove this line<br>
&nbsp; &nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;BEGIN_COM_MAP(CFileInfotipExt)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;COM_INTERFACE_ENTRY(IFileInfotipExt)&nbsp;&nbsp;&nbsp;&nbsp;// Remove this line<br>
&nbsp;&nbsp;&nbsp;&nbsp;END_COM_MAP()<br>
<br>
Some registry setting of the component can also be removed safely from <br>
FileInfotipExt.rgs.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;HKCR<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ATLShellExtInfotipHandler.FileInfotip.1 = s 'FileInfotipExt Class'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CLSID = s '{869DEFF7-C2CE-4918-B205-EF354C551E47}'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ATLShellExtInfotipHandler.FileInfotipEx = s 'FileInfotipExt Class'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CLSID = s '{869DEFF7-C2CE-4918-B205-EF354C551E47}'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CurVer = s 'ATLShellExtInfotipHandler.FileInfotip.1'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove CLSID<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ForceRemove {869DEFF7-C2CE-4918-B205-EF354C551E47} =
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;s 'FileInfotipExt Class'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ProgID = s 'ATLShellExtInfotipHandler.FileInfotip.1'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VersionIndependentProgID =
<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;s 'ATLShellExtInfotipHandler.FileInfotipEx'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InprocServer32 = s '%MODULE%'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;val ThreadingModel = s 'Apartment'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'TypeLib' = s '{52A14351-F64F-4BA0-AF62-95ED373845E9}'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
Step4. Register the infotip handler. First, in the file FileInfotipExt.rgs <br>
add the following content under HKCR to tell ATL what registry entries to add <br>
when the server is registered, and which ones to delete when the server is <br>
unregistered.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;NoRemove .txt<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove shellex<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{00021500-0000-0000-C000-000000000046} =
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;s '{869DEFF7-C2CE-4918-B205-EF354C551E47}'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
HKCR\.txt means that the infotip handler applies to all .txt files. <br>
{869DEFF7-C2CE-4918-B205-EF354C551E47} is the CLSID of the infotip handler <br>
component. {00021500-0000-0000-C000-000000000046} is the GUID of IQueryInfo, <br>
and it stands for toolip handlers under the shellex registry key. When mouse <br>
is placed over a file item displayed in explorer, shell queries for the <br>
registry entry <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;HKEY_CLASSES_ROOT\.&lt;file extension&gt;\ShellEx\{00021500-0000-0000-C000-000000000046}<br>
<br>
Shell then checks the default value present at this key. If the value is a <br>
valid CLSID, shell creates an object of the class. <br>
<br>
Step5. Add the implementation of IPersistFile and IQueryInfo to <br>
CFileInfotipExt. <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;class ATL_NO_VTABLE CFileInfotipExt :<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComObjectRootEx&lt;CComSingleThreadModel&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComCoClass&lt;CFileInfotipExt, &CLSID_FileInfotipExt&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public IPersistFile, <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public IQueryInfo<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;BEGIN_COM_MAP(CFileInfotipExt)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;COM_INTERFACE_ENTRY(IPersistFile)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;COM_INTERFACE_ENTRY(IQueryInfo)<br>
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
&nbsp;&nbsp;&nbsp;&nbsp;// IQueryInfo<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP GetInfoFlags(DWORD*) &nbsp; &nbsp; { return E_NOTIMPL; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP GetInfoTip(DWORD, LPWSTR*);<br>
<br>
Shell queries the extension for IPersistFile and calls its Load method <br>
passing the file name of the item over which mouse is placed. <br>
IPersistFile::Load opens the specified file and initializes an object from <br>
the file contents. We can get the absolute path of the file in this method.<br>
<br>
After that, IQueryInfo is queried for and the method GetInfoTip is called. <br>
GetInfoTip has an out parameter *ppwszTip of type LPWSTR &nbsp;which recieves the
<br>
address of the tool tip buffer. Please note that the memory pointed by <br>
*ppwszTip must be allocated by calling CoTaskMemAlloc. Shell knows to call <br>
CoTaskMemFree to free the memory when the info tip is no longer needed.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;*ppwszTip = (LPWSTR)CoTaskMemAlloc(512 * sizeof(WCHAR));<br>
&nbsp;&nbsp;&nbsp;&nbsp;swprintf_s(*ppwszTip, 512, L&quot;All-In-One Code Framework Shell Extension &quot; \<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;L&quot;Example\nATLShellExtInfotipHandler - FileInfotipExt\nFile name: %s&quot;,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_szFileName);<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Initializing Shell Extensions<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc144105.aspx">http://msdn.microsoft.com/en-us/library/cc144105.aspx</a><br>
<br>
MSDN: IQueryInfo Interface<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb761359.aspx">http://msdn.microsoft.com/en-us/library/bb761359.aspx</a><br>
<br>
The Complete Idiot's Guide to Writing Shell Extensions - Part III<br>
<a target="_blank" href="http://www.codeproject.com/KB/shell/ShellExtGuide3.aspx">http://www.codeproject.com/KB/shell/ShellExtGuide3.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

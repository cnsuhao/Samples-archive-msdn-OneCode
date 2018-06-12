# ATL Windows Shell column handler (ATLShellExtColumnHandler)
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
* 2011-05-05 04:13:57
## Description

<p style="font-family:Courier New"></p>
<h2>ACTIVE TEMPLATE LIBRARY : ATLShellExtColumnHandler Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The Details view in the Microsoft Windows Windows Explorer normally displays <br>
several standard columns. Each column lists information, such as the file <br>
size or type, for each file in the current folder. By implementing and <br>
registering a column handler, you can make custom columns available for <br>
display on Windows 2000, Windows XP and Windows 2003. <br>
<br>
Note: Support for column handler (IColumnProvider) has been removed from <br>
Windows Vista. So the sample does not work on Windows Vista, and later <br>
operating systems. The new property system should be used in its place. See <br>
Property System (<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb776859.aspx)">http://msdn.microsoft.com/en-us/library/bb776859.aspx)</a> for
<br>
conceptual materials that explain the use of the new system.<br>
<br>
FileColumnExt in ATLShellExtColumnHandler demonstrates a column handler that <br>
provides three columns:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;1. Sample C1 - display the file path when enabled<br>
&nbsp;&nbsp;&nbsp;&nbsp;2. Sample C2 - display the file size when enabled<br>
&nbsp;&nbsp;&nbsp;&nbsp;3. Title (Predefined column) - display the file name when enabled<br>
<br>
The three columns process only .cfx files.<br>
<br>
</p>
<h3>Build:</h3>
<p style="font-family:Courier New"><br>
To build ATLShellExtColumnHandler, please run Visual Studio as administrator <br>
because the component needs to be registered into HKCR.<br>
<br>
</p>
<h3>Deployment:</h3>
<p style="font-family:Courier New"><br>
A. Setup<br>
<br>
Regsvr32.exe ATLShellExtColumnHandler.dll<br>
<br>
B. Cleanup<br>
<br>
Regsvr32.exe /u ATLShellExtColumnHandler.dll<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
A. Creating the project<br>
<br>
Step1. Create a Visual C&#43;&#43; / ATL / ATL Project named ATLShellExtColumnHandler <br>
in Visual Studio 2008.<br>
<br>
Step2. In the page &quot;Application Settings&quot; of ATL Project Wizard, select the
<br>
server type as Dynamic-link library (DLL). Do not allow merging of proxy/stub <br>
code. After the creation of the project, remove the proxy project because the <br>
proxy will never be needed for any extension dlls.<br>
<br>
Step3. After the project is created, delete the file <br>
ATLShellExtColumnHandler.rgs from the project. ATLShellExtColumnHandler.rgs <br>
is used to set the AppID of the COM component, which is not necessary for <br>
shell extension. Remove the following line from dllmain.h.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;DECLARE_REGISTRY_APPID_RESOURCEID(IDR_ATLSHELLEXTCOLUMNHANDLER,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;{20092C2A-8317-4CA9-A65E-567B39E5E0AD}&quot;)<br>
<br>
Last, open Resource View of the project, and delete the registry resource <br>
IDR_ATLSHELLEXTCOLUMNHANDLER.<br>
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
B. Creating Column Extension Handler for Files<br>
<br>
Step1. In Solution Explorer, add a new ATL / ATL Simple Object class to the <br>
project.<br>
<br>
Step2. In ATL Simple Object Wizard, specify the short name as FileColumnExt, <br>
and select the threading model as Apartment (corresponding to STA). Because <br>
the extension will only be used by Explorer, so we can change some settings <br>
to remove the Automation features: change the Interface type to Custom, and <br>
change the Aggregation setting to No. When you click OK, the wizard creates a <br>
class called CFileDragAndDropExt that contains the basic code for <br>
implementing a COM object, and adds this class to the project.<br>
<br>
Step3. Remove the implementation of IFileColumnExt from CFileColumnExt since <br>
we are not implementing our own interface.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;class ATL_NO_VTABLE CFileColumnExt :<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComObjectRootEx&lt;CComSingleThreadModel&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComCoClass&lt;CFileColumnExt, &CLSID_FileColumnExt&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public IFileColumnExt&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Remove this line<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;BEGIN_COM_MAP(CFileColumnExt)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;COM_INTERFACE_ENTRY(IFileColumnExt)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Remove this line<br>
&nbsp;&nbsp;&nbsp;&nbsp;END_COM_MAP()<br>
<br>
Some registry setting of the component can also be removed safely from <br>
FileColumnExt.rgs.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;HKCR<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ATLShellExtColumnHandler.FileColumnEx.1 = s 'FileColumnExt Class'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CLSID = s '{69019B90-52D8-4F93-91A3-5378CDC9C290}'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ATLShellExtColumnHandler.FileColumnExt = s 'FileColumnExt Class'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CLSID = s '{69019B90-52D8-4F93-91A3-5378CDC9C290}'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CurVer = s 'ATLShellExtColumnHandler.FileColumnEx.1'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove CLSID<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ForceRemove {69019B90-52D8-4F93-91A3-5378CDC9C290} =
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;s 'FileColumnExt Class'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ProgID = s 'ATLShellExtColumnHandler.FileColumnEx.1'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VersionIndependentProgID = s 'ATLShellExtColumnHandler.FileColumnExt'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InprocServer32 = s '%MODULE%'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;val ThreadingModel = s 'Apartment'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'TypeLib' = s '{23FEBFA0-BBEC-4BA9-BD3C-B6F689AAAC57}'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
Step4. Register the column handler. First, in the file FileColumnExt.rgs add <br>
the following content under HKCR to tell ATL what registry entries to add <br>
when the server is registered, and which ones to delete when the server is <br>
unregistered. Column handlers are registered under the following subkey. <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;HKEY_CLASSES_ROOT\Folder\shellex\ColumnHandlers<br>
<br>
Create a subkey of ColumnHandlers named with the string form of the handler's <br>
class identifier (CLSID) GUID.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;HKCR<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove Folder<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove Shellex<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove ColumnHandlers<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ForceRemove {69019B90-52D8-4F93-91A3-5378CDC9C290} = s 'FileColumnExt'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
Step5. Add the implementation of IColumnProvider to CFileColumnExt.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;class ATL_NO_VTABLE CFileColumnExt :<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComObjectRootEx&lt;CComSingleThreadModel&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComCoClass&lt;CFileColumnExt, &CLSID_FileColumnExt&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public IColumnProvider<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;BEGIN_COM_MAP(CFileColumnExt)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;COM_INTERFACE_ENTRY_IID(IID_IColumnProvider, IColumnProvider)<br>
&nbsp;&nbsp;&nbsp;&nbsp;END_COM_MAP()<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// IColumnProvider<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP Initialize(LPCSHCOLUMNINIT psci);<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP GetColumnInfo(DWORD dwIndex, SHCOLUMNINFO* psci);<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP GetItemData(LPCSHCOLUMNID pscid, LPCSHCOLUMNDATA pscd,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VARIANT* pvarData);<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Creating Column Handlers<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb776831(VS.85).aspx">http://msdn.microsoft.com/en-us/library/bb776831(VS.85).aspx</a><br>
<br>
The Complete Idiot's Guide to Writing Shell Extensions - Part VIII<br>
<a target="_blank" href="http://www.codeproject.com/KB/shell/shellextguide8.aspx">http://www.codeproject.com/KB/shell/shellextguide8.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

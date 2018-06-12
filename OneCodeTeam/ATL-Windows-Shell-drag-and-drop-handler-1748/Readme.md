# ATL Windows Shell drag and drop handler (ATLShellExtDragAndDropHandler)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ATL
* Windows Shell
## Topics
* Shell Extension
* Drag and Drop Handler
## IsPublished
* False
## ModifiedDate
* 2011-05-05 04:15:40
## Description

<p style="font-family:Courier New"></p>
<h2>ACTIVE TEMPLATE LIBRARY : ATLShellExtDragAndDropHandler Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
ATLShellExtDragAndDropHandler demonstrates making Windows shell drag-and-drop <br>
handler in VC&#43;&#43;/ATL. When a user right-clicks a Shell object to drag an <br>
object, a context menu is displayed when the user attempts to drop the object. <br>
A drag-and-drop handler is a context menu handler that can add items to this <br>
context menu.<br>
<br>
FileDragAndDropExt is an example of drag-and-drop handler for file objects. <br>
After the setup of the handler, when you right-click any files to drag the <br>
files to a directory or the desktop, a context menu with &quot;All-In-One Code <br>
Framework&quot; menu item will be displayed. Clicking the menu item prompts a <br>
message box that shows the files being dragged and the target location that <br>
the files are dropped to.<br>
<br>
</p>
<h3>Build:</h3>
<p style="font-family:Courier New"><br>
To build ATLShellExtDragAndDropHandler, please run Visual Studio as <br>
administrator because the component needs to be registered into HKCR.<br>
<br>
</p>
<h3>Deployment:</h3>
<p style="font-family:Courier New"><br>
A. Setup<br>
<br>
Regsvr32.exe ATLShellExtDragAndDropHandler.dll<br>
<br>
B. Cleanup<br>
<br>
Regsvr32.exe /u ATLShellExtDragAndDropHandler.dll<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
A. Creating the project<br>
<br>
Step1. Create a Visual C&#43;&#43; / ATL / ATL Project named <br>
ATLShellExtDragAndDropHandler in Visual Studio 2008.<br>
<br>
Step2. In the page &quot;Application Settings&quot; of ATL Project Wizard, select the
<br>
server type as Dynamic-link library (DLL). Do not allow merging of proxy/stub <br>
code. After the creation of the project, remove the proxy project because the <br>
proxy will never be needed for any extension dlls.<br>
<br>
Step3. After the project is created, delete the file <br>
ATLShellExtDragAndDropHandler.rgs from the project. <br>
ATLShellExtDragAndDropHandler.rgs is used to set the AppID of the COM <br>
component, which is not necessary for shell extension. Remove the following <br>
line from dllmain.h.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;DECLARE_REGISTRY_APPID_RESOURCEID(IDR_ATLSHELLEXTDRAGANDDROPHANDLER,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;{F063E076-4260-4D10-8FB8-6B59DECAFAD2}&quot;)<br>
<br>
Last, open Resource View of the project, and delete the registry resource <br>
IDR_ATLSHELLEXTDRAGANDDROPHANDLER.<br>
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
B. Creating Drag-and-Drop Extension Handler for Files<br>
<br>
Step1. In Solution Explorer, add a new ATL / ATL Simple Object class to the <br>
project.<br>
<br>
Step2. In ATL Simple Object Wizard, specify the short name as <br>
FileDragAndDropExt, and select the threading model as Apartment (<br>
corresponding to STA). Because the extension will only be used by Explorer, <br>
so we can change some settings to remove the Automation features: change the <br>
Interface type to Custom, and change the Aggregation setting to No. When you <br>
click OK, the wizard creates a class called CFileDragAndDropExt that contains <br>
the basic code for implementing a COM object, and adds this class to the <br>
project.<br>
<br>
Step3. Remove the implementation of IFileDragAndDropExt from <br>
CFileDragAndDropExt since we are not implementing our own interface.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;class ATL_NO_VTABLE CFileDragAndDropExt :<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComObjectRootEx&lt;CComSingleThreadModel&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComCoClass&lt;CFileDragAndDropExt, &CLSID_FileDragAndDropExt&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public IFileDragAndDropExt&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Remove this line<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;BEGIN_COM_MAP(CFileDragAndDropExt)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;COM_INTERFACE_ENTRY(IFileDragAndDropExt)&nbsp;&nbsp;&nbsp;&nbsp;// Remove this line<br>
&nbsp;&nbsp;&nbsp;&nbsp;END_COM_MAP()<br>
<br>
Some registry setting of the component can also be removed safely from <br>
FileDragAndDropExt.rgs.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;HKCR<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ATLShellExtDragAndDropHandler.FileDra.1 = s 'FileDragAndDropExt Class'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CLSID = s '{42A553E9-5587-41AF-BCC0-ADA388CFCCDA}'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ATLShellExtDragAndDropHandler.FileDragA = s 'FileDragAndDropExt Class'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CLSID = s '{42A553E9-5587-41AF-BCC0-ADA388CFCCDA}'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CurVer = s 'ATLShellExtDragAndDropHandler.FileDra.1'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove CLSID<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ForceRemove {42A553E9-5587-41AF-BCC0-ADA388CFCCDA} =
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;s 'FileDragAndDropExt Class'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ProgID = s 'ATLShellExtDragAndDropHandler.FileDra.1'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VersionIndependentProgID =
<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;s 'ATLShellExtDragAndDropHandler.FileDragA'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InprocServer32 = s '%MODULE%'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;val ThreadingModel = s 'Apartment'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'TypeLib' = s '{27060220-9651-4446-B7A3-CACE0E0EA53D}'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
Step4. Register the drag-and-drop handler. First, in the file <br>
FileDragAndDropExt.rgs add the following content under HKCR to tell ATL <br>
what registry entries to add when the server is registered, and which ones to <br>
delete when the server is unregistered.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;NoRemove Directory<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove shellex<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove DragDropHandlers<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{42A553E9-5587-41AF-BCC0-ADA388CFCCDA}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;NoRemove Folder<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove shellex<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove DragDropHandlers<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{42A553E9-5587-41AF-BCC0-ADA388CFCCDA}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;NoRemove Drive<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove shellex<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove DragDropHandlers<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{42A553E9-5587-41AF-BCC0-ADA388CFCCDA}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
Drag-and-drop handlers are typically registered under the following subkey:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;HKEY_CLASSES_ROOT\Directory\shellex\DragDropHandlers\<br>
<br>
In some cases, you also need to register under HKCR\Folder to handle drops on <br>
the desktop, and HKCR\Drive to handle drops in root directories. <br>
{42A553E9-5587-41AF-BCC0-ADA388CFCCDA} is the CLSID of the drag-and-drop <br>
handler component.<br>
<br>
Step5. Add the implementation of IShellExtInit and IContextMenu to <br>
CFileDragAndDropExt. <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;class ATL_NO_VTABLE CFileDragAndDropExt :<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComObjectRootEx&lt;CComSingleThreadModel&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComCoClass&lt;CFileDragAndDropExt, &CLSID_FileDragAndDropExt&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public IShellExtInit, <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public IContextMenu<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;BEGIN_COM_MAP(CFileDragAndDropExt)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;COM_INTERFACE_ENTRY(IShellExtInit)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;COM_INTERFACE_ENTRY(IContextMenu)<br>
&nbsp;&nbsp;&nbsp;&nbsp;END_COM_MAP()&nbsp;&nbsp;&nbsp;&nbsp;<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// IShellExtInit<br>
&nbsp; &nbsp;IFACEMETHODIMP Initialize(LPCITEMIDLIST, LPDATAOBJECT, HKEY);<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// IContextMenu<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP GetCommandString(UINT, UINT, UINT*, LPSTR, UINT)<br>
&nbsp;&nbsp;&nbsp;&nbsp;{ return E_NOTIMPL; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP InvokeCommand(LPCMINVOKECOMMANDINFO);<br>
&nbsp;&nbsp;&nbsp;&nbsp;IFACEMETHODIMP QueryContextMenu(HMENU, UINT, UINT, UINT, UINT);<br>
<br>
You must implement IShellExtInit when you are writing a handler based on the <br>
IContextMenu or IShellPropSheetExt interface. When the shell extension is <br>
loaded, Explorer calls the QueryInterface() function to get a pointer to an <br>
IShellExtInit interface and invokes its Initialize to give various <br>
information. pidlFolder is the PIDL of the folder where the files were <br>
dropped. pDataObj is an IDataObject interface pointer through which we <br>
retrieve the names of the files being dragged.<br>
<br>
The remainder of the operation takes place through the handler's IContextMenu <br>
interface. The Shell first calls IContextMenu::QueryContextMenu. It passes in <br>
an HMENU handle that the method can use to add items to the context menu. <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;InsertMenu(hMenu, indexMenu, MF_STRING | MF_BYPOSITION, idCmdFirst &#43;
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IDM_SAMPLE, _T(&quot;&All-In-One Code Framework&quot;));<br>
<br>
If the user selects one of the commands, IContextMenu::GetCommandString is <br>
called to retrieve the Help string that will be displayed on the Windows <br>
Explorer status bar. In this example, we do not need the help string or verb <br>
string for the command, so we simply return E_NOTIMPL in GetCommandString. &nbsp;<br>
<br>
If the user clicks one of the handler's items, the Shell calls <br>
IContextMenu::InvokeCommand. The handler can then execute the appropriate <br>
command according to the command's verb string (in the high-word of <br>
lpcmi-&gt;lpVerb) or its identifier offset (in the low-word of lpcmi-&gt;lpVerb).
<br>
In this example, because we did not implement IContextMenu::GetCommandString <br>
to specify any verb for the command, the high-word of lpcmi-&gt;lpVerb must be <br>
NULL. The low-word should contain the command's identifier offset. If the &nbsp;<br>
offset equals the value specified when we created the menu item, then execute &nbsp;<br>
the command.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;if (NULL != HIWORD(lpcmi-&gt;lpVerb))<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return E_INVALIDARG;<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;if (LOWORD(lpcmi-&gt;lpVerb) == IDM_SAMPLE)<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OnSample(lpcmi-&gt;hwnd);<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;else<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return E_FAIL;<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Creating Drag-and-Drop Handlers<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb776881.aspx">http://msdn.microsoft.com/en-us/library/bb776881.aspx</a><br>
<br>
The Complete Idiot's Guide to Writing Shell Extensions - Part IV<br>
<a target="_blank" href="http://www.codeproject.com/KB/shell/shellextguide4.aspx">http://www.codeproject.com/KB/shell/shellextguide4.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

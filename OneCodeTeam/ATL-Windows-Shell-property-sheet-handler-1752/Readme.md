# ATL Windows Shell property sheet handler (ATLShellExtPropSheetHandler)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ATL
* Windows Shell
## Topics
* Shell Extension
* Property Sheet Handler
## IsPublished
* False
## ModifiedDate
* 2011-05-05 04:17:13
## Description

<p style="font-family:Courier New"></p>
<h2>ACTIVE TEMPLATE LIBRARY : ATLShellExtPropSheetHandler Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
ATLShellExtPropSheetHandler demonstrates making Windows shell property sheet <br>
handler in VC&#43;&#43;/ATL. Property Sheet Handler is called before an object's <br>
Properties property sheet is displayed. It enables you to add or replace <br>
pages. You can register and implement a Property Sheet Handler for a file <br>
class (see FilePropSheetExt), a mounted drive, a control panel application, <br>
and in Windows 7, you can install property sheet handler to devices in <br>
Devices and Printers dialog (see Win7DevicePropSheetExt).<br>
<br>
ATLShellExtPropSheetHandler exposes these property sheet handlers:<br>
<br>
1. FilePropSheetExt<br>
<br>
CLSID: 3CDE9BE7-5794-4338-A1BA-5303410D56C1<br>
<br>
FilePropSheetExt adds a property page with the subject &quot;All-In-One Code <br>
Framework&quot; to the property dialogs of all file classes in Windows Explorer. <br>
The property page displays the name of the first selected file. It also has <br>
a button &quot;Simulate Property Changing&quot; to simulate the change of properties
<br>
that activates the &quot;Apply&quot; button of the property sheet. <br>
<br>
2. Win7DevicePropSheetExt<br>
<br>
CLSID: 387E6235-C3B3-4109-AB21-303EBE6FB5AB<br>
<br>
Win7DevicePropSheetExt adds a property page with the subject &quot;All-In-One Code
<br>
Framework&quot; to the property sheet of mouse in Windows 7 Devices and Printers <br>
dialog. <br>
<br>
</p>
<h3>Build:</h3>
<p style="font-family:Courier New"><br>
To build ATLShellExtPropSheetHandler, please run Visual Studio as <br>
administrator because the component needs to be registered into HKCR.<br>
<br>
</p>
<h3>Deployment:</h3>
<p style="font-family:Courier New"><br>
A. Setup<br>
<br>
Regsvr32.exe ATLShellExtPropSheetHandler.dll<br>
<br>
B. Cleanup<br>
<br>
Regsvr32.exe /u ATLShellExtPropSheetHandler.dll<br>
<br>
</p>
<h3>Creation:</h3>
<p style="font-family:Courier New"><br>
A. Creating the project<br>
<br>
Step1. Create a Visual C&#43;&#43; / ATL / ATL Project named <br>
ATLShellExtPropSheetHandler in Visual Studio 2008.<br>
<br>
Step2. In the page &quot;Application Settings&quot; of ATL Project Wizard, select the
<br>
server type as Dynamic-link library (DLL). Do not allow merging of proxy/stub <br>
code. After the creation of the project, remove the proxy project because the <br>
proxy will never be needed for any extension dlls.<br>
<br>
Step3. After the project is created, delete the file <br>
ATLShellExtPropSheetHandler.rgs from the project. <br>
ATLShellExtPropSheetHandler.rgs is used to set the AppID of the COM component, <br>
which is not necessary for shell extension. Remove the following line from <br>
dllmain.h.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;DECLARE_REGISTRY_APPID_RESOURCEID(IDR_ATLSHELLEXTPROPSHEETHANDLER,
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;{A86133D8-AC65-425D-B03B-E05C4A51951D}&quot;)<br>
<br>
Last, open Resource View of the project, and delete the registry resource <br>
IDR_ATLSHELLEXTPROPSHEETHANDLER.<br>
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
B. Creating Property Sheet Extension Handler for Files<br>
<br>
Step1. In Solution Explorer, add a new ATL / ATL Simple Object class to the <br>
project.<br>
<br>
Step2. In ATL Simple Object Wizard, specify the short name as <br>
FilePropSheetExt, and select the threading model as Apartment (<br>
corresponding to STA). Because the extension will only be used by Explorer, <br>
so we can change some settings to remove the Automation features: change the <br>
Interface type to Custom, and change the Aggregation setting to No. When you <br>
click OK, the wizard creates a class called CFilePropSheetExt that <br>
contains the basic code for implementing a COM object, and adds this class to <br>
the project.<br>
<br>
Step3. Remove the implementation of IFilePropSheetExt from <br>
CFilePropSheetExt since we are not implementing our own interface.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;class ATL_NO_VTABLE CFilePropSheetExt :<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComObjectRootEx&lt;CComSingleThreadModel&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComCoClass&lt;CFilePropSheetExt, &CLSID_FilePropSheetExt&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public IFilePropSheetExt&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Remove this line<br>
&nbsp; &nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;BEGIN_COM_MAP(CFilePropSheetExt)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;COM_INTERFACE_ENTRY(IFilePropSheetExt)&nbsp;&nbsp;&nbsp;&nbsp;// Remove this line<br>
&nbsp;&nbsp;&nbsp;&nbsp;END_COM_MAP()<br>
<br>
Some registry setting of the component can also be removed safely from <br>
FilePropSheetExt.rgs.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;HKCR<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ATLShellExtPropSheetHandler.FilePropS.1 = s 'FilePropSheetExt Class'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CLSID = s '{3CDE9BE7-5794-4338-A1BA-5303410D56C1}'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ATLShellExtPropSheetHandler.FilePropShe = s 'FilePropSheetExt Class'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CLSID = s '{3CDE9BE7-5794-4338-A1BA-5303410D56C1}'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CurVer = s 'ATLShellExtPropSheetHandler.FilePropS.1'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove CLSID<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ForceRemove {3CDE9BE7-5794-4338-A1BA-5303410D56C1} =
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;s 'FilePropSheetExt Class'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ProgID = s 'ATLShellExtPropSheetHandler.FilePropS.1'<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VersionIndependentProgID =
<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;s 'ATLShellExtPropSheetHandler.FilePropShe'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InprocServer32 = s '%MODULE%'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;val ThreadingModel = s 'Apartment'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
r&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'TypeLib' = s '{15EF6A74-CCAB-4D0C-97AF-42397354D554}'<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
Step4. Register the property sheet handler. First, in the file <br>
FilePropSheetExt.rgs add the following content under HKCR to tell ATL <br>
what registry entries to add when the server is registered, and which ones to <br>
delete when the server is unregistered.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;NoRemove *<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove shellex<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove PropertySheetHandlers<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{3CDE9BE7-5794-4338-A1BA-5303410D56C1}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
HKCR\* stands for all file extensions. If you want the property sheet handler <br>
to appears only in .txt files' property dialog, replace the line &quot;NoRemove *&quot;
<br>
with &quot;NoRemove txtfile&quot;. {3CDE9BE7-5794-4338-A1BA-5303410D56C1} is the CLSID
<br>
of the property sheet handler component.<br>
<br>
Step5. Add the implementation of IShellExtInit and IShellPropSheetExt to <br>
CFilePropSheetExt. <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;class ATL_NO_VTABLE CFilePropSheetExt :<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComObjectRootEx&lt;CComSingleThreadModel&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public CComCoClass&lt;CFilePropSheetExt, &CLSID_FilePropSheetExt&gt;,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public IShellExtInit,<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public IShellPropSheetExt<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;BEGIN_COM_MAP(CFilePropSheetExt)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;COM_INTERFACE_ENTRY(IShellExtInit)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;COM_INTERFACE_ENTRY(IShellPropSheetExt)<br>
&nbsp;&nbsp;&nbsp;&nbsp;END_COM_MAP()<br>
<br>
&nbsp; &nbsp;// IShellExtInit<br>
&nbsp; &nbsp;IFACEMETHODIMP Initialize(LPCITEMIDLIST, LPDATAOBJECT, HKEY);<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// IShellPropSheetExt<br>
&nbsp; &nbsp;IFACEMETHODIMP AddPages(LPFNADDPROPSHEETPAGE, LPARAM);<br>
&nbsp; &nbsp;IFACEMETHODIMP ReplacePage(UINT, LPFNADDPROPSHEETPAGE, LPARAM) <br>
&nbsp;&nbsp;&nbsp;&nbsp;{ return E_NOTIMPL; }<br>
<br>
You must implement IShellExtInit when you are writing a handler based on the <br>
IContextMenu or IShellPropSheetExt interface. When the shell extension is <br>
loaded, Explorer calls the QueryInterface() function to get a pointer to an <br>
IShellExtInit interface and invokes its Initialize to give various <br>
information. pidlFolder is the PIDL of the folder containing the files being <br>
acted upon. pDataObj is an IDataObject interface pointer through which we <br>
retrieve the names of the files being worked on.<br>
<br>
If IShellExtInit::Initialize() returns S_OK, Explorer queries for the <br>
interface IShellPropSheetExt. The AddPages method of IShellPropSheetExt is <br>
the one we'll implement. In AddPages, we can add pages to the property sheet <br>
by setting up a PROPSHEETPAGE struct to represent the new page, and creating <br>
the page (CreatePropertySheetPage). If that succeeds, we call the shell's <br>
callback function which adds the newly-created page to the property sheet. <br>
The callback returns a BOOL indicating success or failure. If it fails, we <br>
destroy the page.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;if (!hPage)<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if (!lpfnAddPageProc(hPage, lParam))<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DestroyPropertySheetPage(hPage);<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
While setting up the PROPSHEETPAGE struct, you can specify two call-backs: <br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;PROPSHEETPAGE.pfnDlgProc: the dialog procedure of the property page. In
<br>
&nbsp;&nbsp;&nbsp;&nbsp;the dialog proc, you can, for example, hook WM_INITDIALOG to initialize
<br>
&nbsp;&nbsp;&nbsp;&nbsp;the dialog, or handle the PSN_APPLY notification if the user clicks the
<br>
&nbsp;&nbsp;&nbsp;&nbsp;OK or Apply button.<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;PROPSHEETPAGE.pfnCallback: gets called when the page is created and
<br>
&nbsp;&nbsp;&nbsp;&nbsp;destroyed. To use this call-back, you must add PSP_USECALLBACK to
<br>
&nbsp;&nbsp;&nbsp;&nbsp;PROPSHEETPAGE.dwFlags.<br>
<br>
Step6. Pass the extension object to the property page.<br>
<br>
The property sheet extension object is independent from the property page. <br>
In many cases, it is desirable to be able to use the extension object, or <br>
some other object, from the property page. To do this, set the lParam member <br>
of PROPSHEETPAGE structure to the object pointer. The property page can then <br>
retrieve this value when it processes the WM_INITDIALOG message. For a <br>
property page, the lParam parameter of the WM_INITDIALOG message is a pointer <br>
to the PROPSHEETPAGE structure. Retrieve the object pointer by casting the <br>
lParam of the WM_INITDIALOG message to a PROPSHEETPAGE pointer and then <br>
retrieving the lParam member of the PROPSHEETPAGE structure.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// In the message handler of WM_INITDIALOG<br>
&nbsp;&nbsp;&nbsp;&nbsp;LPPROPSHEETPAGE pPage = (LPPROPSHEETPAGE)lParam;<br>
&nbsp;&nbsp;&nbsp;&nbsp;if (pPage)<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CFilePropSheetExt* pPropSheetExt = (CFilePropSheetExt*)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pPage-&gt;lParam;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if (pPropSheetExt)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Access the property sheet extension from property page<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
Be aware that after IShellPropSheetExt::AddPages is called, the property <br>
sheet will release the property sheet extension object and never use it <br>
again. This means that the extension object would be deleted before the <br>
property page is displayed. When the page attempts to access the object <br>
pointer, the memory will have been freed and the pointer will not be valid. <br>
To correct this, increment the reference count for the extension object when <br>
the page is added and then release the object when the property page dialog <br>
is destroyed:<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// In CFilePropSheetExt::AddPages<br>
&nbsp;&nbsp;&nbsp;&nbsp;hPage = CreatePropertySheetPage (&psp);<br>
&nbsp;&nbsp;&nbsp;&nbsp;if (hPage)<br>
&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if (lpfnAddPageProc(hPage, lParam))<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this-&gt;AddRef();<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;else<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DestroyPropertySheetPage(hPage);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return E_FAIL;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;// In PropPageCallbackProc<br>
&nbsp;&nbsp;&nbsp;&nbsp;switch(uMsg)<br>
&nbsp; &nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;case PSPCB_RELEASE:<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CFilePropSheetExt *pPropSheetExt = (CFilePropSheetExt*)ppsp-&gt;lParam;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if(pPropSheetExt)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pPropSheetExt-&gt;Release();<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;break;<br>
&nbsp; &nbsp;}<br>
<br>
-----------------------------------------------------------------------------<br>
<br>
C. Creating Property Sheet Extension Handler for Windows 7 Devices and <br>
Printers Folder<br>
<br>
Devices and Printers Folder - Extensibility Guide<br>
<a target="_blank" href="&lt;a target=" href="http://www.microsoft.com/whdc/device/DeviceExperience/DevPrintFolder-Ext.mspx">http://www.microsoft.com/whdc/device/DeviceExperience/DevPrintFolder-Ext.mspx</a>'&gt;<a target="_blank" href="http://www.microsoft.com/whdc/device/DeviceExperience/DevPrintFolder-Ext.mspx">http://www.microsoft.com/whdc/device/DeviceExperience/DevPrintFolder-Ext.mspx</a><br>
<br>
Win7DevicePropSheetExt demonstrates a property sheet handler for Windows 7 <br>
mouse device. The steps of creating the extension handler for devices in <br>
Windows 7 Devices and Printers Folder are similar to the steps for files, <br>
except step 4.<br>
<br>
Step4. Register the property sheet handler. In the file <br>
Win7DevicePropSheetExt.rgs add the following content under HKCR.<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;NoRemove DeviceDisplayObject<br>
&nbsp; &nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove HardwareId<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove HID_DEVICE_SYSTEM_MOUSE<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove shellex<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NoRemove PropertySheetHandlers<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{387E6235-C3B3-4109-AB21-303EBE6FB5AB}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;}<br>
<br>
This installs the property sheet handler to devices with hardware ID <br>
HID_DEVICE_SYSTEM_MOUSE. <br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Initializing Shell Extensions<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc144105.aspx">http://msdn.microsoft.com/en-us/library/cc144105.aspx</a><br>
<br>
MSDN: Creating Property Sheet Handlers<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bb776850.aspx">http://msdn.microsoft.com/en-us/library/bb776850.aspx</a><br>
<br>
MSDN: Implementing the Property Page COM Object<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms677109.aspx">http://msdn.microsoft.com/en-us/library/ms677109.aspx</a><br>
<br>
The Complete Idiot's Guide to Writing Shell Extensions - Part V<br>
<a target="_blank" href="http://www.codeproject.com/KB/shell/shellextguide5.aspx">http://www.codeproject.com/KB/shell/shellextguide5.aspx</a><br>
<br>
Devices and Printers Folder - Extensibility Guide<br>
<a target="_blank" href="&lt;a target=" href="http://www.microsoft.com/whdc/device/DeviceExperience/DevPrintFolder-Ext.mspx">http://www.microsoft.com/whdc/device/DeviceExperience/DevPrintFolder-Ext.mspx</a>'&gt;<a target="_blank" href="http://www.microsoft.com/whdc/device/DeviceExperience/DevPrintFolder-Ext.mspx">http://www.microsoft.com/whdc/device/DeviceExperience/DevPrintFolder-Ext.mspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

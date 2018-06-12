# C++ Windows Shell property sheet handler (CppShellExtPropSheetHandler)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows Shell
## Topics
* Shell Extension
## IsPublished
* True
## ModifiedDate
* 2012-01-15 09:30:43
## Description

<p style="font-family:Courier New">&nbsp;</p>
<h2>DYNAMIC LINK LIBRARY : CppShellExtPropSheetHandler Project Overview</h2>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The code sample demonstrates creating a Shell property sheet handler with C&#43;&#43;. <br>
<br>
A property sheet extension is a COM object implemented as an in-proc server. <br>
The property sheet extension must implement the IShellExtInit and <br>
IShellPropSheetExt interfaces. A property sheet extension is instantiated <br>
when the user displays the property sheet for an object of a class for which <br>
the property sheet extension has been registered in the display specifier of <br>
the class. It enables you to add or replace pages. You can register and <br>
implement a property sheet handler for a file class, a mounted drive, a <br>
control panel application, and starting from Windows 7, you can install a <br>
property sheet handler to devices in Devices and Printers dialog.<br>
<br>
The example property sheet handler has the class ID (CLSID): <br>
&nbsp; &nbsp;{5C8FA94F-F274-49B9-A5E5-D34C093F7846}<br>
<br>
It adds a property sheet page with the title &quot;CppShellExtPropSheetHandler&quot; to <br>
the Properties dialog of the .cpp file class when one .cpp file is selected <br>
in the Windows Explorer. The property sheet page displays the name of the <br>
selected file. It also has a button &quot;Simulate Property Changing&quot; to simulate <br>
the change of properties that activates the &quot;Apply&quot; button of the property <br>
sheet. <br>
<br>
</p>
<h3>Setup and Removal:</h3>
<p style="font-family:Courier New"><br>
A. Setup<br>
<br>
If you are going use the Shell extension in a x64 Windows system, please <br>
configure the Visual C&#43;&#43; project to target 64-bit platforms using project <br>
configurations (<a href="&lt;a target=" target="_blank">http://msdn.microsoft.com/en-us/library/9yb4317s.aspx).</a>'&gt;<a href="http://msdn.microsoft.com/en-us/library/9yb4317s.aspx)." target="_blank">http://msdn.microsoft.com/en-us/library/9yb4317s.aspx).</a>
 Only <br>
64-bit extension DLLs can be loaded in the 64-bit Windows Shell. If the <br>
extension is to be loaded in a 32-bit Windows system, you can use the default <br>
Win32 project configuration to build the project.<br>
<br>
In a command prompt running as administrator, navigate to the folder that <br>
contains the build result CppShellExtPropSheetHandler.dll and enter the <br>
command:<br>
<br>
&nbsp; &nbsp;Regsvr32.exe CppShellExtPropSheetHandler.dll<br>
<br>
The context menu handler is registered successfully if you see a message box <br>
saying:<br>
<br>
&nbsp; &nbsp;&quot;DllRegisterServer in CppShellExtPropSheetHandler.dll succeeded.&quot;<br>
<br>
B. Removal<br>
<br>
In a command prompt running as administrator, navigate to the folder that <br>
contains the build result CppShellExtPropSheetHandler.dll and enter the <br>
command:<br>
<br>
&nbsp; &nbsp;Regsvr32.exe /u CppShellExtPropSheetHandler.dll<br>
<br>
The context menu handler is unregistered successfully if you see a message <br>
box saying:<br>
<br>
&nbsp; &nbsp;&quot;DllUnregisterServer in CppShellExtPropSheetHandler.dll succeeded.&quot;<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
The following steps walk through a demonstration of the property sheet <br>
handler code sample.<br>
<br>
Step1. If you are going use the Shell extension in a x64 Windows system, <br>
please configure the Visual C&#43;&#43; project to target 64-bit platforms using <br>
project configurations (<a href="&lt;a target=" target="_blank">http://msdn.microsoft.com/en-us/library/9yb4317s.aspx).</a>'&gt;<a href="http://msdn.microsoft.com/en-us/library/9yb4317s.aspx)." target="_blank">http://msdn.microsoft.com/en-us/library/9yb4317s.aspx).</a>
<br>
Only 64-bit extension DLLs can be loaded in the 64-bit Windows Shell. If the <br>
extension is to be loaded in a 32-bit Windows system, you can use the default <br>
Win32 project configuration.<br>
<br>
Step2. After you successfully build the sample project in Visual Studio 2010, <br>
you will get a DLL: CppShellExtPropSheetHandler.dll. Start a command prompt <br>
as administrator, navigate to the folder that contains the file and enter the <br>
command:<br>
<br>
&nbsp; &nbsp;Regsvr32.exe CppShellExtPropSheetHandler.dll<br>
<br>
The property sheet handler is registered successfully if you see a message <br>
box saying:<br>
<br>
&nbsp; &nbsp;&quot;DllRegisterServer in CppShellExtPropSheetHandler.dll succeeded.&quot;<br>
<br>
Step3. Find a .cpp file in the Windows Explorer (e.g. FilePropSheetExt.cpp <br>
in the sample folder), and open its Properties dialog. You would see the <br>
&quot;CppShellExtPropSheetHandler&quot; property sheet page in the dialog. The page <br>
displays the name of the selected file. It also has a button &quot;Simulate <br>
Property Changing&quot; to simulate the change of properties that activates the <br>
&quot;Apply&quot; button of the property sheet. <br>
<br>
The &quot;CppShellExtPropSheetHandler&quot; property sheet page is added and displayed <br>
when the Properties dialog is opened for only one .cpp file. If the <br>
Properties dialog is opened for more than one file, you will not see the <br>
property sheet page.<br>
<br>
Step4. In the same command prompt, run the command <br>
<br>
&nbsp; &nbsp;Regsvr32.exe /u CppShellExtPropSheetHandler.dll<br>
<br>
to unregister the Shell context menu handler.<br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
A. Creating and configuring the project<br>
<br>
In Visual Studio 2010, create a Visual C&#43;&#43; / Win32 / Win32 Project named <br>
&quot;CppShellExtPropSheetHandler&quot;. In the &quot;Application Settings&quot; page of Win32 <br>
Application Wizard, select the application type as &quot;DLL&quot; and check the &quot;Empty <br>
project&quot; option. After you click the Finish button, an empty Win32 DLL <br>
project is created.<br>
<br>
-----------------------------------------------------------------------------<br>
<br>
B. Implementing a basic Component Object Model (COM) DLL<br>
<br>
Shell extension handlers are all in-process COM objects implemented as DLLs. <br>
Making a basic COM includes implementing DllGetClassObject, DllCanUnloadNow, <br>
DllRegisterServer, and DllUnregisterServer in (and exporting them from) the <br>
DLL, adding a COM class with the basic implementation of the IUnknown <br>
interface, preparing the class factory for your COM class. The relevant files <br>
in this code sample are:<br>
<br>
&nbsp;dllmain.cpp - implements DllMain and the DllGetClassObject, DllCanUnloadNow,
<br>
&nbsp; &nbsp;DllRegisterServer, DllUnregisterServer functions that are necessary for a
<br>
&nbsp; &nbsp;COM DLL. <br>
<br>
&nbsp;GlobalExportFunctions.def - exports the DllGetClassObject, DllCanUnloadNow,
<br>
&nbsp; &nbsp;DllRegisterServer, DllUnregisterServer functions from the DLL through the
<br>
&nbsp; &nbsp;module-definition file. You need to pass the .def file to the linker by
<br>
&nbsp; &nbsp;configuring the Module Definition File property in the project's Property
<br>
&nbsp; &nbsp;Pages / Linker / Input property page.<br>
<br>
&nbsp;Reg.h/cpp - defines the reusable helper functions to register or unregister
<br>
&nbsp; &nbsp;in-process COM components in the registry: <br>
&nbsp; &nbsp;RegisterInprocServer, UnregisterInprocServer<br>
<br>
&nbsp;FilePropSheetExt.h/cpp - defines the COM class. You can find the basic <br>
&nbsp; &nbsp;implementation of the IUnknown interface in the files.<br>
<br>
&nbsp;ClassFactory.h/cpp - defines the class factory for the COM class. <br>
<br>
-----------------------------------------------------------------------------<br>
<br>
C. Implementing the property sheet handler and registering it for a certain <br>
file class<br>
<br>
-----------<br>
Implementing the property sheet handler:<br>
<br>
The FilePropSheetExt.h/cpp files define a property sheet handler. The <br>
property sheet handler must implement the IShellExtInit and IShellPropSheetExt <br>
interfaces. A property sheet extension is instantiated when the user displays <br>
the property sheet for an object of a class for which the property sheet <br>
extension has been registered in the display specifier of the class.<br>
<br>
&nbsp; &nbsp;class FilePropSheetExt : public IShellExtInit, public IShellPropSheetExt<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp;public:<br>
&nbsp; &nbsp; &nbsp; &nbsp;// IShellExtInit<br>
&nbsp; &nbsp; &nbsp; &nbsp;IFACEMETHODIMP Initialize(LPCITEMIDLIST pidlFolder, LPDATAOBJECT
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;pDataObj, HKEY hKeyProgID);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// IShellPropSheetExt<br>
&nbsp; &nbsp; &nbsp; &nbsp;IFACEMETHODIMP AddPages(LPFNADDPROPSHEETPAGE pfnAddPage, LPARAM lParam);<br>
&nbsp; &nbsp; &nbsp; &nbsp;IFACEMETHODIMP ReplacePage(UINT uPageID, <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;LPFNADDPROPSHEETPAGE pfnReplaceWith, LPARAM lParam);<br>
&nbsp; &nbsp;};<br>
<br>
&nbsp;1. Implementing IShellExtInit<br>
<br>
&nbsp;After the property sheet extension COM object is instantiated, the <br>
&nbsp;IShellExtInit::Initialize method is called. IShellExtInit::Initialize <br>
&nbsp;supplies the property sheet extension with an IDataObject object that <br>
&nbsp;holds one or more file names in CF_HDROP format. You can enumerate the <br>
&nbsp;selected files and folders through the IDataObject object. If any value <br>
&nbsp;other than S_OK is returned from IShellExtInit::Initialize, the property &nbsp;<br>
&nbsp;sheet is not displayed.<br>
<br>
&nbsp;In the code sample, the FileContextMenuExt::Initialize method enumerates <br>
&nbsp;the selected files and folders. If only one file is selected, the method <br>
&nbsp;stores the file name for later use and returns S_OK to proceed. If more <br>
&nbsp;than one file or no file are selected, the method returns E_FAIL to not <br>
&nbsp;display the property sheet.<br>
<br>
&nbsp;2. Implementing IShellPropSheetExt<br>
<br>
&nbsp;After IShellExtInit::Initialize returns S_OK, the <br>
&nbsp;IShellPropSheetExt::AddPages method is called. The property sheet <br>
&nbsp;extension must add the page or pages during this method. A property page is
<br>
&nbsp;created by filling a PROPSHEETPAGE structure and then passing the structure
<br>
&nbsp;to the CreatePropertySheetPage function. The property page is then added to
<br>
&nbsp;the property sheet by calling the callback function passed to <br>
&nbsp;IShellPropSheetExt::AddPages in the pfnAddPage parameter. The callback <br>
&nbsp;returns a BOOL indicating success or failure. If it fails, we destroy the <br>
&nbsp;page by calling DestroyPropertySheetPage.<br>
<br>
&nbsp;While setting up the PROPSHEETPAGE struct, you can specify two call-backs: <br>
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
&nbsp;If any value other than S_OK is returned from IShellPropSheetExt::AddPages,
<br>
&nbsp;the property sheet is not displayed.<br>
<br>
&nbsp;If the property sheet extension is not required to add any pages to the <br>
&nbsp;property sheet, it should not call the callback function passed to <br>
&nbsp;IShellPropSheetExt::AddPages in the pfnAddPage parameter.<br>
<br>
&nbsp;The IShellPropSheetExt::ReplacePage method is not used.<br>
<br>
-----------<br>
Passing the extension object to the property page.<br>
<br>
The property sheet extension object is independent from the property page. In <br>
many cases, it is desirable to be able to use the extension object, or some <br>
other object, from the property page. To do this, set the lParam member of <br>
PROPSHEETPAGE structure to the object pointer. The property page can then <br>
retrieve this value when it processes the WM_INITDIALOG message. For a <br>
property page, the lParam parameter of the WM_INITDIALOG message is a pointer <br>
to the PROPSHEETPAGE structure. Retrieve the object pointer by casting the <br>
lParam of the WM_INITDIALOG message to a PROPSHEETPAGE pointer and then <br>
retrieving the lParam member of the PROPSHEETPAGE structure.<br>
<br>
&nbsp; &nbsp;INT_PTR CALLBACK FilePropPageDlgProc(HWND hWnd, UINT uMsg, WPARAM wParam,
<br>
&nbsp; &nbsp; &nbsp; &nbsp;LPARAM lParam)<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;switch (uMsg)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;case WM_INITDIALOG:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Get the pointer to the property sheet page object. This is
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// contained in the LPARAM of the PROPSHEETPAGE structure.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;LPPROPSHEETPAGE pPage = reinterpret_cast&lt;LPPROPSHEETPAGE&gt;(lParam);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (pPage != NULL)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Access the property sheet extension from property page.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;FilePropSheetExt *pExt = reinterpret_cast&lt;FilePropSheetExt *&gt;(pPage-&gt;lParam);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (pExt != NULL)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Access the property sheet extension from property page<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// ...<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Store the object pointer with this particular page dialog.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;SetProp(hWnd, EXT_POINTER_PROP, static_cast&lt;HANDLE&gt;(pExt));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return TRUE;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;...<br>
&nbsp; &nbsp;}<br>
<br>
By storing the pointer to the extension object as a property of the dialog <br>
window, <br>
<br>
&nbsp; &nbsp;// Store the object pointer with this particular page dialog.<br>
&nbsp; &nbsp;SetProp(hWnd, EXT_POINTER_PROP, static_cast&lt;HANDLE&gt;(pExt));<br>
<br>
we can retrieve and access the extension object in the dialog procedure. <br>
<br>
&nbsp; &nbsp;// In FilePropPageDlgProc<br>
&nbsp; &nbsp;FilePropSheetExt *pExt = static_cast&lt;FilePropSheetExt *&gt;(<br>
&nbsp; &nbsp; &nbsp; &nbsp;GetProp(hWnd, EXT_POINTER_PROP));<br>
<br>
Remember to remove the property when the property sheet page is being <br>
destroied.<br>
<br>
&nbsp; &nbsp;// In FilePropPageDlgProc<br>
&nbsp; &nbsp;case WM_DESTROY:<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;RemoveProp(hWnd, EXT_POINTER_PROP);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return TRUE;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
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
&nbsp; &nbsp;IFACEMETHODIMP FilePropSheetExt::AddPages(LPFNADDPROPSHEETPAGE pfnAddPage,
<br>
&nbsp; &nbsp; &nbsp; &nbsp;LPARAM lParam)<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;...<br>
&nbsp; &nbsp; &nbsp; &nbsp;HPROPSHEETPAGE hPage = CreatePropertySheetPage(&amp;psp);<br>
&nbsp; &nbsp; &nbsp; &nbsp;...<br>
&nbsp; &nbsp; &nbsp; &nbsp;if (pfnAddPage(hPage, lParam))<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this-&gt;AddRef();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;...<br>
&nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp;UINT CALLBACK FilePropPageCallbackProc(HWND hWnd, UINT uMsg, LPPROPSHEETPAGE ppsp)<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;switch(uMsg)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;...<br>
&nbsp; &nbsp; &nbsp; &nbsp;case PSPCB_RELEASE:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;FilePropSheetExt *pExt = reinterpret_cast&lt;FilePropSheetExt *&gt;(ppsp-&gt;lParam);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (pExt != NULL)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;pExt-&gt;Release();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;break;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;return FALSE;<br>
&nbsp; &nbsp;}<br>
<br>
-----------<br>
Registering the handler for a certain file class:<br>
<br>
The CLSID of the handler is declared at the beginning of dllmain.cpp.<br>
<br>
// {5C8FA94F-F274-49B9-A5E5-D34C093F7846}<br>
const CLSID CLSID_FilePropSheetExt = <br>
{ 0x5C8FA94F, 0xF274, 0x49B9, { 0xA5, 0xE5, 0xD3, 0x4C, 0x09, 0x3F, 0x78, 0x46 } };<br>
<br>
When you write your own handler, you must create a new CLSID by using the <br>
&quot;Create GUID&quot; tool in the Tools menu, and specify the CLSID value here.<br>
<br>
Property sheet handlers can be associated with a file class by <br>
registering them under the following registry key.<br>
<br>
&nbsp; &nbsp;HKEY_CLASSES_ROOT\&lt;File Type&gt;\shellex\PropertySheetHandlers<br>
<br>
The registration of the property sheet handler is implemented in the <br>
DllRegisterServer function of dllmain.cpp. DllRegisterServer first calls the <br>
RegisterInprocServer function in Reg.h/cpp to register the COM component. <br>
Next, it calls RegisterShellExtPropSheetHandler to associate the handler <br>
with a certain file type. If the file type starts with '.', try to read the <br>
default value of the HKCR\&lt;File Type&gt; key which may contain the Program ID to
<br>
which the file type is linked. If the default value is not empty, use the <br>
Program ID as the file type to proceed the registration. <br>
<br>
For example, this code sample associates the handler with '.cpp' files. <br>
HKCR\.cpp has the default value 'VisualStudio.cpp.10.0' by default when <br>
Visual Studio 2010 is installed, so we proceed to register the handler under <br>
HKCR\VisualStudio.cpp.10.0\ instead of under HKCR\.cpp. The following keys <br>
and values are added in the registration process of the sample handler. <br>
<br>
&nbsp; &nbsp;HKCR<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;NoRemove CLSID<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ForceRemove {5C8FA94F-F274-49B9-A5E5-D34C093F7846} =
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;s 'CppShellExtPropSheetHandler.FilePropSheetExt Class'<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;InprocServer32 = s '&lt;Path of CppShellExtPropSheetHandler.DLL file&gt;'<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;val ThreadingModel = s 'Apartment'<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;NoRemove .cpp = s 'VisualStudio.cpp.10.0'<br>
&nbsp; &nbsp; &nbsp; &nbsp;NoRemove VisualStudio.cpp.10.0<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;NoRemove shellex<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;NoRemove PropertySheetHandlers<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{5C8FA94F-F274-49B9-A5E5-D34C093F7846} =
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;s 'CppShellExtPropSheetHandler.FilePropSheetExt'<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;}<br>
<br>
The unregistration is implemented in the DllUnregisterServer function of <br>
dllmain.cpp. It removes the HKCR\CLSID\{&lt;CLSID&gt;} key and the {&lt;CLSID&gt;} key
<br>
under HKCR\&lt;File Type&gt;\shellex\PropertySheetHandlers.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Initializing Shell Extensions<br>
<a href="http://msdn.microsoft.com/en-us/library/cc144105.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/cc144105.aspx</a><br>
<br>
MSDN: Creating Property Sheet Handlers<br>
<a href="http://msdn.microsoft.com/en-us/library/bb776850.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/bb776850.aspx</a><br>
<br>
MSDN: Implementing the Property Page COM Object<br>
<a href="http://msdn.microsoft.com/en-us/library/ms677109.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/ms677109.aspx</a><br>
<br>
The Complete Idiot's Guide to Writing Shell Extensions - Part V<br>
<a href="http://www.codeproject.com/KB/shell/shellextguide5.aspx" target="_blank">http://www.codeproject.com/KB/shell/shellextguide5.aspx</a><br>
<br>
Devices and Printers Folder - Extensibility Guide<br>
<a href="http://www.microsoft.com/whdc/device/DeviceExperience/DevPrintFolder-Ext.mspx" target="_blank">http://www.microsoft.com/whdc/device/DeviceExperience/DevPrintFolder-Ext.mspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

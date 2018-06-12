# C++ Windows Shell context menu handler (CppShellExtContextMenuHandler)
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
* 2012-01-15 07:23:40
## Description

<p style="font-family:Courier New">&nbsp;</p>
<h2>DYNAMIC LINK LIBRARY : CppShellExtContextMenuHandler Project Overview</h2>
<p style="font-family:Courier New">&nbsp;</p>
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
<a href="&lt;a target=" target="_blank">http://msdn.microsoft.com/en-us/library/dd758091.aspx</a>'&gt;<a href="http://msdn.microsoft.com/en-us/library/dd758091.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/dd758091.aspx</a><br>
<br>
The example context menu handler has the class ID (CLSID): <br>
&nbsp; &nbsp;{BFD98515-CD74-48A4-98E2-13D209E3EE4F}<br>
<br>
It adds the menu item &quot;Display File Name (C&#43;&#43;)&quot; with icon to the context menu <br>
when you right-click a .cpp file in the Windows Explorer. Clicking the menu <br>
item brings up a message box that displays the full path of the .cpp file.<br>
<br>
</p>
<h3>Setup and Removal:</h3>
<p style="font-family:Courier New"><br>
A. Setup<br>
<br>
If you are going to use the Shell extension in a x64 Windows system, please <br>
configure the Visual C&#43;&#43; project to target 64-bit platforms using project <br>
configurations (<a href="&lt;a target=" target="_blank">http://msdn.microsoft.com/en-us/library/9yb4317s.aspx).</a>'&gt;<a href="http://msdn.microsoft.com/en-us/library/9yb4317s.aspx)." target="_blank">http://msdn.microsoft.com/en-us/library/9yb4317s.aspx).</a>
 Only <br>
64-bit extension DLLs can be loaded in the 64-bit Windows Shell. <br>
<br>
If the extension is to be loaded in a 32-bit Windows system, you can use the <br>
default Win32 project configuration to build the project.<br>
<br>
In a command prompt running as administrator, navigate to the folder that <br>
contains the build result CppShellExtContextMenuHandler.dll and enter the <br>
command:<br>
<br>
&nbsp; &nbsp;Regsvr32.exe CppShellExtContextMenuHandler.dll<br>
<br>
The context menu handler is registered successfully if you see a message box <br>
saying:<br>
<br>
&nbsp; &nbsp;&quot;DllRegisterServer in CppShellExtContextMenuHandler.dll succeeded.&quot;<br>
<br>
B. Removal<br>
<br>
In a command prompt running as administrator, navigate to the folder that <br>
contains the build result CppShellExtContextMenuHandler.dll and enter the <br>
command:<br>
<br>
&nbsp; &nbsp;Regsvr32.exe /u CppShellExtContextMenuHandler.dll<br>
<br>
The context menu handler is unregistered successfully if you see a message <br>
box saying:<br>
<br>
&nbsp; &nbsp;&quot;DllUnregisterServer in CppShellExtContextMenuHandler.dll succeeded.&quot;<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
The following steps walk through a demonstration of the context menu handler <br>
code sample.<br>
<br>
Step1. If you are going to use the Shell extension in a x64 Windows system, <br>
please configure the Visual C&#43;&#43; project to target 64-bit platforms using <br>
project configurations (<a href="&lt;a target=" target="_blank">http://msdn.microsoft.com/en-us/library/9yb4317s.aspx).</a>'&gt;<a href="http://msdn.microsoft.com/en-us/library/9yb4317s.aspx)." target="_blank">http://msdn.microsoft.com/en-us/library/9yb4317s.aspx).</a>
<br>
Only 64-bit extension DLLs can be loaded in the 64-bit Windows Shell. <br>
<br>
If the extension is to be loaded in a 32-bit Windows system, you can use the <br>
default Win32 project configuration.<br>
<br>
Step2. After you successfully build the sample project in Visual Studio 2010, <br>
you will get a DLL: CppShellExtContextMenuHandler.dll. Start a command prompt <br>
as administrator, navigate to the folder that contains the file and enter the <br>
command:<br>
<br>
&nbsp; &nbsp;Regsvr32.exe CppShellExtContextMenuHandler.dll<br>
<br>
The context menu handler is registered successfully if you see a message box <br>
saying:<br>
<br>
&nbsp; &nbsp;&quot;DllRegisterServer in CppShellExtContextMenuHandler.dll succeeded.&quot;<br>
<br>
Step3. Find a .cpp file in the Windows Explorer (e.g. FileContextMenuExt.cpp <br>
in the sample folder), and right click it. You would see the &quot;Display File <br>
Name (C&#43;&#43;)&quot; menu item with icon in the context menu and a menu seperator <br>
below it. Clicking the menu item brings up a message box that displays the <br>
full path of the .cpp file.<br>
<br>
The &quot;Display File Name (C&#43;&#43;)&quot; menu item is added and displayed when only one <br>
.cpp file is selected and right-clicked. If more than one file are selected <br>
in the Windows Explorer, you will not see the context menu item.<br>
<br>
Step4. In the same command prompt, run the command <br>
<br>
&nbsp; &nbsp;Regsvr32.exe /u CppShellExtContextMenuHandler.dll<br>
<br>
to unregister the Shell context menu handler.<br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
A. Creating and configuring the project<br>
<br>
In Visual Studio 2010, create a Visual C&#43;&#43; / Win32 / Win32 Project named <br>
&quot;CppShellExtContextMenuHandler&quot;. In the &quot;Application Settings&quot; page of Win32 <br>
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
&nbsp;FileContextMenuExt.h/cpp - defines the COM class. You can find the basic <br>
&nbsp; &nbsp;implementation of the IUnknown interface in the files.<br>
<br>
&nbsp;ClassFactory.h/cpp - defines the class factory for the COM class. <br>
<br>
-----------------------------------------------------------------------------<br>
<br>
C. Implementing the context menu handler and registering it for a certain <br>
file class<br>
<br>
-----------<br>
Implementing the context menu handler:<br>
<br>
The FileContextMenuExt.h/cpp files define a context menu handler. The <br>
context menu handler must implement the IShellExtInit and IContextMenu <br>
interfaces. A context menu extension is instantiated when the user displays <br>
the context menu for an object of a class for which the context menu handler <br>
has been registered.<br>
<br>
&nbsp; &nbsp;class FileContextMenuExt : public IShellExtInit, public IContextMenu<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp;public:<br>
&nbsp; &nbsp; &nbsp; &nbsp;// IShellExtInit<br>
&nbsp; &nbsp; &nbsp; &nbsp;IFACEMETHODIMP Initialize(LPCITEMIDLIST pidlFolder, LPDATAOBJECT
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;pDataObj, HKEY hKeyProgID);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// IContextMenu<br>
&nbsp; &nbsp; &nbsp; &nbsp;IFACEMETHODIMP QueryContextMenu(HMENU hMenu, UINT indexMenu,
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;UINT idCmdFirst, UINT idCmdLast, UINT uFlags);<br>
&nbsp; &nbsp; &nbsp; &nbsp;IFACEMETHODIMP InvokeCommand(LPCMINVOKECOMMANDINFO pici);<br>
&nbsp; &nbsp; &nbsp; &nbsp;IFACEMETHODIMP GetCommandString(UINT_PTR idCommand, UINT uFlags,
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;UINT *pwReserved, LPSTR pszName, UINT cchMax);<br>
&nbsp; &nbsp;};<br>
&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;1. Implementing IShellExtInit<br>
<br>
&nbsp;After the context menu extension COM object is instantiated, the <br>
&nbsp;IShellExtInit::Initialize method is called. IShellExtInit::Initialize <br>
&nbsp;supplies the context menu extension with an IDataObject object that <br>
&nbsp;holds one or more file names in CF_HDROP format. You can enumerate the <br>
&nbsp;selected files and folders through the IDataObject object. If any value <br>
&nbsp;other than S_OK is returned from IShellExtInit::Initialize, the context <br>
&nbsp;menu extension will not be used.<br>
<br>
&nbsp;In the code sample, the FileContextMenuExt::Initialize method enumerates <br>
&nbsp;the selected files and folders. If only one file is selected, the method <br>
&nbsp;stores the file name for later use and returns S_OK to proceed. If more <br>
&nbsp;than one file or no file are selected, the method returns E_FAIL to not use
<br>
&nbsp;the context menu extension.<br>
<br>
&nbsp;2. Implementing IContextMenu<br>
<br>
&nbsp;After IShellExtInit::Initialize returns S_OK, the <br>
&nbsp;IContextMenu::QueryContextMenu method is called to obtain the menu item or <br>
&nbsp;items that the context menu extension will add. The QueryContextMenu <br>
&nbsp;implementation is fairly straightforward. The context menu extension adds <br>
&nbsp;its menu items using the InsertMenuItem or similar functions. The menu <br>
&nbsp;command identifiers must be greater than or equal to idCmdFirst and must be
<br>
&nbsp;less than idCmdLast. QueryContextMenu must return the greatest numeric <br>
&nbsp;identifier added to the menu plus one. The best way to assign menu command <br>
&nbsp;identifiers is to start at zero and work up in sequence. If the context <br>
&nbsp;menu extension does not need to add any items to the menu, it should simply
<br>
&nbsp;return zero from QueryContextMenu.<br>
<br>
&nbsp;In this code sample, we insert the menu item &quot;Display File Name (C&#43;&#43;)&quot; with
<br>
&nbsp;an icon, and add a menu seperator below it.<br>
<br>
&nbsp;IContextMenu::GetCommandString is called to retrieve textual data for the <br>
&nbsp;menu item, such as help text to be displayed for the menu item. If a user <br>
&nbsp;highlights one of the items added by the context menu handler, the handler's
<br>
&nbsp;IContextMenu::GetCommandString method is called to request a Help text <br>
&nbsp;string that will be displayed on the Windows Explorer status bar. This <br>
&nbsp;method can also be called to request the verb string that is assigned to a <br>
&nbsp;command. Either ANSI or Unicode verb strings can be requested. This example
<br>
&nbsp;only implements support for the Unicode values of uFlags, because only <br>
&nbsp;those have been used in Windows Explorer since Windows 2000.<br>
<br>
&nbsp;IContextMenu::InvokeCommand is called when one of the menu items installed <br>
&nbsp;by the context menu extension is selected. The context menu performs or <br>
&nbsp;initiates the desired actions in response to this method.<br>
<br>
-----------<br>
Registering the handler for a certain file class:<br>
<br>
The CLSID of the handler is declared at the beginning of dllmain.cpp.<br>
<br>
// {BFD98515-CD74-48A4-98E2-13D209E3EE4F}<br>
const CLSID CLSID_FileContextMenuExt = <br>
{ 0xBFD98515, 0xCD74, 0x48A4, { 0x98, 0xE2, 0x13, 0xD2, 0x09, 0xE3, 0xEE, 0x4F } };<br>
<br>
When you write your own handler, you must create a new CLSID by using the <br>
&quot;Create GUID&quot; tool in the Tools menu, and specify the CLSID value here.<br>
<br>
Context menu handlers are associated with either a file class or a folder. <br>
For file classes, the handler is registered under the following subkey.<br>
<br>
&nbsp; &nbsp;HKEY_CLASSES_ROOT\&lt;File Type&gt;\shellex\ContextMenuHandlers<br>
<br>
The registration of the context menu handler is implemented in the <br>
DllRegisterServer function of dllmain.cpp. DllRegisterServer first calls the <br>
RegisterInprocServer function in Reg.h/cpp to register the COM component. <br>
Next, it calls RegisterShellExtContextMenuHandler to associate the handler <br>
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
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ForceRemove {BFD98515-CD74-48A4-98E2-13D209E3EE4F} =
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;s 'CppShellExtContextMenuHandler.FileContextMenuExt Class'<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;InprocServer32 = s '&lt;Path of CppShellExtContextMenuHandler.DLL file&gt;'<br>
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
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;NoRemove ContextMenuHandlers<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{BFD98515-CD74-48A4-98E2-13D209E3EE4F} =
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;s 'CppShellExtContextMenuHandler.FileContextMenuExt'<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;}<br>
<br>
The unregistration is implemented in the DllUnregisterServer function of <br>
dllmain.cpp. It removes the HKCR\CLSID\{&lt;CLSID&gt;} key and the {&lt;CLSID&gt;} key
<br>
under HKCR\&lt;File Type&gt;\shellex\ContextMenuHandlers.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
MSDN: Initializing Shell Extensions<br>
<a href="http://msdn.microsoft.com/en-us/library/cc144105.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/cc144105.aspx</a><br>
<br>
MSDN: Creating Context Menu Handlers<br>
<a href="http://msdn.microsoft.com/en-us/library/bb776881.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/bb776881.aspx</a><br>
<br>
MSDN: Implementing the Context Menu COM Object<br>
<a href="http://msdn.microsoft.com/en-us/library/ms677106.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/ms677106.aspx</a><br>
<br>
MSDN: Extending Shortcut Menus<br>
<a href="http://msdn.microsoft.com/en-us/library/cc144101.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/cc144101.aspx</a><br>
<br>
MSDN: Choosing a Static or Dynamic Shortcut Menu Method<br>
<a href="&lt;a target=" target="_blank">http://msdn.microsoft.com/en-us/library/dd758091.aspx</a>'&gt;<a href="http://msdn.microsoft.com/en-us/library/dd758091.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/dd758091.aspx</a><br>
<br>
The Complete Idiot's Guide to Writing Shell Extensions<br>
<a href="http://www.codeproject.com/KB/shell/shellextguide1.aspx" target="_blank">http://www.codeproject.com/KB/shell/shellextguide1.aspx</a><br>
<a href="http://www.codeproject.com/KB/shell/shellextguide2.aspx" target="_blank">http://www.codeproject.com/KB/shell/shellextguide2.aspx</a><br>
<a href="http://www.codeproject.com/KB/shell/shellextguide7.aspx" target="_blank">http://www.codeproject.com/KB/shell/shellextguide7.aspx</a><br>
<br>
How to Use Submenus in a Context Menu Shell Extension<br>
<a href="http://www.codeproject.com/KB/shell/ctxextsubmenu.aspx" target="_blank">http://www.codeproject.com/KB/shell/ctxextsubmenu.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

================================================================================
       Windows APPLICATION: CSIEToolbarButton Overview                        
===============================================================================
/////////////////////////////////////////////////////////////////////////////
Summary:
The sample demonstrates how to create and deploy an IE Toolbar button and menu item.

When you click an IE Toolbar button or menu item, IE can
1. Implement the Exec method of the COM object.
2. Run a script.
3. Run an executable file.


/////////////////////////////////////////////////////////////////////////////
Setup and Removal:

--------------------------------------
In the Development Environment

A. Setup

For 32bit IE on x86 or x64 OS, run 'Visual Studio Command Prompt (2010)' in the 
Microsoft Visual Studio 2010 \ Visual Studio Tools menu as administrator. For 64bit
IE on x64 OS, run Visual Studio x64 Win64 Command Prompt (2010).

Navigate to the folder that contains the build result CSIEToolbarButton.dll and 
enter the command:

    Regasm.exe CSIEToolbarButton.dll /codebase

The Toolbar button is registered successfully if the command prints:
    "Types registered successfully"

B. Removal

For 32bit IE on x86 or x64 OS, run 'Visual Studio Command Prompt (2010)' in the 
Microsoft Visual Studio 2010 \ Visual Studio Tools menu as administrator. For 64bit
IE on x64 OS, run Visual Studio x64 Win64 Command Prompt (2010).

Navigate to the folder that contains the build result CSIEToolbarButton.dll and 
enter the command:

    Regasm.exe CSIEToolbarButton.dll /unregister

The Toolbar button is unregistered successfully if the command prints:

    "Types un-registered successfully"

--------------------------------------
In the Deployment Environment

A. Setup

For 32bit IE on x86 or x64 OS, install CSIEToolbarButtonSetup(x86).msi, the output
of the CSIEToolbarButtonSetup(x86) setup project.

For 64bit IE on x64 OS, install CSIEToolbarButtonSetup(x64).msi outputted by the 
CSIEToolbarButtonSetup(x64) setup project.

B. Removal

For 32bit IE on x86 or x64 OS, uninstall CSIEToolbarButtonSetup(x86).msi, the 
output of the CSIEToolbarButtonSetup(x86) setup project. 

For 64bit IE on x64 OS, uninstall CSIEToolbarButtonSetup(x64).msi, the output of
the CSIEToolbarButtonSetup(x64) setup project.



////////////////////////////////////////////////////////////////////////////////
Demo:
 
Step1. Open this project in VS2010 and set the platform of the solution to x86. Make
       sure that the projects CSIEToolbarButton and CSIEToolbarButtonSetup(x86)
	   are selected to build in Configuration Manager.

	   NOTE: If you want to use this Toolbar button in 64bit IE, set the platform to x64 and 
	         select CSIEToolbarButton and CSIEToolbarButtonSetup(x64) to build.
        
Step2. Build the solution.
 
Step3. Right click the project CSIEToolbarButtonSetup(x86) in Solution Explorer, 
       and choose "Install".

	   After the installation, open 32bit IE and click Tools=>Manage Add-ons, in the 
	   Manage Add-ons dialog, you can find 
	   1. The item "Note Pad" in Browser Extension group.
	   2. A new button "Note Pad" on the IE toolbar (command bar).
	   3. A menu item "Note Pad" in IE Tools menu.
	   You may have to restart IE to make it take effect. 

	   NOTE: You can also use the Regasm command in the "Setup and Removal" section.
 
Step4. Open IE and visit http://www.microsoft.com/. After the page was loaded 
       completely, then click button "Note Pad" on the IE toolbar (command bar) or 
	   the menu item "Note Pad" in IE Tools menu, you will see:
	   1. IE shows a dialog "Images in the page " which list all the image links in 
	      this page. Click OK.
	   2. IE shows a "Message from webpage" dialog which asks you whether "Copy image
	      links on this page to clipboard". Click OK.
	   3. IE shows a Message from webpage" dialog which tells you that "Use Crtl+V to 
	      paste the links to the NotePad.". Click OK.
	   4. NotePad.exe is launched, press "Ctrl+V", all the 	image links in this page 
	      will be pasted to it.	  

/////////////////////////////////////////////////////////////////////////////
Implementation:

A. Create the project and add references

In Visual Studio 2010, create a Visual C# / Windows / Class Library project 
named "CSIEToolbarButton". 

Right click the project in Solution Explorer and choose "Add Reference". Add
"Microsoft HTML Object Library" and "Microsoft Internet Controls" in COM tab.
-----------------------------------------------------------------------------

B. Implement a basic Component Object Model (COM) DLL

A Toolbar button is a COM object implemented as a DLL. Making a basic 
.NET COM component is very straightforward. You just need to define a 
'public' class with ComVisible(true), use the Guid attribute to specify its 
CLSID, and explicitly implements certain COM interfaces. For example, 

    [ClassInterface(ClassInterfaceType.None)]
    [Guid("69FA02A4-19BE-4C49-8D8F-E284E6B01363"), ComVisible(true)]
    public class SimpleObject : ISimpleObject
    {
        ... // Implements the interface
    }

You even do not need to implement IUnknown and class factory by yourself 
because .NET Framework handles them for you.

-----------------------------------------------------------------------------

C. Implement the Toolbar button and registering it for a certain file class

-----------
Implement the preview handler:

The NotePadToolbarButton.cs file defines the Toolbar button. 

The GuidAttribute is attached to the NotePadToolbarButton class to specify 
its CLSID. When you write your own handler, you must create a new CLSID by 
using the "Create GUID" tool in the Tools menu for ToolbarButton class, 
and specify the value in the Guid attribute. 

    ...
    [ComVisible(true)]
    [Guid("c0e8ae32-0758-4c8d-ab71-23b361fe8964")]
    public class NotePadToolbarButton : ...

The class also implements the interface IObjectWithSite. In the SetSite method, you 
can get an instance implemented the interface InternetExplorer. n order to invoke 
a Component Object Model (COM) object from Internet Explorer, it must implement 
IOleCommandTarget. 

    

-----------
Register the Toolbar Button:

The registration and unregistration logic of the  Toolbar Button are also implemented in 
this class. To register it, 
1. Create a new key (using the GUID as the name) in the registry under: 
  HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}
  {GUID} is the valid GUID that you created in step 1.

2. Create the following string values in the registry under the new key:

  ButtonText - Set the value to the label you want for the toolbar button.
  HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\ButtonText
  
  HotIcon - Set the full path of the .ico file that contains the three color icons.
  HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\HotIcon
  
  Icon - Set the full path of the .ico file that contains the three grayscale icons.
  HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\Icon

  Default Visible - To make the toolbar button to appear on the Internet Explorer toolbar 
  by default, set Default Visible to "Yes", otherwise set Default Visible to "No". 
  HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\Default Visible

  MenuText - This is the text you want to be displayed in the menu. This text does not support 
  any underlining of characters for shortcut keys, because there is no way to prevent conflicts. 
  HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\MenuText

  MenuCustomize - Set the value to "help" to have the menu item appear in the Help menu. If
  this string value doesn't exist or is set to something other than "help", the menu item will 
  appear in the Tools menu. 
  HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\MenuCustomize

  MenuStatusBar - This is the text you want displayed in the status bar when the menu item 
  is highlighted. This text should describe what the script associated with this menu item will do. 
  HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\MenuStatusBar

3. The following register key values are required to complete the creation of a toolbar button
  that implements a COM object.
  
  CLSID - set the value equal to {1FBA04EE-3024-11d2-8F1F-0000F87ABD16}. This value indicates 
  that the extension is of the CLSID_Shell_ToolbarExtExec class. 
  HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\CLSID

  ClsidExtension - Set the value of ClsidExtension equal to the GUID of the COM object.
  HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\ClsidExtension   

4. The following register key values are required to complete the creation of a toolbar button that 
  runs a script.
  
  CLSID - set the value equal to {1FBA04EE-3024-11d2-8F1F-0000F87ABD16}. This value indicates 
  that the extension is of the CLSID_Shell_ToolbarExtExec class. 
  HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\CLSID
  
  Script - Set the value of Script to the full path of the script to run.
  HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\Script

5. The following register key values are required to complete the creation of a toolbar button that 
  runs an executable file.
  
  CLSID - set the value equal to {1FBA04EE-3024-11d2-8F1F-0000F87ABD16}. This value indicates 
  that the extension is of the CLSID_Shell_ToolbarExtExec class. 
  HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\CLSID
  
  Exec - Set the value of Exec to the full path of the .exe file to run.
  HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\Exec


-----------------------------------------------------------------------------

D. Deploying the Toolbar Button with a setup project.

  (1) In IEToolbarButton, add an Installer class (named IEToolbarButtonInstaller in this 
   code sample) to define the custom actions in the setup. The class derives from
   System.Configuration.Install.Installer. We use the custom actions to 
   register/unregister the COM-visible classes in the current managed assembly
   when user installs/uninstalls the component. 

    [RunInstaller(true), ComVisible(false)]
    public partial class IEToolbarButtonInstaller : Installer
    {
        public IEToolbarButtonInstaller()
        {         
          InitializeComponent();         
        }
        
        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
           
            RegistrationServices regsrv = new RegistrationServices();
            if (!regsrv.RegisterAssembly(this.GetType().Assembly,
            AssemblyRegistrationFlags.SetCodeBase))
            {
                throw new InstallException("Failed To Register for COM");
            }
        }
         
        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            base.Uninstall(savedState);
            RegistrationServices regsrv = new RegistrationServices();
            if (!regsrv.UnregisterAssembly(this.GetType().Assembly))
            {
                throw new InstallException("Failed To Unregister for COM");
            }
        }   
    }

  In the overriden Install method, we use RegistrationServices.RegisterAssembly 
  to register the classes in the current managed assembly to enable creation 
  from COM. The method also invokes the static method marked with 
  ComRegisterFunctionAttribute to perform the custom COM registration steps. 
  The call is equivalent to running the command: 
  
    "Regasm.exe CSIEToolbarButton.dll /codebase"

  in the development environment. 

  (2) To add a deployment project, on the File menu, point to Add, and then 
  click New Project. In the Add New Project dialog box, expand the Other 
  Project Types node, expand the Setup and Deployment Projects, click Visual 
  Studio Installer, and then click Setup Project. In the Name box, type 
  CSIEToolbarButtonSetup(x86). Click OK to create the project. 
  In the Properties dialog of the setup project, make sure that the 
  TargetPlatform property is set to x86. This setup project is to be deployed 
  for 32bit IE on x86 or x64 Windows operating systems. 

  Right-click the setup project, and choose Add / Project Output ... 
  In the Add Project Output Group dialog box, CSIEToolbarButton will  
  be displayed in the Project list. Select Primary Output and click OK. VS
  will detect the dependencies of the CSIEToolbarButton, including .NET
  Framework 4.0 (Client Profile).

  Right-click the setup project again, and choose View / Custom Actions. 
  In the Custom Actions Editor, right-click the root Custom Actions node. On 
  the Action menu, click Add Custom Action. In the Select Item in Project 
  dialog box, double-click the Application Folder. Select Primary output from 
  CSIEToolbarButton. This adds the custom actions that we defined 
  in BHOInstaller of CSIEToolbarButton. 

  Build the setup project. If the build succeeds, you will get a .msi file 
  and a Setup.exe file. You can distribute them to your users to install or 
  uninstall this BHO. 

  (3) To deploy the Toolbar Button for 64bit IE on a x64 operating system, you 
  must create a new setup project (e.g. CSIEToolbarButtonSetup(x64) 
  in this code sample), and set its TargetPlatform property to x64. 

  Although the TargetPlatform property is set to x64, the native shim 
  packaged with the .msi file is still a 32-bit executable. The Visual Studio 
  embeds the 32-bit version of InstallUtilLib.dll into the Binary table as 
  InstallUtil. So the custom actions will be run in the 32-bit, which is 
  unexpected in this code sample. To workaround this issue and ensure that 
  the custom actions run in the 64-bit mode, you either need to import the 
  appropriate bitness of InstallUtilLib.dll into the Binary table for the 
  InstallUtil record or - if you do have or will have 32-bit managed custom 
  actions add it as a new record in the Binary table and adjust the 
  CustomAction table to use the 64-bit Binary table record for 64-bit managed 
  custom actions. This blog article introduces how to do it manually with 
  Orca http://blogs.msdn.com/b/heaths/archive/2006/02/01/64-bit-managed-custom-actions-with-visual-studio.aspx

  In this code sample, we automate the modification of InstallUtil by using a 
  post-build javascript: Fix64bitInstallUtilLib.js. You can find the script 
  file in the CSIEToolbarButtonSetup(x64) project folder. To 
  configure the script to run in the post-build event, you select the 
  CSIEToolbarButtonSetup(x64) project in Solution Explorer, and 
  find the PostBuildEvent property in the Properties window. Specify its 
  value to be 
  
	"$(ProjectDir)Fix64bitInstallUtilLib.js" "$(BuiltOuputPath)" "$(ProjectDir)"

  Repeat the rest steps in (2) to add the project output, set the custom 
  actions, configure the prerequisites, and build the setup project.


/////////////////////////////////////////////////////////////////////////////
Diagnostic:

To debug Toolbar Button, you can attach to iexplorer.exe. 



///////////////////////////////////////////////////////////////////////////// 
 
References:

Adding Toolbar Buttons
http://msdn.microsoft.com/en-us/library/aa753588(VS.85).aspx

Creating Add-ons for Internet Explorer: Toolbar Buttons
http://msdn.microsoft.com/en-us/library/bb735854(VS.85).aspx

IOleCommandTarget Interface
http://msdn.microsoft.com/en-us/library/ms683797(VS.85).aspx

Mouse event handling problem in BHO
http://social.msdn.microsoft.com/Forums/en/ieextensiondevelopment/thread/1ea154a5-5802-460c-9941-30f14b36d0a4

/////////////////////////////////////////////////////////////////////////////


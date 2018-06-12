/****************************** Module Header ******************************\
 Module Name:  NotePadToolbarButton.cs
 Project:      CSIEToolbarButton
 Copyright (c) Microsoft Corporation.
 
 To add a button to IE toolbar and menu, you can follow these steps:
 
 1. Create a valid GUID for this ComVisible class. 
 
 2. Implement the IObjectWithSite and IOleCommandTarget interfaces.  
   
   In order to invoke a Component Object Model (COM) object from Internet Explorer, 
   it must implement IOleCommandTarget. Only one command is supported per object; 
   the COM object's IOleCommandTarget.Exec is always called with nCmdID=0 and with 
   VARIANT arguments set to NULL. Additionally, the implementation of 
   IOleCommandTarget.QueryStatus is always called with cCmds=1.

   If the COM object needs to access the browser or Dynamic HTML (DHTML) Object Model 
   of the active page, it must implement IObjectWithSite. Internet Explorer calls 
   IObjectWithSite.SetSite with a pointer to IShellBrowser.
 
 3. Register this assembly to COM.
    
    Use RegistrationServices to register this assembly in the IEToolbarButtonInstaller
    class.
   
 4. Create a new key (using the GUID as the name) in the registry under: 
    HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}
    {GUID} is the valid GUID that you created in step 1.
 
 5. Create the following string values in the registry under the new key:
 
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
 
 6. The following register key values are required to complete the creation of a toolbar button
    that implements a COM object.
    
    CLSID - set the value equal to {1FBA04EE-3024-11d2-8F1F-0000F87ABD16}. This value indicates 
    that the extension is of the CLSID_Shell_ToolbarExtExec class. 
    HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\CLSID
 
    ClsidExtension - Set the value of ClsidExtension equal to the GUID of the COM object.
    HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\ClsidExtension   
 
 7. The following register key values are required to complete the creation of a toolbar button that 
    runs a script.
    
    CLSID - set the value equal to {1FBA04EE-3024-11d2-8F1F-0000F87ABD16}. This value indicates 
    that the extension is of the CLSID_Shell_ToolbarExtExec class. 
    HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\CLSID
    
    Script - Set the value of Script to the full path of the script to run.
    HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\Script
 
 8. The following register key values are required to complete the creation of a toolbar button that 
    runs an executable file.
    
    CLSID - set the value equal to {1FBA04EE-3024-11d2-8F1F-0000F87ABD16}. This value indicates 
    that the extension is of the CLSID_Shell_ToolbarExtExec class. 
    HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\CLSID
    
    Exec - Set the value of Exec to the full path of the .exe file to run.
    HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\Extensions\{GUID}\Exec
 
 
 This source is subject to the Microsoft Public License.
 See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
 All other rights reserved.
 
 THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using CSIEToolbarButton.NativeMethods;
using Microsoft.Win32;
using SHDocVw;

namespace CSIEToolbarButton
{
    [ComVisible(true)]
    [Guid("c0e8ae32-0758-4c8d-ab71-23b361fe8964")]
    public class NotePadToolbarButton : IObjectWithSite, IOleCommandTarget
    {
        const string IEExtensionsRegisterKeyPath = "Software\\Microsoft\\Internet Explorer\\Extensions";

        // Current IE instance. For IE7 or later version, an IE Tab is just 
        // an IE instance.
        private InternetExplorer ieInstance;

        #region IObjectWithSite Members
        /// <summary>
        /// This method is called when the extension is instantiated and when
        /// it is destroyed. The site is an object implemented the 
        /// interface IShellBrowser which also implements the interface _IServiceProvider.
        /// </summary>
        /// <param name="site"></param>
        public void SetSite(Object site)
        {
            // Release previous COM objects.
            if (this.ieInstance != null)
            {
                Marshal.ReleaseComObject(this.ieInstance);
                this.ieInstance = null;
            }

            // The site implements IServiceProvider interface and can be used to 
            // get InternetExplorer instance.
            var provider = site as NativeMethods.IServiceProvider;
            if (provider != null)
            {
                Guid guid = new Guid("{0002DF05-0000-0000-C000-000000000046}");
                Guid riid = new Guid("{00000000-0000-0000-C000-000000000046}");
                try
                {
                    object webBrowser;
                    provider.QueryService(ref guid, ref riid, out webBrowser);
                    this.ieInstance = webBrowser as InternetExplorer;
                }
                catch (COMException)
                {
                }
            }
        }

        /// <summary>
        /// Retrieves and returns the specified interface from the last site
        /// set through SetSite(). The typical implementation will query the
        /// previously stored pUnkSite pointer for the specified interface.
        /// </summary>
        public void GetSite(ref Guid guid, out Object ppvSite)
        {
            IntPtr punk = Marshal.GetIUnknownForObject(ieInstance);
            ppvSite = new object();
            IntPtr ppvSiteIntPtr = Marshal.GetIUnknownForObject(ppvSite);
            int hr = Marshal.QueryInterface(punk, ref guid, out ppvSiteIntPtr);
            Marshal.ThrowExceptionForHR(hr);
            Marshal.Release(punk);
        }
        #endregion

        #region IOleCommandTarget Members

        public int QueryStatus(GUID pguidCmdGroup, int cCmds, OLECMD prgCmds, IntPtr pCmdText)
        {
            return 0;
        }

        /// <summary>
        /// When the button is clicked, it will execute the Exec method of the
        /// IOleCommandTarget interface.
        /// </summary>
        public int Exec(GUID pguidCmdGroup, int nCmdID, int nCmdexecopt, object[] pvaIn, int pvaOut)
        {
            StringBuilder msg = new StringBuilder();

            mshtml.HTMLDocument doc = ieInstance.Document as mshtml.HTMLDocument;
            var imgs = doc.getElementsByTagName("img");

            foreach (var img in imgs)
            {
                mshtml.IHTMLImgElement imgElement = img as mshtml.IHTMLImgElement;
                if (imgElement != null)
                {
                    msg.Append(imgElement.src + "\n");
                }
            }

            System.Windows.Forms.MessageBox.Show(msg.ToString(),"Images in the page");
            return 0;
        }

        #endregion


        #region Com Register/UnRegister Methods
        /// <summary>
        /// When this class is registered to COM, add a new key to the BHORegistryKey 
        /// to make IE use this BHO.
        /// On 64bit machine, if the platform of this assembly and the installer is x86,
        /// 32 bit IE can use this BHO. If the platform of this assembly and the installer
        /// is x64, 64 bit IE can use this BHO.
        /// </summary>
        [ComRegisterFunction]
        public static void RegisterIEToolbarButton(Type t)
        {
            string toolbarRegisterKeyPath = string.Format("{0}\\{1}",
                IEExtensionsRegisterKeyPath, t.GUID.ToString("B"));

            using (RegistryKey key = Registry.LocalMachine.CreateSubKey(toolbarRegisterKeyPath))
            {
                FileInfo assemblyFile = new FileInfo(Assembly.GetExecutingAssembly().Location);

                key.SetValue("ButtonText", "NotePad");

                key.SetValue("MenuText", "Note Pad");
                key.SetValue("MenuStatusBar", "Launch NotePad");

                // Implement a COM object.
                key.SetValue("CLSID", "{1FBA04EE-3024-11d2-8F1F-0000F87ABD16}");
                key.SetValue("ClsidExtension", t.GUID.ToString("B"));

                // Run an executable file.
                key.SetValue("Exec", "Notepad.exe");

                // Run a script.
                key.SetValue("Script", string.Format("{0}\\Resources\\GetImageList.htm", assemblyFile.Directory.FullName));

                // Set the icon path.             
                key.SetValue("Icon", string.Format("{0}\\Resources\\NotePadHot.ico", assemblyFile.Directory.FullName));
                key.SetValue("HotIcon", string.Format("{0}\\Resources\\NotePadNormal.ico", assemblyFile.Directory.FullName));
            
                key.SetValue("Default Visible", "Yes");
            }
        }

        /// <summary>
        /// When this class is unregistered from COM, delete the key.
        /// </summary>
        [ComUnregisterFunction]
        public static void UnregisterIEToolbarButton(Type t)
        {
            string toolbarRegisterKeyPath = string.Format("{0}\\{1}",
                IEExtensionsRegisterKeyPath, typeof(NotePadToolbarButton).GUID.ToString("B"));

            RegistryKey key = Registry.LocalMachine.OpenSubKey(IEExtensionsRegisterKeyPath, true);
            string guidString = t.GUID.ToString("B");
            if (key != null)
            {
                key.DeleteSubKey(guidString, false);

                key.Close();
            }
        }
        #endregion
    }
}

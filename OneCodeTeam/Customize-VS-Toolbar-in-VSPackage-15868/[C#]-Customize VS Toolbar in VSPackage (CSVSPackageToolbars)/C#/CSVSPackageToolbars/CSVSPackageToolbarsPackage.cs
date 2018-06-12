/***************************************** Module Header *****************************\
 Module Name:  CSVSPackageToolbarsPackage.cs
 Project:      CSVSPackageToolbars
 Copyright (c) Microsoft Corporation.
 
 Implementation of CSVSPackageToolbars
 
 This source is subject to the Microsoft Public License.
 See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
 All other rights reserved.
 
 THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*************************************************************************************/


using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;

namespace Company.CSVSPackageToolbars
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    ///
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the 
    /// IVsPackage interface and uses the registration attributes defined in the framework to 
    /// register itself and its components with the shell.
    /// </summary>
    // This attribute tells the PkgDef creation utility (CreatePkgDef.exe) that this class is
    // a package.
    [PackageRegistration(UseManagedResourcesOnly = true)]
    // This attribute is used to register the informations needed to show the this package
    // in the Help/About dialog of Visual Studio.
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    // This attribute is needed to let the shell know that this package exposes some menus.
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(GuidList.guidCSVSPackageToolbarsPkgString)]
    public sealed class CSVSPackageToolbarsPackage : Package
    {
        /// <summary>
        /// Default constructor of the package.
        /// Inside this method you can place any initialization code that does not require 
        /// any Visual Studio service because at this point the package object is created but 
        /// not sited yet inside Visual Studio environment. The place to do all the other 
        /// initialization is the Initialize method.
        /// </summary>
        public CSVSPackageToolbarsPackage()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
        }

        // The currently selected menu controller command
        private int currentMCCommand;


        /////////////////////////////////////////////////////////////////////////////
        // Overriden Package Implementation
        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initilaization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));
            base.Initialize();

            // Add our command handlers for menu (commands must exist in the .vsct file)
            OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (null != mcs)
            {
                // Create the command for the menu item.
                CommandID menuCommandID = new CommandID(GuidList.guidCSVSPackageToolbarsCmdSet, (int)PkgCmdIDList.cmdidMyCommand);
                MenuCommand menuItem = new MenuCommand(MenuItemCallback, menuCommandID);
                mcs.AddCommand(menuItem);
                for (int i = PkgCmdIDList.cmdidMCItem1; i <=
                   PkgCmdIDList.cmdidMCItem3; i++)
                {
                    CommandID cmdID = new CommandID(GuidList.guidCSVSPackageToolbarsCmdSet, i);
                    OleMenuCommand mc = new OleMenuCommand(new EventHandler(OnMCItemClicked), cmdID);
                    mc.BeforeQueryStatus += new EventHandler(OnMCItemQueryStatus);
                    mcs.AddCommand(mc);
                    // The first item is, by default, checked.
                    if (PkgCmdIDList.cmdidMCItem1 == i)
                    {
                        mc.Checked = true;
                        this.currentMCCommand = i;
                    }
                }

            }
        }
        #endregion

        /// <summary>
        /// This function is the callback used to execute a command when the a menu item is clicked.
        /// See the Initialize method to see how the menu item is associated to this function using
        /// the OleMenuCommandService service and the MenuCommand class.
        /// </summary>
        private void MenuItemCallback(object sender, EventArgs e)
        {
            // Show a Message Box to prove we were here
            IVsUIShell uiShell = (IVsUIShell)GetService(typeof(SVsUIShell));
            Guid clsid = Guid.Empty;
            int result;
            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(uiShell.ShowMessageBox(
                       0,
                       ref clsid,
                       "CSVSPackageToolbars",
                       string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this.ToString()),
                       string.Empty,
                       0,
                       OLEMSGBUTTON.OLEMSGBUTTON_OK,
                       OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST,
                       OLEMSGICON.OLEMSGICON_INFO,
                       0,        // false
                       out result));
        }

        private void OnMCItemQueryStatus(object sender, EventArgs e)
        {
            OleMenuCommand mc = sender as OleMenuCommand;
            if (null != mc)
            {
                mc.Checked = (mc.CommandID.ID == this.currentMCCommand);
            }
        }

        private void OnMCItemClicked(object sender, EventArgs e)
        {
            OleMenuCommand mc = sender as OleMenuCommand;
            if (null != mc)
            {
                string selection;
                switch (mc.CommandID.ID)
                {
                    case PkgCmdIDList.cmdidMCItem1:
                        selection = "Menu controller Item 1";
                        break;

                    case PkgCmdIDList.cmdidMCItem2:
                        selection = "Menu controller Item 2";
                        break;

                    case PkgCmdIDList.cmdidMCItem3:
                        selection = "Menu controller Item 3";
                        break;

                    default:
                        selection = "Unknown command";
                        break;
                }
                this.currentMCCommand = mc.CommandID.ID;

                IVsUIShell uiShell =
                  (IVsUIShell)GetService(typeof(SVsUIShell));
                Guid clsid = Guid.Empty;
                int result;
                uiShell.ShowMessageBox(
                           0,
                           ref clsid,
                           "Test Toolbar Package",
                           string.Format(CultureInfo.CurrentCulture,
                                         "You selected {0}", selection),
                           string.Empty,
                           0,
                           OLEMSGBUTTON.OLEMSGBUTTON_OK,
                           OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST,
                           OLEMSGICON.OLEMSGICON_INFO,
                           0,
                           out result);
            }
        }

    }
}

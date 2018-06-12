/****************************** Module Header ******************************\
 Module Name:  MyToolWindow.cs
 Project:      CSVSToolWindow
 Copyright (c) Microsoft Corporation.
 
 Define the ToolWindow, and set its ToolBar.
 
 This source is subject to the Microsoft Public License.
 See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
 All other rights reserved.
 
 THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.Win32;

namespace Microsoft.CSVSToolWindow
{
    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    ///
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane, 
    /// usually implemented by the package implementer.
    ///
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its 
    /// implementation of the IVsUIElementPane interface.
    /// </summary>
    [Guid("9e2c6336-e461-43fb-ab62-47a266a46a4e")]
    public class MyToolWindow : ToolWindowPane
    {
        MyControl control = null;

        /// <summary>
        /// Standard constructor for the tool window.
        /// </summary>
        public MyToolWindow() :
            base(null)
        {
            // Set the window title reading it from the resources.
            this.Caption = Resources.ToolWindowTitle;
            // Set the image that will appear on the tab of the window frame
            // when docked with an other window
            // The resource ID correspond to the one defined in the resx file
            // while the Index is the offset in the bitmap strip. Each image in
            // the strip being 16x16.
            this.BitmapResourceID = 301;
            this.BitmapIndex = 1;

            // Create the toolbar.
            this.ToolBar = new CommandID(GuidList.guidCSVSToolWindowCmdSet,
                PkgCmdIDList.ToolbarID);
            this.ToolBarLocation = (int)VSTWT_LOCATION.VSTWT_TOP;

            // Create the handlers for the toolbar commands.
            var mcs = GetService(typeof(IMenuCommandService))
                as OleMenuCommandService;
            if (null != mcs)
            {
                var toolbarbtnCmdID = new CommandID(
                    GuidList.guidCSVSToolWindowCmdSet,
                    PkgCmdIDList.cmdidOpenImage);
                var menuItem = new MenuCommand(new EventHandler(
                    ButtonHandler), toolbarbtnCmdID);
                mcs.AddCommand(menuItem);
            }


            // This is the user control hosted by the tool window
            control = new MyControl();
            base.Content = control;
        }

        private void ButtonHandler(object sender, EventArgs arguments)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "image files |*.bmp;*.png;*.jpg;*.jpeg";
            fd.Multiselect = false;
            if (true == fd.ShowDialog())
            {
                control.Image = new System.Windows.Media.Imaging.BitmapImage(new Uri(fd.FileName));
            }
        }
    }
}

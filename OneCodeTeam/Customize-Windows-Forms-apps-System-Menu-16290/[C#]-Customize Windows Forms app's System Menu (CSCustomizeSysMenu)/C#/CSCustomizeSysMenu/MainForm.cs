/****************************** Module Header ******************************\
Module Name:  MainForm.cs
Project:      CSCustomizeSysMenu
Copyright (c) Microsoft Corporation.
 
This application demonstrates how to modify a winform application’s system menu.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CSCustomizeSysMenu
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // Flags and imports of native API's for manipulating system menu
        [Flags]
        public enum MenuFlags : uint
        {
            MF_STRING = 0,
            MF_BYPOSITION = 0x400,
            MF_SEPARATOR = 0x800,
            MF_REMOVE = 0x1000,
        }
        [DllImport("user32.dll", CharSet= CharSet.Auto, SetLastError = true)]
        static extern bool DrawMenuBar(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool AppendMenu(IntPtr hMenu, MenuFlags uFlags, uint uIDNewItem, string lpNewItem);
        [StructLayout(LayoutKind.Sequential)]
        struct MENUITEMINFO
        {
            public uint cbSize;
            public uint fMask;
            public uint fType;
            public uint fState;
            public uint wID;
            public IntPtr hSubMenu;
            public IntPtr hbmpChecked;
            public IntPtr hbmpUnchecked;
            public IntPtr dwItemData;
            public String dwTypeData;
            public uint cch;
            public IntPtr hbmpItem;

            // Return the size of the structure
            public static uint sizeOf
            {
                get { return (uint)Marshal.SizeOf(typeof(MENUITEMINFO)); }
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool InsertMenuItem(IntPtr hMenu, uint uItem, bool fByPosition,[In] ref MENUITEMINFO lpmii);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetMenuItemCount(IntPtr hMenu);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool GetMenuItemInfo(IntPtr hMenu, uint uItem, bool fByPosition, ref MENUITEMINFO lpmii);

        // Necessary constants defined for usage with Win32 API's
        private const UInt32 MFT_STRING     = 0x0;
        private const UInt32 MIIM_ID        = 0x2;
        private const UInt32 MIIM_STRING    = 0x40;
        private const UInt32 MFS_ENABLED    = 0x0;
        private const UInt32 MF_BYPOSITION  = 0x400;
        private const UInt32 WM_SYSCOMMAND  = 0x112;
        private UInt32 BaseCommandId = 0xf200; // Start menu id's from here
        private UInt32 CurrentIndex = 0;

        private void btnAddToFormSystemMenu_Click(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            if (hMenu != IntPtr.Zero)
            {
                Int32 Count             = GetMenuItemCount(hMenu);
                MENUITEMINFO mnuInfo    = new MENUITEMINFO();
                mnuInfo.cbSize          = MENUITEMINFO.sizeOf;
                mnuInfo.fMask           = MIIM_STRING | MIIM_ID;
                mnuInfo.fState          = MFS_ENABLED;
                mnuInfo.fType           = MFT_STRING;
                mnuInfo.wID             = BaseCommandId + ++CurrentIndex;
                mnuInfo.dwTypeData      = txtMenuCaption.Text;
                InsertMenuItem(hMenu, (UInt32)Count, true, ref mnuInfo);
                DrawMenuBar(hMenu);
            }
        }

        void ShowLastError()
        {
            Win32Exception ex = new Win32Exception();
            MessageBox.Show(ex.Message, "Last Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void handleSysCustomCommand(UInt32 CmdId)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            MENUITEMINFO mnuInfo = new MENUITEMINFO();
            mnuInfo.cbSize = MENUITEMINFO.sizeOf;
            mnuInfo.fType = MFT_STRING;
            mnuInfo.fMask = MIIM_STRING;

            // Get size of buffer first, this call will fill out mnuInfo.cch val which is the buffer size
            if (!GetMenuItemInfo(hMenu, CmdId, false, ref mnuInfo))
            {
                ShowLastError();
            }
            else
            {
                // Pad up a bit
                mnuInfo.cch += 4; 
                mnuInfo.dwTypeData = new String(' ', (Int32)mnuInfo.cch);
                if(!GetMenuItemInfo(hMenu, CmdId, false, ref mnuInfo)) // This time get menu item text
                {
                    ShowLastError();
                }
                else
                {
                    String Text = String.Format("You clicked on: {0}", mnuInfo.dwTypeData);
                    MessageBox.Show(Text, "Menu text", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // A demo on how to handle the event from the new system menu items...
        protected override void WndProc(ref Message Msg)
        {
            if (Msg.Msg == WM_SYSCOMMAND)
            {
                if ((UInt32)Msg.WParam.ToInt32() > BaseCommandId)
                {
                    handleSysCustomCommand((UInt32)Msg.WParam.ToInt32());
                }
            }
            base.WndProc(ref Msg);
        }
    }
}
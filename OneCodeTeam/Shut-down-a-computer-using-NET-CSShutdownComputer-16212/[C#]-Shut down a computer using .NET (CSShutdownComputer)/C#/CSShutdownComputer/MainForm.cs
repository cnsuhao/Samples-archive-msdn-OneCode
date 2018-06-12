/****************************** Module Header ******************************\ 
Module Name: MainForm.cs
Project: CSShutdownComputer
Copyright (c) Microsoft Corporation. 

Implementation for shutting down a computer

This source is subject to the Microsoft Public License. 
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL 
All other rights reserved. 

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
\***************************************************************************/


using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Globalization;
using PrivilegeClass;

namespace CSShutdownComputer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            // Enable SE_REMOTE_SHUTDOWN_NAME and SE_SHUTDOWN_NAME. The Privilege class has been taken from 
            // http://msdn.microsoft.com/en-us/magazine/cc163823.aspx
            new Privilege(Privilege.RemoteShutdown).Enable();
            new Privilege(Privilege.Shutdown).Enable();

            InitializeComponent();
        }

        // These events opens up MSDN documentation of corresponding API's
        private void lnkShutDownReason_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://msdn.microsoft.com/en-us/library/windows/desktop/aa376885(v=vs.85).aspx"); 
        }

        private void lnkDocumentationExitWindowEx_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://msdn.microsoft.com/en-us/library/windows/desktop/aa376868(v=vs.85).aspx"); 
        }

        private void lnkDocInitiateShutdown_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://msdn.microsoft.com/en-us/library/windows/desktop/aa376872(v=vs.85).aspx"); 
        }

        private void lnkDocInitiateSystemShutdownEx_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://msdn.microsoft.com/en-us/library/windows/desktop/aa376874(v=vs.85).aspx"); 
        }

        private void lnkDocAbortSystemShutdown_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://msdn.microsoft.com/en-us/library/windows/desktop/aa376630(v=vs.85).aspx");
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (radExitWindowEx.Checked)
            {
                CallExitWindowsEx();
            }
            else
            {
                if (radInitiateShutdown.Checked)
                {
                    CallInitiateShutdown();
                }
                else
                {
                    if (radInitiateSystemShutdownEx.Checked)
                    {
                        CallInitiateSystemShutdownEx();
                    }
                    else
                    {
                        if (radAbortSystemShutdown.Checked)
                        {
                            CallAbortSystemShutdown();
                        }
                    }
                }
            }
        }

        protected bool HexToNum(String hex, out UInt32 number)
        {
            return UInt32.TryParse(hex, NumberStyles.Any, CultureInfo.CurrentCulture, out number);
        }

        protected bool HexToReasonCode(String hex, out UInt32 reason)
        {
            if (!HexToNum(hex, out reason))
            {
                String err = String.Format("Invalid 'reason' value: {0}! Failed to convert, we are expecting a hex value", hex);
                DisplayError(err, "Error in conversion");
                return false;
            }
            else
            {
                return true;
            }
        }

        // Converts the 'tag' value of each checkbox to integer. The values correspond to the flag's value in Win32
        protected UInt32 GetFlags(CheckBox[] chkFlags)
        {
            UInt32 dwFlags = 0;
            foreach (CheckBox Chk in chkFlags)
            {
                if (Chk.Checked)
                {
                    UInt32 result = 0x0;
                    if (HexToNum(Chk.Tag.ToString(), out result))
                    {
                        dwFlags |= result;
                    }
                    else
                    {
                        String err = String.Format("Invalid 'flag' value: {0}! Failed to convert, we are expecting a hex value", Chk.Tag.ToString());
                        DisplayError(err, "Error in conversion");
                    }
                }
            }

            return dwFlags;
        }

        void DisplayError(String errText, String caption = "Error!")
        {
            MessageBox.Show(errText, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void ShowLastError()
        {
            Win32Exception ex = new Win32Exception();
            DisplayError(ex.Message, "Last Error!");
        }

        // Call ExitWindowEx
        [DllImport("user32.dll", CharSet = CharSet.Auto,  SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ExitWindowsEx(uint uFlags, uint uReason);
        protected void CallExitWindowsEx()
        {
            CheckBox [] chkFlags = { chkEWX_FORCE, 
                                     chkEWX_FORCEIFHUNG, 
                                     chkEWX_HYBRID_SHUTDOWN, 
                                     chkEWX_LOGOFF, 
                                     chkEWX_POWEROFF, 
                                     chkEWX_REBOOT, 
                                     chkEWX_RESTARTAPPS,
                                     chkEWX_SHUTDOWN };

            UInt32 dwFlags = GetFlags(chkFlags);
            UInt32 reason = 0;
            if (HexToNum(txtReasonEWE.Text, out reason))
            {
                if (!ExitWindowsEx(dwFlags, reason))
                {
                    ShowLastError();
                }
            }
        }

        // Call InitiateShutdown
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool InitiateShutdown(string lpMachineName, 
                                            string lpMessage, 
                                            UInt32 dwGracePeriod, 
                                            UInt32 dwShutdownFlags, 
                                            UInt32 dwReason);

        void CallInitiateShutdown()
        {            
            CheckBox [] chkFlags = { chkSHUTDOWN_FORCE_OTHERS, 
                                     chkSHUTDOWN_FORCE_SELF, 
                                     chkSHUTDOWN_GRACE_OVERRIDE, 
                                     chkSHUTDOWN_HYBRID, 
                                     chkSHUTDOWN_INSTALL_UPDATES, 
                                     chkSHUTDOWN_NOREBOOT, 
                                     chkSHUTDOWN_POWEROFF,
                                     chkSHUTDOWN_RESTART,
                                     chkSHUTDOWN_RESTARTAPPS };
            UInt32 flags = GetFlags(chkFlags);
            UInt32 reason = 0;
            if (HexToNum(txtReasonIS.Text, out reason))
            {
                UInt32 gracePeriod;
                if (HexToNum(txtGracePeriodIS.Text, out gracePeriod))
                {
                    if (!InitiateShutdown(txtMachineNameIS.Text, txtMessageIS.Text, gracePeriod, flags, reason))
                    {
                        ShowLastError();
                    }
                }
            }
        }

        // Call InitiateSystemShutdownEx
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InitiateSystemShutdownEx(
            string lpMachineName,
            string lpMessage,
            uint dwTimeout,
            bool bForceAppsClosed,
            bool bRebootAfterShutdown,
            UInt32 dwReason);
        void CallInitiateSystemShutdownEx()
        {
            UInt32 timeout = 0;
            if (HexToNum(txtTimeOutISSE.Text, out timeout))
            {
                UInt32 reason = 0;
                if (HexToNum(txtReasonISSE.Text, out reason))
                {
                    if (!InitiateSystemShutdownEx(txtMachineNameISSE.Text, txtMessageISSE.Text, timeout, 
                        chkForceAppsClosed.Checked, chkRebootAfterShutdown.Checked, reason))
                    {
                        ShowLastError();
                    }
                }
            }
        }

        // Call AbortSystemShutdown
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AbortSystemShutdown(string lpMachineName);
        void CallAbortSystemShutdown()
        {
            if (!AbortSystemShutdown(txtMachineNameASS.Text))
            {
                ShowLastError();
            }
        }

        // Navigate to pinvoke.net for corresponding API's
        private void lnkPInvokeEWE_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://pinvoke.net/default.aspx/user32/ExitWindowsEx.html");
        }

        private void lnkPInvokeLinkISSE_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://pinvoke.net/default.aspx/advapi32/InitiateSystemShutdownEx.html");
        }

        private void lnkPInvokeLinkASS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://pinvoke.net/default.aspx/advapi32/AbortSystemShutdown.html");
        }

        private void radExitWindowEx_CheckedChanged(object sender, EventArgs e)
        {
            grpbxExitWindowEx.Enabled = radExitWindowEx.Checked;
        }

        private void radInitiateShutdown_CheckedChanged(object sender, EventArgs e)
        {
            grpbxInitiateShutdown.Enabled = radInitiateShutdown.Checked;
        }

        private void radInitiateSystemShutdownEx_CheckedChanged(object sender, EventArgs e)
        {
            grpbxInitiateSystemShutdownEx.Enabled = radInitiateSystemShutdownEx.Checked;
        }

        private void radAbortSystemShutdown_CheckedChanged(object sender, EventArgs e)
        {
            grpbxAbortSystemShutdown.Enabled = radAbortSystemShutdown.Checked;
        }
    }
}

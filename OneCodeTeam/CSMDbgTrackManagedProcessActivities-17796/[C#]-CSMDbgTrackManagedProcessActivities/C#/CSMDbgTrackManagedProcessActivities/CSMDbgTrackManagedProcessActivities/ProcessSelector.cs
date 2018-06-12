/****************************** Module Header ******************************\
 * Module Name:  ManagedThread.cs
 * Project:      CSMDbgTrackManagedProcessActivities
 * Copyright (c) Microsoft Corporation.
 * 
 * This dialog is used to select the target process to debug. 
 * 
 *  
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Diagnostics;
using System.Security.Permissions;
using System.Windows.Forms;
using CSMDbgTrackManagedProcessActivities.Debugger;

namespace CSMDbgTrackManagedProcessActivities
{
    [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
    [PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
    public partial class ProcessSelector : Form
    {

        /// <summary>
        /// Specify whether debug a running process or launch an application to debug.
        /// </summary>
        public bool LaunchApplication
        {
            get
            {
                return radLaunchApplication.Checked;
            }
        }

        /// <summary>
        /// The path of the application.
        /// </summary>
        public string ApplicationPath
        {
            get
            {
                if (LaunchApplication)
                {
                    return this.tbApplicationPath.Text;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// The process ID.
        /// </summary>
        public int ProcessID
        {
            get
            {
                if (!LaunchApplication && lstProcess.SelectedItem != null)
                {
                    Process process = lstProcess.SelectedItem as Process;
                    if (process != null && !process.HasExited)
                    {
                        return process.Id;
                    }
                }
                return 0;
            }
        }


        public ProcessSelector()
        {
            InitializeComponent();
        }

        private void ProcessSelector_Load(object sender, EventArgs e)
        {
            tbApplicationPath.Text = Environment.CurrentDirectory + "\\CSMDbgTargetApp.exe";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshManagedProcess();
        }

        private void RefreshManagedProcess()
        {

            var processes = ManagedProcess.EnumManagedProcesses();

            lstProcess.DataSource = processes;

            if (lstProcess.Items.Count > 0)
            {
                lstProcess.SelectedIndex = 0;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                var result = dialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    this.tbApplicationPath.Text = dialog.FileName;
                }
            }
        }


    }
}

/****************************** Module Header ******************************\
 * Module Name:  MainForm.cs
 * Project:      CSMDbgTrackManagedProcessActivities
 * Copyright (c) Microsoft Corporation.
 * 
 * The MainForm of this application. 
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
using System.Collections.Generic;
using System.Windows.Forms;
using CSMDbgTrackManagedProcessActivities.Debugger;
using Microsoft.Samples.Debugging.MdbgEngine;
using Microsoft.Samples.Debugging.CorDebug;

namespace CSMDbgTrackManagedProcessActivities
{
    public partial class MainForm : Form
    {

        // The delegates used in Invoke method.
        private delegate void ParameterizedDelegate(object parameter);
        private delegate void VoidDelegate();

        ManagedProcess managedProcess = null;

        // Specify whether debug a running process or launch an application 
        // to debug.
        bool launchApplication;

        // The path of the application.
        string applicationPath;

        // The process ID.
        int processID;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Launch the ProcessSelector dialog to select a process to debug.
            if (SelectProcess())
            {

                // This method should be executed in a MTA thread.
                MTAThreadHelper.RunInMTAThread(InitializeManagedProcess);

            }
        }

        /// <summary>
        /// Launch the ProcessSelector dialog to select a process to debug.
        /// </summary>
        private bool SelectProcess()
        {
            using (ProcessSelector selector = new ProcessSelector())
            {
                var result = selector.ShowDialog();

                if (result != System.Windows.Forms.DialogResult.OK
                    || (!selector.LaunchApplication && selector.ProcessID <= 0))
                {
                    Application.Exit();
                    return false;
                }

                this.launchApplication = selector.LaunchApplication;
                this.applicationPath = selector.ApplicationPath;
                this.processID = selector.ProcessID;
                return true;
            }
        }

        #region MTAThread methods

        /// <summary>
        /// Attach the debugger to the target process.
        /// This method should be executed in a MTA thread.
        /// </summary>
        private void InitializeManagedProcess()
        {
            if (this.managedProcess != null)
            {
                this.managedProcess.Dispose();
                this.managedProcess = null;
            }

            try
            {
                if (this.launchApplication)
                {
                    this.managedProcess = ManagedDebugger.Instance.CreateProcess(
                        this.applicationPath);
                }
                else
                {
                    this.managedProcess = ManagedDebugger.Instance.AttachTo(
                        this.processID);
                }

                // Register the events.
                this.managedProcess.PostEvent += new EventHandler<PostEventArgs>(managedProcess_PostEvent);
                this.managedProcess.OperationErrorOccurred += new EventHandler<ErrorEventArgs>(managedProcess_OperationErrorOccurred);
                this.managedProcess.ProcessExit += new EventHandler(managedProcess_ProcessExit);

                // Update the UI.
                this.Invoke(new ParameterizedDelegate(RefreshUI), true);

            }
            catch (Exception ex)
            {
                this.ErrorOccurredInMTAThread(
                      new ErrorEventArgs
                      {
                          Error = ex,
                          Ignorable = false,
                          Message = "Cannot initialize to debug the target process."
                      });
            }

        }
        #endregion

        #region Handle managed process events

        /// <summary>
        /// Target process exits.
        /// </summary>
        void managedProcess_ProcessExit(object sender, EventArgs e)
        {
            if (managedProcess != null)
            {

                // This method should be executed in a MTA thread.
                MTAThreadHelper.RunInMTAThread(managedProcess.Dispose);

            }

            this.ErrorOccurredInMTAThread(
                new ErrorEventArgs
                {
                    Error = new ApplicationException("The debuggee has exited."),
                    Ignorable = false,
                    Message = "The debuggee has exited."
                });
        }

        /// <summary>
        /// There is an activity in the target process.
        /// </summary>
        void managedProcess_PostEvent(object sender, PostEventArgs e)
        {
            AddActivity(e.EventMessage);
        }

        /// <summary>
        /// Log the message.
        /// </summary>
        void AddActivity(string message)
        {
            string timeStamp = DateTime.Now.ToString("HH:mm:ss");
            string msg = string.Format("{0}{1}{0}{2}{0}", 
                Environment.NewLine, timeStamp, message);
            this.Invoke(new ParameterizedDelegate(AddActivityHandler), msg);
        }

        /// <summary>
        /// Log the message.
        /// </summary>
        void AddActivityHandler(object msg)
        {
            this.tbActivities.AppendText(msg as string);
            this.tbActivities.SelectionStart = tbActivities.Text.Length - 1;
        }

        /// <summary>
        /// Handle the OperationErrorOccurred event.
        /// This method will be executed in a MTA thread.
        /// </summary>
        private void managedProcess_OperationErrorOccurred(object sender,
            ErrorEventArgs e)
        {
            this.ErrorOccurredInMTAThread(e);
        }

        /// <summary>
        /// Refresh the UI.
        /// This method should be executed in the main thread.
        /// </summary>
        private void RefreshUI(object isProcessRunningParameter)
        {
            bool isProcessRunning = (bool)isProcessRunningParameter;

            if (this.managedProcess == null)
            {
                this.lbProcess.Text = string.Empty;
            }
            else
            {
                this.lbProcess.Text = string.Format(
                    "ProcessID:{0}    Name:{1}",
                    this.managedProcess.ProcessID,
                    this.managedProcess.ProcessName);
            }
        }

        #endregion

        #region UI event handlers of Stop and Continue.

        /// <summary>
        /// Detach the target process.
        /// </summary>
        private void btnDetach_Click(object sender, EventArgs e)
        {
            if (managedProcess != null)
            {

                // This method should be executed in a MTA thread.
                MTAThreadHelper.RunInMTAThread(managedProcess.Dispose);

            }

            // Launch the ProcessSelector dialog.
            if (SelectProcess())
            {

                // This method should be executed in a MTA thread.
                MTAThreadHelper.RunInMTAThread(InitializeManagedProcess);

            }
        }

        #endregion

        #region Error Handler.

        private void ErrorOccurredInMTAThread(ErrorEventArgs e)
        {
            this.Invoke(new ParameterizedDelegate(ErrorUIHandler), e);
        }

        private void ErrorUIHandler(object exceptionParameter)
        {
            ErrorEventArgs e = exceptionParameter as ErrorEventArgs;

            if (e == null || e.Error == null)
            {
                return;
            }

            Exception ex = e.Error;
            if (e.Ignorable)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error occurred in the debuggee.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                var result = MessageBox.Show(
                    string.Format("{0}\nDo you want to exit debugging?", ex.Message),
                    "Exit debugging?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);

                if (result == System.Windows.Forms.DialogResult.No && SelectProcess())
                {
                    MTAThreadHelper.RunInMTAThread(InitializeManagedProcess);
                }
                else
                {
                    this.Close();
                }
            }
        }

        #endregion
    }
}

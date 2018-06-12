/****************************** Module Header ******************************\
 * Module Name:  MainForm.cs
 * Project:      CSMDbgEvaluateFunction
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
using CSMDbgEvaluateFunction.Debugger;

namespace CSMDbgEvaluateFunction
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

            this.dgThread.AutoGenerateColumns = false;
            this.dgVariable.AutoGenerateColumns = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Launch the ProcessSelector dialog to select a process to debug.
            if (SelectProcess())
            {

                // This method should be executed in a MTA thread.
                MTAThreadHelper.RunInMTAThread(InitializeManagedProcess);

            }
            else
            {
                this.Close();
            }
        }

        // Launch the ProcessSelector dialog to select a process to debug.
        private bool SelectProcess()
        {
            using (ProcessSelector selector = new ProcessSelector())
            {
                var result = selector.ShowDialog();

                if (result != System.Windows.Forms.DialogResult.OK
                    || (!selector.LaunchApplication && selector.ProcessID <= 0))
                {
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
                this.managedProcess.OperationErrorOccurred += managedProcess_OperationErrorOccurred;
                this.managedProcess.ProcessExit += managedProcess_ProcessExit;


                // Update the UI.
                this.Invoke(new ParameterizedDelegate(UpdateThreads),
                 new object[] { null });
                this.Invoke(new ParameterizedDelegate(UpdateLocalVariables),
                    new object[] { null });
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



        /// <summary>
        /// Stop the process.
        /// This method will be executed in a MTA thread.
        /// </summary>
        private void StopProcess()
        {
            try
            {
                this.managedProcess.Stop();

                var threads = this.managedProcess.GetThreads();

                this.Invoke(new ParameterizedDelegate(UpdateThreads),
                    threads);

                this.Invoke(new ParameterizedDelegate(RefreshUI),
                    this.managedProcess.MDbgProcess.IsRunning);
            }
            catch (Exception ex)
            {
                this.ErrorOccurredInMTAThread(
                     new ErrorEventArgs
                     {
                         Error = ex,
                         Ignorable = false,
                         Message = "Cannot stop the target process."
                     });
            }
        }

        /// <summary>
        /// Continue the process.
        /// This method will be executed in a MTA thread.
        /// </summary>
        private void ContinueProcess()
        {
            try
            {
                this.managedProcess.Continue();

                this.Invoke(new ParameterizedDelegate(UpdateThreads),
                    new object[] { null });
                this.Invoke(new ParameterizedDelegate(UpdateLocalVariables),
                    new object[] { null });
                this.Invoke(new ParameterizedDelegate(RefreshUI), true);
            }
            catch (Exception ex)
            {
                this.ErrorOccurredInMTAThread(
                    new ErrorEventArgs
                    {
                        Error = ex,
                        Ignorable = false,
                        Message = "Cannot continue the target process."
                    }
                    );
            }
        }

        #endregion


        #region Handle managed process events


        private void managedProcess_ProcessExit(object sender, EventArgs e)
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
                }
                );
        }

        /// <summary>
        /// Handle the OperationErrorOccurred event.
        /// This method will be executed in a MTA thread.
        /// </summary>
        private void managedProcess_OperationErrorOccurred(object sender, ErrorEventArgs e)
        {
            this.ErrorOccurredInMTAThread(e);
        }

        /// <summary>
        /// Update the dgThread datasource.
        /// This method should be executed in the main thread.
        /// </summary>
        private void UpdateThreads(object threadsParameter)
        {
            List<ManagedThread> threads = threadsParameter as List<ManagedThread>;
            this.dgThread.DataSource = threads;
            this.dgThread.ClearSelection();
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
                btnContinue.Enabled = false;
                btnStop.Enabled = false;
                btnEvaluate.Enabled = false;
            }
            else
            {
                this.lbProcess.Text = string.Format(
                    "ProcessID:{0}    tName:{1}",
                    this.managedProcess.ProcessID,
                    this.managedProcess.ProcessName);


                if (isProcessRunning)
                {
                    btnContinue.Enabled = false;
                    btnStop.Enabled = true;
                    btnEvaluate.Enabled = false;
                }
                else
                {
                    btnContinue.Enabled = true;
                    btnStop.Enabled = false;
                    btnEvaluate.Enabled = false;
                }
            }
        }

        #endregion

        #region UI event handlers of Stop and Continue.

        /// <summary>
        /// Stop the target process.
        /// </summary>
        private void btnStop_Click(object sender, EventArgs e)
        {
            this.btnStop.Enabled = false;

            if (this.managedProcess != null)
            {

                // This method should be executed in a MTA thread.
                MTAThreadHelper.RunInMTAThread(StopProcess);

            }
        }

        /// <summary>
        /// Continue the target process.
        /// </summary>
        private void btnContinue_Click(object sender, EventArgs e)
        {
            btnContinue.Enabled = false;

            if (this.managedProcess != null)
            {

                // This method should be executed in a MTA thread.
                MTAThreadHelper.RunInMTAThread(ContinueProcess);

            }
        }

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
            else
            {
                this.Close();
            }
        }

        #endregion

        #region Display the local variables.

        private void dgThread_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgThread.Rows[e.RowIndex];
            MTAThreadHelper.RunInMTAThread(SelectedThreadChanged, row);
        }

        /// <summary>
        /// Get the local variables.
        /// This method should be executed in a MTA thread.
        /// </summary>
        private void SelectedThreadChanged(object rowParameter)
        {
            DataGridViewRow row = rowParameter as DataGridViewRow;

            var thread = row.DataBoundItem as ManagedThread;

            if (thread != null)
            {
                var variables = managedProcess.GetLocalVariables(thread);
                this.Invoke(new ParameterizedDelegate(UpdateLocalVariables), variables);
            }
        }

        /// <summary>
        /// Update the local variables.
        /// This method should be executed in the main thread.
        /// </summary>
        private void UpdateLocalVariables(object localVariablesParameter)
        {
            var localVariables = localVariablesParameter as List<ManagedValue>;
            this.dgVariable.DataSource = localVariables;
            btnEvaluate.Enabled = localVariables != null;
        }

        #endregion

        #region Evaluate a function.

        private void btnEvaluate_Click(object sender, EventArgs e)
        {
            btnEvaluate.Enabled = false;
            MTAThreadHelper.RunInMTAThread(Evaluate, cmbExpression.Text.Trim());
        }

        /// <summary>
        /// Evaluate a function.
        /// This method should be executed in a MTA thread.
        /// </summary>
        /// <param name="expression"></param>
        private void Evaluate(object expression)
        {
            var result = string.Empty;

            try
            {
                var value = managedProcess.FunctionEval(expression as string);

                if (value != null)
                {
                    result = value.GetStringValue(true);
                }
                else
                {
                    result = "There is no value returned";
                }
            }
            catch (Exception ex)
            {
                result = "The expression is invalid.\n" + ex.Message;

                if (ex.InnerException != null)
                {
                    result += ex.InnerException.Message;
                }

                this.ErrorOccurredInMTAThread(
                    new ErrorEventArgs
                    {
                        Error = ex,
                        Ignorable = true,
                        Message = "Cannot evaluate the expression."
                    }
                    );
            }
            finally
            {
                this.Invoke(new ParameterizedDelegate(UpdateResult), result);
            }
        }

        /// <summary>
        /// Display the result of the function.
        /// This method should be executed in the main thread.
        /// </summary>
        /// <param name="result"></param>
        private void UpdateResult(object result)
        {
            this.tbResult.Text = result as string;
            btnEvaluate.Enabled = true;
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
                MTAThreadHelper.RunInMTAThread(StopProcess);

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

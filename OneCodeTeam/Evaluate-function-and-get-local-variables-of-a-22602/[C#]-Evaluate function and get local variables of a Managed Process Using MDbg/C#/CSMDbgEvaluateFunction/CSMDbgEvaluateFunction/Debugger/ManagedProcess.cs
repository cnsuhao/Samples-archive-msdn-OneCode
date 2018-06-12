/****************************** Module Header ******************************\
 * Module Name:  ManagedProcess.cs
 * Project:      CSMDbgEvaluateFunction
 * Copyright (c) Microsoft Corporation.
 * 
 * This class represents a managed process. It contains a MDbgProcess field
 * and a System.Diagnostics.Process field. When a new instance is initialized,
 * it will attach a debugger to the target process, and supplied following 
 * features:
 * 
 * 1. Stop and continue the debuggee.
 * 2. Get the threads and local variables when the debuggee is stopped.
 * 3. Evaluate the expression.
 * 4. Check whether a running process is managed.
 * 5. Check whether an executable file is managed. 
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
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.Samples.Debugging.CorDebug;
using Microsoft.Samples.Debugging.MdbgEngine;
using Microsoft.Samples.Debugging.CorDebug.NativeApi;

namespace CSMDbgEvaluateFunction.Debugger
{
    [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
    [PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
    public partial class ManagedProcess : IDisposable
    {

        private bool disposed = false;

        /// <summary>
        /// Represents a Process in which code execution context can be controlled.
        /// </summary>
        public MDbgProcess MDbgProcess { get; private set; }


        private System.Diagnostics.Process diagnosticsProcess = null;

        /// <summary>
        /// Get System.Diagnostics.Process using ProcessID.
        /// </summary>
        public System.Diagnostics.Process DiagnosticsProcess
        {
            get
            {
                return diagnosticsProcess;
            }
        }

        /// <summary>
        /// The ID of the process. 
        /// </summary>
        public int ProcessID
        {
            get
            {
                return DiagnosticsProcess.Id;
            }
        }

        /// <summary>
        /// The name of the process. 
        /// </summary>
        public string ProcessName
        {
            get
            {
                return DiagnosticsProcess.ProcessName;
            }
        }



        #region Events

        public event EventHandler<ErrorEventArgs> OperationErrorOccurred;

        public event EventHandler ProcessExit;

        #endregion

        #region Constructor

        internal ManagedProcess(MDbgProcess mdbgProcess)
        {
            if (mdbgProcess == null)
            {
                throw new ArgumentNullException("mdbgProcess",
                    "The MDbgProcesscould not be null. ");
            }

            this.MDbgProcess = mdbgProcess;

            var process = Process.GetProcessById(mdbgProcess.CorProcess.Id);
            if (process == null)
            {
                throw new ArgumentException(string.Format("{0}{1}",
                    "Cannot find the process with the ID = ",
                    mdbgProcess.CorProcess.Id));
            }

            this.diagnosticsProcess = process;
        }

        #endregion


        #region Initialize, Stop and Continue

        /// <summary>
        /// Initialize the process.
        /// </summary>
        public void Initialize()
        {
            // Make the attach operation work.
            bool result = this.MDbgProcess.Go().WaitOne();

            if (!result)
            {
                throw new ApplicationException(
                    string.Format(@"The process with an ID {0} could not be "
                    + "attached. Operation time out.", this.DiagnosticsProcess.Id));
            }

            this.MDbgProcess.PostDebugEvent += MDbgProcess_PostDebugEvent;

            // After the process is attached, we have to make it continue.
            this.MDbgProcess.Go();

        }



        /// <summary>
        /// Stop the debuggee.
        /// </summary>
        public void Stop()
        {

            if (!this.MDbgProcess.IsAlive)
            {
                throw new ApplicationException(
                    "Only live process could be stopped.");
            }
            else if (this.MDbgProcess.IsRunning)
            {
                var result = this.MDbgProcess.AsyncStop().WaitOne();

                if (!result)
                {
                    throw new ApplicationException("The process cannot be stopped.");
                }
            }

        }

        /// <summary>
        /// Continue the debuggee.
        /// </summary>
        public void Continue()
        {
            if (!this.MDbgProcess.IsAlive)
            {
                throw new ApplicationException(
                    "Only live process could be continued.");
            }
            else if (!this.MDbgProcess.IsRunning)
            {
                this.MDbgProcess.Go();
            }
        }

        #endregion


        #region Get threads and local variables

        /// <summary>
        /// Get all the threads.
        /// </summary>
        public List<ManagedThread> GetThreads()
        {
            List<ManagedThread> threads = new List<ManagedThread>();

            foreach (MDbgThread thread in this.MDbgProcess.Threads)
            {
                ManagedThread managedThread = new ManagedThread(this, thread);
                threads.Add(managedThread);
            }
            return threads;

        }

        /// <summary>
        /// Get the local variables in the frame which has source. 
        /// </summary>
        public List<ManagedValue> GetLocalVariables(ManagedThread thread)
        {
            return GetLocalVariables(thread, true);
        }

        private List<ManagedValue> GetLocalVariables(ManagedThread thread, bool tryAgain)
        {
            try
            {

                // Set the thread to active.
                this.MDbgProcess.Threads.Active = thread.MDbgThread;

                if (thread.SourcePositionFrame != null)
                {

                    // Get the local variables in the frame which has source. 
                    var frame = thread.SourcePositionFrame;
                    var localVars = frame.Function.GetActiveLocalVars(frame);
                    var args = frame.Function.GetArguments(frame);

                    // The compiler will add some additional variables that start with "CS$"
                    // or "VB$".
                    var sourceCodeVars = from value in localVars.Concat(args)
                                         where !value.Name.StartsWith("CS$") && !value.Name.StartsWith("VB$")
                                         select new ManagedValue(value);

                    return sourceCodeVars.ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                if (tryAgain)
                {
                    return GetLocalVariables(thread, false);
                }
                else
                {
                    throw new ApplicationException("Cannot get the Local Variables.", ex);
                }
            }
        }

        #endregion

        #region Evaluate function

        /// <summary>
        /// The expression to evaluate.
        /// </summary>
        /// <param name="expression">
        /// Description: The expression format is 
        /// 1. Instance Method: obj.Method(args)
        /// 2. Static Method: Class.Method(args)
        /// 
        /// The args should be like following formats
        /// 1. Empty
        /// 2. Integer : 100
        /// 3. String:   "Hello World"
        /// 4. Generic Type (List<int>): [1,2,3,4] 
        /// </param>
        /// <returns>
        /// The value of the expression.
        /// NOTE:
        /// If the function to evaluate has no returned value, return null.
        /// If there is an exception while evaluate the expression, return the exception.
        /// </returns>
        public MDbgValue FunctionEval(string expression)
        {
            return FunctionEval(expression, true);
        }

        private MDbgValue FunctionEval(string expression, bool tryAgain)
        {
            try
            {
                ManagedThread thread = new ManagedThread(this, this.MDbgProcess.Threads.Active);

                if (thread.SourcePositionFrame != null)
                {
                    thread.StepToManagedCode();
                }

                MDbgFunction function = null;
                CorValue[] values = null;

                // Parse the expression.
                bool success = ExpressionPaser.TryParse(
                    this.MDbgProcess,
                    thread.SourcePositionFrame,
                    expression,
                    out function,
                    out values);
                if (!success)
                {
                    if (tryAgain)
                    {
                        return FunctionEval(expression, false);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return FunctionEvalInternal(thread, function, values);
                }
            }
            catch (Exception ex)
            {

                if (tryAgain)
                {
                    return FunctionEval(expression, false);
                }
                else
                {
                    throw new ApplicationException("Cannot evaluate this function.", ex);
                }
            }
        }

        /// <summary>
        ///  Eval a function in the target process.
        /// </summary>
        private MDbgValue FunctionEvalInternal(ManagedThread thread, MDbgFunction function, CorValue[] args)
        {

            // Create a CorEval object.
            CorEval eval = thread.MDbgThread.CorThread.CreateEval();

            // Call the function with the arguments.
            // If the function is an instance method, the first argument is the 
            // instance.
            eval.CallFunction(function.CorFunction, args);

            // Execute the function.
            MDbgProcess.Go().WaitOne();

            MDbgValue value = null;

            // Get the result of the function.
            if (MDbgProcess.StopReason is EvalCompleteStopReason)
            {
                CorValue result =
                    (MDbgProcess.StopReason as EvalCompleteStopReason).Eval.Result;
                if (result != null)
                {
                    value = new MDbgValue(MDbgProcess, result);
                }
            }

            return value;
        }

        #endregion

        #region IDisposable interface

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Protect from being called multiple times.
            if (disposed) return;

            if (disposing)
            {
                // Clean up all managed resources.
                if (this.MDbgProcess != null)
                {

                    // Make sure the underlying CorProcess was stopped before 
                    // detached it.  
                    if (this.MDbgProcess.IsAlive)
                    {

                        var waithandler = this.MDbgProcess.AsyncStop();
                        waithandler.WaitOne();
                        this.MDbgProcess.Detach();
                    }

                }
            }

            disposed = true;
        }


        #endregion


        #region Raise events

        private void MDbgProcess_PostDebugEvent(object sender, CustomPostCallbackEventArgs e)
        {
            switch (e.CallbackType)
            {
                case ManagedCallbackType.OnProcessExit:
                    this.OnProcessExit();
                    break;
                case ManagedCallbackType.OnException2:
                    var exceptionEventArgs = e.CallbackArgs as CorException2EventArgs;

                    if (exceptionEventArgs != null &&
                        exceptionEventArgs.EventType == CorDebugExceptionCallbackType.DEBUG_EXCEPTION_UNHANDLED)
                    {
                        MDbgValue value = new MDbgValue(this.MDbgProcess,
                            exceptionEventArgs.Thread.CurrentException);

                        this.OnOperationErrorOccurred(new ErrorEventArgs
                            {
                                Message = "Unhandled exception occurred in the debuggee.",
                                Error = new ApplicationException(string.Format(
                                    "Unhandled exception occurred in the debuggee.\nType:{0}\nMessage:{1}",
                                    value.GetStringValue(false),
                                    value.GetField("_message").GetStringValue(true))),
                                Ignorable = true
                            });
                    }

                    exceptionEventArgs.Continue = true;
                    break;
                default:
                    break;
            }
        }

        protected virtual void OnProcessExit()
        {
            if (this.ProcessExit != null)
            {
                this.ProcessExit(this, EventArgs.Empty);
            }
        }

        protected virtual void OnOperationErrorOccurred(ErrorEventArgs e)
        {
            if (this.OperationErrorOccurred != null)
            {
                this.OperationErrorOccurred(this, e);
            }
        }

        #endregion


        #region Static Methods



        /// <summary>
        /// Get all the running managed processes.
        /// </summary>
        /// <returns></returns>
        public static List<Process> EnumManagedProcesses()
        {
            int currentProcessID = Process.GetCurrentProcess().Id;

            CLRMetaHost host = new CLRMetaHost();

            List<Process> managedProcess = new List<Process>();

            foreach (Process proc in Process.GetProcesses())
            {
                if (proc.Id == currentProcessID)
                {
                    continue;
                }

                try
                {
                    bool isManagedProcess = IsManagedProcess(host, proc.Id);

                    if (isManagedProcess)
                    {
                        managedProcess.Add(proc);
                    }
                }
                catch (Win32Exception)
                {
                    continue;
                }
                catch (COMException)
                {
                    continue;
                }
            }
            return managedProcess;
        }

        /// <summary>
        /// Determine whether a process is managed.
        /// If a process loads .NET runtime, it is a managed process.
        /// </summary>
        public static bool IsManagedProcess(CLRMetaHost host, int processID)
        {
            IEnumerable<CLRRuntimeInfo> enumerable = host.EnumerateLoadedRuntimes(processID);

            return enumerable.Count() > 0;
        }

        /// <summary>
        /// Determine whether a process is managed.
        /// If a process loads .NET runtime, it is a managed process.
        /// <summary>
        public static bool IsManagedProcess(int processID)
        {
            CLRMetaHost host = new CLRMetaHost();

            IEnumerable<CLRRuntimeInfo> enumerable =
                host.EnumerateLoadedRuntimes(processID);

            return enumerable.Count() > 0;
        }

        /// <summary>
        /// Determine whether an application is managed.
        /// </summary>
        public static bool IsManagedExecutableFile(string applicationPath,
            out string version)
        {
            version = MdbgVersionPolicy.GetDefaultRuntimeForFile(applicationPath);
            return !string.IsNullOrEmpty(version);
        }


        #endregion
    }
}

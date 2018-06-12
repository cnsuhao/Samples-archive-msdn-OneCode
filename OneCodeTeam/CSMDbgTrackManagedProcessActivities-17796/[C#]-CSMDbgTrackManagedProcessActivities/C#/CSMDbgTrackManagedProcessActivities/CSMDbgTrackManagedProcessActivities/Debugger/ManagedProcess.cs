/****************************** Module Header ******************************\
 * Module Name:  ManagedProcess.cs
 * Project:      CSMDbgTrackManagedProcessActivities
 * Copyright (c) Microsoft Corporation.
 * 
 * This class represents a managed process. It contains a MDbgProcess field
 * and a System.Diagnostics.Process field. When a new instance is initialized,
 * it will attach a debugger to the target process, and supplied following 
 * features:
 * 
 * 1. Log the activities of the debuggee. The activities include:
 *    a. A thread is created or a thread exits.
 *    b. An AppDomain is created or an AppDomain is unloaded.
 *    c. An exception is thrown. 
 *    d. Other output information like Debugger.Log()
 *    e. The process exits. 
 *    
 *    If there is an unhandled exception in the debuggee, the OperationErrorOccurred
 *    event will be raised.
 * 2. Check whether a running process is managed.
 * 3. Check whether an executable file is managed. 
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
using Microsoft.Samples.Debugging.CorDebug.NativeApi;
using Microsoft.Samples.Debugging.MdbgEngine;

namespace CSMDbgTrackManagedProcessActivities.Debugger
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

        public event EventHandler<PostEventArgs> PostEvent;

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


        #region Initialize

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

        /// <summary>
        /// Log the activities of the debuggee. The activities include:
        /// a. A thread is created or a thread exits.
        /// b. An AppDomain is created or an AppDomain is unloaded.
        /// c. An exception is thrown. 
        /// d. Other output information like Debugger.Log()
        /// e. The process exits. 
        /// 
        /// If there is an unhandled exception in the debuggee, the OperationErrorOccurred
        /// event will be raised.
        /// </summary>
        private void MDbgProcess_PostDebugEvent(object sender, CustomPostCallbackEventArgs e)
        {
            try
            {
                switch (e.CallbackType)
                {
                    case ManagedCallbackType.OnProcessExit:
                        this.OnProcessExit();
                        break;
                    case ManagedCallbackType.OnException2:
                        var exceptionEventArgs = e.CallbackArgs as CorException2EventArgs;

                        if (exceptionEventArgs != null)
                        {
                            MDbgValue exceptionValue = new MDbgValue(this.MDbgProcess,
                                 exceptionEventArgs.Thread.CurrentException);

                            string exceptionType = exceptionValue.GetStringValue(false);
                            string exceptionMessage = exceptionValue.GetField("_message").GetStringValue(true);

                            // If there is an unhandled exception in the debuggee.
                            if (exceptionEventArgs.EventType == CorDebugExceptionCallbackType.DEBUG_EXCEPTION_UNHANDLED)
                            {
                                this.OnOperationErrorOccurred(new ErrorEventArgs
                                {
                                    Message = "Unhandled exception occurred in the debuggee.",
                                    Error = new ApplicationException(string.Format(
                                        "Unhandled exception occurred in the debuggee.{2}Type:{0}{2}Message:{1}",
                                        exceptionType, exceptionMessage, Environment.NewLine)),
                                    Ignorable = true
                                });
                            }
                            else
                            {
                                AddActivity("Event Type: {0} {3} {1}:{2}",
                                    exceptionEventArgs.EventType, exceptionType,
                                    exceptionMessage, Environment.NewLine);

                            }
                        }

                        // Make the process continue.
                        exceptionEventArgs.Continue = true;
                        break;

                    case ManagedCallbackType.OnCreateThread:

                        var createThreadEventArgs = e.CallbackArgs as CorThreadEventArgs;

                        if (createThreadEventArgs != null)
                        {
                            AddActivity("Create Thread. ThreadID: {0}", createThreadEventArgs.Thread.Id);
                        }
                        break;
                    
                    case ManagedCallbackType.OnThreadExit:
                        CorThreadEventArgs threadExitEventArgs = e.CallbackArgs as CorThreadEventArgs;

                        if (threadExitEventArgs != null)
                        {
                            AddActivity("Thread Exit. ThreadID: {0}", threadExitEventArgs.Thread.Id);
                        }
                        break;

                    case ManagedCallbackType.OnCreateAppDomain:
                        var createAppDomainEventArgs = e.CallbackArgs as CorAppDomainEventArgs;

                        if (createAppDomainEventArgs != null)
                        {
                            AddActivity("Create AppDomain. DomainID: {0} DomainName: {1}",
                                createAppDomainEventArgs.AppDomain.Id,
                                createAppDomainEventArgs.AppDomain.Name);
                        }
                        break;
                   
                    case ManagedCallbackType.OnAppDomainExit:
                        var appDomainExitEventArgs = e.CallbackArgs as CorAppDomainEventArgs;

                        if (appDomainExitEventArgs != null)
                        {
                            AddActivity("AppDomain Exit. DomainID: {0} DomainName: {1}",
                                appDomainExitEventArgs.AppDomain.Id,
                                appDomainExitEventArgs.AppDomain.Name);
                        }
                        break;
                   
                    case ManagedCallbackType.OnLogMessage:
                        var logMessageEventArgs = e.CallbackArgs as CorLogMessageEventArgs;

                        if (logMessageEventArgs != null)
                        {
                            AddActivity("Log Message: {0}", logMessageEventArgs.Message);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch { }
        }

        /// <summary>
        /// Log the activity.
        /// </summary>
        private void AddActivity(string format, params object[] arguments)
        {
            string msg = string.Format(format, arguments);
            AddActivity(msg);
        }

        /// <summary>
        /// Log the activity.
        /// </summary>
        private void AddActivity(string msg)
        {
            this.OnPostEvent(new PostEventArgs
                {
                    EventMessage = msg
                });
        }

        /// <summary>
        /// Raise the PostEvent event.
        /// </summary>
        protected virtual void OnPostEvent(PostEventArgs e)
        {
            if (this.PostEvent != null)
            {
                this.PostEvent(this, e);
            }
        }

        /// <summary>
        /// Raise the ProcessExit event.
        /// </summary>
        protected virtual void OnProcessExit()
        {
            if (this.ProcessExit != null)
            {
                this.ProcessExit(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Raise the OperationErrorOccurred event.
        /// </summary>
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

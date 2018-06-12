/****************************** Module Header ******************************\
 * Module Name:  ManagedDebugger.cs
 * Project:      CSMDbgEvaluateFunction
 * Copyright (c) Microsoft Corporation.
 * 
 * This class represents a managed debugger. It can debug a running managed 
 * process, or launch a managed application to debug.
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
using Microsoft.Samples.Debugging.MdbgEngine;

namespace CSMDbgEvaluateFunction.Debugger
{
    [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
    public class ManagedDebugger
    {

        // Only one ManagedDebugger instance.
        static object locker = new object();

        static ManagedDebugger instance = null;

        public static ManagedDebugger Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new ManagedDebugger();
                        }
                    }
                }
                return instance;
            }
        }

        MDbgEngine debugger = null;

        /// <summary>
        /// The MDbgEngine instance.
        /// </summary>
        public MDbgEngine Debugger
        {
            get
            {
                if (debugger == null)
                {
                    debugger = new MDbgEngine();
                    debugger.Options.StopOnUnhandledException = false;
                }
                return debugger;
            }
        }

        /// <summary>
        /// ManagedDebugger cannot be Instantiated.
        /// </summary>
        private ManagedDebugger() { }

        /// <summary>
        /// Attatch debugger to a running peocess.
        /// </summary>
        /// <returns>
        /// A ManagedProcess instance.
        /// </returns>
        public ManagedProcess AttachTo(int processID)
        {
            
            // Cannot attach to current process itself.
            int currentProcessID = Process.GetCurrentProcess().Id;
            if (currentProcessID == processID)
            {
                throw new ArgumentException("Cannot attach to the debugger itself.");
            }

            // Determine whether the target is a managed process.
            bool isManaged = ManagedProcess.IsManagedProcess(processID);
            if (!isManaged)
            {
                throw new ArgumentException("It is not a managed application.");
            }

            try
            {

                // Get the runtime version of the target process.
                string version = MdbgVersionPolicy.GetDefaultAttachVersion(processID);

                // Attach to the target process.
                var mdbgProcess = this.Debugger.Attach(processID, version);

                // Instantiate a ManagedProcess instance.
                var managedProcess = new ManagedProcess(mdbgProcess);

                // Initialize the ManagedProcess instance.
                managedProcess.Initialize();

                return managedProcess;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error in AttachProcess.", ex);
            }
        }

        /// <summary>
        /// Launch a managed application to debug.
        /// </summary>
        public ManagedProcess CreateProcess(string applicationPath)
        {
            string version = null;

            // Determine whether the target is a managed application. If so, 
            // get the runtime version.
            bool isManaged = ManagedProcess.IsManagedExecutableFile(
                applicationPath, out version);

            if (!isManaged)
            {
                throw new ArgumentException("It is not a managed application.");
            }

            try
            {
                
                // Launch a managed application to debug.
                var mdbgProcess = this.Debugger.CreateProcess(applicationPath,
                    string.Empty, DebugModeFlag.Debug, version);

                var managedProcess = new ManagedProcess(mdbgProcess);

                managedProcess.Initialize();

                return managedProcess;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error in CreateProcess.", ex);
            }
        }
    }
}

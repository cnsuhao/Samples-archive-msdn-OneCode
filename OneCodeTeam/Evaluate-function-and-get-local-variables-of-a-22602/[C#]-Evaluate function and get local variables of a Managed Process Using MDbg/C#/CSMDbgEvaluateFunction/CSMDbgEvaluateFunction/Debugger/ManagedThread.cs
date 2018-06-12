/****************************** Module Header ******************************\
 * Module Name:  ManagedThread.cs
 * Project:      CSMDbgEvaluateFunction
 * Copyright (c) Microsoft Corporation.
 * 
 * This class represents a managed thread. In this sample, it is used to find 
 * the frame that has source code in the thread. 
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

using Microsoft.Samples.Debugging.MdbgEngine;
using System.Security.Permissions;
using System.Linq;

namespace CSMDbgEvaluateFunction.Debugger
{
    [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
    public class ManagedThread
    {
        public ManagedProcess Process { get; private set; }

        public MDbgThread MDbgThread { get; private set; }

        public int ThreadID{get; private set;}

        public string Function{get; private set;}

        public string SourcePosition{get; private set;}

        public MDbgFrame SourcePositionFrame { get; private set; }

        public ManagedThread(ManagedProcess process, MDbgThread thread)
        {
            this.Process = process;
            this.MDbgThread = thread;
            this.Update();
        }

        /// <summary>
        /// Find the frame that has source code in the thread. 
        /// </summary>
        public void Update()
        {
            this.ThreadID = this.MDbgThread.Id;

            bool flag = false;

            if (this.MDbgThread.HaveCurrentFrame)
            {
                var frame = this.MDbgThread.CurrentFrame;

                while (frame != null && frame.SourcePosition == null)
                {
                    frame = frame.NextUp;
                }

                if (frame !=null && frame.SourcePosition != null)
                {
                    this.Function = frame.Function.FullName;
                    var position = frame.SourcePosition;
                    this.SourcePosition = string.Format("File:{0} , Line:{1}",
                        System.IO.Path.GetFileName(position.Path), position.Line);
                    this.SourcePositionFrame = frame;

                    flag = true;
                }
            }
         
            if (!flag)
            {
                this.SourcePositionFrame = null;
                this.Function = string.Empty;
                this.SourcePosition = "Cannot find source.";
            }
        }

        /// <summary>
        /// Step out to a managed frame.
        /// </summary>
        public void StepToManagedCode()
        {
            this.Process.MDbgProcess.Threads.Active = this.MDbgThread;

            while (this.MDbgThread.HaveCurrentFrame 
                && this.MDbgThread.Frames!=null
                && this.MDbgThread.Frames.Count()>0
                && !this.MDbgThread.Frames.First().IsManaged)
            {
                
                this.Process.MDbgProcess.StepOut().WaitOne();
            }
        }
    }
}

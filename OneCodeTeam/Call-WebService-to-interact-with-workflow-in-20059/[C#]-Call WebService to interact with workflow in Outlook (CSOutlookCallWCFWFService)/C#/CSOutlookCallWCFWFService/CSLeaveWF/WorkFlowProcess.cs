/****************************** Module Header ******************************\
* Module Name:  WorkFlowProcess.cs
* Project:      CSLeaveWF
* Copyright(c) Microsoft Corporation.
* 
* This Class is used to create workflow application, run it and update the 
* changes to database.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/


using System;
using System.Activities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DBOperate;

namespace CSLeaveWF
{
    public class WorkFlowProcess
    {
        /// <summary>
        /// Creates a workflow application, binds parameters run it.
        /// </summary>
        /// <param name="leaveName">The Name of leave </param>
        /// <param name="leaveDay">The Day of leave</param>
        public static void CreateAndRun(string leaveName, int leaveDay)
        {
            // Initialize input argument
            IDictionary<string, object> input = new Dictionary<string, object> 
            {
                { "LeaveName" , leaveName },
                { "LeaveDay" , leaveDay }
            };

            // Initialize a host for the instance of workflow
            WorkflowApplication application = new WorkflowApplication(new LeaveProcess(), input);
            Guid id = application.Id;

            // Begins the execution of a workflow instance
            application.Run();    
        }

        /// <summary>
        /// Approve or Reject Leave request
        /// </summary>
        /// <param name="iD">Leave ID</param>
        /// <param name="comment">Approve or Reject</param>
        public static void RunInstance(Guid iD, string comment)
        {
            using (LeaveDataContext dc = new LeaveDataContext())
            {
                Leave info = dc.Leaves.Single(p => p.LeaveID == iD);
                if (!String.IsNullOrEmpty(comment))
                {
                    if (comment.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                    {
                        info.Status = "Approval";
                    }
                    else if (comment.Equals("No", StringComparison.OrdinalIgnoreCase))
                    {
                        info.Status = "Reject";
                    }
                    else
                    {
                        info.Status = "Pending";
                    }

                    // Submit Changes to Database 
                    dc.SubmitChanges();
                }
                else
                {
                    throw new ArgumentNullException("comment", "comment can not be null!");
                }
            }
        }
    }
}

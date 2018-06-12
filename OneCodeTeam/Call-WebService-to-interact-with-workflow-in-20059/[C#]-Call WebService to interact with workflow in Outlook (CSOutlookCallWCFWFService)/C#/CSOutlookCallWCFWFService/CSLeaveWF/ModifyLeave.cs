/****************************** Module Header ******************************\
* Module Name: ModifyLeave.cs
* Project:     CSLeaveWF
* Copyright(c) Microsoft Corporation.
* 
* This Class is used to modify the state of Leave request in database.
*
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/



using System.Activities;
using System.Linq;
using DBOperate;

namespace CSLeaveWF
{
    public class ModifyLeave : CodeActivity
    {
        // Leave entity 
        public InArgument<Leave> UpdateLeaveInfo { get; set; }

        // The state of workflow
        public InArgument<string> State { get; set; }

        // Called by the workflow runtime to execute an activity
        protected override void Execute(CodeActivityContext context)
        {
            using (LeaveDataContext dc = new LeaveDataContext())
            {
                Leave info = dc.Leaves.Single(p => p.LeaveID == UpdateLeaveInfo.Get(context).LeaveID);
                State.Set(context, "Complete");
                info.Status = "Pending";

                // Update the status of Leave record in database
                dc.SubmitChanges();
            }
        }
    }
}

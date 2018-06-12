/****************************** Module Header ******************************\
* Module Name:  CreateLeave.cs
* Project:      CSLeaveWF
* Copyright (c) Microsoft Corporation.
* 
* This Class is used to create a leave request in workflow.
* Here we use Linq to Sql to add record into Sql server. 
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
using DBOperate;

namespace CSLeaveWF
{
    public class CreateLeave : CodeActivity
    {
        // Input Parameters in workflow
        public InArgument<string> Name { get; set; }
        public InArgument<int> Day { get; set; }
        public InArgument<string> Comment { get; set; }

        // Output parameters in workflow
        // return a Leave entity
        public OutArgument<Leave> ObjLeave { get; set; }

        // Called by the workflow runtime to execute an activity
        protected override void Execute(CodeActivityContext context)
        {
            using (LeaveDataContext dc = new LeaveDataContext())
            {
                // Create leave record to sql server
                Leave info = new Leave();
                info.LeaveID = context.WorkflowInstanceId;
                info.LeaveName = Name.Get(context);
                info.LeaveDay = Day.Get(context);
                info.Comment = Comment.Get(context);
                info.Status = "Initialization";

                dc.Leaves.InsertOnSubmit(info);
                dc.SubmitChanges();

                // Set Output Argument
                ObjLeave.Set(context, info);
            }
        }
    }
}

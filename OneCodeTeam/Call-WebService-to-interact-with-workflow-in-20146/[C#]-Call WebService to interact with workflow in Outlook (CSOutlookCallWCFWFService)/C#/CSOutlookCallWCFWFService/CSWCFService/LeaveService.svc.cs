/****************************** Module Header ******************************\
* Module Name:  LeaveService.cs
* Project:      CSWCFService
* Copyright (c) Microsoft Corporation.
* 
* This class inherits the ILeaveService class and implement the methods. 
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
using System.Collections.Generic;
using System.Linq;
using CSLeaveWF;
using DBOperate;

namespace CSWCFService
{
    public class LeaveService : ILeaveService
    {
        /// <summary>
        /// Get Pending list
        /// </summary>
        /// <returns></returns>
        public List<Leave> GetLeaveList()
        {
            using (LeaveDataContext dc = new LeaveDataContext())
            {
                List<Leave> leaves = dc.Leaves.Where(p => p.Status == "Pending").ToList();
                return leaves;
            }
        }

        /// <summary>
        /// Create Leave
        /// </summary>
        /// <param name="name">The Name of Leave</param>
        /// <param name="day">The Day of Leave</param>
        public void CreateLeave(string name, string day)
        {
            WorkFlowProcess.CreateAndRun(name, int.Parse(day));
        }

        /// <summary>
        /// Audit Leave
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comment"></param>
        public void AuditingLeave(string id, string comment)
        {
            WorkFlowProcess.RunInstance(Guid.Parse(id), comment);
        }
    }
}

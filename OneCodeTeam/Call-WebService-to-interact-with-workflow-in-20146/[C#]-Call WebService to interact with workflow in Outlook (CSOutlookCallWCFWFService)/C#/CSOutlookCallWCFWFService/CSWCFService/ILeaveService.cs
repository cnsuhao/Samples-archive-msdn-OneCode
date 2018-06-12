/****************************** Module Header ******************************\
* Module Name:   ILeaveService.cs
* Project:       CSWCFService
* Copyright (c)  Microsoft Corporation.
* 
* This Class is a service interface. Here we define three service methods.
* Outlook Client will call this WCF service to interact with workflow.
*
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/


using System.Collections.Generic;
using System.ServiceModel;
using DBOperate;

namespace CSWCFService
{
    [ServiceContract]
    public interface ILeaveService
    {
        /// <summary>
        /// Get checking list
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<Leave> GetLeaveList();

        /// <summary>
        /// Create Leave
        /// </summary>
        /// <param name="name"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        [OperationContract]
        void CreateLeave(string name, string day);

        /// <summary>
        /// audit Leave
        /// </summary>
        /// <param name="id">Leave Id</param>
        /// <param name="comment">Approve or Reject</param>
        /// <returns></returns>
        [OperationContract]
        void AuditingLeave(string id, string comment);
    }
}


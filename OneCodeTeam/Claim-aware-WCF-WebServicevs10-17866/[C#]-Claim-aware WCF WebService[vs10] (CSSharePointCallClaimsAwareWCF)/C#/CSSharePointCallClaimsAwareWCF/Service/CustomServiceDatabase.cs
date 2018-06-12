/****************************** Module Header ******************************\
* Module Name:    CustomServiceDatabase.cs
* Project:        CSSharePointCallClaimsAwareWCF
* Copyright (c) Microsoft Corporation
*
* A common SQL Server database provisioning infrastructure (to use your own database to store data)
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Principal;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

namespace CustomService
{
    [System.Runtime.InteropServices.Guid("FE92B481-00B1-4ad7-9E89-2DFEF629F38A")]
    internal sealed class CustomServiceDatabase : SPDatabase
    {
        public CustomServiceDatabase() { }

        internal CustomServiceDatabase(SPDatabaseParameters dbParameters)
            : base(dbParameters)
        {
            this.Status = SPObjectStatus.Disabled;
        }

        public override void Provision()
        {
            // stop if DB is already provisioned
            if (SPObjectStatus.Online == this.Status)
                return;

            this.Status = SPObjectStatus.Provisioning;
            this.Update();

            Dictionary<string, bool> options = new Dictionary<string, bool>(1);
            options.Add(SqlDatabaseOption[(int)DatabaseOptions.AutoClose], false);

            SPDatabase.Provision(
                this.DatabaseConnectionString,
                SPUtility.GetGenericSetupPath(@"Template\sql\CustomService.sql"),
                options);

            this.Status = SPObjectStatus.Online;
            this.Update();
        }

        internal void GrantApplicationPoolAccess(SecurityIdentifier processSecurityIdentifier)
        {
            this.GrantAccess(processSecurityIdentifier, "db_owner");
        }

    }
}
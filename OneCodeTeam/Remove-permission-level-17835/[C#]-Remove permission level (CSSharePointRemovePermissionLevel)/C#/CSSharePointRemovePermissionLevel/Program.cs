/****************************** Module Header ******************************\
* Module Name:    Program.cs
* Project:        CSSharePointRemovePermissionLevel
* Copyright (c) Microsoft Corporation
*
* This sample code demonstrates how to programmatically remove specific 
* permission level from group in SharePoint 2010. Generally, we can remove 
* a specific permission level by removing the group’s role assignments from 
* the target web, list, or item.  Also, this sample also shows you how to 
* assign specific permission level to the group.
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
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace CSSharePointRemovePermissionLevel
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connect to SharePoint Site
            string siteUrl = "http://win-2ed380lbo8e/";

            // Group Title
            string groupTitle = "test123";

            // Remove a specific permission level from a group.
            SetPermissionsToGroup(siteUrl, groupTitle);
        }

        /// <summary>
        /// To remove a specific permission level, you have to remove the role assignments from a group.
        /// The various definitions, such as Contribute and Full Control 
        /// can be fetched from the [SPWeb].RoleDefinitions collection. For example:
        /// Administrator>>Full  Control WebDesigner>>Design  Contributor>>Contribute
        /// Reader>>Read  Guest>>Limited Access  None>>View Only
        /// </summary>
        /// <param name="siteUrl">Site Url</param>
        /// <param name="groupTitle">Group title</param>
        public static void SetPermissionsToGroup(string siteUrl, string groupTitle)
        {
            using (var site = new SPSite(siteUrl)) // Connect to SharePoint Site
            {
                using (var web = site.OpenWeb())// Open SharePoint Site
                {
                    // Get group and group roles 
                    var group = web.SiteGroups[groupTitle];
                    var roles = web.RoleAssignments.GetAssignmentByPrincipal(group);

                    #region method 1
                    #region Remove contribute role
                    // Get the SPRoleDefinition
                    SPRoleDefinition sprd = web.RoleDefinitions.GetByType(SPRoleType.Contributor);
                    
                    // Remove the SPRoleDefinition
                    roles.RoleDefinitionBindings.Remove(sprd);
                    
                    // Updates the Role Assignment
                    roles.Update();
                    #endregion

                    //// Add contribute role 
                    //roles.RoleDefinitionBindings.Add(web.RoleDefinitions["Contribute"]);
                    //roles.Update(); 
                    #endregion                   

                    // [-or-]

                    #region method 2
                    //// Remove Read role 
                    //roles.RoleDefinitionBindings.Remove(web.RoleDefinitions["Read"]);
                    //roles.Update();

                    //// Add Read role 
                    //roles.RoleDefinitionBindings.Add(web.RoleDefinitions.GetByType(SPRoleType.Reader));
                    //roles.Update();
                    #endregion
                }
            }
        }

    }
}

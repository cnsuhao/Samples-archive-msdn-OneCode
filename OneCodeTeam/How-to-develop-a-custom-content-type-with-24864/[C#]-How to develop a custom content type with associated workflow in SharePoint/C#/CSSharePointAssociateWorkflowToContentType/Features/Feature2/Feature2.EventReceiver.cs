/****************************** Module Header ******************************\
* Module Name:    Feature2.EventReceiver.cs
* Project:        CSSharePointAssociateWorkflowToContentType
* Copyright (c) Microsoft Corporation
*
* This sample would let developers know what's happening in the background
* when they associate a workflow to a content type.
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
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Workflow;

namespace CSSharePointAssociateWorkflowToContentType.Features.Feature2
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("00a0f069-71d7-406d-8ffb-4f8d555016f7")]
    public class Feature2EventReceiver : SPFeatureReceiver
    {
        // Your site
        private string siteName = "http://win-2ed380lbo8e:7947/";
        // Workflow Name
        private string WorkflowName = "WorkflowForContentType";
        // ContentType Name
        private string ContentTypeName = "MyContentType";

        // Uncomment the method below to handle the event raised after a feature has been activated. 

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            UpdateWorkflowAssociation(1);
        }

        // Uncomment the method below to handle the event raised before a feature is deactivated.

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            UpdateWorkflowAssociation(0);
        }

        /// <summary>
        /// Set the associated between workflow and Content Type.
        /// </summary>
        /// <param name="type">0: Remove; 1: Add or update</param>
        private void UpdateWorkflowAssociation(int type)
        {
            // Connect to Sharepoint Site
            using (SPSite site = new SPSite(siteName))
            {
                // Open Sharepoint Site
                using (SPWeb web = site.OpenWeb())
                {
                    // Get the ContentType by Specific Name
                    SPContentType theCT = web.ContentTypes[ContentTypeName];
                    // Workflow Template
                    SPWorkflowTemplate theWF = null;

                    // Fetch the collection of Workflow Template to get the specific one
                    foreach (SPWorkflowTemplate tpl in web.WorkflowTemplates)
                    {
                        if (tpl.Name == WorkflowName)
                        {
                            theWF = tpl;
                        }
                    }

                    // Represents the association of the workflow template
                    SPWorkflowAssociation wfAssociation = theCT.WorkflowAssociations.GetAssociationByName(WorkflowName, web.Locale);

                    // If it has associated, remove the association. 
                    if (wfAssociation != null)
                    {
                        theCT.WorkflowAssociations.Remove(wfAssociation);
                    }

                    //  Update Workflow Associations
                    theCT.UpdateWorkflowAssociationsOnChildren(true, true, true, false);

                    //
                    if (type > 0)
                    {
                        // Create web ContentType association to the workflow template
                        wfAssociation = SPWorkflowAssociation.CreateWebContentTypeAssociation(theWF, WorkflowName, "Tasks", "Workflow History");

                        // If it hasn't associated then to add a association. Or updates the association.
                        if (theCT.WorkflowAssociations.GetAssociationByName(wfAssociation.Name, web.Locale) == null)
                        {
                            theCT.WorkflowAssociations.Add(wfAssociation);
                        }
                        else
                        {
                            theCT.WorkflowAssociations.Update(wfAssociation);
                        }

                        //  Update Workflow Associations
                        theCT.UpdateWorkflowAssociationsOnChildren(true, true, true, false);
                    }
                }
            }
        }

        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}

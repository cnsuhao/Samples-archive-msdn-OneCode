/****************************** Module Header ******************************\
 * Module Name:  PageStatusEventReceiver.cs
 * Project:      CSSharePointSetPageStatus
 * Copyright (c) Microsoft Corporation.
 * 
 * This sample will show you how to add page status to an application page
 * and from list event receiver. 
 *
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;

namespace CSSharePointSetPageStatus.PageStatusEventReceiver
{
    /// <summary>
    /// List Item Events.
    /// </summary>
    public class PageStatusEventReceiver : SPItemEventReceiver
    {
        StatusBarWebPart.StatusBarWebPart statusBarWebPart;

        /// <summary>
        /// An item was added.
        /// </summary>
        public override void ItemAdded(SPItemEventProperties properties)
        {
            base.ItemAdded(properties);

            SPWeb web = properties.Web;
            string oUrl = properties.List.DefaultViewUrl;
            Microsoft.SharePoint.WebPartPages.SPLimitedWebPartManager coll = web.GetLimitedWebPartManager(oUrl, System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);

            if (coll.WebParts.Count > 1)
            {
                statusBarWebPart = (StatusBarWebPart.StatusBarWebPart)coll.WebParts[1];
                if (statusBarWebPart != null)
                {
                    statusBarWebPart.Message = "Item Added";
                    coll.SaveChanges(statusBarWebPart);               
                }
            }
            else
            {
                statusBarWebPart = new StatusBarWebPart.StatusBarWebPart();
                statusBarWebPart.Message = "Item Added";
                statusBarWebPart.Hidden = true;
                coll.AddWebPart(statusBarWebPart, "Left", 1); 
                coll.SaveChanges(statusBarWebPart);
            }           
        }

       
        /// <summary>
        /// An item was updated.
        /// </summary>
        public override void ItemUpdated(SPItemEventProperties properties)
        {
            base.ItemUpdated(properties);

            SPWeb web = properties.Web;
            string oUrl = properties.List.DefaultViewUrl;
            Microsoft.SharePoint.WebPartPages.SPLimitedWebPartManager coll = web.GetLimitedWebPartManager(oUrl, System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);

            if (coll.WebParts.Count > 1)
            {
                statusBarWebPart = (StatusBarWebPart.StatusBarWebPart)coll.WebParts[1];
                if (statusBarWebPart != null)
                {
                    statusBarWebPart.Message = "Item Updated";
                    coll.SaveChanges(statusBarWebPart);               
                }
            }
            else
            {
                statusBarWebPart = new StatusBarWebPart.StatusBarWebPart();
                statusBarWebPart.Message = "Item Updated";
                statusBarWebPart.Hidden = true;
                coll.AddWebPart(statusBarWebPart, "Left", 1);
                coll.SaveChanges(statusBarWebPart);            
            }           
        }
    }
}
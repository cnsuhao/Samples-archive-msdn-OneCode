/****************************** Module Header ******************************\
Module Name:  EventReceiver1.cs
Project:      CSSharePointAddAlertForDiscussionBoard
Copyright (c) Microsoft Corporation.

The event of the EventReceiver.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;

namespace AddAlertForDiscussionBoard.EventReceiver1
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class EventReceiver1 : SPItemEventReceiver
    {
        /// <summary>
        /// Send Email to topic owner while an item was added.
        /// </summary>
        public override void ItemAdded(SPItemEventProperties props)
        {
            base.ItemAdded(props);

            try
            {        
                SPList list = props.OpenWeb().Lists[props.ListId];
                SPListItemCollection collListItems = list.GetItems();
                StringDictionary headers = AddAlertForDiscussionBoard.Helper.getHeaders();

                var taskListItems = (from SPListItem tItem in list.Items
                                     orderby tItem.ID ascending
                                     select tItem).First();

                SPListItem spl = (SPListItem)taskListItems;
                SPUser spOwner = AddAlertForDiscussionBoard.Helper.GetSPUserFromSPListItemByFieldName(spl, "Created By");

                AddAlertForDiscussionBoard.Helper.strMailto = spOwner.Email;
                AddAlertForDiscussionBoard.Helper.strMailBody = "Send Email to topic owner"; 
                AddAlertForDiscussionBoard.Helper.SendEmail(SPContext.Current.Web);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

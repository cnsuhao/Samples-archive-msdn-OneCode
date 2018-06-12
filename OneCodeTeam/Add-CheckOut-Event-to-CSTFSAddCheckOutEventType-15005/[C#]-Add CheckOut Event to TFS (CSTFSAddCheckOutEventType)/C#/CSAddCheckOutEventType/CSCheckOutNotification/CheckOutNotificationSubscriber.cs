/****************************** Module Header ******************************\
 * Module Name:   CheckOutNotificationSubscriber.cs
 * Project:       CSCheckOutNotification
 * Copyright (c) Microsoft Corporation.
 * 
 * This class implements the Microsoft.TeamFoundation.Framework.Server.ISubscriber
 * interface, and subscribes the PendChangesNotification. The ProcessEvent method
 * will be called when the server receives the pend change request, and in this
 * method, we can fire the custom CheckOutEvent, then TFSJobAgent will send out 
 * the  alert.
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using Microsoft.TeamFoundation.Common;
using Microsoft.TeamFoundation.Framework.Server;
using Microsoft.TeamFoundation.VersionControl.Server;

namespace CSCheckOutNotification
{
    public class CheckOutNotificationSubscriber : ISubscriber
    {

        public string Name
        {
            get
            {
                return "Team Foundation Source Control: CheckOut Alert Provider";
            }
        }

        public SubscriberPriority Priority
        {
            get
            {
                return SubscriberPriority.Normal;
            }
        }

        /// <summary>
        /// Return the types that it subscribes.
        /// </summary>
        /// <returns></returns>
        public Type[] SubscribedTypes()
        {
            return new Type[] { typeof(PendChangesNotification) };
        }

        /// <summary>
        /// The ProcessEvent method will be called when the server receives the pend
        /// change request, and in this method, we can fire the custom CheckOutEvent,
        /// then TFSJobAgent will send out the alert.
        /// </summary>
        /// <param name="requestContext">
        /// From the request, we can get the parameters that contains the detailed 
        /// information.
        /// </param>
        /// <param name="notificationType">
        /// DecisionPoint: before the request is processed.
        /// Notification: after the request is processed.
        /// 
        /// In this sample, this parameter is DecisionPoint.
        /// </param>
        /// <param name="notificationEventArgs">
        /// An instance of PendChangesNotification.
        /// </param>
        /// <param name="statusCode"></param>
        /// <param name="statusMessage"></param>
        /// <param name="properties"></param>
        /// <returns>
        /// Return EventNotificationStatus.ActionPermitted.
        /// </returns>
        public EventNotificationStatus ProcessEvent(
            TeamFoundationRequestContext requestContext,
            NotificationType notificationType,
            object notificationEventArgs,
            out int statusCode,
            out string statusMessage,
            out ExceptionPropertyCollection properties)
        {
            statusCode = 0;
            properties = null;
            statusMessage = string.Empty;

            try
            {
                if (notificationEventArgs is PendChangesNotification)
                {

                    // Initialize a CheckOutEvent instance.
                    PendChangesNotification notification =
                        notificationEventArgs as PendChangesNotification;
                    CheckOutEvent checkoutEvent = new CheckOutEvent();
                    checkoutEvent.WorkspaceName = notification.WorkspaceName;
                    checkoutEvent.UserName = notification.UserName;
                    checkoutEvent.OwnerName = notification.OwnerName;

                    // Get the detailed information from the request context.

                    // Get the count of pend changes.
                    string changes = requestContext.Method.Parameters["changes"];
                    int count = 0;
                    if (int.TryParse(changes.Replace("Count = ", string.Empty), out count))
                    {
                        if (count > 0)
                        {
                            checkoutEvent.Items = new string[count];

                            for (int i = 0; i < count; i++)
                            {
                                checkoutEvent.Items[i] = string.Format("Path:{0} EditType:{1}",
                                    requestContext.Method.Parameters[string.Format("changes[{0}].ItemSpec", i)],
                                    requestContext.Method.Parameters[string.Format("changes[{0}].RequestType", i)]);
                            }
                        }
                    }

                    // Fire the CheckOutEvent.
                    this.FireSystemEvent(requestContext, checkoutEvent);
                }
            }
            catch (Exception exception)
            {
                TeamFoundationApplication.LogException("Sending Event Failed", exception);
            }
            return EventNotificationStatus.ActionPermitted;
        }

        /// <summary>
        ///  Fire the CheckOutEvent.
        /// </summary>
        private void FireSystemEvent(TeamFoundationRequestContext requestContext, object eventObject)
        {
            try
            {
                requestContext.GetService<TeamFoundationNotificationService>().FireSystemEvent(requestContext, eventObject);
            }
            catch (Exception exception)
            {
                TeamFoundationApplication.LogException("Sending Event Failed", exception);
            }
        }
    }
}

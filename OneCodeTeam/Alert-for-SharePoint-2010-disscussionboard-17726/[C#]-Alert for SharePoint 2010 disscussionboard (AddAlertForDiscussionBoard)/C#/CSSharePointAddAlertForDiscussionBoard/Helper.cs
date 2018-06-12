/****************************** Module Header ******************************\
Module Name:  Helper.cs
Project:      CSSharePointAddAlertForDiscussionBoard
Copyright (c) Microsoft Corporation.

The helper class of the feature.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint;

namespace AddAlertForDiscussionBoard
{
    internal class Helper
    {
        /// <summary>
        /// The name-value pairs for header fields.
        /// </summary>
        /// <returns>StringDictionary</returns>
        internal static StringDictionary getHeaders()
        {
            StringDictionary headers = new StringDictionary();
            headers.Add("Cc", "");
            headers.Add("Bcc", "");
            headers.Add("From", "seiya1223@hotmail.com");
            headers.Add("To", strMailto);
            headers.Add("subject", "New reply");
            headers.Add("content-type", "text/html");
            return headers;
        }

        internal static string strMailto = string.Empty;
        internal static string strMailBody = string.Empty;

        /// <summary>
        /// Send Email
        /// </summary>
        /// <param name="spWeb"></param>
        internal static void SendEmail(SPWeb spWeb)
        {
            if (strMailto.Length > 0)
            {
                SPUtility.SendEmail(spWeb, getHeaders(), strMailBody);
            }
        }

        /// <summary>
        /// Processing SPListItem, get this object "Created By" (creator), and return SPUser type
        /// </summary>
        /// <param name="spItem">SPListItem</param>
        /// <param name="fieldName">FieldName,it is "Created By" here</param>
        /// <returns>SPUser</returns>
        internal static SPUser GetSPUserFromSPListItemByFieldName(SPListItem spItem, string fieldName)
        {
            string userName = spItem[fieldName].ToString();
            SPFieldUser _user = (SPFieldUser)spItem.Fields[fieldName];
            SPFieldUserValue userValue = (SPFieldUserValue)_user.GetFieldValue(userName);
            return userValue.User;
        } 
    }
}

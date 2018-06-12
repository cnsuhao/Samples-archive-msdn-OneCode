/****************************** Module Header ******************************\
 * Module Name:   CheckOutEvent.cs
 * Project:       CSCheckOutNotification
 * Copyright (c) Microsoft Corporation.
 * 
 * This class contains the information of the checkout request.
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

namespace CSCheckOutNotification
{
    public class CheckOutEvent
    {
        public string OwnerName { get; set; }
        public string UserName { get; set; }
        public string WorkspaceName { get; set; }
        public string[] Items { get; set; }
    }
}

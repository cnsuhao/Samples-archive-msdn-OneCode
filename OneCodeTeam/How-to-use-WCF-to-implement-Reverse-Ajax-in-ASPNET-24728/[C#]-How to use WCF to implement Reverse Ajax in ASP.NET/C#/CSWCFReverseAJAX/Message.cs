/****************************** Module Header ******************************\
* Module Name:    Message.cs
* Project:        CSWCFReverseAJAX
* Copyright (c) Microsoft Corporation
*
* Message class contains all necessary fields in a message package.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

namespace CSWCFReverseAJAX
{
    /// <summary>
    /// This is a entity class that represents a message item.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// The name who will receive this message.
        /// </summary>
        public string RecipientName { get; set; }

        /// <summary>
        /// The message content.
        /// </summary>
        public string MessageContent { get; set; }
    }
}
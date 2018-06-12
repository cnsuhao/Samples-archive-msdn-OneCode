/****************************** Module Header ******************************\
Module Name:  FileAttachment.cs
Project:      CSAzureSendMailsByWorkerRole
Copyright (c) Microsoft Corporation.
 
As you know, System.Net.Mail api can't be used in Windows Runtime application, 
However, we can create a WCF service to consume the api, and hold this service 
on Azure.

In this way, we can use this service to send email in Windows Store app. 

This class contains necessary information of the attachment file.
 
This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System.Runtime.Serialization;
using System.IO;

namespace MailService.Model
{

    /// <summary>
    /// This class contains necessary information of the attachment file.
    /// </summary>
    [DataContract]
    public class FileAttachment
    {

        #region Public properties
        /// <summary>
        /// Save the file content as a byte array.
        /// </summary>
        [DataMember]
        public byte[] FileContentByteArray { get; set; }

        /// <summary>
        /// Contains necessary information of the file.<br/>
        /// </summary>
        [DataMember]
        public FileInfo Info { get; set; }
        #endregion
    }
}

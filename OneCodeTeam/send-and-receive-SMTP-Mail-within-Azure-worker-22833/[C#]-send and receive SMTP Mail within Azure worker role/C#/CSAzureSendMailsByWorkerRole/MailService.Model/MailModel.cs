/****************************** Module Header ******************************\
Module Name:  MailModel.cs
Project:      CSAzureSendMailsByWorkerRole
Copyright (c) Microsoft Corporation.
 
As you know, System.Net.Mail api can't be used in Windows Runtime application, 
However, we can create a WCF service to consume the api, and hold this service 
on Azure.

In this way, we can use this service to send email in Windows Store app. 

The Email Modle includes all the necessary message.
 
This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System.Runtime.Serialization;

namespace MailService.Model
{

    /// <summary>
    /// An Email Modle includes all the necessary message.
    /// </summary>
    [DataContract]
    public class MailModel
    {
        #region Public properties
        /// <summary>
        /// User's Live account Address.
        /// </summary>
        [DataMember]
        public string SourceAddress
        {
            get;
            set;
        }

        /// <summary>
        /// Password.
        /// </summary>
        [DataMember]
        public string SourcePassword
        {
            get;
            set;
        }

        /// <summary>
        /// The person's email address which you want to send.<br/>
        /// If there is multiple persons you need to send change this property to a string array.
        /// </summary>
        [DataMember]
        public string TargetAddress
        {
            get;
            set;
        }

        /// <summary>
        /// By default use "smtp.live.com" as Source Host in this sample.
        /// </summary>
        [DataMember]
        public string SourceHost
        {
            get;
            set;
        }

        /// <summary>
        /// Port 587 for Live smtp host.
        /// </summary>
        [DataMember]
        public int Port
        {
            get;
            set;
        }

        /// <summary>
        /// Email Title.
        /// </summary>
        [DataMember]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Attachement files.
        /// </summary>
        [DataMember]
        public FileAttachment[] Attachments
        {
            get;
            set;
        }

        /// <summary>
        /// Email Content.
        /// </summary>
        [DataMember]
        public string Text
        {
            get;
            set;
        }

        /// <summary>
        /// If the email content formate is HTML return true, else
        /// return false.
        /// </summary>
        [DataMember]
        public bool IsBodyHtml
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructs an Email Modle includes all the necessary message.
        /// </summary>
        /// <param name="UserEmailAddress">User email address</param>
        /// <param name="UserPassword">User password</param>
        /// <param name="TargetAddress">Target </param>
        /// <param name="Title">Email title</param>
        /// <param name="Text">Email content</param>
        /// <param name="IsBodyHtml">Email body's formate</param>
        /// <param name="FileAttachments">Email attachments</param>
        /// <param name="SourceHost">Email source host</param>
        /// <param name="Port">The port for Email source host</param>
        public MailModel(string UserEmailAddress, string UserPassword, string TargetAddress,string Title,
            string Text, bool IsBodyHtml, FileAttachment[] FileAttachments, string SourceHost = "smtp.live.com",int Port=587)
        {
            this.SourceAddress = UserEmailAddress;
            this.SourcePassword = UserPassword;
            this.TargetAddress = TargetAddress;
            this.Title = Title;
            this.Text = Text;
            this.IsBodyHtml = IsBodyHtml;
            this.Attachments = FileAttachments;
            this.SourceHost = SourceHost;
            this.Port = Port;
        }
        #endregion

    }
    
}

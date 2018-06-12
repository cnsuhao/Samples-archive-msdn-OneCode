/****************************** Module Header ******************************\
Module Name:  EmailModel.cs
Project:      CSASPNETSendingEmail
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to send an email with attachments and embedded
images using SMTP protocol in Asp.net. This is a very common issue in forums, 
customers always fall into troubles when they try to implement relative APIs,
that is because they receive many errors or exceptions, so we provide this 
sample code to show how to send an email with your web application, and this 
sample also demonstrates how to send emails asynchronously for improving 
user experience.

This is an email entity class with basic properties.
 
This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSASPNETSendingEmail
{
    public class EmailModel
    {
        public const string _SourceAddress = "Your Email Address";

        public const string _SourcePassword = "Your Email Password";

        public const string _TargetAddress = "Target Email Address";

        public const string _SourcetHost = "SMTP server host";

        public const string _Title = "Email Title";

        public const string _AttachmentUri = "Attachment URI";

        public const string _ImageUri = "Image URI";

        public const string _Text = "Email Text";

        public string SourceAddress
        {
            get;
            set;
        }

        public string SourcePassword
        {
            get;
            set;
        }

        public string TargetAddress
        {
            get;
            set;
        }

        public string SourcetHost
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string AttachmentUri
        {
            get;
            set;
        }

        public string ImageUri
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }
    }
}
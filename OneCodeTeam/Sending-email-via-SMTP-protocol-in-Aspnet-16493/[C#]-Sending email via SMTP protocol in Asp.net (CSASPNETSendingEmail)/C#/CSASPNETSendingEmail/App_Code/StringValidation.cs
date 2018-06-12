/****************************** Module Header ******************************\
Module Name:  StringValidation.cs
Project:      CSASPNETSendingEmail
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to send an email with attachments and embedded
images using SMTP protocol in Asp.net. This is a very common issue in forums, 
customers always fall into troubles when they try to implement relative APIs,
that is because they receive many errors or exceptions, so we provide this 
sample code to show how to send an email with your web application, and this 
sample also demonstrates how to send emails asynchronously for improving 
user experience.

This class is used to create an simple string variables validation and email
string variable validation.
 
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
using System.Text.RegularExpressions;

namespace CSASPNETSendingEmail
{
    public class StringValidation
    {
        /// <summary>
        /// Email information validation.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string Validation(EmailModel model)
        {
            if (String.IsNullOrEmpty(model.SourceAddress))
                return EmailModel._SourceAddress + " is null";
            if (String.IsNullOrEmpty(model.SourcePassword))
                return EmailModel._SourcePassword + " is null";
            if (String.IsNullOrEmpty(model.TargetAddress))
                return EmailModel._TargetAddress + " is null";
            if (String.IsNullOrEmpty(model.SourcetHost))
                return EmailModel._SourcetHost + " is null";
            if (String.IsNullOrEmpty(model.Title))
                return EmailModel._Title + " is null";
            if (String.IsNullOrEmpty(model.AttachmentUri))
                return EmailModel._AttachmentUri + " is null";
            if (String.IsNullOrEmpty(model.ImageUri))
                return EmailModel._ImageUri + " is null";
            if (String.IsNullOrEmpty(model.Text))
                return EmailModel._Text + " is null";
            if (!ValidEmail(model.SourceAddress))
                return EmailModel._SourceAddress + " is invalid.";
            if (!ValidEmail(model.TargetAddress))
                return EmailModel._TargetAddress + " is invalid.";
            return String.Empty; 
        }

        /// <summary>
        /// Email string variable Regular Expression
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ValidEmail(string email)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(
               email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)" +
               @"|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}
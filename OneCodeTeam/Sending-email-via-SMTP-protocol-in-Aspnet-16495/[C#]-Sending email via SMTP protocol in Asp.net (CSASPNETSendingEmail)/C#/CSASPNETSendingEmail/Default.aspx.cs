/****************************** Module Header ******************************\
Module Name:  Default.aspx.cs
Project:      CSASPNETSendingEmail
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to send an email with attachments and embedded
images using SMTP protocol in Asp.net. This is a very common issue in forums, 
customers always fall into troubles when they try to implement relative APIs,
that is because they receive many errors or exceptions, so we provide this 
sample code to show how to send an email with your web application, and this 
sample also demonstrates how to send emails asynchronously for improving 
user experience.

This web form page shows a form with input controls and can send e-mails by 
SMTP client.
 
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
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.ComponentModel;

namespace CSASPNETSendingEmail
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Sending e-mail message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSend_Click(object sender, EventArgs e)
        {
            EmailModel model = new EmailModel();
            StringValidation validation = new StringValidation();
            model.SourceAddress = tbEmailAddress.Text.Trim();
            model.SourcePassword = tbEmailPassword.Text.Trim();
            model.TargetAddress = tbTargetEmailAddress.Text.Trim();
            model.SourcetHost = tbSourceHost.Text.Trim();
            model.Title = tbTitle.Text.Trim();
            model.AttachmentUri = fupAttachment.PostedFile.FileName;
            model.ImageUri = fupImage.PostedFile.FileName;
            model.Text = tbText.Text;
            string result = validation.Validation(model);
            if (result.Equals(String.Empty))
            {
                // Collect basic messages of Page and make simple validation.
                MailMessage mail = new MailMessage();
                mail.To.Add(model.TargetAddress);
                mail.From = new MailAddress(model.SourceAddress);
                mail.Subject = model.Title;
                mail.Body = model.Text;
                mail.IsBodyHtml = true;
                Attachment attachment = new Attachment(model.AttachmentUri);
                mail.Attachments.Add(attachment);
                mail.Body += String.Format("<p><img src='{0}' /></p>", "cid:imgEmbed");
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mail.Body, null, "text/html");
                LinkedResource resources = new LinkedResource(model.ImageUri, "image/jpg");
                resources.ContentId = "imgEmbed";
                resources.TransferEncoding = TransferEncoding.Base64;
                htmlView.LinkedResources.Add(resources);
                mail.AlternateViews.Add(htmlView);

                SmtpClient client = new SmtpClient();
                object state = mail.Subject;
                client.Host = model.SourcetHost;
                NetworkCredential credential = new NetworkCredential();
                credential.UserName = model.SourceAddress;
                credential.Password = model.SourcePassword;
                client.Credentials = credential;
                client.EnableSsl = true;
                client.Port = 587;

                // Send email asynchronously or not.
                if (Page.IsAsync)
                {
                    client.SendCompleted += new SendCompletedEventHandler(SendCompleted);
                    client.SendAsync(mail, state);
                }
                else
                {
                    client.Send(mail);
                    lbMessage.Text = String.Format("E-mail-{0} has been sent!", mail.Subject);
                }
            }
            else
            {
                lbMessage.Text = result;
            }
        }

        /// <summary>
        /// Reset all controls' value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tbReset_Click(object sender, EventArgs e)
        {
            foreach (Control control in form1.Controls)
            {
                if (control is TextBox)
                {
                    (control as TextBox).Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// Asynchronous e-mail send complete operation event. 
        /// You can create your own exception handing methods base on this method.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        public void SendCompleted(object obj, AsyncCompletedEventArgs e)
        {
            string mailTitle = e.UserState as string;
            if (e.Cancelled)
                lbMessage.Text = String.Format("Send e-mail canceled: Email Title-{0}", mailTitle);
            if (e.Error != null)
                lbMessage.Text = String.Format("Send e-mail error of {0}: {1}", mailTitle, e.Error.ToString());
            else
                lbMessage.Text = String.Format("E-mail-{0} has been sent!", mailTitle);
        }
    }
}

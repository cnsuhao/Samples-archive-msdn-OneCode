/****************************** Module Header ******************************\
Module Name:  MailOperationService.cs
Project:      CSAzureSendMailsByWorkerRole
Copyright (c) Microsoft Corporation.
 
As you know, System.Net.Mail api can't be used in Windows Runtime application, 
However, we can create a WCF service to consume the api, and hold this service 
on Azure.

In this way, we can use this service to send email in Windows Store app. 

This class contains the core function "SendMail".
 
The SendMail method first saves the attachment file to local temp folder, and 
then deletes the the temp folder once the e-mail has been sended successfully.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Collections.Generic;
using MailService.Interface;
using MailService.Model;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace MailService
{
    public class MailOperationService : IMailOperater
    {

        /// <summary>
        /// It will first save the attachment file to local temp folder, and then
        /// delete the the temp folder once the e-mail has been sent successfully.
        /// </summary>
        /// <param name="model">MailModel class</param>
        /// <returns>Behavior state number</returns>
        public bool SendMail(MailModel model)
        {

            string tempFilePath = null;
            string tempFolderPath = Path.GetTempPath() + Guid.NewGuid().ToString() + "\\";
            List<string> tempFilesList = new List<string>();


            MailMessage mail = new MailMessage();
            mail.To.Add(model.TargetAddress);
            mail.From = new MailAddress(model.SourceAddress);
            mail.Subject = model.Title;
            mail.Body = model.Text;
            mail.IsBodyHtml = model.IsBodyHtml;


            if (model.Attachments != null && model.Attachments.Length > 0)
            {
                foreach (var file in model.Attachments)
                {
                    tempFilePath = SaveTempFile(tempFolderPath, file);

                    // Add Attachment to Mail
                    Attachment attachment = new Attachment(tempFilePath);
                    mail.Attachments.Add(attachment);
                }
            }

            try
            {
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = model.SourceHost;
                NetworkCredential credential = new NetworkCredential();
                credential.UserName = model.SourceAddress;
                credential.Password = model.SourcePassword;
                smtpClient.Credentials = credential;
                smtpClient.EnableSsl = true;
                smtpClient.Port = model.Port;
                smtpClient.Send(mail);
            }
            catch (Exception)
            {
                // Failed to send mail
                return false;
            }
            finally
            {
                mail.Dispose();
                TempFileDispose(tempFolderPath);
            }

            // Send mail successfully.
            return true;


        }

        /// <summary>
        /// Save File Attachment to server side, and return the file local path.
        /// </summary>
        /// <param name="TempFolderPath">Default path for temp folder</param>
        /// <param name="Attachment">File information</param>
        /// <returns></returns>
        private string SaveTempFile(string TempFolderPath, FileAttachment Attachment)
        {
            string tempFilePath = TempFolderPath + Attachment.Info.Name;
            if (!Directory.Exists(TempFolderPath))
            {
                Directory.CreateDirectory(TempFolderPath);
            }
            try
            {
                using (FileStream fs = new FileStream(tempFilePath, FileMode.Create))
                {
                    byte[] bytes = Attachment.FileContentByteArray;
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            catch
            {
                return null;
            }

            return tempFilePath;
        }

        /// <summary>
        /// Delete the temp folder and all sub files.
        /// </summary>
        /// <param name="TempFolderPath">The temp folder path</param>
        private void TempFileDispose(string TempFolderPath)
        {
            if (Directory.Exists(TempFolderPath))
            {
                Directory.Delete(TempFolderPath, true);
            }
        }
    }
}

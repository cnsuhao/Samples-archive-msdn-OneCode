/****************************** Module Header ******************************\
Module Name: Program.cs
Project:     Client
Copyright (c) Microsoft Corporation.

This is the client side programe. It's used to invoke the WCF service on 
Azure workrole. 
 
This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using ConsoleApplication1.WCFMailService;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            MailModel mailModel = new MailModel();
            string filePath = "YOUR_FILE_PATH";
            mailModel.SourceAddress = "YOU_MAIL_ADDRESS";
            mailModel.SourcePassword = "YOU_MAIL_PASSWORD";
            mailModel.Title = "MAIL TITILE";
            mailModel.TargetAddress = "TARGET_ADDRESS";
            mailModel.Text = "This is text file";
            mailModel.IsBodyHtml = false;
            List<FileAttachment> AllFileAttachment = new List<FileAttachment>();

            FileAttachment fileAttachment = new FileAttachment();
            fileAttachment.Info = new FileInfo(filePath);
            fileAttachment.FileContentByteArray = File.ReadAllBytes(filePath);
            AllFileAttachment.Add(fileAttachment);
            mailModel.Attachments = AllFileAttachment.ToArray();

            mailModel.SourceHost = "smtp.live.com";
            mailModel.Port = 587;

            MailServiceClient client = new MailServiceClient();
            if (client.SendMail(mailModel))
            {
                Console.WriteLine("The e-mail has been sent successfully.");
            }
            else
            {
                Console.WriteLine("Sorry, failed to send the e-mail. Please check your user name and password.");
            }

         Console.ReadLine();

        }
    }
}

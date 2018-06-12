/****************************** Module Header ******************************\
Module Name:  Program.cs
Project:      CSO365ImportMasterCategory
Copyright (c) Microsoft Corporation.

Currently, Outlook Web App (OWA) does not allow user to export and import Master 
Category List. But some customers relies on this feature for handling their 
email messages efficiently. So they need a workaround to mitigate this issue. 
In this application, we will demonstrate how to export and import Master 
Category List in O365:
1. Export the Master Category List
a. Get the account(s) you want to export the Master Category List from
b. Get the user configuration of the account(s)
c. Export the Master Category List from the user configuration
2. Import the Master Category List
a. Get the account(s) you want to import the Master Category List into
b. Get the file that stores Master Category List
c. Get the user configuration of the account(s)
d. Import the Master Category List from the file

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Collections.Generic;
using Microsoft.Exchange.WebServices.Data;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace CSO365ImportMasterCategory
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.ServerCertificateValidationCallback =
CallbackMethods.CertificateValidationCallBack;
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2010_SP2);

            // Get the information of the account.
            UserInfo user = new UserInfo();
            service.Credentials = new WebCredentials(user.Account, user.Pwd);

            // Set the url of server.
            if (!AutodiscoverUrl(service, user))
            {
                return;
            }
            Console.WriteLine();

            // Export Mster Category List.
            // If you have Impersonation permission, you can get the Category list of the other 
            // accounts in the same domain; or if the accounts provide your account the permission 
            // of Calendar, you can finish the same work. Except the two ways, you can only export 
            // the Master Category List from your current accout.
            ExportMasterCategoryList(service, user.Account, true);
            Console.WriteLine();

            // Import Master Category List.
            // If you have Impersonation permission, you can import the Category list into the other 
            // accounts in the same domain; or if the accounts provide your account the permission 
            // of Calendar, you can finish the same work. Except the two ways, you can only import 
            // the Master Category List into your current accout.
            ImportMasterCategoryList(service, user.Account, true);
            Console.WriteLine();

            Console.WriteLine("Press any key to exit......");
            Console.ReadKey();
        }

        /// <summary>
        /// Export the Master Category List
        /// </summary>
        /// <param name="usingImpersonation">If you have Impersonation permission, you can set it as true; 
        /// or you should set it as false.</param>
        static void ExportMasterCategoryList(ExchangeService service, String currentAddress,
            Boolean usingImpersonation)
        {
            Console.WriteLine("Please input the user identity that you want to export " +
                "Master Category List from(or you can directly press Enter to export the list " +
                "from current account):");
            String inputInfo = Console.ReadLine();

            String words = null;
            String path = null;
            if (!String.IsNullOrWhiteSpace(inputInfo))
            {
                String[] identities = inputInfo.Split(',');

                if (identities.Length > 1)
                {
                    words = "Please input the folder path:";
                    path = InputPath(words, false, true);
                }
                else
                {
                    words = "Please input the folder or file(.xml) path:";
                    path = InputPath(words, false, false);
                }

                foreach (String identity in identities)
                {
                    NameResolutionCollection nameResolutions =
                        service.ResolveName(identity, ResolveNameSearchLocation.DirectoryOnly, true);
                    if (nameResolutions.Count != 1)
                    {
                        Console.WriteLine("{0} is invalid user identity.", identity);
                    }
                    else
                    {
                        String emailAddress = nameResolutions[0].Mailbox.Address;
                        String filePath = GetFilePath(path, identity);

                        // If our account have Impersonation permission, we can set it.
                        if (usingImpersonation)
                        {
                            service.ImpersonatedUserId =
                                    new ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress);
                            ExportMasterCategoryListWithImpersonation(service, filePath);
                            service.ImpersonatedUserId = null;
                        }
                        else
                        {
                            ExportMasterCategoryListWithoutImpersonation(service, emailAddress, filePath);
                        }
                    }
                }
            }
            else
            {
                words = "Please input the folder or file(.xml) path:";
                path = InputPath(words, false, false);
                String filePath = GetFilePath(path, currentAddress);

                ExportMasterCategoryListWithImpersonation(service, filePath);
            }
        }

        /// <summary>
        /// If our account has permission to access the Calendar of the other users, we use this method 
        /// to export Mater Category List.
        /// </summary>
        /// <param name="userAddress">The user mail address that you want to export the Master Category 
        /// List from</param>
        /// <param name="filePath">The path of file that stores the Master Category List</param>
        static void ExportMasterCategoryListWithoutImpersonation(ExchangeService service,
            String userAddress, String filePath)
        {
            Mailbox mailbox = new Mailbox(userAddress);
            FolderId folderId = new FolderId(WellKnownFolderName.Calendar, mailbox);

            // Get the UserConfiguration.
            UserConfiguration userConfiguration =
                UserConfiguration.Bind(service, "CategoryList", folderId,
                UserConfigurationProperties.XmlData);

            // Get the data of Master Category List
            String categoryListString = UTF8Encoding.UTF8.GetString(userConfiguration.XmlData);

            // Export to the file.
            WriteFile(categoryListString, filePath);
        }

        /// <summary>
        /// If our account has Impersonation permission, we can use this method to export the Master 
        /// Category List; or we can use this method to export the Master Category List from our current 
        /// accout.
        /// </summary>
        /// <param name="filePath">The path of file that stores the Master Category List</param>
        static void ExportMasterCategoryListWithImpersonation(ExchangeService service, String filePath)
        {
            UserConfiguration userConfiguration =
                UserConfiguration.Bind(service, "CategoryList", WellKnownFolderName.Calendar,
                UserConfigurationProperties.XmlData);

            String categoryListString = UTF8Encoding.UTF8.GetString(userConfiguration.XmlData);

            WriteFile(categoryListString, filePath);
        }

        /// <summary>
        /// Import the Master Category List.
        /// </summary>
        /// <param name="usingImpersonation">If you have Impersonation permission, you can set it as true;
        /// or you should set it as false.</param>
        static void ImportMasterCategoryList(ExchangeService service, String currentAddress,
            Boolean usingImpersonation)
        {
            Console.WriteLine("Please input the user identity that you want to import " +
                "Master Category List into(or you can directly press Enter to export the list " +
                "from current account):");
            String inputInfo = Console.ReadLine();

            String words = null;
            String path = null;
            if (!String.IsNullOrWhiteSpace(inputInfo))
            {
                String[] identities = inputInfo.Split(',');

                if (identities.Length > 1)
                {
                    words = "Please input the folder path:";
                    path = InputPath(words, true, true);
                }
                else
                {
                    words = "Please input the folder or file(.xml) path:";
                    path = InputPath(words, true, false);
                }

                foreach (String identity in identities)
                {
                    NameResolutionCollection nameResolutions =
                        service.ResolveName(identity, ResolveNameSearchLocation.DirectoryOnly, true);
                    if (nameResolutions.Count != 1)
                    {
                        Console.WriteLine("{0} is invalid user identity.", identity);
                    }
                    else
                    {
                        String emailAddress = nameResolutions[0].Mailbox.Address;
                        String filePath = GetFilePath(path, identity);

                        // If our account has Impersonation permission, we can set it.
                        if (usingImpersonation)
                        {
                            service.ImpersonatedUserId =
                                    new ImpersonatedUserId(ConnectingIdType.SmtpAddress, emailAddress);
                            ImportMasterCategoryListWithImpersonation(service, filePath);
                            service.ImpersonatedUserId = null;
                        }
                        else
                        {
                            ImportMasterCategoryListWithoutImpersonation(service, emailAddress, filePath);
                        }
                        Console.WriteLine("Import Master Category List into {0}", emailAddress);
                    }
                }
            }
            else
            {
                words = "Please input the folder or file(.xml) path:";
                path = InputPath(words, true, false);
                String filePath = GetFilePath(path, currentAddress);

                ImportMasterCategoryListWithImpersonation(service, filePath);

                Console.WriteLine("Import Master Category List into {0}", currentAddress);
            }
        }

        /// <summary>
        /// If our account has permission to access the Calendar of the other users, we use this method
        /// to import Master Category List.
        /// </summary>
        /// <param name="filePath">The path of file that stores the Master Category List</param>
        static void ImportMasterCategoryListWithoutImpersonation(ExchangeService service, String userAddress, String filePath)
        {
            Mailbox mailbox = new Mailbox(userAddress);
            FolderId folderId = new FolderId(WellKnownFolderName.Calendar, mailbox);

            // Get UserConfiguration
            UserConfiguration userConfiguration = UserConfiguration.Bind(service, "CategoryList", folderId, UserConfigurationProperties.XmlData);

            // Set Category List
            String categoryListString = ReadFile(filePath);
            Byte[] categoryListBytes = UTF8Encoding.UTF8.GetBytes(categoryListString);

            userConfiguration.XmlData = categoryListBytes;
            userConfiguration.Update();
        }

        /// <summary>
        /// If our account has Impersonation permission, we can use this method to import the Master 
        /// Category List; or we can use this method to import the Master Category List into our current 
        /// accout.
        /// </summary>
        /// <param name="filePath">The path of file that stores the Master Category List</param>
        static void ImportMasterCategoryListWithImpersonation(ExchangeService service, String filePath)
        {
            UserConfiguration userConfiguration = UserConfiguration.Bind(service, "CategoryList", WellKnownFolderName.Calendar, UserConfigurationProperties.XmlData);

            String categoryListString = ReadFile(filePath);
            Byte[] categoryListBytes = UTF8Encoding.UTF8.GetBytes(categoryListString);

            userConfiguration.XmlData = categoryListBytes;
            userConfiguration.Update();
        }

        /// <summary>
        /// Get the path of folder and file that store the Master Category List.
        /// </summary>
        private static String InputPath(String words, Boolean isMustExists, Boolean isOnlyFolder)
        {
            do
            {
                Console.Write(words);

                String path = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(Path.GetExtension(path)))
                {
                    if (Directory.Exists(path))
                    {
                        return path;
                    }
                    else if (!isMustExists)
                    {
                        Directory.CreateDirectory(path);
                        return path;
                    }
                }
                else if (!isOnlyFolder)
                {
                    if (Path.GetExtension(path).ToUpper() == ".XML")
                    {
                        if (File.Exists(path))
                        {
                            return path;
                        }
                        else if (!isMustExists)
                        {
                            if (!Directory.Exists(Path.GetDirectoryName(path)))
                            {
                                Directory.CreateDirectory(Path.GetDirectoryName(path));
                            }

                            return path;
                        }
                    }
                }

                Console.WriteLine("The path is invaild.");
            } while (true);
        }

        /// <summary>
        /// Get the path of file that store the 
        /// </summary>
        private static String GetFilePath(String path, String fileName)
        {
            if (String.IsNullOrWhiteSpace(Path.GetExtension(path)))
            {
                return Path.Combine(path, fileName + ".xml");
            }
            else
            {
                return path;
            }
        }

        /// <summary>
        /// Write the data into file.
        /// </summary>
        private static void WriteFile(String data, String filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(data);
            }

            Console.WriteLine("Export data into {0} file.", filePath);
        }

        /// <summary>
        /// Read data from the file.
        /// </summary>
        private static String ReadFile(String filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                return reader.ReadToEnd();
            }
        }

        private static Boolean AutodiscoverUrl(ExchangeService service, UserInfo user)
        {
            Boolean isSuccess = false;

            try
            {
                Console.WriteLine("Connecting the Exchange Online......");
                service.AutodiscoverUrl(user.Account, CallbackMethods.RedirectionUrlValidationCallback);
                Console.WriteLine();
                Console.WriteLine("Connect the Exchange Online successfully.");

                isSuccess = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("There's an error.");
                Console.WriteLine(e.Message);
            }

            return isSuccess;
        }
    }
}

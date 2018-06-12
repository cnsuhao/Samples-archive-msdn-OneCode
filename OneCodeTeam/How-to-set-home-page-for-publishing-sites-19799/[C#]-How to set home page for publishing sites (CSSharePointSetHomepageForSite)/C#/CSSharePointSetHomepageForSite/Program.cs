/****************************** Module Header ******************************\
* Module Name:    Program.cs
* Project:        CSSharePointSetHomepageForSite
* Copyright (c) Microsoft Corporation
*
* This sample shows how to set home page for publishing sites programmatically.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace CSSharePointSetHomepageForSite
{
    class Program
    {
        static void Main(string[] args)
        {
            // Url of the PublishingWeb
            string strPublishingWebUrl = "yourPublishingWebUrl";
            // Url of the new WelcomePage
            string strWelcomePageUrl = "yourNewWelcomePageUrl";

            // Connect to SharePoint Site
            using (var oSite = new SPSite(strPublishingWebUrl))
            {
                // Open SharePoint Site
                using (var oWeb = oSite.OpenWeb())
                {
                    // Checks the SPWeb object to verify whether it is a PublishingWeb object.
                    if (Microsoft.SharePoint.Publishing.PublishingWeb.IsPublishingWeb(oWeb))
                    {
                        // Retrieves an instance of the PublishingWeb that wraps the specified SPWeb object.
                        var oPublishingWeb = Microsoft.SharePoint.Publishing.PublishingWeb.GetPublishingWeb(oWeb);

                        try
                        {
                            // Get the new WelcomePage File by the url.
                            SPFile oWelcomePageFile = oWeb.GetFile(strWelcomePageUrl);

                            if (oWelcomePageFile.Exists)
                            {
                                // Sets the Welcome page for this PublishingWeb object.
                                oPublishingWeb.DefaultPage = oWelcomePageFile;

                                // Saves changes to the PublishingWeb object
                                oPublishingWeb.Update();
                            }    
                        }
                        catch (Exception oException)
                        {
                            // Handle the exception
                            Console.WriteLine(oException.Message);
                        }
                        finally
                        {
                            // Prevent memory leaks by closing the Publishing web
                            oPublishingWeb.Close();
                        }
                    }
                }
            }
        }
    }
}

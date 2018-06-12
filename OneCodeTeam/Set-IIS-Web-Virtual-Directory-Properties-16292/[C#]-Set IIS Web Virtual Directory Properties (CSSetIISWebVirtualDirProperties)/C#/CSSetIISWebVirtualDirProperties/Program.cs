/****************************** Module Header ******************************\
Module Name:  Program.cs
Project:      CSSetIISWebVirtualDirProperties
Copyright (c) Microsoft Corporation.

This sample application shows how to set the Name of the Virtual Directory
using System.DirectoryServices namespace.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;


namespace CSSetIISWebVirtualDirProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            string siteName = "HelloWorldSite";
            string physicalPath = @"C:\HelloWorldSite";

            //Using DirectoryEntry bind to the Root of the IIS metabase.
            using (DirectoryEntry rootEntry = new DirectoryEntry("IIS://localhost/W3SVC/1/Root"))
            {
                //Create your Web Virtual Directory
                using (DirectoryEntry testDirectoryEntry = rootEntry.Children.Add(siteName, "IIsWebVirtualDir"))
                {
                    //Closing & Disposing DirectoryEntry object
                    rootEntry.Close();

                    //Give the physical path for the Virtual Directory
                    testDirectoryEntry.Properties["Path"][0] = physicalPath;

                    //Save back the changes back to the IIS metabase
                    testDirectoryEntry.CommitChanges();

                    //We are going to set the Name of the Virtual Directory
                    //By setting it's AppFriendlyName property
                    testDirectoryEntry.Properties["AppFriendlyName"][0] = siteName;

                    //Save the changes back to the IIS metabase
                    testDirectoryEntry.CommitChanges();

                    //Do a close on the DirectoryEntry object
                    testDirectoryEntry.Close();
                }
            }
        }        
    }
}

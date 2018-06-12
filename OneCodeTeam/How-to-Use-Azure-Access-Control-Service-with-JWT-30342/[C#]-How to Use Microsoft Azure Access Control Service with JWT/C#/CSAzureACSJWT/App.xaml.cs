/***************************** Module Header ******************************\
* Module Name:	App.xaml.cs
* Project:		CSAzureACSJWT
* Copyright (c) Microsoft Corporation.
* 
* This sample shows:
* how to do authentication based on Azure Access control service(ACS).
* 
* Store ACS infos we need.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\**************************************************************************/
using System.Windows;

namespace CSAzureACSJWT
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static readonly string realm = "your realm";
        public static readonly string serviceNamespace = "your namespace"; //Access Control Namespaces
        public static readonly string acsHostUrl = "accesscontrol.windows.net";
    }
}

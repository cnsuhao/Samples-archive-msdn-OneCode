/****************************** Module Header ******************************\
* Module Name:  Default.aspx.cs
* Project:      AzureTransferringCustomIISLogs
* Copyright (c) Microsoft Corporation.
*  
* Because any log file transfer to Azure storage are billable ,custom log file 
* before transfer will help you save money. This sample will show you how to 
* custom IIS logs in your Azure web role. This is a frequently asked question in forum,
* so we provide this sample code to show how to achieve this in .NET.
* 
* This web form page shows a form with the description of this project.
*  
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
* All other rights reserved.
*  
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/


using System;

namespace AzureTransferringCustomIISLogs
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
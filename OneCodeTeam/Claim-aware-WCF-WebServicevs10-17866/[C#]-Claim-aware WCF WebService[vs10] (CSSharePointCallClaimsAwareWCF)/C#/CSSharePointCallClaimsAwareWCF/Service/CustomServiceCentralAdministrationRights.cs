/****************************** Module Header ******************************\
* Module Name:    CustomServiceCentralAdministrationRights.cs
* Project:        CSSharePointCallClaimsAwareWCF
* Copyright (c) Microsoft Corporation
*
* This is the Custom ServiceCentralAdministrationRights Class
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
using Microsoft.SharePoint.Administration.AccessControl;

namespace CustomService
{
    /// <summary>
    /// Custom central administration access rights for the sample web service application.
    /// </summary>
    internal static class CustomServiceCentralAdministrationRights
	{
        // NOTE: SPCentralAdministrationRights.Read is required to allow access to the central administration site as a delegated administrator
        public const SPCentralAdministrationRights Write = (SPCentralAdministrationRights)0x1 | SPCentralAdministrationRights.Read;
    }
}
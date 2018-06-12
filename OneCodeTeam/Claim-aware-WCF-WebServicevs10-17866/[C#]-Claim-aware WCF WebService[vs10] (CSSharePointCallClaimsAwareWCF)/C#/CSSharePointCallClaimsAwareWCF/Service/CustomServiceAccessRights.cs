/****************************** Module Header ******************************\
* Module Name:    CustomServiceAccessRights.cs
* Project:        CSSharePointCallClaimsAwareWCF
* Copyright (c) Microsoft Corporation
*
* This class is used to custom ServiceAccessRights
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
    internal static class CustomServiceAccessRights
    {
        public const SPIisWebServiceApplicationRights Add = (SPIisWebServiceApplicationRights)0x1;
        public const SPIisWebServiceApplicationRights Subtract = (SPIisWebServiceApplicationRights)0x2;
        public const SPIisWebServiceApplicationRights Hello = (SPIisWebServiceApplicationRights)0x3;
    }
}
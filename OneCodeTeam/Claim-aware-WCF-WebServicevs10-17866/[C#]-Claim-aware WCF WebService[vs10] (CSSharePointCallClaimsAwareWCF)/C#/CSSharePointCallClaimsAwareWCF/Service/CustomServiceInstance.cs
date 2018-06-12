/****************************** Module Header ******************************\
* Module Name:    CustomServiceInstance.cs
* Project:        CSSharePointCallClaimsAwareWCF
* Copyright (c) Microsoft Corporation
*
* This is the CustomServiceInstance Class
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
using Microsoft.SharePoint.Administration;
using CustomService;

namespace CustomService
{
    public class CustomServiceInstance : SPIisWebServiceInstance
    {
        public CustomServiceInstance() { }

        public CustomServiceInstance(SPServer server, CustomService service)
            : base(server, service) { }

        public override string TypeName
        {
            get { return "Custom Service"; }
        }
    }
}
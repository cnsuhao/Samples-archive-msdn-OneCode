/****************************** Module Header ******************************\
* Module Name:    CustomServiceProxy.cs
* Project:        CSSharePointCallClaimsAwareWCF
* Copyright (c) Microsoft Corporation
*
* This class is used to define Service Proxy
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
using System.Runtime.InteropServices;
using Microsoft.SharePoint.Administration;

namespace CustomService
{
    [Guid("72B01562-6AEE-4ab3-BA64-F7B6A02E3AC6")]
    [SupportedServiceApplication("A12A5C1C-9784-4118-BF9D-B58B24337E34", "1.0.0.0", typeof(CustomServiceApplicationProxy))]
    public sealed class CustomServiceProxy : SPIisWebServiceProxy, IServiceProxyAdministration
    {
        public CustomServiceProxy() : base() { }

        public CustomServiceProxy(SPFarm farm) : base(farm) { }

        public SPServiceApplicationProxy CreateProxy(Type serviceApplicationProxyType, string name, Uri serviceApplicationUri, SPServiceProvisioningContext provisioningContext)
        {
            if (serviceApplicationProxyType != typeof(CustomServiceApplicationProxy))
                throw new NotSupportedException();

            return new CustomServiceApplicationProxy(name, this, serviceApplicationUri);
        }

        public SPPersistedTypeDescription GetProxyTypeDescription(Type serviceApplicationProxyType)
        {
            return new SPPersistedTypeDescription("Custom Service Proxy", "Connects to the sample custom service.");
        }

        public Type[] GetProxyTypes()
        {
            return new Type[] { typeof(CustomServiceApplicationProxy) };
        }
    }
}
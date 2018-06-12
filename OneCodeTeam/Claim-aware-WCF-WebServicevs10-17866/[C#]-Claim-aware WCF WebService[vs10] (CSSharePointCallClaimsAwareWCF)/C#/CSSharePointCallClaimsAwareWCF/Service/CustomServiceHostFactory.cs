/****************************** Module Header ******************************\
* Module Name:    CustomServiceHostFactory.cs
* Project:        CSSharePointCallClaimsAwareWCF
* Copyright (c) Microsoft Corporation
*
* This is the Custom ServiceHostFactory Class
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
using System.ServiceModel;
using System.ServiceModel.Activation;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint;

namespace CustomService
{
    internal sealed class CustomServiceHostFactory : ServiceHostFactory
    {
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            ServiceHost serviceHost = new ServiceHost(typeof(CustomServiceApplication), baseAddresses);

            // Configure the service host for claims authentication
            serviceHost.Configure(SPServiceAuthenticationMode.Claims);
            return serviceHost;
        }
    }
}
/****************************** Module Header ******************************\
* Module Name:    CustomServiceClient.cs
* Project:        CSSharePointCallClaimsAwareWCF
* Copyright (c) Microsoft Corporation
*
* This class is used to define Service Client
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

namespace CustomService
{
    public sealed class CustomServiceClient
    {
        private SPServiceContext _serviceContext;

        public CustomServiceClient(SPServiceContext serviceContext)
        {
            if (serviceContext == null)
                throw new ArgumentNullException("serviceContext");

            _serviceContext = serviceContext;
        }

        public int Add(int a, int b)
        {
            return Add(a, b, ExecuteOptions.None);
        }

        public int Add(int a, int b, ExecuteOptions options)
        {
            int sum = 0;
            CustomServiceApplicationProxy.Invoke(_serviceContext, proxy => sum = proxy.Add(a, b, options));
            return sum;
        }

        public string HelloWorld()
        {
            return HelloWorld(ExecuteOptions.None);
        }

        public string HelloWorld(ExecuteOptions options)
        {
            string result = string.Empty;

            CustomServiceApplicationProxy.Invoke(_serviceContext, proxy => result = proxy.HelloWorld(options));

            return result;
        }
    }
}
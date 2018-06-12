/****************************** Module Header ******************************\
Module Name:  SWTMoudle.cs
Project:      SecurityModule
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to access the WCF service via Access control
service token. Here we create a Silverlight application and a normal Console 
application client. The Token format is SWT, and we will use password as the 
Service identities.

This class gets token from ACS via TokenPolicyKey.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SecurityModule
{
    class SWTMoudle : IHttpModule
    {
        string serviceNamespace = "<Your ACS namespace>";
        string acsHostName = "accesscontrol.windows.net";
        // Certificate and keys
        string trustedTokenPolicyKey = "<Your Signing certificate symmetric key>";
        // Service Realm
        string trustedAudience = "<Your ACS service path>";


        void IHttpModule.Dispose()
        {

        }

        void IHttpModule.Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.Url.AbsolutePath.EndsWith(".svc"))
            {
                // Get the authorization header
                string headerValue = HttpContext.Current.Request.Headers.Get("Authorization");

                // Check that a value is there
                if (string.IsNullOrEmpty(headerValue))
                {
                    throw new ApplicationException("unauthorized");
                }

                // Check that it starts with 'WRAP'
                if (!headerValue.StartsWith("WRAP "))
                {
                    throw new ApplicationException("unauthorized");
                }

                string[] nameValuePair = headerValue.Substring("WRAP ".Length).Split(new char[] { '=' }, 2);

                if (nameValuePair.Length != 2 ||
                    nameValuePair[0] != "access_token" ||
                    !nameValuePair[1].StartsWith("\"") ||
                    !nameValuePair[1].EndsWith("\""))
                {
                    throw new ApplicationException("unauthorized");
                }

                // Trim off the leading and trailing double-quotes
                string token = nameValuePair[1].Substring(1, nameValuePair[1].Length - 2);

                // Create a token validate
                TokenValidator validator = new TokenValidator(
                    this.acsHostName,
                    this.serviceNamespace,
                    this.trustedAudience,
                    this.trustedTokenPolicyKey);

                // Validate the token
                if (!validator.Validate(token))
                {
                    throw new ApplicationException("unauthorized");
                }
            }
        }

    }
}

/***************************** Module Header ******************************\
* Module Name:	IdentityProviderInfo.cs
* Project:		CSAzureACSJWT
* Copyright (c) Microsoft Corporation.
* 
* This sample shows:
* how to do authentication based on Azure Access control service(ACS).
* 
* Store IDP infos we need.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\**************************************************************************/
namespace CSAzureACSJWT
{
    public class IdentityProviderInfo
    {
        public string Name { get; set; }
        public string LoginUrl { get; set; }
    }
}

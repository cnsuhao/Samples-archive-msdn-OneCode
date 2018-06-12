/****************************** Module Header ******************************\
* Module Name:    GetIdentityClass.cs
* Project:        CSSharePointCallClaimsAwareWCF
* Copyright (c) Microsoft Corporation
*
* This class is used to get SharePoint Logged-on user’s security token 
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
using Microsoft.IdentityModel.Claims;

namespace CustomService
{
    public static class GetIdentityClass
    {
        private const string IdentityClaimType = @"http://schemas.microsoft.com/sharepoint/2009/08/claims/userid";

        public static string GetIdentity()
        {
            // Identity Name
            string identityName = String.Empty;

            // Get the Identity of the Current Principal
            IClaimsIdentity claimsIdentity =System.Threading.Thread.CurrentPrincipal.Identity as IClaimsIdentity;

            if (claimsIdentity != null)
            {
                // claim
                foreach (Claim claim in claimsIdentity.Claims)
                {
                    if (String.Equals(IdentityClaimType, claim.ClaimType,
                      StringComparison.OrdinalIgnoreCase))
                    {
                        identityName = claim.Value;
                        break;
                    }
                }
            }
            else
            {
                identityName = System.Threading.Thread.CurrentPrincipal.Identity.Name;
            }

            return identityName;
        }
    }
}

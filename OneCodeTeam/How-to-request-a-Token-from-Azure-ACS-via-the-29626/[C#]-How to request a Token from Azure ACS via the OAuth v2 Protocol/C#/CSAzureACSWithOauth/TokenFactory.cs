/***************************** Module Header ******************************\
* Module Name:	TokenFactory.cs
* Project:		CSAzureACSWithOauth
* Copyright (c) Microsoft Corporation.
* 
* This sample shows how to request a token from ACS via the OAuth.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\**************************************************************************/
using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CSAzureACSWithOauth
{
    public class TokenFactory
    {
        string signingKey;
        string issuer;

        public TokenFactory(string issuer, string signingKey)
        {
            this.issuer = issuer;
            this.signingKey = signingKey;
        }

        public string CreateToken()
        {
            StringBuilder builder = new StringBuilder();

            // Add the issuer name
            builder.Append("Issuer=");
            builder.Append(HttpUtility.UrlEncode(this.issuer));

            string signature = this.GenerateSignature(builder.ToString(), this.signingKey);
            builder.Append("&HMACSHA256=");
            builder.Append(signature);

            return builder.ToString();
        }


        private string GenerateSignature(string unsignedToken, string signingKey)
        {
            HMACSHA256 hmac = new HMACSHA256(Convert.FromBase64String(signingKey));

            byte[] locallyGeneratedSignatureInBytes = hmac.ComputeHash(Encoding.ASCII.GetBytes(unsignedToken));

            string locallyGeneratedSignature = HttpUtility.UrlEncode(Convert.ToBase64String(locallyGeneratedSignatureInBytes));

            return locallyGeneratedSignature;
        }
    }
}

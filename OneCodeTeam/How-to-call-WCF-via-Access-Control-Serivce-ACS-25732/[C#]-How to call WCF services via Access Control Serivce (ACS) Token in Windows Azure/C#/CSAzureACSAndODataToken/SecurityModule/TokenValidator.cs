/****************************** Module Header ******************************\
Module Name:  SWTMoudle.cs
Project:      TokenValidator
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to access the WCF service via Access control
service token. Here we create a Silverlight application and a normal Console 
application client. The Token format is SWT, and we will use password as the 
Service identities.
 
This class is used to authenticate the Token from Access Control Service.

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
using System.Security.Cryptography;

namespace SecurityModule
{
    public class TokenValidator
    {
        private string issuerLabel = "Issuer";
        private string expiresLabel = "ExpiresOn";
        private string audienceLabel = "Audience";
        private string hmacSHA256Label = "HMACSHA256";

        private string acsHostName;

        private string trustedSigningKey;
        private string trustedTokenIssuer;
        private string trustedAudienceValue;

        /// <summary>
        /// Token validate constructor method.
        /// </summary>
        /// <param name="acsHostName"></param>
        /// <param name="serviceNamespace"></param>
        /// <param name="trustedAudienceValue"></param>
        /// <param name="trustedSigningKey"></param>
        public TokenValidator(string acsHostName, string serviceNamespace, string trustedAudienceValue, string trustedSigningKey)
        {
            this.trustedSigningKey = trustedSigningKey;
            this.trustedTokenIssuer = String.Format("https://{0}.{1}/",
                serviceNamespace.ToLowerInvariant(),
                acsHostName.ToLowerInvariant());

            this.trustedAudienceValue = trustedAudienceValue;
        }

        public bool Validate(string token)
        {
            if (!this.IsHMACValid(token, Convert.FromBase64String(this.trustedSigningKey)))
            {
                return false;
            }

            if (this.IsExpired(token))
            {
                return false;
            }

            if (!this.IsIssuerTrusted(token))
            {
                return false;
            }

            if (!this.IsAudienceTrusted(token))
            {
                return false;
            }

            return true;
        }

        public Dictionary<string, string> GetNameValues(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentException();
            }

            return
                token
                .Split('&')
                .Aggregate(
                new Dictionary<string, string>(),
                (dict, rawNameValue) =>
                {
                    if (rawNameValue == string.Empty)
                    {
                        return dict;
                    }

                    string[] nameValue = rawNameValue.Split('=');

                    if (nameValue.Length != 2)
                    {
                        throw new ArgumentException("Invalid formEncodedstring - contains a name/value pair missing an = character");
                    }

                    if (dict.ContainsKey(nameValue[0]) == true)
                    {
                        throw new ArgumentException("Repeated name/value pair in form");
                    }

                    dict.Add(HttpUtility.UrlDecode(nameValue[0]), HttpUtility.UrlDecode(nameValue[1]));
                    return dict;
                });
        }

        private static ulong GenerateTimeStamp()
        {
            // Default implementation of epoch time
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToUInt64(ts.TotalSeconds);
        }

        private bool IsAudienceTrusted(string token)
        {
            Dictionary<string, string> tokenValues = this.GetNameValues(token);

            string audienceValue;

            tokenValues.TryGetValue(this.audienceLabel, out audienceValue);

            if (!string.IsNullOrEmpty(audienceValue))
            {
                if (audienceValue.Equals(this.trustedAudienceValue, StringComparison.Ordinal))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsIssuerTrusted(string token)
        {
            Dictionary<string, string> tokenValues = this.GetNameValues(token);

            string issuerName;

            tokenValues.TryGetValue(this.issuerLabel, out issuerName);

            if (!string.IsNullOrEmpty(issuerName))
            {
                if (issuerName.Equals(this.trustedTokenIssuer))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsHMACValid(string swt, byte[] sha256HMACKey)
        {
            string[] swtWithSignature = swt.Split(new string[] { "&" + this.hmacSHA256Label + "=" }, StringSplitOptions.None);

            if ((swtWithSignature == null) || (swtWithSignature.Length != 2))
            {
                return false;
            }

            HMACSHA256 hmac = new HMACSHA256(sha256HMACKey);

            byte[] locallyGeneratedSignatureInBytes = hmac.ComputeHash(Encoding.ASCII.GetBytes(swtWithSignature[0]));

            string locallyGeneratedSignature = HttpUtility.UrlEncode(Convert.ToBase64String(locallyGeneratedSignatureInBytes));

            return locallyGeneratedSignature == swtWithSignature[1];
        }

        private bool IsExpired(string swt)
        {
            try
            {
                Dictionary<string, string> nameValues = this.GetNameValues(swt);
                string expiresOnValue = nameValues[this.expiresLabel];
                ulong expiresOn = Convert.ToUInt64(expiresOnValue);
                ulong currentTime = Convert.ToUInt64(GenerateTimeStamp());

                if (currentTime > expiresOn)
                {
                    return true;
                }

                return false;
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentException();
            }
        }

    }
}

/***************************** Module Header ******************************\
* Module Name:	Program.cs
* Project:		CSAzureACSWithOauth
* Copyright (c) Microsoft Corporation.
* 
* This sample shows how to request a token from ACS via the OAuth.
* 
* Let user login to Identity provider and get response token.
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
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace CSAzureACSWithOauth
{
   
    class Program
    {
        public const string ACSNameSpace = "{Your-ACS-NameSpace}";

        static void Main(string[] args)
        {
            var accessToken = HttpUtility.UrlDecode(GetTokenBySymmetricKey("http://dinohy.com/"));
            Console.WriteLine(accessToken);
            Console.ReadLine();
        }

        public static string GetTokenByPassword(string scope)
        {
            try
            {
                const string identityName = "{Service-Identity-Name}";
                const string identityPassword = "{Password}";

                // Request a token from ACS
                var client = new WebClient();
                var address = new Uri(string.Format("https://{0}.accesscontrol.windows.net/v2/OAuth2-13", ACSNameSpace));

                var values = new NameValueCollection();

                values.Add("grant_type", "client_credentials");
                values.Add("client_id", identityName);
                values.Add("client_secret", identityPassword);
                values.Add("scope", scope);

                byte[] responseBytes = client.UploadValues(address, "POST", values);

                string response = Encoding.UTF8.GetString(responseBytes);

                // Parse the JSON response and return the access token
                var serializer = new JavaScriptSerializer();

                var decodedDictionary = serializer.DeserializeObject(response) as Dictionary<string, object>;

                return decodedDictionary["access_token"] as string;
            }
            catch (WebException wex)
            {
                string value = new StreamReader(wex.Response.GetResponseStream()).ReadToEnd();
                throw;
            }

        }

        public static string GetTokenBySymmetricKey(string scope)
        {
            try
            {
                // Request a token from ACS
                var client = new WebClient();
                var address = new Uri(string.Format("https://{0}.accesscontrol.windows.net/v2/OAuth2-13", ACSNameSpace));

                var values = new NameValueCollection();

                values.Add("grant_type", "http://schemas.xmlsoap.org/ws/2009/11/swt-token-profile-1.0");
                values.Add("assertion", createSWT("{Service-Identity-Name}", "0ytBPxRB6nc05zv6mjP2aK8rCWWPnP3fR+IDTDHEfSM="));
                values.Add("scope", scope);

                byte[] responseBytes = client.UploadValues(address, "POST", values);

                string response = Encoding.UTF8.GetString(responseBytes);

                // Parse the JSON response and return the access token
                var serializer = new JavaScriptSerializer();

                var decodedDictionary = serializer.DeserializeObject(response) as Dictionary<string, object>;

                return decodedDictionary["access_token"] as string;
            }
            catch (WebException wex)
            {
                string value = new StreamReader(wex.Response.GetResponseStream()).ReadToEnd();
                throw;
            }
        }

        public static string GetTokenFromAcsBySAML(string scope, string samlToken)
        {
            //For how to create a samlToken please refer to:
            //http://msdn.microsoft.com/en-us/library/aa355062(v=vs.110).aspx
            try
            {
                // Request a token from ACS
                var client = new WebClient();
                var address = new Uri(string.Format("https://{0}.accesscontrol.windows.net/v2/OAuth2-13",ACSNameSpace));

                var values = new NameValueCollection();

                values.Add("grant_type", "saml2-bearer");
                values.Add("assertion", samlToken);
                values.Add("scope", scope);

                byte[] responseBytes = client.UploadValues(address, "POST", values);

                string response = Encoding.UTF8.GetString(responseBytes);

                // Parse the JSON response and return the access token
                var serializer = new JavaScriptSerializer();

                var decodedDictionary = serializer.DeserializeObject(response) as Dictionary<string, object>;

                return decodedDictionary["access_token"] as string;
            }
            catch (WebException wex)
            {
                string value = new StreamReader(wex.Response.GetResponseStream()).ReadToEnd();
                throw;
            }
        }

        public static string createSWT(string issuer, string signingKey)
        {
            var factory = new TokenFactory(issuer, signingKey);
            return factory.CreateToken();
        }
    }
}

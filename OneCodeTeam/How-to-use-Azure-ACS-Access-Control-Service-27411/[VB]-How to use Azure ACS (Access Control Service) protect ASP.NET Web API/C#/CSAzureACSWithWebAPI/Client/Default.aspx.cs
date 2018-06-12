/***************************** Module Header ******************************\
* Module Name:	Default.aspx.cs
* Project:		CSAzureACSWithWebAPI
* Copyright (c) Microsoft Corporation.
* 
* Secure Web API is a hot topic in asp.net forum.
* This sample will show you how to use Azure ACS secure the web API.
* It will require you sign in with Live ID/Google/Yahoo/Live connect account 
* first before you use the web API.
*
* Default page
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
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Client
{
    public partial class Default : System.Web.UI.Page
    {
        // USE CONFIGURATION FILE, WEB.CONFIG, TO MANAGE THIS DATA
        static string serviceNamespace = "your namespace";
        static string acsHostUrl = "accesscontrol.windows.net";
        static string realm = "your realm";
        static string uid = "your service identity name";
        static string pwd = "your service identity password";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Get the user name from Claims.
            string name = System.Security.Claims.ClaimsPrincipal.Current.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value;
            if (name != "")
            {
                string token = GetTokenFromACS(realm);
                WebClient client = new WebClient();
                string headerValue = string.Format("WRAP access_token=\"{0}\"", token);

                client.Headers.Add("Authorization", headerValue);
                Stream stream = client.OpenRead(@"http://localhost:65302/api/products");
                StreamReader reader = new StreamReader(stream);

                tbContent.Text = reader.ReadToEnd();
                hlkLogin.Visible = false;
                lbUserName.Text = "Hello" + name;

            }
            else
            {
                hlkLogin.Enabled = true;
                lbUserName.Text = null; ;
                tbContent.Text = "You need to login first if you want to use the WebApi";
            }
        }

        private static string GetTokenFromACS(string scope)
        {
            string wrapPassword = pwd;
            string wrapUsername = uid;

            // request a token from ACS
            WebClient client = new WebClient();
            client.BaseAddress = string.Format("https://{0}.{1}", serviceNamespace, acsHostUrl);

            NameValueCollection values = new NameValueCollection();
            values.Add("wrap_name", wrapUsername);
            values.Add("wrap_password", wrapPassword);
            values.Add("wrap_scope", scope);

            byte[] responseBytes = client.UploadValues("WRAPv0.9/", "POST", values);

            string response = Encoding.UTF8.GetString(responseBytes);

            Console.WriteLine("\nreceived token from ACS: {0}\n", response);

            return HttpUtility.UrlDecode(
                response
                .Split('&')
                .Single(value => value.StartsWith("wrap_access_token=", StringComparison.OrdinalIgnoreCase))
                .Split('=')[1]);
        }
    }
}
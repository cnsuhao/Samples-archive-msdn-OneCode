/***************************** Module Header ******************************\
* Module Name:	Login.xaml.cs
* Project:		CSAzureACSJWT
* Copyright (c) Microsoft Corporation.
* 
* This sample shows:
* how to do authentication based on Azure Access control service(ACS).
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
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using System.Web;
using System.IO;
using System.Runtime.Serialization.Json;
using System.IdentityModel.Tokens;
using CSAzureACSJWT.Properties;

namespace CSAzureACSJWT
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private IEnumerable<IdentityProviderInfo> ipCollection;

        internal event Action SettingsChanged;

        public Login()
        {
            InitializeComponent();
            GetIdentityProviders();
        }
        public void OnSettingsChanged()
        {
            if (SettingsChanged != null)
                SettingsChanged();
        }

        private void GetIdentityProviders()
        {
            {
                Uri identityProviderDiscovery = new Uri(
                    string.Format(CultureInfo.InvariantCulture,
                        "https://{0}.{1}/v2/metadata/IdentityProviders.js?protocol=javascriptnotify&realm={2}&version=1.0",
                        App.serviceNamespace,
                        App.acsHostUrl,
                        HttpUtility.UrlEncode(App.realm)),
                        UriKind.Absolute
                    );

                WebClient webClient = new WebClient();
                webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(WebClientDownloadStringCompleted);
                webClient.DownloadStringAsync(identityProviderDiscovery);
            }
        }


        private void WebClientDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(e.Result)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(IdentityProviderInfo[]));
                ipCollection = serializer.ReadObject(ms) as IEnumerable<IdentityProviderInfo>;
                foreach (var item in ipCollection)
                {
                    switch (item.Name)
                    {
                        case "Google":
                            btnGoogle.Visibility = Visibility.Visible; break;
                        case "Yahoo!":
                            btnYahoo.Visibility = Visibility.Visible; break;
                        default:
                            break;
                    }
                }
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            string ipName = null;

            switch (((Button)sender).Name)
            {
                case "btnGoogle":
                    ipName = "Google";
                    break;
                case "btnYahoo":
                    ipName = "Yahoo!";
                    break;
                default:
                    break;
            }
            if (ipCollection != null)
            {
                var ip = ipCollection.Where(item => item.Name == ipName).Single();

                string idpUrl = ((IdentityProviderInfo)ip).LoginUrl;
                wbsLogin.Navigate(idpUrl);
            }
        }

        private void wbsLogin_Loaded(object sender, RoutedEventArgs e)
        {
            ((WebBrowser)sender).ObjectForScripting = new HtmlInteropClass();

        }

        [System.Runtime.InteropServices.ComVisibleAttribute(true)]
        public class HtmlInteropClass
        {
            public void Notify(string jsonToken)
            {

                var jwtSTH = getDeserializedToken(jsonToken);
                foreach (var claim in jwtSTH.Claims)
                {
                    if (claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")
                    {
                        Settings.Default.CustomerEmail = claim.Value;
                    }
                    ((MainWindow)Application.Current.MainWindow).tblMessage.Text += claim.ToString() + "\n";
                }

                foreach (var window in Application.Current.Windows)
                {
                    if (window as Login != null)
                    {
                        ((Login)window).Close();
                        ((MainWindow)Application.Current.MainWindow).stateCheck();
                    }
                }
            }


            /// <summary>
            /// Third part IDP provider will provide issure a Json formate token, and serialized JWT in "securityToken".
            /// This method will deserialized the Json token and return JwtSecurityToken.
            /// </summary>
            /// <param name="jsonToken"></param>
            /// <returns></returns>
            private JwtSecurityToken getDeserializedToken(string jsonToken)
            {
                dynamic jObj = JsonConvert.DeserializeObject(jsonToken);
                var securityTokenValue = jObj["securityToken"].ToString();


                JwtSecurityTokenHandler jwtSTH = new JwtSecurityTokenHandler();
                var jwtST = jwtSTH.ReadToken(securityTokenValue) as JwtSecurityToken;
                return jwtST;
            }
        }

    }
}

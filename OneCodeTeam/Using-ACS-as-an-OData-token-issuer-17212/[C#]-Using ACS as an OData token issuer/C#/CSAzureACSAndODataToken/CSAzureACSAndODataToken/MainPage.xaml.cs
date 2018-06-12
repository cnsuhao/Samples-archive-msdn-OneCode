/****************************** Module Header ******************************\
Module Name:  MainPage.xaml.cs
Project:      CSAzureACSAndODataToken
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to access the WCF service via Access control
service token. Here we create a Silverlight application and a normal Console 
application client. The Token format is SWT, and we will use password as the 
Service identities.

This page is a Silverlight UserControl. It's used to send HttpWebRequest to ACS
and get Token back, then re-send a request to service with Token in http 
header to get data from WCF service.

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
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Runtime.Serialization;
using RESTfulWCFLibrary;
using System.Windows.Browser;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace CSAzureACSAndODataToken
{
    public partial class MainPage : UserControl
    {
        /// <summary>
        /// Necessary variables from ACS Portal.
        /// </summary>
        const string serviceNamespace = "<Your ACS namespace>";
        const string acsHostUrl = "accesscontrol.windows.net";
        const string realm = "<Your ACS service path>";
        const string userUrl = "<The user service path>";
        const string uid = "<Your service identity name>";
        const string pwd = "<Your service identity password>";
        string variables;
        string tokenString;
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get Token from ACS.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToken_Click(object sender, RoutedEventArgs e)
        {
            string token = GetTokenFromACS(realm);
        }

        /// <summary>
        /// Access WCF service.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnData_Click(object sender, RoutedEventArgs e)
        {
            if (!tbToken.Text.Trim().Equals(string.Empty))
            {
                HttpWebRequest request = HttpWebRequest.Create(userUrl) as HttpWebRequest;
                string headerValue = string.Format("WRAP access_token=\"{0}\"", tokenString);
                request.Method = "GET";
                request.Headers["Authorization"] = headerValue;
                AsyncCallback callBack = new AsyncCallback(LoginGetResponse);
                request.BeginGetResponse(callBack, request);

            }
            else
            {
                lbContent.Content = "Please get token first.";
            }
        }

        /// <summary>
        /// Display data from WCF service.
        /// </summary>
        /// <param name="result"></param>
        public void LoginGetResponse(IAsyncResult result)
        {
            HttpWebRequest request = result.AsyncState as HttpWebRequest;
            HttpWebResponse response = request.EndGetResponse(result) as HttpWebResponse;
            string obj = string.Empty;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                obj = reader.ReadToEnd();
            }
            XDocument document = XDocument.Parse(obj);
            var list = from d in document.Descendants("User")
                       select new User
                       {
                           UserId = d.Element("UserId").Value,
                           FirstName = d.Element("FirstName").Value,
                           LastName = d.Element("LastName").Value
                       };
            ObservableCollection<User> collection = new ObservableCollection<User>();
            foreach (User user in list)
            {
                collection.Add(user);
            }

            Dispatcher.BeginInvoke(() =>
                {
                    dtgContent.ItemsSource = collection;
                });

        }


        /// <summary>
        /// Get Token from ACS portal.
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        private string GetTokenFromACS(string scope)
        {
            string wrapPassword = pwd;
            string wrapUsername = uid;

            // request a token from ACS
            string address = string.Format("https://{0}.{1}/WRAPv0.9", serviceNamespace, acsHostUrl);
            HttpWebRequest requestToken = (HttpWebRequest)HttpWebRequest.Create(address);
            variables = string.Format("{0}={1}&{2}={3}&{4}={5}", "wrap_name", wrapUsername, "wrap_password", wrapPassword, "wrap_scope", scope);
            requestToken.Method = "POST";
            AsyncCallback callBack = new AsyncCallback(EndGetRequestStream);
            requestToken.BeginGetRequestStream(callBack, requestToken);
            return tokenString;
        }

        public void EndGetRequestStream(IAsyncResult result)
        {
            HttpWebRequest requestToken = result.AsyncState as HttpWebRequest;
            Stream stream = requestToken.EndGetRequestStream(result);
            byte[] bytes = Encoding.UTF8.GetBytes(variables);
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
            requestToken.BeginGetResponse(TokenEndReponse, requestToken);
        }

        public void TokenEndReponse(IAsyncResult result)
        {
            HttpWebRequest requestToken = result.AsyncState as HttpWebRequest;
            HttpWebResponse responseToken = requestToken.EndGetResponse(result) as HttpWebResponse;
            using(StreamReader reader = new StreamReader(responseToken.GetResponseStream()))
            {
                tokenString = reader.ReadToEnd();
            }

            string resultString = HttpUtility.UrlDecode(
                tokenString
                .Split('&')
                .Single(value => value.StartsWith("wrap_access_token=", StringComparison.OrdinalIgnoreCase))
                .Split('=')[1]);
            tokenString = resultString;
            Dispatcher.BeginInvoke(() =>
                {
                    tbToken.Text = resultString;
                });

        }


    }

}

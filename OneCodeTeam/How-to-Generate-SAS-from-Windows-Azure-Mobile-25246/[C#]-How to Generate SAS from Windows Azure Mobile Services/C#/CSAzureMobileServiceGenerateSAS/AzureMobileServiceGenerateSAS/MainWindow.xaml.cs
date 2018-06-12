/****************************** Module Header ******************************\
* Module Name: MainWindow.xaml.cs
* Project:     AzureMobileServiceGenerateSAS
* Copyright (c) Microsoft Corporation.
* 
* This project will show you the token.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Windows;
using Microsoft.WindowsAzure.MobileServices;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AzureMobileServiceGenerateSAS
{

    public class SASToken
    {
        public string SAS { get; set; }
    }


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MobileServiceClient MobileService = new MobileServiceClient(
                 "https://[You mobile service name].azure-mobile.net/",
                 "Mobile Service Key"
             );


        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btnStart.IsEnabled = false;
		var user = await MobileService.LoginAsync(MobileServiceAuthenticationProvider.Facebook);
                tbUserID.Text = user.UserId;
                HttpMethod httpMethod = new HttpMethod("GET");

                Dictionary<string, string> dic = new Dictionary<string, string>();
                var apiResult = await MobileService.InvokeApiAsync("generateazuretablesas", httpMethod, dic);
                tbSAS.Text = apiResult.SelectToken("sas").ToString();
                AddToDebug("Get sas from mobile service API successfully, please copy the sas value and use it in TestClient.");
            }
            catch (Exception ex)
            {
                AddToDebug("An error occurs: {0} \n Please try again", ex);
            }
            finally
            {
                btnStart.IsEnabled = true;
            }
        }

        private void AddToDebug(string text, params object[] args)
        {
            if (args != null && args.Length > 0)
            {
                text = string.Format(text, args);
            }

            this.txtDebug.Text = this.txtDebug.Text + text + Environment.NewLine;
        }
    }
}
/***************************** Module Header ******************************\
* Module Name:	MainWindow.xamlcs
* Project:		CSAzureACAuthInWPF
* Copyright (c) Microsoft Corporation.
* 
* This sample shows:
* how to do authentication based on Azure Access control service(ACS).
* how to use ACS to secure your WCF service.
* 
* MainWindow
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
using System.Windows;
using CSAzureACSAuthInWPF.Properties;
using System.Net;
using System.IO;

namespace CSAzureACSAuthInWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            stateClear();
            stateCheck();
        }

        /// <summary>
        /// Clear User Information in Settings
        /// </summary>
        internal void stateClear()
        {
            Settings.Default.CustomerEmail = string.Empty;
            Settings.Default.SWT = string.Empty;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (btnLogin.Content.ToString() == "Login")
            {
                var newLogin = new Login();
                newLogin.Show();
            }
            else
            {
                stateClear();
                Settings.Default.Save();
                stateCheck();
            }
        }


        internal void stateCheck()
        {
            if (Settings.Default.CustomerEmail != string.Empty)
            {
                lblUserName.Visibility = Visibility.Visible;
                lblUserName.Content = Settings.Default.CustomerEmail;
                btnLogin.Content = "Logout";
            }
            else
            {
                btnLogin.Content = "Login";
                lblUserName.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Make a request to WCF service attach SWT.
        /// </summary>
        private void btnGetMessage_Click(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.SWT != String.Empty)
            {
                WebClient client = new WebClient();
                string headerValue = string.Format("WRAP access_token=\"{0}\"", Settings.Default.SWT);

                client.Headers.Add("Authorization", headerValue);
                Stream stream = client.OpenRead(@"http://localhost:12526/RESTUserService.svc/users");

                StreamReader reader = new StreamReader(stream);
                tblMessage.Text = reader.ReadToEnd();
            }
            else
            {
                System.Windows.MessageBox.Show("Please login first");
            }
        }
    }
}

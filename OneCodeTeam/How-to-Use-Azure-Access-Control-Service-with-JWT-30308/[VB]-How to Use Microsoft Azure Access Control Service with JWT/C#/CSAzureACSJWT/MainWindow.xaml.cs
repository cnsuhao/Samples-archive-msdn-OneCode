/***************************** Module Header ******************************\
* Module Name:	MainWindow.xamlcs
* Project:		CSAzureACSJWT
* Copyright (c) Microsoft Corporation.
* 
* This sample shows:
* how to do authentication based on Azure Access control service(ACS).
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

using CSAzureACSJWT.Properties;
using System.Windows;

namespace CSAzureACSJWT
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
                tblMessage.Text = string.Empty;
            }
        }
    }
}

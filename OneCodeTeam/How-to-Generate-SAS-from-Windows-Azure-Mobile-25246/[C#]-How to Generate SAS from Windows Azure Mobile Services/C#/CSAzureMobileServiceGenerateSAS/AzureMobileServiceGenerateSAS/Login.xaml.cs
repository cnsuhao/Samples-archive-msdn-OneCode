/****************************** Module Header ******************************\
* Module Name: Login.xaml.cs
* Project:     AzureMobileServiceGenerateSAS
* Copyright (c) Microsoft Corporation.
* 
* Interaction logic for Login.xaml
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
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Navigation;

namespace AzureMobileServiceGenerateSAS
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
       private Uri startUri;
        private Uri endUri;

        private bool loginCancelled = false;
        private string loginToken = null;

        public Login(Uri startUri, Uri endUri)
        {
            InitializeComponent();

            this.startUri = startUri;
            this.endUri = endUri;

            var bounds = Application.Current.MainWindow.RenderSize;
           
            this.grdRootPanel.Width = Math.Max(bounds.Width, 640);
            this.grdRootPanel.Height = Math.Max(bounds.Height, 480);

            this.webControl.LoadCompleted += webControl_LoadCompleted;
            this.webControl.Navigating += webControl_Navigating;
            this.webControl.Navigate(this.startUri);
        }

        void webControl_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (e.Uri.Equals(this.endUri))
            {
                string uri = e.Uri.ToString();
                int tokenIndex = uri.IndexOf("#token=");
                if (tokenIndex >= 0)
                {
                    this.loginToken = uri.Substring(tokenIndex + "#token=".Length);
                }
                else
                {
                     
                    this.loginCancelled = true;
                }

                ((Popup)this.Parent).IsOpen = false;
            }
        }

        void webControl_LoadCompleted(object sender, NavigationEventArgs e)
        {
            this.progress.Visibility = System.Windows.Visibility.Collapsed;
            this.webControl.Visibility = System.Windows.Visibility.Visible;
        }

        public Task<string> Display()
        {
            Popup popup = new Popup();
            popup.Child = this;
            popup.PlacementRectangle = new Rect(new Size(SystemParameters.FullPrimaryScreenWidth, SystemParameters.FullPrimaryScreenHeight));
            popup.Placement = PlacementMode.Center;
            TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();
            popup.IsOpen = true;
            popup.Closed += (snd, ea) =>
            {
                 if (this.loginCancelled)
                {
                    tcs.SetException(new InvalidOperationException("Login cancelled"));
                }
                else
                {
                    tcs.SetResult(this.loginToken);
                }
            };

            return tcs.Task;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.loginCancelled = true;
            ((Popup)this.Parent).IsOpen = false;
        }
    }
}

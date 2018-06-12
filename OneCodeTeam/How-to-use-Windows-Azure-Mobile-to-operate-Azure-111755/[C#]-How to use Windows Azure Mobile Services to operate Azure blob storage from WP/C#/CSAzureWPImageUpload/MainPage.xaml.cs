/**************************** Module Header ********************************\
* Module Name:    MainPage.xaml.cs
* Project:        CSAzureWPImageUpload
* Copyright (c) Microsoft Corporation
*
* MainPage.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/
using System;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CSAzureWPImageUpload.ViewModels;
using CSAzureWPImageUpload.DataSource;

namespace CSAzureWPImageUpload
{
    public partial class MainPage : PhoneApplicationPage
    {
        PictureDataSource pd;
        public MainPage()
        {
            InitializeComponent();

            pd = new PictureDataSource();

            llsPictures.ItemsSource = pd.AllPictures;

        }

        private void Upload_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/UploadPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void llsPictures_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PictureViewModel pvm = null;
            if (e.AddedItems.Count > 0 && e.AddedItems[0]!=null)
            {
                pvm = (PictureViewModel)e.AddedItems[0];
                var itemId = pvm.UniqueId;
                PhoneApplicationService.Current.State["SelectItem"] = pvm;
                NavigationService.Navigate(new Uri("/PictureDetailPage.xaml?itemId=" + itemId, UriKind.RelativeOrAbsolute));
                llsPictures.SelectedItem = null;
                
            }  
        }
    }
}
/**************************** Module Header ********************************\
* Module Name:    PictureDetailPage.xaml.cs
* Project:        CSAzureWPImageUpload
* Copyright (c) Microsoft Corporation
*
* PictureDetailPage.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CSAzureWPImageUpload.ViewModels;

namespace CSAzureWPImageUpload
{
    public partial class PictureDetailPage : PhoneApplicationPage
    {
     
        public PictureDetailPage()
        {
            InitializeComponent();
            
        }
        protected   override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var item=(PictureViewModel)PhoneApplicationService.Current.State["SelectItem"];
         
            this.DataContext = item;
        }
    }
}
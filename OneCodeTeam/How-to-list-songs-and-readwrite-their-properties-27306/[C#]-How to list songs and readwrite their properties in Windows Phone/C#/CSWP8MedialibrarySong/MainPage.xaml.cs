/****************************** Module Header ******************************\
* Module Name:    MainPage.xaml.cs
* Project:        CSWP8MedialibrarySong
* Copyright (c) Microsoft Corporation
*
* This sample will show you how to list songs and read/write their properties 
* in Windows Phone app.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework.Media;

namespace CSWP8MedialibrarySong
{
    public partial class MainPage : PhoneApplicationPage
    {
        /// <summary>
        /// MediaLibrary
        /// </summary>
        MediaLibrary ml = new MediaLibrary();

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Load Song list.
            lls.ItemsSource = ml.Songs.ToList<Song>();          
        }
       
        /// <summary>
        /// Navigation for selected song.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lls_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Song song = lls.SelectedItem as Song;
            NavigationService.Navigate(new Uri("/SongEdit.xaml?SongName=" + song.Name.ToString(), UriKind.Relative));
        }

        /// <summary>
        /// Search by name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var filterList = (from m in ml.Songs
                            where m.Name.Contains(tbKeywords.Text.Trim().ToString())
                            select m).ToList();

            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                lls.ItemsSource = filterList;
            });
        }
    }
}
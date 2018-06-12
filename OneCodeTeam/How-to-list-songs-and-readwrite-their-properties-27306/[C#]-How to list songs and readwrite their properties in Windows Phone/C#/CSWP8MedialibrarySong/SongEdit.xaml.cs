/****************************** Module Header ******************************\
* Module Name:    SongEdit.xaml.cs
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
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Media.PhoneExtensions;

namespace CSWP8MedialibrarySong
{
    public partial class SongEdit : PhoneApplicationPage
    {
        /// <summary>
        /// MediaLibrary
        /// </summary>
        MediaLibrary ml = new MediaLibrary();
        Song currentSong = null;
        string strSongName;

        public SongEdit()
        {
            InitializeComponent();

            Loaded += SongEdit_Loaded;
        }

        void SongEdit_Loaded(object sender, RoutedEventArgs e)
        {
            currentSong = (from m in ml.Songs
                           where m.Name.Contains(strSongName)
                           select m).First();
            this.DataContext = currentSong;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.Keys.Contains("SongName"))
            {
                strSongName = NavigationContext.QueryString["SongName"];
            }

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            strSongName = null;
            base.OnNavigatedFrom(e);
        }

        /// <summary>
        /// Save the new SongMetadata.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppSaveBar_Click(object sender, EventArgs e)
        {
            // Uri for current song.
            Uri songUri = null;         

            SongMetadata metaData = new SongMetadata();
            metaData.Name = tbName.Text.Trim().ToString();
            metaData.AlbumName = tbAlbumName.Text.Trim().ToString();
            metaData.ArtistName = tbArtistName.Text.Trim().ToString();
            metaData.GenreName = "test";

            foreach (var item in App.listMySong)
            {
                if (currentSong.Name.Equals(item.song.Name))
                {
                    songUri = item.FilePath;
                }
            }

            // The identity of whether to delete , to avoid duplication.
            bool isToDelete = true;

            if (songUri != null)
            {
                try
                {
                    MediaLibraryExtensions.Delete(ml, currentSong);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Equals("The user declined the delete request."))
                    {
                        isToDelete = false;
                    }
                }
                finally
                {
                    if (isToDelete)
                    {
                        var song = MediaLibraryExtensions.SaveSong(ml, songUri, metaData, SaveSongOperation.CopyToLibrary);
                    }
                }
            }

            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}
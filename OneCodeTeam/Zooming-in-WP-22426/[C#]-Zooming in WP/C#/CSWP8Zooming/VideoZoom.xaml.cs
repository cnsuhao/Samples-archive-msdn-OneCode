/****************************** Module Header ******************************\
* Module Name:    VideoZoom.xaml.cs
* Project:        CSWP8Zooming
* Copyright (c) Microsoft Corporation
*
* This demo shows how to zoom in/out image and video.
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
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;

namespace CSWP8Zooming
{
    public partial class VideoZoom : PhoneApplicationPage
    {
        string strLocalName = "howto.wmv";       // Local video.
        double maxHight = 0;                     // Max hight.
        double maxWidth = 0;                     // Max width.
        double changeHight = 0;                  // The amount of the increase or decrease of the high.
        double changeWidth = 0;                  // The amount of the increase or decrease of the width.      

        // Constructor
        public VideoZoom()
        {
            InitializeComponent();

            maxHight = VideoPlayer.ActualHeight;
            maxWidth = VideoPlayer.ActualWidth;
            changeHight = maxHight / 20;
            changeWidth = maxWidth / 20;

            VideoPlayer.Source = new Uri(strLocalName, UriKind.Relative);
            VideoPlayer.MediaEnded += VideoPlayer_MediaEnded;

            // Prepare ApplicationBar and buttons.
            PhoneAppBar = (ApplicationBar)ApplicationBar;
            PhoneAppBar.IsVisible = true;
            StartZoomIn = ((ApplicationBarIconButton)ApplicationBar.Buttons[0]);
            StartZoomOut = ((ApplicationBarIconButton)ApplicationBar.Buttons[1]);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

        /// <summary>
        /// Display the viewfinder when playback ends.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void VideoPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (VideoPlayer.CurrentState != MediaElementState.Playing)
            {
                VideoPlayer.Stop();
                VideoPlayer.Play();
            }
        }

        /// <summary>
        /// Zoom in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            if (VideoPlayer.Height <= maxHight && VideoPlayer.Width <= maxWidth)
            {
                VideoPlayer.Pause();
                VideoPlayer.Height += changeHight;
                VideoPlayer.Width += changeWidth;
                VideoPlayer.Play();
            }
        }

        /// <summary>
        /// Zoom out.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            if (VideoPlayer.Height > changeHight && VideoPlayer.Width > changeWidth)
            {
                VideoPlayer.Stop();
                VideoPlayer.Height -= changeHight;
                VideoPlayer.Width -= changeWidth;
                VideoPlayer.Play();
            }
        }
    }
}
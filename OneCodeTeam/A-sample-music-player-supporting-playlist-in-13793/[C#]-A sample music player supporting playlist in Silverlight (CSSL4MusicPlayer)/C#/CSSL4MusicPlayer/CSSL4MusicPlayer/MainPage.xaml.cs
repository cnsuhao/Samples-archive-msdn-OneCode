/****************************** Module Header ******************************\
* Module Name: MainPage.xaml.cs
* Project:     CSSL4MusicPlayer
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to create a media player in silverlight.
* User can upload some music files in Web application and generate an xml
* file. The music list would be from xml file, when you click music name
* of list, you can begin to enjoy your music. 
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/


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
using System.Xml;
using System.IO;
using System.Windows.Threading;
using System.Windows.Browser;

namespace CSSL4MusicPlayer
{
    public partial class MainPage : UserControl
    {
        // Define some public properties of application, include data items, 
        // some signal variables, a TimeSpan class and a timer. 
        public List<DataItem> DataItems;
        public bool blnIsMuted = false;
        public bool blnIsFull = false;
        private TimeSpan timeDuration;

        public MainPage()
        {
            InitializeComponent();
            this.XmlProcessMethod(); 
        }

        /// <summary>
        /// This method used to asynchronous loading data from xml file and 
        /// adds DownLoadXmlComplete method with WebCient, it will add other 
        /// methods to timer and media element.
        /// </summary>
        private void XmlProcessMethod()
        {
            WebClient webClient = new WebClient();
            webClient.DownloadStringAsync(new Uri(HtmlPage.Document.DocumentUri, "Resource/MusicList.xml"));
            webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(this.DownLoadXmlComplete);
            mediaElement.MediaEnded += new RoutedEventHandler(mediaElement_MediaEnded);
        }

        private void mediaElement_CurrentStateChanged(object sender, RoutedEventArgs e)
        {
            tbStatus.Text = mediaElement.CurrentState.ToString();
            if (mediaElement.CurrentState != MediaElementState.Playing && mediaElement.CurrentState != MediaElementState.Paused)
            {
                this.sliderProcess.IsEnabled = false;
            }
            else
            {
                this.sliderProcess.IsEnabled = true;
            }
        }

        private void mediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            tbStatus.Text = "complete";
            mediaElement.Pause();
            mediaElement.Position = TimeSpan.Zero;
        }

        private void mediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            tbStatus.Text = "start";
            // Retrieve music's total time.
            timeDuration = mediaElement.NaturalDuration.HasTimeSpan ? mediaElement.NaturalDuration.TimeSpan : TimeSpan.FromMilliseconds(0);
            sliderProcess.Maximum = timeDuration.TotalSeconds;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        { 
            mediaElement.Position = TimeSpan.Zero;
            mediaElement.Stop();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Play();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Pause();
        }

        /// <summary>
        /// Muted method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMuted_Click(object sender, RoutedEventArgs e)
        {
            if (!blnIsMuted)
            {
                btnMuted.Content = "Unmute";
                mediaElement.IsMuted = true;
                blnIsMuted = true;
            }
            else
            {
                btnMuted.Content = "Muted";
                mediaElement.IsMuted = false;
                blnIsMuted = false;
            }
        }

        /// <summary>
        /// Full screen method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFullScreen_Click(object sender, RoutedEventArgs e)
        {
            if (!blnIsFull)
            {
                btnFullScreen.Content = "Small Screen";
                Application.Current.Host.Content.IsFullScreen = true;
                blnIsFull = true;
            }
            else
            {
                btnFullScreen.Content = "Full Screen";
                Application.Current.Host.Content.IsFullScreen = false;
                blnIsFull = false;
            }
        }

        /// <summary>
        /// Load music data from xml file and convert data to a List of DataItem
        /// instances. Bind DataGrid control's ItemSource with it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownLoadXmlComplete(object sender, DownloadStringCompletedEventArgs e)
        {
            using (XmlReader reader = XmlReader.Create(new StringReader(e.Result)))
            {
                DataItems = new List<DataItem>();
                while (reader.Read())
                {
                    if (reader.IsStartElement() && reader.GetAttribute("open") == "1")
                    {
                        string pathMusic = reader.GetAttribute("path").ToString();
                        string nameMusic = reader.GetAttribute("name").ToString();
                        DataItem dataItem = new DataItem();
                        dataItem.NameItem = nameMusic;
                        dataItem.PathItem = pathMusic;
                        DataItems.Add(dataItem);
                    }
                }
                this.DataContext = DataItems;
            }
        }

        /// <summary>
        /// Allow user to change another song.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void girdList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sliderProcess.IsEnabled = true;
            mediaElement.Position = new TimeSpan(0);
            DataItem selectItem = (DataItem)girdList.SelectedItem;
            mediaElement.Source = new Uri(HtmlPage.Document.DocumentUri, selectItem.PathItem);
            mediaElement.Play();
        }

        /// <summary>
        /// Go back to the beginning of slider control when music plays complete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void mdeMusic_MediaEnded(object sender, RoutedEventArgs e)
        {
            mediaElement.Position = TimeSpan.Zero;
        }

    }
}

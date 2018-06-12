========================================================================
                  CSSL4MusicPlayer Overview
========================================================================

/////////////////////////////////////////////////////////////////////////////
Use:

The project illustrates how to create a media player via silverlight.
User can upload some music files in Web application and generate xml file, 
the xml file includes some useful information of music files.

/////////////////////////////////////////////////////////////////////////////
Demo the Sample. 

Please follow these demonstration steps below.

Step 1: Open the CSSL4MusicPlayer.sln. Set CSSL4MusicPlayer.Web as start up project.

Step 2: Expand the CSSL4MusicPlayer web application and press 
        Ctrl + F5 to show the CSSL4MusicPlayerTestPage.aspx.

Step 3: You will see a simple media player in CSSL4MusicPlayerTestPage.aspx page,
        you can choose a song to play.
	    [Note]
		please set CSSL4MusicPlayer.Web as startup project and 
		CSSL4MusicPlayerTestPage.aspx page as start page for testing this sample code.
		[/Note]

Step 4: The media player provides some basic functions for user set up. For example,
        user can monitor song's playback progress and time by process silder control,
	    he can check the song's current status, adjusts the volume and balance of 
		music by Slider controls, he can also mute, pause, stop, and resume the 
		current playing music.  

Step 5: Click the music play list for another song.

Step 6: Validation finished.

/////////////////////////////////////////////////////////////////////////////
Code Logical:

Step 1. Create a C# "Silverlight Application" in Visual Studio 2010 or
        Visual Web Developer 2010. Name it as "CSSL4MusicPlayer".

Step 2. Create an xml file and some music files in CSSL4MusicPlayer.Web application
        and create a class named "DataItem.cs" in CSSL4MusicPlayer application.

Step 3. Add some records of music files in MusicList.xml. The xml file need music's
        name and path, you can also add some other information about music files.

Step 4. Create a DataGrid control in MainPage.xaml page, add WebClient asynchronous
        loading the xml file and create a DownLoadXmlComplete function binding data 
		with DataGrid.
		[code]
            private void XmlProcessMethod()
            {
                WebClient webClient = new WebClient();
                webClient.DownloadStringAsync(new Uri(HtmlPage.Document.DocumentUri,
				    "ClientBin/MusicList.xml"));
                webClient.DownloadStringCompleted += new 
				    DownloadStringCompletedEventHandler(this.DownLoadXmlComplete);
                mediaElement.MediaEnded += new RoutedEventHandler(mediaElement_MediaEnded);
                this.Loaded += new RoutedEventHandler(VideoPlayer_Loaded);
            }

			private void DownLoadXmlComplete(object sender, DownloadStringCompletedEventArgs e)
            {
                XmlReader reader = XmlReader.Create(new StringReader(e.Result));
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
                girdList.ItemsSource = DataItems;
            }
	   [/code]

Step 5. Create a media element and some silders in MainPage.xaml page, add some
        buttons to config some basic function of media player.
	   [code]
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
       [/code]  

Step 7. Build the application and you can debug it.
/////////////////////////////////////////////////////////////////////////////
References:

MSDN: Media Element
http://msdn.microsoft.com/en-us/library/system.windows.controls.mediaelement(VS.95).aspx

MSDN: Slider
http://msdn.microsoft.com/en-us/library/system.windows.controls.slider(VS.95).aspx
/////////////////////////////////////////////////////////////////////////////
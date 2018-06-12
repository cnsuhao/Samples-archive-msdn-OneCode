========================================================================
                  CSSL4MediaPlayer Overview
========================================================================

/////////////////////////////////////////////////////////////////////////////
Use:

The project illustrates how to create a media player via silverlight.
User can upload some music files in Web application and generate xml file, 
the xml file includes some useful information of music files.

/////////////////////////////////////////////////////////////////////////////
Demo the Sample. 

Please follow these demonstration steps below.

Step 1: Open the VBSL4MusicPlayer.sln. Set VBSL4MusicPlayer.Web as start up project.

Step 2: Expand the VBSL4MusicPlayer web application and press 
        Ctrl + F5 to show the VBSL4MusicPlayerTestPage.aspx.

Step 3: You will see a simple media player in VBSL4MusicPlayerTestPage.aspx page,
        you can choose a song to play.
		[Node]
		please set VBSL4MusicPlayer.Web as startup project and 
		VBSL4MusicPlayerTestPage.aspx page as start page for testing this sample code.
		[/Node]

Step 4: The media player provides some basic functions for user set up. For example,
        user can monitor song's playback progress and time by process silder control,
	    he can check the song's current status, adjusts the volume and balance of 
		music by Slider controls, he can also mute, pause, stop, and resume the 
		current playing music.  

Step 5: Click the music play list for another song.

Step 6: Validation finished.

/////////////////////////////////////////////////////////////////////////////
Code Logical:

Step 1. Create a VB "Silverlight Application" in Visual Studio 2010 or
        Visual Web Developer 2010. Name it as "VBSL4MusicPlayer".

Step 2. Create an xml file and some music files in VBSL4MusicPlayer.Web application
        and create a class named "DataItem.cs" in VBSL4MusicPlayer application.

Step 3. Add some records of music files in MusicList.xml. The xml file need music's
        name and path, you can also add some other information about music files.

Step 4. Create a DataGrid control in MainPage.xaml page, add WebClient asynchronous
        loading the xml file and create a DownLoadXmlComplete function binding data 
		with DataGrid.
		[code]
             Private Sub XmlProcessMethod()
                 Dim webClient As New WebClient()
                 webClient.DownloadStringAsync(New Uri(HtmlPage.Document.DocumentUri, 
				     "ClientBin/MusicList.xml"))
                 AddHandler webClient.DownloadStringCompleted, AddressOf 
				     Me.DownLoadXmlComplete
             End Sub

			 Private Sub DownLoadXmlComplete(ByVal sender As Object, ByVal e
			      As DownloadStringCompletedEventArgs)
                 Dim reader As XmlReader = XmlReader.Create(New StringReader(e.Result))
                 DataItems = New List(Of DataItem)()
                 While reader.Read()
                     If reader.IsStartElement() AndAlso reader.GetAttribute("open") = "1" Then
                         Dim pathMusic As String = reader.GetAttribute("path").ToString()
                         Dim nameMusic As String = reader.GetAttribute("name").ToString()
                         Dim dataItem As New DataItem()
                         dataItem.NameItem = nameMusic
                         dataItem.PathItem = pathMusic
                         DataItems.Add(dataItem)
                     End If
                 End While
                 girdList.ItemsSource = DataItems
             End Sub
	   [/code]

Step 5. Create a media element and some silders in MainPage.xaml page, add some
        buttons to config some basic function of media player.
	   [code]
    Private Sub mediaElement_CurrentStateChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
        tbStatus.Text = mediaElement.CurrentState.ToString()
        If mediaElement.CurrentState <> MediaElementState.Playing AndAlso mediaElement.CurrentState <> MediaElementState.Paused Then
            sliderProcess.IsEnabled = False
        Else
            sliderProcess.IsEnabled = True
        End If
    End Sub

    Private Sub mediaElement_MediaEnded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        tbStatus.Text = "complete"
        mediaElement.Pause()
        mediaElement.Position = TimeSpan.Zero
    End Sub

    Private Sub mediaElement_MediaOpened(ByVal sender As Object, ByVal e As RoutedEventArgs)
        tbStatus.Text = "start"
        ' Retrieve music's total time.
        timeDuration = If(MediaElement.NaturalDuration.HasTimeSpan, MediaElement.NaturalDuration.TimeSpan, TimeSpan.FromMilliseconds(0))
        sliderProcess.Maximum = timeDuration.TotalSeconds
    End Sub

    Private Sub btnStop_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        mediaElement.Position = TimeSpan.Zero
        mediaElement.Stop()
    End Sub

    Private Sub btnPlay_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        mediaElement.Play()
    End Sub

    Private Sub btnPause_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        mediaElement.Pause()
    End Sub
       [/code]  

Step 7. Build the application and you can debug it.
/////////////////////////////////////////////////////////////////////////////
References:

MSDN: Media Element
http://msdn.microsoft.com/en-us/library/system.windows.controls.mediaelement(VS.95).aspx

MSDN: Slider
http://msdn.microsoft.com/en-us/library/system.windows.controls.slider(VS.95).aspx
/////////////////////////////////////////////////////////////////////////////
# A sample music player supporting playlist in Silverlight (VBSL4MusicPlayer)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Silverlight
## Topics
* Music Player
## IsPublished
* True
## ModifiedDate
* 2011-11-01 07:51:37
## Description

<h2>Silverlight APPLICATION: VBSL4MusicPlayer Overview</h2>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The project illustrates how to create a music player supporting playlist in Silverlight. User can upload some music files in Web application and generate xml file, the xml file includes some useful information of music files.</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Please follow these demonstration steps below.</p>
<p>Step 1: Open the VBSL4MusicPlayer.sln. Set VBSL4MusicPlayer.Web as start up project.</p>
<p>Step 2: Expand the VBSL4MusicPlayer web application and press Ctrl &#43; F5 to show the VBSL4MusicPlayerTestPage.aspx.</p>
<p>Step 3: You will see a simple media player in VBSL4MusicPlayerTestPage.aspx page, you can choose a song to play.<br>
&nbsp; [Note]<br>
&nbsp; please set VBSL4MusicPlayer.Web as startup project and VBSL4MusicPlayerTestPage.aspx page as start page for testing this sample code.<br>
&nbsp; [/Note]</p>
<p>Step 4: The media player provides some basic functions for user set up. For example, user can monitor song's playback progress and time by process silder control, he can check the song's current status, adjusts the volume and balance of music by Slider controls,
 he can also mute, pause, stop, and resume the&nbsp; current playing music.</p>
<p>Step 5: Click the music play list for another song.</p>
<p>Step 6: Validation finished.</p>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
Step 1. Create a&nbsp;VB &quot;Silverlight Application&quot; in Visual Studio 2010 or Visual Web Developer 2010. Name it as &quot;VBSL4MusicPlayer&quot;.</p>
<p>Step 2. Create an xml file and some music files in VBSL4MusicPlayer.Web application and create a class named &quot;DataItem.cs&quot; in VBSL4MusicPlayer application.</p>
<p>Step 3. Add some records of music files in MusicList.xml. The xml file need music's name and path, you can also add some other information about music files.</p>
<p>Step 4. Create a DataGrid control in MainPage.xaml page, add WebClient asynchronous&nbsp; loading the xml file and create a DownLoadXmlComplete function binding data with DataGrid.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">             Private Sub XmlProcessMethod()
                 Dim webClient As New WebClient()
                 webClient.DownloadStringAsync(New Uri(HtmlPage.Document.DocumentUri, 
				     &quot;ClientBin/MusicList.xml&quot;))
                 AddHandler webClient.DownloadStringCompleted, AddressOf 
				     Me.DownLoadXmlComplete
             End Sub

			 Private Sub DownLoadXmlComplete(ByVal sender As Object, ByVal e
			      As DownloadStringCompletedEventArgs)
                 Dim reader As XmlReader = XmlReader.Create(New StringReader(e.Result))
                 DataItems = New List(Of DataItem)()
                 While reader.Read()
                     If reader.IsStartElement() AndAlso reader.GetAttribute(&quot;open&quot;) = &quot;1&quot; Then
                         Dim pathMusic As String = reader.GetAttribute(&quot;path&quot;).ToString()
                         Dim nameMusic As String = reader.GetAttribute(&quot;name&quot;).ToString()
                         Dim dataItem As New DataItem()
                         dataItem.NameItem = nameMusic
                         dataItem.PathItem = pathMusic
                         DataItems.Add(dataItem)
                     End If
                 End While
                 girdList.ItemsSource = DataItems
             End Sub</pre>
<div class="preview">
<pre class="vb">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;XmlProcessMethod()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;webClient&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;WebClient()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;webClient.DownloadStringAsync(<span class="visualBasic__keyword">New</span>&nbsp;Uri(HtmlPage.Document.DocumentUri,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;ClientBin/MusicList.xml&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">AddHandler</span>&nbsp;webClient.DownloadStringCompleted,&nbsp;<span class="visualBasic__keyword">AddressOf</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.DownLoadXmlComplete&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;DownLoadXmlComplete(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DownloadStringCompletedEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;reader&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;XmlReader&nbsp;=&nbsp;XmlReader.Create(<span class="visualBasic__keyword">New</span>&nbsp;StringReader(e.Result))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataItems&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;List(<span class="visualBasic__keyword">Of</span>&nbsp;DataItem)()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;reader.Read()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;reader.IsStartElement()&nbsp;<span class="visualBasic__keyword">AndAlso</span>&nbsp;reader.GetAttribute(<span class="visualBasic__string">&quot;open&quot;</span>)&nbsp;=&nbsp;<span class="visualBasic__string">&quot;1&quot;</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;pathMusic&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;reader.GetAttribute(<span class="visualBasic__string">&quot;path&quot;</span>).ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;nameMusic&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;reader.GetAttribute(<span class="visualBasic__string">&quot;name&quot;</span>).ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dataItem&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;DataItem()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataItem.NameItem&nbsp;=&nbsp;nameMusic&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataItem.PathItem&nbsp;=&nbsp;pathMusic&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataItems.Add(dataItem)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;girdList.ItemsSource&nbsp;=&nbsp;DataItems&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">Step 5. Create a media element and some silders in MainPage.xaml page, add some buttons to config some basic function of media player.</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">    Private Sub mediaElement_CurrentStateChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
        tbStatus.Text = mediaElement.CurrentState.ToString()
        If mediaElement.CurrentState &lt;&gt; MediaElementState.Playing AndAlso mediaElement.CurrentState &lt;&gt; MediaElementState.Paused Then
            sliderProcess.IsEnabled = False
        Else
            sliderProcess.IsEnabled = True
        End If
    End Sub

    Private Sub mediaElement_MediaEnded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        tbStatus.Text = &quot;complete&quot;
        mediaElement.Pause()
        mediaElement.Position = TimeSpan.Zero
    End Sub

    Private Sub mediaElement_MediaOpened(ByVal sender As Object, ByVal e As RoutedEventArgs)
        tbStatus.Text = &quot;start&quot;
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
    End Sub</pre>
<div class="preview">
<pre class="vb">&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;mediaElement_CurrentStateChanged(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;RoutedEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tbStatus.Text&nbsp;=&nbsp;mediaElement.CurrentState.ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;mediaElement.CurrentState&nbsp;&lt;&gt;&nbsp;MediaElementState.Playing&nbsp;<span class="visualBasic__keyword">AndAlso</span>&nbsp;mediaElement.CurrentState&nbsp;&lt;&gt;&nbsp;MediaElementState.Paused&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sliderProcess.IsEnabled&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sliderProcess.IsEnabled&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;mediaElement_MediaEnded(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;RoutedEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tbStatus.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;complete&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mediaElement.Pause()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mediaElement.Position&nbsp;=&nbsp;TimeSpan.Zero&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;mediaElement_MediaOpened(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;RoutedEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tbStatus.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;start&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Retrieve&nbsp;music's&nbsp;total&nbsp;time.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timeDuration&nbsp;=&nbsp;<span class="visualBasic__keyword">If</span>(MediaElement.NaturalDuration.HasTimeSpan,&nbsp;MediaElement.NaturalDuration.TimeSpan,&nbsp;TimeSpan.FromMilliseconds(<span class="visualBasic__number">0</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sliderProcess.Maximum&nbsp;=&nbsp;timeDuration.TotalSeconds&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;btnStop_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;RoutedEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mediaElement.Position&nbsp;=&nbsp;TimeSpan.Zero&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mediaElement.<span class="visualBasic__keyword">Stop</span>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;btnPlay_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;RoutedEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mediaElement.Play()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;btnPause_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;RoutedEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mediaElement.Pause()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">Step 7. Build the application and you can debug it.</div>
<p style="font-family:Courier New">&nbsp;</p>
<h3>References:</h3>
<p>MSDN: Media Element<br>
<a href="http://msdn.microsoft.com/en-us/library/system.windows.controls.mediaelement(VS.95).aspx">http://msdn.microsoft.com/en-us/library/system.windows.controls.mediaelement(VS.95).aspx</a></p>
<p>MSDN: Slider<br>
<a href="http://msdn.microsoft.com/en-us/library/system.windows.controls.slider(VS.95).aspx">http://msdn.microsoft.com/en-us/library/system.windows.controls.slider(VS.95).aspx</a></p>
<p style="font-family:Courier New"><br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>

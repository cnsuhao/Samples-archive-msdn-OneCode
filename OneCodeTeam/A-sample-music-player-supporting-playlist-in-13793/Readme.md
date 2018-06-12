# A sample music player supporting playlist in Silverlight (CSSL4MusicPlayer)
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
* 2012-02-03 08:33:20
## Description

<h2>Silverlight APPLICATION: CSSL4MusicPlayer Overview</h2>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The project illustrates how to create a music player supporting playlist&nbsp;in Silverlight. User can upload some music files in Web application and generate xml file, the xml file includes some useful information of music files.</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Please follow these demonstration steps below.</p>
<p>Step 1: Open the CSSL4MusicPlayer.sln. Set CSSL4MusicPlayer.Web as start up project.</p>
<p>Step 2: Expand the CSSL4MusicPlayer web application and press&nbsp;Ctrl &#43; F5 to show the CSSL4MusicPlayerTestPage.aspx.</p>
<p>Step 3: You will see a simple media player in CSSL4MusicPlayerTestPage.aspx page, you can choose a song to play.<br>
&nbsp;&nbsp;[Note]<br>
&nbsp;&nbsp;please set CSSL4MusicPlayer.Web as startup project and&nbsp;CSSL4MusicPlayerTestPage.aspx page as start page for testing this sample code.<br>
&nbsp;&nbsp;[/Note]</p>
<p>Step 4: The media player provides some basic functions for user set up. For example, user can monitor song's playback progress and time by process silder control, he can check the song's current status, adjusts the volume and balance of&nbsp;music by Slider
 controls, he can also mute, pause, stop, and resume the&nbsp;&nbsp;current playing music.&nbsp;</p>
<p>Step 5: Click the music play list for another song.</p>
<p>Step 6: Validation finished.</p>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
Step 1. Create a C# &quot;Silverlight Application&quot; in Visual Studio 2010 or&nbsp;Visual Web Developer 2010. Name it as &quot;CSSL4MusicPlayer&quot;.</p>
<p>Step 2. Create an xml file and some music files in CSSL4MusicPlayer.Web application and create a class named &quot;DataItem.cs&quot; in CSSL4MusicPlayer application.</p>
<p>Step 3. Add some records of music files in MusicList.xml. The xml file need music's name and path, you can also add some other information about music files.</p>
<p>Step 4. Create a DataGrid control in MainPage.xaml page, add WebClient asynchronous&nbsp; loading the xml file and create a DownLoadXmlComplete function binding data&nbsp;with DataGrid.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">            private void XmlProcessMethod()
            {
                WebClient webClient = new WebClient();
                webClient.DownloadStringAsync(new Uri(HtmlPage.Document.DocumentUri,
        &quot;ClientBin/MusicList.xml&quot;));
                webClient.DownloadStringCompleted &#43;= new 
        DownloadStringCompletedEventHandler(this.DownLoadXmlComplete);
                mediaElement.MediaEnded &#43;= new RoutedEventHandler(mediaElement_MediaEnded);
                this.Loaded &#43;= new RoutedEventHandler(VideoPlayer_Loaded);
            }
 
   private void DownLoadXmlComplete(object sender, DownloadStringCompletedEventArgs e)
            {
                XmlReader reader = XmlReader.Create(new StringReader(e.Result));
                DataItems = new List&lt;DataItem&gt;();
                while (reader.Read())
                {
                    if (reader.IsStartElement() &amp;&amp; reader.GetAttribute(&quot;open&quot;) == &quot;1&quot;)
                    {
                        string pathMusic = reader.GetAttribute(&quot;path&quot;).ToString();
                        string nameMusic = reader.GetAttribute(&quot;name&quot;).ToString();
                        DataItem dataItem = new DataItem();
                        dataItem.NameItem = nameMusic;
                        dataItem.PathItem = pathMusic;
                        DataItems.Add(dataItem);
                    }
                }
                girdList.ItemsSource = DataItems;
            }
</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;XmlProcessMethod()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WebClient&nbsp;webClient&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;WebClient();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;webClient.DownloadStringAsync(<span class="cs__keyword">new</span>&nbsp;Uri(HtmlPage.Document.DocumentUri,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;ClientBin/MusicList.xml&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;webClient.DownloadStringCompleted&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DownloadStringCompletedEventHandler(<span class="cs__keyword">this</span>.DownLoadXmlComplete);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mediaElement.MediaEnded&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;RoutedEventHandler(mediaElement_MediaEnded);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Loaded&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;RoutedEventHandler(VideoPlayer_Loaded);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;DownLoadXmlComplete(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;DownloadStringCompletedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XmlReader&nbsp;reader&nbsp;=&nbsp;XmlReader.Create(<span class="cs__keyword">new</span>&nbsp;StringReader(e.Result));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataItems&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;DataItem&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(reader.Read())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(reader.IsStartElement()&nbsp;&amp;&amp;&nbsp;reader.GetAttribute(<span class="cs__string">&quot;open&quot;</span>)&nbsp;==&nbsp;<span class="cs__string">&quot;1&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;pathMusic&nbsp;=&nbsp;reader.GetAttribute(<span class="cs__string">&quot;path&quot;</span>).ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;nameMusic&nbsp;=&nbsp;reader.GetAttribute(<span class="cs__string">&quot;name&quot;</span>).ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataItem&nbsp;dataItem&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataItem();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataItem.NameItem&nbsp;=&nbsp;nameMusic;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataItem.PathItem&nbsp;=&nbsp;pathMusic;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataItems.Add(dataItem);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;girdList.ItemsSource&nbsp;=&nbsp;DataItems;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>Step 5. Create a media element and some silders in MainPage.xaml page, add some buttons to config some basic function of media player.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">        private void mediaElement_CurrentStateChanged(object sender, RoutedEventArgs e)
        {
            tbStatus.Text = mediaElement.CurrentState.ToString();
            if (mediaElement.CurrentState != MediaElementState.Playing &amp;&amp; mediaElement.CurrentState != MediaElementState.Paused)
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
            tbStatus.Text = &quot;complete&quot;;
            mediaElement.Pause();
            mediaElement.Position = TimeSpan.Zero;
        }
 
        private void mediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            tbStatus.Text = &quot;start&quot;;
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
        }</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;mediaElement_CurrentStateChanged(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tbStatus.Text&nbsp;=&nbsp;mediaElement.CurrentState.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(mediaElement.CurrentState&nbsp;!=&nbsp;MediaElementState.Playing&nbsp;&amp;&amp;&nbsp;mediaElement.CurrentState&nbsp;!=&nbsp;MediaElementState.Paused)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.sliderProcess.IsEnabled&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.sliderProcess.IsEnabled&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;mediaElement_MediaEnded(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tbStatus.Text&nbsp;=&nbsp;<span class="cs__string">&quot;complete&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mediaElement.Pause();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mediaElement.Position&nbsp;=&nbsp;TimeSpan.Zero;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;mediaElement_MediaOpened(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tbStatus.Text&nbsp;=&nbsp;<span class="cs__string">&quot;start&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Retrieve&nbsp;music's&nbsp;total&nbsp;time.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timeDuration&nbsp;=&nbsp;mediaElement.NaturalDuration.HasTimeSpan&nbsp;?&nbsp;mediaElement.NaturalDuration.TimeSpan&nbsp;:&nbsp;TimeSpan.FromMilliseconds(<span class="cs__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sliderProcess.Maximum&nbsp;=&nbsp;timeDuration.TotalSeconds;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;btnStop_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mediaElement.Position&nbsp;=&nbsp;TimeSpan.Zero;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mediaElement.Stop();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;btnPlay_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mediaElement.Play();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;btnPause_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mediaElement.Pause();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>Step 7. Build the application and you can debug it.</p>
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

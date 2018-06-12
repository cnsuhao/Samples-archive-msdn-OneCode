# Extract and convert audio file (CSExtractAudioFile)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Windows General
* Expression Encoder
## Topics
* Audio
* Encoder
## IsPublished
* True
## ModifiedDate
* 2011-06-19 01:55:07
## Description

<p style="font-family:Courier New">&nbsp;</p>
<h2>Windows APPLICATION: CSExtractAudioFile Overview</h2>
<p style="font-family:Courier New">&nbsp;</p>
<h3>Summary:</h3>
<p style="font-family:Courier New"><br>
The sample demonstrates how to extract and convert audio file formats, which <br>
include wav, mp3 and mp4 files.<br>
<br>
The sample is used to extract music file formats. We usually play music with <br>
Windows Media Player or other music-playing software. If we find our favorite <br>
music clip, we can use the function of this sample to extract it and convert <br>
it into another file format. All technology mentioned above is based on <br>
Expression Encoder SDK 4.0. When you install Expression Encoder 4.0, you can <br>
use Visual Studio 2010 to add a reference to it. In this way, you don't have <br>
to install the SDK installation kits individually.<br>
<br>
The sample uses Expression Encoder SDK 4 to output *.mp4 or *.wma file. The <br>
.mp3 audio format is currently not supported as output format in Expression <br>
Encoder 4.<br>
<br>
</p>
<h3>Prerequisite:</h3>
<p style="font-family:Courier New"><br>
1. Please install a free version, called &quot;Microsoft Expression Encoder 4&quot; at <br>
the link as follows:<br>
<a href="http://www.microsoft.com/downloads/en/details.aspx?displaylang=en&FamilyID=75402be0-c603-4998-a79c-becdd197aa79" target="_blank">http://www.microsoft.com/downloads/en/details.aspx?displaylang=en&amp;FamilyID=75402be0-c603-4998-a79c-becdd197aa79</a><br>
<br>
The free version is a feature-filled VC-1 encoding application that supports <br>
the following: <br>
<br>
&nbsp; &nbsp;- High performance multi-core encoding <br>
&nbsp; &nbsp;- Crop/scale/de-interlace operation <br>
&nbsp; &nbsp;- Multi-clip editing <br>
&nbsp; &nbsp;- A/B compare <br>
&nbsp; &nbsp;- Live encoding <br>
&nbsp; &nbsp;- Up to 10 minutes of screen capture <br>
&nbsp; &nbsp;- Smart encoding <br>
&nbsp; &nbsp;- Silverlight templates <br>
&nbsp; &nbsp;- Multi-channel audio import and export <br>
&nbsp; &nbsp;- Rich metadata support <br>
&nbsp; &nbsp;- Presets and custom plug-ins as well as <br>
&nbsp; &nbsp;- Full access to the .NET SDK for all above features <br>
&nbsp; &nbsp;- VC-1 Smooth Streaming (new for v4) <br>
<br>
The Professional version of Microsoft Expression Encoder 4 adds:<br>
&nbsp; &nbsp;- H.264 encoding (both MP4 and Smooth Streaming) <br>
&nbsp; &nbsp;- Live Smooth Streaming encoding <br>
&nbsp; &nbsp;- DRM <br>
&nbsp; &nbsp;- Native support of MP4/H.264, TS, M2TS, AVCHD, MPEG-2, ISM, ISMV, AAC
<br>
&nbsp; &nbsp; &nbsp;and AC-3 files<br>
&nbsp; &nbsp;- Unlimited screen capture durations <br>
<br>
So if you like these features provided by this software application, please <br>
purchase the professional version to support more advanced features.<br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
Step1. Install Microsoft Expression Encoder 4. <br>
<br>
Step2. Build and run the sample project in Visual Studio 2010. <br>
<br>
Step3. Prepare a .wma or .mp4 or .mp3 audio file. &nbsp;Click the button which is
<br>
&nbsp; &nbsp; &nbsp; written as &quot;Choose Audio File...&quot; and select the audio file.
<br>
<br>
Step4. Click the play button and drag the block on the progress bar to <br>
&nbsp; &nbsp; &nbsp; seek the position that you want to start extracting. &nbsp;Then, you click
<br>
&nbsp; &nbsp; &nbsp; the &quot;Set Start Point&quot; button.<br>
&nbsp; &nbsp; &nbsp; Do the same operation to set the end of extract file. &nbsp;It's important
<br>
&nbsp; &nbsp; &nbsp; that you don't set the extract end point before the start point.<br>
<br>
Step5. Select the audio output file format between WMA and MP4. Set the output <br>
&nbsp; &nbsp; &nbsp; directory.<br>
<br>
Step6. Click the &quot;Extract&quot; button to extract the audio file. &nbsp;If it succeeds,
<br>
&nbsp; &nbsp; &nbsp; you will be informed the output file path. &nbsp;You can play the output
<br>
&nbsp; &nbsp; &nbsp; audio file to check if the audio clip is correct. <br>
<br>
</p>
<h3>Implementation:</h3>
<p style="font-family:Courier New"><br>
1. The sample uses the Windows Media Player control to play the source audio <br>
&nbsp; file. &nbsp;The following MSDN article introduces how to embed the Windows
<br>
&nbsp; Media Player ActiveX control in a Windows Form.<br>
&nbsp; <a href="http://msdn.microsoft.com/en-us/library/dd562851.aspx" target="_blank">
http://msdn.microsoft.com/en-us/library/dd562851.aspx</a><br>
&nbsp; <br>
&nbsp; We play a specified audio file in the Windows Media Player control by <br>
&nbsp; setting its URL property and calling AxWindowsMediaPlayer.Ctlcontrols.open.<br>
<br>
&nbsp; &nbsp;this.player.URL = openAudioFileDialog.FileName;<br>
&nbsp; &nbsp;this.player.Ctlcontrols.play();<br>
<br>
&nbsp; When the form is being closed, we call the AxWindowsMediaPlayer.close() <br>
&nbsp; method to release Windows Media Player resources.<br>
<br>
&nbsp; &nbsp;private void MainForm_FormClosing(object sender, FormClosingEventArgs e)<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Releases Windows Media Player resources.<br>
&nbsp; &nbsp; &nbsp; &nbsp;this.player.close();<br>
&nbsp; &nbsp;}<br>
<br>
&nbsp; In order to get the current playing position in the media item, and save <br>
&nbsp; the start and end points, we use the <br>
&nbsp; AxWindowsMediaPlayer.Ctlcontrols.currentPosition property. It contains the
<br>
&nbsp; current position in the media item in seconds from the beginning:<br>
<br>
&nbsp; &nbsp;if (btnSetBeginEndPoints.Tag.Equals(&quot;SetStartPoint&quot;))<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Save the startpoint.<br>
&nbsp; &nbsp; &nbsp; &nbsp;// player.Ctlcontrols.currentPosition contains the current
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// position in the media item in seconds from the beginning.<br>
&nbsp; &nbsp; &nbsp; &nbsp;this.tbStartpoint.Text = (player.Ctlcontrols.currentPosition * 1000).ToString(&quot;0&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp;this.tbEndpoint.Text = &quot;&quot;;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;this.btnSetBeginEndPoints.Text = &quot;Set End Point&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp;this.btnSetBeginEndPoints.Tag = &quot;SetEndPoint&quot;;<br>
&nbsp; &nbsp;}<br>
&nbsp; &nbsp;else if (btnSetBeginEndPoints.Tag.Equals(&quot;SetEndPoint&quot;))<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;// Check if the startpoint is in front of the endpoint.<br>
&nbsp; &nbsp; &nbsp; &nbsp;int endPoint = (int)(player.Ctlcontrols.currentPosition * 1000);<br>
&nbsp; &nbsp; &nbsp; &nbsp;if (endPoint &lt;= int.Parse(this.tbStartpoint.Text))<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MessageBox.Show(&quot;Audio endpoint is overlapped. Please reset the endpoint.&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Save the endpoint<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.tbEndpoint.Text = endPoint.ToString();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.btnSetBeginEndPoints.Text = &quot;Set Start Point&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;this.btnSetBeginEndPoints.Tag = &quot;SetStartPoint&quot;;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;}<br>
<br>
2. The sample uses following helper function to cut the audio file from <br>
&nbsp; startpoint to endpoint, and output the clip as the selected audio format. &nbsp;<br>
<br>
&nbsp; &nbsp;public static string ExtractAudio(string sourceAudioFile, string outputDirectory,<br>
&nbsp; &nbsp; &nbsp; &nbsp;OutputAudioType outputAudioType, double startpoint, double endpoint)<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;using (Job job = new Job())<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;MediaItem src = new MediaItem(sourceAudioFile);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;switch (outputAudioType)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;case OutputAudioType.MP4:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;src.OutputFormat = new MP4OutputFormat();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;src.OutputFormat.AudioProfile = new AacAudioProfile();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;src.OutputFormat.AudioProfile.Codec = AudioCodec.AAC;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;src.OutputFormat.AudioProfile.BitsPerSample = 24;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;break;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;case OutputAudioType.WMA:<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;src.OutputFormat = new WindowsMediaOutputFormat();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;src.OutputFormat.AudioProfile = new WmaAudioProfile();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;src.OutputFormat.AudioProfile.Bitrate = new VariableConstrainedBitrate(128, 192);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;src.OutputFormat.AudioProfile.Codec = AudioCodec.WmaProfessional;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;src.OutputFormat.AudioProfile.BitsPerSample = 24;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;break;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;TimeSpan spanStart = TimeSpan.FromMilliseconds(startpoint);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;src.Sources[0].Clips[0].StartTime = spanStart;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;TimeSpan spanEnd = TimeSpan.FromMilliseconds(endpoint);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;src.Sources[0].Clips[0].EndTime = spanEnd;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;job.MediaItems.Add(src);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;job.OutputDirectory = outputDirectory;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;job.Encode();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return job.MediaItems[0].ActualOutputFileFullPath;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp;}<br>
<br>
&nbsp; btnExtract_Click in MainForm.cs calls the helper method to extract the audio file.<br>
<br>
&nbsp; &nbsp;OutputAudioType outputType = (OutputAudioType)this.cmbOutputAudioType.SelectedValue;<br>
&nbsp; &nbsp;string outputFileName = ExpressionEncoderWrapper.ExtractAudio(<br>
&nbsp; &nbsp;sourceAudioFile, outputDirectory, outputType, <br>
&nbsp; &nbsp;Double.Parse(startpoint), Double.Parse(endpoint));<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Expression Encoder SDK Programming Reference <br>
<a href="http://msdn.microsoft.com/en-us/library/ff396833(v=Expression.40).aspx" target="_blank">http://msdn.microsoft.com/en-us/library/ff396833(v=Expression.40).aspx</a><br>
<br>
Microsoft Expression Encoder 4 FAQ <br>
<a href="http://social.expression.microsoft.com/Forums/en/encoder/thread/3eabf903-b49f-4f92-b508-f28a795d6c90" target="_blank">http://social.expression.microsoft.com/Forums/en/encoder/thread/3eabf903-b49f-4f92-b508-f28a795d6c90</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

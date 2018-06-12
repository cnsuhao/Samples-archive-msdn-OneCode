# How to compress files into a single .gz file for download in ASP.NET(VS2012)
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
* .NET Framework
* Web App Development
## Topics
* Compression
## IsPublished
* True
## ModifiedDate
* 2014-11-03 06:41:08
## Description

<h2>How to compress files into a single .gz file for download in ASP.NET</h2>
<h2>Introduction</h2>
<p>The sample demonstrates how to compress files into a single .gz file for download in ASP.NET.It uses System.IO.Compression.</p>
<h2>Running the Sample</h2>
<p>Step1: Open the solution in Visual Studio 2012 and execute it. It will display list of files from the App_Data folder in a grid view (2 columns 1) Select 2) FileName) with a check box to select the file for download, from Content.aspx page.
<br>
<br>
Step2: Select the files to download i.e. through the checkbox in the gridview (for example SampleFileForDownload1.txt , SampleFileForDownload2.txt) and click Download which will give a Windows download prompt (Open/Save/Cancel Dialogue box). Click on save to
 download files to any physical location in the box. Saving will create a zip archive of .gz extension.
<br>
<br>
Step3: Extract the contents of the Zip (using any Zip extracting tools) to validate the contents of file.</p>
<h2>Using the Code</h2>
<p>The following method is used to compress files.It expects a list of file paths that will be compressed into a .gz file using System.IO.Compression</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden"> public void CompressToZipArchive(List filesForCompression)
			{
			   
					TempZipFilePath = HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings.GetValues(&quot;FolderPath&quot;).GetValue(0).ToString()) &#43; uniqueNameForZipFile &#43; &quot;.gz&quot;;

					using (FileStream compressedFileStream = File.Create(TempZipFilePath))
					{
						//ZipArchive class represents a package of compressed files in the zip archive format
						using (ZipArchive archive = new ZipArchive(compressedFileStream, ZipArchiveMode.Update))
						{
							foreach (string fileToCompress in filesForCompression)
							{
								FileInfo fileToCompressDetails = new FileInfo(fileToCompress);
								// Loop through each entry and add to ZipArchive 
								ZipArchiveEntry readmeEntry = archive.CreateEntryFromFile(fileToCompress, fileToCompressDetails.Name);
							}
						}
					}
			}
</pre>
<pre class="hidden">Public Sub CompressToZipArchive(filesForCompression As List(Of String))

				TempZipFilePath = HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings.GetValues(&quot;FolderPath&quot;).GetValue(0).ToString()) &amp; uniqueNameForZipFile &amp; &quot;.gz&quot;

				Using compressedFileStream As FileStream = File.Create(TempZipFilePath)
					'ZipArchive class represents a package of compressed files in the zip archive format
					Using archive As New ZipArchive(compressedFileStream, ZipArchiveMode.Update)
						For Each fileToCompress As String In filesForCompression
							Dim fileToCompressDetails As New FileInfo(fileToCompress)
							' Loop through each entry and add to ZipArchive 
							Dim readmeEntry As ZipArchiveEntry = archive.CreateEntryFromFile(fileToCompress, fileToCompressDetails.Name)
						Next
					End Using
				End Using
			End Sub
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">void</span>&nbsp;CompressToZipArchive(List&nbsp;filesForCompression)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TempZipFilePath&nbsp;=&nbsp;HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings.GetValues(<span class="cs__string">&quot;FolderPath&quot;</span>).GetValue(<span class="cs__number">0</span>).ToString())&nbsp;&#43;&nbsp;uniqueNameForZipFile&nbsp;&#43;&nbsp;<span class="cs__string">&quot;.gz&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(FileStream&nbsp;compressedFileStream&nbsp;=&nbsp;File.Create(TempZipFilePath))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//ZipArchive&nbsp;class&nbsp;represents&nbsp;a&nbsp;package&nbsp;of&nbsp;compressed&nbsp;files&nbsp;in&nbsp;the&nbsp;zip&nbsp;archive&nbsp;format</span><span class="cs__keyword">using</span>&nbsp;(ZipArchive&nbsp;archive&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ZipArchive(compressedFileStream,&nbsp;ZipArchiveMode.Update))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(<span class="cs__keyword">string</span>&nbsp;fileToCompress&nbsp;<span class="cs__keyword">in</span>&nbsp;filesForCompression)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FileInfo&nbsp;fileToCompressDetails&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;FileInfo(fileToCompress);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Loop&nbsp;through&nbsp;each&nbsp;entry&nbsp;and&nbsp;add&nbsp;to&nbsp;ZipArchive&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ZipArchiveEntry&nbsp;readmeEntry&nbsp;=&nbsp;archive.CreateEntryFromFile(fileToCompress,&nbsp;fileToCompressDetails.Name);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;The following method is used to send the Zip over HTTP</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">public void DownloadFile()
			{
				FileInfo zipPathDetails = new FileInfo(TempZipFilePath);
				HttpContext.Current.Response.ContentType = &quot;application/zip&quot;;
				HttpContext.Current.Response.AppendHeader(&quot;Content-Disposition&quot;, &quot;attachment; filename=&quot; &#43; zipPathDetails.Name);
				HttpContext.Current.Response.AddHeader(&quot;TempFileName&quot;, TempZipFilePath);   // Will be used in Application_EndRequest for file deletion
				HttpContext.Current.Response.WriteFile(TempZipFilePath);
				HttpContext.Current.ApplicationInstance.CompleteRequest();    
			}
</pre>
<pre class="hidden">Public Sub DownloadFile()
				Dim zipPathDetails As New FileInfo(TempZipFilePath)
				HttpContext.Current.Response.ContentType = &quot;application/zip&quot;
				HttpContext.Current.Response.AppendHeader(&quot;Content-Disposition&quot;, &quot;attachment; filename=&quot; &#43; zipPathDetails.Name)
				HttpContext.Current.Response.AddHeader(&quot;TempFileName&quot;, TempZipFilePath)
				' Will be used in Application_EndRequest for file deletion
				HttpContext.Current.Response.WriteFile(TempZipFilePath)
				HttpContext.Current.ApplicationInstance.CompleteRequest()
			End Sub
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">void</span>&nbsp;DownloadFile()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FileInfo&nbsp;zipPathDetails&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;FileInfo(TempZipFilePath);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.Response.ContentType&nbsp;=&nbsp;<span class="cs__string">&quot;application/zip&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.Response.AppendHeader(<span class="cs__string">&quot;Content-Disposition&quot;</span>,&nbsp;<span class="cs__string">&quot;attachment;&nbsp;filename=&quot;</span>&nbsp;&#43;&nbsp;zipPathDetails.Name);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.Response.AddHeader(<span class="cs__string">&quot;TempFileName&quot;</span>,&nbsp;TempZipFilePath);&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Will&nbsp;be&nbsp;used&nbsp;in&nbsp;Application_EndRequest&nbsp;for&nbsp;file&nbsp;deletion</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.Response.WriteFile(TempZipFilePath);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.ApplicationInstance.CompleteRequest();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
</div>
<div class="endscriptcode">The following event from global.asax is used to clear the temporary zip (.gz) created, since this will ensure file is transmitted to the client.</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">protected void Application_EndRequest(object sender, EventArgs e)
			{
			   
				try
				{
					//Deleting once the zip file is flushed to the client.
					if (HttpContext.Current.Response.Headers[&quot;TempfileName&quot;] != null)
					{
						string tempZipFilePath = HttpContext.Current.Response.Headers[&quot;TempfileName&quot;];
						File.Delete(tempZipFilePath);
					}
				}
				catch
				{
					// Add aditional code to log the deletion failure
				}
				finally
				{
					if(HttpContext.Current.Response.Headers[&quot;TempfileName&quot;] != null)
						HttpContext.Current.Response.Headers.Remove(&quot;TempfileName&quot;);     
				}
			}</pre>
<pre class="hidden">Sub Application_EndRequest(ByVal sender As Object, ByVal e As EventArgs)
				Try
					'Deleting once the zip file is flushed to the client.
					If HttpContext.Current.Response.Headers(&quot;TempfileName&quot;) IsNot Nothing Then
						Dim tempZipFilePath As String = HttpContext.Current.Response.Headers(&quot;TempfileName&quot;)
						File.Delete(tempZipFilePath)
					End If
					' Add aditional code to log the deletion failure
				Catch
				Finally
					If HttpContext.Current.Response.Headers(&quot;TempfileName&quot;) IsNot Nothing Then
						HttpContext.Current.Response.Headers.Remove(&quot;TempfileName&quot;)
					End If
				End Try

			End Sub		
        
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">protected</span><span class="cs__keyword">void</span>&nbsp;Application_EndRequest(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Deleting&nbsp;once&nbsp;the&nbsp;zip&nbsp;file&nbsp;is&nbsp;flushed&nbsp;to&nbsp;the&nbsp;client.</span><span class="cs__keyword">if</span>&nbsp;(HttpContext.Current.Response.Headers[<span class="cs__string">&quot;TempfileName&quot;</span>]&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;tempZipFilePath&nbsp;=&nbsp;HttpContext.Current.Response.Headers[<span class="cs__string">&quot;TempfileName&quot;</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;File.Delete(tempZipFilePath);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Add&nbsp;aditional&nbsp;code&nbsp;to&nbsp;log&nbsp;the&nbsp;deletion&nbsp;failure</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">finally</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>(HttpContext.Current.Response.Headers[<span class="cs__string">&quot;TempfileName&quot;</span>]&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.Response.Headers.Remove(<span class="cs__string">&quot;TempfileName&quot;</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
</div>
<p>&nbsp;</p>
<h2>More Information</h2>
<p><a href="http://msdn.microsoft.com/en-us/library/system.io.compression.ziparchive(v=vs.110).aspx"></a></p>
<p><span style="text-decoration:underline"><a href="http://msdn.microsoft.com/en-us/library/system.io.compression.ziparchive(v=vs.110).aspx">http://msdn.microsoft.com/en-us/library/system.io.compression.ziparchive(v=vs.110).aspx</a></span></p>
<p>&nbsp;</p>
<div class="endscriptcode"></div>

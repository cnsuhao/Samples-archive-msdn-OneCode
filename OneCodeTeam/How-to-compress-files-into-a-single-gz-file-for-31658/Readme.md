# How to compress files into a single .gz file for download in ASP.NET(VS2010)
## Requires
* Visual Studio 2010
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
* 2014-11-03 06:41:24
## Description

<h1>How to compress files into a single .gz file for download in ASP.NET</h1>
<h2>Introduction</h2>
<p>Many people seem to think, incorrectly, that the classes in the System.IO.Compression namespace, like GZipStream or DeflateStream, can create or read zip files. Not true. The System.IO.Compression namespace, available starting with .NET v2.0 for the desktop
 Framework and v3.5 for the Compact Framework, includes base class libraries supporting compression within streams - both the Deflate and Gzip formats are supported. But these classes are not directly useful for creating compressed ZIP archives. GZIP is not
 ZIP. Deflate is not ZIP. The GZipStream in System.IO.Compression is able to read and write GZIP streams, but that is not the same as reading or writing a zip file. Also, these classes deliver poor compression in practice, especially with binary data, or previously-compressed
 data. The sample demonstrates how to compress files into a single .gz file for download in ASP.NET using System.IO.Packaging. However a better approach is to use dotnetzip library available in codeplex
<a href="http://dotnetzip.codeplex.com/">http://dotnetzip.codeplex.com/ </a><br>
One cavet of using the ZipPackage to create Zips is that Packages contain a content type manifest named &quot;[Content_Types].xml&quot;.</p>
<h2>Running the Sample</h2>
<p>Step1: Open the solution in Visual Studio 2010 and specify the Web server for a Web application project by using project properties. In Solution Explorer, right-click the name of the Web application project (CSASPNETCompressFilesIntoSingleZip) and then click
 Properties. In the Properties window, click the Web tab and under the Servers select 'Use Local IIS web server' and click on 'Create Virtual Directory'. (Alternatively you can use IIS Express if you are VS 2010 SP1 and configure IIS Express)
<br>
<br>
Step2: Build the project and execute it. (Make sure you have necessary permissions, since we are using local web server). It will display a list of files from the App_Data folder in a grid view (2 columns 1) Select 2) FileName) with a check box to select the
 file for download, from Content.aspx page. Select the files to download through the checkbox in the gridview (for example SampleFileForDownload1.txt , SampleFileForDownload2.txt) and click Download which will give a Windows download prompt (Open/Save/Cancel
 Dialogue box). Click on save to download files to any physical location in the box. Saving will create a zip archive of .gz extension.
<br>
<br>
Step3: Extract the contents of the Zip (using any Zip extracting tools) to validate the contents of file.</p>
<h2>Using the Code</h2>
<p>The following methods are used to compress files.It expects a list of file paths that will be compressed into a .gz file using System.IO.Packaging</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">			public void CompressToZipArchive(List filesForCompression)
			{

				TempZipFilePath = HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings.GetValues(&quot;FolderPath&quot;).GetValue(0).ToString()) &#43; uniqueNameForZipFile &#43; &quot;.gz&quot;; // We can .zip extension also


						foreach (string fileToCompress in filesForCompression)
						{
							// Loop through each entry and add to ZipArchive 
							CreateZip(TempZipFilePath, fileToCompress);
						}
			}
			
			private void CreateZip(string tempZipPath, string inputFileToAdd)
			{
				using (Package package = Package.Open(tempZipPath, FileMode.OpenOrCreate))
				{
					string destFilename = &quot;.\\&quot; &#43; Path.GetFileName(inputFileToAdd);
					Uri uri = PackUriHelper.CreatePartUri(new Uri(destFilename, UriKind.Relative));

					// Checking if a file already exists in the Zip
					if (package.PartExists(uri))
					{
						package.DeletePart(uri);
					}

					PackagePart part = package.CreatePart(uri, &quot;&quot;, CompressionOption.Normal);

					using (FileStream fileStream = new FileStream(inputFileToAdd, FileMode.Open, FileAccess.Read))
					{                    
							CopyStream(fileStream, part.GetStream());                    
					}
				}
			}
			
			private void CopyStream(System.IO.FileStream source, System.IO.Stream target)
			{
				const int bufSize = 0x1000;
				byte[] buf = new byte[bufSize];
				int bytesRead = 0;
				while ((bytesRead = source.Read(buf, 0, bufSize)) &gt; 0)
					target.Write(buf, 0, bytesRead);
			}
        

</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">void</span>&nbsp;CompressToZipArchive(List&nbsp;filesForCompression)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TempZipFilePath&nbsp;=&nbsp;HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings.GetValues(<span class="cs__string">&quot;FolderPath&quot;</span>).GetValue(<span class="cs__number">0</span>).ToString())&nbsp;&#43;&nbsp;uniqueNameForZipFile&nbsp;&#43;&nbsp;<span class="cs__string">&quot;.gz&quot;</span>;&nbsp;<span class="cs__com">//&nbsp;We&nbsp;can&nbsp;.zip&nbsp;extension&nbsp;also</span><span class="cs__keyword">foreach</span>&nbsp;(<span class="cs__keyword">string</span>&nbsp;fileToCompress&nbsp;<span class="cs__keyword">in</span>&nbsp;filesForCompression)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Loop&nbsp;through&nbsp;each&nbsp;entry&nbsp;and&nbsp;add&nbsp;to&nbsp;ZipArchive&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateZip(TempZipFilePath,&nbsp;fileToCompress);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span><span class="cs__keyword">void</span>&nbsp;CreateZip(<span class="cs__keyword">string</span>&nbsp;tempZipPath,&nbsp;<span class="cs__keyword">string</span>&nbsp;inputFileToAdd)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(Package&nbsp;package&nbsp;=&nbsp;Package.Open(tempZipPath,&nbsp;FileMode.OpenOrCreate))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;destFilename&nbsp;=&nbsp;<span class="cs__string">&quot;.\\&quot;</span>&nbsp;&#43;&nbsp;Path.GetFileName(inputFileToAdd);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Uri&nbsp;uri&nbsp;=&nbsp;PackUriHelper.CreatePartUri(<span class="cs__keyword">new</span>&nbsp;Uri(destFilename,&nbsp;UriKind.Relative));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Checking&nbsp;if&nbsp;a&nbsp;file&nbsp;already&nbsp;exists&nbsp;in&nbsp;the&nbsp;Zip</span><span class="cs__keyword">if</span>&nbsp;(package.PartExists(uri))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;package.DeletePart(uri);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PackagePart&nbsp;part&nbsp;=&nbsp;package.CreatePart(uri,&nbsp;<span class="cs__string">&quot;&quot;</span>,&nbsp;CompressionOption.Normal);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(FileStream&nbsp;fileStream&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;FileStream(inputFileToAdd,&nbsp;FileMode.Open,&nbsp;FileAccess.Read))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CopyStream(fileStream,&nbsp;part.GetStream());&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span><span class="cs__keyword">void</span>&nbsp;CopyStream(System.IO.FileStream&nbsp;source,&nbsp;System.IO.Stream&nbsp;target)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">const</span><span class="cs__keyword">int</span>&nbsp;bufSize&nbsp;=&nbsp;0x1000;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;buf&nbsp;=&nbsp;<span class="cs__keyword">new</span><span class="cs__keyword">byte</span>[bufSize];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;bytesRead&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;((bytesRead&nbsp;=&nbsp;source.Read(buf,&nbsp;<span class="cs__number">0</span>,&nbsp;bufSize))&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;target.Write(buf,&nbsp;<span class="cs__number">0</span>,&nbsp;bytesRead);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">The following method is used to send the Zip over HTTP</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public void DownloadFile()
			{
				FileInfo zipPathDetails = new FileInfo(TempZipFilePath);
				if (IsGZipSupported())
				{
					HttpContext.Current.Response.Filter = new System.IO.Compression.GZipStream(HttpContext.Current.Response.Filter, System.IO.Compression.CompressionMode.Compress);
					HttpContext.Current.Response.AppendHeader(&quot;Content-Encoding&quot;, &quot;gzip&quot;); //decompressing the content before rendering
				}
				HttpContext.Current.Response.ContentType = &quot;application/zip&quot;;
				HttpContext.Current.Response.AppendHeader(&quot;Content-Disposition&quot;, &quot;attachment; filename=&quot; &#43; zipPathDetails.Name);
				HttpContext.Current.Response.AddHeader(&quot;TempFileName&quot;, TempZipFilePath);   // Will be used in Application_EndRequest for file deletion
				
				HttpContext.Current.Response.WriteFile(TempZipFilePath);            
				HttpContext.Current.ApplicationInstance.CompleteRequest();
			}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">void</span>&nbsp;DownloadFile()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FileInfo&nbsp;zipPathDetails&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;FileInfo(TempZipFilePath);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(IsGZipSupported())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.Response.Filter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;System.IO.Compression.GZipStream(HttpContext.Current.Response.Filter,&nbsp;System.IO.Compression.CompressionMode.Compress);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.Response.AppendHeader(<span class="cs__string">&quot;Content-Encoding&quot;</span>,&nbsp;<span class="cs__string">&quot;gzip&quot;</span>);&nbsp;<span class="cs__com">//decompressing&nbsp;the&nbsp;content&nbsp;before&nbsp;rendering</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.Response.ContentType&nbsp;=&nbsp;<span class="cs__string">&quot;application/zip&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.Response.AppendHeader(<span class="cs__string">&quot;Content-Disposition&quot;</span>,&nbsp;<span class="cs__string">&quot;attachment;&nbsp;filename=&quot;</span>&nbsp;&#43;&nbsp;zipPathDetails.Name);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.Response.AddHeader(<span class="cs__string">&quot;TempFileName&quot;</span>,&nbsp;TempZipFilePath);&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Will&nbsp;be&nbsp;used&nbsp;in&nbsp;Application_EndRequest&nbsp;for&nbsp;file&nbsp;deletion</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.Response.WriteFile(TempZipFilePath);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.ApplicationInstance.CompleteRequest();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>The following event from global.asax is used to clear the temporary zip (.gz) created, since this will ensure file is transmitted to the client.This will work only with IIS not with built-in Visual Studio Development server (aka. Cassini), so make sure you
 have IIS in the machine that is used to run this sample. i.e. use local IIS Web Server</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">protected void Application_EndRequest(object sender, EventArgs e)
			{              
				try
				{
					//Deleting once the zip file is flushed to the client.
					if (HttpContext.Current.Response.Headers[&quot;TempfileName&quot;] != null)
					{
						string tempZipFilePath = HttpContext.Current.Response.Headers[&quot;TempfileName&quot;];
						File.Delete(tempZipFilePath);
						HttpContext.Current.Response.Headers.Remove(&quot;TempfileName&quot;);
					}
				}
				catch
				{
					// Add aditional code to log the deletion failure
				}           
			} 
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">protected</span><span class="cs__keyword">void</span>&nbsp;Application_EndRequest(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Deleting&nbsp;once&nbsp;the&nbsp;zip&nbsp;file&nbsp;is&nbsp;flushed&nbsp;to&nbsp;the&nbsp;client.</span><span class="cs__keyword">if</span>&nbsp;(HttpContext.Current.Response.Headers[<span class="cs__string">&quot;TempfileName&quot;</span>]&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;tempZipFilePath&nbsp;=&nbsp;HttpContext.Current.Response.Headers[<span class="cs__string">&quot;TempfileName&quot;</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;File.Delete(tempZipFilePath);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.Response.Headers.Remove(<span class="cs__string">&quot;TempfileName&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Add&nbsp;aditional&nbsp;code&nbsp;to&nbsp;log&nbsp;the&nbsp;deletion&nbsp;failure</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h2>More Information</h2>
<p>We need to add reference of windowsbase .net library for Sytem.IO.Packaging</p>
<p><a href="http://msdn.microsoft.com/en-us/library/system.io.packaging(v=vs.100).aspx">http://msdn.microsoft.com/en-us/library/system.io.packaging(v=vs.100).aspx
</a><a href="http://msdn.microsoft.com/en-us/library/system.io.packaging.zippackage%28v=VS.90%29.aspx%20%20%20"><br>
http://msdn.microsoft.com/en-us/library/system.io.packaging.zippackage%28v=VS.90%29.aspx&nbsp;</a></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="endscriptcode"></div>

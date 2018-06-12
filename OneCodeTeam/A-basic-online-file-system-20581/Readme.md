# A basic online file system
## Requires
* Visual Studio 2012
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* file
## IsPublished
* True
## ModifiedDate
* 2013-01-27 06:58:15
## Description

<h1><span style="">Online File System to Upload and Download Files in C# </span>(CS<span style="">ASPNETOnlineFileSystem</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">CS<span style="">ASPNETOnlineFileSystem</span> shows <span style="">
you how to build an online file system to upload and download files in C#. This sample will use
<b style="">FileUpload</b> control to upload files and list all the files in a <b style="">
GridView</b>. Customer can click the files in the <b style="">GridView</b> to download them. Customer can create new folders, delete and rename folders and files in this file system.
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Please follow the demonstration steps below.<span style="">
</span></p>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Open the CSASPNETOnlineFileSystem.sln. </span>
</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">To configure the root path of online file system, you can modify the &lt;RootPath&gt; key in &lt;appSettings&gt; section of Web.Config file.
</span></p>
<p class="MsoListParagraphCxSpLast" style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Right click the OnlineFileSystem.aspx<span style="">&nbsp;
</span>page then select &quot;View in Browser&quot; </span></p>
<p class="MsoNormal"><span style="">Below </span>screenshot<span style=""> shows the main form of the online file system.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/75250/1/image.png" alt="" width="748" height="303" align="middle">
</span></p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoListParagraph" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Below is the core code to upload a file,</span><span style="color:black">
<b style="">fuChooseFile</b></span><span style="color:black"> is the ID property of the
</span><b style=""><span style="">FileUpload</span></b><span style=""> Control. </span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// The file Extension
            string fileExtension = string.Empty;


            // The choosed file name
            string fileName = string.Empty;


            // The new file name in the server
            string newFileName = string.Empty;


            // Check if choosed a file
            if (!fuChooseFile.HasFile)
            {
                lbMessage.Text = &quot;Please choose the file you want to upload. &quot; &#43;
                                 &quot;Note: The file size cannot be zero.&quot;;
                return;
            }




            fileExtension = Path.GetExtension(fuChooseFile.FileName);
            fileName = string.Format(&quot;{0}\\{1}&quot;, CurrentLocation,
                (string.IsNullOrEmpty(fileExtension) ? fuChooseFile.FileName : 
                fuChooseFile.FileName.Replace(fileExtension, &quot;&quot;)));


            if (fileExtension.ToLower() == &quot;.exe&quot; || fileExtension.ToLower() == &quot;.msi&quot;)
            {
                lbMessage.Text =
                    &quot;The file you want to upload cannot be a .exe or .msi file.&quot;;
                return;
            }


            newFileName = fileName;


            // Check file size
            if (fuChooseFile.PostedFile.ContentLength &gt;= 1024*1024*40)
            {
                lbMessage.Text =
                    &quot;The file you want to upload cannot be larger than 40 MB.&quot;;
                return;
            }


            try
            {
                // If there is already a file with the same name in the system,rename 
                // and then upload the file .
                int i = 0;
                while (File.Exists(newFileName &#43; fileExtension))
                { 
                    i&#43;&#43;;
                    newFileName = string.Format(fileName &#43; &quot;({0})&quot;, i);
                }


                fuChooseFile.SaveAs(newFileName &#43; fileExtension);


                lbMessage.Text =
                    string.Format(&quot;The file \&quot;{0}\&quot; was uploaded successfully!&quot;, 
                    Path.GetFileName( fileName));


                ShowFolderItems();
            }
            catch (HttpException he)
            {
                lbMessage.Text = 
                    string.Format(&quot;File {0} upload failed because of the following error:{1}.&quot;, 
                    fuChooseFile.PostedFile.FileName, he.Message);
            }

</pre>
<pre id="codePreview" class="csharp">
// The file Extension
            string fileExtension = string.Empty;


            // The choosed file name
            string fileName = string.Empty;


            // The new file name in the server
            string newFileName = string.Empty;


            // Check if choosed a file
            if (!fuChooseFile.HasFile)
            {
                lbMessage.Text = &quot;Please choose the file you want to upload. &quot; &#43;
                                 &quot;Note: The file size cannot be zero.&quot;;
                return;
            }




            fileExtension = Path.GetExtension(fuChooseFile.FileName);
            fileName = string.Format(&quot;{0}\\{1}&quot;, CurrentLocation,
                (string.IsNullOrEmpty(fileExtension) ? fuChooseFile.FileName : 
                fuChooseFile.FileName.Replace(fileExtension, &quot;&quot;)));


            if (fileExtension.ToLower() == &quot;.exe&quot; || fileExtension.ToLower() == &quot;.msi&quot;)
            {
                lbMessage.Text =
                    &quot;The file you want to upload cannot be a .exe or .msi file.&quot;;
                return;
            }


            newFileName = fileName;


            // Check file size
            if (fuChooseFile.PostedFile.ContentLength &gt;= 1024*1024*40)
            {
                lbMessage.Text =
                    &quot;The file you want to upload cannot be larger than 40 MB.&quot;;
                return;
            }


            try
            {
                // If there is already a file with the same name in the system,rename 
                // and then upload the file .
                int i = 0;
                while (File.Exists(newFileName &#43; fileExtension))
                { 
                    i&#43;&#43;;
                    newFileName = string.Format(fileName &#43; &quot;({0})&quot;, i);
                }


                fuChooseFile.SaveAs(newFileName &#43; fileExtension);


                lbMessage.Text =
                    string.Format(&quot;The file \&quot;{0}\&quot; was uploaded successfully!&quot;, 
                    Path.GetFileName( fileName));


                ShowFolderItems();
            }
            catch (HttpException he)
            {
                lbMessage.Text = 
                    string.Format(&quot;File {0} upload failed because of the following error:{1}.&quot;, 
                    fuChooseFile.PostedFile.FileName, he.Message);
            }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<p class="MsoListParagraph" style=""><span style="font-size:10.0pt; line-height:115%; font-family:&quot;Courier New&quot;"><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;
</span></span></span><span style="">Below is the core code to download a file from the online file system,
<b style="">filePath</b> is the full path of the file to be downloaded.</span><span style="font-size:10.0pt; line-height:115%; font-family:&quot;Courier New&quot;">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
FileInformation = new FileInfo(filePath);


System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
response.ClearContent();
response.Clear();
response.ContentType = &quot;text/plain&quot;;
response.AddHeader(&quot;Content-Disposition&quot;, &quot;attachment; filename=&quot; &#43; 
    FileInformation.Name &#43; &quot;;&quot;);
response.TransmitFile(filePath);
response.Flush();
response.End();

</pre>
<pre id="codePreview" class="csharp">
FileInformation = new FileInfo(filePath);


System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
response.ClearContent();
response.Clear();
response.ContentType = &quot;text/plain&quot;;
response.AddHeader(&quot;Content-Disposition&quot;, &quot;attachment; filename=&quot; &#43; 
    FileInformation.Name &#43; &quot;;&quot;);
response.TransmitFile(filePath);
response.Flush();
response.End();

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""></span></p>
<h2><span style="">More Information</span><span style=""> </span></h2>
<p class="MsoNormal"><span style="">Please reference <b style="">File</b> and <b style="">
Directory</b> class under the namespace <b style="">System.IO</b> for typical operations of file and directories.
</span></p>
<p class="MsoNormal" style="margin-left:.25in"><b style=""><span style="">System.IO.Directory</span></b><span style=""> class Reference:
<a href="http://msdn.microsoft.com/en-us/library/system.io.directory.aspx">http://msdn.microsoft.com/en-us/library/system.io.directory.aspx</a>
</span></p>
<p class="MsoNormal" style="margin-left:.25in"><b style=""><span style="">System.IO.File</span></b><span style=""> class Reference:
<a href="http://msdn.microsoft.com/en-us/library/system.io.file.aspx">http://msdn.microsoft.com/en-us/library/system.io.file.aspx</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

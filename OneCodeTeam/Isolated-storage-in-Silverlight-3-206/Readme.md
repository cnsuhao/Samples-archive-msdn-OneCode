# Isolated storage in Silverlight 3 (CSSL3IsolatedStorage)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Silverlight
## Topics
* Isolated Storage
## IsPublished
* True
## ModifiedDate
* 2011-05-05 06:11:08
## Description

<p style="font-family:Courier New"></p>
<h2>SILVERLIGHT APPLICATION : CSSL3IsolatedStorage Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This project create an Isolated Storage Explorer, with the use of explorer,<br>
user could view application IsolatedStorage's virtual file structure, and <br>
it also provides these file management functions:<br>
<br>
&nbsp; &nbsp;Create dictionary<br>
&nbsp; &nbsp;Upload local file to isolated storage<br>
&nbsp; &nbsp;Open media stream stored in isolated storage and play<br>
&nbsp; &nbsp;Delete dictionary/file<br>
&nbsp; &nbsp;Increase isolated storeage Quota<br>
&nbsp; &nbsp;Save isolated storage file to local<br>
&nbsp; &nbsp;Use IsolatedStorageSettings to store/load config<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
Silverlight 3 Tools for Visual Studio 2008 SP1<br>
<a target="_blank" href="http://www.microsoft.com/downloads/details.aspx?familyid=9442b0f2-7465-417a-88f3-5e7b5409e9dd&displaylang=en">http://www.microsoft.com/downloads/details.aspx?familyid=9442b0f2-7465-417a-88f3-5e7b5409e9dd&displaylang=en</a><br>
<br>
Silverilght 3 runtime:<br>
<a target="_blank" href="http://silverlight.net/getstarted/silverlight3">http://silverlight.net/getstarted/silverlight3</a><br>
<br>
</p>
<h3>Demo:</h3>
<p style="font-family:Courier New"><br>
To run the isolatedstorage sample, please try the following steps:<br>
&nbsp; 1. Open CSSL3IsolatedStorage, compile and run it.<br>
&nbsp; 2. In the thrid paragraph on the application's UI, it shows when you opened this application<br>
last time. This information is stored in IsolatedStorageSettings.<br>
&nbsp; 3. Push the &quot;Increase Quota By 10 MB&quot; button, the application's storage quota will be increased.<br>
&nbsp; 4. in treeview control, you may try to add,delete and open file. It will use API<br>
to manipulate the files in application's IsolatedStorage.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1: How does isolated storage treeview viewmodel works?<br>
&nbsp; &nbsp;1. Define Entities for isolated storage virtual file and directory.<br>
&nbsp; &nbsp;2. In treeview, use HierarchicalDataTemplate to bind data to treeview node.<br>
&nbsp; &nbsp;3. when application startup, traverse isolated storage, use defined entity<br>
&nbsp; &nbsp;to create treeview viewmodel, then set as treeview's itemssource.<br>
<br>
2: How to upload file to isolated storage?<br>
&nbsp; &nbsp;1. Use OpenFileDialog to get a local readable file stream.<br>
&nbsp; &nbsp;2. Get application's IsolatedStorageFile, then use CreateFile method to get one<br>
&nbsp; &nbsp; &nbsp; writeable IsolatedStorageStream.<br>
&nbsp; &nbsp;3. Copy bytes from file stream to isolatedstorage stream.<br>
&nbsp; &nbsp;4. Close streams.<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;Note that: copy stream is very time consuming, use BackgroundWorker to run it in<br>
&nbsp; &nbsp; &nbsp; other thread could get better performance. Details about BackgroundWorker, see<br>
&nbsp; &nbsp; &nbsp; <a target="_blank" href="http://msdn.microsoft.com/en-us/library/cc221403(VS.95).aspx">
http://msdn.microsoft.com/en-us/library/cc221403(VS.95).aspx</a><br>
<br>
3. How to open media stream stored in isolated storage and play?<br>
&nbsp; &nbsp;1. Open isolated storage stream.<br>
&nbsp; &nbsp; &nbsp; IsolatedStorageFile _isofile = IsolatedStorageFile.GetUserStoreForApplication();<br>
&nbsp; &nbsp; &nbsp; var stream = _isofile.OpenFile(item.FilePath, FileMode.Open, FileAccess.Read);<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp;2. set to MediaElement, play.<br>
&nbsp; &nbsp; &nbsp; mePlayer.SetSource(stream);<br>
<br>
4. How to use IsolatedStorageSetting to store config?<br>
&nbsp; &nbsp;IsolatedStorageSettings is a dictionary stored in isolated storage and maintained<br>
&nbsp; &nbsp;by silverlight. It's a good place to store configuration.<br>
&nbsp; &nbsp;<br>
&nbsp; &nbsp;To store data to IsolatedStorageSetting for application usage, use this<br>
&nbsp; &nbsp; &nbsp; &nbsp;solatedStorageSettings.ApplicationSettings[&quot;keyname&quot;] = data;<br>
<br>
&nbsp; &nbsp;And if need store data for whole site usage, use<br>
&nbsp; &nbsp; &nbsp; &nbsp;solatedStorageSettings.SiteSettings[&quot;keyname&quot;] = data;<br>
&nbsp; &nbsp; <br>
5. In application, why directory depth should be less than 4 ?<br>
&nbsp;&nbsp;&nbsp;&nbsp;Isolated storage limit the directory name should be less than 248 characters,<br>
&nbsp;&nbsp;&nbsp;&nbsp;and the full file path should be less than 260 characters. If create deeper<br>
&nbsp;&nbsp;&nbsp;&nbsp;directory, the path length would exceed the limitation.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Isolated Storage<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/bdts8hk0(VS.95).aspx">http://msdn.microsoft.com/en-us/library/bdts8hk0(VS.95).aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>

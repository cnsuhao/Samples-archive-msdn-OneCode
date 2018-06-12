# Create image slide show (CSImageFullScreenSlideShow)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* Windows Forms
## Topics
* Full Screen
* Slideshow
## IsPublished
* True
## ModifiedDate
* 2012-07-22 06:50:21
## Description
=============================================================================<br>
&nbsp; &nbsp; &nbsp; Windows APPLICATION: CSImageFullScreenSlideShow Overview<br>
=============================================================================<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Summary:<br>
<br>
The sample demonstrates how to display image slideshow in a Windows Forms <br>
application. &nbsp;It also shows how to enter the full screen mode to slide-show <br>
images. <br>
<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Demo:<br>
<br>
Step1. Build and run the sample project in Visual Studio 2008. <br>
<br>
Step2. Prepare some image files. &nbsp;Click the &quot;Open Folder...&quot; button and <br>
&nbsp; &nbsp; &nbsp; select the path which includes image files. <br>
<br>
Step3. Click &quot;Previous&quot; button and &quot;Next&quot; button to make image files <br>
&nbsp; &nbsp; &nbsp; displayed in order.<br>
<br>
Step4. Left-click the &quot;Settings&quot; button and select the internal between the <br>
&nbsp; &nbsp; &nbsp; displayed image files for Timer control in order to display them
<br>
&nbsp; &nbsp; &nbsp; with a fixed interval time. Finally, left-click the &quot;Start Slideshow&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; button to make the image files displayed one by one.<br>
<br>
Step5. Left-click the &quot;Full Screen&quot; button to display images in the full <br>
screen mode. &nbsp;Press the &quot;ESC&quot; key to leave the full screen mode.<br>
<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Implementation:<br>
<br>
1. When user selects the root folder of image files, the sample enumerates <br>
&nbsp; the image files in the folder using the stack-based iteration method <br>
&nbsp; demonstrated in this MSDN article: <br>
&nbsp; http://msdn.microsoft.com/en-us/library/bb513869.aspx<br>
&nbsp; The sample does not use <br>
&nbsp; &nbsp; &nbsp; &nbsp;Directory.GetFiles(path, &quot;*.*&quot;, SearchOption.AllDirectories);<br>
&nbsp; to enumerate the files because it will abort when the user does not have <br>
&nbsp; access permissions for certain directories or files in the root folder.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;public static string[] GetFiles(string path, string searchPattern)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string[] patterns = searchPattern.Split(';');<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;List&lt;string&gt; files = new List&lt;string&gt;();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;foreach (string filter in patterns)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Iterate through the directory tree and ignore the
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// DirectoryNotFoundException or UnauthorizedAccessException
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// exceptions. <br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// http://msdn.microsoft.com/en-us/library/bb513869.aspx<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Data structure to hold names of subfolders to be<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// examined for files.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Stack&lt;string&gt; dirs = new Stack&lt;string&gt;(20);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (!Directory.Exists(path))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;throw new ArgumentException();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dirs.Push(path);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;while (dirs.Count &gt; 0)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string currentDir = dirs.Pop();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string[] subDirs;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;subDirs = Directory.GetDirectories(currentDir);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// An UnauthorizedAccessException exception will be thrown
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// if we do not have discovery permission on a folder or
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// file. It may or may not be acceptable to ignore the
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// exception and continue enumerating the remaining files
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// and folders. It is also possible (but unlikely) that a
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// DirectoryNotFound exception will be raised. This will
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// happen if currentDir has been deleted by another
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// application or thread after our call to Directory.Exists.
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// The choice of which exceptions to catch depends entirely
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// on the specific task you are intending to perform and
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// also on how much you know with certainty about the
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// systems on which this code will run.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;catch (UnauthorizedAccessException)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;continue;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;catch (DirectoryNotFoundException)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;continue;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;try<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;files.AddRange(Directory.GetFiles(currentDir, filter));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;catch (UnauthorizedAccessException)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;continue;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;catch (DirectoryNotFoundException)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;continue;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Push the subdirectories onto the stack for traversal.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// This could also be done before handing the files.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;foreach (string str in subDirs)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;dirs.Push(str);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return files.ToArray();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
2. The sample displays the images in a PictureBox. <br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Show the image in the PictureBox.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public static void ShowImage(string path, PictureBox pct)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;pct.ImageLocation = path;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Show the previous image.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void ShowPrevImage()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ShowImage(this.imageFiles[(--this.selected) % this.imageFiles.Length], this.pictureBox);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Show the next image.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void ShowNextImage()<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ShowImage(this.imageFiles[(&#43;&#43;this.selected) % this.imageFiles.Length], this.pictureBox);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; A timer is used to automatically slideshow the images.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Show the next image at every regular intervals.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;private void timer_Tick(object sender, EventArgs e)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ShowNextImage();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
2. To slide-show images in the full-screen mode, the sample provides a helper <br>
&nbsp; class 'FullScreen'. &nbsp;FullScreen.cs contains two public methods: <br>
&nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp;EnterFullScreen - used to make a Windows Form display in the full screen.<br>
&nbsp; &nbsp; &nbsp; &nbsp;LeaveFullScreen - used to restore a Windows Form to its original state.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Maximize the window to the full screen.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public void EnterFullScreen(Form targetForm)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (!IsFullScreen)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Save(targetForm); &nbsp;// Save the original form state.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;targetForm.WindowState = FormWindowState.Maximized;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;targetForm.FormBorderStyle = FormBorderStyle.None;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;targetForm.TopMost = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;targetForm.Bounds = Screen.GetBounds(targetForm);<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;IsFullScreen = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Leave the full screen mode and restore the original window state.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public void LeaveFullScreen(Form targetForm)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (IsFullScreen)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Restore the original Window state.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;targetForm.WindowState = winState;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;targetForm.FormBorderStyle = brdStyle;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;targetForm.TopMost = topMost;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;targetForm.Bounds = bounds;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;IsFullScreen = false;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
References:<br>
<br>
How to: Iterate Through a Directory Tree (C# Programming Guide)<br>
http://msdn.microsoft.com/en-us/library/bb513869.aspx<br>
<br>
Screen.GetBounds Method <br>
http://msdn.microsoft.com/en-us/library/system.windows.forms.screen.getbounds.aspx<br>
<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>

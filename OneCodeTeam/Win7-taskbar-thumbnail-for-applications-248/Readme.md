# Win7 taskbar thumbnail images for applications (CSWin7TaskbarThumbnail)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* Windows 7
* Windows SDK
## Topics
* Windows Shell
* Taskbar
## IsPublished
* False
## ModifiedDate
* 2012-03-04 08:04:26
## Description

<h1><span style="">Win7 taskbar thumbnail images for applications (CSWin7TaskbarThumbnail)
</span></h1>
<h2>Introduction</h2>
<p class="MsoNormal"><br>
Thumbnail toolbars are another productivity feature that gives us the ability to do more without actually switching to another application's window. A thumbnail toolbar is essentially a mini remote-control that is displayed when you hover over the application's
 taskbar button, right beneath the application�s thumbnail. <br>
CSWin7TaskbarThumbnail example demostrates how to set Taskbar Thumbnail previews, change Thumbnail previews order, set Thumbnail toolbars using Taskbar related APIs in Windows API Code Pack.</p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoNormal"><span style="">Press F5 to run this application, and click two �Add as Thumbnail� Button, move mouse to Taskbar, you will see following result.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53659/1/image.png" alt="" width="641" height="480" align="middle">
</span><span style=""></span></p>
<h2>Using the Code</h2>
<p class="MsoNormal"></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style="font-family:Symbol"><span style="">�<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Thumbnail Preview:</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.75in; text-indent:-.25in">
<span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>In form load event, check the Windows version.<span style="">�
</span>If the current system is not Windows 7 or Windows Server 2008 R2, exit the process.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Check the Windows version, then update the UI, otherwise
// exit the current process
private void MainForm_Load(object sender, EventArgs e)
{
��� // Check whether the current system is Windows 7 or 
����// Windows Server 2008 R2
�� �if (TaskbarManager.IsPlatformSupported)
��� {
������� // Update the buttons' enable status
������� removeThumbnailButton.Enabled = false;
������� removeThumbnailButton2.Enabled = false;
��� }
��� else
��� {
������� MessageBox.Show(&quot;Taskbar Application ID is not supported in&quot;
����������� &#43; &quot; your operation system!&quot; &#43; Environment.NewLine &#43;
����������� &quot;Please launch the application in Windows 7 or &quot; &#43;
����������� &quot;Windows Server 2008 R2 systems.&quot;);


������� // Exit the current process
������� Application.Exit();
��� }
}

</pre>
<pre id="codePreview" class="csharp">
// Check the Windows version, then update the UI, otherwise
// exit the current process
private void MainForm_Load(object sender, EventArgs e)
{
��� // Check whether the current system is Windows 7 or 
����// Windows Server 2008 R2
�� �if (TaskbarManager.IsPlatformSupported)
��� {
������� // Update the buttons' enable status
������� removeThumbnailButton.Enabled = false;
������� removeThumbnailButton2.Enabled = false;
��� }
��� else
��� {
������� MessageBox.Show(&quot;Taskbar Application ID is not supported in&quot;
����������� &#43; &quot; your operation system!&quot; &#43; Environment.NewLine &#43;
����������� &quot;Please launch the application in Windows 7 or &quot; &#43;
����������� &quot;Windows Server 2008 R2 systems.&quot;);


������� // Exit the current process
������� Application.Exit();
��� }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.75in"></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.75in; text-indent:-.25in">
<span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create add and remove Thumbnail previews buttons event handler to add and remove the Thumbnial previews which are PictureBox images.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Make the image on preivewPictureBox1 as a Thumbnail preview
private void addThumbnailButton_Click(object sender, EventArgs e)
{
��� // Check whether the Thumbnail preview has been created
��� if (!HasThumbnailPreview(previewPictureBox1))
��� {
������� // Add the Thumbnail preview
������� this.AddThumbnailPreview(previewPictureBox1);


������� // Update the buttons' enable status
������� addThumbnailButton.Enabled = false;
������� removeThumbnailButton.Enabled = true;
��� }
}




// Remove the Thumbnail preview which is the image on 
// preivewPictureBox1
private void removeThumbnailButton_Click(object sender, EventArgs e)
{
��� // Try to retrieve the Thumbnail preview
��� TabbedThumbnail preview = TaskbarManager.Instance.
������� TabbedThumbnail.GetThumbnailPreview(previewPictureBox1);


��� if (preview != null)
��� {
������� // Remove the Thumbnail preview
������� this.RemoveThumbnailPreview(preview);


������� // Update the buttons' enable status
���� ���removeThumbnailButton.Enabled = false;
������� addThumbnailButton.Enabled = true;
��� }
}

</pre>
<pre id="codePreview" class="csharp">
// Make the image on preivewPictureBox1 as a Thumbnail preview
private void addThumbnailButton_Click(object sender, EventArgs e)
{
��� // Check whether the Thumbnail preview has been created
��� if (!HasThumbnailPreview(previewPictureBox1))
��� {
������� // Add the Thumbnail preview
������� this.AddThumbnailPreview(previewPictureBox1);


������� // Update the buttons' enable status
������� addThumbnailButton.Enabled = false;
������� removeThumbnailButton.Enabled = true;
��� }
}




// Remove the Thumbnail preview which is the image on 
// preivewPictureBox1
private void removeThumbnailButton_Click(object sender, EventArgs e)
{
��� // Try to retrieve the Thumbnail preview
��� TabbedThumbnail preview = TaskbarManager.Instance.
������� TabbedThumbnail.GetThumbnailPreview(previewPictureBox1);


��� if (preview != null)
��� {
������� // Remove the Thumbnail preview
������� this.RemoveThumbnailPreview(preview);


������� // Update the buttons' enable status
���� ���removeThumbnailButton.Enabled = false;
������� addThumbnailButton.Enabled = true;
��� }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.75in"></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.75in; text-indent:-.25in">
<span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create change Thumbnail previews order button event handler to modify the Thumbnail previews order.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Change the Thumbnail previews order
private void changePreviewOrderButton_Click(object sender, 
����EventArgs e)
{
��� // Check if the Thumbnail preview 
����if (tabbedThumbnailList.Count == MAX_PREVIEW_COUNT)
��� {
������� // Change the Thumbnail preview order
������� TaskbarManager.Instance.TabbedThumbnail.SetTabOrder(
����������� tabbedThumbnailList[1], tabbedThumbnailList[0]);


������� // Reverse the Thumbnail preview image list
������� tabbedThumbnailList.Reverse();
��� }
}

</pre>
<pre id="codePreview" class="csharp">
// Change the Thumbnail previews order
private void changePreviewOrderButton_Click(object sender, 
����EventArgs e)
{
��� // Check if the Thumbnail preview 
����if (tabbedThumbnailList.Count == MAX_PREVIEW_COUNT)
��� {
������� // Change the Thumbnail preview order
������� TaskbarManager.Instance.TabbedThumbnail.SetTabOrder(
����������� tabbedThumbnailList[1], tabbedThumbnailList[0]);


������� // Reverse the Thumbnail preview image list
������� tabbedThumbnailList.Reverse();
��� }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.75in"></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style="font-family:Symbol"><span style="">�<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Thumbnail Toolbar Buttons:</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.75in; text-indent:-.25in">
<span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create the TabControl selected index changed event handler to create Thumbnail toolbar buttons, clear Thumbnail previews when the user switches the tab to the Thumbnail Toolbar Button page, and make the Thumbnail Toolbar buttons invisible
 when the user switches to the Thumbnail Preview page.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Change the Thumbnail effect between Thumbnail preview and 
// Thumbnail toolbar based on TabControl's selected index.
private void thumbnailTabControl_SelectedIndexChanged(object sender,
��� EventArgs e)
{
��� // Check if it is Thumbnail toolbar index
��� if (thumbnailTabControl.SelectedIndex == THUMBNAIL_TOOLBAR)
��� {
������� // Clear all the Thumbnail previews first


������� // Try to retrieve the Thumbnail preview of previewPictureBox1
������� TabbedThumbnail preview = TaskbarManager.Instance.
����������� TabbedThumbnail.GetThumbnailPreview(previewPictureBox1);


������� if (preview != null)
������� {
����������� // Remove the Thumbnail preview
����������� this.RemoveThumbnailPreview(preview);
������� }


���� ���// Try to retrieve the Thumbnail preview of previewPictureBox2
������� preview = TaskbarManager.Instance.TabbedThumbnail.
����������� GetThumbnailPreview(previewPictureBox2);


������� if (preview != null)
������� {
����������� // Remove the Thumbnail preview
����������� this.RemoveThumbnailPreview(preview);
������� }




������� // Then update the Thumbnail toolbar page effect
 
��������// Select and focus the first image in the image list
������� imageListView.Items[0].Selected = true;
������� imageListView.Focus();


������� // Check if the Thumbnail buttons have been created
������� if (!toolBarButtonCreated)
������� {
����������� // Create the Thumbnail toolbar buttons
����������� CreateToolbarButtons();


����������� // Set the flag
��������� ��toolBarButtonCreated = true;
������� }
������� else
������� {
����������� // Make all the Thumbnail toolbar buttons visible
����������� ChangeVisibility(buttonPrevious, true);
����������� ChangeVisibility(buttonFirst, true);
����������� ChangeVisibility(buttonLast, true);
����������� ChangeVisibility(buttonNext, true);
������� }
��� }
��� // Check if it is Thumbnail preview index
��� else if (thumbnailTabControl.SelectedIndex == THUMBNAIL_PREVIEW)
��� {
������� // Make all the Thumbnail toolbar buttons invisible
������� ChangeVisibility(buttonPrevious, false);
������� ChangeVisibility(buttonFirst, false);
������� ChangeVisibility(buttonLast, false);
������� ChangeVisibility(buttonNext, false);


������� // Update the buttons' enable status
������� addThumbnailButton.Enabled = true;
������� removeThumbnailButton.Enabled = false;
������� addThumbnailButton2.Enabled = true;
������� removeThumbnailButton2.Enabled = false;
��� }
}

</pre>
<pre id="codePreview" class="csharp">
// Change the Thumbnail effect between Thumbnail preview and 
// Thumbnail toolbar based on TabControl's selected index.
private void thumbnailTabControl_SelectedIndexChanged(object sender,
��� EventArgs e)
{
��� // Check if it is Thumbnail toolbar index
��� if (thumbnailTabControl.SelectedIndex == THUMBNAIL_TOOLBAR)
��� {
������� // Clear all the Thumbnail previews first


������� // Try to retrieve the Thumbnail preview of previewPictureBox1
������� TabbedThumbnail preview = TaskbarManager.Instance.
����������� TabbedThumbnail.GetThumbnailPreview(previewPictureBox1);


������� if (preview != null)
������� {
����������� // Remove the Thumbnail preview
����������� this.RemoveThumbnailPreview(preview);
������� }


���� ���// Try to retrieve the Thumbnail preview of previewPictureBox2
������� preview = TaskbarManager.Instance.TabbedThumbnail.
����������� GetThumbnailPreview(previewPictureBox2);


������� if (preview != null)
������� {
����������� // Remove the Thumbnail preview
����������� this.RemoveThumbnailPreview(preview);
������� }




������� // Then update the Thumbnail toolbar page effect
 
��������// Select and focus the first image in the image list
������� imageListView.Items[0].Selected = true;
������� imageListView.Focus();


������� // Check if the Thumbnail buttons have been created
������� if (!toolBarButtonCreated)
������� {
����������� // Create the Thumbnail toolbar buttons
����������� CreateToolbarButtons();


����������� // Set the flag
��������� ��toolBarButtonCreated = true;
������� }
������� else
������� {
����������� // Make all the Thumbnail toolbar buttons visible
����������� ChangeVisibility(buttonPrevious, true);
����������� ChangeVisibility(buttonFirst, true);
����������� ChangeVisibility(buttonLast, true);
����������� ChangeVisibility(buttonNext, true);
������� }
��� }
��� // Check if it is Thumbnail preview index
��� else if (thumbnailTabControl.SelectedIndex == THUMBNAIL_PREVIEW)
��� {
������� // Make all the Thumbnail toolbar buttons invisible
������� ChangeVisibility(buttonPrevious, false);
������� ChangeVisibility(buttonFirst, false);
������� ChangeVisibility(buttonLast, false);
������� ChangeVisibility(buttonNext, false);


������� // Update the buttons' enable status
������� addThumbnailButton.Enabled = true;
������� removeThumbnailButton.Enabled = false;
������� addThumbnailButton2.Enabled = true;
������� removeThumbnailButton2.Enabled = false;
��� }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.75in"></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create a enum type to represent the Thumbnail toolbar buttons.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create a method CreateToolbarButtons to initialize the Thumbnail toolbar buttons.</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.75in; text-indent:-.25in">
<span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create a method ChangeVisibility to change the certain Thumbnail button's visible and enable status based on the current selected index in the imageListView.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Change the certain Thumbnail button's visible and enable status
// based on the current selected index in the imageListView
private void ChangeVisibility(ThumbnailToolbarButton btn, 
����bool show, ButtonTask task)
{
��� if (btn != null)
��� {
������� // Update the button's UI status
������� btn.Visible = show;
������� btn.IsInteractive = show;


������� // Change the certain button enable status based on the 
��������// selected index of the imageListView
������� switch (task)
����� ��{
����������� case ButtonTask.First:
����������� case ButtonTask.Previous:
��������������� // The First and Previous Thumbnail toolbar button 
����������������// is enabled if the first image in the 
����������������// imageListView is not selected
���� �����������btn.Enabled = !imageListView.Items[0].Selected;
��������������� break;
����������� case ButtonTask.Last:
����������� case ButtonTask.Next:
��������������� // The Last and Next Thumbnail toolbar button 
����������������// is enabled if the last image in the 
����������������// imageListView is not selected
��������������� btn.Enabled = !imageListView.Items[imageListView.
������������������� Items.Count - 1].Selected;
��������������� break;
������� }
��� }
}

</pre>
<pre id="codePreview" class="csharp">
// Change the certain Thumbnail button's visible and enable status
// based on the current selected index in the imageListView
private void ChangeVisibility(ThumbnailToolbarButton btn, 
����bool show, ButtonTask task)
{
��� if (btn != null)
��� {
������� // Update the button's UI status
������� btn.Visible = show;
������� btn.IsInteractive = show;


������� // Change the certain button enable status based on the 
��������// selected index of the imageListView
������� switch (task)
����� ��{
����������� case ButtonTask.First:
����������� case ButtonTask.Previous:
��������������� // The First and Previous Thumbnail toolbar button 
����������������// is enabled if the first image in the 
����������������// imageListView is not selected
���� �����������btn.Enabled = !imageListView.Items[0].Selected;
��������������� break;
����������� case ButtonTask.Last:
����������� case ButtonTask.Next:
��������������� // The Last and Next Thumbnail toolbar button 
����������������// is enabled if the last image in the 
����������������// imageListView is not selected
��������������� btn.Enabled = !imageListView.Items[imageListView.
������������������� Items.Count - 1].Selected;
��������������� break;
������� }
��� }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.75in"></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.75in; text-indent:-.25in">
<span style=""><span style="">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create a method ShowList to update the selected index when the certain Thumbnail toolbar button is clicked.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Update the selected index when the certain Thumbnail toolbar 
// button is clicked
private void ShowList(int newIndex)
{
��� // Check whether the selected index is valid
��� if (newIndex &lt; 0 || newIndex &gt; imageListView.Items.Count - 1)
������� return;


��� // Update the selected index and focus the imageListView
��� imageListView.Items[newIndex].Selected = true;
��� imageListView.Focus();
}

</pre>
<pre id="codePreview" class="csharp">
// Update the selected index when the certain Thumbnail toolbar 
// button is clicked
private void ShowList(int newIndex)
{
��� // Check whether the selected index is valid
��� if (newIndex &lt; 0 || newIndex &gt; imageListView.Items.Count - 1)
������� return;


��� // Update the selected index and focus the imageListView
��� imageListView.Items[newIndex].Selected = true;
��� imageListView.Focus();
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.75in"></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<span style=""><span style="">6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create event handlers for Thumbnail toolbar buttons First, Previous, Next, and Last.</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.75in; text-indent:-.25in">
<span style=""><span style="">7.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create imageListView selected index changed event handler to retrieve images from Resource based on the selected index of the imageListView.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Show different image in the imagePictureBox based on the 
// selected index of the imageListView
private void imageListView_SelectedIndexChanged(object sender, 
����EventArgs e)
{
��� if (imageListView.SelectedItems.Count &gt; 0)
��� {
������� Image image;
������� // Retrieve the image from the Resource according to the 
��������// selected index of the imageListView
������� switch (imageListView.SelectedItems[0].ImageIndex)
������� {
����������� case 0:
��������������� image = Properties.Resources.C;
��������������� break;
����������� case 1:
��������������� image = Properties.Resources.O;
��������������� break;
����������� case 2:
��������������� image = Properties.Resources.D;
��������������� break;
����������� default:
������������� ��image = Properties.Resources.E;
��������������� break;
������� }


������� // Update the image in the imagePictureBox
������� imagePictureBox.Image = image;


������� // Update the visible and enable status of the Thumbnail
������� // toolbar buttons
���� ���UpdateButtons();
��� }
}

</pre>
<pre id="codePreview" class="csharp">
// Show different image in the imagePictureBox based on the 
// selected index of the imageListView
private void imageListView_SelectedIndexChanged(object sender, 
����EventArgs e)
{
��� if (imageListView.SelectedItems.Count &gt; 0)
��� {
������� Image image;
������� // Retrieve the image from the Resource according to the 
��������// selected index of the imageListView
������� switch (imageListView.SelectedItems[0].ImageIndex)
������� {
����������� case 0:
��������������� image = Properties.Resources.C;
��������������� break;
����������� case 1:
��������������� image = Properties.Resources.O;
��������������� break;
����������� case 2:
��������������� image = Properties.Resources.D;
��������������� break;
����������� default:
������������� ��image = Properties.Resources.E;
��������������� break;
������� }


������� // Update the image in the imagePictureBox
������� imagePictureBox.Image = image;


������� // Update the visible and enable status of the Thumbnail
������� // toolbar buttons
���� ���UpdateButtons();
��� }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:.75in"></p>
<p class="MsoNormal" style=""><a href="http://code.msdn.microsoft.com/WindowsAPICodePack">Windows® API Code Pack for Microsoft® .NET Framework</a></p>
<p class="MsoNormal" style=""><a href="http://msdn.microsoft.com/en-us/magazine/dd942846.aspx">Inside Windows 7 Introducing The Taskbar APIs</a></p>
<p class="MsoNormal" style=""><a href="http://blogs.microsoft.co.il/blogs/sasha/archive/2009/01/25/welcome-to-the-windows-7-taskbar.aspx">Welcome to the Windows 7 Taskbar</a></p>
<p class="MsoNormal" style=""><a href="http://www.microsoft.com/downloads/details.aspx?familyid=1C333F06-FADB-4D93-9C80-402621C600E7&displaylang=en">Windows 7 Training Kit For Developers</a></p>
<p class="MsoNormal" style=""><a href="http://blogs.microsoft.co.il/blogs/sasha/archive/2009/02/26/windows-7-taskbar-thumbnail-toolbars.aspx">Windows 7 Taskbar: Thumbnail Toolbars</a></p>
<p class="MsoNormal" style=""><a href="http://blogs.microsoft.co.il/blogs/sasha/archive/2009/08/12/windows-7-taskbar-tabbed-thumbnails-and-previews-in-native-code.aspx">Windows 7 Taskbar: Tabbed Thumbnails and Previews in Native Code</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

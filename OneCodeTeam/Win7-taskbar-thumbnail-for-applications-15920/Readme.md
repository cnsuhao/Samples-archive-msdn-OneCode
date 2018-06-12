# Win7 taskbar thumbnail images for applications (VBWin7TaskbarThumbnail)
## Requires
* Visual Studio 2010
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
* 2012-03-04 08:03:28
## Description

<h1><span style="">Win7 taskbar thumbnail images for applications (VBWin7TaskbarThumbnail)
</span></h1>
<h2>Introduction</h2>
<p class="MsoNormal"><br>
Thumbnail toolbars are another productivity feature that gives us the ability to do more without actually switching to another application's window. A thumbnail toolbar is essentially a mini remote-control that is displayed when you hover over the application's
 taskbar button, right beneath the application�s thumbnail. <br>
CSWin7TaskbarThumbnail example demostrates how to set Taskbar Thumbnail previews, change Thumbnail previews order, set Thumbnail toolbars using Taskbar related APIs in Windows API Code Pack.</p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoNormal"><span style="">Press F5 to run this application, and click two �Add as Thumbnail� Button, move mouse to Taskbar, you will see following result.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53654/1/image.png" alt="" width="798" height="355" align="middle">
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
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Check the Windows version, then update the UI, otherwise
' exit the current process
Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As� _
������������������������� System.EventArgs) Handles MyBase.Load
��� If Not TaskbarManager.IsPlatformSupported Then
������� MessageBox.Show(&quot;Taskbar ProgressBar is not supported in your &quot; & _
����������������������� &quot;operation system!&quot; & vbNewLine & &quot;Please launch &quot; & _
����������������������� &quot;the application in Windows 7 or &quot; & _
����������������������� &quot;Windows Server 2008 R2 systems.&quot;)


������� '� Exit the current process
�� �����Application.Exit()
��� Else
������� ' Update the buttons' enable status
������� removeThumbnailButton.Enabled = False
������� removeThumbnailButton2.Enabled = False
��� End If
End Sub

</pre>
<pre id="codePreview" class="vb">
' Check the Windows version, then update the UI, otherwise
' exit the current process
Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As� _
������������������������� System.EventArgs) Handles MyBase.Load
��� If Not TaskbarManager.IsPlatformSupported Then
������� MessageBox.Show(&quot;Taskbar ProgressBar is not supported in your &quot; & _
����������������������� &quot;operation system!&quot; & vbNewLine & &quot;Please launch &quot; & _
����������������������� &quot;the application in Windows 7 or &quot; & _
����������������������� &quot;Windows Server 2008 R2 systems.&quot;)


������� '� Exit the current process
�� �����Application.Exit()
��� Else
������� ' Update the buttons' enable status
������� removeThumbnailButton.Enabled = False
������� removeThumbnailButton2.Enabled = False
��� End If
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.75in"></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.75in; text-indent:-.25in">
<span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;"> </span>
</span></span>Create add and remove Thumbnail previews buttons event handler to add and remove the Thumbnial previews which are PictureBox images.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Make the image on preivewPictureBox1 as a Thumbnail preview
Private Sub addThumbnailButton_Click(ByVal sender As System.Object, ByVal _
������������������������������������ e As System.EventArgs) Handles _
������������������������������������ addThumbnailButton.Click
��� ' Check whether the Thumbnail preview has been created
��� If Not HasThumbnailPreview(pictureBox1) Then


������� ' Add the Thumbnail preview
������� Me.AddThumbnailPreview(pictureBox1)


������� ' Update the buttons' enable status
������� addThumbnailButton.Enabled = False
������� removeThumbnailButton.Enabled = True
��� End If
End Sub




' Remove the Thumbnail preview which is the image on preivewPictureBox1
Private Sub removeThumbnailButton_Click(ByVal sender As System.Object, _
��������������������������������������� ByVal e As System.EventArgs) _
���������������������� �����������������Handles removeThumbnailButton.Click
��� ' Try to retrieve the Thumbnail preview
��� Dim preview As TabbedThumbnail = TaskbarManager.Instance.TabbedThumbnail. _
������������������������������������������� GetThumbnailPreview(pictureBox1)


 ���If Not preview Is Nothing Then


������� ' Remove the Thumbnail preview
������� Me.RemoveThumbnailPreview(preview)


������� ' Update the buttons' enable status
������� removeThumbnailButton.Enabled = False
������� addThumbnailButton.Enabled = True
��� End If
End Sub

</pre>
<pre id="codePreview" class="vb">
' Make the image on preivewPictureBox1 as a Thumbnail preview
Private Sub addThumbnailButton_Click(ByVal sender As System.Object, ByVal _
������������������������������������ e As System.EventArgs) Handles _
������������������������������������ addThumbnailButton.Click
��� ' Check whether the Thumbnail preview has been created
��� If Not HasThumbnailPreview(pictureBox1) Then


������� ' Add the Thumbnail preview
������� Me.AddThumbnailPreview(pictureBox1)


������� ' Update the buttons' enable status
������� addThumbnailButton.Enabled = False
������� removeThumbnailButton.Enabled = True
��� End If
End Sub




' Remove the Thumbnail preview which is the image on preivewPictureBox1
Private Sub removeThumbnailButton_Click(ByVal sender As System.Object, _
��������������������������������������� ByVal e As System.EventArgs) _
���������������������� �����������������Handles removeThumbnailButton.Click
��� ' Try to retrieve the Thumbnail preview
��� Dim preview As TabbedThumbnail = TaskbarManager.Instance.TabbedThumbnail. _
������������������������������������������� GetThumbnailPreview(pictureBox1)


 ���If Not preview Is Nothing Then


������� ' Remove the Thumbnail preview
������� Me.RemoveThumbnailPreview(preview)


������� ' Update the buttons' enable status
������� removeThumbnailButton.Enabled = False
������� addThumbnailButton.Enabled = True
��� End If
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.75in"></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.75in; text-indent:-.25in">
<span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;"> </span>
</span></span>Create change Thumbnail previews order button event handler to modify the Thumbnail previews order.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Change the Thumbnail previews order
Private Sub changePreviewOrderButton_Click(ByVal sender As System.Object, _
������������������������������������������ ByVal e As System.EventArgs) _
������������������������������������������ Handles changePreviewOrderButton.Click
��� ' Check if the Thumbnail preview 
����If tabbedThumbnailList.Count = MAX_PREVIEW_COUNT Then


������� ' Change the Thumbnail preview order
������� TaskbarManager.Instance.TabbedThumbnail.SetTabOrder(tabbedThumbnailList(1), _
����������������������������������������������������������� tabbedThumbnailList(0))
������� ' Reverse the Thumbnail preview image list
������� tabbedThumbnailList.Reverse()
��� End If
End Sub

</pre>
<pre id="codePreview" class="vb">
' Change the Thumbnail previews order
Private Sub changePreviewOrderButton_Click(ByVal sender As System.Object, _
������������������������������������������ ByVal e As System.EventArgs) _
������������������������������������������ Handles changePreviewOrderButton.Click
��� ' Check if the Thumbnail preview 
����If tabbedThumbnailList.Count = MAX_PREVIEW_COUNT Then


������� ' Change the Thumbnail preview order
������� TaskbarManager.Instance.TabbedThumbnail.SetTabOrder(tabbedThumbnailList(1), _
����������������������������������������������������������� tabbedThumbnailList(0))
������� ' Reverse the Thumbnail preview image list
������� tabbedThumbnailList.Reverse()
��� End If
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.75in"></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style="font-family:Symbol"><span style="">�<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Thumbnail Toolbar Buttons:</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.75in; text-indent:-.25in">
<span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;"> </span>
</span></span>Create the TabControl selected index changed event handler to create Thumbnail toolbar buttons, clear Thumbnail previews when the user switches the tab to the Thumbnail Toolbar Button page, and make the Thumbnail Toolbar buttons invisible when
 the user switches to the Thumbnail Preview page.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Change the Thumbnail effect between Thumbnail preview and 
' Thumbnail toolbar based on TabControl's selected index.
Private Sub thumbnailTabControl_SelectedIndexChanged(ByVal sender As System.Object, _
���������������������������������������������������� ByVal e As System.EventArgs) _
���������������������������������������������������� Handles thumbnailTabControl. _
���������������������������������������������������� SelectedIndexChanged
��� ' Check if it is Thumbnail toolbar index
��� If thumbnailTabControl.SelectedIndex = THUMBNAIL_TOOLBAR Then


������� ' Clear the all the Thumbnail previews first


������� ' Try to retrieve the Thumbnail preview of previewPictureBox1
������� Dim preview As TabbedThumbnail = TaskbarManager.Instance. _
������������������������������� TabbedThumbnail.GetThumbnailPreview(pictureBox1)


������� If Not preview Is Nothing Then
����������� ' Remove the Thumbnail preview
����������� Me.RemoveThumbnailPreview(preview)
������� End If


������� ' Try to retrieve the Thumbnail preview of previewPictureBox2
������� preview = TaskbarManager.Instance.TabbedThumbnail. _
������������������������������� GetThumbnailPreview(pictureBox2)


������� If Not preview Is Nothing Then
����������� ' Remove the Thumbnail preview
����������� Me.RemoveThumbnailPreview(preview)
������� End If




������� '� Then update the Thumbnail toolbar page effect


������� ' Select and focus the first image in the image list
������� imageListView.Items(0).Selected = True
������� imageListView.Focus()


������� ' Check if the Thumbnail buttons have been created
������� If Not toolBarButtonCreated Then
����������� ' Create the Thumbnail toolbar buttons
����������� CreateToolbarButtons()


����������� ' Set the flag
����������� toolBarButtonCreated = True
������� Else
����������� ' Make all the Thumbnail toolbar buttons visible
����������� ChangeVisibility(buttonPrevious, True)
����������� ChangeVisibility(buttonFirst, True)
����������� ChangeVisibility(buttonLast, True)
����������� ChangeVisibility(buttonNext, True)
������� End If
������� ' Check if it is Thumbnail preview index
��� ElseIf thumbnailTabControl.SelectedIndex = THUMBNAIL_PREVIEW Then
������� ' Make all the Thumbnail toolbar buttons invisible
������� ChangeVisibility(buttonPrevious, False)
������� ChangeVisibility(buttonFirst, False)
������� ChangeVisibility(buttonLast, False)
������� ChangeVisibility(buttonNext, False)


������� ' Update the buttons' enable status
������� addThumbnailButton.Enabled = True
������� removeThumbnailButton.Enabled = False
������� addThumbnailButton2.Enabled = True
������� removeThumbnailButton2.Enabled = False
��� End If
End Sub

</pre>
<pre id="codePreview" class="vb">
' Change the Thumbnail effect between Thumbnail preview and 
' Thumbnail toolbar based on TabControl's selected index.
Private Sub thumbnailTabControl_SelectedIndexChanged(ByVal sender As System.Object, _
���������������������������������������������������� ByVal e As System.EventArgs) _
���������������������������������������������������� Handles thumbnailTabControl. _
���������������������������������������������������� SelectedIndexChanged
��� ' Check if it is Thumbnail toolbar index
��� If thumbnailTabControl.SelectedIndex = THUMBNAIL_TOOLBAR Then


������� ' Clear the all the Thumbnail previews first


������� ' Try to retrieve the Thumbnail preview of previewPictureBox1
������� Dim preview As TabbedThumbnail = TaskbarManager.Instance. _
������������������������������� TabbedThumbnail.GetThumbnailPreview(pictureBox1)


������� If Not preview Is Nothing Then
����������� ' Remove the Thumbnail preview
����������� Me.RemoveThumbnailPreview(preview)
������� End If


������� ' Try to retrieve the Thumbnail preview of previewPictureBox2
������� preview = TaskbarManager.Instance.TabbedThumbnail. _
������������������������������� GetThumbnailPreview(pictureBox2)


������� If Not preview Is Nothing Then
����������� ' Remove the Thumbnail preview
����������� Me.RemoveThumbnailPreview(preview)
������� End If




������� '� Then update the Thumbnail toolbar page effect


������� ' Select and focus the first image in the image list
������� imageListView.Items(0).Selected = True
������� imageListView.Focus()


������� ' Check if the Thumbnail buttons have been created
������� If Not toolBarButtonCreated Then
����������� ' Create the Thumbnail toolbar buttons
����������� CreateToolbarButtons()


����������� ' Set the flag
����������� toolBarButtonCreated = True
������� Else
����������� ' Make all the Thumbnail toolbar buttons visible
����������� ChangeVisibility(buttonPrevious, True)
����������� ChangeVisibility(buttonFirst, True)
����������� ChangeVisibility(buttonLast, True)
����������� ChangeVisibility(buttonNext, True)
������� End If
������� ' Check if it is Thumbnail preview index
��� ElseIf thumbnailTabControl.SelectedIndex = THUMBNAIL_PREVIEW Then
������� ' Make all the Thumbnail toolbar buttons invisible
������� ChangeVisibility(buttonPrevious, False)
������� ChangeVisibility(buttonFirst, False)
������� ChangeVisibility(buttonLast, False)
������� ChangeVisibility(buttonNext, False)


������� ' Update the buttons' enable status
������� addThumbnailButton.Enabled = True
������� removeThumbnailButton.Enabled = False
������� addThumbnailButton2.Enabled = True
������� removeThumbnailButton2.Enabled = False
��� End If
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.75in"></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;"> </span>
</span></span>Create a enum type to represent the Thumbnail toolbar buttons.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;"> </span>
</span></span>Create a method CreateToolbarButtons to initialize the Thumbnail toolbar buttons.</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.75in; text-indent:-.25in">
<span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;"> </span>
</span></span>Create a method ChangeVisibility to change the certain Thumbnail button's visible and enable status based on the current selected index in the imageListView.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Change the certain Thumbnail button's visible and enable status
' based on the current selected index in the imageListView
Private Sub ChangeVisibility(ByVal btn As ThumbnailToolbarButton, _
���������������������������� ByVal show As Boolean, _
���������������������������� ByVal task As ButtonTask)
��� If Not btn Is Nothing Then


����� ��' Update the button's UI status
������� btn.Visible = show
������� btn.IsInteractive = show


������� ' Change the certain button enable status based on the 
��������' selected index of the imageListView
������� Select Case task


����������� ' The First and Previous Thumbnail toolbar button 
������������' is enabled if the first image in the 
������������' imageListView is not selected
����������� Case ButtonTask.FirstButton
��������������� btn.Enabled = Not imageListView.Items(0).Selected
�� ���������Case ButtonTask.PreviousButton
��������������� btn.Enabled = Not imageListView.Items(0).Selected
��������������� ' The Last and Next Thumbnail toolbar button 
����������������' is enabled if the last image in the 
����������������' imageListView is not selected
����������� Case ButtonTask.LastButton
��������������� btn.Enabled = Not imageListView.Items(imageListView. _
����������������������������������������������������� Items.Count - 1). _
����������������������������������������������������� Selected
����������� Case ButtonTask.NextButton
��������������� btn.Enabled = Not imageListView.Items(imageListView. _
����������������������������������������������������� Items.Count - 1). _
����������������������������������������������������� Selected
�� �����End Select
��� End If
End Sub

</pre>
<pre id="codePreview" class="vb">
' Change the certain Thumbnail button's visible and enable status
' based on the current selected index in the imageListView
Private Sub ChangeVisibility(ByVal btn As ThumbnailToolbarButton, _
���������������������������� ByVal show As Boolean, _
���������������������������� ByVal task As ButtonTask)
��� If Not btn Is Nothing Then


����� ��' Update the button's UI status
������� btn.Visible = show
������� btn.IsInteractive = show


������� ' Change the certain button enable status based on the 
��������' selected index of the imageListView
������� Select Case task


����������� ' The First and Previous Thumbnail toolbar button 
������������' is enabled if the first image in the 
������������' imageListView is not selected
����������� Case ButtonTask.FirstButton
��������������� btn.Enabled = Not imageListView.Items(0).Selected
�� ���������Case ButtonTask.PreviousButton
��������������� btn.Enabled = Not imageListView.Items(0).Selected
��������������� ' The Last and Next Thumbnail toolbar button 
����������������' is enabled if the last image in the 
����������������' imageListView is not selected
����������� Case ButtonTask.LastButton
��������������� btn.Enabled = Not imageListView.Items(imageListView. _
����������������������������������������������������� Items.Count - 1). _
����������������������������������������������������� Selected
����������� Case ButtonTask.NextButton
��������������� btn.Enabled = Not imageListView.Items(imageListView. _
����������������������������������������������������� Items.Count - 1). _
����������������������������������������������������� Selected
�� �����End Select
��� End If
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.75in"></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.75in; text-indent:-.25in">
<span style=""><span style="">5.<span style="font:7.0pt &quot;Times New Roman&quot;"> </span>
</span></span>Create a method ShowList to update the selected index when the certain Thumbnail toolbar button is clicked.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Update the selected index when the certain Thumbnail toolbar 
' button is clicked
Private Sub ShowList(ByVal newIndex As Integer)


��� ' Check whether the selected index is valid
��� If newIndex &lt; 0 Or newIndex &gt; imageListView.Items.Count - 1 Then
������� Return
��� End If


��� ' Update the selected index and focus the imageListView
��� imageListView.Items(newIndex).Selected = True
��� imageListView.Focus()
End Sub

</pre>
<pre id="codePreview" class="vb">
' Update the selected index when the certain Thumbnail toolbar 
' button is clicked
Private Sub ShowList(ByVal newIndex As Integer)


��� ' Check whether the selected index is valid
��� If newIndex &lt; 0 Or newIndex &gt; imageListView.Items.Count - 1 Then
������� Return
��� End If


��� ' Update the selected index and focus the imageListView
��� imageListView.Items(newIndex).Selected = True
��� imageListView.Focus()
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.75in"></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<span style=""><span style="">6.<span style="font:7.0pt &quot;Times New Roman&quot;"> </span>
</span></span>Create event handlers for Thumbnail toolbar buttons First, Previous, Next, and Last.</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.75in; text-indent:-.25in">
<span style=""><span style="">7.<span style="font:7.0pt &quot;Times New Roman&quot;"> </span>
</span></span>Create imageListView selected index changed event handler to retrieve images from Resource based on the selected index of the imageListView.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Show different image in the imagePictureBox based on the 
' selected index of the imageListView
Private Sub imageListView_SelectedIndexChanged(ByVal sender As� _
���������������������������������������������� System.Object, _
���������������������������������������������� ByVal e As System.EventArgs) _
���������������������������������������������� Handles imageListView. _
���������������������������������������������� SelectedIndexChanged
��� If imageListView.SelectedItems.Count &gt; 0 Then
������� Dim image As Image


������� ' Retrieve the image from the Resource according to the 
��������' selected index of the imageListView
������� Select Case imageListView.SelectedItems(0).ImageIndex
����������� Case 0
��������������� image = My.Resources.C
����������� Case 1
��������������� image = My.Resources.O
����������� Case 2
��������������� image = My.Resources.D
����������� Case Else
��������������� image = My.Resources.E
������� End Select


������� ' Update the image in the imagePictureBox
������� imagePictureBox.Image = image


������� ' Update the visible and enable status of the Thumbnail
������� ' toolbar buttons
������� UpdateButtons()
��� End If
End Sub

</pre>
<pre id="codePreview" class="vb">
' Show different image in the imagePictureBox based on the 
' selected index of the imageListView
Private Sub imageListView_SelectedIndexChanged(ByVal sender As� _
���������������������������������������������� System.Object, _
���������������������������������������������� ByVal e As System.EventArgs) _
���������������������������������������������� Handles imageListView. _
���������������������������������������������� SelectedIndexChanged
��� If imageListView.SelectedItems.Count &gt; 0 Then
������� Dim image As Image


������� ' Retrieve the image from the Resource according to the 
��������' selected index of the imageListView
������� Select Case imageListView.SelectedItems(0).ImageIndex
����������� Case 0
��������������� image = My.Resources.C
����������� Case 1
��������������� image = My.Resources.O
����������� Case 2
��������������� image = My.Resources.D
����������� Case Else
��������������� image = My.Resources.E
������� End Select


������� ' Update the image in the imagePictureBox
������� imagePictureBox.Image = image


������� ' Update the visible and enable status of the Thumbnail
������� ' toolbar buttons
������� UpdateButtons()
��� End If
End Sub

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

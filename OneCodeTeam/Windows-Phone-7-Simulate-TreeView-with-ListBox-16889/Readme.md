# Windows Phone 7 Simulate TreeView with ListBox (VBWP7ListAsTree)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows Phone 7
## Topics
* Simulate TreeView with ListBox
## IsPublished
* True
## ModifiedDate
* 2012-05-23 07:55:27
## Description

<h1>Windows Phone 7 Sample<span style=""> (VB</span>WP7ListAsTree)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how<span style=""> to</span> use ListBox Control as a tree in Windows Phone. All pictures in media library will show in ListBox Control with indention<span style="">.
</span></p>
<h2>Building the Sample</h2>
<p class="MsoNormal">Prerequisite: Visual Studio 2010 with Windows phone SDK 7.1.</p>
<p class="MsoNormal">You can get start by checking this link: <br>
<a href="http://create.msdn.com/en-us/home/getting_started">http://create.msdn.com/en-us/home/getting_started</a></p>
<h2>Running the Sample</h2>
<p class="MsoNormal" style="">To run the sample: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><br>
1. Open the project in Visual Studio 2010.<br>
2. Press Ctrl&#43;F5.</p>
<p class="MsoNormal" style="">The result would look like this:<br>
<span style=""><img src="/site/view/file/57740/1/image.png" alt="" width="328" height="531" align="middle">
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">1. Create a new ��Silverlight for Windows Phone�� project.</p>
<p class="MsoNormal">2. Add Reference to Microsoft.Xna.Framework.</p>
<p class="MsoNormal">3. Open MainPage.xaml file and replace its layout Grid with the following code:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;Grid x:Name=&quot;LayoutRoot&quot;&gt;
    &lt;!--TitlePanel contains the name of the application and page title--&gt;
    &lt;StackPanel x:Name=&quot;TitlePanel&quot; Grid.Row=&quot;0&quot; Margin=&quot;12,17,0,28&quot;&gt;
        &lt;TextBlock x:Name=&quot;ApplicationTitle&quot; Text=&quot;Pictures in Media Library&quot; Style=&quot;{StaticResource PhoneTextNormalStyle}&quot;/&gt;
    &lt;/StackPanel&gt;


    &lt;!--ContentPanel - place additional content here--&gt;
    &lt;Grid x:Name=&quot;ContentPanel&quot; Grid.Row=&quot;1&quot; Margin=&quot;12,50,12,0&quot;
          Background=&quot;Transparent&quot;&gt;
        &lt;ListBox x:Name=&quot;treeList&quot;&gt;


        &lt;/ListBox&gt;
    &lt;/Grid&gt;
&lt;/Grid&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;Grid x:Name=&quot;LayoutRoot&quot;&gt;
    &lt;!--TitlePanel contains the name of the application and page title--&gt;
    &lt;StackPanel x:Name=&quot;TitlePanel&quot; Grid.Row=&quot;0&quot; Margin=&quot;12,17,0,28&quot;&gt;
        &lt;TextBlock x:Name=&quot;ApplicationTitle&quot; Text=&quot;Pictures in Media Library&quot; Style=&quot;{StaticResource PhoneTextNormalStyle}&quot;/&gt;
    &lt;/StackPanel&gt;


    &lt;!--ContentPanel - place additional content here--&gt;
    &lt;Grid x:Name=&quot;ContentPanel&quot; Grid.Row=&quot;1&quot; Margin=&quot;12,50,12,0&quot;
          Background=&quot;Transparent&quot;&gt;
        &lt;ListBox x:Name=&quot;treeList&quot;&gt;


        &lt;/ListBox&gt;
    &lt;/Grid&gt;
&lt;/Grid&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">4. Open MainPage.xaml.<span style="">vb</span> file, alter its code like so:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Imports Microsoft.Xna.Framework.Media
Imports System.IO
Imports System.Windows.Media.Imaging


Partial Public Class MainPage
    Inherits PhoneApplicationPage
    ' Constructor
    Public Sub New()
        InitializeComponent()
        Using library = New MediaLibrary()
            ShowAlbum(library.RootPictureAlbum, &quot;|&quot;)
        End Using
    End Sub


    ' Show album pictures as a tree
    Private Sub ShowAlbum(theAlbum As PictureAlbum, indention As String)
        ' Show Album Name
        treeList.Items.Add(String.Concat(indention, &quot;Album: &quot;, theAlbum.Name))


        ' List Albums in this Album
        For Each subAlbum As PictureAlbum In theAlbum.Albums
            ShowAlbum(subAlbum, String.Concat(indention, &quot;-&quot;))
        Next


        ' List Pictures
        For Each thePicture As Picture In theAlbum.Pictures
            ' Get the Picture Stream
            Dim imageStream As Stream = thePicture.GetThumbnail()


            ' Wrap it with a BitmapImage object
            Dim bitmap = New BitmapImage()
            bitmap.SetSource(imageStream)


            ' Create an Image element and set the bitmap
            Dim image = New Image()
            image.Width = 60
            image.Height = 60
            image.Source = bitmap


            Dim outPanel As New StackPanel()
            Dim stackPanel As New StackPanel()
            stackPanel.Orientation = System.Windows.Controls.Orientation.Horizontal
            Dim textBlock As New TextBlock()
            textBlock.Text = thePicture.Name


            stackPanel.Children.Add(image)
            stackPanel.Children.Add(textBlock)


            outPanel.Orientation = System.Windows.Controls.Orientation.Horizontal
            Dim indentionBlock As New TextBlock()
            indentionBlock.Text = String.Concat(indention, &quot;-&quot;)
            outPanel.Children.Add(indentionBlock)
            outPanel.Children.Add(stackPanel)


            treeList.Items.Add(outPanel)
        Next
    End Sub
End Class

</pre>
<pre id="codePreview" class="vb">
Imports Microsoft.Xna.Framework.Media
Imports System.IO
Imports System.Windows.Media.Imaging


Partial Public Class MainPage
    Inherits PhoneApplicationPage
    ' Constructor
    Public Sub New()
        InitializeComponent()
        Using library = New MediaLibrary()
            ShowAlbum(library.RootPictureAlbum, &quot;|&quot;)
        End Using
    End Sub


    ' Show album pictures as a tree
    Private Sub ShowAlbum(theAlbum As PictureAlbum, indention As String)
        ' Show Album Name
        treeList.Items.Add(String.Concat(indention, &quot;Album: &quot;, theAlbum.Name))


        ' List Albums in this Album
        For Each subAlbum As PictureAlbum In theAlbum.Albums
            ShowAlbum(subAlbum, String.Concat(indention, &quot;-&quot;))
        Next


        ' List Pictures
        For Each thePicture As Picture In theAlbum.Pictures
            ' Get the Picture Stream
            Dim imageStream As Stream = thePicture.GetThumbnail()


            ' Wrap it with a BitmapImage object
            Dim bitmap = New BitmapImage()
            bitmap.SetSource(imageStream)


            ' Create an Image element and set the bitmap
            Dim image = New Image()
            image.Width = 60
            image.Height = 60
            image.Source = bitmap


            Dim outPanel As New StackPanel()
            Dim stackPanel As New StackPanel()
            stackPanel.Orientation = System.Windows.Controls.Orientation.Horizontal
            Dim textBlock As New TextBlock()
            textBlock.Text = thePicture.Name


            stackPanel.Children.Add(image)
            stackPanel.Children.Add(textBlock)


            outPanel.Orientation = System.Windows.Controls.Orientation.Horizontal
            Dim indentionBlock As New TextBlock()
            indentionBlock.Text = String.Concat(indention, &quot;-&quot;)
            outPanel.Children.Add(indentionBlock)
            outPanel.Children.Add(stackPanel)


            treeList.Items.Add(outPanel)
        Next
    End Sub
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoNormal">For more info about MediaLibrary class , please see this link:<br>
<a href="http://msdn.microsoft.com/en-us/library/microsoft.xna.framework.media.medialibrary.aspx">http://msdn.microsoft.com/en-us/library/microsoft.xna.framework.media.medialibrary.aspx</a></p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

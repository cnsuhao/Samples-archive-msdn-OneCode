# Windows Phone 7 Simulate TreeView with ListBox (CSWP7ListAsTree)
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
* 2012-05-23 08:26:46
## Description

<h1>Windows Phone 7 Sample<span style=""> &lt;</span>CSWP7ListAsTree<span style="">&gt;
</span></h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how<span style=""> to</span> use <span class="SpellE">
ListBox</span> Control as a tree in Windows Phone. All pictures in media library will show in
<span class="SpellE">ListBox</span> Control with indention<span style="">. </span>
</p>
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
<span style=""><img src="/site/view/file/57744/1/image.png" alt="" width="328" height="531" align="middle">
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
<p class="MsoNormal">4. Open MainPage.xaml.cs file, alter its code like so:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework.Media;
using System.IO;
using System.Windows.Media.Imaging;


namespace CSWP7ListAsTree
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            using (var library = new MediaLibrary())
            {
                ShowAlbum(library.RootPictureAlbum, &quot;|&quot;);
            }
        }


        //Show album pictures as a tree
        void ShowAlbum(PictureAlbum theAlbum, string indention)
        {
            // Show Album Name
            treeList.Items.Add(string.Concat(indention, &quot;Album: &quot;, theAlbum.Name));


            // List Albums in this Album
            foreach (PictureAlbum subAlbum in theAlbum.Albums)
            {
                ShowAlbum(subAlbum, string.Concat(indention, &quot;-&quot;));
            }


            // List Pictures
            foreach (Picture thePicture in theAlbum.Pictures)
            {
                // Get the Picture Stream
                Stream imageStream = thePicture.GetThumbnail();
                // Wrap it with a BitmapImage object
                var bitmap = new BitmapImage();
                bitmap.SetSource(imageStream);
                // Create an Image element and set the bitmap
                var image = new Image();
                image.Width = 60;
                image.Height = 60;
                image.Source = bitmap;


                StackPanel outPanel = new StackPanel();
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = System.Windows.Controls.Orientation.Horizontal;
                TextBlock textBlock = new TextBlock();
                textBlock.Text = thePicture.Name;


                stackPanel.Children.Add(image);
                stackPanel.Children.Add(textBlock);


                outPanel.Orientation = System.Windows.Controls.Orientation.Horizontal;
                TextBlock indentionBlock = new TextBlock();
                indentionBlock.Text = string.Concat(indention, &quot;-&quot;);
                outPanel.Children.Add(indentionBlock);
                outPanel.Children.Add(stackPanel);


                treeList.Items.Add(outPanel);
            }
        }
    }
}

</pre>
<pre id="codePreview" class="csharp">
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework.Media;
using System.IO;
using System.Windows.Media.Imaging;


namespace CSWP7ListAsTree
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            using (var library = new MediaLibrary())
            {
                ShowAlbum(library.RootPictureAlbum, &quot;|&quot;);
            }
        }


        //Show album pictures as a tree
        void ShowAlbum(PictureAlbum theAlbum, string indention)
        {
            // Show Album Name
            treeList.Items.Add(string.Concat(indention, &quot;Album: &quot;, theAlbum.Name));


            // List Albums in this Album
            foreach (PictureAlbum subAlbum in theAlbum.Albums)
            {
                ShowAlbum(subAlbum, string.Concat(indention, &quot;-&quot;));
            }


            // List Pictures
            foreach (Picture thePicture in theAlbum.Pictures)
            {
                // Get the Picture Stream
                Stream imageStream = thePicture.GetThumbnail();
                // Wrap it with a BitmapImage object
                var bitmap = new BitmapImage();
                bitmap.SetSource(imageStream);
                // Create an Image element and set the bitmap
                var image = new Image();
                image.Width = 60;
                image.Height = 60;
                image.Source = bitmap;


                StackPanel outPanel = new StackPanel();
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = System.Windows.Controls.Orientation.Horizontal;
                TextBlock textBlock = new TextBlock();
                textBlock.Text = thePicture.Name;


                stackPanel.Children.Add(image);
                stackPanel.Children.Add(textBlock);


                outPanel.Orientation = System.Windows.Controls.Orientation.Horizontal;
                TextBlock indentionBlock = new TextBlock();
                indentionBlock.Text = string.Concat(indention, &quot;-&quot;);
                outPanel.Children.Add(indentionBlock);
                outPanel.Children.Add(stackPanel);


                treeList.Items.Add(outPanel);
            }
        }
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoNormal">For more info about <span class="SpellE">MediaLibrary</span>
<span class="GramE">class ,</span> please see this link:<br>
<a href="http://msdn.microsoft.com/en-us/library/microsoft.xna.framework.media.medialibrary.aspx">http://msdn.microsoft.com/en-us/library/microsoft.xna.framework.media.medialibrary.aspx</a></p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

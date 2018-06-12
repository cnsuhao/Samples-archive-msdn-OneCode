# Windows Phone SkyDrive Note Sample (CSWP7SkydriveNote)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* Windows Phone 7
## Topics
* Windows Phone 7
## IsPublished
* True
## ModifiedDate
* 2012-05-28 08:21:08
## Description

<h1>Windows Phone SkyDrive Note Sample (CSWP7SkydriveNote)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates two features:</p>
<p class="MsoNormal" style="margin-left:36.0pt">1. A Windows Phone Notebook<br>
2. Uploading notes to SkyDrive. </p>
<p class="MsoNormal">CSWP7SkydriveNote project contains two pages: <span style="">
&nbsp;</span>MainPage.xaml shows the note list in a Listbox control,and MyNote.xaml is used for note editing. When the sample starts up, the following processes will occur:
</p>
<p class="MsoNormal" style="text-indent:36.0pt">1. Collect all note file name, <br>
<span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>2. Deserialize the xml contained in the note files into .net objects. <br>
<span style="">&nbsp;&nbsp;&nbsp; </span><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>3. Show note titles and creation datetime in the note list. </p>
<p class="MsoNormal">When you press a note in the list. The action will navigate page to the MyNote.xaml, so that you can edit and save it. By pressing the ��Connect�� button, you can save the note to SkyDrive.
</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">1. Visual Studio 2010 with Windows phone SDK 7.1.you can get start by checking this link:
<a href="http://create.msdn.com/en-us/home/getting_started">http://create.msdn.com/en-us/home/getting_started</a></p>
<p class="MsoNormal">2. Download and install the&nbsp;<a href="http://go.microsoft.com/fwlink/p/?LinkId=224535">Live SDK</a>, if you haven't already done so.<br>
<span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span>By default, the Live SDK is installed in the \Live\v5.0\ folder in \Program Files\Microsoft SDKs\ (on 32-bit computers) or \Program Files (x86)\Microsoft SDKs\ (on 64-bit computers).</p>
<p class="MsoNormal">3. Get a Live Client Id from <a href="http://manage.dev.live.com/">
here</a> and then open MyNote.xaml, replace ��ClientId�� property with your Id. </p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Press Ctrl&#43;F5 to run the sample in Windows Phone Emulator.
</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/57876/1/image.png" alt="" width="320" height="529" align="middle">
<span style="">&nbsp;</span> <img src="/site/view/file/57877/1/image.png" alt="" width="312" height="524" align="middle">
</span></p>
<p class="MsoNormal"><span style="">You can find the uploaded files in the Documents folder of your SkyDrive.
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">1. Create a new ��Silverlight for Windows Phone�� project.</p>
<p class="MsoNormal">2. Add Reference to <b style="">Microsoft.Live.Controls</b> and
<b style="">Microsoft.Live</b>.<br>
<span style="">&nbsp;&nbsp;&nbsp; </span>You can also copy these two dlls out from Live SDK installation folder; see also the ��Building the Sample�� part.
</p>
<p class="MsoNormal">3. <span style="">&nbsp;</span>Open MainPage.xaml file, replace layout gird xaml with the following code:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;Grid x:Name=&quot;LayoutRoot&quot; Background=&quot;Transparent&quot;&gt;
    &lt;Grid.RowDefinitions&gt;
        &lt;RowDefinition Height=&quot;Auto&quot;/&gt;
        &lt;RowDefinition Height=&quot;*&quot;/&gt;
    &lt;/Grid.RowDefinitions&gt;


    &lt;!--TitlePanel contains the name of the application and page title--&gt;
    &lt;StackPanel x:Name=&quot;TitlePanel&quot; Grid.Row=&quot;0&quot; Margin=&quot;12,17,0,28&quot; Orientation=&quot;Horizontal&quot;&gt;
        &lt;TextBlock x:Name=&quot;ApplicationTitle&quot; Text=&quot;SkyDrive NoteBook&quot; Style=&quot;{StaticResource PhoneTextNormalStyle}&quot;/&gt;
        &lt;TextBlock x:Name=&quot;PageTitle&quot; Text=&quot;Note List&quot; Style=&quot;{StaticResource PhoneTextNormalStyle}&quot;/&gt;
    &lt;/StackPanel&gt;


    &lt;!--ContentPanel - place additional content here--&gt;
    &lt;Grid x:Name=&quot;ContentPanel&quot; Grid.Row=&quot;1&quot; Margin=&quot;0,0,0,0&quot;&gt;
        &lt;ListBox x:Name=&quot;listBox_NoteList&quot; 
                 ItemsSource=&quot;StaticResource noteList&quot;
                 Margin=&quot;0,0,0,60&quot;
                 BorderThickness=&quot;1&quot; Hold=&quot;listBox_NoteList_Hold&quot; Tap=&quot;listBox_NoteList_Tap&quot;&gt;
            &lt;ListBox.ItemTemplate&gt;
                &lt;DataTemplate&gt;
                    &lt;StackPanel Orientation=&quot;Vertical&quot; Margin=&quot;0,5,0,0&quot;
                                Background=&quot;DarkRed&quot;  Width=&quot;450&quot;&gt;
                        &lt;TextBlock Text=&quot;{Binding Title}&quot;&gt;&lt;/TextBlock&gt;
                        &lt;TextBlock Text=&quot;{Binding LastEditTime}&quot;&gt;&lt;/TextBlock&gt;
                    &lt;/StackPanel&gt;
                &lt;/DataTemplate&gt;
            &lt;/ListBox.ItemTemplate&gt;
        &lt;/ListBox&gt;
        &lt;Button x:Name=&quot;btn_NewNote&quot; Content=&quot;New Note&quot; Margin=&quot;0,620,0,0&quot; 
                Background=&quot;DarkRed&quot; BorderThickness=&quot;0&quot;
                Click=&quot;btn_NewNote_Click&quot;&gt;&lt;/Button&gt;
    &lt;/Grid&gt;
&lt;/Grid&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;Grid x:Name=&quot;LayoutRoot&quot; Background=&quot;Transparent&quot;&gt;
    &lt;Grid.RowDefinitions&gt;
        &lt;RowDefinition Height=&quot;Auto&quot;/&gt;
        &lt;RowDefinition Height=&quot;*&quot;/&gt;
    &lt;/Grid.RowDefinitions&gt;


    &lt;!--TitlePanel contains the name of the application and page title--&gt;
    &lt;StackPanel x:Name=&quot;TitlePanel&quot; Grid.Row=&quot;0&quot; Margin=&quot;12,17,0,28&quot; Orientation=&quot;Horizontal&quot;&gt;
        &lt;TextBlock x:Name=&quot;ApplicationTitle&quot; Text=&quot;SkyDrive NoteBook&quot; Style=&quot;{StaticResource PhoneTextNormalStyle}&quot;/&gt;
        &lt;TextBlock x:Name=&quot;PageTitle&quot; Text=&quot;Note List&quot; Style=&quot;{StaticResource PhoneTextNormalStyle}&quot;/&gt;
    &lt;/StackPanel&gt;


    &lt;!--ContentPanel - place additional content here--&gt;
    &lt;Grid x:Name=&quot;ContentPanel&quot; Grid.Row=&quot;1&quot; Margin=&quot;0,0,0,0&quot;&gt;
        &lt;ListBox x:Name=&quot;listBox_NoteList&quot; 
                 ItemsSource=&quot;StaticResource noteList&quot;
                 Margin=&quot;0,0,0,60&quot;
                 BorderThickness=&quot;1&quot; Hold=&quot;listBox_NoteList_Hold&quot; Tap=&quot;listBox_NoteList_Tap&quot;&gt;
            &lt;ListBox.ItemTemplate&gt;
                &lt;DataTemplate&gt;
                    &lt;StackPanel Orientation=&quot;Vertical&quot; Margin=&quot;0,5,0,0&quot;
                                Background=&quot;DarkRed&quot;  Width=&quot;450&quot;&gt;
                        &lt;TextBlock Text=&quot;{Binding Title}&quot;&gt;&lt;/TextBlock&gt;
                        &lt;TextBlock Text=&quot;{Binding LastEditTime}&quot;&gt;&lt;/TextBlock&gt;
                    &lt;/StackPanel&gt;
                &lt;/DataTemplate&gt;
            &lt;/ListBox.ItemTemplate&gt;
        &lt;/ListBox&gt;
        &lt;Button x:Name=&quot;btn_NewNote&quot; Content=&quot;New Note&quot; Margin=&quot;0,620,0,0&quot; 
                Background=&quot;DarkRed&quot; BorderThickness=&quot;0&quot;
                Click=&quot;btn_NewNote_Click&quot;&gt;&lt;/Button&gt;
    &lt;/Grid&gt;
&lt;/Grid&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">4.Open MainPage.xaml.cs file and replace code with the following:</p>
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


using System.IO.IsolatedStorage;
using System.Xml.Serialization;
using System.IO;


namespace CSWP7SkydriveNote
{
    public partial class MainPage : PhoneApplicationPage
    {
        public static List&lt;Note&gt; CreateTestList()
        {
            List&lt;Note&gt; list = new List&lt;Note&gt;();
            Note note = new Note();


            //Get files from isolated store.
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
            XmlSerializer serializer = new XmlSerializer(typeof(Note));
            var filesName = store.GetFileNames();
            if (filesName.Length &gt; 0)
            {
                foreach (string fileName in filesName)
                {
                    if (fileName == &quot;__ApplicationSettings&quot;) continue;
                    using (var file = store.OpenFile(fileName, FileMode.Open))
                    {
                        note = (Note)serializer.Deserialize(file);
                        list.Add(note);
                    }
                }
            }


            store.Dispose();
            return list;
        }


        public MainPage()
        {
            InitializeComponent();
        }


        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            listBox_NoteList.ItemsSource = CreateTestList();
        }


        private void listBox_NoteList_Hold(object sender, GestureEventArgs e)
        {
            //Get item data.
            FrameworkElement element = (FrameworkElement)e.OriginalSource;
            Note item = (Note)element.DataContext;
            //Get element data.
            ListBox listBox = sender as ListBox;
            var selectedItem = listBox.SelectedItem;


            MessageBox.Show(item.Title);
        }


        private void listBox_NoteList_Tap(object sender, GestureEventArgs e)
        {
            //Get item data
            FrameworkElement element = (FrameworkElement)e.OriginalSource;
            Note item = (Note)element.DataContext;
            if (item == null)
            {
                return;
            }


            string urlWithData = string.Format(&quot;/MyNote.xaml?NoteId={0}&quot;, item.NoteID);
            NavigationService.Navigate(new Uri(urlWithData, UriKind.Relative));
        }


        private void btn_NewNote_Click(object sender, RoutedEventArgs e)
        {
            //Navigate to MyNote.xaml page
            NavigationService.Navigate(new Uri(&quot;/MyNote.xaml&quot;, UriKind.Relative));
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


using System.IO.IsolatedStorage;
using System.Xml.Serialization;
using System.IO;


namespace CSWP7SkydriveNote
{
    public partial class MainPage : PhoneApplicationPage
    {
        public static List&lt;Note&gt; CreateTestList()
        {
            List&lt;Note&gt; list = new List&lt;Note&gt;();
            Note note = new Note();


            //Get files from isolated store.
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
            XmlSerializer serializer = new XmlSerializer(typeof(Note));
            var filesName = store.GetFileNames();
            if (filesName.Length &gt; 0)
            {
                foreach (string fileName in filesName)
                {
                    if (fileName == &quot;__ApplicationSettings&quot;) continue;
                    using (var file = store.OpenFile(fileName, FileMode.Open))
                    {
                        note = (Note)serializer.Deserialize(file);
                        list.Add(note);
                    }
                }
            }


            store.Dispose();
            return list;
        }


        public MainPage()
        {
            InitializeComponent();
        }


        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            listBox_NoteList.ItemsSource = CreateTestList();
        }


        private void listBox_NoteList_Hold(object sender, GestureEventArgs e)
        {
            //Get item data.
            FrameworkElement element = (FrameworkElement)e.OriginalSource;
            Note item = (Note)element.DataContext;
            //Get element data.
            ListBox listBox = sender as ListBox;
            var selectedItem = listBox.SelectedItem;


            MessageBox.Show(item.Title);
        }


        private void listBox_NoteList_Tap(object sender, GestureEventArgs e)
        {
            //Get item data
            FrameworkElement element = (FrameworkElement)e.OriginalSource;
            Note item = (Note)element.DataContext;
            if (item == null)
            {
                return;
            }


            string urlWithData = string.Format(&quot;/MyNote.xaml?NoteId={0}&quot;, item.NoteID);
            NavigationService.Navigate(new Uri(urlWithData, UriKind.Relative));
        }


        private void btn_NewNote_Click(object sender, RoutedEventArgs e)
        {
            //Navigate to MyNote.xaml page
            NavigationService.Navigate(new Uri(&quot;/MyNote.xaml&quot;, UriKind.Relative));
        }
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">5. Create a new ��Windows Phone Portrait Page�� page, name it ��MyNote.xaml��, and fill the file with the following code. Next, replace ��<span style="color:blue">your client id here</span>�� with your own Client Id.
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;phone:PhoneApplicationPage 
    x:Class=&quot;CSWP7SkydriveNote.MyNote&quot;
    xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
    xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
    xmlns:phone=&quot;clr-namespace:Microsoft.Phone.Controls;assembly=Microsoft.Phone&quot;
    xmlns:shell=&quot;clr-namespace:Microsoft.Phone.Shell;assembly=Microsoft.Phone&quot;
    xmlns:d=&quot;http://schemas.microsoft.com/expression/blend/2008&quot;
    xmlns:mc=&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;
    FontFamily=&quot;{StaticResource PhoneFontFamilyNormal}&quot;
    FontSize=&quot;{StaticResource PhoneFontSizeNormal}&quot;
    Foreground=&quot;{StaticResource PhoneForegroundBrush}&quot;
    SupportedOrientations=&quot;Portrait&quot; Orientation=&quot;Portrait&quot;
    mc:Ignorable=&quot;d&quot; d:DesignHeight=&quot;768&quot; d:DesignWidth=&quot;480&quot;
    shell:SystemTray.IsVisible=&quot;True&quot;
    xmlns:live=&quot;clr-namespace:Microsoft.Live.Controls;assembly=Microsoft.Live.Controls&quot;
    &gt;


    &lt;!--LayoutRoot is the root grid where all page content is placed--&gt;
    &lt;Grid x:Name=&quot;LayoutRoot&quot; Background=&quot;Transparent&quot;&gt;
        &lt;!--TitlePanel contains the name of the application and page title--&gt;
        &lt;StackPanel x:Name=&quot;TitlePanel&quot; Grid.Row=&quot;0&quot; Margin=&quot;12,17,0,28&quot; Orientation=&quot;Horizontal&quot;&gt;
            &lt;TextBlock x:Name=&quot;ApplicationTitle&quot; Text=&quot;MY NoteBook&quot; Style=&quot;{StaticResource PhoneTextNormalStyle}&quot;/&gt;
            &lt;TextBlock x:Name=&quot;PageTile&quot; Text=&quot;Editing&quot; Style=&quot;{StaticResource PhoneTextNormalStyle}&quot;/&gt;
        &lt;/StackPanel&gt;


        &lt;Button x:Name=&quot;btn_Save&quot; Margin=&quot;0,40,240,670&quot; Height=&quot;70&quot; Content=&quot;Save&quot; 
                Background=&quot;DarkRed&quot; BorderThickness=&quot;0&quot;
                Click=&quot;btn_Save_Click&quot;&gt;&lt;/Button&gt;
        &lt;Button x:Name=&quot;btn_Delete&quot; Margin=&quot;240,40,0,670&quot; Height=&quot;70&quot; Content=&quot;Delete&quot; 
                Background=&quot;DarkRed&quot; BorderThickness=&quot;0&quot;
                Click=&quot;btn_Delete_Click&quot;&gt;&lt;/Button&gt;


        &lt;TextBlock Text=&quot;Title:&quot; Margin=&quot;12,120,420,610&quot;&gt;&lt;/TextBlock&gt;
        &lt;TextBox x:Name=&quot;txtBox_noteTitle&quot; Margin=&quot;50,105,0,590&quot; AcceptsReturn=&quot;False&quot;&gt;&lt;/TextBox&gt;
        &lt;TextBox x:Name=&quot;txtBox_Content&quot; Margin=&quot;0,160,0,50&quot; AcceptsReturn=&quot;True&quot;&gt;&lt;/TextBox&gt;
        &lt;live:SignInButton Name=&quot;btn_Upload&quot; ClientId=&quot;your client id here&quot; Margin=&quot;0,700,0,0&quot;
                           Scopes=&quot;wl.signin wl.basic wl.skydrive_update&quot; Branding=&quot;Skydrive&quot;
                           TextType=&quot;Connect&quot; SessionChanged=&quot;btn_Upload_SessionChanged&quot;
                           Background=&quot;DarkRed&quot; BorderThickness=&quot;0&quot;/&gt;
    &lt;/Grid&gt;
&lt;/phone:PhoneApplicationPage&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;phone:PhoneApplicationPage 
    x:Class=&quot;CSWP7SkydriveNote.MyNote&quot;
    xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
    xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
    xmlns:phone=&quot;clr-namespace:Microsoft.Phone.Controls;assembly=Microsoft.Phone&quot;
    xmlns:shell=&quot;clr-namespace:Microsoft.Phone.Shell;assembly=Microsoft.Phone&quot;
    xmlns:d=&quot;http://schemas.microsoft.com/expression/blend/2008&quot;
    xmlns:mc=&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;
    FontFamily=&quot;{StaticResource PhoneFontFamilyNormal}&quot;
    FontSize=&quot;{StaticResource PhoneFontSizeNormal}&quot;
    Foreground=&quot;{StaticResource PhoneForegroundBrush}&quot;
    SupportedOrientations=&quot;Portrait&quot; Orientation=&quot;Portrait&quot;
    mc:Ignorable=&quot;d&quot; d:DesignHeight=&quot;768&quot; d:DesignWidth=&quot;480&quot;
    shell:SystemTray.IsVisible=&quot;True&quot;
    xmlns:live=&quot;clr-namespace:Microsoft.Live.Controls;assembly=Microsoft.Live.Controls&quot;
    &gt;


    &lt;!--LayoutRoot is the root grid where all page content is placed--&gt;
    &lt;Grid x:Name=&quot;LayoutRoot&quot; Background=&quot;Transparent&quot;&gt;
        &lt;!--TitlePanel contains the name of the application and page title--&gt;
        &lt;StackPanel x:Name=&quot;TitlePanel&quot; Grid.Row=&quot;0&quot; Margin=&quot;12,17,0,28&quot; Orientation=&quot;Horizontal&quot;&gt;
            &lt;TextBlock x:Name=&quot;ApplicationTitle&quot; Text=&quot;MY NoteBook&quot; Style=&quot;{StaticResource PhoneTextNormalStyle}&quot;/&gt;
            &lt;TextBlock x:Name=&quot;PageTile&quot; Text=&quot;Editing&quot; Style=&quot;{StaticResource PhoneTextNormalStyle}&quot;/&gt;
        &lt;/StackPanel&gt;


        &lt;Button x:Name=&quot;btn_Save&quot; Margin=&quot;0,40,240,670&quot; Height=&quot;70&quot; Content=&quot;Save&quot; 
                Background=&quot;DarkRed&quot; BorderThickness=&quot;0&quot;
                Click=&quot;btn_Save_Click&quot;&gt;&lt;/Button&gt;
        &lt;Button x:Name=&quot;btn_Delete&quot; Margin=&quot;240,40,0,670&quot; Height=&quot;70&quot; Content=&quot;Delete&quot; 
                Background=&quot;DarkRed&quot; BorderThickness=&quot;0&quot;
                Click=&quot;btn_Delete_Click&quot;&gt;&lt;/Button&gt;


        &lt;TextBlock Text=&quot;Title:&quot; Margin=&quot;12,120,420,610&quot;&gt;&lt;/TextBlock&gt;
        &lt;TextBox x:Name=&quot;txtBox_noteTitle&quot; Margin=&quot;50,105,0,590&quot; AcceptsReturn=&quot;False&quot;&gt;&lt;/TextBox&gt;
        &lt;TextBox x:Name=&quot;txtBox_Content&quot; Margin=&quot;0,160,0,50&quot; AcceptsReturn=&quot;True&quot;&gt;&lt;/TextBox&gt;
        &lt;live:SignInButton Name=&quot;btn_Upload&quot; ClientId=&quot;your client id here&quot; Margin=&quot;0,700,0,0&quot;
                           Scopes=&quot;wl.signin wl.basic wl.skydrive_update&quot; Branding=&quot;Skydrive&quot;
                           TextType=&quot;Connect&quot; SessionChanged=&quot;btn_Upload_SessionChanged&quot;
                           Background=&quot;DarkRed&quot; BorderThickness=&quot;0&quot;/&gt;
    &lt;/Grid&gt;
&lt;/phone:PhoneApplicationPage&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<a name="OLE_LINK1"><span style="">your client id here</span></a>
<p class="MsoNormal">6. Open MyNote.xaml.cs file, replace code with the following:</p>
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


using System.IO.IsolatedStorage;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Live;


namespace CSWP7SkydriveNote
{
    public partial class MyNote : PhoneApplicationPage
    {
        Note note;


        //The isDeleteNote field is used to identify if the navigation action
        //is caused by delete, if yes, then, the note will not be saved. 
        bool isDeleteNote = false;
        string fileName;
        string noteId;


        private LiveConnectClient client;
        private LiveConnectSession session;


        public MyNote()
        {
            InitializeComponent();
            isDeleteNote = false;
        }


        /// &lt;summary&gt;
        /// Called when this page becomes the active page. 
        /// &lt;/summary&gt;
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ShowNote();
            isDeleteNote = false;
        }


        /// &lt;summary&gt;
        /// Called just before navigating away from this page. 
        /// &lt;/summary&gt;
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            NavigationService.Navigate(new Uri(&quot;/MainPage.xaml&quot;, UriKind.Relative));
        }


        /// &lt;summary&gt;
        /// Called when page is navigating away. 
        /// &lt;/summary&gt;
        protected override void OnNavigatingFrom(System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            if (isDeleteNote) return;
            SaveNote();
        }


        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (isDeleteNote) return;
            SaveNote();
        }


        private void CreateNewNote()
        {
            note = new Note();
            note.NoteID = Guid.NewGuid();
            note.Title = txtBox_noteTitle.Text;
            note.Content = txtBox_Content.Text;
            note.CreatedDate = DateTime.Now;
            note.LastEditTime = DateTime.Now;


            noteId = note.NoteID.ToString();


            //serialize to xml and store into file
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
            using (var file = store.CreateFile(note.NoteID &#43; &quot;.txt&quot;))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Note));
                serializer.Serialize(file, note);
            }
            store.Dispose();
        }


        private void ShowNote()
        {
            //Get the page id
            if (this.NavigationContext.QueryString.Count &lt; 1)
            {
                CreateNewNote();
                return;
            }
            noteId = this.NavigationContext.QueryString[&quot;NoteId&quot;].ToString();
            fileName = noteId &#43; &quot;.txt&quot;;


            //Deserialized the note base on the id. 
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
            XmlSerializer serializer = new XmlSerializer(typeof(Note));
            using (var file = store.OpenFile(fileName, FileMode.Open))
            {
                note = (Note)serializer.Deserialize(file);
            }


            txtBox_noteTitle.Text = note.Title;
            txtBox_Content.Text = note.Content;


            store.Dispose();
        }
        
        private void SaveNote()
        {
            fileName = noteId &#43; &quot;.txt&quot;;
            note.NoteID = new Guid(noteId);
            note.Title = txtBox_noteTitle.Text;
            note.Content = txtBox_Content.Text;
            note.CreatedDate = DateTime.Now;
            note.LastEditTime = DateTime.Now;


            //serialize to xml and store into file
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
            using (var file = store.CreateFile(note.NoteID &#43; &quot;.txt&quot;))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Note));
                serializer.Serialize(file, note);
            }
            store.Dispose();
        }


        private void DeleteNote()
        {
            string idString = noteId;
            fileName = idString &#43; &quot;.txt&quot;;
            using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (store.FileExists(fileName))
                {
                    store.DeleteFile(fileName);
                }
            }


            isDeleteNote = true;
            NavigationService.Navigate(new Uri(&quot;/MainPage.xaml&quot;, UriKind.Relative));
        }


        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteNote();
        }


        private void btn_Upload_SessionChanged(object sender, Microsoft.Live.Controls.LiveConnectSessionChangedEventArgs e)
        {
            if (isDeleteNote) return;
            SaveNote();


            if (e.Status == LiveConnectSessionStatus.Connected)
            {
                session = e.Session;
                client = new LiveConnectClient(session);
                Dispatcher.BeginInvoke(() =&gt; {
                    MessageBox.Show(&quot;Connected&quot;);
                });


                client = new LiveConnectClient(session);


                //Get files from isolated store
                IsolatedStorageFile store = 
                    IsolatedStorageFile.GetUserStoreForApplication();
                IsolatedStorageFileStream fileStream =
                    store.OpenFile(fileName, FileMode.Open);


                //Upload files to document folder by friendly name.
                client.UploadCompleted &#43;= (obj, arg) =&gt;
                {
                    if (arg.Error == null)
                    {
                        IDictionary&lt;string, object&gt; fileInfo = arg.Result;
                        string fileId = fileInfo[&quot;id&quot;].ToString();
                        Dispatcher.BeginInvoke(() =&gt;
                        {
                            MessageBox.Show(fileId);
                        });
                    }
                    else
                    {
                        string errorMessage = &quot;Error calling API: &quot; &#43; arg.Error.Message;
                        Dispatcher.BeginInvoke(() =&gt;
                        {
                            MessageBox.Show(errorMessage);
                        });
                    }
                };


                client.UploadAsync(&quot;me/skydrive/my_documents&quot;, fileName, fileStream);
            }


            if (e.Error != null)
            {
                Dispatcher.BeginInvoke(() =&gt; {
                    MessageBox.Show(e.Error.Message);
                });
            }
        }
    }


    public class Note
    {
        public Guid NoteID { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public DateTime LastEditTime { get; set; }
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


using System.IO.IsolatedStorage;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Live;


namespace CSWP7SkydriveNote
{
    public partial class MyNote : PhoneApplicationPage
    {
        Note note;


        //The isDeleteNote field is used to identify if the navigation action
        //is caused by delete, if yes, then, the note will not be saved. 
        bool isDeleteNote = false;
        string fileName;
        string noteId;


        private LiveConnectClient client;
        private LiveConnectSession session;


        public MyNote()
        {
            InitializeComponent();
            isDeleteNote = false;
        }


        /// &lt;summary&gt;
        /// Called when this page becomes the active page. 
        /// &lt;/summary&gt;
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ShowNote();
            isDeleteNote = false;
        }


        /// &lt;summary&gt;
        /// Called just before navigating away from this page. 
        /// &lt;/summary&gt;
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            NavigationService.Navigate(new Uri(&quot;/MainPage.xaml&quot;, UriKind.Relative));
        }


        /// &lt;summary&gt;
        /// Called when page is navigating away. 
        /// &lt;/summary&gt;
        protected override void OnNavigatingFrom(System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            if (isDeleteNote) return;
            SaveNote();
        }


        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (isDeleteNote) return;
            SaveNote();
        }


        private void CreateNewNote()
        {
            note = new Note();
            note.NoteID = Guid.NewGuid();
            note.Title = txtBox_noteTitle.Text;
            note.Content = txtBox_Content.Text;
            note.CreatedDate = DateTime.Now;
            note.LastEditTime = DateTime.Now;


            noteId = note.NoteID.ToString();


            //serialize to xml and store into file
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
            using (var file = store.CreateFile(note.NoteID &#43; &quot;.txt&quot;))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Note));
                serializer.Serialize(file, note);
            }
            store.Dispose();
        }


        private void ShowNote()
        {
            //Get the page id
            if (this.NavigationContext.QueryString.Count &lt; 1)
            {
                CreateNewNote();
                return;
            }
            noteId = this.NavigationContext.QueryString[&quot;NoteId&quot;].ToString();
            fileName = noteId &#43; &quot;.txt&quot;;


            //Deserialized the note base on the id. 
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
            XmlSerializer serializer = new XmlSerializer(typeof(Note));
            using (var file = store.OpenFile(fileName, FileMode.Open))
            {
                note = (Note)serializer.Deserialize(file);
            }


            txtBox_noteTitle.Text = note.Title;
            txtBox_Content.Text = note.Content;


            store.Dispose();
        }
        
        private void SaveNote()
        {
            fileName = noteId &#43; &quot;.txt&quot;;
            note.NoteID = new Guid(noteId);
            note.Title = txtBox_noteTitle.Text;
            note.Content = txtBox_Content.Text;
            note.CreatedDate = DateTime.Now;
            note.LastEditTime = DateTime.Now;


            //serialize to xml and store into file
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
            using (var file = store.CreateFile(note.NoteID &#43; &quot;.txt&quot;))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Note));
                serializer.Serialize(file, note);
            }
            store.Dispose();
        }


        private void DeleteNote()
        {
            string idString = noteId;
            fileName = idString &#43; &quot;.txt&quot;;
            using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (store.FileExists(fileName))
                {
                    store.DeleteFile(fileName);
                }
            }


            isDeleteNote = true;
            NavigationService.Navigate(new Uri(&quot;/MainPage.xaml&quot;, UriKind.Relative));
        }


        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteNote();
        }


        private void btn_Upload_SessionChanged(object sender, Microsoft.Live.Controls.LiveConnectSessionChangedEventArgs e)
        {
            if (isDeleteNote) return;
            SaveNote();


            if (e.Status == LiveConnectSessionStatus.Connected)
            {
                session = e.Session;
                client = new LiveConnectClient(session);
                Dispatcher.BeginInvoke(() =&gt; {
                    MessageBox.Show(&quot;Connected&quot;);
                });


                client = new LiveConnectClient(session);


                //Get files from isolated store
                IsolatedStorageFile store = 
                    IsolatedStorageFile.GetUserStoreForApplication();
                IsolatedStorageFileStream fileStream =
                    store.OpenFile(fileName, FileMode.Open);


                //Upload files to document folder by friendly name.
                client.UploadCompleted &#43;= (obj, arg) =&gt;
                {
                    if (arg.Error == null)
                    {
                        IDictionary&lt;string, object&gt; fileInfo = arg.Result;
                        string fileId = fileInfo[&quot;id&quot;].ToString();
                        Dispatcher.BeginInvoke(() =&gt;
                        {
                            MessageBox.Show(fileId);
                        });
                    }
                    else
                    {
                        string errorMessage = &quot;Error calling API: &quot; &#43; arg.Error.Message;
                        Dispatcher.BeginInvoke(() =&gt;
                        {
                            MessageBox.Show(errorMessage);
                        });
                    }
                };


                client.UploadAsync(&quot;me/skydrive/my_documents&quot;, fileName, fileStream);
            }


            if (e.Error != null)
            {
                Dispatcher.BeginInvoke(() =&gt; {
                    MessageBox.Show(e.Error.Message);
                });
            }
        }
    }


    public class Note
    {
        public Guid NoteID { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public DateTime LastEditTime { get; set; }
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoNormal">For more information about SkyDrive development, see<span class="GramE">:</span><br>
<a href="http://msdn.microsoft.com/en-us/live/">http://msdn.microsoft.com/en-us/live/</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

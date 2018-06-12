# Windows Phone SkyDrive Note Sample (VBWP7SkydriveNote)
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
* 2012-06-24 11:25:10
## Description

<h1>Windows Phone SkyDrive Note Sample (<span style="">VB</span>WP7SkydriveNote)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates two features:</p>
<p class="MsoNormal" style="margin-left:36.0pt">1. A Windows Phone Notebook<br>
2. Uploading notes to SkyDrive. </p>
<p class="MsoNormal">CSWP7SkydriveNote project contains two pages:<span style="">&nbsp;
</span>MainPage.xaml shows the note list in a Listbox control,and MyNote.xaml is used for note editing. When the sample starts up, the following processes will occur:
</p>
<p class="MsoNormal" style="text-indent:36.0pt">1. Collect all note file name, <br>
<span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>2. Deserialize the xml contained in the note files into .net objects. <br>
<span style="">&nbsp;&nbsp;&nbsp; </span><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>3. Show note titles and creation datetime in the note list. </p>
<p class="MsoNormal">When you press a note in the list. The action will navigate page to the MyNote.xaml, so that you can edit and save it. By pressing the &quot;Connect&quot; button, you can save the note to SkyDrive.
</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">1. Visual Studio 2010 with Windows phone SDK 7.1.you can get start by checking this link:
<a href="http://create.msdn.com/en-us/home/getting_started">http://create.msdn.com/en-us/home/getting_started</a></p>
<p class="MsoNormal">2. Download and install the&nbsp;<a href="http://go.microsoft.com/fwlink/p/?LinkId=224535">Live SDK</a>, if you haven't already done so.<br>
<span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span>By default, the Live SDK is installed in the \Live\v5.0\ folder in \Program Files\Microsoft SDKs\ (on 32-bit computers) or \Program Files (x86)\Microsoft SDKs\ (on 64-bit computers).</p>
<p class="MsoNormal">3. Get a Live Client Id from <a href="http://manage.dev.live.com/">
here</a> and then open MyNote.xaml, replace &quot;ClientId&quot; property with your Id.
</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Press Ctrl&#43;F5 to run the sample in Windows Phone Emulator.
</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/60166/1/image.png" alt="" width="320" height="529" align="middle">
<span style="">&nbsp;</span> <img src="/site/view/file/60167/1/image.png" alt="" width="312" height="524" align="middle">
</span></p>
<p class="MsoNormal"><span style="">You can find the uploaded files in the Documents folder of your SkyDrive.
</span></p>
<h2>Using the Code</h2>
<p class="MsoNormal">1. Create a new &quot;Silverlight for Windows Phone&quot; project.</p>
<p class="MsoNormal">2. Add Reference to <b style="">Microsoft.Live.Controls</b> and
<b style="">Microsoft.Live</b>.<br>
<span style="">&nbsp;&nbsp;&nbsp; </span>You can also copy these two dlls out from Live SDK installation folder; see also the &quot;Building the Sample&quot; part.
</p>
<p class="MsoNormal">3.<span style="">&nbsp; </span>Open MainPage.xaml file, replace layout gird xaml with the following code:</p>
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
<p class="MsoNormal" style="">4.Open MainPage.xaml.<span style="">vb</span> file and replace code with the following:<span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports Microsoft.Phone.Controls


Imports System.IO.IsolatedStorage
Imports System.Xml.Serialization
Imports System.IO




Partial Public Class MainPage
    Inherits PhoneApplicationPage


    Public Shared Function CreateTestList() As List(Of Note)
        Dim list As New List(Of Note)()
        Dim note As New Note()


        'Get files from isolated store.
        Dim store As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
        Dim serializer As New XmlSerializer(GetType(Note))
        Dim filesName = store.GetFileNames()
        If filesName.Length &gt; 0 Then
            For Each fileName As String In filesName
                If fileName = &quot;__ApplicationSettings&quot; Then
                    Continue For
                End If
                Using file = store.OpenFile(fileName, FileMode.Open)
                    note = DirectCast(serializer.Deserialize(file), Note)
                    list.Add(note)
                End Using
            Next
        End If


        store.Dispose()
        Return list
    End Function


    ' Constructor
    Public Sub New()
        InitializeComponent()
    End Sub


    Protected Overrides Sub OnNavigatedTo(e As System.Windows.Navigation.NavigationEventArgs)
        MyBase.OnNavigatedTo(e)
        listBox_NoteList.ItemsSource = CreateTestList()
    End Sub


    Private Sub listBox_NoteList_Hold(sender As Object, e As GestureEventArgs)
        'Get item data.
        Dim element As FrameworkElement = DirectCast(e.OriginalSource, FrameworkElement)
        Dim item As Note = DirectCast(element.DataContext, Note)
        'Get element data.
        Dim listBox As ListBox = TryCast(sender, ListBox)
        Dim selectedItem = listBox.SelectedItem


        MessageBox.Show(item.Title)
    End Sub


    Private Sub listBox_NoteList_Tap(sender As Object, e As GestureEventArgs)
        'Get item data
        Dim element As FrameworkElement = DirectCast(e.OriginalSource, FrameworkElement)
        Dim item As Note = DirectCast(element.DataContext, Note)
        If item Is Nothing Then
            Return
        End If


        Dim urlWithData As String = String.Format(&quot;/MyNote.xaml?NoteId={0}&quot;, item.NoteID)
        NavigationService.Navigate(New Uri(urlWithData, UriKind.Relative))
    End Sub


    Private Sub btn_NewNote_Click(sender As Object, e As RoutedEventArgs)
        'Navigate to MyNote.xaml page
        NavigationService.Navigate(New Uri(&quot;/MyNote.xaml&quot;, UriKind.Relative))
    End Sub


End Class


Public Class Note
    Public Property NoteID() As Guid
        Get
            Return m_NoteID
        End Get
        Set(value As Guid)
            m_NoteID = Value
        End Set
    End Property
    Private m_NoteID As Guid
    Public Property Title() As String
        Get
            Return m_Title
        End Get
        Set(value As String)
            m_Title = Value
        End Set
    End Property
    Private m_Title As String
    Public Property CreatedDate() As DateTime
        Get
            Return m_CreatedDate
        End Get
        Set(value As DateTime)
            m_CreatedDate = Value
        End Set
    End Property
    Private m_CreatedDate As DateTime
    Public Property Content() As String
        Get
            Return m_Content
        End Get
        Set(value As String)
            m_Content = Value
        End Set
    End Property
    Private m_Content As String
    Public Property LastEditTime() As DateTime
        Get
            Return m_LastEditTime
        End Get
        Set(value As DateTime)
            m_LastEditTime = Value
        End Set
    End Property
    Private m_LastEditTime As DateTime
End Class

</pre>
<pre id="codePreview" class="vb">
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports Microsoft.Phone.Controls


Imports System.IO.IsolatedStorage
Imports System.Xml.Serialization
Imports System.IO




Partial Public Class MainPage
    Inherits PhoneApplicationPage


    Public Shared Function CreateTestList() As List(Of Note)
        Dim list As New List(Of Note)()
        Dim note As New Note()


        'Get files from isolated store.
        Dim store As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
        Dim serializer As New XmlSerializer(GetType(Note))
        Dim filesName = store.GetFileNames()
        If filesName.Length &gt; 0 Then
            For Each fileName As String In filesName
                If fileName = &quot;__ApplicationSettings&quot; Then
                    Continue For
                End If
                Using file = store.OpenFile(fileName, FileMode.Open)
                    note = DirectCast(serializer.Deserialize(file), Note)
                    list.Add(note)
                End Using
            Next
        End If


        store.Dispose()
        Return list
    End Function


    ' Constructor
    Public Sub New()
        InitializeComponent()
    End Sub


    Protected Overrides Sub OnNavigatedTo(e As System.Windows.Navigation.NavigationEventArgs)
        MyBase.OnNavigatedTo(e)
        listBox_NoteList.ItemsSource = CreateTestList()
    End Sub


    Private Sub listBox_NoteList_Hold(sender As Object, e As GestureEventArgs)
        'Get item data.
        Dim element As FrameworkElement = DirectCast(e.OriginalSource, FrameworkElement)
        Dim item As Note = DirectCast(element.DataContext, Note)
        'Get element data.
        Dim listBox As ListBox = TryCast(sender, ListBox)
        Dim selectedItem = listBox.SelectedItem


        MessageBox.Show(item.Title)
    End Sub


    Private Sub listBox_NoteList_Tap(sender As Object, e As GestureEventArgs)
        'Get item data
        Dim element As FrameworkElement = DirectCast(e.OriginalSource, FrameworkElement)
        Dim item As Note = DirectCast(element.DataContext, Note)
        If item Is Nothing Then
            Return
        End If


        Dim urlWithData As String = String.Format(&quot;/MyNote.xaml?NoteId={0}&quot;, item.NoteID)
        NavigationService.Navigate(New Uri(urlWithData, UriKind.Relative))
    End Sub


    Private Sub btn_NewNote_Click(sender As Object, e As RoutedEventArgs)
        'Navigate to MyNote.xaml page
        NavigationService.Navigate(New Uri(&quot;/MyNote.xaml&quot;, UriKind.Relative))
    End Sub


End Class


Public Class Note
    Public Property NoteID() As Guid
        Get
            Return m_NoteID
        End Get
        Set(value As Guid)
            m_NoteID = Value
        End Set
    End Property
    Private m_NoteID As Guid
    Public Property Title() As String
        Get
            Return m_Title
        End Get
        Set(value As String)
            m_Title = Value
        End Set
    End Property
    Private m_Title As String
    Public Property CreatedDate() As DateTime
        Get
            Return m_CreatedDate
        End Get
        Set(value As DateTime)
            m_CreatedDate = Value
        End Set
    End Property
    Private m_CreatedDate As DateTime
    Public Property Content() As String
        Get
            Return m_Content
        End Get
        Set(value As String)
            m_Content = Value
        End Set
    End Property
    Private m_Content As String
    Public Property LastEditTime() As DateTime
        Get
            Return m_LastEditTime
        End Get
        Set(value As DateTime)
            m_LastEditTime = Value
        End Set
    End Property
    Private m_LastEditTime As DateTime
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span style=""></span></p>
<p class="MsoNormal" style="">5. Create a new &quot;Windows Phone Portrait Page&quot; page, name it &quot;MyNote.xaml&quot;, and fill the file with the following code. Next, replace &quot;<span style="color:blue">your client id here</span>&quot; with your
 own Client Id. </p>
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
<a name="OLE_LINK2"><span style="">your client id here</span></a>
<p class="MsoNormal" style="">6. Open MyNote.xaml.<span style="">vb</span> file, replace code with the following:<span style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports Microsoft.Phone.Controls


Imports System.IO.IsolatedStorage
Imports System.Xml.Serialization
Imports System.IO
Imports Microsoft.Live




Partial Public Class MyNote
    Inherits PhoneApplicationPage
    Private note As Note


    'The isDeleteNote field is used to identify if the navigation action
    'is caused by delete, if yes, then, the note will not be saved. 
    Private isDeleteNote As Boolean = False
    Private fileName As String
    Private noteId As String


    Private client As LiveConnectClient
    Private session As LiveConnectSession


    Public Sub New()
        InitializeComponent()
        isDeleteNote = False
    End Sub


    ''' &lt;summary&gt;
    ''' Called when this page becomes the active page. 
    ''' &lt;/summary&gt;
    Protected Overrides Sub OnNavigatedTo(e As System.Windows.Navigation.NavigationEventArgs)
        MyBase.OnNavigatedTo(e)
        ShowNote()
        isDeleteNote = False
    End Sub


    ''' &lt;summary&gt;
    ''' Called just before navigating away from this page. 
    ''' &lt;/summary&gt;
    Protected Overrides Sub OnNavigatedFrom(e As System.Windows.Navigation.NavigationEventArgs)
        MyBase.OnNavigatedFrom(e)
        NavigationService.Navigate(New Uri(&quot;/MainPage.xaml&quot;, UriKind.Relative))
    End Sub


    ''' &lt;summary&gt;
    ''' Called when page is navigating away. 
    ''' &lt;/summary&gt;
    Protected Overrides Sub OnNavigatingFrom(e As System.Windows.Navigation.NavigatingCancelEventArgs)
        If isDeleteNote Then
            Return
        End If
        SaveNote()
    End Sub


    Private Sub btn_Save_Click(sender As Object, e As RoutedEventArgs)
        If isDeleteNote Then
            Return
        End If
        SaveNote()
    End Sub


    Private Sub CreateNewNote()
        note = New Note()
        note.NoteID = Guid.NewGuid()
        note.Title = txtBox_noteTitle.Text
        note.Content = txtBox_Content.Text
        note.CreatedDate = DateTime.Now
        note.LastEditTime = DateTime.Now


        noteId = note.NoteID.ToString()


        'serialize to xml and store into file
        Dim store As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
        Using file = store.CreateFile(Convert.ToString(note.NoteID) & &quot;.txt&quot;)
            Dim serializer As New XmlSerializer(GetType(Note))
            serializer.Serialize(file, note)
        End Using
        store.Dispose()
    End Sub


    Private Sub ShowNote()
        'Get the page id
        If Me.NavigationContext.QueryString.Count &lt; 1 Then
            CreateNewNote()
            Return
        End If
        noteId = Me.NavigationContext.QueryString(&quot;NoteId&quot;).ToString()
        fileName = noteId & &quot;.txt&quot;


        'Deserialized the note base on the id. 
        Dim store As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
        Dim serializer As New XmlSerializer(GetType(Note))
        Using file = store.OpenFile(fileName, FileMode.Open)
            note = DirectCast(serializer.Deserialize(file), Note)
        End Using


        txtBox_noteTitle.Text = note.Title
        txtBox_Content.Text = note.Content


        store.Dispose()
    End Sub


    Private Sub SaveNote()
        fileName = noteId & &quot;.txt&quot;
        note.NoteID = New Guid(noteId)
        note.Title = txtBox_noteTitle.Text
        note.Content = txtBox_Content.Text
        note.CreatedDate = DateTime.Now
        note.LastEditTime = DateTime.Now


        'serialize to xml and store into file
        Dim store As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
        Using file = store.CreateFile(Convert.ToString(note.NoteID) & &quot;.txt&quot;)
            Dim serializer As New XmlSerializer(GetType(Note))
            serializer.Serialize(file, note)
        End Using
        store.Dispose()
    End Sub


    Private Sub DeleteNote()
        Dim idString As String = noteId
        fileName = idString & &quot;.txt&quot;
        Using store As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
            If store.FileExists(fileName) Then
                store.DeleteFile(fileName)
            End If
        End Using


        isDeleteNote = True
        NavigationService.Navigate(New Uri(&quot;/MainPage.xaml&quot;, UriKind.Relative))
    End Sub


    Private Sub btn_Delete_Click(sender As Object, e As RoutedEventArgs)
        DeleteNote()
    End Sub


    Private Sub btn_Upload_SessionChanged(sender As Object, e As Microsoft.Live.Controls.LiveConnectSessionChangedEventArgs)
        If isDeleteNote Then
            Return
        End If
        SaveNote()


        If e.Status = LiveConnectSessionStatus.Connected Then
            session = e.Session
            client = New LiveConnectClient(session)
            Dispatcher.BeginInvoke(Function()
                                       MessageBox.Show(&quot;Connected&quot;)
                                   End Function)


            client = New LiveConnectClient(session)


            'Get files from isolated store
            Dim store As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
            Dim fileStream As IsolatedStorageFileStream = store.OpenFile(fileName, FileMode.Open)


            'Upload files to document folder by friendly name.
            AddHandler client.UploadCompleted, AddressOf UploadCompleted


            client.UploadAsync(&quot;me/skydrive/my_documents&quot;, fileName, fileStream)
        End If


        If e.[Error] IsNot Nothing Then
            Dispatcher.BeginInvoke(Function()
                                       MessageBox.Show(e.[Error].Message)
                                   End Function)
        End If
    End Sub


    Private Sub UploadCompleted(sender As Object, e As Microsoft.Live.LiveOperationCompletedEventArgs)
        If e.[Error] Is Nothing Then
            Dim fileInfo As IDictionary(Of String, Object) = e.Result
            Dim fileId As String = fileInfo(&quot;id&quot;).ToString()
            Dispatcher.BeginInvoke(Function()
                                       MessageBox.Show(fileId)
                                   End Function)
        Else
            Dim errorMessage As String = &quot;Error calling API: &quot; & Convert.ToString(e.[Error].Message)
            Dispatcher.BeginInvoke(Function()
                                       MessageBox.Show(errorMessage)
                                   End Function)
        End If
    End Sub


End Class

</pre>
<pre id="codePreview" class="vb">
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports Microsoft.Phone.Controls


Imports System.IO.IsolatedStorage
Imports System.Xml.Serialization
Imports System.IO
Imports Microsoft.Live




Partial Public Class MyNote
    Inherits PhoneApplicationPage
    Private note As Note


    'The isDeleteNote field is used to identify if the navigation action
    'is caused by delete, if yes, then, the note will not be saved. 
    Private isDeleteNote As Boolean = False
    Private fileName As String
    Private noteId As String


    Private client As LiveConnectClient
    Private session As LiveConnectSession


    Public Sub New()
        InitializeComponent()
        isDeleteNote = False
    End Sub


    ''' &lt;summary&gt;
    ''' Called when this page becomes the active page. 
    ''' &lt;/summary&gt;
    Protected Overrides Sub OnNavigatedTo(e As System.Windows.Navigation.NavigationEventArgs)
        MyBase.OnNavigatedTo(e)
        ShowNote()
        isDeleteNote = False
    End Sub


    ''' &lt;summary&gt;
    ''' Called just before navigating away from this page. 
    ''' &lt;/summary&gt;
    Protected Overrides Sub OnNavigatedFrom(e As System.Windows.Navigation.NavigationEventArgs)
        MyBase.OnNavigatedFrom(e)
        NavigationService.Navigate(New Uri(&quot;/MainPage.xaml&quot;, UriKind.Relative))
    End Sub


    ''' &lt;summary&gt;
    ''' Called when page is navigating away. 
    ''' &lt;/summary&gt;
    Protected Overrides Sub OnNavigatingFrom(e As System.Windows.Navigation.NavigatingCancelEventArgs)
        If isDeleteNote Then
            Return
        End If
        SaveNote()
    End Sub


    Private Sub btn_Save_Click(sender As Object, e As RoutedEventArgs)
        If isDeleteNote Then
            Return
        End If
        SaveNote()
    End Sub


    Private Sub CreateNewNote()
        note = New Note()
        note.NoteID = Guid.NewGuid()
        note.Title = txtBox_noteTitle.Text
        note.Content = txtBox_Content.Text
        note.CreatedDate = DateTime.Now
        note.LastEditTime = DateTime.Now


        noteId = note.NoteID.ToString()


        'serialize to xml and store into file
        Dim store As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
        Using file = store.CreateFile(Convert.ToString(note.NoteID) & &quot;.txt&quot;)
            Dim serializer As New XmlSerializer(GetType(Note))
            serializer.Serialize(file, note)
        End Using
        store.Dispose()
    End Sub


    Private Sub ShowNote()
        'Get the page id
        If Me.NavigationContext.QueryString.Count &lt; 1 Then
            CreateNewNote()
            Return
        End If
        noteId = Me.NavigationContext.QueryString(&quot;NoteId&quot;).ToString()
        fileName = noteId & &quot;.txt&quot;


        'Deserialized the note base on the id. 
        Dim store As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
        Dim serializer As New XmlSerializer(GetType(Note))
        Using file = store.OpenFile(fileName, FileMode.Open)
            note = DirectCast(serializer.Deserialize(file), Note)
        End Using


        txtBox_noteTitle.Text = note.Title
        txtBox_Content.Text = note.Content


        store.Dispose()
    End Sub


    Private Sub SaveNote()
        fileName = noteId & &quot;.txt&quot;
        note.NoteID = New Guid(noteId)
        note.Title = txtBox_noteTitle.Text
        note.Content = txtBox_Content.Text
        note.CreatedDate = DateTime.Now
        note.LastEditTime = DateTime.Now


        'serialize to xml and store into file
        Dim store As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
        Using file = store.CreateFile(Convert.ToString(note.NoteID) & &quot;.txt&quot;)
            Dim serializer As New XmlSerializer(GetType(Note))
            serializer.Serialize(file, note)
        End Using
        store.Dispose()
    End Sub


    Private Sub DeleteNote()
        Dim idString As String = noteId
        fileName = idString & &quot;.txt&quot;
        Using store As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
            If store.FileExists(fileName) Then
                store.DeleteFile(fileName)
            End If
        End Using


        isDeleteNote = True
        NavigationService.Navigate(New Uri(&quot;/MainPage.xaml&quot;, UriKind.Relative))
    End Sub


    Private Sub btn_Delete_Click(sender As Object, e As RoutedEventArgs)
        DeleteNote()
    End Sub


    Private Sub btn_Upload_SessionChanged(sender As Object, e As Microsoft.Live.Controls.LiveConnectSessionChangedEventArgs)
        If isDeleteNote Then
            Return
        End If
        SaveNote()


        If e.Status = LiveConnectSessionStatus.Connected Then
            session = e.Session
            client = New LiveConnectClient(session)
            Dispatcher.BeginInvoke(Function()
                                       MessageBox.Show(&quot;Connected&quot;)
                                   End Function)


            client = New LiveConnectClient(session)


            'Get files from isolated store
            Dim store As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication()
            Dim fileStream As IsolatedStorageFileStream = store.OpenFile(fileName, FileMode.Open)


            'Upload files to document folder by friendly name.
            AddHandler client.UploadCompleted, AddressOf UploadCompleted


            client.UploadAsync(&quot;me/skydrive/my_documents&quot;, fileName, fileStream)
        End If


        If e.[Error] IsNot Nothing Then
            Dispatcher.BeginInvoke(Function()
                                       MessageBox.Show(e.[Error].Message)
                                   End Function)
        End If
    End Sub


    Private Sub UploadCompleted(sender As Object, e As Microsoft.Live.LiveOperationCompletedEventArgs)
        If e.[Error] Is Nothing Then
            Dim fileInfo As IDictionary(Of String, Object) = e.Result
            Dim fileId As String = fileInfo(&quot;id&quot;).ToString()
            Dispatcher.BeginInvoke(Function()
                                       MessageBox.Show(fileId)
                                   End Function)
        Else
            Dim errorMessage As String = &quot;Error calling API: &quot; & Convert.ToString(e.[Error].Message)
            Dispatcher.BeginInvoke(Function()
                                       MessageBox.Show(errorMessage)
                                   End Function)
        End If
    End Sub


End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style=""><span style=""></span></p>
<p class="MsoNormal" style="">For more information about SkyDrive development, see:<br>
<a href="http://msdn.microsoft.com/en-us/live/">http://msdn.microsoft.com/en-us/live/</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

# Accesse Item's Index when Databind
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Windows Phone
* Windows Phone 8
* Windows Phone Development
## Topics
* DataBinding
* Index
* DataTemplate
## IsPublished
* True
## ModifiedDate
* 2013-07-05 02:35:00
## Description

<h1>How to access the index of an item in the ItemsControl's DataTemplate when data binding (VBWP8AccessItemIndex)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample will show how to access and use the index of an ItemsControl. You will use the
<b style="">VisualTreeHelper.GetParent</b> method to retrieve the parent element and then use the
<b style="">ItemContainerGenerator.IndexFromContainer</b> method.<span style="">&nbsp;
</span>Additionally, you will use the IndexOf method to retrieve the index.</p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">Step 1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Open VBWP8AccessItemIndex.sln.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">Step 2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press Ctrl &#43; F5. The emulator looks as follows:</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/91777/1/image.png" alt="" width="311" height="285" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">Step 3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Modify the visibility of the StackPanel</p>
<p class="MsoListParagraphCxSpLast">Before modification:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;Grid x:Name=&quot;LayoutRoot&quot;&nbsp; Margin=&quot;0,0,0,81&quot; &gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;StackPanel Visibility=&quot;Collapsed&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;views:DataView1 x:Name=&quot;ItemView1&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/StackPanel&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;StackPanel Visibility=&quot;Visible&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;views:DataView2 x:Name=&quot;ItemView2&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/StackPanel&gt;
&nbsp;&nbsp;&nbsp; &lt;/Grid&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;Grid x:Name=&quot;LayoutRoot&quot;&nbsp; Margin=&quot;0,0,0,81&quot; &gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;StackPanel Visibility=&quot;Collapsed&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;views:DataView1 x:Name=&quot;ItemView1&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/StackPanel&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;StackPanel Visibility=&quot;Visible&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;views:DataView2 x:Name=&quot;ItemView2&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/StackPanel&gt;
&nbsp;&nbsp;&nbsp; &lt;/Grid&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph">After modification:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;Grid x:Name=&quot;LayoutRoot&quot;&nbsp; Margin=&quot;0,0,0,81&quot; &gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;StackPanel Visibility=&quot;Visible&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;views:DataView1 x:Name=&quot;ItemView1&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/StackPanel&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;StackPanel Visibility=&quot;Collapsed&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;views:DataView2 x:Name=&quot;ItemView2&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/StackPanel&gt;
&nbsp;&nbsp;&nbsp; &lt;/Grid&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;Grid x:Name=&quot;LayoutRoot&quot;&nbsp; Margin=&quot;0,0,0,81&quot; &gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;StackPanel Visibility=&quot;Visible&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;views:DataView1 x:Name=&quot;ItemView1&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/StackPanel&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;StackPanel Visibility=&quot;Collapsed&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;views:DataView2 x:Name=&quot;ItemView2&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/StackPanel&gt;
&nbsp;&nbsp;&nbsp; &lt;/Grid&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">Step 4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Close and reopen the emulator. The emulator looks as follows:</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/91778/1/image.png" alt="" width="292" height="423" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle">Tap one item of the ItemControl on the emulator. For example, tap the fifth data item.The emulator looks as follows:</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/91779/1/image.png" alt="" width="288" height="419" align="middle">
</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">Step 5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>The validation is complete.</p>
<h2>Using the Code</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">Step 1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create a Visual Basic &quot;Windows Phone App&quot; in Visual Studio 2012 or Visual Studio Express 2012 for Windows Phone. Name the app &quot;VBWP8AccessItemIndex.&quot;</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">Step 2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Follow these steps to add three folders to the root directory of the project:
</p>
<p class="MsoListParagraphCxSpMiddle">In <b style="">Solution Explorer</b>, right-click the project, point to
<b style="">Add</b> and then click <b style="">New Folder</b>.</p>
<p class="MsoListParagraphCxSpMiddle">Type &quot;Models,&quot; &quot;Views&quot; and &quot;ViewModels&quot; as the name of each folder.</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">Step 3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Add a class in the Models folder as the data model, and name the model UserData. The UserData class implements the
<b style="">INotifyPropertyChanged</b> interface and the <b style="">PropertyChanged</b> event. This enables the class to notify its views when a property value changes, and then the views can update the UI based on the changes.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Class UserData
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Implements INotifyPropertyChanged


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Constructor
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Public Sub New(i As Integer)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.Index = i
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.Name = &quot;Name&quot; & (Me.Index &#43; 1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.Age = i &#43; 5
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Sub


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' id
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Private _index As Integer
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Public Property Index() As Integer
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return _index
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set(value As Integer)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _index = value
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RaisePropertyChanged(&quot;Index&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Property


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' name
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Private _name As String
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Public Property Name() As String
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return _name
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set(value As String)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _name = value
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RaisePropertyChanged(&quot;Name&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Property


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' age
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Private _age As Integer
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Public Property Age() As Integer
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return _age
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set(value As Integer)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _age = value
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RaisePropertyChanged(&quot;Age&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Property


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Background Brush
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Public Property BackgroundBrush() As SolidColorBrush
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim index As Integer = App.ViewModel.UserDatas.IndexOf(Me)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim backgroundColor As Color = If((index Mod 2 = 0), Colors.Gray, Colors.Blue)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return New SolidColorBrush(backgroundColor)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set(value As SolidColorBrush)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Property


&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;' PropertyChangedEventHandler
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Protected Sub RaisePropertyChanged(propertyName As String)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;Dim e = New PropertyChangedEventArgs(propertyName)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RaiseEvent PropertyChanged(Me, e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Catch ex As Exception
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MessageBox.Show(ex.Message)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Sub
&nbsp; End Class

</pre>
<pre id="codePreview" class="vb">
Public Class UserData
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Implements INotifyPropertyChanged


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Constructor
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Public Sub New(i As Integer)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.Index = i
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.Name = &quot;Name&quot; & (Me.Index &#43; 1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.Age = i &#43; 5
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Sub


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' id
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Private _index As Integer
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Public Property Index() As Integer
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return _index
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set(value As Integer)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _index = value
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RaisePropertyChanged(&quot;Index&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Property


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' name
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Private _name As String
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Public Property Name() As String
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return _name
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set(value As String)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _name = value
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RaisePropertyChanged(&quot;Name&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Property


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' age
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Private _age As Integer
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Public Property Age() As Integer
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return _age
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set(value As Integer)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _age = value
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RaisePropertyChanged(&quot;Age&quot;)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Property


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Background Brush
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Public Property BackgroundBrush() As SolidColorBrush
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim index As Integer = App.ViewModel.UserDatas.IndexOf(Me)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim backgroundColor As Color = If((index Mod 2 = 0), Colors.Gray, Colors.Blue)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return New SolidColorBrush(backgroundColor)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set(value As SolidColorBrush)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Property


&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;' PropertyChangedEventHandler
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Protected Sub RaisePropertyChanged(propertyName As String)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;Dim e = New PropertyChangedEventArgs(propertyName)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RaiseEvent PropertyChanged(Me, e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Catch ex As Exception
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MessageBox.Show(ex.Message)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Sub
&nbsp; End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">Step 4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Add a class to the ViewModels folder as the ViewModel, name it &quot;ViewModel.&quot; The ViewModel class will declare a dynamic data collection by using
<b style="">ObservableCollection</b> (Of T) and will contain the code to retrieve the collection of UserDatas.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Sub New()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Instantiated
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.UserDatas = New ObservableCollection(Of UserData)()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Insert test data.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UserDatas.Add(New UserData(8))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UserDatas.Add(New UserData(6))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;UserDatas.Add(New UserData(2))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UserDatas.Add(New UserData(3))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UserDatas.Add(New UserData(4))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UserDatas.Add(New UserData(5))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UserDatas.Add(New UserData(9))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UserDatas.Add(New UserData(7))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UserDatas.Add(New UserData(1))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UserDatas.Add(New UserData(10))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UserDatas.Add(New UserData(12))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UserDatas.Add(New UserData(13))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Sub


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Collection of UserData
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Private _userDatas As ObservableCollection(Of UserData)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Public Property UserDatas() As ObservableCollection(Of UserData)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return _userDatas
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set(value As ObservableCollection(Of UserData))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _userDatas = value
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Property



</pre>
<pre id="codePreview" class="vb">
Public Sub New()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Instantiated
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.UserDatas = New ObservableCollection(Of UserData)()


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Insert test data.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UserDatas.Add(New UserData(8))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UserDatas.Add(New UserData(6))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;UserDatas.Add(New UserData(2))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UserDatas.Add(New UserData(3))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UserDatas.Add(New UserData(4))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UserDatas.Add(New UserData(5))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UserDatas.Add(New UserData(9))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UserDatas.Add(New UserData(7))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UserDatas.Add(New UserData(1))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UserDatas.Add(New UserData(10))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UserDatas.Add(New UserData(12))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UserDatas.Add(New UserData(13))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Sub


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Collection of UserData
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Private _userDatas As ObservableCollection(Of UserData)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Public Property UserDatas() As ObservableCollection(Of UserData)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return _userDatas
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set(value As ObservableCollection(Of UserData))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _userDatas = value
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Set
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Property



</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">Step 5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Add a help class to the project and name it &quot;Utilities.&quot; This can be used to traverse the Visual Tree and retrieve the FrameworkElement's index in ItemsControl.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
&nbsp;&nbsp; ''' Finds the parent.
&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;element&quot;&gt;The element to start with.&lt;/param&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;filter&quot;&gt;The filter criteria.&lt;/param&gt;
&nbsp;&nbsp; ''' &lt;returns&gt;&lt;/returns&gt;
&nbsp;&nbsp; &lt;System.Runtime.CompilerServices.Extension&gt; _
&nbsp;&nbsp; Public Function FindParent(element As DependencyObject, filter As Func(Of DependencyObject, Boolean)) As DependencyObject
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim parent As DependencyObject = VisualTreeHelper.GetParent(element)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If parent IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If filter(parent) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return parent
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return FindParent(parent, filter)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return Nothing
&nbsp;&nbsp; End Function


&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp; ''' Get index of the UIElement by using IndexFromContainer
&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;element&quot;&gt;FrameworkElement&lt;/param&gt;
&nbsp;&nbsp; ''' &lt;returns&gt;index&lt;/returns&gt;
&nbsp;&nbsp; ''' &lt;remarks&gt;&lt;/remarks&gt;
&nbsp;&nbsp; Public Function GetIndexOfUIElement(element As FrameworkElement) As Integer
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim intIndex As Integer
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim parent As ItemsControl = TryCast(element.FindParent(Function(x) TypeOf x Is ItemsControl), ItemsControl)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If parent IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim container As DependencyObject = parent.ItemContainerGenerator.ContainerFromItem(element.DataContext)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If container IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; intIndex = parent.ItemContainerGenerator.IndexFromContainer(container)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Return intIndex
&nbsp;&nbsp; End Function

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
&nbsp;&nbsp; ''' Finds the parent.
&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;element&quot;&gt;The element to start with.&lt;/param&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;filter&quot;&gt;The filter criteria.&lt;/param&gt;
&nbsp;&nbsp; ''' &lt;returns&gt;&lt;/returns&gt;
&nbsp;&nbsp; &lt;System.Runtime.CompilerServices.Extension&gt; _
&nbsp;&nbsp; Public Function FindParent(element As DependencyObject, filter As Func(Of DependencyObject, Boolean)) As DependencyObject
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim parent As DependencyObject = VisualTreeHelper.GetParent(element)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If parent IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If filter(parent) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return parent
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return FindParent(parent, filter)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return Nothing
&nbsp;&nbsp; End Function


&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp; ''' Get index of the UIElement by using IndexFromContainer
&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp; ''' &lt;param name=&quot;element&quot;&gt;FrameworkElement&lt;/param&gt;
&nbsp;&nbsp; ''' &lt;returns&gt;index&lt;/returns&gt;
&nbsp;&nbsp; ''' &lt;remarks&gt;&lt;/remarks&gt;
&nbsp;&nbsp; Public Function GetIndexOfUIElement(element As FrameworkElement) As Integer
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim intIndex As Integer
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim parent As ItemsControl = TryCast(element.FindParent(Function(x) TypeOf x Is ItemsControl), ItemsControl)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If parent IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim container As DependencyObject = parent.ItemContainerGenerator.ContainerFromItem(element.DataContext)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If container IsNot Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; intIndex = parent.ItemContainerGenerator.IndexFromContainer(container)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Return intIndex
&nbsp;&nbsp; End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">Step 6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Add a class to the project and name it &quot;AlternatingRowBackgroundConverter.&quot;</p>
<p class="MsoListParagraphCxSpMiddle">This class can be used to alternate the background of a row. The AlternatingRowBackgroundConverter class implements the
<b style="">IValueConverter</b> interface, and implements the <b style="">Convert</b> and
<b style="">ConvertBack</b> methods.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">Step 7.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Follow these steps to add two views to the Views folder to display the data:</p>
<p class="MsoListParagraphCxSpMiddle">In <b style="">Solution Explorer</b>, right-click the folder View, point to
<b style="">Add</b> and then click <b style="">New Item</b>. In the list of file types, click
<b style="">Windows Phone User Control</b>.</p>
<p class="MsoListParagraphCxSpMiddle">Type &quot;DataView1&quot; and &quot;DataView2&quot; as the name of each view.</p>
<p class="MsoListParagraphCxSpLast">DataView1 will show how to use the custom Converter to alternate the background of the rows. DataView2 will show how to use the
<b style="">IndexOf</b>() method to retrieve the item's index then use the index to alternate the background of the rows. It does not require a converter. We will display the views on a page and connect them to the ViewModel by setting its data context later.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Class AlternatingRowBackgroundConverter
&nbsp;&nbsp;&nbsp; Implements IValueConverter
&nbsp;&nbsp;&nbsp; ' Normal Brush
&nbsp;&nbsp;&nbsp; Public Property NormalBrush() As Brush
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return m_NormalBrush
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set(value As Brush)
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_NormalBrush = value
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Set
&nbsp;&nbsp;&nbsp; End Property
&nbsp;&nbsp;&nbsp; Private m_NormalBrush As Brush


&nbsp;&nbsp;&nbsp; ' Alternate Brush
&nbsp;&nbsp;&nbsp; Public Property AlternateBrush() As Brush
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return m_AlternateBrush
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set(value As Brush)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_AlternateBrush = value
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Set
&nbsp;&nbsp;&nbsp; End Property
&nbsp;&nbsp;&nbsp; Private m_AlternateBrush As Brush


&nbsp;&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; ''' Deal with the background brush of current UIElement element.
&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;value&quot;&gt;&lt;/param&gt;
&nbsp; &nbsp;&nbsp;''' &lt;param name=&quot;targetType&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;parameter&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;culture&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;returns&gt;&lt;/returns&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;remarks&gt;&lt;/remarks&gt;
&nbsp;&nbsp;&nbsp; Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim element As Panel = DirectCast(value, Panel)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AddHandler element.Loaded, AddressOf Element_Loaded


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return NormalBrush
&nbsp;&nbsp;&nbsp; End Function


&nbsp;&nbsp;&nbsp; Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Throw New NotImplementedException()
&nbsp;&nbsp;&nbsp; End Function


&nbsp;&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; ''' Get the index of UIElement element and in accordance with the index to
&nbsp;&nbsp;&nbsp; ''' perform background color alternating.
&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;sender&quot;&gt;UIElement&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;remarks&gt;&lt;/remarks&gt;
&nbsp;&nbsp;&nbsp; Private Sub Element_Loaded(sender As Object, e As RoutedEventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim intIndex As Integer = -1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' index
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim element As Panel = TryCast(sender, Panel)&nbsp; ' Current UIElement&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; intIndex = Utilities.GetIndexOfUIElement(element)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If intIndex &lt;&gt; (-1) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If intIndex Mod 2 &lt;&gt; 0 Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; element.Background = AlternateBrush
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; End Sub
End Class

</pre>
<pre id="codePreview" class="vb">
Public Class AlternatingRowBackgroundConverter
&nbsp;&nbsp;&nbsp; Implements IValueConverter
&nbsp;&nbsp;&nbsp; ' Normal Brush
&nbsp;&nbsp;&nbsp; Public Property NormalBrush() As Brush
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return m_NormalBrush
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set(value As Brush)
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_NormalBrush = value
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Set
&nbsp;&nbsp;&nbsp; End Property
&nbsp;&nbsp;&nbsp; Private m_NormalBrush As Brush


&nbsp;&nbsp;&nbsp; ' Alternate Brush
&nbsp;&nbsp;&nbsp; Public Property AlternateBrush() As Brush
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return m_AlternateBrush
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Set(value As Brush)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_AlternateBrush = value
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Set
&nbsp;&nbsp;&nbsp; End Property
&nbsp;&nbsp;&nbsp; Private m_AlternateBrush As Brush


&nbsp;&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; ''' Deal with the background brush of current UIElement element.
&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;value&quot;&gt;&lt;/param&gt;
&nbsp; &nbsp;&nbsp;''' &lt;param name=&quot;targetType&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;parameter&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;culture&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;returns&gt;&lt;/returns&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;remarks&gt;&lt;/remarks&gt;
&nbsp;&nbsp;&nbsp; Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim element As Panel = DirectCast(value, Panel)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AddHandler element.Loaded, AddressOf Element_Loaded


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return NormalBrush
&nbsp;&nbsp;&nbsp; End Function


&nbsp;&nbsp;&nbsp; Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Throw New NotImplementedException()
&nbsp;&nbsp;&nbsp; End Function


&nbsp;&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; ''' Get the index of UIElement element and in accordance with the index to
&nbsp;&nbsp;&nbsp; ''' perform background color alternating.
&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;sender&quot;&gt;UIElement&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;remarks&gt;&lt;/remarks&gt;
&nbsp;&nbsp;&nbsp; Private Sub Element_Loaded(sender As Object, e As RoutedEventArgs)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim intIndex As Integer = -1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' index
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim element As Panel = TryCast(sender, Panel)&nbsp; ' Current UIElement&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; intIndex = Utilities.GetIndexOfUIElement(element)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If intIndex &lt;&gt; (-1) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If intIndex Mod 2 &lt;&gt; 0 Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; element.Background = AlternateBrush
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; End Sub
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">Step 8.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>The XAML code in DataView2.xaml resembles the following:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;Grid Width=&quot;450&quot; Height=&quot;750&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Grid.ColumnDefinitions&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ColumnDefinition Width=&quot;*&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Grid.ColumnDefinitions&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Grid.RowDefinitions&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;RowDefinition Height=&quot;400&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;RowDefinition Height=&quot;100&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Grid.RowDefinitions&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Grid Grid.Column=&quot;0&quot; Grid.Row=&quot;0&quot; HorizontalAlignment=&quot;Stretch&quot; VerticalAlignment=&quot;Stretch&quot; &gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ScrollViewer&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ItemsControl x:Name=&quot;itmCustomType&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ItemsControl.ItemTemplate&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DataTemplate&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid Background=&quot;{Binding BackgroundBrush}&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Grid.ColumnDefinitions&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ColumnDefinition Width=&quot;100&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ColumnDefinition Width=&quot;200&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ColumnDefinition Width=&quot;150&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Grid.ColumnDefinitions&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBlock x:Name=&quot;tbIndex&quot; TextAlignment=&quot;Center&quot; Grid.Column=&quot;0&quot; Text=&quot;{Binding Index}&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBlock TextAlignment=&quot;Center&quot; Grid.Column=&quot;1&quot; Text=&quot;{Binding Name}&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBlock TextAlignment=&quot;Center&quot; Grid.Column=&quot;2&quot; Text=&quot;{Binding Age}&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Grid&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&lt;/DataTemplate&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ItemsControl.ItemTemplate&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ItemsControl&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ScrollViewer&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Grid&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBlock x:Name=&quot;tbShow&quot; Grid.Column=&quot;0&quot; Grid.Row=&quot;1&quot;&gt;&lt;/TextBlock&gt;
&nbsp;&nbsp; &lt;/Grid&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;Grid Width=&quot;450&quot; Height=&quot;750&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Grid.ColumnDefinitions&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ColumnDefinition Width=&quot;*&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Grid.ColumnDefinitions&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Grid.RowDefinitions&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;RowDefinition Height=&quot;400&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;RowDefinition Height=&quot;100&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Grid.RowDefinitions&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Grid Grid.Column=&quot;0&quot; Grid.Row=&quot;0&quot; HorizontalAlignment=&quot;Stretch&quot; VerticalAlignment=&quot;Stretch&quot; &gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ScrollViewer&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ItemsControl x:Name=&quot;itmCustomType&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ItemsControl.ItemTemplate&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DataTemplate&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid Background=&quot;{Binding BackgroundBrush}&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Grid.ColumnDefinitions&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ColumnDefinition Width=&quot;100&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ColumnDefinition Width=&quot;200&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ColumnDefinition Width=&quot;150&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Grid.ColumnDefinitions&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBlock x:Name=&quot;tbIndex&quot; TextAlignment=&quot;Center&quot; Grid.Column=&quot;0&quot; Text=&quot;{Binding Index}&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBlock TextAlignment=&quot;Center&quot; Grid.Column=&quot;1&quot; Text=&quot;{Binding Name}&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBlock TextAlignment=&quot;Center&quot; Grid.Column=&quot;2&quot; Text=&quot;{Binding Age}&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Grid&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&lt;/DataTemplate&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ItemsControl.ItemTemplate&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ItemsControl&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ScrollViewer&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Grid&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBlock x:Name=&quot;tbShow&quot; Grid.Column=&quot;0&quot; Grid.Row=&quot;1&quot;&gt;&lt;/TextBlock&gt;
&nbsp;&nbsp; &lt;/Grid&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">Step 9.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>The XAML code in DataView1.xaml resembles the following:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;UserControl.Resources&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;converters:AlternatingRowBackgroundConverter
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; x:Key=&quot;MyAlternatingBackgroundConverter&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NormalBrush=&quot;Green&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AlternateBrush=&quot;Red&quot;/&gt;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DataTemplate x:Key=&quot;MyItemTemplate&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Grid
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Background=&quot;{Binding
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RelativeSource={RelativeSource Self},
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Converter={StaticResource MyAlternatingBackgroundConverter}}&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBlock&nbsp;&nbsp;&nbsp;&nbsp; x:Name=&quot;tbName&quot;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Margin=&quot;15&quot; Text=&quot;{Binding Name}&quot; Tap=&quot;tbName_Tap&quot;&gt;&lt;/TextBlock&gt;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Grid&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/DataTemplate&gt;
&nbsp;&nbsp; &lt;/UserControl.Resources&gt;


&nbsp;&nbsp; &lt;Grid Background=&quot;White&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;ItemsControl
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ItemsSource=&quot;{Binding UserDatas}&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ItemTemplate=&quot;{StaticResource MyItemTemplate}&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ItemsControl&gt;
&nbsp;&nbsp; &lt;/Grid&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;UserControl.Resources&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;converters:AlternatingRowBackgroundConverter
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; x:Key=&quot;MyAlternatingBackgroundConverter&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NormalBrush=&quot;Green&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AlternateBrush=&quot;Red&quot;/&gt;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DataTemplate x:Key=&quot;MyItemTemplate&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Grid
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Background=&quot;{Binding
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RelativeSource={RelativeSource Self},
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Converter={StaticResource MyAlternatingBackgroundConverter}}&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBlock&nbsp;&nbsp;&nbsp;&nbsp; x:Name=&quot;tbName&quot;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Margin=&quot;15&quot; Text=&quot;{Binding Name}&quot; Tap=&quot;tbName_Tap&quot;&gt;&lt;/TextBlock&gt;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Grid&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/DataTemplate&gt;
&nbsp;&nbsp; &lt;/UserControl.Resources&gt;


&nbsp;&nbsp; &lt;Grid Background=&quot;White&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&lt;ItemsControl
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ItemsSource=&quot;{Binding UserDatas}&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ItemTemplate=&quot;{StaticResource MyItemTemplate}&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ItemsControl&gt;
&nbsp;&nbsp; &lt;/Grid&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph">In the XAML editor, in the <b style="">&lt;UserControl&gt;</b> tag, with the other namespace declarations, add the following code to DataView1:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
xmlns:converters=&quot;clr-namespace:VBWP8AccessItemIndex&quot;

</pre>
<pre id="codePreview" class="xaml">
xmlns:converters=&quot;clr-namespace:VBWP8AccessItemIndex&quot;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">Step 10.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Right-click App.xaml and then click View Code. Add the following code before RootFrame properties:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Shared m_viewModel As ViewModel = Nothing


&nbsp;&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; ''' A static ViewModel used by the views to bind against.
&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;returns&gt;The MainViewModel object.&lt;/returns&gt;
&nbsp;&nbsp;&nbsp; Public Shared ReadOnly Property ViewModel() As ViewModel
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Delay creation of the view model until necessary
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If m_viewModel Is Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_viewModel = New ViewModel()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return m_viewModel
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;End Get
&nbsp;&nbsp;&nbsp; End Property

</pre>
<pre id="codePreview" class="vb">
Private Shared m_viewModel As ViewModel = Nothing


&nbsp;&nbsp;&nbsp; ''' &lt;summary&gt;
&nbsp;&nbsp;&nbsp; ''' A static ViewModel used by the views to bind against.
&nbsp;&nbsp;&nbsp; ''' &lt;/summary&gt;
&nbsp;&nbsp;&nbsp; ''' &lt;returns&gt;The MainViewModel object.&lt;/returns&gt;
&nbsp;&nbsp;&nbsp; Public Shared ReadOnly Property ViewModel() As ViewModel
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Delay creation of the view model until necessary
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If m_viewModel Is Nothing Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m_viewModel = New ViewModel()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return m_viewModel
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;End Get
&nbsp;&nbsp;&nbsp; End Property

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">Step 11.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Use <span class="SpellE">MainPage.xaml</span> as the main app page. This page will contain two views.</p>
<p class="MsoListParagraphCxSpLast">In the XAML editor, in the <b style="">&lt; phone &gt;</b> tag, with the other namespace declarations, add the following code to main app page:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
xmlns:views=&quot;clr-namespace:VBWP8AccessItemIndex.Views&quot;

</pre>
<pre id="codePreview" class="xaml">
xmlns:views=&quot;clr-namespace:VBWP8AccessItemIndex.Views&quot;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph">The XAML code in MainPage.xaml resembles the following:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;Grid x:Name=&quot;LayoutRoot&quot;&nbsp; Margin=&quot;0,0,0,81&quot; &gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;StackPanel Visibility=&quot;Visible&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;views:DataView1 x:Name=&quot;ItemView1&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/StackPanel&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;StackPanel Visibility=&quot;Collapsed&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;views:DataView2 x:Name=&quot;ItemView2&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/StackPanel&gt;
&nbsp;&nbsp;&nbsp; &lt;/Grid&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;Grid x:Name=&quot;LayoutRoot&quot;&nbsp; Margin=&quot;0,0,0,81&quot; &gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;StackPanel Visibility=&quot;Visible&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;views:DataView1 x:Name=&quot;ItemView1&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/StackPanel&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;StackPanel Visibility=&quot;Collapsed&quot;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;views:DataView2 x:Name=&quot;ItemView2&quot;/&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/StackPanel&gt;
&nbsp;&nbsp;&nbsp; &lt;/Grid&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph">Right-click MainPage.xaml and then click View Code, this can bind the ViewModel's data in to the two views.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub Page_Loaded(sender As Object, e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' data bind
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.ItemView1.DataContext = App.ViewModel
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.ItemView2.itmCustomType.ItemsSource = App.ViewModel.UserDatas
&nbsp;&nbsp; End Sub

</pre>
<pre id="codePreview" class="vb">
Private Sub Page_Loaded(sender As Object, e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' data bind
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.ItemView1.DataContext = App.ViewModel
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.ItemView2.itmCustomType.ItemsSource = App.ViewModel.UserDatas
&nbsp;&nbsp; End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">Step 12.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Build the application, and then you can debug it.</p>
<h2>More Information</h2>
<p class="MsoNormal">ItemsControl Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.windows.controls.itemscontrol(v=VS.95).aspx">http://msdn.microsoft.com/en-us/library/system.windows.controls.itemscontrol(v=VS.95).aspx</a><br>
IValueConverter Interface<br>
<a href="http://msdn.microsoft.com/en-us/library/system.windows.data.ivalueconverter(v=VS.95).aspx">http://msdn.microsoft.com/en-us/library/system.windows.data.ivalueconverter(v=VS.95).aspx</a><br>
VisualTreeHelper.GetParent Method<br>
<a href="http://msdn.microsoft.com/en-us/library/system.windows.media.visualtreehelper.getparent.aspx">http://msdn.microsoft.com/en-us/library/system.windows.media.visualtreehelper.getparent.aspx</a><br>
ItemContainerGenerator Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.windows.controls.itemcontainergenerator.aspx">http://msdn.microsoft.com/en-us/library/system.windows.controls.itemcontainergenerator.aspx</a><br>
ObservableCollection&lt;T&gt; Class<br>
<a href="http://msdn.microsoft.com/en-us/library/ms668604.aspx">http://msdn.microsoft.com/en-us/library/ms668604.aspx</a><br>
INotifyPropertyChanged Interface<br>
<span style="">&nbsp;</span><a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.inotifypropertychanged.aspx">http://msdn.microsoft.com/en-us/library/system.componentmodel.inotifypropertychanged.aspx</a><br>
SolidColorBrush Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.windows.media.solidcolorbrush(v=VS.95).aspx">http://msdn.microsoft.com/en-us/library/system.windows.media.solidcolorbrush(v=VS.95).aspx</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

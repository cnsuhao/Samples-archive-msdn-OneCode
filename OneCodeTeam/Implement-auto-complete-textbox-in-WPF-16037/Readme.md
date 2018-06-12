# Implement auto-complete textbox in WPF (VBWPFAutoCompleteTextBox)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* WPF
## Topics
* Controls
* Auto-complete
## IsPublished
* True
## ModifiedDate
* 2012-03-11 06:50:30
## Description

<h1><span style="">Implement auto-complete textbox in WPF (<span class="SpellE">VBWPFAutoCompl</span>&#8203;<span class="SpellE">eteTextBox</span>)
</span></h1>
<h2>Introduction<br>
<span class="GramE">This</span> example demonstrates how to achieve <span class="SpellE">
<span style="font-weight:normal">AutoCompleteTextBox</span></span> in WPF Application.<span style="">
</span></h2>
<p class="MsoNormal"><span style="">To assist with data entry, Microsoft Internet Explorer 5 and later and some other browsers support a feature referred to as AutoComplete. AutoComplete monitors a
<span class="SpellE">TextBox</span> and creates a list of values entered by the user. When the user returns to the text at a later time, the list is displayed. Instead of retyping a previously entered value, the user can simply select the value from this
 list. </span></p>
<p class="MsoNormal"><span style="">In this example, we��ll create a <span class="SpellE">
TextBox</span> that automatically completes input strings by comparing the prefix being entered to the prefixed of all strings in a maintained source. This is useful for
<span class="SpellE">TextBox</span> controls in which URLs, addresses, file names, or commands will be frequently entered.
</span></p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoNormal"><span style="">Press F5 to run this application, and type some characters in test box, you will see following result.
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/54149/1/image.png" alt="" width="375" height="365" align="middle">
</span><span style=""></span></p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoListParagraph" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Design the <span class="SpellE"><b style="">AutoCompleteEntry</b></span> class which is used to represent a suggested item.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Class AutoCompleteEntry
    Inherits ComboBoxItem
    Private tb As TextBlock


    'text of the item 
    Private _text As String


    ''' &lt;summary&gt; 
    ''' Contrutor of AutoCompleteEntry class 
    ''' &lt;/summary&gt; 
    ''' &lt;param name=&quot;text&quot;&gt;All the Text of the item &lt;/param&gt; 
    ''' &lt;param name=&quot;bold&quot;&gt;The already entered part of the Text&lt;/param&gt; 
    ''' &lt;param name=&quot;unbold&quot;&gt;The remained part of the Text&lt;/param&gt; 
    Public Sub New(ByVal text As String, ByVal bold As String, ByVal unbold As String)
        _text = text
        tb = New TextBlock()
        'highlight the current input Text 
        tb.Inlines.Add(New Run() With {.Text = bold, .FontWeight = FontWeights.Bold, .Foreground = New SolidColorBrush(Colors.RoyalBlue)})
        tb.Inlines.Add(New Run() With {.Text = unbold})
        Me.Content = tb
    End Sub


    ''' &lt;summary&gt; 
    ''' Gets the text. 
    ''' &lt;/summary&gt; 
    Public ReadOnly Property Text() As String
        Get
            Return _text
        End Get
    End Property
End Class

</pre>
<pre id="codePreview" class="vb">
Public Class AutoCompleteEntry
    Inherits ComboBoxItem
    Private tb As TextBlock


    'text of the item 
    Private _text As String


    ''' &lt;summary&gt; 
    ''' Contrutor of AutoCompleteEntry class 
    ''' &lt;/summary&gt; 
    ''' &lt;param name=&quot;text&quot;&gt;All the Text of the item &lt;/param&gt; 
    ''' &lt;param name=&quot;bold&quot;&gt;The already entered part of the Text&lt;/param&gt; 
    ''' &lt;param name=&quot;unbold&quot;&gt;The remained part of the Text&lt;/param&gt; 
    Public Sub New(ByVal text As String, ByVal bold As String, ByVal unbold As String)
        _text = text
        tb = New TextBlock()
        'highlight the current input Text 
        tb.Inlines.Add(New Run() With {.Text = bold, .FontWeight = FontWeights.Bold, .Foreground = New SolidColorBrush(Colors.RoyalBlue)})
        tb.Inlines.Add(New Run() With {.Text = unbold})
        Me.Content = tb
    End Sub


    ''' &lt;summary&gt; 
    ''' Gets the text. 
    ''' &lt;/summary&gt; 
    Public ReadOnly Property Text() As String
        Get
            Return _text
        End Get
    End Property
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Design the <span class="SpellE"><b style="">AutoCompleteTextBox</b></span> to Achieve AutoComplete
<span class="SpellE">TextBox</span> or <span class="SpellE">ComboBox</span>. </span>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Class AutoCompleteTextBox
    Inherits ComboBox
    ''' &lt;summary&gt; 
    ''' Initializes a new instance of the &lt;see cref=&quot;AutoCompleteTextBox&quot;/&gt; class. 
    ''' &lt;/summary&gt; 
    Public Sub New()
        'load and apply style to the ComboBox. 
        Dim rd As New ResourceDictionary()
        rd.Source = New Uri(&quot;/&quot; & Me.[GetType]().Assembly.GetName().Name & &quot;;component/UserControls/AutoCompleteComboBoxStyle.xaml&quot;, UriKind.Relative)
        Me.Resources = rd
        'disable default Text Search Function 
        Me.IsTextSearchEnabled = False
    End Sub


    ''' &lt;summary&gt; 
    ''' override OnApplyTemplate method 
    ''' get TextBox control out of Combobox control, and hook up TextChanged event. 
    ''' &lt;/summary&gt; 
    Public Overloads Overrides Sub OnApplyTemplate()
        MyBase.OnApplyTemplate()
        'get the textbox control in the ComboBox control 
        Dim textBox As TextBox = TryCast(Me.Template.FindName(&quot;PART_EditableTextBox&quot;, Me), TextBox)
        If textBox IsNot Nothing Then
            'disable Autoword selection of the TextBox 
            textBox.AutoWordSelection = False
            'handle TextChanged event to dynamically add Combobox items. 
            AddHandler textBox.TextChanged, AddressOf textBox_TextChanged
        End If
    End Sub


    'The autosuggestionlist source. 
    Private _autoSuggestionList As New ObservableCollection(Of String)()


    ''' &lt;summary&gt; 
    ''' Gets or sets the auto suggestion list. 
    ''' &lt;/summary&gt; 
    ''' &lt;value&gt;The auto suggestion list.&lt;/value&gt; 
    Public Property AutoSuggestionList() As ObservableCollection(Of String)
        Get
            Return _autoSuggestionList
        End Get
        Set(ByVal value As ObservableCollection(Of String))
            _autoSuggestionList = value
        End Set
    End Property




    ''' &lt;summary&gt; 
    ''' main logic to generate auto suggestion list. 
    ''' &lt;/summary&gt; 
    ''' &lt;param name=&quot;sender&quot;&gt;The source of the event.&lt;/param&gt; 
    ''' &lt;param name=&quot;e&quot;&gt;The &lt;see cref=&quot;System.Windows.Controls.TextChangedEventArgs&quot;/&gt; 
    ''' instance containing the event data.&lt;/param&gt; 
    Private Sub textBox_TextChanged(ByVal sender As Object, ByVal e As TextChangedEventArgs)
        Dim textBox As TextBox = TryCast(sender, TextBox)
        textBox.AutoWordSelection = False
        ' if the word in the textbox is selected, then don't change item collection 
        If (textBox.SelectionStart &lt;&gt; 0 OrElse textBox.Text.Length = 0) Then
            Me.Items.Clear()
            'add new filtered items according the current TextBox input 
            If Not String.IsNullOrEmpty(textBox.Text) Then
                For Each s As String In Me._autoSuggestionList
                    If s.StartsWith(textBox.Text, StringComparison.InvariantCultureIgnoreCase) Then


                        Dim unboldpart As String = s.Substring(textBox.Text.Length)
                        Dim boldpart As String = s.Substring(0, textBox.Text.Length)
                        'construct AutoCompleteEntry and add to the ComboBox 
                        Dim entry As New AutoCompleteEntry(s, boldpart, unboldpart)
                        Me.Items.Add(entry)
                    End If
                Next
            End If
        End If
        ' open or close dropdown of the ComboBox according to whether there are items in the 
        ' fitlered result. 
        Me.IsDropDownOpen = Me.HasItems


        'avoid auto selection 
        textBox.Focus()


        textBox.SelectionStart = textBox.Text.Length
    End Sub
End Class

</pre>
<pre id="codePreview" class="vb">
Public Class AutoCompleteTextBox
    Inherits ComboBox
    ''' &lt;summary&gt; 
    ''' Initializes a new instance of the &lt;see cref=&quot;AutoCompleteTextBox&quot;/&gt; class. 
    ''' &lt;/summary&gt; 
    Public Sub New()
        'load and apply style to the ComboBox. 
        Dim rd As New ResourceDictionary()
        rd.Source = New Uri(&quot;/&quot; & Me.[GetType]().Assembly.GetName().Name & &quot;;component/UserControls/AutoCompleteComboBoxStyle.xaml&quot;, UriKind.Relative)
        Me.Resources = rd
        'disable default Text Search Function 
        Me.IsTextSearchEnabled = False
    End Sub


    ''' &lt;summary&gt; 
    ''' override OnApplyTemplate method 
    ''' get TextBox control out of Combobox control, and hook up TextChanged event. 
    ''' &lt;/summary&gt; 
    Public Overloads Overrides Sub OnApplyTemplate()
        MyBase.OnApplyTemplate()
        'get the textbox control in the ComboBox control 
        Dim textBox As TextBox = TryCast(Me.Template.FindName(&quot;PART_EditableTextBox&quot;, Me), TextBox)
        If textBox IsNot Nothing Then
            'disable Autoword selection of the TextBox 
            textBox.AutoWordSelection = False
            'handle TextChanged event to dynamically add Combobox items. 
            AddHandler textBox.TextChanged, AddressOf textBox_TextChanged
        End If
    End Sub


    'The autosuggestionlist source. 
    Private _autoSuggestionList As New ObservableCollection(Of String)()


    ''' &lt;summary&gt; 
    ''' Gets or sets the auto suggestion list. 
    ''' &lt;/summary&gt; 
    ''' &lt;value&gt;The auto suggestion list.&lt;/value&gt; 
    Public Property AutoSuggestionList() As ObservableCollection(Of String)
        Get
            Return _autoSuggestionList
        End Get
        Set(ByVal value As ObservableCollection(Of String))
            _autoSuggestionList = value
        End Set
    End Property




    ''' &lt;summary&gt; 
    ''' main logic to generate auto suggestion list. 
    ''' &lt;/summary&gt; 
    ''' &lt;param name=&quot;sender&quot;&gt;The source of the event.&lt;/param&gt; 
    ''' &lt;param name=&quot;e&quot;&gt;The &lt;see cref=&quot;System.Windows.Controls.TextChangedEventArgs&quot;/&gt; 
    ''' instance containing the event data.&lt;/param&gt; 
    Private Sub textBox_TextChanged(ByVal sender As Object, ByVal e As TextChangedEventArgs)
        Dim textBox As TextBox = TryCast(sender, TextBox)
        textBox.AutoWordSelection = False
        ' if the word in the textbox is selected, then don't change item collection 
        If (textBox.SelectionStart &lt;&gt; 0 OrElse textBox.Text.Length = 0) Then
            Me.Items.Clear()
            'add new filtered items according the current TextBox input 
            If Not String.IsNullOrEmpty(textBox.Text) Then
                For Each s As String In Me._autoSuggestionList
                    If s.StartsWith(textBox.Text, StringComparison.InvariantCultureIgnoreCase) Then


                        Dim unboldpart As String = s.Substring(textBox.Text.Length)
                        Dim boldpart As String = s.Substring(0, textBox.Text.Length)
                        'construct AutoCompleteEntry and add to the ComboBox 
                        Dim entry As New AutoCompleteEntry(s, boldpart, unboldpart)
                        Me.Items.Add(entry)
                    End If
                Next
            End If
        End If
        ' open or close dropdown of the ComboBox according to whether there are items in the 
        ' fitlered result. 
        Me.IsDropDownOpen = Me.HasItems


        'avoid auto selection 
        textBox.Focus()


        textBox.SelectionStart = textBox.Text.Length
    End Sub
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Set the style of the <span class="SpellE"><b style="">AutoCompleteTextBox</b></span><b style="">
</b>in <span class="SpellE"><span class="GramE">Xaml</span></span><span class="GramE"> .</span>
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;!--Brushes and Borders used for this control--&gt;


&lt;ResourceDictionary xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
                      xmlns:local=&quot;clr-namespace:VBWPFAutoCompleteTextBox.UserControls&quot;
    xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;&gt;
    &lt;LinearGradientBrush x:Key=&quot;NormalBrush&quot; StartPoint=&quot;0,0&quot; EndPoint=&quot;0,1&quot;&gt;
        &lt;GradientBrush.GradientStops&gt;
            &lt;GradientStopCollection&gt;
                &lt;GradientStop Color=&quot;#FFF&quot; Offset=&quot;0.0&quot;/&gt;
                &lt;GradientStop Color=&quot;#CCC&quot; Offset=&quot;1.0&quot;/&gt;
            &lt;/GradientStopCollection&gt;
        &lt;/GradientBrush.GradientStops&gt;
    &lt;/LinearGradientBrush&gt;
    &lt;LinearGradientBrush x:Key=&quot;HorizontalNormalBrush&quot; StartPoint=&quot;0,0&quot; EndPoint=&quot;1,0&quot;&gt;
        &lt;GradientBrush.GradientStops&gt;
            &lt;GradientStopCollection&gt;
                &lt;GradientStop Color=&quot;#FFF&quot; Offset=&quot;0.0&quot;/&gt;
                &lt;GradientStop Color=&quot;#CCC&quot; Offset=&quot;1.0&quot;/&gt;
            &lt;/GradientStopCollection&gt;
        &lt;/GradientBrush.GradientStops&gt;
    &lt;/LinearGradientBrush&gt;
    &lt;LinearGradientBrush x:Key=&quot;LightBrush&quot; StartPoint=&quot;0,0&quot; EndPoint=&quot;0,1&quot;&gt;
        &lt;GradientBrush.GradientStops&gt;
            &lt;GradientStopCollection&gt;
                &lt;GradientStop Color=&quot;#FFF&quot; Offset=&quot;0.0&quot;/&gt;
                &lt;GradientStop Color=&quot;#EEE&quot; Offset=&quot;1.0&quot;/&gt;
            &lt;/GradientStopCollection&gt;
        &lt;/GradientBrush.GradientStops&gt;
    &lt;/LinearGradientBrush&gt;
    &lt;LinearGradientBrush x:Key=&quot;HorizontalLightBrush&quot; StartPoint=&quot;0,0&quot; EndPoint=&quot;1,0&quot;&gt;
        &lt;GradientBrush.GradientStops&gt;
            &lt;GradientStopCollection&gt;
                &lt;GradientStop Color=&quot;#FFF&quot; Offset=&quot;0.0&quot;/&gt;
                &lt;GradientStop Color=&quot;#EEE&quot; Offset=&quot;1.0&quot;/&gt;
            &lt;/GradientStopCollection&gt;
        &lt;/GradientBrush.GradientStops&gt;
    &lt;/LinearGradientBrush&gt;
    &lt;LinearGradientBrush x:Key=&quot;DarkBrush&quot; StartPoint=&quot;0,0&quot; EndPoint=&quot;0,1&quot;&gt;
        &lt;GradientBrush.GradientStops&gt;
            &lt;GradientStopCollection&gt;
                &lt;GradientStop Color=&quot;#FFF&quot; Offset=&quot;0.0&quot;/&gt;
                &lt;GradientStop Color=&quot;#AAA&quot; Offset=&quot;1.0&quot;/&gt;
            &lt;/GradientStopCollection&gt;
        &lt;/GradientBrush.GradientStops&gt;
    &lt;/LinearGradientBrush&gt;
    &lt;LinearGradientBrush x:Key=&quot;PressedBrush&quot; StartPoint=&quot;0,0&quot; EndPoint=&quot;0,1&quot;&gt;
        &lt;GradientBrush.GradientStops&gt;
            &lt;GradientStopCollection&gt;
                &lt;GradientStop Color=&quot;#BBB&quot; Offset=&quot;0.0&quot;/&gt;
                &lt;GradientStop Color=&quot;#EEE&quot; Offset=&quot;0.1&quot;/&gt;
                &lt;GradientStop Color=&quot;#EEE&quot; Offset=&quot;0.9&quot;/&gt;
                &lt;GradientStop Color=&quot;#FFF&quot; Offset=&quot;1.0&quot;/&gt;
            &lt;/GradientStopCollection&gt;
        &lt;/GradientBrush.GradientStops&gt;
    &lt;/LinearGradientBrush&gt;
    &lt;SolidColorBrush x:Key=&quot;DisabledForegroundBrush&quot; Color=&quot;#888&quot; /&gt;
    &lt;SolidColorBrush x:Key=&quot;DisabledBackgroundBrush&quot; Color=&quot;#EEE&quot; /&gt;
    &lt;SolidColorBrush x:Key=&quot;WindowBackgroundBrush&quot; Color=&quot;#FFF&quot; /&gt;
    &lt;SolidColorBrush x:Key=&quot;SelectedBackgroundBrush&quot; Color=&quot;#DDD&quot; /&gt;
    &lt;!-- Border Brushes --&gt;
    &lt;LinearGradientBrush x:Key=&quot;NormalBorderBrush&quot; StartPoint=&quot;0,0&quot; EndPoint=&quot;0,1&quot;&gt;
        &lt;GradientBrush.GradientStops&gt;
            &lt;GradientStopCollection&gt;
                &lt;GradientStop Color=&quot;#CCC&quot; Offset=&quot;0.0&quot;/&gt;
                &lt;GradientStop Color=&quot;#444&quot; Offset=&quot;1.0&quot;/&gt;
            &lt;/GradientStopCollection&gt;
        &lt;/GradientBrush.GradientStops&gt;
    &lt;/LinearGradientBrush&gt;
    &lt;LinearGradientBrush x:Key=&quot;HorizontalNormalBorderBrush&quot; StartPoint=&quot;0,0&quot; EndPoint=&quot;1,0&quot;&gt;
        &lt;GradientBrush.GradientStops&gt;
            &lt;GradientStopCollection&gt;
                &lt;GradientStop Color=&quot;#CCC&quot; Offset=&quot;0.0&quot;/&gt;
                &lt;GradientStop Color=&quot;#444&quot; Offset=&quot;1.0&quot;/&gt;
            &lt;/GradientStopCollection&gt;
        &lt;/GradientBrush.GradientStops&gt;
    &lt;/LinearGradientBrush&gt;
    &lt;LinearGradientBrush x:Key=&quot;DefaultedBorderBrush&quot; StartPoint=&quot;0,0&quot; EndPoint=&quot;0,1&quot;&gt;
        &lt;GradientBrush.GradientStops&gt;
            &lt;GradientStopCollection&gt;
                &lt;GradientStop Color=&quot;#777&quot; Offset=&quot;0.0&quot;/&gt;
                &lt;GradientStop Color=&quot;#000&quot; Offset=&quot;1.0&quot;/&gt;
            &lt;/GradientStopCollection&gt;
        &lt;/GradientBrush.GradientStops&gt;
    &lt;/LinearGradientBrush&gt;
    &lt;LinearGradientBrush x:Key=&quot;PressedBorderBrush&quot; StartPoint=&quot;0,0&quot; EndPoint=&quot;0,1&quot;&gt;
        &lt;GradientBrush.GradientStops&gt;
            &lt;GradientStopCollection&gt;
                &lt;GradientStop Color=&quot;#444&quot; Offset=&quot;0.0&quot;/&gt;
                &lt;GradientStop Color=&quot;#888&quot; Offset=&quot;1.0&quot;/&gt;
            &lt;/GradientStopCollection&gt;
        &lt;/GradientBrush.GradientStops&gt;
    &lt;/LinearGradientBrush&gt;
    &lt;SolidColorBrush x:Key=&quot;DisabledBorderBrush&quot; Color=&quot;#AAA&quot; /&gt;
    &lt;SolidColorBrush x:Key=&quot;SolidBorderBrush&quot; Color=&quot;#888&quot; /&gt;
    &lt;SolidColorBrush x:Key=&quot;LightBorderBrush&quot; Color=&quot;#AAA&quot; /&gt;
    &lt;!-- Miscellaneous Brushes --&gt;
    &lt;SolidColorBrush x:Key=&quot;GlyphBrush&quot; Color=&quot;#444&quot; /&gt;
    &lt;SolidColorBrush x:Key=&quot;LightColorBrush&quot; Color=&quot;#DDD&quot; /&gt;




    &lt;ControlTemplate x:Key=&quot;ComboBoxToggleButton&quot; TargetType=&quot;ToggleButton&quot;&gt;
        &lt;Grid&gt;
            &lt;Grid.ColumnDefinitions&gt;
                &lt;ColumnDefinition /&gt;
                &lt;ColumnDefinition Width=&quot;20&quot; /&gt;
            &lt;/Grid.ColumnDefinitions&gt;
            &lt;Border
      x:Name=&quot;Border&quot; 
      Grid.ColumnSpan=&quot;2&quot;
      CornerRadius=&quot;2&quot;
      Background=&quot;{StaticResource NormalBrush}&quot;
      BorderBrush=&quot;{StaticResource NormalBorderBrush}&quot;
      BorderThickness=&quot;1&quot; /&gt;
            &lt;!--Ucomment the following  code block if you implement autocomplete Combobox--&gt;
            &lt;!--&lt;Border 
      Grid.Column=&quot;0&quot;
      CornerRadius=&quot;2,0,0,2&quot; 
      Margin=&quot;1&quot; 
      Background=&quot;{StaticResource WindowBackgroundBrush}&quot; 
      BorderBrush=&quot;{StaticResource NormalBorderBrush}&quot;
      BorderThickness=&quot;0,0,1,0&quot; /&gt;--&gt;
            &lt;!--&lt;Path 
      x:Name=&quot;Arrow&quot;
      Grid.Column=&quot;1&quot;     
      Fill=&quot;{StaticResource GlyphBrush}&quot;
      HorizontalAlignment=&quot;Center&quot;
      VerticalAlignment=&quot;Center&quot;
      Data=&quot;M 0 0 L 4 4 L 8 0 Z&quot;/&gt;--&gt;
        &lt;/Grid&gt;
        &lt;ControlTemplate.Triggers&gt;
            &lt;Trigger Property=&quot;ToggleButton.IsMouseOver&quot; Value=&quot;true&quot;&gt;
                &lt;Setter TargetName=&quot;Border&quot; Property=&quot;Background&quot; Value=&quot;{StaticResource DarkBrush}&quot; /&gt;
            &lt;/Trigger&gt;


            &lt;!--Ucomment the following  code block if you implement autocomplete Combobox--&gt;
            &lt;!--&lt;Trigger Property=&quot;ToggleButton.IsChecked&quot; Value=&quot;true&quot;&gt;
                &lt;Setter TargetName=&quot;Border&quot; Property=&quot;Background&quot; Value=&quot;{StaticResource PressedBrush}&quot; /&gt;
            &lt;/Trigger&gt;--&gt;
            &lt;Trigger Property=&quot;IsEnabled&quot; Value=&quot;False&quot;&gt;
                &lt;Setter TargetName=&quot;Border&quot; Property=&quot;Background&quot; Value=&quot;{StaticResource DisabledBackgroundBrush}&quot; /&gt;
                &lt;Setter TargetName=&quot;Border&quot; Property=&quot;BorderBrush&quot; Value=&quot;{StaticResource DisabledBorderBrush}&quot; /&gt;
                &lt;Setter Property=&quot;Foreground&quot; Value=&quot;{StaticResource DisabledForegroundBrush}&quot;/&gt;


                &lt;!--Ucomment the following  code block if you implement autocomplete Combobox--&gt;
                &lt;!--&lt;Setter TargetName=&quot;Arrow&quot; Property=&quot;Fill&quot; Value=&quot;{StaticResource DisabledForegroundBrush}&quot; /&gt;--&gt;


            &lt;/Trigger&gt;
        &lt;/ControlTemplate.Triggers&gt;
    &lt;/ControlTemplate&gt;


    &lt;ControlTemplate x:Key=&quot;ComboBoxTextBox&quot; TargetType=&quot;TextBox&quot;&gt;
        &lt;Border x:Name=&quot;PART_ContentHost&quot; Focusable=&quot;False&quot; Background=&quot;{TemplateBinding Background}&quot; /&gt;
    &lt;/ControlTemplate&gt;


    &lt;Style TargetType=&quot;{x:Type local:AutoCompleteTextBox}&quot;&gt;
        &lt;Setter Property=&quot;SnapsToDevicePixels&quot; Value=&quot;true&quot;/&gt;
        &lt;Setter Property=&quot;OverridesDefaultStyle&quot; Value=&quot;true&quot;/&gt;
        &lt;Setter Property=&quot;ScrollViewer.HorizontalScrollBarVisibility&quot; Value=&quot;Auto&quot;/&gt;
        &lt;Setter Property=&quot;ScrollViewer.VerticalScrollBarVisibility&quot; Value=&quot;Auto&quot;/&gt;
        &lt;Setter Property=&quot;ScrollViewer.CanContentScroll&quot; Value=&quot;true&quot;/&gt;
        &lt;Setter Property=&quot;MinWidth&quot; Value=&quot;120&quot;/&gt;
        &lt;Setter Property=&quot;MinHeight&quot; Value=&quot;20&quot;/&gt;
        &lt;Setter Property=&quot;IsEditable&quot; Value=&quot;true&quot; /&gt;
        &lt;Setter Property=&quot;Template&quot;&gt;
            &lt;Setter.Value&gt;
                &lt;ControlTemplate TargetType=&quot;{x:Type local:AutoCompleteTextBox}&quot;&gt;
                    &lt;Grid&gt;
                        &lt;ToggleButton 
            Name=&quot;ToggleButton&quot; 
            Template=&quot;{StaticResource ComboBoxToggleButton}&quot; 
            Grid.Column=&quot;2&quot; 
            Focusable=&quot;false&quot;
            ClickMode=&quot;Press&quot;&gt;
                        &lt;/ToggleButton&gt;
                        &lt;ContentPresenter
            Name=&quot;ContentSite&quot;
            IsHitTestVisible=&quot;False&quot; 
            Content=&quot;{TemplateBinding SelectionBoxItem}&quot;
            ContentTemplate=&quot;{TemplateBinding SelectionBoxItemTemplate}&quot;
            ContentTemplateSelector=&quot;{TemplateBinding ItemTemplateSelector}&quot;
            Margin=&quot;3,3,23,3&quot;
            VerticalAlignment=&quot;Center&quot;
            HorizontalAlignment=&quot;Left&quot; /&gt;
                        &lt;TextBox x:Name=&quot;PART_EditableTextBox&quot;
            Style=&quot;{x:Null}&quot; 
            Template=&quot;{StaticResource ComboBoxTextBox}&quot; 
            HorizontalAlignment=&quot;Left&quot; 
            VerticalAlignment=&quot;Center&quot; 
            Margin=&quot;3,3,23,3&quot;
            Focusable=&quot;True&quot; 
            Background=&quot;Transparent&quot;
            Visibility=&quot;Hidden&quot;
            IsReadOnly=&quot;{TemplateBinding IsReadOnly}&quot;/&gt;
                        &lt;Popup 
            Name=&quot;Popup&quot;
            Placement=&quot;Bottom&quot;
            IsOpen=&quot;{TemplateBinding IsDropDownOpen}&quot;
            AllowsTransparency=&quot;True&quot; 
            Focusable=&quot;False&quot;
            PopupAnimation=&quot;Slide&quot;&gt;
                            &lt;Grid 
              Name=&quot;DropDown&quot;
              SnapsToDevicePixels=&quot;True&quot;                
              MinWidth=&quot;{TemplateBinding ActualWidth}&quot;
              MaxHeight=&quot;{TemplateBinding MaxDropDownHeight}&quot;&gt;
                                &lt;Border 
                x:Name=&quot;DropDownBorder&quot;
                Background=&quot;{StaticResource WindowBackgroundBrush}&quot;
                BorderThickness=&quot;1&quot;
                BorderBrush=&quot;{StaticResource SolidBorderBrush}&quot;/&gt;
                                &lt;ScrollViewer Margin=&quot;4,6,4,6&quot; SnapsToDevicePixels=&quot;True&quot;&gt;
                                    &lt;StackPanel IsItemsHost=&quot;True&quot; KeyboardNavigation.DirectionalNavigation=&quot;Contained&quot; /&gt;
                                &lt;/ScrollViewer&gt;
                            &lt;/Grid&gt;
                        &lt;/Popup&gt;
                    &lt;/Grid&gt;
                    &lt;ControlTemplate.Triggers&gt;
                        &lt;Trigger Property=&quot;HasItems&quot; Value=&quot;false&quot;&gt;
                            &lt;Setter TargetName=&quot;DropDownBorder&quot; Property=&quot;MinHeight&quot; Value=&quot;95&quot;/&gt;


                        &lt;/Trigger&gt;


                        &lt;Trigger Property=&quot;IsEnabled&quot; Value=&quot;false&quot;&gt;
                            &lt;Setter Property=&quot;Foreground&quot; Value=&quot;{StaticResource DisabledForegroundBrush}&quot;/&gt;
                        &lt;/Trigger&gt;
                        &lt;Trigger Property=&quot;IsGrouping&quot; Value=&quot;true&quot;&gt;
                            &lt;Setter Property=&quot;ScrollViewer.CanContentScroll&quot; Value=&quot;false&quot;/&gt;
                        &lt;/Trigger&gt;
                        &lt;Trigger SourceName=&quot;Popup&quot; Property=&quot;Popup.AllowsTransparency&quot; Value=&quot;true&quot;&gt;
                            &lt;Setter TargetName=&quot;DropDownBorder&quot; Property=&quot;CornerRadius&quot; Value=&quot;4&quot;/&gt;
                            &lt;Setter TargetName=&quot;DropDownBorder&quot; Property=&quot;Margin&quot; Value=&quot;0,2,0,0&quot;/&gt;
                        &lt;/Trigger&gt;
                        &lt;Trigger Property=&quot;IsEditable&quot;
               Value=&quot;true&quot;&gt;
                            &lt;Setter Property=&quot;IsTabStop&quot; Value=&quot;false&quot;/&gt;
                            &lt;Setter TargetName=&quot;PART_EditableTextBox&quot; Property=&quot;Visibility&quot;    Value=&quot;Visible&quot;/&gt;
                            &lt;Setter TargetName=&quot;ContentSite&quot; Property=&quot;Visibility&quot; Value=&quot;Hidden&quot;/&gt;
                        &lt;/Trigger&gt;
                    &lt;/ControlTemplate.Triggers&gt;
                &lt;/ControlTemplate&gt;
            &lt;/Setter.Value&gt;
        &lt;/Setter&gt;
        &lt;Style.Triggers&gt;
        &lt;/Style.Triggers&gt;
    &lt;/Style&gt;
&lt;/ResourceDictionary&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;!--Brushes and Borders used for this control--&gt;


&lt;ResourceDictionary xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
                      xmlns:local=&quot;clr-namespace:VBWPFAutoCompleteTextBox.UserControls&quot;
    xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;&gt;
    &lt;LinearGradientBrush x:Key=&quot;NormalBrush&quot; StartPoint=&quot;0,0&quot; EndPoint=&quot;0,1&quot;&gt;
        &lt;GradientBrush.GradientStops&gt;
            &lt;GradientStopCollection&gt;
                &lt;GradientStop Color=&quot;#FFF&quot; Offset=&quot;0.0&quot;/&gt;
                &lt;GradientStop Color=&quot;#CCC&quot; Offset=&quot;1.0&quot;/&gt;
            &lt;/GradientStopCollection&gt;
        &lt;/GradientBrush.GradientStops&gt;
    &lt;/LinearGradientBrush&gt;
    &lt;LinearGradientBrush x:Key=&quot;HorizontalNormalBrush&quot; StartPoint=&quot;0,0&quot; EndPoint=&quot;1,0&quot;&gt;
        &lt;GradientBrush.GradientStops&gt;
            &lt;GradientStopCollection&gt;
                &lt;GradientStop Color=&quot;#FFF&quot; Offset=&quot;0.0&quot;/&gt;
                &lt;GradientStop Color=&quot;#CCC&quot; Offset=&quot;1.0&quot;/&gt;
            &lt;/GradientStopCollection&gt;
        &lt;/GradientBrush.GradientStops&gt;
    &lt;/LinearGradientBrush&gt;
    &lt;LinearGradientBrush x:Key=&quot;LightBrush&quot; StartPoint=&quot;0,0&quot; EndPoint=&quot;0,1&quot;&gt;
        &lt;GradientBrush.GradientStops&gt;
            &lt;GradientStopCollection&gt;
                &lt;GradientStop Color=&quot;#FFF&quot; Offset=&quot;0.0&quot;/&gt;
                &lt;GradientStop Color=&quot;#EEE&quot; Offset=&quot;1.0&quot;/&gt;
            &lt;/GradientStopCollection&gt;
        &lt;/GradientBrush.GradientStops&gt;
    &lt;/LinearGradientBrush&gt;
    &lt;LinearGradientBrush x:Key=&quot;HorizontalLightBrush&quot; StartPoint=&quot;0,0&quot; EndPoint=&quot;1,0&quot;&gt;
        &lt;GradientBrush.GradientStops&gt;
            &lt;GradientStopCollection&gt;
                &lt;GradientStop Color=&quot;#FFF&quot; Offset=&quot;0.0&quot;/&gt;
                &lt;GradientStop Color=&quot;#EEE&quot; Offset=&quot;1.0&quot;/&gt;
            &lt;/GradientStopCollection&gt;
        &lt;/GradientBrush.GradientStops&gt;
    &lt;/LinearGradientBrush&gt;
    &lt;LinearGradientBrush x:Key=&quot;DarkBrush&quot; StartPoint=&quot;0,0&quot; EndPoint=&quot;0,1&quot;&gt;
        &lt;GradientBrush.GradientStops&gt;
            &lt;GradientStopCollection&gt;
                &lt;GradientStop Color=&quot;#FFF&quot; Offset=&quot;0.0&quot;/&gt;
                &lt;GradientStop Color=&quot;#AAA&quot; Offset=&quot;1.0&quot;/&gt;
            &lt;/GradientStopCollection&gt;
        &lt;/GradientBrush.GradientStops&gt;
    &lt;/LinearGradientBrush&gt;
    &lt;LinearGradientBrush x:Key=&quot;PressedBrush&quot; StartPoint=&quot;0,0&quot; EndPoint=&quot;0,1&quot;&gt;
        &lt;GradientBrush.GradientStops&gt;
            &lt;GradientStopCollection&gt;
                &lt;GradientStop Color=&quot;#BBB&quot; Offset=&quot;0.0&quot;/&gt;
                &lt;GradientStop Color=&quot;#EEE&quot; Offset=&quot;0.1&quot;/&gt;
                &lt;GradientStop Color=&quot;#EEE&quot; Offset=&quot;0.9&quot;/&gt;
                &lt;GradientStop Color=&quot;#FFF&quot; Offset=&quot;1.0&quot;/&gt;
            &lt;/GradientStopCollection&gt;
        &lt;/GradientBrush.GradientStops&gt;
    &lt;/LinearGradientBrush&gt;
    &lt;SolidColorBrush x:Key=&quot;DisabledForegroundBrush&quot; Color=&quot;#888&quot; /&gt;
    &lt;SolidColorBrush x:Key=&quot;DisabledBackgroundBrush&quot; Color=&quot;#EEE&quot; /&gt;
    &lt;SolidColorBrush x:Key=&quot;WindowBackgroundBrush&quot; Color=&quot;#FFF&quot; /&gt;
    &lt;SolidColorBrush x:Key=&quot;SelectedBackgroundBrush&quot; Color=&quot;#DDD&quot; /&gt;
    &lt;!-- Border Brushes --&gt;
    &lt;LinearGradientBrush x:Key=&quot;NormalBorderBrush&quot; StartPoint=&quot;0,0&quot; EndPoint=&quot;0,1&quot;&gt;
        &lt;GradientBrush.GradientStops&gt;
            &lt;GradientStopCollection&gt;
                &lt;GradientStop Color=&quot;#CCC&quot; Offset=&quot;0.0&quot;/&gt;
                &lt;GradientStop Color=&quot;#444&quot; Offset=&quot;1.0&quot;/&gt;
            &lt;/GradientStopCollection&gt;
        &lt;/GradientBrush.GradientStops&gt;
    &lt;/LinearGradientBrush&gt;
    &lt;LinearGradientBrush x:Key=&quot;HorizontalNormalBorderBrush&quot; StartPoint=&quot;0,0&quot; EndPoint=&quot;1,0&quot;&gt;
        &lt;GradientBrush.GradientStops&gt;
            &lt;GradientStopCollection&gt;
                &lt;GradientStop Color=&quot;#CCC&quot; Offset=&quot;0.0&quot;/&gt;
                &lt;GradientStop Color=&quot;#444&quot; Offset=&quot;1.0&quot;/&gt;
            &lt;/GradientStopCollection&gt;
        &lt;/GradientBrush.GradientStops&gt;
    &lt;/LinearGradientBrush&gt;
    &lt;LinearGradientBrush x:Key=&quot;DefaultedBorderBrush&quot; StartPoint=&quot;0,0&quot; EndPoint=&quot;0,1&quot;&gt;
        &lt;GradientBrush.GradientStops&gt;
            &lt;GradientStopCollection&gt;
                &lt;GradientStop Color=&quot;#777&quot; Offset=&quot;0.0&quot;/&gt;
                &lt;GradientStop Color=&quot;#000&quot; Offset=&quot;1.0&quot;/&gt;
            &lt;/GradientStopCollection&gt;
        &lt;/GradientBrush.GradientStops&gt;
    &lt;/LinearGradientBrush&gt;
    &lt;LinearGradientBrush x:Key=&quot;PressedBorderBrush&quot; StartPoint=&quot;0,0&quot; EndPoint=&quot;0,1&quot;&gt;
        &lt;GradientBrush.GradientStops&gt;
            &lt;GradientStopCollection&gt;
                &lt;GradientStop Color=&quot;#444&quot; Offset=&quot;0.0&quot;/&gt;
                &lt;GradientStop Color=&quot;#888&quot; Offset=&quot;1.0&quot;/&gt;
            &lt;/GradientStopCollection&gt;
        &lt;/GradientBrush.GradientStops&gt;
    &lt;/LinearGradientBrush&gt;
    &lt;SolidColorBrush x:Key=&quot;DisabledBorderBrush&quot; Color=&quot;#AAA&quot; /&gt;
    &lt;SolidColorBrush x:Key=&quot;SolidBorderBrush&quot; Color=&quot;#888&quot; /&gt;
    &lt;SolidColorBrush x:Key=&quot;LightBorderBrush&quot; Color=&quot;#AAA&quot; /&gt;
    &lt;!-- Miscellaneous Brushes --&gt;
    &lt;SolidColorBrush x:Key=&quot;GlyphBrush&quot; Color=&quot;#444&quot; /&gt;
    &lt;SolidColorBrush x:Key=&quot;LightColorBrush&quot; Color=&quot;#DDD&quot; /&gt;




    &lt;ControlTemplate x:Key=&quot;ComboBoxToggleButton&quot; TargetType=&quot;ToggleButton&quot;&gt;
        &lt;Grid&gt;
            &lt;Grid.ColumnDefinitions&gt;
                &lt;ColumnDefinition /&gt;
                &lt;ColumnDefinition Width=&quot;20&quot; /&gt;
            &lt;/Grid.ColumnDefinitions&gt;
            &lt;Border
      x:Name=&quot;Border&quot; 
      Grid.ColumnSpan=&quot;2&quot;
      CornerRadius=&quot;2&quot;
      Background=&quot;{StaticResource NormalBrush}&quot;
      BorderBrush=&quot;{StaticResource NormalBorderBrush}&quot;
      BorderThickness=&quot;1&quot; /&gt;
            &lt;!--Ucomment the following  code block if you implement autocomplete Combobox--&gt;
            &lt;!--&lt;Border 
      Grid.Column=&quot;0&quot;
      CornerRadius=&quot;2,0,0,2&quot; 
      Margin=&quot;1&quot; 
      Background=&quot;{StaticResource WindowBackgroundBrush}&quot; 
      BorderBrush=&quot;{StaticResource NormalBorderBrush}&quot;
      BorderThickness=&quot;0,0,1,0&quot; /&gt;--&gt;
            &lt;!--&lt;Path 
      x:Name=&quot;Arrow&quot;
      Grid.Column=&quot;1&quot;     
      Fill=&quot;{StaticResource GlyphBrush}&quot;
      HorizontalAlignment=&quot;Center&quot;
      VerticalAlignment=&quot;Center&quot;
      Data=&quot;M 0 0 L 4 4 L 8 0 Z&quot;/&gt;--&gt;
        &lt;/Grid&gt;
        &lt;ControlTemplate.Triggers&gt;
            &lt;Trigger Property=&quot;ToggleButton.IsMouseOver&quot; Value=&quot;true&quot;&gt;
                &lt;Setter TargetName=&quot;Border&quot; Property=&quot;Background&quot; Value=&quot;{StaticResource DarkBrush}&quot; /&gt;
            &lt;/Trigger&gt;


            &lt;!--Ucomment the following  code block if you implement autocomplete Combobox--&gt;
            &lt;!--&lt;Trigger Property=&quot;ToggleButton.IsChecked&quot; Value=&quot;true&quot;&gt;
                &lt;Setter TargetName=&quot;Border&quot; Property=&quot;Background&quot; Value=&quot;{StaticResource PressedBrush}&quot; /&gt;
            &lt;/Trigger&gt;--&gt;
            &lt;Trigger Property=&quot;IsEnabled&quot; Value=&quot;False&quot;&gt;
                &lt;Setter TargetName=&quot;Border&quot; Property=&quot;Background&quot; Value=&quot;{StaticResource DisabledBackgroundBrush}&quot; /&gt;
                &lt;Setter TargetName=&quot;Border&quot; Property=&quot;BorderBrush&quot; Value=&quot;{StaticResource DisabledBorderBrush}&quot; /&gt;
                &lt;Setter Property=&quot;Foreground&quot; Value=&quot;{StaticResource DisabledForegroundBrush}&quot;/&gt;


                &lt;!--Ucomment the following  code block if you implement autocomplete Combobox--&gt;
                &lt;!--&lt;Setter TargetName=&quot;Arrow&quot; Property=&quot;Fill&quot; Value=&quot;{StaticResource DisabledForegroundBrush}&quot; /&gt;--&gt;


            &lt;/Trigger&gt;
        &lt;/ControlTemplate.Triggers&gt;
    &lt;/ControlTemplate&gt;


    &lt;ControlTemplate x:Key=&quot;ComboBoxTextBox&quot; TargetType=&quot;TextBox&quot;&gt;
        &lt;Border x:Name=&quot;PART_ContentHost&quot; Focusable=&quot;False&quot; Background=&quot;{TemplateBinding Background}&quot; /&gt;
    &lt;/ControlTemplate&gt;


    &lt;Style TargetType=&quot;{x:Type local:AutoCompleteTextBox}&quot;&gt;
        &lt;Setter Property=&quot;SnapsToDevicePixels&quot; Value=&quot;true&quot;/&gt;
        &lt;Setter Property=&quot;OverridesDefaultStyle&quot; Value=&quot;true&quot;/&gt;
        &lt;Setter Property=&quot;ScrollViewer.HorizontalScrollBarVisibility&quot; Value=&quot;Auto&quot;/&gt;
        &lt;Setter Property=&quot;ScrollViewer.VerticalScrollBarVisibility&quot; Value=&quot;Auto&quot;/&gt;
        &lt;Setter Property=&quot;ScrollViewer.CanContentScroll&quot; Value=&quot;true&quot;/&gt;
        &lt;Setter Property=&quot;MinWidth&quot; Value=&quot;120&quot;/&gt;
        &lt;Setter Property=&quot;MinHeight&quot; Value=&quot;20&quot;/&gt;
        &lt;Setter Property=&quot;IsEditable&quot; Value=&quot;true&quot; /&gt;
        &lt;Setter Property=&quot;Template&quot;&gt;
            &lt;Setter.Value&gt;
                &lt;ControlTemplate TargetType=&quot;{x:Type local:AutoCompleteTextBox}&quot;&gt;
                    &lt;Grid&gt;
                        &lt;ToggleButton 
            Name=&quot;ToggleButton&quot; 
            Template=&quot;{StaticResource ComboBoxToggleButton}&quot; 
            Grid.Column=&quot;2&quot; 
            Focusable=&quot;false&quot;
            ClickMode=&quot;Press&quot;&gt;
                        &lt;/ToggleButton&gt;
                        &lt;ContentPresenter
            Name=&quot;ContentSite&quot;
            IsHitTestVisible=&quot;False&quot; 
            Content=&quot;{TemplateBinding SelectionBoxItem}&quot;
            ContentTemplate=&quot;{TemplateBinding SelectionBoxItemTemplate}&quot;
            ContentTemplateSelector=&quot;{TemplateBinding ItemTemplateSelector}&quot;
            Margin=&quot;3,3,23,3&quot;
            VerticalAlignment=&quot;Center&quot;
            HorizontalAlignment=&quot;Left&quot; /&gt;
                        &lt;TextBox x:Name=&quot;PART_EditableTextBox&quot;
            Style=&quot;{x:Null}&quot; 
            Template=&quot;{StaticResource ComboBoxTextBox}&quot; 
            HorizontalAlignment=&quot;Left&quot; 
            VerticalAlignment=&quot;Center&quot; 
            Margin=&quot;3,3,23,3&quot;
            Focusable=&quot;True&quot; 
            Background=&quot;Transparent&quot;
            Visibility=&quot;Hidden&quot;
            IsReadOnly=&quot;{TemplateBinding IsReadOnly}&quot;/&gt;
                        &lt;Popup 
            Name=&quot;Popup&quot;
            Placement=&quot;Bottom&quot;
            IsOpen=&quot;{TemplateBinding IsDropDownOpen}&quot;
            AllowsTransparency=&quot;True&quot; 
            Focusable=&quot;False&quot;
            PopupAnimation=&quot;Slide&quot;&gt;
                            &lt;Grid 
              Name=&quot;DropDown&quot;
              SnapsToDevicePixels=&quot;True&quot;                
              MinWidth=&quot;{TemplateBinding ActualWidth}&quot;
              MaxHeight=&quot;{TemplateBinding MaxDropDownHeight}&quot;&gt;
                                &lt;Border 
                x:Name=&quot;DropDownBorder&quot;
                Background=&quot;{StaticResource WindowBackgroundBrush}&quot;
                BorderThickness=&quot;1&quot;
                BorderBrush=&quot;{StaticResource SolidBorderBrush}&quot;/&gt;
                                &lt;ScrollViewer Margin=&quot;4,6,4,6&quot; SnapsToDevicePixels=&quot;True&quot;&gt;
                                    &lt;StackPanel IsItemsHost=&quot;True&quot; KeyboardNavigation.DirectionalNavigation=&quot;Contained&quot; /&gt;
                                &lt;/ScrollViewer&gt;
                            &lt;/Grid&gt;
                        &lt;/Popup&gt;
                    &lt;/Grid&gt;
                    &lt;ControlTemplate.Triggers&gt;
                        &lt;Trigger Property=&quot;HasItems&quot; Value=&quot;false&quot;&gt;
                            &lt;Setter TargetName=&quot;DropDownBorder&quot; Property=&quot;MinHeight&quot; Value=&quot;95&quot;/&gt;


                        &lt;/Trigger&gt;


                        &lt;Trigger Property=&quot;IsEnabled&quot; Value=&quot;false&quot;&gt;
                            &lt;Setter Property=&quot;Foreground&quot; Value=&quot;{StaticResource DisabledForegroundBrush}&quot;/&gt;
                        &lt;/Trigger&gt;
                        &lt;Trigger Property=&quot;IsGrouping&quot; Value=&quot;true&quot;&gt;
                            &lt;Setter Property=&quot;ScrollViewer.CanContentScroll&quot; Value=&quot;false&quot;/&gt;
                        &lt;/Trigger&gt;
                        &lt;Trigger SourceName=&quot;Popup&quot; Property=&quot;Popup.AllowsTransparency&quot; Value=&quot;true&quot;&gt;
                            &lt;Setter TargetName=&quot;DropDownBorder&quot; Property=&quot;CornerRadius&quot; Value=&quot;4&quot;/&gt;
                            &lt;Setter TargetName=&quot;DropDownBorder&quot; Property=&quot;Margin&quot; Value=&quot;0,2,0,0&quot;/&gt;
                        &lt;/Trigger&gt;
                        &lt;Trigger Property=&quot;IsEditable&quot;
               Value=&quot;true&quot;&gt;
                            &lt;Setter Property=&quot;IsTabStop&quot; Value=&quot;false&quot;/&gt;
                            &lt;Setter TargetName=&quot;PART_EditableTextBox&quot; Property=&quot;Visibility&quot;    Value=&quot;Visible&quot;/&gt;
                            &lt;Setter TargetName=&quot;ContentSite&quot; Property=&quot;Visibility&quot; Value=&quot;Hidden&quot;/&gt;
                        &lt;/Trigger&gt;
                    &lt;/ControlTemplate.Triggers&gt;
                &lt;/ControlTemplate&gt;
            &lt;/Setter.Value&gt;
        &lt;/Setter&gt;
        &lt;Style.Triggers&gt;
        &lt;/Style.Triggers&gt;
    &lt;/Style&gt;
&lt;/ResourceDictionary&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style=""><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Set the suggested source for the <span class="SpellE">
<b style="">AutoCompleteTextBox</b></span><b style="">.</b> </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Sub ConstructAutoCompletionSource()


    Me.textBox.AutoSuggestionList.Add(&quot;Hello world&quot;)
    Me.textBox.AutoSuggestionList.Add(&quot;Hey buddy&quot;)
    Me.textBox.AutoSuggestionList.Add(&quot;Halo world&quot;)
    Me.textBox.AutoSuggestionList.Add(&quot;apple&quot;)
    Me.textBox.AutoSuggestionList.Add(&quot;apple tree&quot;)
    Me.textBox.AutoSuggestionList.Add(&quot;appaaaaa&quot;)
    Me.textBox.AutoSuggestionList.Add(&quot;arrange&quot;)
    For i As Integer = 0 To 99
        Me.textBox.AutoSuggestionList.Add(&quot;AA&quot; & i)
    Next
End Sub

</pre>
<pre id="codePreview" class="vb">
Private Sub ConstructAutoCompletionSource()


    Me.textBox.AutoSuggestionList.Add(&quot;Hello world&quot;)
    Me.textBox.AutoSuggestionList.Add(&quot;Hey buddy&quot;)
    Me.textBox.AutoSuggestionList.Add(&quot;Halo world&quot;)
    Me.textBox.AutoSuggestionList.Add(&quot;apple&quot;)
    Me.textBox.AutoSuggestionList.Add(&quot;apple tree&quot;)
    Me.textBox.AutoSuggestionList.Add(&quot;appaaaaa&quot;)
    Me.textBox.AutoSuggestionList.Add(&quot;arrange&quot;)
    For i As Integer = 0 To 99
        Me.textBox.AutoSuggestionList.Add(&quot;AA&quot; & i)
    Next
End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>More Information<span style=""> </span></h2>
<p class="MsoNormal"><span style="">ComboBox Class</span><span style=""> </span>
</p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/system.windows.controls.combobox.aspx">http://msdn.microsoft.com/en-us/library/system.windows.controls.combobox.aspx</a>
</span></p>
<p class="MsoNormal"><span style="">FrameworkElement.OnApplyTemplate Method </span>
</p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/system.windows.frameworkelement.onapplytemplate.aspx">http://msdn.microsoft.com/en-us/library/system.windows.frameworkelement.onapplytemplate.aspx</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

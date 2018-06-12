# Implement auto-complete textbox in WPF (CSWPFAutoCompleteTextBox)
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
* 2012-03-11 06:50:47
## Description

<h1><span style="">Implement auto-complete textbox in WPF (<span class="SpellE">CSWPFAutoCompl</span>&#8203;<span class="SpellE">eteTextBox</span>)
</span></h1>
<h2>Introduction</h2>
<p class="MsoNormal">This example demonstrates how to achieve <span class="SpellE">
<b style="">AutoCompleteTextBox</b></span> in WPF Application.<span style=""> </span>
</p>
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
<p class="MsoNormal"><span style=""><img src="/site/view/file/54151/1/image.png" alt="" width="375" height="365" align="middle">
</span><span style=""></span></p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoListParagraph" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Design the <span class="SpellE"><b style="">AutoCompleteEntry</b></span> class which is used to represent a suggested item.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
/// Extended ComboBox Item
/// &lt;/summary&gt;
public class AutoCompleteEntry : ComboBoxItem
{
    private TextBlock tbEntry;


    //text of the item
    private string text;


    /// &lt;summary&gt;
    /// Contrutor of AutoCompleteEntry class
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;text&quot;&gt;All the Text of the item &lt;/param&gt;
    /// &lt;param name=&quot;bold&quot;&gt;The already entered part of the Text&lt;/param&gt;
    /// &lt;param name=&quot;unbold&quot;&gt;The remained part of the Text&lt;/param&gt;
    public AutoCompleteEntry(string text, string bold, string unbold)
    {
        this.text = text;
        tbEntry = new TextBlock();
        //highlight the current input Text
        tbEntry.Inlines.Add(new Run { Text = bold, FontWeight = FontWeights.Bold,
            Foreground = new SolidColorBrush(Colors.RoyalBlue) });
        tbEntry.Inlines.Add(new Run { Text = unbold });
        this.Content = tbEntry;
    }


    /// &lt;summary&gt;
    /// Gets the text.
    /// &lt;/summary&gt;
    public string Text
    {
        get { return this.text; }
    }
}

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
/// Extended ComboBox Item
/// &lt;/summary&gt;
public class AutoCompleteEntry : ComboBoxItem
{
    private TextBlock tbEntry;


    //text of the item
    private string text;


    /// &lt;summary&gt;
    /// Contrutor of AutoCompleteEntry class
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;text&quot;&gt;All the Text of the item &lt;/param&gt;
    /// &lt;param name=&quot;bold&quot;&gt;The already entered part of the Text&lt;/param&gt;
    /// &lt;param name=&quot;unbold&quot;&gt;The remained part of the Text&lt;/param&gt;
    public AutoCompleteEntry(string text, string bold, string unbold)
    {
        this.text = text;
        tbEntry = new TextBlock();
        //highlight the current input Text
        tbEntry.Inlines.Add(new Run { Text = bold, FontWeight = FontWeights.Bold,
            Foreground = new SolidColorBrush(Colors.RoyalBlue) });
        tbEntry.Inlines.Add(new Run { Text = unbold });
        this.Content = tbEntry;
    }


    /// &lt;summary&gt;
    /// Gets the text.
    /// &lt;/summary&gt;
    public string Text
    {
        get { return this.text; }
    }
}

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
/// Achieve AutoComplete TextBox or ComboBox
/// &lt;/summary&gt;
public class AutoCompleteTextBox : ComboBox
{
    /// &lt;summary&gt;
    /// Initializes a new instance of the &lt;see cref=&quot;AutoCompleteTextBox&quot;/&gt; class.
    /// &lt;/summary&gt;
    public AutoCompleteTextBox()
    {
        //load and apply style to the ComboBox.
        ResourceDictionary rd = new ResourceDictionary();
        rd.Source = new Uri(&quot;/&quot; &#43; this.GetType().Assembly.GetName().Name &#43; 
            &quot;;component/UserControls/AutoCompleteComboBoxStyle.xaml&quot;,
             UriKind.Relative);
        this.Resources = rd;
        //disable default Text Search Function
        this.IsTextSearchEnabled = false;
    }
 
    /// &lt;summary&gt;
    /// override OnApplyTemplate method 
    /// get TextBox control out of Combobox control, and hook up TextChanged event.
    /// &lt;/summary&gt;
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        //get the textbox control in the ComboBox control
        TextBox textBox = this.Template.FindName(&quot;PART_EditableTextBox&quot;, this) as TextBox;
        if (textBox != null)
        {
            //disable Autoword selection of the TextBox
            textBox.AutoWordSelection = false;
            //handle TextChanged event to dynamically add Combobox items.
            textBox.TextChanged &#43;= new TextChangedEventHandler(textBox_TextChanged);
        }
    }


    //The autosuggestionlist source.
    private ObservableCollection&lt;string&gt; autoSuggestionList = new ObservableCollection&lt;string&gt;();


    /// &lt;summary&gt;
    /// Gets or sets the auto suggestion list.
    /// &lt;/summary&gt;
    /// &lt;value&gt;The auto suggestion list.&lt;/value&gt;
    public ObservableCollection&lt;string&gt; AutoSuggestionList
    {
        get { return autoSuggestionList; }
        set { autoSuggestionList = value; }
    }


  
    /// &lt;summary&gt;
    /// main logic to generate auto suggestion list.
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;sender&quot;&gt;The source of the event.&lt;/param&gt;
    /// &lt;param name=&quot;e&quot;&gt;The &lt;see cref=&quot;System.Windows.Controls.TextChangedEventArgs&quot;/&gt; 
    /// instance containing the event data.&lt;/param&gt;
    void textBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        textBox.AutoWordSelection = false;
        // if the word in the textbox is selected, then don't change item collection
        if ((textBox.SelectionStart != 0 || textBox.Text.Length==0))
        {
            this.Items.Clear();
            //add new filtered items according the current TextBox input
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                foreach (string s in this.autoSuggestionList)
                {
                    if (s.StartsWith(textBox.Text, StringComparison.InvariantCultureIgnoreCase))
                    {


                        string unboldpart = s.Substring(textBox.Text.Length);
                        string boldpart = s.Substring(0, textBox.Text.Length);
                        //construct AutoCompleteEntry and add to the ComboBox
                        AutoCompleteEntry entry = new AutoCompleteEntry(s, boldpart, unboldpart);
                        this.Items.Add(entry);
                    }
                }
            }
        }
        // open or close dropdown of the ComboBox according to whether there are items in the 
        // fitlered result.
        this.IsDropDownOpen = this.HasItems;


        //avoid auto selection
        textBox.Focus();
        textBox.SelectionStart = textBox.Text.Length;


    }
}

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
/// Achieve AutoComplete TextBox or ComboBox
/// &lt;/summary&gt;
public class AutoCompleteTextBox : ComboBox
{
    /// &lt;summary&gt;
    /// Initializes a new instance of the &lt;see cref=&quot;AutoCompleteTextBox&quot;/&gt; class.
    /// &lt;/summary&gt;
    public AutoCompleteTextBox()
    {
        //load and apply style to the ComboBox.
        ResourceDictionary rd = new ResourceDictionary();
        rd.Source = new Uri(&quot;/&quot; &#43; this.GetType().Assembly.GetName().Name &#43; 
            &quot;;component/UserControls/AutoCompleteComboBoxStyle.xaml&quot;,
             UriKind.Relative);
        this.Resources = rd;
        //disable default Text Search Function
        this.IsTextSearchEnabled = false;
    }
 
    /// &lt;summary&gt;
    /// override OnApplyTemplate method 
    /// get TextBox control out of Combobox control, and hook up TextChanged event.
    /// &lt;/summary&gt;
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        //get the textbox control in the ComboBox control
        TextBox textBox = this.Template.FindName(&quot;PART_EditableTextBox&quot;, this) as TextBox;
        if (textBox != null)
        {
            //disable Autoword selection of the TextBox
            textBox.AutoWordSelection = false;
            //handle TextChanged event to dynamically add Combobox items.
            textBox.TextChanged &#43;= new TextChangedEventHandler(textBox_TextChanged);
        }
    }


    //The autosuggestionlist source.
    private ObservableCollection&lt;string&gt; autoSuggestionList = new ObservableCollection&lt;string&gt;();


    /// &lt;summary&gt;
    /// Gets or sets the auto suggestion list.
    /// &lt;/summary&gt;
    /// &lt;value&gt;The auto suggestion list.&lt;/value&gt;
    public ObservableCollection&lt;string&gt; AutoSuggestionList
    {
        get { return autoSuggestionList; }
        set { autoSuggestionList = value; }
    }


  
    /// &lt;summary&gt;
    /// main logic to generate auto suggestion list.
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;sender&quot;&gt;The source of the event.&lt;/param&gt;
    /// &lt;param name=&quot;e&quot;&gt;The &lt;see cref=&quot;System.Windows.Controls.TextChangedEventArgs&quot;/&gt; 
    /// instance containing the event data.&lt;/param&gt;
    void textBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        textBox.AutoWordSelection = false;
        // if the word in the textbox is selected, then don't change item collection
        if ((textBox.SelectionStart != 0 || textBox.Text.Length==0))
        {
            this.Items.Clear();
            //add new filtered items according the current TextBox input
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                foreach (string s in this.autoSuggestionList)
                {
                    if (s.StartsWith(textBox.Text, StringComparison.InvariantCultureIgnoreCase))
                    {


                        string unboldpart = s.Substring(textBox.Text.Length);
                        string boldpart = s.Substring(0, textBox.Text.Length);
                        //construct AutoCompleteEntry and add to the ComboBox
                        AutoCompleteEntry entry = new AutoCompleteEntry(s, boldpart, unboldpart);
                        this.Items.Add(entry);
                    }
                }
            }
        }
        // open or close dropdown of the ComboBox according to whether there are items in the 
        // fitlered result.
        this.IsDropDownOpen = this.HasItems;


        //avoid auto selection
        textBox.Focus();
        textBox.SelectionStart = textBox.Text.Length;


    }
}

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
                      xmlns:local=&quot;clr-namespace:CSWPFAutoCompleteTextBox.UserControls&quot;
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
                      xmlns:local=&quot;clr-namespace:CSWPFAutoCompleteTextBox.UserControls&quot;
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
<a name="OLE_LINK1"></a><a name="OLE_LINK2"><span style=""><span style="color:green">&lt;!--Brush</span></span></a>
<p class="MsoListParagraphCxSpFirst"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style=""><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Set the suggested source for the <span class="SpellE">
<b style="">AutoCompleteTextBox</b></span><b style="">.</b> </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
/// &lt;summary&gt;
/// Constructs the auto completion source.
/// &lt;/summary&gt;
private void ConstructAutoCompletionSource()
{
    
    this.textBox.AutoSuggestionList.Add(&quot;Hello world&quot;);
    this.textBox.AutoSuggestionList.Add(&quot;Hey buddy&quot;);
    this.textBox.AutoSuggestionList.Add(&quot;Halo world&quot;);
    this.textBox.AutoSuggestionList.Add(&quot;apple&quot;);
    this.textBox.AutoSuggestionList.Add(&quot;apple tree&quot;);
    this.textBox.AutoSuggestionList.Add(&quot;appaaaaa&quot;);
    this.textBox.AutoSuggestionList.Add(&quot;arrange&quot;);
    for (int i = 0; i &lt; 100; i&#43;&#43;)
    {
        this.textBox.AutoSuggestionList.Add(&quot;AA&quot; &#43; i);
    }
}

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
/// Constructs the auto completion source.
/// &lt;/summary&gt;
private void ConstructAutoCompletionSource()
{
    
    this.textBox.AutoSuggestionList.Add(&quot;Hello world&quot;);
    this.textBox.AutoSuggestionList.Add(&quot;Hey buddy&quot;);
    this.textBox.AutoSuggestionList.Add(&quot;Halo world&quot;);
    this.textBox.AutoSuggestionList.Add(&quot;apple&quot;);
    this.textBox.AutoSuggestionList.Add(&quot;apple tree&quot;);
    this.textBox.AutoSuggestionList.Add(&quot;appaaaaa&quot;);
    this.textBox.AutoSuggestionList.Add(&quot;arrange&quot;);
    for (int i = 0; i &lt; 100; i&#43;&#43;)
    {
        this.textBox.AutoSuggestionList.Add(&quot;AA&quot; &#43; i);
    }
}

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
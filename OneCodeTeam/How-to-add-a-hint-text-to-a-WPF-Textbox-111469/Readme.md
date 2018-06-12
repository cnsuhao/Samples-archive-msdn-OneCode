# How to add a hint text to a WPF Textbox
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* WPF
* .NET Framework
* Windows Desktop App Development
## Topics
* TextBox
* hint text
## IsPublished
* True
## ModifiedDate
* 2015-01-04 07:12:01
## Description

<h1>
<hr>
<div><a href="http://blogs.msdn.com/b/onecode"><img src="http://bit.ly/onecodesampletopbanner" alt=""></a></div>
</h1>
<h1>The project illustrates how to add a hint text to a WPF Textbox</h1>
<h2>Introduction</h2>
<p>The project illustrates how to add hint text to a WPF textbox, which will act as a formal note for the control.</p>
<p>Lots of developers ask about this in the MSDN forums, so we created the code sample to address the frequently asked programming scenario.</p>
<p>1. Textbox Hints?</p>
<p><a href="http://social.msdn.microsoft.com/Forums/en-US/e6c6fea0-faba-440a-9e21-2e7baee52df0/textbox-hints?forum=wpf">http://social.msdn.microsoft.com/Forums/en-US/e6c6fea0-faba-440a-9e21-2e7baee52df0/textbox-hints?forum=wpf</a></p>
<p>&nbsp;</p>
<p>2. Textbox display hint info</p>
<p><a href="http://social.msdn.microsoft.com/Forums/en-US/37abab21-ac9f-4aa2-a073-0e363576ad5d/textbox-display-hint-info?forum=silverlightcontrols">http://social.msdn.microsoft.com/Forums/en-US/37abab21-ac9f-4aa2-a073-0e363576ad5d/textbox-display-hint-info?forum=silverlightcontrols</a></p>
<p>&nbsp;</p>
<p>3. How can I add a hint text to WPF textbox?</p>
<p><a href="http://stackoverflow.com/questions/7425618/how-can-i-add-a-hint-text-to-wpf-textbox?lq=1">http://stackoverflow.com/questions/7425618/how-can-i-add-a-hint-text-to-wpf-textbox?lq=1</a></p>
<p>&nbsp;</p>
<h2>Building the Project</h2>
<p><strong>Creating a WPF Application (CSAddHintText2Textbox)</strong></p>
<ol>
<li>In the Visual Studio 2012, create a WPF Application </li><li>Implement a converter class that implements IMultiValueConverter </li></ol>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)

        {

            // Test for non-null

            if (values[0] is bool &amp;&amp; values[1] is bool)

            {

                bool hasText = !(bool)values[0];

                bool hasFocus = (bool)values[1];

 

                if (hasFocus || hasText)

                    return Visibility.Collapsed;

            }

 

            return Visibility.Visible;

         }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;Convert(<span class="cs__keyword">object</span>[]&nbsp;values,&nbsp;Type&nbsp;targetType,&nbsp;<span class="cs__keyword">object</span>&nbsp;parameter,&nbsp;System.Globalization.CultureInfo&nbsp;culture)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Test&nbsp;for&nbsp;non-null</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(values[<span class="cs__number">0</span>]&nbsp;<span class="cs__keyword">is</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;&amp;&amp;&nbsp;values[<span class="cs__number">1</span>]&nbsp;<span class="cs__keyword">is</span>&nbsp;<span class="cs__keyword">bool</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;hasText&nbsp;=&nbsp;!(<span class="cs__keyword">bool</span>)values[<span class="cs__number">0</span>];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;hasFocus&nbsp;=&nbsp;(<span class="cs__keyword">bool</span>)values[<span class="cs__number">1</span>];&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(hasFocus&nbsp;||&nbsp;hasText)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Visibility.Collapsed;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Visibility.Visible;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<p>3. &nbsp;The XAML file will ensure the UI operations</p>
<pre><div class="scriptcode"><div class="pluginEditHolder" pluginCommand="mceScriptCode"><div class="title"><span>XAML</span></div><div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div><span class="hidden">xaml</span><pre class="hidden">&lt;Window.Resources&gt;

        &lt;SolidColorBrush x:Key=&quot;brushWatermarkBackground&quot; Color=&quot;White&quot; /&gt;

        &lt;SolidColorBrush x:Key=&quot;brushWatermarkForeground&quot; Color=&quot;LightSteelBlue&quot; /&gt;

        &lt;SolidColorBrush x:Key=&quot;brushWatermarkBorder&quot; Color=&quot;Indigo&quot; /&gt;

 

        &lt;BooleanToVisibilityConverter x:Key=&quot;BooleanToVisibilityConverter&quot; /&gt;

        &lt;local:TextInputToVisibilityConverter x:Key=&quot;TextInputToVisibilityConverter&quot; /&gt;

 

        &lt;Style x:Key=&quot;EntryFieldStyle&quot; TargetType=&quot;Grid&quot;&gt;

            &lt;Setter Property=&quot;HorizontalAlignment&quot; Value=&quot;Stretch&quot; /&gt;

            &lt;Setter Property=&quot;VerticalAlignment&quot; Value=&quot;Center&quot; /&gt;

            &lt;Setter Property=&quot;Margin&quot; Value=&quot;20,0&quot;/&gt;

        &lt;/Style&gt;

    &lt;/Window.Resources&gt;

&lt;Grid Grid.Row=&quot;0&quot; Background=&quot;{StaticResource brushWatermarkBackground}&quot; Style=&quot;{StaticResource EntryFieldStyle}&quot; &gt;

            &lt;TextBlock Margin=&quot;5,2&quot; Text=&quot;This prompt dissappears as you type...&quot; Foreground=&quot;{StaticResource brushWatermarkForeground}&quot;

                       Visibility=&quot;{Binding ElementName=txtUserEntry, Path=Text.IsEmpty, Converter={StaticResource BooleanToVisibilityConverter}}&quot; /&gt;

            &lt;TextBox Name=&quot;txtUserEntry&quot; Background=&quot;Transparent&quot; BorderBrush=&quot;{StaticResource brushWatermarkBorder}&quot; /&gt;

        &lt;/Grid&gt;

 

        &lt;Grid Grid.Row=&quot;1&quot; Background=&quot;{StaticResource brushWatermarkBackground}&quot; Style=&quot;{StaticResource EntryFieldStyle}&quot; &gt;

            &lt;TextBlock Margin=&quot;5,2&quot; Text=&quot;This dissappears as the control gets focus...&quot; Foreground=&quot;{StaticResource brushWatermarkForeground}&quot; &gt;

                &lt;TextBlock.Visibility&gt;

                    &lt;MultiBinding Converter=&quot;{StaticResource TextInputToVisibilityConverter}&quot;&gt;

                        &lt;Binding ElementName=&quot;txtUserEntry2&quot; Path=&quot;Text.IsEmpty&quot; /&gt;

                        &lt;Binding ElementName=&quot;txtUserEntry2&quot; Path=&quot;IsFocused&quot; /&gt;

                    &lt;/MultiBinding&gt;

                &lt;/TextBlock.Visibility&gt;

            &lt;/TextBlock&gt;

            &lt;TextBox Name=&quot;txtUserEntry2&quot; Background=&quot;Transparent&quot; BorderBrush=&quot;{StaticResource brushWatermarkBorder}&quot; /&gt;

        &lt;/Grid&gt;</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Window</span>.Resources<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;SolidColorBrush</span>&nbsp;x:<span class="xaml__attr_name">Key</span>=<span class="xaml__attr_value">&quot;brushWatermarkBackground&quot;</span>&nbsp;<span class="xaml__attr_name">Color</span>=<span class="xaml__attr_value">&quot;White&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;SolidColorBrush</span>&nbsp;x:<span class="xaml__attr_name">Key</span>=<span class="xaml__attr_value">&quot;brushWatermarkForeground&quot;</span>&nbsp;<span class="xaml__attr_name">Color</span>=<span class="xaml__attr_value">&quot;LightSteelBlue&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;SolidColorBrush</span>&nbsp;x:<span class="xaml__attr_name">Key</span>=<span class="xaml__attr_value">&quot;brushWatermarkBorder&quot;</span>&nbsp;<span class="xaml__attr_name">Color</span>=<span class="xaml__attr_value">&quot;Indigo&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;BooleanToVisibilityConverter</span>&nbsp;x:<span class="xaml__attr_name">Key</span>=<span class="xaml__attr_value">&quot;BooleanToVisibilityConverter&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;local</span>:TextInputToVisibilityConverter&nbsp;x:<span class="xaml__attr_name">Key</span>=<span class="xaml__attr_value">&quot;TextInputToVisibilityConverter&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Style</span>&nbsp;x:<span class="xaml__attr_name">Key</span>=<span class="xaml__attr_value">&quot;EntryFieldStyle&quot;</span>&nbsp;<span class="xaml__attr_name">TargetType</span>=<span class="xaml__attr_value">&quot;Grid&quot;</span><span class="xaml__tag_start">&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">Setter</span>&nbsp;<span class="css__element">Property</span>=&quot;<span class="css__element">HorizontalAlignment</span>&quot;&nbsp;<span class="css__element">Value</span>=&quot;<span class="css__element">Stretch</span>&quot;&nbsp;/&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">Setter</span>&nbsp;<span class="css__element">Property</span>=&quot;<span class="css__element">VerticalAlignment</span>&quot;&nbsp;<span class="css__element">Value</span>=&quot;<span class="css__element">Center</span>&quot;&nbsp;/&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">Setter</span>&nbsp;<span class="css__element">Property</span>=&quot;<span class="css__element">Margin</span>&quot;&nbsp;<span class="css__element">Value</span>=&quot;<span class="css__element">20</span>,<span class="css__element">0</span>&quot;/&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Style&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Window.Resources&gt;&nbsp;
&nbsp;
<span class="xaml__tag_start">&lt;Grid</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;brushWatermarkBackground}&quot;</span>&nbsp;<span class="xaml__attr_name">Style</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;EntryFieldStyle}&quot;</span>&nbsp;<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;5,2&quot;</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;This&nbsp;prompt&nbsp;dissappears&nbsp;as&nbsp;you&nbsp;type...&quot;</span>&nbsp;<span class="xaml__attr_name">Foreground</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;brushWatermarkForeground}&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Visibility</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;ElementName=txtUserEntry,&nbsp;Path=Text.IsEmpty,&nbsp;Converter={StaticResource&nbsp;BooleanToVisibilityConverter}}&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBox</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;txtUserEntry&quot;</span>&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;Transparent&quot;</span>&nbsp;<span class="xaml__attr_name">BorderBrush</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;brushWatermarkBorder}&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;brushWatermarkBackground}&quot;</span>&nbsp;<span class="xaml__attr_name">Style</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;EntryFieldStyle}&quot;</span>&nbsp;<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;5,2&quot;</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;This&nbsp;dissappears&nbsp;as&nbsp;the&nbsp;control&nbsp;gets&nbsp;focus...&quot;</span>&nbsp;<span class="xaml__attr_name">Foreground</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;brushWatermarkForeground}&quot;</span>&nbsp;<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>.Visibility<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;MultiBinding</span>&nbsp;<span class="xaml__attr_name">Converter</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;TextInputToVisibilityConverter}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Binding</span>&nbsp;<span class="xaml__attr_name">ElementName</span>=<span class="xaml__attr_value">&quot;txtUserEntry2&quot;</span>&nbsp;<span class="xaml__attr_name">Path</span>=<span class="xaml__attr_value">&quot;Text.IsEmpty&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Binding</span>&nbsp;<span class="xaml__attr_name">ElementName</span>=<span class="xaml__attr_value">&quot;txtUserEntry2&quot;</span>&nbsp;<span class="xaml__attr_name">Path</span>=<span class="xaml__attr_value">&quot;IsFocused&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/MultiBinding&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/TextBlock.Visibility&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/TextBlock&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBox</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;txtUserEntry2&quot;</span>&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;Transparent&quot;</span>&nbsp;<span class="xaml__attr_name">BorderBrush</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;brushWatermarkBorder}&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</pre>
<h2>Running the Sample</h2>
<p><span style="font-size:10px">1. This sample has two text boxes</span></p>
<p><span style="font-size:10px"><span style="white-space:pre"></span>a.&nbsp;The hint will disappear on typing in the 1</span><sup>st</sup><span style="font-size:10px"> textbox</span></p>
<p><span style="font-size:10px"><span style="white-space:pre"></span>b.&nbsp;The hint will disappear on selection of the 2</span><sup>nd</sup><span style="font-size:10px"> textbox</span></p>
<p><span style="font-size:10px">2. Sharing the sample data by its operations:</span></p>
<ol>
</ol>
<p>&nbsp;<img id="132002" src="/site/view/file/132002/1/image001.png" alt="" width="527" height="346"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>

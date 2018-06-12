# How to bind enum to RadioButtons
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Windows
* Windows 8
* Windows Store app Development
## Topics
* windows8
## IsPublished
* True
## ModifiedDate
* 2013-06-13 10:13:51
## Description

<h1><span style="">How to bind enum to RadioButton (CSWindowsStoreAppBindEnumToRadioButton)
</span></h1>
<h2>Introduction</h2>
<p class="MsoNormal">The Customer class in this sample contains a 'Sport' enum type property; the sample shows how to convert Enum type To Boolean type, and vice versa. It also shows how to bind the enum type to RadioButtons.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal"></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Start Visual Studio Express&nbsp;2012 for Windows&nbsp;8 and select&nbsp;File&nbsp;&gt;&nbsp;Open&nbsp;&gt;&nbsp;Project/Solution.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Go to the directory in which you unzipped the sample. Go to the directory named for the sample, and double-click the Visual Studio Express&nbsp;2012 for Windows&nbsp;8 Solution (.sln) file.</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press F6 or use&nbsp;Build&nbsp;&gt;&nbsp;Build Solution&nbsp;to build the sample.</p>
<p class="MsoListParagraphCxSpLast"></p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>After launching the sample, this screen will display.</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/84374/1/image.png" alt="" width="576" height="326" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle"></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Please select one of the items in GridView through right click or swipe, then click 'Edit' button in bottom Appbar, the edit page will display. Please check the Sport enum is bound to RadioButtons. You can select other RadioButton selections
 and click 'Save' button in bottom <span class="SpellE">Appbar</span>.</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/84375/1/image.png" alt="" width="576" height="328" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle"></p>
<p class="MsoListParagraphCxSpLast"></p>
<h2>Using the Code</h2>
<p class="MsoNormal">The code below shows how to create EnumToBoolConverter:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public class EnumToBoolConverter : IValueConverter
   {
       public object Convert(object value, Type targetType, object parameter, string language)
       {
           string param = parameter as string;
           if (param == null)
               return DependencyProperty.UnsetValue;
           if (Enum.IsDefined(value.GetType(), value) == false)
               return DependencyProperty.UnsetValue;


           object paramValue = Enum.Parse(value.GetType(), param);
           return paramValue.Equals(value);
       }


       public object ConvertBack(object value, Type targetType, object parameter, string language)
       {
           string param = parameter as string;
           if (parameter == null)
               return DependencyProperty.UnsetValue;


           return Enum.Parse(typeof(Sport), param);
       }
   }

</pre>
<pre id="codePreview" class="csharp">
public class EnumToBoolConverter : IValueConverter
   {
       public object Convert(object value, Type targetType, object parameter, string language)
       {
           string param = parameter as string;
           if (param == null)
               return DependencyProperty.UnsetValue;
           if (Enum.IsDefined(value.GetType(), value) == false)
               return DependencyProperty.UnsetValue;


           object paramValue = Enum.Parse(value.GetType(), param);
           return paramValue.Equals(value);
       }


       public object ConvertBack(object value, Type targetType, object parameter, string language)
       {
           string param = parameter as string;
           if (parameter == null)
               return DependencyProperty.UnsetValue;


           return Enum.Parse(typeof(Sport), param);
       }
   }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal">The code below shows the binding in xaml:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xaml</span>
<pre class="hidden">
&lt;StackPanel Grid.Row=&quot;3&quot; Grid.Column=&quot;1&quot; HorizontalAlignment=&quot;Left&quot; VerticalAlignment=&quot;Top&quot; Margin=&quot;0,15,0,0&quot;&gt;
                            &lt;RadioButton IsChecked=&quot;{Binding Path=FavouriteSport,Converter={StaticResource ETBConverter},ConverterParameter=Basketball, Mode=TwoWay}&quot; FontSize=&quot;25&quot; Margin=&quot;0,0,0,10&quot;&gt;Basketball&lt;/RadioButton&gt;
                            &lt;RadioButton IsChecked=&quot;{Binding Path=FavouriteSport,Converter={StaticResource ETBConverter},ConverterParameter=Football, Mode=TwoWay}&quot; FontSize=&quot;25&quot; Margin=&quot;0,0,0,10&quot;&gt;Football&lt;/RadioButton&gt;
                            &lt;RadioButton IsChecked=&quot;{Binding Path=FavouriteSport,Converter={StaticResource ETBConverter},ConverterParameter=Baseball, Mode=TwoWay}&quot; FontSize=&quot;25&quot; Margin=&quot;0,0,0,10&quot;&gt;Baseball&lt;/RadioButton&gt;
                            &lt;RadioButton IsChecked=&quot;{Binding Path=FavouriteSport,Converter={StaticResource ETBConverter},ConverterParameter=Swimming, Mode=TwoWay}&quot; FontSize=&quot;25&quot; Margin=&quot;0,0,0,10&quot;&gt;Swimming&lt;/RadioButton&gt;
                        &lt;/StackPanel&gt;

</pre>
<pre id="codePreview" class="xaml">
&lt;StackPanel Grid.Row=&quot;3&quot; Grid.Column=&quot;1&quot; HorizontalAlignment=&quot;Left&quot; VerticalAlignment=&quot;Top&quot; Margin=&quot;0,15,0,0&quot;&gt;
                            &lt;RadioButton IsChecked=&quot;{Binding Path=FavouriteSport,Converter={StaticResource ETBConverter},ConverterParameter=Basketball, Mode=TwoWay}&quot; FontSize=&quot;25&quot; Margin=&quot;0,0,0,10&quot;&gt;Basketball&lt;/RadioButton&gt;
                            &lt;RadioButton IsChecked=&quot;{Binding Path=FavouriteSport,Converter={StaticResource ETBConverter},ConverterParameter=Football, Mode=TwoWay}&quot; FontSize=&quot;25&quot; Margin=&quot;0,0,0,10&quot;&gt;Football&lt;/RadioButton&gt;
                            &lt;RadioButton IsChecked=&quot;{Binding Path=FavouriteSport,Converter={StaticResource ETBConverter},ConverterParameter=Baseball, Mode=TwoWay}&quot; FontSize=&quot;25&quot; Margin=&quot;0,0,0,10&quot;&gt;Baseball&lt;/RadioButton&gt;
                            &lt;RadioButton IsChecked=&quot;{Binding Path=FavouriteSport,Converter={StaticResource ETBConverter},ConverterParameter=Swimming, Mode=TwoWay}&quot; FontSize=&quot;25&quot; Margin=&quot;0,0,0,10&quot;&gt;Swimming&lt;/RadioButton&gt;
                        &lt;/StackPanel&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoNormal">IValueConverter Interface</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/apps/BR209903">http://msdn.microsoft.com/en-us/library/windows/apps/BR209903</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

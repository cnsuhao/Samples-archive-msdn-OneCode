# How to display Enum in WPF ComboxBox
## Requires
* 
## License
* Apache License, Version 2.0
## Technologies
* .NET Development
* Windows Presentation Framework (WPF)
## Topics
* ComboBox
* Enum
* code snippets
## IsPublished
* True
## ModifiedDate
* 2014-05-05 12:10:28
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:24pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:14pt"><span style="font-weight:bold; font-size:14pt">How to display Enum in WPF ComboBox</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Introduction</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="color:#000000">This code snippet demonstrates how to
</span><a name="OLE_LINK1"></a><a name="OLE_LINK2"></a><span style="color:#000000">display friendly name</span><span style="color:#000000">s</span><span style="color:#000000"> in ComboBox from Enum</span><span style="color:#000000">.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">Using the Code</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="color:#000000">&nbsp;</span><span style="color:#000000">Here we will show a combobox
</span><span style="color:#000000">that </span><span style="color:#000000">includes 3 program</span><span style="color:#000000">ming</span><span style="color:#000000"> languages: C&#43;&#43;, C# and F#. But
</span><span style="color:#000000">we store these languages with </span><span style="color:#000000">other n</span><span style="color:#000000">ame</span><span style="color:#000000">s</span><a name="_GoBack"></a><span style="color:#000000"> in enum: CPlusPlus,
 CSharp and FSharp</span><span style="color:#000000">. So we need convert these names.</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="color:#000000">&nbsp;</span><span style="color:#000000">We use an ObjectDataProvider as the ItemsSource for the Combobox</span><span style="color:#000000">,</span><span style="color:#000000"> and use IValueConverter
 to convert the items' names. </span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span style="color:#000000">In the XAML code, we define 2 resources and respectively apply to the item Source and item Converter. The ExampleConverter is a class which implements IValueConverter interface.</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Window x:Class=&quot;WpfApplication1.MainWindow&quot;
        xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
        xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
        xmlns:sys=&quot;clr-namespace:System;assembly=mscorlib&quot;
        xmlns:WpfApplication1=&quot;clr-namespace:WpfApplication1&quot;
        Title=&quot;MainWindow&quot; Height=&quot;350&quot; Width=&quot;525&quot;&gt;
    &lt;Window.Resources&gt;
        &lt;ObjectDataProvider MethodName=&quot;GetNames&quot;
        ObjectType=&quot;{x:Type sys:Enum}&quot;
        x:Key=&quot;exampleEnumValues&quot;&gt;
            &lt;ObjectDataProvider.MethodParameters&gt;
                &lt;x:Type TypeName=&quot;WpfApplication1:ProgramLanguage&quot; /&gt;
            &lt;/ObjectDataProvider.MethodParameters&gt;
        &lt;/ObjectDataProvider&gt;
        &lt;WpfApplication1:ExampleConverter x:Key=&quot;exampleConverter&quot;/&gt;
    &lt;/Window.Resources&gt;
    &lt;Grid&gt;
        &lt;ComboBox  ItemsSource=&quot;{Binding Source={StaticResource exampleEnumValues}, Converter={StaticResource exampleConverter}}&quot;
      Margin=&quot;10,0,10,80&quot; Height=&quot;25&quot; /&gt;
    &lt;/Grid&gt;
&lt;/Window&gt;
</pre>
<pre id="codePreview" class="xaml">&lt;Window x:Class=&quot;WpfApplication1.MainWindow&quot;
        xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
        xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
        xmlns:sys=&quot;clr-namespace:System;assembly=mscorlib&quot;
        xmlns:WpfApplication1=&quot;clr-namespace:WpfApplication1&quot;
        Title=&quot;MainWindow&quot; Height=&quot;350&quot; Width=&quot;525&quot;&gt;
    &lt;Window.Resources&gt;
        &lt;ObjectDataProvider MethodName=&quot;GetNames&quot;
        ObjectType=&quot;{x:Type sys:Enum}&quot;
        x:Key=&quot;exampleEnumValues&quot;&gt;
            &lt;ObjectDataProvider.MethodParameters&gt;
                &lt;x:Type TypeName=&quot;WpfApplication1:ProgramLanguage&quot; /&gt;
            &lt;/ObjectDataProvider.MethodParameters&gt;
        &lt;/ObjectDataProvider&gt;
        &lt;WpfApplication1:ExampleConverter x:Key=&quot;exampleConverter&quot;/&gt;
    &lt;/Window.Resources&gt;
    &lt;Grid&gt;
        &lt;ComboBox  ItemsSource=&quot;{Binding Source={StaticResource exampleEnumValues}, Converter={StaticResource exampleConverter}}&quot;
      Margin=&quot;10,0,10,80&quot; Height=&quot;25&quot; /&gt;
    &lt;/Grid&gt;
&lt;/Window&gt;
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><span>In the code </span><span>below</span><span>, we define the enum and implement IValueConverter interface.
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">public enum ProgramLanguage
    {
        CPlusPlus,
        CSharp,
        FSharp
    };
    public class ExampleConverter : IValueConverter
    {     
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string[] languages = value as string[];
            List&lt;string&gt; result = new List&lt;string&gt;();
            foreach (var item in languages)
            {
                switch (item)
                {
                    case &quot;CPlusPlus&quot;:
                        result.Add(&quot;C&#43;&#43;&quot;);
                        break;
                    case &quot;CSharp&quot;:
                        result.Add(&quot;C#&quot;);
                        break;
                    case &quot;FSharp&quot;:
                        result.Add(&quot;F#&quot;);
                        break;
                }
            }
            return result;
        }
      
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
      
    }
</pre>
<pre class="hidden">Public Enum ProgramLanguage
    CPlusPlus
    CSharp
    FSharp
End Enum
Public Class ExampleConverter
    Implements IValueConverter
 
    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements IValueConverter.Convert
        Dim languages As String() = TryCast(value, String())
        Dim result As New List(Of String)()
        For Each item In languages
            Select Case item
                Case &quot;CPlusPlus&quot;
                    result.Add(&quot;C&#43;&#43;&quot;)
                    Exit Select
                Case &quot;CSharp&quot;
                    result.Add(&quot;C#&quot;)
                    Exit Select
                Case &quot;FSharp&quot;
                    result.Add(&quot;F#&quot;)
                    Exit Select
            End Select
        Next
        Return result
    End Function
    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class
</pre>
<pre id="codePreview" class="csharp">public enum ProgramLanguage
    {
        CPlusPlus,
        CSharp,
        FSharp
    };
    public class ExampleConverter : IValueConverter
    {     
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string[] languages = value as string[];
            List&lt;string&gt; result = new List&lt;string&gt;();
            foreach (var item in languages)
            {
                switch (item)
                {
                    case &quot;CPlusPlus&quot;:
                        result.Add(&quot;C&#43;&#43;&quot;);
                        break;
                    case &quot;CSharp&quot;:
                        result.Add(&quot;C#&quot;);
                        break;
                    case &quot;FSharp&quot;:
                        result.Add(&quot;F#&quot;);
                        break;
                }
            }
            return result;
        }
      
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
      
    }
</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:10pt; margin-bottom:0pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-weight:bold; font-size:13pt"><span style="font-weight:bold; font-size:13pt">More Information</span></span></p>
<p style="margin-left:0pt; margin-right:0pt; margin-top:0pt; margin-bottom:10pt; font-size:10.0pt; line-height:27.6pt; direction:ltr; unicode-bidi:normal">
<span style="font-size:11pt"><a href="http://msdn.microsoft.com/en-us/library/bb613576(v=vs.110).aspx" style="text-decoration:none"><span style="color:#0563c1; text-decoration:underline">How to: Bind to an Enumeration</span></a></span></p>
<p style="line-height:0.6pt; color:white">Microsoft All-In-One Code Framework is a free, centralized code sample library driven by developers' real-world pains and needs. The goal is to provide customer-driven code samples for all Microsoft development technologies,
 and reduce developers' efforts in solving typical programming tasks. Our team listens to developers&rsquo; pains in the MSDN forums, social media and various DEV communities. We write code samples based on developers&rsquo; frequently asked programming tasks,
 and allow developers to download them with a short sample publishing cycle. Additionally, we offer a free code sample request service. It is a proactive way for our developer community to obtain code samples directly from Microsoft.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>

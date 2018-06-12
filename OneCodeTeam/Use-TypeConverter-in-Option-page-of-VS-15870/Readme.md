# Use TypeConverter in Option page of VS (VBVSPackageOptionPageWithTypeConverter)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* VSX
## Topics
* TypeConverter
* Option Page
## IsPublished
* True
## ModifiedDate
* 2012-03-01 11:48:37
## Description

<h1>Use TypeConverter in Option page of VS (<span class="SpellE"><span style="">VB</span>VSPackageOptionPageWithTypeConverter</span>)<span style="">
</span></h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to use TypeConverter in Option Page.<span style="">
</span></p>
<p class="MsoNormal">A type converter can be used to convert values between data types, and to<span style="">
</span>assist property configuration at design time by providing text-to-value<span style="">
</span>conversion or a drop-down list of values to select from.<span style=""> </span>
</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">VS 20<span style="">08</span> SP1 SDK must be installed on the machine. You can download it from:
</p>
<p class="MsoNormal"><span lang="EN" style=""><a href="http://www.microsoft.com/download/en/details.aspx?id=21827">Visual Studio 2008 SDK 1.1</a></span><span lang="EN" style="">
</span></p>
<p class="MsoNormal">Set the Start Action and Start Options of Debug.</p>
<p class="MsoNormal">Start Action: <u>C:\Program Files\Microsoft Visual Studio </u>
<u><span style="">9</span>.0\Common7\IDE\devenv.exe</u> (32bit OS) or <u>C:\Program Files (x86)\Microsoft Visual Studio
</u><u><span style="">9</span>.0\Common7\IDE\devenv.exe</u> (64bit OS)<u> </u></p>
<p class="MsoNormal">Start Option: <u>/<span class="SpellE">ranu</span> /<span class="SpellE">rootsuffix</span>
<span class="SpellE">Exp</span></u></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53280/1/image.png" alt="" width="576" height="404" align="middle">
</span></p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press <b style="">F5</b> to debug this project.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>In the new instance of Visual Studio, click <b style=""><span style="">Tool</span>=&gt;
</b><b style=""><span style="">Options</span></b>, you will see the <span style="">
Options dialog and find <span class="SpellE"><b style="">MyOptionPage</b></span></span>.<span style=""> You can select the value for<b style="">
<span class="SpellE">MyProperty</span>.</b></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/53281/1/image.png" alt="" width="576" height="330" align="middle">
</span></p>
<p class="MsoListParagraphCxSpLast"></p>
<h2>Using the Code</h2>
<p class="MsoListParagraphCxSpFirst" style=""><b style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style="">Create a VS Package Project. </b></p>
<p class="MsoListParagraphCxSpMiddle">Use Visual Studio Integration Package Wizard to create a simple VSPackage project. You can follow the steps in
<a href="http://msdn.microsoft.com/en-us/library/cc138589.aspx">Walkthrough: Creating a VSPackage</a></p>
<p class="MsoListParagraphCxSpLast" style=""><b style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style="">Add a new class file named <span class="SpellE">
OptionsPage.<span style="">vb</span></span> into the project. </b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
'/////////////////////////////////////////////////////////////////////////////
' Define an enum type which will be shown in the Option Page.
' 
Public Enum MyEnumProperty
    None
    First
    Second
    Third
End Enum


'/////////////////////////////////////////////////////////////////////////////
' Create a class named OptionsPage which derived from DialogPage class, add
' a MyEnumProperty property in it.
' 
Friend Class OptionsPage
    Inherits DialogPage
#Region &quot;Fields&quot;
    Private _myProperty As MyEnumProperty = MyEnumProperty.None
#End Region ' Fields


#Region &quot;Properties&quot;
    &lt;Category(&quot;Enum Options&quot;), Description(&quot;My enum option&quot;), TypeConverter(GetType(EnumTypeConverter))&gt; _
    Public Property MyProperty() As MyEnumProperty
        Get
            Return _myProperty
        End Get
        Set(ByVal value As MyEnumProperty)
            _myProperty = value
        End Set
    End Property
#End Region ' Properties
End Class

</pre>
<pre id="codePreview" class="vb">
'/////////////////////////////////////////////////////////////////////////////
' Define an enum type which will be shown in the Option Page.
' 
Public Enum MyEnumProperty
    None
    First
    Second
    Third
End Enum


'/////////////////////////////////////////////////////////////////////////////
' Create a class named OptionsPage which derived from DialogPage class, add
' a MyEnumProperty property in it.
' 
Friend Class OptionsPage
    Inherits DialogPage
#Region &quot;Fields&quot;
    Private _myProperty As MyEnumProperty = MyEnumProperty.None
#End Region ' Fields


#Region &quot;Properties&quot;
    &lt;Category(&quot;Enum Options&quot;), Description(&quot;My enum option&quot;), TypeConverter(GetType(EnumTypeConverter))&gt; _
    Public Property MyProperty() As MyEnumProperty
        Get
            Return _myProperty
        End Get
        Set(ByVal value As MyEnumProperty)
            _myProperty = value
        End Set
    End Property
#End Region ' Properties
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"><b style=""></b></p>
<p class="MsoListParagraphCxSpLast" style=""><b style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">Define the <span class="SpellE">
EnumTypeConverter</span> class.</span> </b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Friend Class EnumTypeConverter
    Inherits EnumConverter
    Public Sub New()
        MyBase.New(GetType(MyEnumProperty))
    End Sub


    Public Overrides Function CanConvertFrom(ByVal context As ITypeDescriptorContext, ByVal sourceType As Type) As Boolean
        If sourceType Is GetType(String) Then
            Return True
        End If


        Return MyBase.CanConvertFrom(context, sourceType)
    End Function


    Public Overrides Function ConvertFrom(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object) As Object
        Dim str As String = TryCast(value, String)


        If str IsNot Nothing Then
            If str = &quot;Beautiful None&quot; Then
                Return MyEnumProperty.None
            End If
            If str = &quot;Beautiful First&quot; Then
                Return MyEnumProperty.First
            End If
            If str = &quot;Beautiful Second&quot; Then
                Return MyEnumProperty.Second
            End If
            If str = &quot;Beautiful Third&quot; Then
                Return MyEnumProperty.Third
            End If
        End If


        Return MyBase.ConvertFrom(context, culture, value)
    End Function


    Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
        If destinationType Is GetType(String) Then
            Dim result As String = Nothing
            If CInt(Fix(value)) = 0 Then
                result = &quot;Beautiful None&quot;
            ElseIf CInt(Fix(value)) = 1 Then
                result = &quot;Beautiful First&quot;
            ElseIf CInt(Fix(value)) = 2 Then
                result = &quot;Beautiful Second&quot;
            ElseIf CInt(Fix(value)) = 3 Then
                result = &quot;Beautiful Third&quot;
            End If


            If result IsNot Nothing Then
                Return result
            End If
        End If


        Return MyBase.ConvertTo(context, culture, value, destinationType)
    End Function
End Class

</pre>
<pre id="codePreview" class="vb">
Friend Class EnumTypeConverter
    Inherits EnumConverter
    Public Sub New()
        MyBase.New(GetType(MyEnumProperty))
    End Sub


    Public Overrides Function CanConvertFrom(ByVal context As ITypeDescriptorContext, ByVal sourceType As Type) As Boolean
        If sourceType Is GetType(String) Then
            Return True
        End If


        Return MyBase.CanConvertFrom(context, sourceType)
    End Function


    Public Overrides Function ConvertFrom(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object) As Object
        Dim str As String = TryCast(value, String)


        If str IsNot Nothing Then
            If str = &quot;Beautiful None&quot; Then
                Return MyEnumProperty.None
            End If
            If str = &quot;Beautiful First&quot; Then
                Return MyEnumProperty.First
            End If
            If str = &quot;Beautiful Second&quot; Then
                Return MyEnumProperty.Second
            End If
            If str = &quot;Beautiful Third&quot; Then
                Return MyEnumProperty.Third
            End If
        End If


        Return MyBase.ConvertFrom(context, culture, value)
    End Function


    Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
        If destinationType Is GetType(String) Then
            Dim result As String = Nothing
            If CInt(Fix(value)) = 0 Then
                result = &quot;Beautiful None&quot;
            ElseIf CInt(Fix(value)) = 1 Then
                result = &quot;Beautiful First&quot;
            ElseIf CInt(Fix(value)) = 2 Then
                result = &quot;Beautiful Second&quot;
            ElseIf CInt(Fix(value)) = 3 Then
                result = &quot;Beautiful Third&quot;
            End If


            If result IsNot Nothing Then
                Return result
            End If
        End If


        Return MyBase.ConvertTo(context, culture, value, destinationType)
    End Function
End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"><b style=""></b></p>
<p class="MsoListParagraphCxSpLast" style=""><b style=""><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style="">Open the <span class="SpellE">VSPackage.resx</span> file, add two String resource as below
</b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;data name=&quot;113&quot; xml:space=&quot;preserve&quot;&gt;
&lt;value&gt;MyOptionsPage&lt;/value&gt;
&lt;/data&gt;
&lt;data name=&quot;114&quot; xml:space=&quot;preserve&quot;&gt;
&lt;value&gt;OptionsPageWithTypeConverter&lt;/value&gt;
&lt;/data&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;data name=&quot;113&quot; xml:space=&quot;preserve&quot;&gt;
&lt;value&gt;MyOptionsPage&lt;/value&gt;
&lt;/data&gt;
&lt;data name=&quot;114&quot; xml:space=&quot;preserve&quot;&gt;
&lt;value&gt;OptionsPageWithTypeConverter&lt;/value&gt;
&lt;/data&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"><b style=""></b></p>
<p class="MsoListParagraphCxSpLast" style=""><b style=""><span style=""><span style="">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style="">Assign <span class="SpellE">ProvideOptionPage</span> attribute to the package class for</b><b style=""><span style="">
</span>registering our Option Page </b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
&lt;ProvideOptionPage(GetType(OptionsPage), &quot;MyOptionsPage&quot;, &quot;OptionsPageWithTypeConverter&quot;, 113, 114, True)&gt; _
Public NotInheritable Class VBVSPackageOptionPageWithTypeConverterPackage
    Inherits Package


End Class

</pre>
<pre id="codePreview" class="csharp">
&lt;ProvideOptionPage(GetType(OptionsPage), &quot;MyOptionsPage&quot;, &quot;OptionsPageWithTypeConverter&quot;, 113, 114, True)&gt; _
Public NotInheritable Class VBVSPackageOptionPageWithTypeConverterPackage
    Inherits Package


End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph"><b style=""></b></p>
<h2>More Information</h2>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/bb166195(VS.80).aspx">MSDN: Walkthrough: Creating an Options Page (C#)</a><span style="">
</span></p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/ayybcxe5.aspx">MSDN: How to: Implement a Type Converter</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

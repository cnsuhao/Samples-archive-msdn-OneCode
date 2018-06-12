# Use TypeConverter in Option page of VS (CSVSPackageOptionPageWithTypeConverter)
## Requires
* Visual Studio 2010
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
* 2012-03-01 11:48:53
## Description

<h1>Use TypeConverter in Option page of VS (<span class="SpellE">CSVSPackageOptionPageWithTypeConverter</span>)<span style="">
</span></h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample demonstrates how to use TypeConverter in Option Page.</p>
<p class="MsoNormal">A type converter can be used to convert values between data types, and to assist property configuration at design time by providing text-to-value conversion or a drop-down list of values to select from.<span style="">
</span></p>
<h2>Building the Sample</h2>
<p class="MsoNormal">VS 2010 SP1 SDK must be installed on the machine. You can download it from:
</p>
<p class="MsoNormal"><span lang="EN" style=""><a href="http://www.microsoft.com/download/en/details.aspx?id=21835">Visual Studio 2010 SP1 SDK</a></span></p>
<p class="MsoNormal">Set the Start Action and Start Options of Debug.</p>
<p class="MsoNormal">Start Action: <u>C:\Program Files\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe</u> (32bit OS) or
<u>C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe</u> (64bit OS)<u>
</u></p>
<p class="MsoNormal">Start Option: <u>/<span class="SpellE">rootsuffix</span>
<span class="SpellE">Exp</span></u></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/53282/1/image.png" alt="" width="576" height="364" align="middle">
</span></p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Press <b style="">F5</b> to debug this project.</p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>In the new instance of Visual Studio, click <b style=""><span style="">Tool</span>=&gt;
</b><b style=""><span style="">Options</span></b>, you will see the <span style="">
Options dialog and find <span class="SpellE"><b style="">MyOptionPage</b></span></span>.<span style=""> You can select the value for<b style="">
<span class="SpellE">MyProperty</span>.</b></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/53283/1/image.png" alt="" width="576" height="330" align="middle">
</span></p>
<p class="MsoListParagraphCxSpLast"></p>
<h2>Using the Code</h2>
<p class="MsoListParagraphCxSpFirst" style=""><b style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style="">Create a VS Package Project. </b></p>
<p class="MsoListParagraphCxSpMiddle">Use Visual Studio Integration Package Wizard to create a simple VSPackage project. You can follow the steps in
<a href="http://msdn.microsoft.com/en-us/library/cc138589.aspx">Walkthrough: Creating a VSPackage</a></p>
<p class="MsoListParagraphCxSpLast" style=""><b style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style="">Add a new class file named <span class="SpellE">
OptionsPage.cs</span> into the project. </b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public enum MyEnumProperty {
    None,
    First,
    Second,
    Third,
}


class OptionsPage : DialogPage
{
    #region Fields
    private MyEnumProperty myProperty = MyEnumProperty.None;
    #endregion Fields


    #region Properties
    [Category(&quot;Enum Options&quot;)]
    [Description(&quot;My enum option&quot;)]
    [TypeConverter(typeof(EnumTypeConverter))]
    public MyEnumProperty MyProperty
    {
        get
        {
            return myProperty;
        }
        set
        {
            myProperty = value;
        }
    }
    #endregion Properties
}

</pre>
<pre id="codePreview" class="csharp">
public enum MyEnumProperty {
    None,
    First,
    Second,
    Third,
}


class OptionsPage : DialogPage
{
    #region Fields
    private MyEnumProperty myProperty = MyEnumProperty.None;
    #endregion Fields


    #region Properties
    [Category(&quot;Enum Options&quot;)]
    [Description(&quot;My enum option&quot;)]
    [TypeConverter(typeof(EnumTypeConverter))]
    public MyEnumProperty MyProperty
    {
        get
        {
            return myProperty;
        }
        set
        {
            myProperty = value;
        }
    }
    #endregion Properties
}

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
class EnumTypeConverter : EnumConverter
{
    public EnumTypeConverter()
        : base(typeof(MyEnumProperty))
    {
    }


    public override bool CanConvertFrom(ITypeDescriptorContext context,
        Type sourceType)
    {
        if (sourceType == typeof(string)) return true;


        return base.CanConvertFrom(context, sourceType);
    }


    public override object ConvertFrom(ITypeDescriptorContext context,
        CultureInfo culture, object value)
    {
        string str = value as string;


        if (str != null)
        {
            if (str == &quot;Beautiful None&quot;) return MyEnumProperty.None;
            if (str == &quot;Beautiful First&quot;) return MyEnumProperty.First;
            if (str == &quot;Beautiful Second&quot;) return MyEnumProperty.Second;
            if (str == &quot;Beautiful Third&quot;) return MyEnumProperty.Third;
        }


        return base.ConvertFrom(context, culture, value);
    }


    public override object ConvertTo(ITypeDescriptorContext context,
        CultureInfo culture, object value, Type destinationType)
    {
        if (destinationType == typeof(string))
        {
            string result = null;
            if ((int)value == 0) result = &quot;Beautiful None&quot;;
            else if ((int)value == 1) result = &quot;Beautiful First&quot;;
            else if ((int)value == 2) result = &quot;Beautiful Second&quot;;
            else if ((int)value == 3) result = &quot;Beautiful Third&quot;;


            if (result != null) return result;
        }


        return base.ConvertTo(context, culture, value, destinationType);
    }
}

</pre>
<pre id="codePreview" class="csharp">
class EnumTypeConverter : EnumConverter
{
    public EnumTypeConverter()
        : base(typeof(MyEnumProperty))
    {
    }


    public override bool CanConvertFrom(ITypeDescriptorContext context,
        Type sourceType)
    {
        if (sourceType == typeof(string)) return true;


        return base.CanConvertFrom(context, sourceType);
    }


    public override object ConvertFrom(ITypeDescriptorContext context,
        CultureInfo culture, object value)
    {
        string str = value as string;


        if (str != null)
        {
            if (str == &quot;Beautiful None&quot;) return MyEnumProperty.None;
            if (str == &quot;Beautiful First&quot;) return MyEnumProperty.First;
            if (str == &quot;Beautiful Second&quot;) return MyEnumProperty.Second;
            if (str == &quot;Beautiful Third&quot;) return MyEnumProperty.Third;
        }


        return base.ConvertFrom(context, culture, value);
    }


    public override object ConvertTo(ITypeDescriptorContext context,
        CultureInfo culture, object value, Type destinationType)
    {
        if (destinationType == typeof(string))
        {
            string result = null;
            if ((int)value == 0) result = &quot;Beautiful None&quot;;
            else if ((int)value == 1) result = &quot;Beautiful First&quot;;
            else if ((int)value == 2) result = &quot;Beautiful Second&quot;;
            else if ((int)value == 3) result = &quot;Beautiful Third&quot;;


            if (result != null) return result;
        }


        return base.ConvertTo(context, culture, value, destinationType);
    }
}

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
[ProvideOptionPage(typeof(OptionsPage), &quot;MyOptionsPage&quot;,
 &quot;OptionsPageWithTypeConverter&quot;, 113, 114, true)]
public sealed class CSVSPackageOptionPageWithTypeConverterPackage : Package

</pre>
<pre id="codePreview" class="csharp">
[ProvideOptionPage(typeof(OptionsPage), &quot;MyOptionsPage&quot;,
 &quot;OptionsPageWithTypeConverter&quot;, 113, 114, true)]
public sealed class CSVSPackageOptionPageWithTypeConverterPackage : Package

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
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

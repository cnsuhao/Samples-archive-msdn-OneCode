# Enum <--> string converter (CSEnumStringConverter)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* .NET Framework
## Topics
* Enum
## IsPublished
* True
## ModifiedDate
* 2012-08-22 04:20:51
## Description
=============================================================================<br>
&nbsp; &nbsp; &nbsp; CONSOLE APPLICATION : CSEnumStringConverter Project Overview<br>
=============================================================================<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Summary: <br>
<br>
This sample demonstrates how to convert enum to comma separated string & vice<br>
versa. It also covers the description attribute for enum while conversion. <br>
<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Demo:<br>
<br>
The following steps walk through a demonstration of the enum-string <br>
convertion sample.<br>
<br>
Step 1: Build and run the sample solution in Visual Studio 2010<br>
<br>
Step 2: During first conversion process it will use the .NET framework built-in <br>
EnumConverter class to convert string to enum & back to string.<br>
<br>
Step 3: During second conversion process it will use the EnumDescriptionConverter<br>
class to convert the description string to enum & back to string.<br>
/////////////////////////////////////////////////////////////////////////////<br>
Implementation:<br>
<br>
Following enum of ProgrammingLanguage has been used for example.<br>
[Flags]<br>
&nbsp; &nbsp;enum ProgrammingLanguage<br>
&nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp;[Description(&quot;Visual C#&quot;)]<br>
&nbsp; &nbsp; &nbsp; &nbsp;CS = 0x1,<br>
&nbsp; &nbsp; &nbsp; &nbsp;[Description(&quot;Visual Basic&quot;)]<br>
&nbsp; &nbsp; &nbsp; &nbsp;VB = 0x2, <br>
&nbsp; &nbsp; &nbsp; &nbsp;[Description(&quot;Visual C&#43;&#43;&quot;)]<br>
&nbsp; &nbsp; &nbsp; &nbsp;Cpp = 0x4,<br>
&nbsp; &nbsp; &nbsp; &nbsp;[Description(&quot;Javascript&quot;)]<br>
&nbsp; &nbsp; &nbsp; &nbsp;JS = 0x8,<br>
&nbsp; &nbsp; &nbsp; &nbsp;// XAML<br>
&nbsp; &nbsp; &nbsp; &nbsp;XAML = 0x10<br>
&nbsp; &nbsp;}<br>
<br>
System.ComponentModel.EnumConverter supports the conversion of one type to <br>
another which has been used in the first conversion process.<br>
&nbsp; &nbsp;EnumConverter converter = new EnumConverter(typeof(ProgrammingLanguage));<br>
&nbsp; &nbsp;// Convert string to enum.<br>
&nbsp; &nbsp;string langStr = &quot;CS, Cpp, XAML&quot;; &nbsp; &nbsp;<br>
&nbsp; &nbsp;ProgrammingLanguage lang <br>
&nbsp; &nbsp; &nbsp; &nbsp;= (ProgrammingLanguage)converter.ConvertFromString(langStr);<br>
&nbsp; &nbsp;// Convert enum to string.<br>
&nbsp; &nbsp;langStr = converter.ConvertToString(lang);<br>
&nbsp; &nbsp;<br>
EnumDescriptionConverter class inherits EnumConverter to support Description <br>
attributes in the second conversion process.<br>
<br>
1. It will split the comma separated string into string[] and then convert to <br>
&nbsp; &nbsp;long & do bitwise ORing to get the long value representing the enum value.
<br>
&nbsp; &nbsp; &nbsp; &nbsp;// convert from string to enum<br>
&nbsp; &nbsp; &nbsp; &nbsp;public override object ConvertFrom(ITypeDescriptorContext context,
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CultureInfo culture, object value)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (value is string)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string strValue = (string)value;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (strValue.IndexOf(enumSeperator) != -1)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;ulong convertedValue = 0;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;foreach (string v in strValue.Split(enumSeperator))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;convertedValue |= Convert.ToUInt64(Parse(this.EnumType, v), culture);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return Enum.ToObject(this.EnumType, convertedValue);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return Parse(this.EnumType, strValue);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return base.ConvertFrom(context, culture, value);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
2. It will read the custom attributes from the given enum, in this case Description
<br>
attribute & prepare the corresponding string value. In case of flags enum, it will fetch<br>
Description attribute[] & prepare comma separated string as output.<br>
&nbsp; &nbsp; &nbsp; &nbsp;// convert to string<br>
&nbsp; &nbsp; &nbsp; &nbsp; public override object ConvertTo(ITypeDescriptorContext context,
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;CultureInfo culture, object value, Type destinationType)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (destinationType == null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;throw new ArgumentNullException(&quot;destinationType&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (destinationType == typeof(string) && value != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Raise an argument exception if the value isn't defined and if
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// the enum isn't a flags style.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;//<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Type underlyingType = Enum.GetUnderlyingType(this.EnumType);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (value is IConvertible && value.GetType() != underlyingType)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;value = ((IConvertible)value).ToType(underlyingType, culture);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (!this.EnumType.IsDefined(typeof(FlagsAttribute), false) &&
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;!Enum.IsDefined(this.EnumType, value))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;throw new ArgumentException(<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;String.Format(&quot;The value '{0}' is not a valid value for the enum '{1}'.&quot;,
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;value.ToString(), this.EnumType.Name));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// If the enum value is decorated with the Description attribute,
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// return the Description value; otherwise return the name.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string enumName = Enum.Format(this.EnumType, value, &quot;G&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;string nameOrDesc;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (enumName.IndexOf(enumSeperator) != -1)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// This is a flags enum. Split the descriptions with ', '.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;bool firstTime = true;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;StringBuilder retval = new StringBuilder();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;foreach (string v in enumName.Split(enumSeperator))<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;nameOrDesc = v.Trim();<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;FieldInfo info = this.EnumType.GetField(nameOrDesc);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;DescriptionAttribute[] attrs = (DescriptionAttribute[])<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;info.GetCustomAttributes(typeof(DescriptionAttribute), false);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (attrs.Length &gt; 0)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;nameOrDesc = attrs[0].Description;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (firstTime)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;retval.Append(nameOrDesc);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;firstTime = false;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;retval.Append(enumSeperator);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;retval.Append(' ');<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;retval.Append(nameOrDesc);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return retval.ToString();<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;FieldInfo info = this.EnumType.GetField(enumName);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (info != null)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;DescriptionAttribute[] attrs = (DescriptionAttribute[])<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;info.GetCustomAttributes(typeof(DescriptionAttribute), false);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;nameOrDesc = (attrs.Length &gt; 0) ? attrs[0].Description : enumName;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;else<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;nameOrDesc = enumName;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return nameOrDesc;<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return base.ConvertTo(context, culture, value, destinationType);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
References:<br>
<br>
EnumConverter Class<br>
http://msdn.microsoft.com/en-us/library/system.componentmodel.enumconverter.aspx<br>
<br>
DescriptionAttribute Members<br>
http://msdn.microsoft.com/en-us/library/system.componentmodel.descriptionattribute_members(v=VS.85).aspx<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>

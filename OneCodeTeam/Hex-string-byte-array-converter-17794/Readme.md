# Hex string <--> byte array converter (CSHexStringByteArrayConverter)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* .NET Framework
## Topics
* Hex
* Byte
## IsPublished
* True
## ModifiedDate
* 2012-08-22 04:20:23
## Description
=============================================================================<br>
&nbsp; &nbsp; &nbsp;Windows APPLICATION: CSHexStringByteArrayConverter Overview<br>
=============================================================================<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Summary:<br>
<br>
This sample demonstrates how to convert byte array to hex string and vice <br>
versa. For example, <br>
<br>
&nbsp; &nbsp;&quot;FF00EE11&quot; &lt;--&gt; { FF, 00, EE, 11 }<br>
<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Demo:<br>
<br>
Step1. Build and run the sample project in Visual Studio 2008. <br>
<br>
Step2. In the Hex String -&gt; Byte Array group box, input a hex string such as <br>
&nbsp; &nbsp; &nbsp; &quot;FF00EE11&quot; and click the &quot;Hex String -&gt; Byte Array&quot; button. &nbsp;It will
<br>
&nbsp; &nbsp; &nbsp; convert the hex string to an array of bytes and display the bytes in
<br>
&nbsp; &nbsp; &nbsp; the combobox control:<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;FF<br>
&nbsp; &nbsp; &nbsp; &nbsp;00<br>
&nbsp; &nbsp; &nbsp; &nbsp;EE<br>
&nbsp; &nbsp; &nbsp; &nbsp;11<br>
<br>
Step3. Click the &quot;Copy to Clipboard&quot; button next to the byte array combobox. &nbsp;<br>
&nbsp; &nbsp; &nbsp; Then click the &quot;Paste from Clipboard&quot; button. &nbsp;The byte array will be
<br>
&nbsp; &nbsp; &nbsp; copied and pasted to the byte array combobox as the input of the Byte
<br>
&nbsp; &nbsp; &nbsp; Array -&gt; Hex String conversion. In the UI, you can also type more
<br>
&nbsp; &nbsp; &nbsp; bytes and &quot;Add&quot; them to the array.<br>
<br>
Step4. Click the &quot;Byte Array -&gt; Hex String&quot; button to convert the byte array <br>
&nbsp; &nbsp; &nbsp; to a hex string. &nbsp;The hex string will be displayed in the Hex String
<br>
&nbsp; &nbsp; &nbsp; textbox. &nbsp;For example, &quot;FF00EE11&quot;.<br>
<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
Implementation:<br>
<br>
1. The sample uses the following algorithm defined in <br>
&nbsp; HexStringByteArrayConverter.cs to covert hex string to byte array and <br>
&nbsp; vice versa. &nbsp;Altenatively, you can also use the BitConverter.ToString
<br>
&nbsp; method to convert byte array to string of hexadecimal pairs separated by <br>
&nbsp; hyphens, where each pair represents the corresponding element in value; <br>
&nbsp; for example, &quot;7F-2C-4A-00&quot;.<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;private const string hexDigits = &quot;0123456789ABCDEF&quot;;<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Convert a byte array to hex string.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;bytes&quot;&gt;An array of bytes&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;returns&gt;Hex string&lt;/returns&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public static string BytesToHexString(byte[] bytes)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;StringBuilder sb = new StringBuilder(bytes.Length * 2);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;foreach (byte b in bytes)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;sb.AppendFormat(&quot;{0:X2}&quot;, b);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return sb.ToString();<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Convert a hex string to byte array.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;param name=&quot;str&quot;&gt;hex string. For example, &quot;FF00EE11&quot;&lt;/param&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;returns&gt;An array of bytes&lt;/returns&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public static byte[] HexStringToBytes(string str)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;// Determine how many bytes there are. &nbsp; &nbsp;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;byte[] bytes = new byte[str.Length &gt;&gt; 1];<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;for (int i = 0; i &lt; str.Length; i &#43;= 2)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;int highDigit = hexDigits.IndexOf(Char.ToUpperInvariant(str[i]));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;int lowDigit = hexDigits.IndexOf(Char.ToUpperInvariant(str[i &#43; 1]));<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;if (highDigit == -1 || lowDigit == -1)<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;throw new ArgumentException(&quot;The string contains an invalid digit.&quot;, &quot;s&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;bytes[i &gt;&gt; 1] = (byte)((highDigit &lt;&lt; 4) | lowDigit);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;}<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return bytes;<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
2. To verify if the input hex string is in the right format, the code sample <br>
&nbsp; provides the following helper function:<br>
<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// Verify the format of the hex string.<br>
&nbsp; &nbsp; &nbsp; &nbsp;/// &lt;/summary&gt;<br>
&nbsp; &nbsp; &nbsp; &nbsp;public static bool VerifyHexString(string str)<br>
&nbsp; &nbsp; &nbsp; &nbsp;{<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Regex regex = new Regex(&quot;\\A[0-9a-fA-F]&#43;\\z&quot;);<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;return regex.IsMatch(str) && ((str.Length & 1) != 1);<br>
&nbsp; &nbsp; &nbsp; &nbsp;}<br>
<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>
References:<br>
<br>
NumberStyles Enumeration<br>
http://msdn.microsoft.com/en-us/library/system.globalization.numberstyles.aspx<br>
<br>
BitConverter.ToString Method (Byte[]) <br>
http://msdn.microsoft.com/en-us/library/3a733s97.aspx<br>
<br>
<br>
/////////////////////////////////////////////////////////////////////////////<br>

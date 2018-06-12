# XML Serialization demo (CSXmlSerialization)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* XML
## Topics
* XML Serialization
## IsPublished
* True
## ModifiedDate
* 2012-03-04 08:13:40
## Description

<h1><span style="font-family:������">CONSOLE APPLICATION </span>(<span style="font-family:������">CSXmlSerialization</span>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
This sample shows how to serialize an in-memory object to a local xml file and how to deserialize the xml file back to an in-memory object using C#. The designed MySerializableType includes int, string, generic, as well as
<span style="">customized type field and property<b>. </b></span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
1. We define a MySerializableType whose instance will be serialized to xml file. The MySerializableType includes int, string, bool, generic List and a customized type field/property. Mark the type as [Serializable()].</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
2. We define a AnotherType which is used for MySerializableType's inner customized type. Mark the type as [Serializable()].</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
3. In the main method, the codes firstly create and initialize an object of MySerializableType.</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
</p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
4. Then it creates a XmlSerializer and StreamWriter to serialize the instance <span style="">
to local driver as XML file. </span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">The generated xml file in step4 looks like:<b> </b></span></p>
<p class="MsoNormal"><span style="">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt; 
- &lt;MySerializableType xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; 
    xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;
 &lt;StringValue&gt;Test String&lt;/StringValue&gt; 
 &lt;BoolValue&gt;true&lt;/BoolValue&gt; 
 &lt;IntValue&gt;1&lt;/IntValue&gt; 
- &lt;AnotherTypeValue&gt;
 &lt;StringValue&gt;Inner Test String&lt;/StringValue&gt; 
 &lt;IntValue&gt;2&lt;/IntValue&gt; 
 &lt;/AnotherTypeValue&gt;
- &lt;ListValue&gt;
 &lt;string&gt;List Item 1&lt;/string&gt; 
 &lt;string&gt;List Item 2&lt;/string&gt; 
 &lt;string&gt;List Item 3&lt;/string&gt; 
 &lt;/ListValue&gt;
 &lt;/MySerializableType&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt; 
- &lt;MySerializableType xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; 
    xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;
 &lt;StringValue&gt;Test String&lt;/StringValue&gt; 
 &lt;BoolValue&gt;true&lt;/BoolValue&gt; 
 &lt;IntValue&gt;1&lt;/IntValue&gt; 
- &lt;AnotherTypeValue&gt;
 &lt;StringValue&gt;Inner Test String&lt;/StringValue&gt; 
 &lt;IntValue&gt;2&lt;/IntValue&gt; 
 &lt;/AnotherTypeValue&gt;
- &lt;ListValue&gt;
 &lt;string&gt;List Item 1&lt;/string&gt; 
 &lt;string&gt;List Item 2&lt;/string&gt; 
 &lt;string&gt;List Item 3&lt;/string&gt; 
 &lt;/ListValue&gt;
 &lt;/MySerializableType&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
5. Then it creates a StreamReader to read and deserialize the xml file back to object instance.<span style="">
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><img src="/site/view/file/53717/1/image.png" alt="" width="576" height="292" align="middle">
</span><span style=""></span></p>
<h2>More Information</h2>
<p class="MsoListParagraphCxSpFirst" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:������"></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:������"><a href="http://msdn.microsoft.com/en-us/library/system.xml.serialization.xmlserializer.aspx">MSDN: XMLSerializer</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

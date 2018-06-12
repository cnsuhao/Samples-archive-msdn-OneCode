# Get list by url and web Service (CSSharepointGetListIDFromListUrl)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* SharePoint
## Topics
* SharePoint
* web service
* ListID
## IsPublished
* True
## ModifiedDate
* 2012-07-22 07:41:17
## Description

<h1><a name="OLE_LINK4"></a><a name="OLE_LINK3"><span style=""><span style="">Get the list ID, name from the list
</span></span></a><span class="SpellE"><span style=""><span style=""><span style="">url</span></span></span></span><span style=""><span style=""><span style="">
</span>(</span></span><span style=""><span style=""><span class="SpellE"><span class="GramE"><span style="">CSSharePointGetListIDFromListUrl</span></span></span></span></span><span style=""><span style=""><span class="GramE"><span style="">
</span>)</span></span></span></h1>
<h2>Introduction </h2>
<p class="MsoNormal"><span style="">The sample will show you how to get the list ID, name from the list
<span class="SpellE"><span class="GramE">url</span></span> by using web service. In this sample, we use
<span class="SpellE">Lists.GetListCollection</span> Method of list web Services. It will return a System.Xml.XmlNode object. You can get the value of the attribute &quot;DefaultViewUrl&quot; and append it to site
<span class="SpellE"><span class="GramE">url</span></span>. After that, you should compare the
<span class="SpellE"><span class="GramE">url</span></span> with your list <span class="SpellE">
url</span>, and then find the list ID value. </span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow these demonstration steps below.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Open the CSSharePointGetListIDFromListUrl.sln. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: Open the <span class="SpellE">Program.cs</span> file to modify the base
<span class="GramE">url</span> and list url then press &quot;Ctrl&#43;F5&quot; to run the sample.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: Validation finished. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Create a C# &quot;Console Application&quot; in Visual Studio 2010. Name it as &quot;<span class="SpellE">CSSharePointGetListIDFromListUrl</span> &quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt"><span style="">Step 2:<span style="">&nbsp;
</span>Add list web service to your project as below:<br>
<span style="">&nbsp;</span><span style="color:black">Project-&gt; Service References -&gt;Add Server Reference -&gt;Advanced -&gt;Add Web Reference... -&gt;type the url as
</span>&quot;<span style="color:black">yoursite/_vti_bin/Lists.asmx&quot; -&gt;Create</span>
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: Add the following namespaces to <span class="SpellE">Program.cs</span>.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
using System.Xml.Linq;
using System.Xml;
using CSSPGetListIDFromListUrl.ServiceReference1;

</pre>
<pre id="codePreview" class="csharp">
using System.Xml.Linq;
using System.Xml;
using CSSPGetListIDFromListUrl.ServiceReference1;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 4: Create an instance of list web service.<br style="">
<br style="">
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
Lists wsLists = new Lists();//list web service
           wsLists.Url = baseUrl &#43; &quot;/sites/subsite/_vti_bin/Lists.asmx&quot;;//Url
           wsLists.Credentials = System.Net.CredentialCache.DefaultCredentials;//Credentials

</pre>
<pre id="codePreview" class="csharp">
Lists wsLists = new Lists();//list web service
           wsLists.Url = baseUrl &#43; &quot;/sites/subsite/_vti_bin/Lists.asmx&quot;;//Url
           wsLists.Credentials = System.Net.CredentialCache.DefaultCredentials;//Credentials

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 5: Get collection of elements by Linq. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
//Get ListCollection
          XmlNode xn = wsLists.GetListCollection();
          //A instance of XmlNodeReader
          XmlNodeReader xnr = new XmlNodeReader(xn);
          //Load XElement
          XElement listMetadatas = XElement.Load(xnr);
          //Search collection of elements
          IEnumerable&lt;XElement&gt; childElements = from el in listMetadatas.Elements()
                                                select el;

</pre>
<pre id="codePreview" class="csharp">
//Get ListCollection
          XmlNode xn = wsLists.GetListCollection();
          //A instance of XmlNodeReader
          XmlNodeReader xnr = new XmlNodeReader(xn);
          //Load XElement
          XElement listMetadatas = XElement.Load(xnr);
          //Search collection of elements
          IEnumerable&lt;XElement&gt; childElements = from el in listMetadatas.Elements()
                                                select el;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style=""><br>
Step 6: Get Id and name by the specified URL. Iteratively access the collection to get the value of the attribute &quot;DefaultViewUrl&quot;. Append it to site URL, and compare the URL with your list URL, then find the list ID value.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private static void GetIdAndName(IEnumerable&lt;XElement&gt; childElements, string baseUrl, string strListUrl)
       {
           // Temporarily store the url of default view.    
           string strCurrentUrl = string.Empty;


           foreach (XElement el in childElements)
           {
               // Get url by appending the DefaultViewUrl to site url.
               strCurrentUrl = baseUrl &#43; el.Attribute(&quot;DefaultViewUrl&quot;).Value;


               // If current url contains the specified url. 
               if ((strCurrentUrl).Contains(strListUrl))
               {
                   Console.WriteLine(&quot;ID:&quot; &#43; el.Attribute(&quot;ID&quot;).Value);
                   Console.WriteLine(&quot;Title:&quot; &#43; el.Attribute(&quot;Title&quot;).Value);
                   Console.WriteLine(&quot;DefaultViewUrl:&quot; &#43; el.Attribute(&quot;DefaultViewUrl&quot;).Value);
               }
           }
       }

</pre>
<pre id="codePreview" class="csharp">
private static void GetIdAndName(IEnumerable&lt;XElement&gt; childElements, string baseUrl, string strListUrl)
       {
           // Temporarily store the url of default view.    
           string strCurrentUrl = string.Empty;


           foreach (XElement el in childElements)
           {
               // Get url by appending the DefaultViewUrl to site url.
               strCurrentUrl = baseUrl &#43; el.Attribute(&quot;DefaultViewUrl&quot;).Value;


               // If current url contains the specified url. 
               if ((strCurrentUrl).Contains(strListUrl))
               {
                   Console.WriteLine(&quot;ID:&quot; &#43; el.Attribute(&quot;ID&quot;).Value);
                   Console.WriteLine(&quot;Title:&quot; &#43; el.Attribute(&quot;Title&quot;).Value);
                   Console.WriteLine(&quot;DefaultViewUrl:&quot; &#43; el.Attribute(&quot;DefaultViewUrl&quot;).Value);
               }
           }
       }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt; font-family:Consolas"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 7: You can debug and test it with specified URL. </span></p>
<h2>More Information</h2>
<p class="MsoNormal"><span style="">Lists.GetListCollection Method<br>
<a href="http://msdn.microsoft.com/en-us/library/lists.lists.getlistcollection(v=office.12).aspx">http://msdn.microsoft.com/en-us/library/lists.lists.getlistcollection(v=office.12).aspx</a><br>
XmlNode Class<br>
<a href="http://msdn.microsoft.com/en-us/library/bxz4hfh3.aspx">http://msdn.microsoft.com/en-us/library/bxz4hfh3.aspx</a><br>
Lists Web Service<br>
<a href="http://msdn.microsoft.com/en-us/library/websvclists.aspx">http://msdn.microsoft.com/en-us/library/websvclists.aspx</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

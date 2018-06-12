# filter data using jquery load
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* jQuery
## IsPublished
* True
## ModifiedDate
* 2013-07-05 02:40:26
## Description

<h1>Loading dynamic content in order to filter the data using jquery load() function (CSASPNETJqueryFilterLoadDynamicContent)</h1>
<h2>Introduction </h2>
<p class="MsoNormal">The sample code demonstrates how to load dynamic ASPX pages in order to filter the data. With using of jQuery.load() function, we can call the page with provided query string parameter and load appropriate content.
</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Please follow these demonstration steps below.</p>
<p class="MsoNormal">Step 1:&nbsp;Open the <span style="">CSASPNETJqueryFilterLoadDynamicContent</span>.sln. Expand the
<a name="OLE_LINK1"><span style="">CSASPNETJqueryFilterLoadDynamicContent</span>
</a>web application and press Ctrl &#43; F5 to show the GetProvinces.aspx. </p>
<p class="MsoNormal">Step 2: We will see a <span style="font-size:10.0pt; line-height:115%; font-family:&quot;Courier New&quot;">
DropDownList</span> Control on the web page and some information of Province.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/91831/1/image.png" alt="" width="834" height="408" align="middle">
</span></p>
<p class="MsoNormal">Step 3:<span style="">&nbsp; </span>When you click the DropDownList, the page will by using like &quot;GetCountries.aspx?countryID=China&quot; call &quot;GetCountries.aspx&quot; . The selected value of the DropDownList will be as value
 of &quot;countryID&quot; parameter.<br>
The following shows the result by using like &quot;GetCountries.aspx?countryID=China&quot; call &quot;GetCountries.aspx&quot;.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/91832/1/image.png" alt="" width="537" height="356" align="middle">
</span></p>
<p class="MsoNormal">Step 4:<span style="">&nbsp;&nbsp; </span>Validation finished.</p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal">Step 1. Create a C# &quot;ASP.NET Empty Web Application&quot; in Visual Studio 20<span style="">12</span>. Name it as &quot;<span style="">CSASPNETJqueryFilterLoadDynamicContent</span>&quot;.
</p>
<p class="MsoNormal">Step 2.<span style="">&nbsp; </span>Add one web form pages and name it as &quot;GetCountries.aspx&quot; page, then add a Repeater Control to this page then rename it to &quot;rptCountries&quot;. This page will bind the query data to &quot;rptCountries&quot;
 upon request. In order to realize this page:</p>
<p class="MsoNormal">First, we need create a <span style="color:black">Province class for store information.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public class Province
   {
       public string ProvinceName { get; set; }
       public string PinYin { get; set; }
       public string countryID { get; set; }
   }

</pre>
<pre id="codePreview" class="csharp">
public class Province
   {
       public string ProvinceName { get; set; }
       public string PinYin { get; set; }
       public string countryID { get; set; }
   }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><br>
Then, we need declare a <span style="color:black">List of Province and add some instances of the Province class to the list.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">       public List&lt;Province&gt; Provinces;


       /// &lt;summary&gt;
       /// load sample data method
       /// &lt;/summary&gt;
       public void LoadSampleProvincesData()
       {
  Provinces = new List&lt;Province&gt;();
  Provinces.Add(new Province() { countryID = &quot;China&quot;, PinYin = &quot;HeBei&quot;, ProvinceName = &quot;HeBei&quot; });
  Provinces.Add(new Province() { countryID = &quot;China&quot;, PinYin = &quot;BeiJing&quot;, ProvinceName = &quot;BeiJing&quot; });
  Provinces.Add(new Province() { countryID = &quot;China&quot;, PinYin = &quot;ShangHai&quot;, ProvinceName = &quot;ShangHai&quot; });
  Provinces.Add(new Province() { countryID = &quot;China&quot;, PinYin = &quot;ShanXi&quot;, ProvinceName = &quot;ShanXi&quot; });
  Provinces.Add(new Province() { countryID = &quot;China&quot;, PinYin = &quot;JiangXi&quot;, ProvinceName = &quot;JiangXi&quot; });
  Provinces.Add(new Province() { countryID = &quot;China&quot;, PinYin = &quot;LiaoNing&quot;, ProvinceName = &quot;LiaoNing&quot; });
  Provinces.Add(new Province() { countryID = &quot;US&quot;, PinYin = &quot;Los Angeles&quot;, ProvinceName = &quot;Los Angeles&quot; });
  Provinces.Add(new Province() { countryID = &quot;US&quot;, PinYin = &quot;Detroit&quot;, ProvinceName = &quot;Detroit&quot; });
  Provinces.Add(new Province() { countryID = &quot;New York&quot;, PinYin = &quot;New York&quot;, ProvinceName = &quot;New York&quot; });
  Provinces.Add(new Province() { countryID = &quot;UK&quot;, PinYin = &quot;England&quot;, ProvinceName = &quot;England&quot; });
  Provinces.Add(new Province() { countryID = &quot;UK&quot;, PinYin = &quot;Scotland&quot;, ProvinceName = &quot;Scotland&quot; });
       }

</pre>
<pre id="codePreview" class="csharp">       public List&lt;Province&gt; Provinces;


       /// &lt;summary&gt;
       /// load sample data method
       /// &lt;/summary&gt;
       public void LoadSampleProvincesData()
       {
  Provinces = new List&lt;Province&gt;();
  Provinces.Add(new Province() { countryID = &quot;China&quot;, PinYin = &quot;HeBei&quot;, ProvinceName = &quot;HeBei&quot; });
  Provinces.Add(new Province() { countryID = &quot;China&quot;, PinYin = &quot;BeiJing&quot;, ProvinceName = &quot;BeiJing&quot; });
  Provinces.Add(new Province() { countryID = &quot;China&quot;, PinYin = &quot;ShangHai&quot;, ProvinceName = &quot;ShangHai&quot; });
  Provinces.Add(new Province() { countryID = &quot;China&quot;, PinYin = &quot;ShanXi&quot;, ProvinceName = &quot;ShanXi&quot; });
  Provinces.Add(new Province() { countryID = &quot;China&quot;, PinYin = &quot;JiangXi&quot;, ProvinceName = &quot;JiangXi&quot; });
  Provinces.Add(new Province() { countryID = &quot;China&quot;, PinYin = &quot;LiaoNing&quot;, ProvinceName = &quot;LiaoNing&quot; });
  Provinces.Add(new Province() { countryID = &quot;US&quot;, PinYin = &quot;Los Angeles&quot;, ProvinceName = &quot;Los Angeles&quot; });
  Provinces.Add(new Province() { countryID = &quot;US&quot;, PinYin = &quot;Detroit&quot;, ProvinceName = &quot;Detroit&quot; });
  Provinces.Add(new Province() { countryID = &quot;New York&quot;, PinYin = &quot;New York&quot;, ProvinceName = &quot;New York&quot; });
  Provinces.Add(new Province() { countryID = &quot;UK&quot;, PinYin = &quot;England&quot;, ProvinceName = &quot;England&quot; });
  Provinces.Add(new Province() { countryID = &quot;UK&quot;, PinYin = &quot;Scotland&quot;, ProvinceName = &quot;Scotland&quot; });
       }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="color:black"><br>
Finally, we filter Provinces data by &quot;countryID&quot; using LINQ and add the collection as data source to the repeater.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
       protected override void OnInit(EventArgs e)
       {
           //load sample data
           LoadSampleProvincesData();
           base.OnInit(e);
       }


       protected void Page_Load(object sender, EventArgs e)
       {
           if (Request.QueryString.Count &gt; 0)
           {
               if (!string.IsNullOrEmpty(Request.QueryString[&quot;countryID&quot;]))
               {
                   string countryID = Request.QueryString[&quot;countryID&quot;]; //get query string into string variable


                   //filter Provinces sample data by countryID using LINQ
                   //and add the collection as data source to the repeater
                   rptCountries.DataSource = Provinces.Where(x =&gt; x.countryID == countryID);
                   rptCountries.DataBind(); //bind repeater
               }
           }


       }

</pre>
<pre id="codePreview" class="csharp">
       protected override void OnInit(EventArgs e)
       {
           //load sample data
           LoadSampleProvincesData();
           base.OnInit(e);
       }


       protected void Page_Load(object sender, EventArgs e)
       {
           if (Request.QueryString.Count &gt; 0)
           {
               if (!string.IsNullOrEmpty(Request.QueryString[&quot;countryID&quot;]))
               {
                   string countryID = Request.QueryString[&quot;countryID&quot;]; //get query string into string variable


                   //filter Provinces sample data by countryID using LINQ
                   //and add the collection as data source to the repeater
                   rptCountries.DataSource = Provinces.Where(x =&gt; x.countryID == countryID);
                   rptCountries.DataBind(); //bind repeater
               }
           }


       }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><br>
The following shows the code of the Repeater.<b style="">[Note]</b><span style=""> The table with id &quot;tableCountries&quot;, will be used behind.</span><br>
<span style=""><img src="/site/view/file/91833/1/image.png" alt="" width="457" height="407" align="middle">
</span></p>
<p class="MsoNormal">Step 3.<span style="">&nbsp; </span>Add one web form pages and name it as &quot;GetProvinces.aspx&quot; page, then add a DropDownList Control to this page then rename it to &quot;drpCountries&quot;. This page will show to loading dynamic
 content in order to filter the data using load() function of jquery.<br>
The following shows the code of the html. <b style="">[Note]</b><span style=""> The div with id &quot;DivCountries&quot;, will be used behind.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
Select a county:&lt;asp:DropDownList ID=&quot;drpCountries&quot; runat=&quot;server&quot; AutoPostBack=&quot;true&quot;&gt;
           &lt;asp:ListItem&gt;China&lt;/asp:ListItem&gt;
           &lt;asp:ListItem&gt;US&lt;/asp:ListItem&gt;
           &lt;asp:ListItem&gt;UK&lt;/asp:ListItem&gt;
       &lt;/asp:DropDownList&gt;
       <br>
       <div id="DivCountries">
       </div>

</pre>
<pre id="codePreview" class="html">
Select a county:&lt;asp:DropDownList ID=&quot;drpCountries&quot; runat=&quot;server&quot; AutoPostBack=&quot;true&quot;&gt;
           &lt;asp:ListItem&gt;China&lt;/asp:ListItem&gt;
           &lt;asp:ListItem&gt;US&lt;/asp:ListItem&gt;
           &lt;asp:ListItem&gt;UK&lt;/asp:ListItem&gt;
       &lt;/asp:DropDownList&gt;
       <br>
       <div id="DivCountries">
       </div>

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><br>
Step 4. Using jQuery's selector capability, you can do this:<span style="">&nbsp;
</span>$(&quot;#DivCountries&quot;).load(&quot;GetCountries.aspx?countryID=&quot; &#43; countryId &#43; &quot; #tableCountries&quot;);<br>
<span style="">&nbsp;</span>Now using jQuery.load() function, we can call this page with provided query string parameter and load appropriate content. This will load the content of &quot;tableCountries&quot; to &quot;DivCountries&quot;. The code as shown below:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
&lt;script src=&quot;Script/jquery-1.4.1.min.js&quot; type=&quot;text/javascript&quot;&gt;&lt;/script&gt;


   &lt;script type=&quot;text/javascript&quot;&gt;
       $(document).ready(function() {
           var countryId = $(&quot;#&lt;%= drpCountries.ClientID %&gt;&quot;).val();


           $(&quot;#DivCountries&quot;).load(&quot;GetCountries.aspx?countryID=&quot; &#43; countryId &#43; &quot; #tableCountries&quot;);


       }); 
   &lt;/script&gt;

</pre>
<pre id="codePreview" class="js">
&lt;script src=&quot;Script/jquery-1.4.1.min.js&quot; type=&quot;text/javascript&quot;&gt;&lt;/script&gt;


   &lt;script type=&quot;text/javascript&quot;&gt;
       $(document).ready(function() {
           var countryId = $(&quot;#&lt;%= drpCountries.ClientID %&gt;&quot;).val();


           $(&quot;#DivCountries&quot;).load(&quot;GetCountries.aspx?countryID=&quot; &#43; countryId &#43; &quot; #tableCountries&quot;);


       }); 
   &lt;/script&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><br>
Step 5. Build the application and you can debug it.</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

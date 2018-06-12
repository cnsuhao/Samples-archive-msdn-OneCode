# ASP.NET load globalization res from assembly (CSASPNETGloablizationInAssembly)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* Globalization
* Resources
## IsPublished
* True
## ModifiedDate
* 2011-10-30 08:10:34
## Description

<h1>CSASPNETGloablizationInAssembly Overview</h1>
<h2><span>Summary</span></h2>
<div>The code sample demonstrates loading embeded resources in an assembly based on the culture information, and use it to globalize the entire ASP.NET website.&nbsp;&nbsp;You will&nbsp;learn how&nbsp;to access resource files that has compiled in class library
 or dll file in ASP.NET. We give an effective way to get specific resources from compiled file and then apply resource value in whole application.</div>
<h2>Demo</h2>
<div>Step 1: Open the CSASPNETGloablizationInAssembly.sln.</div>
<div>Step 2: Expand the CSASPNETGloablizationInAssembly web application and press&nbsp;Ctrl &#43; F5 to show the Default.aspx.</div>
<div>Step 3: You can see a normal web page in browser, the content of page depend on the current request culture.</div>
<div>Step 4: At the end of default page, there is a DropDownList control. You can select the specific language you want.</div>
<h2>Implementation</h2>
<div>Step 1. Create a C# &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or Visual Web Developer 2010. Name it as &quot;CSASPNETGloablizationInAssembly&quot;.</div>
<div>Step 2. Add one web form in the root directory, name them as &quot;Default.aspx&quot;.</div>
<div>Step 3. Create a class library project in solution, the new class library is&nbsp;used to provide resource files for web application. Name it as&nbsp;&quot;CSASPNETGloablizationInAssemblyResource&quot;.</div>
<div>Step 4. Add some resource files in CSASPNETGloablizationInAssemblyResource. such as LanguageResource.resx, LanguageResource.fr-fr.resx. The language&nbsp;code need embed in resource name.<br>
&nbsp;&nbsp;<br>
Step 5&nbsp; Please add the fields and values in resource files, such as Title, Author, Content, Link, etc. Remember put different languages&nbsp; content in related&nbsp;resource file.<br>
&nbsp; [Note]<br>
&nbsp;&nbsp;Please refer to sample's resource files for customizing your resources.<br>
&nbsp;&nbsp;[/Note]</div>
<div>Step 6. In default web page, you must get the information of resource files, and display them. The code as shown below:</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">    /// &lt;summary&gt;
    /// This project class is used to access resource files from class 
    /// library, and render the correct content with current culture.
    /// &lt;/summary&gt;
    public partial class Default : System.Web.UI.Page
    {
        public string strContent = string.Empty;
        public string strUrl = string.Empty;
        public string strLink = string.Empty;
        const string strBaseName = &quot;CSASPNETGloablizationInAssemblyResource.LanguageResource&quot;;
 
        // Get ResourceManager instance by assembly resource type.
        ResourceManager manager = new ResourceManager(strBaseName, typeof(LanguageResource).Assembly);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CultureInfo culture = new CultureInfo(Context.Request.UserLanguages[0]);
 
                string strTitle = manager.GetString(&quot;Title&quot;, culture);
                string strAuthor = manager.GetString(&quot;Author&quot;, culture);
                this.strContent = manager.GetString(&quot;Content&quot;, culture);
                this.strUrl = manager.GetString(&quot;Url&quot;, culture);
                this.strLink = manager.GetString(&quot;Link&quot;, culture);
                lbTitle.Text = strTitle;
                lbAuthor.Text = strAuthor;
            }
        }
 
        /// &lt;summary&gt;
        /// Add built-in language items of DropDownList control.
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            ddlLanguage.Items.Add(new ListItem(&quot;United State&quot;, &quot;en-us&quot;));
            ddlLanguage.Items.Add(new ListItem(&quot;France&quot;, &quot;fr-fr&quot;));
            ddlLanguage.Items.Add(new ListItem(&quot;中国&quot;, &quot;zh-cn&quot;));
        }
 
        /// &lt;summary&gt;
        /// Change page culture and content by DropDownList SelectedValue.
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string languageCode = ddlLanguage.SelectedValue;
            CultureInfo currentCulture = this.GetLanguageSpecifically(languageCode);
            lbTitle.Text = manager.GetString(&quot;Title&quot;, currentCulture);
            lbAuthor.Text = manager.GetString(&quot;Author&quot;, currentCulture);
            this.strContent = manager.GetString(&quot;Content&quot;, currentCulture);
            this.strLink = manager.GetString(&quot;Link&quot;, currentCulture);
            this.strUrl = manager.GetString(&quot;Url&quot;, currentCulture);
        }
 
        public CultureInfo GetLanguageSpecifically(string languageCode)
        {
            CultureInfo culture = new CultureInfo(languageCode);
            return culture;
        }
 }</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;This&nbsp;project&nbsp;class&nbsp;is&nbsp;used&nbsp;to&nbsp;access&nbsp;resource&nbsp;files&nbsp;from&nbsp;class&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;library,&nbsp;and&nbsp;render&nbsp;the&nbsp;correct&nbsp;content&nbsp;with&nbsp;current&nbsp;culture.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;Default&nbsp;:&nbsp;System.Web.UI.Page&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;strContent&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;strUrl&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;strLink&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;strBaseName&nbsp;=&nbsp;<span class="cs__string">&quot;CSASPNETGloablizationInAssemblyResource.LanguageResource&quot;</span>;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Get&nbsp;ResourceManager&nbsp;instance&nbsp;by&nbsp;assembly&nbsp;resource&nbsp;type.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ResourceManager&nbsp;manager&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ResourceManager(strBaseName,&nbsp;<span class="cs__keyword">typeof</span>(LanguageResource).Assembly);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Page_Load(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!Page.IsPostBack)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CultureInfo&nbsp;culture&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CultureInfo(Context.Request.UserLanguages[<span class="cs__number">0</span>]);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;strTitle&nbsp;=&nbsp;manager.GetString(<span class="cs__string">&quot;Title&quot;</span>,&nbsp;culture);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;strAuthor&nbsp;=&nbsp;manager.GetString(<span class="cs__string">&quot;Author&quot;</span>,&nbsp;culture);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.strContent&nbsp;=&nbsp;manager.GetString(<span class="cs__string">&quot;Content&quot;</span>,&nbsp;culture);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.strUrl&nbsp;=&nbsp;manager.GetString(<span class="cs__string">&quot;Url&quot;</span>,&nbsp;culture);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.strLink&nbsp;=&nbsp;manager.GetString(<span class="cs__string">&quot;Link&quot;</span>,&nbsp;culture);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lbTitle.Text&nbsp;=&nbsp;strTitle;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lbAuthor.Text&nbsp;=&nbsp;strAuthor;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Add&nbsp;built-in&nbsp;language&nbsp;items&nbsp;of&nbsp;DropDownList&nbsp;control.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;e&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnInit(EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.OnInit(e);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ddlLanguage.Items.Add(<span class="cs__keyword">new</span>&nbsp;ListItem(<span class="cs__string">&quot;United&nbsp;State&quot;</span>,&nbsp;<span class="cs__string">&quot;en-us&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ddlLanguage.Items.Add(<span class="cs__keyword">new</span>&nbsp;ListItem(<span class="cs__string">&quot;France&quot;</span>,&nbsp;<span class="cs__string">&quot;fr-fr&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ddlLanguage.Items.Add(<span class="cs__keyword">new</span>&nbsp;ListItem(<span class="cs__string">&quot;中国&quot;</span>,&nbsp;<span class="cs__string">&quot;zh-cn&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Change&nbsp;page&nbsp;culture&nbsp;and&nbsp;content&nbsp;by&nbsp;DropDownList&nbsp;SelectedValue.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;sender&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;e&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ddlLanguage_SelectedIndexChanged(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;languageCode&nbsp;=&nbsp;ddlLanguage.SelectedValue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CultureInfo&nbsp;currentCulture&nbsp;=&nbsp;<span class="cs__keyword">this</span>.GetLanguageSpecifically(languageCode);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lbTitle.Text&nbsp;=&nbsp;manager.GetString(<span class="cs__string">&quot;Title&quot;</span>,&nbsp;currentCulture);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lbAuthor.Text&nbsp;=&nbsp;manager.GetString(<span class="cs__string">&quot;Author&quot;</span>,&nbsp;currentCulture);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.strContent&nbsp;=&nbsp;manager.GetString(<span class="cs__string">&quot;Content&quot;</span>,&nbsp;currentCulture);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.strLink&nbsp;=&nbsp;manager.GetString(<span class="cs__string">&quot;Link&quot;</span>,&nbsp;currentCulture);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.strUrl&nbsp;=&nbsp;manager.GetString(<span class="cs__string">&quot;Url&quot;</span>,&nbsp;currentCulture);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;CultureInfo&nbsp;GetLanguageSpecifically(<span class="cs__keyword">string</span>&nbsp;languageCode)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CultureInfo&nbsp;culture&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CultureInfo(languageCode);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;culture;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">Step 7. Build the application and you can debug it.</div>
<div class="endscriptcode"></div>
<h2 class="endscriptcode">References</h2>
<div class="endscriptcode">
<p>MSDN: ResourceManager Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.resources.resourcemanager.aspx">http://msdn.microsoft.com/en-us/library/system.resources.resourcemanager.aspx</a></p>
<p>MSDN: Assembly Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.reflection.assembly.aspx">http://msdn.microsoft.com/en-us/library/system.reflection.assembly.aspx</a></p>
<p>MSDN: CultureInfo Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo.aspx">http://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo.aspx</a></p>
</div>
<div class="endscriptcode"><br>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
</div>
</div>

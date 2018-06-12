# ASP.NET load globalization res from assembly (CSASPNETGloablizationInAssembly)
## Requires
* Visual Studio 2012
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* Globalization
* resource
## IsPublished
* True
## ModifiedDate
* 2012-12-09 07:00:02
## Description

<h1>Accessing the user controls and web pages from embedded resources (<a name="OLE_LINK1"></a><a name="OLE_LINK2"><span style="">CSASPNETAccessResourceInAssembly</span></a>)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This project illustrates how to access user controls and web pages from class library via virtual path. Here we inherit VirtualPathProvider and VirtualFile class for creating a custom path provider, this virtual file system can provide
 a similar file path for accessing many files or code from different application, for example, we can put the same type of files (a.mp3, b.mp3) but in different assemblies (a.dll, b.dll) with a unite virtual path, like
<a href="http://localhost/mp3/a.mp3">http://localhost/mp3/a.mp3</a> and <a href="http://localhost/mp3/b.mp3">
http://localhost/mp3/b.mp3</a>. In this way, our websites become more clearly and interactive.
</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Please follow these demonstration steps below.</p>
<p class="MsoNormal">Step 1:&nbsp;Open the CSASPNETAccessResourceInAssembly.sln. Expand the CSASPNETAccessResourceInAssembly web application and press Ctrl &#43; F5 to show the Default.aspx.
</p>
<p class="MsoNormal">Step 2: We will see two user controls and two links on the web page as follows.</p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;</span> <img src="/site/view/file/72264/1/image.png" alt="" width="537" height="374" align="middle">
</span></p>
<p class="MsoNormal">Step 3: You can click the two links for viewing pages in different assemblies. The &quot;Assembly/WebPage&quot; link will navigate to the page in CSASPNETAssembly project and the &quot;Website/WebPage&quot; link will navigate to the page
 in current project.</p>
<p class="MsoNormal">The page comes from CSASPNETAssembly:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/72265/1/image.png" alt="" width="537" height="374" align="middle">
</span></p>
<p class="MsoNormal">The page comes from this project:</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/72266/1/image.png" alt="" width="559" height="391" align="middle">
</span></p>
<p class="MsoNormal">Step 4: Validation is finished.</p>
<h2>Using the Code</h2>
<p class="MsoNormal">Code Logical: </p>
<p class="MsoNormal">Step 1. Create a C# &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2012 or Visual Web Developer 2012. Name it as &quot;CSASPNETAccessResourceInAssembly &quot;. The application includes two projects,<span style="">&nbsp;
</span>&quot;CSASPNETAccessResourceInAssembly&quot;, &quot;CSASPNETAssembly&quot;.
</p>
<p class="MsoNormal">Step 2. Add a user control and a web form page in the project &quot;CSASPNETAssembly&quot;, this project is the target project, another project will access these resources. For making difference with other pages or user controls, we need
 add some text and special color border with them.<span style="">&nbsp; </span></p>
<p class="MsoNormal">Step 3. Add a folder with web pages and user controls to &quot;CSASPNETAccessResourceInAssembly&quot; project like step 2, we also need to add some text and borders. Then we need to add a master page for displaying the resources of all
 projects, add a web form page and name it as &quot;Default.aspx&quot;, and load user controls and links in code behind file. For the normal web page and user controls, we can add the relative path directly, but for the resources of other assemblies, we need
 to add some special information to combine a little complex url string.</p>
<h3>The following code is used to add user controls and links in Default.aspx page.</h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Add relative web pages and user controls in assembly and this application.
        DataTable tab = this.InitializeDataTable();
        if (tab != null && tab.Rows.Count != 0)
        {
            for (int i = 0; i &lt; tab.Rows.Count; i&#43;&#43;)
            {
                Control control = Page.LoadControl(tab.Rows[i][&quot;UserControlUrl&quot;].ToString());
                UserControl usercontrol = control as UserControl;
                Page.Controls.Add(usercontrol);
                HyperLink link = new HyperLink();
                link.NavigateUrl = tab.Rows[i][&quot;WebPageUrl&quot;].ToString();
                link.Text = tab.Rows[i][&quot;WebPageText&quot;].ToString();
                Page.Controls.Add(link);
            }
        }
    }


    /// &lt;summary&gt;
    /// Initialize a DataTable variable for storing URL and text properties. 
    /// &lt;/summary&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    protected DataTable InitializeDataTable()
    {
        DataTable tab = new DataTable();
        DataColumn userControlUrl = new DataColumn(&quot;UserControlUrl&quot;,Type.GetType(&quot;System.String&quot;));
        tab.Columns.Add(userControlUrl);
        DataColumn webPageUrl = new DataColumn(&quot;WebPageUrl&quot;, Type.GetType(&quot;System.String&quot;));
        tab.Columns.Add(webPageUrl);
        DataColumn webPageText = new DataColumn(&quot;WebPageText&quot;, Type.GetType(&quot;System.String&quot;));
        tab.Columns.Add(webPageText);
        DataRow dr = tab.NewRow();
        dr[&quot;UserControlUrl&quot;] = &quot;~/Assembly/CSASPNETAssembly.dll/CSASPNETAssembly.WebUserControl.ascx&quot;;
        dr[&quot;WebPageUrl&quot;] = &quot;~/Assembly/CSASPNETAssembly.dll/CSASPNETAssembly.WebPage.aspx&quot;;
        dr[&quot;WebPageText&quot;] = &quot;Assembly/WebPage&quot;;
        DataRow drWebSite = tab.NewRow();
        drWebSite[&quot;UserControlUrl&quot;] = &quot;~/WebSite/WebUserControl.ascx&quot;;
        drWebSite[&quot;WebPageUrl&quot;] = &quot;~/WebSite/WebPage.aspx&quot;;
        drWebSite[&quot;WebPageText&quot;] = &quot;WebSite/WebPage&quot;;
        tab.Rows.Add(dr);
        tab.Rows.Add(drWebSite);
        return tab;
    }
}

</pre>
<pre id="codePreview" class="csharp">
public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Add relative web pages and user controls in assembly and this application.
        DataTable tab = this.InitializeDataTable();
        if (tab != null && tab.Rows.Count != 0)
        {
            for (int i = 0; i &lt; tab.Rows.Count; i&#43;&#43;)
            {
                Control control = Page.LoadControl(tab.Rows[i][&quot;UserControlUrl&quot;].ToString());
                UserControl usercontrol = control as UserControl;
                Page.Controls.Add(usercontrol);
                HyperLink link = new HyperLink();
                link.NavigateUrl = tab.Rows[i][&quot;WebPageUrl&quot;].ToString();
                link.Text = tab.Rows[i][&quot;WebPageText&quot;].ToString();
                Page.Controls.Add(link);
            }
        }
    }


    /// &lt;summary&gt;
    /// Initialize a DataTable variable for storing URL and text properties. 
    /// &lt;/summary&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    protected DataTable InitializeDataTable()
    {
        DataTable tab = new DataTable();
        DataColumn userControlUrl = new DataColumn(&quot;UserControlUrl&quot;,Type.GetType(&quot;System.String&quot;));
        tab.Columns.Add(userControlUrl);
        DataColumn webPageUrl = new DataColumn(&quot;WebPageUrl&quot;, Type.GetType(&quot;System.String&quot;));
        tab.Columns.Add(webPageUrl);
        DataColumn webPageText = new DataColumn(&quot;WebPageText&quot;, Type.GetType(&quot;System.String&quot;));
        tab.Columns.Add(webPageText);
        DataRow dr = tab.NewRow();
        dr[&quot;UserControlUrl&quot;] = &quot;~/Assembly/CSASPNETAssembly.dll/CSASPNETAssembly.WebUserControl.ascx&quot;;
        dr[&quot;WebPageUrl&quot;] = &quot;~/Assembly/CSASPNETAssembly.dll/CSASPNETAssembly.WebPage.aspx&quot;;
        dr[&quot;WebPageText&quot;] = &quot;Assembly/WebPage&quot;;
        DataRow drWebSite = tab.NewRow();
        drWebSite[&quot;UserControlUrl&quot;] = &quot;~/WebSite/WebUserControl.ascx&quot;;
        drWebSite[&quot;WebPageUrl&quot;] = &quot;~/WebSite/WebPage.aspx&quot;;
        drWebSite[&quot;WebPageText&quot;] = &quot;WebSite/WebPage&quot;;
        tab.Rows.Add(dr);
        tab.Rows.Add(drWebSite);
        return tab;
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal">Step 4. Everything is fine, now we can begin to create a custom virtual file system. In the first step,&nbsp; create a class to inherit the VirtualPathProvider class and override some necessary methods, such as<span style="">&nbsp;
</span>FileExists, GetFile, GetCacheDependency, this class is used to receive and analyse the message that can get the correct resources in a web request.</p>
<h3>The following code is a custom virtual path provider class that can distinguish the &quot;Assembly/xxx&quot; folder.
</h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public class CustomPathProvider : VirtualPathProvider
    {
        public CustomPathProvider()
        { 
        }


        /// &lt;summary&gt;
        /// Make a judgment that application find path contains specifical folder name.
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;path&quot;&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        private bool AssemblyPathExist(string path)
        {
            string relateivePath = VirtualPathUtility.ToAppRelative(path);
            return relateivePath.StartsWith(&quot;~/Assembly/&quot;, StringComparison.InvariantCultureIgnoreCase);
        }


        /// &lt;summary&gt;
        /// If we can find this virtual path, return true.
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;virtualPath&quot;&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public override bool FileExists(string virtualPath)
        {
            if (this.AssemblyPathExist(virtualPath))
            {
                return true;
            }
            else 
            {
                return base.FileExists(virtualPath);
            }
        }


        /// &lt;summary&gt;
        /// Use custom VirtualFile class to load assembly resources.
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;virtualPath&quot;&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public override VirtualFile GetFile(string virtualPath)
        {
            if (AssemblyPathExist(virtualPath))
            {
                return new CustomFile(virtualPath);
            }
            else
            {
                return base.GetFile(virtualPath);
            }
        }


        /// &lt;summary&gt;
        /// Return null when application use virtual file path.
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;virtualPath&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;virtualPathDependencies&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;utcStart&quot;&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            if (AssemblyPathExist(virtualPath))
            {
                return null;
            }
            else
            {
                return base.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
            }
        }
    }

</pre>
<pre id="codePreview" class="csharp">
public class CustomPathProvider : VirtualPathProvider
    {
        public CustomPathProvider()
        { 
        }


        /// &lt;summary&gt;
        /// Make a judgment that application find path contains specifical folder name.
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;path&quot;&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        private bool AssemblyPathExist(string path)
        {
            string relateivePath = VirtualPathUtility.ToAppRelative(path);
            return relateivePath.StartsWith(&quot;~/Assembly/&quot;, StringComparison.InvariantCultureIgnoreCase);
        }


        /// &lt;summary&gt;
        /// If we can find this virtual path, return true.
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;virtualPath&quot;&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public override bool FileExists(string virtualPath)
        {
            if (this.AssemblyPathExist(virtualPath))
            {
                return true;
            }
            else 
            {
                return base.FileExists(virtualPath);
            }
        }


        /// &lt;summary&gt;
        /// Use custom VirtualFile class to load assembly resources.
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;virtualPath&quot;&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public override VirtualFile GetFile(string virtualPath)
        {
            if (AssemblyPathExist(virtualPath))
            {
                return new CustomFile(virtualPath);
            }
            else
            {
                return base.GetFile(virtualPath);
            }
        }


        /// &lt;summary&gt;
        /// Return null when application use virtual file path.
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;virtualPath&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;virtualPathDependencies&quot;&gt;&lt;/param&gt;
        /// &lt;param name=&quot;utcStart&quot;&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            if (AssemblyPathExist(virtualPath))
            {
                return null;
            }
            else
            {
                return base.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
            }
        }
    }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal">Step 5. Then we can create a virtual file class that get the path from virtual path provide class and check the url is available or not, and return the relative assembly's file stream.</p>
<h3><a name="OLE_LINK3"></a><a name="OLE_LINK4"><span style="">The following code shows how to check the url's useful information and get the stream of resources.</span></a></h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public class CustomFile: VirtualFile
    {
        string path
        {
            get;
            set;
        }


        public CustomFile(string virtualPath)
            : base(virtualPath)
        {
            path = VirtualPathUtility.ToAppRelative(virtualPath);
        }


        /// &lt;summary&gt;
        /// Override Open method to load resource files of assembly.
        /// &lt;/summary&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public override System.IO.Stream Open()
        {
            string[] strs = path.Split('/');
            string name = strs[2];
            string resourceName = strs[3];
            name = Path.Combine(HttpRuntime.BinDirectory, name);
            Assembly assembly = Assembly.LoadFile(name);
            if (assembly != null)
            {
                Stream s = assembly.GetManifestResourceStream(resourceName);
                return s;
            }
            else
            {
                return null;
            }
        }
    }

</pre>
<pre id="codePreview" class="csharp">
public class CustomFile: VirtualFile
    {
        string path
        {
            get;
            set;
        }


        public CustomFile(string virtualPath)
            : base(virtualPath)
        {
            path = VirtualPathUtility.ToAppRelative(virtualPath);
        }


        /// &lt;summary&gt;
        /// Override Open method to load resource files of assembly.
        /// &lt;/summary&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public override System.IO.Stream Open()
        {
            string[] strs = path.Split('/');
            string name = strs[2];
            string resourceName = strs[3];
            name = Path.Combine(HttpRuntime.BinDirectory, name);
            Assembly assembly = Assembly.LoadFile(name);
            if (assembly != null)
            {
                Stream s = assembly.GetManifestResourceStream(resourceName);
                return s;
            }
            else
            {
                return null;
            }
        }
    }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal">Step 6. At last, you need only register the CustomPathProvider class to the Application_Start event. The provider starts to work when you try to run this application.</p>
<h3>The following code is used to register the custom path provider class to Application_Start event.</h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
using System.Web.Hosting;


protected void Application_Start(object sender, EventArgs e)
{
    HostingEnvironment.RegisterVirtualPathProvider(new CustomPathProvider());
}

</pre>
<pre id="codePreview" class="csharp">
using System.Web.Hosting;


protected void Application_Start(object sender, EventArgs e)
{
    HostingEnvironment.RegisterVirtualPathProvider(new CustomPathProvider());
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal"><span class="GramE">Step 7.</span> Build the application and you can debug it.</p>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoListParagraphCxSpFirst" style="text-indent:5.0pt"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/system.web.hosting.virtualpathprovider.aspx"><span class="SpellE">VirtualPathProvider</span> Class</a></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:5.0pt"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/system.web.hosting.virtualfile.aspx"><span class="SpellE">VirtualFile</span> Class</a></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:5.0pt"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/system.web.virtualpathutility.aspx"><span class="SpellE">VirtualPathUtility</span> Class</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>

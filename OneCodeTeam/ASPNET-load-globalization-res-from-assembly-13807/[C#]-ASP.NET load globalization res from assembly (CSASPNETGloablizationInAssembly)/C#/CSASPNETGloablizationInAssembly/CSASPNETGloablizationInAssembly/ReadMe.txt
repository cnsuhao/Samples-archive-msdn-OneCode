========================================================================
               CSASPNETGloablizationInAssembly Overview
========================================================================

/////////////////////////////////////////////////////////////////////////////
Use:

The project illustrates how to access resource files that has compiled in 
class library or dll file. So we can not use GetGlobalResourceObject function
to get it, here we give an effective way to get specific resources from
compiled file and then apply resource value in whole application.

/////////////////////////////////////////////////////////////////////////////
Demo the Sample. 

Please follow these demonstration steps below.

Step 1: Open the CSASPNETGloablizationInAssembly.sln.

Step 2: Expand the CSASPNETGloablizationInAssembly web application and press 
        Ctrl + F5 to show the Default.aspx.

Step 3: You can see a normal web page in browser, the content of page depend
        on the current request culture.

Step 4: At the end of default page, there is a DropDownList control. You can
        select the specific language you want.

Step 5: Validation finished.

/////////////////////////////////////////////////////////////////////////////
Code Logical:

Step 1. Create a C# "ASP.NET Empty Web Application" in Visual Studio 2010 or
        Visual Web Developer 2010. Name it as "CSASPNETGloablizationInAssembly".

Step 2. Add one web form in the root directory, name them as "Default.aspx".

Step 3. Create a class library project in solution, the new class library is
        used to provide resource files for web application. Name it as 
		"CSASPNETGloablizationInAssemblyResource".

Step 4. Add some resource files in CSASPNETGloablizationInAssemblyResource.
        such as LanguageResource.resx, LanguageResource.fr-fr.resx. The language
		code need embed in resource name.
		
Step 5  Please add the fields and values in resource files, such as Title, Author,
        Content, Link, etc. Remember put different languages	 content in related 
		resource file.
        [Note]
		Please refer to sample's resource files for customizing your resources.
		[/Note]

Step 6. In default web page, you must get the information of resource files, and
        display them. The code as shown below:
		[code]
    /// <summary>
    /// This project class is used to access resource files from class 
    /// library, and render the correct content with current culture.
    /// </summary>
    public partial class Default : System.Web.UI.Page
    {
        public string strContent = string.Empty;
        public string strUrl = string.Empty;
        public string strLink = string.Empty;
        const string strBaseName = "CSASPNETGloablizationInAssemblyResource.LanguageResource";

        // Get ResourceManager instance by assembly resource type.
        ResourceManager manager = new ResourceManager(strBaseName, typeof(LanguageResource).Assembly);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CultureInfo culture = new CultureInfo(Context.Request.UserLanguages[0]);

                string strTitle = manager.GetString("Title", culture);
                string strAuthor = manager.GetString("Author", culture);
                this.strContent = manager.GetString("Content", culture);
                this.strUrl = manager.GetString("Url", culture);
                this.strLink = manager.GetString("Link", culture);
                lbTitle.Text = strTitle;
                lbAuthor.Text = strAuthor;
            }
        }

        /// <summary>
        /// Add built-in language items of DropDownList control.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            ddlLanguage.Items.Add(new ListItem("United State", "en-us"));
            ddlLanguage.Items.Add(new ListItem("France", "fr-fr"));
            ddlLanguage.Items.Add(new ListItem("中国", "zh-cn"));
        }

        /// <summary>
        /// Change page culture and content by DropDownList SelectedValue.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string languageCode = ddlLanguage.SelectedValue;
            CultureInfo currentCulture = this.GetLanguageSpecifically(languageCode);
            lbTitle.Text = manager.GetString("Title", currentCulture);
            lbAuthor.Text = manager.GetString("Author", currentCulture);
            this.strContent = manager.GetString("Content", currentCulture);
            this.strLink = manager.GetString("Link", currentCulture);
            this.strUrl = manager.GetString("Url", currentCulture);
        }

        public CultureInfo GetLanguageSpecifically(string languageCode)
        {
            CultureInfo culture = new CultureInfo(languageCode);
            return culture;
        }
	}
		[/code]

Step 7. Build the application and you can debug it.
/////////////////////////////////////////////////////////////////////////////
References:

MSDN: ResourceManager Class
http://msdn.microsoft.com/en-us/library/system.resources.resourcemanager.aspx

MSDN: Assembly Class
http://msdn.microsoft.com/en-us/library/system.reflection.assembly.aspx

MSDN: CultureInfo Class
http://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo.aspx
/////////////////////////////////////////////////////////////////////////////
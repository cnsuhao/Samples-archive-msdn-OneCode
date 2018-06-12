========================================================================
              CSASPNETDisplayDataStreamResource Overview
========================================================================

/////////////////////////////////////////////////////////////////////////////
Use:

The project illustrates how to display the data stream from Internet resource
and site resource in a web page. Customers want to know how to display the 
title, content or other information of web pages. Thus, the sample can search
the target web page which you input url address in TextBox control and get all
relative link resources of it. 

/////////////////////////////////////////////////////////////////////////////
Demo the Sample. 

Please follow these demonstration steps below.

Step 1: Open the CSASPNETDisplayDataStreamResource.sln.

Step 2: Expand the CSASPNETDisplayDataStreamResource web application and press 
        Ctrl + F5 to show the SearchEngine.aspx.

Step 3: You will see a TextBox and a Button on DisplayResource.aspx page. The TextBox
        is used to input target page's url address and find the link resources of
		web page.

Step 4: If the url links like "#", the application replace it as source page url, 
        and url routing links, such as "/duty/", web application can combine source 
		page url and url routing name to a complete url automatically.

Step 5: Validation finished.

/////////////////////////////////////////////////////////////////////////////
Code Logical:

Step 1. Create a C# "ASP.NET Empty Application" in Visual Studio 2010 or
        Visual Web Developer 2010. Name it as "CSASPNETDisplayDataStreamResource".

Step 2. Add an ASP.NET folder named "App_Code", and this folder is used to store class
        files. In this sample code, we create two class files in it, one of them is 
		"RegexMethod", and the other is "WebPageEntity".

Step 3. Add a web form page named "DisplayResource.aspx", this page is used to retrieve
        page resource and find relative page by key words. The main C# code will be
		like this:
		[code]
    public partial class DisplayResource : System.Web.UI.Page
    {
        private WebPageEntity webResources;
        public string publicTable = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// The method is used to load resource by specific web pages.
        /// </summary>
        public void LoadLink(string url)
        {
            RegexMethod method = new RegexMethod();
            webResources = new WebPageEntity();
            lock (this)
            {
                string result = this.LoadResource(url);
                WebPageEntity webEntity = new WebPageEntity();
                webEntity.Name = Path.GetFileName(url);
                webEntity.Uri=url;
                webEntity.Link = method.GetLinks(result, url);
                webEntity.Content = result;
                webResources = webEntity;
            }
            StringBuilder builder = new StringBuilder();
            builder.Append("<table>");
            for (int i = 0; i < webResources.Link.Count; i++)
            {
                builder.Append("<tr><td><a href='"+webResources.Link[i].ToString()+"'>");
                builder.Append(webResources.Link[i].ToString());
                builder.Append("</a></td></tr>");
            }
            builder.Append("</table>");
            publicTable = builder.ToString();
        }

        /// <summary>
        /// Use HttpWebRequest, HttpWebResponse, StreamReader for retrieving
        /// information of pages, and calling Regex methods to get useful 
        /// information.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string LoadResource(string url)
        {
            HttpWebResponse webResponse = null;
            StreamReader reader = null;
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Timeout = 30000;
                webResponse = (HttpWebResponse)webRequest.GetResponse();
                string resource = String.Empty;
                if (webResponse == null)
                {
                    return string.Empty;
                }
                else if (webResponse.StatusCode != HttpStatusCode.OK)
                {
                    return string.Empty;
                }
                else
                {
                    reader = new StreamReader(webResponse.GetResponseStream(), Encoding.GetEncoding("utf-8"));
                    resource = reader.ReadToEnd();
                    return resource;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (webResponse != null)
                {
                    webResponse.Close();
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        /// <summary>
        /// The search button click event is used to compare key words and 
        /// page resources for selecting relative pages. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearchPage_Click(object sender, EventArgs e)
        {
            if (tbKeyWord.Text.Trim() != string.Empty)
            {
                if (RegexMethod.IsUrl(tbKeyWord.Text.Trim()))
                {
                    this.LoadLink(tbKeyWord.Text.Trim());
                }
                else
                {
                    Response.Write("Url address is not valid");
                }
            }
            else
            {
                Response.Write("Url address can not be null.");
            }

        }
    }
	    [/code]

Step 5. The RegexMethod class provides two methods to extract specific information
        from pages.
	    [code]
        public List<string> GetLinks(string htmlCode,string url)
        {
            List<string> links=new List<string>();
            string strRegexLink = @"(?is)<a .*?>";
            MatchCollection matchList = Regex.Matches(htmlCode, strRegexLink, RegexOptions.IgnoreCase);
            StringBuilder strbLinkList = new StringBuilder();

            foreach (Match matchSingleLink in matchList)
            {
                string matchLink = @"<a[^>]*?href=(['""\s]?)([^'""\s]+)\1[^>]*?>";
                Match match = Regex.Match(matchSingleLink.Value, matchLink, RegexOptions.IgnoreCase);
                if (match.Groups[2].Value == "#")
                {
                    links.Add(url);
                }
                else if (!match.Groups[2].Value.ToLower().Contains("http://"))
                {
                    links.Add(url + match.Groups[2].Value);
                }
                else
                {
                    links.Add(match.Groups[2].Value);
                }
            }
            return links;
        }

        public static bool IsUrl(string source)
        {
            return Regex.IsMatch(source, @"^(((file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp):
			//)|(www\.))+(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]
			{1,3}))(/[a-zA-Z0-9\&amp;%_\./-~-]*)?$", RegexOptions.IgnoreCase);
        }

        [/code]  

Step 6. The WebPageEntity class file is used to store web page resource, 
        and binding them as the data source of GridView control.
	    [code]
	/// <summary>
    /// web page entity class, contain page's basic information,
    /// such as name, content, link, title, body text.
    /// </summary>
    [Serializable]
    public class WebPageEntity
    {
        private string name;
        private string content;
        private string uri;
        private List<string> link;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
            }
        }

        public string Uri
        {
            get
            {
                return uri;
            }
            set
            {
                uri = value;
            }
        }

        public List<string> Link
        {
            get
            {
                return link;
            }
            set
            {
                link = value;
            }
        }
    }
	    [/code]

Step 7. Build the application and you can debug it.
/////////////////////////////////////////////////////////////////////////////
References:

MSDN: HttpWebRequest Class
http://msdn.microsoft.com/en-us/library/system.net.httpwebrequest.aspx

MSDN: HttpWebResponse Class
http://msdn.microsoft.com/en-us/library/system.net.httpwebresponse.aspx

MSDN: .NET Framework Regular Expressions
http://msdn.microsoft.com/en-us/library/hs600312.aspx

MSDN: StreamReader Class
http://msdn.microsoft.com/en-us/library/system.io.streamreader.aspx

MSDN: List<T>.Contains Method 
http://msdn.microsoft.com/en-us/library/bhkz42b3.aspx
/////////////////////////////////////////////////////////////////////////////
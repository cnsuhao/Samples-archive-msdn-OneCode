========================================================================
              CSASPNETModifySessionStateSection Overview
========================================================================

/////////////////////////////////////////////////////////////////////////////
Use:

The project illustrates how to modify sessionState section in the Web.Config
file at run time. Customers always wants to know how to modify web.config in
code-behind page, thus, we provide two methods in this sample code to access
configuration file of web application. Remember if you change the Web.Config file,
the Asp.net application will restart, so please use it carefully.

/////////////////////////////////////////////////////////////////////////////
Demo the Sample. 

Please follow these demonstration steps below.

Step 1: Open the CSASPNETModifySessionStateSection.sln.

Step 2: Expand the CSASPNETModifySessionStateSection web application and press 
        Ctrl + F5 to show the Default.aspx or Default2.aspx.

Step 3: The users can find two TextBox controls and one Button on the page, 
        the current web.config settings displayed in controls.

Step 4: Change the value of controls and click button to modify configuration 
        file, after input correct value, you will receive the success messages,
		and view the forward messages in web.config file.

Step 5: Please open web.config file for value checking. After that, please test
        another web pages as the above steps.

Step 6: Validation finished.

/////////////////////////////////////////////////////////////////////////////
Code Logical:

Step 1. Create a C# "ASP.NET Empty Web Application" in Visual Studio 2010 or
        Visual Web Developer 2010. Name it as "CSASPNETModifySessionStateSection".

Step 2. Add two web forms in the root directory, name them as "Default.aspx", 
        "Default2.aspx".

Step 3. Add two labels, two Textboxes, one button on Default.aspx and Default2.aspx.
        And you need define a public string variable and embed it in UI layer.

Step 4. Add web.config file with Session settings, such as:
        [code]
    <system.web>
        <sessionState mode="InProc" cookieless="false" cookieName="MyCookie"
          timeout="1" />
    </system.web>
		[/code]
		
Step 5  In Default.aspx page, we use XmlDocument class to read and reset
        configuration file, the code as shown below: 
		[code]
        // Define common variables, public string, web.config file path and XmlDocument instance.
        public string strDisplay = string.Empty;
        protected string configPath = AppDomain.CurrentDomain.BaseDirectory + @"\Web.Config";
        XmlDocument document = new XmlDocument();

        /// <summary>
        /// Load current web.config information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                document.Load(configPath);
                XmlNode nodeSession = document.SelectSingleNode("/configuration/system.web/sessionState");
                XmlElement elementSession = (XmlElement)nodeSession;

                string strTimeOut = elementSession.Attributes["timeout"].Value;
                int value=0;
                if (int.TryParse(strTimeOut, out value) && value > 0)
                {
                    tbCookieTimeOut.Text = strTimeOut;
                }
                else
                {
                    lbError.Text = "Session Timeout value is incorrect.";
                }

                string strCookieName = elementSession.Attributes["cookieName"].Value;
                if (strCookieName != string.Empty)
                {
                    tbCookieName.Text = strCookieName;
                }
                else
                {
                    lbError.Text = "Session Name value is empty.";
                }
            }
        }

        /// <summary>
        /// Use XmlDocument instance to modify Session properties.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnModifyByXml_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder strbDisplay = new StringBuilder();
                document.Load(configPath);
                XmlNode nodeSession = document.SelectSingleNode("/configuration/system.web/sessionState");
                XmlElement elementSession = (XmlElement)nodeSession;
                strbDisplay.Append("Forward Settings:<br />");
                strbDisplay.Append("Session TimeOut: ");
                strbDisplay.Append(elementSession.Attributes["timeout"].Value);
                strbDisplay.Append("<br />");
                strbDisplay.Append("Session cookieName: ");
                strbDisplay.Append(elementSession.Attributes["cookieName"].Value);
                strDisplay = strbDisplay.ToString();

                string strMin = tbCookieTimeOut.Text.Trim();
                string strName = tbCookieName.Text.Trim();
                if (strName == string.Empty)
                {
                    lbError.Text = "Cookie Name is null.";
                    return;
                }
                int intMin;
                if (int.TryParse(strMin, out intMin))
                {
                    elementSession.Attributes["cookieName"].Value = strName;
                    elementSession.Attributes["timeout"].Value = intMin.ToString();
                    document.Save(configPath);
                    lbError.Text = "Save Web config file success, please can open web.config file for value checking.";
                }
                else
                {
                    lbError.Text = "Session Timeout value must be an integer number.";
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
	    [/code]

Step 6. In Default2.aspx page, we use WebConfigurationManager class to read and reset
        configuration file, the code as shown below: 
		[code]
		// Define common variables, public string and Configuration instance.
        public string strDisplay = string.Empty;
        Configuration manager;

        /// <summary>
        /// Load current web.config information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                manager = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
                SystemWebSectionGroup sections = manager.GetSectionGroup("system.web") as SystemWebSectionGroup;
                string cookieName = sections.SessionState.CookieName;
                if (!cookieName.Equals(string.Empty))
                {
                    tbCookieName.Text = cookieName;
                }
                else
                {
                    lbError.Text = "Session Name value is empty.";
                }

                TimeSpan timeout = sections.SessionState.Timeout;
                double minutes = timeout.TotalMinutes;
                if (!timeout.Equals(string.Empty) && minutes > 0)
                {
                    tbCookieTimeOut.Text = minutes.ToString();
                }
                else
                {
                    lbError.Text = "Session Timeout value is incorrect.";
                }
            }
        }

        /// <summary>
        /// Use WebConfigurationManager instance to get and set session state properties.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnModifyByXml_Click(object sender, EventArgs e)
        {
            try
            {
                manager = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
                SystemWebSectionGroup sections = manager.GetSectionGroup("system.web") as SystemWebSectionGroup;

                StringBuilder strbDisplay = new StringBuilder();
                strbDisplay.Append("Forward Settings:<br />");
                strbDisplay.Append("Session TimeOut: ");
                strbDisplay.Append(sections.SessionState.Timeout.TotalMinutes.ToString());
                strbDisplay.Append("(m) <br />");
                strbDisplay.Append("Session cookieName: ");
                strbDisplay.Append(sections.SessionState.CookieName);
                strDisplay = strbDisplay.ToString();

                string strMin = tbCookieTimeOut.Text.Trim();
                string strName = tbCookieName.Text.Trim();
                if (strName == string.Empty)
                {
                    lbError.Text = "Cookie Name is null.";
                    return;
                }
                double intMin;
                if (double.TryParse(strMin, out intMin))
                {
                    sections.SessionState.CookieName = strName;
                    sections.SessionState.Timeout = TimeSpan.FromMinutes(intMin);
                    manager.Save();
                    lbError.Text = "Save Web config file success, please can open web.config file for value checking.";
                }
                else
                {
                    lbError.Text = "Session Timeout value must be an integer number.";
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
		[/code]

Step 7. Build the application and you can debug it.
/////////////////////////////////////////////////////////////////////////////
References:

MSDN: Web.config
http://msdn.microsoft.com/en-us/library/aa306178.aspx

MSDN: WebConfigurationManager Class
http://msdn.microsoft.com/en-us/library/system.web.configuration.webconfigurationmanager.aspx

MSDN: XmlDocument Class
http://msdn.microsoft.com/en-us/library/system.xml.xmldocument.aspx
/////////////////////////////////////////////////////////////////////////////
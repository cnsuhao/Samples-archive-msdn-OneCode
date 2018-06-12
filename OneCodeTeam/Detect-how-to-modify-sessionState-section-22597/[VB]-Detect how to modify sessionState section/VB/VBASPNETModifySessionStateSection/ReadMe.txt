========================================================================
              VBASPNETModifySessionStateSection Overview
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

Step 1: Open the VBASPNETModifySessionStateSection.sln.

Step 2: Expand the VBASPNETModifySessionStateSection web application and press 
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

Step 1. Create a VB "ASP.NET Empty Web Application" in Visual Studio 2010 or
        Visual Web Developer 2010. Name it as "VBASPNETModifySessionStateSection".

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
    '' Define common variables, public string, web.config file path and XmlDocument instance.
    Public strDisplay As String = String.Empty
    Protected configPath As String = AppDomain.CurrentDomain.BaseDirectory + "\Web.Config"
    Private document As New XmlDocument()

    ''' <summary>
    ''' Load current web.config information.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            document.Load(configPath)
            Dim nodeSession As XmlNode = document.SelectSingleNode("/configuration/system.web/sessionState")
            Dim elementSession As XmlElement = DirectCast(nodeSession, XmlElement)

            Dim strTimeOut As String = elementSession.Attributes("timeout").Value
            Dim value As Integer = 0
            If Integer.TryParse(strTimeOut, value) AndAlso value > 0 Then
                tbCookieTimeOut.Text = strTimeOut
            Else
                lbError.Text = "Session Timeout value is incorrect."
            End If

            Dim strCookieName As String = elementSession.Attributes("cookieName").Value
            If strCookieName <> String.Empty Then
                tbCookieName.Text = strCookieName
            Else
                lbError.Text = "Session Name value is empty."
            End If
        End If

    End Sub
    ''' <summary>
    ''' Use XmlDocument instance to modify Session properties.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnModifyByXml_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnModifyByXml.Click
        Try
            Dim strbDisplay As New StringBuilder()
            document.Load(configPath)
            Dim nodeSession As XmlNode = document.SelectSingleNode("/configuration/system.web/sessionState")
            Dim elementSession As XmlElement = DirectCast(nodeSession, XmlElement)
            strbDisplay.Append("Forward Settings:<br />")
            strbDisplay.Append("Session TimeOut: ")
            strbDisplay.Append(elementSession.Attributes("timeout").Value)
            strbDisplay.Append("<br />")
            strbDisplay.Append("Session cookieName: ")
            strbDisplay.Append(elementSession.Attributes("cookieName").Value)
            strDisplay = strbDisplay.ToString()

            Dim strMin As String = tbCookieTimeOut.Text.Trim()
            Dim strName As String = tbCookieName.Text.Trim()
            If strName = String.Empty Then
                strDisplay = String.Empty
                lbError.Text = "Cookie Name is null."
                Return
            End If
            Dim intMin As Integer
            If Integer.TryParse(strMin, intMin) Then
                elementSession.Attributes("cookieName").Value = strName
                elementSession.Attributes("timeout").Value = intMin.ToString()
                document.Save(configPath)
                lbError.Text = "Save Web config file success, please can open web.config file for value checking."
            Else
                strDisplay = String.Empty
                lbError.Text = "Session Timeout value must be an integer number."
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
            strDisplay = String.Empty
        End Try
    End Sub

Step 6. In Default2.aspx page, we use WebConfigurationManager class to read and reset
        configuration file, the code as shown below: 
		[code]
    Public strDisplay As String = String.Empty
    ' Define common variables, public string and Configuration instance.
    Private manager As Configuration

    ''' <summary>
    ''' Load current web.config information.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            manager = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath)
            Dim sections As SystemWebSectionGroup = TryCast(manager.GetSectionGroup("system.web"), SystemWebSectionGroup)
            Dim cookieName As String = sections.SessionState.CookieName
            If Not cookieName.Equals(String.Empty) Then
                tbCookieName.Text = cookieName
            Else
                lbError.Text = "Session Name value is empty."
            End If

            Dim timeout As TimeSpan = sections.SessionState.Timeout
            Dim minutes As Double = timeout.TotalMinutes
            If Not timeout.Equals(String.Empty) AndAlso minutes > 0 Then
                tbCookieTimeOut.Text = minutes.ToString()
            Else
                lbError.Text = "Session Timeout value is incorrect."
            End If
        End If

    End Sub
    ''' <summary>
    ''' Use WebConfigurationManager instance to get and set session state properties.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnModifyByXml_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnModifyByXml.Click
        Try
            manager = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath)
            Dim sections As SystemWebSectionGroup = TryCast(manager.GetSectionGroup("system.web"), SystemWebSectionGroup)

            Dim strbDisplay As New StringBuilder()
            strbDisplay.Append("Forward Settings:<br />")
            strbDisplay.Append("Session TimeOut: ")
            strbDisplay.Append(sections.SessionState.Timeout.TotalMinutes.ToString())
            strbDisplay.Append("(m) <br />")
            strbDisplay.Append("Session cookieName: ")
            strbDisplay.Append(sections.SessionState.CookieName)
            strDisplay = strbDisplay.ToString()

            Dim strMin As String = tbCookieTimeOut.Text.Trim()
            Dim strName As String = tbCookieName.Text.Trim()
            If strName = String.Empty Then
                strDisplay = String.Empty
                lbError.Text = "Cookie Name is null."
                Return
            End If
            Dim intMin As Double
            If Double.TryParse(strMin, intMin) Then
                sections.SessionState.CookieName = strName
                sections.SessionState.Timeout = TimeSpan.FromMinutes(intMin)
                manager.Save()
                lbError.Text = "Save Web config file success, please can open web.config file for value checking."
            Else
                strDisplay = String.Empty
                lbError.Text = "Session Timeout value must be an integer number."
            End If
        Catch ex As Exception
            strDisplay = String.Empty
            Response.Write(ex.Message)
        End Try
    End Sub
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
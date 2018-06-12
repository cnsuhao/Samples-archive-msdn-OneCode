'****************************** Module Header ******************************\
'Module Name:  HomeController.vb
'Project:      AzureSQLReportingSerivces_MVC4Role
'Copyright (c) Microsoft Corporation.
'
'The sample code demonstrates how to access SQL Azure Reporting Service and
'get data by authenticated username/password by ReportViewer control and 
'non-ReportViewer clients (such as MVC project). The ReportViewer control
'with server report will help use send request to SQL Azure with credentials
'message, but in MVC role, we need to send request and analysis XML by code.
'
'This controller class is used to create web request to SQL Azure logon page,
'after login success, then get XML data from cloud and display on web page.
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System.Net
Imports System.IO

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        ViewBag.Message = "VBAzureSQLReportingServices"

        Dim request As HttpWebRequest = Nothing
        Dim response As HttpWebResponse = Nothing
        Dim sr As StreamReader = Nothing
        Dim serviceUri As String = "Your service server url" ' such as https://xxxx.reporting.windows.net/ReportServer 
        Dim servicePath As String = "You service folder path" ' such as /testFolder/testReport
        Dim logonPath As String = "/logon.aspx"
        Dim commandParameter As String = "rs:Command=GetSharedDatasetDefinition"
        Dim formatParameter As String = "rs:Format=XML"
        Dim reportServiceUrl As String = String.Format("{0}?{1}&{2}&{3}", serviceUri, servicePath, commandParameter, formatParameter)
        Dim loginUrl As String = String.Format("{0}{1}", serviceUri, logonPath)

        ' Request page protected by forms authentication.
        ' This request will get a 302 to login page
        request = DirectCast(WebRequest.Create(loginUrl), HttpWebRequest)
        request.AllowAutoRedirect = False
        Dim cookieContainer = New CookieContainer()
        request.CookieContainer = cookieContainer

        response = DirectCast(request.GetResponse(), HttpWebResponse)
        If response.StatusCode = HttpStatusCode.Found Then
            ViewBag.Status = "Response: 302 " & response.StatusCode
        Else
            ViewBag.Status = "Response status is " & response.StatusCode & ". Expected was Found"
        End If

        ' Get the url of login page from location header
        Dim locationHeader As String = response.GetResponseHeader("Location")

        ' Request login page
        request = DirectCast(WebRequest.Create(loginUrl), HttpWebRequest)
        request.AllowAutoRedirect = False
        request.CookieContainer = cookieContainer

        response = DirectCast(request.GetResponse(), HttpWebResponse)
        If response.StatusCode = HttpStatusCode.OK Then
            ViewBag.Status = "Response: " & response.StatusCode
        Else
            ViewBag.Status = "Response status is " & response.StatusCode & ". Expected was OK"
        End If


        sr = New StreamReader(response.GetResponseStream())
        Dim loginResponse As String = sr.ReadToEnd()
        sr.Close()

        ' Get SQL Azure Reporting service xml.
        Dim viewStateVar As String = "__VIEWSTATE="
        Dim viewStateSearchString As String = "name=""__VIEWSTATE"" id=""__VIEWSTATE"" value="""
        Dim viewStateStartIndex As Integer = loginResponse.IndexOf(viewStateSearchString)

        loginResponse = loginResponse.Substring(viewStateStartIndex + viewStateSearchString.Length)
        Dim viewStateValue As String = Uri.EscapeDataString(loginResponse.Substring(0, loginResponse.IndexOf(""" />")))
        loginResponse = loginResponse.Substring(loginResponse.IndexOf(""" />"))

        Dim userNameVar As String = "TxtUser="
        Dim userNameValue As String = "arwindgao"
        Dim passwordVar As String = "TxtPwd="
        Dim passwordValue As String = "Password0~"
        Dim loginButtonVar As String = "BtnLogon="
        Dim loginButtonValue As String = "Log+In"
        Dim eventValidationVar As String = "__EVENTVALIDATION="
        Dim eventValSearchString As String = "name=""__EVENTVALIDATION"" id=""__EVENTVALIDATION"" value="""
        Dim eventValStartIndex As Integer = loginResponse.IndexOf(eventValSearchString)
        loginResponse = loginResponse.Substring(eventValStartIndex + eventValSearchString.Length)
        Dim eventValidationValue As String = Uri.EscapeDataString(loginResponse.Substring(0, loginResponse.IndexOf(""" />")))
        Dim postString As String = viewStateVar & viewStateValue & "&" & userNameVar & userNameValue & "&" & passwordVar & passwordValue & "&" & loginButtonVar & loginButtonValue & "&" & eventValidationVar & eventValidationValue

        ' Do a POST to login.aspx now
        ' This should result in 302 with Set-Cookie header
        request = DirectCast(WebRequest.Create(loginUrl), HttpWebRequest)
        request.AllowAutoRedirect = False
        request.CookieContainer = cookieContainer
        request.Method = "POST"
        request.ContentType = "application/x-www-form-urlencoded"

        Dim encoding As New System.Text.ASCIIEncoding()
        Dim requestData As Byte() = encoding.GetBytes(postString)
        request.ContentLength = requestData.Length
        Dim requestStream As Stream = request.GetRequestStream()
        requestStream.Write(requestData, 0, requestData.Length)
        requestStream.Close()
        response = DirectCast(request.GetResponse(), HttpWebResponse)

        request = DirectCast(WebRequest.Create(reportServiceUrl), HttpWebRequest)
        request.AllowAutoRedirect = False
        request.CookieContainer = cookieContainer

        response = DirectCast(request.GetResponse(), HttpWebResponse)
        If response.StatusCode = HttpStatusCode.OK Then
            ViewBag.Status = "Response: " & response.StatusCode
        Else
            ViewBag.Status = "Response status is " & response.StatusCode & ". Expected was OK"
        End If

        sr = New StreamReader(response.GetResponseStream())
        Dim strXML As String = sr.ReadToEnd()
        sr.Close()

        Dim document As XDocument = XDocument.Parse(strXML)
        Dim personList As New List(Of Person)()
        Dim list = From node In document.Descendants(XName.[Get]("Detail", "testReport"))
                   Select node
        For Each node In list
            Dim person As New Person()
            Dim id As Integer
            If Integer.TryParse(node.Attribute("ID").Value, id) Then
                person.Name = node.Attribute("Name").Value
                person.ID = id
                person.Comments = node.Attribute("Comments").Value
                personList.Add(person)
            End If
        Next

        ViewBag.NumTimes = personList.Count
        ViewBag.List = personList

        Return View()
    End Function
End Class

/****************************** Module Header ******************************\
Module Name:  HomeController.cs
Project:      AzureSQLReportingSerivces_MVC4Role
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to access SQL Azure Reporting Service and
get data by authenticated username/password by ReportViewer control and 
non-ReportViewer clients (such as MVC project). The ReportViewer control
with server report will help use send request to SQL Azure with credentials
message, but in MVC role, we need to send request and analysis XML by code.

This controller class is used to create web request to SQL Azure logon page,
after login success, then get XML data from cloud and display on web page.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Specialized;
using System.Web.Security;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Xml;

namespace AzureSQLReportingSerivces_MVC4Role.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "CSAzureSQLReportingServices";

            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader sr = null;
            string serviceUri = "https://0ugtwo-e6e.reporting.windows.net/ReportServer"; // such as https://xxxx.reporting.windows.net/ReportServer 
            string servicePath = "/SQLAzureTestDB/testReport"; // such as /testFolder/testReport
            string logonPath = "/logon.aspx";
            string commandParameter = "rs:Command=GetSharedDatasetDefinition";
            string formatParameter = "rs:Format=XML";
            string reportServiceUrl = string.Format("{0}?{1}&{2}&{3}", serviceUri, servicePath, commandParameter, formatParameter);
            string loginUrl = string.Format("{0}{1}", serviceUri, logonPath);

            // Request page protected by forms authentication.
            // This request will get a 302 to login page
            request = (HttpWebRequest)WebRequest.Create(loginUrl);
            request.AllowAutoRedirect = false;
            var cookieContainer = new CookieContainer();
            request.CookieContainer = cookieContainer;

            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.Found)
            {
                ViewBag.Status = "Response: 302 ";
                ViewBag.Status += response.StatusCode;
            }
            else
            {
                ViewBag.Status = "Response status is " + response.StatusCode + ". Expected was Found";
            }

            // Get the url of login page from location header
            string locationHeader = response.GetResponseHeader("Location");

            // Request login page
            request = (HttpWebRequest)WebRequest.Create(loginUrl);
            request.AllowAutoRedirect = false;
            request.CookieContainer = cookieContainer;

            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                 ViewBag.Status = "Response: 200 ";
                 ViewBag.Status += response.StatusCode;
            }
            else
            {
                 ViewBag.Status = "Response status is " + response.StatusCode + ". Expected was OK";
            }


            sr = new StreamReader(response.GetResponseStream());
            string loginResponse = sr.ReadToEnd();
            sr.Close();

            // Get SQL Azure Reporting service xml.
            string viewStateVar = "__VIEWSTATE=";
            string viewStateSearchString = "name=\"__VIEWSTATE\" id=\"__VIEWSTATE\" value=\"";
            int viewStateStartIndex = loginResponse.IndexOf(viewStateSearchString);

            loginResponse = loginResponse.Substring(viewStateStartIndex + viewStateSearchString.Length);
            string viewStateValue = Uri.EscapeDataString(loginResponse.Substring(0, loginResponse.IndexOf("\" />")));
            loginResponse = loginResponse.Substring(loginResponse.IndexOf("\" />"));

            string userNameVar = "TxtUser=";
            string userNameValue = "arwindgao";
            string passwordVar = "TxtPwd=";
            string passwordValue = "Password0~";
            string loginButtonVar = "BtnLogon=";
            string loginButtonValue = "Log+In";
            string eventValidationVar = "__EVENTVALIDATION=";
            string eventValSearchString = "name=\"__EVENTVALIDATION\" id=\"__EVENTVALIDATION\" value=\"";
            int eventValStartIndex = loginResponse.IndexOf(eventValSearchString);
            loginResponse = loginResponse.Substring(eventValStartIndex + eventValSearchString.Length);
            string eventValidationValue =
                Uri.EscapeDataString(
                    loginResponse.Substring(0, loginResponse.IndexOf("\" />"))
                );
            string postString = viewStateVar + viewStateValue;
            postString += "&" + userNameVar + userNameValue;
            postString += "&" + passwordVar + passwordValue;
            postString += "&" + loginButtonVar + loginButtonValue;
            postString += "&" + eventValidationVar + eventValidationValue;

            // Do a POST to login.aspx now
            // This should result in 302 with Set-Cookie header
            request = (HttpWebRequest)WebRequest.Create(loginUrl);
            request.AllowAutoRedirect = false;
            request.CookieContainer = cookieContainer;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] requestData = encoding.GetBytes(postString);
            request.ContentLength = requestData.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(requestData, 0, requestData.Length);
            requestStream.Close();
            response = (HttpWebResponse)request.GetResponse();

            request = (HttpWebRequest)WebRequest.Create(reportServiceUrl);
            request.AllowAutoRedirect = false;
            request.CookieContainer = cookieContainer;

            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                ViewBag.Status = "Response: 200 ";
                ViewBag.Status += response.StatusCode;
            }
            else
            {
                 ViewBag.Status = "Response status is " + response.StatusCode + ". Expected was OK";
            }

            sr = new StreamReader(response.GetResponseStream());
            string strXML = sr.ReadToEnd();
            sr.Close();

            XDocument document = XDocument.Parse(strXML);
            List<Person> personList = new List<Person>();
            var list = from node in document.Descendants(XName.Get("Detail", "testReport"))
                       select node;
            foreach (var node in list)
            {
                Person person = new Person();
                int id;
                if (int.TryParse(node.Attribute("ID").Value, out id))
                {
                    person.Name = node.Attribute("Name").Value;
                    person.ID = id;
                    person.Comments = node.Attribute("Comments").Value;
                    personList.Add(person);
                }
            }

            ViewBag.NumTimes = personList.Count;
            ViewBag.List = personList;

            return View();
        }
    }
}

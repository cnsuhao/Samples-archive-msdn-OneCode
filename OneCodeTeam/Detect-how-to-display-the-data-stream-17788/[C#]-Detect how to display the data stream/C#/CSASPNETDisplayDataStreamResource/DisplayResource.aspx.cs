/****************************** Module Header ******************************\
* Module Name: DisplayResource.aspx.cs
* Project:     CSASPNETDisplayDataStreamResource
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to display the data stream from Internet resource
* and site resource in a web page. Customers want to know how to display the 
* title, content or other information of web pages. Thus, the sample can search
* the target web page which you input url address in TextBox control and get all
* relative link resources of it. 
* 
* The page is used to display relative web pages by key words.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;

namespace CSASPNETDisplayDataStreamResource
{
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
}
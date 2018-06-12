/****************************** Module Header ******************************\
Module Name:  HTTPAPI.aspx.cs
Project:      CSTranslatorForAzure
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to use Bing translator API when you get it 
from Azure marked place.

This web form page shows a form with input controls and can translate English
to Chinese by HTTP API.
 
This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;

namespace TranslatorForAzure.Page
{
    public partial class HTTPAPI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Obtaining an access token, and use Microsoft translator HTTP API for translating.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnTranslate_Click(object sender, EventArgs e)
        {
            //Obtaining an access token.
            AdmAuthentication authentication =
               new AdmAuthentication(UserData.clientID, UserData.clientSecret);
            string headerValue;
            AdmAccessToken token = authentication.GetAccessToken();
            headerValue = "Bearer " + token.access_token;
            try
            {
                //Add access token to header.
                string txtToTranslate = tbNeedTranslate.Text;
                string uri = "http://api.microsofttranslator.com/v2/Http.svc/Translate?text=" +
                              System.Web.HttpUtility.UrlEncode(txtToTranslate) +
                             "&from=en&to=zh-CHS";
                WebRequest translationWebRequest = WebRequest.Create(uri);
                translationWebRequest.Headers.Add("Authorization", headerValue);
                WebResponse response = null;
                response = translationWebRequest.GetResponse();
                Stream stream = response.GetResponseStream();
                Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
                System.IO.StreamReader translatedStream = new System.IO.StreamReader(stream, encode);
                System.Xml.XmlDocument xTranslation = new System.Xml.XmlDocument();
                xTranslation.LoadXml(translatedStream.ReadToEnd());
                lblEntitySet.Text = xTranslation.InnerText;
               
            }
            catch (WebException ex)
            {
                //Please check your client ID, client secret, redirect url, if this exception hit.
                ProcessWebException(ex);


            }
            catch (Exception ex1)
            {

                Response.Write(ex1.Message);
            }

        }

        /// <summary>
        /// Obtain detailed error information.
        /// </summary>
        /// <param name="e"></param>
        private void ProcessWebException(WebException e)
        {
           
            string strResponse = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)e.Response)
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(responseStream, System.Text.Encoding.ASCII))
                    {
                        strResponse = sr.ReadToEnd();
                    }
                }
            }
            Page.Response.Write("Http status code =" + e.Status + " error message={1}" + strResponse);
        }

    }
}
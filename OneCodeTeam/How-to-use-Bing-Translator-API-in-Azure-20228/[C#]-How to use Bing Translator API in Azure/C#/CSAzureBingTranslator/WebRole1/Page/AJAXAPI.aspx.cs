/****************************** Module Header ******************************\
Module Name:  AJAXAPI.aspx.cs
Project:      CSTranslatorForAzure
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to use Bing translator API when you get it 
from Azure marked place.

This web form page shows a form with input controls and can translate English
to Chinese by AJAX API.
 
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

namespace TranslatorForAzure.Page
{
    public partial class AJAXAPI : System.Web.UI.Page
    {

        /// <summary>
        /// Obtaining an access token.
        /// This is used to authenticate you access to the Microsoft translator API.
        /// </summary>
        /// <returns></returns>
        [System.Web.Services.WebMethod]
        public static AdmAccessToken GetAccessToken()
        {
            AdmAuthentication authentication =
              new AdmAuthentication(UserData.clientID, UserData.clientSecret);

            return authentication.GetAccessToken();

           
        } 

        

        protected void Page_Load(object sender, EventArgs e)
        {


        }

       
    }
}
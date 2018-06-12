/****************************** Module Header ******************************\
* Module Name:    Default.cs
* Project:        CSASPNETRunScriptsAfterServerSideValidation
* Copyright (c) Microsoft Corporation.
*
* The default page demonstrates how to run scripts after server side validation
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNETRunScriptsAfterServerSideValidation
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
            string strMail = Request.Form["tbEmail"];

            if (IsPostBack)
            {
                if (!String.IsNullOrEmpty(strMail))
                {
                    // Declare the pattern to validate the email.
                    string strPattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

                    if (System.Text.RegularExpressions.Regex.IsMatch(strMail, strPattern))
                    {
                        // Register a script to run at client side.
                        Page.ClientScript.RegisterStartupScript(GetType(), "Alert", "<script>document.getElementById('divTask').style.display='block';</script>");
                    }
                    else
                    {
                        CustomValidator1.IsValid = false;
                    }
                }
            }
        }
    }
}
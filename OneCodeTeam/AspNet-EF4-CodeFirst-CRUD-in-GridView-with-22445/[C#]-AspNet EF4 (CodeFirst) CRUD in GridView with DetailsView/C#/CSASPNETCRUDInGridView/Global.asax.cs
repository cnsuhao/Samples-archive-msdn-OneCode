/****************************** Module Header ******************************\
* Module Name:    Global.asax
* Project:        CSASPNETCodeFirstCRUDInGridViewWithDetailsView
* Copyright (c) Microsoft Corporation
*
* The file is used to automatically generate db with several tables when
* server starts.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
\***************************************************************************/

using System;
using System.Configuration;

namespace ASPNETCodeFirstCRUDInGridView
{
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// To decide whether to create data contents once the Server starts.
        /// </summary>
        protected void Application_Start(object sender, EventArgs e)
        {
            DBCreator.DBAutoCreator(Convert.ToBoolean(ConfigurationManager.AppSettings["RecreateDB"]));
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
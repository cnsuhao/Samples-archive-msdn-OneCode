/****************************** Module Header ******************************\
* Module Name:    Default.aspx.cs
* Project:        CSASPNETCheckPageRefresh
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to check whether the page is refreshed or not.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
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

namespace CSASPNETCheckPageRefresh
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsNotRefresh())
            {
                WriteMsg("Page is not refreshed.");
                // Do your logic code here
            }
            else
            {
                WriteMsg("Page is refreshed.");
                // Do your logic code here
            }
         
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsNotRefresh())
            {
                WriteMsg("Page is not refreshed.");
                // Do your logic code here
            }
        }

        /// <summary>
        /// Output some message
        /// </summary>
        /// <param name="strMsg"></param>
        private void WriteMsg(string strMsg)
        {
            Response.Clear();
            Response.Write(strMsg);
        }

        /// <summary>
        /// Determine whether is refresh or not
        /// </summary>
        /// <returns></returns>
        private bool IsNotRefresh()
        {
            bool isNotRefresh = true;

            // User Control
            CheckRefreshUserControl cruc = this.FindControl("CheckRefreshUserControl1") as CheckRefreshUserControl;            
            // Result
            isNotRefresh = cruc.ReFreshCheck == false ? true : false;
            return isNotRefresh;
        }
    }
}

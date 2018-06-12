/****************************** Module Header ******************************\
* Module Name:    CheckRefreshUserControl.ascx.cs
* Project:        CSASPNETCheckPageRefresh
* Copyright (c) Microsoft Corporation
*
* Reusable User Control.
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
    public partial class CheckRefreshUserControl : System.Web.UI.UserControl
    {
        /// <summary> 
        /// Flag for checking whether duplicated refreshing or not.
        /// </summary>   
        public bool ReFreshCheck { get; set; }

        /// <summary>     
        /// Fetch the parent page's class name, which is unique.    
        /// </summary>  
        string parentName = null;
        protected override void OnInit(EventArgs e)
        {
            if (Parent.Parent is Page)
            {
                parentName = Parent.Parent.GetType().Name;

                // If it is Post Back, Reset the Session value to null, and it represents 
                // it's not a repeated loading.
                if (IsPostBack)
                {
                    ReFreshCheck = false;
                    Session[parentName] = null;
                }
                else if (Request.UrlReferrer != null && Request.UrlReferrer.ToString() != Request.Url.ToString())
                {
                    // Detect whether the request coms from the other page. 
                    Session[parentName] = null;
                }
                else
                {                   
                    if (Session[parentName] == null)
                    {
                        ReFreshCheck = false;
                        Session[parentName] = true;
                    }
                    else
                    {
                        ReFreshCheck = true;
                    }
                }
            }
            else
            {
                throw new Exception("You must put the control inside the page!");
            }
        }      
    }
}
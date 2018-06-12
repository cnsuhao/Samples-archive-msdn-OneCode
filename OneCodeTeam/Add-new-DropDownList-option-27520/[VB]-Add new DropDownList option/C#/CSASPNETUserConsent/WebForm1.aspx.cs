/****************************** Module Header ******************************\
Module Name:  WebForm1.aspx.cs
Project:      CSASPNETUserConsent
Copyright (c) Microsoft Corporation.

This project uses ModalPopupExtender to display a popup for asking a user 
whether or not to add a new item to a DropDownList.
 
This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/
using System;
using System.Web.UI.WebControls;

namespace CSASPNETUserConsent
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void ok_Click(object sender, EventArgs e)
        {
            String content = newitem.Text;

            if (content == "")
            {
                Response.Write("New item must not be empty.");
            }
            else
            {
                ddl.Items.Insert(0, new ListItem(content));
                ddl.SelectedIndex = 0;
            }
        }
    }
}
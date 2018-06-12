/****************************** Module Header ******************************\
 * Module Name:  Test.aspx.cs
 * Project:      CSSharePointSetPageStatus
 * Copyright (c) Microsoft Corporation.
 * 
 * This sample will show you how to add page status to an application page
 * and from list event receiver. 
 * This is custom web part.
 *
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace CSSharePointSetPageStatus.Layouts.SharePointSetPageStatus
{
    public partial class Test : LayoutsPageBase
    {
        SPPageStatusSetter spss = new SPPageStatusSetter();
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {       
            spss.AddStatus("Tip", "Welcome to OneCode!", SPPageStatusColor.Green);
            this.Controls.Add(spss);
        }

        protected void btnHide_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(spss);            
        }
    }
}

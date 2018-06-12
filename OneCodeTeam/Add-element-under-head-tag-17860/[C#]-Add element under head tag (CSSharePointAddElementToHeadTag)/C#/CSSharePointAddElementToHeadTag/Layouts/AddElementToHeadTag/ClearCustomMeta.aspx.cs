/****************************** Module Header ******************************\
* Module Name:    ClearCustomMeta.aspx.cs
* Project:        CSSharePointAddElementToHeadTag
* Copyright (c) Microsoft Corporation
*
* This page is used to clear the custom Meta information.
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
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Utilities;
using System.Collections.Generic;

namespace FarmSolutionPages.Layouts.AddElementToHeadTag
{
    public partial class ClearCustomMeta : LayoutsPageBase
    {
        SPWeb myWeb = SPContext.Current.Web;

        protected void cmdClearMeta_Click(object sender, EventArgs e)
        {
            // A List to store the Meta which we need to remove.
            List<string> listKey = new List<string>();

            // Loop AllProperties to identify the items which need to be removed.
            foreach (System.Collections.DictionaryEntry objDE in myWeb.AllProperties)
            {
                if (objDE.Key.ToString().Contains("-CustomMeta"))
                {
                    listKey.Add(objDE.Key.ToString());
                }
            }

            // Remove the custom Meta
            for (int i = 0; i < listKey.Count; i++)
            {
                myWeb.AllProperties.Remove(listKey[i]);
            }

            myWeb.Update();

            SPUtility.Redirect("settings.aspx", SPRedirectFlags.RelativeToLayoutsPage,
             this.Context);

        }

        protected override void OnInit(EventArgs e)
        {
            cmdClearMeta.Click += new EventHandler(cmdClearMeta_Click);
        }
    }
}

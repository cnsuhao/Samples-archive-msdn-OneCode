/****************************** Module Header ******************************\
* Module Name:    Default.aspx.cs
* Project:        CSASPNETInParameterOfSql
* Copyright (c) Microsoft Corporation
*
* This sample code will demonstrate how to set value to “IN Parameter” of SqlDataSource
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

namespace CSASPNETInParameterOfSql
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// set the id dynamically
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDynamicShow_Click(object sender, EventArgs e)
        {
            // list of selected id
            List<string> productIDs = new List<string>();

            foreach (ListItem li in CheckBoxList1.Items)
            {
                if (li.Selected)
                {
                    productIDs.Add(li.Value);
                }
            }

            if (productIDs.Count > 0)
            {
                SqlDataSource1.SelectCommand = String.Format(
              "SELECT [Id], [Name] FROM [Test] WHERE ([Id] IN ({0}))",
              String.Join(", ", productIDs.ToArray()));
            }
        }

        /// <summary>
        /// set the id static
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnStaticShow_Click(object sender, EventArgs e)
        {
            // list of selected id
            string s = "1,2,3,4,5";
            string[] strings = s.Split(',');

            SqlDataSource1.SelectCommand = String.Format(
                "SELECT [Id], [Name] FROM [Test] WHERE ([Id] IN ({0}))",
                String.Join(", ", strings.ToArray()));
        }
    }
}

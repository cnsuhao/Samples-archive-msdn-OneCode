/****************************** Module Header ******************************\
* Module Name:    Default.aspx.cs
* Project:        CSASPNETMultiFiltering
* Copyright (c) Microsoft Corporation
*
* This is the default interface that is used to show the user-defined control.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
\*****************************************************************************/
using System;
namespace CSASPNETMultiFiltering
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MultiFiltering1.BindingSqlDataSourceId = "SqlDataSource1";
                
            }
        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            SqlDataSource1.FilterExpression = MultiFiltering1.FilterExpression;
        }

    }
}
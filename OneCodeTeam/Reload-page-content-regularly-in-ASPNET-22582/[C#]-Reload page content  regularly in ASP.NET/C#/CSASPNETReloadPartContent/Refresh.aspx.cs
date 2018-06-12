/****************************** Module Header ******************************\
* Module Name:    Refresh.aspx.cs
* Project:        CSASPNETReloadPartContent
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to reload part of page content regularly.
* This page is used to load the data. 
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
using System.Data;

namespace CSASPNETReloadPartContent
{
    public partial class Refresh : System.Web.UI.Page
    {
        //Declare a table to store data:custom or query from Database
        DataTable dtResult = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Put your logic here.        

            BindResult();
        }

        //Here i create a table to store the time of refresh,you can put your logic here instead of it.
        private void BindResult()
        {
            //In the actual scene, you may not need operating the session, here is just to test
            if (Session["dtResult"] != null)
            {
                dtResult = (DataTable)Session["dtResult"];
            }
            else
            {
                dtResult = new DataTable();
                dtResult.Columns.Add("Id");
                dtResult.Columns.Add("Time");
            }

            DataRow dr = dtResult.NewRow();
            dr["Id"] = dtResult.Rows.Count + 1;
            dr["Time"] = DateTime.Now.ToString();
            dtResult.Rows.Add(dr);

            //Save data to Session, in a 
            Session["dtResult"]=dtResult;
            //Bind data to GridView
            rptResult.DataSource = dtResult;
            rptResult.DataBind();
        }
    }
}

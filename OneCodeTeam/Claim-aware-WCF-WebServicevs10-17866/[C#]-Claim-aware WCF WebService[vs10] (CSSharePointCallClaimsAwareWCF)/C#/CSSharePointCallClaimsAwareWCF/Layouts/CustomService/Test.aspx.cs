/****************************** Module Header ******************************\
* Module Name:    Test.aspx.cs
* Project:        CSSharePointCallClaimsAwareWCF
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to accomplish custom claim-ware WCF web service 
* for SharePoint 2010.
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

namespace CustomService.Layouts.CustomService
{
    public partial class Test : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomServiceClient client = new CustomServiceClient(SPServiceContext.Current);

            int sum = client.Add(1, 1);

            string strSayHello = client.HelloWorld();

            TestOutputLabel.Text = String.Format("1 + 1 = {0}", sum) + "<br/>" + strSayHello;
        }      
    }
}

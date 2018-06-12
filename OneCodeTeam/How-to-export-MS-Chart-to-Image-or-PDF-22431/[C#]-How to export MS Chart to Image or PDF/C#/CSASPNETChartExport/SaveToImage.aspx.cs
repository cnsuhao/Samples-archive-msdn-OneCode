/****************************** Module Header ******************************\
* Module Name:    SaveToImage.aspx.cs
* Project:        CSASPNETChartExport
* Copyright (c) Microsoft Corporation
*
* This page shows how to export Chart to Image.
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
using System.Web.UI.DataVisualization.Charting;

namespace CSASPNETChartExport
{
    public partial class SaveToImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Bind data to chart.
            Utilities.DisplayChart(myChart);
        }     

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Export FileName
            string exportFileName = Server.MapPath("Images") + "/testImage.jpg";

            // Save image.
            myChart.SaveImage(exportFileName, ChartImageFormat.Jpeg);

            // Prompt.
            this.ClientScript.RegisterStartupScript(this.GetType(), "exportChart", string.Format("alert('It has been successfully exported to:{0}');", exportFileName.Replace('\\', '/')), true);
        }
    }
}
/****************************** Module Header ******************************\
* Module Name:    SaveToPdf.aspx.cs
* Project:        CSASPNETChartExport
* Copyright (c) Microsoft Corporation
*
* This page shows how to export Chart to Pdf.
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
using System.IO;
using System.Web.UI.DataVisualization.Charting;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CSASPNETChartExport
{
    public partial class SaveToPdf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Render the chart.
            Utilities.DisplayChart(myChart);
        }      

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Specify the content type.
            Response.ContentType = "application/pdf";

            // Add a Content-Disposition header.
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}.pdf", "test"));

            // Render the chart.
            Utilities.DisplayChart(myChart);
           
            #region Generate the exported content and send it to the client.
            // Create a Document object
            Document doc = new Document();

            try
            {
                // Create a writer to dump the contents of the Document to the Response.OutputStream stream
                PdfWriter writer = PdfWriter.GetInstance(doc, Response.OutputStream);
                doc.Open();

                // Now create the chart image and add it to the PDF
                using (MemoryStream imgStream = new MemoryStream())
                {
                    // Save the chart to a MemoryStream
                    myChart.SaveImage(imgStream, ChartImageFormat.Png);

                    // Create an Image object from the MemoryStream data
                    Image img = Image.GetInstance(imgStream.ToArray());

                    // Scale the Image object to fit within the boundary of the PDF document and add it
                    img.ScaleToFit(doc.PageSize.Width - (doc.LeftMargin + doc.RightMargin), doc.PageSize.Height - (doc.TopMargin + doc.BottomMargin));
                    doc.Add(img);
                }
            }
            finally
            {
                doc.Close();
            }
            #endregion

            // Indicate that the data to send to the client has ended
            Response.End();
        }
        
    }
}
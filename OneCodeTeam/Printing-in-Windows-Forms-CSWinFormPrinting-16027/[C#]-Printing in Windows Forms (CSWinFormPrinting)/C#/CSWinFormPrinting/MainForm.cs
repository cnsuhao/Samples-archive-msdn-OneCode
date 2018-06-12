/************************************* Module Header **************************************\
* Module Name:  MainForm.cs
* Project:      CSWinFormPrinting
* Copyright (c) Microsoft Corporation.
* 
* This Printing sample demonstrates how to create a standard print job in a Windows Forms 
* application.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

#region Using directives
using System;
using System.Drawing;
using System.Windows.Forms;
#endregion


namespace CSWinFormPrinting
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void frmPrinting_Load(object sender, EventArgs e)
        {
            // The example assumes your form has a Button control, 
            // a PrintDocument component named myDocument, 
            // and a PrintPreviewDialog control. 

            // Handle the PrintPage event to write the print logic.
            this.printDocument1.PrintPage += 
                new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);

            // Specify a PrintDocument instance for the PrintPreviewDialog component.
            this.printPreviewDialog1.Document = this.printDocument1;
        }

        void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Specify what to print and how to print in this event handler.
            // The follow code specify a string and a rectangle to be print 

            using (Font f = new Font("Vanada", 12))
            using (SolidBrush br = new SolidBrush(Color.Black))
            using (Pen p = new Pen(Color.Black)) 
            {
                e.Graphics.DrawString("This is a text.", f, br, 50, 50);

                e.Graphics.DrawRectangle(p, 50, 100, 300, 150);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.printPreviewDialog1.ShowDialog();
        }
    }
}

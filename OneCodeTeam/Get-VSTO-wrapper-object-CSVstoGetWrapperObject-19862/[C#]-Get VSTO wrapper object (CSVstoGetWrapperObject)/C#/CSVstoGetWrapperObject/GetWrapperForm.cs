﻿/************************************* Module Header ************************\
* Module Name:	GetWrapperForm.cs
* Project:		CSVstoGetWrapperObject
* Copyright (c) Microsoft Corporation.
* 
* The CSVstoGetWrapperObject project demonstrates how to get a VSTO wrapper
* object from an existing Office COM object.
*
* This feature requires Visual Studio Tools for Office 4.0 SP1 (included in 
* Visual Studio 2012) for both design-time and runtime support.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\******************************************************************************/


#region Using directives
using System;
using System.Windows.Forms;
using Microsoft.Office.Tools.Excel;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Excel = Microsoft.Office.Interop.Excel;
#endregion

namespace CSVstoGetWrapperObject
{
    public partial class GetWrapperForm : Form
    {
        public GetWrapperForm()
        {
            InitializeComponent();
        }

        private void GetWrapperForm_Load(object sender, System.EventArgs e)
        {
            btnRefreshWb.PerformClick();
        }

        /// <summary>
        /// Refresh the Workbook list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshWb_Click(object sender, EventArgs e)
        {
            cboWorkbooks.Items.Clear();

            foreach (Excel.Workbook wb in Globals.ThisAddIn.Application.Workbooks)
            {
                cboWorkbooks.Items.Add(wb);
            }

            bool hasWorkbook = cboWorkbooks.Items.Count > 0;

            cboWorksheets.Enabled = hasWorkbook;
            btnRefreshWs.Enabled = hasWorkbook;
            btnAddListObject.Enabled = hasWorkbook;

            if (hasWorkbook)
            {
                cboWorkbooks.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Workbook selection changed, refresh the Workseet list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboWorkbooks_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cboWorkbooks.SelectedItem != null)
            {
                btnRefreshWs.PerformClick();
            }
        }

        /// <summary>
        /// Refresh the Worksheet list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshWs_Click(object sender, System.EventArgs e)
        {
            Excel.Workbook wb = (Excel.Workbook)cboWorkbooks.SelectedItem;
            cboWorksheets.Items.Clear();

            foreach (Excel.Worksheet ws in wb.Worksheets)
            {
                cboWorksheets.Items.Add(ws);
            }

            cboWorksheets.SelectedIndex = 0;
        }

        /// <summary>
        /// Adds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddListObject_Click(object sender, System.EventArgs e)
        {
            // This is Microsoft.Office.Interop.Excel.Worksheet (COM)
            Excel.Worksheet ws = (Excel.Worksheet)cboWorksheets.SelectedItem;
            ((Excel._Worksheet)ws).Activate();

            // This is Microsoft.Office.Tools.Excel.Worksheet (VSTO wrapper)
            Worksheet vstoWs = Globals.Factory.GetVstoObject(ws);

            try
            {
                // Now we have the VSTO wrapper, add some VSTO objects to it...
                // First a ListObject
                ListObject lo = vstoWs.Controls.AddListObject(vstoWs.Range["A3", Type.Missing], "myTable");
                // Try bind some data to the ListObject
                lo.DataSource = GetDemoData();
                lo.DataMember = "DemoTable";

                // Now add a button.
                Button btnVsto = vstoWs.Controls.AddButton(vstoWs.Range["A1", Type.Missing], "btnVSTO");
                btnVsto.Text = "VSTO Button";
                btnVsto.Width = 100;
                btnVsto.Height = 23;
                // Setup the button Click event handler.
                btnVsto.Click += delegate(object s, EventArgs args)
                {
                    MessageBox.Show("VSTO button clicked.", "GetVstoObject demo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
            }
            catch (RuntimeException rtEx)
            {
                MessageBox.Show(rtEx.ToString(), "GetVstoObject demo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Generates some data for ListObject databinding.
        /// </summary>
        /// <returns></returns>
        private DemoData GetDemoData()
        {
            DemoData data = new DemoData();

            data.DemoTable.Rows.Add(new object[] { null, "John", new DateTime(1978, 2, 20) });
            data.DemoTable.Rows.Add(new object[] { null, "Eric", new DateTime(1987, 6, 12) });
            data.DemoTable.Rows.Add(new object[] { null, "Mary", new DateTime(1980, 8, 10) });
            data.DemoTable.Rows.Add(new object[] { null, "Mike", new DateTime(1991, 1, 9) });
            data.DemoTable.Rows.Add(new object[] { null, "Joe", new DateTime(1983, 3, 31) });
            data.DemoTable.Rows.Add(new object[] { null, "Lance", new DateTime(1988, 5, 11) });
            data.DemoTable.Rows.Add(new object[] { null, "Tom", new DateTime(1970, 9, 30) });

            return data;
        }
    }
}

/****************************** Module Header ******************************\
* Module Name:  OutlookContacts.cs
* Project:      CSOutLookContactsExportImport
* Copyright (c) Microsoft Corporation.
* 
* The main form of Exporting/Import outlook contacts 
* Click "Export" button to export the outlook contacts to the excel file
* 
* Import outlook contacts form excel spreadsheet as following steps:
* First select an excel spreadsheet to import
* Then Click "Import" button to import the contacts into outlook 
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/



using System;
using System.IO;
using System.Windows.Forms;

namespace CSOutLookContactsExportImport
{
    public partial class OutlookContacts : Form
    {
        
        // Initialize OutlookProvider Object
        OutlookProvider outlook = new OutlookProvider();
        
        // Define connecting string
        string connectingstr = null;
        public OutlookContacts()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Import contacts from Excel spreadsheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxImportExcel.Text == string.Empty)
                {
                    MessageBox.Show("Please select an Excel spreadsheet to import!", "Tips", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }

                // Initialize Connecting String
                connectingstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + tbxImportExcel.Text + ";Extended Properties='Excel 12.0 Xml;HDR=Yes'";

                // call import method to import contacts into outlook
                outlook.ContactsImportFromExcel(connectingstr);
                MessageBox.Show("Import success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Import Exception is: " + ex.Message, "Exception");
            }
        }

        /// <summary>
        /// Select excel spreadsheet to import
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowseImp_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Application.StartupPath;
                openFileDialog.Filter = "All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tbxImportExcel.Text = openFileDialog.FileName;
                }
            }
        }

        /// <summary>
        /// Export outlook contacts to excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {   
            // Exported excel file path
            string exportpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\ContactsExport.xlsx";
           
            // Initialize Connecting String
            string connectingstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + exportpath + ";Extended Properties='Excel 12.0 Xml;HDR=Yes'";
            try
            {
                if (File.Exists(exportpath))
                {
                    // If the excel file has existed in directory
                    // Delete the existing excel and create a new excel file to store the contacts.
                    File.Delete(exportpath);
                    outlook.ContactsExportToExcel(connectingstr, outlook.ContactsItems);
                }
                else
                {
                    outlook.ContactsExportToExcel(connectingstr, outlook.ContactsItems);
                }

                MessageBox.Show("Export success! Exported file path is: " + exportpath);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Export Exception is: " + ex.Message, "Exception");
            }
        }
    }
}

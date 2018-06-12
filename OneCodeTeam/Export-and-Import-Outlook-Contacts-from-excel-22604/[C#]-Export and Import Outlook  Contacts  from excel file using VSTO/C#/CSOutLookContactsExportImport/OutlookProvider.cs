/****************************** Module Header ******************************\
* Module Name:  OutlookProvider.cs
* Project:      CSOutLookContactsExportImport
* Copyright (c) Microsoft Corporation.
* 
* Wrapper class for Outlook operation
* Using ContactsItems to get all contacts in outlook and then export the collection to excel
*  
* Using a DataTable, and then import the DataTable to outlook
*
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/



using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using Microsoft.Office.Interop.Outlook;

namespace CSOutLookContactsExportImport
{
    public class OutlookProvider
    {
        // Define Outlook Application Object
        private readonly Application outlook;

        /// <summary>
        /// Constructor
        /// Create an instance of the Outlook Application Object 
        /// </summary>
        public OutlookProvider()
        {
            outlook = new Application();
        }

        /// <summary>
        /// Collection of Contacts Items
        /// </summary>
        public IEnumerable<ContactItem> ContactsItems
        {
            get
            {
                MAPIFolder folder =
                  outlook.GetNamespace("MAPI").GetDefaultFolder(OlDefaultFolders.olFolderContacts);
                IEnumerable<ContactItem> contacts = folder.Items.OfType<ContactItem>();
                
                // Get Collection ordered by LastName
                var query = from contact in contacts
                            orderby contact.LastName
                            select contact;
                return query;
            }
        }

        /// <summary>
        /// Export Outlook contacts to Excel.
        /// </summary>
        /// <param name="strConn">Connecting String</param>
        /// <param name="contacts">Collection of Outlook Contacts Items</param>
        public void ContactsExportToExcel(string strConn, IEnumerable<ContactItem> contacts)
        {
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                // Create a new sheet in the Excel spreadsheet.
                using (OleDbCommand cmd = new OleDbCommand("Create table Contact(FirstName varchar(50), LastName varchar(50),EmailAddress varchar(50),EmailDisplayName varchar(50))", conn))
                {
                    // Open the connection.
                    conn.Open();

                    // Execute the OleDbCommand.
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO Contact(FirstName,LastName,EmailAddress,EmailDisplayName) values (@FirstName,@LastName,@EmailAddress,@EmailDisplayName)";
                    
                    // Add the parameters.
                    cmd.Parameters.Add(new OleDbParameter("@FirstName", OleDbType.VarChar));
                    cmd.Parameters.Add(new OleDbParameter("@LastName", OleDbType.VarChar));
                    cmd.Parameters.Add(new OleDbParameter("@EmailAddress", OleDbType.VarChar));
                    cmd.Parameters.Add(new OleDbParameter("@EmailDisplayName", OleDbType.VarChar));

                    foreach (var dr in contacts)
                    {
                        cmd.Parameters["@FirstName"].Value = (dr.FirstName == null) ? string.Empty : dr.FirstName;
                        cmd.Parameters["@LastName"].Value = (dr.LastName == null) ? string.Empty : dr.LastName;
                        cmd.Parameters["@EmailAddress"].Value = (dr.Email1Address == null) ? string.Empty : dr.Email1Address;
                        cmd.Parameters["@EmailDisplayName"].Value = (dr.Email1DisplayName == null) ? string.Empty : dr.Email1DisplayName;

                        // Insert the data into the Excel spreadsheet.
                        cmd.ExecuteNonQuery();
                    }
                }
            }

        }

        /// <summary>
        /// Retrieve data from the Excel spreadsheet.
        /// </summary>
        /// <param name="strConn">Connecting String</param>
        /// <returns>DataTable Data</returns>
        public DataTable RetrieveData(string strConn)
        {
            DataTable dtExcel = new DataTable();

            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                // Initialize an OleDbDataAdapter object.
                using (OleDbDataAdapter da = new OleDbDataAdapter("Select * from [Contact$]", conn))
                {
                    // Fill the DataTable with data from the Excel spreadsheet.
                    da.Fill(dtExcel);
                }
            }

            return dtExcel;
        }

        /// <summary>
        /// Import Contacts into Outlook Contacts from Excel spreadsheet
        /// </summary>
        /// <param name="strConn"></param>
        public void ContactsImportFromExcel(string strConn)
        {
            // Get the contacts data from Excel files 
            DataTable dtexcel = RetrieveData(strConn);
            
            // foreach Rows of DataTable
            foreach (DataRow r in dtexcel.Rows)
            {
                // Create ContactItem
                ContactItem c = outlook.CreateItem(OlItemType.olContactItem);
                c.MessageClass = "IPM.Contact";
                c.FirstName = r[0].ToString();
                c.LastName = r[1].ToString();
                c.Email1Address = r[2].ToString();
                c.Email1DisplayName = r[3].ToString();

                // Save ContactItem
                c.Save();
            }
        }
    }
}

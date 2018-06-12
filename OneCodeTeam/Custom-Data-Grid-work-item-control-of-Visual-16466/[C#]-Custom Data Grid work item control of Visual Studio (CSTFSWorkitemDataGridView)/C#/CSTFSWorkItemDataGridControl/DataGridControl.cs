/****************************** Module Header ******************************\
 * Module Name:   DataGridControl.cs
 * Project:       CSTFSWorkItemDataGridControl
 * Copyright (c) Microsoft Corporation.
 * 
 * This class inherits the BaseWITControl and it uses a DataGridView to 
 * represent a workitem field.
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CSTFSWorkItemDataGridControl
{
    public partial class DataGridControl : BaseWITControl
    {
        // The pattern to identify the columns from the attribute.
        // The attribute should like 
        // Column A(FieldA);Column B(FieldB);
        const string columnDefinitionPattern = @"(?<display>.+?)\((?<field>.+?)\);";
        
        // Use DataTable to read the value of this field, and write XML to 
        // this field.
        private DataTable table;
        private BindingSource source;

        public DataGridControl()
        {
            InitializeComponent();

            this.gvData.AutoGenerateColumns = false;
  
            // Initialize data source.
            this.table = new DataTable("DataTable");
            this.source = new BindingSource();
            this.source.DataSource = table;
            this.gvData.DataSource = source;
        }

        // Override some methods of BaseWITControl.
        #region IWorkItemControl

        /// <summary>
        /// Clear the data in the table.
        /// </summary>
        public override void Clear()
        {
            if (this.table != null)
            {
                this.table.Rows.Clear();
            }
        }

        /// <summary>
        /// Control is requested to flush any data to workitem object. 
        /// Write the data in DataTable as XML, and then set the value of current 
        /// field to the XML.
        /// </summary>
        public override void FlushToDatasource()
        {
            if (this.table != null)
            {
                using (StringWriter writer = new StringWriter())
                {
                    this.table.WriteXml(writer, XmlWriteMode.WriteSchema);
                    this.SetFieldValue(writer.ToString());
                }
            }
            else
            {
                this.SetFieldValue(null);
            }
        }

        ///<summary>
        /// Asks control to invalidate the contents and redraw.
        /// Read the value (XML) of current field.
        /// </summary>
        public override void InvalidateDatasource()
        {
            this.Field = null;
            this.Clear();

            if (this.HasValidField)
            {
                try
                {
                    this.table.Clear();
                    using(StringReader reader = new StringReader(this.Field.Value as string))
                    {
                        this.table.ReadXml(reader);
                    }
                }
                catch
                {
                }

                SetReadOnly(!this.Field.IsEditable);

                // If the columns definition changed, update the DataTable.
                foreach (DataGridViewColumn col in this.gvData.Columns)
                {
                    if (!table.Columns.Contains(col.DataPropertyName))
                    {
                        table.Columns.Add(col.DataPropertyName);
                    }
                }                             
            }
        }

        ///<summary>
        /// All attributes specified in work item type definition file for this 
        /// control, including custom attributes.
        /// 
        /// We need the "columns" attribute to initialize the columns of DataGridView.
        /// </summary>
        public override System.Collections.Specialized.StringDictionary Properties
        {
            get
            {
                return base.Properties;
            }
            set
            {
                base.Properties = value;
                UpdateGridViewColumns(base.Properties["columns"]);
            }
        }



        #endregion

        /// <summary>
        /// Initialize the columns of DataGridView. The attributes should like 
        /// Column A(FieldA);Column B(FieldB);
        /// </summary>
        /// <param name="columnsAttribute"></param>
        void UpdateGridViewColumns(string columnsAttribute)
        {
            // The definition of the columns does not change.
            if (string.IsNullOrEmpty(columnsAttribute))
            {
                return;
            }

            // Clear the columns.
            this.gvData.Columns.Clear();

            // Get the new columns definition.
            MatchCollection matches = Regex.Matches(columnsAttribute, columnDefinitionPattern);

            foreach (Match match in matches)
            {
                DataGridViewColumn colum = new DataGridViewTextBoxColumn();
                colum.DataPropertyName = match.Groups["field"].Value;
                colum.HeaderText = match.Groups["display"].Value;
                this.gvData.Columns.Add(colum);
            }
        }
        
        /// <summary>
        /// Enable or disable the DataGridView.
        /// </summary>
        protected override void SetReadOnly(bool readOnly)
        {
            bool canedit = !readOnly && !this.ReadOnly;

            base.SetReadOnly(!canedit);
            this.gvData.ReadOnly = !canedit;
            this.gvData.AllowUserToDeleteRows = canedit;
            this.gvData.AllowUserToAddRows = canedit;
        }

        /// <summary>
        /// Update the field's value if a cell changed.
        /// </summary>
        private void gvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.FlushToDatasource();
        }

        /// <summary>
        /// Update the field's value if a row is deleted.
        /// </summary>
        private void gvData_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            this.FlushToDatasource();
        }



    }
}

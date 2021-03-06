﻿/****************************** Module Header ******************************\
 * Module Name:   DataGridControl.cs
 * Project:       CSTFSWebAccessWorkItemDataGridControl
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

using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.TeamFoundation.WebAccess.Controls;
using Microsoft.TeamFoundation.WebAccess.WorkItemTracking.Controls;

// Defines the metadata attribute that enables an embedded resource in an assembly.
[assembly: WebResource("CSTFSWebAccessWorkItemDataGridControl.DataGridControl.js", 
    "application/x-javascript")]

namespace CSTFSWebAccessWorkItemDataGridControl
{
    /// <summary>
    /// This class inherits BaseWorkItemWebControl which implements most methods of the 
    /// IWorkItemWebControl interface.
    /// </summary>
    public class DataGridControl : BaseWorkItemWebControl
    {
        // The pattern to identify the columns from the attribute.
        // The attribute should like 
        // Column A(FieldA);Column B(FieldB);
        const string columnDefinitionPattern = @"(?<display>.+?)\((?<field>.+?)\);";

        // The panel works as a container of the controls.
        private Panel pnlContainer;

        // Store the value of this field.
        private HiddenField hfValue;


        public DataGridControl()
            : base(HtmlTextWriterTag.Div)
        {
        }

        #region IWorkItemWebControl

        /// <summary>
        /// Clear the value in the hidden field.
        /// </summary>
        public override void Clear()
        {
            this.EnsureChildControls();
            this.hfValue.Value = string.Empty;
        }

        /// <summary>
        /// Control is requested to flush any data to workitem object. 
        /// The field value is stored in the hidden field. GetValidateXml method will 
        /// generate a valid xml from the hfValue.Value, and then set the value of current 
        /// field to the XML.
        /// </summary>
        public override void FlushToDatasource()
        {
            this.EnsureChildControls();
            string valiadXml = GetValidateXml(hfValue.Value);
            this.SetFieldValue(valiadXml);          
        }

        ///<summary>
        /// Asks control to invalidate the contents and redraw.
        /// Read the value (XML) of current field, and set hfValue.Value
        /// to the xml.
        /// </summary>
        public override void InvalidateDatasource()
        {
            this.EnsureChildControls();
            this.Clear();

            if (this.HasValidField)
            {
                string valiadXml = GetValidateXml(this.Field.Value as string);
                this.hfValue.Value = valiadXml;
            }
        }


        #endregion

       
        /// <summary>
        /// Generate a valid XML from the given data. 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string GetValidateXml(string data)
        {
            using (DataTable table = new DataTable("DataTable"))
            {
                try
                {
                    // Determine whether the data is a valiad xml. 
                    using (StringReader reader = new StringReader(data))
                    {
                        table.ReadXml(reader);
                    }
                }
                catch
                {
                }

                // Add columns to the DataTable if the column definition changes. 
                string columnsAttribute = base.Properties["columns"];
                MatchCollection matches = Regex.Matches(columnsAttribute, columnDefinitionPattern);

                foreach (Match match in matches)
                {
                    if (!table.Columns.Contains(match.Groups["field"].Value))
                    {
                        table.Columns.Add(match.Groups["field"].Value);
                    }
                }

                // Return the xml generated by the DataTable.
                using (StringWriter writer = new StringWriter())
                {
                    table.WriteXml(writer, XmlWriteMode.WriteSchema);
                    return writer.ToString();
                }
            }
        }

        #region Overrides methods

        /// <summary>
        /// Create the child controls.
        /// </summary>
        protected override void CreateChildControls()
        {
            this.hfValue = new HiddenField();
            this.pnlContainer = new Panel();

            this.pnlContainer.Controls.Add(this.hfValue);
            this.Controls.Add(this.pnlContainer);
        }

        /// <summary>
        /// Initialize this control.
        /// </summary>
        public override void InitializeControl()
        {
            base.InitializeControl();
            this.EnsureChildControls();
        }

        /// <summary>
        /// Register the client script.
        /// 1. CSTFSWebAccessWorkItemDataGridControl.DataGridControl.js
        /// 2. Use dataGridControl method in CSTFSWebAccessWorkItemDataGridControl.DataGridControl.js
        ///    to generate a client object.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            ScriptManager.RegisterClientScriptResource(
                this, typeof(DataGridControl),
                "CSTFSWebAccessWorkItemDataGridControl.DataGridControl.js");

            string columnsAttribute = base.Properties["columns"];
            ScriptHelper.RegisterObjectScript(
                this,
                "dataGridControl",
                new object[] {
                    base.ClientEditorObjectId, 
                    base.WorkItemFieldName,                   
                    base.ControlId, 
                    this.pnlContainer.ClientID,
                    this.hfValue.ClientID,
                    columnsAttribute,
                    base.ReadOnly});
        }

        #endregion      
    }
}

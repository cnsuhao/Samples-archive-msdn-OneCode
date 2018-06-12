/****************************** Module Header ******************************\
 * Module Name:   MultiValuesControl.cs
 * Project:       CSTFSWebAccessWorkItemMultiValueControl
 * Copyright (c) Microsoft Corporation.
 * 
 * This class inherits the BaseWITControl and it uses a list of check boxes to 
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.TeamFoundation.WebAccess.WorkItemTracking.Controls;
using System.Drawing;
using Microsoft.TeamFoundation.WebAccess.Controls;

// Defines the metadata attribute that enables an embedded resource in an assembly.
[assembly: WebResource("CSTFSWebAccessWorkItemMultiValueControl.MultiValuesControl.js",
    "application/x-javascript")]

namespace CSTFSWebAccessWorkItemMultiValueControl
{
    /// <summary>
    /// This class inherits BaseWorkItemWebControl which implements most methods of the 
    /// IWorkItemWebControl interface.
    /// </summary>
    [ToolboxData("<{0}:MultiValuesControl runat=server></{0}:MultiValuesControl>")]
    public class MultiValuesControl : BaseWorkItemWebControl
    {

        // This char is used to split the options.
        const char splitCharactor = ';';

        // A list of CheckBoxes which represent the options.
        private CheckBoxList lstOptions;

        public MultiValuesControl()
            : base(HtmlTextWriterTag.Div)
        { }

        #region IWorkItemWebControl

        /// <summary>
        /// Clear the value in the checkboxes.
        /// </summary>
        public override void Clear()
        {
            this.EnsureChildControls();
            for (int i = 0; i < this.lstOptions.Items.Count; i++)
            {
                this.lstOptions.Items[i].Selected = false;
            }
        }

        /// <summary>
        /// Control is requested to flush any data to workitem object. 
        /// Combine the selected options to a string, and then set it as the 
        /// field value.
        /// </summary>
        public override void FlushToDatasource()
        {
            this.EnsureChildControls();

            StringBuilder value = new StringBuilder();
            for (int i = 0; i < this.lstOptions.Items.Count; i++)
            {
                if (this.lstOptions.Items[i].Selected)
                {
                    value.AppendFormat("{0}{1}", this.lstOptions.Items[i],
                        splitCharactor);
                }
            }
            this.SetFieldValue(value.ToString());
        }

        ///<summary>
        /// Asks control to invalidate the contents and redraw.
        /// </summary>
        public override void InvalidateDatasource()
        {
            this.EnsureChildControls();
            this.Clear();

            this.lstOptions.BackColor = Color.White;

            for (int i = 0; i < this.lstOptions.Items.Count; i++)
            {
                bool checkedState = (this.Field.Value as string).Contains(
                    string.Format("{0}{1}", this.lstOptions.Items[i].Text, splitCharactor));
                this.lstOptions.Items[i].Selected = checkedState;
            }
        }
        #endregion

        #region  Overrides methods

        /// <summary>
        /// Create the child controls.
        /// </summary>
        protected override void CreateChildControls()
        {
            this.Controls.Clear();
            this.lstOptions = new CheckBoxList();
            this.lstOptions.ID = "val";
            if (this.HasValidField && this.Field.HasAllowedValuesList)
            {
                foreach (var value in this.Field.AllowedValues)
                {

                    ListItem item = new ListItem
                    {
                        Text = value as string,
                        Value = value as string
                    };

                    item.Attributes.Add("title", value as string);

                    this.lstOptions.Items.Add(item);
                }
            }
            this.Controls.Add(this.lstOptions);
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
        /// 1. CSTFSWebAccessWorkItemMultiValueControl.MultiValuesControl.js
        /// 2. Use multiValuesControl method in CSTFSWebAccessWorkItemMultiValueControl.MultiValuesControl.js
        ///    to generate a client object.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            ScriptManager.RegisterClientScriptResource(
                this, typeof(MultiValuesControl),
                "CSTFSWebAccessWorkItemMultiValueControl.MultiValuesControl.js");

            string clientID = this.lstOptions.ClientID;

            ScriptHelper.RegisterObjectScript(
                this,
                "multiValuesControl",
                new object[] {
                    base.ClientEditorObjectId, 
                    base.WorkItemFieldName,                   
                    base.ControlId, 
                    clientID,
                    base.ReadOnly
                });
        }
        #endregion
    }
}

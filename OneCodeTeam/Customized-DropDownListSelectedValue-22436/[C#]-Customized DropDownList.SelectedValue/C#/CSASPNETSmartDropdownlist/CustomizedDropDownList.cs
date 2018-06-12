/****************************** Module Header ******************************\
* Module Name: CustomizedDropDownList.cs
* Project:     CSASPNETSmartDropdownlist
* Copyright (c) Microsoft Corporation
*
* The "SelectedVale" is a value from DropDownList that will be saved into the
* field bound to the data table. However, if the field value does not belong 
* to any element of the collection of the DropDownList itself, it will throw 
* an ArguementOutOfRangeException exception. This sample creates a customized 
* DropDownList that will fix this problem. 
* 
* This is a customized DropDownList that inherits DropDownList control and 
* overrides SelectedValue property. 
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
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Reflection;

namespace CSASPNETSmartDropdownlist
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:CustomizedDropDownList runat=server></{0}:CustomizedDropDownList>")]
    public class CustomizedDropDownList : DropDownList
    {
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
        }

        /// <summary>
        /// Override SelectedValue property.
        /// For testing purpose, here we only provide three types of data field,
        /// Int, Long and String.
        /// </summary>
        public override string SelectedValue
        {
            get
            {
                return base.SelectedValue;
            }
            set
            {
                // If data source is SqlDataSource.
                if (DataSource is DataView)
                {
                    DataView dataView = DataSource as DataView;
                    DataTable tabView = dataView.Table;
                    Type typeColumns = tabView.Columns[DataValueField].DataType;
                    string rowFilter = string.Empty;
                    if (typeColumns.Equals(Type.GetType("System.String")))
                    {
                        rowFilter = string.Format("{0}='{1}'", DataValueField, value);
                    }
                    else if (typeColumns.Equals(Type.GetType("System.Int32")) || typeColumns.Equals(Type.GetType("System.Int64")))
                    {
                        rowFilter = string.Format("{0}={1}", DataValueField, value);
                    }
                    else
                    {
                        throw new NotImplementedException("unsupported type");
                    }

                    dataView.RowFilter = rowFilter;
                    if (dataView.Count != 0)
                    {
                        dataView.RowFilter = string.Empty;
                        base.SelectedValue = value;
                    }
                    else
                    {
                        dataView.RowFilter = string.Empty;
                        base.SelectedValue = Items[0].Value;
                    }
                }
                // If data source is ObjectDataSource
                else if (DataSource is IEnumerable)
                {
                    bool bolFlag = false;
                    foreach (object obj in DataSource as IEnumerable)
                    {
                        Type type = obj.GetType();
                        PropertyInfo info = type.GetProperty(DataValueField);
                        string valueProperty = info.GetValue(obj,null).ToString();
                        if (valueProperty.Equals(value))
                        {
                            bolFlag = true;
                            break;
                        }
                    }

                    if (bolFlag)
                    {
                        base.SelectedValue = value;
                    }
                    else
                    {
                        base.SelectedValue = Items[0].Value;
                    }
                }

                // If user change the selected value after postback.
                if(DataSource == null)
                {
                    bool bolFlag = false;
                    for (int i = 0; i < Items.Count; i++)
                    {
                        if (Items[i].Value.Equals(value))
                        {
                            bolFlag = true;
                            break;
                        }
                    }
                    if (bolFlag)
                    {
                        base.SelectedValue = value;
                    }
                    else
                    {
                        base.SelectedValue = Items[0].Value;
                    }                        
                }
            }
        }
    }
}

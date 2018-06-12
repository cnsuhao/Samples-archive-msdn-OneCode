/****************************** Module Header ******************************\
 * Module Name:  Default.aspx.cs
 * Project:      GetTableSchemaWithDynamicEntity
 * Copyright (c) Microsoft Corporation.
 * 
 * Default class.
 *  
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage;
using System.Configuration;
using System.Data;
using System;
using Microsoft.WindowsAzure;

namespace GetTableSchemaWithDynamicEntity
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CloudStorageAccount account = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
                CloudTableClient client = account.CreateCloudTableClient();
                CloudTable table = client.GetTableReference("CSAzureGetTableSchemaWithDynamicEntityTable");

                // If table does not exist, create it and add some data to this table.
                if (table.CreateIfNotExists())
                {
                    UserData data = new UserData();
                    TableBatchOperation batchOperation = new TableBatchOperation();
                    foreach (var entity in data.UserDataList)
                    {
                        batchOperation.Insert(entity);
                    }
                    table.ExecuteBatch(batchOperation);
                }
            }
        }

        /// <summary>
        /// Query all the data from table "CSAzureGetTableSchemaWithDynamicEntityTable", and show it in gridview.
        /// </summary>
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudTableClient client = account.CreateCloudTableClient();
            CloudTable table = client.GetTableReference("CSAzureGetTableSchemaWithDynamicEntityTable");

            var query = new TableQuery();
            var tableResults = table.ExecuteQuery(query);

            DataTable propertiesTable = new DataTable("CSAzureGetTableSchemaWithDynamicEntity");

            // A Dynamic Entity Table must have the properties in ITableEntity.
            DataColumn partitionKeyColumn = new DataColumn();
            partitionKeyColumn.DataType = Type.GetType("System.String");
            partitionKeyColumn.ColumnName = "Partition Key";
            propertiesTable.Columns.Add(partitionKeyColumn);

            DataColumn rowKeyColumn = new DataColumn();
            rowKeyColumn.DataType = Type.GetType("System.String");
            rowKeyColumn.ColumnName = "Row Key";
            propertiesTable.Columns.Add(rowKeyColumn);

            // Dynamic Entity Table has a property called Properties which includes other table column as KeyValue pair.
            foreach (var entity in tableResults)
            {
                DataRow row;
                row = propertiesTable.NewRow();
                row["Partition Key"] = entity.PartitionKey;
                row["Row Key"] = entity.RowKey;
                if (entity.Properties != null)
                {
                    foreach (var kvp in entity.Properties)
                    {
                        if (!propertiesTable.Columns.Contains(kvp.Key))
                        {
                            DataColumn column = new DataColumn();
                            column.ColumnName = kvp.Key;
                            column.DataType = Type.GetType("System." + kvp.Value.PropertyType.ToString());
                            propertiesTable.Columns.Add(column);
                        }

                        switch (kvp.Value.PropertyType)
                        {
                            case EdmType.Binary:
                                row[kvp.Key] = kvp.Value.BinaryValue;
                                break;
                            case EdmType.Boolean:
                                row[kvp.Key] = kvp.Value.BooleanValue;
                                break;
                            case EdmType.DateTime:
                                row[kvp.Key] = kvp.Value.DateTimeOffsetValue;
                                break;
                            case EdmType.Double:
                                row[kvp.Key] = kvp.Value.DoubleValue;
                                break;
                            case EdmType.Guid:
                                row[kvp.Key] = kvp.Value.GuidValue;
                                break;
                            case EdmType.Int32:
                                row[kvp.Key] = kvp.Value.Int32Value;
                                break;
                            case EdmType.Int64:
                                row[kvp.Key] = kvp.Value.Int64Value;
                                break;
                            case EdmType.String:
                                row[kvp.Key] = kvp.Value.StringValue;
                                break;
                            default:
                                break;
                        }

                    }
                }
                propertiesTable.Rows.Add(row);
            }
            gvwAzureTable.DataSource = propertiesTable;
            gvwAzureTable.DataBind();
        }
    }
}
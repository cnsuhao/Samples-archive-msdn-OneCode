'****************************** Module Header ******************************\
' Module Name:  Default.aspx.vb
' Project:      GetTableSchemaWithDynamicEntity
' Copyright (c) Microsoft Corporation.
' 
' Default class.
'  
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
Imports Microsoft.WindowsAzure.Storage
Imports Microsoft.WindowsAzure.Storage.Table
Imports Microsoft.WindowsAzure

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim account As CloudStorageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"))
            Dim client As CloudTableClient = account.CreateCloudTableClient()
            Dim table As CloudTable = client.GetTableReference("CSAzureGetTableSchemaWithDynamicEntityTable")

            ' If table does not exist, then create it and add some data to this table.
            If table.CreateIfNotExists() Then
                Dim data As New UserData()
                Dim batchOperation As New TableBatchOperation()
                For Each entity In data.UserDataList
                    batchOperation.Insert(entity)
                Next
                table.ExecuteBatch(batchOperation)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Query all the data from table "CSAzureGetTableSchemaWithDynamicEntityTable", and show it in gridview.
    ''' </summary>
    Protected Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim account As CloudStorageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"))
        Dim client As CloudTableClient = account.CreateCloudTableClient()
        Dim table As CloudTable = client.GetTableReference("CSAzureGetTableSchemaWithDynamicEntityTable")

        Dim query = New TableQuery()
        Dim tableResults = table.ExecuteQuery(query)

        Dim propertiesTable As New DataTable("CSAzureGetTableSchemaWithDynamicEntity")

        ' A Dynamic Entity Table must have the properties in ITableEntity.
        Dim partitionKeyColumn As New DataColumn()
        partitionKeyColumn.DataType = Type.[GetType]("System.String")
        partitionKeyColumn.ColumnName = "Partition Key"
        propertiesTable.Columns.Add(partitionKeyColumn)

        Dim rowKeyColumn As New DataColumn()
        rowKeyColumn.DataType = Type.[GetType]("System.String")
        rowKeyColumn.ColumnName = "Row Key"
        propertiesTable.Columns.Add(rowKeyColumn)

        ' Dynamic Entity Table have a property called Proerties which include other table column as KeyValue pair.
        For Each entity In tableResults
            Dim row As DataRow
            row = propertiesTable.NewRow()
            row("Partition Key") = entity.PartitionKey
            row("Row Key") = entity.RowKey
            If entity.Properties IsNot Nothing Then
                For Each kvp In entity.Properties
                    If Not propertiesTable.Columns.Contains(kvp.Key) Then
                        Dim column As New DataColumn()
                        column.ColumnName = kvp.Key
                        column.DataType = Type.[GetType]("System." & kvp.Value.PropertyType.ToString())
                        propertiesTable.Columns.Add(column)
                    End If

                    Select Case kvp.Value.PropertyType
                        Case EdmType.Binary
                            row(kvp.Key) = kvp.Value.BinaryValue
                            Exit Select
                        Case EdmType.[Boolean]
                            row(kvp.Key) = kvp.Value.BooleanValue
                            Exit Select
                        Case EdmType.DateTime
                            row(kvp.Key) = kvp.Value.DateTimeOffsetValue
                            Exit Select
                        Case EdmType.[Double]
                            row(kvp.Key) = kvp.Value.DoubleValue
                            Exit Select
                        Case EdmType.Guid
                            row(kvp.Key) = kvp.Value.GuidValue
                            Exit Select
                        Case EdmType.Int32
                            row(kvp.Key) = kvp.Value.Int32Value
                            Exit Select
                        Case EdmType.Int64
                            row(kvp.Key) = kvp.Value.Int64Value
                            Exit Select
                        Case EdmType.[String]
                            row(kvp.Key) = kvp.Value.StringValue
                            Exit Select
                        Case Else
                            Exit Select

                    End Select
                Next
            End If
            propertiesTable.Rows.Add(row)
        Next
        gvwAzureTable.DataSource = propertiesTable
        gvwAzureTable.DataBind()
    End Sub
End Class
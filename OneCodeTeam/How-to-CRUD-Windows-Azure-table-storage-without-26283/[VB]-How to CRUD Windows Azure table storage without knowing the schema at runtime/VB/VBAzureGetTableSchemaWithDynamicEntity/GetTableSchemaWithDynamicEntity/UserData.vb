'****************************** Module Header ******************************\
' Module Name:  UserData.vb
' Project:      GetTableSchemaWithDynamicEntity
' Copyright (c) Microsoft Corporation.
' 
' UserData class.
'  
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
Imports Microsoft.WindowsAzure.Storage.Table

Public Class UserData
    Public UserDataList As List(Of DynamicTableEntity)

    Public Sub New()

        UserDataList = New List(Of DynamicTableEntity)()

        Dim entity1 As New DynamicTableEntity()
        Dim data1 As New Dictionary(Of String, EntityProperty)()
        data1.Add("Name", New EntityProperty("Sam"))
        data1.Add("Gender", New EntityProperty(True))
        data1.Add("Age", New EntityProperty(18))
        entity1.Properties = data1
        entity1.PartitionKey = "Partition1"
        entity1.RowKey = "1"
        UserDataList.Add(entity1)

        Dim entity2 As New DynamicTableEntity()
        Dim data2 As New Dictionary(Of String, EntityProperty)()
        data2.Add("Name", New EntityProperty("Lucy"))
        data2.Add("Gender", New EntityProperty(False))
        data2.Add("Age", New EntityProperty(20))
        data2.Add("Email", New EntityProperty("Lucy@hotmail.com"))
        entity2.Properties = data2
        entity2.PartitionKey = "Partition1"
        entity2.RowKey = "2"
        UserDataList.Add(entity2)
    End Sub
End Class
'****************************** Module Header ******************************\
' Module Name:  DataManager.vb
' Project:      DataAccessLayer
' Copyright (c) Microsoft Corporation.
'
' The sample code demonstrates how to build a simple 3-tier Asp.net Web Role, 
' which uses Entity Framework (SQL Azure database) as the Data Access Layer. 
' This sample also shows how to implement a User Session Handling (With Azure Cache Service).
'
' This class is used to retrieve data from Entity Framework (SQL Azure database).
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Public Class DataManager
    Public context As TestDBEntities
    Public Sub New()
        context = New TestDBEntities()
    End Sub

    Public Function GetAllTable() As List(Of TestTable)
        Dim list As New List(Of TestTable)()
        list = context.TestTable.ToList()
        Return list
    End Function
End Class

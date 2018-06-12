'****************************** Module Header ******************************\
' Module Name:  BusinessManager.vb
' Project:      BusinessLayer
' Copyright (c) Microsoft Corporation.
'
' The sample code demonstrates how to build a simple 3-tier Asp.net Web Role, 
' which uses Entity Framework (SQL Azure database) as the Data Access Layer. 
' This sample also shows how to implement a User Session Handling (With Azure Cache Service).
'
' This class is used to retrieve data from DAL.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports DataAccessLayer

Public Class BusinessManager
    Private dataManager As DataManager
    Public Sub New()
        dataManager = New DataManager()
    End Sub

    Public Function GetData() As List(Of TestTable)
        Return dataManager.GetAllTable()
    End Function
End Class

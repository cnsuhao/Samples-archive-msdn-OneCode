'****************************** Module Header ******************************\
' Module Name:  Service.svc.vb
' Project:      VBWindowsStoreAppAccessSQLServer
' Copyright (c) Microsoft Corporation.
' 
' This is the Service class which implements the IService interface. 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Imports System.Data.SqlClient

' NOTE: You can use the "Rename" command on the context menu to change the class name "Service1" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.vb at the Solution Explorer and start debugging.
Public Class Service
    Implements IService

    Public Sub New()
    End Sub

    ''' <summary>
    ''' Query data in TestTable
    ''' </summary>
    Private sqlCon As New SqlConnection("Data Source=(local);Initial Catalog=Test;Integrated Security =SSPI;")

    Public Function querySql(ByRef queryParam As Boolean) As DataSet Implements IService.querySql
        Try
            sqlCon.Open()
            Dim strSql As String = "select Title, Text from TestTable"
            Dim ds As New DataSet()
            Dim sqlDa As New SqlDataAdapter(strSql, sqlCon)
            sqlDa.Fill(ds)
            queryParam = True
            Return ds
        Catch
            queryParam = False
            Return Nothing
        Finally
            sqlCon.Close()
        End Try
    End Function
End Class

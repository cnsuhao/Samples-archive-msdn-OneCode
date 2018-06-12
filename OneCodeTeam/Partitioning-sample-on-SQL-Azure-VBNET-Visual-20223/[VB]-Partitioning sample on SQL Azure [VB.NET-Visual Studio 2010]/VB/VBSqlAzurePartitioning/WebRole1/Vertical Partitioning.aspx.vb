'****************************** Module Header ******************************\
' Module Name:  Vertical Partitioning.aspx.vb
' Project: VBSqlAzurePartitioning
' Copyright (c) Microsoft Corporation.
' 
' If you want to store larger amounts of data in SQL Azure you can divide your tables 
' across multiple SQL Azure databases(Vertically Partitions your Data). 
'
' This sample shows how to join two tables on different SQL Azure databases using LINQ. 
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System.Data.Common
Imports System.Data.SqlClient

Public Class Vertical_Partitioning
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not MyBase.IsPostBack Then
            Dim studentDataReader As IEnumerable(Of DbDataRecord) = SQLAzureHelper.ExecuteReader(ConfigurationManager.ConnectionStrings.Item("StudentsConnectionString").ConnectionString, Function(connection)
                                                                                                                                                                                               Dim sql As [String] = "SELECT StudentId, StudentName FROM Student"
                                                                                                                                                                                               Dim sqlCommand As New SqlCommand(sql, connection)
                                                                                                                                                                                               Return (sqlCommand.ExecuteReader())
                                                                                                                                                                                           End Function)
            Dim courseDataReader As IEnumerable(Of DbDataRecord) = SQLAzureHelper.ExecuteReader(ConfigurationManager.ConnectionStrings.Item("CoursesConnectionString").ConnectionString, Function(connection)
                                                                                                                                                                                             Dim sql As [String] = "SELECT CourseName, StudentId FROM Course"
                                                                                                                                                                                             Dim sqlCommand As New SqlCommand(sql, connection)
                                                                                                                                                                                             Return (sqlCommand.ExecuteReader())
                                                                                                                                                                                         End Function)
    Dim query = (From student In studentDataReader
        Join course In courseDataReader On CInt(student.Item("StudentId")) Equals CInt(course.Item("StudentId"))
        Select New With { _
            .CourseName = CStr(course.Item("CourseName")), _
            .StudentName = CStr(student.Item("StudentName")) _
        })
            Me.GridView3.DataSource = query
            Me.GridView3.DataBind()
        End If

    End Sub

End Class
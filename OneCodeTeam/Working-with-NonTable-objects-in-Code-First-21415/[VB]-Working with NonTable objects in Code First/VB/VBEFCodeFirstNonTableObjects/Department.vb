'**************************** Module Header ******************************\
' Module Name:  Department.vb
' Project:      VBEFCodeFirstNonTableObjects
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to work with nontable database objects in Code 
' First.
' The file defines the Department Entity Model class.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************

Imports System.ComponentModel.DataAnnotations

Namespace VBEFCodeFirstNonTableObjects
    <Table("Department")>
    Public Class Department
        Public Property DepartmentID() As Int32
        Public Property Name() As String
        Public Property Budget() As Decimal
        Public Property StartDate() As Date
        Public Property Administrator() As Int32

        Public Overridable Property Courses() As List(Of Course)
    End Class
End Namespace

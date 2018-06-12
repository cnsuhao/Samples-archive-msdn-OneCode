'**************************** Module Header ******************************\
' Module Name:  Course.vb
' Project:      VBEFCodeFirstNonTableObjects
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to work with nontable database objects in Code 
' First.
' The file defines the Course Entity Model class.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.ComponentModel.DataAnnotations

Namespace VBEFCodeFirstNonTableObjects
    <Table("Course")>
    Public Class Course
        Public Property CourseID() As Int32
        <Column("Title")>
        Public Property CourseName() As String
        Public Property Credits() As Int32
        Public Property DepartmentID() As Int32

        Public Overridable Property Department() As Department
    End Class
End Namespace

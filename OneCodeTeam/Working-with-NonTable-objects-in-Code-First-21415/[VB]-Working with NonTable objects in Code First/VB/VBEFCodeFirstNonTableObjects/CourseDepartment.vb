'**************************** Module Header ******************************\
' Module Name:  CourseDepartment.vb
' Project:      VBEFCodeFirstNonTableObjects
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to work with nontable database objects in Code 
' First.
' The file defines the CourseDepartment Non-Entity Model class.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/


Namespace VBEFCodeFirstNonTableObjects
    Public Class CourseDepartment
        Public Property CourseID() As Int32
        Public Property Title() As String
        Public Property Credits() As Int32
        Public Property DepartmentName() As String
    End Class
End Namespace

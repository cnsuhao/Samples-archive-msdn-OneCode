'**************************** Module Header ******************************\
' Module Name:  MySchoolContext.vb
' Project:      VBEFCodeFirstNonTableObjects
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to work with nontable database objects in Code 
' First.
' The file defines the MySchoolContext class.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Data.Entity

Namespace VBEFCodeFirstNonTableObjects
    Public Class MySchoolContext
        Inherits DbContext
        Public Sub New()
        End Sub

        ''' <summary>
        ''' We can specify the database name the context creates or maps.
        ''' </summary>
        ''' <param name="databaseName">the database name the context creates or maps</param>
        Public Sub New(ByVal databaseName As String)
            MyBase.New(databaseName)
        End Sub

        Public Property Courses() As DbSet(Of Course)
        Public Property Departments() As DbSet(Of Department)

    End Class
End Namespace

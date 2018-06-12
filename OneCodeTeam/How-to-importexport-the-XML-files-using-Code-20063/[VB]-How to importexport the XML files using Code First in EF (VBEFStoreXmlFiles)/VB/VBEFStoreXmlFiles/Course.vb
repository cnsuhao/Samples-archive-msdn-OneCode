'**************************** Module Header ******************************\
' Module Name:  Course.vb
' Project:      VBEFStoreXmlFiles
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to import/export the XML into/from database using 
' Code First in EF.
' This file defines the Course class as the Entity type.
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

Namespace VBEFStoreXmlFiles
    Public Class Course
        <Key()>
        Public Property CourseID() As String
        Public Property Title() As String
        Public Property Credits() As Int32?
        Public Property Department() As String
    End Class
End Namespace

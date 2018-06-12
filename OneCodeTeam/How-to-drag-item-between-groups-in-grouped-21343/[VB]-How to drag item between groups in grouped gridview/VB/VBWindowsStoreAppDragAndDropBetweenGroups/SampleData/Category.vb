'***************************** Module Header ******************************\
' Module Name:  Category.vb
' Project:      VBWindowsStoreAppDragAndDropBetweenGroups
' Copyright (c) Microsoft Corporation.
'  
' This class holds a collection of Books.
'   
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
'  
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Public Class Category
    Public Sub New()
        BookList = New ObservableCollection(Of Book)()
    End Sub

    Public Property Name() As String

    Public Property BookList() As ObservableCollection(Of Book)
End Class

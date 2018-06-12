'***************************** Module Header ******************************\
' Module Name:  CustomDataTemplateSelector.vb
' Project:      VBWindowsStoreAppDisableItem
' Copyright (c) Microsoft Corporation.
'  
' This code snippet creates a custom DataTemplateSelector for the GridView to choose DataTemplate
'  
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Public Class CustomDataTemplateSelector
    Inherits DataTemplateSelector
    Public Property defaultTemplate() As DataTemplate

    Public Property unavailable() As DataTemplate

    Protected Overrides Function SelectTemplateCore(item As Object, container As DependencyObject) As DataTemplate
        Dim book As Book = TryCast(item, Book)
        If book.Available = True Then
            Return Me.defaultTemplate
        Else
            Return Me.unavailable
        End If
    End Function
End Class

'****************************** Module Header ******************************\
' Module Name:  Utilities.vb
' Project:      VBWP8AccessItemIndex
' Copyright (c) Microsoft Corporation
'
' Helper class is used to traverse the Visual Tree and get 
' FrameworkElement's index in ItemsControl.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/
Imports System.Windows.Media

Public Module Utilities
    ''' <summary>
    ''' Finds the parent.
    ''' </summary>
    ''' <param name="element">The element to start with.</param>
    ''' <param name="filter">The filter criteria.</param>
    ''' <returns></returns>
    <System.Runtime.CompilerServices.Extension> _
    Public Function FindParent(element As DependencyObject, filter As Func(Of DependencyObject, Boolean)) As DependencyObject
        Dim parent As DependencyObject = VisualTreeHelper.GetParent(element)

        If parent IsNot Nothing Then
            If filter(parent) Then
                Return parent
            End If

            Return FindParent(parent, filter)
        End If

        Return Nothing
    End Function

    ''' <summary>
    ''' Get index of the UIElement by using IndexFromContainer
    ''' </summary>
    ''' <param name="element">FrameworkElement</param>
    ''' <returns>index</returns>
    ''' <remarks></remarks>
    Public Function GetIndexOfUIElement(element As FrameworkElement) As Integer
        Dim intIndex As Integer
        Dim parent As ItemsControl = TryCast(element.FindParent(Function(x) TypeOf x Is ItemsControl), ItemsControl)

        If parent IsNot Nothing Then
            Dim container As DependencyObject = parent.ItemContainerGenerator.ContainerFromItem(element.DataContext)

            If container IsNot Nothing Then
                intIndex = parent.ItemContainerGenerator.IndexFromContainer(container)
            End If
        End If
        Return intIndex
    End Function
End Module


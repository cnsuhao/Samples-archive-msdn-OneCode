'****************************** Module Header ******************************\
' Module Name:    MainPage.xaml.vb
' Project:        VBWP8LongListSelectorHighlight
' Copyright (c) Microsoft Corporation
'
' This demo shows how to highlight a selected item in the LongListSelector 
' on WP8.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Imports System
Imports System.Threading
Imports System.Windows.Controls
Imports Microsoft.Phone.Controls
Imports Microsoft.Phone.Shell

Partial Public Class MainPage
    Inherits PhoneApplicationPage

    ' Constructor
    Public Sub New()
        InitializeComponent()

        SupportedOrientations = SupportedPageOrientation.Portrait Or SupportedPageOrientation.Landscape
        ' Test data.
        Dim listData As List(Of String) = New List(Of String)()
        listData.Add("ASPNET")
        listData.Add("WCF")
        listData.Add("WPF")
        listData.Add("Windows Store")
        listData.Add("Windows Phone")

        ' Bind to control.
        MyLongListSelector1.ItemsSource = listData
        MyLongListSelector2.ItemsSource = listData
    End Sub

    Private Sub MyLongListSelector1_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        ' Get item of LongListSelector.
        Dim userControlList As New List(Of CustomUserControl)()
        GetItemsRecursive(Of CustomUserControl)(MyLongListSelector1, userControlList)

        ' Selected.
        If e.AddedItems.Count > 0 AndAlso e.AddedItems(0) IsNot Nothing Then
            For Each userControl As CustomUserControl In userControlList
                If e.AddedItems(0).Equals(userControl.DataContext) Then
                    VisualStateManager.GoToState(userControl, "Selected", True)
                End If
            Next
        End If
        ' Unselected.
        If e.RemovedItems.Count > 0 AndAlso e.RemovedItems(0) IsNot Nothing Then
            For Each userControl As CustomUserControl In userControlList
                If e.RemovedItems(0).Equals(userControl.DataContext) Then
                    VisualStateManager.GoToState(userControl, "Normal", True)
                End If
            Next
        End If
    End Sub

    Private Sub MyLongListSelector2_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        ' Get item of LongListSelector.
        Dim userControlList As New List(Of UserControl)()
        GetItemsRecursive(Of UserControl)(MyLongListSelector2, userControlList)

        ' Selected.
        If e.AddedItems.Count > 0 AndAlso e.AddedItems(0) IsNot Nothing Then
            For Each userControl As UserControl In userControlList
                If e.AddedItems(0).Equals(userControl.DataContext) Then
                    VisualStateManager.GoToState(userControl, "Selected", True)
                End If
            Next
        End If
        ' Unselected.
        If e.RemovedItems.Count > 0 AndAlso e.RemovedItems(0) IsNot Nothing Then
            For Each userControl As UserControl In userControlList
                If e.RemovedItems(0).Equals(userControl.DataContext) Then
                    VisualStateManager.GoToState(userControl, "Normal", True)
                End If
            Next
        End If

    End Sub

    ''' <summary>
    ''' Recursively get the item.
    ''' </summary>
    ''' <typeparam name="T">The item to get.</typeparam>
    ''' <param name="parents">Parent container.</param>
    ''' <param name="objectList">Item list</param>
    Public Shared Sub GetItemsRecursive(Of T As DependencyObject)(parents As DependencyObject, ByRef objectList As List(Of T))
        Dim childrenCount = VisualTreeHelper.GetChildrenCount(parents)

        For i As Integer = 0 To childrenCount - 1
            Dim child = VisualTreeHelper.GetChild(parents, i)

            If TypeOf child Is T Then
                objectList.Add(TryCast(child, T))
            End If

            GetItemsRecursive(Of T)(child, objectList)
        Next

        Return
    End Sub

End Class
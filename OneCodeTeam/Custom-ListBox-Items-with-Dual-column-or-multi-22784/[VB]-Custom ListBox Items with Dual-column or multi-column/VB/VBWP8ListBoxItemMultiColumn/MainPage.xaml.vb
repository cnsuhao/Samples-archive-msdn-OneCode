'****************************** Module Header ******************************\
' Module Name:    MainPage.xaml.vb
' Project:        VBWP8ListBoxItemMultiColumn
' Copyright (c) Microsoft Corporation
'
' This sample will demo how to custom ListBox Items with Dual-column or 
' multi-column.
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
Imports System.Collections.ObjectModel

Partial Public Class MainPage
    Inherits PhoneApplicationPage
    Shared myVM As ObservableCollection(Of MyListViewModel)

    ' Constructor
    Public Sub New()
        InitializeComponent()

        SupportedOrientations = SupportedPageOrientation.Portrait Or SupportedPageOrientation.Landscape

        AddHandler Loaded, AddressOf MainPage_Loaded
    End Sub

    ''' <summary>
    ''' Page loaded.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs)
        LoadTestData()

        BindData()
    End Sub

    ''' <summary>
    ''' Test data.
    ''' </summary>
    Private Sub LoadTestData()
        myVM = New ObservableCollection(Of MyListViewModel)() From { _
            New MyListViewModel() With { _
                  .Field1 = "A1", _
                  .Field2 = "A2", _
                  .Field3 = "A3", _
                  .Field4 = "A4", _
                  .Field5 = "A5" _
            }, _
            New MyListViewModel() With { _
                  .Field1 = "B1", _
                  .Field2 = "B2", _
                  .Field3 = "B3", _
                  .Field4 = "B4", _
                  .Field5 = "B5" _
            } _
        }
    End Sub

    ''' <summary>
    ''' Add item to listBox.
    ''' </summary>
    ''' <param name="sender">btnAdd</param>
    ''' <param name="e"></param>
    Private Sub btnAdd_Click(sender As Object, e As RoutedEventArgs)
        myVM.Add(New MyListViewModel() With { _
             .Field1 = tbInput.Text, _
             .Field2 = tbInput.Text, _
             .Field3 = tbInput.Text, _
             .Field4 = tbInput.Text, _
             .Field5 = tbInput.Text _
        })

        BindData()
    End Sub

    ''' <summary>
    ''' Data bind to ListBox
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BindData()
        listData.ItemsSource = myVM
        listForUserControl.ItemsSource = myVM
    End Sub

End Class

''' <summary>
''' Entity for test　Data
''' </summary>
''' <remarks></remarks>
Class MyListViewModel

    Property Field1 As String

    Property Field2 As String

    Property Field3 As String

    Property Field4 As String

    Property Field5 As String

End Class
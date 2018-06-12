'****************************** Module Header ******************************\
' Module Name:  MainPage.xaml.vb
' Project:      VBWP8CollectionViewSource
' Copyright (c) Microsoft Corporation
'
' This sample will demo how to databind with CollectionViewSource.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Imports System.Linq
Imports System.Windows
Imports Microsoft.Phone.Controls
Imports VBWP8CollectionViewSource.ViewNamespace
Imports System.Windows.Data
Imports VBWP8CollectionViewSource.ModelNamespace
Imports VBWP8CollectionViewSource.ViewModelNamespace


Partial Public Class MainPage
    Inherits PhoneApplicationPage
    Private vm As ViewModel

    ' Constructor
    Public Sub New()
        InitializeComponent()
        vm = New ViewModel()
    End Sub

    ''' <summary>
    ''' Got data from state
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnNavigatedTo(e As System.Windows.Navigation.NavigationEventArgs)
        MyBase.OnNavigatedTo(e)

        If Not StateUtilities.IsLaunching AndAlso Me.State.ContainsKey("ReadinessAndLevels") Then
            ' Old instance of the application
            ' The user started the application from the Back button.

            vm = DirectCast(Me.State("ReadinessAndLevels"), ViewModel)
            MessageBox.Show("Got data from state")
        Else
            ' New instance of the application
            ' The user started the application from the application list,
            ' or there is no saved state available.

            'MessageBox.Show("Did not get data from state");
            vm.GetReadinessAndLevels()
        End If

        ' There are two different views, but only one view model.
        ' So, use LINQ queries to populate the views.

        ' Set the data context for the Item view.
        ItemViewOnPage.DataContext = From Accomplishment In vm.ReadinessAndLevels
                                     Where Accomplishment.Type = "Item"
                                     Select Accomplishment

        ' [-or-] 

        'Dim cvs As New CollectionViewSource()
        'cvs.Source = vm.ReadinessAndLevels
        'AddHandler cvs.Filter, New FilterEventHandler(AddressOf cvs_Filter)
        'ItemViewOnPage.DataContext = cvs

        ' Set the data context for the Level view.
        LevelViewOnPage.DataContext = From Accomplishment In vm.ReadinessAndLevels
                                      Where Accomplishment.Type = "Level"
                                      Select Accomplishment

        ' If there is only one view, you could use the following code
        ' to populate the view.
        AccomplishmentViewOnPage.DataContext = vm.ReadinessAndLevels
    End Sub

    ''' <summary>
    ''' Provides information and event data that is associated with the CollectionViewSource.Filter event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cvs_Filter(sender As Object, e As FilterEventArgs)
        Dim ral As ReadinessAndLevel = TryCast(e.Item, ReadinessAndLevel)
        If ral IsNot Nothing Then
            e.Accepted = ral.Type = "Item"
        End If
    End Sub

    ''' <summary>
    ''' Save data from state. 
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnNavigatedFrom(e As System.Windows.Navigation.NavigationEventArgs)
        MyBase.OnNavigatedFrom(e)

        If Me.State.ContainsKey("ReadinessAndLevels") Then
            Me.State("ReadinessAndLevels") = vm
        Else
            Me.State.Add("ReadinessAndLevels", vm)
        End If

        StateUtilities.IsLaunching = False
    End Sub

    ''' <summary>
    ''' Store the data. 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AppBarSave_Click(sender As Object, e As EventArgs)
        vm.SaveReadinessAndLevels()
    End Sub

    ''' <summary>
    ''' Add a new item to collection.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAdd_Click(sender As Object, e As RoutedEventArgs)
        vm.ReadinessAndLevels.Add(New ReadinessAndLevel() With { _
             .Name = "Windows 8", _
             .Type = "Item" _
        })
    End Sub

End Class


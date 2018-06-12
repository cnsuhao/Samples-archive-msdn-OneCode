'***************************** Module Header ******************************\
' Module Name:  MainPage.xaml.vb
' Project:      VBWindowsStoreAppAddItem
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to add item to a grouped GridView.
'  
'  
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
'  
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Globalization

' The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

''' <summary>
''' A basic page that provides characteristics common to most applications.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Common.LayoutAwarePage

    Private Shared _source As ObservableCollection(Of GroupInfoCollection(Of Item))

    Public Sub New()
        Me.InitializeComponent()

        _source = (New StoreData()).GetGroupsByCategory()

        collectionViewSource.Source = _source

        Dim pictureOptions As New ObservableCollection(Of String)() From { _
            "Banana", _
            "Lemon", _
            "Mint", _
            "Orange", _
            "SauceCaramel", _
            "SauceChocolate", _
            "SauceStrawberry", _
            "SprinklesChocolate", _
            "SprinklesRainbow", _
            "SprinklesVanilla", _
            "Strawberry", _
            "Vanilla" _
        }
        pictureComboBox.ItemsSource = pictureOptions
        pictureComboBox.SelectedIndex = 0

        Dim groupOptions As New ObservableCollection(Of String)()
        For Each groupInfoList As GroupInfoCollection(Of Item) In _source
            groupOptions.Add(groupInfoList.Key)
        Next

        groupComboBox.ItemsSource = groupOptions
        groupComboBox.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' Populates the page with content passed during navigation.  Any saved state is also
    ''' provided when recreating a page from a prior session.
    ''' </summary>
    ''' <param name="navigationParameter">The parameter value passed to
    ''' <see cref="Frame.Navigate"/> when this page was initially requested.
    ''' </param>
    ''' <param name="pageState">A dictionary of state preserved by this page during an earlier
    ''' session.  This will be null the first time a page is visited.</param>
    Protected Overrides Sub LoadState(navigationParameter As Object, pageState As Dictionary(Of String, Object))

    End Sub

    ''' <summary>
    ''' Preserves state associated with this page in case the application is suspended or the
    ''' page is discarded from the navigation cache.  Values must conform to the serialization
    ''' requirements of <see cref="Common.SuspensionManager.SessionState"/>.
    ''' </summary>
    ''' <param name="pageState">An empty dictionary to be populated with serializable state.</param>
    Protected Overrides Sub SaveState(pageState As Dictionary(Of String, Object))

    End Sub


#Region "Common methods"

    Private Async Function Footer_Click(sender As Object, e As RoutedEventArgs) As Task
        Await Windows.System.Launcher.LaunchUriAsync(New Uri(TryCast(sender, HyperlinkButton).Tag.ToString()))
    End Function


    Public Sub NotifyUser(message As String)
        Me.statusText.Text = message
    End Sub

#End Region

    Private Sub btnAddItemClick(sender As Object, e As Windows.UI.Xaml.RoutedEventArgs)
        Dim path As String = String.Format(CultureInfo.InvariantCulture, "SampleData/Images/60{0}.png", pictureComboBox.SelectedItem)

        Dim item As New Item
        item.Title = titleTextBox.Text
        item.Category = DirectCast(groupComboBox.SelectedItem, String)
        item.SetImage(StoreData.BaseUri, path)
        Dim group As GroupInfoCollection(Of Item) = _source.[Single](Function(groupInfoList) groupInfoList.Key = item.Category)
        group.Add(item)
    End Sub

End Class

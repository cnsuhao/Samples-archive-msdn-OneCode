'***************************** Module Header ******************************\
' Module Name:  MainPage.xaml.vb
' Project:      VBWindowsStoreAppBindEnumToRadioButton
' Copyright (c) Microsoft Corporation.
'  
' This sample demonstrates how to bind enum to RadioButton
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

' The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

''' <summary>
''' A basic page that provides characteristics common to most applications.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Common.LayoutAwarePage

    ' Selected customer to edit
    Private selectedCustomer As Customer
    Public Sub New()
        Me.InitializeComponent()

        ' Bind the customer collection to GridView
        CustomerGridView.ItemsSource = CustomerCollection.Customers
        AddHandler BottomAppBar.Closed, AddressOf BottomAppBar_Closed
    End Sub

    Private Sub BottomAppBar_Closed(sender As Object, e As Object)
        CustomerGridView.SelectedItem = Nothing
    End Sub

#Region "Common methods"

    ''' <summary>
    ''' The the event handler for the click event of the link in the footer. 
    ''' </summary>
    ''' <param name="sender">
    ''' The sender.
    ''' </param>
    ''' <param name="e">
    ''' The event arguments.
    ''' </param>
    Private Async Sub FooterClick(sender As Object, e As RoutedEventArgs)
        Dim hyperlinkButton As HyperlinkButton = TryCast(sender, HyperlinkButton)
        If hyperlinkButton IsNot Nothing Then
            Await Windows.System.Launcher.LaunchUriAsync(New Uri(hyperlinkButton.Tag.ToString()))
        End If
    End Sub

    Public Sub NotifyUser(message As String)
        Me.StatusText.Text = message
    End Sub

#End Region


    Private Sub EditButton_Click(sender As Object, e As RoutedEventArgs)
        selectedCustomer = TryCast(CustomerGridView.SelectedItem, Customer)

        ' Navigate to Edit page with the selected item as parameter
        If selectedCustomer IsNot Nothing Then
            Frame.Navigate(GetType(EditPage), selectedCustomer)
        End If
    End Sub

    Private Sub CustomerGridView_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If CustomerGridView.SelectedItem IsNot Nothing Then
            BottomAppBar.IsOpen = True
            EditButton.IsEnabled = True
        Else
            EditButton.IsEnabled = False
        End If
    End Sub

End Class

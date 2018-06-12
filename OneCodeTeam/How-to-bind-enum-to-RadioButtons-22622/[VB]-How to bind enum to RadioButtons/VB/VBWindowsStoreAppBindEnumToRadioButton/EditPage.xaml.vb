'***************************** Module Header ******************************\
' Module Name:  EditPage.xaml.vb
' Project:      VBWindowsStoreAppBindEnumToRadioButton
' Copyright (c) Microsoft Corporation.
'  
' This is the edit page of the sample
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

Imports Windows.UI.Xaml.Navigation

' The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

''' <summary>
''' A basic page that provides characteristics common to most applications.
''' </summary>
Public NotInheritable Class EditPage
    Inherits Common.LayoutAwarePage

    Private AgeCollection As List(Of Integer)
    Public Sub New()
        Me.InitializeComponent()

        ' Initialize the age ComboBox
        AgeCollection = New List(Of Integer)()
        For i As Integer = 1 To 120
            AgeCollection.Add(i)
        Next
        AgeComboBox.ItemsSource = AgeCollection
    End Sub


    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        ' Get selected customer
        Dim cus As Customer = TryCast(e.Parameter, Customer)
        Me.DataContext = cus
        MyBase.OnNavigatedTo(e)
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As RoutedEventArgs)
        Frame.Navigate(GetType(MainPage))
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

    Private Sub NameTextBox_TextChanged(sender As Object, e As TextChangedEventArgs)
        If String.IsNullOrEmpty(NameTextBox.Text) Then
            HintTextBlock.Visibility = Visibility.Visible
            SaveButton.IsEnabled = False
        Else
            HintTextBlock.Visibility = Visibility.Collapsed
            SaveButton.IsEnabled = True
        End If
    End Sub

End Class

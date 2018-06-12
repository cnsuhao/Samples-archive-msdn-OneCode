'***************************** Module Header ******************************\
' Module Name:  MainPage.xaml.vb
' Project:      VBWindowsStoreAppDisableItem
' Copyright (c) Microsoft Corporation.
'  
' This sample demonstrates how to disable specified item selection in Gridview
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
Public NotInheritable Class MainPage
    Inherits Common.LayoutAwarePage
    Dim books As New ObservableCollection(Of Book)()

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

    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        gvBooks.ItemsSource = books

    End Sub

#Region "Common methods"

    Private Async Function Footer_Click(sender As Object, e As RoutedEventArgs) As Task
        Await Windows.System.Launcher.LaunchUriAsync(New Uri(TryCast(sender, HyperlinkButton).Tag.ToString()))
    End Function


    Public Sub NotifyUser(message As String)
        Me.statusText.Text = message
    End Sub

#End Region

#Region "Add Button Click Event"
    ''' <summary>
    ''' Add item to the Gridview
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnAdd_Click(sender As Object, e As RoutedEventArgs)
        If ValidateInfo() Then
            tbHint.Visibility = Visibility.Collapsed
            Dim book As New Book()
            book.Name = txtName.Text
            book.Category = cbCategory.SelectedValue.ToString()
            book.Price = Convert.ToDecimal(txtPrice.Text)
            book.Available = Convert.ToBoolean(cbAvailable.SelectedIndex)
            books.Add(book)
            svContent.ScrollToVerticalOffset(svContent.ExtentHeight)
        End If
    End Sub
#End Region

#Region "Validate information"
    ''' <summary>
    ''' Check if the information is valid
    ''' </summary>
    ''' <returns></returns>
    Private Function ValidateInfo() As Boolean
      Dim valid As Boolean = False
        If String.IsNullOrEmpty(txtName.Text) OrElse String.IsNullOrEmpty(txtPrice.Text) Then
            tbHint.Text = "Please complete the information!"
            tbHint.Visibility = Visibility.Visible
        Else
            valid = True
        End If
        Return valid
    End Function
#End Region

#Region "Tapped Event"
    ''' <summary>
    ''' Selete the selectable item
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub gvBooks_Tapped(sender As Object, e As TappedRoutedEventArgs)
        ' The y coordinate of the tapped position
        Dim y As Double = e.GetPosition(DirectCast(sender, UIElement)).Y

        ' The x coordinate of the tapped position
        Dim x As Double = e.GetPosition(DirectCast(sender, UIElement)).X

        Dim gvBooksContainer As GridView = TryCast(sender, GridView)

        gvBooksContainer.Measure(New Size(235, 80))
        Dim size As Size = gvBooksContainer.DesiredSize

        ' The tapped item's x index
        Dim itemX As Integer = CInt(Math.Truncate(x / size.Width))

        ' The tapped item's y index
        Dim itemY As Integer = CInt(Math.Truncate(y / size.Height))

        ' Get the index of tapped item
        Dim index As Integer = CInt(itemY * CInt(gvBooks.ActualWidth / size.Width)) + itemX

        If index < gvBooks.Items.Count Then
            Dim book As Book = TryCast(gvBooks.Items(index), Book)
            If book.Available = True Then
                ' Get the tapped item
                Dim tappedItem As GridViewItem = TryCast(gvBooksContainer.ItemContainerGenerator.ContainerFromIndex(index), GridViewItem)
                gvBooksContainer.SelectionMode = ListViewSelectionMode.[Single]
                tappedItem.IsSelected = True
            Else
                gvBooksContainer.SelectionMode = ListViewSelectionMode.None
            End If
        End If
    End Sub
#End Region


    Private Sub txtPrice_TextChanged(sender As Object, e As TextChangedEventArgs)
        Dim price As Decimal
        If Not Decimal.TryParse(txtPrice.Text, price) Then
            tbHint.Text = "Price format is not valid! e.g. 12.35"
            tbHint.Visibility = Visibility.Visible
        Else
            tbHint.Visibility = Visibility.Collapsed
        End If
    End Sub
End Class

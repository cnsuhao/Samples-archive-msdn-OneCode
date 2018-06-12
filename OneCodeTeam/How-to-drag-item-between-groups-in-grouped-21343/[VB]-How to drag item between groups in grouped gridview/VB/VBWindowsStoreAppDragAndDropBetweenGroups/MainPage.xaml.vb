'***************************** Module Header ******************************\
' Module Name:  MainPage.xaml.vb
' Project:      VBWindowsStoreAppDragAndDropBetweenGroups
' Copyright (c) Microsoft Corporation.
'  
' This sample demonstrates how to drag and drop item between groups in grouped GridView. 
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

    Dim draggedItem As Book

    Public Sub New()
        Me.InitializeComponent()
        categoryCollectionViewSource.Source = New SampleData().GetCategoryDataSource()
        bookCollectionViewSource.Source = New SampleData().GetBookDataSource()
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

    Private Sub ItemsByCategory_DragItemsStarting(sender As Object, e As DragItemsStartingEventArgs)
        draggedItem = TryCast(e.Items(0), Book)
    End Sub

    Private Sub VariableSizedWrapGrid_Drop(sender As Object, e As DragEventArgs)
        Try
            If draggedItem IsNot Nothing Then
                Dim sourceCategory = draggedItem.Cate
                Dim child = TryCast(TryCast(DirectCast(sender, VariableSizedWrapGrid).Children(0), GridViewItem).Content, Book)
                draggedItem.Cate = child.Cate

                child.Cate.BookList.Add(draggedItem)
                sourceCategory.BookList.Remove(draggedItem)
                draggedItem = Nothing
            End If
        Catch ex As Exception
            NotifyUser(ex.ToString())
        End Try
    End Sub

End Class

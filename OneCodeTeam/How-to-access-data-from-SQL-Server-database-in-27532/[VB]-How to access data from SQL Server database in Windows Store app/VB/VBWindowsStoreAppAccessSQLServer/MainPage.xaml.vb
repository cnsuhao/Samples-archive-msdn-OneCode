'****************************** Module Header ******************************\
' Module Name:  MainPage.xaml.vb
' Project:      VBWindowsStoreAppAccessSQLServer
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to access data from SQL Server database in Windows Store apps 
'  
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits VBWindowsStoreAppAccessSQLServer.Common.LayoutAwarePage

    ''' <summary>
    ''' Invoked when this page is about to be displayed in a Frame.
    ''' </summary>
    ''' <param name="e">Event data that describes how this page was reached.  The Parameter
    ''' property is typically used to configure the page.</param>
    Protected Overrides Sub OnNavigatedTo(e As Navigation.NavigationEventArgs)

    End Sub

    '' Get data from SQL Server by WCF Service
    Private Async Sub GetButton_Click(sender As Object, e As RoutedEventArgs)
        '' Create proxy instance
        Dim serviceClient As New AccessSQLService.ServiceClient()
        '' async call WCF method to get returned data
        Dim request As New AccessSQLService.querySqlRequest()
        Dim ds As AccessSQLService.querySqlResponse = Await serviceClient.querySqlAsync(request)

        If ds.queryParam Then
            '' Convert Xml to List<Article>
            Dim xdoc As XDocument = XDocument.Parse(ds.querySqlResult.Nodes(1).ToString(), LoadOptions.None)
            Dim data = From query In xdoc.Descendants("Table")
                       Select New Article() With
                              {
                                .Title = query.Element("Title").Value,
                                .Text = query.Element("Text").Value
                              }
            '' set ItemsSource of ListView control
            lvDataTemplates.ItemsSource = data
        Else
            NotifyUser("Error occurs. Please make sure the database has been attached to SQL Server!")
        End If
    End Sub

#Region "Common methods"

    ''' <summary>
    ''' The the event handler for the click event of the link in the footer. 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Async Function FooterClick(sender As Object, e As RoutedEventArgs) As Task
        Dim hyperlinkButton As HyperlinkButton = TryCast(sender, HyperlinkButton)
        If hyperlinkButton IsNot Nothing Then
            Await Windows.System.Launcher.LaunchUriAsync(New Uri(hyperlinkButton.Tag.ToString()))
        End If
    End Function

    Public Sub NotifyUser(message As String)
        Me.StatusBlock.Text = message
    End Sub
#End Region

End Class


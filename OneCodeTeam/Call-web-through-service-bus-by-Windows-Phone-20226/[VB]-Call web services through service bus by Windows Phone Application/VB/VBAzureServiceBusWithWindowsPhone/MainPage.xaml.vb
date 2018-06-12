'****************************** Module Header ******************************\
'Module Name:  MainPage.xaml.vb
'Project:      VBAzureServiceBusWithWindowsPhone
'Copyright (c) Microsoft Corporation.
'
'The sample code demonstrates how to expose an on-premise REST service to Internet
'via Service Bus, then you can access this service by Windows Phone application.
'The service includes normal string, generics and image methods.
'
'This is the Windows Phone Application MainPage, here we use three buttons to call
'Service Bus service and display the result on the phone page.
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Windows.Media.Imaging

Partial Public Class MainPage
    Inherits PhoneApplicationPage
    Dim request As HttpWebRequest
    Shared servicebusNamespace As String = "[Your Namespace]"
    Private helloUri As String = [String].Format("http://{0}.servicebus.windows.net/Hello?name=New User", servicebusNamespace)
    Private personUri As String = [String].Format("http://{0}.servicebus.windows.net/Person", servicebusNamespace)
    Private imageUri As String = [String].Format("http://{0}.servicebus.windows.net/Image", servicebusNamespace)
    ' Constructor
    Public Sub New()
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' Invoke Hello service method.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub button1_Click(sender As System.Object, e As System.Windows.RoutedEventArgs)
        request = DirectCast(HttpWebRequest.Create(helloUri), HttpWebRequest)
        request.Method = "GET"
        btnHello.Content = "Wait for your information.."
        Dim result As IAsyncResult = request.BeginGetResponse(New AsyncCallback(AddressOf Process), "")
    End Sub

    ''' <summary>
    ''' Give information to button's content property.
    ''' </summary>
    ''' <param name="result"></param>
    Private Sub Process(result As IAsyncResult)
        Dim response As HttpWebResponse = DirectCast(request.EndGetResponse(result), HttpWebResponse)
        Dim stream As Stream = response.GetResponseStream()
        Dim s As String = String.Empty
        Using reader As New StreamReader(stream)
            s = reader.ReadToEnd()
            s = Regex.Replace(s, "<(.[^>]*)>", "", RegexOptions.IgnoreCase)
        End Using
        Dispatcher.BeginInvoke(New Action(Sub()
                                              btnHello.Content = s
                                              btnPerson.Content = "Get Person"
                                              btnImage.Content = "Get Image"
                                              lstData.Visibility = Visibility.Collapsed
                                              imgSource.Visibility = Visibility.Collapsed

                                          End Sub))
    End Sub

    ''' <summary>
    ''' Invoke Person service method.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub button2_Click(sender As System.Object, e As System.Windows.RoutedEventArgs)
        request = DirectCast(HttpWebRequest.Create(personUri), HttpWebRequest)
        request.Method = "GET"
        btnPerson.Content = "Wait for your information.."
        Dim result As IAsyncResult = request.BeginGetResponse(New AsyncCallback(AddressOf PersonProcess), "")
    End Sub

    ''' <summary>
    ''' Give Person model class entity information to ListBox control.
    ''' </summary>
    ''' <param name="result"></param>
    Private Sub PersonProcess(result As IAsyncResult)
        Dispatcher.BeginInvoke(New Action(Sub()
                                              lstData.Items.Clear()

                                          End Sub))
        Dim response As HttpWebResponse = DirectCast(request.EndGetResponse(result), HttpWebResponse)
        Dim stream As Stream = response.GetResponseStream()
        Dim str As String = String.Empty
        Dim list As New List(Of Person)()
        Using reader As New StreamReader(stream)
            str += reader.ReadToEnd()

            Dim collection As MatchCollection = Regex.Matches(str, "<Person.*?>(.*?)</Person>")
            For Each c As Match In collection
                If Not c.Value.Equals(String.Empty) Then
                    Dim person As New Person()
                    person.Name = Regex.Replace(Regex.Match(c.Value, "<Name.*?>(.*?)</Name>").Value, "<[^>]*>", String.Empty, RegexOptions.IgnoreCase)
                    person.Comments = Regex.Replace(Regex.Match(c.Value, "<Comments>((\s)*(.*?)(\s)*(.*?)(\s)*(.*?)(\s)*(.*?)(\s)*)</Comments>").Value, "<[^>]*>", String.Empty, RegexOptions.IgnoreCase)
                    list.Add(person)
                End If
            Next

            Dispatcher.BeginInvoke(New Action(Sub()
                                                  For Each p As Person In list
                                                      lstData.Items.Add("Person Name:" + p.Name)
                                                      lstData.Items.Add("Person Comments:" + p.Comments)
                                                      btnPerson.Content = "OK"
                                                      lstData.Visibility = Visibility.Visible
                                                      imgSource.Visibility = Visibility.Collapsed
                                                      btnImage.Content = "Get Image"
                                                      btnHello.Content = "Get Hello"
                                                  Next

                                              End Sub))
        End Using

    End Sub

    ''' <summary>
    ''' Invoke Image service method.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub button3_Click(sender As System.Object, e As System.Windows.RoutedEventArgs)
        request = DirectCast(HttpWebRequest.Create(imageUri), HttpWebRequest)
        request.Method = "GET"
        btnImage.Content = "Wait for your image.."
        Dim result As IAsyncResult = request.BeginGetResponse(New AsyncCallback(AddressOf ImageProcess), Nothing)
    End Sub

    ''' <summary>
    ''' Give Image stream to Image control.
    ''' </summary>
    ''' <param name="result"></param>
    Private Sub ImageProcess(result As IAsyncResult)
        Dim response As HttpWebResponse = DirectCast(request.EndGetResponse(result), HttpWebResponse)
        Dim stream As Stream = response.GetResponseStream()
        Dispatcher.BeginInvoke(New Action(Sub()
                                              Dim source As New BitmapImage()
                                              source.SetSource(stream)
                                              imgSource.Source = source
                                              lstData.Visibility = Visibility.Collapsed
                                              imgSource.Visibility = Visibility.Visible
                                              btnImage.Content = "OK"
                                              btnPerson.Content = "Get Person"
                                              btnHello.Content = "Get Hello"

                                          End Sub))

    End Sub
End Class

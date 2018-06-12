'****************************** Module Header ******************************\
' Module Name:  MainPage.xaml.vb
' Project:      VBAzureACSAndODataToken
' Copyright (c) Microsoft Corporation.
'
' The sample code demonstrates how to access the WCF service via Access control
' service token. Here we create a Silverlight application and a normal Console 
' application client. The Token format is SWT, and we will use password as the 
' Service identities.
'
' This page is a Silverlight UserControl. It's used to send HttpWebRequest to ACS
' and get Token back, then re-send a request to service with Token in http 
' header to get data from WCF service.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System.IO
Imports System.Windows.Browser
Imports System.Text
Imports System.Xml.Linq
Imports System.Collections.ObjectModel

Partial Public Class MainPage
    Inherits UserControl
    ''' <summary>
    ''' Necessary variables from ACS Portal.
    ''' </summary>
    ''' <remarks></remarks>
    Const serviceNamespace As String = "<Your ACS namespace>"
    Const acsHostUrl As String = "accesscontrol.windows.net"
    Const realm As String = "<Your ACS service path>"
    Const loginUrl As String = "<The user service path>"
    Const uid As String = "<Your service identity name>"
    Const pwd As String = "<Your service identity password>"
    Dim variables As String
    Dim tokenString As String
    ''' <summary>
    ''' Get Token from ACS.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        InitializeComponent()
    End Sub
    ''' <summary>
    ''' Access WCF service.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnToken_Click(sender As Object, e As RoutedEventArgs) Handles btnLogin.Click
        Dim token As String = GetTokenFromACS(realm)
    End Sub

    ''' <summary>
    ''' Display data from WCF service.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnData_Click(sender As Object, e As RoutedEventArgs) Handles btnData.Click
        If Not tbToken.Text.Trim().Equals(String.Empty) Then
            Dim request As HttpWebRequest = TryCast(HttpWebRequest.Create(loginUrl), HttpWebRequest)
            Dim headerValue As String = String.Format("WRAP access_token=""{0}""", tokenString)
            request.Method = "GET"
            request.Headers("Authorization") = headerValue
            Dim callBack As New AsyncCallback(AddressOf LoginGetResponse)

            request.BeginGetResponse(callBack, request)
        Else
            lbContent.Content = "Please get token first."
        End If
    End Sub

    ''' <summary>
    ''' Get Token from ACS portal.
    ''' </summary>
    ''' <param name="result"></param>
    ''' <remarks></remarks>
    Public Sub LoginGetResponse(result As IAsyncResult)
        Dim request As HttpWebRequest = TryCast(result.AsyncState, HttpWebRequest)
        Dim response As HttpWebResponse = TryCast(request.EndGetResponse(result), HttpWebResponse)
        Dim obj As String = String.Empty
        Using reader As New StreamReader(response.GetResponseStream())
            obj = reader.ReadToEnd()
        End Using
        Dim document As XDocument = XDocument.Parse(obj)
        Dim List = From d In document.Descendants("User")
                   Select New User() With { _
          .UserId = d.Element("UserId").Value, _
          .FirstName = d.Element("FirstName").Value, _
          .LastName = d.Element("LastName").Value _
        }
        Dim collection As New ObservableCollection(Of User)()
        For Each user As User In List
            collection.Add(user)
        Next

        Dispatcher.BeginInvoke(Sub()
                                   dtgContent.ItemsSource = collection
                               End Sub)

    End Sub

    Private Function GetTokenFromACS(scope As String) As String
        Dim wrapPassword As String = pwd
        Dim wrapUsername As String = uid

        ' request a token from ACS
        Dim address As String = String.Format("https://{0}.{1}/WRAPv0.9", serviceNamespace, acsHostUrl)
        Dim requestToken As HttpWebRequest = DirectCast(HttpWebRequest.Create(address), HttpWebRequest)
        variables = String.Format("{0}={1}&{2}={3}&{4}={5}", "wrap_name", wrapUsername, "wrap_password", wrapPassword, "wrap_scope", _
         scope)
        requestToken.Method = "POST"
        Dim callBack As New AsyncCallback(AddressOf EndGetRequestStream)
        requestToken.BeginGetRequestStream(callBack, requestToken)
        Return tokenString
    End Function

    Public Sub EndGetRequestStream(result As IAsyncResult)
        Dim requestToken As HttpWebRequest = TryCast(result.AsyncState, HttpWebRequest)
        Dim stream As Stream = requestToken.EndGetRequestStream(result)
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(variables)
        stream.Write(bytes, 0, bytes.Length)
        stream.Close()
        requestToken.BeginGetResponse(AddressOf TokenEndReponse, requestToken)
    End Sub

    Public Sub TokenEndReponse(result As IAsyncResult)
        Dim requestToken As HttpWebRequest = TryCast(result.AsyncState, HttpWebRequest)
        Dim responseToken As HttpWebResponse = TryCast(requestToken.EndGetResponse(result), HttpWebResponse)
        Using reader As New StreamReader(responseToken.GetResponseStream())
            tokenString = reader.ReadToEnd()
        End Using

        Dim resultString As String = HttpUtility.UrlDecode(tokenString.Split("&"c).[Single](Function(value) value.StartsWith("wrap_access_token=", StringComparison.OrdinalIgnoreCase)).Split("="c)(1))
        tokenString = resultString
        Dispatcher.BeginInvoke(Sub()
                                   tbToken.Text = resultString
                               End Sub)

    End Sub
End Class
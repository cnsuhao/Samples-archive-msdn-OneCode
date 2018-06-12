'***************************** Module Header ******************************\
'Module Name:  SOAPAPI.aspx.vb
'Project:      VBTranslatorForAzure
'Copyright (c) Microsoft Corporation.
' 
'The sample code demonstrates how to use Bing translator API when you get it 
'from Azure marked place.
'
'This web form page shows a form with input controls and can translate English
'to Chinese by SOAP API.
' 
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
'All other rights reserved.
' 
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\**************************************************************************

Imports VBTranslatorForAzure.TranslatorForAzure
Imports System.ServiceModel.Channels
Imports System.ServiceModel
Imports System.Net
Imports System.IO
Imports System.Runtime.Serialization.Json
Imports System.Runtime.Serialization


Public Class SOAPAPI
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    ''' <summary>
    ''' Obtaining an access token, and use Microsoft translator SOAP API for translating
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btnTranslate_Click(sender As Object, e As EventArgs) Handles btnTranslate.Click
        'Obtaining an access token
        Dim authentication As New AdmAuthentication(UserData.clientID, UserData.clientSecret)
        Dim headerValue As String
        Dim token As AdmAccessToken = authentication.GetAccessToken()
        headerValue = "Bearer " + token.access_token
        Try
            'Add access token to header.
            Dim httpRequestProperty As New HttpRequestMessageProperty()
            httpRequestProperty.Headers.Add("Authorization", headerValue)
            Dim client As New TranslatorService.LanguageServiceClient()
            Using scope As New OperationContextScope(client.InnerChannel)
                OperationContext.Current.OutgoingMessageProperties(HttpRequestMessageProperty.Name) = httpRequestProperty
                Dim translationResult As String

                'Keep appId parameter blank as we are sending access token in authorization header.
                translationResult = client.Translate("", tbNeedTranslate.Text, "en", "zh-CHS", "text/html", "")
                lblEntitySet.Text = translationResult
            End Using
        Catch ex As WebException
            'Please check your client ID, client secret, redirect url, if this exception hit.


            ProcessWebException(ex)
        Catch ex1 As Exception

            Response.Write(ex1.Message)
        End Try

    End Sub


    ''' <summary>
    ''' Obtain detailed error information.
    ''' </summary>
    ''' <param name="e"></param>
    Private Sub ProcessWebException(e As WebException)
        Dim strResponse As String = String.Empty
        Using response As HttpWebResponse = DirectCast(e.Response, HttpWebResponse)
            Using responseStream As Stream = response.GetResponseStream()
                Using sr As New StreamReader(responseStream, System.Text.Encoding.ASCII)
                    strResponse = sr.ReadToEnd()
                End Using
            End Using
        End Using
        Page.Response.Write("Http status code =" + e.Status + " error message={1}" + strResponse)
    End Sub
End Class
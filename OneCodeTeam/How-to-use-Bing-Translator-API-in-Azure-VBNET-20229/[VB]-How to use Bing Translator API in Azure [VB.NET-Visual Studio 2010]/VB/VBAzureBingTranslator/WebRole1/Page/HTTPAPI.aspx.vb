'***************************** Module Header ******************************\
'Module Name:  HTTPAPI.aspx.vb
'Project:      VBTranslatorForAzure
'Copyright (c) Microsoft Corporation.
' 
'The sample code demonstrates how to use Bing translator API when you get it 
'from Azure marked place.
'
'This web form page shows a form with input controls and can translate English
'to Chinese by HTTP API.
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
Imports System.Net
Imports System.IO

Public Class HTTPAPI
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    ''' <summary>
    ''' Obtaining an access token, and use Microsoft translator HTTP API for translating.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btnTranslate_Click(sender As Object, e As EventArgs) Handles btnTranslate.Click
        'Obtaining an access token.
        Dim authentication As New AdmAuthentication(UserData.clientID, UserData.clientSecret)
        Dim headerValue As String
        Dim token As AdmAccessToken = authentication.GetAccessToken()
        headerValue = "Bearer " + token.access_token
        Try
            'Add access token to header.
            Dim txtToTranslate As String = tbNeedTranslate.Text
            Dim uri As String = "http://api.microsofttranslator.com/v2/Http.svc/Translate?text=" + System.Web.HttpUtility.UrlEncode(txtToTranslate) + "&from=en&to=zh-CHS"
            Dim translationWebRequest As WebRequest = WebRequest.Create(uri)
            translationWebRequest.Headers.Add("Authorization", headerValue)
            Dim response As WebResponse = Nothing
            response = translationWebRequest.GetResponse()
            Dim stream As IO.Stream = response.GetResponseStream()
            Dim encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")
            Dim translatedStream As New System.IO.StreamReader(stream, encode)
            Dim xTranslation As New System.Xml.XmlDocument()
            xTranslation.LoadXml(translatedStream.ReadToEnd())

            lblEntitySet.Text = xTranslation.InnerText
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
'***************************** Module Header ******************************\
'Module Name:  AJAXAPI.aspx.vb
'Project:      VBTranslatorForAzure
'Copyright (c) Microsoft Corporation.
' 
'The sample code demonstrates how to use Bing translator API when you get it 
'from Azure marked place.
'
'This web form page shows a form with input controls and can translate English
'to Chinese by AJAX API.
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

Public Class AJAXAPI
    Inherits System.Web.UI.Page

    ''' <summary>
    ''' Obtaining an access token.
    ''' This is used to authenticate you access to the Microsoft translator API.
    ''' </summary>
    ''' <returns></returns>
    <System.Web.Services.WebMethod()>
    Public Shared Function GetAccessToken() As AdmAccessToken
        Dim authentication As New AdmAuthentication(UserData.clientID, UserData.clientSecret)

        Return authentication.GetAccessToken()


    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

End Class
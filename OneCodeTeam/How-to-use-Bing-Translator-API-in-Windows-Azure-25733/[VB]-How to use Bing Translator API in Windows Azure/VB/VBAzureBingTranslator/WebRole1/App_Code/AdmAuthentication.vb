'***************************** Module Header ******************************\
'Module Name:  AdmAuthentication.vb
'Project:      VBTranslatorForAzure
'Copyright (c) Microsoft Corporation.
' 
'The sample code demonstrates how to use Bing translator API when you get it 
'from Azure marked place.
'
'This is a Admin authentication class. 
'You can create a authentication instance with this class, GetAccessToken method
'will return a AdmAccessToken instance.
' 
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
'All other rights reserved.
' 
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\**************************************************************************

Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.Runtime.Serialization.Json
Imports System.Runtime.Serialization
Imports System.Net
Imports System.Text
Imports System.IO



Namespace TranslatorForAzure
	Public Class AdmAuthentication
		Public Shared ReadOnly DatamarketAccessUri As String = "https://datamarket.accesscontrol.windows.net/v2/OAuth2-13"
		Private clientId As String
		Private cientSecret As String
		Private request As String

		Public Sub New(clientId As String, clientSecret As String)
			Me.clientId = clientId
			Me.cientSecret = clientSecret
			'If clientid or client secret has special characters, encode before sending request

			Me.request = String.Format("grant_type=client_credentials&client_id={0}&client_secret={1}&scope=http://api.microsofttranslator.com", HttpUtility.UrlEncode(clientId), HttpUtility.UrlEncode(clientSecret))
		End Sub


		Public Function GetAccessToken() As AdmAccessToken
			Return HttpPost(DatamarketAccessUri, Me.request)
		End Function

		Private Function HttpPost(DatamarketAccessUri As String, requestDetails As String) As AdmAccessToken
			'Prepare OAuth request 
            Dim webRequest As WebRequest = WebRequest.Create(DatamarketAccessUri)
            webRequest.ContentType = "application/x-www-form-urlencoded"
            webRequest.Method = "POST"
			Dim bytes As Byte() = Encoding.ASCII.GetBytes(requestDetails)
            webRequest.ContentLength = bytes.Length
            Using outputStream As Stream = webRequest.GetRequestStream()
                outputStream.Write(bytes, 0, bytes.Length)
            End Using
            Using webResponse As WebResponse = webRequest.GetResponse()
                Dim serializer As New DataContractJsonSerializer(GetType(AdmAccessToken))
                'Get deserialized object from JSON stream
                Dim token As AdmAccessToken = DirectCast(serializer.ReadObject(webResponse.GetResponseStream()), AdmAccessToken)
                Return token
            End Using
		End Function
	End Class

End Namespace
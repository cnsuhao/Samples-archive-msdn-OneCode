'***************************** Module Header ******************************\
'Module Name:  AdmAccessToken.vb
'Project:      VBTranslatorForAzure
'Copyright (c) Microsoft Corporation.
' 
'The sample code demonstrates how to use Bing translator API when you get it 
'from Azure marked place.
'
'This is a Admin Access Token entity class.
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
Imports System.Runtime.Serialization


Namespace TranslatorForAzure
    <DataContract()>
    Public Class AdmAccessToken
        Private _access_token As String
        Private _token_type As String
        Private _expires_in As String
        Private _scope As String

        <DataMember()>
        Public Property access_token() As String
            Get
                Return _access_token
            End Get
            Set(value As String)
                _access_token = value
            End Set
        End Property

        <DataMember()>
        Public Property token_type() As String
            Get
                Return _token_type
            End Get
            Set(value As String)
                _token_type = value
            End Set
        End Property

        <DataMember()>
        Public Property expires_in() As String
            Get
                Return _expires_in
            End Get
            Set(value As String)
                _expires_in = value
            End Set
        End Property

        <DataMember()>
        Public Property scope() As String
            Get
                Return _scope
            End Get
            Set(value As String)
                _scope = value
            End Set
        End Property

    End Class
End Namespace
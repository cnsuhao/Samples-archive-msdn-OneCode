'************************************* Module Header ***********************\
' Module Name:  MainViewModel.vb
' Project:      VBWindowsStoreAppASHWID
' Copyright (c) Microsoft Corporation.
' 
' ViewModel for the MainPage.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/
Imports System.Text
Imports System.Net.Http
Imports System.Runtime.Serialization.Json
Imports System.Net.Http.Headers
Imports Windows.Data.Json
Imports Windows.Security.Cryptography
Imports Windows.UI.Popups
Imports Windows.Storage.Streams
Imports Windows.System.Profile
Imports Windows.System

Public Class MainViewModel
    Inherits ViewModelBase

    ''' <summary>
    ''' Nested class for const property names for NotifyProperty in data binding.
    ''' </summary>
    ''' <remarks></remarks>
    Private Class PropertyNames
        Friend Const OutputTextPropertyName As String = "OutputText"
        Friend Const RegisterDeviceBtnTextPropertyName As String = "RegisterDeviceBtnText"
    End Class

#Region "Private Fields"

    Private ReadOnly _customerId As Guid
    Private ReadOnly _clientAgentId As String
    Private Const MediaTypeHeaderJson As String = "application/json"
    Private _outputText As String
    Private _canVerifyLicense As Boolean
    Private _registerDeviceCommand As DelegateCommand
    Private _footerCommand As DelegateCommand

    ' Specify the cloud service base Uri here.
    Private Const ServiceBaseUri As String = "http://localhost:12345/"
    ' Use following relative path to retrieve the OTP nonce from the cloud.
    Private Const GetNonceApiUriPath As String = "api/OneTimePassword"
    ' Use following relative path to post ASHWID token to the cloud.
    Private Const PostAshwidApiUriPath As String = "api/ASHWID"

#End Region


#Region "Constructor"

    ''' <summary>
    ''' Constructor
    ''' </summary>
    Public Sub New()
        _customerId = New Guid("00000000-0000-0000-0000-000000000001")
        _clientAgentId = String.Concat("AllInOneCode-", Guid.NewGuid)
        CanVerifyLicense = False
    End Sub

#End Region

#Region "Public Properties"

    ''' <summary>
    ''' Update the text on RegisterDevice button.
    ''' For the first time, "Register Device on cloud" is shown.
    ''' After registration, "Verify Device on cloud" text is replaced.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property CanVerifyLicense As Boolean
        Get
            Return _canVerifyLicense
        End Get
        Set(ByVal value As Boolean)
            _canVerifyLicense = value
            RegisterDeviceBtnText = If(_canVerifyLicense, "Verify Device on Cloud", "Register Device on Cloud")
            NotifyPropertyChanged(PropertyNames.RegisterDeviceBtnTextPropertyName)
        End Set
    End Property

    ''' <summary>
    ''' Properties bound to the RegisterDevice button.
    ''' </summary>
    Public Property RegisterDeviceBtnText As String

    ''' <summary>
    ''' Properties bound to the OutputText TextBlock.
    ''' </summary>
    ''' <value></value>
    Public Property OutputText As String
        Get
            Return _outputText
        End Get
        Set(ByVal value As String)
            _outputText = value
            NotifyPropertyChanged(PropertyNames.OutputTextPropertyName)
        End Set
    End Property

#End Region

#Region "Command"
    Public ReadOnly Property RegisterDeviceCommand As DelegateCommand
        Get
            Return If(_registerDeviceCommand IsNot Nothing, _registerDeviceCommand,
                      New DelegateCommand(Function(o As Object)
                                              RegisterDevice()
                                          End Function))
        End Get
    End Property

    ''' <summary>
    ''' DelegateCommand for "Footer" HyperLinkButton
    ''' </summary>
    Public ReadOnly Property FooterCommand As DelegateCommand
        Get
            Return If(_footerCommand IsNot Nothing, _footerCommand, _
                      New DelegateCommand(Function(o As Object)
                                              NavigateToOneCodeSite()
                                          End Function))
        End Get
    End Property

    Private Async Sub RegisterDevice()
        Dim nonce As IBuffer = GetNonce.Result
        If (nonce Is Nothing) Then
            WriteToOutputText("Retrieve random nonce from the cloud failure.  Please check the network connectivity...")
        Else
            Dim nonceBytes As Byte() = Utilities.ConvertBufferToByteArray(nonce)
            WriteToOutputText(String.Format("Get random nonce from the cloud: {0}", _
                        New UTF8Encoding().GetString(nonceBytes, 0, nonceBytes.Length)))

            ' Hardware id, signature, certificate IBuffer objects that can be accessed through properties.
            Dim packageSpecificToken As HardwareToken = HardwareIdentification.GetPackageSpecificToken(nonce)
            Dim hwId As New Ashwid With {
                    .CustomerId = _customerId,
                    .HardwareId = Utilities.ConvertBufferToByteArray(packageSpecificToken.Id),
                    .Certificate = Utilities.ConvertBufferToByteArray(packageSpecificToken.Certificate),
                    .Signature = Utilities.ConvertBufferToByteArray(packageSpecificToken.Signature)
                }

            WriteToOutputText(String.Format( _
                "Call API ""HardwareIdentification.GetPackageSpecificToken(nonce)"" to retrieve Hardware identification on the current device:" & _
                vbCrLf & "  {0}", BitConverter.ToString(hwId.HardwareId)))
            WriteToOutputText(String.Format( _
                "Current customer id (Hardcoded, need be replaced by Microsoft Account Id or per your business logic):" & _
                vbCrLf & "  {0}", _customerId))
            WriteToOutputText(String.Format( _
                "Start to {0} Hardware Id to the cloud...", _
                If(CanVerifyLicense, "verify", "register")))

            Dim postResult As Boolean = Await PostASHWID(hwId)
            If postResult Then
                WriteToOutputText(String.Format("{0} ASHWID to the cloud successfully.", _
                            If(CanVerifyLicense, "Verify", "Register")))
            Else
                WriteToOutputText(String.Format("{0} ASHWID on the cloud failure.", _
                            If(CanVerifyLicense, "Verify", "Register")))
            End If
            
            WriteToOutputText("--------------------------------------------" &
                              "--------------------------------------------")
            CanVerifyLicense = True
        End If
    End Sub

    Private Shared Async Sub NavigateToOneCodeSite()
        Await Launcher.LaunchUriAsync(New Uri("http://blogs.msdn.com/b/onecode"))
    End Sub

#End Region

#Region "WebApi Request to the Cloud"

    ''' <summary>
    ''' Post ASHWID to the cloud.
    ''' </summary>
    Private Async Function PostAshwid(ByVal hwId As Ashwid) As Task(Of Boolean)
        Dim errMsg As String = String.Empty

        Try
            Using client As HttpClient = New HttpClient
                ' Add a unique AgentId to the request header.
                client.DefaultRequestHeaders.UserAgent.ParseAdd(_clientAgentId)

                ' Use JSON request to post the ASHWID to the cloud side.
                client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue(MediaTypeHeaderJson))
                client.BaseAddress = New Uri(ServiceBaseUri)

                ' Use Json serializer
                Dim serializer As New DataContractJsonSerializer(GetType(Ashwid))
                Using stream As MemoryStream = New MemoryStream
                    serializer.WriteObject(stream, hwId)
                    stream.Seek(0, SeekOrigin.Begin)

                    Dim jsonContent As String = New StreamReader(stream).ReadToEnd
                    Dim response As HttpResponseMessage = _
                        Await client.PostAsync(PostAshwidApiUriPath, _
                            New StringContent(jsonContent, Encoding.UTF8, MediaTypeHeaderJson))
                    If response.IsSuccessStatusCode Then
                        Return True
                    End If

                    ' If errors happen during the certification & signature validation,
                    ' show the error message in the MessageDialog.
                    Dim data As String = Await response.Content.ReadAsStringAsync
                    If (Not data Is Nothing) Then
                        Dim content As JsonObject
                        JsonObject.TryParse(data, content)
                        If (Not content Is Nothing) Then
                            Dim val As IJsonValue
                            content.TryGetValue("Message", val)
                            If (Not val Is Nothing) Then
                                Await New MessageDialog(String.Format("{0}: {1}",
                                    response.ReasonPhrase, val.GetString)).ShowAsync
                            End If
                        End If
                    End If
                End Using
            End Using
        Catch hReqEx As HttpRequestException
            errMsg = String.Format("HttpRequest error: {0}", hReqEx.Message)
        End Try

        If Not String.IsNullOrEmpty(errMsg) Then
            Await New MessageDialog(errMsg).ShowAsync
        End If

        Return False
    End Function

    ''' <summary>
    ''' Request a nonce from the server
    ''' </summary>
    ''' <returns>
    ''' Return the nonce from the cloud.
    ''' If get the request error, return null by default.
    ''' </returns>
    Private Async Function GetNonce() As Task(Of IBuffer)
        Dim errMsg As String = String.Empty

        Try
            Using client As HttpClient = New HttpClient
                ' Add a unique AgentId to the request header.
                client.DefaultRequestHeaders.UserAgent.ParseAdd(_clientAgentId)

                ' Use JSON request to get the nonce from the cloud side.
                client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue(MediaTypeHeaderJson))
                client.BaseAddress = New Uri(ServiceBaseUri)

                Dim content As String = client.GetStringAsync(GetNonceApiUriPath).Result
                Dim stream As New MemoryStream(Encoding.Unicode.GetBytes(content))

                ' Deserialize the OneTimePassword
                Dim serializer As New DataContractJsonSerializer(GetType(OneTimePassword))
                Dim otpObj As OneTimePassword = TryCast(serializer.ReadObject(DirectCast(stream, Stream)), OneTimePassword)
                If Not ((otpObj Is Nothing) OrElse String.IsNullOrEmpty(otpObj.Nonce)) Then
                    Return CryptographicBuffer.ConvertStringToBinary(otpObj.Nonce, BinaryStringEncoding.Utf8)
                End If
            End Using
        Catch hReqEx As HttpRequestException
            errMsg = String.Format("HttpRequest error: {0}", hReqEx.Message)
        Catch ex As Exception
            errMsg = String.Format("HttpRequest error: {0}", ex.Message)
        End Try

        If Not String.IsNullOrEmpty(errMsg) Then
            Await New MessageDialog(errMsg).ShowAsync
        End If

        Return Nothing
    End Function

#End Region

#Region "Utilities"

    Private Sub WriteToOutputText(ByVal message As String)
        OutputText += String.Format("- {0}" & vbCrLf & vbCrLf, message)
    End Sub

#End Region

End Class

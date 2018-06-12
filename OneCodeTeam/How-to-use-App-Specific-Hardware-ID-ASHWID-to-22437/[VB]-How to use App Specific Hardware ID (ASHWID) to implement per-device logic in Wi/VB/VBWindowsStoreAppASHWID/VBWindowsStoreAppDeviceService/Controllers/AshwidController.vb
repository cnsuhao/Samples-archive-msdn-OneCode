'************************************* Module Header ***********************\
' Module Name:  AshwidController.vb
' Project:      VBWindowsStoreAppASHWID
' Copyright (c) Microsoft Corporation.
' 
'  AshwidController class for client to upload Ashwid and verify the genuine of the
' Hardware Id and deal with the Hardware drift.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Imports System.Net
Imports System.Net.Http
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Pkcs
Imports Security.Cryptography
Imports VBWindowsStoreAppDeviceService.Models
Imports System.Security.Cryptography.X509Certificates

Namespace VBWindowsStoreAppDeviceService
    Public Class AshwidController
        Inherits System.Web.Http.ApiController

        Private db As New VBWindowsStoreAppDeviceServiceContext
        Private _otp As OneTimePassword

#Region "Public Key"

        Private Shared ReadOnly GRootPublicKey As Byte() = New Byte() { _
            &H30, &H82, &H2, &HA, &H2, &H82, &H2, &H1, &H0, &HA8, &HEF, &HCE, &HEF, &HEC, &H12, &H8B,
            &H92, &H94, &HED, &HCF, &HAA, &HA5, &H81, &H8D, &H4F, &HA4, &HAD, &H4A, &HEC, &HA5, &HF0, &HDA,
            &HA8, &H3D, &HB6, &HE5, &H61, &H1, &H99, &HCE, &H3A, &H23, &H73, &H5A, &H58, &H67, &H9F, &HF5,
            &HB6, &H5B, &HF5, &H4F, &HF9, &HA0, &H9B, &H75, &H1E, &HCC, &H53, &H62, &H10, &H3C, &HA7, &HA5,
            &H3A, &H3B, &HE6, &H24, &H22, &HF4, &H18, &H96, &H2E, &HF2, &HFC, &HD9, &HA5, &H88, &HC6, &HFD,
            &H51, &HF0, &H31, &HC3, &HBD, &H1, &HDC, &H45, &HB6, &HF6, &H40, &H2B, &HB7, &H45, &H7B, &H45,
            &H4F, &HED, &HC0, &HB4, &H7C, &H58, &H44, &HF9, &H89, &HFB, &H6A, &H75, &H3B, &H6D, &HF1, &H2E,
            &HAC, &H35, &HA1, &H5F, &H7A, &H94, &HCD, &H3A, &H6D, &H98, &HB8, &HB8, &H29, &HE6, &H33, &H98,
            &H2E, &H33, &H83, &H7A, &H86, &HB7, &HA8, &HA, &H10, &HF2, &H7, &H32, &H63, &HE4, &H32, &HED,
            &H4D, &HAB, &H5, &HC, &HA1, &HD7, &H72, &H49, &HAC, &H35, &H2C, &H2E, &H70, &HED, &HEE, &H12,
            &HFC, &H23, &HB1, &HDC, &H5A, &HDF, &H61, &HE9, &H2C, &H44, &HCD, &HAE, &HDB, &H6, &H54, &H8F,
            &H4F, &HC1, &HD6, &H15, &H72, &HAE, &H50, &H89, &H39, &H89, &HF5, &H95, &H82, &HDC, &HFF, &H41,
            &HEB, &H89, &H6F, &HBC, &HE0, &H9F, &H79, &H5D, &H24, &H16, &HF7, &H1D, &H38, &HAA, &HDE, &HD8,
            &H24, &H97, &HF6, &H97, &H47, &H74, &H5B, &H23, &H38, &HC8, &H9D, &H2E, &HAA, &HD1, &H1F, &HCE,
            &H9, &H5C, &HF1, &HB9, &H9F, &H92, &H38, &HD2, &H11, &H68, &H3E, &HCC, &H5D, &H4E, &HCF, &H94,
            &H9F, &HD2, &H42, &HBD, &HE2, &HF1, &H4B, &HF1, &HA7, &HA9, &H5C, &H79, &H5, &HFB, &H25, &HF7,
            &HC1, &H53, &HF7, &HD9, &HC4, &H4D, &H79, &HF, &H8A, &H4D, &HB4, &H30, &H71, &HA6, &HE9, &H51,
            &HE5, &H8E, &HE0, &HC8, &H83, &HC7, &H31, &HFC, &H98, &H46, &HF6, &HA2, &H76, &HFC, &HA6, &H81,
            &H6D, &H76, &H90, &H8D, &H32, &H21, &H1F, &H2D, &H3E, &H69, &H2B, &H4F, &HAA, &HEC, &H7B, &HD3,
            &HB9, &H64, &HC1, &HD6, &HBB, &H5F, &HFA, &H38, &HC4, &H41, &HA6, &H6D, &H5A, &HC3, &H11, &H87,
            &HFB, &HBC, &H33, &H70, &H4A, &H26, &H8B, &HE6, &H44, &HDD, &HCB, &HB8, &H30, &HD3, &H9B, &H7B,
            &H1A, &HE, &H3, &HB4, &H51, &HE0, &HCA, &HBF, &H7B, &H3C, &H57, &H9A, &HA0, &HD8, &H4B, &HFE,
            &H7E, &H36, &HD8, &H81, &HFA, &H25, &HBD, &H7E, &H3, &HF5, &H59, &H2C, &HF6, &HD7, &HA7, &H6D,
            &HDD, &H10, &H77, &H77, &H9, &HAE, &H76, &HE2, &H85, &H33, &HA6, &H7D, &H71, &H20, &HF8, &H3A,
            &H4F, &H2A, &HB6, &HEA, &H42, &H29, &HD0, &HD3, &HC6, &H29, &H4B, &H5, &H2C, &HE7, &HB8, &H4A,
            &HCF, &HD2, &HBB, &H82, &H20, &H30, &H9B, &HA2, &H4D, &H1F, &H78, &H2C, &HD9, &H54, &H13, &HD8,
            &H2A, &H28, &H68, &H51, &H56, &HA5, &HF7, &HDB, &HAE, &H59, &HE, &HB9, &HD1, &H30, &H97, &H82,
            &H4, &H66, &HA5, &H2, &H3C, &H25, &HFA, &HDD, &HED, &H9, &HC2, &H60, &HBC, &H17, &H6C, &HA1,
            &H5A, &HB6, &H97, &HCC, &H8A, &H13, &H56, &HF6, &HB4, &HAE, &HDF, &HCF, &H7E, &H40, &H2F, &H49,
            &H41, &HE0, &H63, &H8E, &H58, &H20, &HCC, &HA3, &H4F, &H33, &H3B, &H9B, &HCF, &H3C, &H72, &H7E,
            &H48, &H41, &H42, &H3D, &H63, &HE3, &H5E, &HE7, &H75, &H6C, &H7F, &HEF, &H6D, &H80, &H9, &HA4,
            &H2B, &HA4, &H3E, &HDE, &HE4, &H2B, &H2C, &H2B, &HA9, &H44, &H56, &H83, &HBE, &HB6, &H6E, &H60,
            &HB9, &H16, &H1A, &HE1, &H62, &HE9, &H54, &H9D, &HBF, &H2, &H3, &H1, &H0, &H1}

#End Region


        ' POST api/Ashwid
        ''' <summary>
        ''' 1. Validate the trustworthiness and the validity of the Hardware Id posted
        ''' 2. Handle the hardware drift within the cloud service.
        ''' </summary>
        ''' <param name="ashwid"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function PostAshwid(ByVal ashwid As Ashwid) As HttpResponseMessage
            If ModelState.IsValid Then
                If Not NonceIsValid Then
                    ' RequestTimeout 408
                    Dim rm As HttpResponseMessage = Request.CreateErrorResponse( _
                        HttpStatusCode.RequestTimeout, My.Resources.NonceInValid)
                    rm.ReasonPhrase = My.Resources.NonceInValid
                    Return rm
                End If


                Dim reasonPhraseMsg As String = String.Empty
                Select Case VerifyDataGenuine(ashwid)
                    Case DataGenuineResult.NoLeafCert
                        reasonPhraseMsg = My.Resources.LeafCertificateNotFound
                        Exit Select
                    Case DataGenuineResult.CertificationChainVerificationFailure
                        reasonPhraseMsg = My.Resources.CertificationChainVerificationFailure
                        Exit Select
                    Case DataGenuineResult.RootCertificateInvalid
                        reasonPhraseMsg = My.Resources.RootCertificateInvalid
                        Exit Select
                    Case DataGenuineResult.SignatureInvalid
                        reasonPhraseMsg = My.Resources.SignatureInvalid
                        Exit Select
                    Case DataGenuineResult.Invalid
                        reasonPhraseMsg = My.Resources.DataInValid
                        Exit Select
                End Select

                If Not String.IsNullOrEmpty(reasonPhraseMsg) Then
                    ' Forbidden 403
                    Return Request.CreateErrorResponse(HttpStatusCode.Forbidden, reasonPhraseMsg)
                End If

                ' Try to find the base Hardware Id when registering the app.
                Dim baseHardwareId As Ashwid = db.Ashwids.Find(ashwid.CustomerId)

                ' You could adjust the thresold for hardware drift.
                ' For the demonstration purpose, whenever there's a minior device change,
                ' the device is considered different.
                Const thresholdForBeingTheSameDevice As Integer = 0

                If ((Not baseHardwareId Is Nothing) AndAlso (Not ashwid.HardwareId Is Nothing)) Then
                    Dim diffValue As Double = DiffDeviceDictionary( _
                                ConvertHwIdToDevDic(baseHardwareId.HardwareId), _
                                ConvertHwIdToDevDic(ashwid.HardwareId))

                    If (diffValue > thresholdForBeingTheSameDevice) Then
                        Return Request.CreateErrorResponse(HttpStatusCode.Forbidden, My.Resources.LicenseRefused)
                    End If
                Else
                    db.Ashwids.Add(ashwid)
                    db.SaveChanges()
                End If
                Dim response As HttpResponseMessage = Request.CreateResponse(HttpStatusCode.Created, ashwid)
                response.Headers.Location = New Uri(Url.Link("DefaultApi", New With {.id = ashwid.CustomerId}))
                Return response
            End If

            Return Request.CreateResponse(HttpStatusCode.BadRequest)
        End Function

        ''' <summary>
        ''' Determine if the returned nonce is valid. By default, nonce will be expired in 1 min.
        ''' </summary>
        Private ReadOnly Property NonceIsValid As Boolean
            Get
                Dim userAgent As String = Request.Headers.UserAgent.ToString
                If userAgent.StartsWith("AllInOneCode-") Then
                    userAgent = userAgent.Substring("AllInOneCode-".Length)

                    Dim userAgentGuid As New Guid(userAgent)
                    _otp = db.OneTimePasswords.Find(userAgentGuid)
                    If ((Not _otp Is Nothing) AndAlso _
                        DateTime.Compare(_otp.ExpiredTime, DateTime.UtcNow) > 0) Then
                        Return True
                    End If
                End If

                Return False
            End Get
        End Property

        ''' <summary>
        ''' Enum type of DataGenuineResult, used in the error handling of HttpResponseMessage.
        ''' </summary>
        Private Enum DataGenuineResult
            Genuine = 0
            NoLeafCert = 1
            CertificationChainVerificationFailure = 2
            RootCertificateInvalid = 3
            SignatureInvalid = 4
            Invalid = 5
        End Enum

        ''' <summary>
        ''' Verify the trustworthiness and genuine of the posted Hardware Id
        ''' by using nonce, signature and certificate.
        ''' </summary>
        ''' <param name="ashwid">ASHWID with Hardware Id, certificate and signature</param>
        ''' <returns>The enum type of DataGenuineResult</returns>
        Private Function VerifyDataGenuine(ByVal ashwid As Ashwid) As DataGenuineResult

            Const basicConstraintName As String = "Basic Constraints"
            Const leafCertEku As String = "1.3.6.1.4.1.311.10.5.40"

            Try
                ' Extract certificates from the ASHWID certificate blob.
                ' Certificate blob is a PKCS#7 formatted certification chain.
                Dim cms As New SignedCms
                cms.Decode(ashwid.Certificate)

                ' Looping through all certificates to find the leaf certificate. 
                Dim leafCert As X509Certificate2 = Nothing
                For Each x509 As X509Certificate2 In cms.Certificates
                    Dim basicConstraintExtensionExists As Boolean = False
                    For Each extension As X509Extension In x509.Extensions
                        If (extension.Oid.FriendlyName = basicConstraintName) Then
                            basicConstraintExtensionExists = True
                            Dim ext As X509BasicConstraintsExtension = DirectCast(extension, X509BasicConstraintsExtension)
                            If Not ext.CertificateAuthority Then
                                leafCert = x509
                                Exit For
                            End If
                        End If
                    Next

                    If (Not leafCert Is Nothing) Then
                        Exit For
                    End If

                    If (Not basicConstraintExtensionExists AndAlso (x509.Issuer <> x509.Subject)) Then
                        leafCert = x509
                    End If
                Next

                If (leafCert Is Nothing) Then
                    Return DataGenuineResult.NoLeafCert
                End If

                ' Validating the certificate chain. Ignore the errors due to online revocation check not 
                ' being available. Also we are not failing validation due to expired certificates. Microsoft
                ' will be revoking the certificates that were exploided.

                Dim chain As New X509Chain
                chain.ChainPolicy = New X509ChainPolicy
                chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain
                chain.ChainPolicy.RevocationMode = X509RevocationMode.Online
                chain.ChainPolicy.VerificationFlags = X509VerificationFlags.IgnoreNotTimeValid Or _
                                                    X509VerificationFlags.IgnoreCtlNotTimeValid Or _
                                                    X509VerificationFlags.IgnoreCertificateAuthorityRevocationUnknown Or _
                                                    X509VerificationFlags.IgnoreEndRevocationUnknown Or _
                                                    X509VerificationFlags.IgnoreCtlSignerRevocationUnknown

                chain.ChainPolicy.ApplicationPolicy.Add(New Oid(leafCertEku))

                Dim valid As Boolean = chain.Build(leafCert)

                If Not valid Then
                    For Each status As X509ChainStatus In chain.ChainStatus
                        Select Case status.Status
                            Case X509ChainStatusFlags.NoError, _
                                X509ChainStatusFlags.NotTimeValid, _
                                X509ChainStatusFlags.NotTimeNested, _
                                X509ChainStatusFlags.CtlNotTimeValid, _
                                X509ChainStatusFlags.RevocationStatusUnknown, _
                                X509ChainStatusFlags.OfflineRevocation
                                Exit Select
                            Case Else
                                Return DataGenuineResult.CertificationChainVerificationFailure
                        End Select
                    Next
                End If

                ' GRootPublicKey is the hard coded public key for the root certificate. 
                ' Compare the public key on the root certificate with the hard coded one. 
                ' They must match.
                Dim rootCertificate As X509Certificate2 = chain.ChainElements(chain.ChainElements.Count - 1).Certificate
                If Not rootCertificate.PublicKey.EncodedKeyValue.RawData.SequenceEqual(GRootPublicKey) Then
                    Return DataGenuineResult.RootCertificateInvalid
                End If

                ' Using the leaf Certificate we verify the signature of blob.
                ' The RSACryptoServiceProvider does not provide a way to pass in different padding mode.
                ' We use CLR Security API by CLR Security's team under:
                ' http://clrsecurity.codeplex.com/wikipage?title=Security.Cryptography.RSACng

                ' Concatenate nonce and HardwareId
                Dim nonce As Byte() = Encoding.UTF8.GetBytes(_otp.Nonce)
                Dim rawData As Byte() = New Byte((nonce.Length + ashwid.HardwareId.Length) - 1) {}
                Buffer.BlockCopy(nonce, 0, rawData, 0, nonce.Length)
                Buffer.BlockCopy(ashwid.HardwareId, 0, rawData, nonce.Length, ashwid.HardwareId.Length)

                Dim publicKey As RSACryptoServiceProvider = TryCast(leafCert.PublicKey.Key, RSACryptoServiceProvider)

                If (Not publicKey Is Nothing) Then
                    Dim rsa As New RSACng(1024)
                    rsa.EncryptionHashAlgorithm = CngAlgorithm.Sha256
                    rsa.SignatureHashAlgorithm = CngAlgorithm.Sha1
                    ' Use Pss padding here by CLR Security API
                    rsa.SignaturePaddingMode = AsymmetricPaddingMode.Pss
                    rsa.SignatureSaltBytes = 0

                    Dim parameters As RSAParameters = publicKey.ExportParameters(False)
                    rsa.ImportParameters(parameters)

                    ' Use the leaf certificate to verify that the signed hash signature 
                    ' matches the original nonce that was sent from the cloud service 
                    ' and the received hardware byte stream.
                    Dim isSignatureValid As Boolean = rsa.VerifyData(rawData, ashwid.Signature)
                    If Not isSignatureValid Then
                        Return DataGenuineResult.SignatureInvalid
                    End If
                End If
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
                Debug.WriteLine(ex.StackTrace)
                Return DataGenuineResult.Invalid
            End Try

            Return DataGenuineResult.Genuine
        End Function

        ''' <summary>
        ''' Convert serialized hardwareId to well formed HardwareId structures so that 
        ''' it can be easily consumed. 
        ''' </summary>
        ''' <param name="hardwareId"></param>
        ''' <returns></returns>
        Private Shared Function ConvertHwIdToDevDic( _
                    ByVal hardwareId As Byte()) As IDictionary(Of Integer, List(Of String))

            Dim hardwareIdString As String = BitConverter.ToString(hardwareId).Replace("-", "")

            Dim deviceDic As New Dictionary(Of Integer, List(Of String))
            ' Invalid
            deviceDic.Add(0, New List(Of String))
            ' Processor
            deviceDic.Add(1, New List(Of String))
            ' Memory
            deviceDic.Add(2, New List(Of String))
            ' Disk Device
            deviceDic.Add(3, New List(Of String))
            ' Network Adapter
            deviceDic.Add(4, New List(Of String))
            ' Audio Adapter
            deviceDic.Add(5, New List(Of String))
            ' Docking Station
            deviceDic.Add(6, New List(Of String))
            ' Mobile Broadband
            deviceDic.Add(7, New List(Of String))
            ' Bluetooth
            deviceDic.Add(8, New List(Of String))
            ' System BIOS
            deviceDic.Add(9, New List(Of String))

            For i As Integer = 0 To (hardwareIdString.Length / 8) - 1
                Select Case hardwareIdString.Substring((i * 8), 4)
                    Case "0100"
                        deviceDic(1).Add(hardwareIdString.Substring(((i * 8) + 4), 4))
                        Exit Select
                    Case "0200"
                        deviceDic(2).Add(hardwareIdString.Substring(((i * 8) + 4), 4))
                        Exit Select
                    Case "0300"
                        deviceDic(3).Add(hardwareIdString.Substring(((i * 8) + 4), 4))
                        Exit Select
                    Case "0400"
                        deviceDic(4).Add(hardwareIdString.Substring(((i * 8) + 4), 4))
                        Exit Select
                    Case "0500"
                        deviceDic(5).Add(hardwareIdString.Substring(((i * 8) + 4), 4))
                        Exit Select
                    Case "0600"
                        deviceDic(6).Add(hardwareIdString.Substring(((i * 8) + 4), 4))
                        Exit Select
                    Case "0700"
                        deviceDic(7).Add(hardwareIdString.Substring(((i * 8) + 4), 4))
                        Exit Select
                    Case "0800"
                        deviceDic(8).Add(hardwareIdString.Substring(((i * 8) + 4), 4))
                        Exit Select
                    Case "0900"
                        deviceDic(9).Add(hardwareIdString.Substring(((i * 8) + 4), 4))
                        Exit Select
                End Select
            Next

            Return deviceDic
        End Function

        ''' <summary>
        ''' Compare two devices to see the difference.
        ''' The granularity for the difference is 0.1
        ''' </summary>
        ''' <param name="devDicBase">Base Device Dictionary</param>
        ''' <param name="devDicNew">New Device Dictionary</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function DiffDeviceDictionary( _
                    ByVal devDicBase As IDictionary(Of Integer, List(Of String)),
                    ByVal devDicNew As IDictionary(Of Integer, List(Of String))) As Double

            ' Component Weight in Percentage, updated per the business logic.
            ' 0 - Invalid - 0%
            ' 1 - Processor - 10%
            ' 2 - Memory - 10%
            ' 3 - Disk Device - 20%
            ' 4 - Network Adapter - 10%
            ' 5 - Audio Adapater - 10%
            ' 6 - Docking Station - 5%
            ' 7 - Mobile Broadband - 10%
            ' 8 - Bluetooth - 5%
            ' 9 - System BIOS - 20%
            Dim compWeightPercentage As Integer() = New Integer() {0, 10, 10, 20, 10, 10, 5, 10, 5, 20}

            Dim diffValue As Double = 0
            For i As Integer = 1 To 10 - 1
                Dim diffCount As Integer = (devDicBase(i).Count - devDicNew(i).Count)

                ' the base component size is bigger than the New one.
                If (diffCount >= 0) Then
                    For Each component As String In devDicNew(i)
                        If (Not devDicBase(i).Contains(component)) Then
                            diffCount += 1
                        End If
                    Next
                Else
                    For Each component As String In devDicBase(i)
                        If (Not devDicNew(i).Contains(component)) Then
                            diffCount += 1
                        End If
                    Next
                End If

                diffValue += (diffCount * compWeightPercentage(i))
            Next

            Return diffValue / 100
        End Function


        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
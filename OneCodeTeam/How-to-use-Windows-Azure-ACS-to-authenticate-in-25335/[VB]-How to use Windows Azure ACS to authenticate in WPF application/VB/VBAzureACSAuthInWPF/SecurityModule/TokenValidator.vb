Imports System.Web
Imports System.Security.Cryptography
Imports System.Text

Public Class TokenValidator
    Private issuerLabel As String = "Issuer"
    Private expiresLabel As String = "ExpiresOn"
    Private audienceLabel As String = "Audience"
    Private hmacSHA256Label As String = "HMACSHA256"

    Private trustedSigningKey As String
    Private trustedTokenIssuer As String
    Private trustedAudienceValue As String

    Public Sub New(acsHostName As String, serviceNamespace As String, trustedAudienceValue As String, trustedSigningKey As String)
        Me.trustedSigningKey = trustedSigningKey
        Me.trustedTokenIssuer = [String].Format("https://{0}.{1}/", serviceNamespace.ToLowerInvariant(), acsHostName.ToLowerInvariant())

        Me.trustedAudienceValue = trustedAudienceValue
    End Sub

    Public Function Validate(token As String) As Boolean
        If Not Me.IsHMACValid(token, Convert.FromBase64String(Me.trustedSigningKey)) Then
            Return False
        End If

        If Me.IsExpired(token) Then
            Return False
        End If

        If Not Me.IsIssuerTrusted(token) Then
            Return False
        End If

        If Not Me.IsAudienceTrusted(token) Then
            Return False
        End If

        Return True
    End Function

    Public Function GetNameValues(token As String) As Dictionary(Of String, String)
        If String.IsNullOrEmpty(token) Then
            Throw New ArgumentException()
        End If

        Return token.Split("&"c).Aggregate(New Dictionary(Of String, String)(), Function(dict, rawNameValue)
                                                                                    If rawNameValue = String.Empty Then
                                                                                        Return dict
                                                                                    End If

                                                                                    Dim nameValue As String() = rawNameValue.Split("="c)

                                                                                    If nameValue.Length <> 2 Then
                                                                                        Throw New ArgumentException("Invalid formEncodedstring - contains a name/value pair missing an = character")
                                                                                    End If

                                                                                    If dict.ContainsKey(nameValue(0)) = True Then
                                                                                        Throw New ArgumentException("Repeated name/value pair in form")
                                                                                    End If

                                                                                    dict.Add(HttpUtility.UrlDecode(nameValue(0)), HttpUtility.UrlDecode(nameValue(1)))
                                                                                    Return dict

                                                                                End Function)
    End Function

    Private Shared Function GenerateTimeStamp() As ULong
        ' Default implementation of epoch time
        Dim ts As TimeSpan = DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0, 0)
        Return Convert.ToUInt64(ts.TotalSeconds)
    End Function

    Private Function IsAudienceTrusted(token As String) As Boolean
        Dim tokenValues As Dictionary(Of String, String) = Me.GetNameValues(token)

        Dim audienceValue As String

        tokenValues.TryGetValue(Me.audienceLabel, audienceValue)

        If Not String.IsNullOrEmpty(audienceValue) Then
            If audienceValue.Equals(Me.trustedAudienceValue, StringComparison.Ordinal) Then
                Return True
            End If
        End If

        Return False
    End Function

    Private Function IsIssuerTrusted(token As String) As Boolean
        Dim tokenValues As Dictionary(Of String, String) = Me.GetNameValues(token)

        Dim issuerName As String

        tokenValues.TryGetValue(Me.issuerLabel, issuerName)

        If Not String.IsNullOrEmpty(issuerName) Then
            If issuerName.Equals(Me.trustedTokenIssuer) Then
                Return True
            End If
        End If

        Return False
    End Function

    Private Function IsHMACValid(swt As String, sha256HMACKey As Byte()) As Boolean
        Dim swtWithSignature As String() = swt.Split(New String() {"&" & Me.hmacSHA256Label & "="}, StringSplitOptions.None)

        If (swtWithSignature Is Nothing) OrElse (swtWithSignature.Length <> 2) Then
            Return False
        End If

        Dim hmac As New HMACSHA256(sha256HMACKey)

        Dim locallyGeneratedSignatureInBytes As Byte() = hmac.ComputeHash(Encoding.ASCII.GetBytes(swtWithSignature(0)))

        Dim locallyGeneratedSignature As String = HttpUtility.UrlEncode(Convert.ToBase64String(locallyGeneratedSignatureInBytes))

        Return locallyGeneratedSignature = swtWithSignature(1)

    End Function

    Private Function IsExpired(swt As String) As Boolean
        Try
            Dim nameValues As Dictionary(Of String, String) = Me.GetNameValues(swt)
            Dim expiresOnValue As String = nameValues(Me.expiresLabel)
            Dim expiresOn As ULong = Convert.ToUInt64(expiresOnValue)
            Dim currentTime As ULong = Convert.ToUInt64(GenerateTimeStamp())

            If currentTime > expiresOn Then
                Return True
            End If

            Return False
        Catch generatedExceptionName As KeyNotFoundException
            Throw New ArgumentException()
        End Try
    End Function
End Class
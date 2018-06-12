Imports System.Web

Class SWTModule
    Implements IHttpModule
    ' USE CONFIGURATION FILE, WEB.CONFIG, TO MANAGE THIS DATA
    Dim serviceNamespace As String = "change to your namespace"
    Dim acsHostName As String = "accesscontrol.windows.net"
    Dim trustedTokenPolicyKey As String = "change to your signing key"
    ' Your web API realm
    Dim trustedAudience As String = "change to your realm"



    Private Sub IHttpModule_Dispose() Implements IHttpModule.Dispose

    End Sub

    Private Sub IHttpModule_Init(context As HttpApplication) Implements IHttpModule.Init
        AddHandler context.BeginRequest, AddressOf context_BeginRequest

    End Sub

    Private Sub context_BeginRequest(sender As Object, e As EventArgs)
        ' HANDLE SWT TOKEN VALIDATION
        ' get the authorization header
        Dim headerValue As String = HttpContext.Current.Request.Headers.[Get]("Authorization")

        ' check that a value is there
        If String.IsNullOrEmpty(headerValue) Then
            Throw New ApplicationException("unauthorized")
        End If

        ' check that it starts with 'WRAP'
        If Not headerValue.StartsWith("WRAP ") Then
            Throw New ApplicationException("unauthorized")
        End If

        Dim nameValuePair As String() = headerValue.Substring("WRAP ".Length).Split(New Char() {"="c}, 2)

        If nameValuePair.Length <> 2 OrElse nameValuePair(0) <> "access_token" OrElse Not nameValuePair(1).StartsWith("""") OrElse Not nameValuePair(1).EndsWith("""") Then
            Throw New ApplicationException("unauthorized")
        End If

        ' trim off the leading and trailing double-quotes
        Dim token As String = nameValuePair(1).Substring(1, nameValuePair(1).Length - 2)

        ' create a token validator
        Dim validator As New TokenValidator(Me.acsHostName, Me.serviceNamespace, Me.trustedAudience, Me.trustedTokenPolicyKey)

        ' validate the token
        If Not validator.Validate(token) Then
            Throw New ApplicationException("unauthorized")
        End If

    End Sub
End Class
Imports System.Web

Class SWTModule
    Implements IHttpModule
    'USE CONFIGURATION FILE, WEB.CONFIG, TO MANAGE THIS DATA
    Private serviceNamespace As String = "your namespace"
    'Access Control Namespaces
    Private acsHostName As String = "accesscontrol.windows.net"
    Private trustedTokenPolicyKey As String = "your signing key"
    'You generated this key in read me Running the Sample step 1.7.
    Private trustedAudience As String = "your realm"
    'In this example it should be http://localhost:12526/RESTUserService.svc

    Private Sub IHttpModule_Dispose() Implements IHttpModule.Dispose

    End Sub

    Private Sub IHttpModule_Init(context As HttpApplication) Implements IHttpModule.Init
        AddHandler context.BeginRequest, AddressOf context_BeginRequest

    End Sub

    Private Sub context_BeginRequest(sender As Object, e As EventArgs)
        ' HANDLE SWT TOKEN VALIDATION
        ' get the authorization header
        Dim headerValue As String = HttpContext.Current.Request.Headers.Get("Authorization")

        ' Check that a value is there
        If String.IsNullOrEmpty(headerValue) Then
            Throw New ApplicationException("unauthorized")
        End If

        ' Check that it starts with 'WRAP'
        If Not headerValue.StartsWith("WRAP ") Then
            Throw New ApplicationException("unauthorized")
        End If

        Dim nameValuePair As String() = headerValue.Substring("WRAP ".Length).Split(New Char() {"="c}, 2)

        If nameValuePair.Length <> 2 OrElse nameValuePair(0) <> "access_token" OrElse Not nameValuePair(1).StartsWith("\") OrElse Not nameValuePair(1).EndsWith("\") Then
            Throw New ApplicationException("unauthorized")
        End If

        ' Trim off the leading and trailing double-quotes
        Dim token As String = nameValuePair(1).Substring(1, nameValuePair(1).Length - 2)

        ' Create a token validator
        Dim validator As New TokenValidator(Me.acsHostName, Me.serviceNamespace, Me.trustedAudience, Me.trustedTokenPolicyKey)

        ' Validate the token
        If Not validator.Validate(token) Then
            Throw New ApplicationException("unauthorized")
        End If

    End Sub
End Class
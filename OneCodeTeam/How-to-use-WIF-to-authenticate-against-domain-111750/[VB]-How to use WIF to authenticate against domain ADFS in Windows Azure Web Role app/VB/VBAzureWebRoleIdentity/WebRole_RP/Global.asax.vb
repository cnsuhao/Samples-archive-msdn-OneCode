Imports System.Web.SessionState
Imports Microsoft.IdentityModel.Web.Configuration
Imports Microsoft.IdentityModel.Web
Imports Microsoft.IdentityModel.Tokens

Public Class Global_asax
    Inherits System.Web.HttpApplication
    ''' <summary>
    ''' Retrieves the address that was used in the browser for accessing 
    ''' the web application, and injects it as WREPLY parameter in the
    ''' request to the STS 
    ''' </summary>
    Private Sub WSFederationAuthenticationModule_RedirectingToIdentityProvider(sender As Object, e As RedirectingToIdentityProviderEventArgs)
        '
        ' In the Windows Azure environment, build a wreply parameter for  the SignIn request
        ' that reflects the real address of the application.
        '
        Dim request As HttpRequest = HttpContext.Current.Request
        Dim requestUrl As Uri = request.Url
        Dim wreply As New StringBuilder()
        wreply.Append(requestUrl.Scheme)
        ' e.g. "http" or "https"
        wreply.Append("://")
        wreply.Append(If(request.Headers("Host"), requestUrl.Authority))
        wreply.Append(request.ApplicationPath)
        If Not request.ApplicationPath.EndsWith("/") Then
            wreply.Append("/")
        End If
        e.SignInRequestMessage.Reply = wreply.ToString()
    End Sub

    Private Sub OnServiceConfigurationCreated(sender As Object, e As ServiceConfigurationCreatedEventArgs)
        '
        ' Use the <serviceCertificate> to protect the cookies that are
        ' sent to the client.
        '
        Dim sessionTransforms As New List(Of CookieTransform)(New CookieTransform() {New DeflateCookieTransform(), New RsaEncryptionCookieTransform(e.ServiceConfiguration.ServiceCertificate), New RsaSignatureCookieTransform(e.ServiceConfiguration.ServiceCertificate)})

        Dim sessionHandler As New SessionSecurityTokenHandler(sessionTransforms.AsReadOnly())
        e.ServiceConfiguration.SecurityTokenHandlers.AddOrReplace(sessionHandler)
    End Sub


    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
        AddHandler FederatedAuthentication.ServiceConfigurationCreated, AddressOf OnServiceConfigurationCreated
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class
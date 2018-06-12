Imports Microsoft.IdentityModel.Claims
Imports System.Threading

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim principal As IClaimsPrincipal = DirectCast(Thread.CurrentPrincipal, IClaimsPrincipal)
        Dim identity As IClaimsIdentity = TryCast(principal.Identity, IClaimsIdentity)

        Response.Write("Welcome to Windows Azure Web Role and WIF Sample!<br/><br/>Claims:<br/>")
        For Each c As Claim In identity.Claims
            Response.Write(c.ClaimType + " - " + c.Value & "<br/>")
        Next
    End Sub

End Class
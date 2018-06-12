Imports System.Threading

Public Class Content
    Inherits System.Web.UI.Page
    Public userName As String = String.Empty
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        userName = Thread.CurrentPrincipal.Identity.Name
    End Sub

End Class
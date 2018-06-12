Imports System.Web.SessionState
Imports System.IO

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_EndRequest(ByVal sender As Object, ByVal e As EventArgs)
        Try
            'Deleting once the zip file is flushed to the client.
            If HttpContext.Current.Response.Headers("TempfileName") IsNot Nothing Then
                Dim tempZipFilePath As String = HttpContext.Current.Response.Headers("TempfileName")
                File.Delete(tempZipFilePath)
            End If
            ' Add aditional code to log the deletion failure
        Catch
        Finally
            If HttpContext.Current.Response.Headers("TempfileName") IsNot Nothing Then
                HttpContext.Current.Response.Headers.Remove("TempfileName")
            End If
        End Try

    End Sub

End Class
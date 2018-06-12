Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.SessionState
Imports System.IO

Public Class Global_asax
    Inherits System.Web.HttpApplication

    ''' <summary>
    '''  Deleting the temp zip file. This will work only with IIS, so make sure you have IIS in the machine that is used to run this sample. i.e. use local IIS Web Server
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub Application_EndRequest(ByVal sender As Object, ByVal e As EventArgs)
        Try
            'Deleting once the zip file is flushed to the client.
            If HttpContext.Current.Response.Headers("TempfileName") IsNot Nothing Then
                Dim tempZipFilePath As String = HttpContext.Current.Response.Headers("TempfileName")
                File.Delete(tempZipFilePath)
                HttpContext.Current.Response.Headers.Remove("TempfileName")
            End If
            ' Add aditional code to log the deletion failure
        Catch
        End Try
    End Sub

End Class



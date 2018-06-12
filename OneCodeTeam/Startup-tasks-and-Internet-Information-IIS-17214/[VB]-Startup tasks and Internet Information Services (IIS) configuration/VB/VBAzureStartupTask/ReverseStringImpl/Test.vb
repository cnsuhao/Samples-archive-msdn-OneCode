Imports ReverseStringContract

Public Class TestWCFService
    Implements ITestWCFService

    Public Function ReverseString(s As String) As String Implements ITestWCFService.ReverseString
        Dim arr As Char() = s.ToCharArray()
        Array.Reverse(arr)

        Return New String(arr)
    End Function
End Class

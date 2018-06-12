Imports System
Imports System.Web
Imports System.Web.Services

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
<WebService([Namespace]:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<System.ComponentModel.ToolboxItem(False)> _
<System.Web.Script.Services.ScriptService()> _
Public Class WebService1
    Inherits System.Web.Services.WebService
    <WebMethod()> _
    Public Function Choose(ByVal str As String) As String
        Dim book As String = ""
        If str = "" Then
            book = "You have no choice or do not like book"
        Else
            book = "Your favorite book is:" & str & " <input id=""btBuy"" type=""button"" value=""Buy"" onclick=""return ShowBuy()"" />"
        End If
        Return book
    End Function
End Class


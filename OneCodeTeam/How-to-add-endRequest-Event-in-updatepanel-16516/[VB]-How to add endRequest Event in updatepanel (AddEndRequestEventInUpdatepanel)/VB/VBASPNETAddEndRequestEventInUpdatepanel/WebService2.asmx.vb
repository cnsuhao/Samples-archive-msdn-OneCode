Imports System
Imports System.Web
Imports System.Web.Services

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
<WebService([Namespace]:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<System.ComponentModel.ToolboxItem(False)> _
<System.Web.Script.Services.ScriptService()> _
Public Class WebService2
    Inherits System.Web.Services.WebService
    <WebMethod()> _
    Public Function oMoney(ByVal sNum As String, ByVal sPrice As String) As String
        Dim iNum As Integer = Integer.Parse(sNum)
        Dim dPrice As Double = Double.Parse(sPrice)
        Dim str As String = ""
        Dim dSum As Double = 0
        If (iNum <= 0) OrElse (dPrice <= 0) Then
            str = "You do not plan to buy book"
        Else
            dSum = iNum * dPrice
            str = "You should pay RMB:￥" & dSum
        End If
        Return str
    End Function
End Class

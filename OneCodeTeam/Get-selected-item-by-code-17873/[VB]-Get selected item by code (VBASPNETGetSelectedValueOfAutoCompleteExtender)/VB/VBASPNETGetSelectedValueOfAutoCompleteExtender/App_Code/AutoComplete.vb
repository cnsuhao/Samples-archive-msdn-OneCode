'****************************** Module Header ******************************\
' Module Name:    AutoComplete.vb
' Project:        VBASPNETGetSelectedValueOfAutoCompleteExtender
' Copyright (c) Microsoft Corporation
'
' This WebService is used to search for movies under the conditions
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Imports System.Collections
Imports System.Configuration
Imports System.Data
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Script.Services.ScriptService()> _
Public Class AutoComplete
    Inherits System.Web.Services.WebService

    Private _movies As New List(Of String)()

    Public Sub New()
        _movies.Add("a1")
        _movies.Add("a2")
        _movies.Add("b1")
        _movies.Add("China")
        _movies.Add("c21")
        _movies.Add("Dead")
        _movies.Add("Dear")
        _movies.Add("Dream")
        _movies.Add("Empty")
        _movies.Add("Egg")
        _movies.Add("Flower")
        _movies.Add("Floor")
        _movies.Add("Great")
        _movies.Add("g")
        _movies.Add("h1")
        _movies.Add("h2")
        _movies.Add("i1")
        _movies.Add("jeep")
        _movies.Add("k")
        _movies.Add("Loop")
        _movies.Add("Man")
        _movies.Add("Nice")
        _movies.Add("O1")
        _movies.Add("Pear")
        _movies.Add("Queen")
        _movies.Add("Rest")
        _movies.Add("S1")
        _movies.Add("S2")
        _movies.Add("T1 ")
        _movies.Add("T2 ")
        _movies.Add("US")
        _movies.Add("UK")
        _movies.Add("V")
        _movies.Add("W")
        _movies.Add("X")
        _movies.Add("Y")
        _movies.Add("Z")
    End Sub

    <WebMethod()> _
    Public Function GetMovies(ByVal prefixText As String, ByVal count As Integer) As String()
        If count = 0 Then
            count = 10
        End If

        Dim matches = (From m In _movies Where (m.StartsWith(prefixText, StringComparison.CurrentCultureIgnoreCase)) Select m).Take(count)
        Return matches.ToArray()
    End Function
End Class




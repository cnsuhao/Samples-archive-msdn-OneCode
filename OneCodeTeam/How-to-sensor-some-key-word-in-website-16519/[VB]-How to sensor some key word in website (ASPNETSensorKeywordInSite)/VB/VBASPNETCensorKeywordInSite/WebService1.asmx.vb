'****************************** Module Header ******************************\
' Module Name:  WebService1.asmx.vb
' Project:      VBASPNETCensorKeywordInSite
' Copyright (c) Microsoft Corporation
'
' This is the Web Service
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/

Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data.SqlClient

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WebService1
    Inherits System.Web.Services.WebService

    'Sql Connection
    Private Shared conn As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Sample.mdf;Integrated Security=True;User Instance=True")

    <WebMethod()> _
    Public Function LoadScript() As String
        ' Add your operation implementation here
        Dim input As String = ""

        'Query string
        Dim queryString As String = "SELECT [Name] FROM [WordBlack]"
        'set query string
        Dim command As New SqlCommand(queryString, conn)
        'Open connection
        conn.Open()
        Dim reader As SqlDataReader = command.ExecuteReader()

        If reader.HasRows Then
            While reader.Read()
                input += "|" & TryCast(reader("Name"), String).Trim()
            End While
            input = input.Substring(1)
        End If
        reader.Close()
        'Close connection
        conn.Close()
        Return input
    End Function

End Class
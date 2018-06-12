'****************************** Module Header ******************************\
' Module Name:    Default.aspx.vb
' Project:        VBASPNETInParameterOfSql
' Copyright (c) Microsoft Corporation
'
' This sample code will demonstrate how to set value to “IN Parameter” of SqlDataSource
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    ''' <summary>
    ''' set the id dynamically
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnDynamicShow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDynamicShow.Click
        ' list of selected id
        Dim IDList As New List(Of String)()

        For Each li As ListItem In CheckBoxList1.Items
            If li.Selected Then
                IDList.Add(li.Value)
            End If
        Next

        SqlDataSource1.SelectCommand = [String].Format("SELECT [Id], [Name] FROM [Test] WHERE ([Id] IN ({0}))", [String].Join(", ", IDList.ToArray()))

    End Sub

    ''' <summary>
    ''' Static id
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnStaticShow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnStaticShow.Click

        'Static id
        Dim s As String = "1,2,3,4,5"
        Dim strings As String() = s.Split(","c)

        SqlDataSource1.SelectCommand = [String].Format("SELECT [Id], [Name] FROM [Test] WHERE ([Id] IN ({0}))", [String].Join(", ", strings.ToArray()))
    End Sub
End Class
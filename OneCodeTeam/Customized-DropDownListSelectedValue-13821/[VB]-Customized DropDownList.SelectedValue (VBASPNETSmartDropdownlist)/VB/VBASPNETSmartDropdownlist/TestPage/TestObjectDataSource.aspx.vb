'**************************** Module Header ******************************\
' Module Name: TestObjectDataSource.aspx.vb
' Project:     TestPage
' Copyright (c) Microsoft Corporation
'
' The "SelectedValue" is a value from DropDownList that will be saved into the
' field bound to the data table. However, if the field value does not belong 
' to any element of the collection of the DropDownList itself, it will throw 
' an ArguementOutOfRangeException exception. This sample creates a customized 
' DropDownList that will fix this problem. 
' 
' The TestDropDownList page will load an XML file as data source of GridView and
' customized DropDownList. The data source is SqlDataSource.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************/




Public Class TestObjectDataSource
    Inherits System.Web.UI.Page
    ''' <summary>
    ''' Normal data source
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Load the xml file and convert it to DataTable variable.
            Dim xmlDoc As XDocument = XDocument.Load(Server.MapPath("~/Data.xml"))
            Dim results = From result In xmlDoc.Element("Root").Elements()
                          Select result
            Dim tabXml As New DataTable()
            tabXml.Columns.Add("ID", Type.[GetType]("System.Int32"))
            tabXml.Columns.Add("Name", Type.[GetType]("System.String"))
            tabXml.Columns.Add("Age", Type.[GetType]("System.Int32"))
            tabXml.Columns.Add("Telephone", Type.[GetType]("System.String"))
            tabXml.Columns.Add("Comment", Type.[GetType]("System.String"))
            Dim row As DataRow = tabXml.NewRow()
            row("ID") = 0
            row("Name") = "None"
            row("Age") = 0
            row("Telephone") = "None"
            row("Comment") = "None"
            tabXml.Rows.Add(row)
            For Each result As Object In results
                Dim tabRow As DataRow = tabXml.NewRow()
                tabRow("ID") = Convert.ToInt32(result.Element("ID").Value)
                tabRow("Name") = result.Element("Name").Value
                tabRow("Age") = Convert.ToInt32(result.Element("Age").Value)
                tabRow("Telephone") = result.Element("Telephone").Value
                tabRow("Comment") = result.Element("Comment").Value
                tabXml.Rows.Add(tabRow)
            Next

            ' Customized DropDownList control data binding by DataTable.
            customizedDropDownList.DataSource = tabXml.AsDataView()
            customizedDropDownList.DataTextField = "Name"
            customizedDropDownList.DataValueField = "ID"
            customizedDropDownList.DataBind()
            customizedDropDownList.SelectedValue = "13"

            ' GridView control data binding by DataTable.
            Dim rowGridView As DataRow = tabXml.NewRow()
            rowGridView("ID") = 1000
            rowGridView("Name") = "Ann Anna"
            rowGridView("Age") = 21
            rowGridView("Telephone") = "111111"
            rowGridView("Comment") = "None"
            tabXml.Rows.Add(rowGridView)
            Dim rowGridView2 As DataRow = tabXml.NewRow()
            rowGridView2("ID") = 1001
            rowGridView2("Name") = "Bill Brand"
            rowGridView2("Age") = 41
            rowGridView2("Telephone") = "111112"
            rowGridView2("Comment") = "None"
            tabXml.Rows.Add(rowGridView2)
            tabXml.Rows.Remove(row)
            gvwDropDownListSource.DataSource = tabXml
            gvwDropDownListSource.DataBind()
        End If

    End Sub

    Protected Sub gvwDropDownListSource_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvwDropDownListSource.RowCommand
        If e.CommandName = "Select" Then
            Dim rowIndex As Integer
            Dim convertFlag As Boolean = Integer.TryParse(e.CommandArgument.ToString(), rowIndex)
            If convertFlag Then
                customizedDropDownList.SelectedValue = gvwDropDownListSource.Rows(rowIndex).Cells(0).Text
            Else
                Response.Write("The row index is not correct.")
            End If
        End If

    End Sub
End Class
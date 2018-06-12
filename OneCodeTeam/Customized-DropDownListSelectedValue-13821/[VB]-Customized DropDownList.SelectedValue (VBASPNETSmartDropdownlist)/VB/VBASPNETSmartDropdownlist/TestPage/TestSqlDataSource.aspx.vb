'**************************** Module Header ******************************\
' Module Name: TestSqlDataSource.aspx.vb
' Project:     TestPage
' Copyright (c) Microsoft Corporation
'
' The "SelectedValue" is a value from DropDownList that will be saved into the
' field bound to the data table. However, if the field value does not belong 
' to any element of the collection of the DropDownList itself, it will throw 
' an ArguementOutOfRangeException exception. This sample creates a customized 
' DropDownList that will fix this problem. 
' 
' The TestDropDownList2 page will load an XML file as data source of GridView and
' customized DropDownList. The data source is ObjectDataSource.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************/




Public Class TestSqlDataSource
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Load Xml file and convert it to List<T> variable.
        If Not IsPostBack Then
            Dim xmlDoc As XDocument = XDocument.Load(Server.MapPath("~/Data.xml"))
            Dim entities As List(Of DataEntity) = (From result In xmlDoc.Descendants("Person")
                                                   Select New DataEntity() With { _
             .ID = Convert.ToInt32(result.Element("ID").Value), _
             .Name = result.Element("Name").Value, _
             .Age = Convert.ToInt32(result.Element("Age").Value), _
             .Telephone = result.Element("Telephone").Value, _
             .Comment = result.Element("Comment").Value _
            }).ToList()

            ' Customized DropDownList control data binding by IEnumberable.
            customizedDropDownList.DataSource = TryCast(entities, IEnumerable(Of DataEntity))
            customizedDropDownList.DataTextField = "Name"
            customizedDropDownList.DataValueField = "ID"
            customizedDropDownList.DataBind()
            customizedDropDownList.Items.Insert(0, New ListItem("None", "0"))
            customizedDropDownList.SelectedValue = "12"

            ' GridView control data binding by IEnumberable.
            Dim list As List(Of DataEntity) = TryCast(entities, List(Of DataEntity))
            Dim entitySingle As New DataEntity()
            entitySingle.ID = 1000
            entitySingle.Name = "Ann Anna"
            entitySingle.Age = 21
            entitySingle.Telephone = "111111"
            entitySingle.Comment = "None"
            list.Add(entitySingle)
            Dim entitySingle2 As New DataEntity()
            entitySingle2.ID = 1001
            entitySingle2.Name = "Bill Brand"
            entitySingle2.Age = 41
            entitySingle2.Telephone = "111112"
            entitySingle2.Comment = "None"
            list.Add(entitySingle2)

            gvwDropDownListSource.DataSource = TryCast(entities, IEnumerable(Of DataEntity))
            gvwDropDownListSource.DataBind()
        End If

    End Sub

    Protected Sub gvwDropDownListSource_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvwDropDownListSource.RowCommand
        If e.CommandName = "Select" Then
            Dim rowIndex As Integer
            Dim convertFlag As Boolean = Integer.TryParse(e.CommandArgument.ToString(), rowIndex)
            If convertFlag Then
                Dim num As Integer = gvwDropDownListSource.Rows.Count
                customizedDropDownList.SelectedValue = gvwDropDownListSource.Rows(rowIndex).Cells(0).Text
            Else
                Response.Write("The row index is not correct.")
            End If
        End If

    End Sub
End Class
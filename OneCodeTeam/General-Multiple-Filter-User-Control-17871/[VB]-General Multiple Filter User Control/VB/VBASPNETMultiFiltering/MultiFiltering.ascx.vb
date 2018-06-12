'***************************** Module Header ******************************\
' Module Name:    MultiFiltering.ascx.vb
' Project:        VBASPNETMultiFiltering
' Copyright (c) Microsoft Corporation
'
' This is a user-based control that is used to do a filtering with SqlDataSource.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************/
Imports System.ComponentModel


Partial Public Class MultiFiltering
    Inherits System.Web.UI.UserControl

    ''' <summary>
    ''' Handling an event when loading
    ''' </summary>
    Public Sub New()
        AddHandler Me.GetSqlDatasourceEvent, New Action(Of SqlDataSource)(AddressOf MultiFiltering_GetSqlDatasourceEvent)
    End Sub

    ''' <summary>
    ''' The DataSource gotten from outside
    ''' </summary>
    Private source As SqlDataSource = Nothing

    ''' <summary>
    ''' This will save the DataTable for futher columns'mapping
    ''' </summary>
    Private Property TableColumnsMapping() As DataTable
        Get
            Return TryCast(ViewState("columns"), DataTable)
        End Get
        Set(value As DataTable)

            ViewState("columns") = value
        End Set
    End Property

    ''' <summary>
    ''' This event happens when you set a SqlDataSourceId
    ''' </summary>
    Private Event GetSqlDatasourceEvent As Action(Of SqlDataSource)

    ''' <summary>
    ''' This property is used to store filtering records
    ''' </summary>
    Private Property FilteringData() As List(Of [Structure])
        Get
            Return TryCast(ViewState("Data"), List(Of [Structure]))
        End Get
        Set(value As List(Of [Structure]))
            ViewState("Data") = value
        End Set
    End Property

    ''' <summary>
    ''' Keep the FilterExpression for paging
    ''' </summary>
    Public Property FilterExpression() As String
        Get
            Return If(ViewState("filterexp") Is Nothing, " ", ViewState("filterexp").ToString())
        End Get
        Set(value As String)
            ViewState("filterexp") = value
        End Set
    End Property

    ''' <summary>
    ''' This is a public property for you to set
    ''' a SqlDataSourceId to the control. This property
    ''' can only support set.
    ''' </summary>
    <Browsable(True)> _
    <Category("Data")> _
    <Description("A SqlDataSourceId on the page")> _
    Public Property BindingSqlDataSourceId() As String
        ' Here you don't need to see what you've assigned
        ' So set it private
        Private Get
            Return ViewState("SqlId").ToString()
        End Get
        Set(value As String)
            If String.IsNullOrEmpty(value) Then
                Throw New Exception("BindingSqlId cannot be null!")
            Else
                source = TryCast(Page.FindControl(value), SqlDataSource)
                If source Is Nothing Then
                    Throw New Exception("Cannot find a SqlDataSource named: " & value)
                Else
                    ' If SqlDataSourceID isn't the same as before,re-analyse it.
                    If Not value.Equals(ViewState("SqlId")) Then
                        ViewState("SqlId") = value
                        RaiseEvent GetSqlDatasourceEvent(source)
                    End If
                End If
            End If
        End Set
    End Property

    ''' <summary>
    ''' When column name changes, it will detect the type and cascade to dropdown other dropdownlists
    ''' </summary>
    Protected Sub ddrColumnNames_SelectedIndexChanged(sender As Object, e As EventArgs)
        'When a column's name changed, set proper operation
        Dim ddrColumnName As DropDownList = DirectCast(sender, DropDownList)
        Dim item As RepeaterItem = DirectCast(ddrColumnName.NamingContainer, RepeaterItem)
        AllColumns = TableColumnsMapping
        FilteringData(item.ItemIndex).ColumnIndex = ddrColumnName.SelectedIndex
        FilteringData(item.ItemIndex).OperationIndex = TryCast(item.FindControl("ddrOperation"), DropDownList).SelectedIndex
        FilteringData(item.ItemIndex).RelationIndex = TryCast(item.FindControl("ddrRelation"), DropDownList).SelectedIndex
        FilteringData(item.ItemIndex) = SetSpecificFieldType(FilteringData(item.ItemIndex))
        Repeater1.DataSource = FilteringData
        Repeater1.DataBind()
        AutoShow()
    End Sub


    ''' <summary>
    ''' This event result will analyse the SqlDataSource, and
    ''' use its FilterExpression
    ''' </summary>
    Private Sub MultiFiltering_GetSqlDatasourceEvent(result As SqlDataSource)
        Dim dt As DataTable = Nothing
        dt = TryCast(result.[Select](DataSourceSelectArguments.Empty), DataView).Table
        dt.Clear()
        TableColumnsMapping = dt
        AllColumns = TableColumnsMapping
        FilteringData = AddStruct(FilteringData)
        Repeater1.DataSource = FilteringData
        Repeater1.DataBind()
    End Sub

    ''' <summary>
    ''' When clicking the Remove button, remove the current filter record and rebind.
    ''' </summary>
    Protected Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        If e.CommandName = "Remove" Then
            If FilteringData.Count > 1 Then
                Dim c As Control = TryCast(e.CommandSource, Control)
                Dim index As Integer = TryCast(c.NamingContainer, RepeaterItem).ItemIndex
                AutoBind()
                FilteringData.RemoveAt(index)
                Repeater1.DataSource = FilteringData
                Repeater1.DataBind()
                AutoShow()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Add a new filter record
    ''' </summary>
    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        AutoBind()
        FilteringData = AddStruct(FilteringData)
        Repeater1.DataSource = FilteringData
        Repeater1.DataBind()
        AutoShow()
    End Sub

    ''' <summary>
    ''' This method is binding data contents, it's called when any data contents are changed.
    ''' </summary>
    Private Sub AutoBind()
        Dim ddrColumn As DropDownList = Nothing
        Dim ddrOperation As DropDownList = Nothing
        Dim ddrRelation As DropDownList = Nothing

        For i As Integer = 0 To Repeater1.Items.Count - 1

            ddrColumn = TryCast(Repeater1.Items(i).FindControl("ddrFields"), DropDownList)
            ddrOperation = TryCast(Repeater1.Items(i).FindControl("ddrOperation"), DropDownList)
            ddrRelation = TryCast(Repeater1.Items(i).FindControl("ddrRelation"), DropDownList)

            FilteringData(i).EqualValue = TryCast(Repeater1.Items(i).FindControl("txtBox"), TextBox).Text
            FilteringData(i).ColumnIndex = ddrColumn.SelectedIndex
            FilteringData(i).RelationIndex = ddrRelation.SelectedIndex

            FilteringData(i).OperationIndex = ddrOperation.SelectedIndex
        Next
    End Sub

    ''' <summary>
    ''' This will retrieve all the data contents onto the UI.
    ''' </summary>
    Private Sub AutoShow()
        Dim ddrColumn As DropDownList = Nothing
        Dim ddrOperation As DropDownList = Nothing
        Dim ddrRelation As DropDownList = Nothing

        For i As Integer = 0 To Repeater1.Items.Count - 1
            ddrColumn = TryCast(Repeater1.Items(i).FindControl("ddrFields"), DropDownList)
            ddrOperation = TryCast(Repeater1.Items(i).FindControl("ddrOperation"), DropDownList)
            ddrRelation = TryCast(Repeater1.Items(i).FindControl("ddrRelation"), DropDownList)

            ddrColumn.SelectedIndex = FilteringData(i).ColumnIndex
            ddrOperation.SelectedIndex = FilteringData(i).OperationIndex
            ddrRelation.SelectedIndex = FilteringData(i).RelationIndex
        Next
    End Sub

    ''' <summary>
    ''' When the button is clicked, generate a complete filtering statement and do filtering.
    ''' </summary>
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim datasource As SqlDataSource = DirectCast(Page.FindControl(BindingSqlDataSourceId), SqlDataSource)

        AutoBind()


        ' Show All
        If chkAll.Checked Then
            FilterExpression = " "
            datasource.FilterExpression = FilterExpression
        Else
            ' Loop the FilterData to get the values
            Dim sbu As New StringBuilder()
            Dim s As String = Nothing

            For i As Integer = 0 To FilteringData.Count - 1
                Dim tempop As String = FilteringData(i).Operations(FilteringData(i).OperationIndex)
                Dim columnname As String = FilteringData(i).ColumnNames(FilteringData(i).ColumnIndex)

                s = "'" + FilteringData(i).EqualValue & "')"

                If tempop.Equals("Like") Then
                    s = "'%" + FilteringData(i).EqualValue & "%')"
                ElseIf FilteringData(i).DataType Is GetType(DateTime) Then
                    ' DateTime has milliseconds, so "=" means between 00:00:00 and 23:59:59

                    If tempop.Equals("=") Then
                        Dim ts As String = FilteringData(i).EqualValue + " 00:00:00"
                        Dim ts2 As String = FilteringData(i).EqualValue + " 23:59:59"
                        tempop = ">="
                        s = "'" & ts & "' and " & columnname & "<='" & ts2 & "')"

                        ' "<>" means not between 00:00:00 and 23:59:59
                    ElseIf tempop.Equals("<>") Then
                        Dim ts As String = FilteringData(i).EqualValue + " 00:00:00"
                        Dim ts2 As String = FilteringData(i).EqualValue + " 23:59:59"
                        tempop = "<"
                        s = "'" & ts & "' or " & columnname & ">'" & ts2 & "')"
                    ElseIf tempop.Equals(">") Then
                        s = "'" + FilteringData(i).EqualValue & " 23:59:59')"

                        ' ">=" means combining the two together
                    ElseIf tempop.Equals(">=") Then
                        Dim ts As String = FilteringData(i).EqualValue + " 00:00:00"
                        Dim ts2 As String = FilteringData(i).EqualValue + " 23:59:59"
                        tempop = ">="
                        s = "'" & ts & "' and " & columnname & "<='" & ts2 & "' or " & columnname & " >'" & ts2 & "')"
                    ElseIf tempop.Equals("<") Then
                        s = "'" + FilteringData(i).EqualValue & " 00:00:00')"
                    ElseIf tempop.Equals("<=") Then
                        Dim ts As String = FilteringData(i).EqualValue + " 00:00:00"
                        Dim ts2 As String = FilteringData(i).EqualValue + " 23:59:59"
                        tempop = ">="
                        s = "'" & ts & "' and " & columnname & "<='" & ts2 & "' or " & columnname & " <'" & ts2 & "')"
                    End If
                End If

                sbu.Append(("(" + FilteringData(i).ColumnNames(FilteringData(i).ColumnIndex) & " " & tempop & " " & s) + FilteringData(i).Relations(FilteringData(i).RelationIndex))
            Next

            ' Remove the last relation symbol "And" or "Or"
            s = sbu.ToString().Substring(sbu.ToString().LastIndexOf(")"c) + 1)
            sbu = sbu.Remove(sbu.ToString().LastIndexOf(s), s.Length)

            Try
                ' Use this to check whether it will raise an error
                TryCast(datasource.[Select](DataSourceSelectArguments.Empty), DataView).RowFilter = sbu.ToString()
                datasource.FilterExpression = sbu.ToString()
                FilterExpression = datasource.FilterExpression
                lbError.Text = ""
            Catch
                lbError.Text = "Please check whether your value fits the type."
            Finally
                sbu = Nothing
            End Try
        End If
    End Sub

End Class
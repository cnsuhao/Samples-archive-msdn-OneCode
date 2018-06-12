'******************************** Module Header **********************************\
' Module Name:	EmployeeList.vb
' Project:		VBEFDeepCloneObject
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to implement deep clone/duplicate entity objects using 
' serialization and reflection.
' This module is used to show the list of the employees and the related objects.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*********************************************************************************/

Namespace VBEFDeepCloneObject

    Public Class EmployeeList

#Region "Constructors"

        Public Sub New()
            InitializeComponent()
        End Sub

#End Region

#Region "Public Function"

        ''' <summary>
        ''' Refresh the gridviews when the db's records has been changed.
        ''' </summary>
        Public Sub RefreshData()
            BindDataSource()
        End Sub

#End Region

#Region "Form Event"

        Private Sub EmployeeList_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            BindDataSource()
            AddHandler employeeGridView.SelectionChanged, AddressOf empSelection_Changed
        End Sub

#End Region

#Region "GridView Event"

        ''' <summary>
        ''' Select the related records in the address, bascic sales and detail sales 
        ''' when the selected item in the employee grid view changed.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Public Sub empSelection_Changed(ByVal sender As Object, ByVal e As EventArgs) Handles employeeGridView.SelectionChanged
            If employeeGridView.Rows.Count > 0 AndAlso employeeGridView.SelectedRows.Count > 0 Then
                Dim emp As DataGridViewRow = employeeGridView.SelectedRows(0)
                ClearGridViewSelection()

                SelectRows(empAddressGridView, emp.Cells(0).Value.ToString())

                SelectRows(bsInfoGridView, emp.Cells(0).Value.ToString())

                If bsInfoGridView.SelectedRows.Count <> 0 Then
                    SelectRows(dsInfoGridView, bsInfoGridView.SelectedRows(0).Cells(1).Value.ToString())

                End If
            End If

        End Sub

#End Region

#Region "Button Event"

        ''' <summary>
        ''' Show the Create Employee form.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub btnCreate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCreate.Click
            ShowNextForm(Config.EmpDetailsForm)
        End Sub

        ''' <summary>
        ''' Show the Sales information form.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub btnSales_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSales.Click
            ShowNextForm(Config.BsInfoForm)
        End Sub

        ''' <summary>
        ''' Clone the selected employee and related child object.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub btnClone_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClone.Click
            Dim currentEmpId As Integer = Convert.ToInt32(employeeGridView.SelectedRows(0).Cells(0).Value)

            Dim emp = (From a In Config.Context.Employees Where a.EmpId = currentEmpId Select a).FirstOrDefault()

            Dim empNew = emp.Clone()

            empNew.ClearEntityReference(True)

            Config.Context.AddToEmployees(empNew)
            Config.Context.SaveChanges()

            RefreshData()

            employeeGridView.ClearSelection()
            SelectRows(employeeGridView, (From a In Config.Context.Employees Select a.EmpId).Max().ToString())
        End Sub

#End Region

#Region "Private Function"

        ''' <summary>
        ''' Bind data to the gridview when the form was loaded or show again.
        ''' </summary>
        Private Sub BindDataSource()
            Dim emps = (From a In Config.Context.Employees Select New With { _
                a.EmpId, _
                a.FirstName, _
                a.LastName, _
                a.Age, _
                a.Sex _
            })

            Dim empAddress = (From a In Config.Context.EmpAddresses Select New With { _
                a.EmpId, _
                a.AddressLine, _
                a.City, _
                a.State _
            })

            Dim bsSalesInfo = (From a In Config.Context.BasicSalesInfoes Select New With { _
                a.EmpId, _
                a.SalInfoId, _
                a.Total _
            })

            Dim dsSalesInfo = (From a In Config.Context.DetailSalesInfoes Select New With { _
                a.BasicSalInfoId, _
                a.Sale, _
                a.Year.Value.Year _
            })

            employeeGridView.DataSource = emps
            empAddressGridView.DataSource = empAddress
            bsInfoGridView.DataSource = bsSalesInfo
            dsInfoGridView.DataSource = dsSalesInfo

        End Sub

        ''' <summary>
        ''' Clear the selection of the gridview.
        ''' </summary>
        Private Sub ClearGridViewSelection()
            empAddressGridView.ClearSelection()
            bsInfoGridView.ClearSelection()
            dsInfoGridView.ClearSelection()
        End Sub

        ''' <summary>
        ''' Select the related item accord the selected employee id.
        ''' </summary>
        ''' <param name="gridview"></param>
        ''' <param name="selectedId"></param>
        Private Sub SelectRows(ByVal gridview As DataGridView, ByVal selectedId As String)
            If gridview Is Nothing OrElse String.IsNullOrEmpty(selectedId) Then
                MessageBox.Show(My.Resources.Msg)
            End If
            For Each selectedRow As DataGridViewRow In gridview.Rows
                If selectedRow.Cells(0).Value.ToString().Equals(selectedId, StringComparison.OrdinalIgnoreCase) Then
                    selectedRow.Selected = True
                End If
            Next
        End Sub

        Private Sub ShowNextForm(ByVal from As Form)
            from.ShowDialog()
        End Sub

#End Region

    End Class

End Namespace
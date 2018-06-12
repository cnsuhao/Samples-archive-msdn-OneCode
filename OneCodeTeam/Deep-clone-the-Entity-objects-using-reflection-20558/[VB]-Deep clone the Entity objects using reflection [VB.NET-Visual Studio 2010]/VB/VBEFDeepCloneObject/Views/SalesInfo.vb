'******************************** Module Header **********************************\
' Module Name:	SalesInfo.vb
' Project:		VBEFDeepCloneObject
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to implement deep clone/duplicate entity objects 
' using serialization and reflection.
' This module is used to show the detail information of the sales.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*********************************************************************************/

Imports System.ComponentModel
Imports System.Text.RegularExpressions

Namespace VBEFDeepCloneObject

    Public Class SalesInfo

#Region "Constructors"

        Public Sub New()
            InitializeComponent()
        End Sub

#End Region

#Region "Event"

        Private Sub SalesInfo_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            Dim empIds As IQueryable(Of Integer) = From a In Config.Context.Employees Select a.EmpId
            cbxEmpId.DataSource = empIds
            cbxYear.DataSource = Config.Years
        End Sub

        ''' <summary>
        ''' Save the sales information
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
            If Config.ValidateTextBox(Me) Then
                Dim empId As Integer = Convert.ToInt32(cbxEmpId.Text)
                Dim basicSalesInfo As BasicSalesInfo = (From a In Config.Context.BasicSalesInfoes Where a.EmpId = empId Select a).FirstOrDefault()

                ' If the basicSalesInfo has exist then add the sales 
                ' to the total of the basicSalesInfo. If not add a new 
                ' record to the basicSalesInfo.
                If basicSalesInfo Is Nothing Then
                    Dim bsInfo = New BasicSalesInfo() With { _
                     .EmpId = empId, _
                     .Total = Convert.ToDouble(tbxSales.Text) _
                    }

                    Config.Context.AddToBasicSalesInfoes(bsInfo)
                    Config.Context.SaveChanges()

                    Dim bsInfoId As Integer = (From a In Config.Context.BasicSalesInfoes Select a.SalInfoId).Max()
                    AddDetailSalsInfo(bsInfoId)
                Else
                    basicSalesInfo.Total += Convert.ToDouble(tbxSales.Text)
                    AddDetailSalsInfo(basicSalesInfo.SalInfoId)
                End If

                Hide()
                Config.EmpListForm.RefreshData()
            End If
        End Sub

        ''' <summary>
        ''' Ensure that the sales must be decimal and can't be null.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub tbxSales_Validating(ByVal sender As Object, ByVal e As CancelEventArgs) Handles tbxSales.Validating
            If Not Regex.IsMatch(tbxSales.Text, "^(([0-9]+/.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*/.[0-9]+)|([0-9]*[1-9][0-9]*))$") OrElse tbxSales.Text.Trim().Equals("") Then
                e.Cancel = True
                tbxSales.[Select](0, tbxSales.Text.Length)
                errorProvider.SetError(tbxSales, My.Resources.SalesMsg)
            End If
        End Sub

        ''' <summary>
        ''' Clear the error provider information.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub tbxSales_Validated(ByVal sender As Object, ByVal e As EventArgs) Handles tbxSales.Validated
            errorProvider.SetError(tbxSales, "")
        End Sub

#End Region

#Region "Private Function"

        ''' <summary>
        ''' Save the detail sales information to database.
        ''' </summary>
        ''' <param name="bsInfoId">The basic sales id of the saving item </param>
        Private Sub AddDetailSalsInfo(ByVal bsInfoId As Integer)
            Dim dsInfo = New DetailSalesInfo() With { _
             .BasicSalInfoId = bsInfoId, _
             .Sale = Convert.ToDouble(tbxSales.Text), _
             .Year = Convert.ToDateTime(String.Format("1/1/{0}", cbxYear.Text)) _
            }

            Config.Context.AddToDetailSalesInfoes(dsInfo)
            Config.Context.SaveChanges()
        End Sub

#End Region

    End Class

End Namespace
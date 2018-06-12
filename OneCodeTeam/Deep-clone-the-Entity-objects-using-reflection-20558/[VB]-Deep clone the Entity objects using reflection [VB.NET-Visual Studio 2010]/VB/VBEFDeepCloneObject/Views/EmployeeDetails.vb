'******************************** Module Header **********************************\
' Module Name:	EmployeeDetails.vb
' Project:		VBEFDeepCloneObject
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to implement deep clone/duplicate entity objects 
' using serialization and reflection.
' This module is used to show the detail information of the employee.
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

    Public Class EmployeeDetails

#Region "Consturctors"

        Public Sub New()
            InitializeComponent()
        End Sub

#End Region

#Region "Events"

        ''' <summary>
        ''' Save all the employee related information when click the save button.
        ''' First save the employee basic information 
        ''' then save the ralated address information.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
            If Config.ValidateTextBox(Me) Then
                SaveEmployee()
                SaveEmpAddress()

                Hide()
                Config.EmpListForm.RefreshData()
            End If
        End Sub

        ''' <summary>
        ''' Ensure that the age is numberic and can't be null.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub tbxAge_Validating(ByVal sender As Object, ByVal e As CancelEventArgs) Handles tbxAge.Validating
            Dim isValid As Boolean = True

            If Not Regex.IsMatch(tbxAge.Text, "^\+?[1-9][0-9]*$") Then
                isValid = False
            Else
                Dim age As Integer = Convert.ToInt32(tbxAge.Text)
                If Not (age > 0 AndAlso age < 100) Then
                    isValid = False
                End If
            End If

            If Not isValid Then
                e.Cancel = True
                tbxAge.[Select](0, tbxAge.Text.Length)
                errorProvider.SetError(tbxAge, My.Resources.AgeMsg)
            End If

        End Sub

        ''' <summary>
        ''' Clear the error provider information.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub tbxAge_Validated(ByVal sender As Object, ByVal e As EventArgs) Handles tbxAge.Validated
            errorProvider.SetError(tbxAge, "")
        End Sub

#End Region

#Region "Private Function"

        ''' <summary>
        ''' Save the new employee information to the database.
        ''' </summary>
        Private Sub SaveEmployee()
            Dim emp = New Employee() With { _
             .FirstName = tbxFirstName.Text, _
             .LastName = tbxLastName.Text, _
             .Age = Convert.ToDouble(tbxAge.Text), _
             .Sex = cbxSex.Text _
            }

            Config.Context.AddToEmployees(emp)
            Config.Context.SaveChanges()
        End Sub

        ''' <summary>
        ''' Save the new employee's address information to the database.
        ''' </summary>
        Private Sub SaveEmpAddress()
            Dim currentEmpId As Integer = (From a In Config.Context.Employees Select a.EmpId).Max()

            Dim empAddress = New EmpAddress() With { _
             .AddressLine = tbxAddress.Text, _
             .City = tbxCity.Text, _
             .State = tbxState.Text, _
             .EmpId = currentEmpId _
            }

            Config.Context.AddToEmpAddresses(empAddress)
            Config.Context.SaveChanges()
        End Sub

#End Region

    End Class

End Namespace


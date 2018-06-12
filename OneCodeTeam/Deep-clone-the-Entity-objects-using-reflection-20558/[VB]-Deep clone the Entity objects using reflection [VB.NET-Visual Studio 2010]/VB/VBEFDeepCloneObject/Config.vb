'******************************** Module Header **********************************\
' Module Name:	Config.vb
' Project:		VBEFDeepCloneObject
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to implement deep clone/duplicate entity objects 
' using serialization and reflection.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*********************************************************************************/


Imports System.Windows.Forms

Namespace VBEFDeepCloneObject
    ''' <summary>
    ''' Define some global objects been used in multi forms.
    ''' </summary>
    NotInheritable Class Config
        Private Sub New()
        End Sub
        Public Shared Property Context() As EFCloneEntities
            Get
                Return _context
            End Get
            Set(ByVal value As EFCloneEntities)
                _context = value
            End Set
        End Property
        Private Shared _context As EFCloneEntities

        Public Shared Property EmpListForm() As EmployeeList
            Get
                Return _empListForm
            End Get
            Set(ByVal value As EmployeeList)
                _empListForm = value
            End Set
        End Property
        Private Shared _empListForm As EmployeeList

        Public Shared Property EmpDetailsForm() As EmployeeDetails
            Get
                Return _mpDetailsForm
            End Get
            Set(ByVal value As EmployeeDetails)
                _mpDetailsForm = value
            End Set
        End Property
        Private Shared _mpDetailsForm As EmployeeDetails

        Public Shared Property BsInfoForm() As SalesInfo
            Get
                Return _bsInfoForm
            End Get
            Set(ByVal value As SalesInfo)
                _bsInfoForm = value
            End Set
        End Property
        Private Shared _bsInfoForm As SalesInfo

        Public Shared Property Years() As String()
            Get
                Return _years
            End Get
            Set(ByVal value As String())
                _years = value
            End Set
        End Property
        Private Shared _years As String()

        ''' <summary>
        ''' Used to validate whether there are some empty textboxs.
        ''' </summary>
        ''' <param name="form"></param>
        ''' <returns></returns>
        Public Shared Function ValidateTextBox(ByVal form As Form) As Boolean
            For Each ctrl As Control In form.Controls
                If TypeOf ctrl Is TextBox Then
                    If ctrl.Text.Trim() = "" Then
                        Dim msg As String = String.Format("The {0} field {1}", ctrl.Name.Substring(3), My.Resources.TextBoxValidateMsg)

                        MessageBox.Show(msg)
                        ctrl.Focus()
                        Return False
                    End If
                End If
            Next

            Return True
        End Function
    End Class
End Namespace

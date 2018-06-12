'**************************** Module Header ******************************\
' Module Name:  Customer.vb
' Project:      VBDeepCloneObject
' Copyright (c) Microsoft Corporation.
' 
' The struct is used to demonstrate the deep clone.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Namespace VBDeepCloneObject
    Friend Structure Customer
        Private idOfCustomer As Integer
        Private nameOfCustomer As String
        Private addressOfCustomer As Address

        ''' <summary>
        ''' Get the deep clone of the Customer.
        ''' </summary>
        ''' <returns>Return the deep clone.</returns>
        Public Function DeepCopy() As Customer
            Dim newCustomer As Customer = Me
            newCustomer.Address = DeepCloneHelper.DeepClone(Address)
            Return newCustomer
        End Function
        Public Property Id() As Integer
            Get
                Return idOfCustomer
            End Get
            Set(ByVal value As Integer)
                idOfCustomer = value
            End Set
        End Property

        Public Property Name() As String
            Get
                Return nameOfCustomer
            End Get
            Set(ByVal value As String)
                nameOfCustomer = value
            End Set
        End Property

        Public Property Address() As Address
            Get
                Return addressOfCustomer
            End Get
            Set(ByVal value As Address)
                addressOfCustomer = value
            End Set
        End Property
    End Structure
End Namespace

'**************************** Module Header ******************************\
' Module Name:  UnpivotRow.vb
' Project:      VBEFPivotOperation
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to implement the Pivot and Unpivot operation in 
' Entity Framework.
' This file includes the definition of UnpivotRow class that stores the Unpivot 
' result.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/


Namespace VBEFPivotOperation
    ''' <summary>
    ''' Store the row of the Unpivot result.
    ''' </summary>
    ''' <typeparam name="TypeId">type of ObjectId</typeparam>
    ''' <typeparam name="TypeAttr">type of Attribute</typeparam>
    ''' <typeparam name="TypeValue">type of Value</typeparam>
    Public Class UnpivotRow(Of TypeId, TypeAttr, TypeValue)
        Public Property ObjectId() As TypeId
        Public Property Attribute() As TypeAttr
        Public Property Value() As TypeValue
    End Class
End Namespace

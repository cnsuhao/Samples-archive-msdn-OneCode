'***************************** Module Header ******************************\
' Module Name:	EmployeeComparer.vb
' Project:		VBDataTable2ListLINQOperation
' Copyright (c) Microsoft Corporation.
' 
' The project illustrates how to get a distinct, ordered list of names from a 
' DataTable using LINQ.
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/


' Custom comparer for the Employee class
Class EmployeeComparer
    Implements IEqualityComparer(Of Employee)

    ' Products are equal if their names and product numbers are equal. 
    Public Function Equals1(ByVal x As Employee, ByVal y As Employee
            ) As Boolean Implements IEqualityComparer(Of Employee).Equals

        ' Check whether the compared objects reference the same data. 
        If x Is y Then Return True

        'Check whether any of the compared objects is null. 
        If x Is Nothing OrElse y Is Nothing Then Return False

        'Check whether the products' properties are equal. 
        Return x.Id = y.Id AndAlso x.Name = y.Name AndAlso x.Location = y.Location
    End Function

    ' If Equals() returns true for a pair of objects  
    ' then GetHashCode() must return the same value for these objects. 

    Public Function GetHashCode1(
        ByVal employee As Employee
        ) As Integer Implements IEqualityComparer(Of Employee).GetHashCode

        ' Check whether the object is null. 
        If employee Is Nothing Then Return 0

        'Get hash code for the Id field if it is not null. 
        Dim hashEmployeeId As Integer = employee.Id.GetHashCode()

        'Get hash code for the Name field if it is not null. 
        Dim hashEmployeeName As Integer = If(employee.Name Is Nothing, 0, employee.Name.GetHashCode())

        'Get hash code for the Location field. 
        Dim hashEmployeeLocation As Integer = If(employee.Location Is Nothing, 0, employee.Location.GetHashCode())

        'Calculate the hash code for the product. 
        Return hashEmployeeId Xor hashEmployeeName Xor hashEmployeeLocation
    End Function

End Class
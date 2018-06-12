'*************************** Module Header ******************************'
' Module Name:  Person.vb
' Project:	    VBWindowsStoreAppReflection
' Copyright (c) Microsoft Corporation.
' 
' Define the classes to be demonstrated.
' 
' Person is the base class.
' Student inherits from Person, and implements IStudy.
' Employee inherits from Person, and implements IWork.
' Engineer and Saler inherit from Employee.
' 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************'

Namespace Types
    Public Class Person
        Public Property Name() As Double

        Public Property Age() As Integer

        Public Property IsMale() As Boolean
    End Class

    Public Class Student
        Inherits Person
        Implements IStudy
        Public Property Grade() As Integer

        Public Property School() As String



        Public Sub Study() Implements IStudy.Study

        End Sub
    End Class

    Public Class Employee
        Inherits Person
        Implements IWork
        Public Property Company() As String

        Public Overridable Sub Work() Implements IWork.Work
        End Sub
    End Class

    Public Class Engineer
        Inherits Employee
        Public Property Technology() As String
    End Class

    Public Class Saler
        Inherits Employee
        Public Property Product() As String
    End Class
End Namespace

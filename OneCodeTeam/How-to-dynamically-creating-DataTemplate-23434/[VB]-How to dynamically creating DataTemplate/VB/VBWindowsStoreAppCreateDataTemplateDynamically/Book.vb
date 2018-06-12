'***************************** Module Header ******************************\
' Module Name:    Book.vb
' Project:        VBWindowsStoreAppCreateDataTemplateDynamically
' Copyright (c) Microsoft Corporation.
' 
' This class is used to initialize data in Book collection
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/


Imports System.Collections.Generic

Public Class Book
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(value As String)
            m_Name = value
        End Set
    End Property
    Private m_Name As String
    Public Property Price() As Decimal
        Get
            Return m_Price
        End Get
        Set(value As Decimal)
            m_Price = value
        End Set
    End Property
    Private m_Price As Decimal
    Public Property Author() As String
        Get
            Return m_Author
        End Get
        Set(value As String)
            m_Author = value
        End Set
    End Property
    Private m_Author As String

    Public Shared Function GetBooks() As List(Of Book)
        Dim Books As New List(Of Book)()

        Books.Add(New Book() With { _
            .Author = "Allen", _
            .Price = 29.99D, _
            .Name = "War" _
        })
        Books.Add(New Book() With { _
            .Author = "Carter", _
            .Price = 35D, _
            .Name = "Fighting Like A Man" _
        })
        Books.Add(New Book() With { _
            .Author = "Rose", _
            .Price = 39.99D, _
            .Name = "Tomorrow" _
        })
        Books.Add(New Book() With { _
            .Author = "Daisy", _
            .Price = 99D, _
            .Name = "Last Three Days" _
        })
        Books.Add(New Book() With { _
            .Author = "Mary", _
            .Price = 10D, _
            .Name = "Fire Wall" _
        })
        Books.Add(New Book() With { _
            .Author = "Ray", _
            .Price = 19.99D, _
            .Name = "Lie" _
        })
        Books.Add(New Book() With { _
            .Author = "Sherry", _
            .Price = 45.5D, _
            .Name = "Three Wolves" _
        })
        Books.Add(New Book() With { _
            .Author = "Lisa", _
            .Price = 36.99D, _
            .Name = "Beauty" _
        })
        Books.Add(New Book() With { _
            .Author = "Judy", _
            .Price = 12D, _
            .Name = "The One" _
        })
        Books.Add(New Book() With { _
            .Author = "Jack", _
            .Price = 88.99D, _
            .Name = "Chosen by God" _
        })
        Books.Add(New Book() With { _
            .Author = "May", _
            .Price = 130D, _
            .Name = "The Magic" _
        })
        Books.Add(New Book() With { _
            .Author = "Vivian", _
            .Price = 299.99D, _
            .Name = "Who is the Murder" _
        })

        Return Books
    End Function
End Class
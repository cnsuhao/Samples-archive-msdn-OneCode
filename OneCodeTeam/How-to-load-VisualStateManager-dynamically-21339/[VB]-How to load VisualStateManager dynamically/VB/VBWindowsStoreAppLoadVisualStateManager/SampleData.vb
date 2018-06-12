'***************************** Module Header ******************************\
' Module Name:  SampleData.vb
' Project:      VBWindowsStoreAppLoadVisualStateManager
' Copyright (c) Microsoft Corporation.
'  
' This sample code is used to prepare data for display in UI.
'   
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
'  
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/


Imports System.Collections.Generic

Class SampleData
    Public Property Books() As List(Of Book)
        Get
            Return m_Books
        End Get
        Set(value As List(Of Book))
            m_Books = value
        End Set
    End Property
    Private m_Books As List(Of Book)
    Public Sub New()
        Books = New List(Of Book)()

        Dim book1 As New Book()
        book1.Category = "Novel"
        book1.Name = "John's relique"
        book1.Price = 50D
        Books.Add(book1)

        Dim book2 As New Book()
        book2.Category = "Novel"
        book2.Name = "A magical pig"
        book2.Price = 30.5D
        Books.Add(book2)

        Dim book3 As New Book()
        book3.Category = "Novel"
        book3.Name = "Wolves"
        book3.Price = 40.5D
        Books.Add(book3)

        Dim book4 As New Book()
        book4.Category = "Novel"
        book4.Name = "Naughty Tom"
        book4.Price = 33.5D
        Books.Add(book4)

        Dim book5 As New Book()
        book5.Category = "Novel"
        book5.Name = "Beyond"
        book5.Price = 60D
        Books.Add(book5)

        Dim book6 As New Book()
        book6.Category = "Novel"
        book6.Name = "Black 3 Minutes"
        book6.Price = 230D
        Books.Add(book6)

        Dim book7 As New Book()
        book7.Category = "Novel"
        book7.Name = "Rich and Powerful"
        book7.Price = 310.5D
        Books.Add(book7)

        Dim book8 As New Book()
        book8.Category = "Novel"
        book8.Name = "Lie"
        book8.Price = 130.5D
        Books.Add(book8)

        Dim book9 As New Book()
        book9.Category = "Novel"
        book9.Name = "See you next century"
        book9.Price = 10.5D
        Books.Add(book9)



    End Sub
End Class

Class Book
    Public Property Category() As String
        Get
            Return m_Category
        End Get
        Set(value As String)
            m_Category = value
        End Set
    End Property
    Private m_Category As String
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
End Class
'***************************** Module Header ******************************\
' Module Name:  SampleData.vb
' Project:      VBWindowsStoreAppDragAndDropBetweenGroups
' Copyright (c) Microsoft Corporation.
'  
' It generates the sample data for data binding.
'  
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
' All other rights reserved.
'  
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Public Class SampleData
    Public Property Categories() As ObservableCollection(Of Category)

    Public Property Books() As ObservableCollection(Of Book)

    Public Sub New()
        Categories = New ObservableCollection(Of Category)()
        Books = New ObservableCollection(Of Book)()

        Dim novel As New Category()
        novel.Name = "Novel"
        Dim fairyTale As New Category()
        fairyTale.Name = "Fairy Tale"
        Dim management As New Category()
        management.Name = "Management"
        Dim computerScience As New Category()
        computerScience.Name = "Computer Science"

        Dim badBoy As New Book()
        badBoy.Name = "Bad Boy"
        badBoy.Author = "John"
        badBoy.Price = 30
        badBoy.Cate = novel
        novel.BookList.Add(badBoy)
        Books.Add(badBoy)

        Dim fighting As New Book()
        fighting.Name = "Fighting"
        fighting.Author = "Rose"
        fighting.Price = 50
        fighting.Cate = novel
        novel.BookList.Add(fighting)
        Books.Add(fighting)

        Dim heaven As New Book()
        heaven.Name = "Heaven"
        heaven.Author = "Allen"
        heaven.Price = 100
        heaven.Cate = novel
        novel.BookList.Add(heaven)
        Books.Add(heaven)

        Dim hood As New Book()
        hood.Name = "Hood"
        hood.Author = "Bruce"
        hood.Price = 10
        hood.Cate = fairyTale
        fairyTale.BookList.Add(hood)
        Books.Add(hood)

        Dim theThree As New Book()
        theThree.Name = "The Three"
        theThree.Author = "Jobs"
        theThree.Price = 60
        theThree.Cate = fairyTale
        fairyTale.BookList.Add(theThree)
        Books.Add(theThree)

        Dim ninja As New Book()
        ninja.Name = "Ninja"
        ninja.Cate = fairyTale
        ninja.Author = "Brown"
        ninja.Price = 10
        fairyTale.BookList.Add(ninja)
        Books.Add(ninja)

        Dim White As New Book()
        White.Name = "White"
        White.Author = "Jesson"
        White.Price = 100
        White.Cate = fairyTale
        fairyTale.BookList.Add(White)
        Books.Add(White)

        Dim fifteenMinutes As New Book()
        fifteenMinutes.Name = "Fifteen Minutes Management"
        fifteenMinutes.Author = "Carter"
        fifteenMinutes.Price = 35
        fifteenMinutes.Cate = management
        management.BookList.Add(fifteenMinutes)
        Books.Add(fifteenMinutes)

        Dim staffMotivation As New Book()
        staffMotivation.Name = "Staff Motivation"
        staffMotivation.Author = "Sherry"
        staffMotivation.Price = 99
        staffMotivation.Cate = management
        management.BookList.Add(staffMotivation)
        Books.Add(staffMotivation)

        Dim csharp As New Book()
        csharp.Name = "Learning C# In One Week"
        csharp.Author = "Bob"
        csharp.Price = 200
        csharp.Cate = computerScience
        computerScience.BookList.Add(csharp)

        Categories.Add(novel)
        Categories.Add(fairyTale)
        Categories.Add(management)
        Categories.Add(computerScience)
    End Sub

    ''' <summary>
    ''' Return the Category Datasouce
    ''' </summary>
    ''' <returns></returns>
    Public Function GetCategoryDataSource() As ObservableCollection(Of Category)
        Return Categories
    End Function

    ''' <summary>
    ''' Return the Book Datasource
    ''' </summary>
    ''' <returns></returns>
    Public Function GetBookDataSource() As ObservableCollection(Of Book)
        Return Books
    End Function
End Class

'*************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBXPath
' Copyright (c) Microsoft Corporation.
' 
' This sample project shows how to use XPathDocument class to load the XML 
' file and manipulate. It includes two main parts, XPathNavigator usage and 
' XPath Expression usage. The first part shows how to use XPathNavigator to 
' navigate through the whole document, read its content. The second part 
' shows how to use XPath expression to filter information and select it out.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'  EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

#Region "Using directives"
Imports System.Xml.XPath
#End Region


Module MainModule
    Sub Main()
        ' Initialize XPathDocument and XPathNavigator.
        Dim xPathNavigator As XPathNavigator
        Dim xPathDoc As XPathDocument

        ' Navigate through the whole document.
        ' Create a new instance of XPathDocument from a XML file.
        xPathDoc = New XPathDocument("books.xml")

        ' Call CreateNavigator method to create a navigator instance.
        ' And we will use this navigator object to navigate through whole document.
        xPathNavigator = xPathDoc.CreateNavigator()

        ' Move to the root element.
        xPathNavigator.MoveToRoot()

        ' Catalog element is the first children of the root.
        ' Move to catalog element.
        xPathNavigator.MoveToFirstChild()

        ' We can know a XML node's type from the NodeType property.
        ' XPathNodeType has Attribute, Element, Namespace and so on.
        If xPathNavigator.NodeType = XPathNodeType.Element Then
            ' We can know if a Node has child nodes by checking its
            ' HasChildren property. If it returns true, that node has child nodes.
            If xPathNavigator.HasChildren = True Then

                ' Move to the first child which is our first book nodes.
                xPathNavigator.MoveToFirstChild()
                Do
                    ' We can know if a node has any attribute by checking
                    ' the HasAttributes property. When this property returns
                    ' true, we can get the specified attribute by calling
                    ' navigator.GetAttribute() method.
                    If xPathNavigator.HasAttributes = True Then
                        Console.WriteLine("Book ID: " & xPathNavigator.GetAttribute("id", ""))
                    End If

                    ' Iterate through a book node's child nodes
                    ' and list all child node information, like 
                    ' name, author, price, publish date and so on.
                    If xPathNavigator.HasChildren Then
                        xPathNavigator.MoveToFirstChild()
                        Do
                            Console.Write(vbTab & "{0}:" & vbTab & "{1}" & vbCrLf, xPathNavigator.Name, xPathNavigator.Value)
                        Loop While xPathNavigator.MoveToNext()

                        ' When all child nodes are reached. The MoveToNext() method returns
                        ' false. Then we need to call MoveToParent to go back to the book level.
                        xPathNavigator.MoveToParent()
                    End If

                    ' Move to the next book element.
                Loop While xPathNavigator.MoveToNext()
            End If
        End If


        ' Use XPath Expression to select out book bk103.
        ' The expression should be "/catalog/book[@id='bk103']"
        ' @ means to look id attribute and match bk103.
        Console.WriteLine("Use XPath Expression to select out the book with ID bk103:")
        Dim expression As XPathExpression = xPathNavigator.Compile("/catalog/book[@id='bk103']")
        Dim iterator As XPathNodeIterator = xPathNavigator.Select(expression)

        ' After compile the XPath expression, we can call navigator.Select
        ' to retrieve the XPathNodeIterator. With this iterator, we can loop
        ' trough the results filtered by the XPath expression.
        ' The following codes print the book bk103's detailed information.
        Do While iterator.MoveNext()
            Dim nav As XPathNavigator = iterator.Current.Clone()
            Console.WriteLine("Book ID: " & nav.GetAttribute("id", ""))
            If nav.HasChildren Then
                nav.MoveToFirstChild()
                Do
                    Console.Write(vbTab & "{0}:" & vbTab & "{1}" & vbCrLf, nav.Name, nav.Value)
                Loop While nav.MoveToNext()
            End If
        Loop


        ' Use XPath to select out all books whose price are more than 10.00
        ' '[]' means to look into the child node to match the condition "price > 10".
        Console.WriteLine(vbCrLf & "Use XPath Expression to select out all books whose price are more than 10:")
        expression = xPathNavigator.Compile("/catalog/book[price>10]")
        iterator = xPathNavigator.Select(expression)

        ' After getting the iterator, we print title and price for books 
        ' whose price are more than 10.
        Do While iterator.MoveNext()
            Dim nav As XPathNavigator = iterator.Current.Clone()
            Console.WriteLine("Book ID: " & nav.GetAttribute("id", ""))
            If nav.HasChildren Then
                nav.MoveToFirstChild()
                Do
                    If nav.Name = "title" Then
                        Console.Write(vbTab & "{0}:" & vbTab & "{1}" & vbCrLf, nav.Name, nav.Value)
                    End If
                    If nav.Name = "price" Then
                        Console.Write(vbTab & "{0}:" & vbTab & "{1}" & vbCrLf, nav.Name, nav.Value)
                    End If
                Loop While nav.MoveToNext()
            End If
        Loop

        ' Use XPath Expression to calculate the average price of all books.
        ' Here in XPath, we use the sum, div, and count formula.
        Console.WriteLine(vbCrLf & "Use XPath Expression to calculate the average price of all books:")
        expression = xPathNavigator.Compile("sum(/catalog/book/price) div count(/catalog/book/price)")
        Dim averagePrice As String = xPathNavigator.Evaluate(expression).ToString()
        Console.WriteLine("The average price of the books are {0}", averagePrice)

        ' End. Read a char to exit

        Console.WriteLine("Input any key to quit the sample application")
        Console.ReadLine()
    End Sub
End Module

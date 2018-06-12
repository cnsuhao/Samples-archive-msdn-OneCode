'****************************** Module Header ******************************\
'Module Name:  WindowsPhoneService.vb
'Project:      ServiceBusServices
'Copyright (c) Microsoft Corporation.
'
'The sample code demonstrates how to expose an on-premise REST service to Internet
'via Service Bus, then you can access this service by Windows Phone application.
'The service includes normal string, generics and image methods.
'
'This is the service class.
'
'This source is subject to the Microsoft Public License.
'See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL
'All other rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System.IO

Public Class WindowsPhoneService
    Implements IWindowsPhoneService
    ''' <summary>
    ''' Return hello string.
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    Public Function Hello(name As String) As String Implements IWindowsPhoneService.Hello
        Return "Hello," & name
    End Function

    ''' <summary>
    ''' Return some entities.
    ''' </summary>
    ''' <returns></returns>
    Public Function Persons() As List(Of Person) Implements IWindowsPhoneService.Persons
        Dim person As New Person()
        person.Name = "John"
        person.Comments = "John's comments"
        Dim list As New List(Of Person)()
        Dim person2 As New Person()
        person2.Name = "John2"
        person2.Comments = "John2's comments"
        list.Add(person2)
        list.Add(person)
        Return list
    End Function

    ''' <summary>
    ''' Return MSDN.jpg file stream.
    ''' </summary>
    ''' <returns></returns>
    Public Function Image() As Stream Implements IWindowsPhoneService.Image
        Dim fileSource As FileStream = File.OpenRead("Files/Microsoft.jpg")
        Return fileSource
    End Function
End Class

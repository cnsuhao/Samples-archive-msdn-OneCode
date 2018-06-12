'**************************** Module Header ******************************\
' Module Name: CustomFile.vb
' Project:     VBASPNETAccessResourceInAssembly
' Copyright (c) Microsoft Corporation
'
' This project illustrates how to access user controls and web pages from class
' library via virtual path. Here we inherit VirtualPathProvider and VirtualFile 
' class for creating a custom path provider. In VBASPNETAccessResourceAssembly,
' we can load embed resource files use specify virtual path in assembly.
' 
' This class inherits VirtualFile class and override Open method for loading
' assembly files.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'****************************************************************************



Imports System.Web.Hosting
Imports System.IO
Imports System.Reflection

Public Class CustomFile
    Inherits VirtualFile
    Private Property path As String

    Public Sub New(ByVal virtualPath As String)
        MyBase.New(virtualPath)
        path = VirtualPathUtility.ToAppRelative(virtualPath)
    End Sub
    ''' <summary>
    ''' Override Open method to load resource files of assembly.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function Open() As System.IO.Stream
        Dim strs As String() = path.Split("/"c)
        Dim name As String = strs(2)
        Dim resourceName As String = strs(3)
        name = System.IO.Path.Combine(HttpRuntime.BinDirectory, name)
        Dim assembly As Assembly = assembly.LoadFile(name)
        If assembly IsNot Nothing Then
            Dim s As Stream = assembly.GetManifestResourceStream(resourceName)
            Return s
        Else
            Return Nothing
        End If
    End Function
End Class

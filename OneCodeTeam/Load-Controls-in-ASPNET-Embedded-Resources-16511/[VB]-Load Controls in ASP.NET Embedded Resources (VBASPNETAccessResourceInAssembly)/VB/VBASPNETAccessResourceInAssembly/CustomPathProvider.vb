'**************************** Module Header ******************************\
' Module Name: CustomPathProvider.vb
' Project:     VBASPNETAccessResourceInAssembly
' Copyright (c) Microsoft Corporation
'
' This project illustrates how to access user controls and web pages from class
' library via virtual path. Here we inherit VirtualPathProvider and VirtualFile 
' class for creating a custom path provider. In VBASPNETAccessResourceAssembly,
' we can load embed resource files use specify virtual path in assembly.
' 
' This class inherits VirtualPathProvider class for creating a custom path
' provider, here we need override FileExists, GetFile, GetCacheDependency methods.
' The application will invoke CustomFile.Open method when it finds the specifical
' folder name.
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

Public Class CustomPathProvider
    Inherits VirtualPathProvider

    ''' <summary>
    ''' Make a judgment that application find path contains specifical folder name.
    ''' </summary>
    ''' <param name="path"></param>
    ''' <returns></returns>
    Private Function AssemblyPathExist(ByVal path As String) As Boolean
        Dim relateivePath As String = VirtualPathUtility.ToAppRelative(path)
        Return relateivePath.StartsWith("~/Assembly/", StringComparison.InvariantCultureIgnoreCase)
    End Function
    ''' <summary>
    ''' If we can find this virtual path, return true.
    ''' </summary>
    ''' <param name="virtualPath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function FileExists(ByVal virtualPath As String) As Boolean
        If Me.AssemblyPathExist(virtualPath) Then
            Return True
        Else
            Return MyBase.FileExists(virtualPath)
        End If
    End Function
    ''' <summary>
    ''' Use custom VirtualFile class to load assembly resources.
    ''' </summary>
    ''' <param name="virtualPath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function GetFile(ByVal virtualPath As String) As System.Web.Hosting.VirtualFile
        If AssemblyPathExist(virtualPath) Then
            Return New CustomFile(virtualPath)
        Else
            Return MyBase.GetFile(virtualPath)
        End If
    End Function
    ''' <summary>
    ''' Return null when application use virtual file path.
    ''' </summary>
    ''' <param name="virtualPath"></param>
    ''' <param name="virtualPathDependencies"></param>
    ''' <param name="utcStart"></param>
    ''' <returns></returns>
    Public Overrides Function GetCacheDependency(ByVal virtualPath As String, ByVal virtualPathDependencies As IEnumerable, ByVal utcStart As DateTime) As CacheDependency
        If AssemblyPathExist(virtualPath) Then
            Return Nothing
        Else
            Return MyBase.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart)
        End If
    End Function
End Class

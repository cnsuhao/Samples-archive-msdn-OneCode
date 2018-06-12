'************************** Module Header ******************************'
' Module Name:  MainModule.vb
' Project:      VBCreateCabinet
' Copyright (c) Microsoft Corporation.
' 
' The Console UI of this application.
' Use can type following commands:
' 
'  pack <cabfile> <sourcefolder>
'  unpack <cabfile> <destiFolder>
'  sign <cabfile> <pfxFile> <password>
'  verify <cabfile>";
' 
' This application also supports command line arguments.
'  
'     VBCreateCabinet pack <cabfile> <sourcefolder>
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'************************************************************************'

Imports System.Linq
Imports System.Text.RegularExpressions
Imports Microsoft.Deployment.Compression


Module MainModule
    Private Const helpMsg As String = "Type command in following formats:" & ControlChars.CrLf _
                                      & "    pack <cabfile> <sourcefolder>" & ControlChars.CrLf _
                                      & "    unpack <cabfile> <destiFolder>" & ControlChars.CrLf _
                                      & "    sign <cabfile> <pfxFile> <password>" & ControlChars.CrLf _
                                      & "    verify <cabfile>"


    Sub Main(ByVal args() As String)
        Try

            ' Arguments are supplied.
            If args Is Nothing AndAlso args.Length <> 0 Then
                Dim flag As Boolean = Run(args)
                Environment.ExitCode = If(flag, 0, 100)
            Else
                Do
                    Console.WriteLine(helpMsg)
                    Dim input As String = Console.ReadLine()
                    Dim arguments() As String = Nothing
                    If ResolveArguments(input, arguments) Then
                        Run(arguments)
                    End If
                Loop
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Resolve the input as the arguments.
    ''' For example, [pack d:\temp\my.cab "C:\My folder"] will be recognized as 
    ''' args[0] = pack
    ''' args[1] = d:\temp\my.cab
    ''' args[2] = c:\My Folder
    ''' </summary>
    Private Function ResolveArguments(ByVal input As String, ByRef args() As String) As Boolean
        input = input.Trim()
        If String.IsNullOrEmpty(input) Then
            args = Nothing
            Return False
        End If

        ' Match "<some words>" first, and then use whitespace to split the 
        ' input.
        Dim pattern As String = "("".+?"" )|("".+?""$)|(.+? )|(.+?$)"

        Dim matches = Regex.Matches(input, pattern)

        If matches IsNot Nothing Then
            Dim argList = New List(Of String)()
            For Each match As Match In matches
                argList.Add(match.Value.Replace("""", String.Empty).Trim())
            Next match
            args = argList.ToArray()
            Return True
        Else
            args = Nothing
            Return False
        End If
    End Function

    ''' <summary>
    ''' Run the method specified by the first argument.
    ''' </summary>
    ''' <returns>
    ''' True if the method runs successfully.
    ''' </returns>
    Private Function Run(ByVal args() As String) As Boolean
        Try
            Select Case args(0).ToLower()
                Case "pack"
                    If args.Length = 3 Then
                        RunPackMethod(args(1), args(2))
                        Return True
                    Else
                        Console.WriteLine("Please use this format:")
                        Console.WriteLine("    pack cabfile sourcefolder")
                        Return False
                    End If
                Case "unpack"
                    If args.Length = 3 Then
                        RunUnpackMethod(args(1), args(2))
                        Return True
                    Else
                        Console.WriteLine("Please use this format:")
                        Console.WriteLine("    unpack cabfile destifolder")
                        Return False
                    End If
                Case "sign"
                    If args.Length = 4 Then
                        RunSignMethod(args(1), args(2), args(3))
                        Return True
                    Else
                        Console.WriteLine("Please use this format:")
                        Console.WriteLine("    sign cabfile pfxFile password")
                        Return False
                    End If
                Case "verify"
                    If args.Length = 2 Then
                        RunVerifyMethod(args(1))
                        Return True
                    Else
                        Console.WriteLine("Please use this format:")
                        Console.WriteLine("    verify cabfile")
                        Return False
                    End If
                Case Else
                    Return False
            End Select
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Pack a folder to the cabinet.
    ''' </summary>
    Private Sub RunPackMethod(ByVal cabFilePath As String, ByVal sourceFolder As String)
        Try
            Dim pkg As SignableCabinetPackage = SignableCabinetPackage.LoadOrCreateCab(cabFilePath)
            pkg.Pack(sourceFolder,
                     True,
                     CompressionLevel.Normal,
                     AddressOf ProcessHandle)
            Console.WriteLine("Packing cabinet succeed.")
        Catch ex As Exception
            Console.WriteLine("Packing cabinet failed.")
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Unpack files from a cabinet.
    ''' </summary>
    Private Sub RunUnpackMethod(ByVal cabFilePath As String,
                                ByVal destinationFolder As String)
        Try
            Dim pkg As SignableCabinetPackage = SignableCabinetPackage.LoadCab(cabFilePath)
            pkg.Unpack(destinationFolder, AddressOf ProcessHandle)
            Console.WriteLine("Unpacking cabinet succeed.")
        Catch ex As Exception
            Console.WriteLine("Unpacking cabinet failed.")
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Sign a cabinet.
    ''' </summary>
    Private Sub RunSignMethod(ByVal cabFilePath As String,
                              ByVal pfxFilePath As String,
                              ByVal password As String)
        Try
            Dim pkg As SignableCabinetPackage = SignableCabinetPackage.LoadCab(cabFilePath)
            pkg.Sign(pfxFilePath, password)
            Console.WriteLine("Cabinet signature succeed.")
        Catch ex As Exception
            Console.WriteLine("Cabinet signature failed.")
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Verify the signature of a cabinet.
    ''' </summary>
    Private Sub RunVerifyMethod(ByVal cabFilePath As String)
        Try
            Dim pkg As SignableCabinetPackage = SignableCabinetPackage.LoadCab(cabFilePath)
            pkg.Verify()
            Console.WriteLine("Cabinet signature verification succeed.")
        Catch ex As System.Runtime.InteropServices.COMException
            Console.WriteLine("Cabinet signature verification failed.")
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Handle the event that a file is being processed. 
    ''' </summary>
    Private Sub ProcessHandle(ByVal sender As Object,
                              ByVal e As ArchiveProgressEventArgs)

    End Sub
End Module


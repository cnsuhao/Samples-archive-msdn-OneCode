'************************** Module Header ******************************'
' Module Name:  SignedCabinetPackage.vb
' Project:      VBCreateCabinet
' Copyright (c) Microsoft Corporation.
' 
' This class represents a signable cabinet package. 
' 
' It inherits Microsoft.Deployment.Compression.Cab.CabInfo class, which could 
' be used to create a cabinet package. For more detailed information about creating
' a normal cabinet package, see the SDK documents of WiX Toolset
' http://wix.codeplex.com/releases/view/60102
' 
' The Sign method uses Signtool.exe to sign the cabinet package. 
' http://msdn.microsoft.com/en-us/library/8s9b9yaz.aspx
' 
' To verify the signature of a cabinet package, we can use WinVerifyTrust function.
' The WinVerifyTrust function performs a trust verification action on a specified object.
' The function passes the inquiry to a trust provider that supports the action identifier,
' if one exists.
' http://msdn.microsoft.com/en-us/library/windows/desktop/aa388208(v=vs.85).aspx
' 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'************************************************************************'

Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Runtime.Serialization
Imports System.Security.Permissions
Imports Microsoft.Deployment.Compression.Cab
Imports VBCreateCabinet.Signature


<Serializable()>
Public Class SignableCabinetPackage
    Inherits CabInfo
    Public Sub New(ByVal path As String)
        MyBase.New(path)
    End Sub

    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New(info, context)
    End Sub

    ''' <summary>
    ''' Sign the cabinet using signtool.exe.
    ''' </summary>
    ''' <param name="pfxFilePath"></param>
    ''' <param name="password"></param>
    <PermissionSetAttribute(SecurityAction.LinkDemand, Name:="FullTrust")>
    Public Sub Sign(ByVal pfxFilePath As String, ByVal password As String)
        Dim signtool As ProcessStartInfo = New ProcessStartInfo With {
            .Arguments = String.Format("sign /f {0} /p {1} {2}",
                                       pfxFilePath,
                                       password,
                                       Me.FullPath),
            .FileName = "signtool.exe",
            .CreateNoWindow = True,
            .RedirectStandardOutput = True,
            .UseShellExecute = False}

        Dim signtoolProc As Process = Process.Start(signtool)
        signtoolProc.WaitForExit()

        If signtoolProc.ExitCode <> 0 Then
            Throw New ApplicationException(signtoolProc.StandardOutput.ReadToEnd())
        End If
    End Sub

    ''' <summary>
    ''' Verify the signature of a cabinet.
    ''' </summary>
    Public Sub Verify()
        Using wtd As New NativeMethods.WINTRUST_DATA(Me.FullPath)

            Dim guidAction As New Guid(NativeMethods.WINTRUST_ACTION_GENERIC_VERIFY_V2)
            Dim result As Integer = NativeMethods.WinVerifyTrust(
                NativeMethods.INVALID_HANDLE_VALUE, guidAction, wtd)

            If result <> 0 Then
                Dim exception = Marshal.GetExceptionForHR(result)
                Throw exception
            End If
        End Using
    End Sub


#Region "Shared Helper Functions"

    Public Shared Function LoadOrCreateCab(ByVal path As String) As SignableCabinetPackage
        If File.Exists(path) Then
            Return LoadCab(path)
        Else
            Return CreateCab(path)
        End If
    End Function

    Public Shared Function LoadCab(ByVal path As String) As SignableCabinetPackage
        If Not File.Exists(path) Then
            Throw New ArgumentException("Cannot find the path " & path)
        End If

        Dim pkg As New SignableCabinetPackage(path)

        If Not pkg.IsValid() Then
            Throw New ArgumentException("This is not a valid cabinet file.")
        End If

        Return pkg
    End Function

    Public Shared Function CreateCab(ByVal path As String) As SignableCabinetPackage
        Return CreateCab(path, True)
    End Function

    Public Shared Function CreateCab(ByVal path As String,
                                     ByVal overrideExistingFile As Boolean) _
                                 As SignableCabinetPackage
        If File.Exists(path) Then
            If overrideExistingFile Then
                File.Delete(path)
            Else
                Throw New ArgumentException("There is already a file named " & path)
            End If
        End If

        Dim pkg As New SignableCabinetPackage(path)
        Return pkg
    End Function

#End Region

End Class


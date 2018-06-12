'************************************* Module Header ***********************\
' Module Name:  OneTimePasswordController.vb
' Project:      VBWindowsStoreAppASHWID
' Copyright (c) Microsoft Corporation.
' 
' OneTimePasswordController for client to retrieve OTP nonce from the server.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Imports System.Data.Entity.Infrastructure
Imports VBWindowsStoreAppDeviceService.Models

Namespace VBWindowsStoreAppDeviceService
    Public Class OneTimePasswordController
        Inherits System.Web.Http.ApiController

        Private db As New VBWindowsStoreAppDeviceServiceContext

        ' GET api/OneTimePassword
        ' Get OTP nonce from the cloud
        Function GetOneTimePasswords() As OneTimePassword

            Dim userAgent As String = Request.Headers.UserAgent.ToString
            If Not userAgent.StartsWith("AllInOneCode-") Then
                Return Nothing
            End If

            userAgent = userAgent.Substring("AllInOneCode-".Length)
            Dim userAgentGuid As New Guid(userAgent)

            Dim otp As OneTimePassword = Nothing
            If ModelState.IsValid Then
                otp = db.OneTimePasswords.Find(userAgentGuid)

                If (Not otp Is Nothing) Then
                    ' Found the original otp in the database, renew the expired time.
                    otp.ExpiredTime = DateTime.UtcNow.AddMinutes(1)
                    otp.Nonce = Guid.NewGuid().ToString().Substring(0, 6)
                    db.Entry(otp).State = EntityState.Modified
                Else
                    ' Password will be expired in one minute by default.
                    ' Nonce will be generated randomly in a substring of GUID value.
                    otp = New OneTimePassword With { _
                        .AgentId = New Guid(userAgent), _
                        .ExpiredTime = DateTime.UtcNow.AddMinutes(1), _
                        .Nonce = Guid.NewGuid().ToString().Substring(0, 6) _
                    }
                    db.OneTimePasswords.Add(otp)
                End If

                Try
                    db.SaveChanges()
                Catch duce As DbUpdateConcurrencyException
                    Debug.WriteLine(duce.Message)
                    Debug.WriteLine(duce.StackTrace)
                End Try
            End If

            Return otp
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
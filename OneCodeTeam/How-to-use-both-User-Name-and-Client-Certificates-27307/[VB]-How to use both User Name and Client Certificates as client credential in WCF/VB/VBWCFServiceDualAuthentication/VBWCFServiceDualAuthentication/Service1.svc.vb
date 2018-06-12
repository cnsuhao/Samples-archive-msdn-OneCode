'****************************** Module Header ******************************\
' Module Name:    Service1.svc.vb
' Project:        VBWCFServiceDualAuthentication
' Copyright (c) Microsoft Corporation
'
' The project illustrates how to use both User Name and Client Certificates 
' as client credential type in WCF. 
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Imports System.IdentityModel.Selectors

' NOTE: You can use the "Rename" command on the context menu to change the class name "Service1" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.vb at the Solution Explorer and start debugging.
Public Class Service1
    Implements IService1

    Public Sub New()
    End Sub

    Public Function GetData(ByVal value As Integer) As String Implements IService1.GetData
        Return String.Format("You entered: {0}", value)
    End Function

End Class


Public Class MyUserNamePasswordValidator
    Inherits UserNamePasswordValidator
    Public Overrides Sub Validate(userName As String, password As String)
        If userName Is Nothing OrElse password Is Nothing Then
            Throw New ArgumentNullException()
        End If

        If Not (userName = "Melissa" AndAlso password = "123@abc") Then
            ' This throws an informative fault to the client.
            ' When you do not want to throw an infomative fault to the client,
            ' throw the following exception.
            ' throw new SecurityTokenException("Unknown Username or Incorrect Password");
            Throw New FaultException("Unknown Username or Incorrect Password")
        End If
    End Sub
End Class

' Define the Certificate Validator class

Public Class CertificateValidate
    Inherits X509CertificateValidator
    Public Overrides Sub Validate(Certificate As System.Security.Cryptography.X509Certificates.X509Certificate2)
        ' Check for the certificate

        If Certificate Is Nothing Then
            Throw New ArgumentNullException("Unable to find certificate")
        End If

        ' Check the Incoming client certificate
        If Certificate.IssuerName.Name <> "CN=MSIT Enterprise CA 2" Then
            Throw New System.IdentityModel.Tokens.SecurityTokenValidationException("Cannot find the issuer")
        End If
    End Sub
End Class


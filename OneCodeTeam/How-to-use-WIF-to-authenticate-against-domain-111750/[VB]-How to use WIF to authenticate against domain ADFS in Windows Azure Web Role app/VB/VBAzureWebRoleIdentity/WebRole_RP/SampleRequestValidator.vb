Imports System.Web.Util
Imports Microsoft.IdentityModel.Protocols.WSFederation

Public Class SampleRequestValidator
    Inherits RequestValidator
    Protected Overrides Function IsValidRequestString(context As HttpContext, value As String, requestValidationSource__1 As RequestValidationSource, collectionKey As String, ByRef validationFailureIndex As Integer) As Boolean
        validationFailureIndex = 0

        If requestValidationSource__1 = RequestValidationSource.Form AndAlso collectionKey.Equals(WSFederationConstants.Parameters.Result, StringComparison.Ordinal) Then
            Dim message As SignInResponseMessage = TryCast(WSFederationMessage.CreateFromFormPost(context.Request), SignInResponseMessage)

            If message IsNot Nothing Then
                Return True
            End If
        End If

        Return MyBase.IsValidRequestString(context, value, requestValidationSource__1, collectionKey, validationFailureIndex)
    End Function
End Class

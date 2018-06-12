'****************************** Module Header ******************************\
' Module Name:    CheckRefreshUserControl.ascx.vb
' Project:        VBASPNETCheckPageRefresh
' Copyright (c) Microsoft Corporation
'
' Reusable User Control.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'*****************************************************************************/

Partial Public Class CheckRefreshUserControl
    Inherits System.Web.UI.UserControl

    ''' <summary> 
    ''' Flag for checking whether duplicated refreshing or not.
    ''' </summary>   
    Public Property ReFreshCheck() As Boolean
        Get
            Return _reFreshCheck
        End Get
        Set(ByVal value As Boolean)
            _reFreshCheck = Value
        End Set
    End Property
    Private _reFreshCheck As Boolean

    ''' <summary>     
    ''' Fetch the parent page's class name, which is unique.    
    ''' </summary>  
    Private parentName As String = Nothing
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
        If TypeOf Parent.Parent Is Page Then
            parentName = Parent.Parent.[GetType]().Name
            If IsPostBack Then
                ' If it is postback, reset the Session value to null, and it represents 
                ' it's not a repeated loading.
                ReFreshCheck = False
                Session(parentName) = Nothing
            ElseIf Request.UrlReferrer IsNot Nothing AndAlso Request.UrlReferrer.ToString() <> Request.Url.ToString() Then

                ' Detect whether the request comes from the other page. 
                Session(parentName) = Nothing
            Else
                If Session(parentName) Is Nothing Then
                    ReFreshCheck = False
                    Session(parentName) = True
                Else
                    ReFreshCheck = True
                End If
            End If
        Else
            Throw New Exception("You must put the control inside the page!")
        End If
    End Sub

End Class
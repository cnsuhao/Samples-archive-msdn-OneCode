'***************************** Module Header ******************************\
' Module Name:  BasicValidation.vb
' Project:		VBWF4CustomValidation
' Copyright (c) Microsoft Corporation.
' 
' This is a custom activity inherited from NativeActivity. PersonInfo activity
' can validate the input age automatically. if the input age number is negative
' There will be a red ball appear in the designer and tell user "age must larger"
' than 0. 
'
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
'**************************************************************************/

Imports System.Activities

Public Class PersonInfo
    Inherits NativeActivity
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(value As String)
            m_Name = value
        End Set
    End Property
    Private m_Name As String
    Public Property Age() As Integer
        Get
            Return m_Age
        End Get
        Set(value As Integer)
            m_Age = value
        End Set
    End Property
    Private m_Age As Integer

    Protected Overrides Sub CacheMetadata(metadata As NativeActivityMetadata)
        MyBase.CacheMetadata(metadata)
        If Age < 0 Then
            metadata.AddValidationError("age must larger than 0")
        End If
    End Sub

    Protected Overrides Sub Execute(context As NativeActivityContext)
        Console.WriteLine(Name & " " & Age)
    End Sub
End Class


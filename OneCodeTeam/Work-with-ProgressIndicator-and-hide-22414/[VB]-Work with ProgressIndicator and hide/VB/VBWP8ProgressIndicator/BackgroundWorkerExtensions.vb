'***************************** Module Header ******************************\
'* Module Name:    BackgroundWorkerExtensions.vb
'* Project:        VBWP8ProgressIndicator
'* Copyright (c) Microsoft Corporation
'*
'* This class is the custom extension for BackgroundWorker.
'* 
'* This source is subject to the Microsoft Public License.
'* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
'* All other rights reserved.
'* 
'* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
'* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
'* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'\****************************************************************************

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Public Module BackgroundWorkerExtensions
    <System.Runtime.CompilerServices.Extension()> _
    Public Function RunWorkerTaskAsync(backgroundWorker As BackgroundWorker) As Task(Of Object)
        Dim tcs = New TaskCompletionSource(Of Object)()
        Dim handler As RunWorkerCompletedEventHandler = Nothing
        handler = Function(sender, args)
                      If args.Cancelled Then
                          tcs.TrySetCanceled()
                      ElseIf args.[Error] IsNot Nothing Then
                          tcs.TrySetException(args.[Error])
                      Else
                          tcs.TrySetResult(args.Result)
                      End If
                      Return Nothing
                  End Function
        AddHandler backgroundWorker.RunWorkerCompleted, handler
        Try
            backgroundWorker.RunWorkerAsync()
        Catch
            RemoveHandler backgroundWorker.RunWorkerCompleted, handler
            Throw
        End Try
        Return tcs.Task
    End Function
End Module

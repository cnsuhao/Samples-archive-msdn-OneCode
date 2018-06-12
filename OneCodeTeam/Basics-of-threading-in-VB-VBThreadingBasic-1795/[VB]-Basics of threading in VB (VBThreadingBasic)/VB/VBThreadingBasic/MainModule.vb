' **************************** Module Header ******************************\
' Module Name:       MainModule.vb
' Project:           VBThreadingBasic
' Copyright (c) Microsoft Corporation.
' 
' This example demonstrates how to create threads using VB.NET in three 
' different approaches. And it also shows how to create a thread that require
' a parameter. In the target threads, it also shows how to use lock keyword 
' to ensure a code snippet executed without interruption.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/



Imports System.Threading


Module MainModule
    Private i As Integer = 0
    Private o As New Object()

    Sub Main()
        Console.WriteLine("Main Thread's managed thread id: " & Thread.CurrentThread.ManagedThreadId.ToString())

        ' The following region shows several ways to create a thread.
        ' The first way directly create a new thread manually.
        ' The second and third way run the target function from a thread pool.
        ' Second way has the best performance.
        ' The forth way invokes a parameterized function within the new thread.


        ' Method1: Create a thread by new Thread object.
        Dim ts1 As New ThreadStart(AddressOf ThreadFunction1)
        Dim t1 As New Thread(ts1)
        t1.Start()

        ' Method2: Create a thread by ThreadPool.QueueUserWorkItem.
        ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf ThreadFunction2))

        ' Method3: Create a thread by ThreadStart.BeginInvoke.
        Dim ts2 As New ThreadStart(AddressOf ThreadFunction3)
        ts2.BeginInvoke(Nothing, Nothing)

        ' Method4: Create a thread with parameters.
        Dim pts As New ParameterizedThreadStart(AddressOf ThreadFunction4)
        Dim t2 As New Thread(pts)
        t2.Start("Message")


        Console.ReadKey()
    End Sub

    Private Sub ThreadFunction1()
        SyncLock o
            Console.WriteLine(vbCrLf & "Method1: Current thread's managed thread id: " & Thread.CurrentThread.ManagedThreadId.ToString())
            Console.WriteLine((i).ToString())
            i += 1
        End SyncLock
    End Sub

    Private Sub ThreadFunction2(ByVal stateInfo As Object)
        SyncLock o
            Console.WriteLine(vbCrLf & "Method2: Current thread's managed thread id: " & Thread.CurrentThread.ManagedThreadId.ToString())
            Console.WriteLine((i).ToString())
            i += 1
        End SyncLock
    End Sub

    Private Sub ThreadFunction3()
        SyncLock o
            Console.WriteLine(vbCrLf & "Method3: Current thread's managed thread id: " & Thread.CurrentThread.ManagedThreadId.ToString())
            Console.WriteLine((i).ToString())
            i += 1
        End SyncLock
    End Sub

    Private Sub ThreadFunction4(ByVal message As Object)
        SyncLock o
            Console.WriteLine(vbCrLf & "Method4: Current thread's managed thread id: " & Thread.CurrentThread.ManagedThreadId.ToString() & vbTab & message)
            Console.WriteLine((i).ToString())
            i += 1
        End SyncLock
    End Sub
End Module

'**************************** Module Header ******************************\
' Module Name:  DirtyReadThreads.vb
' Project:      VBDataIsolationLevel
' Copyright (c) Microsoft Corporation.
' 
' In this application, we will demonstrate how to use the IsolationLevel 
' Enumeration in DbTransaction.
' In this class, we will demonstrate if the specific transaction allows the Dirty 
' Read behavior.
' If the transaction allows the behavior, the threads will operate in the following 
' order:
' 1. In first thread, begin a transaction and add the Quantity value(ProductId=1);
' 2. In the second thread, read the Quantity value and add the value again;
' 3. Commit the transaction in second thread;
' 4. Roll back the transacton in first thread.
' If the transaction allows the behavior, the Quantity value will be added twice;
' or the Quantity value will be added once.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Data.SqlClient

Namespace VBDataIsolationLevel
	Friend NotInheritable Class DirtyReadThreads
        Private Sub New()
        End Sub
        Public Shared Sub DirtyReadFirstThread(ByVal connStrig As String, ByVal level As IsolationLevel)
            Console.WriteLine("Begin the DirtyReadFirstThread.....")

            Using conn As New SqlConnection(connStrig)
                                   Dim cmdText As String = "Use DbDataIsolationLevel; " & ControlChars.CrLf &
                        " Update dbo.Products set Quantity=Quantity+100 where ProductId=1;" & ControlChars.CrLf &
                        "WaitFor Delay '00:00:06';"

                conn.Open()

                Using tran As SqlTransaction = conn.BeginTransaction(level, "DirtyReadFirst")
                    Using command As New SqlCommand(cmdText, conn)
                        command.Transaction = tran

                        command.ExecuteNonQuery()
                    End Using

                    If tran IsNot Nothing Then
                        tran.Rollback()
                    End If
                End Using
            End Using

            Console.WriteLine("Exit from the DirtyReadFirstThread.....")
        End Sub

        Public Shared Sub DirtyReadSecondThread(ByVal connStrig As String, ByVal level As IsolationLevel)
            Console.WriteLine("Begin the DirtyReadSecondThread.....")

            Using conn As New SqlConnection(connStrig)
                    Dim cmdText As String = "Use DbDataIsolationLevel;" & ControlChars.CrLf &
                        "WaitFor Delay '00:00:03'; " & ControlChars.CrLf &
                        "Declare @qty int;" & ControlChars.CrLf &
                        "select @qty=Quantity from dbo.Products where ProductId=1;" & ControlChars.CrLf &
                        "Update dbo.Products set Quantity=@qty+100 where ProductId=1;"

                conn.Open()

                Using tran As SqlTransaction = conn.BeginTransaction(level, "DirtyReadSecond")
                    Using command As New SqlCommand(cmdText, conn)
                        command.Transaction = tran

                        command.ExecuteNonQuery()
                    End Using
                    tran.Commit()
                End Using
            End Using

            Console.WriteLine("Exit from the DirtyReadSecondThread.....")
        End Sub
    End Class
End Namespace

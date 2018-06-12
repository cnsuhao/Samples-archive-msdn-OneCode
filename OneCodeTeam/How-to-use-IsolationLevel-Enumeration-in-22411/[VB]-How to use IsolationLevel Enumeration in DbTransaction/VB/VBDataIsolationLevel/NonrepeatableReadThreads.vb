'**************************** Module Header ******************************\
' Module Name:  NonrepeatableReadThreads.vb
' Project:      VBDataIsolationLevel
' Copyright (c) Microsoft Corporation.
' 
' In this application, we will demonstrate how to use the IsolationLevel 
' Enumeration in DbTransaction.
' In this class, we will demonstrate if the specific transaction allows the Nonrepeatable 
' Read behavior.
' If the transaction allows the behavior, the threads will operate in the following 
' order:
' 1. In first thread, select the product(ProductId=1);
' 2. In the second thread, update the Quantity value(ProductId=1);
' 3. Commit the transaction in second thread;
' 4. Select the product again.
' 5. Commit the transaction in first thread;
' If the transaction allows the behavior, the two Select operations will get the 
' different results; or the two Select operations will get the same result.
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
    Friend NotInheritable Class NonrepeatableReadThreads
        Private Sub New()
        End Sub
        Public Shared Sub NonrepeatableReadFirstThread(ByVal connStrig As String, ByVal level As IsolationLevel)
            Console.WriteLine("Begin the NonrepeatableReadFirstThread.....")

            Using conn As New SqlConnection(connStrig)
                Dim cmdText As String = "Use DbDataIsolationLevel; " & ControlChars.CrLf &
                    "Select ProductId,ProductName,Quantity,Price" & ControlChars.CrLf &
                    "from dbo.Products" & ControlChars.CrLf &
                    "where ProductId=1" & ControlChars.CrLf &
                    "        WaitFor Delay '00:00:06';" & ControlChars.CrLf &
                    "Select ProductId,ProductName,Quantity,Price" & ControlChars.CrLf &
                    "from dbo.Products" & ControlChars.CrLf &
                    "where ProductId=1"

                conn.Open()

                Using tran As SqlTransaction = conn.BeginTransaction(level, "NonrepeatableReadFirst")
                    Using command As New SqlCommand(cmdText, conn)
                        command.Transaction = tran

                        Using reader As SqlDataReader = command.ExecuteReader()
                            Dim isFirstReader As Boolean = True
                            Do
                                Console.WriteLine("It's the result of {0} read:", If(isFirstReader, "first", "second"))
                                TransactionIsolationLevels.DisplayData(reader)
                                isFirstReader = Not isFirstReader
                            Loop While reader.NextResult() AndAlso Not isFirstReader
                        End Using
                    End Using

                    tran.Commit()
                End Using
            End Using

            Console.WriteLine("Exit from the NonrepeatableReadFirstThread.....")
        End Sub

        Public Shared Sub NonrepeatableReadSecondThread(ByVal connStrig As String, ByVal level As IsolationLevel)
            Console.WriteLine("Begin the NonrepeatableReadSecondThread.....")

            Using conn As New SqlConnection(connStrig)
                Dim cmdText As String = "Use DbDataIsolationLevel;" & ControlChars.CrLf &
                    "WaitFor Delay '00:00:03'; " & ControlChars.CrLf &
                    "Update dbo.Products set Quantity=Quantity+100 where ProductId=1;"

                conn.Open()

                Using tran As SqlTransaction = conn.BeginTransaction(level, "NonrepeatableReadSecond")
                    Using command As New SqlCommand(cmdText, conn)
                        command.Transaction = tran

                        command.ExecuteNonQuery()
                    End Using
                    tran.Commit()
                End Using
            End Using

            Console.WriteLine("Exit from the NonrepeatableReadSecondThread.....")
        End Sub
    End Class
End Namespace

'**************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBDataIsolationLevel
' Copyright (c) Microsoft Corporation.
' 
' In this application, we will demonstrate how to use the IsolationLevel 
' Enumeration in DbTransaction.
' We will show you which of the following behaviors are allowed in the different 
' isolation levels.
' 1. Dirty reads;
' 2. Non-repeatable reads;
' 3. Phantoms.
' We will execute the following up behaviors in the following isolation levels:
' 1. ReadUncommitted;
' 2. ReadCommitted;
' 3. RepeatableRead;
' 4. Serializable; 
' 5. Snapshot.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports VBDataIsolationLevel.My

Namespace VBDataIsolationLevel
    Friend Class MainModule
        <MTAThread()>
        Shared Sub Main(ByVal args() As String)
            Dim connString As String = MySettings.Default.MyConnectionString

            OperateDatabase.CreateDatabase(connString)
            Console.WriteLine()

            Console.WriteLine("Demonstrate the ReadUncommitted transaction: ")
            TransactionIsolationLevels.DemonstrateIsolationLevel(connString, IsolationLevel.ReadUncommitted)
            Console.WriteLine("-----------------------------------------------")

            Console.WriteLine("Demonstrate the ReadCommitted transaction: ")
            TransactionIsolationLevels.DemonstrateIsolationLevel(connString, IsolationLevel.ReadCommitted)
            Console.WriteLine("-----------------------------------------------")

            Console.WriteLine("Demonstrate the RepeatableRead transaction: ")
            TransactionIsolationLevels.DemonstrateIsolationLevel(connString, IsolationLevel.RepeatableRead)
            Console.WriteLine("-----------------------------------------------")

            Console.WriteLine("Demonstrate the Serializable transaction: ")
            TransactionIsolationLevels.DemonstrateIsolationLevel(connString, IsolationLevel.Serializable)
            Console.WriteLine("-----------------------------------------------")

            Console.WriteLine("Demonstrate the Snapshot transaction: ")
            OperateDatabase.SetSnapshot(connString, True)
            TransactionIsolationLevels.DemonstrateIsolationLevel(connString, IsolationLevel.Snapshot)
            Console.WriteLine("-----------------------------------------------")

            Console.WriteLine("Demonstrate the difference between the Snapshot and Serializable transactions:")
            TransactionIsolationLevels.DemonstrateBetweenSnapshotAndSerializable(connString)
            OperateDatabase.SetSnapshot(connString, False)
            Console.WriteLine()

            Console.WriteLine("Press any key to exit.....")
            Console.ReadKey()
        End Sub
    End Class
End Namespace

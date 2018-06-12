/****************************** Module Header ******************************\
Module Name:  Program.cs
Project:      CSDataIsolationLevel
Copyright (c) Microsoft Corporation.

In this application, we will demonstrate how to use the IsolationLevel 
Enumeration in DbTransaction.
We will show you which of the following behaviors are allowed in the different 
isolation levels.
1. Dirty reads;
2. Non-repeatable reads;
3. Phantoms.
We will execute the following up behaviors in the following isolation levels:
1. ReadUncommitted;
2. ReadCommitted;
3. RepeatableRead;
4. Serializable; 
5. Snapshot.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using CSDataIsolationLevel.Properties;

namespace CSDataIsolationLevel
{
    class Program
    {
        static void Main(string[] args)
        {
            String connString = Settings.Default.MyConnectionString;

            OperateDatabase.CreateDatabase(connString);
            Console.WriteLine();

            Console.WriteLine("Demonstrate the ReadUncommitted transaction: ");
            TransactionIsolationLevels.DemonstrateIsolationLevel(connString,
                System.Data.IsolationLevel.ReadUncommitted);
            Console.WriteLine("-----------------------------------------------");

            Console.WriteLine("Demonstrate the ReadCommitted transaction: ");
            TransactionIsolationLevels.DemonstrateIsolationLevel(connString,
                System.Data.IsolationLevel.ReadCommitted);
            Console.WriteLine("-----------------------------------------------");

            Console.WriteLine("Demonstrate the RepeatableRead transaction: ");
            TransactionIsolationLevels.DemonstrateIsolationLevel(connString,
                System.Data.IsolationLevel.RepeatableRead);
            Console.WriteLine("-----------------------------------------------");

            Console.WriteLine("Demonstrate the Serializable transaction: ");
            TransactionIsolationLevels.DemonstrateIsolationLevel(connString,
                System.Data.IsolationLevel.Serializable);
            Console.WriteLine("-----------------------------------------------");

            Console.WriteLine("Demonstrate the Snapshot transaction: ");
            OperateDatabase.SetSnapshot(connString, true);
            TransactionIsolationLevels.DemonstrateIsolationLevel(connString,
                System.Data.IsolationLevel.Snapshot);
            Console.WriteLine("-----------------------------------------------");

            Console.WriteLine("Demonstrate the difference between the Snapshot and Serializable transactions:");
            TransactionIsolationLevels.DemonstrateBetweenSnapshotAndSerializable(connString);
            OperateDatabase.SetSnapshot(connString, false);
            Console.WriteLine();

            Console.WriteLine("Press any key to exit.....");
            Console.ReadKey();
        }
    }
}

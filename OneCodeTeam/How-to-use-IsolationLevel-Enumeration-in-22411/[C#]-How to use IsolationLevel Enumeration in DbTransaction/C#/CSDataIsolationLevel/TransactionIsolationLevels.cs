/****************************** Module Header ******************************\
Module Name:  TransactionIsolationLevels.cs
Project:      CSDataIsolationLevel
Copyright (c) Microsoft Corporation.

In this application, we will demonstrate how to use the IsolationLevel 
Enumeration in DbTransaction.
We will show you which of the following behaviors are allowed in the different 
isolation levels.
1. Dirty reads;
2. Non-repeatable reads;
3. Phantoms.
The Serializable and Snapshot transactions get the same result in the following up
behaviors. In this file, we will show the difference between them.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Data;
using System.Threading;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CSDataIsolationLevel
{
    // Use the delegate to call the different threads.
    public delegate void AsyncAccessDatabase(String connString, IsolationLevel level);

    static class TransactionIsolationLevels
    {
        /// <summary>
        /// In this method, we will demonstrate if the specific transaction allows the 
        /// following behaviors:
        /// 1. Dirty reads;
        /// 2. Non-repeatable reads;
        /// 3. Phantoms.
        /// </summary>
        public static void DemonstrateIsolationLevel(String connString, IsolationLevel level)
        {
            // Before connect the database, recreate the table.
            OperateDatabase.CreateTable(connString);
            DemonstrateIsolationLevel(connString, level, DirtyReadThreads.DirtyReadFirstThread,
                DirtyReadThreads.DirtyReadSecondThread);
            DisplayData(connString);
            Console.WriteLine();

            OperateDatabase.CreateTable(connString);
            DemonstrateIsolationLevel(connString, level,
                NonrepeatableReadThreads.NonrepeatableReadFirstThread,
                NonrepeatableReadThreads.NonrepeatableReadSecondThread);
            Console.WriteLine();

            OperateDatabase.CreateTable(connString);
            DemonstrateIsolationLevel(connString, level, PhantomReadThreads.PhantomReadFirstThread,
                PhantomReadThreads.PhantomReadSecondThread);
            Console.WriteLine();
        }

        /// <summary>
        /// In this method, we will demonstrate if the specific transaction allows the 
        /// specific behaviors.
        /// </summary>
        public static void DemonstrateIsolationLevel(String connString, IsolationLevel level,
            AsyncAccessDatabase firstThread, AsyncAccessDatabase secondThread)
        {
            Task[] tasks ={
                            Task.Factory.StartNew(()=>firstThread(connString, level)),
                            Task.Factory.StartNew(()=>secondThread(connString, level))
                        };

            Task.WaitAll(tasks);
        }

        /// <summary>
        /// In thie method, we will demonstrate the difference between the Serializable 
        /// and Snapshot transaction
        /// </summary>
        public static void DemonstrateBetweenSnapshotAndSerializable(String connString)
        {
            OperateDatabase.CreateTable(connString);

            Console.WriteLine("Exchange Vaules in the Snapshot transaction:");
            DemonstrateIsolationLevel(connString, IsolationLevel.Snapshot,
                ExchangeValuesThreads.ExchangeValuesFirstThread,
                ExchangeValuesThreads.ExchangeValuesSecondThread);
            DisplayData(connString);
            Console.WriteLine();

            Console.WriteLine("Cannot Exchange Vaules in the Serializable transaction:");
            OperateDatabase.CreateTable(connString);
            DemonstrateIsolationLevel(connString, IsolationLevel.Serializable,
                ExchangeValuesThreads.ExchangeValuesFirstThread,
                ExchangeValuesThreads.ExchangeValuesSecondThread);
            DisplayData(connString);
        }

        public static void DisplayData(String connString)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                String cmdText = @"Use DbDataIsolationLevel; 

                    Select ProductId,ProductName,Quantity,Price
                    from dbo.Products";

                conn.Open();

                using (SqlCommand command = new SqlCommand(cmdText, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DisplayData(reader);
                    }
                }
            }
        }

        public static void DisplayData(SqlDataReader reader)
        {
            Boolean isFirst = true;

            while (reader.Read())
            {
                if (isFirst)
                {
                    isFirst = false;

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write("{0,-12}   ", reader.GetName(i));
                    }
                    Console.WriteLine();
                }

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write("{0,-12}   ", reader[i]);
                }
                Console.WriteLine();
            }
        }
    }
}

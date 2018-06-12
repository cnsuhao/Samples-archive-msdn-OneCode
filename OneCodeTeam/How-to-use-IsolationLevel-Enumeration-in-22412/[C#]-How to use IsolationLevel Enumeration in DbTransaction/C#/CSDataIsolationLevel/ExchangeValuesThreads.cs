/****************************** Module Header ******************************\
Module Name:  ExchangeValuesThreads.cs
Project:      CSDataIsolationLevel
Copyright (c) Microsoft Corporation.

In this application, we will demonstrate how to use the IsolationLevel 
Enumeration in DbTransaction.
In this class, we will demonstrate the difference between the Serializable 
and Snapshot transaction
For the the Serializable transaction, threads will operate in the following 
order:
1. In first thread, get the Price of product(ProductId=2) and store in the 
variable;
2. In first thread, update the Price of product(ProductId=1) with the price 
of product(ProductId=2);
3. Commit the transaction in first thread;
4. In second thread, get the Price of product(ProductId=1) and store in the 
variable;
5. In second thread, update the Price of product(ProductId=2) with the price 
of product(ProductId=1);
6. Commit the transaction in second thread;
Now the values of the Price(ProductId=1 and ProductId=2) are as same as the 
original Price of Product(ProductId=2).

For the the Snapshot transaction, threads will operate in the following 
order:
1. In first thread, get the Price of product(ProductId=2) and store in the 
variable;
2. In first thread, update the Price of product(ProductId=1) with the price 
of product(ProductId=2);
3. In second thread, get the Price of product(ProductId=1) from the snapshot 
and store in the variable;
4. In second thread, update the Price of product(ProductId=2) with the price 
of product(ProductId=1);
5. Commit the transaction in second thread;
6. Commit the transaction in first thread;
Now we exchange the Price of products(ProductId=1 and ProductId=2).

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Data.SqlClient;
using System.Data;

namespace CSDataIsolationLevel
{
    static class ExchangeValuesThreads
    {
        public static void ExchangeValuesFirstThread(String connStrig, IsolationLevel level)
        {
            Console.WriteLine("Begin the ExchangeValuesFirstThread.....");

            using (SqlConnection conn = new SqlConnection(connStrig))
            {
                    String cmdText = @"Use DbDataIsolationLevel;

                    Declare @price money;
                    select @price=Price from dbo.Products where ProductId=2;

                    Update dbo.Products set Price=@price where ProductId=1;

                    WaitFor Delay '00:00:06'; ";

                    conn.Open();

                    using (SqlTransaction tran = conn.BeginTransaction(level, "ExchangeValuesFirst"))
                    {

                        using (SqlCommand command = new SqlCommand(cmdText, conn))
                        {
                            command.Transaction = tran;

                            command.ExecuteNonQuery();
                        }

                        tran.Commit();
                    }
            }

            Console.WriteLine("Exit from the ExchangeValuesFirstThread.....");
        }

        public static void ExchangeValuesSecondThread(String connStrig, IsolationLevel level)
        {
            Console.WriteLine("Begin the ExchangeValuesSecondThread.....");

            using (SqlConnection conn = new SqlConnection(connStrig))
            {
                    String cmdText = @"Use DbDataIsolationLevel;

                    WaitFor Delay '00:00:03'; 

                    Declare @price money;
                    select @price=Price from dbo.Products where ProductId=1;

                    Update dbo.Products set Price=@price where ProductId=2;";

                    conn.Open();

                    using (SqlTransaction tran = conn.BeginTransaction(level, "ExchangeValuesSecond"))
                    {
                        using (SqlCommand command = new SqlCommand(cmdText, conn))
                        {
                            command.Transaction = tran;

                            command.ExecuteNonQuery();
                        }
                        tran.Commit();
                    }
            }

            Console.WriteLine("Exit from the ExchangeValuesSecondThread.....");
        }
    }
}

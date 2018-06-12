/****************************** Module Header ******************************\
* Module Name:       Program.cs
* Project:           CSThreadingMonitor
* Copyright (c) Microsoft Corporation.
* 
* This sample shows how to use Monitor to synchronize threads
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/


using System;
using System.Threading;

namespace CSThreadingMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Result initialized to say there is no error.
            int result = 0;   
            Cell cell = new Cell();

            // Use cell for storage.
            // produce 20 items.
            CellProd prod = new CellProd(cell, 20);  
          
            // Use cell for storage.
            // consume 20 items
            CellCons cons = new CellCons(cell, 20);

            // Threads producer and consumer have been created, 
            // but not started at this point.
            Thread producer = new Thread(new ThreadStart(prod.ThreadRun));
            Thread consumer = new Thread(new ThreadStart(cons.ThreadRun));

            try
            {
                // Run both until done.
                producer.Start();
                consumer.Start();
               
                // threads producer and consumer have finished at this point.
                producer.Join();             
                consumer.Join();
               
            }
            catch (ThreadStateException e)
            {
                // Display text of exception
                Console.WriteLine(e);

                // Result says there is an error.
                result = 1;            
            }
            catch (ThreadInterruptedException e)
            { 
                // This exception means that the thread was interrupted during a Wait.
                Console.WriteLine(e);
               
                // Result says there is an error.
                result = 1;            
            
            }

            // Even though Main returns void, this provides a return code to 
            // the parent process.
            Environment.ExitCode = result;

        }
    }

    public class CellProd
    {
        // Field to hold cell object to be used.
        Cell cell;

        // Field for how many items to produce in cell.
        int quantity = 1;  

        public CellProd(Cell box, int request)
        {
            // Pass in what cell object to be used.
            cell = box;

            // Pass in how many items to produce in cell.
            quantity = request;  
        }
        public void ThreadRun()
        {
            // "producing"
            for (int looper = 1; looper <= quantity; looper++)
            {
                cell.WriteToCell(looper);  
            }
              
        }
    }

    public class CellCons
    {
        // Field to hold cell object to be used.
        Cell cell;

        // Field for how many items to consume from cell.
        int quantity = 1; 

        public CellCons(Cell box, int request)
        {
            // Pass in what cell object to be used.
            cell = box;

            // Pass in how many items to consume from cell.
            quantity = request;  
        }
        public void ThreadRun()
        {
            int valReturned; 
            
            // Consume the result by placing it in valReturned.
            for (int looper = 1; looper <= quantity; looper++)
            {
                valReturned = cell.ReadFromCell();
            }
              
        }
    }

    public class Cell
    {
        int cellContents;         // Cell contents
        bool readerFlag = false;  // State flag
        public int ReadFromCell()
        {
            lock (this)   // Enter synchronization block
            {
                if (!readerFlag)
                {            // Wait until Cell.WriteToCell is done producing
                    try
                    {
                        // Waits for the Monitor.Pulse in WriteToCell
                        Monitor.Wait(this);
                    }
                    catch (SynchronizationLockException e)
                    {
                        Console.WriteLine(e);
                    }
                    catch (ThreadInterruptedException e)
                    {
                        Console.WriteLine(e);
                    }
                }
                Console.WriteLine("Consume: {0}", cellContents);
                readerFlag = false;    // Reset the state flag to say consuming
                // is done.
                Monitor.Pulse(this);   // Pulse tells Cell.WriteToCell that
                // Cell.ReadFromCell is done.
            }   // Exit synchronization block
            return cellContents;
        }

        public void WriteToCell(int n)
        {
            // Enter synchronization block
            lock (this)  
            {
                // Wait until Cell.ReadFromCell is done consuming.
                if (readerFlag)
                {    
                    try
                    {
                        // Wait for the Monitor.Pulse in
                        Monitor.Wait(this); 
                        // ReadFromCell
                    }
                    catch (SynchronizationLockException e)
                    {
                        Console.WriteLine(e);
                    }
                    catch (ThreadInterruptedException e)
                    {
                        Console.WriteLine(e);
                    }
                }
                cellContents = n;
                Console.WriteLine("Produce: {0}", cellContents);

                // Reset the state flag to say producing is done.
                readerFlag = true;

                // Pulse tells Cell.ReadFromCell that Cell.WriteToCell is done.
                // Exit synchronization block
                Monitor.Pulse(this); 
                
            }  
        }
    }
}

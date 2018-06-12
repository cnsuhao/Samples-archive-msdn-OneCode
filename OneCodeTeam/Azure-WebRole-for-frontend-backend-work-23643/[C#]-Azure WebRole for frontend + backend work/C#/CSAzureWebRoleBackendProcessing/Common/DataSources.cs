/****************************** Module Header ******************************\
* Project Name:   CSAzureWebRoleBackendProcessing
* Module Name:    Common
* File Name:      DataSources.cs
* Copyright (c) Microsoft Corporation
*
* This class provides methods to access Table storage and Queue storage.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
*
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using System.Diagnostics;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;

namespace CSAzureWebRoleBackendProcessing.Common
{
    public class DataSources
    {
        static CloudStorageAccount _storageAccount
        { 
            get
            {
                return CloudStorageAccount.Parse(RoleEnvironment.GetConfigurationSettingValue("DataConnectionString"));
            } 
        }

        WordDataContext _context;
        CloudQueueClient _queueStorage;
        static readonly string _queueName = "words";
        public CloudQueue WordQuque
        {
            get
            {
                return _queueStorage.GetQueueReference(_queueName);
            }
        }

        /// <summary>
        /// Instantiate a new DataSources object.
        /// This method will throw exception if the storage account is wrong.
        /// </summary>
        public DataSources()
        {
            CloudTableClient client = new CloudTableClient(new Uri(_storageAccount.TableEndpoint.AbsoluteUri), _storageAccount.Credentials);
            // Instantiate a table service context.
            _context = new WordDataContext(client);

            // Instantiate a queue client for use.
            _queueStorage = _storageAccount.CreateCloudQueueClient();
        }

        public IEnumerable<WordEntry> GetWordEntries()
        {
            var results = from word in _context.WordEntry select word;
            return results;
        }

        public WordEntry GetWordEntry(string partitionKey, string rowKey)
        {
            var results = from word in _context.WordEntry
                          where word.PartitionKey == partitionKey && word.RowKey == rowKey
                          select word;
            return results.FirstOrDefault();
        }

        public void AddWordEntry(WordEntry newItem)
        {
            _context.AddObject("WordEntry", newItem);
            _context.SaveChanges();
        }

        public void UpdateWordEntry(WordEntry updatedItem)
        {
            _context.UpdateObject(updatedItem);
            _context.SaveChanges();
        }

        public void QueueMessage(string message)
        {
            WordQuque.AddMessage(new CloudQueueMessage(message));
        }

        static DataSources()
        {
            // Cancel the restart of instances when the service configuration is updated.
            RoleEnvironment.Changing += (sender, e) =>
            {
                e.Cancel = false;
            };
            RoleEnvironment.Changed += (sender, e) =>
            {
                // Initialize the storage again after the configuration is changed.
                initializeStorage();
            };

            // Firstly Initialize the storage at the first start.
            initializeStorage();
        }
        static void initializeStorage()
        {
            try
            {
                //Create the Table for storing words.
                CloudTableClient tableStorage = _storageAccount.CreateCloudTableClient();
                CloudTable table=tableStorage.GetTableReference("WordEntry");
                table.CreateIfNotExists();

                // Create the queue for communication if it is not exist.
                CloudQueueClient queueStorage = _storageAccount.CreateCloudQueueClient();
                CloudQueue queue = queueStorage.GetQueueReference(_queueName);
                queue.CreateIfNotExists();
            }
            // This method is running in the backend.
            // It will never crash even though there is a big error.
            catch (Exception ex) 
            {
                Trace.TraceError("Exception when processing queue item. Message: '{0}'", ex.Message);
            }
        }
    }
}
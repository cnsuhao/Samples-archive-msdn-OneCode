/****************************** Module Header ******************************\
Module Name:  FileDataSource.cs
Project:      TableStorageManager
Copyright (c) Microsoft Corporation.
 
The sample code demonstrates how to backup Azure Storage in Cloud. Though 
Windows Azure Platform have 3 copies for our data, but this is only physical
backup, if a logical errors occurred that all copies of storage would been
modified, so this sample shows how to protect our important data with code.

The FileDataSource package the bottom layer methods(about cloud account,
TableServiceContext, credentials, etc).

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
All other rights reserved.
 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using System.Data.Services.Client;

namespace TableStorageManager
{
    public class FileDataSource
    {
        private static CloudStorageAccount account;
        private FileContext context;
        private string tableName;

        public FileDataSource(string tableName)
        {
            // Create table storage client via cloud account.
            account = CloudStorageAccount.FromConfigurationSetting("StorageConnections");
            CloudTableClient client = account.CreateCloudTableClient();
            client.CreateTableIfNotExist(tableName);
            this.tableName = tableName;

            // Table context properties.
            context = new FileContext(account.TableEndpoint.AbsoluteUri, account.Credentials);
            context.RetryPolicy = RetryPolicies.Retry(3, TimeSpan.FromSeconds(1));
            context.IgnoreResourceNotFoundException = true;
            context.IgnoreMissingProperties = true;
            
        }

        /// <summary>
        /// Get all entities method.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FileEntity> GetAllEntities()
        {
            var list = from m in this.context.GetEntities
                       select m;
            return list;
        }

        /// <summary>
        /// Get table rows by partitionKey.
        /// </summary>
        /// <param name="partitionKey"></param>
        /// <returns></returns>
        public IEnumerable<FileEntity> GetEntities(string partitionKey)
        {
            var list = from m in this.context.GetEntities
                       where m.PartitionKey == partitionKey
                       select m;
            return list;
        }

        /// <summary>
        /// Get specify entity.
        /// </summary>
        /// <param name="partitionKey"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public FileEntity GetEntitiesByName(string partitionKey, string fileName)
        {
            var list = from m in this.context.GetEntities
                       where m.PartitionKey == partitionKey && m.FileName == fileName
                       select m;
            if (list.Count() > 0)
                return list.First<FileEntity>();
            else
                return null;
        }

        /// <summary>
        /// Add an entity.
        /// </summary>
        /// <param name="entity"></param>
        public void AddFile(FileEntity entity)
        {
            this.context.AddObject(this.tableName, entity);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Add multiple entities.
        /// </summary>
        /// <param name="entities"></param>
        public void AddNumbersOfFiles(List<FileEntity> entities)
        {
            if (entities.Count() > 0)
            {
                int totleNumbers = entities.Count();
                int uploadTimes = entities.Count() / 100;
                if ((entities.Count() % 100) > 0)
                    uploadTimes += 1;
                for (int i = 0; i < uploadTimes; i++)
                {
                    if (i == uploadTimes - 1)
                    {
                        for (int j = i * 100; j < totleNumbers; j++)
                        {
                            this.context.AddObject(this.tableName, entities[j]);
                        }
                        this.context.SaveChanges();
                    }
                    else
                    {
                        for (int j = i * 100; j < (i + 1) * 100; j++)
                        {
                            this.context.AddObject(this.tableName, entities[j]);
                        }
                        this.context.SaveChanges();
                    }
                }
            }

        }

        /// <summary>
        /// Make a judgment to check file is exists.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="partitionKey"></param>
        /// <returns></returns>
        public bool FileExists(string filename, string partitionKey)
        {
            IEnumerable<FileEntity> list = from m in this.context.GetEntities
                       where m.FileName == filename && m.PartitionKey == partitionKey
                       select m;
            if (list.Count()>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

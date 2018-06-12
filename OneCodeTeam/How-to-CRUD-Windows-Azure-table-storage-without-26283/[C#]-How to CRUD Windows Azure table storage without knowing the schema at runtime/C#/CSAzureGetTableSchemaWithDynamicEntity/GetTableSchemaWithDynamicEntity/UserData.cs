/****************************** Module Header ******************************\
 * Module Name:  UserData.cs
 * Project:      GetTableSchemaWithDynamicEntity
 * Copyright (c) Microsoft Corporation.
 * 
 * UserData class.
 *  
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetTableSchemaWithDynamicEntity
{
    public class UserData
    {
        public List<DynamicTableEntity> UserDataList;

        public UserData()
        {

            UserDataList = new List<DynamicTableEntity>();

            DynamicTableEntity entity1 = new DynamicTableEntity();
            Dictionary<string, EntityProperty> data1 = new Dictionary<string, EntityProperty>();
            data1.Add("Name", new EntityProperty("Sam"));
            data1.Add("Gender", new EntityProperty(true));
            data1.Add("Age", new EntityProperty(18));
            entity1.Properties = data1;
            entity1.PartitionKey = "Partition1";
            entity1.RowKey = "1";
            UserDataList.Add(entity1);

            DynamicTableEntity entity2 = new DynamicTableEntity();
            Dictionary<string, EntityProperty> data2 = new Dictionary<string, EntityProperty>();
            data2.Add("Name", new EntityProperty("Lucy"));
            data2.Add("Gender", new EntityProperty(false));
            data2.Add("Age", new EntityProperty(20));
            data2.Add("Email", new EntityProperty("Lucy@hotmail.com"));
            entity2.Properties = data2;
            entity2.PartitionKey = "Partition1";
            entity2.RowKey = "2";
            UserDataList.Add(entity2);
        }
    }
}
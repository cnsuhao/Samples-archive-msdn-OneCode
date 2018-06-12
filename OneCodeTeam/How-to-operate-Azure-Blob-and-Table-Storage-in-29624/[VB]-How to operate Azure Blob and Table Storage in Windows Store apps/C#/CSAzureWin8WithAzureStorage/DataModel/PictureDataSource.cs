/***************************** Module Header ******************************\
* Module Name:	PictureDataSource.cs
* Project:		CSAzureWin8WithAzureStorage
* Copyright (c) Microsoft Corporation.
* 
* This sample shows how to store images to Windows Azure Blob storage,
* and save image information to table storage.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\**************************************************************************/

using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;
using Windows.Storage;
using System.Collections.ObjectModel;


namespace CSAzureWin8WithAzureStorage.Model
{
    public class PictureDataSource
    {

        public static PictureDataSource pictureDataSource = new PictureDataSource();
        private ObservableCollection<PictureViewModel> allImages = new ObservableCollection<PictureViewModel>();
        

        public PictureDataSource()
        {
            GetPictureInfoFromTableStorage();
        }

        public  ObservableCollection<PictureViewModel> AllImages
        {
            get { return allImages; }
        }
       public static async Task<bool> UploadPictureToCloud(PictureViewModel pictureViewModel)
        {
           
            try
            {
                var blockBlobClient = App.account.CreateCloudBlobClient();
                var contianer = blockBlobClient.GetContainerReference(App.contianerName);
                await contianer.CreateIfNotExistsAsync();
                CloudBlockBlob picture = contianer.GetBlockBlobReference(Guid.NewGuid().ToString());
                using (var filestream = await pictureViewModel.PictureFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    await picture.UploadFromStreamAsync(filestream);
                    pictureViewModel.PictureUrl = picture.Uri.ToString();
                }
                

                var tableClient = App.account.CreateCloudTableClient();
                var table = tableClient.GetTableReference(App.tableName);
                await table.CreateIfNotExistsAsync();

                var operation = TableOperation.Insert(pictureViewModel.PictureTableEntity);
                await table.ExecuteAsync(operation);

                pictureDataSource.AllImages.Add(pictureViewModel);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
          
        }

       public  async void GetPictureInfoFromTableStorage()
       {
           var client = App.account.CreateCloudTableClient();
           var table = client.GetTableReference(App.tableName);
           await table.CreateIfNotExistsAsync();

           var results = await table.ExecuteQuerySegmentedAsync(new TableQuery(), null);
           foreach (var item in results)
           {
               pictureDataSource.allImages.Add(new PictureViewModel() { PictureTableEntity = item });
           }
       }

       public static ObservableCollection<PictureViewModel> GetAllImages()
        {
            return pictureDataSource.AllImages;
        }

       public static async Task<bool> DeletePictureFormCloud(PictureViewModel pictureViewModel)
       {
           try
           {
               var blob = new CloudBlockBlob(new Uri(pictureViewModel.PictureUrl), App.credentials);
               await blob.DeleteAsync();

               var tableClient = App.account.CreateCloudTableClient();
               var table = tableClient.GetTableReference(App.tableName);

               var operation = TableOperation.Delete(pictureViewModel.PictureTableEntity);
               await table.ExecuteAsync(operation);

               pictureDataSource.AllImages.Remove(pictureViewModel);
               return true;
           }
           catch (Exception)
           {
               throw;
           }
       }

       
    }
}

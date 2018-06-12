/**************************** Module Header ********************************\
* Module Name:    PictureDataSource.cs
* Project:        CSAzureWPImageUpload
* Copyright (c) Microsoft Corporation
*
* PictureDataSource Class.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/
using CSAzureWPImageUpload.Models;
using CSAzureWPImageUpload.ViewModels;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CSAzureWPImageUpload.DataSource
{
    public class PictureDataSource
    {
        private static PictureDataSource pictureDataSource = new PictureDataSource();

        private IMobileServiceTable<Picture> imageTable =  App.MobileService.GetTable<Picture>();

        private ObservableCollection<PictureViewModel> allPictures = new ObservableCollection<PictureViewModel>();

        public  PictureDataSource()
        {
            Load();
        }
        public ObservableCollection<PictureViewModel> AllPictures
        {
            get { return this.allPictures; }
        }

        public static ObservableCollection<PictureViewModel> GetAllPictures()
        {
            return pictureDataSource.allPictures;
        }


        private  async void Load()
        {
            var pictures= await LoadAllPictures();
            foreach (var image in pictures)
            {
                this.allPictures.Add(new PictureViewModel(image.Id, image.Name, new Uri(image.ImageUrl), image.Description));
            }
   
        }
        private async Task<List<Picture>> LoadAllPictures()
        {
            while (true)
            {
                try
                {
                    var pictures = await this.imageTable.ToListAsync();
                    return pictures; 
                }
                catch (Exception e)
                {
                    //TODO:May throw NetWorkException
                }
            }
        }

        public static async Task UploadPicture(UploadViewModel uploadForm)
        {
            //// Add picture item to trigger insert operation which returns the SAS for the blob images
            try
            {
                var guid = Guid.NewGuid();
                var pictureItem = new Picture();
                pictureItem.Name = uploadForm.PictureName;
                pictureItem.Description = uploadForm.PictureDescription;
                pictureItem.FileName = guid.ToString();

              
                var pictureTable = App.MobileService.GetTable<Picture>();
                await pictureTable.InsertAsync(pictureItem);

                var containerName = "mypictures";

                //// Upload picture directly to blob storage using SAS and the Storage Client library for Windows 8 
                //// Get a stream of the image just taken 
                using (Stream fileStream = await uploadForm.PictureFile.OpenStreamForReadAsync())
                {
                    await BlobStorageHelper.UploadBlob(fileStream, pictureItem.FileName, pictureItem.ImageUrl, containerName);
                }

                //// Update the picture Table to remove the SAS from the URL 
                pictureItem.ImageUrl = pictureItem.ImageUrl.Substring(0, pictureItem.ImageUrl.IndexOf('?'));
                await pictureTable.UpdateAsync(pictureItem);

                var pictures = GetAllPictures();
                pictures.Add(new PictureViewModel(pictureItem.Id, pictureItem.Name, new Uri(pictureItem.ImageUrl), pictureItem.Description));
            }
            catch (Exception e)
            {
                //TODO:May throw NetWorkException
                throw;
            }  
        }
    }
}

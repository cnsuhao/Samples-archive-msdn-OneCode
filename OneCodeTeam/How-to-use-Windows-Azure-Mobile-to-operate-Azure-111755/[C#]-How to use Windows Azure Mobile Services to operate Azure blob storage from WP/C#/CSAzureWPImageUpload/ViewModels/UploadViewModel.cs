/**************************** Module Header ********************************\
* Module Name:    UploadViewModel.xaml.cs
* Project:        CSAzureWPImageUpload
* Copyright (c) Microsoft Corporation
*
* UploadViewModel.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/
using CSAzureWPImageUpload.Common;
using Windows.Storage;

namespace CSAzureWPImageUpload.ViewModels
{
    public class UploadViewModel : BindableBase
    {
        private string pictureName;
        private string pictureDescription;
        
        private string newAlbumName;
        private StorageFile pictureFile;
       

        public StorageFile PictureFile
        {
            get { return pictureFile; }
            set { pictureFile = value; }
        }
        

        public string NewAlbumName
        {
            get { return newAlbumName; }
            set { newAlbumName = value; }
        }

        public string PictureDescription
        {
            get { return pictureDescription; }
            set { pictureDescription = value; }
        }


        public string PictureName
        {
            get { return pictureName; }
            set { this.SetProperty(ref pictureName, value); }
        }
    }
}

/**************************** Module Header ********************************\
* Module Name:    PictureViewModel.xaml.cs
* Project:        CSAzureWPImageUpload
* Copyright (c) Microsoft Corporation
*
* PictureViewModel.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/
using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CSAzureWPImageUpload.ViewModels
{
    public class PictureViewModel : BaseViewModel
    {
        private string description = string.Empty;
        private ImageSource image = null;
        private Uri imageUrl = null;
        

        public PictureViewModel(string uniqueId, string title, Uri imageUrl, string description):base(uniqueId,title)  
        {
            
            this.description = description;
            this.imageUrl = imageUrl;
            this.Title = title;
        }

        public string Description
        {
            get { return this.description; }
            set { this.SetProperty(ref this.description, value); }
        }

        public ImageSource Image
        {
            get
            {
                if (this.image == null && this.imageUrl != null)
                {
                    this.image = new BitmapImage(this.imageUrl);
                }

                return this.image;
            }

            set
            {
                this.imageUrl = null;
                this.SetProperty(ref this.image, value);
            }
        }
        public void SetImage(Uri url)
        {
            this.image = null;
            this.imageUrl = url;
            this.OnPropertyChanged("Image");
        }

        
    }
}

/****************************** Module Header ******************************\
* Module Name:	BitmapHelper.cs
* Project:		VideoStoryCreator
* Copyright (c) Microsoft Corporation.
* 
* A helper class that resized the images.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;
using Microsoft.Xna.Framework.Media;

namespace VideoStoryCreator
{
    public static class BitmapHelper
    {
        // Currently we hard code the target resolution.
        // Consider to support user configuration in the future.
        // TODO: Move all hard coded value to a central place.
        internal static int ResizedImageWidth = 800;
        internal static int ResizedImageHeight = 600;

        /// <summary>
        /// Get the original image from XNA media library.
        /// And resize it to the target resolution.
        /// </summary>
        /// <param name="name">The name of the image.</param>
        /// <returns>A stream representing the resized image, in jpeg format.</returns>
        public static Stream GetResizedImage(string name)
        {
            MediaLibrary mediaLibrary = new MediaLibrary();
            PictureCollection pictureCollection = mediaLibrary.Pictures;

            Picture picture = pictureCollection.Where(p => p.Name == name).FirstOrDefault();
            if (picture == null)
            {
                throw new InvalidOperationException(string.Format("Cannot load the picture {0}. Possibly the picture has been deleted.", name));
            }
            Stream originalImageStream = picture.GetImage();
            BitmapImage bmp = new BitmapImage();
            bmp.SetSource(originalImageStream);
            WriteableBitmap originalImage = new WriteableBitmap(bmp);
            MemoryStream targetStream = new MemoryStream();
            originalImage.SaveJpeg(targetStream, ResizedImageWidth, ResizedImageHeight, 0, 100);

            // Now that the image has been turned into a WriteableBitmap, the original image stream can be closed.
            originalImageStream.Close();

            targetStream.Position = 0;
            return targetStream;
        }
    }
}

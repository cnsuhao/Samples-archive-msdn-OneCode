/****************************** Module Header ******************************\
* Module Name:	PreviewPage.xaml.cs
* Project:		VideoStoryCreator
* Copyright (c) Microsoft Corporation.
* 
* This page allows the user to preview the story using DispatcherTimer and Storyboard.
* It doesn't actually encode the story to a video.
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
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework.Media;
using VideoStoryCreator.Models;

namespace VideoStoryCreator
{
    // Since PhoneApplicationPage is not CLS compliant, we have to set it to false in the derived class.
    [CLSCompliant(false)]
    public partial class PreviewPage : PhoneApplicationPage
    {
        private DispatcherTimer _dispatcherTimer;
        private int _currentImageIndex;

        public PreviewPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            int mediaCount = App.MediaCollection.Count;
            if (mediaCount < 2)
            {
                throw new InvalidOperationException("You must choose at least two media.");
            }

            // Configure the foreground/background images.
            if (App.MediaCollection[0].ResizedImage != null)
            {
                this.foregroundImage.Source = App.MediaCollection[0].ResizedImage;
            }
            else
            {
                WriteableBitmap bmp = this.GetResizedImage(App.MediaCollection[0]);
                this.foregroundImage.Source = bmp;
            }
            if (App.MediaCollection[1].ResizedImage != null)
            {
                this.backgroundImage.Source = App.MediaCollection[1].ResizedImage;
            }
            else
            {
                WriteableBitmap bmp = this.GetResizedImage(App.MediaCollection[1]);
                this.backgroundImage.Source = bmp;
            }

            // Set _currentImageIndex to 2, so the next time we'll begin with App.MediaCollection[2].
            this._currentImageIndex = 2;

            this._dispatcherTimer = new DispatcherTimer();
            this._dispatcherTimer.Interval = App.MediaCollection[0].PhotoDuration;
            this._dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            this._dispatcherTimer.Start();
        }

        void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            this.backgroundImage.Opacity = 1;
            VideoStoryCreator.Transitions.ITransition transition = App.MediaCollection[this._currentImageIndex - 1].Transition;

            // Display the transition if it's not null.
            // This task is delegated to the individual transition class.
            if (transition != null)
            {
                transition.ForegroundElement = this.foregroundImage;
                transition.BackgroundElement = this.backgroundImage;
                transition.TransitionCompleted += new EventHandler(TransitionCompleted);
                transition.Begin();
                this._dispatcherTimer.Stop();
            }
            // No transition. Simply start to display the next image.
            else
            {
                this._dispatcherTimer.Stop();
                this.backgroundImage.SetValue(Canvas.ZIndexProperty, 2);
                this.foregroundImage.SetValue(Canvas.ZIndexProperty, 0);
                this.GoToNext();
            }
        }

        void TransitionCompleted(object sender, EventArgs e)
        {
            VideoStoryCreator.Transitions.ITransition transition = (VideoStoryCreator.Transitions.ITransition)sender;

            // Modify the z-index if it's not already modified by the transition.
            if (!transition.ImageZIndexModified)
            {
                this.backgroundImage.SetValue(Canvas.ZIndexProperty, 2);
                this.foregroundImage.SetValue(Canvas.ZIndexProperty, 0);
            }
            transition.Stop();

            this.GoToNext();
        }

        /// <summary>
        /// Display the next image.
        /// </summary>
        private void GoToNext()
        {
            // Switch the reference so the logic is clearer.
            // When passed to the transition class, foreground image is the current image,
            // while background image is the new image to display.
            Image tempImg = this.foregroundImage;
            this.foregroundImage = this.backgroundImage;
            this.backgroundImage = tempImg;

            // More images available, continue the animation.
            if (_currentImageIndex < App.MediaCollection.Count)
            {
                if (App.MediaCollection[this._currentImageIndex].ResizedImage != null)
                {
                    this.backgroundImage.Source = App.MediaCollection[this._currentImageIndex].ResizedImage;
                }
                else
                {
                    WriteableBitmap bmp = this.GetResizedImage(App.MediaCollection[this._currentImageIndex]);
                    this.backgroundImage.Source = bmp;
                }

                this._dispatcherTimer.Interval = App.MediaCollection[_currentImageIndex].PhotoDuration;
                this._currentImageIndex++;
                this._dispatcherTimer.Start();
            }
        }

        /// <summary>
        /// Get the original image from XNA media library.
        /// And resize it to the target resolution.
        /// Invokes BitmapHelper.GetResizedImage internally.
        /// The difference is this method returns WriteableBitmap,
        /// while BitmapHelper.GetResizedImage returns Stream.
        /// This method also sets Photo.ResizedImage and Photo.ResizedImageStream.
        /// </summary>
        /// <param name="photo">The photo that needs to be resized.</param>
        /// <returns>A WriteableBitmap representing the resized image.</returns>
        private WriteableBitmap GetResizedImage(Photo photo)
        {
            Stream resizedImageStream = BitmapHelper.GetResizedImage(photo.Name);
            WriteableBitmap resizedImage = new WriteableBitmap(BitmapHelper.ResizedImageWidth, BitmapHelper.ResizedImageHeight);
            resizedImage.SetSource(resizedImageStream);
            photo.ResizedImageStream = resizedImageStream;
            photo.ResizedImage = resizedImage;
            return resizedImage;
        }
    }
}
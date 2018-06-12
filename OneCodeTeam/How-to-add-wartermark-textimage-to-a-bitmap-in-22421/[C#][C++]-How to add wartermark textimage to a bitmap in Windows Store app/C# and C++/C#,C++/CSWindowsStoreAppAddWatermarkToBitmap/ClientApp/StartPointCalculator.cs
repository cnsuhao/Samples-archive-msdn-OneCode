/****************************** Module Header ******************************\
 * Module Name:  StartPointCalculator.cs
 * Project:      ClientApp
 * Copyright (c) Microsoft Corporation.
 * 
 * This class exposes some properties for data binding. It's used to set the
 * position of the start point indicator.
 *
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System.ComponentModel;

namespace ClientApp
{
    public class StartPointCalculator : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private const string OffsetXInpercentName = "OffsetXInPercent";
        private const string OffsetYInpercentName = "OffsetYInPercent";
        private const string StartPointOffsetXName = "StartPointOffsetX";
        private const string StartPointOffsetYName = "StartPointOffsetY";
        private const string BackgroundImageActualWidthName= "BackgroundImageActualWidth";
        private const string BackgroundImageActualHeightName = "BackgroundImageActualHeight";
        private const string ImageContainerActualWidthName = "ImageContainerActualWidth";
        private const string ImageContainerActualHeightName = "ImageContainerActualHeight";

        public StartPointCalculator()
        {
        }

        double backGroundImageActualHeight;
        public double BackgroundImageActualHeight
        {
            get { return backGroundImageActualHeight; }
            set
            {
                if (backGroundImageActualHeight != value)
                {
                    backGroundImageActualHeight = value;
                    this.OnPropertyChanged(BackgroundImageActualHeightName);
                }
            }
        }

        double backGroundImageActualWidth;
        public double BackgroundImageActualWidth
        {
            get { return backGroundImageActualWidth; }
            set
            {
                if (backGroundImageActualWidth != value)
                {
                    backGroundImageActualWidth = value;
                    this.OnPropertyChanged(BackgroundImageActualWidthName);
                }
            }
        }

        double imageContainerActualWidth;
        public double ImageContainerActualWidth
        {
            get { return imageContainerActualWidth; }
            set
            {
                if (imageContainerActualWidth != value)
                {
                    imageContainerActualWidth = value;
                    this.OnPropertyChanged(ImageContainerActualWidthName);
                }
            }
        }

        double imageContainerActualHeight;
        public double ImageContainerActualHeight
        {
            get { return imageContainerActualHeight; }
            set
            {
                if (imageContainerActualHeight != value)
                {
                    imageContainerActualHeight = value;
                    this.OnPropertyChanged(ImageContainerActualHeightName);
                }
            }
        }

        // offsetXInpercent should be in the range of 0.0 - 1.0;
        private double offsetXInPercent;
        public double OffsetXInPercent
        {
            get { return offsetXInPercent; }
            set
            {
                if (offsetXInPercent != value)
                {
                    offsetXInPercent = value;
                    this.OnPropertyChanged(OffsetXInpercentName);
                }
            }
        }

        // offsetYInpercent should be in the range in the range of 0.0 - 1.0;
        private double offsetYInPercent;
        public double OffsetYInPercent
        {
            get { return offsetYInPercent; }
            set
            {
                if (offsetYInPercent != value)
                {
                    offsetYInPercent = value;
                    this.OnPropertyChanged(OffsetYInpercentName);
                }
            }
        }

        private double startPointOffsetX;
        public double StartPointOffsetX
        {
            get { return startPointOffsetX; }
            set 
            {
                if (startPointOffsetX != value)
                {
                    startPointOffsetX = value;
                    this.OnPropertyChanged(StartPointOffsetXName);
                }
            }
        }

        private double startPointOffsetY;
        public double StartPointOffsetY
        {
            get { return startPointOffsetY; }
            set
            {
                if (startPointOffsetY != value)
                {
                    startPointOffsetY = value;
                    this.OnPropertyChanged(StartPointOffsetYName);
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

            if (propertyName == OffsetXInpercentName || propertyName == BackgroundImageActualWidthName
                || propertyName == ImageContainerActualWidthName)
            {
                UpdateStartPointOffsetX();
            }
            else if (propertyName == OffsetYInpercentName || propertyName == BackgroundImageActualHeightName
                || propertyName == ImageContainerActualHeightName)
            {
                UpdateStartPointOffsetY();
            }
        }

        private void UpdateStartPointOffsetX()
        {
            // Update StartPointOffsetX 
            double offsetX = (ImageContainerActualWidth - BackgroundImageActualWidth) / 2.0;
            StartPointOffsetX = offsetX + BackgroundImageActualWidth * offsetXInPercent;
        }

        private void UpdateStartPointOffsetY()
        {
            // Update StartPointOffsetY
            double offsetY = (ImageContainerActualHeight - BackgroundImageActualHeight) / 2.0;
            StartPointOffsetY = offsetY + BackgroundImageActualHeight * offsetYInPercent;

        }
    }
}

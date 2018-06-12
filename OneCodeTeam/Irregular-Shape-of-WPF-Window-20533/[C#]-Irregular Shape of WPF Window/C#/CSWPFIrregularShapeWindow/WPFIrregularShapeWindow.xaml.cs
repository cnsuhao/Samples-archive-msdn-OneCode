/********************************** Module Header **********************************\
*Module Name:  WPFIrregularShapeWindow.xaml.cs
*Project:      CSWPFIrregularShapeWindow
*Copyright (c) Microsoft Corporation.
*
*The WPFIrregularShapeWindow.xaml.cs file defines a MainWindow Class inherited windows Class is 
*responsible for showing which present five irregular shape window  
*
*This source is subject to the Microsoft Public License.
*See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
*All other rights reserved.
*
*THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
*EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
*MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***********************************************************************************/

using System.Windows;
using System.Windows.Controls;
using System;

namespace CSWPFIrregularShapeWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WPFIrregularShapeWindow : Window
    {
        public int height;
        public int width;
        public WPFIrregularShapeWindow()
        {
            InitializeComponent();
        }


        private void Window_Click(object sender, RoutedEventArgs e)
        {

            // Generate random number added to the child windows's width and height in order to not be overlapped each other.
            Random ro = new Random();
            height = ro.Next(500);
            width = ro.Next(500);
            Button btn = e.Source as Button;
            if (btn != null)
            {
                switch(btn.Tag as string)
                {
                    case "Ellipse Window":
                        EllipseWindow ellipseWindow = new EllipseWindow();

                        // Show the child windows individually
                        ellipseWindow.Left = this.Left + this.Width+width;
                        ellipseWindow.Top = this.Top +this.Height+height;
                        ellipseWindow.Show();
                        break;
                    case "Rounded Corners Window":
                        RoundedCornersWindow roundedCornersWindow = new RoundedCornersWindow();

                        // Show the child windows individually
                        roundedCornersWindow.Left = this.Left + this.Width+width;
                        roundedCornersWindow.Top = this.Top + this.Height + height;

                        roundedCornersWindow.Show();
                        break;
                    case "Triangle Corners Window":
                        TriangleCornersWindow triangleCornersWindow = new TriangleCornersWindow();

                        // Show the child windows individually
                        triangleCornersWindow.Left = this.Left + this.Width+width;
                        triangleCornersWindow.Top = this.Top + this.Height+height;

                        triangleCornersWindow.Show();
                        break;
                    case "Popup Corners Window":
                        PopupCornersWindow popupCornersWindow = new PopupCornersWindow();

                        // Show the child windows individually
                        popupCornersWindow.Left = this.Left +this.Width+width;
                        popupCornersWindow.Top = this.Top + this.Height+height;

                        popupCornersWindow.Show();
                        break;
                    case "Picture Based Windows":
                        PictureBasedWindow picturebasedWindows = new PictureBasedWindow();

                        // Show the child windows individually
                        picturebasedWindows.Left = this.Left + this.Width+ width;
                        picturebasedWindows.Top = this.Top + this.Height+height;

                        picturebasedWindows.Show();
                        break;
                     
                    default:
                        break;
                }
            }
        }

       
    }
}

/***************************************** Module Header *****************************\
 Module Name:  MyControl.xaml.cs
 Project:      CSVSPackageStatusBar
 Copyright (c) Microsoft Corporation.
 
 In this sample, we will demo:
 1. Write highlighted text in feedback region
 2. Read text from feedback region
 3. Show progress bar in status bar
 4. Show animation in the status bar
 5. Write row, column and char to designer region
 
 This source is subject to the Microsoft Public License.
 See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
 All other rights reserved.
 
 THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*************************************************************************************/

using System.Windows.Controls;
using Microsoft.VisualStudio.Shell.Interop;
using System.Windows;

namespace Microsoft.CSVSPackageStatusBar
{
    /// <summary>
    /// Interaction logic for MyControl.xaml
    /// </summary>
    public partial class MyControl : UserControl
    {
        public IVsStatusbar SvcStatusBar { get; set; }

        public MyControl()
        {
            InitializeComponent();
        }


        private void btnWriteFeedback_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Checks to see if the status bar is frozen 
            // by calling the IsFrozen method.
            int frozen;
            SvcStatusBar.IsFrozen(out frozen);
            if (frozen == 0)
            {
                // SetColorText only displays white text on a 
                // dark blue background.
                SvcStatusBar.SetColorText("Here's some highlighted text", 0, 0);
                MessageBox.Show("Pause");
                SvcStatusBar.SetText("Done");
            }
        }

        private void btnReadFeedback_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Retrieve the status bar text.
            string text;
            SvcStatusBar.GetText(out text);
            MessageBox.Show(text);

            // Clear the status bar text.
            SvcStatusBar.FreezeOutput(0);
            SvcStatusBar.Clear();
        }

        private void btnShowProgressBar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            uint cookie = 0;
            string label = "Progress bar label...";

            // Initialize the progress bar.
            SvcStatusBar.Progress(ref cookie, 1, "", 0, 0);

            for (uint i = 0, total = 100; i <= total; i++)
            {
                // Display incremental progress.
                SvcStatusBar.Progress(ref cookie, 1, label, i, total);
                System.Threading.Thread.Sleep(10);
            }

            // Clear the progress bar.
            SvcStatusBar.Progress(ref cookie, 0, "", 0, 0);
        }

        private void btnShowAnimation_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            object icon =
                (short)Microsoft.VisualStudio.Shell.Interop.Constants.SBAI_Deploy;

            // Display the animated Visual Studio icon in the Animation region.
            // Start the animation by calling the Animation method of the status bar. 
            // Pass in 1 as the value of the first parameter, and a reference to an 
            // animated icon as the value of the second parameter.
            SvcStatusBar.Animation(1, ref icon);

            MessageBox.Show(
                "Click OK to end status bar animation.");

            // Stop the animation by calling the Animation method of the status bar. 
            // Pass in 0 as the value of the first parameter, and a reference to the 
            // animated icon as the value of the second parameter.
            SvcStatusBar.Animation(0, ref icon);
        }

        private void btnUpdateDesignerRegion_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Set insert/overstrike mode.
            object mode = 1; // Insert mode
            SvcStatusBar.SetInsMode(ref mode);

            // Display Ln ## Col ## Ch ## information.
            object ln = "##", col = "##", ch = "##";
            SvcStatusBar.SetLineColChar(ref ln, ref col, ref ch);
        }
    }
}
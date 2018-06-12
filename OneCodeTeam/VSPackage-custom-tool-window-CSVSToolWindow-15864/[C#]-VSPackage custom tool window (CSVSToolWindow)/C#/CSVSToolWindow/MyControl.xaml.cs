/****************************** Module Header ******************************\
 Module Name:  MyControl.cs
 Project:      CSVSToolWindow
 Copyright (c) Microsoft Corporation.
 
 This UserControl will be displayed as the content of the ToolWindow.
 
 This source is subject to the Microsoft Public License.
 See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
 All other rights reserved.
 
 THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/


using System.Windows.Controls;
using System.Windows.Media;

namespace Microsoft.CSVSToolWindow
{
    /// <summary>
    /// Interaction logic for MyControl.xaml
    /// </summary>
    public partial class MyControl : UserControl
    {
        public ImageSource Image
        {
            get
            {
                return imgDisplay.Source;
            }
            set
            {
                imgDisplay.Source = value;
            }

        }

        public MyControl()
        {
            InitializeComponent();
        }

    }
}
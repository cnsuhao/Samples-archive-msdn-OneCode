/****************************** Module Header ******************************\
 Module Name:  MyControl.cs
 Project:      CSVSPackageToolbox
 Copyright (c) Microsoft Corporation.
 
 This UserControl will be displayed as the content of the ToolWindow.
 
 This source is subject to the Microsoft Public License.
 See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
 All other rights reserved.
 
 THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MyCompany.CSVSToolbox
{
    // Set the display name and custom bitmap to use for this item.
    // The build action for the bitmap must be "Embedded Resource".
    [DisplayName("ToolboxMemberDemo")]
    [Description("Custom toolbox item from package LoadToolboxMembers.")]
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(MyControl), "MyControl.bmp")]
    public partial class MyControl : UserControl
    {
        public MyControl()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog opg = new OpenFileDialog();
            opg.Multiselect = false;
            if (opg.ShowDialog() == DialogResult.OK)
                this.tbFileName.Text = opg.FileName;
        }
    }
}

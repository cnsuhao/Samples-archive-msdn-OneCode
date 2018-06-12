/************************************* Module Header *************************\
* Module Name:	GetWrapperRibbon.cs
* Project:		CSVstoGetWrapperObject
* Copyright (c) Microsoft Corporation.
* 
* The CSVstoGetWrapperObject project demonstrates how to get a VSTO wrapper
* object from an existing Office COM object.
*
* This feature requires Visual Studio Tools for Office 4.0 (included in 
* Visual Studio 2012) for both design-time and runtime support.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\******************************************************************************/

using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Office.Tools.Ribbon;

namespace CSVstoGetWrapperObject
{
    public partial class GetWrapperRibbon
    {
        private GetWrapperForm getWrapperForm = null;

        private void GetWrapperRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnShowGetWrapperCS_Click(object sender, RibbonControlEventArgs e)
        {
            if (getWrapperForm == null ||
               getWrapperForm.IsDisposed)
            {
                getWrapperForm = new GetWrapperForm();
                getWrapperForm.Show(NativeWindow.FromHandle(Process.GetCurrentProcess().MainWindowHandle));
            }
            else
            {
                getWrapperForm.Activate();
            }
        }
    }
}

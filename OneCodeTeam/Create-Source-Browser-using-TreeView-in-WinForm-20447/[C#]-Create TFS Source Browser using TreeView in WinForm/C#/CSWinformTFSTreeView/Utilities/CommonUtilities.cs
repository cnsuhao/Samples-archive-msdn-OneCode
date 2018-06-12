/****************************** Module Header ******************************\
Module Name:  CommonUtilities.cs
Project:      CSWinformTFSTreeView
Copyright (c) Microsoft Corporation.

Common Utilities

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx.
All other rights reserved.
	 
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System.Windows.Forms;

namespace Microsoft.OneCode.Utilities
{
    internal class CommonUtilities
    {
        /// <summary>
        /// Show warning message box with OneCode caption
        /// </summary>
        /// <param name="message">Message String</param>
        internal static void ShowWarning(string message)
        {
            MessageBox.Show(message, UtilityResources.OneCodeCaption, 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Show error message box with OneCode caption
        /// </summary>
        /// <param name="error">Error String</param>
        internal static void ShowError(string error)
        {
            MessageBox.Show(error, UtilityResources.OneCodeCaption, 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

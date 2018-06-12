/****************************** Module Header ******************************\
* Module Name:  WorkFlowRibbon.cs
* Project:      CSOutlookCallWCFInteractWithWF
* Copyright(c) Microsoft Corporation.
* 
* This Class is to create ribbon of outlook, we can show Leave main form via 
* this ribbon.
*
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/


using Microsoft.Office.Tools.Ribbon;

namespace CSOutlookCallWCFInteractWithWF
{
    public partial class WorkFlowRibbon
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        /// <summary>
        /// Start Leave WorkFlow 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeaveWF_Click(object sender, RibbonControlEventArgs e)
        {
            // Show the Leave workflow Main Form
            LeaveMainForm createLeaveForm = new LeaveMainForm();
            createLeaveForm.ShowDialog();
        }
    }
}

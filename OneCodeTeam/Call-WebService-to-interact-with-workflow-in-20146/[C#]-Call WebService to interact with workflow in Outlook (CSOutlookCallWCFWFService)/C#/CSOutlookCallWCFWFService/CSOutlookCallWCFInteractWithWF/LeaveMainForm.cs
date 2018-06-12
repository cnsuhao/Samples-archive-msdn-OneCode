/****************************** Module Header ******************************\
* Module Name:   LeaveMainForm.cs
* Project:       CSOutlookCallWCFInteractWithWF
* Copyright (c)  Microsoft Corporation.
* 
* The Leave Main Form. It calls WCF service to interact with workflow.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Windows.Forms;
using CSOutlookCallWCFInteractWithWF.ServiceReference1;

namespace CSOutlookCallWCFInteractWithWF
{
    public partial class LeaveMainForm : Form
    {
        // Initialize a new instance of Service Client 
        LeaveServiceClient leave = new LeaveServiceClient();

        // Constructor function
        public LeaveMainForm()
        {
            InitializeComponent();
            BindListView();
        }

        /// <summary>
        /// Get pending list from database and bind the list to ListView control 
        /// </summary>
        private void BindListView()
        {
            lstViewPendingLeaves.Items.Clear();
            ListViewItem itemsource = new ListViewItem();
            Leave[] leaves = leave.GetLeaveList();
            foreach (var l in leaves)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Add(l.LeaveID.ToString());
                item.SubItems.Add(l.LeaveName);
                item.SubItems.Add(l.LeaveDay.ToString());
                item.SubItems.Add(l.Comment);
                item.SubItems.Add(l.Status);
                lstViewPendingLeaves.Items.Add(item);
            }    
        }

        /// <summary>
        /// Create a Leave WorkFlow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbName.Text)||string.IsNullOrWhiteSpace(tbDay.Text))
            {
                MessageBox.Show("Name or Day cann't be empty");
                 return;
            }

            try
            {
                leave.CreateLeave(tbName.Text.Trim(), tbDay.Text.Trim());

                // Clear input argument
                tbName.Clear();
                tbDay.Clear();
                MessageBox.Show("Create Leave request successfully.");
                BindListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occurs, The exception is :" + ex.Message);
            }
        }

        /// <summary>
        /// Approve leave request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (lstViewPendingLeaves.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a Leave Request to approve or reject", "Tip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string leaveGuid = lstViewPendingLeaves.SelectedItems[0].SubItems[1].Text;
                leave.AuditingLeave(leaveGuid, "Yes");
                MessageBox.Show("Approve Successfully");
                BindListView();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Exception occurs, The exception is :" + ex.Message);
            }
        }

        /// <summary>
        /// Reject leave request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReject_Click(object sender, EventArgs e)
        {
            if (lstViewPendingLeaves.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a Leave Request to approve or reject", "Tip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string leaveGuid = lstViewPendingLeaves.SelectedItems[0].SubItems[1].Text;
                leave.AuditingLeave(leaveGuid, "No");
                MessageBox.Show("Reject Successfully");
                BindListView();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Exception occurs, The exception is :"+ex.Message);
            }
        }
    }
}

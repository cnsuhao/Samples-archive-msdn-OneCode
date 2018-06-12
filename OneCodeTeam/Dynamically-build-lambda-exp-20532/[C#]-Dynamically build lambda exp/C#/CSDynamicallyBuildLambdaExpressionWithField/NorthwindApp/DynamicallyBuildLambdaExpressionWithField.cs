/********************************** Module Header **********************************\
* Module Name:  DynamicallyBuildLambdaExpression.cs
* Project:      CSDynamicallyBuildLambdaExpressionWithField
* Copyright (c) Microsoft Corporation.
*
* The DynamicallyBuildLambdaExpression.cs file defines a Winform which is used to demonstrate
* how to show result into DataGridView Control and how to select condition.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
*
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
* EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
* MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***********************************************************************************/


using System;
using System.Linq;
using DynamicCondition;

namespace NorthwindApp
{
    public partial class DynamicBuildLambdaExpression
    {
        internal DynamicBuildLambdaExpression()
        {
            InitializeComponent();
        }

        private NorthwindDataContext db = new NorthwindDataContext();

        /// <summary>
        /// Load the list of fields into the control when Winform loads.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Load the list of fields into the control
            ConditionBuilder1.SetDataSource(db.Orders);
        }

        /// <summary>
        /// Dynamically generate LINQ query and put it into DataGridView Control 
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Get the Condition out of the control
            var c = ConditionBuilder1.GetCondition<Order>();

            // Filter out all Orders that don't match the Condition
            // Note that the query does not actually get executed yet to due to deferred execution
            var filteredQuery = db.Orders.Where(c);

            // We can now perform any other operations (such as Order By or Select) on filteredQuery
            var query = from row in filteredQuery
                        orderby row.OrderDate, row.OrderID
                        select row;

            // Executes the query and displays the results in DataGridView1
            dgResult.DataSource = query;
        }

        /// <summary>
        /// Property DefaultInstance
        /// </summary>
        private static DynamicBuildLambdaExpression _defaultInstance;
        public static DynamicBuildLambdaExpression DefaultInstance
        {
            get
            {
                if (_defaultInstance == null)
                    _defaultInstance = new DynamicBuildLambdaExpression();
                return _defaultInstance;
            }
        }
    }

}
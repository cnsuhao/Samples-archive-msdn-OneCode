/****************************** Module Header ******************************\
Module Name:  ClonedDataTable.cs
Project:      CSDataTableUpdate
Copyright (c) Microsoft Corporation.

In this sample, we will demonstrate how to update the structure and constraints 
of the destination table after DataTable.Clone.
ClonedDataTable class will return a destiantion table after construct and
includes all the updating events.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.ComponentModel;

namespace CSDataTableUpdate
{
    public class ClonedDataTable
    {
        private DataTable sourceTable;
        private DataTable destinationTable;

        public ClonedDataTable(DataTable source)
        {
            sourceTable = source;
            // set the cloned result
            destinationTable = sourceTable.Clone();
        }

        public void UpdateAddedColumn()
        {
            sourceTable.Columns.CollectionChanged +=
                new CollectionChangeEventHandler(ColumnAdded);
        }

        public void UpdateDeletedColumn()
        {
            sourceTable.Columns.CollectionChanged +=
                new CollectionChangeEventHandler(ColumnDeleted);
        }

        public void UpdateUniqueConstraint()
        {
            sourceTable.Constraints.CollectionChanged +=
                new CollectionChangeEventHandler(UniqueConstraint_Changed);
        }

        public void UpdateForeignKeyConstraint()
        {
            sourceTable.Constraints.CollectionChanged +=
                new CollectionChangeEventHandler(ForeignKeyConstraint_Changed);
        }

        /// <summary>
        /// After the source table adds a column, the method will be trigged and add the same 
        /// column in destination table.
        /// </summary>
        void ColumnAdded(object sender, System.ComponentModel.CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Add)
            {
                DataColumn column = e.Element as DataColumn;

                if (column != null)
                {
                    DataColumn newColumn =
                        new DataColumn(column.ColumnName, column.DataType, column.Expression, column.ColumnMapping);

                    if (!destinationTable.Columns.Contains(newColumn.ColumnName))
                    {
                        destinationTable.Columns.Add(newColumn);
                    }
                }
            }
        }

        /// <summary>
        /// After the source table deletes a column, the method will be trigged and delete the same 
        /// column in destination table.
        /// </summary>
        void ColumnDeleted(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Remove)
            {
                DataColumn column = e.Element as DataColumn;

                if (column != null)
                {
                    if (destinationTable.Columns.Contains(column.ColumnName))
                    {
                        destinationTable.Columns.Remove(column.ColumnName);
                    }
                }
            }
        }

        /// <summary>
        /// After the source table changes the UniqueConstraint, the method will be trigged and change  
        /// the same UniqueConstraint in destination table.
        /// </summary>
        void UniqueConstraint_Changed(object sender, CollectionChangeEventArgs e)
        {
            UniqueConstraint constraint = e.Element as UniqueConstraint;

            if (constraint == null)
            {
                return;
            }

            String constraintName = constraint.ConstraintName;

            if (e.Action == CollectionChangeAction.Add)
            {
                DataColumn[] columns = new DataColumn[constraint.Columns.Count()];
                Boolean isPrimaryKey = constraint.IsPrimaryKey;

                // Get the columns used in new constraint from the destiantion table.
                for (Int32 i = 0; i < constraint.Columns.Count(); i++)
                {
                    String columnName = constraint.Columns[i].ColumnName;

                    if (destinationTable.Columns.Contains(columnName))
                    {
                        columns[i] = destinationTable.Columns[columnName];
                    }
                    else
                    {
                        return;
                    }
                }

                UniqueConstraint newConstraint = new UniqueConstraint(constraintName, columns, isPrimaryKey);

                if (!destinationTable.Constraints.Contains(constraintName))
                {
                    destinationTable.Constraints.Add(newConstraint);
                }

            }
            else if (e.Action == CollectionChangeAction.Remove)
            {
                if (destinationTable.Constraints.Contains(constraintName))
                {
                    destinationTable.Constraints.Remove(constraintName);
                }
            }

        }

        /// <summary>
        /// After the source table changes the ForeignKeyConstraint, the method will be trigged and change  
        /// the same ForeignKeyConstraint in destination table.
        /// </summary>
        void ForeignKeyConstraint_Changed(object sender, CollectionChangeEventArgs e)
        {
            ForeignKeyConstraint constraint = e.Element as ForeignKeyConstraint;

            if (constraint == null)
            {
                return;
            }

            // If the source and destination are not in the same DataSet, we won't change the ForeignKeyConstraint.
            if (sourceTable.DataSet != destinationTable.DataSet)
            {
                return;
            }

            String constraintName = constraint.ConstraintName;

            if (e.Action == CollectionChangeAction.Add)
            {
                DataColumn[] columns = new DataColumn[constraint.Columns.Count()];
                DataColumn[] parentColumns = constraint.RelatedColumns;

                // Get the columns used in new constraint from the destination table.
                for (int i = 0; i < constraint.Columns.Count(); i++)
                {
                    String columnName = constraint.Columns[i].ColumnName;

                    if (destinationTable.Columns.Contains(columnName))
                    {
                        columns[i] = destinationTable.Columns[columnName];
                    }
                    else
                    {
                        return;
                    }
                }

                ForeignKeyConstraint newConstraint = new ForeignKeyConstraint(constraintName, parentColumns, columns);
                newConstraint.AcceptRejectRule = constraint.AcceptRejectRule;
                newConstraint.DeleteRule = constraint.DeleteRule;
                newConstraint.UpdateRule = constraint.UpdateRule;

                if (!destinationTable.Constraints.Contains(constraintName))
                {
                    destinationTable.Constraints.Add(newConstraint);
                }
            }
            else if (e.Action == CollectionChangeAction.Remove)
            {
                if (destinationTable.Constraints.Contains(constraintName))
                {
                    destinationTable.Constraints.Remove(constraintName);
                }
            }
        }

        // return the destination table.
        public DataTable DestinationTable
        {
            get { return destinationTable; }
        }
    }
}

/****************************** Module Header ******************************\
* Module Name:    MultiFiltering..cs
* Project:        CSASPNETMultiFiltering
* Copyright (c) Microsoft Corporation
*
* Store each filtering condition as a record.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
\*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;

namespace CSASPNETMultiFiltering
{

    public partial class MultiFiltering
    {
        // Keep all column and their types
        private DataTable AllColumns { get; set; }


        /// <summary>
        /// This class is a structure of columns
        /// to be bound to my user control. Because
        /// this class can be only used in the user
        /// control, so this is a protected nested
        /// class.
        /// </summary>

        [Serializable]
        protected class Structure : ICloneable
        {
            public List<string> ColumnNames { get; set; }
            public List<string> Operations { get; set; }
            public List<string> Relations { get { return new List<string>() { "And", "Or" }; } }

            // This is bound field
            public string EqualValue { get; set; }
            public int ColumnIndex { get; set; }
            public int OperationIndex { get; set; }
            public int RelationIndex { get; set; }

            // This field illistrates the type of your field
            public Type DataType { get; set; }

            public Structure()
            {
                ColumnIndex = 0;
                OperationIndex = 0;
                RelationIndex = 0;
                EqualValue = "";
            }

            // Copy itself to create multiple filter
            public object Clone()
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    BinaryFormatter f = new BinaryFormatter();
                    f.Serialize(ms, this);
                    ms.Position = 0;
                    return f.Deserialize(ms);
                }
            }
        }

        /// <summary>
        /// According to the specific type of structure,set proper operations.
        /// </summary>
        protected Structure SetSpecificFieldType(Structure stu)
        {
            Structure s = stu;
            s.Operations = new List<string>();

            s.Operations.Add("=");
            s.Operations.Add("<>");
            s.DataType = AllColumns.Columns[s.ColumnIndex].DataType;

            if (AllColumns.Columns[s.ColumnIndex].DataType == typeof(string))
            {
                s.Operations.Add("Like");
            }
            else if (AllColumns.Columns[s.ColumnIndex].DataType != typeof(bool))
            {
                s.Operations.Add(">");
                s.Operations.Add(">=");
                s.Operations.Add("<");
                s.Operations.Add("<=");
            }
            return s;
        }

        /// <summary>
        /// Add the struct to the list for being shown
        /// </summary>
        protected List<Structure> AddStruct(List<Structure> structures)
        {
            List<Structure> ss = structures;
            Structure s = null;

            if (ss == null)
            {

                ss = new List<Structure>();
                s = new Structure();
                s.ColumnNames = new List<string>();

                foreach (DataColumn item in AllColumns.Columns)
                {
                    if (item.DataType != typeof(byte[]))
                    {
                        s.ColumnNames.Add(item.ColumnName);
                    }
                }
                s = SetSpecificFieldType(s);
            }
            else
            {
                s = (Structure)structures[structures.Count - 1].Clone();
            }
            ss.Add(s);
            return ss;

        }


    }
}
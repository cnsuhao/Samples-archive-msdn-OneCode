/****************************** Module Header ******************************\
Module Name:  Course.cs
Project:      CSDataTableCustomType
Copyright (c) Microsoft Corporation.

This sample demonstrates how to use the custom type in DataTable.
This file contains the definition of the custom type.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Text;
using System.Xml.Serialization;

namespace CSDataTableCustomType
{
    public class Course : IComparable<Course>, IComparable, IXmlSerializable
    {
        #region Properties
        public String CourseId { get; set; }
        public String Title { get; set; }
        public Int32 Credits { get; set; }
        #endregion

        #region Implement the IComparable Interface
        /// <summary>
        /// Implement the generic IComparable interface.
        /// </summary>
        /// <param name="other">It's used to compare with this object.</param>
        /// <returns></returns>
        public int CompareTo(Course other)
        {
            if (other == null)
                return 1;
            else return this.CourseId.CompareTo(other.CourseId);
        }

        /// <summary>
        /// Implement the IComparable interface. 
        /// When we set a column as the primary key in DataTable, the DataTable need to make 
        /// sure that every value in the primary key column is unique. So DataTable will use 
        /// this method to compare the values.
        /// And when we sort the DataTable by this type, DataTable will also use this method.
        /// </summary>
        /// <param name="obj">It's used to compare with this object.</param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            Course other = obj as Course;
            if (other != null)
                return this.CompareTo(other);
            else throw new ArgumentException("Object is not a Course");
        }

        #endregion

        #region Implement the IXmlSerializable Interface
        // We implement the IXmlSerializable interface to convert this object with Xml. 
        // It may be a little harder than SerializableAttribute, but we can get more control.

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Create this object from the Xml.
        /// </summary>
        /// <param name="reader"></param>
        public void ReadXml(System.Xml.XmlReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException("reader is null");

            // Because there may be many types of node, we first get the Course node.
            reader.ReadStartElement("Course");

            CourseId = reader.ReadElementString("CourseId");
            Title = reader.ReadElementString("Title");

            String CreditsString = reader.ReadElementString("Credits");
            int credit = 0;
            if (Int32.TryParse(CreditsString, out credit))
                Credits = credit;
            else Credits = -1;

            reader.ReadEndElement();
        }

        /// <summary>
        /// Write this object into Xml.
        /// </summary>
        /// <param name="writer"></param>
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException("writer is null");

            writer.WriteElementString("CourseId", CourseId);
            writer.WriteElementString("Title", Title);
            writer.WriteElementString("Credits", Credits.ToString());
        }
        #endregion

        public override string ToString()
        {
            return String.Format("CourseId:{0,-10} Title:{1,-15} Credits:{2}", CourseId, Title, Credits);
        }
    }
}

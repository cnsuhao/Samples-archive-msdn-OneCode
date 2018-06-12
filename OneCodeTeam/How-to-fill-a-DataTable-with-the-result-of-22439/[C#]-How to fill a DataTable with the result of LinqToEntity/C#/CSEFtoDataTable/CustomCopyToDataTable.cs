/****************************** Module Header ******************************\
Module Name:  CustomCopyToDataTable.cs
Project:      CSEFtoDataTable
Copyright (c) Microsoft Corporation.

This sample demonstrates how to fill a DataTable with the result of the Linq 
to Entity query.
This file demonstrates how to implement two custom CopyToDataTable<T> extension 
methods that accept a generic parameter T of a type other than DataRow.The logic 
to create a DataTable from an IEnumerable<T> source is contained in the 
ObjectShredder<T> class, which is then wrapped in two overloaded CopyToDataTable<T> 
extension methods. 

This source is subject to the Microsoft Public License
See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;

namespace CSEFtoDataTable
{
    public static class CustomCopyToDataTable
    {
        public static DataTable CopyToDataTable<T>(this IEnumerable<T> source)
        {
            return new ObjectShredder<T>().Shred(source, null, null);
        }

        public static DataTable CopyToDataTable<T>(this IEnumerable<T> source,
                                                    DataTable table, LoadOption? options)
        {
            return new ObjectShredder<T>().Shred(source, table, options);
        }
    }
}

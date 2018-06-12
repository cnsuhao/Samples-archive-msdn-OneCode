/****************************** Module Header ******************************\
* Module Name: DataItem.cs
* Project:     CSSL4MusicPlayer
* Copyright (c) Microsoft Corporation
*
* This is an entity class of music information. 
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/


using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace CSSL4MusicPlayer
{
    public class DataItem
    {
        private string nameItem;
        private string pathItem;

        public string NameItem
        {
            get
            {
                return nameItem;
            }
            set
            {
                nameItem = value;
            }
        }

        public string PathItem
        {
            get
            {
                return pathItem;
            }
            set
            {
                pathItem = value;
            }
        }
    }
}

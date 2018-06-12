/****************************** Module Header ******************************\
* Module Name:    MyItem.cs
* Project:        CSASPNETInheritingFromTreeNode
* Copyright (c) Microsoft Corporation
*
* This class defines the custom object which cab be used to assigned to 
* custom tree node.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

using System;


namespace CSASPNETInheritingFromTreeNode
{
    /// <summary>
    /// We can store custom objects in the tree node.
    /// All objects which are stored in View State need to be serializable.
    /// </summary>
    [Serializable]
    public class MyItem
    {
        public string Title { get; set; }
    }
}
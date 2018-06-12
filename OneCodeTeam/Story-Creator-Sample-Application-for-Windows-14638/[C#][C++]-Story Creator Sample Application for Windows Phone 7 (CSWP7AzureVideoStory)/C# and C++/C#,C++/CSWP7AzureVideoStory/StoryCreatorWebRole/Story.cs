/****************************** Module Header ******************************\
* Module Name:	Story.cs
* Project: StoryCreatorWebRole
* Copyright (c) Microsoft Corporation.
* 
* A model class representing a story.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoryCreatorWebRole
{
    public class Story
    {
        public string Name { get; set; }
        public string VideoUri { get; set; }
    }
}
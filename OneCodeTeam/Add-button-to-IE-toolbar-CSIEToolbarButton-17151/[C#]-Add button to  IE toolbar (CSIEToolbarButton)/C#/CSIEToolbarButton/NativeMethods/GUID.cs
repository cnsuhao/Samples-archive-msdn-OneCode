/****************************** Module Header ******************************\
* Module Name:  GUID.cs
* Project:	    CSIEToolbarButton
* Copyright (c) Microsoft Corporation.
* 
* This class represents a unique identifier. 
* 
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
using System.Runtime;
using System.Runtime.InteropServices;

namespace CSIEToolbarButton.NativeMethods
{
    [StructLayout(LayoutKind.Sequential)]
    public class GUID
    {
        public Guid guid;

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public GUID(Guid guid)
        {
            this.guid = guid;
        }
    }

 

}

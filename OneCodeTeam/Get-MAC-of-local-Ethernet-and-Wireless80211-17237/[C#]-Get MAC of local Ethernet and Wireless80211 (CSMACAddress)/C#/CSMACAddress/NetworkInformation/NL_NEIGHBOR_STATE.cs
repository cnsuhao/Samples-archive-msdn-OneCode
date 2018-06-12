/****************************** Module Header ******************************\
 * Module Name:  NL_NEIGHBOR_STATE.cs
 * Project:      CSMACAddress
 * Copyright (c) Microsoft Corporation.
 * 
 * The state of a network neighbor IP address.
 *  
 * http://msdn.microsoft.com/en-us/library/aa814498(VS.85).aspx
 * 
 * Syntax
 *  
 * typedef enum _NL_NEIGHBOR_STATE {
 *     NlnsUnreachable,
 *     NlnsIncomplete,
 *     NlnsProbe,
 *     NlnsDelay,
 *     NlnsStale,
 *     NlnsReachable,
 *     NlnsPermanent,
 *     NlnsMaximum,
 * } NL_NEIGHBOR_STATE, *PNL_NEIGHBOR_STATE;

 * 
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

namespace CSMACAddress.NetworkInformation
{
    internal enum NL_NEIGHBOR_STATE
    {
        NlnsUnreachable,
        NlnsIncomplete,
        NlnsProbe,
        NlnsDelay,
        NlnsStale,
        NlnsReachable,
        NlnsPermanent,
        NlnsMaximum,
    }
}

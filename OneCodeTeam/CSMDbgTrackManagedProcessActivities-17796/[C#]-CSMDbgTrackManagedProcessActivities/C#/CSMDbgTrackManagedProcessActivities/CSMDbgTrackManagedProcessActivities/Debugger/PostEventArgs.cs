/****************************** Module Header ******************************\
 * Module Name:  PostEventArgs.cs
 * Project:      CSMDbgTrackManagedProcessActivities
 * Copyright (c) Microsoft Corporation.
 * 
 * The class ErrorEventArgs defines the arguments used by the PostEvent event.
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

namespace CSMDbgTrackManagedProcessActivities.Debugger
{
    public class PostEventArgs:EventArgs
    {
        public string EventMessage { get; set; }
    }
}

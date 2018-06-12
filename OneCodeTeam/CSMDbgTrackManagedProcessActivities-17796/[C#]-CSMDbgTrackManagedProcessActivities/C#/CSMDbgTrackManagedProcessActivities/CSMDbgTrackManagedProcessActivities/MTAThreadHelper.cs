/****************************** Module Header ******************************\
 * Module Name:  MTAThreadHelper.cs
 * Project:      CSMDbgTrackManagedProcessActivities
 * Copyright (c) Microsoft Corporation.
 * 
 * The main thread of WinForm Application is STAThread, but the debugger needs
 * MTAThread,
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System.Threading;

namespace CSMDbgTrackManagedProcessActivities
{
    public class MTAThreadHelper
    {
        public static Thread RunInMTAThread(ParameterizedThreadStart start, object parameter)
        {
            Thread thread = new Thread(start);
            var result = thread.TrySetApartmentState(ApartmentState.MTA);
            thread.Start(parameter);
            return thread;
        }

        public static Thread RunInMTAThread(ThreadStart start)
        {
            Thread thread = new Thread(start);
            var result = thread.TrySetApartmentState(ApartmentState.MTA);
            thread.Start();
            return thread;
        }
    }
}

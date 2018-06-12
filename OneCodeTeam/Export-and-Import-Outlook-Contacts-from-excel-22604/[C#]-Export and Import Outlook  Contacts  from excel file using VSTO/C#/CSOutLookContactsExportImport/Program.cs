/****************************** Module Header ******************************\
* Module Name:  Program.cs
* Project:      CSOutLookContactsExportImport
* Copyright (c) Microsoft Corporation.
* 
*  The beginning class of the application
*
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CSOutLookContactsExportImport
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new OutlookContacts());
        }
    }
}

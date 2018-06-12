/****************************** Module Header ******************************\
* Module Name:  Program.cs
* Project:      CSShellPrintImageWithShellExecute
* Copyright (c) Microsoft Corporation.
* 
* This file contains the code for the CSShellPrintImageWithShellExecute sample.
* The sample demonstrates how to print an image using ShellExecute to invoke 
* ImageView_PrintTo, equivalent to right clicking on an image and printing.
* Using the printto verb with ShellExecute may have unpredictable effects since
* this may be configured differently on different operating systems.  The approach
* demonstrated here invokes ImageView directly with the correct parameters
* to directly print an image to the default printer.
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
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CSShellPrintImageWithShellExecute
{
    class Program
    {
        [STAThreadAttribute]  // Required for the OpenFileDialog.ShowDialog()
        static void Main(string[] args)
        {
            // An OpenFileDialog is simply used to request an image file from the user to print.
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images (*.jpg;*.gif;*.bmp;*.tiff;*.png)|*.jpg;*.gif;*.bmp;*.tiff;*.png";
            ofd.CheckFileExists = true;
            ofd.Multiselect = false;
            ofd.ShowDialog();
            if (ofd.FileName == null) 
                return;
            
            // GetPrinterProperty() and GetDefaultPrinter() are used to retrieve information for 
            // the parameters passed to ImageView_PrintTo.
            Win32.PrinterInfo2 prn = Win32.GetPrinterProperty(Win32.GetDefaultPrinter());
            
            // ShellExecute does the work.
            int retVal = Win32.ShellExecute(
                IntPtr.Zero, // This parameter can be null.
                String.Empty, // There is no verb being invoked in this case.

                // The next parameter actually supplies the command line used for ShellExecute.
                // We invoke ImageView_PrintTo through rundll32.exe, with the shimgvw.dll, hosting this feature.
                System.Environment.SystemDirectory + "\\rundll32.exe",  // The command line itself.

                // Command line parameters, specifying dll and ImageView_PrintTo function within it
                System.Environment.SystemDirectory + "\\shimgvw.dll,ImageView_PrintTo /pt " + 

                // Parameters passed to ImageView_PrintTo
		            "\"" + ofd.FileName + "\" " + // File to print
		            "\"" + prn.PrinterName +"\" " +  // Printer name
		            "\"" + prn.DriverName + "\" " +  // Driver name
		            "\"" + prn.PortName + "\"",   // Port name
                String.Empty, // Default directory for ShellExecute process, can be null.
                Win32.ShowCommands.SW_HIDE  // Window state for ShellExecute process, will be hidden.
                );
        }

        // These are the functions, structures and enumerations required to get printer information, 
        // using PInvoke to Win32.
        class Win32
        {
            private const int ERROR_FILE_NOT_FOUND = 2;
            private const int ERROR_INSUFFICIENT_BUFFER = 122;

            [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern int ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, 
                string lpParameters, string lpDirectory, ShowCommands nShowCmd);

            [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool GetDefaultPrinter(StringBuilder pszBuffer, ref int pcchBuffer);

            [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
            static extern bool OpenPrinter(string pPrinterName, out IntPtr phPrinter, ref PrinterDefaults pDefault);

            [DllImport("winspool.drv", SetLastError = true, CharSet = CharSet.Auto)]
            public static extern bool GetPrinter(IntPtr printerHandle, int level, IntPtr printerData, 
                int bufferSize, ref int printerDataSize);

            [DllImport("winspool.drv", SetLastError = true, CharSet = CharSet.Auto)]
            public static extern bool ClosePrinter(IntPtr printerHandle);

            [StructLayout(LayoutKind.Sequential)]
            public struct PrinterDefaults
            {
                public IntPtr pDatatype;
                public IntPtr pDevMode;
                public int DesiredAccess;
            }

            public struct PrinterInfo2
            {
                [MarshalAs(UnmanagedType.LPTStr)]
                public string ServerName;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string PrinterName;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string ShareName;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string PortName;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string DriverName;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string Comment;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string Location;
                public IntPtr DevMode;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string SepFile;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string PrintProcessor;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string Datatype;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string Parameters;
                public IntPtr SecurityDescriptor;
                public uint Attributes;
                public uint Priority;
                public uint DefaultPriority;
                public uint StartTime;
                public uint UntilTime;
                public uint Status;
                public uint Jobs;
                public uint AveragePpm;
            }

            public enum ShowCommands : int
            {
                SW_HIDE = 0,
                SW_SHOWNORMAL = 1,
                SW_NORMAL = 1,
                SW_SHOWMINIMIZED = 2,
                SW_SHOWMAXIMIZED = 3,
                SW_MAXIMIZE = 3,
                SW_SHOWNOACTIVATE = 4,
                SW_SHOW = 5,
                SW_MINIMIZE = 6,
                SW_SHOWMINNOACTIVE = 7,
                SW_SHOWNA = 8,
                SW_RESTORE = 9,
                SW_SHOWDEFAULT = 10,
                SW_FORCEMINIMIZE = 11,
                SW_MAX = 11
            }

            public enum PrinterProperty
            {
                ServerName,
                PrinterName,
                ShareName,
                PortName,
                DriverName,
                Comment,
                Location,
                PrintProcessor,
                Datatype,
                Parameters,
                Attributes,
                Priority,
                DefaultPriority,
                StartTime,
                UntilTime,
                Status,
                Jobs,
                AveragePpm
            };

            public static string GetDefaultPrinter()
            {
                int pcchBuffer = 0;
                if (GetDefaultPrinter(null, ref pcchBuffer))
                {
                    return null;
                }
                int lastWin32Error = Marshal.GetLastWin32Error();
                if (lastWin32Error == ERROR_INSUFFICIENT_BUFFER)
                {
                    StringBuilder pszBuffer = new StringBuilder(pcchBuffer);
                    if (GetDefaultPrinter(pszBuffer, ref pcchBuffer))
                    {
                        return pszBuffer.ToString();
                    }
                    lastWin32Error = Marshal.GetLastWin32Error();
                }
                if (lastWin32Error == ERROR_FILE_NOT_FOUND)
                {
                    return null;
                }
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            public static PrinterInfo2 GetPrinterProperty(string printerUncName)
            {
                var printerInfo2 = new PrinterInfo2();

                var pHandle = new IntPtr();
                var defaults = new PrinterDefaults();
                try
                {
                    // Open a handle to the printer.
                    bool ok = OpenPrinter(printerUncName, out pHandle, ref defaults);

                    if (!ok)
                    {
                        // OpenPrinter failed, get the last known error and thrown it.
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    }

                    // Here we determine the size of the data we to be returned
                    // Passing in 0 for the size will force the function to return the size of the data requested
                    int actualDataSize = 0;
                    GetPrinter(pHandle, 2, IntPtr.Zero, 0, ref actualDataSize);

                    int err = Marshal.GetLastWin32Error();

                    if (err == 122)
                    {
                        if (actualDataSize > 0)
                        {
                            // Allocate memory to the size of the data requested.
                            IntPtr printerData = Marshal.AllocHGlobal(actualDataSize);
                           
                            // Retrieve the actual information this time.
                            GetPrinter(pHandle, 2, printerData, actualDataSize, ref actualDataSize);

                            // Marshal to our structure.
                            printerInfo2 = (PrinterInfo2)Marshal.PtrToStructure(printerData, typeof(PrinterInfo2));
                           
                            // We've made the conversion, now free up that memory.
                            Marshal.FreeHGlobal(printerData);
                        }
                    }
                    else
                    {
                        throw new Win32Exception(err);
                    }

                    return printerInfo2;
                }
                finally
                {
                    // Always close the handle to the printer
                    ClosePrinter(pHandle);
                }
            }
        }
    }
}

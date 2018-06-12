/****************************** Module Header ******************************\
* Module Name:  MainPage.xaml.cs
* Project:      CSSL5DIBFromClipboard
* Copyright (c) Microsoft Corporation.
* 
* This code sample demonstrates accessing the Windows Clipboard and retrieving a 
* Device Independent Bitmap (DIB) and saving the DIB to a file.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Runtime.InteropServices;

namespace CSSL5DIBFromClipboard
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveDIBOnClipboardToFile();
        }

        private void SaveDIBOnClipboardToFile()
        {
            // Check to see if we've got trust
            // http://msdn.microsoft.com/en-us/library/system.windows.application.haselevatedpermissions(v=vs.95).aspx
            if (true == Application.Current.HasElevatedPermissions)
            {
                // Get Data off the Clipboard
                bool res = NativeMethods.OpenClipboard(IntPtr.Zero);
                if (NativeMethods.IsClipboardFormatAvailable(NativeMethods.CF_DIB))
                {
                    // Save the clipboard data to this stream,
                    // the stream could also come from HttpWebRequest, File, or other source. 
                    IntPtr clipboardDataHandle = NativeMethods.GetClipboardData(NativeMethods.CF_DIB);
                    IntPtr ptr = NativeMethods.GlobalLock(clipboardDataHandle);
                    byte[] buffer = HGlobalToByteArray(ptr);
                    NativeMethods.GlobalUnlock(clipboardDataHandle);
                    NativeMethods.CloseClipboard();

                    // Pick someplace to Save the File
                    SaveFileDialog sfd = new SaveFileDialog();
                    if (true == sfd.ShowDialog())
                    {
                        Stream fs = sfd.OpenFile();

                        WriteBitmapFileToStream(buffer, fs);

                        fs.Close();
                        fs.Dispose();
                    }
                }
            }
        }

        private bool WriteBitmapFileToStream(byte[] biBuffer, Stream stream)
        {
            // Designed for 32-bit Bitmap Structures.

            // Write the BITMAPFILEHEADER data to the Stream
            // http://msdn.microsoft.com/en-us/library/dd183374(v=VS.85).aspx
            BinaryWriter bw = new BinaryWriter(stream);
            bw.Write((ushort)19778); // BM = 'B' + ('M' << 8); //=19778
            bw.Write((uint)(14 + biBuffer.GetLength(0))); // BitmapFileInfoHeader (14) + BitmapInfo size, 
            bw.Write((ushort)0);  // reserved 0
            bw.Write((ushort)0);  // reserved 0
            bw.Write((uint)54);  // Offset to bitmap data = FileInfoHeader (14) + BitmapInfoHeader (40)
            bw.Flush();

            // Write the BITMAPINFO (BITMAPINFOHEADER + Bitmap Data) to the stream.
            stream.Write(biBuffer, 0, biBuffer.GetLength(0));
            stream.Flush();

            return true;
        }

        private byte[] HGlobalToByteArray(IntPtr hGlobal)
        {
            int size = NativeMethods.GlobalSize(hGlobal);
            byte[] buffer = new byte[size];
            Marshal.Copy(hGlobal, buffer, 0, size);
            return buffer;
        }
    }
}

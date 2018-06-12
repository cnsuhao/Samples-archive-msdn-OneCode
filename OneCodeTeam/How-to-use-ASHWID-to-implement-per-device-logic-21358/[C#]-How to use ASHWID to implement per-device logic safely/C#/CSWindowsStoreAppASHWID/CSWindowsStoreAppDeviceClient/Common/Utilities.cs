/****************************** Module Header ******************************\
 * Module Name:  Utilities.cs
 * Project:      CSWindowsStoreAppDeviceClient
 * Copyright (c) Microsoft Corporation.
 * 
 * Utilities class
 *  
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using Windows.Storage.Streams;

namespace CSWindowsStoreAppDeviceClient.Common
{
    public class Utilities
    {
        /// <summary>
        /// Utility function to convert IBuffer instance to byte array.
        /// </summary>
        /// <param name="buf">IBuffer instance</param>
        /// <returns>byte arrays</returns>
        public static byte[] ConvertBufferToByteArray(IBuffer buf)
        {
            if (buf == null)
            {
                return null;
            }

            using (var dataReader = DataReader.FromBuffer(buf))
            {
                var bytes = new byte[buf.Length];
                dataReader.ReadBytes(bytes);
                return bytes;
            }
        }
    }
}

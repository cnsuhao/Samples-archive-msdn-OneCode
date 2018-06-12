/****************************** Module Header ******************************\
* Module Name:    FileInUse.cs
* Project:        CSCheckFileInUse
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to check whether a file is in use or not.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
* All other rights reserved.
*
\*****************************************************************************/
using System.IO;

/// <summary>
/// Summary description for FileInUse
/// </summary>
/// 
namespace CSCheckFileInUse
{
    public class FileInUse
    {
        public FileInUse()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        /// <summary>
        /// This function checks whether the file is in use or not.
        /// </summary>
        /// <param name="filename">File Name</param>
        /// <returns>Return True if file in use else false</returns>
        public static bool IsFileInUse(string filename)
        {
            bool locked = false;
            FileStream fs = null;
            try
            {
                fs =
                     File.Open(filename, FileMode.OpenOrCreate,
                     FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException )
            {
                locked = true;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
            return locked;
        }
    }
}
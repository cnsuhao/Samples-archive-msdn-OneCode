/****************************** Module Header ******************************\
Module Name:  CompressionArchive.cs
Project:      CSASPNETCompressFilesIntoSingleZip
Copyright (c) Microsoft Corporation.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Web;

namespace CSASPNETCompressFilesIntoSingleZip
{
    /// <summary>
    /// 
    /// </summary>
    public class CompressionArchive
    {
        private static string folderPath = HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings.GetValues("FolderPath").GetValue(0).ToString());

        private string uniqueNameForZipFile;

        private string _tempZipFilePath;
        
        public string TempZipFilePath
        {
            get { return _tempZipFilePath; }
            set { _tempZipFilePath = value; }
        }        

        public CompressionArchive()
        {
            uniqueNameForZipFile = GenerateGuid(); 
        }
        

        /// <summary>
        /// Compress to a zip file from the input files
        /// </summary>
        /// <param name="filesForCompression"></param>
        public void CompressToZipArchive(List<string> filesForCompression)
        {
           
                TempZipFilePath = HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings.GetValues("FolderPath").GetValue(0).ToString()) + uniqueNameForZipFile + ".gz";

                using (FileStream compressedFileStream = File.Create(TempZipFilePath))
                {
                    //ZipArchive class represents a package of compressed files in the zip archive format
                    using (ZipArchive archive = new ZipArchive(compressedFileStream, ZipArchiveMode.Update))
                    {
                        foreach (string fileToCompress in filesForCompression)
                        {
                            FileInfo fileToCompressDetails = new FileInfo(fileToCompress);
                            // Loop through each entry and add to ZipArchive 
                            ZipArchiveEntry readmeEntry = archive.CreateEntryFromFile(fileToCompress, fileToCompressDetails.Name);
                        }
                    }
                }
        }

        /// <summary>
        /// Sends the Zip over HTTP i.e. Download Prompt
        /// </summary>
        /// <param name="zipFilePath"></param>
        public void DownloadFile()
        {
            FileInfo zipPathDetails = new FileInfo(TempZipFilePath);
            HttpContext.Current.Response.ContentType = "application/zip";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + zipPathDetails.Name);
            HttpContext.Current.Response.AddHeader("TempFileName", TempZipFilePath);   // Will be used in Application_EndRequest for file deletion
            HttpContext.Current.Response.WriteFile(TempZipFilePath);
            HttpContext.Current.ApplicationInstance.CompleteRequest();    
        }

        /// <summary>
        /// Generate a unique GUID, can be used for creating a unique file name for temp Zip file
        /// </summary>
        /// <returns> Unique ID</returns>
        private string GenerateGuid()
        {
            string result = "";
            double innerLoop, outerLoop;
            Random uniqueGUID = new Random();
            for (outerLoop = 0; outerLoop < 10; outerLoop++)
            {
                if (outerLoop == 3 || outerLoop == 6 || outerLoop == 9)
                    result = result + '-';
                innerLoop = Math.Floor(Convert.ToDouble(uniqueGUID.Next(9999)));
                result = result + innerLoop;
            }
            return result;
        }        
    }
}
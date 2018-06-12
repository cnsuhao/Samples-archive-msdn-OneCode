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
using System.IO.Packaging;

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

            TempZipFilePath = HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings.GetValues("FolderPath").GetValue(0).ToString()) + uniqueNameForZipFile + ".gz"; // We can .zip extension also


                    foreach (string fileToCompress in filesForCompression)
                    {
                        // Loop through each entry and add to ZipArchive 
                        CreateZip(TempZipFilePath, fileToCompress);
                    }
        }

        /// <summary>
        /// Sends the Zip over HTTP i.e. Download Prompt
        /// </summary>
        /// <param name="zipFilePath"></param>
        public void DownloadFile()
        {
            FileInfo zipPathDetails = new FileInfo(TempZipFilePath);
            if (IsGZipSupported())
            {
                HttpContext.Current.Response.Filter = new System.IO.Compression.GZipStream(HttpContext.Current.Response.Filter, System.IO.Compression.CompressionMode.Compress);
                HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip"); //decompressing the content before rendering
            }
            HttpContext.Current.Response.ContentType = "application/zip";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + zipPathDetails.Name);
            HttpContext.Current.Response.AddHeader("TempFileName", TempZipFilePath);   // Will be used in Application_EndRequest for file deletion
            
            HttpContext.Current.Response.WriteFile(TempZipFilePath);            
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }


        /// <summary>
        /// Determines if GZip is supported
        /// </summary>
        /// <returns></returns>
        public static bool IsGZipSupported()
        {
            string AcceptEncoding = HttpContext.Current.Request.Headers["Accept-Encoding"];
            if (!string.IsNullOrEmpty(AcceptEncoding) && AcceptEncoding.Contains("gzip") || AcceptEncoding.Contains("deflate"))
                return true;
            return false;
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

        /// <summary>
        /// using System.IO.Packaging to add files to a single zip file
        /// One cavet of using the ZipPackage to create Zips is that Packages contain a content type manifest named "[Content_Types].xml". 
        /// </summary>
        /// <param name="tempZipPath"></param>
        /// <param name="inputFileToAdd"></param>
        private void CreateZip(string tempZipPath, string inputFileToAdd)
        {
            using (Package package = Package.Open(tempZipPath, FileMode.OpenOrCreate))
            {
                string destFilename = ".\\" + Path.GetFileName(inputFileToAdd);
                Uri uri = PackUriHelper.CreatePartUri(new Uri(destFilename, UriKind.Relative));

                // Checking if a file already exists in the Zip
                if (package.PartExists(uri))
                {
                    package.DeletePart(uri);
                }

                PackagePart part = package.CreatePart(uri, "", CompressionOption.Normal);

                using (FileStream fileStream = new FileStream(inputFileToAdd, FileMode.Open, FileAccess.Read))
                {                    
                        CopyStream(fileStream, part.GetStream());                    
                }
            }
        }

        /// <summary>
        /// Copies data from a source stream to a target stream.
        /// </summary>
        /// <param name="source">The source stream to copy from.</param>
        /// <param name="target">The destination stream to copy to.</param>
        private void CopyStream(System.IO.FileStream source, System.IO.Stream target)
        {
            const int bufSize = 0x1000;
            byte[] buf = new byte[bufSize];
            int bytesRead = 0;
            while ((bytesRead = source.Read(buf, 0, bufSize)) > 0)
                target.Write(buf, 0, bytesRead);
        }
    }
}
/***************************** Module Header ******************************\
 Module Name:	Form1.cs
 Project:		CSAzureUploadBigFile
 Copyright (c) Microsoft Corporation.
 
 This sample demonstrates how to upload a big file to azure blob storage.

 This source is subject to the Microsoft Public License.
 See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
 All other rights reserved.
 
 THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
**************************************************************************/
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSAzureUploadBigFile
{
    public partial class Form1 : Form
    {
        private string storageConnectionString
    = "DefaultEndpointsProtocol=https;AccountName={account-name};AccountKey={account-key}";

        private int bufferSize = 40 * 1024;
        private int blockCount = 0;
        private List<string> blockIds = new List<string>();
        private string filePath;
        private bool isCanceled = false;
        public Form1()
        {
            InitializeComponent();
            btnStart.Enabled = false;
            btnEnd.Enabled = false;
        }

        private void uploadBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            UploadBigFile(uploadBackgroundWorker, e);
        }

        private void uploadBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void uploadBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!isCanceled)
            {
                blockIds.Clear();
            }
            btnStart.Enabled = true;
            browseFile.Enabled = true;
            btnEnd.Enabled = false;
        }

        private void browseFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = filePath = openFileDialog1.FileName;
                using (FileStream fileStream = File.OpenRead(filePath))
                {
                    blockCount = (int)(fileStream.Length / bufferSize) + 1;
                }
                progressBar1.Maximum = blockCount;
            }
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                btnStart.Enabled = true;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!uploadBackgroundWorker.IsBusy)
            {
                btnStart.Enabled = false;
                browseFile.Enabled = false;
                btnEnd.Enabled = true;
                uploadBackgroundWorker.RunWorkerAsync();
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            browseFile.Enabled = true;
            btnEnd.Enabled = false;
            uploadBackgroundWorker.CancelAsync();
            isCanceled = true;
        }

        private void UploadBigFile(BackgroundWorker worker, DoWorkEventArgs e)
        {
            //bufferSize 40KB
            byte[] bufferBytes = new byte[bufferSize];
            string fileName = Path.GetFileName(filePath);

            CloudBlockBlob blob = GetBlobkBlob(fileName);

            using (FileStream fileStream = File.OpenRead(filePath))
            {
                //Get the total count of block
                blockCount = (int)(fileStream.Length / bufferSize) + 1;
                Int64 currentBlockSize = 0;
                int currentCount = blockIds.Count();
                fileStream.Seek(bufferSize * currentCount, SeekOrigin.Begin);
                for (int i = blockIds.Count; i < blockCount; i++)
                {
                    if (worker.WorkerSupportsCancellation && worker.CancellationPending)
                    {
                        return;
                    }
                    currentBlockSize = bufferSize;
                    if (i == blockCount - 1)
                    {
                        currentBlockSize = fileStream.Length - bufferSize * i;
                        bufferBytes = new byte[currentBlockSize];
                    }
                    if (currentBlockSize == 0) break;
                    //Get the block data
                    fileStream.Read(bufferBytes, 0, Convert.ToInt32(currentBlockSize));
                    using (MemoryStream memoryStream = new MemoryStream(bufferBytes))
                    {
                        try
                        {
                            //Get Base64-encoded block Id
                            string blockId = Convert.ToBase64String(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()));
                            //Upload the block
                            blob.PutBlock(blockId, memoryStream, null);
                            //Cache the block Id
                            blockIds.Add(blockId);
                            worker.ReportProgress(i + 1);
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
            }
            //Commit all the blocks
            blob.PutBlockList(blockIds);
            isCanceled = false;
        }

        private CloudBlockBlob GetBlobkBlob(string fileName)
        {
            var storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            CloudBlobClient blobStorage = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobStorage.GetContainerReference("mycontainer");
            container.CreateIfNotExists();

            return container.GetBlockBlobReference(fileName);
        }
    }
}

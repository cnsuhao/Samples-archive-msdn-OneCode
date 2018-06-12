/****************************** Module Header ******************************\
* Module Name:  SaveWordService.svc.cs
* Project:      JSO15SaveWordDocumentWeb
* Copyright(c)  Microsoft Corporation.
* 
* The Class is used to save all content of word document on client machine
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
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace JSO15SaveWordDocumentWeb
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SaveWordService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SaveWordService.svc or SaveWordService.svc.cs at the Solution Explorer and start debugging.
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class SaveWordService
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public string SaveAllContent(string bytestring)
        {
            string[] bytestrings = bytestring.Split(',');
            int length = bytestrings.Length;
            byte[] buffer = new byte[length];
            for (int i = 0; i < length; i++)
            {
                buffer[i] = Convert.ToByte(bytestrings[i]);
            }

            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Copy.docx";
            if (File.Exists(savePath))
            {
                try
                {
                    File.Delete(savePath);
                }
                catch
                {
                    return "0";
                }
            }

            using (FileStream savestream = new FileStream(savePath, FileMode.Create))
            {
                savestream.Write(buffer, 0, length);
            }

            return savePath;
        }
    }
}
